using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IQuoteItemListUC
    {
        event EventHandler QuoteItemListUCLoadEventRaised;
        event EventHandler lblQuantityDoubleClickEventRaised;
        event EventHandler NudItemQuantityValueChangedEventRaised;
        event EventHandler LblDiscountDoubleClickEventRaised;
        event EventHandler NudItemDiscountValueChangedEventRaised;
        event EventHandler LblPriceDoubleClickEventRaised;
        event EventHandler NudItemPriceValueChangedEventRaised;
        event EventHandler ComputeNetPriceTextChangeEventRaised;
        event KeyEventHandler NudItemPriceKeyDownEventRaised;
        event KeyEventHandler NudItemDiscountKeyDownEventRaised;
        event KeyEventHandler NudItemQuantityKeyDownEventRaised;

        NumericUpDown itemQuantity { get; set; }
        NumericUpDown itemDiscount { get; set; }
        NumericUpDown itemPrice { get; set; }
        PictureBox GetPboxItemImage();
        PictureBox GetPboxTopView();
        Label GetLblQuantity();
        Label GetLblDiscount();
        Label GetLblPrice();
        Label GetLblNetPrice();

        string ItemName { get; set; }
        string itemWindoorNumber { get; set; }
        string itemDesc { get; set; }


    }
}