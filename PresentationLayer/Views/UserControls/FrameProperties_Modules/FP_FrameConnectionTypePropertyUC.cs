using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_FrameConnectionTypePropertyUC : UserControl, IFP_FrameConnectionTypePropertyUC
    {
        public FP_FrameConnectionTypePropertyUC()
        {
            InitializeComponent();
        }
        public event EventHandler FrameConnectionTypePropertyUCLoadEventRaised;
        private void FP_FrameConnectionTypePropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, FrameConnectionTypePropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_ConnectionType.DataBindings.Add(ModelBinding["Frame_ConnectionType"]);
            this.DataBindings.Add(ModelBinding["Frame_ConnectionTypeVisibility"]);
        }
    }
}
