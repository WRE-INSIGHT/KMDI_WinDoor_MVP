using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_InversionClipPropertyUC : UserControl, IFP_InversionClipPropertyUC
    {
        public FP_InversionClipPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler InversionClipCheckedChangedEventRaised;
        public event EventHandler InversionClipPropertyUCLoadEventRaised;



        private void chk_InversionClip_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, InversionClipCheckedChangedEventRaised, e);
        }

        private void FP_InversionClipPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, InversionClipPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Frame_InversionClipVisibility"]);
            chk_InversionClip.DataBindings.Add(ModelBinding["Frame_InversionClipOption"]);
        }
    }
}
