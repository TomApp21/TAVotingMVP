using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Candidate;
using DomainLayer.Models.Election;
using DomainLayer.Models.Voter;
using PresentationLayer.Views.UserControls.Admin;
using PresentationLayer.Views.UserControls.Voter;
using ServiceLayer.Services;
using ServiceLayer.Services.VoterServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls.Admin
{
    public class CastVotePresenter : BasePresenter, ICastVotePresenter
    {
        public event EventHandler CastVoteViewReadyToShowEventRaised;
        public event EventHandler<AccessTypeEventArgs> CastVoteBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> CandidateDDSelectedIndexChangedEventRaised;


        private ICastVoteViewUC _castVoteCandidateViewUC;
        private ICandidateServices _candidateServices;
        private IVoterServices _voterServices;
        private IElectionServices _electionServices;
        private ICandidateModel _candidateModelWithoutBinding;


        // Fields recreated here from User Model to be databound to the View
        private string _candidateName;
        private string _electionName;
        private int _candidateId;
        private int _userId;

        private IList<CandidateModel> _candidates;

        BindingList<ElectionModel> _electionSelectDtoBindingList;

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource _electionSelectDtoBindingSource;



        public ICastVoteViewUC GetCastCandidateVoteViewUC()
        {
            return _castVoteCandidateViewUC;
        }

        public CastVotePresenter(ICastVoteViewUC castVoteCandidateViewUC,
                                 ICandidateServices candidateServices,
                                 IVoterServices voterServices,
                                 IElectionServices electionServices,
                                 ICandidateModel candidateModel)

        {
            _castVoteCandidateViewUC = castVoteCandidateViewUC;
            _candidateServices = candidateServices;
            _voterServices = voterServices;
            _electionServices = electionServices;
            _candidateModelWithoutBinding = candidateModel;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _castVoteCandidateViewUC.CastVoteCandidateBtnClickEventRaised  += new EventHandler<AccessTypeEventArgs>(OnCastCandidateBtnClickEventRaised);

            _castVoteCandidateViewUC.CandidateDDSelectedIndexChangedEventRaised += new EventHandler<AccessTypeEventArgs>(OnCandidateDDSelectedIndexChangedEventRaised);
        }

        public void BuildDatasourceForEligibleCandidatesList(int userId)
        {
            // ==========================

            // get user model to getelection id
            // get election model from election id
            // get election name

            VoterModel thisVoter = _voterServices.GetVoterById(userId);

            if (!thisVoter.VoterIdentityConfirmed)
            {
                _castVoteCandidateViewUC.HideControls();
                _castVoteCandidateViewUC.ShowAwaitingRegistrationLabel();
            }
            else if (thisVoter.CastVote)
            {
                _castVoteCandidateViewUC.HideControls();
                _castVoteCandidateViewUC.ShowVoteCastLabel();
            }
            else
            {

                int electionId = thisVoter.ElectionId;

                ElectionModel thisElection = _electionServices.GetElectionById(electionId);

                IEnumerable<CandidateModel> allCandidates = (IEnumerable<CandidateModel>)_candidateServices.GetCandidatesForElection(thisElection.ElectionId);

                _candidates = allCandidates.ToList();

                _electionName = thisElection.ElectionName;
                _userId = userId;
                _castVoteCandidateViewUC.ElectionName = _electionName;
            }

        }


        public void SetupCastCandidateVoteViewForAdd(int userId)
        {
            InitializeValues();

            BuildDatasourceForEligibleCandidatesList(userId);


            Dictionary<string, Binding> candidateModelbindingDictionary = new Dictionary<string, Binding>();

            SetupBindingsForView(candidateModelbindingDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Update;

            _castVoteCandidateViewUC.SetUpUserCastCandidateVoteView(candidateModelbindingDictionary, _candidates, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, CastVoteViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> candidateModelbindingDictionary)
        {

            Binding candidateNameBinding = new Binding("Text", this, "ElectionName", false, DataSourceUpdateMode.OnPropertyChanged);


            //Store bindings into a dictionary for the View to access for its textBoxes
            candidateModelbindingDictionary.Add("ElectionName", candidateNameBinding);

        }

        private void OnCastCandidateBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {

            _candidateModelWithoutBinding.CandidateName = _candidateName;
            _candidateId = _castVoteCandidateViewUC.SelectedCandidateId;
            _candidateModelWithoutBinding.CandidateId = _candidateId; 
            //_candidateModelWithoutBinding.ElectionId = _electionId;



            try
            {
                if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Update)
                {
                    _candidateServices.CastCandidateVote(_candidateModelWithoutBinding.CandidateId, _userId); //Use model service to save updated model to database 
                }

                InitializeValues();
            }
            catch (Exception e1)
            {
                ShowErrorMessage("Error Message", e1.Message);
                return;
            }
            EventHelpers.RaiseEvent(this, CastVoteBtnClickEventRaised, accessTypeEventArgs);

            // Display success message/ clear bindings
            // ---------------------------------------
            MessageBox.Show("Vote Successfully Cast");

            _castVoteCandidateViewUC.HideControls();
            _castVoteCandidateViewUC.ShowVoteCastLabel();

        }

        private void OnCandidateDDSelectedIndexChangedEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {
            EventHelpers.RaiseEvent(this, CandidateDDSelectedIndexChangedEventRaised, accessTypeEventArgs);
        }


        private void InitializeValues()
        {
            _electionName = string.Empty;
            _candidateName = string.Empty;
            _candidateId = 0;
            _candidates = null;

            _candidateModelWithoutBinding.CandidateId = 0;
            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public string CandidateName
        {
            get { return this._candidateName; }
            set
            {
                if (value == this._candidateName) return;
                this._candidateName = value;
                NotifyPropertyChanged();
            }
        }
        public int CandidateId
        {
            get { return this._candidateId; }
            set
            {
                if (value == this._candidateId) return;
                this._candidateId = value;
                NotifyPropertyChanged();
            }
        }

        public string ElectionName
        {
            get { return this._electionName; }
            set
            {
                if (value == this._electionName) return;
                this._electionName = value;
                NotifyPropertyChanged();
            }
        }

       

        public IList<CandidateModel> Candidates
        {
            get { return this._candidates; }
            set
            {
                if (value != this._candidates)
                {
                    this._candidates = value;
                    NotifyPropertyChanged("Elections");
                }
            }
        }
        //public ElectionModel SelectedElection
        //{
        //    get { return this._selectedElection; }
        //    set
        //    {
        //        if (value != this._selectedElection)
        //        {
        //            this._selectedElection = value;
        //            NotifyPropertyChanged("SelectedElection");

        //        }
        //    }
        //}
    }
}
