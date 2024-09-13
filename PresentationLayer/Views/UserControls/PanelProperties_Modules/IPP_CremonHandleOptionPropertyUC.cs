using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_CremonHandleOptionPropertyUC
    {
        event EventHandler cmbCremonArtNoSelectedValueChangedEventRaised;
        event EventHandler PPCremonHandleOptionPropertyUCLoadEventRaised;

        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}