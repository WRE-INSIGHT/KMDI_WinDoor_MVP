using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenter.UserControls.Dividers;
using Unity;
using Unity.Lifetime;
using PresentationLayer.Views.UserControls.Dividers;
using System.Windows.Forms;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class DividerUIUnitTest
    {
        IMullionUCPresenter _mullionUCP;
        ITransomUCPresenter _transomUCP;

        IUnityContainer UnityC;

        [TestInitialize]
        public void SetUp()
        {
            UnityC = new UnityContainer()
               .RegisterType<IMullionUC, MullionUC>(new ContainerControlledLifetimeManager())
               .RegisterType<IMullionUCPresenter, MullionUCPresenter>(new ContainerControlledLifetimeManager())

               .RegisterType<ITransomUC, TransomUC>(new ContainerControlledLifetimeManager())
               .RegisterType<ITransomUCPresenter, TransomUCPresenter>(new ContainerControlledLifetimeManager())
               ;

            _mullionUCP = UnityC.Resolve<MullionUCPresenter>();
            _transomUCP = UnityC.Resolve<TransomUCPresenter>();
        }
        [TestMethod]
        public void MullionUC_Testing()
        {
            frmDividerTesting frm = new frmDividerTesting();

            IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(UnityC);
            IMullionUC mullionUC = mullionUCP.GetMullion("test");

            FlowLayoutPanel flp_multi = new FlowLayoutPanel();
            flp_multi.Name = "multiPnl";
            flp_multi.BackColor = SystemColors.Control;
            flp_multi.Dock = DockStyle.Fill;
            flp_multi.Margin = new Padding(0);
            flp_multi.Paint += new PaintEventHandler(Border_Paint);
            frm.pnl_frame.Controls.Add(flp_multi);

            Panel pnl = new Panel();
            pnl.Size = new Size(180, 330);
            pnl.BackColor = Color.DarkGray;
            pnl.Margin = new Padding(10, 10, 0, 10);
            pnl.Paint += new PaintEventHandler(Border_Paint);
            pnl.Resize += Pnl_Resize;

            Panel pnl2 = new Panel();
            pnl2.Size = new Size(180, 330);
            pnl2.BackColor = Color.DarkGray;
            pnl2.Margin = new Padding(0, 10, 10, 10);
            pnl2.Paint += new PaintEventHandler(Border_Paint);
            pnl2.Resize += Pnl_Resize;

            flp_multi.Controls.Add(pnl);
            flp_multi.Controls.Add((UserControl)mullionUC);
            flp_multi.Controls.Add(pnl2);

            frm.ShowDialog();
        }
        [TestMethod]
        public void TransomUC_Testing()
        {
            frmDividerTesting frm = new frmDividerTesting();

            ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(UnityC);
            ITransomUC transomUC = transomUCP.GetMullion("test");

            FlowLayoutPanel flp_multi = new FlowLayoutPanel();
            flp_multi.Name = "multiPnl";
            flp_multi.FlowDirection = FlowDirection.TopDown;
            flp_multi.BackColor = SystemColors.Control;
            flp_multi.Dock = DockStyle.Fill;
            flp_multi.Margin = new Padding(0);
            flp_multi.Paint += new PaintEventHandler(Border_Paint);
            frm.pnl_frame.Controls.Add(flp_multi);

            Panel pnl = new Panel();
            pnl.Size = new Size(330, 180);
            pnl.BackColor = Color.DarkGray;
            pnl.Margin = new Padding(10, 10, 10, 0);
            pnl.Paint += new PaintEventHandler(Border_Paint);
            pnl.Resize += Pnl_Resize;

            Panel pnl2 = new Panel();
            pnl2.Size = new Size(330, 180);
            pnl2.BackColor = Color.DarkGray;
            pnl2.Margin = new Padding(10, 0, 10, 0);
            pnl2.Paint += new PaintEventHandler(Border_Paint);
            pnl2.Resize += Pnl_Resize;

            flp_multi.Controls.Add(pnl);
            flp_multi.Controls.Add((UserControl)transomUC);
            flp_multi.Controls.Add(pnl2);

            frm.ShowDialog();
        }

        private void Pnl_Resize(object sender, EventArgs e)
        {
            ((Panel)sender).Invalidate();
        }

        private void Border_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Control pnl = (Control)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;


            if (pnl.Name != "multiPnl")
            {
                int w = 1;
                int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       pnl.ClientRectangle.Width - w,
                                                                       pnl.ClientRectangle.Height - w));
            }
            
            if (pnl.Name == "multiPnl")
            {
                int pInnerX = 10,
                pInnerY = 10,
                pInnerWd = pnl.ClientRectangle.Width - 20,
                pInnerHt = pnl.ClientRectangle.Height - 20;

                Point[] corner_points = new[]
                {
                    new Point(0,0),
                    new Point(pInnerX, pInnerY),
                    new Point(pnl.ClientRectangle.Width, 0),
                    new Point(pInnerX + pInnerWd, pInnerY),
                    new Point(0, pnl.ClientRectangle.Height),
                    new Point(pInnerX, pInnerY + pInnerHt),
                    new Point(pnl.ClientRectangle.Width, pnl.ClientRectangle.Height),
                    new Point(pInnerX + pInnerWd, pInnerY + pInnerHt)
                };

                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }


                Rectangle bounds = new Rectangle(new Point(10, 10),
                                                 new Size(pnl.ClientRectangle.Width - 20, pnl.ClientRectangle.Height - 20));
                g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), bounds);
                g.DrawRectangle(Pens.Black, bounds);
            }
        }
    }
}
