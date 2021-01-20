using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class FixedPanelUC : UserControl, IFixedPanelUC
    {
        public FixedPanelUC()
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

        public event EventHandler fixedPanelUCSizeChangedEventRaised;
        public event EventHandler deleteToolStripClickedEventRaised;
        public event PaintEventHandler fixedPanelUCPaintEventRaised;
        public event EventHandler fixedPanelMouseEnterEventRaised;
        public event EventHandler fixedPanelMouseLeaveEventRaised;

        private void FixedPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, fixedPanelUCPaintEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["Panel_ID"]);
            this.DataBindings.Add(binding["Panel_Dock"]);
            this.DataBindings.Add(binding["Panel_Width"]);
            this.DataBindings.Add(binding["Panel_Height"]);
            this.DataBindings.Add(binding["Panel_Visibility"]);
            this.DataBindings.Add(binding["Panel_Orient"]);
            this.DataBindings.Add(binding["Panel_Margin"]);
        }

        private void FixedPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, fixedPanelUCSizeChangedEventRaised, e);
        }

        private void FixedPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_fxd.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
        }

        private void FixedPanelUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, fixedPanelMouseEnterEventRaised, e);
        }

        private void FixedPanelUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, fixedPanelMouseLeaveEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }
    }
}
