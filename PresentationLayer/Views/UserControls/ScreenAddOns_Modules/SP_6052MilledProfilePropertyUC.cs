using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_6052MilledProfilePropertyUC : UserControl, ISP_6052MilledProfilePropertyUC
    {
        public SP_6052MilledProfilePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler SP6052MilledProfilePropertyUCLoadEventRaised;



        private void SP_6052MilledProfilePropertyUC_Load(object sender, EventArgs e)
        {
            nud_6052MilledProfile.Maximum = decimal.MaxValue;
            nud_6052MilledProfileQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SP6052MilledProfilePropertyUCLoadEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_6052MilledProfileVisibility"]);
            nud_6052MilledProfile.DataBindings.Add(ModelBinding["Screen_6052MilledProfile"]);
            nud_6052MilledProfileQty.DataBindings.Add(ModelBinding["Screen_6052MilledProfileQty"]);

        }
    }
}
