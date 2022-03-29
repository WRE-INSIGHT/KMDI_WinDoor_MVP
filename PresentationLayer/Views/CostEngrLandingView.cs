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

        public DataGridView DGV_CustRefNo
        {
            get
            {
                return dgv_CustRefNo;
            }
        }

        #endregion

        public event EventHandler CostEngrLandingViewLoadEventRaised;
        public event DataGridViewCellMouseEventHandler dgvAssignedProjectsCellMouseDoubleClickEventRaised;
        public event EventHandler btnbackNavClickEventRaised;
        public event EventHandler btnforwardNavClick;

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
            EventHelpers.RaiseEvent(sender, btnbackNavClickEventRaised, e);
        }

        private void btn_forwardNav_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnforwardNavClick, e);
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

        public bool SetSelectedIndex_TabpageNav(int index)
        {
            bool has_set = false;
            if (index > tab_Nav.TabCount - 1 || index < 0)
            {
                has_set = false;
            }
            else if (index <= tab_Nav.TabCount -1)
            {
                has_set = true;
            }

            if (has_set)
            {
                tab_Nav.SelectedIndex = index;
            }

            if (index > 0)
            {
                btn_backNav.Enabled = true;
                btn_backNav.BackgroundImage = Properties.Resources.enabled_back_arrow_104px;
            }
            else if (index <= 0)
            {
                btn_backNav.Enabled = false;
                btn_backNav.BackgroundImage = Properties.Resources.disabled_back_arrow_104px;
            }

            if (index < tab_Nav.TabPages.Count - 1)
            {
                btn_forwardNav.Enabled = true;
                btn_forwardNav.BackgroundImage = Properties.Resources.enabled_forward_button_104px;
            }
            else if (index >= tab_Nav.TabPages.Count - 1)
            {
                btn_forwardNav.Enabled = false;
                btn_forwardNav.BackgroundImage = Properties.Resources.disabled_forward_button_104px;
            }

            return has_set;
        }

        private void dgv_CustRefNo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common.rowpostpaint(sender, e);
        }
    }
}
