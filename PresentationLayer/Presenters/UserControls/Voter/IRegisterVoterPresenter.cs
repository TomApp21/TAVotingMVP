using CommonComponets;
using PresentationLayer.Views.UserControls.Voter;
using System;

namespace PresentationLayer.Presenters.UserControls.Voter
{
    public interface IRegisterVoterPresenter
    {
        event EventHandler VoterRegClearBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> VoterRegisterBtnClickEventRaised;
        event EventHandler VoterRegistrationViewReadyToShowEventRaised;

        IVoterRegistrationUC GetRegisterVoterViewUC();
    }
}