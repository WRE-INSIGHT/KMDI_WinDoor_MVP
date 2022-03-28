using CommonComponents;
using PresentationLayer.CommonMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CostEngrLandingView : Form, ICostEngrLandingView
    {
        public CostEngrLandingView()
        {
            InitializeComponent();
        }

        #region GetSet

        public DataGridView DGV_ASsignedProject
        {
            get
            {
                return dgv_AssignedProjects;
            }
        }

        #endregion

        public event EventHandler CostEngrLandingViewLoadEventRaised;
        public event DataGridViewCellMouseEventHandler dgvAssignedProjectsCellMouseDoubleClickEventRaised;

        public void ShowThis()
        {
            this.ShowDialog();
        }

        private void CostEngrLandingView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CostEngrLandingViewLoadEventRaised, e);
        }

        private void btn_backNav_Click(object sender, EventArgs e)
        {
            tab_Nav.SelectedIndex = (tab_Nav.SelectedIndex > 0) ? tab_Nav.SelectedIndex - 1 : 0;
        }

        private void btn_forwardNav_Click(object sender, EventArgs e)
        {
            tab_Nav.SelectedIndex += 1;
        }

        CommonFunctions common = new CommonFunctions();

        private void dgv_AssignedProjects_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common.rowpostpaint(sender, e);
        }

        private void dgv_AssignedProjects_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EventHelpers.RaiseDatagridviewCellMouseEvent(sender, dgvAssignedProjectsCellMouseDoubleClickEventRaised, e);
        }

        public void SetText_LblNav(string text)
        {
            lbl_nav.Text = text;
        }
    }
}
