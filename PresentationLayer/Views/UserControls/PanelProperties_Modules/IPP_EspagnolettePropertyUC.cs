using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_EspagnolettePropertyUC : IViewCommon
    {
        event EventHandler cmbEspagnoletteSelectedValueEventRaised;
        event EventHandler PPEspagnolettePropertyLoadEventRaised;
    }
}