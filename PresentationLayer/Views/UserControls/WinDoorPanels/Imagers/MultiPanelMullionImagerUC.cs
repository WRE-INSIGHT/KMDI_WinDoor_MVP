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

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public partial class MultiPanelMullionImagerUC : UserControl, IMultiPanelMullionImagerUC
    {
        public MultiPanelMullionImagerUC()
        {
            InitializeComponent();
        }

        private int _mpanelID;
        public int MPanel_ID
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
        public event PaintEventHandler flpMulltiPaintEventRaised;

        private void MultiPanelMullionImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, flpMulltiPaintEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanel_Name"]);
            this.DataBindings.Add(ModelBinding["MPanel_Dock"]);
            this.DataBindings.Add(ModelBinding["MPanel_Width"]);
            this.DataBindings.Add(ModelBinding["MPanel_Height"]);
            this.DataBindings.Add(ModelBinding["MPanel_Visibility"]);
            this.DataBindings.Add(ModelBinding["MPanel_Margin"]);
        }
    }
}
