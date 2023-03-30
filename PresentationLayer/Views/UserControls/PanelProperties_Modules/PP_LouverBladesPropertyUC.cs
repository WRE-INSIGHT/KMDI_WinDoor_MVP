using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_LouverBladesPropertyUC : UserControl, IPP_LouverBladesPropertyUC
    {
        public PP_LouverBladesPropertyUC()
        {
            InitializeComponent();
        }

        public NumericUpDown GetNudLouverBlades()
        {
            return nud_LouverBlades;
        }

        public event EventHandler PPLouverBladesPropertyUCLoadEventRaised;
        private void PP_LouverBladesPropertyUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PPLouverBladesPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_LouverBladesVisibility"]);
            nud_LouverBlades.DataBindings.Add(ModelBinding["Panel_LouverBladesCount"]);
        }
    }
}
