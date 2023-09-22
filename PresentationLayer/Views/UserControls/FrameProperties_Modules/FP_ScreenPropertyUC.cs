using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_ScreenPropertyUC : UserControl, IFP_ScreenPropertyUC
    {
        public FP_ScreenPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler FScreenPropertyUCLoadEventRaised;
        public event EventHandler ScreenCheckedChangedEventRaised;
        // public event EventHandler screenHeightOptionCheckedChangedEventRaised;
        public event EventHandler nudScreenHeightValueChangedEventRaised;

        private void FP_ScreenPropertyUC_Load(object sender, EventArgs e)
        {
            nud_screenHeight.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, FScreenPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            chck_screenHeightOption.DataBindings.Add(ModelBinding["Frame_ScreenHeightOption"]);
            this.DataBindings.Add(ModelBinding["Frame_ScreenVisibility"]);
            pnl_ScreenHeight.DataBindings.Add(ModelBinding["Frame_ScreenHeightVisibility"]);
            chk_Screen.DataBindings.Add(ModelBinding["Frame_ScreenOption"]);
            nud_screenHeight.DataBindings.Add(ModelBinding["Frame_ScreenFrameHeightEnable"]);
            nud_screenHeight.DataBindings.Add(ModelBinding["Frame_ScreenFrameHeight"]);
        }

        private void chk_Screen_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ScreenCheckedChangedEventRaised, e);
        }


        private void nud_screenHeight_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudScreenHeightValueChangedEventRaised, e);
        }

        private void nud_screenHeight_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
