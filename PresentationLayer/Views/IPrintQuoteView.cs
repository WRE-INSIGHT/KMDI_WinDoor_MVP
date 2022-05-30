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



        void ShowPrintQuoteView();


        event EventHandler btnRefreshClickEventRaised;
        event EventHandler PrintQuoteViewLoadEventRaised;


        ReportViewer GetReportViewer();
        BindingSource GetBindingSource();
        DateTimePicker GetDTPDate();
    }
}