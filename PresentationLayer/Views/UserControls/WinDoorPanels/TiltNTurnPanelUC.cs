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
    public partial class TiltNTurnPanelUC : UserControl, IPanelUC, ITiltNTurnPanelUC
    {
        public TiltNTurnPanelUC()
        {
            InitializeComponent();
        }

        #region GetSet

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

        public bool Panel_ExtensionOptionsVisibility
        {
            get
            {
                return extensionToolStripMenuItem.Checked;
            }

            set
            {
                extensionToolStripMenuItem.Checked = value;
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
        #endregion

        public event EventHandler deleteToolStripClickedEventRaised;
        public event EventHandler tiltNturnPanelUCMouseEnterEventRaised;
        public event EventHandler tiltNturnPanelUCMouseLeaveEventRaised;
        public event PaintEventHandler tiltNturnPanelUCPaintEventRaised;
        public event EventHandler tiltNturnPanelUCSizeChangedEventRaised;

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        private void TiltNTurnPanelUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, tiltNturnPanelUCMouseEnterEventRaised, e);
        }

        private void TiltNTurnPanelUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, tiltNturnPanelUCMouseLeaveEventRaised, e);
        }

        private void TiltNTurnPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, tiltNturnPanelUCPaintEventRaised, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
        }

        private void TiltNTurnPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, tiltNturnPanelUCSizeChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_Name"]);
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["Panel_WidthToBind"]);
            this.DataBindings.Add(ModelBinding["Panel_HeightToBind"]);
            this.DataBindings.Add(ModelBinding["Panel_DisplayHeight"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            this.DataBindings.Add(ModelBinding["Panel_Orient"]);
            this.DataBindings.Add(ModelBinding["Panel_Margin"]);
            this.DataBindings.Add(ModelBinding["Panel_Placement"]);
            this.DataBindings.Add(ModelBinding["Panel_ExtensionOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Panel_CmenuDeleteVisibility"]);
        }

        private void TiltNTurnPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _panelCmenuDeleteVisibility == true)
            {
                cmenu_tiltnturn.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }
    }
}
