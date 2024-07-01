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
    public partial class FixedPanelUC : UserControl, IFixedPanelUC, IPanelUC
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

        private int _panelGlassID;
        public int PanelGlass_ID
        {
            get
            {
                return _panelGlassID;
            }
            set
            {
                _panelGlassID = value;
                this.Invalidate();
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

        public bool cmenuFxdOverlapSashVisibility
        {
            get
            {
                return overlapSashToolStripMenuItem.Visible;
            }

            set
            {
                overlapSashToolStripMenuItem.Visible = value;
            }
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null)
            {
                RemoveDataBinding();
            }

        }

        private void RemoveDataBinding()
        {
            this.DataBindings.Clear();
            cmenu_fxd.Dispose();
            deleteToolStripMenuItem.Dispose();
            overlapSashToolStripMenuItem.Dispose();
            rightToolStripMenuItem.Dispose();
            noneToolStripMenuItem.Dispose();
            leftToolStripMenuItem.Dispose();
            bothToolStripMenuItem.Dispose();
            this.Dispose();


        }

        public ContextMenuStrip GetcmenuFxd()
        {
            return cmenu_fxd;
        }
        public event EventHandler deleteToolStripClickedEventRaised;
        public event PaintEventHandler fixedPanelUCPaintEventRaised;
        public event EventHandler fixedPanelMouseEnterEventRaised;
        public event EventHandler fixedPanelMouseLeaveEventRaised;
        public event EventHandler fixedPanelSizeChangedEventRaised;
        public event MouseEventHandler fixedPanelUCMouseMoveEventRaised;
        public event MouseEventHandler fixedPanelUCMouseDownEventRaised;
        public event MouseEventHandler fixedPanelUCMouseUpEventRaised;
        public event EventHandler rightToolStripClickedEventRaised;
        public event EventHandler leftToolStripClickedEventRaised;
        public event EventHandler bothToolStripClickedEventRaised;
        public event EventHandler noneToolStripClickedEventRaised;
        public event MouseEventHandler fixedPanelUCMouseClickEventRaised;
        public event MouseEventHandler fixedPanelUCMouseDoubleClickedEventRaised;
        public event KeyEventHandler fixedPanelUCKeyDownEventRaised;

        private void FixedPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, fixedPanelUCPaintEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["Panel_ID"]);
            this.DataBindings.Add(binding["Panel_Name"]);
            this.DataBindings.Add(binding["Panel_Dock"]);
            this.DataBindings.Add(binding["Panel_Width"]);
            this.DataBindings.Add(binding["Panel_Height"]);
            this.DataBindings.Add(binding["Panel_Visibility"]);
            this.DataBindings.Add(binding["Panel_Orient"]);
            this.DataBindings.Add(binding["Panel_Margin"]);
            this.DataBindings.Add(binding["Panel_Placement"]);
            this.DataBindings.Add(binding["PanelGlass_ID"]);
            this.DataBindings.Add(binding["Panel_CmenuDeleteVisibility"]);
            this.DataBindings.Add(binding["Panel_BackColor"]);

        }

        private void FixedPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
               
                EventHelpers.RaiseMouseEvent(this, fixedPanelUCMouseClickEventRaised, e);
            }
            catch (Exception)
            {

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

        private void FixedPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, fixedPanelSizeChangedEventRaised, e);
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

        private void NoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, noneToolStripClickedEventRaised, e);
        }

        private void FixedPanelUC_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, fixedPanelUCMouseUpEventRaised, e);
        }

        private void FixedPanelUC_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, fixedPanelUCMouseMoveEventRaised, e);
        }

        private void FixedPanelUC_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, fixedPanelUCMouseDownEventRaised, e);
        }

        private void cmenu_fxd_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void FixedPanelUC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, fixedPanelUCMouseDoubleClickedEventRaised, e);
        }

        private void FixedPanelUC_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(this, fixedPanelUCKeyDownEventRaised, e);
        }

        private void FixedPanelUC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }
        public void FocusOnThis()
        {
            this.Focus();
        }
    }
}
