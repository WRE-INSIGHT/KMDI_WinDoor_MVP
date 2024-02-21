using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_MotorizedPropertyUC : IViewCommon
    {
        event EventHandler chkMotorizedCheckedChangedEventRaised;
        event EventHandler PPMotorizedPropertyUCLoadEventRaised;
        event EventHandler cmbMotorizedMechSelectedValueChangedEventRaised;
        event EventHandler chkRemoteCheckedChangedEventRaised;
        event EventHandler numSetQtyValueChangedEventRaised;
        event EventHandler num2dHingeQtyValueChangedEventRaised;
        event EventHandler numButtHingeQtyValueChangedEventRaised;
    }
}