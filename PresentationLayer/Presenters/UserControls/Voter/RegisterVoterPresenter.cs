using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Election;
using DomainLayer.Models.User;
using DomainLayer.Models.Voter;
using PresentationLayer.Views.UserControls.Voter;
using ServiceLayer.Services;
using ServiceLayer.Services.LoginServices;
using ServiceLayer.Services.VoterServices;
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
    public class RegisterVoterPresenter : BasePresenter, IRegisterVoterPresenter
    {
        public event EventHandler VoterRegistrationViewReadyToShowEventRaised;
        public event EventHandler VoterRegClearBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> VoterRegisterBtnClickEventRaised;


        private IVoterRegistrationUC _voterRegisterViewUC;
        private IVoterServices _voterServices;
        private IVoterModel _voterModelWithoutBinding;
        private IElectionServices _electionServices;


        private int _loggedInUserId;

        // Fields recreated here from VoterModel to be databound to the View
        private string _firstName;
        private string _lastName;
        private string _dateOfBirth;
        private string _nationalInsurance;
        private string _addrLine1;
        private string _addrLine2;
        private string _postCode;
        private int _electionId;
        private string _electionName;
        private IList<ElectionModel> _elections;


        public IVoterRegistrationUC GetRegisterVoterViewUC(int loggedInUserId)
        {
            _loggedInUserId = loggedInUserId;
            return _voterRegisterViewUC;
        }
        public IVoterRegistrationUC GetRegisterVoterViewUC()
        {
            return _voterRegisterViewUC;
        }


        public RegisterVoterPresenter(IVoterRegistrationUC voterRegistrationUC,
                                 IVoterServices voterServices,
                                 IVoterModel voterModelWithoutBinding,
                                 IElectionServices electionServices)

        {
            _voterRegisterViewUC = voterRegistrationUC;
            _voterServices = voterServices;
            _voterModelWithoutBinding = voterModelWithoutBinding;
            _electionServices = electionServices;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _voterRegisterViewUC.VoterRegistrationBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnVoterRegistrationBtnClickEventRaised);

            _voterRegisterViewUC.VoterRegClearBtnClickEventRaised += new EventHandler(OnVoterRegClearBtnClickEventRaised);
        }

        public void BuildDatasourceForEligibleElectionsList()
        {
            // ==========================

            IEnumerable<ElectionModel> allElections = (IEnumerable<ElectionModel>)_electionServices.GetAllValidElections();

            _elections = allElections.ToList(); //.ToList();



        }



        //public void SetupVoterRegForAdd(int loggedInUserId)
        //{
        //    InitializeValues();

        //    Dictionary<string, Binding> userModelbindingDictionary = new Dictionary<string, Binding>();

        //    SetupBindingsForView(userModelbindingDictionary);

        //    AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

        //    accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

        //    _voterRegisterViewUC.SetUpVoterRegistrationView(userModelbindingDictionary, accessTypeEventArgs);


        //    EventHelpers.RaiseEvent(this, VoterRegistrationViewReadyToShowEventRaised, new EventArgs());
        //}

        public void SetupVoterReg(int loggedInUserId)
        {
            //InitializeValues(isModifiedEnabled: true);
            InitializeValues();

            Dictionary<string, Binding> departmentModelbindingDictionary = new Dictionary<string, Binding>();

            bool voterIsRegistered = LoadVoterDetails(loggedInUserId);

       
            SetupBindingsForView(departmentModelbindingDictionary);
            BuildDatasourceForEligibleElectionsList();

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Read;

            if (!voterIsRegistered)
                accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            //Tell View to load up its DataGridView with binding objects created here
            _voterRegisterViewUC.SetUpVoterRegistrationView(departmentModelbindingDictionary, _elections, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, VoterRegistrationViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> voterModelbindingDictionary)
        {
            //Create bindings for data the View will use on its textBoxes
            Binding firstNameBinding = new Binding("Text", this, "FirstName", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding lastNameBinding = new Binding("Text", this, "LastName", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding dateOfBirthBinding = new Binding("Text", this, "DateOfBirth", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding addLine1Binding = new Binding("Text", this, "AddressLine1", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding addLine2Binding = new Binding("Text", this, "AddressLine2", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding postcodeBinding = new Binding("Text", this, "Postcode", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding natInsBinding = new Binding("Text", this, "NationalInsurance", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding electionIdBinding = new Binding("Text", this, "ElectionId", false, DataSourceUpdateMode.OnPropertyChanged);


            //Store bindings into a dictionary for the View to access for its textBoxes
            voterModelbindingDictionary.Add("FirstName", firstNameBinding);
            voterModelbindingDictionary.Add("LastName", lastNameBinding);
            voterModelbindingDictionary.Add("DateOfBirth", dateOfBirthBinding);
            voterModelbindingDictionary.Add("AddressLine1", addLine1Binding);
            voterModelbindingDictionary.Add("AddressLine2", addLine2Binding);
            voterModelbindingDictionary.Add("Postcode", postcodeBinding);
            voterModelbindingDictionary.Add("NationalInsurance", natInsBinding);
            voterModelbindingDictionary.Add("ElectionId", electionIdBinding);

        }

        private void OnVoterRegistrationBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {

            _voterModelWithoutBinding.FirstName = _firstName;
            _voterModelWithoutBinding.LastName = _lastName;
            _voterModelWithoutBinding.DateOfBirth = _dateOfBirth;
            _voterModelWithoutBinding.AddressLine1 = _addrLine1;
            _voterModelWithoutBinding.AddressLine2 = _addrLine2;
            _voterModelWithoutBinding.Postcode = _postCode;
            _voterModelWithoutBinding.NationalInsurance = _nationalInsurance;
            _electionId = _voterRegisterViewUC.SelectedElectionId ;
            _voterModelWithoutBinding.ElectionId = _electionId;

            try
            {
                if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Add)
                {
                    _voterServices.RegisterVoter(_voterModelWithoutBinding, _loggedInUserId); //Use model service to save updated model to database 
                }

                InitializeValues();
            }
            catch (Exception e1)
            {
                ShowErrorMessage("Error Message", e1.Message);
                return;
            }
            EventHelpers.RaiseEvent(this, VoterRegisterBtnClickEventRaised, accessTypeEventArgs);

            // Display success message/ clear bindings
            // ---------------------------------------
            MessageBox.Show("User Successfully registered");
            _voterRegisterViewUC.FormatAlreadyRegisteredView();
            //_voterRegisterViewUC.ClearExistingBindings();
        }

        private void OnVoterRegClearBtnClickEventRaised(object sender, EventArgs e)
        {
            _voterRegisterViewUC.ClearExistingBindings();

            EventHelpers.RaiseEvent(this, VoterRegClearBtnClickEventRaised, new EventArgs());
        }

        private bool LoadVoterDetails(int loggedInUserId)
        {
            bool voterAlreadyRegistered = false;

            _voterModelWithoutBinding = _voterServices.GetVoterById(loggedInUserId);


            if (_voterModelWithoutBinding.FirstName != "")
            {
                _firstName = _voterModelWithoutBinding.FirstName;
                _lastName = _voterModelWithoutBinding.LastName;
                _dateOfBirth = _voterModelWithoutBinding.DateOfBirth;
                _addrLine1 = _voterModelWithoutBinding.AddressLine1;
                _addrLine2 = _voterModelWithoutBinding.AddressLine2;
                _postCode = _voterModelWithoutBinding.Postcode;
                _nationalInsurance = _voterModelWithoutBinding.NationalInsurance;
                _electionId = _voterModelWithoutBinding.ElectionId;

                _voterRegisterViewUC.FormatAlreadyRegisteredView();
                voterAlreadyRegistered = true;
            }
            return voterAlreadyRegistered;


        }



        private void InitializeValues()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _dateOfBirth = string.Empty;
            _addrLine1 = string.Empty;
            _addrLine2 = string.Empty;
            _postCode = string.Empty;
            _nationalInsurance = string.Empty;
            _electionId = 0;

            _voterModelWithoutBinding.FirstName = string.Empty;
            _voterModelWithoutBinding.LastName = string.Empty;
            _voterModelWithoutBinding.DateOfBirth = string.Empty;
            _voterModelWithoutBinding.AddressLine1 = string.Empty;
            _voterModelWithoutBinding.AddressLine2 = string.Empty;
            _voterModelWithoutBinding.Postcode = string.Empty;
            _voterModelWithoutBinding.NationalInsurance = string.Empty;
            _voterModelWithoutBinding.ElectionId = 0;

        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (value == this._firstName) return;
                this._firstName = value;
                NotifyPropertyChanged();
            }
        }
        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (value == this._lastName) return;
                this._lastName = value;
                NotifyPropertyChanged();
            }
        }
        public string DateOfBirth
        {
            get { return this._dateOfBirth; }
            set
            {
                if (value == this._dateOfBirth) return;
                this._dateOfBirth = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressLine1
        {
            get { return this._addrLine1; }
            set
            {
                if (value == this._addrLine1) return;
                this._addrLine1 = value;
                NotifyPropertyChanged();
            }
        }
        public string AddressLine2
        {
            get { return this._addrLine2; }
            set
            {
                if (value == this._addrLine2) return;
                this._addrLine2 = value;
                NotifyPropertyChanged();
            }
        }
        public string Postcode
        {
            get { return this._postCode; }
            set
            {
                if (value == this._postCode) return;
                this._postCode = value;
                NotifyPropertyChanged();
            }
        }
        public string NationalInsurance
        {
            get { return this._nationalInsurance; }
            set
            {
                if (value == this._nationalInsurance) return;
                this._nationalInsurance = value;
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









    }
}
