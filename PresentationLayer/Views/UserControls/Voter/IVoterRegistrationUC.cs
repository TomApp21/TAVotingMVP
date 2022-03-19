using CommonComponets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Voter
{
    public interface IVoterRegistrationUC
    {
        AccessTypeEventArgs AccessTypeEventArgs { get; set; }

        event EventHandler<AccessTypeEventArgs> VoterRegistrationBtnClickEventRaised;
        event EventHandler VoterRegClearBtnClickEventRaised;

        void BindUserModelToView(Dictionary<string, Binding> bindingDictionary);
        void ClearExistingBindings();
        void SetUpVoterRegistrationView(Dictionary<string, Binding> bindingDictionary, AccessTypeEventArgs accessTypeEventArgs);

        void FormatAlreadyRegisteredView();
    }
}