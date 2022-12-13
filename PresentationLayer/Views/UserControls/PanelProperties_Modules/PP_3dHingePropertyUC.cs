 using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_3dHingePropertyUC : UserControl, IPP_3dHingePropertyUC
    {
        public PP_3dHingePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PP3dHingeLoadEventRaised;
        public event EventHandler num3dHingeQtyValueChangedEventRaised;

        private void PP_3dHingePropertyUC_Load(object sender, EventArgs e)
        {
            num_3dHingeQty.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, PP3dHingeLoadEventRaised, e);
        }

        private void num_3dHingeQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num3dHingeQtyValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            num_3dHingeQty.DataBindings.Add(ModelBinding["Panel_3dHingeQty"]);
            this.DataBindings.Add(ModelBinding["Panel_3dHingePropertyVisibility"]);
        }


    }
}
