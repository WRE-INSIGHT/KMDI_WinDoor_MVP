using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_PVCbox1067WithReinPropertyUC : UserControl, ISP_PVCbox1067WithReinPropertyUC
    {
        public SP_PVCbox1067WithReinPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler SPPVCbox1067WithReinPropertyUCLoadEventRaised;


        private void SP_PVCbox1067WithReinPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SPPVCbox1067WithReinPropertyUCLoadEventRaised, e);
        }


        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_1067PVCboxVisibility"]);
            nud_1067PVCbox.DataBindings.Add(ModelBinding["Screen_1067PVCbox"]);
            nud_1067PVCboxQty.DataBindings.Add(ModelBinding["Screen_1067PVCboxQty"]);

        }

    }
}
