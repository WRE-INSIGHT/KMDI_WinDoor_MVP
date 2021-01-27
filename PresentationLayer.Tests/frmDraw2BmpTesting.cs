using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Tests
{
    public partial class frmDraw2BmpTesting : Form
    {
        public frmDraw2BmpTesting()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            int fr_pads = 26;
            //if (_frameModel.Frame_Type.ToString().Contains("Window"))
            //{
            //    fr_pads = 26;
            //}
            //else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            //{
            //    fr_pads = 33;
            //}

            Panel pfr = (Panel)sender;
            Rectangle pnl_inner = new Rectangle(new Point(fr_pads, fr_pads),
                                                new Size(pfr.ClientRectangle.Width - (fr_pads * 2),
                                                         pfr.ClientRectangle.Height - (fr_pads * 2)));


            g.SmoothingMode = SmoothingMode.AntiAlias;


            int pInnerX = pnl_inner.Location.X,
            pInnerY = pnl_inner.Location.Y,
            pInnerWd = pnl_inner.Width,
            pInnerHt = pnl_inner.Height;

            Point[] corner_points = new[]
            {
            new Point(0,0),
            new Point(pInnerX,pInnerY),
            new Point(pfr.ClientRectangle.Width,0),
            new Point(pInnerX + pInnerWd,pInnerY),
            new Point(0,pfr.ClientRectangle.Height),
            new Point(pInnerX,pInnerY + pInnerHt),
            new Point(pfr.ClientRectangle.Width,pfr.ClientRectangle.Height),
            new Point(pInnerX + pInnerWd,pInnerY + pInnerHt)
            };

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            //UserControl mullion = (UserControl)flp_multi.Controls.OfType<IMullionUC>().First();
            //Point mul_Pt = mullion.Location;
            //g.DrawLine(blkPen, new Point(mul_Pt.X + 26, 13), new Point(mul_Pt.X + 26 + 30, 13));
            //g.DrawLine(blkPen, new Point(13, 13), new Point(50, 13));

            g.DrawRectangle(blkPen, pnl_inner);

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));

        }
    }
}
