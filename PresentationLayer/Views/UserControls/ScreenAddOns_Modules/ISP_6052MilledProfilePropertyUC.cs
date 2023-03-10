using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_6052MilledProfilePropertyUC : IViewCommon
    {
        event EventHandler SP6052MilledProfilePropertyUCLoadEventRaised;
        event EventHandler nud_6052MilledProfile_ValueChangedEventRaised;
        int Screen_6052MilledProfile { get; set; }
        int Screen_6052MilledProfileQty { get; set; }
    }
}