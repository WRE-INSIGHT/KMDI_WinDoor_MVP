using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_6040MilledProfileWithReinforcementPropertyUC : UserControl, ISP_6040MilledProfileWithReinforcementPropertyUC
    {
        public SP_6040MilledProfileWithReinforcementPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;

        private void SP_6040MilledProfileWithReinforcementPropertyUC_Load(object sender, EventArgs e)
        {
            nud_6040MilledProfile.Maximum = decimal.MaxValue;
            nud_6040MilledProfileQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_6040MilledProfileVisibility"]);
            nud_6040MilledProfile.DataBindings.Add(ModelBinding["Screen_6040MilledProfile"]);
            nud_6040MilledProfileQty.DataBindings.Add(ModelBinding["Screen_6040MilledProfileQty"]);

        }

    }
}
