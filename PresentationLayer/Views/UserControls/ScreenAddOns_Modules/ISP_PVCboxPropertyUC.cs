using CommonComponents;
using System;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_PVCboxPropertyUC : IViewCommon
    {
        //event EventHandler ComputePVCboxPriceEventRaised;
        event EventHandler SPPVCboxPropertyUCLoadEventRaised;
        event EventHandler nud0505WidthValueChangedEventRaised;
        event EventHandler nud1067HeightValueChangedEventRaised;
        event EventHandler nud0505QtyValueChangedEventRaised;
        event EventHandler nud1067QtyValueChangedEventRaised;

        // void ComputePVCboxPrice(object sender, EventArgs e);
    }
}