using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_6040MilledProfileWithReinforcementPropertyUC : IViewCommon
    {
        event EventHandler SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;
        event EventHandler nud_6040MilledProfile_ValueChangedEventRaised;

        int Screen_6040MilledProfile { get; set; }
        int Screen_6040MilledProfileQty { get; set; }
    }
}