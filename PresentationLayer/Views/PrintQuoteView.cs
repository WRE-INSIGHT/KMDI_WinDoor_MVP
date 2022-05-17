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

        private void PrintQuoteView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void ShowPrintQuoteView()
        {
            this.Show();
        }
    }
}
