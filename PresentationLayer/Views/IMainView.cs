using PresentationLayer.Views.UserControls;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IMainView
    {
        event EventHandler MainViewLoadedEventRaised;
        event EventHandler LoginMenuBtnClickEventRaised;
        event EventHandler RegisterMenuBtnClickEventRaised;
        event EventHandler RegisterVoterMenuBtnClickEventRaised;




        Panel GetUserControlPanel();
        void ShowMainView();
        void ExpandUserControlPanel();
        void ResetUserControlPanelSizeandLocation();
    }
}