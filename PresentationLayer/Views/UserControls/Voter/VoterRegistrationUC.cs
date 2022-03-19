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

namespace PresentationLayer.Views.UserControls.Voter
{
    public partial class VoterRegistrationUC : BaseUserControUC, IVoterRegistrationUC
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

        public event EventHandler<AccessTypeEventArgs> VoterRegistrationBtnClickEventRaised;
        public event EventHandler VoterRegClearBtnClickEventRaised;

        public VoterRegistrationUC()
        {
            InitializeComponent();

            _accessTypeEventArgs = new AccessTypeEventArgs();
        }

        public void SetUpVoterRegistrationView(Dictionary<string, Binding> bindingDictionary,
                              AccessTypeEventArgs accessTypeEventArgs)
        {
            BindUserModelToView(bindingDictionary);
            _accessTypeEventArgs = accessTypeEventArgs;
        }

        public void BindUserModelToView(Dictionary<string, Binding> bindingDictionary)
        {
            ClearExistingBindings();

            FirstNameTextInputUC.InputBoxDataBindings.Add(bindingDictionary["FirstName"]);
            LastNameTextInputUCoxUC2.InputBoxDataBindings.Add(bindingDictionary["LastName"]);
            DOBTextInputBoxUC.InputBoxDataBindings.Add(bindingDictionary["DateOfBirth"]);
            AddLine1TextBoxInputUC.InputBoxDataBindings.Add(bindingDictionary["AddressLine1"]);
            AddLine2TextBoxInputUC.InputBoxDataBindings.Add(bindingDictionary["AddressLine2"]);
            PostcodeTextBoxInputUC.InputBoxDataBindings.Add(bindingDictionary["Postcode"]);
            NatInsTextInputBoxUC.InputBoxDataBindings.Add(bindingDictionary["NationalInsurance"]);
            //electioni.InputBoxDataBindings.Add(bindingDictionary["LastName"]);

        }

        public void ClearExistingBindings()
        {
            FirstNameTextInputUC.InputBoxText = "";
            LastNameTextInputUCoxUC2.InputBoxText = "";

            FirstNameTextInputUC.InputBoxDataBindings.Clear();
            LastNameTextInputUCoxUC2.InputBoxDataBindings.Clear();
            DOBTextInputBoxUC.InputBoxDataBindings.Clear();
            AddLine1TextBoxInputUC.InputBoxDataBindings.Clear();
            AddLine2TextBoxInputUC.InputBoxDataBindings.Clear();
            PostcodeTextBoxInputUC.InputBoxDataBindings.Clear();
            NatInsTextInputBoxUC.InputBoxDataBindings.Clear();
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, VoterRegClearBtnClickEventRaised, e);

        }

        private void RegisterButton_Click_1(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, VoterRegistrationBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);

        }

        public void FormatAlreadyRegisteredView()
        {
            FirstNameTextInputUC.InputBoxReadOnly = true;
            LastNameTextInputUCoxUC2.InputBoxReadOnly = true;
            DOBTextInputBoxUC.InputBoxReadOnly = true;
            AddLine1TextBoxInputUC.InputBoxReadOnly = true;
            AddLine2TextBoxInputUC.InputBoxReadOnly = true;
            PostcodeTextBoxInputUC.InputBoxReadOnly = true;
            NatInsTextInputBoxUC.InputBoxReadOnly = true;

            ClearButton.Visible = false;
            RegisterButton.Visible = false;
            alreadyRegisteredLabel.Visible = true;
        }

        private void VoterRegistrationUC_Load(object sender, EventArgs e)
        {
            //if (FirstNameTextInputUC.InputBoxText != String.Empty)
            //{
            //    FirstNameTextInputUC.InputBoxReadOnly = true;
            //    LastNameTextInputUCoxUC2.InputBoxReadOnly = true;
            //    DOBTextInputBoxUC.InputBoxReadOnly = true;
            //    AddLine1TextBoxInputUC.InputBoxReadOnly = true;
            //    AddLine2TextBoxInputUC.InputBoxReadOnly = true;
            //    PostcodeTextBoxInputUC.InputBoxReadOnly = true;
            //    NatInsTextInputBoxUC.InputBoxReadOnly = true;
            //}
        }
    }
}
