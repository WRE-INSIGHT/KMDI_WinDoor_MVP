using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_CenterClosurePropertyUC : UserControl, ISP_CenterClosurePropertyUC
    {
        public SP_CenterClosurePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler chkBoxCenterClosureCheckedChangedEventRaised;
        public event EventHandler SPCenterClosurePropertyUCLoadEventRaised;
        public event EventHandler nudIntermediatePartValueChangedEventRaised;
        public event EventHandler nudIntermediatePartQtyValueChangedEventRaised;


        private void chkBox_CenterClosure_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkBoxCenterClosureCheckedChangedEventRaised, e);
        }

        private void SP_CenterClosurePropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SPCenterClosurePropertyUCLoadEventRaised, e);
        }

        private void nud_IntermediatePart_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudIntermediatePartValueChangedEventRaised, e);
        }

        private void nud_IntermediatePartQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudIntermediatePartQtyValueChangedEventRaised, e);
        }

        public Panel GetPanelBody()
        {
            return pnl_Body;
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_CenterClosureVisibility"]);
            chkBox_CenterClosure.DataBindings.Add(ModelBinding["Screen_CenterClosureVisibilityOption"]);
            nud_LatchKitQty.DataBindings.Add(ModelBinding["Screen_LatchKitQty"]);
            nud_IntermediatePartQty.DataBindings.Add(ModelBinding["Screen_IntermediatePartQty"]);

        }
    }
}
