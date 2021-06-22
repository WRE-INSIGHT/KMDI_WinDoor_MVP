using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ServiceLayer.Services.DividerServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class MultiPanelMullionUCPresenter : IMultiPanelMullionUCPresenter, IPresenterCommon
    {
        IMultiPanelMullionUC _multiPanelMullionUC;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;

        private IUnityContainer _unityC;

        private IMultiPanelModel _multiPanelModel;
        private IFrameModel _frameModel;

        private IMainPresenter _mainPresenter;
        private IFixedPanelUCPresenter _fixedUCP;
        private IFixedPanelImagerUCPresenter _fixedImagerUCP;
        private ICasementPanelUCPresenter _casementUCP;
        private ICasementPanelImagerUCPresenter _casementImagerUCP;
        private IAwningPanelUCPresenter _awningUCP;
        private IAwningPanelImagerUCPresenter _awningImagerUCP;
        private ISlidingPanelUCPresenter _slidingUCP;
        private ISlidingPanelImagerUCPresenter _slidingImagerUCP;
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IDividerPropertiesUCPresenter _divPropertiesUCP;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IMullionUCPresenter _mullionUCP;
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomUCPresenter _transomUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP_orig;  //Injected Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCP;
        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP; //Given Instance
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP_Injected; //Injected Instance
        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP; //Injected Instance

        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP_parent; //parent instance of Imager counterpart
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP_parent; //parent instance of Imager counterpart

        private IDividerServices _divServices;
        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;
        
        bool _initialLoad;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();
        private CommonFunctions _commonFunctions = new CommonFunctions();

        Timer _tmr = new Timer();

        public IMultiPanelPropertiesUCPresenter multiPropUCP2_given
        {
            get
            {
                return _multiPropUCP2_given;
            }
        }

        public MultiPanelMullionUCPresenter(IMultiPanelMullionUC multiPanelMullionUC,
                                            IFixedPanelUCPresenter fixedUCP,
                                            ICasementPanelUCPresenter casementUCP,
                                            IAwningPanelUCPresenter awningUCP,
                                            ISlidingPanelUCPresenter slidingUCP,
                                            IPanelServices panelServices,
                                            IMultiPanelServices multipanelServices,
                                            IPanelPropertiesUCPresenter panelPropertiesUCP,
                                            IfrmDimensionPresenter frmDimensionPresenter,
                                            IFixedPanelImagerUCPresenter fixedImagerUCP,
                                            ICasementPanelImagerUCPresenter casementImagerUCP,
                                            IAwningPanelImagerUCPresenter awningImagerUCP,
                                            ISlidingPanelImagerUCPresenter slidingImagerUCP,
                                            IMullionUCPresenter mullionUCP,
                                            ITransomUCPresenter transomUCP,
                                            IDividerServices divServices,
                                            IMultiPanelPropertiesUCPresenter multiPropUCP_orig,
                                            IMullionImagerUCPresenter mullionImagerUCP,
                                            ITransomImagerUCPresenter transomImagerUCP,
                                            IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP,
                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP_Injected,
                                            IDividerPropertiesUCPresenter divPropertiesUCP)
        {
            _multiPanelMullionUC = multiPanelMullionUC;
            _fixedUCP = fixedUCP;
            _casementUCP = casementUCP;
            _awningUCP = awningUCP;
            _slidingUCP = slidingUCP;
            _panelServices = panelServices;
            _multipanelServices = multipanelServices;
            _panelPropertiesUCP = panelPropertiesUCP;
            _frmDimensionPresenter = frmDimensionPresenter;
            _fixedImagerUCP = fixedImagerUCP;
            _casementImagerUCP = casementImagerUCP;
            _mullionUCP = mullionUCP;
            _transomUCP = transomUCP;
            _divServices = divServices;
            _multiPropUCP_orig = multiPropUCP_orig;
            _mullionImagerUCP = mullionImagerUCP;
            _awningImagerUCP = awningImagerUCP;
            _slidingImagerUCP = slidingImagerUCP;
            _transomImagerUCP = transomImagerUCP;
            _multiTransomImagerUCP = multiTransomImagerUCP;
            _multiMullionImagerUCP_Injected = multiMullionImagerUCP_Injected;
            _divPropertiesUCP = divPropertiesUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelMullionUC.flpMulltiPaintEventRaised += _multiPanelMullionUC_flpMulltiPaintEventRaised;
            _multiPanelMullionUC.flpMultiMouseEnterEventRaised += _multiPanelMullionUC_flpMultiMouseEnterEventRaised;
            _multiPanelMullionUC.flpMultiMouseLeaveEventRaised += _multiPanelMullionUC_flpMultiMouseLeaveEventRaised;
            _multiPanelMullionUC.divCountClickedEventRaised += _multiPanelMullionUC_divCountClickedEventRaised;
            _multiPanelMullionUC.deleteClickedEventRaised += _multiPanelMullionUC_deleteClickedEventRaised;
            _multiPanelMullionUC.flpMultiDragDropEventRaised += _multiPanelMullionUC_flpMultiDragDropEventRaised;
            _multiPanelMullionUC.multiMullionSizeChangedEventRaised += _multiPanelMullionUC_multiMullionSizeChangedEventRaised;
            _multiPanelMullionUC.dividerEnabledCheckedChangedEventRaised += _multiPanelMullionUC_dividerEnabledCheckedChangedEventRaised;
            _multiPanelMullionUC.flpMultiDragOverEventRaised += _multiPanelMullionUC_flpMultiDragOverEventRaised;
            _tmr.Tick += _tmr_Tick;
        }

        private void _multiPanelMullionUC_flpMultiDragOverEventRaised(object sender, DragEventArgs e)
        {
            int totalCount_objs_to_accomodate = (_multiPanelModel.MPanel_Divisions * 2) + 1;
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            if (_multiPanelModel.MPanelLst_Objects.Count() < totalCount_objs_to_accomodate)
            {
                if ((data.Contains("Multi-Panel") && data.Contains("Mullion")))
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        int _timer_count;
        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
            }
        }

        private void _multiPanelMullionUC_dividerEnabledCheckedChangedEventRaised(object sender, EventArgs e)
        {
            _multiPanelModel.MPanel_DividerEnabled = ((ToolStripMenuItem)sender).Checked;
        }

        int prev_Width = 0,
            prev_Height = 0;
        private void _multiPanelMullionUC_multiMullionSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        mpnlModelWd = _multiPanelModel.MPanel_Width,
                        mpnlModelHt = _multiPanelModel.MPanel_Height;

                    if (thisWd != mpnlModelWd || prev_Width != mpnlModelWd)
                    {
                        //_multiPanelModel.MPanel_Width = thisWd;
                        _WidthChange = true;
                    }
                    if (thisHt != mpnlModelHt || prev_Height != mpnlModelHt)
                    {
                        //_multiPanelModel.MPanel_Height = thisHt;
                        _HeightChange = true;
                    }
                }
                prev_Width = _multiPanelModel.MPanel_Width;
                prev_Height = _multiPanelModel.MPanel_Height;

                _tmr.Start();
                ((UserControl)sender).Invalidate();
                _basePlatformImagerUCP.InvalidateBasePlatform();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int _frmDmRes_Width;
        private int _frmDmRes_Height;

        private int divSize = 0;
        private void _multiPanelMullionUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {

            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int totalPanelCount = _multiPanelModel.MPanel_Divisions + 1;

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }

            IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);
            if (data.Contains("Multi-Panel"))
            {
                if (_multiPanelModel.MPanel_StackNo < 3)
                {
                    int suggest_Wd = (((_multiPanelModel.MPanel_Width) - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount),
                        suggest_HT = _multiPanelModel.MPanel_Height;

                    int mpanelDisplayWidth = _multiPanelModel.MPanel_DisplayWidth / (_multiPanelModel.MPanel_Divisions + 1),
                        mpanelDisplayHeight = _multiPanelModel.MPanel_DisplayHeight;

                    FlowDirection flow = FlowDirection.LeftToRight;
                    if (data.Contains("Transom"))
                    {
                        flow = FlowDirection.TopDown;
                    }

                    int increment_StackNo = _multiPanelModel.MPanel_StackNo + 1;

                    IMultiPanelModel mPanelModel = _multipanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          mpanelDisplayWidth,
                                                                                          mpanelDisplayHeight,
                                                                                          fpnl,
                                                                                          (UserControl)_frameUCP.GetFrameUC(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          flow,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          _mainPresenter.GetMultiPanelCount(),
                                                                                          DockStyle.None,
                                                                                          increment_StackNo,
                                                                                          _multiPanelModel.GetNextIndex(),
                                                                                          _multiPanelModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom);
                    _frameModel.Lst_MultiPanel.Add(mPanelModel);
                    _multiPanelModel.MPanelLst_MultiPanel.Add(mPanelModel);
                    _multiPanelModel.Reload_MultiPanelMargin();

                    IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP_orig.GetNewInstance(_unityC, mPanelModel, _mainPresenter);
                    _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)multiPropUCP.GetMultiPanelPropertiesUC());

                    _multiPanelModel.AdjustPropertyPanelHeight("Mpanel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");

                    if (data.Contains("Mullion"))
                    {
                        IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP_Injected.GetNewInstance(_unityC,
                                                                                                                                   mPanelModel,
                                                                                                                                   _frameModel,
                                                                                                                                   _multiMullionImagerUCP);
                        IMultiPanelMullionImagerUC multiMullionUC = multiMullionImagerUCP.GetMultiPanelImager();
                        _multiMullionImagerUCP.AddControl((UserControl)multiMullionUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();

                        IMultiPanelMullionUCPresenter multiUCP = GetNewInstance(_unityC,
                                                                                mPanelModel,
                                                                                _frameModel,
                                                                                _mainPresenter,
                                                                                _frameUCP,
                                                                                this,
                                                                                _multiPanelTransomUCP,
                                                                                multiPropUCP,
                                                                                _basePlatformImagerUCP,
                                                                                multiMullionImagerUCP,
                                                                                _multiMullionImagerUCP);
                        IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiUCP.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC, _frameModel.Frame_Type.ToString());

                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls_Dimensions();
                            _multiPanelModel.Fit_MyControls_ToBindDimensions();
                            _multiPanelModel.Adjust_ControlDisplaySize();
                            _mainPresenter.Run_GetListOfMaterials_SpecificItem();
                            _multiPanelModel.SetEqualGlassDimension();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
                        {
                            IDividerModel divModel = _divServices.AddDividerModel(divSize,
                                                                                  _multiPanelModel.MPanel_Height,
                                                                                  fpnl,
                                                                                  DividerModel.DividerType.Mullion,
                                                                                  true,
                                                                                  _frameModel.Frame_Zoom,
                                                                                  Divider_ArticleNo._7536,
                                                                                  _multiPanelModel.MPanel_DisplayWidth,
                                                                                  _multiPanelModel.MPanel_DisplayHeight,
                                                                                  _multiPanelModel,
                                                                                  _mainPresenter.GetDividerCount(),
                                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                                  _frameModel.Frame_Type.ToString());

                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            IDividerPropertiesUCPresenter divPropUCP = _divPropertiesUCP.GetNewInstance(_unityC, divModel, _mainPresenter);
                            _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)divPropUCP.GetDivProperties());

                            _multiPanelModel.AdjustPropertyPanelHeight("Div", "add");
                            _frameModel.AdjustPropertyPanelHeight("Div", "add");

                            IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel,
                                                                                        _mainPresenter);
                            IMullionUC mullionUC = mullionUCP.GetMullion();
                            fpnl.Controls.Add((UserControl)mullionUC);
                            mullionUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());

                            IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                          divModel,
                                                                                                          _multiPanelModel,
                                                                                                          _frameModel,
                                                                                                          _multiMullionImagerUCP,
                                                                                                          mullionUC);
                            IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                            _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                    }
                    else if (data.Contains("Transom"))
                    {
                        IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                         mPanelModel,
                                                                                                                         _frameModel,
                                                                                                                         _multiMullionImagerUCP);
                        IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                        _multiMullionImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();

                        IMultiPanelTransomUCPresenter multiTransom = _multiPanelTransomUCP.GetNewInstance(_unityC,
                                                                                                          mPanelModel,
                                                                                                          _frameModel,
                                                                                                          _mainPresenter,
                                                                                                          _frameUCP,
                                                                                                          this,
                                                                                                          multiPropUCP,
                                                                                                          _frameImagerUCP,
                                                                                                          _basePlatformImagerUCP,
                                                                                                          multiTransomImagerUCP,
                                                                                                          _multiMullionImagerUCP);
                        IMultiPanelTransomUC multiUC = multiTransom.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiTransom.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC, _frameModel.Frame_Type.ToString());

                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls_Dimensions();
                            _multiPanelModel.Fit_MyControls_ToBindDimensions();
                            _multiPanelModel.Adjust_ControlDisplaySize();
                            _mainPresenter.Run_GetListOfMaterials_SpecificItem();
                            _multiPanelModel.SetEqualGlassDimension();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
                        {
                            IDividerModel divModel = _divServices.AddDividerModel(divSize,
                                                                                 _multiPanelModel.MPanel_Height,
                                                                                 fpnl,
                                                                                 DividerModel.DividerType.Mullion,
                                                                                 true,
                                                                                 _frameModel.Frame_Zoom,
                                                                                 Divider_ArticleNo._7536,
                                                                                 _multiPanelModel.MPanel_DisplayWidth,
                                                                                 _multiPanelModel.MPanel_DisplayHeight,
                                                                                  _multiPanelModel,
                                                                                 _mainPresenter.GetDividerCount(),
                                                                                 _frameModel.FrameImageRenderer_Zoom);

                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            IDividerPropertiesUCPresenter divPropUCP = _divPropertiesUCP.GetNewInstance(_unityC, divModel, _mainPresenter);
                            _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)divPropUCP.GetDivProperties());

                            _multiPanelModel.AdjustPropertyPanelHeight("Div", "add");
                            _frameModel.AdjustPropertyPanelHeight("Div", "add");

                            IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel,
                                                                                        _mainPresenter);
                            IMullionUC mullionUC = mullionUCP.GetMullion();
                            fpnl.Controls.Add((UserControl)mullionUC);
                            mullionUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());

                            IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                          divModel,
                                                                                                          _multiPanelModel,
                                                                                                          _frameModel,
                                                                                                          _multiMullionImagerUCP,
                                                                                                          mullionUC);
                            IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                            _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Maximum stacks reached", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                int suggest_Wd = 0,
                    suggest_HT = _multiPanelModel.MPanel_Height - 20,
                    suggest_DisplayWD = _multiPanelModel.MPanel_DisplayWidth / totalPanelCount,
                    suggest_DisplayHT = _multiPanelModel.MPanel_DisplayHeight;

                if (_multiPanelModel.MPanel_DividerEnabled)
                {
                    suggest_Wd = (((_multiPanelModel.MPanel_Width - 20) - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);
                }
                else if (!_multiPanelModel.MPanel_DividerEnabled)
                {
                    suggest_Wd = (_multiPanelModel.MPanel_Width - 20) / totalPanelCount;
                }

                if (_multiPanelModel.MPanel_ParentModel != null)
                {
                    suggest_HT = (_multiPanelModel.MPanel_Height - 20) + 4;
                }

                IPanelModel _panelModel = _panelServices.AddPanelModel(suggest_Wd,
                                                                       suggest_HT,
                                                                       fpnl,
                                                                       (UserControl)_frameUCP.GetFrameUC(),
                                                                       (UserControl)framePropUC,
                                                                       (UserControl)_multiPanelMullionUC,
                                                                       data,
                                                                       true,
                                                                       _frameModel.Frame_Zoom,
                                                                       _frameModel,
                                                                       _multiPanelModel,
                                                                       suggest_DisplayWD,
                                                                       suggest_DisplayHT,
                                                                       Glass_Thickness._6mm,
                                                                       GlazingBead_ArticleNo._2452,
                                                                       GlassFilm_Types._None,
                                                                       _mainPresenter.GetPanelCount(),
                                                                       _mainPresenter.GetPanelGlassID(),
                                                                       _frameModel.FrameImageRenderer_Zoom,
                                                                       _multiPanelModel.GetNextIndex(),
                                                                       DockStyle.None);
                //_frameModel.Lst_Panel.Add(_panelModel);
                _multiPanelModel.MPanelLst_Panel.Add(_panelModel);
                _multiPanelModel.Reload_PanelMargin();

                IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());

                if (data == "Fixed Panel")
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("FxdNone", "add");
                    _frameModel.AdjustPropertyPanelHeight("FxdNone", "add");

                    IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC,
                                                                               _panelModel,
                                                                               _frameModel,
                                                                               _mainPresenter,
                                                                               _multiPanelModel,
                                                                               this,
                                                                               _multiMullionImagerUCP);
                    IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                    fpnl.Controls.Add((UserControl)fixedUC);
                    _multiPanelModel.AddControl_MPanelLstObjects((UserControl)fixedUC, _frameModel.Frame_Type.ToString());
                    fixedUCP.SetInitialLoadFalse();

                    IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC,
                                                                                                 _panelModel,
                                                                                                 _multiMullionImagerUCP);
                    IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
                    _multiMullionImagerUCP.AddControl((UserControl)fixedImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Casement Panel")
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");

                    ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC,
                                                                                        _panelModel,
                                                                                        _frameModel,
                                                                                        _mainPresenter,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _multiMullionImagerUCP);
                    ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                    fpnl.Controls.Add((UserControl)casementUC);
                    _multiPanelModel.AddControl_MPanelLstObjects((UserControl)casementUC, _frameModel.Frame_Type.ToString());
                    casementUCP.SetInitialLoadFalse();

                    ICasementPanelImagerUCPresenter casementImagerUCP = _casementImagerUCP.GetNewInstance(_unityC,
                                                                                                          _panelModel,
                                                                                                          _multiMullionImagerUCP);
                    ICasementPanelImagerUC casementImagerUC = casementImagerUCP.GetCasementPanelImagerUC();
                    _multiMullionImagerUCP.AddControl((UserControl)casementImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Awning Panel")
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");

                    IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC,
                                                                                  _panelModel,
                                                                                  _frameModel,
                                                                                  _mainPresenter,
                                                                                  _multiPanelModel,
                                                                                  this,
                                                                                  _multiMullionImagerUCP);
                    IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                    fpnl.Controls.Add((UserControl)awningUC);
                    _multiPanelModel.AddControl_MPanelLstObjects((UserControl)awningUC, _frameModel.Frame_Type.ToString());
                    awningUCP.SetInitialLoadFalse();

                    IAwningPanelImagerUCPresenter awningImagerUCP = _awningImagerUCP.GetNewInstance(_unityC,
                                                                                                    _panelModel,
                                                                                                    _multiMullionImagerUCP);
                    IAwningPanelImagerUC awningImagerUC = awningImagerUCP.GetAwningPanelUC();
                    _multiMullionImagerUCP.AddControl((UserControl)awningImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Sliding Panel")
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");

                    ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC,
                                                                                     _panelModel,
                                                                                     _frameModel,
                                                                                     _mainPresenter,
                                                                                     _multiPanelModel,
                                                                                     this,
                                                                                     _multiMullionImagerUCP);
                    ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                    fpnl.Controls.Add((UserControl)slidingUC);
                    _multiPanelModel.AddControl_MPanelLstObjects((UserControl)slidingUC, _frameModel.Frame_Type.ToString());
                    slidingUCP.SetInitialLoadFalse();

                    ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC,
                                                                                                       _panelModel,
                                                                                                       _multiMullionImagerUCP);
                    ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
                    _multiMullionImagerUCP.AddControl((UserControl)slidingImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }

                if (_panelModel.Panel_Placement == "Last")
                {
                    _multiPanelModel.Fit_MyControls_Dimensions();
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Adjust_ControlDisplaySize();
                    _mainPresenter.Run_GetListOfMaterials_SpecificItem();
                    _multiPanelModel.SetEqualGlassDimension();
                }
                else if (_multiPanelModel.MPanel_DividerEnabled && _panelModel.Panel_Placement != "Last")
                {
                    IDividerModel divModel = _divServices.AddDividerModel(divSize,
                                                                          _multiPanelModel.MPanel_Height,
                                                                          fpnl,
                                                                          //(UserControl)_frameUCP.GetFrameUC(),
                                                                          DividerModel.DividerType.Mullion,
                                                                          true,
                                                                          _frameModel.Frame_Zoom,
                                                                          Divider_ArticleNo._7536,
                                                                          _multiPanelModel.MPanel_DisplayWidth,
                                                                          _multiPanelModel.MPanel_DisplayHeight,
                                                                          _multiPanelModel,
                                                                          _mainPresenter.GetDividerCount(),
                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                          _frameModel.Frame_Type.ToString());

                    _frameModel.Lst_Divider.Add(divModel);
                    _multiPanelModel.MPanelLst_Divider.Add(divModel);

                    IDividerPropertiesUCPresenter divPropUCP = _divPropertiesUCP.GetNewInstance(_unityC, divModel, _mainPresenter);
                    _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)divPropUCP.GetDivProperties());

                    _multiPanelModel.AdjustPropertyPanelHeight("Div", "add");
                    _frameModel.AdjustPropertyPanelHeight("Div", "add");

                    IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                divModel,
                                                                                _multiPanelModel,
                                                                                this,
                                                                                _frameModel,
                                                                                _mainPresenter);//,
                                                                                                //_basePlatformImagerUCP);
                    IMullionUC mullionUC = mullionUCP.GetMullion();
                    fpnl.Controls.Add((UserControl)mullionUC);
                    _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                    mullionUCP.SetInitialLoadFalse();

                    IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                  divModel,
                                                                                                  _multiPanelModel,
                                                                                                  _frameModel,
                                                                                                  _multiMullionImagerUCP,
                                                                                                  mullionUC);
                    IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                    _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
            }

            foreach (Control ctrl in fpnl.Controls)
            {
                if (ctrl.Name.Contains("Multi"))
                {
                    ctrl.Controls[0].Invalidate(); //Invalidate the fpnl inside
                }
                else
                {
                    ctrl.Invalidate(); //Divider
                }
            }
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
        }

        private void _multiPanelMullionUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete TransomUC
            if (_multiPanelModel.MPanel_ParentModel != null &&
                _multiPanelModel.MPanel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.IndexOf((UserControl)_multiPanelMullionUC);

                Control divUC = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx + 1];
                _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Remove((UserControl)divUC);
                _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)divUC);

                IDividerModel div = _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                _mainPresenter.DeleteDividerPropertiesUC(div.Div_ID);
                div.Div_MPanelParent.MPanelLst_Divider.Remove(div);
                _frameModel.Lst_Divider.Remove(div);

                _multiPanelModel.AdjustPropertyPanelHeight("Div", "delete");
                _frameModel.AdjustPropertyPanelHeight("Div", "delete");
            }
            #endregion

            #region Delete MultiPanel Mullion
            FlowLayoutPanel innerFlp = (FlowLayoutPanel)((UserControl)_multiPanelMullionUC).Controls[0];
            Control parent_ctrl = ((UserControl)_multiPanelMullionUC).Parent;

            var multiPanels = _mpnlCommons.GetAll(innerFlp, "Multi", "flp");
            foreach (var mpnl in multiPanels)
            {
                _multiPanelModel.AdjustPropertyPanelHeight("Mpanel", "delete");
                _frameModel.AdjustPropertyPanelHeight("Mpanel", "delete");
            }

            var panels = _mpnlCommons.GetAll(innerFlp, "PanelUC");
            foreach (var pnl in panels)
            {
                IPanelUC fxd = (IPanelUC)pnl;
                if (pnl.Name.Contains("Fixed"))
                {
                    if (fxd.pnl_Orientation == true)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "delete");
                        _frameModel.AdjustPropertyPanelHeight("Panel", "delete");
                    }
                    else
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("FxdNone", "delete");
                        _frameModel.AdjustPropertyPanelHeight("FxdNone", "delete");
                    }
                }
                _mainPresenter.DeductPanelGlassID();
            }

            var mullions = _mpnlCommons.GetAll(innerFlp, "MullionUC");
            foreach (var mul in mullions)
            {
                _multiPanelModel.AdjustPropertyPanelHeight("Div", "delete");
                _frameModel.AdjustPropertyPanelHeight("Div", "delete");
            }

            var transoms = _mpnlCommons.GetAll(innerFlp, "TransomUC");
            foreach (var transom in transoms)
            {
                _multiPanelModel.AdjustPropertyPanelHeight("Div", "delete");
                _frameModel.AdjustPropertyPanelHeight("Div", "delete");
            }

            _mainPresenter.DeleteMultiPanelPropertiesUC(_multiPanelModel.MPanel_ID);

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.DeleteControl_MPanelLstObjects((UserControl)_multiPanelMullionUC, 
                                                                                   _frameModel.Frame_Type.ToString(),
                                                                                   _multiPanelModel.MPanel_Placement);
            }

            if (_multiPanelModel.MPanel_Parent is IFrameUC)
            {
                _frameModel.SetDeductFramePadding(false);
            }
            
            foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
            {
                _frameModel.Lst_Panel.Remove(pnl);
            }
            foreach (IDividerModel div in _multiPanelModel.MPanelLst_Divider)
            {
                _frameModel.Lst_Divider.Remove(div);
            }
            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
            {
                _frameModel.Lst_MultiPanel.Remove(mpnl);
            }

            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_multiPanelMullionUC);
            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_multiPanelMullionUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_multiPanelMullionUC);
            }

            if (_multiPanelModel.MPanel_Parent != null)
            {
                _multiPanelModel.AdjustPropertyPanelHeight("Mpanel", "delete");
                _frameModel.AdjustPropertyPanelHeight("Mpanel", "delete");
                _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)_multiPanelMullionUC);
            }

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.MPanelLst_MultiPanel.Remove(_multiPanelModel);
                _multiPanelModel.MPanel_ParentModel.Object_Indexer();
                _multiPanelModel.MPanel_ParentModel.Reload_MultiPanelMargin();
                _multiPanelModel.MPanel_ParentModel.Reload_PanelMargin();
                _commonFunctions.Automatic_Div_Addition(_mainPresenter,
                                                        _frameModel,
                                                        _divServices,
                                                        _transomUCP,
                                                        _unityC,
                                                        _mullionUCP,
                                                        _mullionImagerUCP,
                                                        _transomImagerUCP,
                                                        _mainPresenter.GetDividerCount(),
                                                        _multiPanelModel,
                                                        null,
                                                        _multiPanelTransomUCP,
                                                        _multiPanelMullionUCP,
                                                        _multiMullionImagerUCP_parent,
                                                        _multiPanelTransomImagerUCP_parent);
            }

            if (_frameModel != null)
            {
                _frameModel.Lst_MultiPanel.Remove(_multiPanelModel);
            }

            if (parent_ctrl.Name.Contains("flp_Multi"))
            {
                foreach (Control ctrl in parent_ctrl.Controls)
                {
                    ctrl.Invalidate();
                }
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.SetPanelGlassID();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();

            #endregion
        }

        private void _multiPanelMullionUC_divCountClickedEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input no. of division for " + _multiPanelModel.MPanel_Name, "WinDoor Maker", "1");
            if (input != "" && input != "0")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        _multiPanelModel.MPanel_Divisions = int_input;
                        Invalidate_MultiPanelMullionUC();
                    }
                    else if (int_input < 0)
                    {
                        MessageBox.Show("Invalid number");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233033)
                    {
                        MessageBox.Show("Please input a number.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, ex.HResult.ToString());
                    }
                }
            }
        }

        private void _multiPanelMullionUC_flpMultiMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
        }

        private void _multiPanelMullionUC_flpMultiMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
        }
        
        Color color = Color.Black;
        bool _HeightChange = false,
             _WidthChange = false;

        private void _multiPanelMullionUC_flpMulltiPaintEventRaised(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            Control fpnlParent = fpnl.Parent.Parent; //Parent ng mismong usercontrol, Its either Frame or Multi-Panel
            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;


            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = _frameModel.Frame_Deduction,
                pInnerY = _frameModel.Frame_Deduction,
                pInnerWd = fpnl.ClientRectangle.Width - (_frameModel.Frame_Deduction * 2),
                pInnerHt = fpnl.ClientRectangle.Height - (_frameModel.Frame_Deduction * 2);

            int ht_ToBind = _multiPanelModel.MPanel_HeightToBind,
                wd_ToBind = _multiPanelModel.MPanel_WidthToBind;

            float zoom = _multiPanelModel.MPanel_Zoom;

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];
            
            Point[] corner_points = new[]
            {
                    new Point(0,0),
                    new Point(pInnerX, pInnerY),
                    new Point(fpnl.ClientRectangle.Width, 0),
                    new Point(pInnerX + pInnerWd, pInnerY),
                    new Point(0, fpnl.ClientRectangle.Height),
                    new Point(pInnerX, pInnerY + pInnerHt),
                    new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                    new Point(pInnerX + pInnerWd, pInnerY + pInnerHt)
            };

            GraphicsPath gpath = new GraphicsPath();
            GraphicsPath gpath2 = new GraphicsPath();
            Rectangle bounds = new Rectangle();
            Pen pen = new Pen(Color.Black, 2);

            List<Point[]> thisDrawingPoints_bot = null, //botTransom
                          thisDrawingPoints_top = null, //topTransom
                          thisDrawingPoints_forMullion_RightSide = null,
                          thisDrawingPoints_forMullion_LeftSide = null;

            int pixels_count = 0;
            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                pixels_count = 8;
            }
            else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                pixels_count = 10;
            }

            Rectangle[] divs_bounds_values = { new Rectangle(new Point(0, ht_ToBind - (int)(pixels_count * zoom)), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))) , //bot
                                               new Rectangle(new Point(0, -1), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))), //top
                                               new Rectangle(new Point(wd_ToBind - (int)(pixels_count * zoom), 0), new Size((int)(pixels_count * zoom), ht_ToBind - 1)), //right
                                               new Rectangle(new Point(-1, 0), new Size((int)(pixels_count * zoom), ht_ToBind - 1)) //left
                                             };

            Rectangle divider_bounds_Bot = new Rectangle();
            Rectangle divider_bounds_Top = new Rectangle();
            Rectangle divider_bounds_Right = new Rectangle();
            Rectangle divider_bounds_Left = new Rectangle();

            string parent_name = _multiPanelModel.MPanel_Parent.Name,
                   lvl2_parent_Type = "",
                   thisObj_placement = _multiPanelModel.MPanel_Placement;
            DockStyle parent_doxtyle = DockStyle.None;

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC))
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                int bPoints = (int)(10 * _frameModel.Frame_Zoom),
                    bSizeDeduction = (int)(20 * _frameModel.Frame_Zoom);

                bounds = new Rectangle(new Point(bPoints, bPoints),
                                       new Size(fpnl.ClientRectangle.Width - bSizeDeduction, fpnl.ClientRectangle.Height - bSizeDeduction));
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                string parentObj_placement = _multiPanelModel.MPanel_ParentModel.MPanel_Placement;

                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1,
                    parent_mpnl_childObj_count = parent_mpnl.GetCount_MPanelLst_Object(),
                    indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

                parent_doxtyle = _multiPanelModel.MPanel_ParentModel.MPanel_Dock;

                GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();
                GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                #region Variable Declaration

                #region MAIN PLATFORM Parent_Type
                if (parent_doxtyle == DockStyle.None)
                {
                    lvl2_parent_Type = _multiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type;
                }
                #endregion

                #region thisDrawingPoints_bot and thisDrawingPoints_top
                thisDrawingPoints_bot = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                    fpnl.Height,
                                                                                    "TransomUC",
                                                                                    "First",
                                                                                    _frameModel.Frame_Type.ToString());

                thisDrawingPoints_top = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                    fpnl.Height,
                                                                                    "TransomUC",
                                                                                    "Last",
                                                                                    _frameModel.Frame_Type.ToString());
                #endregion

                #region bounds declaration
                int wd_deduction = 0,
                    ht_deduction = 0,
                    bounds_PointX = 0,
                    bounds_PointY = 0;

                if (parent_name.Contains("MultiTransom"))
                #region Parent is MultiPanel Transom
                {
                    wd_deduction = (int)(20 * zoom);
                    bounds_PointX = (int)(10 * zoom);

                    if (thisObj_placement == "First")
                    {
                        bounds_PointY = (int)(10 * zoom);
                        ht_deduction = (int)((10 + (pixels_count + 1)) * zoom);
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointY = (int)(pixels_count * zoom);
                        ht_deduction = (int)(((((pixels_count + 2) * 2)) - 1) * zoom);
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointY = (int)(pixels_count * zoom);
                        ht_deduction = (int)((pixels_count * 2) * zoom);
                    }
                }
                #endregion

                else if (parent_name.Contains("MultiMullion"))
                #region Parent is MultiPanel Mullion
                {
                    bounds_PointY = (int)(10 * zoom);
                    ht_deduction = (int)(20 * zoom);
                    if (thisObj_placement == "First")
                    {
                        bounds_PointX = (int)(10 * zoom);
                        wd_deduction = (int)((10 + (pixels_count + 1)) * zoom);
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointX = (int)(pixels_count * zoom);
                        wd_deduction = (int)((((pixels_count + 2) * 2) - 1) * zoom);

                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointX = (int)(pixels_count * zoom);
                        wd_deduction = (int)((pixels_count * 2) * zoom);
                    }
                }
                #endregion

                bounds = new Rectangle(new Point(bounds_PointX, bounds_PointY),
                                       new Size(fpnl.Width - wd_deduction,
                                                fpnl.Height - ht_deduction));
                #endregion

                #region 'thisDrawingPoints_for..' of this obj when the Parent obj has doxtyle.None

                thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                     fpnl.Height,
                                                                                                     "Mullion",
                                                                                                     "First",
                                                                                                     _frameModel.Frame_Type.ToString()); //4th parameter must be the placement of the parent control

                thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                    fpnl.Height,
                                                                                                    "Mullion",
                                                                                                    "Last",
                                                                                                    _frameModel.Frame_Type.ToString()); //4th parameter must be the placement of the parent control
                #endregion

                #endregion


                #region MAIN GRAPHICS ALGORITHM with curve (commented)
                //if (parent_name.Contains("MultiMullion") &&
                //    parent_doxtyle == DockStyle.Fill &&
                //    thisObj_placement == "First")
                //#region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Last")
                //#region Last Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "First")
                //#region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 0; i < corner_points.Length - 5; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Last")
                //#region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 4; i < corner_points.Length - 1; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //#region Pattern (M-T-M)

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Last")
                //#region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height), 
                //                           new Point(pInnerX, pInnerY + pInnerHt));


                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Last")
                //#region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);


                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "First")
                //#region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //#endregion

                //#region Pattern (T-T-M)

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 0; i < corner_points.Length - 5; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 4; i < corner_points.Length - 1; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //#endregion

                //#region Pattern (M-M-M)

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         (thisObj_placement == "First" ||  thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //#endregion

                //#region Pattern (T-M-M)

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Last")
                //#region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Last")
                //#region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "First")
                //#region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //#endregion

                #endregion

                #region MAIN GRAPHICS ALGORITHM without curve

                if (parent_name.Contains("MultiMullion") &&
                    parent_doxtyle == DockStyle.Fill &&
                    thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion


                #region Pattern (M-T-M)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                #endregion

                #region Pattern (T-T-M)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region (Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                #endregion

                #region Pattern (M-M-M)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 3;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                #endregion

                #region Pattern (T-M-M)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));

                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                #endregion

                #endregion
            }

            if (parent_name.Contains("MultiMullion") &&
                parent_doxtyle == DockStyle.None &&
                lvl2_parent_Type == "Transom")
            {
                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Top);
                g.DrawRectangle(Pens.Black, divider_bounds_Top);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Bot);
                g.DrawRectangle(Pens.Black, divider_bounds_Bot);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Left);
                g.DrawRectangle(Pens.Black, divider_bounds_Left);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Right);
                g.DrawRectangle(Pens.Black, divider_bounds_Right);
            }
            else
            {
                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Left);
                g.DrawRectangle(Pens.Black, divider_bounds_Left);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Right);
                g.DrawRectangle(Pens.Black, divider_bounds_Right);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Top);
                g.DrawRectangle(Pens.Black, divider_bounds_Top);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Bot);
                g.DrawRectangle(Pens.Black, divider_bounds_Bot);
            }


            g.FillRectangle(new SolidBrush(Color.MistyRose), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString(_multiPanelModel.MPanel_Name + " (" + _multiPanelModel.MPanel_Divisions + ")", drawFont, new SolidBrush(Color.Black), bounds);

            if (_timer_count != 0 && _timer_count < 8)
            {
                if (_HeightChange)
                {
                    _commonFunctions.Red_Arrow_Lines_forHeight(g, _multiPanelModel);
                }

                if (_WidthChange)
                {
                    _commonFunctions.Red_Arrow_Lines_forWidth(g, _multiPanelModel);
                }
            }
            else if (_timer_count >= 8)
            {
                _tmr.Stop();
                _timer_count = 0;
                _HeightChange = false;
                _WidthChange = false;
            }
        }

        public IMultiPanelMullionUC GetMultiPanel()
        {
            _initialLoad = true;
            _multiPanelMullionUC.ThisBinding(CreateBindingDictionary());
            ((IMultiPanelUC)_multiPanelMullionUC).GetDivEnabler().Checked = _multiPanelModel.MPanel_DividerEnabled;
            return _multiPanelMullionUC;
        }
        
        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                            IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP_parent)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;
            multiMullionUCP._frameImagerUCP = frameImagerUCP;
            multiMullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiMullionUCP._multiMullionImagerUCP = multiMullionImagerUCP;
            multiMullionUCP._multiPanelTransomImagerUCP_parent = multiTransomImagerUCP_parent;

            return multiMullionUCP;
        }

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                            IMultiPanelModel multiPanelModel, 
                                                            IFrameModel frameModel, 
                                                            IMainPresenter mainPresenter, 
                                                            IFrameUCPresenter frameUCP, 
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP, 
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP, 
                                                            IFrameImagerUCPresenter frameImagerUCP, 
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;
            multiMullionUCP._frameImagerUCP = frameImagerUCP;
            multiMullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiMullionUCP._multiMullionImagerUCP = multiMullionImagerUCP;

            return multiMullionUCP;
        }

        private IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                             IMultiPanelModel multiPanelModel,
                                                             IFrameModel frameModel,
                                                             IMainPresenter mainPresenter,
                                                             IFrameUCPresenter frameUCP,
                                                             IMultiPanelMullionUCPresenter multiPanelMullionUCP,
                                                             IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                             IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                             IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                             IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                             IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP_parent)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelMullionUCP = multiPanelMullionUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;
            multiMullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiMullionUCP._multiMullionImagerUCP = multiMullionImagerUCP;
            multiMullionUCP._multiMullionImagerUCP_parent = multiMullionImagerUCP_parent;

            return multiMullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Name", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Width", _multiPanelModel, "MPanel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Height", _multiPanelModel, "MPanel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Placement", new Binding("MPanel_Placement", _multiPanelModel, "MPanel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            //multiPanelBinding.Add("MPanel_Margin", new Binding("Margin", _multiPanelModel, "MPanel_Margin", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt)
        {
            _frmDmRes_Width = frmDimension_numWd;
            _frmDmRes_Height = frmDimension_numHt;
            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
        }

        public void DeletePanel(UserControl obj)
        {
            ((IMultiPanelUC)_multiPanelMullionUC).DeletePanel(obj);
        }

        public void Invalidate_MultiPanelMullionUC()
        {
            ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}