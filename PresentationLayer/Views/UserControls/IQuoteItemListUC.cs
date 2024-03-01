using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IQuoteItemListUC : IViewCommon
    {
        event EventHandler QuoteItemListUCLoadEventRaised;
        event EventHandler lblQuantityDoubleClickEventRaised;
        event EventHandler NudItemQuantityValueChangedEventRaised;
        event EventHandler LblDiscountDoubleClickEventRaised;
        event EventHandler NudItemDiscountValueChangedEventRaised;
        event EventHandler LblPriceDoubleClickEventRaised;
        event EventHandler NudItemPriceValueChangedEventRaised;
        event EventHandler ComputeNetPriceTextChangeEventRaised;
        event EventHandler tboxItemNameTextChangedEventRaised;
        event EventHandler tboxWindoorNumberTextChangedEventRaised;
        event EventHandler suggestedPriceToolStripMenuItemClickEventRaised;
        event EventHandler setAllDiscountToolStripMenuItemClickEventRaised;
        event EventHandler rtboxDescTextChangedEventRaised;
        event EventHandler nudWoodecValueChangedEventRaised;

        event KeyEventHandler NudItemPriceKeyDownEventRaised;
        event KeyEventHandler NudItemDiscountKeyDownEventRaised;
        event KeyEventHandler NudItemQuantityKeyDownEventRaised;

        NumericUpDown itemQuantity { get; set; }
        NumericUpDown itemDiscount { get; set; }
        NumericUpDown itemPrice { get; set; }
        NumericUpDown woodecAddl { get; set; }
        PictureBox GetPboxItemImage();
        //PictureBox GetPboxTopView();
        Label GetLblQuantity();
        Label GetLblDiscount();
        Label GetLblPrice();
        Label GetLblNetPrice();
        CheckBox GetChkboxItemImage();
        NumericUpDown GetNudWoodec();
        CheckBox showitemMage { get; set; }
        string ItemName { get; set; }
        string ItemNumber { get; set; }
        string itemWindoorNumber { get; set; }
        string itemDesc { get; set; }


    }
}