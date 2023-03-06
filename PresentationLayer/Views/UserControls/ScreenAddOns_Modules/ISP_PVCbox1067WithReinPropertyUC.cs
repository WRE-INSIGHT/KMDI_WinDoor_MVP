using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_PVCbox1067WithReinPropertyUC : IViewCommon
    {
        event EventHandler SPPVCbox1067WithReinPropertyUCLoadEventRaised;
        event EventHandler nud_1067PVCbox_ValueChangedEventRaised;

        int Screen_1067PVCbox { get; set; }
        int Screen_1067PVCboxQty { get; set; }
    }
}