using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;
using System.Drawing;
using System.ComponentModel;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class CasementPanelUC : UserControl, ICasementPanelUC, IPanelUC
    {
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

        public CasementPanelUC()
        {
            InitializeComponent();
        }

        public event PaintEventHandler casementPanelUCPaintEventRaised;
        public event EventHandler casementPanelUCSizeChangedEventRaised;
        public event EventHandler casementPanelUCMouseEnterEventRaised;
        public event EventHandler casementPanelUCMouseLeaveEventRaised;
        public event EventHandler deleteToolStripClickedEventRaised;
        public event MouseEventHandler casementPanelUCMouseClickEventRaised;
        public event MouseEventHandler casementPanelUCMouseMoveEventRaised;
        public event MouseEventHandler casementPanelUCMouseDownEventRaised;
        public event MouseEventHandler casementPanelUCMouseUpEventRaised;
        public event EventHandler rightToolStripClickedEventRaised;
        public event EventHandler leftToolStripClickedEventRaised;
        public event EventHandler bothToolStripClickedEventRaised;
        public event EventHandler noneToolStripClickedEventRaised;
        public event MouseEventHandler casementPanelUCMouseDoubleClickedEventRaised;
        public event KeyEventHandler casementPanelUCKeyDownEventRaised;

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
            this.DataBindings.Add(ModelBinding["Panel_BackColor"]);
            this.DataBindings.Add(ModelBinding["Panel_CmenuDeleteVisibility"]);
        }

        private void CasementPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, casementPanelUCPaintEventRaised, e);
        }

        private void CasementPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, casementPanelUCSizeChangedEventRaised, e);
        }

        private void CasementPanelUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, casementPanelUCMouseEnterEventRaised, e);
        }

        private void CasementPanelUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, casementPanelUCMouseLeaveEventRaised, e);
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void CasementPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && _panelCmenuDeleteVisibility == true)
                {
                    if (this.Parent.Name.Contains("Frame"))
                        overlapSashToolStripMenuItem.Visible = false;
                    else
                        overlapSashToolStripMenuItem.Visible = true;
                    cmenu_casement.Show(new Point(MousePosition.X, MousePosition.Y));
                }
                EventHelpers.RaiseMouseEvent(sender, casementPanelUCMouseClickEventRaised, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
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

        private void CasementPanelUC_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, casementPanelUCMouseUpEventRaised, e);
        }

        private void CasementPanelUC_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, casementPanelUCMouseMoveEventRaised, e);
        }

        private void CasementPanelUC_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, casementPanelUCMouseDownEventRaised, e);
        }

        private void CasementPanelUC_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(this, casementPanelUCKeyDownEventRaised, e);
        }
        public void FocusOnThis()
        {
            this.Focus();
        }
        private void CasementPanelUC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void CasementPanelUC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, casementPanelUCMouseDoubleClickedEventRaised, e);
        }
    }
}
