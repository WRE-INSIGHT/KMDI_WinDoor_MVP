using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_HingePropertyUC : IViewCommon
    {
        event EventHandler cmbHingeSelectedValueChangedEventRaised;
        event EventHandler PPHingeLoadEventRaised;
    }
}