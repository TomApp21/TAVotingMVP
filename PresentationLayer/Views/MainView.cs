using CommonComponents;
using PresentationLayer.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler MainViewLoadedEventRaised;
        public event EventHandler LoginMenuBtnClickEventRaised;
        public event EventHandler RegisterMenuBtnClickEventRaised;
        public event EventHandler RegisterVoterMenuBtnClickEventRaised;
        public event EventHandler ConfirmIdentityMenuBtnClickEventRaised;
        public event EventHandler CreateElectionMenuBtnClickEventRaised;
        public event EventHandler AddCandidateMenuBtnClickEventRaised;
        public event EventHandler CastVoteMenuBtnClickEventRaised;


        public event EventHandler LoggedInSuccessfullyEventRaised;


        private Panel _userControlPanelOrigValues = null;

        private List<Button> NavigationButtonList = null;

        private List<Button> VotersButtonList = null;
        private List<Button> LoginButtonList = null;
        private List<Button> AuditorsButtonList = null;
        private List<Button> AdminButtonList = null;




        public MainView()
        {
            InitializeComponent();
        }

        public void ResetUserControlPanelSizeandLocation()
        {
            userControlPanel.Height = _userControlPanelOrigValues.Height;
            userControlPanel.Width = _userControlPanelOrigValues.Width;
            userControlPanel.Location = _userControlPanelOrigValues.Location;
            //SetVisibilityOfControlsForPanelSliding(true);
        }
        public void ShowMainView()
        {
            this.Show();
        }

        public void ExpandUserControlPanel()
        {
            //SetVisibilityOfControlsForPanelSliding(true);  // was false to diable

            //a.Enabled = true;
        }
        public Panel GetUserControlPanel()
        {
            return userControlPanel;
        }

        //private void SetVisibilityOfControlsForPanelSliding(bool visibility)
        //{
        //    ButtonHelper.SetVisibilityOfButtons(NavigationButtonList, visibility, underlineLabel);

        //    gardenPictureBox.Visible = visibility;
        //}


        public void ShowVoterButtons(int userId, EventArgs e)  // pass in user model or id?
        {
            ButtonHelper.HideAllButtons(NavigationButtonList);
            ButtonHelper.SetVisibilityOfButtons(VotersButtonList);

            EventHelpers.RaiseEvent(this, LoggedInSuccessfullyEventRaised, e);

        }



        public void ShowAdminButtons(int userId, EventArgs e)
        {
            ButtonHelper.HideAllButtons(NavigationButtonList);
            ButtonHelper.SetVisibilityOfButtons(AdminButtonList);

            EventHelpers.RaiseEvent(this, LoggedInSuccessfullyEventRaised, e);

            // raise event
        }

        public void ShowAuditorButtons()
        {
            ButtonHelper.HideAllButtons(NavigationButtonList);
            ButtonHelper.SetVisibilityOfButtons(AuditorsButtonList);
        }




        private void MainView_Load(object sender, EventArgs e)
        {
            NavigationButtonList = new List<Button>() { loginBtn, registerBtn, registerVoterButton, CastVoteButton, AddCandidateBtn, CreateElectionBtn, ViewElectionBtn };
            VotersButtonList = new List<Button>() { registerVoterButton, CastVoteButton };
            LoginButtonList = new List<Button>() {loginBtn, registerBtn };
            AdminButtonList = new List<Button>() { ConfirmIdentitiesButton, AddCandidateBtn, CreateElectionBtn };
            AuditorsButtonList = new List<Button>() { ViewElectionBtn };

            //ButtonHelper.SetGroupToBorderless(NavigationButtonList);
            ButtonHelper.HideAllButtons(NavigationButtonList);
            ButtonHelper.SetVisibilityOfButtons(LoginButtonList);


            _userControlPanelOrigValues = new Panel();

            _userControlPanelOrigValues.Height = userControlPanel.Height;
            _userControlPanelOrigValues.Width = userControlPanel.Width;
            _userControlPanelOrigValues.Location = new Point(userControlPanel.Location.X, userControlPanel.Location.Y);

            ButtonHelper.SetUnderlinePosition(registerBtn, underlineLabel);

            FormHelper.SetFormAppearance(this);

            EventHelpers.RaiseEvent(objectRaisingEvent: this, eventHandlerRaised: MainViewLoadedEventRaised, eventArgs: e);
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, LoginMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(loginBtn, underlineLabel);
        }
        private void registerBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, RegisterMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(registerBtn, underlineLabel);

        }
        private void registerVoterButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, RegisterVoterMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(registerBtn, underlineLabel);
        }

        private void CastVoteButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, CastVoteMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(CastVoteButton, underlineLabel);
        }


        private void ConfirmIdentitiesButton_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ConfirmIdentityMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(ConfirmIdentitiesButton, underlineLabel);

        }

        private void CreateElectionBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, CreateElectionMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(CreateElectionBtn, underlineLabel);
        }

        private void AddCandidateBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, AddCandidateMenuBtnClickEventRaised, e);

            ButtonHelper.SetUnderlinePosition(AddCandidateBtn, underlineLabel);

        }

        private void moreOptionsPictureBox_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
