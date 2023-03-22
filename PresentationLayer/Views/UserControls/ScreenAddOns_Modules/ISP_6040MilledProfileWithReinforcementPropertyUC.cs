using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public interface ISP_6040MilledProfileWithReinforcementPropertyUC : IViewCommon
    {
        event EventHandler SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;
        event EventHandler nud_6040MilledProfile_ValueChangedEventRaised;
        event EventHandler nud6040MilledProfileQtyValueChangedEventRaised;

        int Screen_6040MilledProfile { get; set; }
        int Screen_6040MilledProfileQty { get; set; }
        NumericUpDown GetNumericUpDown6040ProfilewRein();
        NumericUpDown GetNumericUpDown6040ProfilewReinQty();
    }
}