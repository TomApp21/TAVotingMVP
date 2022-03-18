using System;
using System.Drawing;
using System.Windows.Forms;


namespace PresentationLayer.Common
{
    static public class PictureBoxHelper
    {
        static public void SetClickableBehavior(PictureBox pictureBox)
        {
            pictureBox.MouseMove += new MouseEventHandler(OnPictureBoxMouseMoveEventRaised);
            pictureBox.MouseLeave += new EventHandler(OnPictureBoxMouseLeaveEventRaised);
        }
        static private void OnPictureBoxMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
        static private void OnPictureBoxMouseLeaveEventRaised(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }


        static public void DisplayContextMenu(PictureBox pictureBox, ContextMenuStrip contextMenuStrip, Form form)
        {
            Point pointForContextMenu = form.PointToScreen(
              new Point(pictureBox.Location.X - contextMenuStrip.Width + pictureBox.Width,
                        pictureBox.Location.Y + pictureBox.Height));

            contextMenuStrip.Show(pointForContextMenu.X, pointForContextMenu.Y);
        }


    }
}
