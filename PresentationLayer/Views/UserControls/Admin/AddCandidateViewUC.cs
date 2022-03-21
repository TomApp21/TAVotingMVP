﻿using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Election;
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
    public partial class AddCandidateViewUC : BaseUserControUC, IAddCandidateViewUC
    {

        private AccessTypeEventArgs _accessTypeEventArgs;

        private int _selectedElectionId;

        public AccessTypeEventArgs AccessTypeEventArgs
        {
            get { return _accessTypeEventArgs; }
            set
            {
                if (value == _accessTypeEventArgs) return;
                _accessTypeEventArgs = value;
            }
        }

        public int SelectedElectionId
        {
            get { return _selectedElectionId; }
            set
            {
                if (value == _selectedElectionId) return;
                _selectedElectionId = value;
            }
        }

        public event EventHandler<AccessTypeEventArgs> CreateCandidateBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> ElectionDDSelectedIndexChangedEventRaised;

        //public event EventHandler AdminCreateElectionViewReadyToShowEventRaised;
        public AddCandidateViewUC()
        {
            InitializeComponent();
            _accessTypeEventArgs = new AccessTypeEventArgs();

        }



        public void SetUpUserCreateCandidateView(Dictionary<string, Binding> bindingDictionary, List<IElectionModel> allValidElections,
                                      AccessTypeEventArgs accessTypeEventArgs)
        {
            BindCandidateModelToView(bindingDictionary);
            _accessTypeEventArgs = accessTypeEventArgs;

            this.dropdownElectionList.DataSource = null;
            dropdownElectionList.DataSource = allValidElections;
            dropdownElectionList.DisplayMember = "ElectionName";
            dropdownElectionList.ValueMember = "ElectionId";
        }

        public void BindCandidateModelToView(Dictionary<string, Binding> bindingDictionary)
        {
            ClearExistingBindings();

            CandidateNameTextInputUC.InputBoxDataBindings.Add(bindingDictionary["CandidateName"]);

          
        }

        public void ClearExistingBindings()
        {
            CandidateNameTextInputUC.InputBoxText = "";
            //dropdownElectionList.SelectedIndex = 0;

            CandidateNameTextInputUC.InputBoxDataBindings.Clear();
        }


        private void dropdownElectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedElectionId = (int)dropdownElectionList.SelectedValue;
           
            _accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Read;

            EventHelpers.RaiseEvent(this, ElectionDDSelectedIndexChangedEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            EventHelpers.RaiseEvent(this, CreateCandidateBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);

        }
    }
}