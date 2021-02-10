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
using CommonComponents;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ModelLayer.Model.Quotation.MultiPanel;
using ServiceLayer.Services.MultiPanelServices;
using System.Linq;

namespace PresentationLayer.Presenter.UserControls
{
    public class FrameUCPresenter : IFrameUCPresenter, IPresenterCommon
    {
        IFrameUC _frameUC;
        private IUnityContainer _unityC;

        private IFrameModel _frameModel;
        private IPanelModel _panelModel;
        private IMultiPanelModel _multipanelModel;

        private IMainPresenter _mainPresenter;
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IFixedPanelUCPresenter _fixedUCP;
        private IFixedPanelImagerUCPresenter _fixedImagerUCP;
        private ICasementPanelUCPresenter _casementUCP;
        private ICasementPanelImagerUCPresenter _casementImagerUCP;
        private IAwningPanelUCPresenter _awningUCP;
        private IAwningPanelImagerUCPresenter _awningImagerUCP;
        private ISlidingPanelUCPresenter _slidingUCP;
        private ISlidingPanelImagerUCPresenter _slidingImagerUCP;
        private IMultiPanelMullionUCPresenter _multiUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IBasePlatformPresenter _basePlatformUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP;

        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;

        private ContextMenuStrip _frameCmenu;

        public FrameUCPresenter(IFrameUC frameUC,
                                IFixedPanelUCPresenter fixedUCP,
                                IFixedPanelImagerUCPresenter fixedImagerUCP,
                                IPanelServices panelServices,
                                IPanelPropertiesUCPresenter panelPropertiesUCP,
                                ICasementPanelUCPresenter casementUCP,
                                IAwningPanelUCPresenter awningUCP,
                                IAwningPanelImagerUCPresenter awningImagerUCP,
                                ISlidingPanelUCPresenter slidingUCP,
                                ICasementPanelImagerUCPresenter casementImagerUCP,
                                ISlidingPanelImagerUCPresenter slidingImagerUCP,
                                IMultiPanelServices multipanelServices,
                                IMultiPanelMullionUCPresenter multiUCP,
                                IMultiPanelTransomUCPresenter multiTransomUCP,
                                IMultiPanelPropertiesUCPresenter multiPropUCP)
        {
            _frameUC = frameUC;
            _frameCmenu = _frameUC.GetFrameCmenu();
            _fixedUCP = fixedUCP;
            _fixedImagerUCP = fixedImagerUCP;
            _panelServices = panelServices;
            _panelPropertiesUCP = panelPropertiesUCP;
            _casementUCP = casementUCP;
            _casementImagerUCP = casementImagerUCP;
            _awningUCP = awningUCP;
            _awningImagerUCP = awningImagerUCP;
            _slidingUCP = slidingUCP;
            _slidingImagerUCP = slidingImagerUCP;
            _multipanelServices = multipanelServices;
            _multiUCP = multiUCP;
            _multiTransomUCP = multiTransomUCP;
            _multiPropUCP = multiPropUCP;
            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _frameUC.frameLoadEventRaised += new EventHandler(OnFrameLoadEventRaised);
            _frameUC.deleteCmenuEventRaised += new EventHandler(OnDeleteCmenuEventRaised);
            _frameUC.outerFramePaintEventRaised += new PaintEventHandler(OnOuterFramePaintEventRaised);
            _frameUC.frameMouseClickEventRaised += new MouseEventHandler(OnFrameMouseClickEventRaised);
            _frameUC.frameMouseEnterEventRaised += new EventHandler(OnFrameMouseEnterEventRaised);
            _frameUC.frameMouseLeaveEventRaised += new EventHandler(OnFrameMouseLeaveEventRaised);
            _frameUC.frameDragDropEventRaised += _frameUC_frameDragDropEventRaised;
        }

        private void _frameUC_frameDragDropEventRaised(object sender, DragEventArgs e)
        {
            UserControl frame = (UserControl)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int panelID = _mainPresenter.GetPanelCount() + 1,
                multiID = _mainPresenter.GetMultiPanelCount() + 1,
                droped_objWD = frame.Width - _frameModel.Frame_Padding_int.All * 2,
                droped_objHT = frame.Height - _frameModel.Frame_Padding_int.All * 2;

            IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);

            if (data.Contains("Multi-Panel"))
            {
                FlowDirection flow = FlowDirection.LeftToRight;
                if (data.Contains("Transom"))
                {
                    flow = FlowDirection.TopDown;
                }

                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    _frameModel.Frame_Padding_int = new Padding(16);
                }
                else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    _frameModel.Frame_Padding_int = new Padding(23);
                }

                int wd = frame.Width - _frameModel.Frame_Padding_int.All * 2,
                    ht = frame.Height - _frameModel.Frame_Padding_int.All * 2;

                _multipanelModel = _multipanelServices.AddMultiPanelModel(wd,
                                                                          ht,
                                                                          frame,
                                                                          frame,
                                                                          true,
                                                                          flow,
                                                                          multiID);
                _frameModel.Lst_MultiPanel.Add(_multipanelModel);

                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP.GetNewInstance(_unityC, _multipanelModel, _mainPresenter);
                framePropUC.GetFramePropertiesFLP().Controls.Add((UserControl)multiPropUCP.GetMultiPanelPropertiesUC());
                _frameModel.FrameProp_Height += 129;

                if (data.Contains("Mullion"))
                {
                    IMultiPanelMullionUCPresenter multiUCP = _multiUCP.GetNewInstance(_unityC, 
                                                                                      _multipanelModel, 
                                                                                      _frameModel, 
                                                                                      _mainPresenter,
                                                                                      this,
                                                                                      multiPropUCP);
                    IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                    frame.Controls.Add((UserControl)multiUC);
                }
                else if (data.Contains("Transom"))
                {
                    IMultiPanelTransomUCPresenter multiTransom = _multiTransomUCP.GetNewInstance(_unityC,
                                                                                                 _multipanelModel,
                                                                                                 _frameModel,
                                                                                                 _mainPresenter,
                                                                                                 this,
                                                                                                 multiPropUCP);
                    IMultiPanelTransomUC multiUC = multiTransom.GetMultiPanel();
                    frame.Controls.Add((UserControl)multiUC);
                }
            }
            else
            {
                _panelModel = _panelServices.AddPanelModel(droped_objWD,
                                                           frame.Height - _frameModel.Frame_Padding_int.All * 2,
                                                           frame,
                                                           frame,
                                                           (UserControl)framePropUC,
                                                           null,
                                                           data,
                                                           true,
                                                           panelID);
                _frameModel.Lst_Panel.Add(_panelModel);

                IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                framePropUC.GetFramePropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());
                _frameModel.FrameProp_Height += 148;


                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    _frameModel.Frame_Padding_int = new Padding(26);
                }
                else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    _frameModel.Frame_Padding_int = new Padding(33);
                }

                if (data == "Fixed Panel")
                {
                    IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC, 
                                                                               _panelModel, 
                                                                               _frameModel, 
                                                                               _mainPresenter,
                                                                               this);
                    IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                    frame.Controls.Add((UserControl)fixedUC);
                    fixedUCP.SetInitialLoadFalse();

                    //IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC, _panelModel);
                    //IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
                    //pnl_inner_willRenderImg.Controls.Add((UserControl)fixedImagerUC);
                }
                else if (data == "Casement Panel")
                {
                    ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC, 
                                                                                        _panelModel, 
                                                                                        _frameModel, 
                                                                                        _mainPresenter,
                                                                                        this);
                    ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                    frame.Controls.Add((UserControl)casementUC);

                    //ICasementPanelImagerUCPresenter casementImagerUCP = _casementImagerUCP.GetNewInstance(_unityC, _panelModel);
                    //ICasementPanelImagerUC casementImagerUC = casementImagerUCP.GetCasementPanelImagerUC();
                    //pnl_inner_willRenderImg.Controls.Add((UserControl)casementImagerUC);
                }
                else if (data == "Awning Panel")
                {
                    IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC, 
                                                                                  _panelModel, 
                                                                                  _frameModel, 
                                                                                  _mainPresenter,
                                                                                  this);
                    IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                    frame.Controls.Add((UserControl)awningUC);

                    //IAwningPanelImagerUCPresenter awningImagerUCP = _awningImagerUCP.GetNewInstance(_unityC, _panelModel);
                    //IAwningPanelImagerUC awningImagerUC = awningImagerUCP.GetAwningPanelUC();
                    //pnl_inner_willRenderImg.Controls.Add((UserControl)awningImagerUC);
                }
                else if (data == "Sliding Panel")
                {
                    ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC, 
                                                                                     _panelModel, 
                                                                                     _frameModel, 
                                                                                     _mainPresenter,
                                                                                     this);
                    ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                    frame.Controls.Add((UserControl)slidingUC);

                    //ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC, _panelModel);
                    //ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
                    //pnl_inner_willRenderImg.Controls.Add((UserControl)slidingImagerUC);
                }
            }
        }

        //private void OnPanelInnerDragDropEventRaised(object sender, DragEventArgs e)
        //{
        //    Control pnl = (Control)sender; //Control na babagsakan
        //    string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

        //    int panelID = _mainPresenter.GetPanelCount() + 1;
        //    int multiID = _mainPresenter.GetMultiPanelCount() + 1;

        //    IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);
        //    Panel pnl_inner_willRenderImg = _mainPresenter.GetFrameImagerInnerPanel(_frameModel.Frame_ID);

        //    if (pnl.Name == "pnl_inner")
        //    {
        //        if (data.Contains("Multi-Panel"))
        //        {
        //            FlowDirection flow = FlowDirection.LeftToRight;
        //            if (data.Contains("Transom"))
        //            {
        //                flow = FlowDirection.TopDown;
        //            }
        //            _multipanelModel = _multipanelServices.AddMultiPanelModel(pnl.Width,
        //                                                                      pnl.Height,
        //                                                                      pnl,
        //                                                                      (UserControl)pnl.Parent,
        //                                                                      true,
        //                                                                      flow,
        //                                                                      multiID);
        //            _frameModel.Lst_MultiPanel.Add(_multipanelModel);

        //            if (data.Contains("Mullion"))
        //            {
        //                IMultiPanelMullionUCPresenter multiUCP = _multiUCP.GetNewInstance(_unityC, 
        //                    _multipanelModel, 
        //                    _frameModel, 
        //                    _mainPresenter);
        //                IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
        //                pnl.Controls.Add((UserControl)multiUC);
        //            }
        //        }
        //        else
        //        {
        //            _panelModel = _panelServices.AddPanelModel(pnl.Width,
        //                                                       pnl.Height,
        //                                                       pnl,
        //                                                       (UserControl)pnl.Parent,
        //                                                       (UserControl)framePropUC,
        //                                                       data,
        //                                                       true,
        //                                                       panelID);
        //            _frameModel.Lst_Panel.Add(_panelModel);

        //            IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
        //            framePropUC.GetFramePropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());
        //            _frameModel.FrameProp_Height += 148;

        //            if (data == "Fixed Panel")
        //            {
        //                IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC, _panelModel, _frameModel, _mainPresenter);
        //                IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
        //                pnl.Controls.Add((UserControl)fixedUC);
        //                fixedUCP.SetInitialLoadFalse();

        //                IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC, _panelModel);
        //                IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
        //                pnl_inner_willRenderImg.Controls.Add((UserControl)fixedImagerUC);
        //            }
        //            else if (data == "Casement Panel")
        //            {
        //                ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC, _panelModel, _frameModel, _mainPresenter);
        //                ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
        //                pnl.Controls.Add((UserControl)casementUC);


        //                ICasementPanelImagerUCPresenter casementImagerUCP = _casementImagerUCP.GetNewInstance(_unityC, _panelModel);
        //                ICasementPanelImagerUC casementImagerUC = casementImagerUCP.GetCasementPanelImagerUC();
        //                pnl_inner_willRenderImg.Controls.Add((UserControl)casementImagerUC);
        //            }
        //            else if (data == "Awning Panel")
        //            {
        //                IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC, _panelModel, _frameModel, _mainPresenter);
        //                IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
        //                pnl.Controls.Add((UserControl)awningUC);

        //                IAwningPanelImagerUCPresenter awningImagerUCP = _awningImagerUCP.GetNewInstance(_unityC, _panelModel);
        //                IAwningPanelImagerUC awningImagerUC = awningImagerUCP.GetAwningPanelUC();
        //                pnl_inner_willRenderImg.Controls.Add((UserControl)awningImagerUC);
        //            }
        //            else if (data == "Sliding Panel")
        //            {
        //                ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC, _panelModel, _frameModel, _mainPresenter);
        //                ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
        //                pnl.Controls.Add((UserControl)slidingUC);

        //                ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC, _panelModel);
        //                ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
        //                pnl_inner_willRenderImg.Controls.Add((UserControl)slidingImagerUC);
        //            }
        //        }
        //        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        //    }
        //}

        //private void OnPanelInnerMouseLeaveEventRaised(object sender, EventArgs e)
        //{
        //    color = Color.Black;
        //    _frameUC.InvalidateThis();
        //}

        //private void OnPanelInnerMouseEnterEventRaised(object sender, EventArgs e)
        //{
        //    color = Color.Blue;
        //    _frameUC.InvalidateThis();
        //}

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
                //_frameUC.InvalidateThisParentsParent();
            }
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

        public void OnFrameLoadEventRaised(object sender, EventArgs e)
        {
            _frameUC.ThisBinding(CreateBindingDictionary());
            _frameUC.InvalidateThis();
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> frameBinding = new Dictionary<string, Binding>();
            frameBinding.Add("Frame_Visible", new Binding("Visible", _frameModel, "Frame_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Width", new Binding("Width", _frameModel, "Frame_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Height", new Binding("Height", _frameModel, "Frame_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Padding", new Binding("thisPadding", _frameModel, "Frame_Padding_int", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_ID", new Binding("frameID", _frameModel, "Frame_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Name", new Binding("Name", _frameModel, "Frame_Name", true, DataSourceUpdateMode.OnPropertyChanged));

            return frameBinding;
        }

        Color color = Color.Black;
        public void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            UserControl pfr = (UserControl)sender;

            int fr_pads = 0;
            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                fr_pads = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                fr_pads = 33;
            }

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
            
            g.DrawRectangle(blkPen, pnl_inner);

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

        public IFrameUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                IFrameModel frameModel, 
                                                IMainPresenter mainPresenter,
                                                IBasePlatformPresenter basePlatformUCP)
        {
            unityC
                .RegisterType<IFrameUC, FrameUC>()
                .RegisterType<IFrameUCPresenter, FrameUCPresenter>();
            FrameUCPresenter framePresenter = unityC.Resolve<FrameUCPresenter>();
            framePresenter._frameModel = frameModel;
            framePresenter._mainPresenter = mainPresenter;
            framePresenter._unityC = unityC;
            framePresenter._basePlatformUCP = basePlatformUCP;

            return framePresenter;
        }
        
        public void DeleteFrame()
        {
            _frameModel.Frame_Visible = false;
            _basePlatformUCP.ViewDeleteControl((UserControl)_frameUC);
            _basePlatformUCP.InvalidateBasePlatform();
            _basePlatformUCP.Invalidate_flpMain();
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        public void ViewDeleteControl(UserControl control)
        {
            _frameUC.DeleteControl(control);
        }
    }
}
