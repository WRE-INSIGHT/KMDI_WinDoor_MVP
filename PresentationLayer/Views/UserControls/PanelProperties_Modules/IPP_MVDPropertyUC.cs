using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_MVDPropertyUC : IViewCommon
    {
        event EventHandler cmbMVDArtNoSelectedValueChangedEventRaised;
        event EventHandler PPMVDPropertyLoadEventRaised;
    }
}