namespace PresentationLayer.Views.UserControls.Admin
{
    partial class AddCandidateViewUC
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
            this.AddButton = new System.Windows.Forms.Button();
            this.CandidateNameTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.dropdownElectionList = new System.Windows.Forms.ComboBox();
            this.ElectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(210, 158);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(109, 27);
            this.AddButton.TabIndex = 34;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CandidateNameTextInputUC
            // 
            this.CandidateNameTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.CandidateNameTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CandidateNameTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.CandidateNameTextInputUC.InputBoxHeight = 13;
            this.CandidateNameTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.CandidateNameTextInputUC.InputBoxReadOnly = false;
            this.CandidateNameTextInputUC.InputBoxText = "";
            this.CandidateNameTextInputUC.InputBoxWidth = 837;
            this.CandidateNameTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.CandidateNameTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.CandidateNameTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CandidateNameTextInputUC.InputLabelHeight = 13;
            this.CandidateNameTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.CandidateNameTextInputUC.InputLabelText = "Candidate Name";
            this.CandidateNameTextInputUC.InputLabelWidth = 100;
            this.CandidateNameTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.CandidateNameTextInputUC.InputLineLabelWidth = 837;
            this.CandidateNameTextInputUC.Location = new System.Drawing.Point(139, 64);
            this.CandidateNameTextInputUC.Name = "CandidateNameTextInputUC";
            this.CandidateNameTextInputUC.Size = new System.Drawing.Size(180, 37);
            this.CandidateNameTextInputUC.TabIndex = 31;
            // 
            // dropdownElectionList
            // 
            this.dropdownElectionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dropdownElectionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownElectionList.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownElectionList.FormattingEnabled = true;
            this.dropdownElectionList.Location = new System.Drawing.Point(139, 124);
            this.dropdownElectionList.MaxDropDownItems = 16;
            this.dropdownElectionList.Name = "dropdownElectionList";
            this.dropdownElectionList.Size = new System.Drawing.Size(180, 23);
            this.dropdownElectionList.TabIndex = 55;
            this.dropdownElectionList.SelectedIndexChanged += new System.EventHandler(this.dropdownElectionList_SelectedIndexChanged);
            // 
            // ElectionLabel
            // 
            this.ElectionLabel.AutoSize = true;
            this.ElectionLabel.BackColor = System.Drawing.Color.White;
            this.ElectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElectionLabel.Location = new System.Drawing.Point(141, 108);
            this.ElectionLabel.Name = "ElectionLabel";
            this.ElectionLabel.Size = new System.Drawing.Size(53, 13);
            this.ElectionLabel.TabIndex = 57;
            this.ElectionLabel.Text = "Election";
            // 
            // AddCandidateViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ElectionLabel);
            this.Controls.Add(this.dropdownElectionList);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CandidateNameTextInputUC);
            this.Name = "AddCandidateViewUC";
            this.Size = new System.Drawing.Size(458, 359);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private CommonComponents.TextInputUnderlineNoBoxUC CandidateNameTextInputUC;
        private System.Windows.Forms.ComboBox dropdownElectionList;
        private System.Windows.Forms.Label ElectionLabel;
    }
}
