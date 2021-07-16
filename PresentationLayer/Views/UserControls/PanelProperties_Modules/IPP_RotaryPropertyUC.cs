using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RotaryPropertyUC : IViewCommon
    {
        event EventHandler cmbLockingKitSelectedValueChangedEventRaised;
        event EventHandler cmbRotaryArtNoSelectedValueChangedEventRaised;
        event EventHandler PPRotaryPropertyLoadEventRaised;
    }
}