using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonComponents;
using System.Drawing;
using System.ComponentModel;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class CasementPanelUC : UserControl, ICasementPanelUC
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

        public CasementPanelUC()
        {
            InitializeComponent();
        }

        public event PaintEventHandler casementPanelUCPaintEventRaised;
        public event EventHandler casementPanelUCSizeChangedEventRaised;
        public event EventHandler casementPanelUCMouseEnterEventRaised;
        public event EventHandler casementPanelUCMouseLeaveEventRaised;
        public event EventHandler deleteToolStripClickedEventRaised;

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
            if (e.Button == MouseButtons.Right)
            {
                cmenu_casement.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
        }
    }
}
