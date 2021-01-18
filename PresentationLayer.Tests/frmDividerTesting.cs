using PresentationLayer.Views.UserControls.Dividers;
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
    public partial class frmDividerTesting : Form
    {
        public frmDividerTesting()
        {
            InitializeComponent();
        }

        private void pnl_frame_Paint(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            Panel pfr = (Panel)sender;
            Panel pnl_inner = (Panel)pfr.Controls[0];

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


            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));

        }

        //private void pnl_inner_Paint(object sender, PaintEventArgs e)
        //{
        //    Panel pnl = (Panel)sender;
        //    Graphics g = e.Graphics;

        //    g.SmoothingMode = SmoothingMode.AntiAlias;

        //    Color col = Color.Black;
        //    int w = 1;
        //    int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

        //    Rectangle bounds = new Rectangle(0,
        //                                     0,
        //                                     pnl.ClientRectangle.Width - w,
        //                                     pnl.ClientRectangle.Height - w);
        //    g.DrawRectangle(new Pen(col, w), bounds);
        //    //g.DrawArc(Pens.Black, bounds, 45.0F, 360.0F);
        //}

        private void frmDividerTesting_SizeChanged(object sender, EventArgs e)
        {
            pnl_frame.Invalidate();
            //pnl_inner.Invalidate();
            pnl_frame.Controls[0].Invalidate();
        }

        private void flp_multi_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            FlowLayoutPanel pnl = (FlowLayoutPanel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pnl.ClientRectangle.Width - w,
                                                                   pnl.ClientRectangle.Height - w));
        }

        private void frmDividerTesting_Paint(object sender, PaintEventArgs e)
        {
            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            //Point point1 = new Point(50, 50);
            //Point point2 = new Point(100, 25);
            //Point point3 = new Point(200, 5);
            //Point point4 = new Point(250, 50);
            //Point point5 = new Point(300, 100);
            //Point point6 = new Point(350, 200);
            //Point point7 = new Point(250, 250);
            //Point[] curvePoints = { point1, point2, point3, point4, point5, point6, point7 };

            // Draw lines between original points to screen.
            //e.Graphics.DrawLines(redPen, curvePoints);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gpath = new GraphicsPath();
            //Rectangle rect = new Rectangle(50, 50, 30, 150);

            //gpath.AddRectangle(rect);

            Point[] topCurve = { new Point(80, 50),
                                 new Point(65, 45),
                                 new Point(50, 50)
                               };

            Point[] botCurve = { new Point(50, 200),
                                 new Point(65, 205),
                                 new Point(80, 200)
                               };

            gpath.AddLine(new Point(50, 50), new Point(50, 200));
            gpath.AddCurve(botCurve);
            gpath.AddLine(new Point(80, 50), new Point(80, 200));
            gpath.AddCurve(topCurve);

            g.DrawPath(Pens.Black, gpath);
            g.FillPath(Brushes.LightSkyBlue, gpath);
            //g.DrawRectangle(Pens.Black, rect);

            //Point[] curvePoints = { new Point(50, 60), new Point(80, 60), };
            //g.DrawArc(Pens.Black, rect, 0, 180f);


            // Draw curve to screen.
            //g.DrawCurve(greenPen, curvePoints);
        }
    }
}
