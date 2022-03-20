using CommonComponets;
using PresentationLayer.Views.UserControls.Admin;
using System;
using System.ComponentModel;

namespace PresentationLayer.Presenters.UserControls.Voter
{
    public interface ICreateElectionPresenter
    {
        string EndDate { get; set; }
        string StartDate { get; set; }
        string ElectionName { get; set; }

        event EventHandler AdminCreateElectionViewReadyToShowEventRaised;
        event EventHandler<AccessTypeEventArgs> CreateElectionBtnClickEventRaised;
        event EventHandler CreateElectionClearBtnClickEventRaised;

        event PropertyChangedEventHandler PropertyChanged;

        ICreateElectionViewUC GetCreateElectionViewUC();
        void SetupCreateElectionViewForAdd();
    }
}