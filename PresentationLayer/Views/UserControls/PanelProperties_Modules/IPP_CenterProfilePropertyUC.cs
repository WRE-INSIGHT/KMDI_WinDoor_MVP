using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_CenterProfilePropertyUC : IViewCommon
    {
        event EventHandler CenterProfileArtNoSelectedValueChangedEventRaised;
        event EventHandler CenterProfilePropertyUCLoadEventRaised;
    }
}