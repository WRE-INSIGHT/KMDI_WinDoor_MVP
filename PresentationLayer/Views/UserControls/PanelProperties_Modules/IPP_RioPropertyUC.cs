using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_RioPropertyUC : IViewCommon
    {
        event EventHandler cmbRioArtNoSelectedValueChangedEventRaised;
        event EventHandler cmbRioArtNo2SelectedValueChangedEventRaised;
        event EventHandler PPRioPropertyLoadEventRaised;
    }
}