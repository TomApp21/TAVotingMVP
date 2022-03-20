using CommonComponets;
using DomainLayer.Models.Voter;
using PresentationLayer.Views.UserControls.Admin;
using ServiceLayer.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.UserControls.Admin
{
    internal class ConfirmIdentityPresenter : IConfirmIdentityPresenter
    {
        public event EventHandler DepartmentListYesDeleteBtnClickEventRaised;
        public event EventHandler VoterRegistrationViewReadyToShowEventRaised;
        public event EventHandler VoterRegClearBtnClickEventRaised;

        public event EventHandler<AccessTypeEventArgs> VoterRegisterBtnClickEventRaised;

        private IConfirmIdentitiesUC _confirmIdentitiesViewUC;
        private IAdminServices _adminServices;

        //private int _loggedInUserId;
        //private  _departmentDetailPresenter;
        //private IDepartmentListDeleteView _departmentListDeleteView;

        //BindingList to load with collection of DepartmentModels returned from repository
        //This list will be used to construct the BindingSource for the Views DataGridView
        BindingList<VoterSelectDto> _voterSelectDtoBindingList;

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource _voterSelectDtoBindingSource;

        public IConfirmIdentitiesUC GetConfirmIdentityViewUC()

        {
            return _confirmIdentitiesViewUC;
        }

        //public IConfirmIdentitiesUC GetRegisterVoterViewUC(int loggedInUserId)
        //{
        //    _loggedInUserId = loggedInUserId;
        //    return _confirmIdentitiesViewUC;
        //}

        public ConfirmIdentityPresenter(IConfirmIdentitiesUC confirmIdenitiesListViewUC, IAdminServices adminServices)
        {
            _confirmIdentitiesViewUC = confirmIdenitiesListViewUC;
            _adminServices = adminServices;

            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _confirmIdentitiesViewUC.ApproveIdentityListMenuClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnApproveIdentityListMenuClickEventRaised);

            _confirmIdentitiesViewUC.DenyIdentityListMenuClickEventRaised += new EventHandler<AccessTypeEventArgs>(OnDenyIdentityListMenuClickEventRaised);
        }

        //public void OnDepartmentListYesDeleteBtnClickEventRaised(object sender, EventArgs e)
        //{
        //    DepartmentSelectDto departmentSelectDto = (DepartmentSelectDto)_departmentSelectDtoBindingSource.Current;
        //    _departmentServices.DeleteById(departmentSelectDto.DepartmentId);

        //    LoadAllDepartmentsFromDbToGrid();
        //}

        //public void OnDeleteSelectedDepartmentInGridMenuClickEventRaised(object sender, EventArgs e)
        //{
        //    DepartmentSelectDto departmentSelectDto = (DepartmentSelectDto)_departmentSelectDtoBindingSource.Current;

        //    string DepartNameToDelete = departmentSelectDto.DepartmentName;

        //    _departmentListDeleteView.ShowDepartmentListDeleteView(DepartNameToDelete);
        //}

        public void OnApproveIdentityListMenuClickEventRaised(object sender, AccessTypeEventArgs e)
        {
            VoterSelectDto voterSelectDto = (VoterSelectDto)_voterSelectDtoBindingSource.Current;

            _adminServices.UpdateConfirmIdentity(voterSelectDto, true);


            LoadAllVotersFromDbToGrid();
            // refresh?
        }

        public void OnDenyIdentityListMenuClickEventRaised(object sender, AccessTypeEventArgs e)
        {
            VoterSelectDto voterSelectDto = (VoterSelectDto)_voterSelectDtoBindingSource.Current;

            _adminServices.UpdateConfirmIdentity(voterSelectDto, false);

            LoadAllVotersFromDbToGrid();

        }

        private void BuildDatasourceForAllVotersList()
        {
            IEnumerable<VoterSelectDto> allVotersAwaitingConfirmation = (IEnumerable<VoterSelectDto>)_adminServices.GetVoterSelectList();

            _voterSelectDtoBindingList = new BindingList<VoterSelectDto>();
            foreach (VoterSelectDto votersDetails in allVotersAwaitingConfirmation)
            {
                _voterSelectDtoBindingList.Add(votersDetails);
            };

            _voterSelectDtoBindingSource = new BindingSource();//Reset

            this._voterSelectDtoBindingSource.DataSource = _voterSelectDtoBindingList;
        }

        public void LoadAllVotersFromDbToGrid()
        {
            int rowHeight = 17;

            BuildDatasourceForAllVotersList();

            Dictionary<string, float> gridColumnWidthsDictionary = new Dictionary<string, float>();
            SetConIdentitiesListViewGridColumnWidths(gridColumnWidthsDictionary);

            Dictionary<string, string> headingsDictionary = new Dictionary<string, string>();
            SetConIdentitiesListViewGridHeadings(headingsDictionary);

            AccessTypeEventArgs accessTypeEventArgs = new AccessTypeEventArgs();
            accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Update;

            _confirmIdentitiesViewUC.LoadConIdentityListToGrid(_voterSelectDtoBindingSource, headingsDictionary, gridColumnWidthsDictionary, rowHeight, accessTypeEventArgs);
        }

        private void SetConIdentitiesListViewGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary)
        {
            gridColumnWidthsDictionary["FirstName"] = (float)(.10);
            gridColumnWidthsDictionary["LastName"] = (float)(.10);
            gridColumnWidthsDictionary["DateOfBirth"] = (float)(.12);
            gridColumnWidthsDictionary["AddressLine1"] = (float)(.17);
            gridColumnWidthsDictionary["AddressLine2"] = (float)(.17);
            gridColumnWidthsDictionary["Postcode"] = (float)(.10);
            gridColumnWidthsDictionary["NationalInsurance"] = (float)(.12);
            gridColumnWidthsDictionary["ElectionId"] = (float)(.08);
            gridColumnWidthsDictionary["Options"] = (float)(.08);

        }

        private void SetConIdentitiesListViewGridHeadings(Dictionary<string, string> headingsDictionary)
        {
            headingsDictionary["FirstName"] = "First Name";
            headingsDictionary["LastName"] = "Last Name";
            headingsDictionary["DateOfBirth"] = "DOB";
            headingsDictionary["AddressLine1"] = "Address Line 1";
            headingsDictionary["AddressLine2"] = "Address Line 2";
            headingsDictionary["Postcode"] = "Postcode";
            headingsDictionary["NationalInsurance"] = "National Insurance";
            headingsDictionary["ElectionId"] = "Election Id";
            headingsDictionary["OptionsButton"] = "Options";
        }
    }
}
