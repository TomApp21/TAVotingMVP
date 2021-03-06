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
    public partial class LoginUC : BaseUserControUC, ILoginUC
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

        public event EventHandler<AccessTypeEventArgs> UserLoginBtnClickEventRaised;
        public event EventHandler UserLoginCancelBtnClickEventRaised;

        public LoginUC()
        {
            InitializeComponent();

            _accessTypeEventArgs = new AccessTypeEventArgs();
        }

        public void SetUpUserLoginView(Dictionary<string, Binding> bindingDictionary,
                              AccessTypeEventArgs accessTypeEventArgs)
        {
            BindUserModelToView(bindingDictionary);
            _accessTypeEventArgs = accessTypeEventArgs;
        }

        public void BindUserModelToView(Dictionary<string, Binding> bindingDictionary)
        {
            ClearExistingBindings();

            UsernameTextInputUC.InputBoxDataBindings.Add(bindingDictionary["Username"]);
            PasswordTextInputUC.InputBoxDataBindings.Add(bindingDictionary["Password"]);
        }

        public void ClearExistingBindings()
        {
            UsernameTextInputUC.InputBoxText = "";
            PasswordTextInputUC.InputBoxText = "";

            UsernameTextInputUC.InputBoxDataBindings.Clear();
            PasswordTextInputUC.InputBoxDataBindings.Clear();
        }





        private void CancelButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, UserLoginCancelBtnClickEventRaised, e);

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, UserLoginBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);

        }
    }
}

