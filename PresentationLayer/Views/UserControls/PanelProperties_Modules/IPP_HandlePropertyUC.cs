using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_HandlePropertyUC : IViewCommon
    {
        event EventHandler cmbHandleTypeSelectedValueEventRaised;
        event EventHandler PPHandlePropertyLoadEventRaised;
    }
}