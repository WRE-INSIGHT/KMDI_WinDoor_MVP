using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RotolinePropertyUC : IViewCommon
    {
        event EventHandler cmbRotolineArtNoSelectedValueChangedEventRaised;
        event EventHandler PPRotolinePropertyLoadEventRaised;
    }
}