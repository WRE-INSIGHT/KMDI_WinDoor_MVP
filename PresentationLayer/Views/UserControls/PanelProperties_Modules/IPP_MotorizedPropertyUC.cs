using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_MotorizedPropertyUC : IViewCommon
    {
        event EventHandler chkMotorizedCheckedChangedEventRaised;
        event EventHandler PPMotorizedPropertyUCLoadEventRaised;
        event EventHandler cmbMotorizedMechSelectedValueChangedEventRaised;
    }
}