using CommonComponents;
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
    public partial class CostEngrEmployeeView : Form, ICostEngrEmployeeView
    {
        public CostEngrEmployeeView()
        {
            InitializeComponent();
        }

        #region GetSet

        public CheckedListBox ChkList_CE
        {
            get
            {
                return chkList_CE;
            }
        }

        public Panel Pnl_Status
        {
            get
            {
                return pnl_Status;
            }
        }

        public Label Lbl_Status
        {
            get
            {
                return lbl_Status;
            }
        }

        #endregion

        public void ShowThis()
        {
            this.Show();
        }

        public event EventHandler CostEngrEmployeeViewLoadEventRaised;
        public event EventHandler btnAcceptClickEventRaised;

        private void CostEngrEmployeeView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CostEngrEmployeeViewLoadEventRaised, e);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAcceptClickEventRaised, e);
        }
    }
}
