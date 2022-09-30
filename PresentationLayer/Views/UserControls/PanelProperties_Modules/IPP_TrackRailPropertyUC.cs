using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_TrackRailPropertyUC : IViewCommon
    {
        event EventHandler cmbTrackRailArtNoSelectedValueChangedEventRaised;
        event EventHandler PPTrackRailPropertyUCLoadEventRaised;
    }
}