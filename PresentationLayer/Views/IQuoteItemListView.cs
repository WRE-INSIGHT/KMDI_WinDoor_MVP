using System;

namespace PresentationLayer.Views
{
    public interface IQuoteItemListView
    {
        event EventHandler TSbtnPrintClickEventRaised;

        void showQuoteItemList();
    }
}