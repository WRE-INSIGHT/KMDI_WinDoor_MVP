using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPrintGlassSummaryView
    {
        event EventHandler PringGlassSummaryViewLoadEventRaised;
        event EventHandler btnRefreshClickEventRaised;

        BindingSource GetBindingSource();
        BindingSource GetBindingSourceNP();
        DateTimePicker GetDateTimePicker();
        ReportViewer GetReportViewer();
        CheckBox ShowPrice();
        void ShowGlassSummaryView();
        bool CheckedShowPrice { get; set; }
    }
}