namespace PresentationLayer.Views
{
  partial class MainView
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.userControlPanel = new System.Windows.Forms.Panel();
            this.underlineLabel = new System.Windows.Forms.Label();
            this.moreOptionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ViewElectionBtn = new System.Windows.Forms.Button();
            this.CastVoteButton = new System.Windows.Forms.Button();
            this.registerVoterButton = new System.Windows.Forms.Button();
            this.AddCandidateBtn = new System.Windows.Forms.Button();
            this.ConfirmIdentitiesButton = new System.Windows.Forms.Button();
            this.CreateElectionBtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.gardenPictureBox = new System.Windows.Forms.PictureBox();
            this.moreOptionsContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gardenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userControlPanel
            // 
            this.userControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPanel.BackColor = System.Drawing.Color.White;
            this.userControlPanel.Location = new System.Drawing.Point(2, 212);
            this.userControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userControlPanel.Name = "userControlPanel";
            this.userControlPanel.Size = new System.Drawing.Size(1046, 517);
            this.userControlPanel.TabIndex = 0;
            // 
            // underlineLabel
            // 
            this.underlineLabel.BackColor = System.Drawing.Color.Black;
            this.underlineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel.Location = new System.Drawing.Point(108, 188);
            this.underlineLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.underlineLabel.Name = "underlineLabel";
            this.underlineLabel.Size = new System.Drawing.Size(146, 6);
            this.underlineLabel.TabIndex = 9;
            this.underlineLabel.Text = "label1";
            // 
            // moreOptionsContextMenuStrip
            // 
            this.moreOptionsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.moreOptionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.moreOptionsContextMenuStrip.Name = "moreOptionsContextMenuStrip";
            this.moreOptionsContextMenuStrip.Size = new System.Drawing.Size(149, 100);
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.SettingsToolStripMenuItem.Text = "Settings";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(0, 0);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(82, 60);
            this.loginBtn.TabIndex = 11;
            this.loginBtn.Text = "Log In";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.Location = new System.Drawing.Point(319, 0);
            this.registerBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(111, 60);
            this.registerBtn.TabIndex = 12;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(890, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Voting App";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ViewElectionBtn);
            this.panel1.Controls.Add(this.CastVoteButton);
            this.panel1.Controls.Add(this.registerVoterButton);
            this.panel1.Controls.Add(this.AddCandidateBtn);
            this.panel1.Controls.Add(this.registerBtn);
            this.panel1.Controls.Add(this.ConfirmIdentitiesButton);
            this.panel1.Controls.Add(this.CreateElectionBtn);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Location = new System.Drawing.Point(4, 151);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 60);
            this.panel1.TabIndex = 0;
            // 
            // ViewElectionBtn
            // 
            this.ViewElectionBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ViewElectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewElectionBtn.Location = new System.Drawing.Point(910, 0);
            this.ViewElectionBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ViewElectionBtn.Name = "ViewElectionBtn";
            this.ViewElectionBtn.Size = new System.Drawing.Size(118, 60);
            this.ViewElectionBtn.TabIndex = 18;
            this.ViewElectionBtn.Text = "View Elections";
            this.ViewElectionBtn.UseVisualStyleBackColor = true;
            this.ViewElectionBtn.Visible = false;
            // 
            // CastVoteButton
            // 
            this.CastVoteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CastVoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CastVoteButton.Location = new System.Drawing.Point(708, 0);
            this.CastVoteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CastVoteButton.Name = "CastVoteButton";
            this.CastVoteButton.Size = new System.Drawing.Size(202, 60);
            this.CastVoteButton.TabIndex = 19;
            this.CastVoteButton.Text = "Cast Vote";
            this.CastVoteButton.UseVisualStyleBackColor = true;
            this.CastVoteButton.Visible = false;
            this.CastVoteButton.Click += new System.EventHandler(this.CastVoteButton_Click);
            // 
            // registerVoterButton
            // 
            this.registerVoterButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.registerVoterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerVoterButton.Location = new System.Drawing.Point(550, 0);
            this.registerVoterButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.registerVoterButton.Name = "registerVoterButton";
            this.registerVoterButton.Size = new System.Drawing.Size(158, 60);
            this.registerVoterButton.TabIndex = 14;
            this.registerVoterButton.Text = "Voter Registration";
            this.registerVoterButton.UseVisualStyleBackColor = true;
            this.registerVoterButton.Visible = false;
            this.registerVoterButton.Click += new System.EventHandler(this.registerVoterButton_Click);
            // 
            // AddCandidateBtn
            // 
            this.AddCandidateBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddCandidateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCandidateBtn.Location = new System.Drawing.Point(430, 0);
            this.AddCandidateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddCandidateBtn.Name = "AddCandidateBtn";
            this.AddCandidateBtn.Size = new System.Drawing.Size(120, 60);
            this.AddCandidateBtn.TabIndex = 16;
            this.AddCandidateBtn.Text = "Create Candidate";
            this.AddCandidateBtn.UseVisualStyleBackColor = true;
            this.AddCandidateBtn.Visible = false;
            this.AddCandidateBtn.Click += new System.EventHandler(this.AddCandidateBtn_Click);
            // 
            // ConfirmIdentitiesButton
            // 
            this.ConfirmIdentitiesButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConfirmIdentitiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmIdentitiesButton.Location = new System.Drawing.Point(199, 0);
            this.ConfirmIdentitiesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConfirmIdentitiesButton.Name = "ConfirmIdentitiesButton";
            this.ConfirmIdentitiesButton.Size = new System.Drawing.Size(120, 60);
            this.ConfirmIdentitiesButton.TabIndex = 15;
            this.ConfirmIdentitiesButton.Text = "Confirm Identities";
            this.ConfirmIdentitiesButton.UseVisualStyleBackColor = true;
            this.ConfirmIdentitiesButton.Visible = false;
            this.ConfirmIdentitiesButton.Click += new System.EventHandler(this.ConfirmIdentitiesButton_Click);
            // 
            // CreateElectionBtn
            // 
            this.CreateElectionBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.CreateElectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateElectionBtn.Location = new System.Drawing.Point(82, 0);
            this.CreateElectionBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateElectionBtn.Name = "CreateElectionBtn";
            this.CreateElectionBtn.Size = new System.Drawing.Size(117, 60);
            this.CreateElectionBtn.TabIndex = 17;
            this.CreateElectionBtn.Text = "Create Election";
            this.CreateElectionBtn.UseVisualStyleBackColor = true;
            this.CreateElectionBtn.Visible = false;
            this.CreateElectionBtn.Click += new System.EventHandler(this.CreateElectionBtn_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutBtn.Location = new System.Drawing.Point(824, 18);
            this.LogOutBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(202, 35);
            this.LogOutBtn.TabIndex = 20;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // gardenPictureBox
            // 
            this.gardenPictureBox.Image = global::PresentationLayer.Properties.Resources.rsz_1denny_muller_jyrti3loqnc_unsplash;
            this.gardenPictureBox.Location = new System.Drawing.Point(0, 0);
            this.gardenPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gardenPictureBox.Name = "gardenPictureBox";
            this.gardenPictureBox.Size = new System.Drawing.Size(1047, 142);
            this.gardenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gardenPictureBox.TabIndex = 10;
            this.gardenPictureBox.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1047, 728);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gardenPictureBox);
            this.Controls.Add(this.underlineLabel);
            this.Controls.Add(this.userControlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model View Presenter Demo ";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.moreOptionsContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gardenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel userControlPanel;
    private System.Windows.Forms.Label underlineLabel;
    private System.Windows.Forms.ContextMenuStrip moreOptionsContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem helpAboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.PictureBox gardenPictureBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ViewElectionBtn;
        private System.Windows.Forms.Button AddCandidateBtn;
        private System.Windows.Forms.Button ConfirmIdentitiesButton;
        private System.Windows.Forms.Button registerVoterButton;
        private System.Windows.Forms.Button CastVoteButton;
        private System.Windows.Forms.Button CreateElectionBtn;
        private System.Windows.Forms.Button LogOutBtn;
    }
}