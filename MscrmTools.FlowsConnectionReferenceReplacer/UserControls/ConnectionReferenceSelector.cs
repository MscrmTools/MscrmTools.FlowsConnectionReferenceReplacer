using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Workflow.ComponentModel.Design;

namespace MscrmTools.FlowsConnectionReferenceReplacer.UserControls
{
    public partial class ConnectionReferenceSelector : UserControl
    {
        private static List<Entity> connectionReferences;
        private string filteredConnector = "";
        private List<ListViewItem> items;
        private int sortingColumnIndex = 0;

        public ConnectionReferenceSelector()
        {
            InitializeComponent();
        }

        public event EventHandler OnSelectionChanged;

        public bool AllowMultipleSelection
        {
            get
            {
                return lvConnectionRefs.MultiSelect;
            }
            set
            {
                lvConnectionRefs.CheckBoxes = value;
                lvConnectionRefs.MultiSelect = value;
            }
        }

        public List<Entity> SelectedReferences => lvConnectionRefs.CheckBoxes ? lvConnectionRefs.CheckedItems.Cast<ListViewItem>().Select(e => (Entity)e.Tag).ToList() : lvConnectionRefs.SelectedItems.Cast<ListViewItem>().Select(e => (Entity)e.Tag).ToList();

        public void DisplayConnectionReferences()
        {
            if (items == null)
            {
                GetListViewItems();
            }

            var filteredItems = items
                 .Where(i => (string.IsNullOrEmpty(filteredConnector) || ((Entity)i.Tag).GetAttributeValue<string>("connectorid") == filteredConnector)
                 && (string.IsNullOrEmpty(commandBar1.Text) || ((Entity)i.Tag).GetAttributeValue<string>("connectionreferencedisplayname").ToLower().IndexOf(commandBar1.Text.ToLower()) >= 0))
                 .ToList();

            lvConnectionRefs.SelectedIndexChanged -= lvConnectionRefs_SelectedIndexChanged;
            lvConnectionRefs.ItemChecked -= lvConnectionRefs_ItemChecked;
            lvConnectionRefs.Items.Clear();
            lvConnectionRefs.Items.AddRange(filteredItems.ToArray());
            lvConnectionRefs.SelectedIndexChanged += lvConnectionRefs_SelectedIndexChanged;
            lvConnectionRefs.ItemChecked += lvConnectionRefs_ItemChecked;

            if (lvConnectionRefs.Items.Count > 0)
                lvConnectionRefs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            else
                lvConnectionRefs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void LoadConnectionReferences(IOrganizationService service)
        {
            connectionReferences = service.RetrieveMultiple(new QueryExpression("connectionreference")
            {
                ColumnSet = new ColumnSet("connectionreferencedisplayname", "connectionreferencelogicalname", "connectorid")
            }).Entities.ToList();

            GetListViewItems();
        }

        internal void Filter(string connector)
        {
            filteredConnector = connector;

            DisplayConnectionReferences();
            return;

            lvConnectionRefs.ItemChecked -= lvConnectionRefs_ItemChecked;
            lvConnectionRefs.SelectedIndexChanged -= lvConnectionRefs_SelectedIndexChanged;
            lvConnectionRefs.Items.Clear();

            var filteredItems = items
                .Where(i => (filteredConnector == null || ((Entity)i.Tag).GetAttributeValue<string>("connectorid") == filteredConnector)
                && (string.IsNullOrEmpty(commandBar1.Text) || ((Entity)i.Tag).GetAttributeValue<string>("connectionreferencedisplayname").ToLower().IndexOf(commandBar1.Text.ToLower()) >= 0))
                .ToArray();

            lvConnectionRefs.Items.AddRange(filteredItems);
            lvConnectionRefs.ItemChecked += lvConnectionRefs_ItemChecked;
            lvConnectionRefs.SelectedIndexChanged += lvConnectionRefs_SelectedIndexChanged;
        }

        private bool CheckConnectorSelection()
        {
            var connector = ((Entity)lvConnectionRefs.Items.Cast<ListViewItem>().First().Tag).GetAttributeValue<string>("connectorid");
            foreach (ListViewItem item in lvConnectionRefs.CheckedItems)
            {
                if (connector != ((Entity)item.Tag).GetAttributeValue<string>("connectorid"))
                {
                    MessageBox.Show(this, "Please select only connection references for the same connector", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void commandBar1_OnClear(object sender, EventArgs e)
        {
            lvConnectionRefs.ItemChecked -= lvConnectionRefs_ItemChecked;
            lvConnectionRefs.SelectedIndexChanged -= lvConnectionRefs_SelectedIndexChanged;
            foreach (ListViewItem item in lvConnectionRefs.Items)
            {
                item.Checked = false;
            }
            lvConnectionRefs.ItemChecked += lvConnectionRefs_ItemChecked;
            lvConnectionRefs.SelectedIndexChanged += lvConnectionRefs_SelectedIndexChanged;

            DisplayConnectionReferences();
            OnSelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void commandBar1_OnSearchTextChanged(object sender, EventArgs e)
        {
            DisplayConnectionReferences();
        }

        private void commandBar1_OnSelectAll(object sender, EventArgs e)
        {
            lvConnectionRefs.ItemChecked -= lvConnectionRefs_ItemChecked;
            lvConnectionRefs.SelectedIndexChanged -= lvConnectionRefs_SelectedIndexChanged;
            foreach (ListViewItem item in lvConnectionRefs.Items)
            {
                item.Checked = true;

                if (!CheckConnectorSelection())
                {
                    break;
                }
            }
            lvConnectionRefs.ItemChecked += lvConnectionRefs_ItemChecked;
            lvConnectionRefs.SelectedIndexChanged += lvConnectionRefs_SelectedIndexChanged;

            lvConnectionRefs_ItemChecked(lvConnectionRefs, new ItemCheckedEventArgs(lvConnectionRefs.CheckedItems[0]));
        }

        private void ConnectionReferenceSelector_Load(object sender, EventArgs e)
        {
            lvConnectionRefs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void GetListViewItems()
        {
            items = connectionReferences
               .Where(cr => string.IsNullOrEmpty(filteredConnector) || cr.GetAttributeValue<string>("connectorid") == filteredConnector)
             .Where(cr => string.IsNullOrEmpty(commandBar1.Text) || cr.GetAttributeValue<string>("connectionreferencedisplayname").ToLower().IndexOf(commandBar1.Text.ToLower()) >= 0)
              .Select(e =>
              new ListViewItem(e.GetAttributeValue<string>("connectionreferencedisplayname"))
              {
                  Tag = e,
                  SubItems =
                  {
                        new ListViewItem.ListViewSubItem(){
                            Text = e.GetAttributeValue<string>("connectionreferencelogicalname") }
                  }
              }).ToList();
        }

        private void lvConnectionRefs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortingColumnIndex)
                lvConnectionRefs.Sorting = lvConnectionRefs.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            else
                lvConnectionRefs.Sorting = SortOrder.Ascending;

            lvConnectionRefs.ListViewItemSorter = new ListViewItemComparer(e.Column, lvConnectionRefs.Sorting);
            sortingColumnIndex = e.Column;
        }

        private void lvConnectionRefs_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OnSelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void lvConnectionRefs_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectionChanged?.Invoke(this, EventArgs.Empty);

            if (lvConnectionRefs.CheckBoxes)
            {
                foreach (ListViewItem item in lvConnectionRefs.SelectedItems)
                {
                    item.Checked = true;
                }
            }
        }
    }
}