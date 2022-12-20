using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_SlidingRailsPropertyUC : UserControl, IFP_SlidingRailsPropertyUC
    {
        public FP_SlidingRailsPropertyUC()
        {
            InitializeComponent();
        }

        public NumericUpDown GetNudRailsQty()
        {
            return nud_RailsQty;
        }

        public event EventHandler FPSlidingRailsPropertyUCLoadEventRaised;
        public event EventHandler  nudRailsQtyValueChangedEventRaised;
        private void FP_SlidingRailsPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, FPSlidingRailsPropertyUCLoadEventRaised, e);
        }

        private void nud_RailsQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudRailsQtyValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Frame_SlidingRailsQtyVisibility"]);
            nud_RailsQty.DataBindings.Add(ModelBinding["Frame_SlidingRailsQty"]);
        }

        private void FP_SlidingRailsPropertyUC_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(this.Parent.Name);
        }
    }
}
