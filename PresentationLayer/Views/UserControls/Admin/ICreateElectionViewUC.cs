using CommonComponets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Admin
{
    public interface ICreateElectionViewUC
    {
        AccessTypeEventArgs AccessTypeEventArgs { get; set; }

        event EventHandler<AccessTypeEventArgs> CreateElectionBtnClickEventRaised;
        event EventHandler CreateElectionClearBtnClickEventRaised;

        void BindUserModelToView(Dictionary<string, Binding> bindingDictionary);
        void ClearExistingBindings();
        void SetUpUserCreateElectionView(Dictionary<string, Binding> bindingDictionary, AccessTypeEventArgs accessTypeEventArgs);
    }
}