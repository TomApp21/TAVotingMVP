using CommonComponets;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters.UserControls
{
    public interface ILoginPresenter
    { 
        //event EventHandler UserLoginViewReadyToShowEventRaised;
        event EventHandler UserLoginCancelBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> UserLoginBtnClickEventRaised;

        string Username { get; set; }
        string Password { get; set; }
       

        event PropertyChangedEventHandler PropertyChanged;
        void SetupUserForLogin();

        ILoginUC GetLoginUserViewUC();
    }
}
