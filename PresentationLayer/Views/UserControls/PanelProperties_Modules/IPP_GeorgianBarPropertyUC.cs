using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_GeorgianBarPropertyUC
    {
        event EventHandler nudHorizontalQuantityValueChanged;
        event EventHandler nudVerticalQuantityValueChanged;
        event EventHandler PPGeorgianBarPropertyUCLoadEventRaised;

        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}