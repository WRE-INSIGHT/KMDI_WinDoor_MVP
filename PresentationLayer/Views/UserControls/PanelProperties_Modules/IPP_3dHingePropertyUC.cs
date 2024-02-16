using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_3dHingePropertyUC : IViewCommon
    {
        event EventHandler PP3dHingeLoadEventRaised;
        event EventHandler num3dHingeQtyValueChangedEventRaised;
        event EventHandler num3dHingeQtyValueKeyUpEventRaised;
    }
}