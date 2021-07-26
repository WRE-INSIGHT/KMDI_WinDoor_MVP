using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_CornerDrivePropertyUC : IViewCommon
    {
        event EventHandler cmbCornerDriveSelectedValueChangedEventRaised;
        event EventHandler PPCornerDriveCLoadEventRaised;
    }
}