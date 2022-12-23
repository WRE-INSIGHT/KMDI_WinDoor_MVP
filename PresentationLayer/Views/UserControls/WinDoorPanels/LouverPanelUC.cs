using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class LouverPanelUC : UserControl, ILouverPanelUC, IPanelUC
    {
        public LouverPanelUC()
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

        public bool pnl_Orientation { get; set; }

        public event EventHandler louverPanelUCLoadEventRaised;
        public event EventHandler deleteToolStripClickedEventRaised;
        public event EventHandler louverPanelUCMouseEnterEventRaised;
        public event EventHandler louverPanelUCMouseLeaveEventRaised;
        public event PaintEventHandler louverPanelUCPaintEventRaised;
        public event EventHandler louverPanelUCSizeChangedEventRaised;
        public event MouseEventHandler louverPanelUCMouseClickEventRaised;

        private void LouverPanelUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, louverPanelUCLoadEventRaised, e);
        }

        private void LouverPanelUC_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, louverPanelUCPaintEventRaised, e);
        }

        private void LouverPanelUC_MouseEnter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, louverPanelUCMouseEnterEventRaised, e);
        }
        private void LouverPanelUC_MouseLeave(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, louverPanelUCMouseLeaveEventRaised, e);
        }

        private void LouverPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, louverPanelUCSizeChangedEventRaised, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripClickedEventRaised, e);
        }

        private void LouverPanelUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _panelCmenuDeleteVisibility == true)
            {
                cmenu_louver.Show(new Point(MousePosition.X, MousePosition.Y));
            }
            else if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(this, louverPanelUCMouseClickEventRaised, e);
            }
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_Name"]);
            this.DataBindings.Add(ModelBinding["Panel_Dock"]);
            this.DataBindings.Add(ModelBinding["Panel_WidthToBind"]);
            this.DataBindings.Add(ModelBinding["Panel_HeightToBind"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            this.DataBindings.Add(ModelBinding["Panel_Margin"]);
            this.DataBindings.Add(ModelBinding["Panel_Placement"]);
            this.DataBindings.Add(ModelBinding["Panel_CmenuDeleteVisibility"]);
        }

    }
}
