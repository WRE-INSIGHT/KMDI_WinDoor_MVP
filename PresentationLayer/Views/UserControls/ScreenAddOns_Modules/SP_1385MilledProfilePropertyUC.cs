using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_1385MilledProfilePropertyUC : UserControl, ISP_1385MilledProfilePropertyUC
    {
        public SP_1385MilledProfilePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler SP1385MilledProfilePropertyUCLoadEventRaised;

        private void SP_1385MilledProfilePropertyUC_Load(object sender, EventArgs e)
        {
            nud_1385MilledProfile.Maximum = decimal.MaxValue;
            nud_1385MilledProfileQty.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, SP1385MilledProfilePropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_1385MilledProfileVisibility"]);
            nud_1385MilledProfile.DataBindings.Add(ModelBinding["Screen_1385MilledProfile"]);
            nud_1385MilledProfileQty.DataBindings.Add(ModelBinding["Screen_1385MilledProfileQty"]);
        }
    }
}
