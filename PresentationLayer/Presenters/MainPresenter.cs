using CommonComponets;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Presenters.UserControls.Admin;
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
        private IConfirmIdentityPresenter _confirmIdentityPresenter;
        private ICreateElectionPresenter _createElectionPresenter;
        private IAddCandidatePresenter _addCandidatePresenter;
        private ICastVotePresenter _castVotePresenter;


        private List<UserControl> _userControList;

        public IMainView GetMainView() { return _mainView; }
        public void SetMainView(IMainView mainView) { _mainView = mainView; }

        public MainPresenter()
        {

        }

        public MainPresenter(IMainView mainView, ICastVotePresenter castVotePresenter, IAddCandidatePresenter addCandidatePresenter, ICreateElectionPresenter createElectionPresenter, IConfirmIdentityPresenter confirmIdentityPresenter, IRegisterPresenter registerPresenter, IRegisterVoterPresenter registerVoterPresenter, ILoginPresenter loginPresenter, IErrorMessageView errorMessageView) : base(errorMessageView)
        {
            _mainView = mainView;
            _userControlPanel = _mainView.GetUserControlPanel();

            _userLoginPresenter = loginPresenter;
            _userRegisterPresenter = registerPresenter;
            _voterRegistrationPresenter = registerVoterPresenter;
            _confirmIdentityPresenter = confirmIdentityPresenter;
            _createElectionPresenter = createElectionPresenter;
            _addCandidatePresenter = addCandidatePresenter;
            _castVotePresenter = castVotePresenter;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
   
            
            _mainView.LoginMenuBtnClickEventRaised += new EventHandler(OnUserLoginBtnClickEventRaised);
            _mainView.RegisterMenuBtnClickEventRaised += new EventHandler(OnUserRegisterBtnClickEventRaised);
            _mainView.RegisterVoterMenuBtnClickEventRaised += new EventHandler(OnVoterRegisterBtnClickEventRaised);
            _mainView.ConfirmIdentityMenuBtnClickEventRaised += new EventHandler(OnConfirmIdentityMenuBtnClickEventRaised);
            _mainView.CreateElectionMenuBtnClickEventRaised += new EventHandler(OnCreateElectionMenuBtnClickEventRaised);
            _mainView.AddCandidateMenuBtnClickEventRaised += new EventHandler(OnAddCandidateMenuBtnClickEventRaised);
            _mainView.CastVoteMenuBtnClickEventRaised += new EventHandler(OnCastVoteMenuClickEventRaised);


            _mainView.MainViewLoadedEventRaised += new EventHandler(OnMainViewLoadedEventRaised);

            _mainView.LoggedInSuccessfullyEventRaised += new EventHandler(OnLogInSuccessEventRaised);

        }

        public void OnMainViewLoadedEventRaised(object sender, System.EventArgs e)
        {
            _userControList = new List<UserControl>();
            _userControList.Add((UserControl)_userLoginPresenter.GetLoginUserViewUC());
            _userControList.Add((UserControl)_userRegisterPresenter.GetRegisterUserViewUC());
            _userControList.Add((UserControl)_voterRegistrationPresenter.GetRegisterVoterViewUC());
            _userControList.Add((UserControl)_confirmIdentityPresenter.GetConfirmIdentityViewUC());
            _userControList.Add((UserControl)_createElectionPresenter.GetCreateElectionViewUC());

            _userControList.Add((UserControl)_addCandidatePresenter.GetAddCandidateViewUC());
            _userControList.Add((UserControl)_castVotePresenter.GetCastCandidateVoteViewUC());



            AssignUserControlToMainViewPanel((BaseUserControUC)_userLoginPresenter.GetLoginUserViewUC());
            AssignUserControlToMainViewPanel((BaseUserControUC)_userRegisterPresenter.GetRegisterUserViewUC());
            AssignUserControlToMainViewPanel((BaseUserControUC)_voterRegistrationPresenter.GetRegisterVoterViewUC());
            AssignUserControlToMainViewPanel((BaseUserControUC)_confirmIdentityPresenter.GetConfirmIdentityViewUC());
            AssignUserControlToMainViewPanel((BaseUserControUC)_createElectionPresenter.GetCreateElectionViewUC());
            AssignUserControlToMainViewPanel((BaseUserControUC)_addCandidatePresenter.GetAddCandidateViewUC());
            AssignUserControlToMainViewPanel((BaseUserControUC)_castVotePresenter.GetCastCandidateVoteViewUC());





            _userLoginPresenter.SetupUserForLogin();
            SetUserControlVisibleInPanel((UserControl)_userLoginPresenter.GetLoginUserViewUC());
        }

 
        public void OnUserLoginBtnClickEventRaised(object sender, System.EventArgs e)
        {
            _userLoginPresenter.SetupUserForLogin();
            SetUserControlVisibleInPanel((UserControl)_userLoginPresenter.GetLoginUserViewUC());
        }

        public void OnUserRegisterBtnClickEventRaised(object sender, System.EventArgs e)
        {

            _userRegisterPresenter.SetupUserRegForAdd();
            SetUserControlVisibleInPanel((UserControl)_userRegisterPresenter.GetRegisterUserViewUC());
        }

        public void OnVoterRegisterBtnClickEventRaised(object sender, System.EventArgs e)
        {
            int u = _userLoginPresenter.UserId;

            _voterRegistrationPresenter.SetupVoterReg(u);

            SetUserControlVisibleInPanel((UserControl)_voterRegistrationPresenter.GetRegisterVoterViewUC(u));
        }

        public void OnCastVoteMenuClickEventRaised(object sender, System.EventArgs e)
        {
            int u = _userLoginPresenter.UserId;

            _castVotePresenter.SetupCastCandidateVoteViewForAdd(u);

            SetUserControlVisibleInPanel((UserControl)_castVotePresenter.GetCastCandidateVoteViewUC());
        }






        public void OnConfirmIdentityMenuBtnClickEventRaised(object sender, System.EventArgs e)
        {
            SetUserControlVisibleInPanel((UserControl)_confirmIdentityPresenter.GetConfirmIdentityViewUC());
        }

        public void OnCreateElectionMenuBtnClickEventRaised(object sender, System.EventArgs e)
        {
            _createElectionPresenter.SetupCreateElectionViewForAdd();
            SetUserControlVisibleInPanel((UserControl)_createElectionPresenter.GetCreateElectionViewUC());
        }

        public void OnAddCandidateMenuBtnClickEventRaised(object sender, System.EventArgs e)
        {

            _addCandidatePresenter.SetupAddCandidateViewForAdd();
            SetUserControlVisibleInPanel((UserControl)_addCandidatePresenter.GetAddCandidateViewUC());
        }

        





        public void OnLogInSuccessEventRaised(object sender, System.EventArgs e)
        {
            // SETR UP, pass in id?
            int u = _userLoginPresenter.UserId;
            bool isVoter = _userLoginPresenter.IsVoter;
            bool isAdmin = _userLoginPresenter.IsAdmin;
            bool isAuditor = _userLoginPresenter.IsAuditor;

            if (isVoter)
            {
                _voterRegistrationPresenter.SetupVoterReg(u);
                SetUserControlVisibleInPanel((UserControl)_voterRegistrationPresenter.GetRegisterVoterViewUC(u));

            }
            if (isAdmin)
            {
                _confirmIdentityPresenter.LoadAllVotersFromDbToGrid();
                SetUserControlVisibleInPanel((UserControl)_confirmIdentityPresenter.GetConfirmIdentityViewUC());

            }
            if (isAuditor)
            {

            }


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
