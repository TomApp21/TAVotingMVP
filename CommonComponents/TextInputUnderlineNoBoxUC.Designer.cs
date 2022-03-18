namespace CommonComponents
{
  partial class TextInputUnderlineNoBoxUC
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
      this.InputLineLabel = new System.Windows.Forms.Label();
      this.InputTextBox = new System.Windows.Forms.TextBox();
      this.InputLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // InputLineLabel
      // 
      this.InputLineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.InputLineLabel.BackColor = System.Drawing.Color.LightGray;
      this.InputLineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.InputLineLabel.ForeColor = System.Drawing.Color.LightGray;
      this.InputLineLabel.Location = new System.Drawing.Point(2, 35);
      this.InputLineLabel.Name = "InputLineLabel";
      this.InputLineLabel.Size = new System.Drawing.Size(206, 2);
      this.InputLineLabel.TabIndex = 3;
      this.InputLineLabel.Text = "label1";
      // 
      // InputTextBox
      // 
      this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.InputTextBox.Location = new System.Drawing.Point(2, 20);
      this.InputTextBox.Name = "InputTextBox";
      this.InputTextBox.Size = new System.Drawing.Size(206, 13);
      this.InputTextBox.TabIndex = 2;
      this.InputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTextBox_KeyPress);
      // 
      // InputLabel
      // 
      this.InputLabel.AutoSize = true;
      this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.InputLabel.Location = new System.Drawing.Point(0, 3);
      this.InputLabel.Name = "InputLabel";
      this.InputLabel.Size = new System.Drawing.Size(34, 13);
      this.InputLabel.TabIndex = 4;
      this.InputLabel.Text = "label";
      // 
      // TextInputUnderlineNoBoxUC
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.InputLabel);
      this.Controls.Add(this.InputLineLabel);
      this.Controls.Add(this.InputTextBox);
      this.Name = "TextInputUnderlineNoBoxUC";
      this.Size = new System.Drawing.Size(212, 37);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label InputLineLabel;
    private System.Windows.Forms.TextBox InputTextBox;
    private System.Windows.Forms.Label InputLabel;
  }
}
