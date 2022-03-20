using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IMainView
    {
        event EventHandler MainViewLoadedEventRaised;
        event EventHandler LoginMenuBtnClickEventRaised;
        event EventHandler RegisterMenuBtnClickEventRaised;
        event EventHandler RegisterVoterMenuBtnClickEventRaised;
        event EventHandler ConfirmIdentityMenuBtnClickEventRaised;
        event EventHandler CreateElectionMenuBtnClickEventRaised;

        event EventHandler LoggedInSuccessfullyEventRaised;



        Panel GetUserControlPanel();
        void ShowMainView();
        void ExpandUserControlPanel();
        void ResetUserControlPanelSizeandLocation();

        void ShowVoterButtons(int id, EventArgs e);
        void ShowAdminButtons(int id, EventArgs e);
        void ShowAuditorButtons();

    }
}