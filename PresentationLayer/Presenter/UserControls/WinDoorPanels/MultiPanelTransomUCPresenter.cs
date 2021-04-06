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

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class MultiPanelTransomUCPresenter : IMultiPanelTransomUCPresenter, IPresenterCommon
    {
        IMultiPanelTransomUC _multiPanelTransomUC;
        private IMultiPanelMullionUCPresenter _multiMullionUCP; //Original Instance
        private IMultiPanelMullionUCPresenter _multiMullionUCP_given; //Given Instance

        private IUnityContainer _unityC;

        private IMultiPanelModel _multiPanelModel;
        private IPanelModel _panelModel;
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
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP_orig;  //Original Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCP;
        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP; //Injected Instance
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP_Given; //Given Instance
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP; //Given Instance
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP_Injected; //Injected Instance
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP_parent; //parent instance of Imager counterpart
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP_parent; //parent instance of Imager counterpart

        private IDividerServices _divServices;
        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;

        bool _initialLoad;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();
        private CommonFunctions _commonFunctions = new CommonFunctions();

        Timer _tmr = new Timer();

        public MultiPanelTransomUCPresenter(IMultiPanelTransomUC multiPanelTransomUC,
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
                                            ITransomUCPresenter transomUCP,
                                            IMullionUCPresenter mullionUCP,
                                            IDividerServices divServices,
                                            IMultiPanelMullionUCPresenter multiMullionUCP,
                                            IMultiPanelPropertiesUCPresenter multiPropUCP_orig,
                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                            IMullionImagerUCPresenter mullionImagerUCP,
                                            ITransomImagerUCPresenter transomImagerUCP,
                                            IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP_Injected)
        {
            _multiPanelTransomUC = multiPanelTransomUC;
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
            _awningImagerUCP = awningImagerUCP;
            _slidingImagerUCP = slidingImagerUCP;
            _transomUCP = transomUCP;
            _mullionUCP = mullionUCP;
            _divServices = divServices;
            _multiMullionUCP = multiMullionUCP;
            _multiPropUCP_orig = multiPropUCP_orig;
            _multiMullionImagerUCP = multiMullionImagerUCP;
            _mullionImagerUCP = mullionImagerUCP;
            _transomImagerUCP = transomImagerUCP;
            _multiPanelTransomImagerUCP_Injected = multiPanelTransomImagerUCP_Injected;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelTransomUC.flpMulltiPaintEventRaised += _multiPanelTransomUC_flpMulltiPaintEventRaised;
            _multiPanelTransomUC.flpMultiDragDropEventRaised += _multiPanelTransomUC_flpMultiDragDropEventRaised;
            _multiPanelTransomUC.flpMultiMouseEnterEventRaised += _multiPanelTransomUC_flpMultiMouseEnterEventRaised;
            _multiPanelTransomUC.flpMultiMouseLeaveEventRaised += _multiPanelTransomUC_flpMultiMouseLeaveEventRaised;
            _multiPanelTransomUC.divCountClickedEventRaised += _multiPanelTransomUC_divCountClickedEventRaised;
            _multiPanelTransomUC.deleteClickedEventRaised += _multiPanelTransomUC_deleteClickedEventRaised;
            _multiPanelTransomUC.multiMullionSizeChangedEventRaised += _multiPanelTransomUC_multiMullionSizeChangedEventRaised;
            _multiPanelTransomUC.dividerEnabledCheckChangedEventRaised += _multiPanelTransomUC_dividerEnabledCheckChangedEventRaised;
            _tmr.Tick += _tmr_Tick;
        }

        int _timer_count;

        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                _multiPanelTransomUC.InvalidateFlp();
            }
        }

        private void _multiPanelTransomUC_dividerEnabledCheckChangedEventRaised(object sender, EventArgs e)
        {
            _multiPanelModel.MPanel_DividerEnabled = ((ToolStripMenuItem)sender).Checked;
        }

        int prev_Width = 0,
            prev_Height = 0;
        private void _multiPanelTransomUC_multiMullionSizeChangedEventRaised(object sender, EventArgs e)
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
                        _multiPanelModel.MPanel_Width = thisWd;
                        _WidthChange = true;
                    }
                    if (thisHt != mpnlModelHt || prev_Height != mpnlModelHt)
                    {
                        _multiPanelModel.MPanel_Height = thisHt;
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

        private int divSize = 0,
                    divID = 0;
        private void _multiPanelTransomUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int panelID = _mainPresenter.GetPanelCount() + 1,
                multiID = _mainPresenter.GetMultiPanelCount() + 1;

                divID = _mainPresenter.GetDividerCount() + 1;

            int multiPanel_boundsWD = fpnl.Width - 20,
                multiPanel_boundsHT = fpnl.Height - 20,
                totalPanelCount = _multiPanelModel.MPanel_Divisions + 1;

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }

            if (data.Contains("Multi-Panel")) //if Multi-Panel
            {
                int suggest_Wd = fpnl.Width,
                    suggest_HT = ((fpnl.Height - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);

                _frmDimensionPresenter.SetPresenters(this);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.AddPanelIntoMultiPanel;
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.SetValues(suggest_Wd, suggest_HT);
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                bool frmResult = _frmDimensionPresenter.GetfrmResult();

                if (!frmResult)
                {
                    FlowDirection flow = FlowDirection.LeftToRight;
                    if (data.Contains("Transom"))
                    {
                        flow = FlowDirection.TopDown;
                    }
                    
                    IMultiPanelModel mPanelModel = _multipanelServices.AddMultiPanelModel(_frmDmRes_Width,
                                                                                          _frmDmRes_Height,
                                                                                          fpnl,
                                                                                          (UserControl)_frameUCP.GetFrameUC(),
                                                                                          true,
                                                                                          flow,
                                                                                          multiID,
                                                                                          DockStyle.None,
                                                                                          _multiPanelModel.GetNextIndex(),
                                                                                          _multiPanelModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom);
                    _frameModel.Lst_MultiPanel.Add(mPanelModel);
                    _multiPanelModel.MPanelLst_MultiPanel.Add(mPanelModel);
                    _multiPanelModel.Reload_MultiPanelMargin();

                    IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP_orig.GetNewInstance(_unityC, mPanelModel, _mainPresenter);
                    _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)multiPropUCP.GetMultiPanelPropertiesUC());

                    _frameModel.FrameProp_Height += (129 + 3); // +3 for MultiPanelProperties' Margin
                    _multiPanelModel.MPanelProp_Height += (129 + 3);

                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        _frameModel.Frame_Padding_int = new Padding(16);
                    }
                    else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        _frameModel.Frame_Padding_int = new Padding(23);
                    }

                    if (data.Contains("Mullion"))
                    {

                        IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                         mPanelModel,
                                                                                                                         _frameModel,
                                                                                                                         _multiPanelTransomImagerUCP);
                        IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)multiMullionImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();

                        IMultiPanelMullionUCPresenter multiUCP = _multiMullionUCP.GetNewInstance(_unityC,
                                                                                                 mPanelModel,
                                                                                                 _frameModel,
                                                                                                 _mainPresenter,
                                                                                                 _frameUCP,
                                                                                                 this,
                                                                                                 multiPropUCP,
                                                                                                 _frameImagerUCP,
                                                                                                 _basePlatformImagerUCP,
                                                                                                 multiMullionImagerUCP,
                                                                                                 _multiPanelTransomImagerUCP);
                        IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiUCP.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC , _frameModel.Frame_Type.ToString());

                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
                        {
                            IDividerModel divModel = _divServices.AddDividerModel(fpnl.Width,
                                                                                  divSize,
                                                                                  fpnl,
                                                                                  //(UserControl)_frameUCP.GetFrameUC(),
                                                                                  DividerModel.DividerType.Transom,
                                                                                  true,
                                                                                  divID,
                                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                                  _frameModel.Frame_Type.ToString());

                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel,
                                                                                        _mainPresenter);
                            ITransomUC transomUC = transomUCP.GetTransom();
                            fpnl.Controls.Add((UserControl)transomUC);
                            transomUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());

                            ITransomImagerUCPresenter transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                                                          divModel,
                                                                                                          _multiPanelModel,
                                                                                                          _frameModel,
                                                                                                          _multiPanelTransomImagerUCP,
                                                                                                          transomUC);
                            ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                            _multiPanelTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                    }
                    else if (data.Contains("Transom"))
                    {
                        IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiPanelTransomImagerUCP_Injected.GetNewInstance(_unityC,
                                                                                                                                        mPanelModel,
                                                                                                                                        _frameModel,
                                                                                                                                        _multiPanelTransomImagerUCP);
                        IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();

                        IMultiPanelTransomUCPresenter multiTransom = GetNewInstance(_unityC,
                                                                                    mPanelModel,
                                                                                    _frameModel,
                                                                                    _mainPresenter,
                                                                                    _frameUCP,
                                                                                    multiPropUCP,
                                                                                    _frameImagerUCP,
                                                                                    _basePlatformImagerUCP,
                                                                                    multiTransomImagerUCP,
                                                                                    _multiPanelTransomImagerUCP);
                        IMultiPanelTransomUC multiUC = multiTransom.GetMultiPanel();
                        fpnl.Controls.Add((UserControl)multiUC);
                        multiTransom.SetInitialLoadFalse();
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC, _frameModel.Frame_Type.ToString());

                        if (mPanelModel.MPanel_Placement == "Last")
                        {
                            _multiPanelModel.Fit_MyControls();
                        }
                        else if (mPanelModel.MPanel_Placement != "Last")
                        {
                            IDividerModel divModel = _divServices.AddDividerModel(fpnl.Width,
                                                                                  divSize,
                                                                                  fpnl,
                                                                                  //(UserControl)_frameUCP.GetFrameUC(),
                                                                                  DividerModel.DividerType.Transom,
                                                                                  true,
                                                                                  divID,
                                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                                  _frameModel.Frame_Type.ToString());

                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel,
                                                                                        _mainPresenter);
                            ITransomUC transomUC = transomUCP.GetTransom();
                            fpnl.Controls.Add((UserControl)transomUC);
                            transomUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());

                            ITransomImagerUCPresenter transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                                                          divModel,
                                                                                                          _multiPanelModel,
                                                                                                          _frameModel,
                                                                                                          _multiPanelTransomImagerUCP,
                                                                                                          transomUC);
                            ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                            _multiPanelTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                    }
                }
            }
            else
            {
                int suggest_Wd = multiPanel_boundsWD,
                    suggest_HT = 0;

                if (_multiPanelModel.MPanel_DividerEnabled)
                {
                    suggest_HT = ((multiPanel_boundsHT - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);
                }
                else if (!_multiPanelModel.MPanel_DividerEnabled)
                {
                    suggest_HT = multiPanel_boundsHT / totalPanelCount;
                }

                if (_multiPanelModel.MPanel_ParentModel != null)
                {
                    suggest_Wd = multiPanel_boundsWD + 2;
                }

                _frmDimensionPresenter.SetPresenters(this);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.AddPanelIntoMultiPanel;
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.SetValues(suggest_Wd, suggest_HT);
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                bool frmResult = _frmDimensionPresenter.GetfrmResult();

                IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);

                if (!frmResult)
                {
                    _panelModel = _panelServices.AddPanelModel(_frmDmRes_Width,
                                                               _frmDmRes_Height,
                                                               fpnl,
                                                               (UserControl)_frameUCP.GetFrameUC(),
                                                               (UserControl)framePropUC,
                                                               (UserControl)_multiPanelTransomUC,
                                                               data,
                                                               true,
                                                               _frameModel.Frame_Zoom,
                                                               panelID,
                                                               _frameModel.FrameImageRenderer_Zoom,
                                                               _multiPanelModel.GetNextIndex(),
                                                               DockStyle.None);
                    _frameModel.Lst_Panel.Add(_panelModel);
                    _multiPanelModel.MPanelLst_Panel.Add(_panelModel);
                    _multiPanelModel.Reload_PanelMargin();

                    IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());

                    _frameModel.FrameProp_Height += 148;
                    _multiPanelModel.MPanelProp_Height += 148;

                    if (data == "Fixed Panel")
                    {
                        IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC,
                                                                                   _panelModel,
                                                                                   _frameModel,
                                                                                   _mainPresenter,
                                                                                   _multiPanelModel,
                                                                                   this,
                                                                                   _multiPanelTransomImagerUCP);
                        IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                        fpnl.Controls.Add((UserControl)fixedUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)fixedUC, _frameModel.Frame_Type.ToString());
                        fixedUCP.SetInitialLoadFalse();

                        IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC,
                                                                                                     _panelModel,
                                                                                                     _multiPanelTransomImagerUCP);
                        IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)fixedImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();
                    }
                    else if (data == "Casement Panel")
                    {
                        ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC,
                                                                                            _panelModel,
                                                                                            _frameModel,
                                                                                            _mainPresenter,
                                                                                            _multiPanelModel,
                                                                                            this,
                                                                                            _multiPanelTransomImagerUCP);
                        ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                        fpnl.Controls.Add((UserControl)casementUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)casementUC, _frameModel.Frame_Type.ToString());
                        casementUCP.SetInitialLoadFalse();

                        ICasementPanelImagerUCPresenter casementImagerUCP = _casementImagerUCP.GetNewInstance(_unityC, 
                                                                                                              _panelModel,
                                                                                                              _multiPanelTransomImagerUCP);
                        ICasementPanelImagerUC casementImagerUC = casementImagerUCP.GetCasementPanelImagerUC();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)casementImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();
                    }
                    else if (data == "Awning Panel")
                    {
                        IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC,
                                                                                      _panelModel,
                                                                                      _frameModel,
                                                                                      _mainPresenter,
                                                                                      _multiPanelModel,
                                                                                      this,
                                                                                      _multiPanelTransomImagerUCP);
                        IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                        fpnl.Controls.Add((UserControl)awningUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)awningUC, _frameModel.Frame_Type.ToString());
                        awningUCP.SetInitialLoadFalse();

                        IAwningPanelImagerUCPresenter awningImagerUCP = _awningImagerUCP.GetNewInstance(_unityC, 
                                                                                                        _panelModel, 
                                                                                                        _multiPanelTransomImagerUCP);
                        IAwningPanelImagerUC awningImagerUC = awningImagerUCP.GetAwningPanelUC();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)awningImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();
                    }
                    else if (data == "Sliding Panel")
                    {
                        ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC,
                                                                                         _panelModel,
                                                                                         _frameModel,
                                                                                         _mainPresenter,
                                                                                         _multiPanelModel,
                                                                                         this,
                                                                                         _multiPanelTransomImagerUCP);
                        ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                        fpnl.Controls.Add((UserControl)slidingUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)slidingUC, _frameModel.Frame_Type.ToString());
                        slidingUCP.SetInitialLoadFalse();

                        ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC,
                                                                                                           _panelModel,
                                                                                                           _multiPanelTransomImagerUCP);
                        ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)slidingImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();
                    }

                    if (_panelModel.Panel_Placement == "Last")
                    {
                        _multiPanelModel.Fit_MyControls();
                    }
                    else if (_multiPanelModel.MPanel_DividerEnabled && _panelModel.Panel_Placement != "Last")
                    {
                        IDividerModel divModel = _divServices.AddDividerModel(fpnl.Width,
                                                                              divSize,
                                                                              fpnl,
                                                                              //(UserControl)_frameUCP.GetFrameUC(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());

                        _frameModel.Lst_Divider.Add(divModel);
                        _multiPanelModel.MPanelLst_Divider.Add(divModel);

                        ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                    divModel,
                                                                                    _multiPanelModel,
                                                                                    this,
                                                                                    _frameModel,
                                                                                    _mainPresenter);
                        ITransomUC transomUC = transomUCP.GetTransom();
                        fpnl.Controls.Add((UserControl)transomUC);
                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                        transomUCP.SetInitialLoadFalse();

                        ITransomImagerUCPresenter transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                                                      divModel,
                                                                                                      _multiPanelModel,
                                                                                                      _frameModel,
                                                                                                      _multiPanelTransomImagerUCP,
                                                                                                      transomUC);
                        ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                        _multiPanelTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                        _basePlatformImagerUCP.InvalidateBasePlatform();
                    }
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
        }

        private void _multiPanelTransomUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete TransomUC
            if (_multiPanelModel.MPanel_ParentModel != null &&
                _multiPanelModel.MPanel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.IndexOf((UserControl)_multiPanelTransomUC);

                Control divUC = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx + 1];
                _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Remove((UserControl)divUC);
                _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)divUC);

                IDividerModel div = _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                div.Div_Visible = false;
            }
            #endregion

            #region Delete MultiPanel Transom
            FlowLayoutPanel innerFlp = (FlowLayoutPanel)((UserControl)_multiPanelTransomUC).Controls[0];
            Control parent_ctrl = ((UserControl)_multiPanelTransomUC).Parent;

            var multiPanels = _mpnlCommons.GetAll(innerFlp, "Multi", "flp");
            foreach (var mpnl in multiPanels)
            {
                _multiPanelModel.MPanelProp_Height -= (129 + 3);
                _frameModel.FrameProp_Height -= (129 + 3); // +3 for MultiPanelProperties' Margin
            }

            var panels = _mpnlCommons.GetAll(innerFlp, "PanelUC");
            foreach (var pnl in panels)
            {
                _multiPanelModel.MPanelProp_Height -= 148;
                _frameModel.FrameProp_Height -= 148;
            }

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.DeleteControl_MPanelLstObjects((UserControl)_multiPanelTransomUC, 
                                                                                    _frameModel.Frame_Type.ToString(),
                                                                                    _multiPanelModel.MPanel_Placement);
            }

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                _frameModel.Frame_Type = FrameModel.Frame_Padding.Window;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                _frameModel.Frame_Type = FrameModel.Frame_Padding.Door;
            }

            foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel.Where(pnl => pnl.Panel_Visibility == true))
            {
                pnl.Panel_Visibility = false;
            }
            foreach (IDividerModel div in _multiPanelModel.MPanelLst_Divider.Where(div => div.Div_Visible == true))
            {
                div.Div_Visible = false;
            }
            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel.Where(mpnl => mpnl.MPanel_Visibility == true))
            {
                mpnl.MPanel_Visibility = false;
            }

            _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)_multiPanelTransomUC);

            if (_multiPanelModel.MPanel_Parent != null)
            {
                _multiPanelModel.MPanelProp_Height -= (129 + 3);
                _frameModel.FrameProp_Height -= (129 + 3); // +3 for MultiPanelProperties' Margin;
            }

            _multiPanelModel.MPanel_Visibility = false;

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
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
                                                        _mainPresenter.GetDividerCount() + 1,
                                                        _multiPanelModel,
                                                        null,
                                                        this,
                                                        null,
                                                        _multiPanelMullionImagerUCP_parent,
                                                        _multiPanelTransomImagerUCP_parent);
            }
            
            if (parent_ctrl.Name.Contains("flp_Multi"))
            {
                foreach (Control ctrl in parent_ctrl.Controls)
                {
                    ctrl.Invalidate();
                }
            }

            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

            #endregion
        }

        private void _multiPanelTransomUC_divCountClickedEventRaised(object sender, EventArgs e)
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

        private void _multiPanelTransomUC_flpMultiMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _multiPanelTransomUC.InvalidateFlp();
        }

        private void _multiPanelTransomUC_flpMultiMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _multiPanelTransomUC.InvalidateFlp();
        }

        Color color = Color.Black;
        bool _HeightChange = false,
             _WidthChange = false;
        private void _multiPanelTransomUC_flpMulltiPaintEventRaised(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = 10,
                pInnerY = 10,
                pInnerWd = fpnl.ClientRectangle.Width - 20,
                pInnerHt = fpnl.ClientRectangle.Height - 20;

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


            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;

            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC)) //if inside Frame
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                bounds = new Rectangle(new Point(10, 10),
                                       new Size(fpnl.ClientRectangle.Width - 20,
                                                fpnl.ClientRectangle.Height - 20));
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                string parent_name = _multiPanelModel.MPanel_Parent.Name,
                       lvl2_parent_Type = "",
                       thisObj_placement = _multiPanelModel.MPanel_Placement,
                       parentObj_placement = _multiPanelModel.MPanel_ParentModel.MPanel_Placement;
                DockStyle parent_doxtyle = _multiPanelModel.MPanel_ParentModel.MPanel_Dock;
                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1,
                    parent_mpnl_childObj_count = parent_mpnl.GetCount_MPanelLst_Object(),
                    indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

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
                    wd_deduction = 20;
                    bounds_PointX = 10;
                    if (thisObj_placement == "First")
                    {
                        bounds_PointY = 10;
                        ht_deduction = (10 + (pixels_count + 1));
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointY = pixels_count + 2;
                        ht_deduction = (((pixels_count + 2) * 2)) - 1;
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointY = pixels_count + 2;
                        ht_deduction = (pixels_count + 2) * 2;
                        if (parent_doxtyle == DockStyle.None)
                        {
                            bounds_PointY = (pixels_count + 2 == 10) ? pixels_count + 2 : 10;
                            ht_deduction = 10 + (pixels_count + 1);
                        }
                    }
                }
                #endregion

                else if (parent_name.Contains("MultiMullion"))
                #region Parent is MultiPanel Mullion
                {
                    bounds_PointY = 10;
                    ht_deduction = 20;
                    if (thisObj_placement == "First")
                    {
                        bounds_PointX = 10;
                        wd_deduction = (10 + (pixels_count + 1));
                    }
                    else if (thisObj_placement == "Last")
                    {
                        bounds_PointX = pixels_count + 2;
                        wd_deduction = ((pixels_count + 2) * 2) - 1;

                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        bounds_PointX = pixels_count + 2;
                        wd_deduction = (pixels_count + 2) * 2;
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

                #region MAIN GRAPHICS ALGORITHM

                if (parent_name.Contains("MultiTransom") &&
                    parent_doxtyle == DockStyle.Fill &&
                    thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
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

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a MAIN PLATFORM (MultiTransom)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);


                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                #region Pattern (M-T-T)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],
                                                       new Point(thisDrawingPoints_forMullion_RightSide[0][1].X,
                                                                thisDrawingPoints_forMullion_RightSide[0][1].Y + 20));
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height), new Point(pInnerX, pInnerY + pInnerHt));

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);


                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],
                                                       new Point(thisDrawingPoints_forMullion_RightSide[0][1].X,
                                                                 thisDrawingPoints_forMullion_RightSide[0][1].Y + 20));
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
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

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
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

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0],
                                                      new Point(thisDrawingPoints_forMullion_LeftSide[0][1].X,
                                                                thisDrawingPoints_forMullion_LeftSide[0][1].Y + 20));
                    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                #endregion

                #region Pattern (T-T-T)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));

                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between" || thisObj_placement == "Last"))
                #region (First or Somewhere in Between or Last) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                #region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in MAIN PLATFORM (MultiMullion)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                }
                #endregion

                #endregion

                #region Pattern (M-M-T)

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

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (Somewhere in Between && Last) in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                #region (Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion
                
                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
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

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                #endregion

                #region Pattern (T-M-T)
                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));

                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0],thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
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

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    thisDrawingPoints_bot[1][0].X += 20; //Add 20 units
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    thisDrawingPoints_top[1][0].X += 20;
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);


                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);


                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20; //add 20 units
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                    thisDrawingPoints_bot[1][0].X += 20;
                    thisDrawingPoints_bot[1][1].X += 20;
                    thisDrawingPoints_bot[1][2].X += 20;
                    gpath.AddCurve(thisDrawingPoints_bot[1]);
                    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                    thisDrawingPoints_bot[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_bot[3][1].X -= 20;
                    thisDrawingPoints_bot[3][2].X -= 20;
                    gpath.AddCurve(thisDrawingPoints_bot[3]);

                    g.DrawPath(pen, gpath);
                    g.FillPath(Brushes.PowderBlue, gpath);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

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

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20; //add 20 units
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
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

                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                    thisDrawingPoints_top[1][0].X += 20; //add 20 units
                    thisDrawingPoints_top[1][1].X += 20;
                    thisDrawingPoints_top[1][2].X += 20;
                    gpath2.AddCurve(thisDrawingPoints_top[1]);
                    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                    thisDrawingPoints_top[3][0].X -= 20; //deduct 20 units
                    thisDrawingPoints_top[3][1].X -= 20;
                    thisDrawingPoints_top[3][2].X -= 20;
                    gpath2.AddCurve(thisDrawingPoints_top[3]);

                    g.DrawPath(pen, gpath2);
                    g.FillPath(Brushes.PowderBlue, gpath2);

                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                    g.DrawPath(pen, gpath_forMullion_LeftSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                    g.DrawPath(pen, gpath_forMullion_RightSide);
                    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                }
                #endregion

                #endregion

                #endregion
            }

            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

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

        public IMultiPanelTransomUC GetMultiPanel()
        {
            _initialLoad = true;
            _multiPanelTransomUC.ThisBinding(CreateBindingDictionary());
            _multiPanelTransomUC.GetDivEnabler().Checked = _multiPanelModel.MPanel_DividerEnabled;

            return _multiPanelTransomUC;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                            IMultiPanelModel multiPanelModel, 
                                                            IFrameModel frameModel, 
                                                            IMainPresenter mainPresenter, 
                                                            IFrameUCPresenter frameUCP, 
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP, 
                                                            IFrameImagerUCPresenter frameImagerUCP, 
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP, 
                                                            IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;
            multiTransomUCP._frameImagerUCP = frameImagerUCP;
            multiTransomUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiTransomUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return multiTransomUCP;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP,
                                                            IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP_parent)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;
            multiTransomUCP._frameImagerUCP = frameImagerUCP;
            multiTransomUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiTransomUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;
            multiTransomUCP._multiPanelMullionImagerUCP_parent = multiPanelMullionImagerUCP_parent;

            return multiTransomUCP;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP,
                                                            IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP_parent)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;
            multiTransomUCP._frameImagerUCP = frameImagerUCP;
            multiTransomUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiTransomUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;
            multiTransomUCP._multiPanelTransomImagerUCP_parent = multiPanelTransomImagerUCP_parent;

            return multiTransomUCP;
        }

        public IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelMullionUCPresenter multiPanelMullionUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiMullionUCP_given = multiPanelMullionUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;
            multiTransomUCP._frameImagerUCP = frameImagerUCP;
            multiTransomUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiTransomUCP._multiMullionImagerUCP_Given = multiMullionImagerUCP;

            return multiTransomUCP;
        }

        private IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>()
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>();
            MultiPanelTransomUCPresenter multiTransomUCP = unityC.Resolve<MultiPanelTransomUCPresenter>();
            multiTransomUCP._unityC = unityC;
            multiTransomUCP._multiPanelModel = multiPanelModel;
            multiTransomUCP._frameModel = frameModel;
            multiTransomUCP._mainPresenter = mainPresenter;
            multiTransomUCP._frameUCP = frameUCP;
            multiTransomUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiTransomUCP._multiPropUCP2_given = multiPropUCP;
            multiTransomUCP._frameImagerUCP = frameImagerUCP;
            multiTransomUCP._basePlatformImagerUCP = basePlatformImagerUCP;

            return multiTransomUCP;
        }

        public void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt)
        {
            _frmDmRes_Width = frmDimension_numWd;
            _frmDmRes_Height = frmDimension_numHt;
            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
        }

        public void DeletePanel(UserControl obj)
        {
            _multiPanelTransomUC.DeletePanel(obj);
            if (obj.Name.Contains("PanelUC"))
            {
                _multiPanelModel.MPanelProp_Height -= 148;
            }
        }

        public void Invalidate_MultiPanelMullionUC()
        {
            _multiPanelTransomUC.InvalidateFlp();
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Name", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Width", _multiPanelModel, "MPanel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Height", _multiPanelModel, "MPanel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
