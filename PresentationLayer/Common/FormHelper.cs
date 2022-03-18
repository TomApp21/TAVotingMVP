using System.Windows.Forms;

namespace PresentationLayer.Common
{
  static public class FormHelper
  {
    static public void SetDialogAppearance(Form form)
    {
      form.FormBorderStyle = FormBorderStyle.FixedDialog;
      form.BackColor = System.Drawing.Color.White;
      //form.Icon = PresentationLayer.Properties.Resources.MVPDemo768Main;
      form.MinimizeBox = false;
      form.MaximizeBox = false;
    }

    static public void SetFormAppearance(Form form)
    {
      SetDialogAppearance(form);
      form.MinimizeBox = true;
    }
  }
}
