using CommonComponents;
using Microsoft.Reporting.WinForms;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class PrintQuoteView : Form, IPrintQuoteView
    {
        public PrintQuoteView()
        {
            InitializeComponent();
        }
        public string QuotationAddress
        {
            get
            {
                return rtbox_Address.Text;
            }
            set
            {
                rtbox_Address.Text = value;
            }

        }
        public string QuotationSalutation
        {
            get
            {
                return rtbox_Salutation.Text;
            }
            set
            {
                rtbox_Salutation.Text = value;
            }

        }
        public string QuotationBody
        {
            get
            {
                return rtbox_Body.Text;
            }
            set
            {
                rtbox_Body.Text = value;
            }

        }
        public string QuotationOuofTownExpenses
        {
            get
            {
                return txt_oftexpenses.Text;
            }
            set
            {
                txt_oftexpenses.Text = value;
            }
        }
        public ReportViewer GetReportViewer()
        {
            return reportViewer1;
        }
        public BindingSource GetBindingSource()
        {
            return BSQuotation;
        }
        public CheckBox ShowLastPage()
        {
            return chkbox_show;
        }
        public TextBox GetOutofTownExpenses()
        {
            return txt_oftexpenses;
        }     
        public DateTimePicker GetDTPDate()
        {
            return dtp_Date;
        }
        public Label GetUniversalLabel()
        {
            return lbl_UniversalLabel;
        }
        public Button GetRefreshBtn()
        {
            return btnRefresh;
        }
        public void ShowPrintQuoteView()
        {
            this.Show();
        }
        public CheckedListBox GetChkLstBox()
        {
            return chklstbox_itemnum;
        }
        public CheckBox GetShowPageNum()
        {
            return chk_showpagenum;
        }

        public event EventHandler btnRefreshClickEventRaised;
        public event EventHandler PrintQuoteViewLoadEventRaised;
        public event EventHandler SelectedIndexChangeEventRaised;
        private void PrintQuoteView_Load(object sender, EventArgs e)
        {
            DSQuotation _dsq = new DSQuotation();

            rtbox_Address.Text = "";
            rtbox_Salutation.Text = "";
            rtbox_Body.Text = "";
            txt_oftexpenses.Text = "";
            dtp_Date.Value = DateTime.Now;

            EventHelpers.RaiseEvent(sender, PrintQuoteViewLoadEventRaised, e);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnRefreshClickEventRaised, e);
        }

       
        private void BSQuotation_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chklstbox_itemnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SelectedIndexChangeEventRaised, e);
        }

       
    }
}
