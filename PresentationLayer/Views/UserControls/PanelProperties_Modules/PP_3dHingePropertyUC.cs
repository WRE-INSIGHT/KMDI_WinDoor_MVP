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
    public partial class PP_3dHingePropertyUC : UserControl, IPP_3dHingePropertyUC
    {
        public PP_3dHingePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PP3dHingeLoadEventRaised;

        private void PP_3dHingePropertyUC_Load(object sender, EventArgs e)
        {
            num_3dHingeQty.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(sender, PP3dHingeLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            num_3dHingeQty.DataBindings.Add(ModelBinding["Panel_3dHingeQty"]);
            this.DataBindings.Add(ModelBinding["Panel_3dHingePropertyVisibility"]);
        }
    }
}
