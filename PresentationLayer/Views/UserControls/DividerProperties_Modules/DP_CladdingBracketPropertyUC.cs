using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public partial class DP_CladdingBracketPropertyUC : UserControl, IDP_CladdingBracketPropertyUC
    {
        public DP_CladdingBracketPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler nudBracketForUPVCValueChangedEventRaised;
        public event EventHandler nudBracketForConcreteValueChangedEventRaised;
        public event EventHandler CladdingBracketPropertyUCLoadEventRaised;

        private void DP_CladdingBracketPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CladdingBracketPropertyUCLoadEventRaised, e);
        }

        private void nudBracketForUPVC_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudBracketForUPVCValueChangedEventRaised, e);
        }

        private void nudBracketForConcrete_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudBracketForConcreteValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_claddingBracketVisibility"]);
            nudBracketForConcrete.DataBindings.Add(ModelBinding["Div_CladdingBracketForConcrete"]);
            nudBracketForUPVC.DataBindings.Add(ModelBinding["Div_CladdingBracketForUPVC"]);
        }
    }
}
