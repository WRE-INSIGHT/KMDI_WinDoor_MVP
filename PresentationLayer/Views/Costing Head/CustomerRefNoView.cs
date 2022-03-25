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
    public partial class CustomerRefNoView : Form, ICustomerRefNoView
    {
        public CustomerRefNoView()
        {
            InitializeComponent();
        }

        #region GetSet
        public CheckedListBox ChkList_CustRefNo
        {
            get
            {
                return chkList_CustRefNo;
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

        public string CustomerReferenceNo
        {
            get
            {
                return txt_SearchProj.Text.Trim();
            }
        }

        #endregion

        public void ShowThis()
        {
            this.Show();
            this.TopMost = true;
        }

        public event EventHandler CustomerRefNoViewLoadEventRaised;
        public event EventHandler btnAcceptClickEventRaised;
        public event EventHandler btnAddCustRefClickEventRaised;
        public event FormClosedEventHandler CustomerRefNoViewFormClosedEventRaised;

        private void CustomerRefNoView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CustomerRefNoViewLoadEventRaised, e);
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAcceptClickEventRaised, e);
        }

        private void btn_AddCustRef_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddCustRefClickEventRaised, e);
        }

        private void CustomerRefNoView_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHelpers.RaiseFormClosedEvent(sender, CustomerRefNoViewFormClosedEventRaised, e);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CloseThis()
        {
            this.Close();
        }
    }
}
