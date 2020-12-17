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

        public event EventHandler fixedPanelUCLoadEventRaised;
        public event EventHandler fixedPanelUCSizeChangedEventRaised;

        private void FixedPanelUC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color col = Color.Black;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           this.ClientRectangle.Width - w,
                                                           this.ClientRectangle.Height - w));
        }

        private void FixedPanelUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, fixedPanelUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> binding)
        {
            this.DataBindings.Add(binding["Panel_Dock"]);
            this.DataBindings.Add(binding["Panel_Width"]);
            this.DataBindings.Add(binding["Panel_Height"]);
            this.DataBindings.Add(binding["Panel_Visibility"]);
        }

        private void FixedPanelUC_SizeChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, fixedPanelUCSizeChangedEventRaised, e);
        }
    }
}
