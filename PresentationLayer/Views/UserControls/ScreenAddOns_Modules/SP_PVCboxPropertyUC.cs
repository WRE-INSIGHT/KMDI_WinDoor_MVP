using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_PVCboxPropertyUC : UserControl, ISP_PVCboxPropertyUC
    {
        public SP_PVCboxPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler SPPVCboxPropertyUCLoadEventRaised;
        public event EventHandler nud0505WidthValueChangedEventRaised;
        public event EventHandler nud1067HeightValueChangedEventRaised;
        public event EventHandler nud0505QtyValueChangedEventRaised;
        public event EventHandler nud1067QtyValueChangedEventRaised;


        // public event EventHandler ComputePVCboxPriceEventRaised;


        private void SP_PVCboxPropertyUC_Load(object sender, EventArgs e)
        {
            nud_0505Qty.Maximum = decimal.MaxValue;
            nud_1067Qty.Maximum = decimal.MaxValue;
            nud_1067Height.Maximum = decimal.MaxValue;
            nud_0505Width.Maximum = decimal.MaxValue;

            nud_0505Qty.Value = 0;
            nud_1067Qty.Value = 0;
            nud_1067Height.Value = 0;
            nud_0505Width.Value = 0;

            EventHelpers.RaiseEvent(sender, SPPVCboxPropertyUCLoadEventRaised, e);
        }

        //public void ComputePVCboxPrice(object sender, EventArgs e)
        //{
        //    EventHelpers.RaiseEvent(sender, ComputePVCboxPriceEventRaised, e);
        //}

        private void nud_0505Width_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud0505WidthValueChangedEventRaised, e);
        }

        private void nud_1067Height_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud1067HeightValueChangedEventRaised, e);
        }

        private void nud_0505Qty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud0505QtyValueChangedEventRaised, e);
        }

        private void nud_1067Qty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nud1067QtyValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_PVCVisibility"]);
            nud_0505Width.DataBindings.Add(ModelBinding["Screen_0505Width"]);
            nud_1067Height.DataBindings.Add(ModelBinding["Screen_1067Height"]);
            nud_0505Qty.DataBindings.Add(ModelBinding["Screen_0505Qty"]);
            nud_1067Qty.DataBindings.Add(ModelBinding["Screen_1067Qty"]);
        }


    }
}
