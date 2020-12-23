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

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class AwningPanelUC : UserControl, IAwningPanelUC
    {
        public AwningPanelUC()
        {
            InitializeComponent();
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

        public event EventHandler deleteToolStripClickedEventRaised;
        public event EventHandler awningPanelUCMouseEnterEventRaised;
        public event EventHandler awningPanelUCMouseLeaveEventRaised;
        public event PaintEventHandler awningPanelUCPaintEventRaised;
        public event EventHandler awningPanelUCSizeChangedEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["Panel_Width"]);
            this.DataBindings.Add(ModelBinding["Panel_Height"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            this.DataBindings.Add(ModelBinding["Panel_Orient"]);
        }

        private void AwningPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, awningPanelUCPaintEventRaised, e);
        }

        private void AwningPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, awningPanelUCSizeChangedEventRaised, e);
        }

        private void AwningPanelUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, awningPanelUCMouseEnterEventRaised, e);
        }

        private void AwningPanelUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, awningPanelUCMouseLeaveEventRaised, e);
        }

        private void AwningPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_awning.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }
    }
}
