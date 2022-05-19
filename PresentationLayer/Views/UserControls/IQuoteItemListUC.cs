using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IQuoteItemListUC
    {
        event EventHandler QuoteItemListUCLoadEventRaised;

        TextBox GetTboxItemName();
        TextBox GetTboxDimension();
        RichTextBox GetRtboxDesc();
        PictureBox GetPboxItemImage();

    }
}