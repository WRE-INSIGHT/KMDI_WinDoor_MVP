using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_CenterHingePropertyUC : IViewCommon
    {
        event EventHandler CenterHingePropertyUCLoadEventRaised;
        event EventHandler CmbCenterHingeSelectedValueChangedEventRaised;
    }
}