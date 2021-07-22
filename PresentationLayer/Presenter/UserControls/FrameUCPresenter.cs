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
using static ModelLayer.Model.Quotation.QuotationModel;
using static EnumerationTypeLayer.EnumerationTypes;

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
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP;
        private IBasePlatformPresenter _basePlatformUCP;
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP;
        private IFrameImagerUCPresenter _frameImagerUCP;
        private IFramePropertiesUCPresenter _framePropertiesUCP;

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
                                IMultiPanelPropertiesUCPresenter multiPropUCP,
                                IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP)
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
            _multiMullionImagerUCP = multiMullionImagerUCP;
            _multiTransomImagerUCP = multiTransomImagerUCP;
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
            _frameUC.frameControlAddedEventRaised += _frameUC_frameControlAddedEventRaised;
            _frameUC.frameControlRemovedEventRaised += _frameUC_frameControlRemovedEventRaised;
        }

        private void _frameUC_frameControlRemovedEventRaised(object sender, ControlEventArgs e)
        {
            _framePropertiesUCP.SetFrameTypeRadioBtnEnabled(true);
        }

        private void _frameUC_frameControlAddedEventRaised(object sender, ControlEventArgs e)
        {
            UserControl pfr = (UserControl)sender;

            if (pfr.Controls[0] is IMultiPanelUC)
            {
                _framePropertiesUCP.SetFrameTypeRadioBtnEnabled(false);
            }
            else if (pfr.Controls[0] is IPanelUC)
            {
                _framePropertiesUCP.SetFrameTypeRadioBtnEnabled(true);
            }
        }

        private void _frameUC_frameDragDropEventRaised(object sender, DragEventArgs e)
        {
            UserControl frame = (UserControl)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);

            if (data.Contains("Multi-Panel"))
            {
                FlowDirection flow = FlowDirection.LeftToRight;
                if (data.Contains("Transom"))
                {
                    flow = FlowDirection.TopDown;
                }

                _frameModel.SetDeductFramePadding(true);
                
                _multipanelModel = _multipanelServices.AddMultiPanelModel(wd,
                                                                          ht,
                                                                          _frameModel.Frame_Width,
                                                                          _frameModel.Frame_Height,
                                                                          frame,
                                                                          frame,
                                                                          _frameModel,
                                                                          true,
                                                                          flow,
                                                                          _frameModel.Frame_Zoom,
                                                                          _mainPresenter.GetMultiPanelCount(),
                                                                          DockStyle.Fill,
                                                                          1,
                                                                          0,
                                                                          null,
                                                                          _frameModel.FrameImageRenderer_Zoom);
                _frameModel.Lst_MultiPanel.Add(_multipanelModel);

                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP.GetNewInstance(_unityC, _multipanelModel, _mainPresenter);
                framePropUC.GetFramePropertiesFLP().Controls.Add((UserControl)multiPropUCP.GetMultiPanelPropertiesUC());
                _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");

                if (data.Contains("Mullion"))
                {
                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                      _multipanelModel,
                                                                                                                      _frameModel,
                                                                                                                      _frameImagerUCP);
                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                    _frameImagerUCP.AddControl((UserControl)multiMullionImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();

                    IMultiPanelMullionUCPresenter multiUCP = _multiUCP.GetNewInstance(_unityC, 
                                                                                      _multipanelModel,
                                                                                      _frameModel,
                                                                                      _mainPresenter,
                                                                                      this,
                                                                                      _multiTransomUCP,
                                                                                      multiPropUCP,
                                                                                      _frameImagerUCP,
                                                                                      _basePlatformImagerUCP,
                                                                                      multiMullionImagerUCP);
                    IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                    frame.Controls.Add((UserControl)multiUC);
                    //multiUCP.SetInitialLoadFalse();
                }
                else if (data.Contains("Transom"))
                {
                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                      _multipanelModel,
                                                                                                                      _frameModel,
                                                                                                                      _frameImagerUCP);
                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                    _frameImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();

                    IMultiPanelTransomUCPresenter multiTransomUCP = _multiTransomUCP.GetNewInstance(_unityC,
                                                                                                    _multipanelModel,
                                                                                                    _frameModel,
                                                                                                    _mainPresenter,
                                                                                                    this,
                                                                                                    multiPropUCP,
                                                                                                    _frameImagerUCP,
                                                                                                    _basePlatformImagerUCP,
                                                                                                    multiTransomImagerUCP);
                    IMultiPanelTransomUC multiUC = multiTransomUCP.GetMultiPanel();
                    frame.Controls.Add((UserControl)multiUC);
                    //multiTransomUCP.SetInitialLoadFalse();
                }
            }
            else
            {
                MiddleCloser_ArticleNo midArtNo = MiddleCloser_ArticleNo._None;
                if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                {
                    midArtNo = MiddleCloser_ArticleNo._1WC70DB;
                }
                else if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                         _frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
                {
                    midArtNo = MiddleCloser_ArticleNo._1WC70WHT;
                }

                MotorizedMech_ArticleNo motor = MotorizedMech_ArticleNo._41556C;

                if (ht >= 2000 ||
                    (wd >= 1600 && ht >= 1500))
                {
                    motor = MotorizedMech_ArticleNo._409990E;
                }
                else
                {
                    if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                    {
                        motor = MotorizedMech_ArticleNo._41555B;
                    }
                    else if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                             _frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
                    {
                        motor = MotorizedMech_ArticleNo._41556C;
                    }
                }

                _panelModel = _panelServices.AddPanelModel(wd,
                                                           ht,
                                                           frame,
                                                           frame,
                                                           (UserControl)framePropUC,
                                                           null,
                                                           data,
                                                           true,
                                                           _frameModel.Frame_Zoom,
                                                           _frameModel,
                                                           null,
                                                           _frameModel.Frame_Width,
                                                           _frameModel.Frame_Height,
                                                           GlazingBead_ArticleNo._2452,
                                                           GlassFilm_Types._None,
                                                           SashProfile_ArticleNo._None,
                                                           SashReinf_ArticleNo._None,
                                                           GlassType._Single,
                                                           Espagnolette_ArticleNo._None,
                                                           Striker_ArticleNo._M89ANT,
                                                           midArtNo,
                                                           LockingKit_ArticleNo._None,
                                                           motor,
                                                           Handle_Type._Rotoswing,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           Extension_ArticleNo._None,
                                                           false,
                                                           false,
                                                           false,
                                                           false,
                                                           0,
                                                           0,
                                                           0,
                                                           0,
                                                           0,
                                                           0,
                                                           0,
                                                           0,
                                                           _mainPresenter.GetPanelCount(),
                                                           _mainPresenter.GetPanelGlassID());
                _frameModel.Lst_Panel.Add(_panelModel);

                IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                framePropUC.GetFramePropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());

                if (data == "Fixed Panel")
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");

                    _panelModel.AdjustPropertyPanelHeight("addGlass");

                    IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC, 
                                                                               _panelModel, 
                                                                               _frameModel, 
                                                                               _mainPresenter,
                                                                               this);
                    IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                    frame.Controls.Add((UserControl)fixedUC);

                    IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC, 
                                                                                                 _panelModel, 
                                                                                                 _frameImagerUCP);
                    IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
                    _frameImagerUCP.AddControl((UserControl)fixedImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Casement Panel")
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC, 
                                                                                        _panelModel, 
                                                                                        _frameModel, 
                                                                                        _mainPresenter,
                                                                                        this);
                    ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                    frame.Controls.Add((UserControl)casementUC);
                    //casementUCP.SetInitialLoadFalse();

                    ICasementPanelImagerUCPresenter casementImagerUCP = _casementImagerUCP.GetNewInstance(_unityC, _panelModel, _frameImagerUCP);
                    ICasementPanelImagerUC casementImagerUC = casementImagerUCP.GetCasementPanelImagerUC();
                    _frameImagerUCP.AddControl((UserControl)casementImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Awning Panel")
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                    _panelModel.AdjustPropertyPanelHeight("addChkMotorized");
                    _panelModel.AdjustPropertyPanelHeight("addSash");
                    _panelModel.AdjustPropertyPanelHeight("addGlass");
                    _panelModel.AdjustPropertyPanelHeight("addHandle");

                    _panelModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");

                    IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC, 
                                                                                  _panelModel, 
                                                                                  _frameModel, 
                                                                                  _mainPresenter,
                                                                                  this);
                    IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                    frame.Controls.Add((UserControl)awningUC);

                    IAwningPanelImagerUCPresenter awningImagerUCP = _awningImagerUCP.GetNewInstance(_unityC, _panelModel, _frameImagerUCP);
                    IAwningPanelImagerUC awningImagerUC = awningImagerUCP.GetAwningPanelUC();
                    _frameImagerUCP.AddControl((UserControl)awningImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Sliding Panel")
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC, 
                                                                                     _panelModel, 
                                                                                     _frameModel, 
                                                                                     _mainPresenter,
                                                                                     this);
                    ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                    frame.Controls.Add((UserControl)slidingUC);

                    ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC, _panelModel, _frameImagerUCP);
                    ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
                    _frameImagerUCP.AddControl((UserControl)slidingImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
            }
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
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
            frameBinding.Add("Frame_Width", new Binding("Width", _frameModel, "Frame_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Height", new Binding("Height", _frameModel, "Frame_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Padding", new Binding("Padding", _frameModel, "Frame_Padding_int", true, DataSourceUpdateMode.OnPropertyChanged));
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


            int fr_pads = _frameModel.Frame_Padding_int.All;
            
            Rectangle pnl_inner = new Rectangle(new Point(fr_pads , fr_pads), 
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

            if (pfr.Controls.Count == 0)
            {
                g.DrawRectangle(blkPen, pnl_inner);
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

        public IFrameUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                IFrameModel frameModel, 
                                                IMainPresenter mainPresenter,
                                                IBasePlatformPresenter basePlatformUCP,
                                                IFrameImagerUCPresenter frameImagerUCP,
                                                IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                IFramePropertiesUCPresenter framePropertiesUCP)
        {
            unityC
                .RegisterType<IFrameUC, FrameUC>()
                .RegisterType<IFrameUCPresenter, FrameUCPresenter>();
            FrameUCPresenter framePresenter = unityC.Resolve<FrameUCPresenter>();
            framePresenter._frameModel = frameModel;
            framePresenter._mainPresenter = mainPresenter;
            framePresenter._unityC = unityC;
            framePresenter._basePlatformUCP = basePlatformUCP;
            framePresenter._frameImagerUCP = frameImagerUCP;
            framePresenter._basePlatformImagerUCP = basePlatformImagerUCP;
            framePresenter._framePropertiesUCP = framePropertiesUCP;

            return framePresenter;
        }
        
        public void DeleteFrame()
        {
            foreach (IPanelModel pnl in _frameModel.Lst_Panel)
            {
                _mainPresenter.DeductPanelGlassID();
            }

            foreach (IMultiPanelModel mpnl in _frameModel.Lst_MultiPanel)
            {
                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                {
                    _mainPresenter.DeductPanelGlassID();
                }
            }

            _basePlatformUCP.ViewDeleteControl((UserControl)_frameUC);
            _basePlatformUCP.InvalidateBasePlatform();
            _basePlatformUCP.Invalidate_flpMain();
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.DeleteFramePropertiesUC(_frameModel.Frame_ID);
            _mainPresenter.DeleteFrame_OnFrameList_WindoorModel(_frameModel);

            _mainPresenter.SetPanelGlassID();
        }

        public void ViewDeleteControl(UserControl control)
        {
            _frameUC.DeleteControl(control);
        }
    }
}
