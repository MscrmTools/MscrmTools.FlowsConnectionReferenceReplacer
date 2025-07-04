using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.FlowsConnectionReferenceReplacer.UserControls
{
    public partial class FlowWithConnectionRefReplacementList : UserControl
    {
        private List<Entity> flows;
        private int sortingColumnIndex = 0;
        private List<Entity> sourceConnectionReferences;

        public FlowWithConnectionRefReplacementList()
        {
            InitializeComponent();
        }

        public List<Entity> SelectedFlows => lvFlows.CheckedItems.Cast<ListViewItem>().Select(f => (Entity)f.Tag).ToList();

        public Entity TargetConnectionReference { get; set; }

        public void Clear()
        {
            lvFlows.Items.Clear();
        }

        public void Display()
        {
            var targetCr = TargetConnectionReference.GetAttributeValue<string>("connectionreferencelogicalname");

            lvFlows.Items.Clear();
            lvFlows.Items.AddRange(flows
                .Where(f =>
                        (commandBar1.Text.Length == 0 || f.GetAttributeValue<string>("name").ToLower().IndexOf(commandBar1.Text.ToLower()) >= 0)
                        && sourceConnectionReferences.Any(scr => f.GetAttributeValue<string>("clientdata").IndexOf(scr.GetAttributeValue<string>("connectionreferencelogicalname")) > 0 && scr.GetAttributeValue<string>("connectionreferencelogicalname") != targetCr)
                        )
                .Select(f => new ListViewItem(f.GetAttributeValue<string>("name"))
                {
                    Tag = f,
                    SubItems =
                {
                    new ListViewItem.ListViewSubItem
                    {
                        Text = string.Join(", ", sourceConnectionReferences.Where(scr =>
                        f.GetAttributeValue<string>("clientdata").IndexOf(scr.GetAttributeValue<string>("connectionreferencelogicalname")) > 0)
                        .Select(cr => cr.GetAttributeValue<string>("connectionreferencelogicalname")))
                    },
                    new ListViewItem.ListViewSubItem
                    {
                        Text = targetCr
                    }
                }
                }).ToArray());

            if (lvFlows.Items.Count > 0)
                lvFlows.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            else
                lvFlows.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void LoadFlows(List<Entity> sourceConnectionReferences, IOrganizationService service)
        {
            this.sourceConnectionReferences = sourceConnectionReferences;

            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("name", "clientdata", "ownerid"),
                Criteria = new FilterExpression(LogicalOperator.Or)
            };

            foreach (var scr in sourceConnectionReferences)
            {
                query.Criteria.AddCondition("clientdata", ConditionOperator.Like, $"%{scr.GetAttributeValue<string>("connectionreferencelogicalname")}%");
            }

            flows = service.RetrieveMultiple(query).Entities.ToList();
        }

        public void Reset()
        {
            flows = null;
            sourceConnectionReferences = null;

            lvFlows.Items.Clear();
        }

        private void commandBar1_OnClear(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in lvFlows.Items)
            {
                item.Checked = false;
            }
        }

        private void commandBar1_OnSearchTextChanged(object sender, System.EventArgs e)
        {
            Display();
        }

        private void commandBar1_OnSelectAll(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in lvFlows.Items)
            {
                item.Checked = true;
            }
        }

        private void FlowWithConnectionRefReplacementList_Load(object sender, System.EventArgs e)
        {
            lvFlows.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvFlows_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortingColumnIndex)
                lvFlows.Sorting = lvFlows.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            else
                lvFlows.Sorting = SortOrder.Ascending;

            lvFlows.ListViewItemSorter = new ListViewItemComparer(e.Column, lvFlows.Sorting);
            sortingColumnIndex = e.Column;
        }
    }
}