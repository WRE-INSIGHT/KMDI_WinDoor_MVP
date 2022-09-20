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
    }
}
