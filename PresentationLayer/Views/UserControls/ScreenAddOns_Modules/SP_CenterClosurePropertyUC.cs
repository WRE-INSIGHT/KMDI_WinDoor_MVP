using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_CenterClosurePropertyUC : UserControl, ISP_CenterClosurePropertyUC
    {
        public event EventHandler chkBoxCenterClosureCheckedChangedEventRaised;
        public event EventHandler SPCenterClosurePropertyUCLoadEventRaised;
        public event EventHandler nud_LatchKitQty_ValueChangedEventRaised;
        public event EventHandler nud_IntermediatePartQty_ValueChangedEventRaised;

        public int Screen_LatchKitQty
        {
            get
            {
                return Convert.ToInt32(nud_LatchKitQty.Value);
            }
            set
            {
                nud_LatchKitQty.Value = value;
            }
        }
        public int Screen_IntermediatePartQty
        {
            get
            {
                return Convert.ToInt32(nud_IntermediatePartQty.Value);
            }
            set
            {
                nud_IntermediatePartQty.Value = value;
            }
        }
        public NumericUpDown GetNumericUpDownLatchKit()
        {
            return nud_LatchKitQty;
        }
        public NumericUpDown GetNumericUpDownIntermediatePart()
        {
            return nud_IntermediatePartQty;
        }

        public SP_CenterClosurePropertyUC()
        {
            InitializeComponent();
        }

        private void chkBox_CenterClosure_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkBoxCenterClosureCheckedChangedEventRaised, e);
        }

        private void SP_CenterClosurePropertyUC_Load(object sender, EventArgs e)
        {
            nud_LatchKitQty.Maximum = decimal.MaxValue;
            nud_IntermediatePartQty.Maximum = decimal.MaxValue; 
            EventHelpers.RaiseEvent(sender, SPCenterClosurePropertyUCLoadEventRaised, e);
        }
      
        private void nud_LatchKitQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_LatchKitQty_ValueChangedEventRaised, e);
        }
        private void nud_LatchKitQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_LatchKitQty_ValueChangedEventRaised, e);
        }
        private void nud_IntermediatePartQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_IntermediatePartQty_ValueChangedEventRaised, e);
        }
        private void nud_IntermediatePartQty_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud_IntermediatePartQty_ValueChangedEventRaised, e);
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
