using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface ISP_SpringLoadedUC
    {
        event EventHandler springLoadedCheckboxEventRaised;
        event EventHandler spSpringLoadedUCLoadEventRaised;
        CheckBox SpringLoadedCheckBox();
        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}