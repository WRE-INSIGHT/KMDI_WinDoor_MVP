using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RotoswingForSlidingPropertyUC : IViewCommon
    {
        event EventHandler cmbRotoswingForSlidingNoSelectedValueChangedEventRaised;
        event EventHandler PPRotoswingForSlidingPropertyUCLoadEventRaised;
    }
}