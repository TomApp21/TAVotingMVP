using CommonComponets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface ILoginUC
    {

        event EventHandler<AccessTypeEventArgs> UserLoginBtnClickEventRaised;
        event EventHandler UserLoginCancelBtnClickEventRaised;

        void SetUpUserLoginView(Dictionary<string, Binding> bindingDictionary,
                              AccessTypeEventArgs accessTypeEventArgs);
        void ClearExistingBindings();
    }
}
