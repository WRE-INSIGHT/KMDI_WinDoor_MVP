using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IQuoteItemListView
    {
        event EventHandler TSbtnPrintClickEventRaised;
        event EventHandler TSbtnGlassSummaryClickEventRaised;
        event EventHandler QuoteItemListViewLoadEventRaised;
        event EventHandler TsbtnContractSummaryClickEventRaised;
        event FormClosedEventHandler QuoteItemListViewFormClosedEventRaised;

        Panel GetPnlPrintBody();
        void showQuoteItemList();
        void closeQuoteItemList();
    }
}