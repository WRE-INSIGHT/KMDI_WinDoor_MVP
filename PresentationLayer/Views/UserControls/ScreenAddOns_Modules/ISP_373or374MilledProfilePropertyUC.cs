using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_373or374MilledProfilePropertyUC : IViewCommon
    {
        event EventHandler SP373or374MilledProfilePropertyUCLoadEventRaised;
        event EventHandler nud_373or374MilledProfile_ValueChangedEventRaise;
        event EventHandler nud373or374MilledProfileQtyValueChangedEventRaised;
        int Screen_373or374MilledProfile { get; set; }
        int Screen_373or374MilledProfileQty { get; set; }
        NumericUpDown GetNumericUpDown373or374Profile();
        NumericUpDown GetNumericUpDown373or374Qty();
    }
}