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

        public event EventHandler CladdingBracketPropertyUCLoadEventRaised;

        private void DP_CladdingBracketPropertyUC_Load(object sender, EventArgs e)
        {
            nudBracketForConcrete.Maximum = decimal.MaxValue;
            nudBracketForUPVC.Maximum = decimal.MaxValue;

            EventHelpers.RaiseEvent(sender, CladdingBracketPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Div_claddingBracketVisibility"]);
            nudBracketForConcrete.DataBindings.Add(ModelBinding["Div_CladdingBracketForConcreteQTY"]);
            nudBracketForUPVC.DataBindings.Add(ModelBinding["Div_CladdingBracketForUPVCQTY"]);
        }
    }
}
