using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_6052MilledProfilePropertyUC : IViewCommon
    {
        event EventHandler SP6052MilledProfilePropertyUCLoadEventRaised;
        event EventHandler nud_6052MilledProfile_ValueChangedEventRaised;
        event EventHandler nud_6052MilledProfileQty_ValueChangedEventRaised;
        int Screen_6052MilledProfile { get; set; }
        int Screen_6052MilledProfileQty { get; set; }
        NumericUpDown GetNumericUpDown6052MilledProfile();
        NumericUpDown GetNumericUpDown6052MilledQty();
    }
}