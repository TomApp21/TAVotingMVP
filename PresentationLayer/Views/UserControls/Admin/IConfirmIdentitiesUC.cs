using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Admin
{
    public interface IConfirmIdentitiesUC
    {
        event EventHandler ApproveIdentityListMenuClickEventRaised;
        event EventHandler ConIdentityListViewLoadEventRaised;
        event EventHandler DenyIdentityListMenuClickEventRaised;

        void LoadConIdentityListToGrid(BindingSource departmentListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight);
        void ReloadConfirmIdentitiesGrid(BindingSource confirmIdentitiesListBindingSource);
    }
}