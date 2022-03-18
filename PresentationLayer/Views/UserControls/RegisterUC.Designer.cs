namespace PresentationLayer.Views.UserControls
{
    partial class RegisterUC
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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.PasswordRegTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.UsernameRegTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ConPwordRegTextInputUC = new CommonComponents.TextInputUnderlineNoBoxUC();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Location = new System.Drawing.Point(196, 193);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(109, 27);
            this.RegisterButton.TabIndex = 15;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PasswordRegTextInputUC
            // 
            this.PasswordRegTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.PasswordRegTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordRegTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.PasswordRegTextInputUC.InputBoxHeight = 13;
            this.PasswordRegTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.PasswordRegTextInputUC.InputBoxReadOnly = false;
            this.PasswordRegTextInputUC.InputBoxText = "";
            this.PasswordRegTextInputUC.InputBoxWidth = 1043;
            this.PasswordRegTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.PasswordRegTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.PasswordRegTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordRegTextInputUC.InputLabelHeight = 13;
            this.PasswordRegTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.PasswordRegTextInputUC.InputLabelText = "Password";
            this.PasswordRegTextInputUC.InputLabelWidth = 61;
            this.PasswordRegTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.PasswordRegTextInputUC.InputLineLabelWidth = 1043;
            this.PasswordRegTextInputUC.Location = new System.Drawing.Point(71, 94);
            this.PasswordRegTextInputUC.Name = "PasswordRegTextInputUC";
            this.PasswordRegTextInputUC.Size = new System.Drawing.Size(231, 37);
            this.PasswordRegTextInputUC.TabIndex = 14;
            // 
            // UsernameRegTextInputUC
            // 
            this.UsernameRegTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.UsernameRegTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameRegTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.UsernameRegTextInputUC.InputBoxHeight = 13;
            this.UsernameRegTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.UsernameRegTextInputUC.InputBoxReadOnly = false;
            this.UsernameRegTextInputUC.InputBoxText = "";
            this.UsernameRegTextInputUC.InputBoxWidth = 1043;
            this.UsernameRegTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.UsernameRegTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.UsernameRegTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameRegTextInputUC.InputLabelHeight = 13;
            this.UsernameRegTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.UsernameRegTextInputUC.InputLabelText = "Username";
            this.UsernameRegTextInputUC.InputLabelWidth = 63;
            this.UsernameRegTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.UsernameRegTextInputUC.InputLineLabelWidth = 1043;
            this.UsernameRegTextInputUC.Location = new System.Drawing.Point(71, 40);
            this.UsernameRegTextInputUC.Name = "UsernameRegTextInputUC";
            this.UsernameRegTextInputUC.Size = new System.Drawing.Size(231, 37);
            this.UsernameRegTextInputUC.TabIndex = 13;
            // 
            // ClearButton
            // 
            this.ClearButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(196, 226);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(109, 27);
            this.ClearButton.TabIndex = 16;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConPwordRegTextInputUC
            // 
            this.ConPwordRegTextInputUC.InputBoxBackgroundColor = System.Drawing.SystemColors.Window;
            this.ConPwordRegTextInputUC.InputBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConPwordRegTextInputUC.InputBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.ConPwordRegTextInputUC.InputBoxHeight = 13;
            this.ConPwordRegTextInputUC.InputBoxLocation = new System.Drawing.Point(2, 20);
            this.ConPwordRegTextInputUC.InputBoxReadOnly = false;
            this.ConPwordRegTextInputUC.InputBoxText = "";
            this.ConPwordRegTextInputUC.InputBoxWidth = 1081;
            this.ConPwordRegTextInputUC.InputLabelBackgroundColor = System.Drawing.Color.White;
            this.ConPwordRegTextInputUC.InputLabelColor = System.Drawing.SystemColors.ControlText;
            this.ConPwordRegTextInputUC.InputLabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConPwordRegTextInputUC.InputLabelHeight = 13;
            this.ConPwordRegTextInputUC.InputLabelLocation = new System.Drawing.Point(0, 3);
            this.ConPwordRegTextInputUC.InputLabelText = "Confirm Password";
            this.ConPwordRegTextInputUC.InputLabelWidth = 107;
            this.ConPwordRegTextInputUC.InputLineLabelLocation = new System.Drawing.Point(2, 35);
            this.ConPwordRegTextInputUC.InputLineLabelWidth = 1081;
            this.ConPwordRegTextInputUC.Location = new System.Drawing.Point(71, 142);
            this.ConPwordRegTextInputUC.Name = "ConPwordRegTextInputUC";
            this.ConPwordRegTextInputUC.Size = new System.Drawing.Size(231, 37);
            this.ConPwordRegTextInputUC.TabIndex = 18;
            // 
            // RegisterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConPwordRegTextInputUC);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.PasswordRegTextInputUC);
            this.Controls.Add(this.UsernameRegTextInputUC);
            this.Name = "RegisterUC";
            this.Size = new System.Drawing.Size(379, 278);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private CommonComponents.TextInputUnderlineNoBoxUC PasswordRegTextInputUC;
        private CommonComponents.TextInputUnderlineNoBoxUC UsernameRegTextInputUC;
        private System.Windows.Forms.Button ClearButton;
        private CommonComponents.TextInputUnderlineNoBoxUC ConPwordRegTextInputUC;
    }
}
