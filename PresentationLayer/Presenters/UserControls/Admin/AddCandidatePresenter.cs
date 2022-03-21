using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Candidate;
using DomainLayer.Models.Election;
using PresentationLayer.Views.UserControls.Admin;
using ServiceLayer.Services;
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
    public class AddCandidatePresenter : BasePresenter, IAddCandidatePresenter
    {
        public event EventHandler AddCandidateViewReadyToShowEventRaised;
        public event EventHandler<AccessTypeEventArgs> CreateCandidateBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> ElectionDDSelectedIndexChangedEventRaised;


        private IAddCandidateViewUC _addCandidateViewUC;
        private ICandidateServices _candidateServices;
        private IElectionServices _electionServices;
        private ICandidateModel _candidateModelWithoutBinding;


        // Fields recreated here from User Model to be databound to the View
        private string _candidateName;
        private int _electionId;

        public List<IElectionModel> elections = new List<IElectionModel>();


        public IAddCandidateViewUC GetAddCandidateViewUC()
        {
            return _addCandidateViewUC;
        }

        public AddCandidatePresenter(IAddCandidateViewUC addCandidateViewUC,
                                 ICandidateServices candidateServices,
                                 IElectionServices electionServices,
                                 ICandidateModel candidateModel)

        {
            _addCandidateViewUC = addCandidateViewUC;
            _candidateServices = candidateServices;
            _electionServices = electionServices;
            _candidateModelWithoutBinding = candidateModel;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _addCandidateViewUC.CreateCandidateBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnCreateCandidateBtnClickEventRaised);

            _addCandidateViewUC.ElectionDDSelectedIndexChangedEventRaised += new EventHandler<AccessTypeEventArgs>(OnElectionDDSelectedIndexChangedEventRaised);
        }


        //private void WireUpElectionList()
        //{
        //    el.DataSource = null;
        //    dropdownElectionList.DataSource = elections;
        //    dropdownElectionList.DisplayMember = "ElectionName"; // Column Name
        //    dropdownElectionList.ValueMember = "ElectionId";
        //}

        public void BuildDatasourceForEligibleElectionsList()
        {
            IEnumerable<IElectionModel> allValidElections = _electionServices.GetAllValidElections();
            elections = allValidElections.ToList();
        }


        public void SetupAddCandidateViewForAdd()
        {
            InitializeValues();

            BuildDatasourceForEligibleElectionsList();


            Dictionary<string, Binding> candidateModelbindingDictionary = new Dictionary<string, Binding>();

            SetupBindingsForView(candidateModelbindingDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            _addCandidateViewUC.SetUpUserCreateCandidateView(candidateModelbindingDictionary, elections, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, AddCandidateViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> userModelbindingDictionary)
        {
            //Create bindings for data the View will use on its textBoxes
            Binding candidateNameBinding = new Binding("Text", this, "CandidateName", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding electionIdBinding = new Binding("Text", this, "ElectionId", false, DataSourceUpdateMode.OnPropertyChanged);

            //Store bindings into a dictionary for the View to access for its textBoxes
            userModelbindingDictionary.Add("CandidateName", candidateNameBinding);
            userModelbindingDictionary.Add("ElectionId", electionIdBinding);
        }

        private void OnCreateCandidateBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {

            _candidateModelWithoutBinding.CandidateName = _candidateName;
            _candidateModelWithoutBinding.ElectionId = _electionId;

            try
            {
                if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Add)
                {
                    _candidateServices.AddCandidate(_candidateModelWithoutBinding); //Use model service to save updated model to database 
                }

                InitializeValues();
            }
            catch (Exception e1)
            {
                ShowErrorMessage("Error Message", e1.Message);
                return;
            }
            EventHelpers.RaiseEvent(this, CreateCandidateBtnClickEventRaised, accessTypeEventArgs);

            // Display success message/ clear bindings
            // ---------------------------------------
            MessageBox.Show("Election Successfully created");
            _addCandidateViewUC.ClearExistingBindings();
        }

        private void OnElectionDDSelectedIndexChangedEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {
            
            selectedElection = (Election)dropdownElectionList.SelectedItem;
            int id = selectedElection.ElectionId;

            _candidateModelWithoutBinding.ElectionId = _electionId;

            EventHelpers.RaiseEvent(this, ElectionDDSelectedIndexChangedEventRaised, accessTypeEventArgs);
        }


        private void InitializeValues()
        {
            _candidateName = string.Empty;
            _electionId = 0;


            _candidateModelWithoutBinding.CandidateName = string.Empty;
            _candidateModelWithoutBinding.ElectionId = 0;
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
        public int ElectionId
        {
            get { return this._electionId; }
            set
            {
                if (value == this._electionId) return;
                this._electionId = value;
                NotifyPropertyChanged();
            }
        }

    }
}
