namespace MscrmTools.FlowsConnectionReferenceReplacer.UserControls
{
    partial class CommandBar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.llClearAll = new System.Windows.Forms.LinkLabel();
            this.llSelectAll = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.llClearAll);
            this.panel1.Controls.Add(this.llSelectAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel1.Size = new System.Drawing.Size(772, 32);
            this.panel1.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSearch.Location = new System.Drawing.Point(71, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(237, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.Location = new System.Drawing.Point(0, 4);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 28);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llClearAll
            // 
            this.llClearAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.llClearAll.Location = new System.Drawing.Point(581, 4);
            this.llClearAll.Name = "llClearAll";
            this.llClearAll.Size = new System.Drawing.Size(120, 28);
            this.llClearAll.TabIndex = 1;
            this.llClearAll.TabStop = true;
            this.llClearAll.Text = "Clear all";
            this.llClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_Clicked);
            // 
            // llSelectAll
            // 
            this.llSelectAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.llSelectAll.Location = new System.Drawing.Point(701, 4);
            this.llSelectAll.Name = "llSelectAll";
            this.llSelectAll.Size = new System.Drawing.Size(71, 28);
            this.llSelectAll.TabIndex = 0;
            this.llSelectAll.TabStop = true;
            this.llSelectAll.Text = "Select all";
            this.llSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_Clicked);
            // 
            // CommandBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CommandBar";
            this.Size = new System.Drawing.Size(772, 32);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.LinkLabel llClearAll;
        private System.Windows.Forms.LinkLabel llSelectAll;
    }
}
