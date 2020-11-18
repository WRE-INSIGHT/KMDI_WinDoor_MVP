using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PresentationLayer.Presenter.UserControls
{
    public class FrameUCPresenter : IFrameUCPresenter
    {
        private IFrameUC _frameUC;

        //private float zoom = 1.0f;
        public FrameUCPresenter(IFrameUC frameUC)
        {
            _frameUC = frameUC.GetNewFrame();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _frameUC.frameLoadEventRaised += new EventHandler(OnFrameLoadEventRaised);
            _frameUC.outerFramePaintEventRaised += new PaintEventHandler(OnOuterFramePaintEventRaised);
            _frameUC.innerFramePaintEventRaised += new PaintEventHandler(OnInnerFramePaintEventRaised);
        }

        public void OnInnerFramePaintEventRaised(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            //Panel frame = (Panel)pnl.Parent;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            //if (frame.Tag.ToString() == "0")
            //{
            //    int cond = pnl.Width + pnl.Height;

            //    for (int i = 10; i < cond; i += 10)
            //    {
            //        g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
            //    }
            //}

            //string accname_col = pnl.AccessibleName;
            Color col = Color.Black;
            //if (accname_col == "Black")
            //{
            //    col = Color.Black;
            //}
            //else if (accname_col == "Blue")
            //{
            //    col = Color.Blue;
            //}

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           pnl.ClientRectangle.Width - w,
                                                           pnl.ClientRectangle.Height - w));
        }

        public void OnFrameLoadEventRaised(object sender, EventArgs e)
        {
            _frameUC.InvalidateThis();
        }

        public void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;
            //g.ScaleTransform(zoom, zoom);

            UserControl pfr = (UserControl)sender;
            Panel pnl_inner = (Panel)pfr.Controls[0];

            g.SmoothingMode = SmoothingMode.AntiAlias;


            //if (pfr.AccessibleDescription == "viewmodeOn")
            //{
            //    Font dmnsion_font = new Font("Segoe UI", 12 * zoom);

            //    Size s = TextRenderer.MeasureText(pfr.Name, dmnsion_font);
            //    double mid = (pfr.Width) / 2;
            //    TextRenderer.DrawText(g,
            //                          pfr.Name,
            //                          dmnsion_font,
            //                          new Point((int)(mid - (s.Width / 2)), 1),
            //                          Color.Blue);
            //}

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

            //string accname_col = pfr.AccessibleName;
            Color col = Color.Black;
            //if (accname_col == "Black")
            //{
            //    col = Color.Black;
            //}
            //else if (accname_col == "Blue")
            //{
            //    col = Color.Blue;
            //}

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));
        }

        public IFrameUC GetFrameUC()
        {
            return _frameUC;
        }
    }
}
