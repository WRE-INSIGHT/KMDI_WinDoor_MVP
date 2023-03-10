using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_1385MilledProfilePropertyUC : UserControl, ISP_1385MilledProfilePropertyUC
    {

        public int Screen_1385MilledProfile
        {
            get
            {
                return Convert.ToInt32(nud_1385MilledProfile.Value);
            }
            set
            {
                nud_1385MilledProfile.Value = value;
            }
        }

        public int Screen_1385MilledProfileQty
        {
            get
            {
                return Convert.ToInt32(nud_1385MilledProfileQty.Value);
            }
            set
            {
                nud_1385MilledProfileQty.Value = value;
            }
        }

        public event EventHandler nud1385MilledProfileValueChangedEventRaised;
        public event EventHandler SP1385MilledProfilePropertyUCLoadEventRaised;

        public SP_1385MilledProfilePropertyUC()
        {
            InitializeComponent();
        }
       
        private void SP_1385MilledProfilePropertyUC_Load(object sender, EventArgs e)
        {
            nud_1385MilledProfile.Maximum = decimal.MaxValue;
            nud_1385MilledProfileQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SP1385MilledProfilePropertyUCLoadEventRaised, e);
        }

        private void nud_1385MilledProfile_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud1385MilledProfileValueChangedEventRaised, e);
        }
        private void nud_1385MilledProfile_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud1385MilledProfileValueChangedEventRaised, e);
        }
        private void nud_1385MilledProfileQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud1385MilledProfileValueChangedEventRaised, e);
        }
        private void nud_1385MilledProfileQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud1385MilledProfileValueChangedEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_1385MilledProfileVisibility"]);
            nud_1385MilledProfile.DataBindings.Add(ModelBinding["Screen_1385MilledProfile"]);
            nud_1385MilledProfileQty.DataBindings.Add(ModelBinding["Screen_1385MilledProfileQty"]);
        }


    }
}
