using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_AliminumTrackPropertyUC : UserControl, IPP_AliminumTrackPropertyUC
    {
        public PP_AliminumTrackPropertyUC()
        {
            InitializeComponent();
        }

        public NumericUpDown GetNudAluminumTrackQty()
        {
            return nud_AluminumTrackQty;
        }

        public event EventHandler PPAliminumTrackPropertyUCLoadEventRaised;

        private void PP_AliminumTrackPropertyUC_Load(object sender, EventArgs e)
        {
            nud_AluminumTrackQty.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, PPAliminumTrackPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            nud_AluminumTrackQty.DataBindings.Add(ModelBinding["Panel_AluminumTrackQty"]);
            this.DataBindings.Add(ModelBinding["Panel_AluminumTrackQtyVisibility"]);
        }
    }
}
