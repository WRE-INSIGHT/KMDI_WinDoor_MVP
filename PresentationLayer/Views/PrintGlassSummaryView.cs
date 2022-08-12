using CommonComponents;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class PrintGlassSummaryView : Form, IPrintGlassSummaryView
    {
        public PrintGlassSummaryView()
        {
            InitializeComponent();
        }
        public DateTimePicker GetDateTimePicker()
        {
            return dtp_Date;
        }
        public ReportViewer GetReportViewer()
        {
            return reportViewer1;
        }

        public void ShowGlassSummaryView()
        {
            this.Show();
        }
        public BindingSource GetBindingSource()
        {
            return BSGlassSummary;
        }


        public event EventHandler PringGlassSummaryViewLoadEventRaised;
        public event EventHandler btnRefreshClickEventRaised;
        private void PringGlassSummaryView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PringGlassSummaryViewLoadEventRaised, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnRefreshClickEventRaised, e);
        }
    }
}
