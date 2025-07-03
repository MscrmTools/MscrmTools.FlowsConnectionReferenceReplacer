namespace MscrmTools.FlowsConnectionReferenceReplacer
{
    partial class MyPluginControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.crsSource = new MscrmTools.FlowsConnectionReferenceReplacer.UserControls.ConnectionReferenceSelector();
            this.scSecondary = new System.Windows.Forms.SplitContainer();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.crsTarget = new MscrmTools.FlowsConnectionReferenceReplacer.UserControls.ConnectionReferenceSelector();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.wccr = new MscrmTools.FlowsConnectionReferenceReplacer.UserControls.FlowWithConnectionRefReplacementList();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.tsbFindFlows = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateFLows = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSecondary)).BeginInit();
            this.scSecondary.Panel1.SuspendLayout();
            this.scSecondary.Panel2.SuspendLayout();
            this.scSecondary.SuspendLayout();
            this.gbTarget.SuspendLayout();
            this.gbSummary.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 39);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbSource);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scSecondary);
            this.scMain.Size = new System.Drawing.Size(1414, 844);
            this.scMain.SplitterDistance = 327;
            this.scMain.TabIndex = 5;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.crsSource);
            this.gbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSource.Location = new System.Drawing.Point(0, 0);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(327, 844);
            this.gbSource.TabIndex = 1;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Connection references to be replaced";
            // 
            // crsSource
            // 
            this.crsSource.AllowMultipleSelection = true;
            this.crsSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crsSource.Location = new System.Drawing.Point(3, 18);
            this.crsSource.Name = "crsSource";
            this.crsSource.Size = new System.Drawing.Size(321, 823);
            this.crsSource.TabIndex = 0;
            this.crsSource.OnSelectionChanged += new System.EventHandler(this.crsSource_OnSelectionChanged);
            // 
            // scSecondary
            // 
            this.scSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSecondary.Location = new System.Drawing.Point(0, 0);
            this.scSecondary.Name = "scSecondary";
            // 
            // scSecondary.Panel1
            // 
            this.scSecondary.Panel1.Controls.Add(this.gbTarget);
            // 
            // scSecondary.Panel2
            // 
            this.scSecondary.Panel2.Controls.Add(this.gbSummary);
            this.scSecondary.Size = new System.Drawing.Size(1083, 844);
            this.scSecondary.SplitterDistance = 361;
            this.scSecondary.TabIndex = 0;
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.crsTarget);
            this.gbTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTarget.Location = new System.Drawing.Point(0, 0);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(361, 844);
            this.gbTarget.TabIndex = 1;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Connection reference to apply";
            // 
            // crsTarget
            // 
            this.crsTarget.AllowMultipleSelection = false;
            this.crsTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crsTarget.Location = new System.Drawing.Point(3, 18);
            this.crsTarget.Name = "crsTarget";
            this.crsTarget.Size = new System.Drawing.Size(355, 823);
            this.crsTarget.TabIndex = 0;
            // 
            // gbSummary
            // 
            this.gbSummary.Controls.Add(this.wccr);
            this.gbSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSummary.Location = new System.Drawing.Point(0, 0);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(718, 844);
            this.gbSummary.TabIndex = 0;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Flow(s) you want to update";
            // 
            // wccr
            // 
            this.wccr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wccr.Location = new System.Drawing.Point(3, 18);
            this.wccr.Name = "wccr";
            this.wccr.Size = new System.Drawing.Size(712, 823);
            this.wccr.TabIndex = 0;
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoad,
            this.tssSeparator1,
            this.tsbFindFlows,
            this.tsbUpdateFLows});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1414, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbLoad
            // 
            this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(78, 36);
            this.tsbLoad.Text = "Load";
            this.tsbLoad.Click += new System.EventHandler(this.tsbLoad_Click);
            this.tsbLoad.ToolTipText = "Load connection references from the connected environment";
            // 
            // tsbFindFlows
            // 
            this.tsbFindFlows.Image = global::MscrmTools.FlowsConnectionReferenceReplacer.Properties.Resources.Search32;
            this.tsbFindFlows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindFlows.Name = "tsbFindFlows";
            this.tsbFindFlows.Size = new System.Drawing.Size(181, 36);
            this.tsbFindFlows.Text = "Find flows to update";
            this.tsbFindFlows.Click += new System.EventHandler(this.tsbFindFlows_Click);
            this.tsbFindFlows.ToolTipText = "Find flows which use the selected connection references to be replaced";
            // 
            // tsbUpdateFLows
            // 
            this.tsbUpdateFLows.Image = global::MscrmTools.FlowsConnectionReferenceReplacer.Properties.Resources.Startup32;
            this.tsbUpdateFLows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateFLows.Name = "tsbUpdateFLows";
            this.tsbUpdateFLows.Size = new System.Drawing.Size(135, 36);
            this.tsbUpdateFLows.Text = "Update Flows";
            this.tsbUpdateFLows.ToolTipText = "Update selected Flows to replace source connection refernces to the target connec" +
    "tion reference";
            this.tsbUpdateFLows.Click += new System.EventHandler(this.tsbUpdateFLows_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1414, 883);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbSource.ResumeLayout(false);
            this.scSecondary.Panel1.ResumeLayout(false);
            this.scSecondary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSecondary)).EndInit();
            this.scSecondary.ResumeLayout(false);
            this.gbTarget.ResumeLayout(false);
            this.gbSummary.ResumeLayout(false);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer scMain;
        private UserControls.ConnectionReferenceSelector crsSource;
        private System.Windows.Forms.SplitContainer scSecondary;
        private UserControls.ConnectionReferenceSelector crsTarget;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.GroupBox gbSummary;
        private UserControls.FlowWithConnectionRefReplacementList wccr;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbFindFlows;
        private System.Windows.Forms.ToolStripButton tsbUpdateFLows;
    }
}
