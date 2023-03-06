using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_373or374MilledProfilePropertyUC : IViewCommon
    {
        event EventHandler SP373or374MilledProfilePropertyUCLoadEventRaised;
        event EventHandler nud_373or374MilledProfile_ValueChangedEventRaise;
        int Screen_373or374MilledProfile { get; set; }
        int Screen_373or374MilledProfileQty { get; set; }
    }
}