using CommonComponents;
using CommonComponets;
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
    public partial class ConfirmIdentitiesUC : BaseUserControUC, IConfirmIdentitiesUC
    {

        private AccessTypeEventArgs _accessTypeEventArgs;

        public AccessTypeEventArgs AccessTypeEventArgs
        {
            get { return _accessTypeEventArgs; }
            set
            {
                if (value == _accessTypeEventArgs) return;
                _accessTypeEventArgs = value;
            }
        }

        public ConfirmIdentitiesUC()
        {
            InitializeComponent();
        }
        public event EventHandler ConIdentityListViewLoadEventRaised;
        public event EventHandler<AccessTypeEventArgs> DenyIdentityListMenuClickEventRaised;
        public event EventHandler<AccessTypeEventArgs> ApproveIdentityListMenuClickEventRaised;

        const int columnForGridButton = 9;


        private void ConfirmIdentitiesUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ConIdentityListViewLoadEventRaised, e);

        }

        public void ReloadConfirmIdentitiesGrid(BindingSource confirmIdentitiesListBindingSource)
        {
            this.ConfirmIdentitiesListDataGridView.DataSource = confirmIdentitiesListBindingSource;
        }

        public void LoadConIdentityListToGrid(BindingSource departmentListBindingSource, Dictionary<string, string> headingsDictionary, Dictionary<string, float> gridColumnWidthsDictionary, int rowHeight, AccessTypeEventArgs accessTypeEventArgs)
        {
            _accessTypeEventArgs = accessTypeEventArgs;


            this.ConfirmIdentitiesListDataGridView.RowTemplate.Height = 32;

            this.ConfirmIdentitiesListDataGridView.DataSource = departmentListBindingSource;

            SetGridHeaderText(headingsDictionary);
            ConfirmIdentitiesListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfirmIdentitiesListDataGridView.AllowUserToAddRows = false; //Removes blank row at end of grid load
            ConfirmIdentitiesListDataGridView.ReadOnly = true;

            int optionsWidth = 0;
            SetGridColumnWidths(gridColumnWidthsDictionary, ref optionsWidth);

            /*
                  DataGridViewButtonColumn buttonActionColumn = new DataGridViewButtonColumn();
                  buttonActionColumn.Name = "Options";
                  buttonActionColumn.Text = "Options";
                  buttonActionColumn.Width = optionsButtonWidth;


                  int columnIndex = 4;
                  if (DepartmentListDataGridView.Columns["Options"] == null)
                  {
                    DepartmentListDataGridView.Columns.Insert(columnIndex, buttonActionColumn);
                  }
            */
            // --------------------------------------------

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Options";
            imageColumn.Name = "Options";
            imageColumn.Width = optionsWidth;
            imageColumn.Image = Properties.Resources.MoreOptionsBlackDotsOnWhite20x20;
            //int columnIndex = 4;
            if (ConfirmIdentitiesListDataGridView.Columns["Options"] == null)
            {
                ConfirmIdentitiesListDataGridView.Columns.Add(imageColumn);
            }

        }

        private void SetGridHeaderText(Dictionary<string, string> headingsDictionary)
        {
            ConfirmIdentitiesListDataGridView.Columns["FirstName"].HeaderText = headingsDictionary["FirstName"];
            ConfirmIdentitiesListDataGridView.Columns["LastName"].HeaderText = headingsDictionary["LastName"];
            ConfirmIdentitiesListDataGridView.Columns["DateOfBirth"].HeaderText = headingsDictionary["DateOfBirth"];
            ConfirmIdentitiesListDataGridView.Columns["AddressLine1"].HeaderText = headingsDictionary["AddressLine1"];
            ConfirmIdentitiesListDataGridView.Columns["AddressLine2"].HeaderText = headingsDictionary["AddressLine2"];
            ConfirmIdentitiesListDataGridView.Columns["Postcode"].HeaderText = headingsDictionary["Postcode"];
            ConfirmIdentitiesListDataGridView.Columns["NationalInsurance"].HeaderText = headingsDictionary["NationalInsurance"];
            ConfirmIdentitiesListDataGridView.Columns["ElectionId"].HeaderText = headingsDictionary["ElectionId"];


        }
        private void SetGridColumnWidths(Dictionary<string, float> gridColumnWidthsDictionary, ref int optionsWidth)
        {
            int GridWidth = (ConfirmIdentitiesListDataGridView.Width - ConfirmIdentitiesListDataGridView.RowHeadersWidth -
                       SystemInformation.VerticalScrollBarWidth);


            ConfirmIdentitiesListDataGridView.Columns["FirstName"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["FirstName"]);
            ConfirmIdentitiesListDataGridView.Columns["LastName"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["LastName"]);
            ConfirmIdentitiesListDataGridView.Columns["DateOfBirth"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["DateOfBirth"]);
            ConfirmIdentitiesListDataGridView.Columns["AddressLine1"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["AddressLine1"]);
            ConfirmIdentitiesListDataGridView.Columns["AddressLine2"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["AddressLine2"]);
            ConfirmIdentitiesListDataGridView.Columns["Postcode"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["Postcode"]);
            ConfirmIdentitiesListDataGridView.Columns["NationalInsurance"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["NationalInsurance"]);
            ConfirmIdentitiesListDataGridView.Columns["ElectionId"].Width = (int)((GridWidth) * gridColumnWidthsDictionary["ElectionId"]);
            
            optionsWidth = (int)((GridWidth) * gridColumnWidthsDictionary["Options"]);
        }



        private void approveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnApproveSelectedIdentityInGridMenuClick(sender, (AccessTypeEventArgs)_accessTypeEventArgs);
        }

        private void denyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnDenySelectedIdentityInGridMenuClick(sender, (AccessTypeEventArgs)_accessTypeEventArgs);
        }

        private void OnApproveSelectedIdentityInGridMenuClick(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {
            EventHelpers.RaiseEvent(this, ApproveIdentityListMenuClickEventRaised, accessTypeEventArgs);
        }
        private void OnDenySelectedIdentityInGridMenuClick(object sender, AccessTypeEventArgs accessTypeEventArgs)
        {
            EventHelpers.RaiseEvent(this, DenyIdentityListMenuClickEventRaised, accessTypeEventArgs);
        }



        private void ConfirmIdentitiesListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ConfirmIdentitiesListDataGridView.Columns["Options"].Index)
            {
                optionsContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void ConfirmIdentitiesListDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (ConfirmIdentitiesListDataGridView.Columns[e.ColumnIndex].Name == "Options")
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void ConfirmIdentitiesListDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (ConfirmIdentitiesListDataGridView.Columns[e.ColumnIndex].Name == "Options")
                {
                    Cursor.Current = Cursors.Hand;
                }
            }
        }
    }
}
