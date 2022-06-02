using CommonComponets;
using DomainLayer.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Voter
{
    public interface ICastVoteViewUC
    {
        AccessTypeEventArgs AccessTypeEventArgs { get; set; }
        int SelectedCandidateId { get; set; }

        event EventHandler<AccessTypeEventArgs> CreateCandidateBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> ElectionDDSelectedIndexChangedEventRaised;

        void BindCandidateModelToView(Dictionary<string, Binding> bindingDictionary);
        void ClearExistingBindings();
        void SetUpUserCastCandidateVoteView(Dictionary<string, Binding> bindingDictionary, IEnumerable<CandidateModel> x, AccessTypeEventArgs accessTypeEventArgs);

    }
}
