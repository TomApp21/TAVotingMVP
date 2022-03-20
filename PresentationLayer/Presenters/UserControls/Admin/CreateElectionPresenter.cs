using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Election;
using PresentationLayer.Views.UserControls.Admin;
using ServiceLayer.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls.Voter
{
    public class CreateElectionPresenter : BasePresenter, ICreateElectionPresenter
    {
        public event EventHandler AdminCreateElectionViewReadyToShowEventRaised;
        public event EventHandler CreateElectionClearBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> CreateElectionBtnClickEventRaised;


        private ICreateElectionViewUC _createElectionViewUC;
        private IAdminServices _adminServices;
        private IElectionModel _electionModelWithoutBinding;


        // Fields recreated here from User Model to be databound to the View
        private string _electionName;
        private string _startDate;
        private string _endDate;


        public ICreateElectionViewUC GetCreateElectionViewUC()
        {
            return _createElectionViewUC;
        }

        public CreateElectionPresenter(ICreateElectionViewUC createElectionViewUC,
                                 IAdminServices electionServices,
                                 IElectionModel electionModelWithoutBinding)

        {
            _createElectionViewUC = createElectionViewUC;
            _adminServices = electionServices;
            _electionModelWithoutBinding = electionModelWithoutBinding;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _createElectionViewUC.CreateElectionBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnCreateElectionBtnClickEventRaised);

            _createElectionViewUC.CreateElectionClearBtnClickEventRaised += new EventHandler(OnCreateElectionClearBtnClickEventRaised);
        }

        public void SetupCreateElectionViewForAdd()
        {
            InitializeValues();

            Dictionary<string, Binding> electionModelbindingDictionary = new Dictionary<string, Binding>();

            SetupBindingsForView(electionModelbindingDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            _createElectionViewUC.SetUpUserCreateElectionView(electionModelbindingDictionary, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, AdminCreateElectionViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> userModelbindingDictionary)
        {
            //Create bindings for data the View will use on its textBoxes
            Binding electionNameBinding = new Binding("Text", this, "ElectionName", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding firstNameBinding = new Binding("Text", this, "StartDate", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding lastNameBinding = new Binding("Text", this, "EndDate", false, DataSourceUpdateMode.OnPropertyChanged);

            //Store bindings into a dictionary for the View to access for its textBoxes
            userModelbindingDictionary.Add("ElectionName", electionNameBinding);
            userModelbindingDictionary.Add("StartDate", firstNameBinding);
            userModelbindingDictionary.Add("EndDate", lastNameBinding);
        }

        private void OnCreateElectionBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {

            _electionModelWithoutBinding.ElectionName = _electionName;
            _electionModelWithoutBinding.StartDate = _startDate;
            _electionModelWithoutBinding.EndDate = _endDate;

            try
            {
                if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Add)
                {
                    _adminServices.AddElection(_electionModelWithoutBinding); //Use model service to save updated model to database 
                }

                InitializeValues();
            }
            catch (Exception e1)
            {
                ShowErrorMessage("Error Message", e1.Message);
                return;
            }
            EventHelpers.RaiseEvent(this, CreateElectionBtnClickEventRaised, accessTypeEventArgs);

            // Display success message/ clear bindings
            // ---------------------------------------
            MessageBox.Show("Election Successfully created");
            _createElectionViewUC.ClearExistingBindings();
        }

        private void OnCreateElectionClearBtnClickEventRaised(object sender, EventArgs e)
        {
            _createElectionViewUC.ClearExistingBindings();

            EventHelpers.RaiseEvent(this, CreateElectionClearBtnClickEventRaised, new EventArgs());
        }


        private void InitializeValues()
        {
            _electionName = string.Empty;
            _startDate = string.Empty;
            _endDate = string.Empty;


            _electionModelWithoutBinding.ElectionName = string.Empty;
            _electionModelWithoutBinding.StartDate = string.Empty;
            _electionModelWithoutBinding.EndDate = string.Empty;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        public string StartDate
        {
            get { return this._startDate; }
            set
            {
                if (value == this._startDate) return;
                this._startDate = value;
                NotifyPropertyChanged();
            }
        }
        public string EndDate
        {
            get { return this._endDate; }
            set
            {
                if (value == this._endDate) return;
                this._endDate = value;
                NotifyPropertyChanged();
            }
        }
    }
}
