using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_DummyDHandlePropertyUC : IViewCommon
    {
        event EventHandler cmbDummyDArtNoSelectedValueChangedEventRaised;
        event EventHandler PPDummyDHandlePropertyUCLoadEventRaised;
    }
}