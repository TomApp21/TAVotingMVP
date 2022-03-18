namespace PresentationLayer.Views.UserControls.Voter
{
    partial class VoterRegistrationUC
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.UsernameTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(186, 222);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(109, 27);
            this.CancelButton.TabIndex = 20;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // LoginButton
            // 
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(186, 189);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(109, 27);
            this.LoginButton.TabIndex = 19;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextInputUC
            // 
            this.PasswordTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.PasswordTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.PasswordTextInputUC.InputBoxHeight = 13;
            this.PasswordTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.PasswordTextInputUC.InputBoxReadOnly = false;
            this.PasswordTextInputUC.InputBoxText = "";
            this.PasswordTextInputUC.InputBoxWidth = 1157;
            this.PasswordTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.PasswordTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.PasswordTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextInputUC.InputLabelHeight = 13;
            this.PasswordTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.PasswordTextInputUC.InputLabelText = "Password";
            this.PasswordTextInputUC.InputLabelWidth = 61;
            this.PasswordTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.PasswordTextInputUC.InputLineLabelWidth = 1157;
            this.PasswordTextInputUC.Location = new System.Drawing.Point(64, 115);
            this.PasswordTextInputUC.Name = "PasswordTextInputUC";
            this.PasswordTextInputUC.Size = new System.Drawing.Size(231, 37);
            this.PasswordTextInputUC.TabIndex = 18;
            // 
            // UsernameTextInputUC
            // 
            this.UsernameTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.UsernameTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.UsernameTextInputUC.InputBoxHeight = 13;
            this.UsernameTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.UsernameTextInputUC.InputBoxReadOnly = false;
            this.UsernameTextInputUC.InputBoxText = "";
            this.UsernameTextInputUC.InputBoxWidth = 1157;
            this.UsernameTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.UsernameTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.UsernameTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextInputUC.InputLabelHeight = 13;
            this.UsernameTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.UsernameTextInputUC.InputLabelText = "Username";
            this.UsernameTextInputUC.InputLabelWidth = 63;
            this.UsernameTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.UsernameTextInputUC.InputLineLabelWidth = 1157;
            this.UsernameTextInputUC.Location = new System.Drawing.Point(64, 61);
            this.UsernameTextInputUC.Name = "UsernameTextInputUC";
            this.UsernameTextInputUC.Size = new System.Drawing.Size(231, 37);
            this.UsernameTextInputUC.TabIndex = 17;
            // 
            // VoterRegistrationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextInputUC);
            this.Controls.Add(this.UsernameTextInputUC);
            this.Name = "VoterRegistrationUC";
            this.Size = new System.Drawing.Size(453, 311);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button LoginButton;
        private CommonComponents.TextInputUnderlineNoBoxUC PasswordTextInputUC;
        private CommonComponents.TextInputUnderlineNoBoxUC UsernameTextInputUC;
    }
}
