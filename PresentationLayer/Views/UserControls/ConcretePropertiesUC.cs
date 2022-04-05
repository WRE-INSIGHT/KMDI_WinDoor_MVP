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

        private int frameID;
        public int FrameID
        {
            get
            {
                return frameID;
            }

            set
            {
                frameID = value;
            }
        }

        public event EventHandler ConcretePropertiesUCLoadEventRaised;
        public event EventHandler numcWidthValueChangedEventRaised;
        public event EventHandler numcHeightValueChangedEventRaised;

        private void ConcretePropertiesUC_Load(object sender, EventArgs e)
        {
            num_cWidth.Maximum = decimal.MaxValue;
            num_cHeight.Maximum = decimal.MaxValue;
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
    }
}
