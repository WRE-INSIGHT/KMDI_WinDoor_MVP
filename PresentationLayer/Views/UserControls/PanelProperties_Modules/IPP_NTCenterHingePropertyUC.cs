using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_NTCenterHingePropertyUC : IViewCommon
    {
        event EventHandler NTCenterHingePropertyUCLoadEventRaised;
        event EventHandler CmbNTCenterHingeSelectedValueChangedEventRaised;
    }
}