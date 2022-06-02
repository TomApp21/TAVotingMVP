using CommonComponets;
using DomainLayer.Models.Election;
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
        void SetUpVoterRegistrationView(Dictionary<string, Binding> bindingDictionary, IList<ElectionModel> x, AccessTypeEventArgs accessTypeEventArgs);

        void FormatAlreadyRegisteredView();

        int SelectedElectionId { get; set; }
    }
}