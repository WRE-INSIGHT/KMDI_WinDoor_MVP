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
        DateTimePicker GetDateTimePicker();
        ReportViewer GetReportViewer();
        void ShowGlassSummaryView();
    }
}