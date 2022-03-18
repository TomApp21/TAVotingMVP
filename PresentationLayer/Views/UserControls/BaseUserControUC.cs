using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public class BaseUserControUC : UserControl
    {

        public AnchorStyles SetAnchorStylesTopBottomLeftRight()
        {
            return ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
        }
        public void SetParentSizeLocationAnchor(Panel parentPanel)
        {
            Parent = parentPanel;
            Height = parentPanel.Height;
            Width = parentPanel.Width;
            Location = new Point(0, 0);
            Anchor = SetAnchorStylesTopBottomLeftRight();
        }
    }
}
