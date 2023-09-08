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
        event EventHandler partialAdjustmentUC_LoadEventRaised;
        event EventHandler paPnlAfter_ResizeEventRaised;
        event EventHandler btn_HideAndShow_ClickEventRaised;
        event EventHandler btn_UsePartialAdjustment_ClickEventRaised;
    }
}