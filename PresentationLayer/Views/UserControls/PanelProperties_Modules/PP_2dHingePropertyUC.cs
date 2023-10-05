using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_2dHingePropertyUC : UserControl, IPP_2dHingePropertyUC
    {
        public PP_2dHingePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PP2dHingeLoadEventRaised;
        public event EventHandler num2dHingeQtyNonMotorizedValueChangedEventRaised;

        private void PP_2dHingePropertyUC_Load(object sender, EventArgs e)
        {
            num_2dHingeQtyNonMotorized.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, PP2dHingeLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            num_2dHingeQtyNonMotorized.DataBindings.Add(ModelBinding["Panel_2DHingeQty_nonMotorized"]);
            this.DataBindings.Add(ModelBinding["Panel_2dHingeVisibility_nonMotorized"]);
        }

        private void num_2dHingeQtyNonMotorized_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, num2dHingeQtyNonMotorizedValueChangedEventRaised, e);
        }
        private void num_2dHingeQtyNonMotorized_Mousewheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
