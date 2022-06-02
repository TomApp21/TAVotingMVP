using CommonComponets;
using DomainLayer.Models.Candidate;
using PresentationLayer.Views.UserControls.Voter;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PresentationLayer.Presenters.UserControls.Admin
{
    public interface ICastVotePresenter
    {
        string ElectionName { get; set; }
        int CandidateId { get; set; }


        string CandidateName { get; set; }




        IList<CandidateModel> Candidates { get; set; }


        event EventHandler CastVoteViewReadyToShowEventRaised;
        event EventHandler<AccessTypeEventArgs> CastVoteBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> CandidateDDSelectedIndexChangedEventRaised;
        event PropertyChangedEventHandler PropertyChanged;


        ICastVoteViewUC GetCastCandidateVoteViewUC(int userId);
        void SetupCastCandidateVoteViewForAdd(int userId);

    }
}