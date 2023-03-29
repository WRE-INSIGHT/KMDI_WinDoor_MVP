using CommonComponents;
using System;
using System.Windows.Forms;

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

        int Screen_0505Width { get; set; }
        int Screen_0505Qty { get; set; }
        int Screen_1067Height { get; set; }
        int Screen_1067Qty { get; set; }

        NumericUpDown GetNumericUpDownScreen0505width();
        NumericUpDown GetNumericUpDownScreen0505Qty();
        NumericUpDown GetNumericUpDownScreen1067height();
        NumericUpDown GetNumericUpDownScreen1067Qty();
        



        // void ComputePVCboxPrice(object sender, EventArgs e);
    }
}