using Microsoft.Reporting.WinForms;
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
        CheckBox ShowLastPage();
        Label GetUniversalLabel();
        Button GetRefreshBtn();
        TextBox GetOutofTownExpenses();
        void ShowPrintQuoteView();


        event EventHandler btnRefreshClickEventRaised;
        event EventHandler PrintQuoteViewLoadEventRaised;


        ReportViewer GetReportViewer();
        BindingSource GetBindingSource();
        DateTimePicker GetDTPDate();
    }
}