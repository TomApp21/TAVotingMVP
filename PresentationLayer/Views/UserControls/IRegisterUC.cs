using CommonComponets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IRegisterUC
    {
        event EventHandler<AccessTypeEventArgs> UserRegisterBtnClickEventRaised;
        event EventHandler UserRegisterClearBtnClickEventRaised;

        void SetUpUserRegistrationView(Dictionary<string, Binding> bindingDictionary,
                                      AccessTypeEventArgs accessTypeEventArgs);
        void ClearExistingBindings();
    }
}
