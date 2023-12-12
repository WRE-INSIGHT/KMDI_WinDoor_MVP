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
        Timer BGChangedTimer();
        void GetUCdispose();

        event EventHandler partialAdjustmentUC_LoadEventRaised;
        event EventHandler paPnlAfter_ResizeEventRaised;
        event EventHandler btn_HideAndShow_ClickEventRaised;
        event EventHandler btn_UsePartialAdjustment_ClickEventRaised;
        event EventHandler pnl_Header_MouseLeaveEventRaised;
        event EventHandler tmr_BGChange_TickEventRaised;
        event EventHandler pnl_Header_MouseEnterEventRaised;
        event EventHandler btn_HideAndShow_MouseEnterEventRaised;
        event EventHandler btn_HideAndShow_MouseLeaveEventRaised;
        event EventHandler btn_UsePartialAdjustment_MouseEnterEventRaised;
        event EventHandler btn_UsePartialAdjustment_MouseLeaveEventRaised;
        event MouseEventHandler pnl_Header_LeftMouseDownEventRaised;
        event EventHandler pnl_Header_RightMouseDownClickEventRaised;
        event EventHandler RightMouseDownLeaveExceptionEventRaised;
    }
}