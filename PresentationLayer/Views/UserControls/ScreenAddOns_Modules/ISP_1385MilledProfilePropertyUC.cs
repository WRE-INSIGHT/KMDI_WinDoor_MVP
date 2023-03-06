using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_1385MilledProfilePropertyUC : IViewCommon
    {
        event EventHandler SP1385MilledProfilePropertyUCLoadEventRaised;
        event EventHandler nud1385MilledProfileValueChangedEventRaised;

        int Screen_1385MilledProfile { get; set; }
        int Screen_1385MilledProfileQty { get; set; }
    }
}