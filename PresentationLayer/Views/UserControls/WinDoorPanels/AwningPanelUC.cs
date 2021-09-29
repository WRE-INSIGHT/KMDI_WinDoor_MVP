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
    public partial class AwningPanelUC : UserControl, IAwningPanelUC, IPanelUC
    {
        public AwningPanelUC()
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

        private int _panelHeight;
        public int Panel_DisplayHeight
        {
            get
            {
                return _panelHeight;
            }
            set
            {
                _panelHeight = value;
                if (_panelHeight >= 2100)
                {
                    extensionToolStripMenuItem.Visible = true;
                }
                else if (_panelHeight < 2100)
                {
                    extensionToolStripMenuItem.Visible = false;
                }
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
        public event EventHandler awningPanelUCMouseEnterEventRaised;
        public event EventHandler awningPanelUCMouseLeaveEventRaised;
        public event PaintEventHandler awningPanelUCPaintEventRaised;
        public event EventHandler extensionToolStripMenuItemClickedEventRaised;

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

        private void AwningPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(this, awningPanelUCPaintEventRaised, e);
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
            if (e.Button == MouseButtons.Right && _panelCmenuDeleteVisibility == true)
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

        private void extensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, extensionToolStripMenuItemClickedEventRaised, e);
        }
    }
}
