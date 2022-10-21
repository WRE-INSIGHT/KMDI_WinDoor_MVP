using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_LandCoverPropertyUC : UserControl, ISP_LandCoverPropertyUC
    {
        public SP_LandCoverPropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler SPLandCoverPropertyUCLoadEventRaised;

        private void SP_LandCoverPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SPLandCoverPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_LandCoverVisibility"]);
            nud_LandCover.DataBindings.Add(ModelBinding["Screen_LandCover"]);
            nud_LandCoverQty.DataBindings.Add(ModelBinding[" "]);

        }
    }
}
