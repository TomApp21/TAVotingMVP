using CommonComponets;
using DomainLayer.Models.Election;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Admin
{
    public interface IAddCandidateViewUC
    {
        AccessTypeEventArgs AccessTypeEventArgs { get; set; }
        int SelectedElectionId { get; set; }

        event EventHandler<AccessTypeEventArgs> CreateCandidateBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> ElectionDDSelectedIndexChangedEventRaised;

        void BindCandidateModelToView(Dictionary<string, Binding> bindingDictionary);
        void ClearExistingBindings();
        void SetUpUserCreateCandidateView(Dictionary<string, Binding> bindingDictionary, List<IElectionModel> allValidElections, AccessTypeEventArgs accessTypeEventArgs);
    }
}