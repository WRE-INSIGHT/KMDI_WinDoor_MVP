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
        public string VatPercentage
        {
            get
            {
                return txtbox_VAT.Text;
            }
            set
            {
                txtbox_VAT.Text = value;
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
        public Label GetAddressLabel()
        {
            return lbl_address;
        }
        public Label GetSalutationLabel()
        {
            return label6;
        }
        public Label GetBodyLabel()
        {
            return label7;
        }
        public RichTextBox GetQuotationBody()
        {
            return rtbox_Body;
        }
        public RichTextBox GetQuotationSalutation()
        {
            return rtbox_Salutation;
        }
        public RichTextBox GetQuotationAddress()
        {
            return rtbox_Address;
        }
        public Label GetAdditionalInfoLabel()
        {
            return lbl_addinfo;
        }
        public CheckBox GetLabor_N_MobiChkbox()
        {
            return chkbox_LnM;
        }
        public CheckBox GetFreightChargesChkbox()
        {
            return chkbox_FC;
        }
        public CheckBox GetVatChkbox()
        {
            return chkbox_VAT;
        }
        public TextBox GetLabor_N_MobiTxtBox()
        {
            return txtbox_LnM;
        }
        public TextBox GetFreightChargeTxtBox()
        {
            return txtbox_FC;
        }
        public TextBox GetVatTxtbox()
        {
            return txtbox_VAT;
        }

        public event EventHandler btnRefreshClickEventRaised;
        public event EventHandler PrintQuoteViewLoadEventRaised;
        public event EventHandler SelectedIndexChangeEventRaised;
        public event EventHandler txtoftexpensesKeyPressEventRaised;
        public event EventHandler chkboxLnMCheckedChangedEventRaised;
        public event EventHandler chkboxFCCheckedChangedEventRaised;
        public event EventHandler chkboxVATCheckedChangedEventRaised;

        private void PrintQuoteView_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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

        private void txt_oftexpenses_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EventHelpers.RaiseEvent(sender, txtoftexpensesKeyPressEventRaised, e);
            }
        }

        private void chkbox_LnM_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender,chkboxLnMCheckedChangedEventRaised,e);
        }

        private void chkbox_FC_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender,chkboxFCCheckedChangedEventRaised,e);
        }

        private void chkbox_VAT_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxVATCheckedChangedEventRaised, e);
        }
    }
}
