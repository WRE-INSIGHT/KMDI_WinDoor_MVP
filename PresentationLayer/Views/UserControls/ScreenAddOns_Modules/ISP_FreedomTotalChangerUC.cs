using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_FreedomTotalChangerUC
    {
        event EventHandler chkboxtotalChangerCheckedChangedEventRaised;
        event EventHandler SPFreedomTotalChangerUCLoadEventRaised;
        CheckBox GetFreedomTotalChangerChkBx();
        void ThisBinding(Dictionary<string, Binding> ModelBinding);
    }
}