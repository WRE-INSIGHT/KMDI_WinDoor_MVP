using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_DHandle_IOLockingPropertyUC : IViewCommon
    {
        event EventHandler cmbD_IOLockingArtNoSelectedValueChangedEventRaised;
        event EventHandler PPDHandleIOLockingPropertyUCLoadEventRaised;
    }
}