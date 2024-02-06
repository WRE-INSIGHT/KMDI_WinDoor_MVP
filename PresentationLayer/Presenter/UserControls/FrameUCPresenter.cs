using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using ModelLayer.Variables;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unity;
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
        private IUserModel _userModel;
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
        private ITiltNTurnPanelUCPresenter _tiltNTurnUCP;
        private ILouverPanelUCPresenter _louverPanelUCP;
        private ConstantVariables constants = new ConstantVariables();

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
                                ITiltNTurnPanelUCPresenter tiltNTurnUCP,
                                ILouverPanelUCPresenter louverPanelUCP,
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
            _tiltNTurnUCP = tiltNTurnUCP;
            _louverPanelUCP = louverPanelUCP;
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
            _frameModel.Frame_BotFrameEnable = true;
        }

        private void _frameUC_frameControlAddedEventRaised(object sender, ControlEventArgs e)
        {
            //UserControl pfr = (UserControl)sender;

            //if (pfr.Controls[0] is IMultiPanelUC)
            //{
            try
            {
                _framePropertiesUCP.SetFrameTypeRadioBtnEnabled(false);
                _frameModel.Frame_BotFrameEnable = false;
            }
            catch (Exception)
            {

            }

            //}
            //else if (pfr.Controls[0] is IPanelUC)
            //{
            //    _framePropertiesUCP.SetFrameTypeRadioBtnEnabled(true);
            //}
        }
        
        private void _frameUC_frameDragDropEventRaised(object sender, DragEventArgs e)
        {
            _mainPresenter.ForceRestartAndLoadFile();//chksrobj
            UserControl frame = (UserControl)sender; //Control na babagsakan
            List<object> lst_data = e.Data.GetData(e.Data.GetFormats()[0]) as List<object>;

            string data = lst_data[0].ToString();
            int divCount = Convert.ToInt32(lst_data[1]);

            int bot_deduct = (int)(_frameModel.Frame_Type - 10);
            if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 || _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052)
            {
                bot_deduct = (int)(_frameModel.Frame_Type - 10);
            }
            else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 || _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
            {
                bot_deduct = 26 - 10;
            }
            else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None || _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 || _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66)
            {
                bot_deduct = 0;
            }

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
             ht = _frameModel.Frame_Height - ((int)(_frameModel.Frame_Type - 10) + bot_deduct);
            

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
                                                                          0,
                                                                          _frameModel.Frame_Height,
                                                                          0,
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
                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                          "",
                                                                          divCount);

                _multipanelModel.Set_DimensionToBind_using_FrameDimensions();
                _multipanelModel.Imager_Set_DimensionToBind_using_FrameDimensions();
                _frameModel.Lst_MultiPanel.Add(_multipanelModel);

                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP.GetNewInstance(_unityC, _multipanelModel, _mainPresenter);
                UserControl multiPropUC = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                multiPropUC.Dock = DockStyle.Top;
                framePropUC.GetFramePropertiesPNL().Controls.Add(multiPropUC);
                _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");

                if (data.Contains("Mullion"))
                {
                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                      _multipanelModel,
                                                                                                                      _frameModel,
                                                                                                                      _frameImagerUCP);
                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                    //_frameImagerUCP.AddControl((UserControl)multiMullionImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();

                    IMultiPanelMullionUCPresenter multiUCP = _multiUCP.GetNewInstance(_unityC,
                                                                                      _userModel,
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
                }
                else if (data.Contains("Transom"))
                {
                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                      _multipanelModel,
                                                                                                                      _frameModel,
                                                                                                                      _frameImagerUCP);
                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                    //_frameImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                    _basePlatformImagerUCP.InvalidateBasePlatform();
                    IMultiPanelTransomUCPresenter multiTransomUCP = _multiTransomUCP.GetNewInstance(_unityC,
                                                                                                    _userModel,
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

                Rotoswing_HandleArtNo handleArtNo = null;

                Foil_Color inside_color = _frameModel.Frame_WindoorModel.WD_InsideColor;



                if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Havana ||
                    inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Mahogany)
                {
                    handleArtNo = Rotoswing_HandleArtNo._RSC833307;
                }
                else if (inside_color == Foil_Color._CharcoalGray || inside_color == Foil_Color._FossilGray ||
                         inside_color == Foil_Color._BeechOak || inside_color == Foil_Color._DriftWood ||
                         inside_color == Foil_Color._Graphite || inside_color == Foil_Color._JetBlack ||
                         inside_color == Foil_Color._ChestnutOak || inside_color == Foil_Color._WashedOak ||
                         inside_color == Foil_Color._GreyOak || inside_color == Foil_Color._Cacao)
                {
                    handleArtNo = Rotoswing_HandleArtNo._RSC773452;
                }
                  

                _frameModel.SetDeductFramePadding(false, false);

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
                                                           0,
                                                           _frameModel.Frame_Height,
                                                           0,
                                                           GlazingBead_ArticleNo._2452,
                                                           GlassFilm_Types._None,
                                                           SashProfile_ArticleNo._7581,
                                                           SashReinf_ArticleNo._R675,
                                                           GlassType._Single,
                                                           Espagnolette_ArticleNo._None,
                                                           Striker_ArticleNo._M89ANTA,
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
                                                           handleArtNo,
                                                           GeorgianBar_ArticleNo._None,
                                                           OverlapSash._None,
                                                           0,
                                                           0,
                                                           false,
                                                           _mainPresenter.GetPanelCount(),
                                                           _mainPresenter.GetPanelGlassID());
                _frameModel.Lst_Panel.Add(_panelModel);

                _panelModel.Imager_SetDimensionsToBind_FrameParent();

                IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                UserControl panelPropUC = (UserControl)panelPropUCP.GetPanelPropertiesUC();
                panelPropUC.Dock = DockStyle.Top;
                framePropUC.GetFramePropertiesPNL().Controls.Add(panelPropUC);

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

                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Casement Panel")
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

                    ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC,
                                                                                        _panelModel,
                                                                                        _frameModel,
                                                                                        _mainPresenter,
                                                                                        this);
                    ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                    frame.Controls.Add((UserControl)casementUC);

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

                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Sliding Panel")
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

                    ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC,
                                                                                     _panelModel,
                                                                                     _frameModel,
                                                                                     _mainPresenter,
                                                                                     this);
                    ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                    frame.Controls.Add((UserControl)slidingUC);

                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "TiltNTurn Panel")
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

                    ITiltNTurnPanelUCPresenter tiltNTurnUCP = _tiltNTurnUCP.GetNewInstance(_unityC,
                                                                                           _panelModel,
                                                                                           _frameModel,
                                                                                           _mainPresenter,
                                                                                           this);
                    ITiltNTurnPanelUC tiltnTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                    frame.Controls.Add((UserControl)tiltnTurnUC);

                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
                else if (data == "Louver Panel")
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addSash");


                    _panelModel.AdjustPropertyPanelHeight("addGlass");

                    //_frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    //_frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    //_frameModel.AdjustPropertyPanelHeight("Panel", "addLouverBlades");
                    //_frameModel.AdjustPropertyPanelHeight("Panel", "addLouverGallerySetArtNo");
                    //_frameModel.AdjustPropertyPanelHeight("Panel", "addLouverGallery");
                    //_frameModel.AdjustPropertyPanelHeight("Panel", "addLouverGallerySet");



                    //_panelModel.AdjustPropertyPanelHeight("addGlass");
                    //_panelModel.AdjustPropertyPanelHeight("addLouverBlades");
                    //_panelModel.AdjustPropertyPanelHeight("addLouverGallerySetArtNo");
                    //_panelModel.AdjustPropertyPanelHeight("addLouverGallery");
                    //_panelModel.AdjustPropertyPanelHeight("addLouverGallerySet");



                    ILouverPanelUCPresenter louverPanelUCP = _louverPanelUCP.GetNewInstance(_unityC,
                                                                                            _panelModel,
                                                                                            _frameModel,
                                                                                            _mainPresenter,
                                                                                            this);
                    ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                    frame.Controls.Add((UserControl)louverPanelUC);

                    _basePlatformImagerUCP.InvalidateBasePlatform();
                }
            }
            _mainPresenter.SetChangesMark();
            _mainPresenter.Run_GetListOfMaterials_SpecificItem();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.itemDescription();
            _mainPresenter.qoutationModel_MainPresenter.BOMandItemlistStatus = "BOM";
            _mainPresenter.qoutationModel_MainPresenter.ItemCostingPriceAndPoints();
            //_mainPresenter.GetMainView().GetCurrentPrice().Value = _mainPresenter.qoutationModel_MainPresenter.CurrentPrice;
            _mainPresenter.GetMainView().GetCurrentPrice().Value = _mainPresenter.windoorModel_MainPresenter.WD_currentPrice;
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
            if (MessageBox.Show("Are you sure you want to DELETE " + _frameModel.Frame_Name + "?",
                                "Deletion",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteFrame();
                _mainPresenter.SetChangesMark();
                _mainPresenter.itemDescription();
                _mainPresenter.GetCurrentPrice();
            }
        }
        private UserControl frameUC;
        private void OnFrameMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                color = Color.Blue;
                _frameUC.InvalidateThis();
                _frameCmenu.Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            }
            else
            {

                try
                {
                    frameUC = (UserControl)sender;
                    Console.WriteLine(frameUC.Size.Width);
                    IWindoorModel wdm = _frameModel.Frame_WindoorModel;
                    int propertyHeight = 0;
                    int framePropertyHeight = 0;
                    int concretePropertyHeight = 0;
                    int mpnlPropertyHeight = 0;
                    int pnlPropertyHeight = 0;
                    int divPropertyHeight = 0;
                    foreach (Control wndrObject in wdm.lst_objects)
                    {
                        if (wndrObject.Name.Contains("Frame"))
                        {
                            #region FrameModel
                            foreach (FrameModel frm in wdm.lst_frame)
                            {
                                if (frm.Frame_Name == wndrObject.Name)
                                {
                                    if (frm.Frame_Name == wndrObject.Name)
                                    {
                                        if (frm.Frame_Name == frameUC.Name)
                                        {
                                            _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight;
                                            return;

                                        }
                                        else
                                        {
                                            framePropertyHeight += constants.frame_propertyHeight_default;
                                            if (_frameModel.Frame_BotFrameVisible == true)
                                            {
                                                framePropertyHeight += constants.frame_botframeproperty_PanelHeight;
                                            }
                                            if (_frameModel.Frame_SlidingRailsQtyVisibility == true)
                                            {
                                                framePropertyHeight += constants.frame_SlidingRailsQtyproperty_PanelHeight;
                                            }
                                            if (_frameModel.Frame_ConnectionTypeVisibility == true && _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                                            {
                                                framePropertyHeight += constants.frame_ConnectionTypeproperty_PanelHeight;
                                            }
                                        }
                                    }
                                    #region  Frame Panel
                                    foreach (PanelModel pnl in frm.Lst_Panel)
                                    {
                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                    }
                                    #endregion
                                    #region 2nd Level MultiPanel
                                    foreach (MultiPanelModel mpnl in frm.Lst_MultiPanel)
                                    {
                                        mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                        foreach (Control ctrl in mpnl.MPanelLst_Objects)
                                        {
                                            if (ctrl.Name.Contains("PanelUC"))
                                            {
                                                #region 2nd Level MultiPanel Panel
                                                foreach (PanelModel pnl in mpnl.MPanelLst_Panel)
                                                {
                                                    if (ctrl.Name == pnl.Panel_Name)
                                                    {
                                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                        break;
                                                    }
                                                }
                                                #endregion

                                            }
                                            else if (ctrl.Name.Contains("MullionUC") || ctrl.Name.Contains("TransomUC"))
                                            {
                                                #region 2nd Level MultiPanel Divider
                                                foreach (DividerModel div in mpnl.MPanelLst_Divider)
                                                {
                                                    if (ctrl.Name == div.Div_Name)
                                                    {
                                                        divPropertyHeight += div.Div_PropHeight;
                                                        break;
                                                    }
                                                }
                                                #endregion

                                            }
                                            else if (ctrl.Name.Contains("MultiTransom") || ctrl.Name.Contains("MultiMullion"))
                                            {

                                                #region 2nd Level MultiPanel MultiPanel

                                                foreach (MultiPanelModel thirdlvlmpnl in mpnl.MPanelLst_MultiPanel)
                                                {
                                                    if (ctrl.Name == thirdlvlmpnl.MPanel_Name)
                                                    {
                                                        mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                        foreach (Control thirdlvlctrl in thirdlvlmpnl.MPanelLst_Objects)
                                                        {
                                                            if (thirdlvlctrl.Name.Contains("PanelUC"))
                                                            {
                                                                foreach (PanelModel pnl in thirdlvlmpnl.MPanelLst_Panel)
                                                                {
                                                                    if (thirdlvlctrl.Name == pnl.Panel_Name)
                                                                    {
                                                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                            else if (thirdlvlctrl.Name.Contains("MullionUC") || thirdlvlctrl.Name.Contains("TransomUC"))
                                                            {

                                                                foreach (DividerModel div in thirdlvlmpnl.MPanelLst_Divider)
                                                                {
                                                                    if (thirdlvlctrl.Name == div.Div_Name)
                                                                    {
                                                                        divPropertyHeight += div.Div_PropHeight;
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                            foreach (MultiPanelModel fourthlvlmpnl in thirdlvlmpnl.MPanelLst_MultiPanel)
                                                            {
                                                                if (thirdlvlctrl.Name == fourthlvlmpnl.MPanel_Name)
                                                                {
                                                                    mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                                    foreach (Control fourthlvlctrl in fourthlvlmpnl.MPanelLst_Objects)
                                                                    {

                                                                        if (fourthlvlctrl.Name.Contains("PanelUC"))
                                                                        {
                                                                            foreach (PanelModel pnl in fourthlvlmpnl.MPanelLst_Panel)
                                                                            {
                                                                                if (fourthlvlctrl.Name == pnl.Panel_Name)
                                                                                {
                                                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                                    break;
                                                                                }
                                                                            }

                                                                        }
                                                                        else if (fourthlvlctrl.Name.Contains("MullionUC") || fourthlvlctrl.Name.Contains("TransomUC"))
                                                                        {
                                                                            foreach (DividerModel div in fourthlvlmpnl.MPanelLst_Divider)
                                                                            {
                                                                                if (fourthlvlctrl.Name == div.Div_Name)
                                                                                {
                                                                                    divPropertyHeight += div.Div_PropHeight;
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion
                                    propertyHeight += frm.Frame_PropertiesUC.Height;
                                    framePropertyHeight = 0;
                                    mpnlPropertyHeight = 0;
                                    pnlPropertyHeight = 0;
                                    divPropertyHeight = 0;
                                }

                            }

                            #endregion
                        }
                        else
                        {
                            #region Concrete

                            foreach (IConcreteModel crm in wdm.lst_concrete)
                            {
                                if (wndrObject.Name == crm.Concrete_Name)
                                {
                                    concretePropertyHeight += constants.concrete_propertyHeight_default;
                                    break;
                                }
                            }
                            #endregion
                        }


                    }
                }
                catch (Exception)
                {

                }
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
            frameBinding.Add("Frame_CmenuDeleteVisibility", new Binding("Frame_CmenuDeleteVisibility", _frameModel, "Frame_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return frameBinding;
        }

        Color color = Color.Black;
        public void OnOuterFramePaintEventRaised(object sender, PaintEventArgs e)
        {
            Pen blkPen = new Pen(Color.Black);

            Graphics g = e.Graphics;

            UserControl pfr = (UserControl)sender;

            int top_pads = _frameModel.Frame_Padding_int.Top,
                    right_pads = _frameModel.Frame_Padding_int.Right,
                    left_pads = _frameModel.Frame_Padding_int.Left,
                    bot_pads = _frameModel.Frame_Padding_int.Bottom;

            Rectangle pnl_inner = new Rectangle();

            //if (_frameModel.Frame_Zoom == 0.26f || _frameModel.Frame_Zoom == 0.17f || 
            //    _frameModel.Frame_Zoom == 0.13f || _frameModel.Frame_Zoom == 0.10f)
            //{
            //    pnl_inner = new Rectangle(new Point(15, 15),
            //                              new Size(pfr.ClientRectangle.Width - (15 * 2),
            //                                       pfr.ClientRectangle.Height - (15 * 2)));
            //}
            //else
            //{
            pnl_inner = new Rectangle(new Point(top_pads, left_pads),
                                            new Size(pfr.ClientRectangle.Width - (right_pads + left_pads),
                                                     pfr.ClientRectangle.Height - (top_pads + bot_pads)));
            //}

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
            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 && _frameModel.Lst_MultiPanel.Count >= 1 ||
              _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050 && _frameModel.Lst_MultiPanel.Count >= 1)
                {
                    corner_points[4] = new Point(0, pfr.ClientRectangle.Height);
                    corner_points[5] = new Point(pInnerX, pInnerY + pInnerHt - 2);

                    corner_points[6] = new Point(pfr.ClientRectangle.Width - 1, pfr.ClientRectangle.Height - 1);
                    corner_points[7] = new Point(pInnerX + pInnerWd - 1, pInnerY + pInnerHt - 3);
                }
            }
          
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
                                                IUserModel userModel,
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
            framePresenter._userModel = userModel;
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
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.DeleteFramePropertiesUC(_frameModel.Frame_ID);
            _mainPresenter.DeleteFrame_OnFrameList_WindoorModel(_frameModel);
            _mainPresenter.SetPanelGlassID();
            _mainPresenter.DeselectDivider();
            if (_mainPresenter.windoorModel_MainPresenter.lst_frame.Count == 0)
            {
                _mainPresenter.windoorModel_MainPresenter.frameIDCounter = 0;

            }

        }

        public void ViewDeleteControl(UserControl control)
        {
            _frameUC.DeleteControl(control);
        }

    }

}
