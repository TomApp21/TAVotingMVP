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

namespace PresentationLayer.Views.UserControls.Admin
{
    public partial class CreateElectionViewUC : BaseUserControUC, ICreateElectionViewUC
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

        public event EventHandler<AccessTypeEventArgs> CreateElectionBtnClickEventRaised;
        public event EventHandler CreateElectionClearBtnClickEventRaised;

        //public event EventHandler AdminCreateElectionViewReadyToShowEventRaised;


        public CreateElectionViewUC()
        {
            InitializeComponent();

            _accessTypeEventArgs = new AccessTypeEventArgs();
        }

        public void SetUpUserCreateElectionView(Dictionary<string, Binding> bindingDictionary,
                                      AccessTypeEventArgs accessTypeEventArgs)
        {
            BindUserModelToView(bindingDictionary);
            _accessTypeEventArgs = accessTypeEventArgs;
        }

        public void BindUserModelToView(Dictionary<string, Binding> bindingDictionary)
        {
            ClearExistingBindings();

            ElectionNameTextInputUC.InputBoxDataBindings.Add(bindingDictionary["ElectionName"]);
            StartDateTextInputUCoxUC2.InputBoxDataBindings.Add(bindingDictionary["StartDate"]);
            EndDateTextInputBoxUC.InputBoxDataBindings.Add(bindingDictionary["EndDate"]);
        }

        public void ClearExistingBindings()
        {
            ElectionNameTextInputUC.InputBoxText = "";
            StartDateTextInputUCoxUC2.InputBoxText = "";
            EndDateTextInputBoxUC.InputBoxText = "";

            ElectionNameTextInputUC.InputBoxDataBindings.Clear();
            StartDateTextInputUCoxUC2.InputBoxDataBindings.Clear();
            EndDateTextInputBoxUC.InputBoxDataBindings.Clear();
        }



        private void CreateButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, CreateElectionBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, CreateElectionClearBtnClickEventRaised, e);

        }
    }
}
