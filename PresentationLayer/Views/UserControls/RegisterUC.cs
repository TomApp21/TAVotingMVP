using CommonComponents;
using CommonComponets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class RegisterUC : BaseUserControUC, IRegisterUC
    {
        private AccessTypeEventArgs _accessTypeEventArgs;


        public AccessTypeEventArgs AccessTypeEventArgs
        {
            get { return _accessTypeEventArgs; }
            set
            {
                if (value == _accessTypeEventArgs) return;
                _accessTypeEventArgs = value;
            }
        }

        public event EventHandler<AccessTypeEventArgs> UserRegisterBtnClickEventRaised;
        public event EventHandler UserRegisterClearBtnClickEventRaised;

        public RegisterUC()
        {
            InitializeComponent();

            _accessTypeEventArgs = new AccessTypeEventArgs();
        }

        public void SetUpUserRegistrationView(Dictionary<string, Binding> bindingDictionary,
                                      AccessTypeEventArgs accessTypeEventArgs)
        {
            BindUserModelToView(bindingDictionary);
            _accessTypeEventArgs = accessTypeEventArgs;
        }

        public void BindUserModelToView(Dictionary<string, Binding> bindingDictionary)
        {
            ClearExistingBindings();

            UsernameRegTextInputUC.InputBoxDataBindings.Add(bindingDictionary["Username"]);
            PasswordRegTextInputUC.InputBoxDataBindings.Add(bindingDictionary["Password"]);
            ConPwordRegTextInputUC.InputBoxDataBindings.Add(bindingDictionary["ConfirmPassword"]);
        }

        public void ClearExistingBindings()
        {
            UsernameRegTextInputUC.InputBoxText = "";
            PasswordRegTextInputUC.InputBoxText = "";
            ConPwordRegTextInputUC.InputBoxText = "";

            UsernameRegTextInputUC.InputBoxDataBindings.Clear();
            PasswordRegTextInputUC.InputBoxDataBindings.Clear();
            ConPwordRegTextInputUC.InputBoxDataBindings.Clear();
        }



 



        private void CancelButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, UserRegisterClearBtnClickEventRaised, e);

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, UserRegisterBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);
        }
    }
}

