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

namespace PresentationLayer.Views.Costing_Head
{
    public partial class AssignAEView : Form, IAssignAEView
    {
        public AssignAEView()
        {
            InitializeComponent();
        }
        public DataGridView DGV_Client
        {
            get
            {
                return dgv_Client;
            }
        }
        public string SearchAEICStr
        {
            get
            {
                return txt_SearchAEICStr.Text.Trim();
            }
        }
        public string SearchClientStr
        {
            get
            {
                return txt_SearchClientStr.Text.Trim();
            }
        }
        public DataGridView DGV_AEIC
        {
            get
            {
                return dgv_AEIC;
            }
        }
        public DataGridView DGV_Project
        {
            get
            {
                return dgv_Project;
            }
        }
        public event EventHandler AssignAEViewLoadEventRaised;
        public event EventHandler btnSearchProjClickEventRaised;
        public event EventHandler btnSearchAEICClickEventRaised;
        public event EventHandler btnEqualClickEventRaised;
        public event EventHandler DeleteToolStripButtonClickEventRaised;
        public event EventHandler btnSaveClickEventRaised;
        public event EventHandler AddProjectToolStripButtonClickEventRaised;

        public void ShowThis()
        {
            this.Show();
        }
        CommonFunctions common = new CommonFunctions();
        private void AssignAE_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, AssignAEViewLoadEventRaised, e);
        }
        private void dgv_Client_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common.rowpostpaint(sender, e);
        }
        private void btn_SearchProj_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSearchProjClickEventRaised, e);
        }
        private void txt_SearchClientStr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_SearchProj.PerformClick();
            }
        }
        private void txt_SearchAEICStr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_SearchProj.PerformClick();
            }
        }
        private void btn_SearchAEIC_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSearchAEICClickEventRaised, e);
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnEqualClickEventRaised, e);
        }
        private void dgv_Project_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common.rowpostpaint(sender, e);
        }
        private void dgv_AEIC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common.rowpostpaint(sender, e);
        }
        private void deletetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DeleteToolStripButtonClickEventRaised, e);
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSaveClickEventRaised, e);
        }

        private void assignAEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, AddProjectToolStripButtonClickEventRaised, e);
        }
    }
}