namespace PresentationLayer.Views.UserControls.Admin
{
    partial class ConfirmIdentitiesUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ConfirmIdentitiesListDataGridView = new System.Windows.Forms.DataGridView();
            this.optionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.approveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ConfirmIdentitiesListDataGridView)).BeginInit();
            this.optionsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmIdentitiesListDataGridView
            // 
            this.ConfirmIdentitiesListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmIdentitiesListDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ConfirmIdentitiesListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConfirmIdentitiesListDataGridView.Location = new System.Drawing.Point(4, 26);
            this.ConfirmIdentitiesListDataGridView.Name = "ConfirmIdentitiesListDataGridView";
            this.ConfirmIdentitiesListDataGridView.ReadOnly = true;
            this.ConfirmIdentitiesListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfirmIdentitiesListDataGridView.Size = new System.Drawing.Size(450, 307);
            this.ConfirmIdentitiesListDataGridView.TabIndex = 1;
            this.ConfirmIdentitiesListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConfirmIdentitiesListDataGridView_CellClick);
            this.ConfirmIdentitiesListDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConfirmIdentitiesListDataGridView_CellMouseLeave);
            this.ConfirmIdentitiesListDataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ConfirmIdentitiesListDataGridView_CellMouseMove);
            // 
            // optionsContextMenuStrip
            // 
            this.optionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveToolStripMenuItem,
            this.denyToolStripMenuItem});
            this.optionsContextMenuStrip.Name = "contextMenuStrip1";
            this.optionsContextMenuStrip.Size = new System.Drawing.Size(128, 64);
            // 
            // approveToolStripMenuItem
            // 
            this.approveToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Add_Icon_Black_Background_01__24x24_;
            this.approveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.approveToolStripMenuItem.Name = "approveToolStripMenuItem";
            this.approveToolStripMenuItem.Size = new System.Drawing.Size(127, 30);
            this.approveToolStripMenuItem.Text = "Approve";
            this.approveToolStripMenuItem.Click += new System.EventHandler(this.approveToolStripMenuItem_Click);
            // 
            // denyToolStripMenuItem
            // 
            this.denyToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Edit_Icon_Black_Background_01_24x24_;
            this.denyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.denyToolStripMenuItem.Name = "denyToolStripMenuItem";
            this.denyToolStripMenuItem.Size = new System.Drawing.Size(127, 30);
            this.denyToolStripMenuItem.Text = "Deny";
            this.denyToolStripMenuItem.Click += new System.EventHandler(this.denyToolStripMenuItem_Click);
            // 
            // ConfirmIdentitiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConfirmIdentitiesListDataGridView);
            this.Name = "ConfirmIdentitiesUC";
            this.Size = new System.Drawing.Size(458, 359);
            this.Load += new System.EventHandler(this.ConfirmIdentitiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConfirmIdentitiesListDataGridView)).EndInit();
            this.optionsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ConfirmIdentitiesListDataGridView;
        private System.Windows.Forms.ContextMenuStrip optionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem approveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denyToolStripMenuItem;
    }
}
