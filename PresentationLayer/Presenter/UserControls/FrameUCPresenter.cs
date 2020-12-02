using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class FrameUCPresenter : IFrameUCPresenter
    {
        IFrameUC _frameUC;

        private IFrameModel _frameModel;
        private IBasePlatformPresenter _basePlatformPresenter;
        private IMainPresenter _mainPresenter;
        private ContextMenuStrip _frameCmenu;

        public FrameUCPresenter(IFrameUC frameUC,
                                IBasePlatformPresenter basePlatformPresenter)
        {
            _frameUC = frameUC;
            _basePlatformPresenter = basePlatformPresenter;
            _frameCmenu = _frameUC.GetFrameCmenu();
            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _frameUC.frameLoadEventRaised += new EventHandler(OnFrameLoadEventRaised);
            _frameUC.deleteCmenuEventRaised += new EventHandler(OnDeleteCmenuEventRaised);
            _frameUC.outerFramePaintEventRaised += new PaintEventHandler(OnOuterFramePaintEventRaised);
            _frameUC.innerFramePaintEventRaised += new PaintEventHandler(OnInnerFramePaintEventRaised);
            _frameUC.frameMouseClickEventRaised += new MouseEventHandler(OnFrameMouseClickEventRaised);
            _frameUC.frameMouseEnterEventRaised += new EventHandler(OnFrameMouseEnterEventRaised);
            _frameUC.frameMouseLeaveEventRaised += new EventHandler(OnFrameMouseLeaveEventRaised);
            _frameUC.panelInnerMouseEnterEventRaised += new EventHandler(OnPanelInnerMouseEnterEventRaised);
            _frameUC.panelInnerMouseLeaveEventRaised += new EventHandler(OnPanelInnerMouseLeaveEventRaised);

        }

        private void OnPanelInnerMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _frameUC.InvalidateThis();
        }

        private void OnPanelInnerMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _frameUC.InvalidateThis();
        }

        private void OnFrameMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _frameUC.InvalidateThis();
        }

        private void OnFrameMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _frameUC.InvalidateThis();
        }

        private void OnDeleteCmenuEventRaised(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to DELETE?",
                                "Deletion",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteFrame();
            }
           // _promptYesNoUCP.SetValues(this, _mainPresenter);
           //_promptYesNoUCP.GetPromptYesNo().PromptYesNo("Are you sure you want to DELETE?");
        }

        private void OnFrameMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                color = Color.Blue;
                _frameUC.InvalidateThis();
                _frameCmenu.Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            }
        }

        public void OnInnerFramePaintEventRaised(object sender, PaintEventArgs e)
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

        public void OnFrameLoadEventRaised(object sender, EventArgs e)
        {
            _frameUC.fWidth = _frameModel.Frame_Width;
            _frameUC.fHeight = _frameModel.Frame_Height;

            Enum enum_frameType = _frameModel.Frame_Type;
            _frameUC.fPadding = Convert.ToInt32(enum_frameType);

            _frameUC.InvalidateThis();
        }

        Color color = Color.Black;
        public void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e)
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
            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));
        }

        public IFrameUC GetFrameUC()
        {
            return _frameUC;
        }

        public IFrameUCPresenter GetNewInstance(IUnityContainer unityC, IFrameModel frameModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IFrameUC, FrameUC>()
                .RegisterType<IFrameUCPresenter, FrameUCPresenter>();
            FrameUCPresenter framePresenter = unityC.Resolve<FrameUCPresenter>();
            framePresenter._frameModel = frameModel;
            framePresenter._mainPresenter = mainPresenter;

            return framePresenter;
        }

        public IFrameUCPresenter GetFrameUCPresenter()
        {
            return this;
        }

        public void DeleteFrame()
        {
            _basePlatformPresenter.DeleteFrameUC(_frameUC);
            _frameModel.Frame_Visible = false;
            //_mainPresenter.DeleteFrame_OnFrameList_WindoorModel(_frameModel);
            //delete pati frame properties body
        }
    }
}
