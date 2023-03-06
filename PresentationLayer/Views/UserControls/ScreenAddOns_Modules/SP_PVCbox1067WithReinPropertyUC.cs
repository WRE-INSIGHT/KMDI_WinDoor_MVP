using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_PVCbox1067WithReinPropertyUC : UserControl, ISP_PVCbox1067WithReinPropertyUC
    {
        public event EventHandler SPPVCbox1067WithReinPropertyUCLoadEventRaised;
        public event EventHandler nud_1067PVCbox_ValueChangedEventRaised;

        public int Screen_1067PVCbox
        {
            get
            {
                return Convert.ToInt32(nud_1067PVCbox.Value);
            }
            set
            {
                nud_1067PVCbox.Value = value;
            }
        }

        public int Screen_1067PVCboxQty
        {
            get
            {
                return Convert.ToInt32(nud_1067PVCboxQty.Value);
            }
            set
            {
                nud_1067PVCboxQty.Value = value;
            }
        }
        public SP_PVCbox1067WithReinPropertyUC()
        {
            InitializeComponent();
        }

        private void SP_PVCbox1067WithReinPropertyUC_Load(object sender, EventArgs e)
        {
            nud_1067PVCbox.Maximum = decimal.MaxValue;
            nud_1067PVCboxQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SPPVCbox1067WithReinPropertyUCLoadEventRaised, e);
        }

        private void nud_1067PVCbox_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_1067PVCbox_ValueChangedEventRaised,e );
        }

        private void nud_1067PVCbox_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_1067PVCbox_ValueChangedEventRaised, e);

        }

        private void nud_1067PVCboxQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_1067PVCbox_ValueChangedEventRaised, e);

        }

        private void nud_1067PVCboxQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_1067PVCbox_ValueChangedEventRaised, e);

        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_1067PVCboxVisibility"]);
            nud_1067PVCbox.DataBindings.Add(ModelBinding["Screen_1067PVCbox"]);
            nud_1067PVCboxQty.DataBindings.Add(ModelBinding["Screen_1067PVCboxQty"]);

        }

   
    }
}
