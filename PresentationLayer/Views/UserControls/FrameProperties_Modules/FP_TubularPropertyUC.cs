using CommonComponents;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_TubularPropertyUC : UserControl, IFP_TubularPropertyUC
    {
        public FP_TubularPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler nudTubularWidthValueChangedEventRaised;
        public event EventHandler nudTubularHeightValueChangedEventRaised;
        public event EventHandler FPTubularPropertyUCLoadEventRaised;
        public event EventHandler chkTubularCheckedChangedEventRaised;


        private void nud_TubularWidth_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudTubularWidthValueChangedEventRaised, e);
        }

        private void nud_TubularHeight_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudTubularHeightValueChangedEventRaised, e);
        }

        private void FP_TubularPropertyUC_Load(object sender, EventArgs e)
        {
            nud_TubularHeight.Maximum = decimal.MaxValue;
            nud_TubularWidth.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, FPTubularPropertyUCLoadEventRaised, e);
        }

        private void chk_Tubular_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkTubularCheckedChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Frame_TubularVisibility"]);
            chk_Tubular.DataBindings.Add(ModelBinding["Frame_TubularOption"]);
            pnl_TubularWidth.DataBindings.Add(ModelBinding["Frame_TubularWidthVisibility"]);
            pnl_TubularHeight.DataBindings.Add(ModelBinding["Frame_TubularHeightVisibility"]);
            nud_TubularHeight.DataBindings.Add(ModelBinding["Frame_TubularHeight"]);
            nud_TubularWidth.DataBindings.Add(ModelBinding["Frame_TubularWidth"]);
        }
    }
}
