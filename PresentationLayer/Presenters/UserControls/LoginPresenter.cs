using CommonComponents;
using CommonComponets;
using DomainLayer.Models.User;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.LoginServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls
{
    public class LoginPresenter : BasePresenter, ILoginPresenter
    {
         
        public event EventHandler UserLoginViewReadyToShowEventRaised;
        public event EventHandler UserLoginCancelBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> UserLoginBtnClickEventRaised;

        private ILoginUC _userLoginViewUC;
        private IUserServices _userServices;
        private IUserModel _userModelWithoutBinding;
        
        public IUserModel _loggedInUserModel;

        private IMainView _mainView;

        private int _userId;
        private bool _isVoter;
        private bool _isAdmin;
        private bool _isAuditor;

        // Fields recreated here from UserModel to be databound to the View
        private string _username;
        private string _password;
        

        public ILoginUC GetLoginUserViewUC()
        {
            return _userLoginViewUC;
        }


        public LoginPresenter(ILoginUC userLoginViewUC,
                                 IUserServices userServices,
                                 IUserModel userModelWithoutBinding, IMainView mainView)
                                 
        {
            _userLoginViewUC = userLoginViewUC;
            _userServices = userServices;
            _userModelWithoutBinding = userModelWithoutBinding;
            _mainView = mainView;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _userLoginViewUC.UserLoginBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnUserLoginBtnClickEventRaised);

            _userLoginViewUC.UserLoginCancelBtnClickEventRaised += new EventHandler(OnUserLoginCancelBtnClickEventRaised);

            //_mainView.LoggedInSuccessfullyEventRaised += new


        }

        public void SetupUserForLogin()
        {
            InitializeValues();

            Dictionary<string, Binding> userModelbindingDictionary = new Dictionary<string, Binding>();

            SetupBindingsForView(userModelbindingDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Read;

            _userLoginViewUC.SetUpUserLoginView(userModelbindingDictionary, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, UserLoginViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> userModelbindingDictionary)
        {
            //Create bindings for data the View will use on its textBoxes
            Binding usernameNameBinding = new Binding("Text", this, "Username", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding passwordBinding = new Binding("Text", this, "Password", false, DataSourceUpdateMode.OnPropertyChanged);

            //Store bindings into a dictionary for the View to access for its textBoxes
            userModelbindingDictionary.Add("Username", usernameNameBinding);
            userModelbindingDictionary.Add("Password", passwordBinding);
        }


        private void OnUserLoginBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {
            _userModelWithoutBinding.Username = _username;
            _userModelWithoutBinding.Password = _password;

            try
            {
                if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Read)
                {
                    _loggedInUserModel = _userServices.LoginUser(_userModelWithoutBinding); //Use model service to save updated model to database 
                }

                InitializeValues();
            }
            catch (Exception e1)
            {
                ShowErrorMessage("Error Message", e1.Message);
                return;
            }
            EventHelpers.RaiseEvent(this, UserLoginBtnClickEventRaised, accessTypeEventArgs);

            // Display success message/ clear bindings
            // ---------------------------------------

            MessageBox.Show("User Successfully logged in");
            _userLoginViewUC.ClearExistingBindings();

            if (_loggedInUserModel.IsVoter)
            {
                _userId = _loggedInUserModel.UserId;
                _isVoter = _loggedInUserModel.IsVoter;
                _mainView.ShowVoterButtons(_userId, new EventArgs());

                // presenter . show . set up
            }
            else if (_loggedInUserModel.IsAdmin)
            {
                _isAdmin = _loggedInUserModel.IsAdmin;
                _mainView.ShowAdminButtons();
            }
            else // Auditor
            {
                _isAuditor = _loggedInUserModel.IsAuditor;
                _mainView.ShowAuditorButtons();
            }

            _userId = _loggedInUserModel.UserId;
        }


        private void OnUserLoginCancelBtnClickEventRaised(object sender, EventArgs e)
        {
            _userLoginViewUC.ClearExistingBindings();
            EventHelpers.RaiseEvent(this, UserLoginCancelBtnClickEventRaised, new EventArgs());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void InitializeValues()
        {
            _username = string.Empty;
            _password = string.Empty;


            _userModelWithoutBinding.Username = string.Empty;
            _userModelWithoutBinding.Password = string.Empty;
        }

        public int UserId
        {
            get { return this._userId; }
            set
            {
                if (value == this._userId) return;
                this._userId = value;
                NotifyPropertyChanged();
            }
        }

        public string Username
        {
            get { return this._username; }
            set
            {
                if (value == this._username) return;
                this._username = value;
                NotifyPropertyChanged();
            }
        }
        public string Password
        {
            get { return this._password; }
            set
            {
                if (value == this._password) return;
                this._password = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsVoter
        {
            get { return this._isVoter; }
            set
            {
                if (value == this._isVoter) return;
                this._isVoter = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsAdmin
        {
            get { return this._isAdmin; }
            set
            {
                if (value == this._isAdmin) return;
                this._isAdmin = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsAuditor
        {
            get { return this._isAuditor; }
            set
            {
                if (value == this._isAuditor) return;
                this._isAuditor = value;
                NotifyPropertyChanged();
            }
        }
    }
}
