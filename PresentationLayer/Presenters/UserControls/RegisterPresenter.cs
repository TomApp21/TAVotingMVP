using CommonComponents;
using CommonComponets;
using DomainLayer.Models.User;
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
    public class RegisterPresenter : BasePresenter, IRegisterPresenter
    {

        public event EventHandler UserRegistrationViewReadyToShowEventRaised;
        public event EventHandler UserRegClearBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> UserRegisterBtnClickEventRaised;


        private IRegisterUC _userRegisterViewUC;
        private IUserServices _userServices;
        private IUserModel _userModelWithoutBinding;


        // Fields recreated here from User Model to be databound to the View
        private string _username;
        private string _password;
        private string _confirmPassword;


        public IRegisterUC GetRegisterUserViewUC()
        {
            return _userRegisterViewUC;
        }

        public RegisterPresenter(IRegisterUC userRegisterViewUC,
                                 IUserServices userServices,
                                 IUserModel userModelWithoutBinding)
                                 
        {
            _userRegisterViewUC = userRegisterViewUC;
            _userServices = userServices;
            _userModelWithoutBinding = userModelWithoutBinding;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _userRegisterViewUC.UserRegisterBtnClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnUserRegisterBtnClickEventRaised);

            _userRegisterViewUC.UserRegisterClearBtnClickEventRaised += new EventHandler(OnUserRegisterClearBtnClickEventRaised);
        }

        public void SetupUserRegForAdd()
        {
            InitializeValues();

            Dictionary<string, Binding> userModelbindingDictionary = new Dictionary<string, Binding>();

            SetupBindingsForView(userModelbindingDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();

            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            _userRegisterViewUC.SetUpUserRegistrationView(userModelbindingDictionary, accessTypeEventArgs);

            EventHelpers.RaiseEvent(this, UserRegistrationViewReadyToShowEventRaised, new EventArgs());
        }

        private void SetupBindingsForView(Dictionary<string, Binding> userModelbindingDictionary)
        {
            //Create bindings for data the View will use on its textBoxes
            Binding usernameNameBinding = new Binding("Text", this, "Username", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding passwordBinding = new Binding("Text", this, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            Binding confirmPasswordBinding = new Binding("Text", this, "ConfirmPassword", false, DataSourceUpdateMode.OnPropertyChanged);

            //Store bindings into a dictionary for the View to access for its textBoxes
            userModelbindingDictionary.Add("Username", usernameNameBinding);
            userModelbindingDictionary.Add("Password", passwordBinding);
            userModelbindingDictionary.Add("ConfirmPassword", confirmPasswordBinding);
        }

        private void OnUserRegisterBtnClickEventRaised(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {

            _userModelWithoutBinding.Username = _username;
            _userModelWithoutBinding.Password = _password;
            _userModelWithoutBinding.ConfirmPassword = _confirmPassword;

            try
            {
                if (accessTypeEventArgs.AccessTypeValue == AccessTypeEventArgs.AccessType.Add)
                {
                    _userServices.RegisterUser(_userModelWithoutBinding); //Use model service to save updated model to database 
                }
                
                InitializeValues();
            }
            catch (Exception e1)
            {
                ShowErrorMessage("Error Message", e1.Message);
                return;
            }
            EventHelpers.RaiseEvent(this, UserRegisterBtnClickEventRaised, accessTypeEventArgs);
            
            // Display success message/ clear bindings
            // ---------------------------------------
            MessageBox.Show("User Successfully registered");
            _userRegisterViewUC.ClearExistingBindings();
        }

        private void OnUserRegisterClearBtnClickEventRaised(object sender, EventArgs e)
        {
            _userRegisterViewUC.ClearExistingBindings();

            EventHelpers.RaiseEvent(this, UserRegClearBtnClickEventRaised, new EventArgs());
        }


        private void InitializeValues()
        {
            _username = string.Empty;
            _password = string.Empty;
            _confirmPassword = string.Empty;


            _userModelWithoutBinding.Username = string.Empty;
            _userModelWithoutBinding.Password = string.Empty;
            _userModelWithoutBinding.ConfirmPassword = string.Empty;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        public string ConfirmPassword
        {
            get { return this._confirmPassword; }
            set
            {
                if (value == this._confirmPassword) return;
                this._confirmPassword = value;
                NotifyPropertyChanged();
            }
        }
        
    }
}

