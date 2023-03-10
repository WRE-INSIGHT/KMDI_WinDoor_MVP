using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_373or374MilledProfilePropertyUC : UserControl, ISP_373or374MilledProfilePropertyUC
    {
        public event EventHandler SP373or374MilledProfilePropertyUCLoadEventRaised;
        public event EventHandler nud_373or374MilledProfile_ValueChangedEventRaise;

        public int Screen_373or374MilledProfile
        {
            get
            {
                return Convert.ToInt32(nud_373or374MilledProfile.Value);
            }
            set
            {
                nud_373or374MilledProfile.Value = value;
            }
        }

        public int Screen_373or374MilledProfileQty
        {
            get
            {
                return Convert.ToInt32(nud_373or374MilledProfileQty.Value);
            }
            set
            {
                nud_373or374MilledProfileQty.Value = value;
            }
        }
        public SP_373or374MilledProfilePropertyUC()
        {
            InitializeComponent();
        }

        private void SP_373or374MilledProfilePropertyUC_Load(object sender, EventArgs e)
        {
            nud_373or374MilledProfile.Maximum = decimal.MaxValue;
            nud_373or374MilledProfileQty.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, SP373or374MilledProfilePropertyUCLoadEventRaised, e);
        }
        private void nud_373or374MilledProfile_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_373or374MilledProfile_ValueChangedEventRaise,e);
        }

        private void nud_373or374MilledProfile_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_373or374MilledProfile_ValueChangedEventRaise, e);
        }

        private void nud_373or374MilledProfileQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_373or374MilledProfile_ValueChangedEventRaise, e);
        }

        private void nud_373or374MilledProfileQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_373or374MilledProfile_ValueChangedEventRaise, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_373or374MilledProfileVisibility"]);
            nud_373or374MilledProfile.DataBindings.Add(ModelBinding["Screen_373or374MilledProfile"]);
            nud_373or374MilledProfileQty.DataBindings.Add(ModelBinding["Screen_373or374MilledProfileQty"]);
        }

        
    }
}
