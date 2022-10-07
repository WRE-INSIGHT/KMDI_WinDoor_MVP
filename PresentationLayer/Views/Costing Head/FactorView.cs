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
    public partial class FactorView : Form, IFactorView
    {
        public FactorView()
        {
            InitializeComponent();
        }

        public DataGridView DGV_Factor
        {
            get
            {
                return dgv_Factor;
            }
        }

        public string SearchFactorStr
        {
            get
            {
                return txt_SearchFactor.Text;
            }
        }

        CommonFunctions common = new CommonFunctions();
        public event EventHandler FactorViewLoadEventRaised;
        public event EventHandler EditToolStripMenuItemClickEventRaised;
        public event EventHandler btnSearchClickEventRaised;

        public void ShowThis()
        {
            this.ShowDialog();
        }

        private void FactorView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, FactorViewLoadEventRaised, e);
        }

        private void dgv_Factor_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common.rowpostpaint(sender, e);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, EditToolStripMenuItemClickEventRaised, e);
        }

        private void btn_SearchFactor_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSearchClickEventRaised, e);
        }

        private void txt_SearchFactor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_SearchFactor.PerformClick();
            }
        }
    }
}
