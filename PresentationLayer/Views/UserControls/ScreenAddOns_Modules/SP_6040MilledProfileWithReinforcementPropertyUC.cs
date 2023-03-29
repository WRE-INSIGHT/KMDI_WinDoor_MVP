using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_6040MilledProfileWithReinforcementPropertyUC : UserControl, ISP_6040MilledProfileWithReinforcementPropertyUC
    {
        public event EventHandler SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;
        public event EventHandler nud_6040MilledProfile_ValueChangedEventRaised;
        public event EventHandler nud6040MilledProfileQtyValueChangedEventRaised;

        public int Screen_6040MilledProfile
        {
            get
            {
                return Convert.ToInt32(nud_6040MilledProfile.Value);
            }
            set
            {
                nud_6040MilledProfile.Value = value;
            }
        }
        public int Screen_6040MilledProfileQty
        {
            get
            {
                return Convert.ToInt32(nud_6040MilledProfileQty.Value);
            }
            set
            {
                nud_6040MilledProfileQty.Value = value;
            }
        }
        public NumericUpDown GetNumericUpDown6040ProfilewRein()
        {
            return nud_6040MilledProfile;
        }
        public NumericUpDown GetNumericUpDown6040ProfilewReinQty()
        {
            return nud_6040MilledProfileQty;
        }

        public SP_6040MilledProfileWithReinforcementPropertyUC()
        {
            InitializeComponent();
        }

        private void SP_6040MilledProfileWithReinforcementPropertyUC_Load(object sender, EventArgs e)
        {
            nud_6040MilledProfile.Maximum = decimal.MaxValue;
            nud_6040MilledProfileQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised, e);
        }

        private void nud_6040MilledProfile_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_6040MilledProfile_ValueChangedEventRaised,e);
        }

        private void nud_6040MilledProfile_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_6040MilledProfile_ValueChangedEventRaised, e);
        }

        private void nud_6040MilledProfileQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud6040MilledProfileQtyValueChangedEventRaised, e);
        }

        private void nud_6040MilledProfileQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud6040MilledProfileQtyValueChangedEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_6040MilledProfileVisibility"]);
            nud_6040MilledProfile.DataBindings.Add(ModelBinding["Screen_6040MilledProfile"]);
            nud_6040MilledProfileQty.DataBindings.Add(ModelBinding["Screen_6040MilledProfileQty"]);

        }


    }
}
