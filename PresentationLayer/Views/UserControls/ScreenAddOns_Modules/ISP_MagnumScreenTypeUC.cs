using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_MagnumScreenTypeUC
    {
        event EventHandler magnumScreenTypeEventRaised;
        event EventHandler reinforcedCheckBoxEventRaised;
        event EventHandler magnumScreenTypeUCloadEventRaised;
        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}