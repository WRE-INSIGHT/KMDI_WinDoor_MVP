using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_SlidingTypePropertyUC : IViewCommon
    {
        event EventHandler cmbSlidingTypeSelectedValueChangedEventRaised;
        event EventHandler PPSlidingTypePropertyUCLoadEventRaised;
    }
}