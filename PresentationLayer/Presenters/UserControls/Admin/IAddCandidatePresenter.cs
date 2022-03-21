using CommonComponets;
using PresentationLayer.Views.UserControls.Admin;
using System;
using System.ComponentModel;

namespace PresentationLayer.Presenters.UserControls.Admin
{
    public interface IAddCandidatePresenter
    {
        string CandidateName { get; set; }
        int ElectionId { get; set; }

        event EventHandler AddCandidateViewReadyToShowEventRaised;
        event EventHandler<AccessTypeEventArgs> CreateCandidateBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> ElectionDDSelectedIndexChangedEventRaised;
        event PropertyChangedEventHandler PropertyChanged;

        IAddCandidateViewUC GetAddCandidateViewUC();
        void SetupAddCandidateViewForAdd();
    }
}