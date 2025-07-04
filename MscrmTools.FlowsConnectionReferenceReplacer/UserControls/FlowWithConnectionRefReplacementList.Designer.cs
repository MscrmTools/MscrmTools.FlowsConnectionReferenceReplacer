namespace MscrmTools.FlowsConnectionReferenceReplacer.UserControls
{
    partial class FlowWithConnectionRefReplacementList
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
            this.lvFlows = new System.Windows.Forms.ListView();
            this.chFlowName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSourceConnectionRefs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTargetConnectionRef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandBar1 = new MscrmTools.FlowsConnectionReferenceReplacer.UserControls.CommandBar();
            this.SuspendLayout();
            // 
            // lvFlows
            // 
            this.lvFlows.CheckBoxes = true;
            this.lvFlows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFlowName,
            this.chSourceConnectionRefs,
            this.chTargetConnectionRef});
            this.lvFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFlows.HideSelection = false;
            this.lvFlows.Location = new System.Drawing.Point(0, 0);
            this.lvFlows.Name = "lvFlows";
            this.lvFlows.Size = new System.Drawing.Size(1746, 994);
            this.lvFlows.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFlows.TabIndex = 0;
            this.lvFlows.UseCompatibleStateImageBehavior = false;
            this.lvFlows.View = System.Windows.Forms.View.Details;
            this.lvFlows.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvFlows_ColumnClick);
            // 
            // chFlowName
            // 
            this.chFlowName.Text = "Flow name";
            // 
            // chSourceConnectionRefs
            // 
            this.chSourceConnectionRefs.Text = "Source connection reference(s)";
            // 
            // chTargetConnectionRef
            // 
            this.chTargetConnectionRef.Text = "Target connection reference";
            // 
            // commandBar1
            // 
            this.commandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandBar1.Location = new System.Drawing.Point(0, 0);
            this.commandBar1.Name = "commandBar1";
            this.commandBar1.Size = new System.Drawing.Size(1397, 37);
            this.commandBar1.TabIndex = 2;
            this.commandBar1.OnClear += new System.EventHandler(this.commandBar1_OnClear);
            this.commandBar1.OnSearchTextChanged += new System.EventHandler(this.commandBar1_OnSearchTextChanged);
            this.commandBar1.OnSelectAll += new System.EventHandler(this.commandBar1_OnSelectAll);
            // 
            // FlowWithConnectionRefReplacementList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvFlows);
            this.Controls.Add(this.commandBar1);
            this.Name = "FlowWithConnectionRefReplacementList";
            this.Size = new System.Drawing.Size(1397, 795);
            this.Load += new System.EventHandler(this.FlowWithConnectionRefReplacementList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvFlows;
        private System.Windows.Forms.ColumnHeader chFlowName;
        private System.Windows.Forms.ColumnHeader chSourceConnectionRefs;
        private System.Windows.Forms.ColumnHeader chTargetConnectionRef;
        private CommandBar commandBar1;
    }
}
