using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_6052MilledProfilePropertyUC : UserControl, ISP_6052MilledProfilePropertyUC
    {
        public event EventHandler SP6052MilledProfilePropertyUCLoadEventRaised;
        public event EventHandler nud_6052MilledProfile_ValueChangedEventRaised;
        public event EventHandler nud_6052MilledProfileQty_ValueChangedEventRaised;

        public int Screen_6052MilledProfile
        {
            get
            {
                return Convert.ToInt32(nud_6052MilledProfile.Value);
            }
            set
            {
                nud_6052MilledProfile.Value = value;
            }
        }
        public int Screen_6052MilledProfileQty
        {
            get
            {
                return Convert.ToInt32(nud_6052MilledProfileQty.Value);
            }
            set
            {
                nud_6052MilledProfileQty.Value = value;
            }
        }
        public NumericUpDown GetNumericUpDown6052MilledProfile()
        {
            return nud_6052MilledProfile;
        }
        public NumericUpDown GetNumericUpDown6052MilledQty()
        {
            return nud_6052MilledProfileQty;
        }
        public SP_6052MilledProfilePropertyUC()
        {
            InitializeComponent();
        }

        private void SP_6052MilledProfilePropertyUC_Load(object sender, EventArgs e)
        {
            nud_6052MilledProfile.Maximum = decimal.MaxValue;
            nud_6052MilledProfileQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SP6052MilledProfilePropertyUCLoadEventRaised, e);
        }
        private void nud_6052MilledProfile_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_6052MilledProfile_ValueChangedEventRaised,e);
        }

        private void nud_6052MilledProfile_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_6052MilledProfile_ValueChangedEventRaised, e);
        }
        private void nud_6052MilledProfileQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_6052MilledProfileQty_ValueChangedEventRaised, e);
        }

        private void nud_6052MilledProfileQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_6052MilledProfileQty_ValueChangedEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_6052MilledProfileVisibility"]);
            nud_6052MilledProfile.DataBindings.Add(ModelBinding["Screen_6052MilledProfile"]);
            nud_6052MilledProfileQty.DataBindings.Add(ModelBinding["Screen_6052MilledProfileQty"]);

        }

       
    }
}
