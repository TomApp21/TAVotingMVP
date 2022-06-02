﻿using CommonComponents;
using CommonComponets;
using DomainLayer.Models.Candidate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Voter
{
    public partial class CastVoteViewUC : UserControl
    {
        public CastVoteViewUC()
        {
            InitializeComponent();
            _accessTypeEventArgs = new AccessTypeEventArgs();
        }
        private AccessTypeEventArgs _accessTypeEventArgs;

        private int _selectedCandidateId;

        public AccessTypeEventArgs AccessTypeEventArgs
        {
            get { return _accessTypeEventArgs; }
            set
            {
                if (value == _accessTypeEventArgs) return;
                _accessTypeEventArgs = value;
            }
        }

        public int SelectedCandidateId
        {
            get { return _selectedCandidateId; }
            set
            {
                if (value == _selectedCandidateId) return;
                _selectedCandidateId = value;
            }
        }

        public event EventHandler<AccessTypeEventArgs> CastVoteCandidateBtnClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> CandidateDDSelectedIndexChangedEventRaised;

        //public event EventHandler AdminCreateElectionViewReadyToShowEventRaised;



        public void SetUpUserCastVoteCandidateView(Dictionary<string, Binding> bindingDictionary, IEnumerable<CandidateModel> _candidates,
                                      AccessTypeEventArgs accessTypeEventArgs)
        {
            BindCandidateModelToView(bindingDictionary);
            _accessTypeEventArgs = accessTypeEventArgs;

            this.dropdownCandidateList.DataSource = _candidates;
            this.dropdownCandidateList.ValueMember = "CandidateId";
            this.dropdownCandidateList.DisplayMember = "CandidateName";
        }

        public void BindCandidateModelToView(Dictionary<string, Binding> bindingDictionary)
        {
            ClearExistingBindings();

            ElectionNameTextInputUC.InputBoxDataBindings.Add(bindingDictionary["ElectionName"]);
        }

        public void ClearExistingBindings()
        {
            ElectionNameTextInputUC.InputBoxText = "";

            ElectionNameTextInputUC.InputBoxDataBindings.Clear();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Add;

            SelectedCandidateId = (int)dropdownCandidateList.SelectedValue;

            EventHelpers.RaiseEvent(this, CastVoteCandidateBtnClickEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);

        }

        private void dropdownCandidateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _accessTypeEventArgs.AccessTypeValue = AccessTypeEventArgs.AccessType.Read;

            EventHelpers.RaiseEvent(this, CandidateDDSelectedIndexChangedEventRaised, (AccessTypeEventArgs)_accessTypeEventArgs);

        }
    }
}
