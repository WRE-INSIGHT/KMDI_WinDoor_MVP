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

        public BindingSource GetBindingSourceNP()
        {
            return bindingSource1;
        }

        private bool _checkedshowprice;
        public bool CheckedShowPrice
        {
            get
            {
                return _checkedshowprice;
            }
            set
            {
                _checkedshowprice = value;
            }
        }
      
        public CheckBox ShowPrice()
        {
            return chkbx_ShowPrice;
        }

        public event EventHandler PringGlassSummaryViewLoadEventRaised;
        public event EventHandler btnRefreshClickEventRaised;
        private void PrintGlassSummaryView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PringGlassSummaryViewLoadEventRaised, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnRefreshClickEventRaised, e);
        }

    }
}
