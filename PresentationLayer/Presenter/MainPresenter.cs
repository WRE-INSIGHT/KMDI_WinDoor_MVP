﻿using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Screen;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.Costing_Head;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels.Thumbs;
using ServiceLayer.Services.ConcreteServices;
using ServiceLayer.Services.DividerServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.ScreenServices;
using ServiceLayer.Services.WindoorServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        #region GlobalVar
        Class.csFunctions csfunc = new Class.csFunctions();
        IMainView _mainView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel; //currently selected item
        private IFrameModel _frameModel;
        private IScreenModel _screenModel;
        private IConcreteModel _concreteModel;

        private ILoginView _loginView;
        private IItemInfoUC _itemInfoUC;
        private IFrameUC _frameUC;
        private IFramePropertiesUC _framePropertiesUC;

        private IQuotationServices _quotationServices;
        private IWindoorServices _windoorServices;
        private IFrameServices _frameServices;
        private IMultiPanelServices _multipanelServices;
        private IMultiPanelModel _multiPanelModel;
        private IPanelServices _panelServices;
        private IDividerServices _divServices;
        private IConcreteServices _concreteServices;
        private IScreenServices _screenServices;


        private IFrameUCPresenter _frameUCPresenter;
        private IFrameImagerUCPresenter _frameImagerUCPresenter;
        private IBasePlatformPresenter _basePlatformPresenter;
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCPresenter;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IItemInfoUCPresenter _itemInfoUCPresenter;
        private IFramePropertiesUCPresenter _framePropertiesUCPresenter;
        private IConcretePropertiesUCPresenter _concretePropertiesUCPresenter;
        private IControlsUCPresenter _controlsUCP;
        private IFixedPanelUCPresenter _fixedPanelUCPresenter;
        private IExplosionPresenter _explosionPresenter;
        private IDividerPropertiesUCPresenter _divPropertiesUCP;
        private ICreateNewGlassPresenter _createNewGlassPresenter;
        private IChangeItemColorPresenter _changeItemColorPresenter;
        private ICreateNewGlassTypePresenter _createNewGlassTypePresenter;
        private ICreateNewGlassColorPresenter _createNewGlassColorPresenter;
        private ICreateNewGlassSpacerPresenter _createNewGlassSpacerPresenter;
        private ICustomArrowHeadPresenter _customArrowHeadPresenter;
        private ICustomArrowHeadUCPresenter _customArrowHeadUCP;
        private IAssignProjectsPresenter _assignProjPresenter;
        private IAssignAEPresenter _addProjPresenter;
        private ICostEngrLandingPresenter _ceLandingPresenter;
        private IFactorPresenter _factorPresenter;
        private IConcreteUCPresenter _concreteUCPresenter;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private ISortItemPresenter _sortItemPresenter;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private ISortItemUCPresenter _sortItemUCPresenter;
        private ISetTopViewSlidingPanellingPresenter _setTopViewSlidingPanellingPresenter;
        private IGlassThicknessListPresenter _glassThicknessPresenter;
        private IScreenPresenter _screenPresenter;

        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IMultiPanelPropertiesUCPresenter _multiPanelPropertiesUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP;
        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionUC _multiMullionUC;
        private IMultiPanelTransomUC _multiTransomUC;
        private IMullionUCPresenter _mullionUCP;
        private ITransomUCPresenter _transomUCP;



        Panel _pnlMain, _pnlItems, _pnlPropertiesBody, _pnlControlSub;

        private FrameModel.Frame_Padding frameType;
        private int _quoteId;
        private string input_qrefno, _projectName, _custRefNo;
        private string _wndrFileName;
        private DateTime _quotationDate;

        private CommonFunctions _commonfunc = new CommonFunctions();

        private DataTable _glassThicknessDT = new DataTable();
        private DataTable _glassTypeDT = new DataTable();
        private DataTable _spacerDT = new DataTable();
        private DataTable _colorDT = new DataTable();

        private ToolStripLabel _tsLblStatus;
        private ToolStrip _tsMain;
        private MenuStrip _msMainMenu;
        private Base_Color baseColor;

        private Control _controlRaised_forDMSelection;
        private IDividerModel _divModel_forDMSelection;
        private IPanelModel _prevPanelModel_forDMSelection;
        private IPanelModel _nxtPanelModel_forDMSelection;
        private IPanelModel _pnlModel_forGlassSelection;
        private IDividerPropertiesUCPresenter _divPropUCP_forDMSelection;
        private IFixedPanelUCPresenter _fixedUCP;
        private ICasementPanelUCPresenter _casementUCP;
        private IAwningPanelUCPresenter _awningUCP;
        private ISlidingPanelUCPresenter _slidingUCP;
        private ITiltNTurnPanelUCPresenter _tiltNTurnUCP;
        private ILouverPanelUCPresenter _louverPanelUCP;
        private IFrameUCPresenter frmUCPresenter;
        private IDividerModel _prev_divModel;
        #endregion

        #region GetSet

        public DataTable GlassThicknessDT
        {
            get
            {
                return _glassThicknessDT;
            }
            set
            {
                _glassThicknessDT = value;
            }
        }

        public DataTable GlassTypeDT
        {
            get
            {
                return _glassTypeDT;
            }
            set
            {
                _glassTypeDT = value;
            }
        }


        public DataTable GlassSpacerDT
        {
            get
            {
                return _spacerDT;
            }
            set
            {
                _spacerDT = value;
            }
        }

        public DataTable GlassColorDT
        {
            get
            {
                return _colorDT;
            }
            set
            {
                _colorDT = value;
            }
        }


        public string inputted_quotationRefNo
        {
            get
            {
                return input_qrefno;
            }

            set
            {
                input_qrefno = value;
            }
        }

        public IQuotationModel qoutationModel_MainPresenter
        {
            get
            {
                return _quotationModel;
            }

            set
            {
                _quotationModel = value;
            }
        }

        public IBasePlatformPresenter basePlatform_MainPresenter
        {
            get
            {
                return _basePlatformPresenter;
            }

            set
            {
                _basePlatformPresenter = value;
            }
        }

        public IfrmDimensionPresenter frmDimension_MainPresenter
        {
            get
            {
                return _frmDimensionPresenter;
            }

            set
            {
                _frmDimensionPresenter = value;
            }
        }

        public IWindoorModel windoorModel_MainPresenter
        {
            get
            {
                return _windoorModel;
            }

            set
            {
                _windoorModel = value;
            }
        }

        public Panel pnlMain_MainPresenter
        {
            get
            {
                return _pnlMain;
            }

            set
            {
                _pnlMain = value;
            }
        }

        public Panel pnlItems_MainPresenter
        {
            get
            {
                return _pnlItems;
            }

            set
            {
                _pnlItems = value;
            }
        }

        public IItemInfoUC itemInfoUC_MainPresenter
        {
            get
            {
                return _itemInfoUC;
            }

            set
            {
                _itemInfoUC = value;
            }
        }

        public FrameModel.Frame_Padding frameType_MainPresenter
        {
            get
            {
                return frameType;
            }

            set
            {
                frameType = value;
            }
        }

        public IFrameModel frameModel_MainPresenter
        {
            get
            {
                return _frameModel;
            }

            set
            {
                _frameModel = value;
            }
        }

        public IFrameUC frameUC_MainPresenter
        {
            get
            {
                return _frameUC;
            }

            set
            {
                _frameUC = value;
            }
        }

        public IFramePropertiesUC framePropertiesUC_MainPresenter
        {
            get
            {
                return _framePropertiesUC;
            }

            set
            {
                _framePropertiesUC = value;
            }
        }

        public Panel pnlPropertiesBody_MainPresenter
        {
            get
            {
                return _pnlPropertiesBody;
            }

            set
            {
                _pnlPropertiesBody = value;
            }
        }

        public IBasePlatformImagerUCPresenter basePlatformWillRenderImg_MainPresenter
        {
            get
            {
                return _basePlatformImagerUCPresenter;
            }

            set
            {
                _basePlatformImagerUCPresenter = value;
            }
        }

        public IDividerPropertiesUCPresenter divPropertiesUCP
        {
            get
            {
                return _divPropertiesUCP;
            }
        }

        public DataTable Glass_Type
        {
            get
            {
                return _glassTypeDT;
            }
        }

        public DataTable Spacer
        {
            get
            {
                return _spacerDT;
            }
        }

        public DataTable Color
        {
            get
            {
                return _colorDT;
            }
        }

        public IDividerModel DivModel_forDMSelection
        {
            get
            {
                return _divModel_forDMSelection;
            }
        }

        public IPanelModel PrevPnlModel_forDMSelection
        {
            get
            {
                return _prevPanelModel_forDMSelection;
            }
        }

        public IPanelModel NxtPnlModel_forDMSelection
        {
            get
            {
                return _nxtPanelModel_forDMSelection;
            }
        }

        public IPanelModel PnlModel_forGlassSelection()
        {
            return _pnlModel_forGlassSelection;
        }

        public Control ControlRaised_forDMSelection
        {
            get
            {
                return _controlRaised_forDMSelection;
            }
        }

        public DateTime inputted_quoteDate
        {
            get
            {
                return _quotationDate;
            }
            set
            {
                _quotationDate = value;
            }
        }

        public int inputted_quoteId
        {
            get
            {
                return _quoteId;
            }
            set
            {
                _quoteId = value;
            }
        }

        public string inputted_projectName
        {
            get
            {
                return _projectName;
            }
            set
            {
                _projectName = value;
            }
        }
        public string inputted_custRefNo
        {
            get
            {
                return _custRefNo;
            }
            set
            {
                _custRefNo = value;
            }
        }

        public string wndrFileName
        {
            get
            {
                return _wndrFileName;
            }

            set
            {
                _wndrFileName = value;
            }
        }
        private bool _isNewProject = false;
        public bool isNewProject
        {
            get
            {
                return _isNewProject;
            }

            set
            {
                _isNewProject = value;
            }
        }
        private bool _isOpenProject = false;
        public bool isOpenProject
        {
            get
            {
                return _isOpenProject;
            }

            set
            {
                _isOpenProject = value;
            }
        }
        private decimal _pricingFactor;
        public decimal pricingFactor
        {
            get
            {
                return _pricingFactor;
            }

            set
            {
                _pricingFactor = value;
            }
        }


        public IScreenModel screenModel_MainPresenter
        {
            get
            {
                return _screenModel;
            }

            set
            {
                _screenModel = value;
            }
        }

        #endregion

        public MainPresenter(IMainView mainView,
                             IFrameUCPresenter frameUCPresenter,
                             IfrmDimensionPresenter frmDimensionPresenter,
                             IBasePlatformPresenter basePlatformPresenter,
                             IQuotationServices quotationServices,
                             IWindoorServices windoorServices,
                             IItemInfoUCPresenter itemInfoUCPresenter,
                             IFrameServices frameServices,
                             IFramePropertiesUCPresenter framePropertiesPresenter,
                             IConcretePropertiesUCPresenter concretePropertiesUCPresenter,
                             IFixedPanelUCPresenter fixedPanelUCPresenter,
                             IPanelServices panelServices,
                             IConcreteServices concreteServices,
                             IControlsUCPresenter controlsUCP,
                             IBasePlatformImagerUCPresenter basePlatformImagerUCPresenter,
                             IFrameImagerUCPresenter frameImagerUCPresenter,
                             IExplosionPresenter explosionPresenter,
                             IDividerPropertiesUCPresenter divPropertiesUCP,
                             ICreateNewGlassPresenter createNewGlassPresenter,
                             ICreateNewGlassTypePresenter createNewGlassTypePresenter,
                             ICreateNewGlassColorPresenter createNewGlassColorPresenter,
                             ICreateNewGlassSpacerPresenter createNewGlassSpacerPresenter,
                             IChangeItemColorPresenter changeItemColorPresenter,
                             ICustomArrowHeadPresenter customArrowHeadPresenter,
                             ICustomArrowHeadUCPresenter customArrowHeadUCP,
                             IAssignProjectsPresenter assignProjPresenter,
                             IAssignAEPresenter addProjPresenter,
                             ICostEngrLandingPresenter ceLandingPresenter,
                             IConcreteUCPresenter concreteUCPresenter,
                             IQuoteItemListPresenter quoteItemListPresenter,
                             IPrintQuotePresenter printQuotePresenter,
                             IQuoteItemListUCPresenter quoteItemListUCPresenter,
                             ISetTopViewSlidingPanellingPresenter setTopViewSlidingPanellingPresenter,
                             ISortItemPresenter sortItemPresenter,
                             ISortItemUCPresenter sortItemUCPresenter,
                             IPanelPropertiesUCPresenter panelPropertiesUCP,
                             IFixedPanelUCPresenter fixedUCP,
                             ICasementPanelUCPresenter casementUCP,
                             IAwningPanelUCPresenter awningUCP,
                             ISlidingPanelUCPresenter slidingUCP,
                             ITiltNTurnPanelUCPresenter tiltNTurnUCP,
                             ILouverPanelUCPresenter louverPanelUCP,
                             IMultiPanelServices multipanelServices,
                             IMultiPanelPropertiesUCPresenter multiPanelPropertiesUCP,
                             IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                             IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP,
                             IMultiPanelMullionUCPresenter multiMullionUCP,
                             IMultiPanelTransomUCPresenter multiTransomUCP,
                             IFrameImagerUCPresenter frameImagerUCP,
                             IDividerServices divServices,
                             IMullionUCPresenter mullionUCP,
                             ITransomUCPresenter transomUCP,
                             IGlassThicknessListPresenter glassThicknessPresenter,
                             IScreenPresenter screenPresenter,
                             IFactorPresenter factorPresenter,
                             IScreenServices screenServices)

        {
            _mainView = mainView;
            _frameUCPresenter = frameUCPresenter;
            _frameImagerUCPresenter = frameImagerUCPresenter;
            _frmDimensionPresenter = frmDimensionPresenter;
            _basePlatformPresenter = basePlatformPresenter;
            _quotationServices = quotationServices;
            _windoorServices = windoorServices;
            _itemInfoUCPresenter = itemInfoUCPresenter;
            _frameServices = frameServices;
            _framePropertiesUCPresenter = framePropertiesPresenter;
            _concretePropertiesUCPresenter = concretePropertiesUCPresenter;
            _fixedPanelUCPresenter = fixedPanelUCPresenter;
            _multipanelServices = multipanelServices;
            _panelServices = panelServices;
            _concreteServices = concreteServices;
            _controlsUCP = controlsUCP;
            _basePlatformImagerUCPresenter = basePlatformImagerUCPresenter;
            _explosionPresenter = explosionPresenter;
            _divPropertiesUCP = divPropertiesUCP;
            _createNewGlassPresenter = createNewGlassPresenter;
            _createNewGlassTypePresenter = createNewGlassTypePresenter;
            _createNewGlassColorPresenter = createNewGlassColorPresenter;
            _createNewGlassSpacerPresenter = createNewGlassSpacerPresenter;
            _changeItemColorPresenter = changeItemColorPresenter;
            _customArrowHeadPresenter = customArrowHeadPresenter;
            _customArrowHeadUCP = customArrowHeadUCP;
            _assignProjPresenter = assignProjPresenter;
            _ceLandingPresenter = ceLandingPresenter;
            _concreteUCPresenter = concreteUCPresenter;
            _quoteItemListPresenter = quoteItemListPresenter;
            _printQuotePresenter = printQuotePresenter;
            _quoteItemListUCPresenter = quoteItemListUCPresenter;
            _setTopViewSlidingPanellingPresenter = setTopViewSlidingPanellingPresenter;
            _sortItemPresenter = sortItemPresenter;
            _sortItemUCPresenter = sortItemUCPresenter;
            _panelPropertiesUCP = panelPropertiesUCP;
            _fixedUCP = fixedUCP;
            _casementUCP = casementUCP;
            _awningUCP = awningUCP;
            _slidingUCP = slidingUCP;
            _addProjPresenter = addProjPresenter;
            _tiltNTurnUCP = tiltNTurnUCP;
            _louverPanelUCP = louverPanelUCP;
            _multiPanelPropertiesUCP = multiPanelPropertiesUCP;
            _multiMullionImagerUCP = multiMullionImagerUCP;
            _multiTransomImagerUCP = multiTransomImagerUCP;
            _multiMullionUCP = multiMullionUCP;
            _multiTransomUCP = multiTransomUCP;
            _frameImagerUCP = frameImagerUCP;
            _divServices = divServices;
            _mullionUCP = mullionUCP;
            _transomUCP = transomUCP;
            _glassThicknessPresenter = glassThicknessPresenter;
            _screenPresenter = screenPresenter;
            _factorPresenter = factorPresenter;
            _screenServices = screenServices;

            SubscribeToEventsSetup();
        }
        public IMainView GetMainView()
        {
            return _mainView;
        }

        public void SetLblStatus(string status,
                                 bool visibility,
                                 Control controlRaised = null,
                                 IDividerModel divModel = null,
                                 IPanelModel prev_pnl = null, //selected panelModel / prevPanel
                                 IPanelModel nxt_pnl = null,
                                 IDividerPropertiesUCPresenter divPropUCP = null)
        {
            _tsLblStatus.Visible = visibility;

            if (status == "DMPreSelection")
            {
                _windoorModel.WD_CmenuDeleteVisibility = false;

                _tsLblStatus.Text = "Select one of the highlighted panel";
                _controlRaised_forDMSelection = controlRaised;
                _pnlControlSub.Enabled = false;
                _msMainMenu.Enabled = false;
                _pnlPropertiesBody.Enabled = false;
                _tsMain.Enabled = false;
                _divModel_forDMSelection = divModel;
                _prevPanelModel_forDMSelection = prev_pnl;
                _nxtPanelModel_forDMSelection = nxt_pnl;
                _divPropUCP_forDMSelection = divPropUCP;
            }
            else if (status == "DMSelection")
            {
                _windoorModel.WD_CmenuDeleteVisibility = true;

                _tsLblStatus.Text = "";
                _pnlControlSub.Enabled = true;
                _msMainMenu.Enabled = true;
                _pnlPropertiesBody.Enabled = true;
                _tsMain.Enabled = true;
                _controlRaised_forDMSelection.Text = "P" + prev_pnl.PanelGlass_ID;
                _controlRaised_forDMSelection.BackColor = System.Drawing.Color.PaleGreen;

                Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
                divBinding.Add("Panel_SashProfileArtNo", new Binding("Panel_SashProfileArtNo", prev_pnl, "Panel_SashProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

                _divPropUCP_forDMSelection.GetDivProperties().Bind_DMPanelModel(divBinding);
                _divPropUCP_forDMSelection.GetLeverEspagUCP().BindSashProfileArtNo();
            }
        }

        public void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC)
        {
            _userModel = userModel;
            _loginView = loginView;
            _pnlMain = _mainView.GetPanelMain();
            _pnlItems = _mainView.GetPanelItems();
            _pnlPropertiesBody = _mainView.GetPanelPropertiesBody();
            _pnlControlSub = _mainView.GetPanelControlSub();
            _tsLblStatus = _mainView.GetLblSelectedDivider();
            _tsMain = _mainView.GetTSMain();
            _msMainMenu = _mainView.GetMNSMainMenu();

            _unityC = unityC;
        }
        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
            _mainView.MainViewClosingEventRaised += new EventHandler(OnMainViewClosingEventRaised);
            _mainView.OpenToolStripButtonClickEventRaised += new EventHandler(OnOpenToolStripButtonClickEventRaised);
            _mainView.NewFrameButtonClickEventRaised += new EventHandler(OnNewFrameButtonClickEventRaised);
            _mainView.NewQuotationMenuItemClickEventRaised += new EventHandler(OnNewQuotationMenuItemClickEventRaised);
            _mainView.PanelMainSizeChangedEventRaised += new EventHandler(OnPanelMainSizeChangedEventRaised);
            _mainView.CreateNewItemClickEventRaised += new EventHandler(OnCreateNewItemClickEventRaised);
            _mainView.LabelSizeClickEventRaised += new EventHandler(OnLabelSizeClickEventRaised);
            _mainView.ButtonMinusZoomClickEventRaised += _mainView_ButtonMinusZoomClickEventRaised;
            _mainView.ButtonPlusZoomClickEventRaised += _mainView_ButtonPlusZoomClickEventRaised;
            _mainView.DeleteToolStripButtonClickEventRaised += _mainView_DeleteToolStripButtonClickEventRaised;
            _mainView.ListOfMaterialsToolStripMenuItemClickEventRaised += _mainView_ListOfMaterialsToolStripMenuItemClickEventRaised;
            _mainView.CreateNewGlassClickEventRaised += _mainView_CreateNewGlassClickEventRaised;
            _mainView.ChangeItemColorClickEventRaised += _mainView_ChangeItemColorClickEventRaised;
            _mainView.glassTypeColorSpacerToolStripMenuItemClickEventRaised += _mainView_glassTypeColorSpacerToolStripMenuItemClickEventRaised;
            _mainView.glassBalancingToolStripMenuItemClickEventRaised += _mainView_glassBalancingToolStripMenuItemClickEventRaised;
            _mainView.customArrowHeadToolStripMenuItemClickEventRaised += new EventHandler(OncustomArrowHeadToolStripMenuItemClickEventRaised);
            _mainView.assignProjectsToolStripMenuItemClickEventRaised += _mainView_assignProjectsToolStripMenuItemClickEventRaised;
            _mainView.selectProjectToolStripMenuItemClickEventRaised += _mainView_selectProjectToolStripMenuItemClickEventRaised;
            _mainView.NewConcreteButtonClickEventRaised += _mainView_NewConcreteButtonClickEventRaised;
            _mainView.refreshToolStripButtonClickEventRaised += _mainView_refreshToolStripButtonClickEventRaised;
            _mainView.CostingItemsToolStripMenuItemClickRaiseEvent += _mainView_CostingItemsToolStripMenuItemClickRaiseEvent;
            _mainView.saveAsToolStripMenuItemClickEventRaised += _mainView_saveAsToolStripMenuItemClickEventRaised;
            _mainView.saveToolStripButtonClickEventRaised += _mainView_saveToolStripButtonClickEventRaised;
            _mainView.slidingTopViewToolStripMenuItemClickRaiseEvent += _mainView_slidingTopViewToolStripMenuItemClickRaiseEvent;
            _mainView.ViewImagerToolStripButtonClickEventRaised += _mainView_ViewImagerToolStripButtonClickEventRaised;
            _mainView.ItemsDragEventRaiseEvent += _mainView_ItemsDragEventRaiseEvent;
            _mainView.SortItemButtonClickEventRaised += _mainView_SortItemButtonClickEventRaised;
            _mainView.existingItemToolStripMenuItemClickEventRaised += _mainView_existingItemToolStripMenuItemClickEventRaised;
            _mainView.SetGlassToolStripMenuItemClickRaiseEvent += _mainView_SetGlassToolStripMenuItemClickRaiseEvent;
            _mainView.addProjectsToolStripMenuItemClickEventRaised += _mainView_addProjectsToolStripMenuItemClickEventRaised;
            _mainView.screenToolStripMenuItemClickEventRaised += _mainView_screenToolStripMenuItemClickEventRaised;
            _mainView.factorToolStripMenuItemClickEventRaised += _mainView_factorToolStripMenuItemClickEventRaised;
        }





        #region Events  
        private void _mainView_factorToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            IFactorPresenter factor = _factorPresenter.GetNewInstance(_unityC, this);
            factor.GetFactorView().ShowThis();
        }
        private void _mainView_screenToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
           // int screenID = _screenModel.Screen_id += 1;
            _screenModel = _screenServices.AddScreenModel(1,
                                                          0,
                                                          0,
                                                          0.0m,
                                                          null,
                                                          string.Empty,
                                                          0.0m,
                                                          0,
                                                          0.0m);

            _screenModel.Screen_PVCVisibility = false;
            IScreenPresenter glassThicknessPresenter = _screenPresenter.CreateNewInstance(_unityC, this, _screenModel);//, _screenDT);
            glassThicknessPresenter.GetScreenView().ShowScreemView();
        }

        private void _mainView_SetGlassToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            //IGlassThicknessListPresenter glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance(_unityC, GlassThicknessDT, );
            //glassThicknessPresenter.ShowGlassThicknessListView();
        }

        private void _mainView_slidingTopViewToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            ISetTopViewSlidingPanellingPresenter TopView = _setTopViewSlidingPanellingPresenter.CreateNewInstance(_unityC, this, _windoorModel, _itemInfoUCPresenter);
            TopView.GetSetTopViewSlidingPanellingView().GetSetTopSlidingPanellingView();
        }


        private void _mainView_selectProjectToolStripMenuItemClickEventRaised1(object sender, EventArgs e)
        {

        }

        string wndrfile = "",
               wndrProjectFileName = "",
              searchStr = "",
              todo,
              mainTodo;
        public bool online_login = true;
        int x = 50;

        private void _mainView_saveToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            SaveChanges();
        }


        private void _mainView_saveAsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            SaveAs();
        }

        public void SaveAs()
        {
            wndrProjectFileName = _mainView.GetSaveFileDialog().FileName;
            if (wndrfile != _mainView.GetSaveFileDialog().FileName)
            {
                wndrfile = _mainView.GetSaveFileDialog().FileName;

            }
            else
            {
                if (!_mainView.mainview_title.Contains(wndrfile))
                {
                    _mainView.mainview_title += "( " + wndrfile + " )";
                }
            }
            saveToolStripButton_Click();
        }

        private void saveToolStripButton_Click()
        {
            //saveToolStripButton.Enabled = false;
            //UppdateDictionaries();
            _mainView.mainview_title = _mainView.mainview_title.Replace("*", "");
            if (wndrfile != "")
            {
                try
                {
                    string txtfile = wndrfile.Replace(".wndr", ".txt");
                    File.WriteAllLines(txtfile, Saving_dotwndr());
                    File.SetAttributes(txtfile, FileAttributes.Hidden);
                    csfunc.EncryptFile(txtfile);
                    File.Delete(txtfile);

                    //if (online_login && updatefile_bgw.IsBusy != true)
                    //{
                    int startFileName = txtfile.LastIndexOf("\\") + 1;
                    string outFile = txtfile.Substring(startFileName, txtfile.LastIndexOf(".") - startFileName) + ".wndr";
                    searchStr = outFile;
                    todo = "GetFile";
                    x = 50; // for fadeoutImage
                            //tsp_Sync.Image = Properties.Resources.cloud_sync_40px;
                            //tsp_Sync.Visible = true;
                            //CostingItems.Rows.Clear();
                            //updatefile_bgw.RunWorkerAsync();
                            //}
                    MessageBox.Show("File saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    wndrProjectFileName = _mainView.GetSaveFileDialog().FileName;
                    SetMainViewTitle(input_qrefno,
                                     _projectName,
                                     _custRefNo,
                                     _windoorModel.WD_name,
                                     _windoorModel.WD_profile,
                                     true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                //MessageBox.Show(this, "Please save your progress locally or online to prevent data loss", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<string> Saving_dotwndr()
        {
            #region Save

            List<string> wndr_content = new List<string>();

            wndr_content.Add("QuoteId: " + _quoteId);
            wndr_content.Add("ProjectName: " + _projectName);
            wndr_content.Add("CustomerRefNo: " + _custRefNo);
            foreach (var prop in _quotationModel.GetType().GetProperties())
            {
                wndr_content.Add(prop.Name + ": " + prop.GetValue(_quotationModel, null));
            }
            foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                wndr_content.Add("(");
                foreach (var prop in wdm.GetType().GetProperties())
                {


                    wndr_content.Add(prop.Name + ": " + prop.GetValue(wdm, null));
                }
                foreach (FrameModel frm in wdm.lst_frame)
                {
                    wndr_content.Add("{");
                    foreach (var prop in frm.GetType().GetProperties())
                    {
                        wndr_content.Add("\t" + prop.Name + ": " + prop.GetValue(frm, null));
                    }
                    foreach (PanelModel pnl in frm.Lst_Panel)
                    {
                        wndr_content.Add("\t#");
                        foreach (var prop in pnl.GetType().GetProperties())
                        {
                            wndr_content.Add("\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                        }
                    }
                    foreach (MultiPanelModel mpnl in frm.Lst_MultiPanel)
                    {
                        wndr_content.Add("\t[");
                        foreach (var prop in mpnl.GetType().GetProperties())
                        {
                            wndr_content.Add("\t\t" + prop.Name + ": " + prop.GetValue(mpnl, null));
                        }
                        foreach (Control ctrl in mpnl.MPanelLst_Objects)
                        {
                            //else if (row_str.Contains("ProjectName"))
                            //{
                            //    _projectName = extractedValue_str;
                            //}

                            if (ctrl.Name.Contains("PanelUC"))
                            {
                                wndr_content.Add("\t\t#");
                                foreach (PanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    if (ctrl.Name == pnl.Panel_Name)
                                    {

                                        foreach (var prop in pnl.GetType().GetProperties())
                                        {
                                            wndr_content.Add("\t\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                        }
                                        break;
                                    }
                                }
                            }
                            else if (ctrl.Name.Contains("MullionUC") || ctrl.Name.Contains("TransomUC"))
                            {
                                wndr_content.Add("\t\t|");
                                foreach (DividerModel div in mpnl.MPanelLst_Divider)
                                {
                                    if (ctrl.Name == div.Div_Name)
                                    {
                                        foreach (var prop in div.GetType().GetProperties())
                                        {
                                            if (prop.Name == "Div_DMPanel" && div.Div_DMPanel != null)
                                            {

                                                wndr_content.Add("\t\t\t" + prop.Name + ": " + div.Div_DMPanel.Panel_Name);
                                            }
                                            else if (prop.Name == "Div_CladdingSizeList")
                                            {

                                                string claddingArray = "";
                                                foreach (KeyValuePair<int, int> cladList in div.Div_CladdingSizeList)
                                                {
                                                    claddingArray += "<" + cladList.Key + "," + cladList.Value + ">; ";
                                                }

                                                wndr_content.Add("\t\t\t" + prop.Name + ": " + claddingArray);
                                            }
                                            else
                                            {
                                                wndr_content.Add("\t\t\t" + prop.Name + ": " + prop.GetValue(div, null));
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                            else if (ctrl.Name.Contains("MultiTransom") || ctrl.Name.Contains("MultiMullion"))
                            {
                                wndr_content.Add("\t\t[");
                                foreach (MultiPanelModel thirdlvlmpnl in mpnl.MPanelLst_MultiPanel)
                                {
                                    if (ctrl.Name == thirdlvlmpnl.MPanel_Name)
                                    {
                                        foreach (var prop in thirdlvlmpnl.GetType().GetProperties())
                                        {
                                            wndr_content.Add("\t\t\t" + prop.Name + ": " + prop.GetValue(thirdlvlmpnl, null));
                                        }
                                        foreach (Control thirdlvlctrl in thirdlvlmpnl.MPanelLst_Objects)
                                        {
                                            if (thirdlvlctrl.Name.Contains("PanelUC"))
                                            {
                                                wndr_content.Add("\t\t\t#");
                                                foreach (PanelModel pnl in thirdlvlmpnl.MPanelLst_Panel)
                                                {
                                                    if (thirdlvlctrl.Name == pnl.Panel_Name)
                                                    {

                                                        foreach (var prop in pnl.GetType().GetProperties())
                                                        {
                                                            wndr_content.Add("\t\t\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                                        }
                                                        break;
                                                    }
                                                }
                                            }
                                            else if (thirdlvlctrl.Name.Contains("MullionUC") || thirdlvlctrl.Name.Contains("TransomUC"))
                                            {

                                                wndr_content.Add("\t\t\t|");
                                                foreach (DividerModel div in thirdlvlmpnl.MPanelLst_Divider)
                                                {
                                                    if (thirdlvlctrl.Name == div.Div_Name)
                                                    {
                                                        foreach (var prop in div.GetType().GetProperties())
                                                        {
                                                            if (prop.Name == "Div_DMPanel")
                                                            {

                                                                wndr_content.Add("\t\t\t\t" + prop.Name + ": " + div.Div_DMPanel.Panel_Name);

                                                            }
                                                            else
                                                            {
                                                                wndr_content.Add("\t\t\t\t" + prop.Name + ": " + prop.GetValue(div, null));
                                                            }
                                                        }
                                                        break;
                                                    }
                                                }
                                            }

                                            foreach (MultiPanelModel fourthlvlmpnl in thirdlvlmpnl.MPanelLst_MultiPanel)
                                            {
                                                if (thirdlvlctrl.Name == fourthlvlmpnl.MPanel_Name)
                                                {
                                                    foreach (var prop in fourthlvlmpnl.GetType().GetProperties())
                                                    {
                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + prop.GetValue(fourthlvlmpnl, null));
                                                    }

                                                    foreach (Control fourthlvlctrl in thirdlvlmpnl.MPanelLst_Objects)
                                                    {

                                                        if (fourthlvlctrl.Name.Contains("PanelUC"))
                                                        {
                                                            wndr_content.Add("\t\t\t\t#");
                                                            foreach (PanelModel pnl in fourthlvlmpnl.MPanelLst_Panel)
                                                            {
                                                                if (fourthlvlctrl.Name == pnl.Panel_Name)
                                                                {

                                                                    foreach (var prop in pnl.GetType().GetProperties())
                                                                    {
                                                                        wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                                                    }
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else if (fourthlvlctrl.Name.Contains("MullionUC") || fourthlvlctrl.Name.Contains("TransomUC"))
                                                        {
                                                            wndr_content.Add("\t\t\t\t|");
                                                            foreach (DividerModel div in fourthlvlmpnl.MPanelLst_Divider)
                                                            {
                                                                if (fourthlvlctrl.Name == div.Div_Name)
                                                                {
                                                                    foreach (var prop in div.GetType().GetProperties())
                                                                    {


                                                                        if (prop.Name == "Div_DMPanel")
                                                                        {

                                                                            wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + div.Div_DMPanel.Panel_Name);

                                                                        }
                                                                        else
                                                                        {
                                                                            wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + prop.GetValue(div, null));
                                                                        }



                                                                    }
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                wndr_content.Add("\t\t\t]");
                                            }
                                        }
                                    }
                                }

                                wndr_content.Add("\t\t]");
                            }
                        }

                        wndr_content.Add("\t]");
                        break;
                    }
                    wndr_content.Add("}");
                }
                foreach (IConcreteModel crm in wdm.lst_concrete)
                {
                    foreach (var prop in crm.GetType().GetProperties())
                    {
                        wndr_content.Add(prop.Name + ": " + prop.GetValue(crm, null));
                    }
                }
                wndr_content.Add(")");
            }
            wndr_content.Add("EndofFile");
            #endregion

            return wndr_content;
        }
        private void _mainView_CostingItemsToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            IQuoteItemListPresenter quoteItesm = _quoteItemListPresenter.GetNewInstance(_unityC, _quotationModel, _quoteItemListUCPresenter, _windoorModel, this);
            quoteItesm.GetQuoteItemListView().showQuoteItemList();
        }

        private void OncustomArrowHeadToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            if (_windoorModel.WD_customArrowToggle == false)
            {
                ICustomArrowHeadPresenter customArrowHeadPresenter = _customArrowHeadPresenter.GetNewInstance(_unityC, _customArrowHeadUCP, _windoorModel, this);
                customArrowHeadPresenter.GetICustomArrowHeadView().ShowCustomArrowHead();
                _windoorModel.WD_customArrowToggle = true;
            }
            else if (_windoorModel.WD_customArrowToggle == true)
            {
                _windoorModel.WD_customArrowToggle = false;
            }
        }


        private void _mainView_refreshToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                _basePlatformImagerUCPresenter.SendToBack_baseImager();



                //save frame
                Frame_Save_UserControl();
                Frame_Save_PropertiesUC();

                //set mainview
                SetMainViewTitle(input_qrefno,
                                 _projectName,
                                 _custRefNo,
                                 _windoorModel.WD_name,
                                 _windoorModel.WD_profile,
                                 false);
                _quotationModel.Select_Current_Windoor(_windoorModel);

                //clear
                _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);

                //basePlatform


                _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                _mainView.GetThis().Controls.Add(bpUC);

                _mainView.RemoveBinding(_mainView.GetLblSize());
                _mainView.RemoveBinding();
                _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());
                _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                _basePlatformPresenter.InvalidateBasePlatform();

            }
            catch (Exception ex)
            {

                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _mainView_NewConcreteButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                Scenario_Quotation(false, false, false, true, false, frmDimensionPresenter.Show_Purpose.CreateNew_Concrete, 0, 0, "", "");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _mainView_selectProjectToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                ICostEngrLandingPresenter ceLandingPresenter = _ceLandingPresenter.GetNewInstance(_userModel, this, _unityC);
                ceLandingPresenter.ShowThisView();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _mainView_assignProjectsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                IAssignProjectsPresenter assignProj = _assignProjPresenter.GetNewInstance(_unityC, this);
                assignProj.Set_UserModel(_userModel);
                assignProj.ShowThisView();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _mainView_glassBalancingToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            _quotationModel.GetListOfMaterials(_windoorModel);

            ToolStripMenuItem gb = (ToolStripMenuItem)sender;

            string gbmode = "";

            foreach (IFrameModel fr in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {
                    bool allWithSash = mpnl.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == true);
                    bool allNoSash = mpnl.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == false);
                    if (allWithSash == true && allNoSash == false)
                    {
                        gbmode = "withSash";
                    }
                    else if (allWithSash == false && allNoSash == true)
                    {
                        gbmode = "noSash";
                    }
                    else if (allWithSash == false && allNoSash == false)
                    {
                        gbmode = "";
                    }
                }
            }

            if (gbmode == "")
            {
                MessageBox.Show("Cannot apply auto glass balancing" + "\n" + "You can apply auto glass balancing if all panel has sash or all panel has no sash",
                                "Glass balancing not available",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gb.Checked = false;
            }
            else if (gbmode != "")
            {

                if (gb.Checked == true)
                {
                    foreach (IFrameModel fr in _windoorModel.lst_frame)
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                pnl.Panel_Width = pnl.Panel_OriginalWidth;
                                pnl.Panel_Height = pnl.Panel_OriginalHeight;
                            }
                        }
                    }
                }
                else if (gb.Checked == false)
                {
                    foreach (IFrameModel fr in _windoorModel.lst_frame)
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            mpnl.MPanel_DisplayWidth = mpnl.MPanel_OriginalDisplayWidth;
                            mpnl.MPanel_DisplayHeight = mpnl.MPanel_OriginalDisplayHeight;

                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                pnl.Panel_Width = pnl.Panel_OriginalWidth;
                                pnl.Panel_Height = pnl.Panel_OriginalHeight;
                                pnl.Panel_DisplayWidth = pnl.Panel_OriginalDisplayWidth;
                                pnl.Panel_DisplayHeight = pnl.Panel_OriginalDisplayHeight;
                            }

                            mpnl.Fit_MyControls_Dimensions();
                            mpnl.Fit_MyControls_ToBindDimensions();
                            mpnl.Fit_MyControls_ImagersToBindDimensions();
                            mpnl.Adjust_ControlDisplaySize();
                        }
                    }
                }
                _basePlatformPresenter.InvalidateBasePlatform();
                _basePlatformPresenter.Invalidate_flpMainControls();
                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                _basePlatformImagerUCPresenter.Invalidate_flpMain();
            }
        }

        private void _mainView_glassTypeColorSpacerToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            DataTable dt = new DataTable();

            if (menu == _mainView.Glass_Type)
            {
                ICreateNewGlassTypePresenter createNewGlassTypePresenter = _createNewGlassTypePresenter.GetNewInstance(_unityC, this, _glassTypeDT);
                createNewGlassTypePresenter.ShowCreateNewGlassTypeView();

            }
            else if (menu == _mainView.Spacer)
            {
                ICreateNewGlassSpacerPresenter createNewGlassSpacerPresenter = _createNewGlassSpacerPresenter.GetNewInstance(_unityC, this, _spacerDT);
                createNewGlassSpacerPresenter.ShowCreateNewGlassSpacerView();
            }
            else if (menu == _mainView.Color)
            {
                ICreateNewGlassColorPresenter createNewGlassColorPresenter = _createNewGlassColorPresenter.GetNewInstance(_unityC, this, _colorDT);
                createNewGlassColorPresenter.ShowCreateNewGlassColorView();
            }
        }

        private void _mainView_ChangeItemColorClickEventRaised(object sender, EventArgs e)
        {
            IChangeItemColorPresenter presenter = _changeItemColorPresenter.GetNewInstance(_unityC, this, _windoorModel);
            presenter.ShowView();
        }

        private void _mainView_CreateNewGlassClickEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            CreateNewGlass_ShowPurpose show_purpose = CreateNewGlass_ShowPurpose._DefaultNone;

            if (menu == _mainView.Glass_Single)
            {
                show_purpose = CreateNewGlass_ShowPurpose._Single;
            }
            else if (menu == _mainView.Glass_DoubleInsulated)
            {
                show_purpose = CreateNewGlass_ShowPurpose._DoubleInsulated;
            }
            else if (menu == _mainView.Glass_DoubleLaminated)
            {
                show_purpose = CreateNewGlass_ShowPurpose._DoubleLaminated;
            }
            else if (menu == _mainView.Glass_TripleInsulated)
            {
                show_purpose = CreateNewGlass_ShowPurpose._TripleInsulated;
            }
            else if (menu == _mainView.Glass_TripleLaminated)
            {
                show_purpose = CreateNewGlass_ShowPurpose._TripleLaminated;
            }


            ICreateNewGlassPresenter createNewGlassPresenter = _createNewGlassPresenter.GetNewInstance(_unityC, this, show_purpose, _glassThicknessDT);
            createNewGlassPresenter.ShowCreateNewGlassView();
        }

        private void _mainView_ListOfMaterialsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            string incompatibility_str = Check_Incompatibility();
            int unbalancedGlass_cnt = Check_UnbalancedGlass();
            bool proceed = false;

            if (incompatibility_str != "")
            {
                DialogResult dr = MessageBox.Show("Incompatibility(s) detected, Do you wish to proceed?" + incompatibility_str, "Incompatibility Check", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    proceed = true;
                }
                else if (dr == DialogResult.No)
                {
                    proceed = false;
                }
            }
            else
            {
                proceed = true;
            }

            if (unbalancedGlass_cnt >= 1)
            {
                DialogResult dr = MessageBox.Show("Unbalanced Glass detected, Do you wish to proceed?", "Unbalanced Glass Check", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    proceed = true;
                }
                else if (dr == DialogResult.No)
                {
                    proceed = false;
                }
            }

            if (proceed)
            {
                IExplosionPresenter explosionPresenter = _explosionPresenter.GetNewInstance(_unityC, _quotationModel, this, _windoorModel);
                explosionPresenter.ShowExplosionView();
            }
        }

        bool toggle;
        private void _mainView_DeleteToolStripButtonClickEventRaised(object sender, EventArgs e)
        {

            if (_quotationModel != null && _windoorModel != null)
            {
                if (MessageBox.Show("Are you sure want to delete " + _windoorModel.WD_name + "?", "Delete Item",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                    {
                        if (wdm == _windoorModel)
                        {
                            foreach (IItemInfoUC itemInfo in _pnlItems.Controls)
                            {
                                if (itemInfo.WD_Selected == true)
                                {
                                    _pnlItems.Controls.Remove((UserControl)itemInfo);
                                }

                            }
                            wdm.lst_frame.Clear();
                            _quotationModel.Lst_Windoor.Remove(wdm);

                            break;
                        }
                    }

                    _pnlPropertiesBody.Controls.Clear();
                    _pnlMain.Controls.Clear();
                    //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
                    int count = 1;
                    foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                    {
                        wdm.WD_name = "Item " + count;
                        count++;
                    }
                    foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                    {
                        Load_Windoor_Item(wdm);
                        break;
                    }
                    if (_quotationModel.Lst_Windoor.Count == 0)
                    {
                        Clearing_Operation();
                    }
                }
            }
        }

        private void _mainView_ButtonPlusZoomClickEventRaised(object sender, EventArgs e)
        {
            int ndx_zoomPercentage = Array.IndexOf(_windoorModel.Arr_ZoomPercentage, _windoorModel.WD_zoom);

            if (ndx_zoomPercentage < _windoorModel.Arr_ZoomPercentage.Count() - 1)
            {
                ndx_zoomPercentage++;
                _windoorModel.WD_zoom = _windoorModel.Arr_ZoomPercentage[ndx_zoomPercentage];
                _windoorModel.SetDimensions_basePlatform();
                _windoorModel.SetZoom();

                //FitControls_InsideMultiPanel();
                //Fit_MyControls_byControlsLocation();
            }
            _basePlatformPresenter.InvalidateBasePlatform();
            _basePlatformPresenter.Invalidate_flpMainControls();
        }

        private void _mainView_ButtonMinusZoomClickEventRaised(object sender, EventArgs e)
        {
            int ndx_zoomPercentage = Array.IndexOf(_windoorModel.Arr_ZoomPercentage, _windoorModel.WD_zoom);

            if (ndx_zoomPercentage > 0)
            {
                ndx_zoomPercentage--;
                _windoorModel.WD_zoom = _windoorModel.Arr_ZoomPercentage[ndx_zoomPercentage];
                _windoorModel.SetDimensions_basePlatform();
                _windoorModel.SetZoom();

                //FitControls_InsideMultiPanel();
                //Fit_MyControls_byControlsLocation();
            }
            _basePlatformPresenter.InvalidateBasePlatform();
            _basePlatformPresenter.Invalidate_flpMainControls();
        }

        private void OnLabelSizeClickEventRaised(object sender, EventArgs e)
        {
            _frmDimensionPresenter.SetPresenters(this);
            _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.ChangeBasePlatformSize;
            _frmDimensionPresenter.SetProfileType(_windoorModel.WD_profile);
            _frmDimensionPresenter.SetBaseColor(_windoorModel.WD_BaseColor.ToString());
            _frmDimensionPresenter.SetHeight();
            _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);
            _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
        }

        private void OnCreateNewItemClickEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmItem = (ToolStripMenuItem)sender;
            if (tsmItem.Name == "C70ToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "C70 Profile", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
            }
            else if (tsmItem.Name == "PremiLineToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "PremiLine Profile", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
            }
            else if (tsmItem.Name == "G58ToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "G58 Profile", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
            }
        }

        private void OnPanelMainSizeChangedEventRaised(object sender, EventArgs e)
        {
            //Panel pnlMain = (Panel)sender;
            //pnlMain.PerformLayout();
        }

        private void OnNewQuotationMenuItemClickEventRaised(object sender, EventArgs e)
        {
            bool create_new = false;

            if (_quotationModel != null)
            {
                if (MessageBox.Show("Are you sure want to create new Quotation?", "Delete progress",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    create_new = true;
                    Scenario_Quotation(false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                }
            }
            else
            {
                create_new = true;
            }

            if (create_new == true)
            {
                input_qrefno = Interaction.InputBox("Quotation Reference No.", "Windoor Maker", "");
                if (input_qrefno != "" && input_qrefno != "0")
                {
                    Scenario_Quotation(true, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
                }
            }
        }

        private void OnNewFrameButtonClickEventRaised(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender;
            if (tsb.Name == "tsBtnNwin")
            {
                frameType = FrameModel.Frame_Padding.Window;
            }
            else if (tsb.Name == "tsBtnNdoor")
            {
                frameType = FrameModel.Frame_Padding.Door;
            }
            Scenario_Quotation(false, false, true, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Frame, 0, 0, "", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
        }
        string[] file_lines;
        bool onload = false;
        BackgroundWorker bgw = new BackgroundWorker();
        BackgroundWorker updatefile_bgw = new BackgroundWorker();
        private void OnOpenToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_mainView.GetOpenFileDialog().ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialogResult = DialogResult.No;
                    if (!string.IsNullOrWhiteSpace(wndrFileName) && GetMainView().GetToolStripButtonSave().Enabled == true)
                    {
                        dialogResult = MessageBox.Show("Do you want to save changes in " + wndrFileName, "Delete progress",
                                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    }

                    if (dialogResult == DialogResult.Yes ||
                        dialogResult == DialogResult.No)
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            SaveChanges();
                        }
                        Clearing_Operation();
                        wndrProjectFileName = _mainView.GetOpenFileDialog().FileName;
                        isNewProject = false;
                        isOpenProject = true;
                        wndrfile = _mainView.GetOpenFileDialog().FileName;
                        csfunc.DecryptFile(wndrfile);
                        int startFileName = wndrfile.LastIndexOf("\\") + 1;
                        wndrFileName = wndrfile.Substring(startFileName);
                        string outFile = wndrfile.Substring(0, startFileName) +
                                         wndrfile.Substring(startFileName, wndrfile.LastIndexOf(".") - startFileName) + ".txt";

                        file_lines = File.ReadAllLines(outFile);
                        File.SetAttributes(outFile, FileAttributes.Hidden);
                        onload = true;
                        _mainView.GetTsProgressLoading().Maximum = file_lines.Length;
                        _basePlatformImagerUCPresenter.SendToBack_baseImager();
                        StartWorker("Open_WndrFiles");
                    }
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show("Corrupted file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartWorker(string todo)
        {
            if (bgw.IsBusy != true)
            {
                mainTodo = todo;
                bgw.RunWorkerAsync();
                if (todo == "Open_WndrFiles")
                {
                    _mainView.GetToolStripLabelLoading().Text = "Initializing";
                    ToggleMode(true, false);
                }
                else
                {
                    ToggleMode(false, false);
                }

            }
            else
            {
                MessageBox.Show(_mainView.GetThis(), "Please Wait!", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ToggleMode(bool visibility, bool enabled)
        {
            _mainView.GetToolStripLabelLoading().Visible = visibility;
            _mainView.GetTsProgressLoading().Visible = visibility;

            _mainView.GetMNSMainMenu().Enabled = enabled;
            _mainView.GetSCMain().Enabled = enabled;
            _mainView.GetPanelRight().Enabled = enabled;
            _mainView.GetTSMain().Enabled = enabled;
        }
        private void OnMainViewClosingEventRaised(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            _loginView.CloseLoginView();
        }

        private void OnMainViewLoadEventRaised(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FirstTym == true)
            {
                string defDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Windoor Maker files";
                Directory.CreateDirectory(defDir);
                MessageBox.Show("Your default sync directory >> " + defDir + "\n\nYou can change sync directory anytime at 'Tools' > 'Change sync directory'",
                                "Sync directory",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Properties.Settings.Default.WndrDir = defDir;
                Properties.Settings.Default.FirstTym = false;
            }
            _mainView.Nickname = _userModel.Nickname;
            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Multi-Panel (Transom)", new Thumbs_MultiPanelTransomUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Multi-Panel (Mullion)", new Thumbs_MultiPanelMullionUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Louver Panel", new Thumbs_LouverPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "TiltNTurn Panel", new Thumbs_TiltNTurnPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Sliding Panel", new Thumbs_SlidingPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Awning Panel", new Thumbs_AwningPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Casement Panel", new Thumbs_CasementPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, _quotationModel, "Fixed Panel", new Thumbs_FixedPanelUC()).GetControlUC());

            _glassThicknessDT.Columns.Add(CreateColumn("TotalThickness", "TotalThickness", "System.Decimal"));
            _glassThicknessDT.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            _glassThicknessDT.Columns.Add(CreateColumn("Single", "Single", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Double", "Double", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Triple", "Triple", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Insulated", "Insulated", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Laminated", "Laminated", "System.Boolean"));

            //single
            _glassThicknessDT.Rows.Add(0.0f, "Unglazed", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(5.0f, "5 mm Clear", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Clear", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tinted Green", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Blue", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tinted Bronze", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Clear with Georgian Bar", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Clear", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Green", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tinted Blue", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(13.0, "13 mm Clear", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(14.0, "14 mm Clear", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(24.0, "24 mm Clear with Georgian Bar", true, false, false, false, false);
            //double insulated
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Clear + 12 + 6 mm Clear", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear Low-e + 12 Ar + 6 mm Clear Low-e", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "6 mm Tempered Clear + 12 + 5 mm Tempered Clear", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "6 mm Tempered Clear Low-e + 12 + 5 mm Tempered Tinted Gray", false, true, false, true, false);
            //double laminated
            _glassThicknessDT.Rows.Add(11.76f, "6 mm Clear + 0.76 + 5 mm Clear", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm Tinted Black+ 0.76 + 5 mm Clear", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear Low-e + 1.52 + 6 mm Tempered Clear Low-e", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(9.58f, "4 mm Tempered Clear Low-e + 1.52 + 4 mm Tempered Clear Low-e", false, true, false, false, true);
            //triple insulated
            _glassThicknessDT.Rows.Add(41.0f, "6 mm Tempered Clear Low-e + 12 + 5 mm Tempered Tinted Gray + 12 + 6 mm Tempered Clear Low-e", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(33.0f, "4 mm Tinted Black + 10 + 5 mm Clear + 10 + 4 mm Tinted Black", false, false, true, true, false);
            //triple laminated
            _glassThicknessDT.Rows.Add(19.04f, "6 mm Clear + 1.52 + 4 mm Clear + 1.52 + 6 mm Clear", false, false, true, false, true);
            _glassThicknessDT.Rows.Add(23.04f, "8 mm Tempered Tinted Green + 1.52 + 4 mm Tempered Clear + 1.52 + 8 mm Tempered Tinted Green", false, false, true, false, true);

            _glassTypeDT.Columns.Add(CreateColumn("GlassType", "GlassType", "System.String"));
            _spacerDT.Columns.Add(CreateColumn("Spacer", "Spacer", "System.String"));
            _colorDT.Columns.Add(CreateColumn("Color", "Color", "System.String"));

            _glassTypeDT.Rows.Add("Annealed");
            _glassTypeDT.Rows.Add("Tempered");
            _glassTypeDT.Rows.Add("Unglazed");

            _spacerDT.Rows.Add("Air");
            _spacerDT.Rows.Add("Argon");

            _colorDT.Rows.Add("Clear");
            _colorDT.Rows.Add("Tinted Gray");
            _colorDT.Rows.Add("Tinted Bronze");
            _colorDT.Rows.Add("Tinted Green");
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.DoWork += Bgw_DoWork;
        }
        private void _mainView_addProjectsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                IAssignAEPresenter addProj = _addProjPresenter.GetNewInstance(_unityC, this);
                addProj.Set_UserModel(_userModel);
                addProj.ShowThisView();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _mainView_existingItemToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_mainView.GetOpenFileDialog().ShowDialog() == DialogResult.OK)
                {
                    SetChangesMark();
                    _isOpenProject = false;
                    wndrfile = _mainView.GetOpenFileDialog().FileName;
                    csfunc.DecryptFile(wndrfile);
                    int startFileName = wndrfile.LastIndexOf("\\") + 1;
                    string outFile = wndrfile.Substring(0, startFileName) +
                                     wndrfile.Substring(startFileName, wndrfile.LastIndexOf(".") - startFileName) + ".txt";

                    file_lines = File.ReadAllLines(outFile);
                    File.SetAttributes(outFile, FileAttributes.Hidden);
                    onload = true;
                    _mainView.GetTsProgressLoading().Maximum = file_lines.Length;
                    _basePlatformImagerUCPresenter.SendToBack_baseImager();
                    StartWorker("Open_WndrFiles");
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show("Corrupted file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _mainView_SortItemButtonClickEventRaised(object sender, EventArgs e)
        {
            ISortItemPresenter sortItem = _sortItemPresenter.GetNewInstance(_unityC, _quotationModel, _sortItemUCPresenter, _windoorModel, this);
            sortItem.GetSortItemView().showSortItem();
        }
        private void _mainView_ItemsDragEventRaiseEvent(object sender, DragEventArgs e)
        {
            #region ItemsDrag
            //Point p = _mainView.GetPanelItems().PointToClient(new Point(e.X, e.Y));
            //var item = _mainView.GetPanelItems().GetChildAtPoint(p);
            //int index = _mainView.GetPanelItems().Controls.GetChildIndex(item, false);
            //IItemInfoUC lbl = e.Data.GetData("PresentationLayer.Views.UserControls.ItemInfoUC") as IItemInfoUC;
            //foreach (IItemInfoUC ctrl in _mainView.GetPanelItems().Controls)
            //{
            //    if(lbl.WD_Item == ctrl.WD_Item)
            //    {
            //        _mainView.GetPanelItems().Controls.SetChildIndex((UserControl)ctrl, index);
            //        MessageBox.Show(ctrl.WD_Item);

            //    }
            //}
            //_mainView.GetPanelItems().Controls.SetChildIndex((UserControl)e.Data.GetData(e.Data.GetFormats()[0]), index);
            //List<IWindoorModel> lstwndr = new List<IWindoorModel>();
            //foreach (UserControl uc in _mainView.GetPanelItems().Controls)
            //{
            //    for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            //    {
            //        IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
            //        if (uc.Name == wdm.WD_name)
            //        {
            //            wdm.WD_name = "Item " + itemCount;
            //            lstwndr.Add(wdm);
            //        }
            //    }
            //}
            //lstwndr.Reverse();
            //_quotationModel.Lst_Windoor.Clear();
            //_quotationModel.Lst_Windoor = lstwndr;
            //int itemCount = 1;
            //foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            //{
            //    wdm.WD_name = "Item " + itemCount;
            //    itemCount++;
            //}
            //_mainView.GetPanelItems().Invalidate();
            #endregion
        }
        private void _mainView_ViewImagerToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            toggle = !toggle;
            if (toggle == true)
            {
                _basePlatformImagerUCPresenter.BringToFront_baseImager();
            }
            else if (toggle == false)
            {
                _basePlatformImagerUCPresenter.SendToBack_baseImager();
            }
        }
        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (mainTodo)
                {
                    case "Open_WndrFiles":
                        Opening_dotwndr(e.ProgressPercentage);
                        _mainView.GetTsProgressLoading().Value = e.ProgressPercentage;
                        if (_mainView.GetToolStripLabelLoading().Text != "Initializing...")
                        {
                            _mainView.GetToolStripLabelLoading().Text += ".";
                        }
                        else
                        {
                            _mainView.GetToolStripLabelLoading().Text = "Initializing";
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (mainTodo)
                {
                    case "Open_WndrFiles":
                        for (int i = 0; i < file_lines.Length; i++)
                        {
                            if (bgw.CancellationPending == true)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                bgw.ReportProgress(i);
                            }
                        }
                        //e.Result = e.Argument.ToString();
                        break;

                    //case "GetCloudFiles":
                    //    var objds = csq.CostingQuery_ReturnDS("GetCloudFiles", "", (int)info[0]);
                    //    sql_Transaction_result = objds.Item1;
                    //    e.Result = objds.Item2;
                    //    break;

                    default:
                        break;
                }
            }
            catch (SqlException ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                if (ex.Number == -2)
                {
                    MessageBox.Show("Request timed out", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (ex.Number == 1232)
                {
                    MessageBox.Show("Please check internet connection", "Network Disconnected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 19)
                {
                    MessageBox.Show("Server is down", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message);
                ToggleMode(false, true);
            }
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null || e.Cancelled == true)
                {
                    _mainView.GetToolStripLabelLoading().Text = "Error";
                    ToggleMode(false, true);
                    _mainView.GetToolStripLabelLoading().Visible = true;
                    onload = false;
                }
                else
                {
                    switch (mainTodo)
                    {
                        case "Open_WndrFiles":

                            _mainView.GetToolStripLabelLoading().Text = "Finished";
                            ToggleMode(false, true);
                            _mainView.GetToolStripLabelLoading().Visible = true;
                            //autoDescription = true;
                            onload = false;
                            //tmr_fadeOutText.Enabled = true;
                            //tmr_fadeOutText.Start();

                            int startFileName = wndrfile.LastIndexOf("\\") + 1;
                            string outFile = wndrfile.Substring(0, startFileName) +
                                             wndrfile.Substring(startFileName, wndrfile.LastIndexOf(".") - startFileName) + ".txt";
                            File.Delete(outFile);
                            SetMainViewTitle(input_qrefno,
                                             _projectName,
                                             _custRefNo,
                                             _windoorModel.WD_name,
                                             _windoorModel.WD_profile,
                                             true);
                            break;

                        case "GetCloudFiles":
                        //if (sql_Transaction_result == "Committed")
                        //{
                        //    frmQuoteList frm = new frmQuoteList();
                        //    frm.ds = (DataSet)e.Result;
                        //    ToggleMode(false, true);
                        //    frm.info = info;
                        //    if (frm.ShowDialog() == DialogResult.OK)
                        //    {
                        //        Clearing_Operation();


                        //        wndrfile = frm.FileName;

                        //        csfunc.DecryptFile(wndrfile);

                        //        int startFileName1 = wndrfile.LastIndexOf("\\") + 1;
                        //        string outFile1 = wndrfile.Substring(0, startFileName1) +
                        //                         wndrfile.Substring(startFileName1, wndrfile.LastIndexOf(".") - startFileName1) + ".txt";

                        //        file_lines = File.ReadAllLines(outFile1);
                        //        File.SetAttributes(outFile1, FileAttributes.Hidden);
                        //        tsprogress_Loading.Maximum = file_lines.Length;

                        //        autoDescription = false;
                        //        onload = true;

                        //        StartWorker("Open_WndrFiles");
                        //    }
                        //}
                        //else
                        //{
                        //    ToggleMode(false, true);
                        //}
                        //break;

                        default:
                            break;
                    }
                    //sql_Transaction_result = "";
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }
        private void Opening_dotwndr(int row)
        {
            string row_str = file_lines[row].Replace("\t", "");
            string extractedValue_str = string.Empty;
            if (!string.IsNullOrWhiteSpace(row_str))
            {
                extractedValue_str = row_str.Substring(row_str.IndexOf(": ") + 2);
            }
            if (row_str.Contains("QuoteId:"))
            {
                if (_isOpenProject && !isNewProject)
                {
                    inside_quotation = true;
                }
            }
            else if (row_str == "(")
            {
                inside_item = true;
            }
            else if (row_str == "{")
            {
                inside_frame = true;

            }
            else if (row_str.Contains("#"))
            {
                inside_panel = true;
            }
            else if (file_lines[row].Contains("\t["))
            {
                if (file_lines[row].ToString() == "\t[")
                {
                    mpnllvl = "second level";
                }
                else
                {
                    mpnllvl = "third level";
                }
                inside_multi = true;
            }

            else if (row_str.Contains("|"))
            {
                inside_divider = true;
            }
            else if (row_str == "}")
            {
                frmDimension_numWd = 0; ;
                frmDimension_numHt = 0;
                frmDimension_profileType = "";
                frmDimension_baseColor = "";
            }

            else if (row_str == ")")
            {
                int itemCount = 1;
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {

                    wdm.WD_name = "Item " + itemCount;
                    itemCount++;
                }
                //_basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                //UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                //_mainView.GetThis().Controls.Add(bpUC);
                //foreach (IFrameModel frame in _windoorModel.lst_frame)
                //{
                //    _pnlPropertiesBody.Controls.Add((UserControl)frame.Frame_PropertiesUC);
                //    _basePlatformPresenter.AddFrame((IFrameUC)frame.Frame_UC);
                //}

                //_mainView.RemoveBinding(_mainView.GetLblSize());
                //_mainView.RemoveBinding();
                //_mainView.ThisBinding(CreateBindingDictionary_MainPresenter());

            }
            if (row_str == "EndofFile")
            {
                Load_Windoor_Item(_windoorModel);
            }
            switch (inside_quotation)
            {
                case true:
                    #region Load for Quotation Model


                    if (row_str.Contains("QuoteId"))
                    {
                        _quoteId = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("ProjectName"))
                    {
                        _projectName = extractedValue_str;
                    }
                    else if (row_str.Contains("CustomerRefNo"))
                    {
                        _custRefNo = extractedValue_str;
                    }
                    else if (row_str.Contains("Quotation_ref_no"))
                    {
                        inputted_quotationRefNo = extractedValue_str;
                    }
                    else if (row_str.Contains("Quotation_Date"))
                    {
                        inputted_quoteDate = Convert.ToDateTime(extractedValue_str);
                        Scenario_Quotation(false, false, false, false, true, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                        _quotationModel.Quotation_ref_no = inputted_quotationRefNo;
                    }
                    else if (row_str.Contains("Frame_PUFoamingQty_Total"))
                    {
                        _quotationModel.Frame_PUFoamingQty_Total = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("Frame_SealantWHQty_Total"))
                    {
                        _quotationModel.Frame_SealantWHQty_Total = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("Glass_SealantWHQty_Total"))
                    {
                        _quotationModel.Glass_SealantWHQty_Total = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("GlazingSpacer_TotalQty"))
                    {
                        _quotationModel.GlazingSpacer_TotalQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("GlazingSeal_TotalQty"))
                    {
                        _quotationModel.GlazingSeal_TotalQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("Screws_for_Fabrication"))
                    {
                        _quotationModel.Screws_for_Fabrication = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("Expansion_BoltQty_Total"))
                    {
                        _quotationModel.Expansion_BoltQty_Total = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                    }
                    else if (row_str.Contains("Screws_for_Installation"))
                    {
                        _quotationModel.Screws_for_Installation = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                    }
                    else if (row_str.Contains("Screws_for_Cladding"))
                    {
                        _quotationModel.Screws_for_Cladding = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("Rebate_Qty"))
                    {
                        _quotationModel.Rebate_Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                    }
                    else if (row_str.Contains("Plastic_CoverQty_Total"))
                    {
                        _quotationModel.Plastic_CoverQty_Total = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        inside_quotation = false;
                    }
                    break;
                #endregion
                case false:
                    if (inside_item)
                    {
                        #region Load for Windoor Model
                        if (row_str.Contains("WD_profile:"))
                        {
                            frmDimension_profileType = extractedValue_str;
                        }
                        if (row_str.Contains("WD_height:"))
                        {
                            frmDimension_numHt = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_BaseColor:"))
                        {
                            frmDimension_baseColor = extractedValue_str;
                        }
                        if (row_str.Contains("WD_width:"))
                        {
                            frmDimension_numWd = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            Scenario_Quotation(false,
                                     true,
                                     false,
                                     false,
                                     true,
                                     frmDimensionPresenter.Show_Purpose.CreateNew_Item,
                                     frmDimension_numWd,
                                     frmDimension_numHt,
                                     frmDimension_profileType,
                                     frmDimension_baseColor);
                        }
                        if (row_str.Contains("WD_name:"))
                        {
                            _windoorModel.WD_name = extractedValue_str;
                        }
                        if (row_str.Contains("WD_description:"))
                        {
                            _windoorModel.WD_description = extractedValue_str;
                        }

                        if (row_str.Contains("WD_discount:"))
                        {
                            //_windoorModel.WD_discount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }

                        if (row_str.Contains("WD_height_4basePlatform:"))
                        {
                            _windoorModel.WD_height_4basePlatform = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_height_4basePlatform_forImageRenderer:"))
                        {
                            _windoorModel.WD_height_4basePlatform_forImageRenderer = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_id:"))
                        {
                            _windoorModel.WD_id = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }

                        if (row_str.Contains("WD_orientation:"))
                        {
                            _windoorModel.WD_orientation = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("WD_price:"))
                        {
                            _windoorModel.WD_price = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_quantity:"))
                        {
                            _windoorModel.WD_quantity = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_visibility:"))
                        {
                            _windoorModel.WD_visibility = Convert.ToBoolean(extractedValue_str);
                        }

                        if (row_str.Contains("WD_width_4basePlatform:"))
                        {
                            _windoorModel.WD_width_4basePlatform = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_width_4basePlatform_forImageRenderer:"))
                        {
                            _windoorModel.WD_width_4basePlatform_forImageRenderer = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_zoom:"))
                        {
                            _windoorModel.WD_zoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_zoom_forImageRenderer:"))
                        {
                            //_windoorModel.WD_zoom_forImageRenderer = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_PropertiesScroll:"))
                        {
                            _windoorModel.WD_PropertiesScroll = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_SlidingTopViewVisibility:"))
                        {
                            _windoorModel.WD_SlidingTopViewVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("frameIDCounter:"))
                        {
                            _windoorModel.frameIDCounter = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("concreteIDCounter:"))
                        {
                            _windoorModel.concreteIDCounter = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("panelIDCounter:"))
                        {
                            int strCount = row_str.IndexOf(":");
                            if (strCount == 14)
                            {
                                _windoorModel.panelIDCounter = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            }
                        }
                        if (row_str.Contains("mpanelIDCounter:"))
                        {
                            _windoorModel.mpanelIDCounter = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("divIDCounter:"))
                        {
                            _windoorModel.divIDCounter = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("PanelGlassID_Counter:"))
                        {
                            _windoorModel.PanelGlassID_Counter = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }

                        if (row_str.Contains("WD_InsideColor:"))
                        {
                            foreach (Foil_Color color in Foil_Color.GetAll())
                            {
                                string asd = extractedValue_str;
                                if (color.ToString() == extractedValue_str)
                                {
                                    _windoorModel.WD_InsideColor = color;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("WD_OutsideColor:"))
                        {
                            foreach (Foil_Color color in Foil_Color.GetAll())
                            {
                                if (color.ToString() == extractedValue_str)
                                {
                                    _windoorModel.WD_OutsideColor = color;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("WD_PlasticCover:"))
                        {
                            _windoorModel.WD_PlasticCover = Convert.ToDecimal(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_CmenuDeleteVisibility:"))
                        {
                            _windoorModel.WD_CmenuDeleteVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("WD_Selected:"))
                        {
                            _windoorModel.WD_Selected = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Lbl_ArrowHtCount:"))
                        {
                            _windoorModel.Lbl_ArrowHtCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Lbl_ArrowWdCount:"))
                        {
                            _windoorModel.Lbl_ArrowWdCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Div_ArrowCount:"))
                        {
                            _windoorModel.Div_ArrowCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_customArrowToggle:"))
                        {
                            _windoorModel.WD_customArrowToggle = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("WD_CostingPoints:"))
                        {
                            _windoorModel.WD_CostingPoints = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_pboxImagerHeight:"))
                        {
                            _windoorModel.WD_pboxImagerHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            inside_item = false;
                        }
                        #endregion
                    }
                    else if (inside_frame)
                    {
                        #region Load for Frame Model


                        if (row_str.Contains("Frame_Height:"))
                        {
                            frmDimension_numHt = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Width:"))
                        {
                            frmDimension_numWd = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            Scenario_Quotation(false,
                                     true,
                                     false,
                                     false,
                                     true,
                                     frmDimensionPresenter.Show_Purpose.CreateNew_Frame,
                                     frmDimension_numWd,
                                     frmDimension_numHt,
                                     frmDimension_profileType,
                                     frmDimension_baseColor);
                        }
                        if (row_str.Contains("Frame_BasicDeduction:"))
                        {
                        }
                        if (row_str.Contains("Frame_HeightToBind:"))
                        {
                            _frameModel.Frame_HeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        if (row_str.Contains("FrameImageRenderer_Height:"))
                        {
                            _frameModel.FrameImageRenderer_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ID:"))
                        {
                            _frameModel.Frame_ID = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Type:"))
                        {
                            if (row_str.Contains("Window"))
                            {
                                _frameModel.Frame_Type = FrameModel.Frame_Padding.Window;
                            }
                            else
                            {
                                _frameModel.Frame_Type = FrameModel.Frame_Padding.Door;
                            }
                        }
                        if (row_str.Contains("Frame_Name:"))
                        {
                            _frameModel.Frame_Name = extractedValue_str;
                        }

                        if (row_str.Contains("Frame_WidthToBind:"))
                        {
                            _frameModel.Frame_WidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("FrameImageRenderer_Width:"))
                        {
                            _frameModel.FrameImageRenderer_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Visible:"))
                        {
                            _frameModel.Frame_Visible = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("FrameProp_Height:"))
                        {
                            _frameModel.FrameProp_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("FrameImageRenderer_Zoom:"))
                        {
                            _frameModel.FrameImageRenderer_Zoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Zoom:"))
                        {
                            _frameModel.Frame_Zoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_BotFrameEnable:"))
                        {
                            _frameModel.Frame_BotFrameEnable = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Deduction:"))
                        {
                        }
                        if (row_str.Contains("Frame_ExplosionWidth:"))
                        {
                            _frameModel.Frame_ExplosionWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ExplosionHeight:"))
                        {
                            _frameModel.Frame_ExplosionHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ReinfWidth:"))
                        {
                            _frameModel.Frame_ReinfWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ReinfHeight:"))
                        {
                            _frameModel.Frame_ReinfHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_CmenuDeleteVisibility:"))
                        {
                            _frameModel.Frame_CmenuDeleteVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_If_InwardMotorizedCasement:"))
                        {
                            _frameModel.Frame_If_InwardMotorizedCasement = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_MilledArtNo:"))
                        {
                            foreach (MilledFrame_ArticleNo artcNo in MilledFrame_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_MilledArtNo = artcNo;
                                    break;
                                }
                            }

                        }
                        if (row_str.Contains("Frame_MilledReinfArtNo:"))
                        {
                            foreach (MilledFrameReinf_ArticleNo artcNo in MilledFrameReinf_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_MilledReinfArtNo = artcNo;
                                    break;
                                }
                            }
                            inside_frame = false;


                        }
                        if (row_str.Contains("Frame_ArtNo:"))
                        {
                            foreach (FrameProfile_ArticleNo artcNo in FrameProfile_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_ArtNo = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ReinfArtNo:"))
                        {
                            foreach (FrameReinf_ArticleNo artcNo in FrameReinf_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_ReinfArtNo = artcNo;
                                    break;
                                }
                            }
                        }

                        if (row_str.Contains("Frame_BotFrameArtNo:"))
                        {
                            foreach (BottomFrameTypes artcNo in BottomFrameTypes.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_BotFrameArtNo = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_BotFrameVisible:"))
                        {
                            _frameModel.Frame_BotFrameVisible = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_SlidingRailsQty:"))
                        {
                            _frameModel.Frame_SlidingRailsQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_SlidingRailsQtyVisibility:"))
                        {
                            _frameModel.Frame_SlidingRailsQtyVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ConnectionType:"))
                        {
                            foreach (FrameConnectionType artcNo in FrameConnectionType.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_ConnectionType = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ConnectionTypeVisibility:"))
                        {
                            _frameModel.Frame_ConnectionTypeVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ArtNoForPremi:"))
                        {
                            foreach (FrameProfileForPremi_ArticleNo artcNo in FrameProfileForPremi_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_ArtNoForPremi = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ExplosionWidth:"))
                        {
                            _frameModel.Frame_ExplosionWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ReinfForPremiArtNo:"))
                        {
                            foreach (FrameReinfForPremi_ArticleNo artcNo in FrameReinfForPremi_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    _frameModel.Frame_ReinfForPremiArtNo = artcNo;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    else if (inside_panel)
                    {
                        #region Load for Panel


                        if (row_str.Contains("Panel_ChkText:"))
                        {
                            panel_ChkText = extractedValue_str;
                        }
                        if (row_str.Contains("Panel_Dock:"))
                        {
                            switch (extractedValue_str)
                            {
                                case "Fill":
                                    panel_Dock = DockStyle.Fill;
                                    break;
                                case "None":
                                    panel_Dock = DockStyle.None;
                                    break;
                            }
                        }
                        if (row_str.Contains("Panel_Parent:"))
                        {
                            if (!string.IsNullOrWhiteSpace(extractedValue_str))
                            {
                                if (row_str.Contains("FrameUC"))
                                {
                                    panel_Parent = _frameModel.Frame_UC;
                                }
                                else
                                {
                                    if (_multiPanelModel.MPanel_Type == "Mullion")
                                    {
                                        panel_Parent = _multiMullionUC.Getflp();

                                    }
                                    else
                                    {
                                        panel_Parent = _multiTransomUC.Getflp();
                                    }
                                }
                            }
                        }
                        if (row_str.Contains("Panel_MultiPanelGroup:"))
                        {
                            if (!string.IsNullOrWhiteSpace(extractedValue_str))
                            {
                                if (row_str.Contains("FrameUC"))
                                {
                                    panel_FrameGroup = _frameModel.Frame_UC;
                                }
                                else
                                {
                                    if (_multiPanelModel.MPanel_Type == "Mullion")
                                    {
                                        panel_FrameGroup = (UserControl)_multiMullionUC;

                                    }
                                    else
                                    {
                                        panel_FrameGroup = (UserControl)_multiTransomUC;
                                    }
                                }
                            }
                        }
                        if (row_str.Contains("Panel_FrameGroup:"))
                        {
                            panel_FrameGroup = _frameModel.Frame_UC;

                        }
                        if (row_str.Contains("Panel_FramePropertiesGroup:"))
                        {
                            panel_FramePropertiesGroup = _frameModel.Frame_PropertiesUC;
                        }
                        if (row_str.Contains("Panel_Height:"))
                        {
                            panel_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_OriginalHeight:"))
                        {
                            panel_OriginalHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("PanelImageRenderer_Height:"))
                        {
                            panel_ImageRenderer_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_HeightToBind:"))
                        {
                            panel_HeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_DisplayHeight:"))
                        {
                            panel_DisplayHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_DisplayHeightDecimal:"))
                        {
                            panel_DisplayHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_OriginalDisplayHeight:"))
                        {
                            panel_OriginalDisplayHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_OriginalDisplayHeightDecimal:"))
                        {
                            panel_OriginalDisplayHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_ID:"))
                        {
                            panel_ID = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_Name:"))
                        {
                            panel_Name = extractedValue_str;
                        }
                        if (row_str.Contains("Panel_Orient:"))
                        {
                            panel_Orient = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_OrientVisibility:"))
                        {
                            panel_OrientVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_Type:"))
                        {
                            panel_Type = extractedValue_str;
                        }
                        if (row_str.Contains("Panel_Width:"))
                        {
                            panel_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_OriginalWidth:"))
                        {
                            panel_OriginalWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("PanelImageRenderer_Width:"))
                        {
                            panel_ImageRenderer_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_WidthToBind:"))
                        {
                            panel_WidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_DisplayWidth:"))
                        {
                            panel_DisplayWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_DisplayWidthDecimal:"))
                        {
                            panel_DisplayWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_OriginalDisplayWidth:"))
                        {
                            panel_OriginalDisplayWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        if (row_str.Contains("Panel_OriginalDisplayWidthDecimal:"))
                        {
                            panel_OriginalDisplayWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_Visibility:"))
                        {
                            panel_Visibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("PanelImageRenderer_Zoom:"))
                        {
                            panel_ImageRendererZoom = float.Parse(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_Index_Inside_MPanel:"))
                        {
                            panel_Index_Inside_MPanel = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_Index_Inside_SPanel:"))
                        {
                            panel_Index_Inside_SPanel = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        if (row_str.Contains("Panel_Placement:"))
                        {
                            panel_Placement = extractedValue_str;
                        }
                        if (row_str.Contains("Panel_Overlap_Sash:"))
                        {
                            foreach (OverlapSash pnl_ovrlpsash in OverlapSash.GetAll())
                            {
                                if (pnl_ovrlpsash.ToString() == extractedValue_str)
                                {
                                    panel_OverlapSash = pnl_ovrlpsash;
                                }
                            }
                        }
                        if (extractedValue_str.Contains("Margin"))
                        {
                            string[] arr = extractedValue_str.Split(new char[] { ',' }, StringSplitOptions.None);
                            Padding marginPad = new Padding(Convert.ToInt32(Regex.Match(arr[0], @"\d+").ToString()),
                                                            Convert.ToInt32(Regex.Match(arr[1], @"\d+").ToString()),
                                                            Convert.ToInt32(Regex.Match(arr[2], @"\d+").ToString()),
                                                            Convert.ToInt32(Regex.Match(arr[3], @"\d+").ToString())
                                                            );
                            if (row_str.Contains("Panel_Margin:"))
                            {
                                panel_Margin = marginPad;
                            }
                            if (row_str.Contains("Panel_MarginToBind:"))
                            {

                                panel_MarginToBind = marginPad;
                            }
                            if (row_str.Contains("PanelImageRenderer_Margin:"))
                            {
                                panel_ImageRenderer_Margin = marginPad;
                            }
                        }
                        if (row_str.Contains("Panel_Zoom:"))
                        {

                            panel_Zoom = float.Parse(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_ParentMultiPanelModel:"))
                        {
                            //panel_ParentMultiPanelModel = _multiPanelModel;
                        }
                        if (row_str.Contains("Panel_PropertyHeight:"))
                        {
                            //panel_PropertyHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_HandleOptionsVisibility:"))
                        {
                            panel_HandleOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_RotoswingOptionsVisibility:"))
                        {
                            panel_RotoswingOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_RioOptionsVisibility:"))
                        {
                            panel_RioOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_RioOptionsVisibility2:"))
                        {
                            panel_RioOptionsVisibility2 = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_RotolineOptionsVisibility:"))
                        {
                            panel_RotolineOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_MVDOptionsVisibility:"))
                        {
                            panel_MVDOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_RotaryOptionsVisibility:"))
                        {
                            panel_RotaryOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Panel_HandleOptionsHeight:"))
                        {
                            panel_HandleOptionsHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_LouverBladesCount:"))
                        {
                            panel_LouverBladesCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Panel_BackColor:"))
                        {
                            panel_BackColor = ColorTranslator.FromHtml(row_str.Substring(row_str.IndexOf("[") + 1, row_str.IndexOf("]") - 1 - row_str.IndexOf("[")));
                        }
                        if (row_str.Contains("Panel_SlidingTypes:"))
                        {
                            foreach (SlidingTypes pnl_slidingType in SlidingTypes.GetAll())
                            {
                                int ass = row_str.IndexOf(":");
                                string asda = extractedValue_str;
                                if (pnl_slidingType.ToString() == extractedValue_str)
                                {
                                    panel_SlidingTypes = pnl_slidingType;
                                }
                            }
                        }
                        if (row_str.Contains("Panel_SlidingTypeVisibility:"))
                        {
                            panel_SlidingTypeVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        //Explosion
                        else if (row_str.Contains("PanelGlass_ID:"))
                        {
                            panel_GlassID = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassThicknessDesc:"))
                        {
                            panel_GlassThicknessDesc = extractedValue_str;
                        }
                        else if (row_str.Contains("Panel_GlassThickness:"))
                        {
                            panel_GlassThickness = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("PanelGlazingBead_ArtNo:"))
                        {
                            foreach (GlazingBead_ArticleNo gban in GlazingBead_ArticleNo.GetAll())
                            {
                                if (gban.ToString() == extractedValue_str)
                                {
                                    panel_GlazingBeadArtNo = gban;
                                }
                            }

                        }
                        else if (row_str.Contains("Panel_GlazingAdaptorArtNo:"))
                        {
                            foreach (GlazingAdaptor_ArticleNo gaan in GlazingAdaptor_ArticleNo.GetAll())
                            {
                                if (gaan.ToString() == extractedValue_str)
                                {
                                    panel_GlazingAdaptorArtNo = gaan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GBSpacerArtNo:"))
                        {
                            foreach (GBSpacer_ArticleNo gaan in GBSpacer_ArticleNo.GetAll())
                            {
                                if (gaan.ToString() == extractedValue_str)
                                {
                                    panel_GBSpacerArtNo = gaan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ChkGlazingAdaptor:"))
                        {

                            panel_ChkGlazingAdaptor = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlazingBeadWidth:"))
                        {
                            panel_GlazingBeadWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlazingBeadWidthDecimal:"))
                        {
                            panel_GlazingBeadWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlazingBeadHeight:"))
                        {
                            panel_GlazingBeadHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlazingBeadHeightDecimal:"))
                        {
                            panel_GlazingBeadHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassWidth:"))
                        {
                            panel_GlassWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassWidthDecimal:"))
                        {
                            panel_GlassWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalGlassWidth:"))
                        {
                            panel_OriginalGlassWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalGlassWidthDecimal:"))
                        {
                            panel_OriginalGlassWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassHeight:"))
                        {
                            panel_GlassHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassHeightDecimal:"))
                        {
                            panel_GlassHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalGlassHeight:"))
                        {
                            panel_OriginalGlassHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalGlassHeightDecimal:"))
                        {
                            panel_OriginalGlassHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassPropertyHeight:"))
                        {
                            //panel_GlassPropertyHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlazingSpacerQty:"))
                        {
                            panel_GlazingSpacerQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassFilm:"))
                        {
                            foreach (GlassFilm_Types gft in GlassFilm_Types.GetAll())
                            {
                                if (gft.ToString() == extractedValue_str)
                                {
                                    panel_GlassFilm = gft;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SashPropertyVisibility:"))
                        {
                            panel_SashPropertyVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashProfileArtNo:"))
                        {
                            foreach (SashProfile_ArticleNo span in SashProfile_ArticleNo.GetAll())
                            {
                                if (span.ToString() == extractedValue_str)
                                {
                                    panel_SashProfileArtNo = span;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SashReinfArtNo:"))
                        {
                            foreach (SashReinf_ArticleNo sran in SashReinf_ArticleNo.GetAll())
                            {
                                if (sran.ToString() == extractedValue_str)
                                {
                                    panel_SashReinfArtNo = sran;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SashWidth:"))
                        {
                            panel_SashWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashWidthDecimal:"))
                        {
                            panel_SashWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashHeight:"))
                        {
                            panel_SashHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashHeightDecimal:"))
                        {
                            panel_SashHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalSashWidth:"))
                        {
                            panel_OriginalSashWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalSashWidthDecimal:"))
                        {
                            panel_OriginalSashWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalSashHeight:"))
                        {
                            panel_OriginalSashHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_OriginalSashHeightDecimal:"))
                        {
                            panel_OriginalSashHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashReinfWidth:"))
                        {
                            panel_SashReinfWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashReinfWidthDecimal:"))
                        {
                            panel_SashReinfWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashReinfHeight:"))
                        {
                            panel_SashReinfHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SashReinfHeightDecimal:"))
                        {
                            panel_SashReinfHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_CoverProfileArtNo:"))
                        {
                            foreach (CoverProfile_ArticleNo cpan in CoverProfile_ArticleNo.GetAll())
                            {
                                if (cpan.ToString() == extractedValue_str)
                                {
                                    panel_CoverProfileArtNo = cpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverProfileArtNo2:"))
                        {
                            foreach (CoverProfile_ArticleNo cpan in CoverProfile_ArticleNo.GetAll())
                            {
                                if (cpan.ToString() == extractedValue_str)
                                {
                                    panel_CoverProfileArtNo2 = cpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FrictionStayArtNo:"))
                        {
                            foreach (FrictionStay_ArticleNo fsan in FrictionStay_ArticleNo.GetAll())
                            {
                                if (fsan.ToString() == extractedValue_str)
                                {
                                    panel_FrictionStayArtNo = fsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FSCasementArtNo:"))
                        {
                            foreach (FrictionStayCasement_ArticleNo fscan in FrictionStayCasement_ArticleNo.GetAll())
                            {
                                if (fscan.ToString() == extractedValue_str)
                                {
                                    panel_FSCasementArtNo = fscan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SnapInKeepArtNo:"))
                        {
                            foreach (SnapInKeep_ArticleNo sikan in SnapInKeep_ArticleNo.GetAll())
                            {
                                if (sikan.ToString() == extractedValue_str)
                                {
                                    panel_SnapInKeepArtNo = sikan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FixedCamArtNo:"))
                        {
                            foreach (FixedCam_ArticleNo fcan in FixedCam_ArticleNo.GetAll())
                            {
                                if (fcan.ToString() == extractedValue_str)
                                {
                                    panel_FixedCamArtNo = fcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_30x25CoverArtNo:"))
                        {
                            foreach (_30x25Cover_ArticleNo can in _30x25Cover_ArticleNo.GetAll())
                            {
                                if (can.ToString() == extractedValue_str)
                                {
                                    panel_30x25CoverArtNo = can;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_MotorizedDividerArtNo:"))
                        {
                            foreach (MotorizedDivider_ArticleNo mdan in MotorizedDivider_ArticleNo.GetAll())
                            {
                                if (mdan.ToString() == extractedValue_str)
                                {
                                    panel_MotorizedDividerArtNo = mdan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverForMotorArtNo:"))
                        {
                            foreach (CoverForMotor_ArticleNo cfman in CoverForMotor_ArticleNo.GetAll())
                            {
                                if (cfman.ToString() == extractedValue_str)
                                {
                                    panel_CoverForMotorArtNo = cfman;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_2dHingeArtNo:"))
                        {
                            foreach (_2DHinge_ArticleNo han in _2DHinge_ArticleNo.GetAll())
                            {
                                if (han.ToString() == extractedValue_str)
                                {
                                    panel_2dHingeArtNo = han;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PushButtonSwitchArtNo:"))
                        {
                            foreach (PushButtonSwitch_ArticleNo pbsan in PushButtonSwitch_ArticleNo.GetAll())
                            {
                                if (pbsan.ToString() == extractedValue_str)
                                {
                                    panel_PushButtonSwitchArtNo = pbsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FalsePoleArtNo:"))
                        {
                            foreach (FalsePole_ArticleNo fpan in FalsePole_ArticleNo.GetAll())
                            {
                                if (fpan.ToString() == extractedValue_str)
                                {
                                    panel_FalsePoleArtNo = fpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SupportingFrameArtNo:"))
                        {
                            foreach (SupportingFrame_ArticleNo sfan in SupportingFrame_ArticleNo.GetAll())
                            {
                                if (sfan.ToString() == extractedValue_str)
                                {
                                    panel_SupportingFrameArtNo = sfan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PlateArtNo:"))
                        {
                            foreach (Plate_ArticleNo pan in Plate_ArticleNo.GetAll())
                            {
                                if (pan.ToString() == extractedValue_str)
                                {
                                    panel_PlateArtNo = pan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_HandleType:"))
                        {
                            foreach (Handle_Type ht in Handle_Type.GetAll())
                            {
                                if (ht.ToString() == extractedValue_str)
                                {
                                    panel_HandleType = ht;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotoswingArtNo:"))
                        {
                            foreach (Rotoswing_HandleArtNo rhan in Rotoswing_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == extractedValue_str)
                                {
                                    panel_RotoswingArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotaryArtNo:"))
                        {
                            foreach (Rotary_HandleArtNo rhan in Rotary_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == extractedValue_str)
                                {
                                    panel_RotaryArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RioArtNo:"))
                        {
                            foreach (Rio_HandleArtNo rhan in Rio_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == extractedValue_str)
                                {
                                    panel_RioArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RioArtNo2:"))
                        {
                            foreach (Rio_HandleArtNo rhan in Rio_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == extractedValue_str)
                                {
                                    panel_RioArtNo2 = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ProfileKnobCylinderArtNo:"))
                        {
                            foreach (ProfileKnobCylinder_ArtNo pkcan in ProfileKnobCylinder_ArtNo.GetAll())
                            {
                                if (pkcan.ToString() == extractedValue_str)
                                {
                                    panel_ProfileKnobCylinderArtNo = pkcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CylinderCoverArtNo:"))
                        {
                            foreach (Cylinder_CoverArtNo ccan in Cylinder_CoverArtNo.GetAll())
                            {
                                if (ccan.ToString() == extractedValue_str)
                                {
                                    panel_CylinderCoverArtNo = ccan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotolineArtNo:"))
                        {
                            foreach (Rotoline_HandleArtNo rhan in Rotoline_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == extractedValue_str)
                                {
                                    panel_RotolineArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_MVDArtNo:"))
                        {
                            foreach (MVD_HandleArtNo mvdhan in MVD_HandleArtNo.GetAll())
                            {
                                if (mvdhan.ToString() == extractedValue_str)
                                {
                                    panel_MVDArtNo = mvdhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_EspagnoletteArtNo:"))
                        {
                            foreach (Espagnolette_ArticleNo ean in Espagnolette_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_EspagnoletteArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_EspagnoletteOptionsVisibility:"))
                        {
                            panel_EspagnoletteOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtensionTopArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionTopArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionTop2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionTop2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionTop3ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionTop3ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionBotArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionBotArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionBot2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionBot2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionLeftArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionLeftArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionLeft2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionLeft2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionRightArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionRightArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionRight2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionRight2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtTopChk:"))
                        {

                            panel_ExtTopChk = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtTop2Chk:"))
                        {
                            panel_ExtTop2Chk = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtBotChk:"))
                        {
                            panel_ExtBotChk = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtLeftChk:"))
                        {
                            panel_ExtLeftChk = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtRightChk:"))
                        {
                            panel_ExtRightChk = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtTopQty:"))
                        {
                            panel_ExtTopQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtBotQty:"))
                        {
                            panel_ExtBotQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtLeftQty:"))
                        {
                            panel_ExtLeftQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtRightQty:"))
                        {
                            panel_ExtRightQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtTop2Qty:"))
                        {
                            panel_ExtTop2Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtTop3Qty:"))
                        {
                            panel_ExtTop3Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtBot2Qty:"))
                        {
                            panel_ExtBot2Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtLeft2Qty:"))
                        {
                            panel_ExtLeft2Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtRight2Qty:"))
                        {
                            panel_ExtRight2Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_CornerDriveArtNo:"))
                        {
                            foreach (CornerDrive_ArticleNo cdan in CornerDrive_ArticleNo.GetAll())
                            {
                                if (cdan.ToString() == extractedValue_str)
                                {
                                    panel_CornerDriveArtNo = cdan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerDriveOptionsVisibility:"))
                        {
                            panel_CornerDriveOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtensionOptionsVisibility:"))
                        {
                            panel_ExtensionOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_RotoswingOptionsHeight:"))
                        {
                            panel_RotoswingOptionsHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_PlasticWedge:"))
                        {
                            foreach (PlasticWedge_ArticleNo pwan in PlasticWedge_ArticleNo.GetAll())
                            {
                                if (pwan.ToString() == extractedValue_str)
                                {
                                    panel_PlasticWedge = pwan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PlasticWedgeQty:"))
                        {
                            panel_PlasticWedgeQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MiddleCloserArtNo:"))
                        {
                            foreach (MiddleCloser_ArticleNo mcan in MiddleCloser_ArticleNo.GetAll())
                            {
                                if (mcan.ToString() == extractedValue_str)
                                {
                                    panel_MiddleCloserArtNo = mcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LockingKitArtNo:"))
                        {
                            foreach (LockingKit_ArticleNo lkan in LockingKit_ArticleNo.GetAll())
                            {
                                if (lkan.ToString() == extractedValue_str)
                                {
                                    panel_LockingKitArtNo = lkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GlassType:"))
                        {
                            foreach (GlassType gt in GlassType.GetAll())
                            {
                                if (gt.ToString() == extractedValue_str)
                                {
                                    panel_GlassType = gt;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerArtno_A:"))
                        {
                            foreach (Striker_ArticleNo san in Striker_ArticleNo.GetAll())
                            {
                                if (san.ToString() == extractedValue_str)
                                {
                                    panel_StrikerArtno_A = san;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerQty_A:"))
                        {
                            panel_StrikerQty_A = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_StrikerArtno_C:"))
                        {
                            foreach (Striker_ArticleNo san in Striker_ArticleNo.GetAll())
                            {
                                if (san.ToString() == extractedValue_str)
                                {
                                    panel_StrikerArtno_C = san;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerQty_C:"))
                        {
                            panel_StrikerQty_C = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MiddleCloserPairQty:"))
                        {
                            panel_MiddleCloserPairQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MotorizedOptionVisibility:"))
                        {
                            panel_MotorizedOptionVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MotorizedMechArtNo:"))
                        {
                            foreach (MotorizedMech_ArticleNo mman in MotorizedMech_ArticleNo.GetAll())
                            {
                                if (mman.ToString() == extractedValue_str)
                                {
                                    panel_MotorizedMechArtNo = mman;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_MotorizedPropertyHeight:"))
                        {
                            //panel_MotorizedPropertyHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MotorizedMechQty:"))
                        {
                            panel_MotorizedMechQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MotorizedMechSetQty:"))
                        {
                            panel_MotorizedMechSetQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_2DHingeQty:"))
                        {
                            panel_2DHingeQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_2dHingeArtNo_nonMotorized:"))
                        {
                            foreach (_2DHinge_ArticleNo han in _2DHinge_ArticleNo.GetAll())
                            {
                                if (han.ToString() == extractedValue_str)
                                {
                                    panel_2dHingeArtNo_nonMotorized = han;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_2DHingeQty_nonMotorized:"))
                        {
                            panel_2DHingeQty_nonMotorized = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_2dHingeVisibility_nonMotorized:"))
                        {
                            panel_2dHingeVisibility_nonMotorized = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_3dHingeArtNo:"))
                        {
                            foreach (_3dHinge_ArticleNo han in _3dHinge_ArticleNo.GetAll())
                            {
                                if (han.ToString() == extractedValue_str)
                                {
                                    panel_3dHingeArtNo = han;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_3dHingeQty:"))
                        {
                            panel_3dHingeQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_3dHingePropertyVisibility:"))
                        {
                            panel_3dHingePropertyVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ButtHingeArtNo:"))
                        {
                            foreach (ButtHinge_ArticleNo bhan in ButtHinge_ArticleNo.GetAll())
                            {
                                if (bhan.ToString() == extractedValue_str)
                                {
                                    panel_ButtHingeArtNo = bhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ButtHingeQty:"))
                        {

                            panel_ButtHingeQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_2dHingeVisibility:"))
                        {
                            panel_2dHingeVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ButtHingeVisibility:"))
                        {
                            panel_ButtHingeVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_AdjStrikerArtNo:"))
                        {
                            foreach (AdjustableStriker_ArticleNo asan in AdjustableStriker_ArticleNo.GetAll())
                            {
                                if (asan.ToString() == extractedValue_str)
                                {
                                    panel_AdjStrikerArtNo = asan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_AdjStrikerQty:"))
                        {
                            panel_AdjStrikerQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_RestrictorStayArtNo:"))
                        {
                            foreach (RestrictorStay_ArticleNo rsan in RestrictorStay_ArticleNo.GetAll())
                            {
                                if (rsan.ToString() == extractedValue_str)
                                {
                                    panel_RestrictorStayArtNo = rsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RestrictorStayQty:"))
                        {
                            panel_RestrictorStayQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ExtensionPropertyHeight:"))
                        {
                            //panel_ExtensionPropertyHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GeorgianBarArtNo:"))
                        {
                            foreach (GeorgianBar_ArticleNo gban in GeorgianBar_ArticleNo.GetAll())
                            {
                                if (gban.ToString() == extractedValue_str)
                                {
                                    panel_GeorgianBarArtNo = gban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GeorgianBar_VerticalQty:"))
                        {
                            panel_GeorgianBar_VerticalQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GeorgianBar_HorizontalQty:"))
                        {
                            panel_GeorgianBar_HorizontalQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GeorgianBarOptionVisibility:"))
                        {
                            panel_GeorgianBarOptionVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_HingeOptions:"))
                        {
                            foreach (HingeOption ho in HingeOption.GetAll())
                            {
                                if (ho.ToString() == extractedValue_str)
                                {
                                    panel_HingeOptions = ho;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_HingeOptionsPropertyHeight:"))
                        {
                            //panel_HingeOptionsPropertyHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_HingeOptionsVisibility:"))
                        {
                            panel_HingeOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_CenterHingeOptions:"))
                        {
                            foreach (CenterHingeOption cho in CenterHingeOption.GetAll())
                            {
                                if (cho.ToString() == extractedValue_str)
                                {
                                    panel_CenterHingeOptions = cho;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CenterHingeOptionsVisibility:"))
                        {
                            panel_CenterHingeOptionsVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_NTCenterHingeArticleNo:"))
                        {
                            foreach (NTCenterHinge_ArticleNo ntchan in NTCenterHinge_ArticleNo.GetAll())
                            {
                                if (ntchan.ToString() == extractedValue_str)
                                {
                                    panel_NTCenterHingeArticleNo = ntchan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StayBearingKArtNo:"))
                        {
                            foreach (StayBearingK_ArticleNo sbkan in StayBearingK_ArticleNo.GetAll())
                            {
                                if (sbkan.ToString() == extractedValue_str)
                                {
                                    panel_StayBearingKArtNo = sbkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StayBearingPinArtNo:"))
                        {
                            foreach (StayBearingPin_ArticleNo sbpan in StayBearingPin_ArticleNo.GetAll())
                            {
                                if (sbpan.ToString() == extractedValue_str)
                                {
                                    panel_StayBearingPinArtNo = sbpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StayBearingCoverArtNo:"))
                        {
                            foreach (StayBearingCover_ArticleNo sbcan in StayBearingCover_ArticleNo.GetAll())
                            {
                                if (sbcan.ToString() == extractedValue_str)
                                {
                                    panel_StayBearingCoverArtNo = sbcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TopCornerHingeArtNo:"))
                        {
                            foreach (TopCornerHinge_ArticleNo tchan in TopCornerHinge_ArticleNo.GetAll())
                            {
                                if (tchan.ToString() == extractedValue_str)
                                {
                                    panel_TopCornerHingeArtNo = tchan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TopCornerHingeCoverArtNo:"))
                        {
                            foreach (TopCornerHingeCover_ArticleNo tchcan in TopCornerHingeCover_ArticleNo.GetAll())
                            {
                                if (tchcan.ToString() == extractedValue_str)
                                {
                                    panel_TopCornerHingeCoverArtNo = tchcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TopCornerHingeSpacerArtNo:"))
                        {
                            foreach (TopCornerHingeSpacer_ArticleNo tchsan in TopCornerHingeSpacer_ArticleNo.GetAll())
                            {
                                if (tchsan.ToString() == extractedValue_str)
                                {
                                    panel_TopCornerHingeSpacerArtNo = tchsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerHingeKArtNo:"))
                        {
                            foreach (CornerHingeK_ArticleNo chkan in CornerHingeK_ArticleNo.GetAll())
                            {
                                if (chkan.ToString() == extractedValue_str)
                                {
                                    panel_CornerHingeKArtNo = chkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerPivotRestKArtNo:"))
                        {
                            foreach (CornerPivotRestK_ArticleNo cprkan in CornerPivotRestK_ArticleNo.GetAll())
                            {
                                if (cprkan.ToString() == extractedValue_str)
                                {
                                    panel_CornerPivotRestKArtNo = cprkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerHingeCoverKArtNo:"))
                        {
                            foreach (CornerHingeCoverK_ArticleNo chckan in CornerHingeCoverK_ArticleNo.GetAll())
                            {
                                if (chckan.ToString() == extractedValue_str)
                                {
                                    panel_CornerHingeCoverKArtNo = chckan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverForCornerPivotRestVerticalArtNo:"))
                        {
                            foreach (CoverForCornerPivotRestVertical_ArticleNo cfcprvan in CoverForCornerPivotRestVertical_ArticleNo.GetAll())
                            {
                                if (cfcprvan.ToString() == extractedValue_str)
                                {
                                    panel_CoverForCornerPivotRestVerticalArtNo = cfcprvan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverForCornerPivotRestArtNo:"))
                        {
                            foreach (CoverForCornerPivotRest_ArticleNo cfcpran in CoverForCornerPivotRest_ArticleNo.GetAll())
                            {
                                if (cfcpran.ToString() == extractedValue_str)
                                {
                                    panel_CoverForCornerPivotRestArtNo = cfcpran;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_WeldableCArtNo:"))
                        {
                            foreach (WeldableCornerJoint_ArticleNo wcjan in WeldableCornerJoint_ArticleNo.GetAll())
                            {
                                if (wcjan.ToString() == extractedValue_str)
                                {
                                    panel_WeldableCArtNo = wcjan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LatchDeadboltStrikerArtNo:"))
                        {
                            foreach (LatchDeadboltStriker_ArticleNo ldsan in LatchDeadboltStriker_ArticleNo.GetAll())
                            {
                                if (ldsan.ToString() == extractedValue_str)
                                {
                                    panel_LatchDeadboltStrikerArtNo = ldsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CmenuDeleteVisibility:"))
                        {
                            panel_CmenuDeleteVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_NTCenterHingeVisibility:"))
                        {
                            panel_NTCenterHingeVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MiddleCloserVisibility:"))
                        {
                            panel_MiddleCloserVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MotorizedpnlOptionVisibility:"))
                        {
                            panel_MotorizedpnlOptionVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GuideTrackProfileArtNo:"))
                        {

                        }
                        else if (row_str.Contains("Panel_AluminumTrackArtNo:"))
                        {
                            foreach (AluminumTrack_ArticleNo atan in AluminumTrack_ArticleNo.GetAll())
                            {
                                if (atan.ToString() == extractedValue_str)
                                {
                                    panel_AluminumTrackArtNo = atan;
                                }
                            }


                        }
                        else if (row_str.Contains("Panel_AluminumTrackQty:"))
                        {
                            panel_AluminumTrackQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_AluminumTrackQtyVisibility:"))
                        {
                            panel_AluminumTrackQtyVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_WeatherBarArtNo:"))
                        {
                            foreach (WeatherBar_ArticleNo wban in WeatherBar_ArticleNo.GetAll())
                            {
                                if (wban.ToString() == extractedValue_str)
                                {
                                    panel_WeatherBarArtNo = wban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_WeatherBarFastenerArtNo:"))
                        {
                            foreach (WeatherBarFastener_ArticleNo wbfan in WeatherBarFastener_ArticleNo.GetAll())
                            {
                                if (wbfan.ToString() == extractedValue_str)
                                {
                                    panel_WeatherBarFastenerArtNo = wbfan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_EndCapForWeatherBarArtNo:"))
                        {
                            foreach (EndCapForWeatherBar_ArticleNo ecfwban in EndCapForWeatherBar_ArticleNo.GetAll())
                            {
                                if (ecfwban.ToString() == extractedValue_str)
                                {
                                    panel_EndCapForWeatherBarArtNo = ecfwban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_WaterSeepageArtNo:"))
                        {
                            foreach (WaterSeepage_ArticleNo wsan in WaterSeepage_ArticleNo.GetAll())
                            {
                                if (wsan.ToString() == extractedValue_str)
                                {
                                    panel_WaterSeepageArtNo = wsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_BrushSealArtNo:"))
                        {
                            foreach (BrushSeal_ArticleNo bsan in BrushSeal_ArticleNo.GetAll())
                            {
                                if (bsan.ToString() == extractedValue_str)
                                {
                                    panel_BrushSealArtNo = bsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RollersTypes:"))
                        {
                            foreach (RollersTypes rt in RollersTypes.GetAll())
                            {
                                if (rt.ToString() == extractedValue_str)
                                {
                                    panel_RollersTypes = rt;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RollersTypesVisibility:"))
                        {
                            panel_RollersTypesVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlazingRebateBlockArtNo:"))
                        {
                            foreach (GlazingRebateBlock_ArticleNo grban in GlazingRebateBlock_ArticleNo.GetAll())
                            {
                                if (grban.ToString() == extractedValue_str)
                                {
                                    panel_GlazingRebateBlockArtNo = grban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_Spacer:"))
                        {
                            foreach (Spacer_ArticleNo san in Spacer_ArticleNo.GetAll())
                            {
                                if (san.ToString() == extractedValue_str)
                                {
                                    panel_Spacer = san;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SealingBlockArtNo:"))
                        {
                            foreach (SealingBlock_ArticleNo sban in SealingBlock_ArticleNo.GetAll())
                            {
                                if (sban.ToString() == extractedValue_str)
                                {
                                    panel_SealingBlockArtNo = sban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_InterlockArtNo:"))
                        {
                            foreach (Interlock_ArticleNo ian in Interlock_ArticleNo.GetAll())
                            {
                                if (ian.ToString() == extractedValue_str)
                                {
                                    panel_InterlockArtNo = ian;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionForInterlockArtNo:"))
                        {
                            foreach (ExtensionForInterlock_ArticleNo efian in ExtensionForInterlock_ArticleNo.GetAll())
                            {
                                if (efian.ToString() == extractedValue_str)
                                {
                                    panel_ExtensionForInterlockArtNo = efian;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DHandleInsideArtNo:"))
                        {
                            foreach (D_HandleArtNo dhan in D_HandleArtNo.GetAll())
                            {
                                if (dhan.ToString() == extractedValue_str)
                                {
                                    panel_DHandleInsideArtNo = dhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DHandleOutsideArtNo:"))
                        {
                            foreach (D_HandleArtNo dhan in D_HandleArtNo.GetAll())
                            {
                                if (dhan.ToString() == extractedValue_str)
                                {
                                    panel_DHandleOutsideArtNo = dhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DHandleIOLockingInsideArtNo:"))
                        {
                            foreach (D_Handle_IO_LockingArtNo dhiolan in D_Handle_IO_LockingArtNo.GetAll())
                            {
                                if (dhiolan.ToString() == extractedValue_str)
                                {
                                    panel_DHandleIOLockingInsideArtNo = dhiolan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DHandleIOLockingOutsideArtNo:"))
                        {
                            foreach (D_Handle_IO_LockingArtNo dhiolan in D_Handle_IO_LockingArtNo.GetAll())
                            {
                                if (dhiolan.ToString() == extractedValue_str)
                                {
                                    panel_DHandleIOLockingOutsideArtNo = dhiolan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DummyDHandleInsideArtNo:"))
                        {
                            foreach (DummyD_HandleArtNo ddhan in DummyD_HandleArtNo.GetAll())
                            {
                                if (ddhan.ToString() == extractedValue_str)
                                {
                                    panel_DummyDHandleInsideArtNo = ddhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DummyDHandleOutsideArtNo:"))
                        {
                            foreach (DummyD_HandleArtNo ddhan in DummyD_HandleArtNo.GetAll())
                            {
                                if (ddhan.ToString() == extractedValue_str)
                                {
                                    panel_DummyDHandleOutsideArtNo = ddhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PopUpHandleArtNo:"))
                        {
                            foreach (PopUp_HandleArtNo puhan in PopUp_HandleArtNo.GetAll())
                            {
                                if (puhan.ToString() == extractedValue_str)
                                {
                                    panel_PopUpHandleArtNo = puhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotoswingForSlidingHandleArtNo:"))
                        {
                            foreach (Rotoswing_Sliding_HandleArtNo rshan in Rotoswing_Sliding_HandleArtNo.GetAll())
                            {
                                if (rshan.ToString() == extractedValue_str)
                                {
                                    panel_RotoswingForSlidingHandleArtNo = rshan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_DHandleOptionVisibilty:"))
                        {
                            panel_DHandleOptionVisibilty = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_DHandleIOLockingOptionVisibilty:"))
                        {
                            panel_DHandleIOLockingOptionVisibilty = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_DummyDHandleOptionVisibilty:"))
                        {
                            panel_DummyDHandleOptionVisibilty = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_PopUpHandleOptionVisibilty:"))
                        {
                            panel_PopUpHandleOptionVisibilty = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_RotoswingForSlidingHandleOptionVisibilty:"))
                        {
                            panel_RotoswingForSlidingHandleOptionVisibilty = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_StrikerArtno_Sliding:"))
                        {
                            foreach (Striker_ArticleNo san in Striker_ArticleNo.GetAll())
                            {
                                if (san.ToString() == extractedValue_str)
                                {
                                    panel_StrikerArtno_Sliding = san;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerArtno_SlidingQty:"))
                        {
                            panel_StrikerArtno_SlidingQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_ScrewSetsArtNo:"))
                        {
                            foreach (ScrewSets ss in ScrewSets.GetAll())
                            {
                                if (ss.ToString() == extractedValue_str)
                                {
                                    panel_ScrewSetsArtNo = ss;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PVCCenterProfileArtNo:"))
                        {
                            foreach (PVCCenterProfile_ArticleNo pvccan in PVCCenterProfile_ArticleNo.GetAll())
                            {
                                if (pvccan.ToString() == extractedValue_str)
                                {
                                    panel_PVCCenterProfileArtNo = pvccan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GS100_T_EM_T_HMCOVER_ArtNo:"))
                        {
                            foreach (GS100_T_EM_T_HMCOVER_ArticleNo hmcan in GS100_T_EM_T_HMCOVER_ArticleNo.GetAll())
                            {
                                if (hmcan.ToString() == extractedValue_str)
                                {
                                    panel_GS100_T_EM_T_HMCOVER_ArtNo = hmcan;
                                }
                            }
                        }

                        else if (row_str.Contains("Panel_TrackProfileArtNo:"))
                        {
                            foreach (TrackProfile_ArticleNo tpan in TrackProfile_ArticleNo.GetAll())
                            {
                                if (tpan.ToString() == extractedValue_str)
                                {
                                    panel_TrackProfileArtNo = tpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TrackRailArtNo:"))
                        {
                            foreach (TrackRail_ArticleNo tran in TrackRail_ArticleNo.GetAll())
                            {
                                if (tran.ToString() == extractedValue_str)
                                {
                                    panel_TrackRailArtNo = tran;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TrackRailArtNoVisibility:"))
                        {
                            panel_TrackRailArtNoVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_MicrocellOneSafetySensorArtNo:"))
                        {
                            foreach (MicrocellOneSafetySensor_ArticleNo mossan in MicrocellOneSafetySensor_ArticleNo.GetAll())
                            {
                                if (mossan.ToString() == extractedValue_str)
                                {
                                    panel_MicrocellOneSafetySensorArtNo = mossan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_AutodoorBracketForGS100UPVCArtNo:"))
                        {
                            foreach (AutodoorBracketForGS100UPVC_ArticleNo abfan in AutodoorBracketForGS100UPVC_ArticleNo.GetAll())
                            {
                                if (abfan.ToString() == extractedValue_str)
                                {
                                    panel_AutodoorBracketForGS100UPVCArtNo = abfan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GS100EndCapScrewM5AndLSupportArtNo:"))
                        {
                            foreach (GS100EndCapScrewM5AndLSupport_ArticleNo gscsan in GS100EndCapScrewM5AndLSupport_ArticleNo.GetAll())
                            {
                                if (gscsan.ToString() == extractedValue_str)
                                {
                                    panel_GS100EndCapScrewM5AndLSupportArtNo = gscsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_EuroLeadExitButtonArtNo:"))
                        {
                            foreach (EuroLeadExitButton_ArticleNo eleban in EuroLeadExitButton_ArticleNo.GetAll())
                            {
                                if (eleban.ToString() == extractedValue_str)
                                {
                                    panel_EuroLeadExitButtonArtNo = eleban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TOOTHBELT_EM_CMArtNo:"))
                        {
                            foreach (TOOTHBELT_EM_CM_ArticleNo tban in TOOTHBELT_EM_CM_ArticleNo.GetAll())
                            {
                                if (tban.ToString() == extractedValue_str)
                                {
                                    panel_TOOTHBELT_EM_CMArtNo = tban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GuBeaZenMicrowaveSensorArtNo:"))
                        {
                            foreach (GuBeaZenMicrowaveSensor_ArticleNo gbzmsan in GuBeaZenMicrowaveSensor_ArticleNo.GetAll())
                            {
                                if (gbzmsan.ToString() == extractedValue_str)
                                {
                                    panel_GuBeaZenMicrowaveSensorArtNo = gbzmsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SlidingDoorKitGs100_1ArtNo:"))
                        {
                            foreach (SlidingDoorKitGs100_1_ArticleNo sdkan in SlidingDoorKitGs100_1_ArticleNo.GetAll())
                            {
                                if (sdkan.ToString() == extractedValue_str)
                                {
                                    panel_SlidingDoorKitGs100_1ArtNo = sdkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GS100CoverKitArtNo:"))
                        {
                            foreach (GS100CoverKit_ArticleNo gsckan in GS100CoverKit_ArticleNo.GetAll())
                            {
                                if (gsckan.ToString() == extractedValue_str)
                                {
                                    panel_GS100CoverKitArtNo = gsckan;
                                }
                            }
                            IPanelModel pnlModel = _panelServices.AddPanelModel(panel_Width,
                                                                                panel_Height,
                                                                                (Control)panel_Parent,
                                                                                (UserControl)panel_FrameGroup,
                                                                                (UserControl)panel_FramePropertiesGroup,
                                                                                (UserControl)panel_MultiPanelGroup,
                                                                                panel_Type,
                                                                                panel_Visibility,
                                                                                _frameModel.Frame_Zoom,
                                                                                _frameModel,
                                                                                null,
                                                                                panel_DisplayWidth,
                                                                                panel_DisplayWidthDecimal,
                                                                                panel_DisplayHeight,
                                                                                panel_DisplayHeightDecimal,
                                                                                panel_GlazingBeadArtNo,
                                                                                panel_GlassFilm,
                                                                                panel_SashProfileArtNo,
                                                                                panel_SashReinfArtNo,
                                                                                panel_GlassType,
                                                                                panel_EspagnoletteArtNo,
                                                                                //panel_StrikerArtNo,
                                                                                Striker_ArticleNo._M89ANTA,
                                                                                panel_MiddleCloserArtNo,
                                                                                panel_LockingKitArtNo,
                                                                                panel_MotorizedMechArtNo,
                                                                                panel_HandleType,
                                                                                panel_ExtensionTopArtNo,
                                                                                panel_ExtensionTop2ArtNo,
                                                                                panel_ExtensionBotArtNo,
                                                                                panel_ExtensionBot2ArtNo,
                                                                                panel_ExtensionLeftArtNo,
                                                                                panel_ExtensionLeft2ArtNo,
                                                                                panel_ExtensionRightArtNo,
                                                                                panel_ExtensionRight2ArtNo,
                                                                                panel_ExtTopChk,
                                                                                panel_ExtBotChk,
                                                                                panel_ExtLeftChk,
                                                                                panel_ExtRightChk,
                                                                                panel_ExtTopQty,
                                                                                panel_ExtBotQty,
                                                                                panel_ExtLeftQty,
                                                                                panel_ExtRightQty,
                                                                                panel_ExtTop2Qty,
                                                                                panel_ExtBot2Qty,
                                                                                panel_ExtLeft2Qty,
                                                                                panel_ExtRight2Qty,
                                                                                panel_RotoswingArtNo,
                                                                                panel_GeorgianBarArtNo,
                                                                                panel_OverlapSash,
                                                                                panel_GeorgianBar_VerticalQty,
                                                                                panel_GeorgianBar_HorizontalQty,
                                                                                panel_GeorgianBarOptionVisibility,
                                                                                panel_ID,
                                                                                panel_GlassID,
                                                                                panel_ImageRendererZoom,
                                                                                panel_Index_Inside_MPanel,
                                                                                panel_Dock,
                                                                                panel_Name,
                                                                                panel_Orient,
                                                                                panel_HingeOptions,
                                                                                panel_SlidingTypeVisibility,
                                                                                panel_SlidingTypes);

                            pnlModel.Panel_ChkText = panel_ChkText;
                            pnlModel.Panel_ParentMultiPanelModel = panel_ParentMultiPanelModel;
                            pnlModel.Panel_Type = panel_Type;
                            pnlModel.Panel_Placement = panel_Placement;
                            pnlModel.Panel_OriginalHeight = panel_OriginalHeight;
                            pnlModel.PanelImageRenderer_Height = panel_ImageRenderer_Height;
                            pnlModel.Panel_HeightToBind = panel_HeightToBind;
                            pnlModel.Panel_OriginalDisplayHeight = panel_OriginalDisplayHeight;
                            pnlModel.Panel_OriginalDisplayHeightDecimal = panel_OriginalDisplayHeightDecimal;
                            pnlModel.PanelImageRenderer_Width = panel_ImageRenderer_Width;
                            pnlModel.Panel_WidthToBind = panel_WidthToBind;
                            pnlModel.Panel_OriginalDisplayWidth = panel_OriginalDisplayWidth;
                            pnlModel.Panel_OriginalDisplayWidthDecimal = panel_OriginalDisplayWidthDecimal;
                            pnlModel.Panel_Index_Inside_SPanel = panel_Index_Inside_SPanel;
                            //pnlModel.Panel_PropertyHeight = panel_PropertyHeight;
                            pnlModel.Panel_HandleOptionsHeight = panel_HandleOptionsHeight;
                            pnlModel.Panel_LouverBladesCount = panel_LouverBladesCount;
                            pnlModel.Panel_Orient = panel_Orient;
                            pnlModel.Panel_OrientVisibility = panel_OrientVisibility;
                            pnlModel.Panel_HandleOptionsVisibility = panel_HandleOptionsVisibility;
                            pnlModel.Panel_RotoswingOptionsVisibility = panel_RotoswingOptionsVisibility;
                            pnlModel.Panel_RioOptionsVisibility = panel_RioOptionsVisibility;
                            pnlModel.Panel_RioOptionsVisibility2 = panel_RioOptionsVisibility2;
                            pnlModel.Panel_RotolineOptionsVisibility = panel_RotolineOptionsVisibility;
                            pnlModel.Panel_MVDOptionsVisibility = panel_MVDOptionsVisibility;
                            pnlModel.Panel_RotaryOptionsVisibility = panel_RotaryOptionsVisibility;

                            #region Explosion
                            pnlModel.PanelGlass_ID = panel_GlassID;
                            pnlModel.Panel_GlassThicknessDesc = panel_GlassThicknessDesc;
                            pnlModel.Panel_GlassThickness = panel_GlassThickness;
                            pnlModel.PanelGlazingBead_ArtNo = panel_GlazingBeadArtNo;
                            pnlModel.Panel_GlazingAdaptorArtNo = panel_GlazingAdaptorArtNo;
                            pnlModel.Panel_GBSpacerArtNo = panel_GBSpacerArtNo;
                            pnlModel.Panel_ChkGlazingAdaptor = panel_ChkGlazingAdaptor;
                            pnlModel.Panel_GlazingBeadWidth = panel_GlazingBeadWidth;
                            pnlModel.Panel_GlazingBeadWidthDecimal = panel_GlazingBeadWidthDecimal;
                            pnlModel.Panel_GlazingBeadHeight = panel_GlazingBeadHeight;
                            pnlModel.Panel_GlazingBeadHeightDecimal = panel_GlazingBeadHeightDecimal;
                            pnlModel.Panel_GlassWidth = panel_GlassWidth;
                            pnlModel.Panel_GlassWidthDecimal = panel_GlassWidthDecimal;
                            pnlModel.Panel_OriginalGlassWidth = panel_OriginalGlassWidth;
                            pnlModel.Panel_OriginalGlassWidthDecimal = panel_OriginalGlassWidthDecimal;
                            pnlModel.Panel_GlassHeight = panel_GlassHeight;
                            pnlModel.Panel_GlassHeightDecimal = panel_GlassHeightDecimal;
                            pnlModel.Panel_OriginalGlassHeight = panel_OriginalGlassHeight;
                            pnlModel.Panel_OriginalGlassHeightDecimal = panel_OriginalGlassHeightDecimal;
                            //pnlModel.Panel_GlassPropertyHeight = panel_GlassPropertyHeight;
                            pnlModel.Panel_GlazingSpacerQty = panel_GlazingSpacerQty;
                            pnlModel.Panel_GlassFilm = panel_GlassFilm;
                            pnlModel.Panel_SashPropertyVisibility = panel_SashPropertyVisibility;
                            pnlModel.Panel_SashProfileArtNo = panel_SashProfileArtNo;
                            pnlModel.Panel_SashReinfArtNo = panel_SashReinfArtNo;
                            pnlModel.Panel_SashWidth = panel_SashWidth;
                            pnlModel.Panel_SashWidthDecimal = panel_SashWidthDecimal;
                            pnlModel.Panel_SashHeight = panel_SashHeight;
                            pnlModel.Panel_SashHeightDecimal = panel_SashHeightDecimal;
                            pnlModel.Panel_OriginalSashWidth = panel_OriginalSashWidth;
                            pnlModel.Panel_OriginalSashWidthDecimal = panel_OriginalSashWidthDecimal;
                            pnlModel.Panel_OriginalSashHeight = panel_OriginalSashHeight;
                            pnlModel.Panel_OriginalSashHeightDecimal = panel_OriginalSashHeightDecimal;
                            pnlModel.Panel_SashReinfWidth = panel_SashReinfWidth;
                            pnlModel.Panel_SashReinfWidthDecimal = panel_SashReinfWidthDecimal;
                            pnlModel.Panel_SashReinfHeight = panel_SashReinfHeight;
                            pnlModel.Panel_SashReinfHeightDecimal = panel_SashReinfHeightDecimal;
                            pnlModel.Panel_CoverProfileArtNo = panel_CoverProfileArtNo;
                            pnlModel.Panel_CoverProfileArtNo2 = panel_CoverProfileArtNo2;
                            pnlModel.Panel_FrictionStayArtNo = panel_FrictionStayArtNo;
                            pnlModel.Panel_FSCasementArtNo = panel_FSCasementArtNo;
                            pnlModel.Panel_SnapInKeepArtNo = panel_SnapInKeepArtNo;
                            pnlModel.Panel_FixedCamArtNo = panel_FixedCamArtNo;
                            pnlModel.Panel_30x25CoverArtNo = panel_30x25CoverArtNo;
                            pnlModel.Panel_MotorizedDividerArtNo = panel_MotorizedDividerArtNo;
                            pnlModel.Panel_CoverForMotorArtNo = panel_CoverForMotorArtNo;
                            pnlModel.Panel_2dHingeArtNo = panel_2dHingeArtNo;
                            pnlModel.Panel_PushButtonSwitchArtNo = panel_PushButtonSwitchArtNo;
                            pnlModel.Panel_FalsePoleArtNo = panel_FalsePoleArtNo;
                            pnlModel.Panel_SupportingFrameArtNo = panel_SupportingFrameArtNo;
                            pnlModel.Panel_PlateArtNo = panel_PlateArtNo;
                            pnlModel.Panel_HandleType = panel_HandleType;
                            pnlModel.Panel_RotoswingArtNo = panel_RotoswingArtNo;
                            pnlModel.Panel_RotaryArtNo = panel_RotaryArtNo;
                            pnlModel.Panel_RioArtNo = panel_RioArtNo;
                            pnlModel.Panel_RioArtNo2 = panel_RioArtNo2;
                            pnlModel.Panel_ProfileKnobCylinderArtNo = panel_ProfileKnobCylinderArtNo;
                            pnlModel.Panel_CylinderCoverArtNo = panel_CylinderCoverArtNo;
                            pnlModel.Panel_RotolineArtNo = panel_RotolineArtNo;
                            pnlModel.Panel_MVDArtNo = panel_MVDArtNo;
                            pnlModel.Panel_EspagnoletteArtNo = panel_EspagnoletteArtNo;
                            pnlModel.Panel_EspagnoletteOptionsVisibility = panel_EspagnoletteOptionsVisibility;
                            pnlModel.Panel_ExtensionTopArtNo = panel_ExtensionTopArtNo;
                            pnlModel.Panel_ExtensionTop2ArtNo = panel_ExtensionTop2ArtNo;
                            pnlModel.Panel_ExtensionTop3ArtNo = panel_ExtensionTop3ArtNo;
                            pnlModel.Panel_ExtensionBotArtNo = panel_ExtensionBotArtNo;
                            pnlModel.Panel_ExtensionBot2ArtNo = panel_ExtensionBot2ArtNo;
                            pnlModel.Panel_ExtensionLeftArtNo = panel_ExtensionLeftArtNo;
                            pnlModel.Panel_ExtensionLeft2ArtNo = panel_ExtensionLeft2ArtNo;
                            pnlModel.Panel_ExtensionRightArtNo = panel_ExtensionRightArtNo;
                            pnlModel.Panel_ExtensionRight2ArtNo = panel_ExtensionRight2ArtNo;
                            pnlModel.Panel_ExtTopChk = panel_ExtTopChk;
                            pnlModel.Panel_ExtTop2Chk = panel_ExtTop2Chk;
                            pnlModel.Panel_ExtBotChk = panel_ExtBotChk;
                            pnlModel.Panel_ExtLeftChk = panel_ExtLeftChk;
                            pnlModel.Panel_ExtRightChk = panel_ExtRightChk;
                            pnlModel.Panel_ExtTopQty = panel_ExtTopQty;
                            pnlModel.Panel_ExtBotQty = panel_ExtBotQty;
                            pnlModel.Panel_ExtLeftQty = panel_ExtLeftQty;
                            pnlModel.Panel_ExtRightQty = panel_ExtRightQty;
                            pnlModel.Panel_ExtTop2Qty = panel_ExtTop2Qty;
                            pnlModel.Panel_ExtTop3Qty = panel_ExtTop3Qty;
                            pnlModel.Panel_ExtBot2Qty = panel_ExtBot2Qty;
                            pnlModel.Panel_ExtLeft2Qty = panel_ExtLeft2Qty;
                            pnlModel.Panel_ExtRight2Qty = panel_ExtRight2Qty;
                            pnlModel.Panel_CornerDriveArtNo = panel_CornerDriveArtNo;
                            pnlModel.Panel_CornerDriveOptionsVisibility = panel_CornerDriveOptionsVisibility;
                            pnlModel.Panel_ExtensionOptionsVisibility = panel_ExtensionOptionsVisibility;
                            pnlModel.Panel_RotoswingOptionsHeight = panel_RotoswingOptionsHeight;
                            pnlModel.Panel_PlasticWedge = panel_PlasticWedge;
                            pnlModel.Panel_PlasticWedgeQty = panel_PlasticWedgeQty;
                            pnlModel.Panel_MiddleCloserArtNo = panel_MiddleCloserArtNo;
                            pnlModel.Panel_LockingKitArtNo = panel_LockingKitArtNo;
                            pnlModel.Panel_GlassType = panel_GlassType;
                            pnlModel.Panel_StrikerArtno_A = panel_StrikerArtno_A;
                            pnlModel.Panel_StrikerQty_A = panel_StrikerQty_A;
                            pnlModel.Panel_StrikerArtno_C = panel_StrikerArtno_C;
                            pnlModel.Panel_StrikerQty_C = panel_StrikerQty_C;
                            pnlModel.Panel_MiddleCloserPairQty = panel_MiddleCloserPairQty;
                            pnlModel.Panel_MotorizedOptionVisibility = panel_MotorizedOptionVisibility;
                            pnlModel.Panel_MotorizedMechArtNo = panel_MotorizedMechArtNo;
                            //pnlModel.Panel_MotorizedPropertyHeight = panel_MotorizedPropertyHeight;
                            pnlModel.Panel_MotorizedMechQty = panel_MotorizedMechQty;
                            pnlModel.Panel_MotorizedMechSetQty = panel_MotorizedMechSetQty;
                            pnlModel.Panel_2DHingeQty = panel_2DHingeQty;
                            pnlModel.Panel_2dHingeArtNo_nonMotorized = panel_2dHingeArtNo_nonMotorized;
                            pnlModel.Panel_2DHingeQty_nonMotorized = panel_2DHingeQty_nonMotorized;
                            pnlModel.Panel_2dHingeVisibility_nonMotorized = panel_2dHingeVisibility_nonMotorized;
                            pnlModel.Panel_3dHingeArtNo = panel_3dHingeArtNo;
                            pnlModel.Panel_3dHingeQty = panel_3dHingeQty;
                            pnlModel.Panel_3dHingePropertyVisibility = panel_3dHingePropertyVisibility;
                            pnlModel.Panel_ButtHingeArtNo = panel_ButtHingeArtNo;
                            pnlModel.Panel_ButtHingeQty = panel_ButtHingeQty;
                            pnlModel.Panel_2dHingeVisibility = panel_2dHingeVisibility;
                            pnlModel.Panel_ButtHingeVisibility = panel_ButtHingeVisibility;
                            pnlModel.Panel_AdjStrikerArtNo = panel_AdjStrikerArtNo;
                            pnlModel.Panel_AdjStrikerQty = panel_AdjStrikerQty;
                            pnlModel.Panel_RestrictorStayArtNo = panel_RestrictorStayArtNo;
                            pnlModel.Panel_RestrictorStayQty = panel_RestrictorStayQty; ;
                            //pnlModel.Panel_ExtensionPropertyHeight = panel_ExtensionPropertyHeight;
                            pnlModel.Panel_GeorgianBarArtNo = panel_GeorgianBarArtNo;
                            pnlModel.Panel_GeorgianBar_VerticalQty = panel_GeorgianBar_VerticalQty;
                            pnlModel.Panel_GeorgianBar_HorizontalQty = panel_GeorgianBar_HorizontalQty;
                            pnlModel.Panel_GeorgianBarOptionVisibility = panel_GeorgianBarOptionVisibility; ;
                            pnlModel.Panel_HingeOptions = panel_HingeOptions;
                            //pnlModel.Panel_HingeOptionsPropertyHeight = panel_HingeOptionsPropertyHeight;
                            pnlModel.Panel_HingeOptionsVisibility = panel_HingeOptionsVisibility;
                            pnlModel.Panel_CenterHingeOptions = panel_CenterHingeOptions;
                            pnlModel.Panel_CenterHingeOptionsVisibility = panel_CenterHingeOptionsVisibility;
                            pnlModel.Panel_NTCenterHingeArticleNo = panel_NTCenterHingeArticleNo;
                            pnlModel.Panel_StayBearingKArtNo = panel_StayBearingKArtNo;
                            pnlModel.Panel_StayBearingPinArtNo = panel_StayBearingPinArtNo;
                            pnlModel.Panel_StayBearingCoverArtNo = panel_StayBearingCoverArtNo;
                            pnlModel.Panel_TopCornerHingeArtNo = panel_TopCornerHingeArtNo;
                            pnlModel.Panel_TopCornerHingeCoverArtNo = panel_TopCornerHingeCoverArtNo;
                            pnlModel.Panel_TopCornerHingeSpacerArtNo = panel_TopCornerHingeSpacerArtNo;
                            pnlModel.Panel_CornerHingeKArtNo = panel_CornerHingeKArtNo;
                            pnlModel.Panel_CornerPivotRestKArtNo = panel_CornerPivotRestKArtNo; ;
                            pnlModel.Panel_CornerHingeCoverKArtNo = panel_CornerHingeCoverKArtNo;
                            pnlModel.Panel_CoverForCornerPivotRestVerticalArtNo = panel_CoverForCornerPivotRestVerticalArtNo;
                            pnlModel.Panel_CoverForCornerPivotRestArtNo = panel_CoverForCornerPivotRestArtNo;
                            pnlModel.Panel_WeldableCArtNo = panel_WeldableCArtNo;
                            pnlModel.Panel_LatchDeadboltStrikerArtNo = panel_LatchDeadboltStrikerArtNo;
                            pnlModel.Panel_CmenuDeleteVisibility = panel_CmenuDeleteVisibility;
                            pnlModel.Panel_NTCenterHingeVisibility = panel_NTCenterHingeVisibility; ;
                            pnlModel.Panel_MiddleCloserVisibility = panel_MiddleCloserVisibility;
                            pnlModel.Panel_MotorizedpnlOptionVisibility = panel_MotorizedpnlOptionVisibility;
                            pnlModel.Panel_GuideTrackProfileArtNo = panel_GuideTrackProfileArtNo;
                            pnlModel.Panel_AluminumTrackArtNo = panel_AluminumTrackArtNo;
                            pnlModel.Panel_AluminumTrackQty = panel_AluminumTrackQty;
                            pnlModel.Panel_AluminumTrackQtyVisibility = panel_AluminumTrackQtyVisibility;
                            pnlModel.Panel_WeatherBarArtNo = panel_WeatherBarArtNo;
                            pnlModel.Panel_WeatherBarFastenerArtNo = panel_WeatherBarFastenerArtNo;
                            pnlModel.Panel_EndCapForWeatherBarArtNo = panel_EndCapForWeatherBarArtNo;
                            pnlModel.Panel_WaterSeepageArtNo = panel_WaterSeepageArtNo;
                            pnlModel.Panel_BrushSealArtNo = panel_BrushSealArtNo;
                            pnlModel.Panel_RollersTypes = panel_RollersTypes;
                            pnlModel.Panel_RollersTypesVisibility = panel_RollersTypesVisibility;
                            pnlModel.Panel_GlazingRebateBlockArtNo = panel_GlazingRebateBlockArtNo;
                            pnlModel.Panel_Spacer = panel_Spacer;
                            pnlModel.Panel_SealingBlockArtNo = panel_SealingBlockArtNo;
                            pnlModel.Panel_InterlockArtNo = panel_InterlockArtNo;
                            pnlModel.Panel_ExtensionForInterlockArtNo = panel_ExtensionForInterlockArtNo;
                            pnlModel.Panel_DHandleInsideArtNo = panel_DHandleInsideArtNo;
                            pnlModel.Panel_DHandleOutsideArtNo = panel_DHandleOutsideArtNo;
                            pnlModel.Panel_DHandleIOLockingInsideArtNo = panel_DHandleIOLockingInsideArtNo;
                            pnlModel.Panel_DHandleIOLockingOutsideArtNo = panel_DHandleIOLockingOutsideArtNo;
                            pnlModel.Panel_DummyDHandleInsideArtNo = panel_DummyDHandleInsideArtNo;
                            pnlModel.Panel_DummyDHandleOutsideArtNo = panel_DummyDHandleOutsideArtNo;
                            pnlModel.Panel_PopUpHandleArtNo = panel_PopUpHandleArtNo;
                            pnlModel.Panel_RotoswingForSlidingHandleArtNo = panel_RotoswingForSlidingHandleArtNo;
                            pnlModel.Panel_DHandleOptionVisibilty = panel_DHandleOptionVisibilty;
                            pnlModel.Panel_DHandleIOLockingOptionVisibilty = panel_DHandleIOLockingOptionVisibilty;
                            pnlModel.Panel_DummyDHandleOptionVisibilty = panel_DummyDHandleOptionVisibilty;
                            pnlModel.Panel_PopUpHandleOptionVisibilty = panel_PopUpHandleOptionVisibilty;
                            pnlModel.Panel_RotoswingForSlidingHandleOptionVisibilty = panel_RotoswingForSlidingHandleOptionVisibilty;
                            pnlModel.Panel_StrikerArtno_Sliding = panel_StrikerArtno_Sliding;
                            pnlModel.Panel_StrikerArtno_SlidingQty = panel_StrikerArtno_SlidingQty;
                            pnlModel.Panel_ScrewSetsArtNo = panel_ScrewSetsArtNo;
                            pnlModel.Panel_PVCCenterProfileArtNo = panel_PVCCenterProfileArtNo;
                            pnlModel.Panel_GS100_T_EM_T_HMCOVER_ArtNo = panel_GS100_T_EM_T_HMCOVER_ArtNo;
                            pnlModel.Panel_TrackProfileArtNo = panel_TrackProfileArtNo;
                            pnlModel.Panel_TrackRailArtNo = panel_TrackRailArtNo;
                            pnlModel.Panel_TrackRailArtNoVisibility = panel_TrackRailArtNoVisibility;
                            pnlModel.Panel_MicrocellOneSafetySensorArtNo = panel_MicrocellOneSafetySensorArtNo;
                            pnlModel.Panel_AutodoorBracketForGS100UPVCArtNo = panel_AutodoorBracketForGS100UPVCArtNo;
                            pnlModel.Panel_GS100EndCapScrewM5AndLSupportArtNo = panel_GS100EndCapScrewM5AndLSupportArtNo;
                            pnlModel.Panel_EuroLeadExitButtonArtNo = panel_EuroLeadExitButtonArtNo;
                            pnlModel.Panel_TOOTHBELT_EM_CMArtNo = panel_TOOTHBELT_EM_CMArtNo;
                            pnlModel.Panel_GuBeaZenMicrowaveSensorArtNo = panel_GuBeaZenMicrowaveSensorArtNo;
                            pnlModel.Panel_SlidingDoorKitGs100_1ArtNo = panel_SlidingDoorKitGs100_1ArtNo;
                            pnlModel.Panel_GS100CoverKitArtNo = panel_GS100CoverKitArtNo;
                            #endregion





                            IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, pnlModel, this);
                            UserControl panelPropUC = (UserControl)panelPropUCP.GetPanelPropertiesUC();
                            IFramePropertiesUC framePropUC = (FramePropertiesUC)_frameModel.Frame_PropertiesUC;
                            panelPropUC.Dock = DockStyle.Top;

                            if (panel_Parent.Parent.Name.Contains("frame"))
                            {

                                _frameModel.Lst_Panel.Add(pnlModel);
                                pnlModel.Imager_SetDimensionsToBind_FrameParent();
                                framePropUC.GetFramePropertiesPNL().Controls.Add(panelPropUC);
                            }
                            else
                            {
                                pnlModel.Panel_ParentMultiPanelModel = _multiPanelModel;
                                _multiPanelModel.MPanelLst_Panel.Add(pnlModel);
                                _multiPanelModel.Reload_PanelMargin();

                                if (_prev_divModel != null)
                                {
                                    pnlModel.Panel_CornerDriveOptionsVisibility = _prev_divModel.Div_ChkDM;
                                }
                                //pnlModel.SetDimensionsToBind_using_ZoomPercentage();
                                //pnlModel.Imager_SetDimensionsToBind_using_ZoomPercentage();
                                pnlModel.SetPanelMargin_using_ZoomPercentage();
                                pnlModel.SetPanelMarginImager_using_ImageZoomPercentage();

                                if (panel_Parent.Parent.Name.Contains("MultiMullion"))
                                {
                                    _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(panelPropUC);
                                }
                                else
                                {
                                    _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(panelPropUC);
                                }
                            }
                            panelPropUC.BringToFront();


                            if (panel_Type.Contains("Fixed Panel"))
                            {

                                IFixedPanelUCPresenter fixedUCP;
                                if (panel_Parent.Parent.Name.Contains("frame"))
                                {
                                    fixedUCP = (FixedPanelUCPresenter)_fixedUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              frmUCPresenter);
                                    IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)fixedUC);
                                }
                                else
                                {


                                    if (panel_Parent.Parent.Name.Contains("MultiMullion"))
                                    {
                                        fixedUCP = (FixedPanelUCPresenter)_fixedUCP.GetNewInstance(_unityC,
                                                                                      pnlModel,
                                                                                      _frameModel,
                                                                                      this,
                                                                                      _multiPanelModel,
                                                                                      _multiMullionUCP,
                                                                                      _multiMullionImagerUCP);
                                        IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                                        _multiMullionUC.Getflp().Controls.Add((UserControl)fixedUC);
                                        //_multiMullionUCP.GetflpMullion().Controls.Add((UserControl)fixedUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)fixedUC);
                                    }
                                    else
                                    {
                                        fixedUCP = (FixedPanelUCPresenter)_fixedUCP.GetNewInstance(_unityC,
                                                                                       pnlModel,
                                                                                       _frameModel,
                                                                                       this,
                                                                                       _multiPanelModel,
                                                                                       _multiTransomUCP,
                                                                                       _multiTransomImagerUCP);
                                        IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                                        _multiTransomUC.Getflp().Controls.Add((UserControl)fixedUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)fixedUC);
                                        fixedUCP.SetInitialLoadFalse();
                                    }

                                }
                            }
                            else if (panel_Type.Contains("Casement Panel"))
                            {
                                ICasementPanelUCPresenter casementUCP;
                                if (panel_Parent.Parent.Name.Contains("frame"))
                                {
                                    casementUCP = (CasementPanelUCPresenter)_casementUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              frmUCPresenter);
                                    ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)casementUC);
                                }
                                else
                                {
                                    if (panel_Parent.Parent.Name.Contains("MultiMullion"))
                                    {
                                        casementUCP = (CasementPanelUCPresenter)_casementUCP.GetNewInstance(_unityC,
                                                                                      pnlModel,
                                                                                      _frameModel,
                                                                                      this,
                                                                                      _multiPanelModel,
                                                                                      _multiMullionUCP,
                                                                                      _multiMullionImagerUCP);
                                        ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                                        _multiMullionUC.Getflp().Controls.Add((UserControl)casementUC);

                                        //_multiMullionUCP.GetflpMullion().Controls.Add((UserControl)casementUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)casementUC);
                                        casementUCP.SetInitialLoadFalse();
                                    }
                                    else
                                    {
                                        casementUCP = (CasementPanelUCPresenter)_casementUCP.GetNewInstance(_unityC,
                                                                                       pnlModel,
                                                                                       _frameModel,
                                                                                       this,
                                                                                       _multiPanelModel,
                                                                                       _multiTransomUCP,
                                                                                       _multiTransomImagerUCP);
                                        ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                                        _multiTransomUC.Getflp().Controls.Add((UserControl)casementUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)casementUC);
                                        casementUCP.SetInitialLoadFalse();
                                    }

                                }
                            }
                            else if (panel_Type.Contains("Awning Panel"))
                            {
                                IAwningPanelUCPresenter awningUCP;
                                if (panel_Parent.Parent.Name.Contains("frame"))
                                {
                                    awningUCP = (AwningPanelUCPresenter)_awningUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              frmUCPresenter);
                                    IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)awningUC);
                                }
                                else
                                {
                                    if (panel_Parent.Parent.Name.Contains("MultiPanelMullion"))
                                    {
                                        awningUCP = (AwningPanelUCPresenter)_awningUCP.GetNewInstance(_unityC,
                                                                                      pnlModel,
                                                                                      _frameModel,
                                                                                      this,
                                                                                      _multiPanelModel,
                                                                                      _multiMullionUCP,
                                                                                      _multiMullionImagerUCP);
                                        IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                                        _multiMullionUC.Getflp().Controls.Add((UserControl)awningUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)awningUC);
                                        awningUCP.SetInitialLoadFalse();
                                    }
                                    else
                                    {
                                        awningUCP = (AwningPanelUCPresenter)_awningUCP.GetNewInstance(_unityC,
                                                                                       pnlModel,
                                                                                       _frameModel,
                                                                                       this,
                                                                                       _multiPanelModel,
                                                                                       _multiTransomUCP,
                                                                                       _multiTransomImagerUCP);
                                        IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                                        _multiTransomUC.Getflp().Controls.Add((UserControl)awningUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)awningUC);
                                        awningUCP.SetInitialLoadFalse();
                                    }

                                }

                            }
                            else if (panel_Type.Contains("Sliding Panel"))
                            {
                                ISlidingPanelUCPresenter slidingUCP;
                                if (panel_Parent.Parent.Name.Contains("frame"))
                                {
                                    slidingUCP = (SlidingPanelUCPresenter)_slidingUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              frmUCPresenter);
                                    ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)slidingUC);
                                }
                                else
                                {
                                    if (panel_Parent.Parent.Name.Contains("MultiMullion"))
                                    {
                                        slidingUCP = (SlidingPanelUCPresenter)_slidingUCP.GetNewInstance(_unityC,
                                                                                      pnlModel,
                                                                                      _frameModel,
                                                                                      this,
                                                                                      _multiPanelModel,
                                                                                      _multiMullionUCP,
                                                                                      _multiMullionImagerUCP);
                                        ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                                        _multiMullionUC.Getflp().Controls.Add((UserControl)slidingUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)slidingUC);
                                        slidingUCP.SetInitialLoadFalse();
                                    }
                                    else
                                    {
                                        slidingUCP = (SlidingPanelUCPresenter)_slidingUCP.GetNewInstance(_unityC,
                                                                                       pnlModel,
                                                                                       _frameModel,
                                                                                       this,
                                                                                       _multiPanelModel,
                                                                                       _multiTransomUCP,
                                                                                       _multiTransomImagerUCP);
                                        ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                                        _multiTransomUC.Getflp().Controls.Add((UserControl)slidingUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)slidingUC);
                                        slidingUCP.SetInitialLoadFalse();
                                    }

                                }

                            }
                            else if (panel_Type.Contains("TiltNTurn Panel"))
                            {
                                ITiltNTurnPanelUCPresenter tiltNTurnUCP;
                                if (panel_Parent.Parent.Name.Contains("frame"))
                                {
                                    tiltNTurnUCP = (TiltNTurnPanelUCPresenter)_tiltNTurnUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              frmUCPresenter);
                                    ITiltNTurnPanelUC tiltNTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)tiltNTurnUC);
                                }
                                else
                                {
                                    if (panel_Parent.Parent.Name.Contains("MultiMullion"))
                                    {
                                        tiltNTurnUCP = (TiltNTurnPanelUCPresenter)_tiltNTurnUCP.GetNewInstance(_unityC,
                                                                                      pnlModel,
                                                                                      _frameModel,
                                                                                      this,
                                                                                      _multiPanelModel,
                                                                                      _multiMullionUCP,
                                                                                      _multiMullionImagerUCP);
                                        ITiltNTurnPanelUC tiltNTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                                        _multiMullionUC.Getflp().Controls.Add((UserControl)tiltNTurnUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)tiltNTurnUC);
                                        tiltNTurnUCP.SetInitialLoadFalse();
                                    }
                                    else
                                    {
                                        tiltNTurnUCP = (TiltNTurnPanelUCPresenter)_tiltNTurnUCP.GetNewInstance(_unityC,
                                                                                       pnlModel,
                                                                                       _frameModel,
                                                                                       this,
                                                                                       _multiPanelModel,
                                                                                       _multiTransomUCP,
                                                                                       _multiTransomImagerUCP);
                                        ITiltNTurnPanelUC tiltNTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                                        _multiTransomUC.Getflp().Controls.Add((UserControl)tiltNTurnUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)tiltNTurnUC);
                                        tiltNTurnUCP.SetInitialLoadFalse();
                                    }

                                }

                            }
                            else if (panel_Type.Contains("Louver Panel"))
                            {
                                ILouverPanelUCPresenter louverPanelUCP;
                                if (panel_Parent.Parent.Name.Contains("frame"))
                                {
                                    louverPanelUCP = (LouverPanelUCPresenter)_louverPanelUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              frmUCPresenter);
                                    ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)louverPanelUC);
                                }
                                else
                                {
                                    if (panel_Parent.Parent.Name.Contains("MultiMullion"))
                                    {
                                        louverPanelUCP = (LouverPanelUCPresenter)_louverPanelUCP.GetNewInstance(_unityC,
                                                                                                   pnlModel,
                                                                                                   _frameModel,
                                                                                                   this,
                                                                                                   _multiPanelModel,
                                                                                                   _multiMullionUCP);
                                        ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                                        _multiMullionUC.Getflp().Controls.Add((UserControl)louverPanelUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)louverPanelUC);
                                        louverPanelUCP.SetInitialLoadFalse();
                                    }
                                    else
                                    {
                                        louverPanelUCP = (LouverPanelUCPresenter)_louverPanelUCP.GetNewInstance(_unityC,
                                                                                                   pnlModel,
                                                                                                   _frameModel,
                                                                                                   this,
                                                                                                   _multiPanelModel,
                                                                                                   _multiTransomUCP);
                                        ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                                        _multiTransomUC.Getflp().Controls.Add((UserControl)louverPanelUC);
                                        _multiPanelModel.MPanelLst_Objects.Add((UserControl)louverPanelUC);
                                        louverPanelUCP.SetInitialLoadFalse();
                                    }

                                }


                            }
                            if (!panel_Parent.Parent.Name.Contains("frame"))
                            {
                                if (pnlModel.Panel_Placement == "Last")
                                {
                                    _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                                    Run_GetListOfMaterials_SpecificItem();
                                }
                            }
                            _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            inside_panel = false;
                        }

                        #endregion

                    }

                    else if (inside_multi)
                    {
                        #region Load for Multi Panel


                        if (row_str.Contains("MPanel_ID:"))
                        {
                            mPanel_ID = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Name:"))
                        {
                            mPanel_Name = Convert.ToString(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Dock:"))
                        {
                            switch (extractedValue_str)
                            {
                                case "Fill":
                                    mPanel_Dock = DockStyle.Fill;
                                    break;
                                case "None":
                                    mPanel_Dock = DockStyle.None;
                                    break;
                            }
                        }
                        else if (row_str.Contains("MPanel_Width:"))
                        {
                            mPanel_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_WidthToBind:"))
                        {
                            mPanel_WidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_WidthToBindPrev:"))
                        {
                            mPanel_WidthToBindPrev = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelImager_WidthToBindPrev:"))
                        {
                            mPanel_WidthToBindPrev = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_DisplayWidth:"))
                        {
                            mPanel_DisplayWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_DisplayWidthDecimal:"))
                        {
                            mPanel_DisplayWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Height:"))
                        {
                            mPanel_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_HeightToBind:"))
                        {
                            mPanel_HeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_HeightToBindPrev:"))
                        {
                            mPanel_HeightToBindPrev = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelImager_HeightToBindPrev:"))
                        {
                            mPanel_HeightToBindPrev = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_DisplayHeight:"))
                        {
                            mPanel_DisplayHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_DisplayHeightDecimal:"))
                        {
                            mPanel_DisplayHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Type:"))
                        {
                            mPanel_Type = Convert.ToString(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_FlowDirection:"))
                        {
                            switch (extractedValue_str)
                            {
                                case "BottomUp":
                                    mPanel_FlowDirection = FlowDirection.BottomUp;
                                    break;
                                case "LeftToRight":
                                    mPanel_FlowDirection = FlowDirection.LeftToRight;
                                    break;
                                case "RightToLeft":
                                    mPanel_FlowDirection = FlowDirection.RightToLeft;
                                    break;
                                case "TopDown":
                                    mPanel_FlowDirection = FlowDirection.TopDown;
                                    break;
                            }
                        }
                        else if (row_str.Contains("MPanel_Visibility:"))
                        {
                            mPanel_Visibility = Convert.ToBoolean(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelImageRenderer_Zoom:"))
                        {
                            mPanelImageRenderer_Zoom = float.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelImageRenderer_Height:"))
                        {
                            mPanelImageRenderer_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelImageRenderer_Width:"))
                        {
                            mPanelImageRenderer_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Divisions:"))
                        {
                            mPanel_Divisions = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Parent:"))
                        {
                            mPanel_Parent = _frameModel.Frame_UC;
                        }
                        else if (row_str.Contains("MPanel_FrameGroup:"))
                        {
                            mPanel_FrameGroup = _frameModel.Frame_UC;
                        }
                        else if (row_str.Contains("MPanel_FrameModelParent:"))
                        {
                            mPanel_FrameModelParent = _frameModel;
                        }
                        else if (extractedValue_str.Contains("Margin"))
                        {
                            string[] arr = extractedValue_str.Split(new char[] { ',' }, StringSplitOptions.None);
                            Padding marginPad = new Padding(Convert.ToInt32(Regex.Match(arr[0], @"\d+").ToString()),
                                                            Convert.ToInt32(Regex.Match(arr[1], @"\d+").ToString()),
                                                            Convert.ToInt32(Regex.Match(arr[2], @"\d+").ToString()),
                                                            Convert.ToInt32(Regex.Match(arr[3], @"\d+").ToString())
                                                            );
                            if (row_str.Contains("MPanel_Margin:"))
                            {
                                mPanel_Margin = marginPad;
                            }
                            else if (row_str.Contains("MPanelImageRenderer_Margin:"))
                            {
                                mPanelImageRenderer_Margin = marginPad;
                            }
                        }

                        else if (row_str.Contains("MPanel_Index_Inside_MPanel:"))
                        {
                            mPanel_Index_Inside_MPanel = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelLst_Panel:"))
                        {
                            mPanelLst_Panel = new List<IPanelModel>();
                        }
                        else if (row_str.Contains("MPanelLst_Divider:"))
                        {
                            mPanelLst_Divider = new List<IDividerModel>();
                        }
                        else if (row_str.Contains("MPanelLst_MultiPanel:"))
                        {
                            mPanelLst_MultiPanel = new List<IMultiPanelModel>();
                        }
                        else if (row_str.Contains("MPanelLst_Objects:"))
                        {
                            //mPanelLst_Objects = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelLst_Imagers:"))
                        {
                            //mPanelLst_Imagers = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanelProp_Height:"))
                        {
                            //mPanelProp_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_NumEnable:"))
                        {
                            mPanel_NumEnable = Convert.ToBoolean(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Placement: "))
                        {
                            mPanel_Placement = extractedValue_str;
                        }
                        else if (row_str.Contains("MPanel_ParentModel:"))
                        {

                            //mPanel_ParentModel = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_DividerEnabled:"))
                        {
                            mPanel_DividerEnabled = Convert.ToBoolean(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_Zoom:"))
                        {
                            mPanel_Zoom = float.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_StackNo:"))
                        {
                            mPanel_StackNo = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_AddPixel:"))
                        {
                            mPanel_AddPixel = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalDisplayWidth:"))
                        {
                            mPanel_OriginalDisplayWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalDisplayWidthDecimal:"))
                        {
                            mPanel_OriginalDisplayWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalDisplayHeight:"))
                        {
                            mPanel_OriginalDisplayHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalDisplayHeightDecimal:"))
                        {
                            mPanel_OriginalDisplayHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalGlassWidth:"))
                        {
                            mPanel_OriginalGlassWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalGlassWidthDecimal:"))
                        {
                            mPanel_OriginalGlassWidthDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalGlassHeight:"))
                        {
                            mPanel_OriginalGlassHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_OriginalGlassHeightDecimal:"))
                        {
                            mPanel_OriginalGlassHeightDecimal = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_CmenuDeleteVisibility:"))
                        {
                            mPanel_CmenuDeleteVisibility = Convert.ToBoolean(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("MPanel_GlassBalanced:"))
                        {
                            mPanel_GlassBalanced = Convert.ToBoolean(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            IFramePropertiesUC framePropUC = (FramePropertiesUC)_frameModel.Frame_PropertiesUC;
                            _frameModel.SetDeductFramePadding(true);
                            IMultiPanelModel multipanelModel = _multipanelServices.AddMultiPanelModel(mPanel_Width,
                                                                                                      mPanel_Height,
                                                                                                      mPanel_DisplayWidth,
                                                                                                      mPanel_DisplayWidthDecimal,
                                                                                                      mPanel_DisplayHeight,
                                                                                                      mPanel_DisplayHeightDecimal,
                                                                                                      mPanel_Parent,
                                                                                                      mPanel_FrameGroup,
                                                                                                      mPanel_FrameModelParent,
                                                                                                      mPanel_Visibility,
                                                                                                      mPanel_FlowDirection,
                                                                                                      mPanel_Zoom,
                                                                                                      mPanel_ID,
                                                                                                      mPanel_Dock,
                                                                                                      mPanel_StackNo,
                                                                                                      mPanel_Index_Inside_MPanel,
                                                                                                      mPanel_ParentModel,
                                                                                                      mPanelImageRenderer_Zoom,
                                                                                                      mPanel_Name,
                                                                                                      mPanel_Divisions,
                                                                                                      mPanelLst_Panel,
                                                                                                      mPanelLst_Divider,
                                                                                                      mPanelLst_MultiPanel,
                                                                                                      mPanelLst_Objects,
                                                                                                      mPanelLst_Imagers);
                            if (mpnllvl == "second level")
                            {
                                _multiPanelModel = multipanelModel;
                                _multiPanelModel.MPanel_WidthToBind = mPanel_WidthToBind;
                                _multiPanelModel.MPanel_WidthToBindPrev = mPanel_WidthToBindPrev;
                                _multiPanelModel.MPanelImager_WidthToBindPrev = mPanelImager_WidthToBindPrev;
                                _multiPanelModel.MPanel_HeightToBind = mPanel_HeightToBind;
                                _multiPanelModel.MPanel_HeightToBindPrev = mPanel_HeightToBindPrev;
                                _multiPanelModel.MPanelImager_HeightToBindPrev = mPanelImager_HeightToBindPrev;
                                _multiPanelModel.MPanel_Type = mPanel_Type;
                                _multiPanelModel.MPanelImageRenderer_Height = mPanelImageRenderer_Height;
                                _multiPanelModel.MPanelImageRenderer_Width = mPanelImageRenderer_Width;
                                _multiPanelModel.MPanel_Margin = mPanel_Margin;
                                _multiPanelModel.MPanelImageRenderer_Margin = mPanelImageRenderer_Margin;
                                _multiPanelModel.MPanelProp_Height = mPanelProp_Height;
                                _multiPanelModel.MPanel_NumEnable = mPanel_NumEnable;
                                _multiPanelModel.MPanel_Placement = mPanel_Placement;
                                _multiPanelModel.MPanel_DividerEnabled = mPanel_DividerEnabled;
                                _multiPanelModel.MPanel_OriginalDisplayWidth = mPanel_OriginalDisplayWidth;
                                _multiPanelModel.MPanel_OriginalDisplayWidthDecimal = mPanel_OriginalDisplayWidthDecimal;
                                _multiPanelModel.MPanel_OriginalDisplayHeight = mPanel_OriginalDisplayHeight;
                                _multiPanelModel.MPanel_OriginalDisplayHeightDecimal = mPanel_OriginalDisplayHeightDecimal;
                                _multiPanelModel.MPanel_OriginalGlassWidth = mPanel_OriginalGlassWidth;
                                _multiPanelModel.MPanel_OriginalGlassWidthDecimal = mPanel_OriginalGlassWidthDecimal;
                                _multiPanelModel.MPanel_OriginalGlassHeight = mPanel_OriginalGlassHeight;
                                _multiPanelModel.MPanel_OriginalGlassHeightDecimal = mPanel_OriginalGlassHeightDecimal;
                                _multiPanelModel.MPanel_CmenuDeleteVisibility = mPanel_CmenuDeleteVisibility;
                                _multiPanelModel.MPanel_GlassBalanced = mPanel_GlassBalanced;

                                _multiPanelModel.Set_DimensionToBind_using_FrameDimensions();
                                _multiPanelModel.Imager_Set_DimensionToBind_using_FrameDimensions();
                                _frameModel.Lst_MultiPanel.Add(_multiPanelModel);
                                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPanelPropertiesUCP.GetNewInstance(_unityC, _multiPanelModel, this);
                                UserControl multiPropUC = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                                multiPropUC.Dock = DockStyle.Top;
                                framePropUC.GetFramePropertiesPNL().Controls.Add(multiPropUC);
                                _multiPropUCP2_given = multiPropUCP;
                                multiPropUC.BringToFront();
                                _multiPanelModel.AdjustPropertyPanelHeight("Mpanel", "add");
                                _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");
                                if (mPanel_Type.Contains("Mullion"))
                                {
                                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel,
                                                                                                                                      _frameModel,
                                                                                                                                      _frameImagerUCP);
                                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                                    IMultiPanelMullionUCPresenter multiUCP = (MultiPanelMullionUCPresenter)_multiMullionUCP.GetNewInstance(_unityC,
                                                                                                      _multiPanelModel,
                                                                                                      _frameModel,
                                                                                                      this,
                                                                                                      _frameUCPresenter,
                                                                                                      _multiTransomUCP,
                                                                                                      multiPropUCP,
                                                                                                      _frameImagerUCP,
                                                                                                      _basePlatformImagerUCPresenter,
                                                                                                      multiMullionImagerUCP);
                                    _multiMullionUC = multiUCP.GetMultiPanel();
                                    _multiMullionUCP = multiUCP;
                                    _frameModel.Frame_UC.Controls.Add((UserControl)_multiMullionUC);
                                    _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                                    _basePlatformImagerUCPresenter.Invalidate_flpMain();
                                }
                                else if (mPanel_Type.Contains("Transom"))
                                {
                                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel,
                                                                                                                                      _frameModel,
                                                                                                                                      _frameImagerUCP);
                                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                                    IMultiPanelTransomUCPresenter multiUCP = (MultiPanelTransomUCPresenter)_multiTransomUCP.GetNewInstance(_unityC,
                                                                                                                    _multiPanelModel,
                                                                                                                    _frameModel,
                                                                                                                    this,
                                                                                                                    _frameUCPresenter,
                                                                                                                    multiPropUCP,
                                                                                                                    _frameImagerUCP,
                                                                                                                    _basePlatformImagerUCPresenter,
                                                                                                                    multiTransomImagerUCP);
                                    _multiTransomUC = multiUCP.GetMultiPanel();
                                    _multiTransomUCP = multiUCP;
                                    _frameModel.Frame_UC.Controls.Add((UserControl)_multiTransomUC);
                                    _basePlatformPresenter.InvalidateBasePlatform();
                                }
                            }
                            #region 3rd level
                            else if (mpnllvl == "third level") //drawing of 3rd level multipanel objs
                            {
                                multipanelModel.MPanel_WidthToBind = mPanel_WidthToBind;
                                multipanelModel.MPanel_WidthToBindPrev = mPanel_WidthToBindPrev;
                                multipanelModel.MPanelImager_WidthToBindPrev = mPanelImager_WidthToBindPrev;
                                multipanelModel.MPanel_HeightToBind = mPanel_HeightToBind;
                                multipanelModel.MPanel_HeightToBindPrev = mPanel_HeightToBindPrev;
                                multipanelModel.MPanelImager_HeightToBindPrev = mPanelImager_HeightToBindPrev;
                                multipanelModel.MPanel_Type = mPanel_Type;
                                multipanelModel.MPanelImageRenderer_Height = mPanelImageRenderer_Height;
                                multipanelModel.MPanelImageRenderer_Width = mPanelImageRenderer_Width;
                                multipanelModel.MPanel_Margin = mPanel_Margin;
                                multipanelModel.MPanelImageRenderer_Margin = mPanelImageRenderer_Margin;
                                multipanelModel.MPanelProp_Height = mPanelProp_Height;
                                multipanelModel.MPanel_NumEnable = mPanel_NumEnable;
                                multipanelModel.MPanel_Placement = mPanel_Placement;
                                multipanelModel.MPanel_DividerEnabled = mPanel_DividerEnabled;
                                multipanelModel.MPanel_OriginalDisplayWidth = mPanel_OriginalDisplayWidth;
                                multipanelModel.MPanel_OriginalDisplayWidthDecimal = mPanel_OriginalDisplayWidthDecimal;
                                multipanelModel.MPanel_OriginalDisplayHeight = mPanel_OriginalDisplayHeight;
                                multipanelModel.MPanel_OriginalDisplayHeightDecimal = mPanel_OriginalDisplayHeightDecimal;
                                multipanelModel.MPanel_OriginalGlassWidth = mPanel_OriginalGlassWidth;
                                multipanelModel.MPanel_OriginalGlassWidthDecimal = mPanel_OriginalGlassWidthDecimal;
                                multipanelModel.MPanel_OriginalGlassHeight = mPanel_OriginalGlassHeight;
                                multipanelModel.MPanel_OriginalGlassHeightDecimal = mPanel_OriginalGlassHeightDecimal;
                                multipanelModel.MPanel_CmenuDeleteVisibility = mPanel_CmenuDeleteVisibility;
                                multipanelModel.MPanel_GlassBalanced = mPanel_GlassBalanced;
                                multipanelModel.MPanel_ParentModel = _multiPanelModel;

                                multipanelModel.Set_DimensionToBind_using_FrameDimensions();
                                multipanelModel.Imager_Set_DimensionToBind_using_FrameDimensions();
                                _frameModel.Lst_MultiPanel.Add(multipanelModel);
                                _multiPanelModel.MPanelLst_MultiPanel.Add(multipanelModel);
                                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPanelPropertiesUCP.GetNewInstance(_unityC, multipanelModel, this);
                                UserControl multiPropUC = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                                multiPropUC.Dock = DockStyle.Top;
                                _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(multiPropUC);
                                multiPropUC.BringToFront();
                                if (mPanel_Type.Contains("Mullion"))
                                {
                                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      multipanelModel,
                                                                                                                                      _frameModel,
                                                                                                                                      _frameImagerUCP);
                                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                                    //_frameImagerUCP.AddControl((UserControl)multiMullionImagerUC);
                                    IMultiPanelMullionUCPresenter multiUCP = (MultiPanelMullionUCPresenter)_multiMullionUCP.GetNewInstance(_unityC,
                                                                                                      multipanelModel,
                                                                                                      _frameModel,
                                                                                                      this,
                                                                                                      _frameUCPresenter,
                                                                                                      _multiTransomUCP,
                                                                                                      _multiPropUCP2_given,
                                                                                                      _frameImagerUCP,
                                                                                                      _basePlatformImagerUCPresenter,
                                                                                                      multiMullionImagerUCP);
                                    IMultiPanelMullionUC multMullionUC = multiUCP.GetMultiPanel();
                                    _multiMullionUCP = multiUCP;
                                    foreach (IMultiPanelTransomUC multiTransomUC in _frameModel.Frame_UC.Controls)
                                    {
                                        multiTransomUC.Getflp().Controls.Add((UserControl)multMullionUC);
                                        multiUCP.SetInitialLoadFalse();
                                        multipanelModel.MPanel_Parent = multiTransomUC.Getflp();
                                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multMullionUC, _frameModel.Frame_Type.ToString());
                                        _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)multMullionUC, _frameModel.Frame_Type.ToString());
                                    }

                                    _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                                }
                                else if (mPanel_Type.Contains("Transom"))
                                {
                                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      multipanelModel,
                                                                                                                                      _frameModel,
                                                                                                                                      _frameImagerUCP);
                                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                                    //_frameImagerUCP.AddControl((UserControl)multiTransomImagerUC);

                                    IMultiPanelTransomUCPresenter multiTransomUCP = (MultiPanelTransomUCPresenter)_multiTransomUCP.GetNewInstance(_unityC,
                                                                                                                    multipanelModel,
                                                                                                                    _frameModel,
                                                                                                                    this,
                                                                                                                    _frameUCPresenter,
                                                                                                                    _multiPropUCP2_given,
                                                                                                                    _frameImagerUCP,
                                                                                                                    _basePlatformImagerUCPresenter,
                                                                                                                    multiTransomImagerUCP);
                                    IMultiPanelTransomUC multTransomUC = multiTransomUCP.GetMultiPanel();
                                    _multiTransomUCP = multiTransomUCP;
                                    foreach (IMultiPanelMullionUC multiMullionUC in _frameModel.Frame_UC.Controls)
                                    {
                                        multiMullionUC.Getflp().Controls.Add((UserControl)multTransomUC);
                                        multiTransomUCP.SetInitialLoadFalse();
                                        multipanelModel.MPanel_Parent = multiMullionUC.Getflp();
                                        _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multTransomUC, _frameModel.Frame_Type.ToString());
                                        _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)multTransomUC, _frameModel.Frame_Type.ToString());
                                    }
                                    _basePlatformPresenter.InvalidateBasePlatform();
                                }
                                if (multipanelModel.MPanel_Placement == "Last")
                                {
                                    if (_multiPanelModel.MPanel_Zoom == 0.5 || _multiPanelModel.MPanel_Zoom == 1)
                                    {
                                        _multiPanelModel.Fit_MyControls_Dimensions();

                                    }
                                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                                    _multiPanelModel.Fit_MyControls_ToBindDimensions();

                                }
                            }
                            #endregion
                            inside_multi = false;
                        }
                        #endregion
                    }
                    else if (inside_divider)
                    {
                        #region Load for Divider
                        if (row_str.Contains("Div_ID:"))
                        {
                            div_ID = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_Name:"))
                        {
                            div_Name = extractedValue_str;
                        }
                        else if (row_str.Contains("Div_Type:"))
                        {
                            if (extractedValue_str == "Mullion")
                            {
                                div_Type = DividerModel.DividerType.Mullion;
                            }
                            else
                            {
                                div_Type = DividerModel.DividerType.Transom;
                            }
                        }
                        else if (row_str.Contains("Div_Width:"))
                        {
                            div_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_DisplayWidth:"))
                        {
                            div_DisplayWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_Height:"))
                        {
                            div_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_DisplayHeight:"))
                        {
                            div_DisplayHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_Visible:"))
                        {
                            div_Visible = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_Parent:"))
                        {
                            //if (_multiPanelModel.MPanel_Type == "Mullion")
                            //{
                            //    div_Parent = _multiMullionUC.Getflp();

                            //}
                            //else
                            //{
                            //    div_Parent = _multiTransomUC.Getflp();
                            //}
                        }
                        else if (row_str.Contains("Div_FrameType:"))
                        {
                            div_FrameType = extractedValue_str;
                        }
                        else if (row_str.Contains("DivImageRenderer_Zoom:"))
                        {
                            divImageRenderer_Zoom = float.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("DivImageRenderer_Height:"))
                        {
                            divImageRenderer_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("DivImageRenderer_Width:"))
                        {
                            divImageRenderer_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_Zoom:"))
                        {
                            div_Zoom = float.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_WidthToBind:"))
                        {
                            div_WidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_HeightToBind:"))
                        {
                            div_HeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_CladdingBracketForUPVCQTY:"))
                        {
                            div_CladdingBracketForUPVCQTY = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_CladdingBracketForConcreteQTY:"))
                        {
                            div_CladdingBracketForConcreteQTY = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_claddingBracketVisibility:"))
                        {
                            div_claddingBracketVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_DMArtNo:"))
                        {
                            foreach (DummyMullion_ArticleNo dman in DummyMullion_ArticleNo.GetAll())
                            {
                                if (dman.ToString() == extractedValue_str)
                                {
                                    div_DMArtNo = dman;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_AlumSpacer50Qty:"))
                        {
                            div_AlumSpacer50Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_EndcapDM:"))
                        {
                            foreach (EndcapDM_ArticleNo ecdman in EndcapDM_ArticleNo.GetAll())
                            {
                                if (ecdman.ToString() == extractedValue_str)
                                {
                                    div_EndcapDM = ecdman;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_FixedCamDM:"))
                        {
                            foreach (FixedCam_ArticleNo fcan in FixedCam_ArticleNo.GetAll())
                            {
                                if (fcan.ToString() == extractedValue_str)
                                {
                                    div_FixedCamDM = fcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_SnapNKeepDM:"))
                        {
                            foreach (SnapInKeep_ArticleNo sikan in SnapInKeep_ArticleNo.GetAll())
                            {
                                if (sikan.ToString() == extractedValue_str)
                                {
                                    div_SnapNKeepDM = sikan;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_ChkDM:"))
                        {
                            div_ChkDM = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_ChkDMVisibility:"))
                        {
                            div_ChkDMVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_ArtVisibility:"))
                        {
                            div_ArtVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_MPanelParent:"))
                        {
                            div_MPanelParent = _multiPanelModel;
                        }
                        else if (row_str.Contains("Div_FrameParent:"))
                        {
                            div_FrameParent = _frameModel;
                        }
                        else if (row_str.Contains("Div_DMPanel:"))
                        {

                            foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                            {
                                if (pnl.Panel_Name == extractedValue_str)
                                {
                                    div_DMPanel = pnl;
                                }
                            }
                            //div_DMPanel = _panelMode;
                        }
                        else if (row_str.Contains("Div_ArtNo:"))
                        {
                            foreach (Divider_ArticleNo dvdan in Divider_ArticleNo.GetAll())
                            {
                                if (dvdan.ToString() == extractedValue_str)
                                {
                                    div_ArtNo = dvdan;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_ReinfArtNo:"))
                        {
                            foreach (DividerReinf_ArticleNo dvdran in DividerReinf_ArticleNo.GetAll())
                            {
                                if (dvdran.ToString() == extractedValue_str)
                                {
                                    div_ReinfArtNo = dvdran;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_ExplosionWidth:"))
                        {
                            div_ExplosionWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_ExplosionHeight:"))
                        {
                            div_ExplosionHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_ReinfWidth:"))
                        {
                            div_ReinfWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_ReinfHeight:"))
                        {
                            div_ReinfHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_Bounded:"))
                        {
                            div_Bounded = extractedValue_str;
                        }
                        else if (row_str.Contains("Div_MechJoinArtNo:"))
                        {
                            foreach (Divider_MechJointArticleNo dvdmjan in Divider_MechJointArticleNo.GetAll())
                            {
                                if (dvdmjan.ToString() == extractedValue_str)
                                {
                                    div_MechJoinArtNo = dvdmjan;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_CladdingProfileArtNoVisibility:"))
                        {
                            div_CladdingProfileArtNoVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_CladdingProfileArtNo:"))
                        {
                            foreach (CladdingProfile_ArticleNo cpan in CladdingProfile_ArticleNo.GetAll())
                            {
                                if (cpan.ToString() == extractedValue_str)
                                {
                                    div_CladdingProfileArtNo = cpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_CladdingReinfArtNo:"))
                        {
                            foreach (CladdingReinf_ArticleNo cran in CladdingReinf_ArticleNo.GetAll())
                            {
                                if (cran.ToString() == extractedValue_str)
                                {
                                    div_CladdingReinfArtNo = cran;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_CladdingSizeList:"))
                        {
                            string[] words = extractedValue_str.Split(';');

                            div_CladdingSizeList = new Dictionary<int, int>();
                            foreach (string str in words)
                            {
                                if (str.Trim() != string.Empty)
                                {
                                    int key = Convert.ToInt32(str.Split('<', ',')[1]);
                                    int value = Convert.ToInt32(str.Split(',', '>')[1]);
                                    div_CladdingSizeList.Add(key, value);
                                }

                            }
                            //div_CladdingSizeList = extractedValue_str;
                        }
                        else if (row_str.Contains("Div_CladdingCount:"))
                        {
                            div_CladdingCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_PropHeight:"))
                        {
                            //div_PropHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Div_LeverEspagVisibility:"))
                        {
                            div_LeverEspagVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Div_LeverEspagArtNo:"))
                        {
                            foreach (LeverEspagnolette_ArticleNo lean in LeverEspagnolette_ArticleNo.GetAll())
                            {
                                if (lean.ToString() == extractedValue_str)
                                {
                                    div_LeverEspagArtNo = lean;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_ShootboltStrikerArtNo:"))
                        {
                            div_ShootboltStrikerArtNo = ShootboltStriker_ArticleNo._N705A20106;
                        }
                        else if (row_str.Contains("Div_ShootboltNonReverseArtNo:"))
                        {
                            foreach (ShootboltNonReverse_ArticleNo sbnran in ShootboltNonReverse_ArticleNo.GetAll())
                            {
                                if (sbnran.ToString() == extractedValue_str)
                                {
                                    div_ShootboltNonReverseArtNo = sbnran;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_ShootboltReverseArtNo:"))
                        {
                            foreach (ShootboltReverse_ArticleNo sbran in ShootboltReverse_ArticleNo.GetAll())
                            {
                                if (sbran.ToString() == extractedValue_str)
                                {
                                    div_ShootboltReverseArtNo = sbran;
                                }
                            }
                        }
                        else if (row_str.Contains("Div_DMStrikerArtNo:"))
                        {
                            foreach (DummyMullionStriker_ArticleNo dmsan in DummyMullionStriker_ArticleNo.GetAll())
                            {
                                if (dmsan.ToString() == extractedValue_str)
                                {
                                    div_DMStrikerArtNo = dmsan;
                                }
                            }
                            int divSize = 0;
                            if (_frameModel.Frame_Type.ToString().Contains("Window"))
                            {
                                divSize = 26;
                            }
                            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
                            {
                                divSize = 33;
                            }
                            //bool divchkdm = false;

                            //if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                            //{
                            //    if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                            //        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                            //    {
                            //        if (_multiPanelModel.MPanel_ParentModel == null)
                            //        {
                            //            divchkdm = true;
                            //        }
                            //        else if (_multiPanelModel.MPanel_ParentModel != null)
                            //        {
                            //            if (_multiPanelModel.MPanel_Placement == "Last")
                            //            {
                            //                divchkdm = true;
                            //            }
                            //        }
                            //    }
                            //}
                            //FlowLayoutPanel fpnl;
                            int divHeigth = 0,
                                divWidth = 0;
                            if (_multiPanelModel.MPanel_Type == "Mullion")
                            {
                                //fpnl = _multiMullionUC.Getflp();
                                divWidth = divSize;
                                divHeigth = _multiPanelModel.MPanel_Height;
                            }
                            else
                            {
                                //fpnl = _multiTransomUC.Getflp();
                                divWidth = _multiPanelModel.MPanel_Width;
                                divHeigth = divSize;
                            }
                            IDividerModel divModel = _divServices.AddDividerModel(div_Width,
                                                                                  div_Height,
                                                                                  div_Parent,
                                                                                  div_Type,
                                                                                  div_Visible,
                                                                                  div_Zoom,
                                                                                  div_ArtNo,
                                                                                  div_DisplayWidth,
                                                                                  div_DisplayHeight,
                                                                                  div_MPanelParent,
                                                                                  div_FrameParent,
                                                                                  GetDividerCount(),
                                                                                  divImageRenderer_Zoom,
                                                                                  _frameModel.Frame_Type.ToString(),
                                                                                  div_Name,
                                                                                  null,
                                                                                  div_ChkDM);
                            divModel.Div_ID = div_ID;
                            divModel.DivImageRenderer_Height = divImageRenderer_Height;
                            divModel.DivImageRenderer_Width = divImageRenderer_Width;
                            divModel.Div_WidthToBind = div_WidthToBind;
                            divModel.Div_HeightToBind = div_HeightToBind;
                            divModel.Div_CladdingBracketForUPVCQTY = div_CladdingBracketForUPVCQTY;
                            divModel.Div_CladdingBracketForConcreteQTY = div_CladdingBracketForConcreteQTY;
                            divModel.Div_ExplosionWidth = div_ExplosionWidth;
                            divModel.Div_ExplosionHeight = div_ExplosionHeight;
                            divModel.Div_ReinfWidth = div_ReinfWidth;
                            divModel.Div_ReinfHeight = div_ReinfHeight;
                            divModel.Div_CladdingCount = div_CladdingCount;
                            divModel.Div_AlumSpacer50Qty = div_AlumSpacer50Qty;
                            divModel.Div_FrameType = div_FrameType;
                            divModel.Div_Bounded = div_Bounded;
                            divModel.Div_claddingBracketVisibility = div_claddingBracketVisibility;
                            divModel.Div_ChkDMVisibility = div_ChkDMVisibility;
                            divModel.Div_ArtVisibility = div_ArtVisibility;
                            divModel.Div_CladdingProfileArtNoVisibility = div_CladdingProfileArtNoVisibility;
                            divModel.Div_LeverEspagVisibility = div_LeverEspagVisibility;
                            //divModel.Div_Parent = div_Parent;
                            divModel.Div_DMArtNo = div_DMArtNo;
                            divModel.Div_EndcapDM = div_EndcapDM;
                            divModel.Div_FixedCamDM = div_FixedCamDM;
                            divModel.Div_SnapNKeepDM = div_SnapNKeepDM;
                            divModel.Div_DMPanel = div_DMPanel;
                            divModel.Div_ReinfArtNo = div_ReinfArtNo;
                            divModel.Div_MechJoinArtNo = div_MechJoinArtNo;
                            divModel.Div_CladdingProfileArtNo = div_CladdingProfileArtNo;
                            divModel.Div_CladdingReinfArtNo = div_CladdingReinfArtNo;
                            divModel.Div_LeverEspagArtNo = div_LeverEspagArtNo;
                            divModel.Div_ShootboltStrikerArtNo = div_ShootboltStrikerArtNo;
                            divModel.Div_ShootboltNonReverseArtNo = div_ShootboltNonReverseArtNo;
                            divModel.Div_ShootboltReverseArtNo = div_ShootboltReverseArtNo;
                            divModel.Div_DMStrikerArtNo = div_DMStrikerArtNo;
                            divModel.Div_CladdingSizeList = div_CladdingSizeList;
                            divModel.SetDimensionsToBind_using_DivZoom();
                            divModel.SetDimensionsToBind_using_DivZoom_Imager_Initial();
                            _prev_divModel = divModel;
                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);
                            IDividerPropertiesUCPresenter divPropUCP = _divPropertiesUCP.GetNewInstance(_unityC, divModel, this);
                            UserControl divPropUC = (UserControl)divPropUCP.GetDivProperties();
                            divPropUC.Dock = DockStyle.Top;
                            _multiPanelModel.AdjustPropertyPanelHeight("Div", "add");
                            _frameModel.AdjustPropertyPanelHeight("Div", "add");
                            if (_multiPanelModel.MPanel_Type == "Mullion")
                            {
                                _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                divPropUC.BringToFront();
                                IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                            divModel,
                                                                                            _multiPanelModel,
                                                                                            _multiMullionUCP,
                                                                                            _frameModel,
                                                                                            this);
                                IMullionUC mullionUC = mullionUCP.GetMullion();
                                _multiMullionUC.Getflp().Controls.Add((UserControl)mullionUC);
                                mullionUCP.SetInitialLoadFalse();
                                _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                                _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                            }
                            else
                            {
                                _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                divPropUC.BringToFront();
                                ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                            divModel,
                                                                                            _multiPanelModel,
                                                                                            _multiTransomUCP,
                                                                                            _frameModel,
                                                                                            this);
                                ITransomUC transomUC = transomUCP.GetTransom();
                                _multiTransomUC.Getflp().Controls.Add((UserControl)transomUC);
                                transomUCP.SetInitialLoadFalse();
                                _multiPanelModel.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                                _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                            }
                            _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            _basePlatformImagerUCPresenter.Invalidate_flpMain();
                            inside_divider = false;
                        }
                        #endregion
                    }
                    break;
            }
        }


        #endregion

        bool inside_quotation, inside_item, inside_frame, inside_panel, inside_multi, inside_divider;
        int frmDimension_numWd = 0,
            frmDimension_numHt = 0;
        string frmDimension_profileType = "",
               frmDimension_baseColor = "";

        #region WindoorModel Properties

        //string wD_profile,
        //       wD_name,
        //       wD_description,
        //       wD_Dimension;
        //int wD_height,
        //    wD_width,
        //    wD_id,
        //    wD_width_4basePlatform,
        //    wD_width_4basePlatform_forImageRenderer,
        //    wD_height_4basePlatform,
        //    wD_height_4basePlatform_forImageRenderer,
        //    wD_PropertiesScroll,
        //    wD_price,
        //    wD_quantity,
        //    frameIDCounter,
        //    concreteIDCounter,
        //    panelIDCounter,
        //    mpanelIDCounter,
        //    divIDCounter,
        //    panelGlassID_Counter,
        //    lbl_ArrowHtCount,
        //    div_ArrowCount,
        //    lbl_ArrowWdCount,
        //    wD_pboxImagerHeight;
        //Base_Color wD_BaseColor;
        //bool 
        //    wD_visibility,
        //    wD_orientation,
        //    wD_SlidingTopViewVisibility,
        //    wD_CmenuDeleteVisibility,
        //    wD_Selected,
        //    wD_customArrowToggle;
        //double wD_zoom,
        //    wD_zoom_forImageRenderer,
        //    arr_ZoomPercentage;
        //decimal wD_discount,
        //    wD_PlasticCover,
        //    wD_CostingPoints;

        //IFrameModel lst_frame;
        //IConcreteModel lst_concrete;
        //Foil_Color wD_InsideColor,
        //    wD_OutsideColor;
        #endregion
        #region Panel Properties
        //Panel 
        string panel_Name,
               panel_ChkText,
               panel_Type,
               panel_Placement;
        int panel_Height,
            panel_OriginalHeight,
            panel_ImageRenderer_Height,
            panel_HeightToBind,
            panel_DisplayHeight,
            panel_DisplayHeightDecimal,
            panel_OriginalDisplayHeight,
            panel_OriginalDisplayHeightDecimal,
            panel_ID,
            panel_Width,
            panel_OriginalWidth,
            panel_ImageRenderer_Width,
            panel_WidthToBind,
            panel_DisplayWidth,
            panel_DisplayWidthDecimal,
            panel_OriginalDisplayWidth,
            panel_OriginalDisplayWidthDecimal,
            panel_Index_Inside_MPanel,
            panel_Index_Inside_SPanel,
            panel_PropertyHeight,
            panel_HandleOptionsHeight,
            panel_LouverBladesCount;
        bool panel_Orient,
             panel_OrientVisibility,
             panel_Visibility,
             panel_HandleOptionsVisibility,
             panel_RotoswingOptionsVisibility,
             panel_RioOptionsVisibility,
             panel_RioOptionsVisibility2,
             panel_RotolineOptionsVisibility,
             panel_MVDOptionsVisibility,
             panel_RotaryOptionsVisibility,
             panel_SlidingTypeVisibility;
        float panel_ImageRendererZoom,
              panel_Zoom;

        DockStyle panel_Dock;
        Control panel_Parent;
        UserControl panel_MultiPanelGroup,
                    panel_FrameGroup,
                    panel_FramePropertiesGroup;
        OverlapSash panel_OverlapSash;
        Padding panel_Margin,
                panel_MarginToBind,
                panel_ImageRenderer_Margin;
        IFrameModel panel_ParentFrameModel;
        IMultiPanelModel panel_ParentMultiPanelModel;
        Color panel_BackColor;
        SlidingTypes panel_SlidingTypes;

        #region Explosion Properties 
        string panel_GlassThicknessDesc;
        float panel_GlassThickness;
        bool panel_ChkGlazingAdaptor,
             panel_SashPropertyVisibility,
             panel_EspagnoletteOptionsVisibility,
             panel_ExtTopChk,
             panel_ExtTop2Chk,
             panel_ExtBotChk,
             panel_ExtLeftChk,
             panel_ExtRightChk,
             panel_CornerDriveOptionsVisibility,
             panel_ExtensionOptionsVisibility,
             panel_MotorizedOptionVisibility,
             panel_2dHingeVisibility_nonMotorized,
             panel_3dHingePropertyVisibility,
             panel_2dHingeVisibility,
             panel_ButtHingeVisibility,
             panel_GeorgianBarOptionVisibility,
             panel_HingeOptionsVisibility,
             panel_CenterHingeOptionsVisibility,
             panel_CmenuDeleteVisibility,
             panel_NTCenterHingeVisibility,
             panel_MiddleCloserVisibility,
             panel_MotorizedpnlOptionVisibility,
             panel_AluminumTrackQtyVisibility,
             panel_RollersTypesVisibility,
             panel_DHandleOptionVisibilty,
             panel_DHandleIOLockingOptionVisibilty,
             panel_DummyDHandleOptionVisibilty,
             panel_PopUpHandleOptionVisibilty,
             panel_TrackRailArtNoVisibility,
             panel_RotoswingForSlidingHandleOptionVisibilty;
        int panel_GlassID,
            panel_GlazingBeadWidth,
            panel_GlazingBeadWidthDecimal,
            panel_GlazingBeadHeight,
            panel_GlazingBeadHeightDecimal,
            panel_GlassWidth,
            panel_GlassWidthDecimal,
            panel_OriginalGlassWidth,
            panel_OriginalGlassWidthDecimal,
            panel_GlassHeight,
            panel_GlassHeightDecimal,
            panel_OriginalGlassHeight,
            panel_OriginalGlassHeightDecimal,
            panel_GlassPropertyHeight,
            panel_GlazingSpacerQty,
            panel_SashWidth,
            panel_SashWidthDecimal,
            panel_SashHeight,
            panel_SashHeightDecimal,
            panel_OriginalSashWidth,
            panel_OriginalSashWidthDecimal,
            panel_OriginalSashHeight,
            panel_OriginalSashHeightDecimal,
            panel_SashReinfWidth,
            panel_SashReinfWidthDecimal,
            panel_SashReinfHeight,
            panel_SashReinfHeightDecimal,
            panel_ExtTopQty,
            panel_ExtBotQty,
            panel_ExtLeftQty,
            panel_ExtRightQty,
            panel_ExtTop2Qty,
            panel_ExtTop3Qty,
            panel_ExtBot2Qty,
            panel_ExtLeft2Qty,
            panel_ExtRight2Qty,
            panel_RotoswingOptionsHeight,
            panel_PlasticWedgeQty,
            panel_StrikerQty_A,
            panel_StrikerQty_C,
            panel_MiddleCloserPairQty,
            panel_MotorizedPropertyHeight,
            panel_MotorizedMechQty,
            panel_MotorizedMechSetQty,
            panel_2DHingeQty,
            panel_2DHingeQty_nonMotorized,
            panel_3dHingeQty,
            panel_ButtHingeQty,
            panel_AdjStrikerQty,
            panel_RestrictorStayQty,
            panel_ExtensionPropertyHeight,
            panel_GeorgianBar_VerticalQty,
            panel_GeorgianBar_HorizontalQty,
            panel_HingeOptionsPropertyHeight,
            panel_AluminumTrackQty,
            panel_StrikerArtno_SlidingQty;
        GlazingBead_ArticleNo panel_GlazingBeadArtNo;
        GlazingAdaptor_ArticleNo panel_GlazingAdaptorArtNo;
        GBSpacer_ArticleNo panel_GBSpacerArtNo;
        GlassFilm_Types panel_GlassFilm;
        SashProfile_ArticleNo panel_SashProfileArtNo;
        SashReinf_ArticleNo panel_SashReinfArtNo;
        CoverProfile_ArticleNo panel_CoverProfileArtNo,
                               panel_CoverProfileArtNo2;
        FrictionStay_ArticleNo panel_FrictionStayArtNo;
        FrictionStayCasement_ArticleNo panel_FSCasementArtNo;
        SnapInKeep_ArticleNo panel_SnapInKeepArtNo;
        FixedCam_ArticleNo panel_FixedCamArtNo;
        _30x25Cover_ArticleNo panel_30x25CoverArtNo;
        MotorizedDivider_ArticleNo panel_MotorizedDividerArtNo;
        CoverForMotor_ArticleNo panel_CoverForMotorArtNo;
        _2DHinge_ArticleNo panel_2dHingeArtNo;
        _2DHinge_ArticleNo panel_2dHingeArtNo_nonMotorized;
        PushButtonSwitch_ArticleNo panel_PushButtonSwitchArtNo;
        FalsePole_ArticleNo panel_FalsePoleArtNo;
        SupportingFrame_ArticleNo panel_SupportingFrameArtNo;
        Plate_ArticleNo panel_PlateArtNo;
        Handle_Type panel_HandleType;
        Rotoswing_HandleArtNo panel_RotoswingArtNo;
        Rotary_HandleArtNo panel_RotaryArtNo;
        Rio_HandleArtNo panel_RioArtNo;
        Rio_HandleArtNo panel_RioArtNo2;
        ProfileKnobCylinder_ArtNo panel_ProfileKnobCylinderArtNo;
        Cylinder_CoverArtNo panel_CylinderCoverArtNo;
        Rotoline_HandleArtNo panel_RotolineArtNo;
        MVD_HandleArtNo panel_MVDArtNo;
        Espagnolette_ArticleNo panel_EspagnoletteArtNo;
        Extension_ArticleNo panel_ExtensionTopArtNo,
                            panel_ExtensionTop2ArtNo,
                            panel_ExtensionTop3ArtNo,
                            panel_ExtensionBotArtNo,
                            panel_ExtensionBot2ArtNo,
                            panel_ExtensionLeftArtNo,
                            panel_ExtensionLeft2ArtNo,
                            panel_ExtensionRightArtNo,
                            panel_ExtensionRight2ArtNo;
        CornerDrive_ArticleNo panel_CornerDriveArtNo;
        PlasticWedge_ArticleNo panel_PlasticWedge;
        MiddleCloser_ArticleNo panel_MiddleCloserArtNo;
        LockingKit_ArticleNo panel_LockingKitArtNo;
        GlassType panel_GlassType;
        Striker_ArticleNo panel_StrikerArtno_A; //for Awning
        Striker_ArticleNo panel_StrikerArtno_C; //for Casement
        MotorizedMech_ArticleNo panel_MotorizedMechArtNo;
        _3dHinge_ArticleNo panel_3dHingeArtNo;
        ButtHinge_ArticleNo panel_ButtHingeArtNo;
        AdjustableStriker_ArticleNo panel_AdjStrikerArtNo;
        RestrictorStay_ArticleNo panel_RestrictorStayArtNo;
        GeorgianBar_ArticleNo panel_GeorgianBarArtNo;
        HingeOption panel_HingeOptions;
        CenterHingeOption panel_CenterHingeOptions;
        NTCenterHinge_ArticleNo panel_NTCenterHingeArticleNo;
        StayBearingK_ArticleNo panel_StayBearingKArtNo;
        StayBearingPin_ArticleNo panel_StayBearingPinArtNo;
        StayBearingCover_ArticleNo panel_StayBearingCoverArtNo;
        TopCornerHinge_ArticleNo panel_TopCornerHingeArtNo;
        TopCornerHingeCover_ArticleNo panel_TopCornerHingeCoverArtNo;
        TopCornerHingeSpacer_ArticleNo panel_TopCornerHingeSpacerArtNo;
        CornerHingeK_ArticleNo panel_CornerHingeKArtNo;
        CornerPivotRestK_ArticleNo panel_CornerPivotRestKArtNo;
        CornerHingeCoverK_ArticleNo panel_CornerHingeCoverKArtNo;
        CoverForCornerPivotRestVertical_ArticleNo panel_CoverForCornerPivotRestVerticalArtNo;
        CoverForCornerPivotRest_ArticleNo panel_CoverForCornerPivotRestArtNo;
        WeldableCornerJoint_ArticleNo panel_WeldableCArtNo;
        LatchDeadboltStriker_ArticleNo panel_LatchDeadboltStrikerArtNo;
        GuideTrackProfile_ArticleNo panel_GuideTrackProfileArtNo;
        AluminumTrack_ArticleNo panel_AluminumTrackArtNo;
        WeatherBarFastener_ArticleNo panel_WeatherBarFastenerArtNo;
        EndCapForWeatherBar_ArticleNo panel_EndCapForWeatherBarArtNo;
        WeatherBar_ArticleNo panel_WeatherBarArtNo;
        WaterSeepage_ArticleNo panel_WaterSeepageArtNo;
        BrushSeal_ArticleNo panel_BrushSealArtNo;
        RollersTypes panel_RollersTypes;
        GlazingRebateBlock_ArticleNo panel_GlazingRebateBlockArtNo;
        Spacer_ArticleNo panel_Spacer;
        SealingBlock_ArticleNo panel_SealingBlockArtNo;
        Interlock_ArticleNo panel_InterlockArtNo;
        ExtensionForInterlock_ArticleNo panel_ExtensionForInterlockArtNo;
        D_HandleArtNo panel_DHandleInsideArtNo;
        D_HandleArtNo panel_DHandleOutsideArtNo;
        D_Handle_IO_LockingArtNo panel_DHandleIOLockingInsideArtNo;
        D_Handle_IO_LockingArtNo panel_DHandleIOLockingOutsideArtNo;
        DummyD_HandleArtNo panel_DummyDHandleInsideArtNo;
        DummyD_HandleArtNo panel_DummyDHandleOutsideArtNo;
        PopUp_HandleArtNo panel_PopUpHandleArtNo;
        Rotoswing_Sliding_HandleArtNo panel_RotoswingForSlidingHandleArtNo;
        Striker_ArticleNo panel_StrikerArtno_Sliding;
        ScrewSets panel_ScrewSetsArtNo;
        PVCCenterProfile_ArticleNo panel_PVCCenterProfileArtNo;
        GS100_T_EM_T_HMCOVER_ArticleNo panel_GS100_T_EM_T_HMCOVER_ArtNo;
        TrackProfile_ArticleNo panel_TrackProfileArtNo;
        TrackRail_ArticleNo panel_TrackRailArtNo;
        MicrocellOneSafetySensor_ArticleNo panel_MicrocellOneSafetySensorArtNo;
        AutodoorBracketForGS100UPVC_ArticleNo panel_AutodoorBracketForGS100UPVCArtNo;
        GS100EndCapScrewM5AndLSupport_ArticleNo panel_GS100EndCapScrewM5AndLSupportArtNo;
        EuroLeadExitButton_ArticleNo panel_EuroLeadExitButtonArtNo;
        TOOTHBELT_EM_CM_ArticleNo panel_TOOTHBELT_EM_CMArtNo;
        GuBeaZenMicrowaveSensor_ArticleNo panel_GuBeaZenMicrowaveSensorArtNo;
        SlidingDoorKitGs100_1_ArticleNo panel_SlidingDoorKitGs100_1ArtNo;
        GS100CoverKit_ArticleNo panel_GS100CoverKitArtNo;
        #endregion
        #endregion
        #region Divider Properties
        int div_ID,
            div_Width,
            div_DisplayWidth,
            div_Height,
            div_DisplayHeight,
            divImageRenderer_Height,
            divImageRenderer_Width,
            div_WidthToBind,
            div_HeightToBind,
            div_CladdingBracketForUPVCQTY,
            div_CladdingBracketForConcreteQTY,
            div_ExplosionWidth,
            div_ExplosionHeight,
            div_ReinfWidth,
            div_ReinfHeight,
            div_CladdingCount,
            div_PropHeight,
            div_AlumSpacer50Qty;

        string div_Name,
               div_FrameType,
               div_Bounded;
        float divImageRenderer_Zoom,
              div_Zoom;
        bool div_Visible,
             div_claddingBracketVisibility,
             div_ChkDM,
             div_ChkDMVisibility,
             div_ArtVisibility,
             div_CladdingProfileArtNoVisibility,
             div_LeverEspagVisibility;
        DividerModel.DividerType div_Type;
        Control div_Parent;
        DummyMullion_ArticleNo div_DMArtNo;
        EndcapDM_ArticleNo div_EndcapDM;
        FixedCam_ArticleNo div_FixedCamDM;
        SnapInKeep_ArticleNo div_SnapNKeepDM;
        IMultiPanelModel div_MPanelParent;
        IFrameModel div_FrameParent;
        IPanelModel div_DMPanel;
        Divider_ArticleNo div_ArtNo;
        DividerReinf_ArticleNo div_ReinfArtNo;
        Divider_MechJointArticleNo div_MechJoinArtNo;
        CladdingProfile_ArticleNo div_CladdingProfileArtNo;
        CladdingReinf_ArticleNo div_CladdingReinfArtNo;
        Dictionary<int, int> div_CladdingSizeList;
        LeverEspagnolette_ArticleNo div_LeverEspagArtNo;
        ShootboltStriker_ArticleNo div_ShootboltStrikerArtNo;
        ShootboltNonReverse_ArticleNo div_ShootboltNonReverseArtNo;
        ShootboltReverse_ArticleNo div_ShootboltReverseArtNo;
        DummyMullionStriker_ArticleNo div_DMStrikerArtNo;
        #endregion
        #region MPanel Properties
        int mPanel_ID,
            mPanel_Width,
            mPanel_WidthToBind,
            mPanel_WidthToBindPrev,
            mPanelImager_WidthToBindPrev,
            mPanel_DisplayWidth,
            mPanel_DisplayWidthDecimal,
            mPanel_Height,
            mPanel_HeightToBind,
            mPanel_HeightToBindPrev,
            mPanelImager_HeightToBindPrev,
            mPanel_DisplayHeight,
            mPanel_DisplayHeightDecimal,
            mPanelImageRenderer_Height,
            mPanelImageRenderer_Width,
            mPanel_Divisions,
            mPanel_Index_Inside_MPanel,
            mPanelProp_Height,
            mPanel_StackNo,
            mPanel_AddPixel,
            mPanel_OriginalDisplayWidth,
            mPanel_OriginalDisplayWidthDecimal,
            mPanel_OriginalDisplayHeight,
            mPanel_OriginalDisplayHeightDecimal,
            mPanel_OriginalGlassWidth,
            mPanel_OriginalGlassWidthDecimal,
            mPanel_OriginalGlassHeight,
            mPanel_OriginalGlassHeightDecimal;
        string mPanel_Name,
               mPanel_Type,
               mPanel_Placement;
        bool mPanel_CmenuDeleteVisibility,
             mPanel_GlassBalanced,
             mPanel_NumEnable,
             mPanel_Visibility,
             mPanel_DividerEnabled;
        DockStyle mPanel_Dock;
        float mPanel_Zoom,
              mPanelImageRenderer_Zoom;
        FlowDirection mPanel_FlowDirection;
        Control mPanel_Parent;
        UserControl mPanel_FrameGroup;
        IFrameModel mPanel_FrameModelParent;
        Padding mPanel_Margin,
                mPanelImageRenderer_Margin;
        List<IPanelModel> mPanelLst_Panel;
        List<IDividerModel> mPanelLst_Divider;
        List<IMultiPanelModel> mPanelLst_MultiPanel;
        List<Control> mPanelLst_Objects;
        List<Control> mPanelLst_Imagers;
        IMultiPanelModel mPanel_ParentModel;
        #endregion
        string mpnllvl = "";

        #region ViewUpdate(Controls)

        private void Clearing_Operation()
        {
            _quotationModel = null;
            _frameModel = null;
            _screenModel = null;
            _multiPanelModel = null;
            _pnlItems.Controls.Clear();
            _pnlPropertiesBody.Controls.Clear();
            _pnlMain.Controls.Clear();
            //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
            _basePlatformPresenter.RemoveBindingView();
            SetMainViewTitle("");
            CreateNewWindoorBtn_Disable();
            ItemToolStrip_Disable();
            wndrFileName = string.Empty;
            wndrfile = string.Empty;
            wndrProjectFileName = string.Empty;
            _mainView.GetToolStripButtonSave().Enabled = false;
            //_basePlatformPresenter.getBasePlatformViewUC().thisVisibility = false;

        }

        private void ItemToolStrip_Enable()
        {
            _mainView.ItemToolStripEnabled = true;
        }

        private void ItemToolStrip_Disable()
        {
            _mainView.ItemToolStripEnabled = false;
        }

        private void BotToolStrip_Enable()
        {
            _mainView.GetPanelBot().Enabled = true;
        }

        private void BotToolStrip_Disable()
        {
            _mainView.GetPanelBot().Enabled = false;
        }

        private void SetMainViewTitle(string qrefno, string project_name, string cust_ref_no, string itemname, string profiletype, bool saved)
        {
            _mainView.mainview_title = project_name + " [" + cust_ref_no + "] (" + qrefno.ToUpper() + ") >> " + itemname + " (" + profiletype + ")";
            _mainView.mainview_title = (saved == false) ? _mainView.mainview_title + "*" : _mainView.mainview_title.Replace("*", "");
            if (!saved)
            {
                _mainView.GetToolStripButtonSave().Enabled = true;
            }
            else
            {
                _mainView.GetToolStripButtonSave().Enabled = false;
            }
        }
        private void SetMainViewTitle(string qrefno, string project_name, string cust_ref_no)
        {
            _mainView.mainview_title = project_name + " [" + cust_ref_no + "] (" + qrefno.ToUpper() + ")";
        }
        private void SetMainViewTitle(string qrefno)
        {
            _mainView.mainview_title = qrefno;
        }

        public void Invalidate_pnlMain()
        {
            _pnlMain.Invalidate();
        }

        private void CreateNewWindoorBtn_Enable()
        {
            _mainView.CreateNewWindoorBtnEnabled = true;
        }

        private void CreateNewWindoorBtn_Disable()
        {
            _mainView.CreateNewWindoorBtnEnabled = false;
        }

        #endregion


        #region Scenarios

        public void Scenario_Quotation(bool QoutationInputBox_OkClicked,
                                       bool NewItem_OkClicked,
                                       bool AddedFrame,
                                       bool AddedConcrete,
                                       bool OpenWindoorFile,
                                       frmDimensionPresenter.Show_Purpose purpose,
                                       int frmDimension_numWd,
                                       int frmDimension_numHt,
                                       string frmDimension_profileType,
                                       string frmDimension_baseColor)
        {
            if (frmDimension_numWd == 0 && frmDimension_numHt == 0) //from Quotation Input box to here
            {
                if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile)
                {
                    Clearing_Operation();
                }
                else if (QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile)
                {
                    SetMainViewTitle(input_qrefno, _projectName, _custRefNo);
                    ItemToolStrip_Enable();
                    _quotationModel = _quotationServices.AddQuotationModel(input_qrefno, _quotationDate, _quoteId);

                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.Quotation;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.SetBaseColor(frmDimension_baseColor);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile)
                {
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.CreateNew_Item;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.SetBaseColor(frmDimension_baseColor);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame && !AddedConcrete && !OpenWindoorFile)
                {
                    _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = purpose;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.SetBaseColor(frmDimension_baseColor);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && AddedConcrete && !OpenWindoorFile)
                {
                    _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = purpose;
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = true;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && OpenWindoorFile) //from Open Windoor File
                {
                    ItemToolStrip_Enable();
                    _quotationModel = _quotationServices.AddQuotationModel(input_qrefno, _quotationDate, _quoteId);

                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.OpenWndrFile;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.SetBaseColor(frmDimension_baseColor);
                    //_frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    //_frmDimensionPresenter.mainPresenter_newItem_ClickedOK = false;
                    //_frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    //_frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    //_frmDimensionPresenter.mainPresenter_OpenWindoorFile_ClickedOK = true;

                }
            }
            else if (frmDimension_numWd != 0 && frmDimension_numHt != 0) //from frmDimension to here
            {
                if (QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile)
                {
                    if (_frmDimensionPresenter.baseColor_frmDimensionPresenter == Base_Color._Ivory.ToString() ||
                              _frmDimensionPresenter.baseColor_frmDimensionPresenter == Base_Color._White.ToString())
                    {
                        baseColor = Base_Color._White;
                    }
                    else if (_frmDimensionPresenter.baseColor_frmDimensionPresenter == Base_Color._DarkBrown.ToString())
                    {
                        baseColor = Base_Color._DarkBrown;
                    }
                    if (purpose == frmDimensionPresenter.Show_Purpose.Quotation)
                    {
                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         baseColor,
                                                                         Foil_Color._Walnut,
                                                                         Foil_Color._Walnut);
                        _windoorModel.SetDimensions_basePlatform();
                        AddWndrList_QuotationModel(_windoorModel);
                        _mainView.Zoom = _windoorModel.WD_zoom;
                        _mainView.PropertiesScroll = _windoorModel.WD_PropertiesScroll;
                        _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                        _mainView.GetThis().Controls.Add(bpUC);

                        _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());

                        AddItemInfoUC(_windoorModel);

                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                        _projectName,
                                        _custRefNo,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);
                        ItemToolStrip_Enable();
                        CreateNewWindoorBtn_Enable();
                        BotToolStrip_Enable();

                        _mainView.RemoveBinding(_mainView.GetLblSize());
                        _mainView.RemoveBinding();
                        _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());
                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }
                if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && OpenWindoorFile) // Open File
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Item)
                    {
                        _frmDimensionPresenter.SetBaseColor(frmDimension_baseColor);
                        if (_frmDimensionPresenter.baseColor_frmDimensionPresenter == Base_Color._Ivory.ToString() ||
                              _frmDimensionPresenter.baseColor_frmDimensionPresenter == Base_Color._White.ToString())
                        {
                            baseColor = Base_Color._White;
                        }
                        else if (_frmDimensionPresenter.baseColor_frmDimensionPresenter == Base_Color._DarkBrown.ToString())
                        {
                            baseColor = Base_Color._DarkBrown;
                        }

                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         baseColor,
                                                                         Foil_Color._Walnut,
                                                                         Foil_Color._Walnut);
                        AddWndrList_QuotationModel(_windoorModel);
                        //_quotationModel.Select_Current_Windoor(_windoorModel);
                        _windoorModel.SetDimensions_basePlatform();

                        _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                        _mainView.GetThis().Controls.Add(bpUC);

                        _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());
                        _pnlMain.Controls.Clear();
                        AddItemInfoUC(_windoorModel); //add item information user control

                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                        _projectName,
                                        _custRefNo,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         true);

                        BotToolStrip_Enable();
                        CreateNewWindoorBtn_Enable();

                        //_mainView.RemoveBinding();
                        //_mainView.RemoveBinding(_mainView.GetLblSize());
                        //_mainView.ThisBinding(CreateBindingDictionary_MainPresenter());

                        _pnlPropertiesBody.Controls.Clear(); //Clearing Operation
                        //_basePlatformPresenter.RemoveBindingView();
                        //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
                        _pnlItems.VerticalScroll.Value = _pnlItems.VerticalScroll.Maximum;
                        _pnlItems.PerformLayout();

                        //_frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Frame)
                    {
                        _frameModel = _frameServices.AddFrameModel(frmDimension_numWd,
                                                                   frmDimension_numHt,
                                                                   frameType,
                                                                   _windoorModel.WD_zoom_forImageRenderer,
                                                                   _windoorModel.WD_zoom,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   null,
                                                                   _windoorModel.frameIDCounter,
                                                                   "",
                                                                   true,
                                                                   true,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   (UserControl)_frameUC,
                                                                   (UserControl)_framePropertiesUC);
                        _frameModel.Set_DimensionsToBind_using_FrameZoom();
                        _frameModel.Set_ImagerDimensions_using_ImagerZoom();
                        _frameModel.Set_FramePadding();

                        IFramePropertiesUCPresenter framePropUCP = _framePropertiesUCPresenter.GetNewInstance(_frameModel, _unityC, this);
                        AddFrameUC(_frameModel, framePropUCP);
                        _frameModel.Frame_UC = (UserControl)_frameUC;
                        _frameModel.Frame_PropertiesUC = (UserControl)framePropUCP.GetFramePropertiesUC();
                        AddFrameList_WindoorModel(_frameModel);
                        _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                        _basePlatformImagerUCPresenter.Invalidate_flpMain();
                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                         _projectName,
                                         _custRefNo,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         true);

                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile) //Add new Item
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Item)
                    {
                        Frame_Save_UserControl();
                        Frame_Save_PropertiesUC();

                        //clear previous basePlatformUC
                        _pnlMain.Controls.Clear();
                        _basePlatformImagerUCPresenter.SendToBack_baseImager();
                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         baseColor,
                                                                         Foil_Color._Walnut,
                                                                         Foil_Color._Walnut);
                        AddWndrList_QuotationModel(_windoorModel);
                        _quotationModel.Select_Current_Windoor(_windoorModel);
                        _windoorModel.SetDimensions_basePlatform();

                        _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                        _mainView.GetThis().Controls.Add(bpUC);

                        _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());

                        AddItemInfoUC(_windoorModel); //add item information user control

                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                        _projectName,
                                        _custRefNo,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);

                        BotToolStrip_Enable();
                        CreateNewWindoorBtn_Enable();

                        _mainView.RemoveBinding();
                        _mainView.RemoveBinding(_mainView.GetLblSize());
                        _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());

                        _pnlPropertiesBody.Controls.Clear(); //Clearing Operation
                        _basePlatformPresenter.RemoveBindingView();
                        _basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
                        _pnlItems.VerticalScroll.Value = _pnlItems.VerticalScroll.Maximum;
                        _pnlItems.PerformLayout();

                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame && !AddedConcrete && !OpenWindoorFile) //add frame
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Frame)
                    {
                        int frameID = _windoorModel.frameIDCounter += 1;
                        _frameModel = _frameServices.AddFrameModel(frmDimension_numWd,
                                                                   frmDimension_numHt,
                                                                   frameType,
                                                                   _windoorModel.WD_zoom_forImageRenderer,
                                                                   _windoorModel.WD_zoom,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   null,
                                                                   frameID,
                                                                   "",
                                                                   true,
                                                                   true,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   (UserControl)_frameUC,
                                                                   (UserControl)_framePropertiesUC);
                        _frameModel.Set_DimensionsToBind_using_FrameZoom();
                        _frameModel.Set_ImagerDimensions_using_ImagerZoom();
                        _frameModel.Set_FramePadding();

                        AddFrameList_WindoorModel(_frameModel);
                        IFramePropertiesUCPresenter framePropUCP = AddFramePropertiesUC(_frameModel);
                        AddFrameUC(_frameModel, framePropUCP);

                        _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                        _projectName,
                                        _custRefNo,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);

                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && AddedConcrete && !OpenWindoorFile) //add concrete
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Concrete)
                    {
                        int concreteID = _windoorModel.concreteIDCounter += 1;
                        _concreteModel = _concreteServices.AddConcreteModel(frmDimension_numWd,
                                                                            frmDimension_numHt,
                                                                            _windoorModel.WD_zoom,
                                                                            _windoorModel.WD_zoom_forImageRenderer,
                                                                            concreteID);
                        _concreteModel.Set_DimensionsToBind_using_ConcreteZoom();
                        _concreteModel.Set_ImagerDimensions_using_ImagerZoom();

                        AddConcreteList_WindoorModel(_concreteModel);
                        IConcretePropertiesUCPresenter concretePropertiesUCPresenter = AddConcretePropertiesUC(_concreteModel);
                        AddConcreteUC(_concreteModel);

                        _basePlatformPresenter.InvalidateBasePlatform();
                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }

            }
        }

        public void frmDimensionResults(frmDimensionPresenter.Show_Purpose purpose,
                                       int frmDimension_numWd,
                                       int frmDimension_numHt)
        {
            if (purpose == frmDimensionPresenter.Show_Purpose.ChangeBasePlatformSize)
            {
                _windoorModel.WD_width = frmDimension_numWd;
                _windoorModel.WD_height = frmDimension_numHt;
                _windoorModel.SetDimensions_basePlatform();
                _windoorModel.SetZoom();
                _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                _basePlatformPresenter.InvalidateBasePlatform();
                _basePlatformPresenter.Invalidate_flpMainControls();
            }
            Load_Windoor_Item(_windoorModel);
        }
        #endregion

        #region Functions

        public void Set_User_View()
        {
            if (_userModel.AccountType == "Cost Engr")
            {
                _mainView.Set_AssignProject_Visibility(false);
            }
        }

        public void Frame_Save_PropertiesUC()
        {
            foreach (UserControl uc in _pnlPropertiesBody.Controls)
            {
                if (uc is IFramePropertiesUC)
                {
                    IFramePropertiesUC fpUC = (IFramePropertiesUC)uc;
                    foreach (IFrameModel frModel in _windoorModel.lst_frame)
                    {
                        if (fpUC.FrameID == frModel.Frame_ID)
                        {
                            frModel.Frame_PropertiesUC = uc;
                        }
                    }
                }
            }
        }

        public void Frame_Save_UserControl()
        {
            _basePlatformPresenter.RemoveBindingView();
            foreach (UserControl uc in _basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls)
            {
                if (uc is IFrameUC)
                {
                    IFrameUC fUC = (IFrameUC)uc;
                    foreach (IFrameModel frModel in _windoorModel.lst_frame)
                    {
                        if (fUC.frameID == frModel.Frame_ID)
                        {
                            frModel.Frame_UC = uc;
                        }
                    }
                }
            }
        }

        public void Load_Windoor_Item(IWindoorModel item)
        {
            _basePlatformImagerUCPresenter.SendToBack_baseImager();



            //save frame
            Frame_Save_UserControl();
            Frame_Save_PropertiesUC();

            //set mainview
            _windoorModel = item;
            SetMainViewTitle(input_qrefno,
                             _projectName,
                             _custRefNo,
                             item.WD_name,
                             item.WD_profile,
                             false);
            _quotationModel.Select_Current_Windoor(item);

            //clear
            _pnlMain.Controls.Clear();
            _pnlPropertiesBody.Controls.Clear();
            _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);

            //basePlatform
            _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, item, this);
            AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());
            _basePlatformPresenter.InvalidateBasePlatform();

            _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, item, this);
            UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
            _mainView.GetThis().Controls.Add(bpUC);

            //frames
            foreach (IFrameModel frame in item.lst_frame)
            {
                _pnlPropertiesBody.Controls.Add((UserControl)frame.Frame_PropertiesUC);
                _basePlatformPresenter.AddFrame((IFrameUC)frame.Frame_UC);
            }

            _pnlPropertiesBody.Refresh();
            _mainView.RemoveBinding(_mainView.GetLblSize());
            _mainView.RemoveBinding();
            _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());
            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
        }

        public void Set_pnlPropertiesBody_ScrollView(int scroll_value)
        {
            _pnlPropertiesBody.VerticalScroll.Value += scroll_value;
            _pnlPropertiesBody.PerformLayout();
        }

        private string Check_Incompatibility()
        {
            string incompatibility = "\n";

            foreach (IFrameModel frame in _windoorModel.lst_frame)
            {
                FrameProfile_ArticleNo frame_art = frame.Frame_ArtNo;

                foreach (IPanelModel pnl in frame.Lst_Panel)
                {
                    SashProfile_ArticleNo sash_art = pnl.Panel_SashProfileArtNo;
                    Handle_Type handletype = pnl.Panel_HandleType;
                    Espagnolette_ArticleNo espag_art = pnl.Panel_EspagnoletteArtNo;

                    if (pnl.Panel_Type.Contains("Fixed") == false && pnl.Panel_HandleOptionsVisibility == true)
                    {
                        if (handletype == Handle_Type._Rotoswing)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._7502 &&
                                  sash_art == SashProfile_ArticleNo._7581) &&
                                !(frame_art == FrameProfile_ArticleNo._7507 &&
                                  sash_art == SashProfile_ArticleNo._7581) &&
                                !(frame_art == FrameProfile_ArticleNo._7507 &&
                                  sash_art == SashProfile_ArticleNo._395) &&
                                  !(frame_art == FrameProfile_ArticleNo._2060 &&
                                  sash_art == SashProfile_ArticleNo._2067) &&
                                  !(frame_art == FrameProfile_ArticleNo._6050 &&
                                  sash_art == SashProfile_ArticleNo._6040))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                            }
                        }
                        else if (handletype == Handle_Type._Rio || handletype == Handle_Type._Rotoline || handletype == Handle_Type._MVD)
                        {

                            if (!(frame_art == FrameProfile_ArticleNo._7507 && (sash_art == SashProfile_ArticleNo._374 || sash_art == SashProfile_ArticleNo._373)) &&
                                !(frame_art == FrameProfile_ArticleNo._6052 && sash_art == SashProfile_ArticleNo._6041))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                            }
                        }
                        else if (handletype == Handle_Type._RotoswingForSliding || handletype == Handle_Type._PopUp)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._6052 &&
                                  sash_art == SashProfile_ArticleNo._6040))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                            }
                        }
                        else if (handletype == Handle_Type._D || handletype == Handle_Type._DummyD || handletype == Handle_Type._D_IO_Locking)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._6052 &&
                                  sash_art == SashProfile_ArticleNo._6041))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                            }
                        }

                        if (espag_art == Espagnolette_ArticleNo._741012 || espag_art == Espagnolette_ArticleNo._EQ87NT ||
                        espag_art == Espagnolette_ArticleNo._628806 || espag_art == Espagnolette_ArticleNo._628807 ||
                        espag_art == Espagnolette_ArticleNo._628809)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._7502 && sash_art == SashProfile_ArticleNo._7581) &&
                                !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581) &&
                                !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067) &&
                                !(frame_art == FrameProfile_ArticleNo._6050 && sash_art == SashProfile_ArticleNo._6040))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                            }
                        }
                        else if (espag_art == Espagnolette_ArticleNo._642105 || espag_art == Espagnolette_ArticleNo._642089 ||
                                 espag_art == Espagnolette_ArticleNo._630963)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._7507 &&
                                 (sash_art == SashProfile_ArticleNo._374 ||
                                  sash_art == SashProfile_ArticleNo._373)))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                            }
                        }
                        else if (espag_art == Espagnolette_ArticleNo._N110A00006 || espag_art == Espagnolette_ArticleNo._N110A01006 ||
                                 espag_art == Espagnolette_ArticleNo._N110A02206 || espag_art == Espagnolette_ArticleNo._N110A03206 ||
                                 espag_art == Espagnolette_ArticleNo._N110A04206 || espag_art == Espagnolette_ArticleNo._N110A05206 ||
                                 espag_art == Espagnolette_ArticleNo._N110A06206)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._395))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                            }
                        }
                        else if ((espag_art == Espagnolette_ArticleNo._774275 || espag_art == Espagnolette_ArticleNo._774276 ||
                                  espag_art == Espagnolette_ArticleNo._774277 || espag_art == Espagnolette_ArticleNo._774278))
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._6050 ||
                                  frame_art == FrameProfile_ArticleNo._6052) &&
                                !(sash_art == SashProfile_ArticleNo._6040))
                            {
                                MessageBox.Show("You've selected an incompatible item, be advised", "Espagnolette Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (espag_art == Espagnolette_ArticleNo._774286 || espag_art == Espagnolette_ArticleNo._774287 ||
                                 espag_art == Espagnolette_ArticleNo._731852 || espag_art == Espagnolette_ArticleNo._6_90137_10_0_1)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._6052) && !(sash_art == SashProfile_ArticleNo._6041))
                            {
                                MessageBox.Show("You've selected an incompatible item, be advised", "Espagnolette Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }



                        List<Extension_ArticleNo> lst_extArt = new List<Extension_ArticleNo>();
                        lst_extArt.Add(pnl.Panel_ExtensionTopArtNo);
                        if (pnl.Panel_ExtTopChk)
                        {
                            lst_extArt.Add(pnl.Panel_ExtensionTop2ArtNo);
                        }
                        if (pnl.Panel_ExtTop2Chk)
                        {
                            lst_extArt.Add(pnl.Panel_ExtensionTop3ArtNo);
                        }

                        lst_extArt.Add(pnl.Panel_ExtensionBotArtNo);
                        if (pnl.Panel_ExtBotChk)
                        {
                            lst_extArt.Add(pnl.Panel_ExtensionBot2ArtNo);
                        }

                        lst_extArt.Add(pnl.Panel_ExtensionLeftArtNo);
                        if (pnl.Panel_ExtLeftChk)
                        {
                            lst_extArt.Add(pnl.Panel_ExtensionLeft2ArtNo);
                        }

                        lst_extArt.Add(pnl.Panel_ExtensionRightArtNo);
                        if (pnl.Panel_ExtRightChk)
                        {
                            lst_extArt.Add(pnl.Panel_ExtensionRight2ArtNo);
                        }

                        if (pnl.Panel_ExtensionOptionsVisibility == true)
                        {
                            foreach (Extension_ArticleNo ext in lst_extArt)
                            {
                                if (ext == Extension_ArticleNo._639957)
                                {
                                    if (!(frame_art == FrameProfile_ArticleNo._7502 && sash_art == SashProfile_ArticleNo._7581) &&
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581) &&
                                        !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067))
                                    {
                                        incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + " \nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Extension : " + ext.DisplayName;
                                    }
                                }
                                else if (ext == Extension_ArticleNo._641798 || ext == Extension_ArticleNo._567639 || ext == Extension_ArticleNo._630956)
                                {
                                    if (!(frame_art == FrameProfile_ArticleNo._7507 &&
                                         (sash_art == SashProfile_ArticleNo._374 ||
                                          sash_art == SashProfile_ArticleNo._373)))
                                    {
                                        incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + " \nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Extension : " + ext.DisplayName;
                                    }
                                }
                                else if (ext == Extension_ArticleNo._612978)
                                {
                                    if (!(frame_art == FrameProfile_ArticleNo._7502 && sash_art == SashProfile_ArticleNo._7581) &&
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581) &&
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._374) &&
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._373) &&
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._395) &&
                                        !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067))
                                    {
                                        incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + " \nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Extension : " + ext.DisplayName;
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                {
                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                    {
                        SashProfile_ArticleNo sash_art = pnl.Panel_SashProfileArtNo;
                        Handle_Type handletype = pnl.Panel_HandleType;
                        Espagnolette_ArticleNo espag_art = pnl.Panel_EspagnoletteArtNo;

                        if (pnl.Panel_Type.Contains("Fixed") == false && pnl.Panel_HandleOptionsVisibility == true)
                        {
                            if (handletype == Handle_Type._Rotoswing)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._7502 &&
                                      sash_art == SashProfile_ArticleNo._7581) &&
                                    !(frame_art == FrameProfile_ArticleNo._7507 &&
                                      sash_art == SashProfile_ArticleNo._7581) &&
                                    !(frame_art == FrameProfile_ArticleNo._7507 &&
                                      sash_art == SashProfile_ArticleNo._395) &&
                                      !(frame_art == FrameProfile_ArticleNo._2060 &&
                                      sash_art == SashProfile_ArticleNo._2067) &&
                                      !(frame_art == FrameProfile_ArticleNo._6050 &&
                                      sash_art == SashProfile_ArticleNo._6040))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                                }
                            }
                            else if (handletype == Handle_Type._Rio || handletype == Handle_Type._Rotoline || handletype == Handle_Type._MVD)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._7507 &&
                                      (sash_art == SashProfile_ArticleNo._374 ||
                                       sash_art == SashProfile_ArticleNo._373)))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                                }
                            }


                            if (espag_art == Espagnolette_ArticleNo._741012 || espag_art == Espagnolette_ArticleNo._EQ87NT ||
                                espag_art == Espagnolette_ArticleNo._628806 || espag_art == Espagnolette_ArticleNo._628807 ||
                                espag_art == Espagnolette_ArticleNo._628809)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._7502 && sash_art == SashProfile_ArticleNo._7581) &&
                                    !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581) &&
                                    !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067) &&
                                    !(frame_art == FrameProfile_ArticleNo._6050 && sash_art == SashProfile_ArticleNo._6040))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                                }
                            }
                            else if (espag_art == Espagnolette_ArticleNo._642105 || espag_art == Espagnolette_ArticleNo._642089 ||
                                     espag_art == Espagnolette_ArticleNo._630963)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._7507 &&
                                     (sash_art == SashProfile_ArticleNo._374 ||
                                      sash_art == SashProfile_ArticleNo._373)))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                                }
                            }
                            else if (espag_art == Espagnolette_ArticleNo._N110A00006 || espag_art == Espagnolette_ArticleNo._N110A01006 ||
                                     espag_art == Espagnolette_ArticleNo._N110A02206 || espag_art == Espagnolette_ArticleNo._N110A03206 ||
                                     espag_art == Espagnolette_ArticleNo._N110A04206 || espag_art == Espagnolette_ArticleNo._N110A05206 ||
                                     espag_art == Espagnolette_ArticleNo._N110A06206)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._395))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                                }
                            }
                            else if (espag_art == Espagnolette_ArticleNo._774275 || espag_art == Espagnolette_ArticleNo._774276 ||
                                     espag_art == Espagnolette_ArticleNo._774277 || espag_art == Espagnolette_ArticleNo._774278)
                            {
                                if (!((frame_art == FrameProfile_ArticleNo._6050 || frame_art == FrameProfile_ArticleNo._6052) &&
                                    sash_art == SashProfile_ArticleNo._6040))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Espagnolette : " + espag_art.DisplayName;
                                }
                            }
                            else if (espag_art == Espagnolette_ArticleNo._774286 || espag_art == Espagnolette_ArticleNo._774287 ||
                                     espag_art == Espagnolette_ArticleNo._731852 || espag_art == Espagnolette_ArticleNo._6_90137_10_0_1)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._6052 && sash_art == SashProfile_ArticleNo._6041))
                                {
                                    MessageBox.Show("You've selected an incompatible item, be advised", "Espagnolette Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            List<Extension_ArticleNo> lst_extArt = new List<Extension_ArticleNo>();
                            lst_extArt.Add(pnl.Panel_ExtensionTopArtNo);
                            if (pnl.Panel_ExtTopChk)
                            {
                                lst_extArt.Add(pnl.Panel_ExtensionTop2ArtNo);
                            }
                            if (pnl.Panel_ExtTop2Chk)
                            {
                                lst_extArt.Add(pnl.Panel_ExtensionTop3ArtNo);
                            }

                            lst_extArt.Add(pnl.Panel_ExtensionBotArtNo);
                            if (pnl.Panel_ExtBotChk)
                            {
                                lst_extArt.Add(pnl.Panel_ExtensionBot2ArtNo);
                            }

                            lst_extArt.Add(pnl.Panel_ExtensionLeftArtNo);
                            if (pnl.Panel_ExtLeftChk)
                            {
                                lst_extArt.Add(pnl.Panel_ExtensionLeft2ArtNo);
                            }

                            lst_extArt.Add(pnl.Panel_ExtensionRightArtNo);
                            if (pnl.Panel_ExtRightChk)
                            {
                                lst_extArt.Add(pnl.Panel_ExtensionRight2ArtNo);
                            }

                            if (pnl.Panel_ExtensionOptionsVisibility == true)
                            {
                                foreach (Extension_ArticleNo ext in lst_extArt)
                                {
                                    if (ext == Extension_ArticleNo._639957)
                                    {
                                        if (!(frame_art == FrameProfile_ArticleNo._7502 && sash_art == SashProfile_ArticleNo._7581) &&
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581) &&
                                            !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067))
                                        {
                                            incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + " \nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Extension : " + ext.DisplayName;
                                        }
                                    }
                                    else if (ext == Extension_ArticleNo._641798 || ext == Extension_ArticleNo._567639 || ext == Extension_ArticleNo._630956)
                                    {
                                        if (!(frame_art == FrameProfile_ArticleNo._7507 &&
                                            (sash_art == SashProfile_ArticleNo._374 ||
                                             sash_art == SashProfile_ArticleNo._373)))
                                        {
                                            incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + " \nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Extension : " + ext.DisplayName;
                                        }
                                    }
                                    else if (ext == Extension_ArticleNo._612978)
                                    {
                                        if (!(frame_art == FrameProfile_ArticleNo._7502 && sash_art == SashProfile_ArticleNo._7581) &&
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581) &&
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._374) &&
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._373) &&
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._395) &&
                                            !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067))
                                        {
                                            incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + " \nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Extension : " + ext.DisplayName;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (IDividerModel div in frame.Lst_Divider)
                {
                    if (div.Div_ChkDM == true && div.Div_DMPanel != null)
                    {
                        if (div.Div_DMArtNo == DummyMullion_ArticleNo._7533 &&
                            (div.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) == false)
                        {
                            incompatibility += "\n\nOn " + div.Div_Name + "\nSash Profile : " + div.Div_DMPanel.Panel_SashProfileArtNo.DisplayName + ", Dummy Mullion : " + div.Div_DMArtNo.DisplayName;
                        }
                        else if (div.Div_DMArtNo == DummyMullion_ArticleNo._385P &&
                                 ((div.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                   div.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                   div.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)) == false)
                        {
                            incompatibility += "\n\nOn " + div.Div_Name + "\nSash Profile : " + div.Div_DMPanel.Panel_SashProfileArtNo.DisplayName + ", Dummy Mullion : " + div.Div_DMArtNo.DisplayName;
                        }
                    }
                    else if (div.Div_ChkDM == true && div.Div_DMPanel == null)
                    {
                        incompatibility += "\n\nOn " + div.Div_Name + "\nSash Profile : no selected panel, Dummy Mullion : " + div.Div_DMArtNo.DisplayName;
                    }
                }
            }

            return incompatibility.Trim();
        }

        private int Check_UnbalancedGlass()
        {
            int unbalancedGlass_cnt = 0;

            foreach (IFrameModel frame in _windoorModel.lst_frame)
            {
                try
                {
                    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    {
                        string gbmode = "";
                        bool same_sash = false;
                        SashProfile_ArticleNo ref_sash = mpnl.MPanelLst_Panel[0].Panel_SashProfileArtNo;
                        bool allWithSash = mpnl.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == true);
                        bool allNoSash = mpnl.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == false);
                        if (mpnl.MPanel_DividerEnabled == true)
                        {
                            if (allWithSash == true && allNoSash == false)
                            {
                                gbmode = "withSash";
                                int ref_sash_count = mpnl.MPanelLst_Panel.Select(pnl => pnl.Panel_SashProfileArtNo == ref_sash).Count();
                                if (ref_sash_count == mpnl.MPanelLst_Panel.Count)
                                {
                                    same_sash = true;
                                }
                                else
                                {
                                    same_sash = false;
                                }
                            }
                            else if (allWithSash == false && allNoSash == true)
                            {
                                gbmode = "noSash";
                            }
                            else if (allWithSash == false && allNoSash == false)
                            {
                                gbmode = "";
                            }

                            if (gbmode != "")
                            {
                                if (same_sash == true || gbmode == "noSash")
                                {
                                    if (mpnl.MPanel_Divisions >= 2 && mpnl.MPanel_GlassBalanced == false)
                                    {
                                        unbalancedGlass_cnt++;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            return unbalancedGlass_cnt;
        }

        public void Run_GetListOfMaterials_SpecificItem()
        {
            _quotationModel.GetListOfMaterials(_windoorModel);
        }

        public void Fit_MyControls_byControlsLocation()
        {
            foreach (IFrameModel frames in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpanel in frames.Lst_MultiPanel)
                {
                    foreach (Control ctrl in mpanel.MPanelLst_Objects)
                    {
                        if (ctrl is IPanelUC)
                        {
                            IPanelUC panel = (IPanelUC)ctrl;
                            if (panel.Panel_Placement == "Last")
                            {
                                IPanelModel pnlModel = mpanel.MPanelLst_Panel.Find(pnl => pnl.Panel_ID == panel.Panel_ID);
                                if (mpanel.MPanel_Type == "Mullion")
                                {
                                    while (ctrl.Location.Y > ctrl.Margin.Top)
                                    {
                                        pnlModel.Panel_WidthToBind--;
                                        if (ctrl.Location.Y == ctrl.Margin.Top)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (mpanel.MPanel_Type == "Transom")
                                {
                                    while (ctrl.Location.X > ctrl.Margin.Left)
                                    {
                                        pnlModel.Panel_HeightToBind--;
                                        if (ctrl.Location.X == ctrl.Margin.Left)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (ctrl is IMultiPanelUC)
                        {
                            IMultiPanelUC multi = (IMultiPanelUC)ctrl;
                            if (multi.MPanel_Placement == "Last")
                            {
                                IMultiPanelModel mpnlModel = mpanel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_ID == multi.MPanel_ID);
                                if (mpanel.MPanel_Type == "Mullion")
                                {
                                    while (ctrl.Location.Y > ctrl.Margin.Top)
                                    {
                                        mpnlModel.MPanel_WidthToBind--;
                                        if (ctrl.Location.Y == ctrl.Margin.Top)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (mpanel.MPanel_Type == "Transom")
                                {
                                    while (ctrl.Location.X > ctrl.Margin.Left)
                                    {
                                        mpnlModel.MPanel_HeightToBind--;
                                        if (ctrl.Location.X == ctrl.Margin.Left)
                                        {
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

        public void Fit_MyImager_byImagersLocation()
        {
            foreach (IFrameModel frames in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpnl in frames.Lst_MultiPanel)
                {
                    foreach (Control imager in mpnl.MPanelLst_Imagers)
                    {
                        if (imager is IPanelImagerUC)
                        {
                            IPanelImagerUC imgr = (IPanelImagerUC)imager;
                            if (imgr.Panel_Placement == "Last")
                            {
                                IPanelModel pnlModel = mpnl.MPanelLst_Panel.Find(pnl => pnl.Panel_ID == imgr.Panel_ID);
                                if (mpnl.MPanel_Type == "Mullion")
                                {
                                    while (imager.Location.Y > imager.Margin.Top)
                                    {
                                        pnlModel.PanelImageRenderer_Width--;
                                        if (imager.Location.Y == imager.Margin.Top)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (mpnl.MPanel_Type == "Transom")
                                {
                                    while (imager.Location.X > imager.Margin.Left)
                                    {
                                        pnlModel.PanelImageRenderer_Height--;
                                        if (imager.Location.X == imager.Margin.Left)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (imager is IMultiPanelImagerUC)
                        {
                            IMultiPanelImagerUC multi = (IMultiPanelImagerUC)imager;
                            if (multi.MPanel_Placement == "Last")
                            {
                                IMultiPanelModel mpnlModel = mpnl.MPanelLst_MultiPanel.Find(mpanl => mpanl.MPanel_ID == multi.MPanel_ID);
                                if (mpnl.MPanel_Type == "Mullion")
                                {
                                    while (imager.Location.Y > imager.Margin.Top)
                                    {
                                        mpnlModel.MPanelImageRenderer_Width--;
                                        if (imager.Location.Y == imager.Margin.Top)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (mpnl.MPanel_Type == "Transom")
                                {
                                    while (imager.Location.X > imager.Margin.Left)
                                    {
                                        mpnlModel.MPanelImageRenderer_Height--;
                                        if (imager.Location.X == imager.Margin.Left)
                                        {
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

        private void FitControls_InsideMultiPanel()
        {
            foreach (IFrameModel frames in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpanel in frames.Lst_MultiPanel)
                {
                    if (mpanel.MPanelLst_Objects.Count() == (mpanel.MPanel_Divisions * 2) + 1)
                    {
                        mpanel.Fit_MyControls_ToBindDimensions();
                        mpanel.Fit_MyControls_ImagersToBindDimensions();
                        foreach (IMultiPanelModel mpanels in mpanel.MPanelLst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpanels.MPanelLst_Panel)
                            {
                                pnl.SetDimensionToBind_2ndlvl_using_BaseDimension();
                            }
                        }
                    }

                }
            }
        }

        private Dictionary<string, Binding> CreateBindingDictionary_MainPresenter()
        {
            Dictionary<string, Binding> mainPresenterBinding = new Dictionary<string, Binding>();
            mainPresenterBinding.Add("WD_Dimension", new Binding("Text", _windoorModel, "WD_Dimension", true, DataSourceUpdateMode.OnPropertyChanged));
            mainPresenterBinding.Add("WD_zoom", new Binding("Zoom", _windoorModel, "WD_zoom", true, DataSourceUpdateMode.OnPropertyChanged));
            mainPresenterBinding.Add("WD_customArrowToggle", new Binding("CustomArrowHeadToggle", _windoorModel, "WD_customArrowToggle", true, DataSourceUpdateMode.OnPropertyChanged));
            mainPresenterBinding.Add("WD_PropertiesScroll", new Binding("PropertiesScroll", _windoorModel, "WD_PropertiesScroll", true, DataSourceUpdateMode.OnValidation));
            return mainPresenterBinding;
        }

        public void AddBasePlatform(IBasePlatformUC basePlatform)
        {
            _pnlMain.Controls.Add((UserControl)basePlatform);
        }

        public void AddWndrList_QuotationModel(IWindoorModel wndr)
        {
            _quotationModel.Lst_Windoor.Add(wndr);
        }

        public void AddItemInfoUC(IWindoorModel wndr)
        {
            IItemInfoUCPresenter itemInfoUCP = (ItemInfoUCPresenter)_itemInfoUCPresenter.GetNewInstance(wndr, _unityC, this);
            _itemInfoUC = itemInfoUCP.GetItemInfoUC();
            _pnlItems.Controls.Add((UserControl)_itemInfoUC);
        }

        public void AddFrameUC(IFrameModel frameModel, IFramePropertiesUCPresenter framePropertiesUCP)
        {
            IFrameImagerUCPresenter frameImagerUCP = (FrameImagerUCPresenter)_frameImagerUCPresenter.GetNewInstance(_unityC, frameModel, this);

            IFrameUCPresenter frameUCP = (FrameUCPresenter)_frameUCPresenter.GetNewInstance(_unityC,
                                                                                            frameModel,
                                                                                            this,
                                                                                            _basePlatformPresenter,
                                                                                            frameImagerUCP,
                                                                                            _basePlatformImagerUCPresenter,
                                                                                            framePropertiesUCP);
            _frameUC = frameUCP.GetFrameUC();
            frmUCPresenter = frameUCP;
            _basePlatformPresenter.AddFrame(_frameUC);

            //_basePlatformImagerUCPresenter.AddFrame(frameImagerUCP.GetFrameImagerUC());
        }

        private void AddConcreteUC(IConcreteModel concreteModel)
        {
            IConcreteUCPresenter concreteUCPresenter = _concreteUCPresenter.GetNewInstance(_unityC, concreteModel, this, _basePlatformPresenter);
            IConcreteUC concrete = concreteUCPresenter.GetConcreteUC();
            _basePlatformPresenter.AddConcrete(concrete);
        }

        public IFramePropertiesUCPresenter AddFramePropertiesUC(IFrameModel frameModel)
        {
            IFramePropertiesUCPresenter FramePropertiesUCP = _framePropertiesUCPresenter.GetNewInstance(frameModel, _unityC, this);
            _framePropertiesUC = FramePropertiesUCP.GetFramePropertiesUC();
            _pnlPropertiesBody.Controls.Add((UserControl)_framePropertiesUC);

            return FramePropertiesUCP;
        }

        private IConcretePropertiesUCPresenter AddConcretePropertiesUC(IConcreteModel concreteModel)
        {
            IConcretePropertiesUCPresenter concretePropertiesUCPresenter = _concretePropertiesUCPresenter.GetNewInstance(concreteModel, _unityC, this);
            IConcretePropertiesUC concretePropertiesUC = concretePropertiesUCPresenter.GetConcretePropertiesUC();
            _pnlPropertiesBody.Controls.Add((UserControl)concretePropertiesUC);

            return concretePropertiesUCPresenter;
        }

        public void AddFrameList_WindoorModel(IFrameModel frameModel)
        {
            _windoorModel.lst_frame.Add(frameModel);
        }

        private void AddConcreteList_WindoorModel(IConcreteModel concreteModel)
        {
            _windoorModel.lst_concrete.Add(concreteModel);
        }

        public void DeleteFrame_OnFrameList_WindoorModel(IFrameModel frameModel)
        {
            _windoorModel.lst_frame.Remove(frameModel);
        }

        public void DeleteConcrete_OnConcreteList_WindoorModel(IConcreteModel concreteModel)
        {
            _windoorModel.lst_concrete.Remove(concreteModel);
        }


        public IFramePropertiesUC GetFrameProperties(int frameID)
        {
            return _pnlPropertiesBody.Controls.OfType<IFramePropertiesUC>().First(ctrl => ctrl.FrameID == frameID);
        }

        public int GetPanelCount()
        {
            return _windoorModel.panelIDCounter += 1;
        }

        public int GetMultiPanelCount()
        {
            return _windoorModel.mpanelIDCounter += 1;
        }

        public int GetDividerCount()
        {
            return _windoorModel.divIDCounter += 1;
        }

        public int GetPanelGlassID()
        {
            return _windoorModel.PanelGlassID_Counter += 1;
        }

        public void DeductPanelGlassID()
        {
            _windoorModel.PanelGlassID_Counter -= 1;
        }

        public void SetPanelGlassID()
        {
            _windoorModel.SetPanelGlassID();
        }

        ITransomUCPresenter current_transom;
        IMullionUCPresenter current_mullion;

        public void SetSelectedDivider(IDividerModel divModel,
                                       ITransomUCPresenter transomUCP = null,
                                       IMullionUCPresenter mullionUCP = null)
        {
            _tsLblStatus.Visible = true;
            _tsLblStatus.Text = divModel.Div_Name + " Selected";
            if (transomUCP != null)
            {
                if (current_transom != null)
                {
                    current_transom.boolKeyDown = false;
                    current_transom = null;
                }
                else if (current_mullion != null)
                {
                    current_mullion.boolKeyDown = false;
                    current_mullion = null;
                }
                transomUCP.boolKeyDown = true;
                transomUCP.FocusOnThisTransomDiv();
                current_transom = transomUCP;
            }
            else if (mullionUCP != null)
            {
                if (current_transom != null)
                {
                    current_transom.boolKeyDown = false;
                    current_transom = null;
                }
                else if (current_mullion != null)
                {
                    current_mullion.boolKeyDown = false;
                    current_mullion = null;
                }
                mullionUCP.boolKeyDown = true;
                mullionUCP.FocusOnThisMullionDiv();
                current_mullion = mullionUCP;
            }

        }

        public void DeselectDivider()
        {
            _mainView.GetLblSelectedDivider().Visible = false;
            _mainView.GetLblSelectedDivider().Text = "";
            _mainView.SetActiveControl(null);
        }

        public void DeleteMultiPanelPropertiesUC(int multiPanelID)
        {
            var propertiesUC = _commonfunc.GetAll(_pnlPropertiesBody, "MultiPanelPropertiesUC");
            foreach (IMultiPanelPropertiesUC mpnlProperties in propertiesUC)
            {
                if (mpnlProperties.MPanelID == multiPanelID)
                {
                    ((UserControl)mpnlProperties).Parent.Controls.Remove((UserControl)mpnlProperties);
                }
            }
        }

        public void DeleteDividerPropertiesUC(int divID)
        {
            var propertiesUC = _commonfunc.GetAll(_pnlPropertiesBody, "DividerPropertiesUC");
            foreach (IDividerPropertiesUC divProperties in propertiesUC)
            {
                if (divProperties.Div_ID == divID)
                {
                    ((UserControl)divProperties).Parent.Controls.Remove((UserControl)divProperties);
                }
            }
        }

        public void DeletePanelPropertiesUC(int panelID)
        {
            var propertiesUC = _commonfunc.GetAll(_pnlPropertiesBody, "Panel_PropertiesUC");
            foreach (IPanelPropertiesUC pnlProperties in propertiesUC)
            {
                if (pnlProperties.Panel_ID == panelID)
                {
                    ((UserControl)pnlProperties).Parent.Controls.Remove((UserControl)pnlProperties);
                }
            }
        }

        public void DeleteFramePropertiesUC(int frameID)
        {
            var propertiesUC = _commonfunc.GetAll(_pnlPropertiesBody, "FramePropertiesUC");
            foreach (IFramePropertiesUC frameProperties in propertiesUC)
            {
                if (frameProperties.FrameID == frameID)
                {
                    ((UserControl)frameProperties).Parent.Controls.Remove((UserControl)frameProperties);
                }
            }
        }

        public void DeleteConcretePropertiesUC(int concreteID)
        {
            var propertiesUC = _commonfunc.GetAll(_pnlPropertiesBody, "ConcretePropertiesUC");
            foreach (IConcretePropertiesUC concreteProperties in propertiesUC)
            {
                if (concreteProperties.Concrete_ID == concreteID)
                {
                    ((UserControl)concreteProperties).Parent.Controls.Remove((UserControl)concreteProperties);
                }
            }
        }

        private DataColumn CreateColumn(string columname, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columname;
            col.Caption = caption;
            return col;
        }

        public void SetChangesMark()
        {
            SetMainViewTitle(input_qrefno,
                             _projectName,
                             _custRefNo,
                             _windoorModel.WD_name,
                             _windoorModel.WD_profile,
                             false);
        }

        public void SaveChanges()
        {
            _mainView.mainview_title = _mainView.mainview_title.Replace("*", "");
            if (wndrProjectFileName != "")
            {
                string txtfile = wndrProjectFileName.Replace(".wndr", ".txt");
                File.WriteAllLines(txtfile, Saving_dotwndr());
                File.SetAttributes(txtfile, FileAttributes.Hidden);
                csfunc.EncryptFile(txtfile);
                File.Delete(txtfile);
                _mainView.GetToolStripButtonSave().Enabled = false;
                if (online_login != true)
                {
                    int startFileName = txtfile.LastIndexOf("\\") + 1;
                    string outFile = txtfile.Substring(startFileName, txtfile.LastIndexOf(".") - startFileName) + ".wndr";
                    searchStr = outFile;
                    x = 50;
                    _mainView.GetToolStripLabelSync().Image = Properties.Resources.cloud_sync_40px;
                    _mainView.GetToolStripLabelSync().Visible = true;
                }
                MessageBox.Show("File saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                wndrProjectFileName = _mainView.GetSaveFileDialog().FileName;
                SetMainViewTitle(input_qrefno,
                                     _projectName,
                                     _custRefNo,
                                     _windoorModel.WD_name,
                                     _windoorModel.WD_profile,
                                     true);
            }
            else
            {
                _mainView.GetSaveFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
                if (_mainView.GetSaveFileDialog().ShowDialog() == DialogResult.OK)
                {
                    if (wndrfile != _mainView.GetSaveFileDialog().FileName)
                    {
                        wndrfile = _mainView.GetSaveFileDialog().FileName;
                        saveToolStripButton_Click();

                    }
                }

            }
        }
        #endregion

    }
}