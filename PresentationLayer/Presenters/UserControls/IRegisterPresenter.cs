using CommonComponets;
using PresentationLayer.Views.UserControls;
using System;
using System.ComponentModel;

namespace PresentationLayer.Presenters.UserControls
{
    public interface IRegisterPresenter
    {
        string Username { get; set; }

        string Password { get; set; }
        string ConfirmPassword { get; set; }


        event EventHandler UserRegistrationViewReadyToShowEventRaised;
        event EventHandler UserRegClearBtnClickEventRaised;
        event EventHandler<AccessTypeEventArgs> UserRegisterBtnClickEventRaised;

        event PropertyChangedEventHandler PropertyChanged;

        void SetupUserRegForAdd();
        IRegisterUC GetRegisterUserViewUC();
    }
}