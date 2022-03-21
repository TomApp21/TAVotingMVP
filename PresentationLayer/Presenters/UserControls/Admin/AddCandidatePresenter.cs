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
        private string _electionName;
        private int _electionId;

        private IList<ElectionModel> _elections;
        private ElectionModel _selectedElection;

        BindingList<ElectionModel> _electionSelectDtoBindingList;

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource _electionSelectDtoBindingSource;

        //public List<IElectionModel> elections = new List<IElectionModel>();


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
            // ==========================

            IEnumerable<ElectionModel> allElections = (IEnumerable<ElectionModel>)_electionServices.GetAllValidElections();

            _elections = allElections.ToList();



            _electionSelectDtoBindingList = new BindingList<ElectionModel>();
            foreach (ElectionModel electionModel in allElections)
            {
                _electionSelectDtoBindingList.Add(electionModel);
            };

            _electionSelectDtoBindingSource = new BindingSource();//Reset

            this._electionSelectDtoBindingSource.DataSource = _electionSelectDtoBindingList;

        }


        public void SetupAddCandidateViewForAdd()
        {
            InitializeValues();

            BuildDatasourceForEligibleElectionsList();


            Dictionary<string, Binding> candidateModelbindingDictionary = new Dictionary<string, Binding>();

            SetupBindingsForView(candidateModelbindingDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            _addCandidateViewUC.SetUpUserCreateCandidateView(candidateModelbindingDictionary, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, AddCandidateViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> candidateModelbindingDictionary)
        {
            //BindingSource bindingSource = new BindingSource();

            //bindingSource.DataSource = _elections.ToList();


            //Create bindings for data the View will use on its inputs
            Binding electionListDataSourceBinding = new Binding("DataSource", _electionSelectDtoBindingSource.DataSource, "Elections", true, DataSourceUpdateMode.OnPropertyChanged);
            Binding electionListSelectedValueBinding = new Binding("SelectedValue", _electionSelectDtoBindingSource, "ElectionId", true, DataSourceUpdateMode.OnValidation);
            Binding electionNameBinding = new Binding("Text", this, "ElectionName", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding candidateNameBinding = new Binding("Text", this, "CandidateName", false, DataSourceUpdateMode.OnPropertyChanged);

            Binding electionIdBinding = new Binding("Text", this, "ElectionId", false, DataSourceUpdateMode.OnPropertyChanged);

            //Store bindings into a dictionary for the View to access for its textBoxes
            candidateModelbindingDictionary.Add("CandidateName", candidateNameBinding);
            candidateModelbindingDictionary.Add("ElectionId", electionIdBinding);
            candidateModelbindingDictionary.Add("ElectionName", electionNameBinding);

            candidateModelbindingDictionary.Add("Elections", electionListDataSourceBinding);
            candidateModelbindingDictionary.Add("SelectedValue", electionListSelectedValueBinding);

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
            EventHelpers.RaiseEvent(this, ElectionDDSelectedIndexChangedEventRaised, accessTypeEventArgs);
        }


        private void InitializeValues()
        {
            _candidateName = string.Empty;
            _electionName = string.Empty;
            _electionId = 0;
            _elections = null;

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

        public IList<ElectionModel> Elections
        {
            get { return this._elections; }
            set
            {
                if (value != this._elections)
                {
                    this._elections = value;
                    NotifyPropertyChanged("Elections");
                }
            }
        }
        public ElectionModel SelectedElection
        {
            get { return this._selectedElection; }
            set
            {
                if (value != this._selectedElection)
                {
                    this._selectedElection = value;
                    NotifyPropertyChanged("SelectedElection");

                }
            }
        }
    }
}
