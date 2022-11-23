using CommonComponents;
using Microsoft.Reporting.WinForms;
using System;
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


        public event EventHandler btnRefreshClickEventRaised;
        public event EventHandler PrintQuoteViewLoadEventRaised;
        private void PrintQuoteView_Load(object sender, EventArgs e)
        {
            rtbox_Address.Text = "";
            rtbox_Salutation.Text = "";
            rtbox_Body.Text = "";
            dtp_Date.Value = DateTime.Now;
            EventHelpers.RaiseEvent(sender, PrintQuoteViewLoadEventRaised, e);
        }

        public void ShowPrintQuoteView()
        {
            this.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnRefreshClickEventRaised, e);
        }

        public ReportViewer GetReportViewer()
        {
            return reportViewer1;
        }

        public BindingSource GetBindingSource()
        {
            return BSQuotation;
        }

        public DateTimePicker GetDTPDate()
        {
            return dtp_Date;
        }

        private void BSQuotation_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
