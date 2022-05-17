using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class QuoteItemListView : Form, IQuoteItemListView
    {
        public QuoteItemListView()
        {
            InitializeComponent();
        }

        public event EventHandler TSbtnPrintClickEventRaised;


        private void TSbtnPrint_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, TSbtnPrintClickEventRaised, e);
        }

        public void showQuoteItemList()
        {
            this.Show();
        }

        private void QuoteItemListView_Load(object sender, EventArgs e)
        {

        }

    }
}
