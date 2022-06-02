namespace PresentationLayer.Views.UserControls.Voter
{
    partial class CastVoteViewUC
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
            this.CandidateLabel = new System.Windows.Forms.Label();
            this.dropdownCandidateList = new System.Windows.Forms.ComboBox();
            this.CastVoteButton = new System.Windows.Forms.Button();
            this.ElectionNameTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.SuspendLayout();
            // 
            // CandidateLabel
            // 
            this.CandidateLabel.AutoSize = true;
            this.CandidateLabel.BackColor = System.Drawing.Color.White;
            this.CandidateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CandidateLabel.Location = new System.Drawing.Point(172, 158);
            this.CandidateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CandidateLabel.Name = "CandidateLabel";
            this.CandidateLabel.Size = new System.Drawing.Size(103, 20);
            this.CandidateLabel.TabIndex = 65;
            this.CandidateLabel.Text = "Candidates";
            // 
            // dropdownCandidateList
            // 
            this.dropdownCandidateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dropdownCandidateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownCandidateList.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownCandidateList.FormattingEnabled = true;
            this.dropdownCandidateList.Location = new System.Drawing.Point(168, 183);
            this.dropdownCandidateList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dropdownCandidateList.MaxDropDownItems = 16;
            this.dropdownCandidateList.Name = "dropdownCandidateList";
            this.dropdownCandidateList.Size = new System.Drawing.Size(268, 33);
            this.dropdownCandidateList.TabIndex = 64;
            this.dropdownCandidateList.SelectedIndexChanged += new System.EventHandler(this.dropdownCandidateList_SelectedIndexChanged);
            // 
            // CastVoteButton
            // 
            this.CastVoteButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.CastVoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CastVoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CastVoteButton.Location = new System.Drawing.Point(275, 235);
            this.CastVoteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CastVoteButton.Name = "CastVoteButton";
            this.CastVoteButton.Size = new System.Drawing.Size(164, 42);
            this.CastVoteButton.TabIndex = 63;
            this.CastVoteButton.Text = "Cast Vote";
            this.CastVoteButton.UseVisualStyleBackColor = true;
            // 
            // ElectionNameTextInputUC
            // 
            this.ElectionNameTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.ElectionNameTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElectionNameTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.ElectionNameTextInputUC.InputBoxHeight = 19;
            this.ElectionNameTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.ElectionNameTextInputUC.InputBoxReadOnly = true;
            this.ElectionNameTextInputUC.InputBoxText = "";
            this.ElectionNameTextInputUC.InputBoxWidth = 603;
            this.ElectionNameTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.ElectionNameTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.ElectionNameTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElectionNameTextInputUC.InputLabelHeight = 20;
            this.ElectionNameTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.ElectionNameTextInputUC.InputLabelText = "Election Name";
            this.ElectionNameTextInputUC.InputLabelWidth = 131;
            this.ElectionNameTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.ElectionNameTextInputUC.InputLineLabelWidth = 603;
            this.ElectionNameTextInputUC.Location = new System.Drawing.Point(168, 90);
            this.ElectionNameTextInputUC.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ElectionNameTextInputUC.Name = "ElectionNameTextInputUC";
            this.ElectionNameTextInputUC.Size = new System.Drawing.Size(270, 57);
            this.ElectionNameTextInputUC.TabIndex = 62;
            // 
            // CastVoteViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CandidateLabel);
            this.Controls.Add(this.dropdownCandidateList);
            this.Controls.Add(this.CastVoteButton);
            this.Controls.Add(this.ElectionNameTextInputUC);
            this.Name = "CastVoteViewUC";
            this.Size = new System.Drawing.Size(687, 552);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CandidateLabel;
        private System.Windows.Forms.ComboBox dropdownCandidateList;
        private System.Windows.Forms.Button CastVoteButton;
        private CommonComponents.TextInputUnderlineNoBoxUC ElectionNameTextInputUC;
    }
}
