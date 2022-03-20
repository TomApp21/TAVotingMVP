using CommonComponets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Admin
{
    public interface IConfirmIdentitiesUC
    {
        event EventHandler<AccessTypeEventArgs> ApproveIdentityListMenuClickEventRaised;
        event EventHandler ConIdentityListViewLoadEventRaised;
        event EventHandler<AccessTypeEventArgs> DenyIdentityListMenuClickEventRaised;

        void LoadConIdentityListToGrid(BindingSource departmentListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight, AccessTypeEventArgs accessTypeEventArgs);
        void ReloadConfirmIdentitiesGrid(BindingSource confirmIdentitiesListBindingSource);
    }
}