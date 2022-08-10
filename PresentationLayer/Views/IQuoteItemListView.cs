using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IQuoteItemListView
    {
        event EventHandler TSbtnPrintClickEventRaised;
        event EventHandler TSbtnGlassSummaryClickEventRaised;
        event EventHandler QuoteItemListViewLoadEventRaised;

        Panel GetPnlPrintBody();
        void showQuoteItemList();
    }
}