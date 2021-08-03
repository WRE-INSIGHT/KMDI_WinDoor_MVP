using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_GeorgianBarPropertyUC : IViewCommon
    {
        event EventHandler PPGeorgianBarPropertyUCLoadEventRaised;
        event EventHandler cmbGBArtNumSelectedValueChangedEventRaised;
        event EventHandler numVerticalValueChangedEventRaised;
        event EventHandler numHorizontalValueChangedEventRaised;
    }
}