using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_PVCbox1067WithReinPropertyUC : IViewCommon
    {
        event EventHandler SPPVCbox1067WithReinPropertyUCLoadEventRaised;
        event EventHandler nud_1067PVCbox_ValueChangedEventRaised;
        event EventHandler nud1067PVCboxQtyValueChangedEventRaised;

        int Screen_1067PVCbox { get; set; }
        int Screen_1067PVCboxQty { get; set; }
        NumericUpDown GetNumericUpDown1067PVCBox();
        NumericUpDown GetNumericUpDown1067PVCBoxQty();
    }
}