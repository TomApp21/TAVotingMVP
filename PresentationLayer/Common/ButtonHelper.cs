
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
    static public class ButtonHelper
    {
        static public void SetToBorderless(Button button)
        {
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;

            button.MouseMove += new MouseEventHandler(OnBorderlessMouseMoveEventRaised);
            button.MouseLeave += new EventHandler(OnBorderlessMouseLeaveEventRaised);
        }

        static public void SetGroupToBorderless(List<Button> buttons)
        {
            foreach (Button btn in buttons)
            {
                SetToBorderless(btn);
            }
        }

        static private void OnBorderlessMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
        static private void OnBorderlessMouseLeaveEventRaised(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        static public void SetVisibilityOfButtons(List<Button> buttons, bool visibility, Label underlineLabel)
        {
            foreach (Button btn in buttons)
            {
                btn.Visible = visibility;
            }

            if (underlineLabel != null)
            {
                underlineLabel.Visible = visibility;
            }
        }

        static public void SetUnderlinePosition(Button button, Label underlineLabel)
        {
            underlineLabel.Width = button.Bounds.Width - (int)(button.Bounds.Width * .15); ;
            underlineLabel.Left = button.Bounds.Left + (int)(button.Bounds.Width * .08); ;
            underlineLabel.Top = button.Top + button.Height;
        }

        static public void HideAllButtons(List<Button> allButtons)
        {
            foreach (Button btn in allButtons)
            {
                btn.Visible = false;
            }
        }

        static public void SetVisibilityOfButtons(List<Button> showButtonList)
        {
            foreach (Button btn in showButtonList)
            {
                btn.Visible = true;
            }
        }


    }
}
