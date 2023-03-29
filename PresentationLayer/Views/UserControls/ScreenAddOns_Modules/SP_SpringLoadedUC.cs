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

namespace PresentationLayer.Views.UserControls
{
    public partial class SP_SpringLoadedUC : UserControl, ISP_SpringLoadedUC
    {

        public CheckBox SpringLoadedCheckBox()
        {
            return springloadedchkbox;
        }
        public SP_SpringLoadedUC()
        {
            InitializeComponent();
        }

        public event EventHandler springLoadedCheckboxEventRaised;
        public event EventHandler spSpringLoadedUCLoadEventRaised;

        private void springloadedchkbox_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, springLoadedCheckboxEventRaised, e);
        }

        private void SP_SpringLoadedUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, spSpringLoadedUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<String ,Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["SpringLoad_Visibility"]);
            springloadedchkbox.DataBindings.Add(ModelBinding["SpringLoad_Checked"]);
        }
    }
}
