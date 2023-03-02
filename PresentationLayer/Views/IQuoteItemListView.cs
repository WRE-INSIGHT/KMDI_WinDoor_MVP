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
        event EventHandler chkboxSelectallCheckedChangeEventRaised;

        Panel GetPnlPrintBody();
        void showQuoteItemList();
        void closeQuoteItemList();
        CheckBox GetChkboxSelectAll();
        bool GetItemListUC_CheckBoxState { get; set; }
        bool RenderPdfAtBackground { get; set; }
    }
}