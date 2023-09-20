using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IPartialAdjustmenItemDisabledUC
    {
        Panel PanelBody();
        event EventHandler btn_Cancel_ClickEventRaised;
        event EventHandler btn_Yes_ClickEventRaised;
        event EventHandler PartialAdjustmenItemDisabledUC_LoadEventRaised;
        event EventHandler PartialAdjustmenItemDisabledUC_ResizeEventRaised;

        UserControl GetPartialAdjustmentItemDisableUC();
        void ItemInfoDisabledBringToFront();
        void ItemInfoDisabledSendToBack();
        void DisposeThis();
        void InvalidateItemDisabled();
    }
}