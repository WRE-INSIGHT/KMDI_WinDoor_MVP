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
    public partial class AwningPanelImagerUC : UserControl, IAwningPanelImagerUC, IPanelImagerUC
    {
        public AwningPanelImagerUC()
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

        private bool _pnlOrientation;
        public bool pnl_Orientation
        {
            get
            {
                return _pnlOrientation;
            }

            set
            {
                _pnlOrientation = value;
                this.Invalidate();
            }
        }

        private string _panelPlacement;
        public string Panel_Placement
        {
            get
            {
                return _panelPlacement;
            }
            set
            {
                _panelPlacement = value;
            }
        }

        public event PaintEventHandler awningPanelImagerUCPaintEventRaised;
        public event EventHandler awningPanelImagerUCVisibleChangedEventRaised;

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["PanelImageRenderer_Width"]);
            this.DataBindings.Add(ModelBinding["PanelImageRenderer_Height"]);
            this.DataBindings.Add(ModelBinding["Panel_Orient"]);
            this.DataBindings.Add(ModelBinding["PanelImageRenderer_Margin"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            this.DataBindings.Add(ModelBinding["Panel_Placement"]);
        }

        private void AwningPanelImagerUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, awningPanelImagerUCPaintEventRaised, e);
        }

        private void AwningPanelImagerUC_VisibleChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, awningPanelImagerUCVisibleChangedEventRaised, e);
        }
    }
}
