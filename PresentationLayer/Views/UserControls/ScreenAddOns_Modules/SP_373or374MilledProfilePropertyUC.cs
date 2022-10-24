using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_373or374MilledProfilePropertyUC : UserControl, ISP_373or374MilledProfilePropertyUC
    {
        public SP_373or374MilledProfilePropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler SP373or374MilledProfilePropertyUCLoadEventRaised;



        private void SP_373or374MilledProfilePropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SP373or374MilledProfilePropertyUCLoadEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_373or374MilledProfileVisibility"]);
            nud_373or374MilledProfile.DataBindings.Add(ModelBinding["Screen_373or374MilledProfile"]);
            nud_373or374MilledProfileQty.DataBindings.Add(ModelBinding["Screen_373or374MilledProfileQty"]);
        }

    }
}
