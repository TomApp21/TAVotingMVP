using CommonComponets;
using PresentationLayer.Views.UserControls.Admin;
using System;

namespace PresentationLayer.Presenters.UserControls.Admin
{
    public interface IConfirmIdentityPresenter
    {
        event EventHandler DepartmentListYesDeleteBtnClickEventRaised;

        IConfirmIdentitiesUC GetConfirmIdentityViewUC();
        //IConfirmIdentitiesUC GetRegisterVoterViewUC(int loggedInUserId);
        void LoadAllVotersFromDbToGrid();
        void OnApproveIdentityListMenuClickEventRaised(object sender, AccessTypeEventArgs e);
        void OnDenyIdentityListMenuClickEventRaised(object sender, AccessTypeEventArgs e);
    }
}