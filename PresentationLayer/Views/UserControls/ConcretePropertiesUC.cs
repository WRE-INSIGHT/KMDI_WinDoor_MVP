using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ConcretePropertiesUC : UserControl, IConcretePropertiesUC
    {
        public ConcretePropertiesUC()
        {
            InitializeComponent();
        }

        public int Concrete_ID { get; set; }

        public event EventHandler ConcretePropertiesUCLoadEventRaised;
        public event EventHandler numcWidthValueChangedEventRaised;
        public event EventHandler numcHeightValueChangedEventRaised;

        private void ConcretePropertiesUC_Load(object sender, EventArgs e)
        {
            num_cWidth.Maximum = decimal.MaxValue;
            num_cHeight.Maximum = decimal.MaxValue;
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(sender, ConcretePropertiesUCLoadEventRaised, e);
        }

        private void num_cWidth_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numcWidthValueChangedEventRaised, e);
        }

        private void num_cHeight_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numcHeightValueChangedEventRaised, e);
        }

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Concrete_ID"]);
            lbl_ConcreteName.DataBindings.Add(ModelBinding["Concrete_Name"]);
            num_cWidth.DataBindings.Add(ModelBinding["Concrete_Width"]);
            num_cHeight.DataBindings.Add(ModelBinding["Concrete_Height"]);
        }

      
    }
}
