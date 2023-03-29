using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_1385MilledProfilePropertyUC : IViewCommon
    {
        event EventHandler SP1385MilledProfilePropertyUCLoadEventRaised;
        event EventHandler nud1385MilledProfileValueChangedEventRaised;
        event EventHandler nud1385MilledProfileQtyValueChangedEventRaised;

        int Screen_1385MilledProfile { get; set; }
        int Screen_1385MilledProfileQty { get; set; }

        NumericUpDown GetNumericUpDown1385Milled();

        NumericUpDown GetNumerincUpDown1385MilledQty();
  

    }
}