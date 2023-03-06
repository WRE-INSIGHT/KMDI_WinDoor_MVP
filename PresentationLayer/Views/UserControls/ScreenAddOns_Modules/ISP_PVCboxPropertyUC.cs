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

        int Screen_0505Width { get; set; }
        int Screen_0505Qty { get; set; }
        int Screen_1067Height { get; set; }
        int Screen_1067Qty { get; set; }


        // void ComputePVCboxPrice(object sender, EventArgs e);
    }
}