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
    public partial class MultiPanelPropertiesUC : UserControl, IMultiPanelPropertiesUC
    {
        private int _mpanelID;
        public int MPanelID
        {
            get
            {
                return _mpanelID;
            }
            set
            {
                _mpanelID = value;
            }
        }

        public event EventHandler MultiPanelPropertiesLoadEventRaised;
        public event EventHandler NumHeightValueChangedEventRaised;
        public event EventHandler NumWidthValueChangedEventRaised;
        public event EventHandler MultiPanelPropertiesSizeChangedEventRaised;

        public FlowLayoutPanel GetMultiPanelPropertiesFLP()
        {
            return flp_MultiPanelProperties;
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanelProp_Height"]);
            lbl_MultiPanelName.DataBindings.Add(ModelBinding["MPanel_Name"]);
            this.DataBindings.Add(ModelBinding["MPanel_Visibility"]);
            num_Width.DataBindings.Add(ModelBinding["MPanel_Width"]);
            num_Width.DataBindings.Add(ModelBinding["MPanel_PNumEnable1"]);
            num_Height.DataBindings.Add(ModelBinding["MPanel_Height"]);
            num_Height.DataBindings.Add(ModelBinding["MPanel_PNumEnable2"]);
        }

        public MultiPanelPropertiesUC()
        {
            InitializeComponent();
        }

        private void MultiPanelPropertiesUC_Load(object sender, EventArgs e)
        {
            num_Height.Maximum = int.MaxValue;
            num_Width.Maximum = int.MaxValue;
            EventHelpers.RaiseEvent(this, MultiPanelPropertiesLoadEventRaised, e);
        }

        private void num_Width_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NumWidthValueChangedEventRaised, e);
        }

        private void num_Height_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NumHeightValueChangedEventRaised, e);
        }

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void MultiPanelPropertiesUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, MultiPanelPropertiesSizeChangedEventRaised, e);
        }
    }
}
