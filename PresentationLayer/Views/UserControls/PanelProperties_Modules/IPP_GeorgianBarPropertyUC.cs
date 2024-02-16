using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_GeorgianBarPropertyUC : IViewCommon
    {
        bool enable_num { set; }

        event EventHandler PPGeorgianBarPropertyUCLoadEventRaised;
        event EventHandler cmbGBArtNumSelectedValueChangedEventRaised;
        event EventHandler numVerticalValueChangedEventRaised;
        event EventHandler numHorizontalValueChangedEventRaised;
        event EventHandler btnGeorgianBarCustomDesignClickEventRaised;
        event EventHandler numVerticalValueKeyUpEventRaised;
        event EventHandler numHorizontalValueKeyUpEventRaised;

    }
}