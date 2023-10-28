using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IPartialAdjustmentUC
    {
        RichTextBox GetCurrentItemDescription();
        PictureBox GetCurrentItemDesignImage();
        Panel GetCurrentItemMainPanel();
        RichTextBox GetOldItemDescription();
        PictureBox GetOldItemDesignImage();
        UserControl GetAdjustmentUCForm();
        Label GetPAItemNo();
        Label GetOldItemPrice();
        Label GetCurrentItemPrice();
        Panel GetHeaderPanel();

        event EventHandler partialAdjustmentUC_LoadEventRaised;
        event EventHandler paPnlAfter_ResizeEventRaised;
        event EventHandler btn_HideAndShow_ClickEventRaised;
        event EventHandler btn_UsePartialAdjustment_ClickEventRaised;
        event EventHandler pnl_Header_MouseHoverEventRaised;
        event EventHandler pnl_Header_MouseLeaveEventRaised;
    }
}