namespace MscrmTools.FlowsConnectionReferenceReplacer.UserControls
{
    partial class ConnectionReferenceSelector
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvConnectionRefs = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandBar1 = new MscrmTools.FlowsConnectionReferenceReplacer.UserControls.CommandBar();
            this.SuspendLayout();
            // 
            // lvConnectionRefs
            // 
            this.lvConnectionRefs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chLogicalName});
            this.lvConnectionRefs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnectionRefs.HideSelection = false;
            this.lvConnectionRefs.Location = new System.Drawing.Point(0, 32);
            this.lvConnectionRefs.Name = "lvConnectionRefs";
            this.lvConnectionRefs.Size = new System.Drawing.Size(903, 1130);
            this.lvConnectionRefs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvConnectionRefs.TabIndex = 0;
            this.lvConnectionRefs.UseCompatibleStateImageBehavior = false;
            this.lvConnectionRefs.View = System.Windows.Forms.View.Details;
            this.lvConnectionRefs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvConnectionRefs_ColumnClick);
            this.lvConnectionRefs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvConnectionRefs_ItemChecked);
            this.lvConnectionRefs.SelectedIndexChanged += new System.EventHandler(this.lvConnectionRefs_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            // 
            // chLogicalName
            // 
            this.chLogicalName.Text = "Logical name";
            // 
            // commandBar1
            // 
            this.commandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandBar1.Location = new System.Drawing.Point(0, 0);
            this.commandBar1.Name = "commandBar1";
            this.commandBar1.Size = new System.Drawing.Size(903, 32);
            this.commandBar1.TabIndex = 1;
            this.commandBar1.OnClear += new System.EventHandler(this.commandBar1_OnClear);
            this.commandBar1.OnSearchTextChanged += new System.EventHandler(this.commandBar1_OnSearchTextChanged);
            this.commandBar1.OnSelectAll += new System.EventHandler(this.commandBar1_OnSelectAll);
            // 
            // ConnectionReferenceSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvConnectionRefs);
            this.Controls.Add(this.commandBar1);
            this.Name = "ConnectionReferenceSelector";
            this.Size = new System.Drawing.Size(903, 1162);
            this.Load += new System.EventHandler(this.ConnectionReferenceSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvConnectionRefs;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chLogicalName;
        private CommandBar commandBar1;
    }
}
