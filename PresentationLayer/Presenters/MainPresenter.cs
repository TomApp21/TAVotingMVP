using CommonComponets;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Presenters.UserControls.Voter;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : BasePresenter, IMainPresenter
    {

        IMainView _mainView;


        Panel _userControlPanel;

        private ILoginPresenter _userLoginPresenter;
        private IRegisterPresenter _userRegisterPresenter;
        private IRegisterVoterPresenter _voterRegistrationPresenter;


        private List<UserControl> _userControList;

        public IMainView GetMainView() { return _mainView; }
        public void SetMainView(IMainView mainView) { _mainView = mainView; }

        public MainPresenter()
        {

        }

        public MainPresenter(IMainView mainView, IRegisterPresenter registerPresenter, IRegisterVoterPresenter registerVoterPresenter, ILoginPresenter loginPresenter, IErrorMessageView errorMessageView) : base(errorMessageView)
        {
            _mainView = mainView;
            _userControlPanel = _mainView.GetUserControlPanel();

            _userLoginPresenter = loginPresenter;
            _userRegisterPresenter = registerPresenter;
            _voterRegistrationPresenter = registerVoterPresenter;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
   
            
            _mainView.LoginMenuBtnClickEventRaised += new EventHandler(OnUserLoginBtnClickEventRaised);
            _mainView.RegisterMenuBtnClickEventRaised += new EventHandler(OnUserRegisterBtnClickEventRaised);
            _mainView.RegisterVoterMenuBtnClickEventRaised += new EventHandler(OnVoterRegisterBtnClickEventRaised);


            _mainView.MainViewLoadedEventRaised += new EventHandler(OnMainViewLoadedEventRaised);

        }

        public void OnMainViewLoadedEventRaised(object sender, System.EventArgs e)
        {
            _userControList = new List<UserControl>();
            _userControList.Add((UserControl)_userLoginPresenter.GetLoginUserViewUC());
            _userControList.Add((UserControl)_userRegisterPresenter.GetRegisterUserViewUC());

            AssignUserControlToMainViewPanel((BaseUserControUC)_userLoginPresenter.GetLoginUserViewUC());
         

            SetUserControlVisibleInPanel((UserControl)_userLoginPresenter.GetLoginUserViewUC());
        }

 



        public void OnUserLoginBtnClickEventRaised(object sender, System.EventArgs e)
        {
            _userLoginPresenter.SetupUserForLogin();
            SetUserControlVisibleInPanel((UserControl)_userLoginPresenter.GetLoginUserViewUC());
        }

        public void OnUserRegisterBtnClickEventRaised(object sender, System.EventArgs e)
        {
            AssignUserControlToMainViewPanel((BaseUserControUC)_userRegisterPresenter.GetRegisterUserViewUC());

            _userRegisterPresenter.SetupUserRegForAdd();
            SetUserControlVisibleInPanel((UserControl)_userRegisterPresenter.GetRegisterUserViewUC());
        }

        public void OnVoterRegisterBtnClickEventRaised(object sender, System.EventArgs e)
        {
            //_voterRegistrationPresenter.SetupUserRegForAdd();
            SetUserControlVisibleInPanel((UserControl)_voterRegistrationPresenter.GetRegisterVoterViewUC());
        }
  

        private void AssignUserControlToMainViewPanel(BaseUserControUC baseUserControl)
        {
            baseUserControl.SetParentSizeLocationAnchor(_userControlPanel);
        }

        private void SetUserControlVisibleInPanel(UserControl userControl)
        {
            foreach (UserControl uc in _userControList)
            {
                if (uc.Name == userControl.Name)
                {
                    userControl.Visible = true;
                }
                else uc.Visible = false;
            }
        }

    }
}
