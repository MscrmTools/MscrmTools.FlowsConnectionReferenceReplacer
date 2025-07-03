using System;
using System.Windows.Forms;

namespace MscrmTools.FlowsConnectionReferenceReplacer.UserControls
{
    public partial class CommandBar : System.Windows.Forms.UserControl
    {
        public CommandBar()
        {
            InitializeComponent();
        }

        public event EventHandler OnClear;

        public event EventHandler OnSearchTextChanged;

        public event EventHandler OnSelectAll;

        public bool AllowSelectAll { set
            {
                llSelectAll.Enabled = value;

            } 
        }

        public string Text => txtSearch.Text;

        private void Link_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == llClearAll) OnClear?.Invoke(this, EventArgs.Empty);
            if (sender == llSelectAll) OnSelectAll?.Invoke(this, EventArgs.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OnSearchTextChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}