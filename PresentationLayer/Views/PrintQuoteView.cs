﻿using CommonComponents;
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
        string glassType;
        public string GlassType
        {
            get
            {
                return glassType;
            }
            set
            {
                glassType = value;
            }
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
        public string LaborandMobilization
        {
            get
            {
                return txtbox_LnM.Text;
            }
            set
            {
                txtbox_LnM.Text = value;
            }
        }
        public string FreightCharge
        {
            get
            {
                return txtbox_FC.Text;
            }
            set
            {
                txtbox_FC.Text = value;
            }
        }
        public string LessDiscount
        {
            get
            {
                return txtbox_LessD.Text;
            }
            set
            {
                txtbox_LessD.Text = value;
            }
        }
        public string RowLimit
        {
            get
            {
                return txtbox_rowlimit.Text;
            }
            set
            {
                txtbox_rowlimit.Text = value;
            }
        }

        public TextBox GetRowLimitTxtBox()
        {
            return txtbox_rowlimit;
        }

        public CheckBox GetLessDiscountchkbox()
        {
            return chkbox_LessD;
        }
        public TextBox GetLessDiscountTxtBox()
        {
            return txtbox_LessD;
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
            this.ShowDialog();
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
        public CheckBox GetSubTotalCheckBox()
        {
            return chkbox_subtotal;
        }

        public ComboBox GetReviewedByCmb()
        {
            return cmb_ReviewedBy;
        }
        public ComboBox GetNotedByCmb()
        {
            return cmb_NotedBy;
        }

        public event EventHandler btnRefreshClickEventRaised;
        public event EventHandler PrintQuoteViewLoadEventRaised;
        public event EventHandler SelectedIndexChangeEventRaised;
        public event EventHandler txtoftexpensesKeyPressEventRaised;
        public event EventHandler chkboxLnMCheckedChangedEventRaised;
        public event EventHandler chkboxFCCheckedChangedEventRaised;
        public event EventHandler chkboxVATCheckedChangedEventRaised;
        public event EventHandler chkboxLessDCheckedChangedEventRaised;
        public event EventHandler chkboxsubtotalCheckedChangedEventRaised;
        public event FormClosingEventHandler PrintQuoteViewFormClosingEventRaised;
        

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

        private void PrintQuoteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHelpers.RaiseFormClosingEvent(sender, PrintQuoteViewFormClosingEventRaised, e);
        }

        private void chkbox_LessD_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxLessDCheckedChangedEventRaised, e);
        }

        private void chkbox_subtotal_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxsubtotalCheckedChangedEventRaised, e);
        }
    }
}
