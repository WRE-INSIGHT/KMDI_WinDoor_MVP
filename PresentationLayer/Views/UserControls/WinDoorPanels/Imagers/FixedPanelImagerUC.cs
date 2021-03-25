using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public partial class FixedPanelImagerUC : UserControl, IFixedPanelImagerUC
    {
        public FixedPanelImagerUC()
        {
            InitializeComponent();
        }

        private int _panelID;
        public int Panel_ID
        {
            get
            {
                return _panelID;
            }
            set
            {
                _panelID = value;
            }
        }

        Color color = Color.Black;

        public event PaintEventHandler fixedPanelImagerUCPaintEventRaised;

        private void FixedPanelImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, fixedPanelImagerUCPaintEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["PanelImageRenderer_Width"]);
            this.DataBindings.Add(ModelBinding["PanelImageRenderer_Height"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
        }
    }
}
