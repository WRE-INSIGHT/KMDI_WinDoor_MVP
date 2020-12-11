using System;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Unity;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.Panel;
using ServiceLayer.Services.PanelServices;

namespace PresentationLayer.Presenter.UserControls
{
    public class FrameUCPresenter : IFrameUCPresenter
    {
        IFrameUC _frameUC;
        private IUnityContainer _unityC;

        private IFrameModel _frameModel;
        private IPanelModel _panelModel;

        private IBasePlatformPresenter _basePlatformPresenter;
        private IMainPresenter _mainPresenter;
        private IFixedPanelUCPresenter _fixedUCP;

        private IPanelServices _panelServices;

        private ContextMenuStrip _frameCmenu;

        public FrameUCPresenter(IFrameUC frameUC,
                                IBasePlatformPresenter basePlatformPresenter,
                                IFixedPanelUCPresenter fixedUCP,
                                IPanelServices panelServices)
        {
            _frameUC = frameUC;
            _basePlatformPresenter = basePlatformPresenter;
            _frameCmenu = _frameUC.GetFrameCmenu();
            _fixedUCP = fixedUCP;
            _panelServices = panelServices;
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
            _frameUC.panelInnerDragDropEventRaised += new DragEventHandler(OnPanelInnerDragDropEventRaised);
        }

        private void OnPanelInnerDragDropEventRaised(object sender, DragEventArgs e)
        {
            Control pnl = (Control)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;
            if (data == "Fixed")
            {
                if (pnl.Name == "pnl_inner")
                {
                    _panelModel = AddPanelModel(pnl.Width, pnl.Height, pnl, (UserControl)pnl.Parent, data);

                    IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC, _panelModel);
                    IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                    fixedUC.thisdock = DockStyle.Left;
                    pnl.Controls.Add((UserControl)fixedUC);
                }
            }
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
                _frameUC.InvalidateThisParentsParent();
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
            _frameUC.ThisBinding(CreateBindingDictionary());
            _frameUC.InvalidateThis();
        }

        private Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> frameBinding = new Dictionary<string, Binding>();
            frameBinding.Add("Frame_Visible", new Binding("Visible", _frameModel, "Frame_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Width", new Binding("Width", _frameModel, "Frame_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Height", new Binding("Height", _frameModel, "Frame_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Padding", new Binding("Padding", _frameModel, "Frame_Padding_int", true, DataSourceUpdateMode.OnPropertyChanged));

            return frameBinding;
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
            framePresenter._unityC = unityC;
            

            return framePresenter;
        }

        public IFrameUCPresenter GetFrameUCPresenter()
        {
            return this;
        }

        public void DeleteFrame()
        {
            _frameModel.Frame_Visible = false;
        }

        public IPanelModel AddPanelModel(int panelWd,
                                         int panelHt,
                                         Control panelParent,
                                         UserControl panelFrameGroup,
                                         string panelType,
                                         int panelID = 0,
                                         string panelName = "",
                                         DockStyle panelDock = DockStyle.Fill,
                                         bool panelOrient = false,
                                         bool panelVisibility = false)
        {
            //int count = 0;
            if (panelID == 0)
            {
                panelID++;
                //foreach (IFrameModel frame in _windoorModel.lst_frame)
                //{
                //    foreach (IPanelModel panel in frame.lst_Panel)
                //    {
                //        count++;
                //    }
                //}
            }
            if (panelName == "")
            {
                panelName = "Panel " + panelID;
            }

            _panelModel = _panelServices.CreatePanelModel(panelID,
                                                          panelName,
                                                          panelWd,
                                                          panelHt,
                                                          panelDock,
                                                          panelType,
                                                          panelOrient,
                                                          panelParent,
                                                          panelFrameGroup,
                                                          panelVisibility);

            return _panelModel;
        }
    }
}
