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

        public event EventHandler fixedPanelUCSizeChangedEventRaised;
        public event EventHandler deleteToolStripClickedEventRaised;

        Color color = Color.Black;
        private void FixedPanelUC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           this.ClientRectangle.Width - w,
                                                           this.ClientRectangle.Height - w));
        }

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["Panel_ID"]);
            this.DataBindings.Add(binding["Panel_Dock"]);
            this.DataBindings.Add(binding["Panel_Width"]);
            this.DataBindings.Add(binding["Panel_Height"]);
            this.DataBindings.Add(binding["Panel_Visibility"]);
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
            color = Color.Blue;
            this.Invalidate();
        }

        private void FixedPanelUC_MouseLeave(object sender, EventArgs e)
        {
            color = Color.Black;
            this.Invalidate();
        }
    }
}
