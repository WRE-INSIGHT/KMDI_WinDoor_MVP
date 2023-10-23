using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IPartialAdjustmentBaseHolderUC
    {
        event EventHandler PartialAdjustmentBaseHolderUC_LoadEventRaised;
        event EventHandler btn_Expnd_ClickEventRaised;
        event EventHandler btn_addItemQty_ClickEventRaised;
        UserControl GetPABaseHolderUC();
        void PABaseHolderBringToFront();
        void PABaseHolderDispose();
        void PABaseHolderInvalidate();
        void PABaseHolderSendToBack();
        Panel PABaseHolderPanelTitle();
        Panel PABaseHolderPanelBody();
        Button PABaseHolderExpandBtn();
        Button PABaseHolderAddItemQtyBtn();
        Label PABaseHolderItemName();


    }
}