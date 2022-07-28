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
    public partial class SlidingPanelUC : UserControl, ISlidingPanelUC, IPanelUC
    {
        public SlidingPanelUC()
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

        public Color Panel_BackColor
        {
            get
            {
                return this.BackColor;
            }
        }

        private bool _panelCmenuDeleteVisibility;
        public bool Panel_CmenuDeleteVisibility
        {
            get
            {
                return _panelCmenuDeleteVisibility;
            }

            set
            {
                _panelCmenuDeleteVisibility = value;
            }
        }

        public event EventHandler deleteToolStripClickedEventRaised;
        public event EventHandler slidingPanelUCMouseEnterEventRaised;
        public event EventHandler slidingPanelUCMouseLeaveEventRaised;
        public event PaintEventHandler slidingPanelUCPaintEventRaised;
        public event EventHandler slidingPanelUCSizeChangedEventRaised;


        public event MouseEventHandler slidingPanelUCMouseMoveEventRaised;
        public event MouseEventHandler slidingPanelUCMouseDownEventRaised;
        public event MouseEventHandler slidingPanelUCMouseUpEventRaised;
        public event EventHandler rightToolStripClickedEventRaised;
        public event EventHandler leftToolStripClickedEventRaised;
        public event EventHandler bothToolStripClickedEventRaised;
        public event EventHandler noneToolStripClickedEventRaised;
        public event MouseEventHandler slidingPanelUCMouseClickEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_Name"]);
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["Panel_Width"]);
            this.DataBindings.Add(ModelBinding["Panel_Height"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            this.DataBindings.Add(ModelBinding["Panel_Orient"]);
            this.DataBindings.Add(ModelBinding["Panel_Margin"]);
            this.DataBindings.Add(ModelBinding["Panel_Placement"]);
            this.DataBindings.Add(ModelBinding["Panel_CmenuDeleteVisibility"]);
        }

        private void SlidingPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, slidingPanelUCPaintEventRaised, e);
        }

        private void SlidingPanelUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, slidingPanelUCMouseEnterEventRaised, e);
        }

        private void SlidingPanelUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, slidingPanelUCMouseLeaveEventRaised, e);
        }

        private void SlidingPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, slidingPanelUCSizeChangedEventRaised, e);
        }

        private void SlidingPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _panelCmenuDeleteVisibility == true)
            {
                cmenu_sliding.Show(new Point(MousePosition.X, MousePosition.Y));
            }
            EventHelpers.RaiseMouseEvent(sender, slidingPanelUCMouseClickEventRaised, e);
          
            //Console.WriteLine(this.Parent.Width);
            //Console.WriteLine();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, rightToolStripClickedEventRaised, e);
        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, leftToolStripClickedEventRaised, e);
        }

        private void BothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, bothToolStripClickedEventRaised, e);
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, noneToolStripClickedEventRaised, e);
        }

        private void SlidingPanelUC_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, slidingPanelUCMouseDownEventRaised, e);
        }

        private void SlidingPanelUC_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, slidingPanelUCMouseMoveEventRaised, e);
        }

        private void SlidingPanelUC_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, slidingPanelUCMouseUpEventRaised, e);
        }

       
    }
}
