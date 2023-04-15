﻿using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPrintQuoteView
    {
        string QuotationAddress { get; set; }
        string QuotationSalutation { get; set; }
        string QuotationBody { get; set; }
        string QuotationOuofTownExpenses { get; set; }
        string VatPercentage { get; set; }
        CheckBox ShowLastPage();
        Label GetUniversalLabel();
        Button GetRefreshBtn();
        TextBox GetOutofTownExpenses();
        CheckedListBox GetChkLstBox();
        CheckBox GetShowPageNum();
        void ShowPrintQuoteView();


        event EventHandler btnRefreshClickEventRaised;
        event EventHandler PrintQuoteViewLoadEventRaised;
        event EventHandler SelectedIndexChangeEventRaised;
        event EventHandler txtoftexpensesKeyPressEventRaised;
        event EventHandler chkboxLnMCheckedChangedEventRaised;
        event EventHandler chkboxFCCheckedChangedEventRaised;
        event EventHandler chkboxVATCheckedChangedEventRaised;

        ReportViewer GetReportViewer();
        BindingSource GetBindingSource();
        DateTimePicker GetDTPDate();
        RichTextBox GetQuotationBody();
        RichTextBox GetQuotationSalutation();
        RichTextBox GetQuotationAddress();
        Label GetAddressLabel();
        Label GetSalutationLabel();
        Label GetBodyLabel();
        Label GetAdditionalInfoLabel();
        CheckBox GetLabor_N_MobiChkbox();
        CheckBox GetFreightChargesChkbox();
        CheckBox GetVatChkbox();
        TextBox GetLabor_N_MobiTxtBox();
        TextBox GetFreightChargeTxtBox();
        TextBox GetVatTxtbox();

    }
}