using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PresentationLayer.Views.UserControls.WinDoorPanels.Thumbs
{
    public partial class Thumbs_FixedPanelUC : UserControl
    {
        public Thumbs_FixedPanelUC()
        {
            InitializeComponent();
        }

        private void Thumbs_FixedPanelUC_Paint(object sender, PaintEventArgs e)
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
    }
}
