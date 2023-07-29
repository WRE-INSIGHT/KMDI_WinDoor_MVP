using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPrintQuoteView
    {
        string GlassType { get; set; }
        string QuotationAddress { get; set; }
        string QuotationSalutation { get; set; }
        string QuotationBody { get; set; }
        string QuotationOuofTownExpenses { get; set; }
        string VatPercentage { get; set; }
        string LaborandMobilization { get; set; }
        string FreightCharge { get; set; }
        string LessDiscount { get; set; }
        string RowLimit { get; set; }
        TextBox GetRowLimitTxtBox();
        TextBox GetLessDiscountTxtBox();
        CheckBox GetLessDiscountchkbox();
        CheckBox ShowLastPage();
        Label GetUniversalLabel();
        Button GetRefreshBtn();
        TextBox GetOutofTownExpenses();
        CheckedListBox GetChkLstBox();
        CheckBox GetShowPageNum();
        CheckBox GetSubTotalCheckBox();
        ComboBox GetReviewedByCmb();
        ComboBox GetNotedByCmb();

        void ShowPrintQuoteView();
        
        event EventHandler btnRefreshClickEventRaised;
        event EventHandler PrintQuoteViewLoadEventRaised;
        event EventHandler SelectedIndexChangeEventRaised;
        event EventHandler txtoftexpensesKeyPressEventRaised;
        event EventHandler chkboxLnMCheckedChangedEventRaised;  
        event EventHandler chkboxFCCheckedChangedEventRaised;
        event EventHandler chkboxVATCheckedChangedEventRaised;
        event EventHandler chkboxLessDCheckedChangedEventRaised;
        event EventHandler chkboxsubtotalCheckedChangedEventRaised;
        event FormClosingEventHandler PrintQuoteViewFormClosingEventRaised;

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