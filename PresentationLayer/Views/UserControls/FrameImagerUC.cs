using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class FrameImagerUC : UserControl, IFrameImagerUC
    {
        public FrameImagerUC()
        {
            InitializeComponent();
        }
        public bool thisVisible
        {
            get
            {
                return this.Visible;
            }
        }

        private int _frameID;
        public int frameID
        {
            get
            {
                return _frameID;
            }

            set
            {
                _frameID = value;
                this.Tag = value;
                pnl_inner.Tag = value;
            }
        }

        public void InvalidateThis()
        {
            this.Invalidate();
        }

        public void InvalidatePanelInner()
        {
            pnl_inner.Invalidate();
        }

        public void InvalidateThisParent()
        {
            this.Parent.Invalidate();
        }

        public void InvalidateThisParentsParent()
        {
            this.Parent.Parent.Invalidate();
        }

        public Panel GetInnerPanel()
        {
            return pnl_inner;
        }

        private void pnl_inner_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color col = Color.Black;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           pnl.ClientRectangle.Width - w,
                                                           pnl.ClientRectangle.Height - w));
        }

        private void FrameImagerUC_Paint(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            UserControl pfr = (UserControl)sender;
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

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Frame_ID"]);
            this.DataBindings.Add(ModelBinding["Frame_Visible"]);
            this.DataBindings.Add(ModelBinding["FrameImageRenderer_Width"]);
            this.DataBindings.Add(ModelBinding["FrameImageRenderer_Height"]);
            this.DataBindings.Add(ModelBinding["Frame_Padding"]);
        }
    }
}
