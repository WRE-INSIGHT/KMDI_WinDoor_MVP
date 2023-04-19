using CommonComponents;
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
using ModelLayer.Variables;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.Costing_Head;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

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
        private IConcreteUC _concreteUC;
        private IPanelModel _panelModel;

        ConstantVariables constants = new ConstantVariables();
        private ILoginView _loginView;
        private IItemInfoUC _itemInfoUC;
        private IFrameUC _frameUC;
        private IFramePropertiesUC _framePropertiesUC;

        private IQuotationServices _quotationServices;
        private IWindoorServices _windoorServices;
        private IFrameServices _frameServices;
        private IMultiPanelServices _multipanelServices;

        private IMultiPanelModel _multiModelParent = null;
        private IMultiPanelModel _multiPanelModel2ndLvl;
        private IMultiPanelModel _multiPanelModel3rdLvl;
        private IMultiPanelModel _multiPanelModel4thLvl;
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
        private IPricingPresenter _pricingPresenter;
        private ISetMultipleGlassThicknessPresenter _setMultipleGlassThicknessPresenter;


        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IMultiPanelPropertiesUCPresenter _multiPanelPropertiesUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUC2ndLvl; //Given Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUC3rdLvl; //Given Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUC4thLvl; //Given Instance
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP;
        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionUC _multiMullionUC2nd;
        private IMultiPanelTransomUC _multiTransomUC2nd;
        private IMultiPanelMullionUC _multiMullionUC3rd;
        private IMultiPanelTransomUC _multiTransomUC3rd;
        private IMultiPanelMullionUC _multiMullionUC4th;
        private IMultiPanelTransomUC _multiTransomUC4th;

        private IMullionUCPresenter _mullionUCP;
        private ITransomUCPresenter _transomUCP;


        Panel _pnlMain, _pnlItems, _pnlPropertiesBody, _pnlControlSub;

        private FrameModel.Frame_Padding frameType;
        private int _quoteId;
        private string input_qrefno, _projectName, _custRefNo;
        private string _wndrFilePath, _wndrFileName;
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
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;



        #endregion

        #region GetSet
        private IDictionary<string, string> _rdlcHeaders = new Dictionary<string, string>();
        
        public IDictionary<string,string> RDLCHeader
        {
            get { return _rdlcHeaders; }
            set { _rdlcHeaders = value; }
        }
        private List<IScreenModel> _screenList = new List<IScreenModel>();
        public List<IScreenModel> Screen_List
        {
            get { return _screenList; }
            set { _screenList = value; }
        }

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

        private NumericUpDown _lblCurrentPrice;
        public NumericUpDown LblCurrentPrice
        {
            get
            {
                return _lblCurrentPrice;
            }
            set
            {
                _lblCurrentPrice = value;
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
        private bool _itemLoad;
        public bool ItemLoad
        {
            get
            {
                return _itemLoad;
            }
            set
            {
                _itemLoad = value;
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
        private DateTime _dateAssigned;
        public DateTime dateAssigned
        {
            get
            {
                return _dateAssigned;
            }
            set
            {
                _dateAssigned = value;
            }
        }
        public string wndrFilePath
        {
            get
            {
                return _wndrFilePath;
            }

            set
            {
                _wndrFilePath = value;
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
        private string _position;
        public string position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }
        private string _aeic;
        public string aeic
        {
            get
            {
                return _aeic;
            }

            set
            {
                _aeic = value;
            }
        }
        private string _projectAddress;
        public string projectAddress
        {
            get
            {
                return _projectAddress;
            }

            set
            {
                _projectAddress = value;
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

        public string printStatus { get; set; }

        private string _titleLastname;
        public string titleLastname
        {
            get
            {
                return _titleLastname;
            }

            set
            {
                _titleLastname = value;
            }
        }

        public int PropertiesScroll
        {
            get
            {
                return _mainView.PropertiesScroll;
            }

            set
            {
                _mainView.PropertiesScroll = value;
            }
        }

        public int ItemScroll
        {
            get
            {
                return _mainView.ItemScroll;
            }

            set
            {
                _mainView.ItemScroll = value;
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
                             IScreenServices screenServices,
                             IMullionImagerUCPresenter mullionImagerUCP,
                             ITransomImagerUCPresenter transomImagerUCP,
                             IPricingPresenter pricingPresenter,
                             ISetMultipleGlassThicknessPresenter setMultipleGlassThicknessPresenter

                             )
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
            _mullionImagerUCP = mullionImagerUCP;
            _transomImagerUCP = transomImagerUCP;
            _pricingPresenter = pricingPresenter;
            _setMultipleGlassThicknessPresenter = setMultipleGlassThicknessPresenter;
            _lblCurrentPrice = _mainView.GetCurrentPrice();



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
                //_divPropUCP_forDMSelection.GetLeverEspagUCP().BindSashProfileArtNo();
                _divPropUCP_forDMSelection.GetLeverEspagUCP(_unityC, _divModel_forDMSelection).BindSashProfileArtNo();
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
            _mainView.MainViewClosedEventRaised += new EventHandler(OnMainViewClosedEventRaised);
            _mainView.MainViewClosingEventRaised += new FormClosingEventHandler(OnMainViewClosingEventRaised);
            _mainView.OpenToolStripButtonClickEventRaised += new EventHandler(OnOpenToolStripButtonClickEventRaised);
            _mainView.NewFrameButtonClickEventRaised += new EventHandler(OnNewFrameButtonClickEventRaised);
            _mainView.NewQuotationMenuItemClickEventRaised += new EventHandler(OnNewQuotationMenuItemClickEventRaised);
            _mainView.PanelMainSizeChangedEventRaised += new EventHandler(OnPanelMainSizeChangedEventRaised);
            _mainView.CreateNewItemClickEventRaised += new EventHandler(OnCreateNewItemClickEventRaised);
            _mainView.LabelSizeClickEventRaised += new EventHandler(OnLabelSizeClickEventRaised);
            _mainView.ButtonMinusZoomClickEventRaised += new EventHandler(OnButtonMinusZoomClickEventRaised);
            _mainView.ButtonPlusZoomClickEventRaised += new EventHandler(OnButtonPlusZoomClickEventRaised);
            _mainView.DeleteToolStripButtonClickEventRaised += new EventHandler(OnDeleteToolStripButtonClickEventRaised);
            _mainView.ListOfMaterialsToolStripMenuItemClickEventRaised += new EventHandler(OnListOfMaterialsToolStripMenuItemClickEventRaised);
            _mainView.CreateNewGlassClickEventRaised += new EventHandler(OnCreateNewGlassClickEventRaised);
            _mainView.ChangeItemColorClickEventRaised += new EventHandler(OnChangeItemColorClickEventRaised);
            _mainView.glassTypeColorSpacerToolStripMenuItemClickEventRaised += new EventHandler(OnGlassTypeColorSpacerToolStripMenuItemClickEventRaised);
            _mainView.glassBalancingToolStripMenuItemClickEventRaised += new EventHandler(OnGlassBalancingToolStripMenuItemClickEventRaised);
            _mainView.customArrowHeadToolStripMenuItemClickEventRaised += new EventHandler(OncustomArrowHeadToolStripMenuItemClickEventRaised);
            _mainView.assignProjectsToolStripMenuItemClickEventRaised += new EventHandler(OnAssignProjectsToolStripMenuItemClickEventRaised);
            _mainView.selectProjectToolStripMenuItemClickEventRaised += new EventHandler(OnSelectProjectToolStripMenuItemClickEventRaised);
            _mainView.NewConcreteButtonClickEventRaised += new EventHandler(OnNewConcreteButtonClickEventRaised);
            _mainView.refreshToolStripButtonClickEventRaised += new EventHandler(OnRefreshToolStripButtonClickEventRaised);
            _mainView.CostingItemsToolStripMenuItemClickRaiseEvent += new EventHandler(OnCostingItemsToolStripMenuItemClickRaiseEvent);
            _mainView.saveAsToolStripMenuItemClickEventRaised += new EventHandler(OnSaveAsToolStripMenuItemClickEventRaised);
            _mainView.saveToolStripButtonClickEventRaised += new EventHandler(OnSaveToolStripButtonClickEventRaised);
            _mainView.slidingTopViewToolStripMenuItemClickRaiseEvent += new EventHandler(OnSlidingTopViewToolStripMenuItemClickRaiseEvent);
            _mainView.ViewImagerToolStripButtonClickEventRaised += new EventHandler(OnViewImagerToolStripButtonClickEventRaised);
            _mainView.ItemsDragEventRaiseEvent += new DragEventHandler(OnItemsDragEventRaiseEvent);
            _mainView.SortItemButtonClickEventRaised += new EventHandler(OnSortItemButtonClickEventRaised);
            _mainView.existingItemToolStripMenuItemClickEventRaised += new EventHandler(OnExistingItemToolStripMenuItemClickEventRaised);
            _mainView.SetGlassToolStripMenuItemClickRaiseEvent += new EventHandler(OnSetGlassToolStripMenuItemClickRaiseEvent);
            _mainView.addProjectsToolStripMenuItemClickEventRaised += new EventHandler(OnAddProjectsToolStripMenuItemClickEventRaised);
            _mainView.screenToolStripMenuItemClickEventRaised += new EventHandler(OnScreenToolStripMenuItemClickEventRaised);
            _mainView.factorToolStripMenuItemClickEventRaised += new EventHandler(OnFactorToolStripMenuItemClickEventRaised);
            _mainView.billOfMaterialToolStripMenuItemClickEventRaised += new EventHandler(OnBillOfMaterialToolStripMenuItemClickEventRaised);
            _mainView.DuplicateToolStripButtonClickEventRaised += new EventHandler(OnDuplicateToolStripButtonClickEventRaised);
            _mainView.ChangeSyncDirectoryToolStripMenuItemClickEventRaised += new EventHandler(OnChangeSyncDirectoryToolStripMenuItemClickEventRaised);
            _mainView.NudCurrentPriceValueChangedEventRaised += new EventHandler(OnNudCurrentPriceValueChangedEventRaised);
            _mainView.setNewFactorEventRaised += new EventHandler(OnsetNewFactorEventRaised);
            _mainView.PanelMainMouseWheelRaiseEvent += new MouseEventHandler(OnPanelMainMouseWheelEventRaised);

        }

        private void OnMainViewClosingEventRaised(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(wndrFileName) && GetMainView().GetToolStripButtonSave().Enabled == true)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save your changes in " + wndrFileName + "?", "Closing Application",
                                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = false;
                }

                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (_quotationModel != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save your progress?", "Closing Application",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _mainView.GetSaveFileDialog().FileName = _custRefNo + "(" + input_qrefno + ")";
                        if (_mainView.GetSaveFileDialog().ShowDialog() == DialogResult.OK)
                        {
                            wndr_content = new List<string>();
                            SaveAs();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = false;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }

                }
            }
        }
        #region Events  
        private void OnPanelMainMouseWheelEventRaised(object sender, MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (numberOfTextLinesToMove > 0)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
        #region setnewfactor
        private void OnsetNewFactorEventRaised(object sender, EventArgs e)
        {
            setNewFactor();
        }

        public async void setNewFactor()
        {
            decimal value;
            try
            {
                string[] province = projectAddress.Split(',');
                value = await _quotationServices.GetFactorByProvince((province[province.Length - 2]).Trim());
                //string province = projectAddress.Split(',').LastOrDefault().Replace("Luzon", string.Empty).Replace("Visayas", string.Empty).Replace("Mindanao", string.Empty).Trim();
                //value = await _quotationServices.GetFactorByProvince(province);
                string factorTypes = "Province: "
                                   + (province[province.Length - 2]).Trim()
                                   + "\nCurrent/File Factor: "
                                   + _quotationModel.PricingFactor
                                   + "\nFactor in database: "
                                   + value;
                string input = Interaction.InputBox(factorTypes, "Set New Factor", _quotationModel.PricingFactor.ToString());
                if (input != "" && input != "0")
                {
                    try
                    {
                        decimal deci_input = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(input)));
                        if (deci_input > 0)
                        {
                            if (deci_input != _quotationModel.PricingFactor)
                            {
                                _quotationModel.PricingFactor = deci_input;
                                MessageBox.Show("New Factor Set Sucessfully");
                                GetCurrentPrice();
                            }
                            else
                            {
                                MessageBox.Show("Set Factor is the same as old", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (deci_input < 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void OnNudCurrentPriceValueChangedEventRaised(object sender, EventArgs e)
        {
            _lblCurrentPrice.Value = ((NumericUpDown)sender).Value;
            if (_itemLoad)
            {
                updatePriceOfMainView();
            }
            else
            {
                if (_quotationModel != null)
                {
                    updatePriceFromMainViewToItemList();
                    _windoorModel.WD_fileLoad = false;
                    _windoorModel.WD_currentPrice = _lblCurrentPrice.Value;
                }
                else
                {
                    _lblCurrentPrice.Value = 0;
                }
            }
        }

        private void OnChangeSyncDirectoryToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.WndrDir = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                _mainView.GetOpenFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
            }
        }
        private void OnBillOfMaterialToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            Run_GetListOfMaterials_SpecificItem();
            _quotationModel.BOMandItemlistStatus = "BOM";
            IPricingPresenter PricingPresenter = _pricingPresenter.CreateNewInstance(_unityC, this, _quotationModel);
            PricingPresenter.GetPricingView().ShowPricingList();
            _quotationModel.Select_Current_Windoor(_windoorModel);


        }

        private void OnDuplicateToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                Scenario_Quotation(false,
                                   false,
                                   false,
                                   false,
                                   false,
                                   true,
                                   frmDimensionPresenter.Show_Purpose.Duplicate,
                                   _windoorModel.WD_width,
                                   _windoorModel.WD_height,
                                   _windoorModel.WD_profile,
                                   _windoorModel.WD_BaseColor.Value.ToString());
                _quotationModel.Select_Current_Windoor(_windoorModel);
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }

        }
        private void OnFactorToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            IFactorPresenter factor = _factorPresenter.GetNewInstance(_unityC, this);
            factor.GetFactorView().ShowThis();
        }
        private void OnScreenToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            // int screenID = _screenModel.Screen_id += 1;
            _screenModel = _screenServices.AddScreenModel(0.0m,
                                                          0,
                                                          0,
                                                          null,
                                                          string.Empty,
                                                          0.0m,
                                                          0,
                                                          0,
                                                          0,
                                                          0.0m,
                                                          0.0m,
                                                          string.Empty,
                                                          0.0m,
                                                          0.0m);

            _screenModel.Screen_PVCVisibility = false;
            IScreenPresenter glassThicknessPresenter = _screenPresenter.CreateNewInstance(_unityC, this, _screenModel, _quotationServices);//, _screenDT);
            glassThicknessPresenter.GetScreenView().ShowScreemView();

        }

        private void OnSetGlassToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {

            ISetMultipleGlassThicknessPresenter multipleGlassThicknessPresenter = _setMultipleGlassThicknessPresenter.GetNewInstance(_unityC, _windoorModel, this);
            multipleGlassThicknessPresenter.Get_MltpleGlssThcknView().ShowMultipleThckView();

        }

        private void OnSlidingTopViewToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            ISetTopViewSlidingPanellingPresenter TopView = _setTopViewSlidingPanellingPresenter.CreateNewInstance(_unityC, this, _windoorModel, _itemInfoUCPresenter);
            TopView.GetSetTopViewSlidingPanellingView().GetSetTopSlidingPanellingView();
        }


        private void _mainView_selectProjectToolStripMenuItemClickEventRaised1(object sender, EventArgs e)
        {

        }

        string searchStr = "",
              todo,
              mainTodo;
        public bool online_login = true;
        int x = 50;

        private void OnSaveToolStripButtonClickEventRaised(object sender, EventArgs e)
        {

            wndr_content = new List<string>();
            SaveChanges();
        }


        private void OnSaveAsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            _mainView.GetSaveFileDialog().FileName = _custRefNo + "(" + input_qrefno + ")";
            if (_mainView.GetSaveFileDialog().ShowDialog() == DialogResult.OK)
            {
                wndr_content = new List<string>();
                SaveAs();
            }

        }

        public void SaveAs()
        {
            _wndrFilePath = _mainView.GetSaveFileDialog().FileName;
            if (_wndrFilePath != _mainView.GetSaveFileDialog().FileName)
            {
                _wndrFilePath = _mainView.GetSaveFileDialog().FileName;

            }
            else
            {
                if (!_mainView.mainview_title.Contains(_wndrFilePath))
                {
                    _mainView.mainview_title += "( " + _wndrFilePath + " )";
                }
            }
            saveToolStripButton_Click();
        }

        private void saveToolStripButton_Click()
        {
            //saveToolStripButton.Enabled = false;
            //UppdateDictionaries();
            _mainView.mainview_title = _mainView.mainview_title.Replace("*", "");
            if (_wndrFilePath != "")
            {
                try
                {
                    string txtfile = _wndrFilePath.Replace(".wndr", ".txt");
                    File.WriteAllLines(txtfile, Saving_dotwndr());
                    File.Delete(_wndrFilePath);
                    FileInfo f = new FileInfo(txtfile);
                    f.MoveTo(Path.ChangeExtension(txtfile, ".wndr"));
                    //File.SetAttributes(txtfile, FileAttributes.Hidden);
                    //csfunc.EncryptFile(txtfile);
                    //File.Delete(txtfile);

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
                    _wndrFilePath = _mainView.GetSaveFileDialog().FileName;
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
        List<string> wndr_content = new List<string>();

        private List<string> Saving_dotwndr()
        {
            #region Save

            wndr_content.Add("QuoteId: " + _quoteId);
            wndr_content.Add("ProjectName: " + _projectName);
            wndr_content.Add("ClientsName: " + inputted_projectName);
            wndr_content.Add("ClientsTitleLastname: " + _titleLastname);
            wndr_content.Add("ProjectAddress: " + _projectAddress);
            wndr_content.Add("CustomerRefNo: " + _custRefNo);
            wndr_content.Add("DateAssigned: " + _dateAssigned);
            wndr_content.Add("AEIC: " + _aeic);
            wndr_content.Add("AEIC_POS: " + _position);

            foreach (var prop in _quotationModel.GetType().GetProperties())
            {
                wndr_content.Add(prop.Name + ": " + prop.GetValue(_quotationModel, null));
            }
            foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                SaveWindoorModel(wdm);

            }
            foreach (ScreenModel scm in Screen_List)
            {
                wndr_content.Add("~");

                foreach (var prop in scm.GetType().GetProperties())
                {
                    wndr_content.Add(prop.Name + ": " + prop.GetValue(scm, null));
                    //wndr_content.Add("_screenServices." + prop.Name + " = " + prop.Name.Substring(0,1).ToLower() + prop.Name.Substring(1) + ";");
                }
                wndr_content.Add("~");
            }

            foreach (var dic in _rdlcHeaders)
            {
                wndr_content.Add(".");
                wndr_content.Add(dic.Key + ": " + dic.Value);
                wndr_content.Add(".");
            }

            wndr_content.Add("EndofFile");
            #endregion

            return wndr_content;
        }

        private void SaveWindoorModel(IWindoorModel wdm)
        {
            wndr_content.Add("(");
            foreach (var prop in wdm.GetType().GetProperties())
            {
                if (prop.Name == "Dictionary_ht_redArrowLines" && wdm.Dictionary_ht_redArrowLines != null)
                {

                    string Dictionary_ht_redArrowLinesArray = "";
                    foreach (KeyValuePair<int, Decimal> ht_redArrowLines in wdm.Dictionary_ht_redArrowLines)
                    {
                        Dictionary_ht_redArrowLinesArray += "<" + ht_redArrowLines.Key + "," + ht_redArrowLines.Value + ">; ";
                    }

                    wndr_content.Add(prop.Name + ": " + Dictionary_ht_redArrowLinesArray);
                }
                else if (prop.Name == "Dictionary_wd_redArrowLines" && wdm.Dictionary_wd_redArrowLines != null)
                {

                    string Dictionary_wd_redArrowLinesArray = "";
                    foreach (KeyValuePair<int, Decimal> wd_redArrowLines in wdm.Dictionary_wd_redArrowLines)
                    {
                        Dictionary_wd_redArrowLinesArray += "<" + wd_redArrowLines.Key + "," + wd_redArrowLines.Value + ">; ";
                    }

                    wndr_content.Add(prop.Name + ": " + Dictionary_wd_redArrowLinesArray);
                }

                else if (prop.Name == "WD_description")
                {
                    string Wd_desu = prop.GetValue(wdm, null).ToString().Replace("\n", @"\m/");
                    wndr_content.Add(prop.Name + ": " + Wd_desu);
                }
                else
                {
                    wndr_content.Add(prop.Name + ": " + prop.GetValue(wdm, null));

                }
            }
            foreach (Control wndrObject in wdm.lst_objects)
            {
                if (wndrObject.Name.Contains("Frame"))
                {
                    #region FrameModel
                    foreach (FrameModel frm in wdm.lst_frame)
                    {
                        if (frm.Frame_Name == wndrObject.Name)
                        {
                            wndr_content.Add("{");
                            foreach (var prop in frm.GetType().GetProperties())
                            {
                                wndr_content.Add("\t" + prop.Name + ": " + prop.GetValue(frm, null));
                            }
                            #region  Frame Panel
                            foreach (PanelModel pnl in frm.Lst_Panel)
                            {
                                wndr_content.Add("\t#");
                                foreach (var prop in pnl.GetType().GetProperties())
                                {


                                    if (prop.Name == "Panel_LstLouverArtNo")
                                    {
                                        string lstLouverArtNo = "";
                                        if (pnl.Panel_LstLouverArtNo != null)
                                        {
                                            foreach (string pnl_lstLouverArtNo in pnl.Panel_LstLouverArtNo)
                                            {
                                                lstLouverArtNo += pnl_lstLouverArtNo + ",";
                                            }
                                        }
                                        wndr_content.Add("\t\t" + prop.Name + ": " + lstLouverArtNo);
                                    }
                                    else if (prop.Name == "Panel_LstSealForHandleMultiplier")
                                    {
                                        string lstSealForHandleMultiplier = "";
                                        if (pnl.Panel_LstSealForHandleMultiplier != null)
                                        {
                                            foreach (int panel_LstSealForHandle in pnl.Panel_LstSealForHandleMultiplier)
                                            {
                                                lstSealForHandleMultiplier = panel_LstSealForHandle + ",";
                                            }
                                        }
                                        wndr_content.Add("\t\t" + prop.Name + ": " + lstSealForHandleMultiplier);
                                    }
                                    else
                                    {
                                        wndr_content.Add("\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                    }

                                }

                            }
                            #endregion
                            #region 2nd Level MultiPanel
                            foreach (MultiPanelModel mpnl in frm.Lst_MultiPanel)
                            {
                                wndr_content.Add("\t[");
                                foreach (var prop in mpnl.GetType().GetProperties())
                                {

                                    if (prop.Name == "MPanel_Parent")
                                    {
                                        wndr_content.Add("\t\t" + prop.Name + ": " + mpnl.MPanel_Parent.Name);
                                    }

                                    else
                                    {
                                        wndr_content.Add("\t\t" + prop.Name + ": " + prop.GetValue(mpnl, null));
                                    }
                                }
                                foreach (Control ctrl in mpnl.MPanelLst_Objects)
                                {
                                    //else if (row_str.Contains("ProjectName"))
                                    //{
                                    //    _projectName = extractedValue_str;
                                    //}

                                    if (ctrl.Name.Contains("PanelUC"))
                                    {
                                        #region 2nd Level MultiPanel Panel

                                        wndr_content.Add("\t\t#");
                                        foreach (PanelModel pnl in mpnl.MPanelLst_Panel)
                                        {
                                            if (ctrl.Name == pnl.Panel_Name)
                                            {

                                                foreach (var prop in pnl.GetType().GetProperties())
                                                {

                                                    if (prop.Name == "Panel_Parent")
                                                    {
                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + pnl.Panel_Parent.Name);
                                                    }

                                                    else if (prop.Name == "Panel_LstLouverArtNo")
                                                    {
                                                        string lstLouverArtNo = "";
                                                        if (pnl.Panel_LstLouverArtNo != null)
                                                        {
                                                            foreach (string pnl_lstLouverArtNo in pnl.Panel_LstLouverArtNo)
                                                            {
                                                                lstLouverArtNo += pnl_lstLouverArtNo + ",";
                                                            }
                                                        }
                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + lstLouverArtNo);
                                                    }
                                                    else if (prop.Name == "Panel_LstSealForHandleMultiplier")
                                                    {
                                                        string lstSealForHandleMultiplier = "";
                                                        if (pnl.Panel_LstSealForHandleMultiplier != null)
                                                        {
                                                            foreach (int panel_LstSealForHandle in pnl.Panel_LstSealForHandleMultiplier)
                                                            {
                                                                lstSealForHandleMultiplier = panel_LstSealForHandle + ",";
                                                            }
                                                        }
                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + lstSealForHandleMultiplier);
                                                    }
                                                    else
                                                    {
                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        #endregion

                                    }
                                    else if (ctrl.Name.Contains("MullionUC") || ctrl.Name.Contains("TransomUC"))
                                    {
                                        #region 2nd Level MultiPanel Divider

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
                                                    else if (prop.Name == "Div_Parent")
                                                    {

                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + div.Div_Parent.Name);
                                                    }
                                                    else if (prop.Name == "Div_CladdingSizeList" && div.Div_CladdingSizeList != null)
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
                                        #endregion

                                    }
                                    else if (ctrl.Name.Contains("MultiTransom") || ctrl.Name.Contains("MultiMullion"))
                                    {

                                        #region 2nd Level MultiPanel MultiPanel

                                        foreach (MultiPanelModel thirdlvlmpnl in mpnl.MPanelLst_MultiPanel)
                                        {
                                            if (ctrl.Name == thirdlvlmpnl.MPanel_Name)
                                            {
                                                wndr_content.Add("\t\t[");
                                                foreach (var prop in thirdlvlmpnl.GetType().GetProperties())
                                                {
                                                    if (prop.Name == "MPanel_Parent" || prop.Name == "MPanel_ParentModel")
                                                    {
                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + thirdlvlmpnl.MPanel_Parent.Name);
                                                    }
                                                    else
                                                    {
                                                        wndr_content.Add("\t\t\t" + prop.Name + ": " + prop.GetValue(thirdlvlmpnl, null));
                                                    }

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
                                                                    if (prop.Name == "Panel_Parent")
                                                                    {
                                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + pnl.Panel_Parent.Name);
                                                                    }
                                                                    else if (prop.Name == "Panel_LstLouverArtNo")
                                                                    {
                                                                        string lstLouverArtNo = "";
                                                                        if (pnl.Panel_LstLouverArtNo != null)
                                                                        {
                                                                            foreach (string pnl_lstLouverArtNo in pnl.Panel_LstLouverArtNo)
                                                                            {
                                                                                lstLouverArtNo += pnl_lstLouverArtNo + ",";
                                                                            }
                                                                        }
                                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + lstLouverArtNo);
                                                                    }
                                                                    else if (prop.Name == "Panel_LstSealForHandleMultiplier")
                                                                    {
                                                                        string lstSealForHandleMultiplier = "";
                                                                        if (pnl.Panel_LstSealForHandleMultiplier != null)
                                                                        {
                                                                            foreach (int panel_LstSealForHandle in pnl.Panel_LstSealForHandleMultiplier)
                                                                            {
                                                                                lstSealForHandleMultiplier = panel_LstSealForHandle + ",";
                                                                            }
                                                                        }
                                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + lstSealForHandleMultiplier);
                                                                    }
                                                                    else
                                                                    {
                                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                                                    }

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
                                                                    if (prop.Name == "Div_DMPanel" && div.Div_DMPanel != null)
                                                                    {

                                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + div.Div_DMPanel.Panel_Name);

                                                                    }
                                                                    else if (prop.Name == "Div_Parent")
                                                                    {

                                                                        wndr_content.Add("\t\t\t\t" + prop.Name + ": " + div.Div_Parent.Name);
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
                                                            wndr_content.Add("\t\t\t[");
                                                            foreach (var prop in fourthlvlmpnl.GetType().GetProperties())
                                                            {
                                                                if (prop.Name == "MPanel_Parent" || prop.Name == "MPanel_ParentModel")
                                                                {
                                                                    wndr_content.Add("\t\t\t\t" + prop.Name + ": " + fourthlvlmpnl.MPanel_Parent.Name);
                                                                }
                                                                else
                                                                {
                                                                    wndr_content.Add("\t\t\t\t" + prop.Name + ": " + prop.GetValue(fourthlvlmpnl, null));
                                                                }
                                                            }

                                                            foreach (Control fourthlvlctrl in fourthlvlmpnl.MPanelLst_Objects)
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
                                                                                if (prop.Name == "Panel_Parent")
                                                                                {
                                                                                    wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + pnl.Panel_Parent.Name);
                                                                                }
                                                                                else if (prop.Name == "Panel_LstLouverArtNo")
                                                                                {
                                                                                    string lstLouverArtNo = "";
                                                                                    if (pnl.Panel_LstLouverArtNo != null)
                                                                                    {
                                                                                        foreach (string pnl_lstLouverArtNo in pnl.Panel_LstLouverArtNo)
                                                                                        {
                                                                                            lstLouverArtNo += pnl_lstLouverArtNo + ",";
                                                                                        }
                                                                                    }
                                                                                    wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + lstLouverArtNo);
                                                                                }
                                                                                else if (prop.Name == "Panel_LstSealForHandleMultiplier")
                                                                                {
                                                                                    string lstSealForHandleMultiplier = "";
                                                                                    if (pnl.Panel_LstSealForHandleMultiplier != null)
                                                                                    {
                                                                                        foreach (int panel_LstSealForHandle in pnl.Panel_LstSealForHandleMultiplier)
                                                                                        {
                                                                                            lstSealForHandleMultiplier = panel_LstSealForHandle + ",";
                                                                                        }
                                                                                    }
                                                                                    wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + lstSealForHandleMultiplier);
                                                                                }
                                                                                else
                                                                                {
                                                                                    wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + prop.GetValue(pnl, null));
                                                                                }
                                                                            }
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
                                                                            wndr_content.Add("\t\t\t\t|");
                                                                            foreach (var prop in div.GetType().GetProperties())
                                                                            {


                                                                                if (prop.Name == "Div_DMPanel" && div.Div_DMPanel != null)
                                                                                {

                                                                                    wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + div.Div_DMPanel.Panel_Name);

                                                                                }
                                                                                else if (prop.Name == "Div_Parent")
                                                                                {

                                                                                    wndr_content.Add("\t\t\t\t\t" + prop.Name + ": " + div.Div_Parent.Name);
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
                                                            wndr_content.Add("\t\t\t]");

                                                        }
                                                    }
                                                }
                                                wndr_content.Add("\t\t]");
                                            }
                                        }
                                        #endregion
                                    }
                                }

                                wndr_content.Add("\t]");
                                break;
                            }
                            #endregion

                        }
                        wndr_content.Add("}");
                    }
                    #endregion
                }
                else if (wndrObject.Name.Contains("Concrete"))
                {
                    #region Concrete

                    foreach (IConcreteModel crm in wdm.lst_concrete)
                    {
                        if (wndrObject.Name == crm.Concrete_Name)
                        {
                            wndr_content.Add("/");
                            foreach (var prop in crm.GetType().GetProperties())
                            {
                                wndr_content.Add("\t" + prop.Name + ": " + prop.GetValue(crm, null));
                            }
                        }
                    }
                    #endregion
                }
            }
            wndr_content.Add(")");
        }

        private void OnCostingItemsToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            _quotationModel.BOMandItemlistStatus = "PriceItemList";
            IQuoteItemListPresenter quoteItesm = _quoteItemListPresenter.GetNewInstance(_unityC, _quotationModel, _quoteItemListUCPresenter, _windoorModel, this);
            quoteItesm.GetQuoteItemListView().showQuoteItemList();
            _quotationModel.Select_Current_Windoor(_windoorModel);
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


        private void OnRefreshToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                _basePlatformImagerUCPresenter.SendToBack_baseImager();
                _frameModel.Lst_MultiPanel = Arrange_Frame_MultiPanelModel(_frameModel);

                //save frame
                Windoor_Save_UserControl();
                Windoor_Save_PropertiesUC();

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
                //GetCurrentPrice();
                //itemDescription();

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void OnNewConcreteButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                Scenario_Quotation(false, false, false, true, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Concrete, 0, 0, "", "");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void OnSelectProjectToolStripMenuItemClickEventRaised(object sender, EventArgs e)
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

        private void OnAssignProjectsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
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

        private void OnGlassBalancingToolStripMenuItemClickEventRaised(object sender, EventArgs e)
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

        private void OnGlassTypeColorSpacerToolStripMenuItemClickEventRaised(object sender, EventArgs e)
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

        private void OnChangeItemColorClickEventRaised(object sender, EventArgs e)
        {
            IChangeItemColorPresenter presenter = _changeItemColorPresenter.GetNewInstance(_unityC, this, _windoorModel);
            presenter.ShowView();
        }

        private void OnCreateNewGlassClickEventRaised(object sender, EventArgs e)
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

        private void OnListOfMaterialsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
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
        private void OnDeleteToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            int propertiesScroll = PropertiesScroll;
            if (_quotationModel != null && _windoorModel != null)
            {
                _mainView.CreateNewWindoorBtnEnabled = false;

                if (MessageBox.Show("Are you sure want to delete " + _windoorModel.WD_name + "?", "Delete Item",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _basePlatformImagerUCPresenter.SendToBack_baseImager();
                    int wndrId = _windoorModel.WD_id;
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
                            //_windoorModel.lst_frame.Clear();
                            _quotationModel.Lst_Windoor.Remove(_windoorModel);

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
                        wdm.WD_id = count;
                        count++;
                    }
                    foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                    {
                        if (wndrId < _quotationModel.Lst_Windoor.Count())
                        {
                            if (wdm.WD_id == wndrId)
                            {
                                Load_Windoor_Item(wdm);
                                break;
                            }
                        }
                        else if (wndrId == _quotationModel.Lst_Windoor.Count())
                        {
                            Load_Windoor_Item(_quotationModel.Lst_Windoor[wndrId - 1]);
                            break;
                        }
                        else
                        {
                            if (wndrId - 1 == _quotationModel.Lst_Windoor.Count())
                            {
                                if (wdm.WD_id == wndrId - 1)
                                {
                                    Load_Windoor_Item(wdm);
                                    break;
                                }


                            }

                        }

                    }

                }
            }
            if (_quotationModel.Lst_Windoor.Count == 0)
            {
                Clearing_Operation();
            }
            else
            {
                _mainView.CreateNewWindoorBtnEnabled = true;
            }
            if (_quotationModel != null)
            {
                if (_quotationModel.Lst_Windoor.Count != 0)
                {
                    GetCurrentPrice();
                }
            }
            else
            {
                _lblCurrentPrice.Value = 0;
            }
            PropertiesScroll = propertiesScroll;
            //wndr_content = new List<string>();
            //Saving_dotwndr();
        }

        private void OnButtonPlusZoomClickEventRaised(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void OnButtonMinusZoomClickEventRaised(object sender, EventArgs e)
        {
            ZoomOut();
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
                Scenario_Quotation(false, true, false, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "C70 Profile", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
            }
            else if (tsmItem.Name == "PremiLineToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "PremiLine Profile", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
            }
            else if (tsmItem.Name == "G58ToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "G58 Profile", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
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
                    Scenario_Quotation(false, false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
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
                    Scenario_Quotation(true, false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
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
            Scenario_Quotation(false, false, true, false, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Frame, 0, 0, "", _frmDimensionPresenter.baseColor_frmDimensionPresenter);
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
                    _rdlcHeaders.Clear();              
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

                        openFileMethod(_mainView.GetOpenFileDialog().FileName);
                    }

                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show("Corrupted file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void openFileMethod(string filePath)
        {
            _wndrFilePath = filePath;
            isNewProject = false;
            isOpenProject = true;
            //csfunc.DecryptFile(wndrfile);
            int startFileName = _wndrFilePath.LastIndexOf("\\") + 1;
            wndrFileName = _wndrFilePath.Substring(startFileName);
            FileInfo f = new FileInfo(_wndrFilePath);
            f.MoveTo(Path.ChangeExtension(_wndrFilePath, ".txt"));
            string outFile = _wndrFilePath.Substring(0, startFileName) +
                             _wndrFilePath.Substring(startFileName, _wndrFilePath.LastIndexOf(".") - startFileName) + ".txt";

            file_lines = File.ReadAllLines(outFile);
            f.MoveTo(Path.ChangeExtension(outFile, ".wndr"));
            onload = true;
            _mainView.GetTsProgressLoading().Maximum = file_lines.Length;
            _basePlatformImagerUCPresenter.SendToBack_baseImager();
            StartWorker("Open_WndrFiles");
        }

        private void StartWorker(string todo)
        {
            if (bgw.IsBusy != true)
            {
                mainTodo = todo;
                bgw.RunWorkerAsync();
                if (todo == "Open_WndrFiles" || todo == "Add_Existing_Items" || todo == "Duplicate_Item")
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
            //_mainView.GetToolStripLabelLoading().Visible = visibility;
            //_mainView.GetTsProgressLoading().Visible = visibility;

            _mainView.GetMNSMainMenu().Enabled = enabled;
            _mainView.GetSCMain().Enabled = enabled;
            _mainView.GetPanelRight().Enabled = enabled;
            _mainView.GetTSMain().Enabled = enabled;

            _mainView.GetToolStripLabelLoading().Visible = visibility;
            _mainView.GetTsProgressLoading().Visible = visibility;
        }
        private void OnMainViewClosedEventRaised(object sender, EventArgs e)
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
            else
            {
                _mainView.GetOpenFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
            }
            //_mainView.Nickname = _userModel.Nickname;
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
            _glassThicknessDT.Columns.Add(CreateColumn("GlassType_Insu_Lami", "GlassType_Insu_Lami", "System.String"));
            _glassThicknessDT.Columns.Add(CreateColumn("Single", "Single", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Double", "Double", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Triple", "Triple", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Insulated", "Insulated", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Laminated", "Laminated", "System.Boolean"));

            #region Single
            //single Annealed
            _glassThicknessDT.Rows.Add(0.0f, "Unglazed", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(0.0f, "Security Mesh", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(5.0f, "5 mm Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Euro Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Acid Etched Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Acid Etched Euro Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Grey", "NA", true, false, false, false, false);

            //single Annealed w/ Georgian Bar 

            _glassThicknessDT.Rows.Add(5.0f, "5 mm Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm  Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);

            //Single Tempered
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Clear Oversized", "NA", true, false, false, false, false);//
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Grey", "NA", true, false, false, false, false);

            // Single Tempered w/ Georgian bar
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(12.0f, "12 mm Tempered Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);

            //Single Annealed With Low-E
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Grey", "NA", true, false, false, false, false);

            //Single Annealed With Low-E w / Georgian Bar 
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Tinted w/ HardCoated Low-E Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Tinted w/ HardCoated Low-E Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Tinted w/ HardCoated Low-E Grey with Georgian Bar", "NA", true, false, false, false, false);


            //Single Tempered With Low-E
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Grey", "NA", true, false, false, false, false);

            //Single Tempered Low w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Tinted w/ HardCoated Low-E Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Tinted w/ HardCoated Low-E Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Tinted w/ HardCoated Low-E Grey with Georgian Bar", "NA", true, false, false, false, false);

            //Single Tempered Heat-Soaked
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Heat-Soaked Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Heat-Soaked Clear", "NA", true, false, false, false, false);

            //Single Tempered Heat-Soaked w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Heat-Soaked Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Heat-Soaked Clear with Georgian Bar", "NA", true, false, false, false, false);

            //Single Tempered Heat-Soaked with Low-E
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Heat-Soaked Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Heat-Soaked Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Heat-Soaked Clear w/ HardCoated Low-E", "NA", true, false, false, false, false);

            //Single Tempered Heat-Soaked Low-E w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Heat-Soaked Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Heat-Soaked Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Heat-Soaked Clear w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);

            //Single Annealed Reflective
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Recflective Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Grey", "NA", true, false, false, false, false);

            //Single Annealed Reflective w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(8.0f, "8 mm  Recflective Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm  Recflective Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm  Recflective Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);

            //Single Tempered Reflective 
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Clear", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Bronze", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Blue", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Green", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Grey", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Gold w/ HardCoated Low-E", "NA", true, false, false, false, false);

            //Single Tempered Reflective w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Clear with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Bronze with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Blue with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Green with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(8.0f, "8 mm Tempered Recflective Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(10.0f, "10 mm Tempered Recflective Tinted Grey with Georgian Bar", "NA", true, false, false, false, false);
            _glassThicknessDT.Rows.Add(6.0f, "6 mm Tempered Recflective Gold w/ HardCoated Low-E with Georgian Bar", "NA", true, false, false, false, false);

            #endregion

            #region Double

            #region Insulated

            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Solarban Clear with Low-e + 12 Argon + 6 mm Tempered Clear", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(20.0f, "4 mm Self-Cleaning Tempered Clear + 12 Argon + 4 mm Tempered Clear with Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Self-Cleaning Tempered Clear + 12 Argon + 6 mm Tempered Clear with Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.38f, "6 mm  Bronze + 12 Argon + (3 mm Clear + 0.38 PVB + 3 Clear )", "Double Insulated", false, true, false, true, false);

            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Solarban Clear with Low-e + 12 Argon + 6 mm Tempered Clear with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(20.0f, "4 mm Self-Cleaning Tempered Clear + 12 Argon + 4 mm Tempered Clear with Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Self-Cleaning Tempered Clear + 12 Argon + 6 mm Tempered Clear with Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.38f, "6 mm  Bronze + 12 Argon + (3 mm Clear + 0.38 PVB + 3 Clear )", "Double Insulated with Georgian Bar", false, true, false, true, false);
            //Annealed
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Clear + 10 + 4 mm Clear", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear + 12 + 6 mm Clear", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear + 12 + 6 mm Tinted", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Tinted + 12 + 6 mm Tinted", "Double Insulated", false, true, false, true, false);

            //Annealed w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Clear + 10 + 4 mm Clear with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear + 12 + 6 mm Clear with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear + 12 + 6 mm Tinted with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Tinted + 12 + 6 mm Tinted with Georgian Bar", "Double Insulated", false, true, false, true, false);

            //Tempered
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 + 4 mm Clear", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 Argon + 4 mm Tempered Tinted", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear + 12 + 6 mm Tempered Tinted", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Clear + 12 Argon + 6 mm Tempered Tinted", "Double Insulated", false, true, false, true, false);

            //Tempered w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 + 4 mm Clear with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 Argon + 4 mm Tempered Tinted with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Clear + 12 + 6 mm Tempered Tinted with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Clear + 12 Argon + 6 mm Tempered Tinted with Georgian Bar", "Double Insulated", false, true, false, true, false);

            //Annealed with Low-e
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Clear + 10 + 4 mm Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Clear + 12 Argon + 6 mm Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tinted + 10 Argon + 4 mm Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tinted + 12 Argon + 6 mm Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);

            //Annealed  Low-e w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Clear + 10 + 4 mm Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Clear + 12 Argon + 6 mm Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tinted + 10 Argon + 4 mm Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tinted + 12 Argon + 6 mm Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);

            //Tempered with Low-e
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Clear + 10 + 4 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 + 4 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Clear + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e", "DI", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Tinted + 10 Argon + 4 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Tinted + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);

            //Tempered Low-e w/ Georgian Bar 
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Clear + 10 + 4 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 + 4 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Clear + 10 Argon + 4 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Clear + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "DI", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(23.0f, "5 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Clear + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(18.0f, "4 mm Tempered Tinted + 10 Argon + 4 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Tinted + 12 Argon + 6 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);
            //Tempered Heat-Soaked with Low-e
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Heat-Soaked Clear + 12 Argon + 6 mm Tempered Heat-Soaked Clear with HardCoated Low-e", "Double Insulated", false, true, false, true, false);

            //Tempered Heat-Soaked Low-e w/ Georgian Bar
            _glassThicknessDT.Rows.Add(24.0f, "6 mm Tempered Heat-Soaked Clear + 12 Argon + 6 mm Tempered Heat-Soaked Clear with HardCoated Low-e with Georgian Bar", "Double Insulated", false, true, false, true, false);






            #endregion

            #region Laminated

            _glassThicknessDT.Rows.Add(11.89f, "6 mm Tempered Clear + 0.89  SG InterLayer + 5 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.89f, "6 mm Tempered Clear + 0.89  SG InterLayer + 6 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52  SG InterLayer + 6 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(21.52f, "10 mm Tempered Clear + 1.52  SG InterLayer + 10 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(25.52f, "12 mm Tempered Clear + 1.52  SG InterLayer + 12 mm Tempered Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear with Low-e + 1.52 + 4 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear with Low-e + 1.52  + 6 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(23.04f, "10 mm Tempered Clear with Low-e + 3.04 + 10 mm Tempered Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52  + 4 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(10.52f, "4 mm Tempered Clear + 1.52  + 5 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.52f, "4 mm Tempered Clear + 1.52  + 6 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 + 6 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Tinted + 1.52 + 4 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.52f, "6 mm Tempered Tinted + 1.52  + 5 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Tinted + 1.52 + 6 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(12.52f, "5 mm Tempered Clear with Low-e + 1.52 + 6 mm Tempered Tinted", "Double Laminated", false, true, false, false, true);//

            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Heat-Soaked Clear + 1.52 + 6 mm Tempered Heat-Soaked Clear w/ HardCoated Low-e", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(6.38f, "3 mm  Clear + 0.38 + 3 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(8.76f, "4 mm  Clear + 0.76 + 4 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm  Clear + 0.76 + 5 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.76f, "6 mm  Clear + 0.76 + 6 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(21.04f, "10 mm  Clear + 3.04 + 8 mm  Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(7.38f, "4 mm  Clear with Low-e + 0.38 + 3 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm  Clear with Low-e + 0.76 + 5 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.76f, "6 mm  Clear with Low-e + 0.76 + 6 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(5.76f, "4 mm  Clear with Low-e + 0.76 + 1 mm  Tinted", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(6.38f, "3 mm  Tinted + 0.38 + 3 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76, "6 mm  Tinted + 0.76 + 5 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.76, "6 mm  Tinted + 0.76 + 6 mm  Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(6.338f, "3 mm  Clear + 0.38 White PVB  + 3 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(8.76f, "4 mm  Clear + 0.76 White PVB  + 4 mm  Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm  Clear + 0.76 White PVB  + 5 mm  Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(12.89f, "6 mm  Clear + 0.89 SG Interlayer  + 6 mm  Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(7.52f, "3 mm Tempered Clear + 1.52 + 3 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52 + 4 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.52f, "6 mm Tempered Clear + 1.52 + 4 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.52f, "6 mm Tempered Clear + 1.52 + 5 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 + 6 mm Tempered Clear", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(12.76f, "6 mm  Tinted + 0.76 + 6 mm  Tinted", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(8.76f, "4 mm  Tinted + 0.76 + 4 mm  with HardCoated Low-e", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.52f, "6 mm Tempered Tinted  + 1.52 + 5 mm Tempered Clear with HardCoated Low-e", "Double Laminated", false, true, false, false, true);//Same above but diff price and pos
            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear with HardCoated Low-e", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear with HardCoated Low-e", "Double Laminated", false, true, false, false, true);

            //with Georgian Bar 

            _glassThicknessDT.Rows.Add(11.89f, "6 mm Tempered Clear + 0.89  SG InterLayer + 5 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.89f, "6 mm Tempered Clear + 0.89  SG InterLayer + 6 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52  SG InterLayer + 6 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(21.52f, "10 mm Tempered Clear + 1.52  SG InterLayer + 10 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(25.52f, "12 mm Tempered Clear + 1.52  SG InterLayer + 12 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear with Low-e + 1.52 + 4 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear with Low-e + 1.52  + 6 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(23.04f, "10 mm Tempered Clear with Low-e + 3.04 + 10 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52  + 4 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(10.52f, "4 mm Tempered Clear + 1.52  + 5 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.52f, "4 mm Tempered Clear + 1.52  + 6 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 + 6 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Tinted + 1.52 + 4 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.52f, "6 mm Tempered Tinted + 1.52  + 5 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Tinted + 1.52 + 6 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(12.52f, "5 mm Tempered Clear with Low-e + 1.52 + 6 mm Tempered Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);//

            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Heat-Soaked Clear + 1.52 + 6 mm Tempered Heat-Soaked Clear w/ HardCoated Low-e with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(6.38f, "3 mm  Clear + 0.38 + 3 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(8.76f, "4 mm  Clear + 0.76 + 4 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm  Clear + 0.76 + 5 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.76f, "6 mm  Clear + 0.76 + 6 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(21.04f, "10 mm  Clear + 3.04 + 8 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(7.38f, "4 mm  Clear with Low-e + 0.38 + 3 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm  Clear with Low-e + 0.76 + 5 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.76f, "6 mm  Clear with Low-e + 0.76 + 6 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(5.76f, "4 mm  Clear with Low-e + 0.76 + 1 mm  Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(6.38f, "3 mm  Tinted + 0.38 + 3 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76, "6 mm  Tinted + 0.76 + 5 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.76, "6 mm  Tinted + 0.76 + 6 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(6.338f, "3 mm  Clear + 0.38 White PVB  + 3 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(8.76f, "4 mm  Clear + 0.76 White PVB  + 4 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.76f, "6 mm  Clear + 0.76 White PVB  + 5 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(12.89f, "6 mm  Clear + 0.89 SG Interlayer  + 6 mm  Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(7.52f, "3 mm Tempered Clear + 1.52 + 3 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52 + 4 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(11.52f, "6 mm Tempered Clear + 1.52 + 4 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.52f, "6 mm Tempered Clear + 1.52 + 5 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 + 6 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);

            _glassThicknessDT.Rows.Add(12.76f, "6 mm  Tinted + 0.76 + 6 mm  Tinted with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(8.76f, "4 mm  Tinted + 0.76 + 4 mm  with HardCoated Low-e with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(12.52f, "6 mm Tempered Tinted  + 1.52 + 5 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Laminated", false, true, false, false, true);//Same above but diff price and pos
            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(9.52f, "4 mm Tempered Clear + 1.52 White PVB + 4 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Laminated", false, true, false, false, true);
            _glassThicknessDT.Rows.Add(13.52f, "6 mm Tempered Clear + 1.52 White PVB + 6 mm Tempered Clear with HardCoated Low-e with Georgian Bar", "Double Laminated", false, true, false, false, true);

            #endregion

            #endregion

            #region Triple

            #region InsuLated

            _glassThicknessDT.Rows.Add(24.0f, "4 mm  Clear + 6 + 4 mm  Clear + 6 + 4 mm  Clear", "Triple Insulated", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 + 4 mm  Clear + 6 + 4 mm Tempered Clear", "Triple Insulated", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear", "Triple Insulated", false, false, true, true, false);
            //_glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear (Type One)", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 Argon + 4 mm  Clear + 6 Argon + 4 mm Tempered Clear with Low-e", "Triple Insulated", false, false, true, true, false);

            //with Georgian Bar 
            _glassThicknessDT.Rows.Add(24.0f, "4 mm  Clear + 6 + 4 mm  Clear + 6 + 4 mm  Clear with Georgian Bar", "Triple Insulated", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 + 4 mm  Clear + 6 + 4 mm Tempered Clear with Georgian Bar", "Triple Insulated", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear with Georgian Bar", "Triple Insulated", false, false, true, true, false);
            //_glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 + 4 mm Tempered Clear + 6 + 4 mm Tempered Clear (Type One) with Georgian Bar", false, false, true, true, false);
            _glassThicknessDT.Rows.Add(24.0f, "4 mm Tempered Clear + 6 Argon + 4 mm  Clear + 6 Argon + 4 mm Tempered Clear with Low-e with Georgian Bar", "Triple Insulated", false, false, true, true, false);
            #endregion

            #region Laminated

            _glassThicknessDT.Rows.Add(19.04f, "6 mm Clear + 1.52 + 4 mm Clear + 1.52 + 6 mm Clear", "Triple Laminated", false, false, true, false, true);
            //_glassThicknessDT.Rows.Add(23.04f, "8 mm Tempered Tinted Green + 1.52 + 4 mm Tempered Clear + 1.52 + 8 mm Tempered Tinted Green", false, false, true, false, true);

            //w Georgian Bar 
            _glassThicknessDT.Rows.Add(19.04f, "6 mm Clear + 1.52 + 4 mm Clear + 1.52 + 6 mm Clear with Georgian Bar", "Triple Laminated", false, false, true, false, true);

            #endregion

            #endregion

            _glassTypeDT.Columns.Add(CreateColumn("GlassType", "GlassType", "System.String"));
            _spacerDT.Columns.Add(CreateColumn("Spacer", "Spacer", "System.String"));
            _colorDT.Columns.Add(CreateColumn("Color", "Color", "System.String"));

            _glassTypeDT.Rows.Add("Annealed");
            _glassTypeDT.Rows.Add("Tempered");
            _glassTypeDT.Rows.Add("Acid Etched");
            _glassTypeDT.Rows.Add("Unglazed");

            _spacerDT.Rows.Add("Air");
            _spacerDT.Rows.Add("Argon");

            _colorDT.Rows.Add("Clear");
            _colorDT.Rows.Add("Tinted Gray");
            _colorDT.Rows.Add("Tinted Bronze");
            _colorDT.Rows.Add("Tinted Green");
            _colorDT.Rows.Add("Euro Grey");


            _mainView.GetCurrentPrice().Maximum = decimal.MaxValue;
            _mainView.GetCurrentPrice().DecimalPlaces = 2;
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.DoWork += Bgw_DoWork;
            if (Properties.Settings.Default.FilePath != "")
            {
                openFileMethod(Properties.Settings.Default.FilePath);
                Properties.Settings.Default.FilePath = "";
                Properties.Settings.Default.Save();
            }


        }
        private void OnAddProjectsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
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

        private void OnExistingItemToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_mainView.GetOpenFileDialog().ShowDialog() == DialogResult.OK)
                {


                    SetChangesMark();
                    add_existing = true;
                    _isOpenProject = false;
                    string addExistingwndrfile = _mainView.GetOpenFileDialog().FileName;

                    int startFileName = addExistingwndrfile.LastIndexOf("\\") + 1;
                    FileInfo f = new FileInfo(addExistingwndrfile);
                    f.MoveTo(Path.ChangeExtension(addExistingwndrfile, ".txt"));
                    string outFile = addExistingwndrfile.Substring(0, startFileName) +
                                     addExistingwndrfile.Substring(startFileName, addExistingwndrfile.LastIndexOf(".") - startFileName) + ".txt";
                    Windoor_Save_UserControl();
                    Windoor_Save_PropertiesUC();
                    file_lines = File.ReadAllLines(outFile);
                    f.MoveTo(Path.ChangeExtension(addExistingwndrfile, ".wndr"));
                    onload = true;
                    Windoor_Save_UserControl();
                    Windoor_Save_PropertiesUC();

                    ////foreach(string strline in file_lines) 
                    ////{
                    ////    if(strline.Contains("WD_name:"))
                    ////    {
                    ////        MessageBox.Show(strline);
                    ////    }
                    ////}
                    _mainView.GetTsProgressLoading().Maximum = file_lines.Length;
                    _basePlatformImagerUCPresenter.SendToBack_baseImager();
                    StartWorker("Add_Existing_Items");
                    SetMainViewTitle(input_qrefno,
                                 _projectName,
                                 _custRefNo,
                                 _windoorModel.WD_name,
                                 _windoorModel.WD_profile,
                                 false);
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show("Corrupted file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSortItemButtonClickEventRaised(object sender, EventArgs e)
        {
            _sortItemPresenter = _sortItemPresenter.GetNewInstance(_unityC, _quotationModel, _sortItemUCPresenter, _windoorModel, this);
            _sortItemPresenter.GetSortItemView().showSortItem();
        }
        private void OnItemsDragEventRaiseEvent(object sender, DragEventArgs e)
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
        private void OnViewImagerToolStripButtonClickEventRaised(object sender, EventArgs e)
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
                    case "Add_Existing_Items":
                    case "Duplicate_Item":
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
                    case "Add_Existing_Items":
                    case "Duplicate_Item":
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
                        case "Add_Existing_Items":
                        case "Duplicate_Item":
                            //tmr_fadeOutText.Enabled = true;
                            //tmr_fadeOutText.Start();

                            //int startFileName = wndrfile.LastIndexOf("\\") + 1;
                            //string outFile = wndrfile.Substring(0, startFileName) +
                            //                 wndrfile.Substring(startFileName, wndrfile.LastIndexOf(".") - startFileName) + ".txt";
                            //File.Delete(outFile);
                            SetMainViewTitle(input_qrefno,
                                             _projectName,
                                             _custRefNo,
                                             _windoorModel.WD_name,
                                             _windoorModel.WD_profile,
                                             true);

                            _mainView.GetToolStripLabelLoading().Text = "Finished";

                            ToggleMode(false, true);
                            _mainView.GetToolStripLabelLoading().Visible = true;
                            //autoDescription = true;
                            onload = false;
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
                inside_screen = false;
                _itemLoad = true;
                if (_isOpenProject && !isNewProject)
                {
                    inside_quotation = true;
                }
            }
            else if (row_str == "(")
            {
                inside_quotation = false;
                inside_item = true;
            }
            else if (row_str == "{")
            {
                inside_item = false;
                inside_frame = true;

            }
            else if (row_str == "/")
            {
                if (inside_frame)
                {
                    Frame_Load();
                }
                inside_item = false;
                inside_concrete = true;
            }

            else if (row_str.Contains("#"))
            {
                if (inside_frame)
                {
                    Frame_Load();
                }

                if (inside_panel)
                {
                    Panel_Load();
                }
                inside_panel = true;
            }
            else if (file_lines[row].Contains("\t["))
            {
                if (inside_frame)
                {
                    Frame_Load();
                }
                if (file_lines[row].ToString() == "\t[")
                {
                    mpnllvl = "second level";
                }
                else if (file_lines[row].ToString() == "\t\t[")
                {
                    mpnllvl = "third level";
                }
                else if (file_lines[row].ToString() == "\t\t\t[")
                {
                    mpnllvl = "fourth level";
                }
                inside_multi = true;
            }
            else if (file_lines[row].Contains("\t]"))
            {
                if (inside_panel)
                {
                    Panel_Load();
                }
                if (file_lines[row].ToString() == "\t\t\t]")
                {
                    _multiPanelModel4thLvl = null;
                    mpnllvl = "third level";

                }
                else if (file_lines[row].ToString() == "\t\t]")
                {
                    _multiPanelModel3rdLvl = null;
                    mpnllvl = "second level";
                }
                else
                {
                    _multiPanelModel2ndLvl = null;
                    mpnllvl = "";
                }

            }
            else if (row_str.Contains("|"))
            {
                if (inside_panel)
                {
                    Panel_Load();
                }
                inside_divider = true;
            }
            else if (row_str == "}")
            {
                if (inside_panel)
                {
                    Panel_Load();
                }
                _frameModel.Lst_MultiPanel = Arrange_Frame_MultiPanelModel(_frameModel);
                frm_Width = 0; ;
                frm_Height = 0;
                inside_frame = false;
                frmDimension_profileType = "";
                frmDimension_baseColor = "";

            }
            else if (row_str == ")")
            {
                _basePlatformPresenter.InvalidateBasePlatform();
                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                inside_item = false;
            }
            else   if (row_str == "~")
            {
                if (inside_screen)
                {
                    Load_Screen();
                    inside_screen = false;
                }
                else
                {
                    inside_screen = true;
                }

            }
            else if(row_str == "." )
            {
                if (inside_rdlcDic)
                {
                    Load_RDLCHeaders();
                    inside_rdlcDic = false;
                }
                else
                {
                    inside_rdlcDic = true;
                }
            }
              if (row_str == "EndofFile")
            {
                add_existing = false;
                int wndrId = 0;
                foreach (IWindoorModel wndr in _quotationModel.Lst_Windoor)
                {
                    wndrId += 1;
                    wndr.WD_name = "Item " + wndrId;
                    wndr.WD_id = wndrId;
                }

                if (mainTodo == "Open_WndrFiles")
                {
                    Load_Windoor_Item(_quotationModel.Lst_Windoor[0]);

                    updatePriceOfMainView();
                    ItemScroll = 0;
                }
                else if (mainTodo == "Add_Existing_Items" || mainTodo == "Duplicate_Item")
                {
                    Load_Windoor_Item(_windoorModel);
                    _lblCurrentPrice.Value = _windoorModel.WD_price;
                    ItemScroll = _mainView.GetPanelItems().VerticalScroll.Maximum;

                }
                PropertiesScroll = 0;
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
                    else if (row_str.Contains("ClientsName:"))
                    {
                        inputted_projectName = extractedValue_str;
                    }
                    else if (row_str.Contains("ClientsTitleLastname:"))
                    {
                        _titleLastname = extractedValue_str;
                    }
                    else if (row_str.Contains("ProjectAddress:"))
                    {
                        _projectAddress = extractedValue_str;
                    }
                    else if (row_str.Contains("CustomerRefNo"))
                    {
                        _custRefNo = extractedValue_str;
                        inputted_custRefNo = extractedValue_str;
                    }
                    else if (row_str.Contains("DateAssigned"))
                    {
                        _dateAssigned = Convert.ToDateTime(extractedValue_str);
                    }
                    else if (row_str.Contains("AEIC:"))
                    {
                        _aeic = extractedValue_str;
                    }
                    else if (row_str.Contains("AEIC_POS:"))
                    {
                        _position = extractedValue_str;
                    }
                    else if (row_str.Contains("PricingFactor"))
                    {
                        _quotationModel.PricingFactor = Convert.ToDecimal(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0.00" : (String.Format("{0:0.00}", Convert.ToDecimal(extractedValue_str))));
                    }
                    else if (row_str.Contains("Quotation_ref_no"))
                    {
                        inputted_quotationRefNo = extractedValue_str;
                    }
                    else if (row_str.Contains("Quotation_Date"))
                    {
                        inputted_quoteDate = Convert.ToDateTime(extractedValue_str);
                        Scenario_Quotation(false, false, false, false, true, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                        _quotationModel.Quotation_ref_no = inputted_quotationRefNo;
                        _quotationModel.Customer_Ref_Number = inputted_custRefNo;
                        _quotationModel.Date_Assigned = dateAssigned;

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
                    }

                    else if (row_str.Contains("BOM_Filter:"))
                    {
                        foreach (BillOfMaterialsFilter bomf in BillOfMaterialsFilter.GetAll())
                        {
                            if (bomf.ToString() == extractedValue_str)
                            {
                                _quotationModel.BOM_Filter = bomf;
                            }
                        }
                    }
                    else if (row_str.Contains("BOM_Status:"))
                    {
                        _quotationModel.BOM_Status = Convert.ToBoolean(extractedValue_str);
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
                            frm_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_BaseColor:"))
                        {
                            frmDimension_baseColor = extractedValue_str;
                        }
                        if (row_str.Contains("WD_width:"))
                        {
                            frm_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            Scenario_Quotation(false,
                                     false,
                                     false,
                                     false,
                                     true,
                                     false,
                                     frmDimensionPresenter.Show_Purpose.CreateNew_Item,
                                     frm_Width,
                                     frm_Height,
                                     frmDimension_profileType,
                                     frmDimension_baseColor);
                            _windoorModel.WD_fileLoad = true;
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
                            _windoorModel.WD_price = Convert.ToDecimal(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_quantity:"))
                        {
                            _windoorModel.WD_quantity = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_visibility:"))
                        {
                            _windoorModel.WD_visibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("WD_description:"))
                        {
                            _windoorModel.WD_description = extractedValue_str.Replace(@"\m/", "\n");
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
                        if (row_str.Contains("WD_price:"))
                        {
                            _windoorModel.WD_price = Convert.ToDecimal(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_quantity:"))
                        {
                            _windoorModel.WD_quantity = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_discount:"))
                        {
                            _windoorModel.WD_discount = Convert.ToDecimal(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
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
                            _windoorModel.WD_CostingPoints = decimal.Parse(extractedValue_str);
                        }

                        if (row_str.Contains("Dictionary_wd_redArrowLines:"))
                        {
                            string[] words = extractedValue_str.Split(';');
                            if (extractedValue_str.Contains("<"))
                            {
                                Dictionary<int, Decimal> dictionary_wd_redArrowLinesList = new Dictionary<int, Decimal>();
                                foreach (string str in words)
                                {
                                    if (str.Trim() != string.Empty)
                                    {
                                        int key = Convert.ToInt32(str.Split('<', ',')[1]);
                                        decimal value = Convert.ToDecimal(str.Split(',', '>')[1]);
                                        dictionary_wd_redArrowLinesList.Add(key, value);
                                    }

                                }
                                _windoorModel.Dictionary_wd_redArrowLines = dictionary_wd_redArrowLinesList;
                            }
                        }
                        if (row_str.Contains("Dictionary_ht_redArrowLines:"))
                        {
                            string[] words = extractedValue_str.Split(';');
                            if (extractedValue_str.Contains("<"))
                            {
                                Dictionary<int, Decimal> dictionary_ht_redArrowLinesList = new Dictionary<int, Decimal>();
                                foreach (string str in words)
                                {
                                    if (str.Trim() != string.Empty)
                                    {
                                        int key = Convert.ToInt32(str.Split('<', ',')[1]);
                                        decimal value = Convert.ToDecimal(str.Split(',', '>')[1]);
                                        dictionary_ht_redArrowLinesList.Add(key, value);
                                    }

                                }
                                _windoorModel.Dictionary_ht_redArrowLines = dictionary_ht_redArrowLinesList;
                            }
                        }
                        if (row_str.Contains("WD_pboxImagerHeight:"))
                        {
                            _windoorModel.WD_pboxImagerHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("WD_itemName:"))
                        {
                            _windoorModel.WD_itemName = extractedValue_str;
                        }
                        if (row_str.Contains("WD_WindoorNumber:"))
                        {
                            _windoorModel.WD_WindoorNumber = extractedValue_str;

                        }
                        #endregion
                    }
                    else if (inside_frame)
                    {
                        #region Load for Frame Model


                        if (row_str.Contains("Frame_Height:"))
                        {
                            frm_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Width:"))
                        {
                            frm_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        if (row_str.Contains("Frame_BasicDeduction:"))
                        {
                        }
                        if (row_str.Contains("Frame_HeightToBind:"))
                        {
                            frm_HeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        if (row_str.Contains("FrameImageRenderer_Height:"))
                        {
                            frmImageRenderer_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ID:"))
                        {
                            frm_ID = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Type:"))
                        {
                            if (row_str.Contains("Window"))
                            {
                                frameType = FrameModel.Frame_Padding.Window;
                            }
                            else
                            {
                                frameType = FrameModel.Frame_Padding.Door;
                            }
                        }
                        if (row_str.Contains("Frame_Name:"))
                        {
                            frm_Name = extractedValue_str;
                        }

                        if (row_str.Contains("Frame_WidthToBind:"))
                        {
                            frm_WidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("FrameImageRenderer_Width:"))
                        {
                            frmImageRenderer_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Visible:"))
                        {
                            frm_Visible = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("FrameProp_Height:"))
                        {
                            frmProp_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("frmImageRenderer_Zoom:"))
                        {
                            frmImageRenderer_Zoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Zoom:"))
                        {
                            frm_Zoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_BotFrameEnable:"))
                        {
                            frm_BotfrmEnable = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_Deduction:"))
                        {
                        }
                        if (row_str.Contains("Frame_ExplosionWidth:"))
                        {
                            frm_ExplosionWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ExplosionHeight:"))
                        {
                            frm_ExplosionHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ReinfWidth:"))
                        {
                            frm_ReinfWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ReinfHeight:"))
                        {
                            frm_ReinfHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_CmenuDeleteVisibility:"))
                        {
                            frm_CmenuDeleteVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_If_InwardMotorizedCasement:"))
                        {
                            frm_If_InwardMotorizedCasement = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_MilledArtNo:"))
                        {
                            foreach (MilledFrame_ArticleNo artcNo in MilledFrame_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_MilledArtNo = artcNo;
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
                                    frm_MilledReinfArtNo = artcNo;
                                    break;
                                }
                            }

                        }
                        if (row_str.Contains("Frame_ArtNo:"))
                        {
                            foreach (FrameProfile_ArticleNo artcNo in FrameProfile_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_ArtNo = artcNo;
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
                                    frm_ReinfArtNo = artcNo;
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
                                    frm_BotfrmArtNo = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_BotFrameVisible:"))
                        {
                            frm_BotfrmVisible = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_SlidingRailsQty:"))
                        {
                            frm_SlidingRailsQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_SlidingRailsQtyVisibility:"))
                        {
                            frm_SlidingRailsQtyVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ConnectionType:"))
                        {
                            foreach (FrameConnectionType artcNo in FrameConnectionType.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_ConnectionType = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ConnectionTypeVisibility:"))
                        {
                            frm_ConnectionTypeVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ArtNoForPremi:"))
                        {
                            foreach (FrameProfileForPremi_ArticleNo artcNo in FrameProfileForPremi_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_ArtNoForPremi = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ExplosionWidth:"))
                        {
                            frm_ExplosionWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ReinfForPremiArtNo:"))
                        {
                            foreach (FrameReinfForPremi_ArticleNo artcNo in FrameReinfForPremi_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_ReinfForPremiArtNo = artcNo;
                                    break;
                                }
                            }
                        }

                        if (row_str.Contains("Frame_MechJointArticleNo:"))
                        {
                            foreach (Frame_MechJointArticleNo artcNo in Frame_MechJointArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_MechJointArticleNo = artcNo;
                                    break;
                                }
                            }

                        }
                        if (row_str.Contains("Frame_TrackProfileArtNoVisibility:"))
                        {
                            frm_BotfrmVisible = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_TrackProfileArtNo:"))
                        {
                            foreach (TrackProfile_ArticleNo artcNo in TrackProfile_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_TrackProfile_ArticleNo = artcNo;
                                    break;
                                }
                            }
                        }

                        if (row_str.Contains("Frame_ConnectingProfile_ArticleNo:"))
                        {
                            foreach (ConnectingProfile_ArticleNo artcNo in ConnectingProfile_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_ConnectingProfile_ArticleNo = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_MeshType:"))
                        {
                            foreach (MeshType artcNo in MeshType.GetAll())
                            {
                                if (artcNo.ToString() == extractedValue_str)
                                {
                                    frm_MeshType = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ScreenVisibility:"))
                        {
                            frm_ScreenVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ScreenOption:"))
                        {
                            frm_ScreenOption = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ScreenHeightOption:"))
                        {
                            frm_ScreenHeightOption = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ScreenHeightVisibility:"))
                        {
                            frm_ScreenHeightVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ScreenFrameHeight:"))
                        {
                            frm_ScreenFrameHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Frame_ScreenFrameHeightEnable:"))
                        {
                            frm_ScreenFrameHeightEnable = Convert.ToBoolean(extractedValue_str);
                        }
                        #endregion
                    }
                    else if (inside_concrete)
                    {
                        #region Load for Concrete Model

                        if (row_str.Contains("Concrete_Width:"))
                        {
                            frm_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        if (row_str.Contains("Concrete_Height:"))
                        {
                            frm_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            Scenario_Quotation(false,
                                               false,
                                               false,
                                               false,
                                               true,
                                               false,
                                               frmDimensionPresenter.Show_Purpose.CreateNew_Concrete,
                                               frm_Width,
                                               frm_Height,
                                               frmDimension_profileType,
                                               frmDimension_baseColor);

                        }
                        if (row_str.Contains("Concrete_Id:"))
                        {
                            _concreteModel.Concrete_Id = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Concrete_WidthToBind:"))
                        {
                            _concreteModel.Concrete_WidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Concrete_HeightToBind:"))
                        {
                            _concreteModel.Concrete_HeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Concrete_ImagerWidthToBind:"))
                        {
                            _concreteModel.Concrete_ImagerWidthToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Concrete_ImagerHeightToBind:"))
                        {
                            _concreteModel.Concrete_ImagerHeightToBind = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Concrete_ImagerZoom:"))
                        {
                            _concreteModel.Concrete_ImagerZoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        if (row_str.Contains("Concrete_Zoom:"))
                        {
                            _concreteModel.Concrete_Zoom = float.Parse(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                            inside_concrete = false;
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
                                    if (mpnllvl == "fourth level")
                                    {
                                        if (extractedValue_str.Contains("MultiMullion"))
                                        {
                                            panel_Parent = _multiMullionUC4th.Getflp();
                                        }
                                        else
                                        {
                                            panel_Parent = _multiTransomUC4th.Getflp();
                                        }
                                    }
                                    else if (mpnllvl == "third level")
                                    {
                                        if (extractedValue_str.Contains("MultiMullion"))
                                        {
                                            panel_Parent = _multiMullionUC3rd.Getflp();
                                        }
                                        else
                                        {
                                            panel_Parent = _multiTransomUC3rd.Getflp();
                                        }
                                    }
                                    else
                                    {
                                        if (extractedValue_str.Contains("MultiMullion"))
                                        {
                                            panel_Parent = _multiMullionUC2nd.Getflp();
                                        }
                                        else
                                        {
                                            panel_Parent = _multiTransomUC2nd.Getflp();
                                        }
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
                                    panel_MultiPanelGroup = _frameModel.Frame_UC;
                                }
                                else
                                {

                                    if (panel_Parent.Name.Contains("MultiMullion"))
                                    {
                                        panel_MultiPanelGroup = (UserControl)_multiMullionUC2nd;
                                    }
                                    else
                                    {
                                        panel_MultiPanelGroup = (UserControl)_multiTransomUC2nd;
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
                        if (row_str.Contains("Panel_DisplayHeightDecimal:") && _userModel.Department != "Sales & Operations (Costing)")
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
                        if (row_str.Contains("Panel_DisplayWidthDecimal:") && _userModel.Department != "Sales & Operations (Costing)")
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
                        if (row_str.Contains("Panel_GlassPricePerSqrMeter:"))
                        {
                            panel_GlassPricePerSqrMeter = Convert.ToDecimal(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
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
                            if (_multiPanelModel3rdLvl == null)
                            {
                                panel_ParentMultiPanelModel = _multiPanelModel2ndLvl;
                            }
                            else if (_multiPanelModel4thLvl == null)
                            {
                                panel_ParentMultiPanelModel = _multiPanelModel3rdLvl;
                            }
                            else
                            {
                                panel_ParentMultiPanelModel = _multiPanelModel4thLvl;
                            }
                        }
                        if (row_str.Contains("Panel_PropertyHeight:"))
                        {
                            panel_PropertyHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
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
                            panel_GlassThickness = float.Parse(extractedValue_str);
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
                        else if (row_str.Contains("Panel_GlassType_Insu_Lami:"))
                        {
                            panel_GlassType_Insu_Lami = extractedValue_str;
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

                        else if (row_str.Contains("Panel_LouverGallerySetCount:"))
                        {
                            panel_LouverGallerySetCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_CasementSealWidth:"))
                        {
                            panel_CasementSealWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_RubberSealWidth:"))
                        {
                            panel_RubberSealWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
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
                        #region Louvre Panel

                        if (row_str.Contains("Panel_PlantOnWeatherStripHeadWidth:"))
                        {
                            panel_PlantOnWeatherStripHeadWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_PlantOnWeatherStripSealWidth:"))
                        {
                            panel_PlantOnWeatherStripSealWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverFrameWeatherStripHeadWidth:"))
                        {
                            panel_LouverFrameWeatherStripHeadWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverFrameBottomWeatherStripWidth:"))
                        {
                            panel_LouverFrameBottomWeatherStripWidth = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_SealForHandleQty:"))
                        {
                            panel_SealForHandleQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouvreGallerySetHeight:"))
                        {
                            panel_LouvreGallerySetHeight = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverNumberBladesPerSet:"))
                        {
                            panel_LouverNumberBladesPerSet = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverGalleryVisibility:"))
                        {
                            panel_LouverGalleryVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverGallerySetVisibility:"))
                        {
                            panel_LouverGallerySetVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassPnlGlazingBeadVisibility:"))
                        {
                            panel_GlassPnlGlazingBeadVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_GlassPnlGlazingAdaptorVisibility:"))
                        {
                            panel_GlassPnlGlazingAdaptorVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverGallerySetOptionVisibility:"))
                        {
                            panel_LouverGallerySetOptionVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Panel_LouverGallerySetOptionArtNo:"))
                        {
                            panel_LouverGallerySetOptionArtNo = extractedValue_str;
                        }
                        else if (row_str.Contains("Panel_LouverBladeTypeOption:"))
                        {
                            foreach (BladeType_Option bto in BladeType_Option.GetAll())
                            {
                                if (bto.ToString() == extractedValue_str)
                                {
                                    panel_LouverBladeTypeOption = bto;
                                }
                            }
                        }

                        else if (row_str.Contains("Panel_LouverBladeHeight:"))
                        {
                            foreach (BladeHeight_Option bho in BladeHeight_Option.GetAll())
                            {
                                if (bho.ToString() == extractedValue_str)
                                {
                                    panel_LouverBladeHeight = bho;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LouverHandleType:"))
                        {
                            foreach (LouverHandleType_Option lhto in LouverHandleType_Option.GetAll())
                            {
                                if (lhto.ToString() == extractedValue_str)
                                {
                                    panel_LouverHandleType = lhto;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LouverHandleLocation:"))
                        {
                            foreach (LouverHandleLoc_Option lhlo in LouverHandleLoc_Option.GetAll())
                            {
                                if (lhlo.ToString() == extractedValue_str)
                                {
                                    panel_LouverHandleLocation = lhlo;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LouverGalleryColor:"))
                        {
                            foreach (LouverColor_Option lco in LouverColor_Option.GetAll())
                            {
                                if (lco.ToString() == extractedValue_str)
                                {
                                    panel_LouverGalleryColor = lco;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_AluminumPullHandleArtNo:"))
                        {
                            foreach (AluminumPullHandle_ArticleNo aphan in AluminumPullHandle_ArticleNo.GetAll())
                            {
                                if (aphan.ToString() == extractedValue_str)
                                {
                                    panel_AluminumPullHandleArtNo = aphan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PlantOnWeatherStripHeadArtNo:"))
                        {
                            foreach (PlantOnWeatherStripHead_ArticleNo powsan in PlantOnWeatherStripHead_ArticleNo.GetAll())
                            {
                                if (powsan.ToString() == extractedValue_str)
                                {
                                    panel_PlantOnWeatherStripHeadArtNo = powsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PlantOnWeatherStripSealArtNo:"))
                        {
                            foreach (PlantOnWeatherStripSeal_ArticleNo powssan in PlantOnWeatherStripSeal_ArticleNo.GetAll())
                            {
                                if (powssan.ToString() == extractedValue_str)
                                {
                                    panel_PlantOnWeatherStripSealArtNo = powssan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LouverFrameWeatherStripHeadArtNo:"))
                        {
                            foreach (LouverFrameWeatherStripHead_ArticleNo lfwsan in LouverFrameWeatherStripHead_ArticleNo.GetAll())
                            {
                                if (lfwsan.ToString() == extractedValue_str)
                                {
                                    panel_LouverFrameWeatherStripHeadArtNo = lfwsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LouverFrameBottomWeatherStripArtNo:"))
                        {
                            foreach (LouverFrameBottomWeatherStrip_ArticleNo lfbwsan in LouverFrameBottomWeatherStrip_ArticleNo.GetAll())
                            {
                                if (lfbwsan.ToString() == extractedValue_str)
                                {
                                    panel_LouverFrameBottomWeatherStripArtNo = lfbwsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RubberSealArtNo:"))
                        {
                            foreach (RubberSeal_ArticleNo rsan in RubberSeal_ArticleNo.GetAll())
                            {
                                if (rsan.ToString() == extractedValue_str)
                                {
                                    panel_RubberSealArtNo = rsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CasementSealArtNo:"))
                        {
                            foreach (CasementSeal_ArticleNo csan in CasementSeal_ArticleNo.GetAll())
                            {
                                if (csan.ToString() == extractedValue_str)
                                {
                                    panel_CasementSealArtNo = csan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SealForHandleArtNo:"))
                        {
                            foreach (SealForHandle_ArticleNo sfhan in SealForHandle_ArticleNo.GetAll())
                            {
                                if (sfhan.ToString() == extractedValue_str)
                                {
                                    panel_SealForHandleArtNo = sfhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_BubbleSealArtNo:"))
                        {
                            foreach (BubbleSeal_ArticleNo bsan in BubbleSeal_ArticleNo.GetAll())
                            {
                                if (bsan.ToString() == extractedValue_str)
                                {
                                    panel_BubbleSealArtNo = bsan;
                                }
                            }
                        }


                        else if (row_str.Contains("Panel_LstLouverArtNo:"))
                        {
                            panel_LstLouverArtNo = new List<string>();
                            string[] arrLouverArtNo = extractedValue_str.Split(new char[] { ',' }, StringSplitOptions.None);
                            foreach (string str_louver_artNo in arrLouverArtNo)
                            {
                                if (str_louver_artNo != "" && str_louver_artNo != null)
                                {
                                    panel_LstLouverArtNo.Add(str_louver_artNo);
                                }
                            }

                        }

                        #endregion
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
                        }
                        else if (row_str.Contains("Panel_OverLappingPanelQty:"))
                        {

                            panel_OverLappingPanelQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }



                        else if (row_str.Contains("Panel_AluminumPullHandleArtNo:"))
                        {

                            foreach (AluminumPullHandle_ArticleNo aphan in AluminumPullHandle_ArticleNo.GetAll())
                            {
                                if (aphan.ToString() == extractedValue_str)
                                {
                                    panel_AluminumPullHandleArticleNo = aphan;
                                }
                            }





                        }
                        //List<int> Panel_LstSealForHandleMultiplier
                        else if (row_str.Contains("Panel_LstSealForHandleMultiplier:"))
                        {
                            panel_LstSealForHandleMultiplier = new List<int>();
                            string[] arrSealForHandle = extractedValue_str.Split(new char[] { ',' }, StringSplitOptions.None);
                            foreach (string str_SealForHandle in arrSealForHandle)
                            {
                                if (str_SealForHandle != "" && str_SealForHandle != null)
                                {
                                    panel_LstSealForHandleMultiplier.Add(Convert.ToInt32(str_SealForHandle));
                                }
                            }

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
                            if (extractedValue_str.Contains("Frame"))
                            {
                                mPanel_Parent = _frameModel.Frame_UC;

                            }
                            else
                            {
                                if (mpnllvl == "fourth level")
                                {
                                    if (extractedValue_str.Contains("Mullion"))
                                    {
                                        mPanel_Parent = _multiMullionUC3rd.Getflp();

                                    }
                                    else
                                    {
                                        mPanel_Parent = _multiTransomUC3rd.Getflp();
                                    }
                                }
                                else if (mpnllvl == "third level")
                                {
                                    if (extractedValue_str.Contains("Mullion"))
                                    {
                                        mPanel_Parent = _multiMullionUC2nd.Getflp();

                                    }
                                    else
                                    {
                                        mPanel_Parent = _multiTransomUC2nd.Getflp();
                                    }
                                }

                            }
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
                            mPanelProp_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
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
                            if (extractedValue_str.Contains("Multi"))
                            {
                                if (extractedValue_str.Contains("Mullion"))
                                {
                                    if (_multiPanelModel2ndLvl.MPanel_Type == "Mullion")
                                    {
                                        mPanel_ParentModel = _multiPanelModel2ndLvl;
                                    }
                                    else
                                    {
                                        mPanel_ParentModel = _multiPanelModel3rdLvl;
                                    }
                                }
                                else
                                {
                                    if (_multiPanelModel2ndLvl.MPanel_Type == "Transom")
                                    {
                                        mPanel_ParentModel = _multiPanelModel2ndLvl;
                                    }
                                    else
                                    {
                                        mPanel_ParentModel = _multiPanelModel3rdLvl;
                                    }
                                }

                            }
                            else
                            {
                                mPanel_ParentModel = null;
                            }
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
                                _multiPanelModel2ndLvl = multipanelModel;
                                _multiPanelModel2ndLvl.MPanel_WidthToBind = mPanel_WidthToBind;
                                _multiPanelModel2ndLvl.MPanel_WidthToBindPrev = mPanel_WidthToBindPrev;
                                _multiPanelModel2ndLvl.MPanelImager_WidthToBindPrev = mPanelImager_WidthToBindPrev;
                                _multiPanelModel2ndLvl.MPanel_HeightToBind = mPanel_HeightToBind;
                                _multiPanelModel2ndLvl.MPanel_HeightToBindPrev = mPanel_HeightToBindPrev;
                                _multiPanelModel2ndLvl.MPanelImager_HeightToBindPrev = mPanelImager_HeightToBindPrev;
                                _multiPanelModel2ndLvl.MPanel_Type = mPanel_Type;
                                _multiPanelModel2ndLvl.MPanelImageRenderer_Height = mPanelImageRenderer_Height;
                                _multiPanelModel2ndLvl.MPanelImageRenderer_Width = mPanelImageRenderer_Width;
                                _multiPanelModel2ndLvl.MPanel_Margin = mPanel_Margin;
                                _multiPanelModel2ndLvl.MPanelImageRenderer_Margin = mPanelImageRenderer_Margin;
                                _multiPanelModel2ndLvl.MPanelProp_Height = 129;
                                _multiPanelModel2ndLvl.MPanel_NumEnable = mPanel_NumEnable;
                                _multiPanelModel2ndLvl.MPanel_Placement = mPanel_Placement;
                                _multiPanelModel2ndLvl.MPanel_DividerEnabled = mPanel_DividerEnabled;
                                _multiPanelModel2ndLvl.MPanel_OriginalDisplayWidth = mPanel_OriginalDisplayWidth;
                                _multiPanelModel2ndLvl.MPanel_OriginalDisplayWidthDecimal = mPanel_OriginalDisplayWidthDecimal;
                                _multiPanelModel2ndLvl.MPanel_OriginalDisplayHeight = mPanel_OriginalDisplayHeight;
                                _multiPanelModel2ndLvl.MPanel_OriginalDisplayHeightDecimal = mPanel_OriginalDisplayHeightDecimal;
                                _multiPanelModel2ndLvl.MPanel_OriginalGlassWidth = mPanel_OriginalGlassWidth;
                                _multiPanelModel2ndLvl.MPanel_OriginalGlassWidthDecimal = mPanel_OriginalGlassWidthDecimal;
                                _multiPanelModel2ndLvl.MPanel_OriginalGlassHeight = mPanel_OriginalGlassHeight;
                                _multiPanelModel2ndLvl.MPanel_OriginalGlassHeightDecimal = mPanel_OriginalGlassHeightDecimal;
                                _multiPanelModel2ndLvl.MPanel_CmenuDeleteVisibility = mPanel_CmenuDeleteVisibility;
                                _multiPanelModel2ndLvl.MPanel_GlassBalanced = mPanel_GlassBalanced;
                                _multiPanelModel2ndLvl.MPanel_ParentModel = null;
                                _multiPanelModel2ndLvl.Set_DimensionToBind_using_FrameDimensions();
                                _multiPanelModel2ndLvl.Imager_Set_DimensionToBind_using_FrameDimensions();
                                _frameModel.Lst_MultiPanel.Add(_multiPanelModel2ndLvl);
                                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPanelPropertiesUCP.GetNewInstance(_unityC, _multiPanelModel2ndLvl, this);
                                UserControl multiPropUC = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                                multiPropUC.Dock = DockStyle.Top;
                                _framePropertiesUCPresenter.GetFramePropertiesUC().GetFramePropertiesPNL().Controls.Add(multiPropUC);
                                multiPropUC.BringToFront();
                                _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");
                                if (mPanel_Type.Contains("Mullion"))
                                {
                                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel2ndLvl,
                                                                                                                                      _frameModel,
                                                                                                                                      _frameImagerUCP);
                                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                                    IMultiPanelMullionUCPresenter multiUCP = (MultiPanelMullionUCPresenter)_multiMullionUCP.GetNewInstance(_unityC,
                                                                                                                                           _userModel,
                                                                                                                                           _multiPanelModel2ndLvl,
                                                                                                                                           _frameModel,
                                                                                                                                           this,
                                                                                                                                           _frameUCPresenter,
                                                                                                                                           _multiTransomUCP,
                                                                                                                                           multiPropUCP,
                                                                                                                                           _frameImagerUCP,
                                                                                                                                           _basePlatformImagerUCPresenter,
                                                                                                                                           multiMullionImagerUCP);

                                    _multiMullionUCP = multiUCP;
                                    _multiMullionUC2nd = _multiMullionUCP.GetMultiPanel();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)_multiMullionUC2nd);
                                    _basePlatformImagerUCPresenter.Invalidate_flpMain();
                                }
                                else if (mPanel_Type.Contains("Transom"))
                                {
                                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel2ndLvl,
                                                                                                                                      _frameModel,
                                                                                                                                      _frameImagerUCP);
                                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                                    IMultiPanelTransomUCPresenter multiUCP = (MultiPanelTransomUCPresenter)_multiTransomUCP.GetNewInstance(_unityC,
                                                                                                                                           _userModel,
                                                                                                                                           _multiPanelModel2ndLvl,
                                                                                                                                           _frameModel,
                                                                                                                                           this,
                                                                                                                                           _frameUCPresenter,
                                                                                                                                           multiPropUCP,
                                                                                                                                           _frameImagerUCP,
                                                                                                                                           _basePlatformImagerUCPresenter,
                                                                                                                                           multiTransomImagerUCP);
                                    _multiTransomUCP = multiUCP;
                                    _multiTransomUC2nd = _multiTransomUCP.GetMultiPanel();
                                    _frameModel.Frame_UC.Controls.Add((UserControl)_multiTransomUC2nd);
                                }
                                _multiPropUC2ndLvl = multiPropUCP;

                            }
                            #region 3rd level
                            else if (mpnllvl == "third level") //drawing of 3rd level multipanel objs
                            {
                                _multiPanelModel3rdLvl = multipanelModel;
                                _multiPanelModel3rdLvl.MPanel_WidthToBind = mPanel_WidthToBind;
                                _multiPanelModel3rdLvl.MPanel_WidthToBindPrev = mPanel_WidthToBindPrev;
                                _multiPanelModel3rdLvl.MPanelImager_WidthToBindPrev = mPanelImager_WidthToBindPrev;
                                _multiPanelModel3rdLvl.MPanel_HeightToBind = mPanel_HeightToBind;
                                _multiPanelModel3rdLvl.MPanel_HeightToBindPrev = mPanel_HeightToBindPrev;
                                _multiPanelModel3rdLvl.MPanelImager_HeightToBindPrev = mPanelImager_HeightToBindPrev;
                                _multiPanelModel3rdLvl.MPanel_Type = mPanel_Type;
                                _multiPanelModel3rdLvl.MPanelImageRenderer_Height = mPanelImageRenderer_Height;
                                _multiPanelModel3rdLvl.MPanelImageRenderer_Width = mPanelImageRenderer_Width;
                                _multiPanelModel3rdLvl.MPanel_Margin = mPanel_Margin;
                                _multiPanelModel3rdLvl.MPanelImageRenderer_Margin = mPanelImageRenderer_Margin;
                                _multiPanelModel3rdLvl.MPanelProp_Height = 129;
                                _multiPanelModel3rdLvl.MPanel_NumEnable = mPanel_NumEnable;
                                _multiPanelModel3rdLvl.MPanel_Placement = mPanel_Placement;
                                _multiPanelModel3rdLvl.MPanel_DividerEnabled = mPanel_DividerEnabled;
                                _multiPanelModel3rdLvl.MPanel_OriginalDisplayWidth = mPanel_OriginalDisplayWidth;
                                _multiPanelModel3rdLvl.MPanel_OriginalDisplayWidthDecimal = mPanel_OriginalDisplayWidthDecimal;
                                _multiPanelModel3rdLvl.MPanel_OriginalDisplayHeight = mPanel_OriginalDisplayHeight;
                                _multiPanelModel3rdLvl.MPanel_OriginalDisplayHeightDecimal = mPanel_OriginalDisplayHeightDecimal;
                                _multiPanelModel3rdLvl.MPanel_OriginalGlassWidth = mPanel_OriginalGlassWidth;
                                _multiPanelModel3rdLvl.MPanel_OriginalGlassWidthDecimal = mPanel_OriginalGlassWidthDecimal;
                                _multiPanelModel3rdLvl.MPanel_OriginalGlassHeight = mPanel_OriginalGlassHeight;
                                _multiPanelModel3rdLvl.MPanel_OriginalGlassHeightDecimal = mPanel_OriginalGlassHeightDecimal;
                                _multiPanelModel3rdLvl.MPanel_CmenuDeleteVisibility = mPanel_CmenuDeleteVisibility;
                                _multiPanelModel3rdLvl.MPanel_GlassBalanced = mPanel_GlassBalanced;
                                _multiPanelModel3rdLvl.Set_DimensionToBind_using_FrameDimensions();
                                _frameModel.Lst_MultiPanel.Add(_multiPanelModel3rdLvl);
                                _multiPanelModel2ndLvl.MPanelLst_MultiPanel.Add(_multiPanelModel3rdLvl);
                                _multiPanelModel2ndLvl.Reload_MultiPanelMargin();
                                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPanelPropertiesUCP.GetNewInstance(_unityC, _multiPanelModel3rdLvl, this);
                                UserControl multiPropUC = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                                multiPropUC.Dock = DockStyle.Top;
                                _multiPropUC2ndLvl.GetMultiPanelPropertiesPNL().Controls.Add(multiPropUC);
                                multiPropUC.BringToFront();
                                _multiPanelModel2ndLvl.AdjustPropertyPanelHeight("Mpanel", "add");
                                _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");
                                if (mPanel_Type.Contains("Mullion"))
                                {
                                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel3rdLvl,
                                                                                                                                      _frameModel,
                                                                                                                                      _multiTransomImagerUCP);
                                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                                    _multiTransomImagerUCP.AddControl((UserControl)multiMullionImagerUC);
                                    _multiPanelModel2ndLvl.MPanelLst_Imagers.Add((UserControl)multiMullionImagerUC);
                                    IMultiPanelMullionUCPresenter multiUCP = (MultiPanelMullionUCPresenter)_multiMullionUCP.GetNewInstance(_unityC,
                                                                                                                                           _userModel,
                                                                                                                                            _multiPanelModel3rdLvl,
                                                                                                                                            _frameModel,
                                                                                                                                            this,
                                                                                                                                            _frameUCPresenter,
                                                                                                                                            _multiTransomUCP,
                                                                                                                                            multiPropUCP,
                                                                                                                                            _frameImagerUCP,
                                                                                                                                            _basePlatformImagerUCPresenter,
                                                                                                                                            multiMullionImagerUCP,
                                                                                                                                            _multiTransomImagerUCP);
                                    _multiMullionUCP = multiUCP;
                                    _multiMullionUC3rd = _multiMullionUCP.GetMultiPanel();
                                    _multiTransomUC2nd.Getflp().Controls.Add((UserControl)_multiMullionUC3rd);
                                    _multiMullionUCP.SetInitialLoadFalse();
                                    _multiPanelModel3rdLvl.MPanel_Parent = _multiTransomUC2nd.Getflp();
                                    _multiPanelModel2ndLvl.AddControl_MPanelLstObjects((UserControl)_multiMullionUC3rd, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)_multiMullionUC, _frameModel.Frame_Type.ToString());


                                }
                                else if (mPanel_Type.Contains("Transom"))
                                {
                                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel3rdLvl,
                                                                                                                                      _frameModel,
                                                                                                                                      _multiMullionImagerUCP);
                                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                                    _multiMullionImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                                    _multiPanelModel2ndLvl.MPanelLst_Imagers.Add((UserControl)multiTransomImagerUC);
                                    IMultiPanelTransomUCPresenter multiTransomUCP = _multiTransomUCP.GetNewInstance(_unityC,
                                                                                                                    _userModel,
                                                                                                                    _multiPanelModel3rdLvl,
                                                                                                                    _frameModel,
                                                                                                                    this,
                                                                                                                    _frameUCPresenter,
                                                                                                                    _multiMullionUCP,
                                                                                                                    multiPropUCP,
                                                                                                                    _frameImagerUCP,
                                                                                                                    _basePlatformImagerUCPresenter,
                                                                                                                    multiTransomImagerUCP,
                                                                                                                    _multiMullionImagerUCP);
                                    _multiTransomUCP = multiTransomUCP;
                                    _multiTransomUC3rd = _multiTransomUCP.GetMultiPanel();
                                    _multiMullionUC2nd.Getflp().Controls.Add((UserControl)_multiTransomUC3rd);
                                    _multiTransomUCP.SetInitialLoadFalse();
                                    _multiPanelModel3rdLvl.MPanel_Parent = _multiMullionUC2nd.Getflp();
                                    _multiPanelModel2ndLvl.AddControl_MPanelLstObjects((UserControl)_multiTransomUC3rd, _frameModel.Frame_Type.ToString());
                                    ////_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)_multiTransomUC, _frameModel.Frame_Type.ToString());

                                }
                                _multiPropUC3rdLvl = multiPropUCP;

                                if (_multiPanelModel3rdLvl.MPanel_Placement == "Last")
                                {
                                    _multiPanelModel2ndLvl.Fit_MyControls_ImagersToBindDimensions();
                                    _multiPanelModel2ndLvl.Fit_MyControls_ToBindDimensions();
                                    _multiPanelModel2ndLvl.Fit_EqualPanel_ToBindDimensions();
                                    //Run_GetListOfMaterials_SpecificItem();
                                }
                            }
                            #endregion


                            #region 4th level
                            else if (mpnllvl == "fourth level") //drawing of 3rd level multipanel objs
                            {
                                _multiPanelModel4thLvl = multipanelModel;
                                _multiPanelModel4thLvl.MPanel_WidthToBind = mPanel_WidthToBind;
                                _multiPanelModel4thLvl.MPanel_WidthToBindPrev = mPanel_WidthToBindPrev;
                                _multiPanelModel4thLvl.MPanelImager_WidthToBindPrev = mPanelImager_WidthToBindPrev;
                                _multiPanelModel4thLvl.MPanel_HeightToBind = mPanel_HeightToBind;
                                _multiPanelModel4thLvl.MPanel_HeightToBindPrev = mPanel_HeightToBindPrev;
                                _multiPanelModel4thLvl.MPanelImager_HeightToBindPrev = mPanelImager_HeightToBindPrev;
                                _multiPanelModel4thLvl.MPanel_Type = mPanel_Type;
                                _multiPanelModel4thLvl.MPanelImageRenderer_Height = mPanelImageRenderer_Height;
                                _multiPanelModel4thLvl.MPanelImageRenderer_Width = mPanelImageRenderer_Width;
                                _multiPanelModel4thLvl.MPanel_Margin = mPanel_Margin;
                                _multiPanelModel4thLvl.MPanelImageRenderer_Margin = mPanelImageRenderer_Margin;
                                _multiPanelModel4thLvl.MPanelProp_Height = 129;
                                _multiPanelModel4thLvl.MPanel_NumEnable = mPanel_NumEnable;
                                _multiPanelModel4thLvl.MPanel_Placement = mPanel_Placement;
                                _multiPanelModel4thLvl.MPanel_DividerEnabled = mPanel_DividerEnabled;
                                _multiPanelModel4thLvl.MPanel_OriginalDisplayWidth = mPanel_OriginalDisplayWidth;
                                _multiPanelModel4thLvl.MPanel_OriginalDisplayWidthDecimal = mPanel_OriginalDisplayWidthDecimal;
                                _multiPanelModel4thLvl.MPanel_OriginalDisplayHeight = mPanel_OriginalDisplayHeight;
                                _multiPanelModel4thLvl.MPanel_OriginalDisplayHeightDecimal = mPanel_OriginalDisplayHeightDecimal;
                                _multiPanelModel4thLvl.MPanel_OriginalGlassWidth = mPanel_OriginalGlassWidth;
                                _multiPanelModel4thLvl.MPanel_OriginalGlassWidthDecimal = mPanel_OriginalGlassWidthDecimal;
                                _multiPanelModel4thLvl.MPanel_OriginalGlassHeight = mPanel_OriginalGlassHeight;
                                _multiPanelModel4thLvl.MPanel_OriginalGlassHeightDecimal = mPanel_OriginalGlassHeightDecimal;
                                _multiPanelModel4thLvl.MPanel_CmenuDeleteVisibility = mPanel_CmenuDeleteVisibility;
                                _multiPanelModel4thLvl.MPanel_GlassBalanced = mPanel_GlassBalanced;
                                _multiPanelModel4thLvl.Set_DimensionToBind_using_FrameDimensions();
                                _frameModel.Lst_MultiPanel.Add(_multiPanelModel4thLvl);
                                _multiPanelModel3rdLvl.MPanelLst_MultiPanel.Add(_multiPanelModel4thLvl);
                                _multiPanelModel3rdLvl.Reload_MultiPanelMargin();
                                IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPanelPropertiesUCP.GetNewInstance(_unityC, _multiPanelModel4thLvl, this);
                                UserControl multiPropUC = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                                multiPropUC.Dock = DockStyle.Top;
                                _multiPropUC3rdLvl.GetMultiPanelPropertiesPNL().Controls.Add(multiPropUC);
                                _multiPanelModel3rdLvl.AdjustPropertyPanelHeight("Mpanel", "add");
                                _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");
                                multiPropUC.BringToFront();
                                if (mPanel_Type.Contains("Mullion"))
                                {
                                    IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP = _multiMullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel4thLvl,
                                                                                                                                      _frameModel,
                                                                                                                                      _multiTransomImagerUCP);
                                    IMultiPanelMullionImagerUC multiMullionImagerUC = multiMullionImagerUCP.GetMultiPanelImager();
                                    _multiTransomImagerUCP.AddControl((UserControl)multiMullionImagerUC);
                                    _multiPanelModel3rdLvl.MPanelLst_Imagers.Add((UserControl)multiMullionImagerUC);
                                    IMultiPanelMullionUCPresenter multiUCP = (MultiPanelMullionUCPresenter)_multiMullionUCP.GetNewInstance(_unityC,
                                                                                                                                           _userModel,
                                                                                                                                           _multiPanelModel4thLvl,
                                                                                                                                           _frameModel,
                                                                                                                                           this,
                                                                                                                                           _frameUCPresenter,
                                                                                                                                           _multiTransomUCP,
                                                                                                                                           multiPropUCP,
                                                                                                                                           _frameImagerUCP,
                                                                                                                                           _basePlatformImagerUCPresenter,
                                                                                                                                           multiMullionImagerUCP,
                                                                                                                                           _multiTransomImagerUCP);
                                    _multiMullionUCP = multiUCP;
                                    _multiMullionUC4th = _multiMullionUCP.GetMultiPanel();
                                    _multiTransomUC3rd.Getflp().Controls.Add((UserControl)_multiMullionUC4th);
                                    _multiMullionUCP.SetInitialLoadFalse();
                                    _multiPanelModel4thLvl.MPanel_Parent = _multiTransomUC3rd.Getflp();
                                    _multiPanelModel3rdLvl.AddControl_MPanelLstObjects((UserControl)_multiMullionUC4th, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)_multiMullionUC, _frameModel.Frame_Type.ToString());

                                }
                                else if (mPanel_Type.Contains("Transom"))
                                {
                                    IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                                      _multiPanelModel4thLvl,
                                                                                                                                      _frameModel,
                                                                                                                                      _multiMullionImagerUCP);
                                    IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                                    _multiMullionImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                                    _multiPanelModel3rdLvl.MPanelLst_Imagers.Add((UserControl)multiTransomImagerUC);
                                    IMultiPanelTransomUCPresenter multiTransomUCP = _multiTransomUCP.GetNewInstance(_unityC,
                                                                                                                    _userModel,
                                                                                                                    _multiPanelModel4thLvl,
                                                                                                                    _frameModel,
                                                                                                                    this,
                                                                                                                    _frameUCPresenter,
                                                                                                                    _multiMullionUCP,
                                                                                                                    multiPropUCP,
                                                                                                                    _frameImagerUCP,
                                                                                                                    _basePlatformImagerUCPresenter,
                                                                                                                    multiTransomImagerUCP,
                                                                                                                    _multiMullionImagerUCP);
                                    _multiTransomUCP = multiTransomUCP;
                                    _multiTransomUC4th = _multiTransomUCP.GetMultiPanel();
                                    _multiMullionUC3rd.Getflp().Controls.Add((UserControl)_multiTransomUC4th);
                                    _multiTransomUCP.SetInitialLoadFalse();
                                    _multiPanelModel4thLvl.MPanel_Parent = _multiMullionUC3rd.Getflp();
                                    _multiPanelModel3rdLvl.AddControl_MPanelLstObjects((UserControl)_multiTransomUC4th, _frameModel.Frame_Type.ToString());
                                    ////_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)_multiTransomUC, _frameModel.Frame_Type.ToString());

                                }
                                _multiPropUC4thLvl = multiPropUCP;
                                if (_multiPanelModel4thLvl.MPanel_Placement == "Last")
                                {
                                    _multiPanelModel3rdLvl.Fit_MyControls_ImagersToBindDimensions();
                                    _multiPanelModel3rdLvl.Fit_MyControls_ToBindDimensions();
                                    _multiPanelModel3rdLvl.Fit_EqualPanel_ToBindDimensions();
                                    //Run_GetListOfMaterials_SpecificItem();
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
                            if (mpnllvl == "fourth level")
                            {
                                if (extractedValue_str.Contains("Mullion"))
                                {
                                    div_Parent = _multiMullionUC4th.Getflp();

                                }
                                else
                                {
                                    div_Parent = _multiTransomUC4th.Getflp();
                                }
                            }
                            else if (mpnllvl == "third level")
                            {
                                if (extractedValue_str.Contains("Mullion"))
                                {
                                    div_Parent = _multiMullionUC3rd.Getflp();

                                }
                                else
                                {
                                    div_Parent = _multiTransomUC3rd.Getflp();
                                }
                            }



                            //else if (mpnllvl == "third level")
                            //{
                            //    if (extractedValue_str.Contains("Mullion"))
                            //    {
                            //        div_Parent = _multiMullionUC3rd.Getflp();

                            //    }
                            //    else
                            //    {
                            //        div_Parent = _multiTransomUC3rd.Getflp();
                            //    }
                            //    mpnllvl = "third level";
                            //}

                            else
                            {
                                if (extractedValue_str.Contains("Mullion"))
                                {
                                    div_Parent = _multiMullionUC2nd.Getflp();

                                }
                                else
                                {
                                    div_Parent = _multiTransomUC2nd.Getflp();
                                }
                            }

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
                            if (_multiPanelModel2ndLvl != null)
                            {
                                if (_multiPanelModel3rdLvl != null)
                                {
                                    if (_multiPanelModel4thLvl != null)
                                    {
                                        div_MPanelParent = _multiPanelModel4thLvl;

                                    }
                                    else
                                    {
                                        div_MPanelParent = _multiPanelModel3rdLvl;
                                    }
                                }
                                else
                                {
                                    div_MPanelParent = _multiPanelModel2ndLvl;
                                }

                            }


                        }
                        else if (row_str.Contains("Div_FrameParent:"))
                        {
                            div_FrameParent = _frameModel;
                        }
                        else if (row_str.Contains("Div_DMPanel:"))
                        {
                            div_DMPanelName = extractedValue_str;

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
                            div_CladdingSizeList = new Dictionary<int, int>();

                            string[] words = extractedValue_str.Split(';');
                            if (extractedValue_str.Contains("<"))
                            {
                                foreach (string str in words)
                                {
                                    if (str.Trim() != string.Empty)
                                    {
                                        int key = Convert.ToInt32(str.Split('<', ',')[1]);
                                        int value = Convert.ToInt32(str.Split(',', '>')[1]);
                                        div_CladdingSizeList.Add(key, value);
                                    }

                                }
                            }

                            //div_CladdingSizeList.Reverse();
                        }
                        else if (row_str.Contains("Div_CladdingCount:"))
                        {
                            //div_CladdingCount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
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
                            int divSize = (int)_frameModel.Frame_Type;
                            int divHeigth = 0,
                                divWidth = 0;
                            if (_multiPanelModel2ndLvl.MPanel_Type == "Mullion")
                            {
                                //fpnl = _multiMullionUC2nd.Getflp();
                                divWidth = divSize;
                                divHeigth = _multiPanelModel2ndLvl.MPanel_Height;
                            }
                            else
                            {
                                //fpnl = _multiTransomUC2nd.Getflp();
                                divWidth = _multiPanelModel2ndLvl.MPanel_Width;
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
                            //divModel.Div_CladdingCount = div_CladdingCount;
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
                            //divModel.SetDimensionsToBind_using_DivZoom();
                            //divModel.SetDimensionsToBind_using_DivZoom_Imager_Initial();
                            _prev_divModel = divModel;
                            _frameModel.Lst_Divider.Add(divModel);
                            _divModel_forDMSelection = _prev_divModel;
                            _divPropUCP_forDMSelection = _divPropertiesUCP.GetNewInstance(_unityC, divModel, this);
                            _controlRaised_forDMSelection = _divPropUCP_forDMSelection.GetDivProperties().GetBtnSelectDMPanel();
                            UserControl divPropUC = (UserControl)_divPropUCP_forDMSelection.GetDivProperties();
                            divPropUC.Dock = DockStyle.Top;
                            if (div_Parent.Parent.Parent.Name.Contains("Frame"))
                            {
                                _multiPanelModel2ndLvl.MPanelLst_Divider.Add(divModel);
                                if (_multiPanelModel2ndLvl.MPanel_Type == "Mullion")
                                {
                                    _multiPropUC2ndLvl.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();
                                    IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel2ndLvl,
                                                                                                _multiMullionUCP,
                                                                                                _frameModel,
                                                                                                this);
                                    IMullionUC mullionUC = mullionUCP.GetMullion();
                                    _multiMullionUC2nd.Getflp().Controls.Add((UserControl)mullionUC);
                                    mullionUCP.SetInitialLoadFalse();
                                    _multiPanelModel2ndLvl.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());



                                    IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                 divModel,
                                                                                                                 _multiPanelModel2ndLvl,
                                                                                                                 _frameModel,
                                                                                                                 _multiMullionImagerUCP,
                                                                                                                 mullionUC);
                                    IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                                    _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                                    _multiPanelModel2ndLvl.MPanelLst_Imagers.Add((UserControl)mullionImagerUC);

                                }
                                else
                                {
                                    _multiPropUC2ndLvl.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();
                                    ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel2ndLvl,
                                                                                                _multiTransomUCP,
                                                                                                _frameModel,
                                                                                                this);
                                    ITransomUC transomUC = transomUCP.GetTransom();
                                    _multiTransomUC2nd.Getflp().Controls.Add((UserControl)transomUC);
                                    transomUCP.SetInitialLoadFalse();
                                    _multiPanelModel2ndLvl.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());

                                    ITransomImagerUCPresenter transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                                                                     divModel,
                                                                                                                     _multiPanelModel2ndLvl,
                                                                                                                     _frameModel,
                                                                                                                     _multiTransomImagerUCP,
                                                                                                                     transomUC);
                                    ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                                    _multiTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                                    _multiPanelModel2ndLvl.MPanelLst_Imagers.Add((UserControl)transomImagerUC);
                                }
                                _multiPanelModel2ndLvl.AdjustPropertyPanelHeight("Div", "add");
                                _frameModel.AdjustPropertyPanelHeight("Div", "add");

                            }
                            else if (div_Parent.Parent.Parent.Parent.Parent.Name.Contains("Frame"))
                            {
                                _multiPanelModel3rdLvl.MPanelLst_Divider.Add(divModel);
                                if (_multiPanelModel3rdLvl.MPanel_Type == "Mullion")
                                {
                                    _multiPropUC3rdLvl.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();
                                    IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel3rdLvl,
                                                                                                _multiMullionUCP,
                                                                                                _frameModel,
                                                                                                this);
                                    IMullionUC mullionUC = mullionUCP.GetMullion();
                                    _multiMullionUC3rd.Getflp().Controls.Add((UserControl)mullionUC);
                                    mullionUCP.SetInitialLoadFalse();
                                    _multiPanelModel3rdLvl.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());

                                    IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                  divModel,
                                                                                                                  _multiPanelModel3rdLvl,
                                                                                                                  _frameModel,
                                                                                                                  _multiMullionImagerUCP,
                                                                                                                  mullionUC);
                                    IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                                    _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                                    _multiPanelModel3rdLvl.MPanelLst_Imagers.Add((UserControl)mullionImagerUC);
                                }
                                else
                                {
                                    _multiPropUC3rdLvl.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();
                                    ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel3rdLvl,
                                                                                                _multiTransomUCP,
                                                                                                _frameModel,
                                                                                                this);
                                    ITransomUC transomUC = transomUCP.GetTransom();
                                    _multiTransomUC3rd.Getflp().Controls.Add((UserControl)transomUC);
                                    transomUCP.SetInitialLoadFalse();
                                    _multiPanelModel3rdLvl.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());

                                    ITransomImagerUCPresenter transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                                                                   divModel,
                                                                                                                   _multiPanelModel3rdLvl,
                                                                                                                   _frameModel,
                                                                                                                   _multiTransomImagerUCP,
                                                                                                                   transomUC);
                                    ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                                    _multiTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                                    _multiPanelModel3rdLvl.MPanelLst_Imagers.Add((UserControl)transomImagerUC);

                                }
                                _multiPanelModel3rdLvl.AdjustPropertyPanelHeight("Div", "add");
                                _frameModel.AdjustPropertyPanelHeight("Div", "add");
                            }
                            else
                            {
                                _multiPanelModel4thLvl.MPanelLst_Divider.Add(divModel);
                                if (_multiPanelModel4thLvl.MPanel_Type == "Mullion")
                                {
                                    _multiPropUC4thLvl.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();
                                    IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel4thLvl,
                                                                                                _multiMullionUCP,
                                                                                                _frameModel,
                                                                                                this);
                                    IMullionUC mullionUC = mullionUCP.GetMullion();
                                    _multiMullionUC4th.Getflp().Controls.Add((UserControl)mullionUC);
                                    mullionUCP.SetInitialLoadFalse();
                                    _multiPanelModel4thLvl.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());

                                    IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                  divModel,
                                                                                                                  _multiPanelModel4thLvl,
                                                                                                                  _frameModel,
                                                                                                                  _multiMullionImagerUCP,
                                                                                                                  mullionUC);
                                    IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                                    _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                                    _multiPanelModel4thLvl.MPanelLst_Imagers.Add((UserControl)mullionImagerUC);
                                }
                                else
                                {
                                    _multiPropUC4thLvl.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();
                                    ITransomUCPresenter transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel4thLvl,
                                                                                                _multiTransomUCP,
                                                                                                _frameModel,
                                                                                                this);
                                    ITransomUC transomUC = transomUCP.GetTransom();
                                    _multiTransomUC4th.Getflp().Controls.Add((UserControl)transomUC);
                                    transomUCP.SetInitialLoadFalse();
                                    _multiPanelModel4thLvl.AddControl_MPanelLstObjects((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                                    //_multiPanelModel2ndLvl.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());

                                    ITransomImagerUCPresenter transomImagerUCP = _transomImagerUCP.GetNewInstance(_unityC,
                                                                                                                  divModel,
                                                                                                                  _multiPanelModel4thLvl,
                                                                                                                  _frameModel,
                                                                                                                  _multiTransomImagerUCP,
                                                                                                                  transomUC);
                                    ITransomImagerUC transomImagerUC = transomImagerUCP.GetTransomImager();
                                    _multiTransomImagerUCP.AddControl((UserControl)transomImagerUC);
                                    _multiPanelModel4thLvl.MPanelLst_Imagers.Add((UserControl)transomImagerUC);
                                }
                                _multiPanelModel4thLvl.AdjustPropertyPanelHeight("Div", "add");
                                _frameModel.AdjustPropertyPanelHeight("Div", "add");
                            }
                            inside_divider = false;
                        }
                        #endregion
                    }
                    else if (inside_screen)
                    {
                        #region Load for Screen


                        if (row_str.Contains("Screen_id:"))
                        {
                            screen_id = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Types_Window:"))
                        {
                            screen_Types_Window = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Types_Door:"))
                        {
                            screen_Types_Door = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Width:"))
                        {
                            screen_Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Height:"))
                        {
                            screen_Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Factor:"))
                        {
                            screen_Factor = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Types:"))
                        {
                            foreach (ScreenType scrnType in ScreenType.GetAll())
                            {
                                if (scrnType.ToString() == extractedValue_str)
                                {
                                    screen_Types = scrnType;
                                }
                            }
                        }
                        else if (row_str.Contains("Screen_PlisséType:"))
                        {
                            foreach (PlisseType plssTyp in PlisseType.GetAll())
                            {
                                if (plssTyp.ToString() == extractedValue_str)
                                {
                                    screen_PlisséType = plssTyp;
                                }
                            }
                        }
                        else if (row_str.Contains("Screen_BaseColor:"))
                        {
                            foreach (Base_Color BsClr in Base_Color.GetAll())
                            {
                                if (BsClr.ToString() == extractedValue_str)
                                {
                                    screen_BaseColor = BsClr;
                                }
                            }

                        }
                        else if (row_str.Contains("Screen_Set:"))
                        {
                            screen_Set = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_WindoorID:"))
                        {
                            screen_WindoorID = extractedValue_str;
                        }
                        else if (row_str.Contains("Screen_UnitPrice:"))
                        {
                            screen_UnitPrice = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Quantity:"))
                        {
                            screen_Quantity = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_TotalAmount:"))
                        {
                            screen_TotalAmount = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_NetPrice:"))
                        {
                            screen_NetPrice = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_Discount:"))
                        {
                            screen_Discount = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_DiscountedPrice:"))
                        {
                            screen_DiscountedPrice = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_DiscountedPriceWithoutVat:"))
                        {
                            screen_DiscountedPriceWithoutVat = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_LaborAndMobilization:"))
                        {
                            screen_LaborAndMobilization = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_TotalNetPriceWithoutVat:"))
                        {
                            screen_TotalNetPriceWithoutVat = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_PVCVisibility:"))
                        {
                            screen_PVCVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("SpringLoad_Checked:"))
                        {
                            springLoad_Checked = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("SpringLoad_Visibility:"))
                        {
                            springLoad_Visibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_0505Width:"))
                        {
                            screen_0505Width = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_1067Height:"))
                        {
                            screen_1067Height = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_0505Qty:"))
                        {
                            screen_0505Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_1067Qty:"))
                        {
                            screen_1067Qty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_CenterClosureVisibility:"))
                        {
                            screen_CenterClosureVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_CenterClosureVisibilityOption:"))
                        {
                            screen_CenterClosureVisibilityOption = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_LatchKitQty:"))
                        {
                            screen_LatchKitQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_IntermediatePartQty:"))
                        {
                            screen_IntermediatePartQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_6040MilledProfileVisibility:"))
                        {
                            screen_6040MilledProfileVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_6040MilledProfile:"))
                        {
                            screen_6040MilledProfile = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_6040MilledProfileQty:"))
                        {
                            screen_6040MilledProfileQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_LandCoverVisibility:"))
                        {
                            screen_LandCoverVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_LandCover:"))
                        {
                            screen_LandCover = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_LandCoverQty:"))
                        {
                            screen_LandCoverQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_1067PVCboxVisibility:"))
                        {
                            screen_1067PVCboxVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_1067PVCbox:"))
                        {
                            screen_1067PVCbox = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_1067PVCboxQty:"))
                        {
                            screen_1067PVCboxQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_1385MilledProfileVisibility:"))
                        {
                            screen_1385MilledProfileVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_1385MilledProfile:"))
                        {
                            screen_1385MilledProfile = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_1385MilledProfileQty:"))
                        {
                            screen_1385MilledProfileQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_373or374MilledProfileVisibility:"))
                        {
                            screen_373or374MilledProfileVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_373or374MilledProfile:"))
                        {
                            screen_373or374MilledProfile = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_373or374MilledProfileQty:"))
                        {
                            screen_373or374MilledProfileQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_6052MilledProfileVisibility:"))
                        {
                            screen_6052MilledProfileVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_6052MilledProfile:"))
                        {
                            screen_6052MilledProfile = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_6052MilledProfileQty:"))
                        {
                            screen_6052MilledProfileQty = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_ExchangeRateVisibility:"))
                        {
                            screen_ExchangeRateVisibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_ExchangeRate:"))
                        {
                            screen_ExchangeRate = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Magnum_ScreenType:"))
                        {
                            foreach (Magnum_ScreenType mgnmScrnTyp in Magnum_ScreenType.GetAll())
                            {
                                if (mgnmScrnTyp.ToString() == extractedValue_str)
                                {
                                    magnum_ScreenType = mgnmScrnTyp;

                                }
                            }
                        }
                        else if (row_str.Contains("Reinforced:"))
                        {
                            reinforced = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("SP_MagnumScreenType_Visibility:"))
                        {
                            sp_MagnumScreenType_Visibility = Convert.ToBoolean(extractedValue_str);
                        }
                        else if (row_str.Contains("PlissedRd_Panels:"))
                        {
                            plissedRd_Panels = Convert.ToInt32(string.IsNullOrWhiteSpace(extractedValue_str) == true ? "0" : extractedValue_str);

                        }
                        else if (row_str.Contains("Screen_Description:"))
                        {
                            screen_description = extractedValue_str;
                        }
                        else if (row_str.Contains("DiscountPercentage:"))
                        {
                            discountPercentage = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_ItemNumber:"))
                        {
                            screen_ItemNumber = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Screen_NextItemNumber:"))
                        {
                            screen_NextItemNumber = decimal.Parse(extractedValue_str);
                        }
                        else if (row_str.Contains("Freedom_ScreenSize:"))
                        {
                            foreach (Freedom_ScreenSize frdmsize in Freedom_ScreenSize.GetAll())
                            {
                                if (frdmsize.ToString() == extractedValue_str)
                                {
                                    freedom_ScreenSize = frdmsize;

                                }
                            }
                        }
                        else if (row_str.Contains("Freedom_ScreenType:"))
                        {
                            foreach (Freedom_ScreenType frdmtype in Freedom_ScreenType.GetAll())
                            {
                                if (frdmtype.ToString() == extractedValue_str)
                                {
                                    freedom_ScreenType = frdmtype;
                                }
                            }
                        }

                        #endregion
                    }
                    else if (inside_rdlcDic)
                    {
                        #region Load for RLDC Headers
                        if (row_str != ".")
                        {
                            string[] key = row_str.Split(':');
                            var value = row_str.Substring(row_str.IndexOf(": ") + 1 );

                            if (rdlcDicChangeKey == true)
                            {
                                RDLCDictionary_key = key[0];
                            }
                            if(value == "" || value == " ")
                            {
                                value = "\n" + "\n";
                            }
                            else if(value == " To: ")
                            {
                                value = value + "\n";
                                rdlcAddNewLineToAddr = true;
                            }
                            else if (rdlcAddNewLineToAddr == true)
                            {
                                value = value + "\n";
                                rdlcAddNewLineToAddr = false;
                            }
                            else if(RDLCDictionary_key.Contains("QuotationBody") && value.ToLower().Contains("using"))
                            {
                                value = value + "\n";
                            }                                               
                            RDLCDictionary_value = RDLCDictionary_value + value;
                            rdlcDicChangeKey = false;
                        }
                        #endregion
                    }
                    break;
            }

        }

        private void Load_RDLCHeaders()
        {
            if (add_existing == false)
            {
              _rdlcHeaders.Add(RDLCDictionary_key, RDLCDictionary_value.TrimStart());
                Console.WriteLine("KEY  :" + RDLCDictionary_key + "VALUE :"  +  RDLCDictionary_value.TrimStart());
            }

            if (RDLCDictionary_key != null && RDLCDictionary_value != null)
            {
                // Console.WriteLine("not null insert to dictionary");
                rdlcDicChangeKey = true;
                RDLCDictionary_key = "";
                RDLCDictionary_value = "";
            }
        }
        private void Load_Screen()
        {
            IScreenModel scr = _screenServices.AddScreenModel(screen_ItemNumber,
                                                             screen_Width,
                                                             screen_Height,
                                                             screen_Types,
                                                             screen_WindoorID,
                                                             screen_UnitPrice,
                                                             screen_Quantity,
                                                             screen_Set,
                                                             screen_Discount,
                                                             screen_NetPrice,
                                                             screen_TotalAmount,
                                                             screen_description,
                                                             screen_Factor,
                                                             screen_AddOnsSpecialFactor);

            scr.Screen_id = screen_id;
            scr.Screen_Types_Window = screen_Types_Window;
            scr.Screen_Types_Door = screen_Types_Door;
            scr.Screen_Width = screen_Width;
            scr.Screen_Height = screen_Height;
            scr.Screen_Factor = screen_Factor;
            scr.Screen_AddOnsSpecialFactor = screen_AddOnsSpecialFactor;
            scr.Screen_Types = screen_Types;
            scr.Screen_PlisséType = screen_PlisséType;
            scr.Screen_BaseColor = screen_BaseColor;
            scr.Screen_Set = screen_Set;
            scr.Screen_WindoorID = screen_WindoorID;
            scr.Screen_UnitPrice = screen_UnitPrice;
            scr.Screen_Quantity = screen_Quantity;
            scr.Screen_TotalAmount = screen_TotalAmount;
            scr.Screen_NetPrice = screen_NetPrice;
            scr.Screen_Discount = screen_Discount;
            scr.Screen_DiscountedPrice = screen_DiscountedPrice;
            scr.Screen_DiscountedPriceWithoutVat = screen_DiscountedPriceWithoutVat;
            scr.Screen_LaborAndMobilization = screen_LaborAndMobilization;
            scr.Screen_TotalNetPriceWithoutVat = screen_TotalNetPriceWithoutVat;
            scr.Screen_PVCVisibility = screen_PVCVisibility;
            scr.SpringLoad_Checked = springLoad_Checked;
            scr.SpringLoad_Visibility = springLoad_Visibility;
            scr.Screen_0505Width = screen_0505Width;
            scr.Screen_1067Height = screen_1067Height;
            scr.Screen_0505Qty = screen_0505Qty;
            scr.Screen_1067Qty = screen_1067Qty;
            scr.Screen_CenterClosureVisibility = screen_CenterClosureVisibility;
            scr.Screen_CenterClosureVisibilityOption = screen_CenterClosureVisibilityOption;
            scr.Screen_LatchKitQty = screen_LatchKitQty;
            scr.Screen_IntermediatePartQty = screen_IntermediatePartQty;
            scr.Screen_6040MilledProfileVisibility = screen_6040MilledProfileVisibility;
            scr.Screen_6040MilledProfile = screen_6040MilledProfile;
            scr.Screen_6040MilledProfileQty = screen_6040MilledProfileQty;
            scr.Screen_LandCoverVisibility = screen_LandCoverVisibility;
            scr.Screen_LandCover = screen_LandCover;
            scr.Screen_LandCoverQty = screen_LandCoverQty;
            //scr.Screen_1067PVCboxVisibility = screen_1067PVCboxVisibility;
            //scr.Screen_1067PVCbox = screen_1067PVCbox;
            //scr.Screen_1067PVCboxQty = screen_1067PVCboxQty;
            scr.Screen_1385MilledProfileVisibility = screen_1385MilledProfileVisibility;
            scr.Screen_1385MilledProfile = screen_1385MilledProfile;
            scr.Screen_1385MilledProfileQty = screen_1385MilledProfileQty;
            scr.Screen_373or374MilledProfileVisibility = screen_373or374MilledProfileVisibility;
            scr.Screen_373or374MilledProfile = screen_373or374MilledProfile;
            scr.Screen_373or374MilledProfileQty = screen_373or374MilledProfileQty;
            scr.Screen_6052MilledProfileVisibility = screen_6052MilledProfileVisibility;
            scr.Screen_6052MilledProfile = screen_6052MilledProfile;
            scr.Screen_6052MilledProfileQty = screen_6052MilledProfileQty;
            scr.Screen_ExchangeRateVisibility = screen_ExchangeRateVisibility;
            scr.Screen_ExchangeRate = screen_ExchangeRate;
            scr.Magnum_ScreenType = magnum_ScreenType;
            scr.Reinforced = reinforced;
            scr.SP_MagnumScreenType_Visibility = sp_MagnumScreenType_Visibility;
            scr.PlissedRd_Panels = plissedRd_Panels;
            scr.Screen_Description = screen_description;
            scr.DiscountPercentage = discountPercentage;
            scr.Screen_ItemNumber = screen_ItemNumber;
            scr.Screen_NextItemNumber = screen_NextItemNumber;
            scr.Freedom_ScreenSize = freedom_ScreenSize;
            scr.Freedom_ScreenType = freedom_ScreenType;

            this.Screen_List.Add(scr);
        }
        private void Frame_Load()
        {
            Scenario_Quotation(false,
                                 false,
                                 false,
                                 false,
                                 true,
                                 false,
                                 frmDimensionPresenter.Show_Purpose.CreateNew_Frame,
                                 frm_Width,
                                 frm_Height,
                                 frmDimension_profileType,
                                 frmDimension_baseColor);
            inside_frame = false;

        }
        private void Panel_Load()
        {
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
                                                                               panel_SlidingTypes
                                                                               );
            pnlModel.Panel_fileLoad = true;
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
            pnlModel.Panel_GlassPricePerSqrMeter = panel_GlassPricePerSqrMeter;
            //pnlModel.Panel_PropertyHeight = panel_PropertyHeight;
            //pnlModel.Panel_HandleOptionsHeight = panel_HandleOptionsHeight;
            pnlModel.Panel_LouverBladesCount = panel_LouverBladesCount;
            //pnlModel.Panel_Orient = panel_Orient;
            pnlModel.Panel_OrientVisibility = panel_OrientVisibility;
            pnlModel.Panel_HandleOptionsVisibility = panel_HandleOptionsVisibility;
            pnlModel.Panel_RotoswingOptionsVisibility = panel_RotoswingOptionsVisibility;
            pnlModel.Panel_RioOptionsVisibility = panel_RioOptionsVisibility;
            pnlModel.Panel_RioOptionsVisibility2 = panel_RioOptionsVisibility2;
            pnlModel.Panel_RotolineOptionsVisibility = panel_RotolineOptionsVisibility;
            pnlModel.Panel_MVDOptionsVisibility = panel_MVDOptionsVisibility;
            pnlModel.Panel_RotaryOptionsVisibility = panel_RotaryOptionsVisibility;
            pnlModel.Panel_GlassType_Insu_Lami = panel_GlassType_Insu_Lami;
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
            pnlModel.Panel_OverLappingPanelQty = panel_OverLappingPanelQty;
            pnlModel.Panel_AluminumPullHandleArtNo = panel_AluminumPullHandleArticleNo;




            #region louvre 


            pnlModel.Panel_PlantOnWeatherStripHeadWidth = panel_PlantOnWeatherStripHeadWidth;
            pnlModel.Panel_PlantOnWeatherStripSealWidth = panel_PlantOnWeatherStripSealWidth;
            pnlModel.Panel_LouverFrameWeatherStripHeadWidth = panel_LouverFrameWeatherStripHeadWidth;
            pnlModel.Panel_LouverFrameBottomWeatherStripWidth = panel_LouverFrameBottomWeatherStripWidth;
            pnlModel.Panel_SealForHandleQty = panel_SealForHandleQty;
            pnlModel.Panel_LouvreGallerySetHeight = panel_LouvreGallerySetHeight;
            pnlModel.Panel_LouverNumberBladesPerSet = panel_LouverNumberBladesPerSet;
            pnlModel.Panel_LouverGalleryVisibility = panel_LouverGalleryVisibility;
            pnlModel.Panel_LouverGallerySetVisibility = panel_LouverGallerySetVisibility;
            pnlModel.Panel_GlassPnlGlazingBeadVisibility = panel_GlassPnlGlazingBeadVisibility;
            pnlModel.Panel_GlassPnlGlazingAdaptorVisibility = panel_GlassPnlGlazingAdaptorVisibility;
            pnlModel.Panel_LouverBladeTypeOption = panel_LouverBladeTypeOption;

            pnlModel.Panel_LouverBladeHeight = panel_LouverBladeHeight;
            pnlModel.Panel_LouverHandleType = panel_LouverHandleType;
            pnlModel.Panel_LouverHandleLocation = panel_LouverHandleLocation;
            pnlModel.Panel_LouverGalleryColor = panel_LouverGalleryColor;

            pnlModel.Panel_AluminumPullHandleArtNo = panel_AluminumPullHandleArtNo;
            pnlModel.Panel_PlantOnWeatherStripHeadArtNo = panel_PlantOnWeatherStripHeadArtNo;
            pnlModel.Panel_PlantOnWeatherStripSealArtNo = panel_PlantOnWeatherStripSealArtNo;
            pnlModel.Panel_LouverFrameWeatherStripHeadArtNo = panel_LouverFrameWeatherStripHeadArtNo;
            pnlModel.Panel_LouverFrameBottomWeatherStripArtNo = panel_LouverFrameBottomWeatherStripArtNo;
            pnlModel.Panel_RubberSealArtNo = panel_RubberSealArtNo;
            pnlModel.Panel_CasementSealArtNo = panel_CasementSealArtNo;
            pnlModel.Panel_SealForHandleArtNo = panel_SealForHandleArtNo;
            pnlModel.Panel_BubbleSealArtNo = panel_BubbleSealArtNo;
            pnlModel.Panel_LstSealForHandleMultiplier = panel_LstSealForHandleMultiplier;
            pnlModel.Panel_LstLouverArtNo = panel_LstLouverArtNo;
            pnlModel.Panel_LouverGallerySetCount = panel_LouverGallerySetCount;
            pnlModel.Panel_LouverGallerySetOptionArtNo = panel_LouverGallerySetOptionArtNo;
            pnlModel.Panel_LouverGallerySetOptionVisibility = panel_LouverGallerySetOptionVisibility;
            pnlModel.Panel_CasementSealWidth = panel_CasementSealWidth;
            pnlModel.Panel_RubberSealWidth = panel_RubberSealWidth;
            #endregion





            #endregion
            IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, pnlModel, this);
            UserControl panelPropUC = (UserControl)panelPropUCP.GetPanelPropertiesUC();
            panelPropUC.Dock = DockStyle.Top;

            if (panel_Parent.Parent.Name.Contains("frame"))
            {

                _frameModel.Lst_Panel.Add(pnlModel);
                pnlModel.Imager_SetDimensionsToBind_FrameParent();
                _framePropertiesUCPresenter.GetFramePropertiesUC().GetFramePropertiesPNL().Controls.Add(panelPropUC);
            }
            else
            {
                if (panel_Parent.Parent.Parent.Name.Contains("Frame"))
                {
                    _multiModelParent = _multiPanelModel2ndLvl;
                    _multiPropUC2ndLvl.GetMultiPanelPropertiesPNL().Controls.Add(panelPropUC);

                }
                else if (panel_Parent.Parent.Parent.Parent.Parent.Name.Contains("Frame"))
                {
                    _multiModelParent = _multiPanelModel3rdLvl;
                    _multiPropUC3rdLvl.GetMultiPanelPropertiesPNL().Controls.Add(panelPropUC);

                }
                else
                {
                    _multiModelParent = _multiPanelModel4thLvl;
                    _multiPropUC4thLvl.GetMultiPanelPropertiesPNL().Controls.Add(panelPropUC);

                }
                pnlModel.Panel_ParentMultiPanelModel = _multiModelParent;
                _multiModelParent.MPanelLst_Panel.Add(pnlModel);
                _multiModelParent.Reload_PanelMargin();
                pnlModel.SetPanelMargin_using_ZoomPercentage();
                pnlModel.SetPanelMarginImager_using_ImageZoomPercentage();
                panelPropUC.BringToFront();


            }

            IMultiPanelMullionUC multiMullionUC;
            IMultiPanelTransomUC multiTransomUC;

            if (mpnllvl == "second level")
            {
                multiMullionUC = _multiMullionUC2nd;
                multiTransomUC = _multiTransomUC2nd;
            }
            else if (mpnllvl == "third level")
            {
                multiMullionUC = _multiMullionUC3rd;
                multiTransomUC = _multiTransomUC3rd;
            }
            else
            {
                multiMullionUC = _multiMullionUC4th;
                multiTransomUC = _multiTransomUC4th;
            }

            if (panel_Type.Contains("Fixed Panel"))
            {
                IFixedPanelUCPresenter fixedUCP;
                if (panel_Parent.Parent.Name.Contains("frame"))
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    pnlModel.AdjustPropertyPanelHeight("addGlass");

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


                    if (panel_Parent.Name.Contains("MultiMullion"))
                    {
                        fixedUCP = (FixedPanelUCPresenter)_fixedUCP.GetNewInstance(_unityC,
                                                                      pnlModel,
                                                                      _frameModel,
                                                                      this,
                                                                      _multiModelParent,
                                                                      _multiMullionUCP,
                                                                      _multiMullionImagerUCP);
                        IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                        multiMullionUC.Getflp().Controls.Add((UserControl)fixedUC);

                        fixedUCP.SetInitialLoadFalse();
                        _multiModelParent.AddControl_MPanelLstObjects((UserControl)fixedUC, _frameModel.Frame_Type.ToString());


                        //_multiMullionUCP.GetflpMullion().Controls.Add((UserControl)fixedUC);
                        //_multiModelParent.MPanelLst_Objects.Add((UserControl)fixedUC);
                    }
                    else
                    {
                        fixedUCP = (FixedPanelUCPresenter)_fixedUCP.GetNewInstance(_unityC,
                                                                       pnlModel,
                                                                       _frameModel,
                                                                       this,
                                                                       _multiModelParent,
                                                                       _multiTransomUCP,
                                                                       _multiTransomImagerUCP);
                        IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                        multiTransomUC.Getflp().Controls.Add((UserControl)fixedUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)fixedUC);
                        fixedUCP.SetInitialLoadFalse();
                    }

                }
            }
            else if (panel_Type.Contains("Casement Panel"))
            {
                ICasementPanelUCPresenter casementUCP;
                if (panel_Parent.Parent.Name.Contains("frame"))
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                    pnlModel.AdjustPropertyPanelHeight("addChkMotorized");
                    pnlModel.AdjustPropertyPanelHeight("addSash");
                    pnlModel.AdjustPropertyPanelHeight("addGlass");
                    pnlModel.AdjustPropertyPanelHeight("addHandle");
                    pnlModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");
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
                    if (panel_Parent.Name.Contains("MultiMullion"))
                    {
                        casementUCP = (CasementPanelUCPresenter)_casementUCP.GetNewInstance(_unityC,
                                                                      pnlModel,
                                                                      _frameModel,
                                                                      this,
                                                                      _multiModelParent,
                                                                      _multiMullionUCP,
                                                                      _multiMullionImagerUCP);
                        ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                        multiMullionUC.Getflp().Controls.Add((UserControl)casementUC);

                        //_multiMullionUCP.GetflpMullion().Controls.Add((UserControl)casementUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)casementUC);
                        casementUCP.SetInitialLoadFalse();
                    }
                    else
                    {
                        casementUCP = (CasementPanelUCPresenter)_casementUCP.GetNewInstance(_unityC,
                                                                       pnlModel,
                                                                       _frameModel,
                                                                       this,
                                                                       _multiModelParent,
                                                                       _multiTransomUCP,
                                                                       _multiTransomImagerUCP);
                        ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                        multiTransomUC.Getflp().Controls.Add((UserControl)casementUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)casementUC);
                        casementUCP.SetInitialLoadFalse();
                    }

                }
            }
            else if (panel_Type.Contains("Awning Panel"))
            {
                IAwningPanelUCPresenter awningUCP;
                if (panel_Parent.Parent.Name.Contains("frame"))
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                    pnlModel.AdjustPropertyPanelHeight("addChkMotorized");
                    pnlModel.AdjustPropertyPanelHeight("addSash");
                    pnlModel.AdjustPropertyPanelHeight("addGlass");
                    pnlModel.AdjustPropertyPanelHeight("addHandle");

                    pnlModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");
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
                    if (panel_Parent.Name.Contains("MultiMullion"))
                    {
                        awningUCP = (AwningPanelUCPresenter)_awningUCP.GetNewInstance(_unityC,
                                                                      pnlModel,
                                                                      _frameModel,
                                                                      this,
                                                                      _multiModelParent,
                                                                      _multiMullionUCP,
                                                                      _multiMullionImagerUCP);
                        IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                        multiMullionUC.Getflp().Controls.Add((UserControl)awningUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)awningUC);
                        awningUCP.SetInitialLoadFalse();
                    }
                    else
                    {
                        awningUCP = (AwningPanelUCPresenter)_awningUCP.GetNewInstance(_unityC,
                                                                       pnlModel,
                                                                       _frameModel,
                                                                       this,
                                                                       _multiModelParent,
                                                                       _multiTransomUCP,
                                                                       _multiTransomImagerUCP);
                        IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                        multiTransomUC.Getflp().Controls.Add((UserControl)awningUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)awningUC);
                        awningUCP.SetInitialLoadFalse();
                    }

                }

            }
            else if (panel_Type.Contains("Sliding Panel"))
            {
                ISlidingPanelUCPresenter slidingUCP;
                if (panel_Parent.Parent.Name.Contains("frame"))
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                    pnlModel.AdjustPropertyPanelHeight("addChkMotorized");
                    pnlModel.AdjustPropertyPanelHeight("addSash");
                    pnlModel.AdjustPropertyPanelHeight("addGlass");
                    pnlModel.AdjustPropertyPanelHeight("addHandle");

                    pnlModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");
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
                    if (panel_Parent.Name.Contains("MultiMullion"))
                    {
                        slidingUCP = (SlidingPanelUCPresenter)_slidingUCP.GetNewInstance(_unityC,
                                                                      pnlModel,
                                                                      _frameModel,
                                                                      this,
                                                                      _multiModelParent,
                                                                      _multiMullionUCP,
                                                                      _multiMullionImagerUCP);
                        ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                        multiMullionUC.Getflp().Controls.Add((UserControl)slidingUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)slidingUC);
                        slidingUCP.SetInitialLoadFalse();
                    }
                    else
                    {
                        slidingUCP = (SlidingPanelUCPresenter)_slidingUCP.GetNewInstance(_unityC,
                                                                       pnlModel,
                                                                       _frameModel,
                                                                       this,
                                                                       _multiModelParent,
                                                                       _multiTransomUCP,
                                                                       _multiTransomImagerUCP);
                        ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                        multiTransomUC.Getflp().Controls.Add((UserControl)slidingUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)slidingUC);
                        slidingUCP.SetInitialLoadFalse();
                    }

                }

            }
            else if (panel_Type.Contains("TiltNTurn Panel"))
            {
                ITiltNTurnPanelUCPresenter tiltNTurnUCP;
                if (panel_Parent.Parent.Name.Contains("frame"))
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                    pnlModel.AdjustPropertyPanelHeight("addChkMotorized");
                    pnlModel.AdjustPropertyPanelHeight("addSash");
                    pnlModel.AdjustPropertyPanelHeight("addGlass");
                    pnlModel.AdjustPropertyPanelHeight("addHandle");

                    pnlModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");

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
                    if (panel_Parent.Name.Contains("MultiMullion"))
                    {
                        tiltNTurnUCP = (TiltNTurnPanelUCPresenter)_tiltNTurnUCP.GetNewInstance(_unityC,
                                                                      pnlModel,
                                                                      _frameModel,
                                                                      this,
                                                                      _multiModelParent,
                                                                      _multiMullionUCP,
                                                                      _multiMullionImagerUCP);
                        ITiltNTurnPanelUC tiltNTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                        multiMullionUC.Getflp().Controls.Add((UserControl)tiltNTurnUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)tiltNTurnUC);
                        tiltNTurnUCP.SetInitialLoadFalse();
                    }
                    else
                    {
                        tiltNTurnUCP = (TiltNTurnPanelUCPresenter)_tiltNTurnUCP.GetNewInstance(_unityC,
                                                                       pnlModel,
                                                                       _frameModel,
                                                                       this,
                                                                       _multiModelParent,
                                                                       _multiTransomUCP,
                                                                       _multiTransomImagerUCP);
                        ITiltNTurnPanelUC tiltNTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                        multiTransomUC.Getflp().Controls.Add((UserControl)tiltNTurnUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)tiltNTurnUC);
                        tiltNTurnUCP.SetInitialLoadFalse();
                    }

                }

            }
            else if (panel_Type.Contains("Louver Panel"))
            {
                ILouverPanelUCPresenter louverPanelUCP;
                if (panel_Parent.Parent.Name.Contains("frame"))
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");


                    pnlModel.AdjustPropertyPanelHeight("addGlass");
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
                    if (panel_Parent.Name.Contains("MultiMullion"))
                    {
                        louverPanelUCP = (LouverPanelUCPresenter)_louverPanelUCP.GetNewInstance(_unityC,
                                                                                   pnlModel,
                                                                                   _frameModel,
                                                                                   this,
                                                                                   _multiModelParent,
                                                                                   _multiMullionUCP);
                        ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                        multiMullionUC.Getflp().Controls.Add((UserControl)louverPanelUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)louverPanelUC);
                        louverPanelUCP.SetInitialLoadFalse();
                    }
                    else
                    {
                        louverPanelUCP = (LouverPanelUCPresenter)_louverPanelUCP.GetNewInstance(_unityC,
                                                                                   pnlModel,
                                                                                   _frameModel,
                                                                                   this,
                                                                                   _multiModelParent,
                                                                                   _multiTransomUCP);
                        ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                        multiTransomUC.Getflp().Controls.Add((UserControl)louverPanelUC);
                        _multiModelParent.MPanelLst_Objects.Add((UserControl)louverPanelUC);
                        louverPanelUCP.SetInitialLoadFalse();
                    }
                }
            }
            if (pnlModel.Panel_GeorgianBarOptionVisibility == true)
            {
                pnlModel.AdjustPropertyPanelHeight("addGeorgianBar");
                pnlModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                if (pnlModel.Panel_ParentMultiPanelModel != null)
                {
                    pnlModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addGeorgianBar");
                }
            }
            if (!panel_Parent.Parent.Name.Contains("frame"))
            {
                if (pnlModel.Panel_Placement == "Last")
                {

                    _multiModelParent.Fit_DisplayDimensions();
                    _multiModelParent.Fit_EqualPanel_ToBindDimensions();
                    _multiModelParent.Fit_MyControls_ToBindDimensions();
                    _multiModelParent.Fit_MyControls_ImagersToBindDimensions();
                }
                if (div_DMPanelName != "" || div_DMPanelName != null)
                {
                    foreach (IPanelModel pnl in _multiModelParent.MPanelLst_Panel)
                    {
                        if (pnl.Panel_Name == div_DMPanelName)
                        {
                            _prev_divModel.Div_DMPanel = pnl;
                            SetLblStatus("DMSelection", false, _controlRaised_forDMSelection, _prev_divModel, pnl);
                            div_DMPanelName = "";
                        }
                    }
                }
            }
            inside_panel = false;
        }

        #endregion
        bool inside_quotation, inside_item, inside_frame, inside_concrete, inside_panel, inside_multi, inside_divider, inside_screen,inside_rdlcDic,
             rdlcDicChangeKey = true,
             rdlcAddNewLineToAddr = false,
             add_existing = false;
        #region Frame Properties

        string frmDimension_profileType = "",
               frmDimension_baseColor = "";
        int frm_Height,
              frm_Width,
              frm_BasicDeduction,
              frm_ID,
              frm_WidthToBind,
              frm_HeightToBind,
              frmImageRenderer_Height,
              frmImageRenderer_Width,
              frm_SlidingRailsQty,
              frm_ExplosionWidth,
              frm_ReinfWidth,
              frm_Deduction,
              frm_ReinfHeight,
              frm_ExplosionHeight,
              frmProp_Height,
              frm_ScreenFrameHeight;

        int[] Arr_padding_norm,
                Arr_padding_withmpnl;

        string frm_Name;

        bool frm_Visible,
             frm_BotfrmEnable,
             frm_BotfrmVisible,
             frm_TrackProfileArtNoVisibility,
             frm_SlidingRailsQtyVisibility,
             frm_ConnectionTypeVisibility,
             frm_CmenuDeleteVisibility,
             frm_If_InwardMotorizedCasement,
             frm_ScreenVisibility,
             frm_ScreenOption,
             frm_ScreenHeightOption,
             frm_ScreenHeightVisibility,
             frm_ScreenFrameHeightEnable;
        Padding frm_Padding_int,
                frmImageRenderer_Padding_int;
        float frmImageRenderer_Zoom,
              frm_Zoom;
        //List`1 Lst_Panel
        //List`1 Lst_MultiPanel
        //List`1 Lst_Divider
        IWindoorModel frm_WindoorModel;
        BottomFrameTypes frm_BotfrmArtNo;
        FrameConnectionType frm_ConnectionType;
        UserControl frm_UC,
                    frm_PropertiesUC;
        FrameProfile_ArticleNo frm_ArtNo;
        FrameProfileForPremi_ArticleNo frm_ArtNoForPremi;
        FrameReinf_ArticleNo frm_ReinfArtNo;
        FrameReinfForPremi_ArticleNo frm_ReinfForPremiArtNo;
        MilledFrame_ArticleNo frm_MilledArtNo;
        Frame_MechJointArticleNo frm_MechJointArticleNo;
        ConnectingProfile_ArticleNo frm_ConnectingProfile_ArticleNo;
        MeshType frm_MeshType;
        TrackProfile_ArticleNo frm_TrackProfile_ArticleNo;
        MilledFrameReinf_ArticleNo frm_MilledReinfArtNo;
        #endregion
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
            panel_DisplayHeightDecimal = 0,
            panel_OriginalDisplayHeight,
            panel_OriginalDisplayHeightDecimal,
            panel_ID,
            panel_Width,
            panel_OriginalWidth,
            panel_ImageRenderer_Width,
            panel_WidthToBind,
            panel_DisplayWidth,
            panel_DisplayWidthDecimal = 0,
            panel_OriginalDisplayWidth,
            panel_OriginalDisplayWidthDecimal,
            panel_Index_Inside_MPanel,
            panel_Index_Inside_SPanel,
            panel_PropertyHeight,
            panel_HandleOptionsHeight,
            panel_LouverBladesCount;
        decimal panel_GlassPricePerSqrMeter;
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

        #region Louvre


        int panel_PlantOnWeatherStripHeadWidth,
            panel_PlantOnWeatherStripSealWidth,
            panel_LouverFrameWeatherStripHeadWidth,
            panel_LouverFrameBottomWeatherStripWidth,
            panel_SealForHandleQty,
            panel_LouvreGallerySetHeight,
            panel_CasementSealWidth,
            panel_RubberSealWidth,
            panel_LouverGallerySetCount,
            panel_LouverNumberBladesPerSet;
        bool panel_LouverGalleryVisibility,
            panel_LouverGallerySetOptionVisibility,
            panel_LouverGallerySetVisibility,
            panel_GlassPnlGlazingBeadVisibility,
            panel_GlassPnlGlazingAdaptorVisibility;
        string panel_LouverGallerySetOptionArtNo;
        List<int> panel_LstSealForHandleMultiplier;
        List<string> panel_LstLouverArtNo;
        BladeType_Option panel_LouverBladeTypeOption;

        BladeHeight_Option panel_LouverBladeHeight;
        LouverHandleType_Option panel_LouverHandleType;
        LouverHandleLoc_Option panel_LouverHandleLocation;
        LouverColor_Option panel_LouverGalleryColor;

        AluminumPullHandle_ArticleNo panel_AluminumPullHandleArtNo;
        PlantOnWeatherStripHead_ArticleNo panel_PlantOnWeatherStripHeadArtNo;
        PlantOnWeatherStripSeal_ArticleNo panel_PlantOnWeatherStripSealArtNo;
        LouverFrameWeatherStripHead_ArticleNo panel_LouverFrameWeatherStripHeadArtNo;
        LouverFrameBottomWeatherStrip_ArticleNo panel_LouverFrameBottomWeatherStripArtNo;
        RubberSeal_ArticleNo panel_RubberSealArtNo;
        CasementSeal_ArticleNo panel_CasementSealArtNo;
        SealForHandle_ArticleNo panel_SealForHandleArtNo;
        BubbleSeal_ArticleNo panel_BubbleSealArtNo;
        #endregion

        #region Explosion Properties 
        string panel_GlassThicknessDesc,
               panel_GlassType_Insu_Lami;
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
            panel_StrikerArtno_SlidingQty,
            panel_OverLappingPanelQty;
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
        AluminumPullHandle_ArticleNo panel_AluminumPullHandleArticleNo;
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
               div_Bounded,
               div_DMPanelName;
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
        #region Screen Properties

        bool reinforced,
             sp_MagnumScreenType_Visibility,
             screen_Types_Window,
             screen_Types_Door,
             screen_PVCVisibility,
             springLoad_Checked,
             springLoad_Visibility,
             screen_CenterClosureVisibility,
             screen_CenterClosureVisibilityOption,
             screen_6040MilledProfileVisibility,
             screen_LandCoverVisibility,
             screen_ExchangeRateVisibility,
             screen_6052MilledProfileVisibility,
             screen_373or374MilledProfileVisibility,
             screen_1067PVCboxVisibility,
             screen_1385MilledProfileVisibility;
        decimal screen_Factor,
                screen_UnitPrice,
                screen_TotalAmount,
                screen_NetPrice,
                screen_DiscountedPrice,
                screen_DiscountedPriceWithoutVat,
                screen_LaborAndMobilization,
                screen_TotalNetPriceWithoutVat,
                screen_AddOnsSpecialFactor;
        int screen_id,
            screen_Set,
            screen_Quantity,
            screen_Width,
            screen_Height,
            screen_Discount,
            screen_0505Width,
            screen_1067Height,
            screen_0505Qty,
            screen_1067Qty,
            screen_LatchKitQty,
            screen_IntermediatePartQty,
            screen_6040MilledProfile,
            screen_6040MilledProfileQty,
            screen_LandCover,
            screen_LandCoverQty,
            screen_1067PVCbox,
            screen_1067PVCboxQty,
            screen_1385MilledProfile,
            screen_1385MilledProfileQty,
            screen_373or374MilledProfile,
            screen_373or374MilledProfileQty,
            screen_6052MilledProfile,
            screen_6052MilledProfileQty,
            screen_ExchangeRate,
            plissedRd_Panels;
        string screen_WindoorID,
               screen_description;
        decimal discountPercentage,
                screen_ItemNumber,
                screen_NextItemNumber;
        Freedom_ScreenSize freedom_ScreenSize;
        Freedom_ScreenType freedom_ScreenType;
        ScreenType screen_Types;
        PlisseType screen_PlisséType;
        Base_Color screen_BaseColor;
        Magnum_ScreenType magnum_ScreenType;

        #endregion
        #region rdlcDictionary Properties
        string RDLCDictionary_key,
               RDLCDictionary_value;
        #endregion
        string mpnllvl = "";

        #region ViewUpdate(Controls)

        public void Clearing_Operation()
        {
            _quotationModel = null;
            _frameModel = null;
            _windoorModel = null;
            _screenModel = null;
            _multiPanelModel2ndLvl = null;
            _multiPanelModel3rdLvl = null;
            _multiPanelModel4thLvl = null;
            _multiMullionUC2nd = null;
            _multiTransomUC2nd = null;
            _multiMullionUC3rd = null;
            _multiTransomUC3rd = null;
            _multiMullionUC4th = null;
            _multiTransomUC4th = null;
            _multiModelParent = null;
            mpnllvl = string.Empty;
            _screenList = new List<IScreenModel>();
            _pnlItems.Controls.Clear();


            IEnumerable<Control> controls = _pnlMain.Controls.Cast<Control>().OfType<Control>();
            foreach (Control cons in controls)
            {
                cons.Dispose();
            }
            IEnumerable<Control> controlss = _pnlPropertiesBody.Controls.Cast<Control>().OfType<Control>();
            foreach (Control cons in controlss)
            {
                cons.Dispose();
            }

            _pnlPropertiesBody.Controls.Clear();
            _pnlMain.Controls.Clear();
            //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
            _basePlatformPresenter.RemoveBindingView();
            SetMainViewTitle("");
            CreateNewWindoorBtn_Disable();
            ItemToolStrip_Disable();
            _wndrFilePath = string.Empty;
            _wndrFileName = string.Empty;
            _mainView.GetToolStripButtonSave().Enabled = false;
            _mainView.CreateNewWindoorBtnEnabled = false;
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
            if (!saved && _wndrFilePath != "")
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
                                       bool Duplicate,
                                       frmDimensionPresenter.Show_Purpose purpose,
                                       int frmDimension_numWd,
                                       int frmDimension_numHt,
                                       string frmDimension_profileType,
                                       string frmDimension_baseColor)
        {
            if (frmDimension_numWd == 0 && frmDimension_numHt == 0) //from Quotation Input box to here
            {
                if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile && !Duplicate)
                {
                    Clearing_Operation();
                }
                else if (QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile)
                {

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
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile && !Duplicate)
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
                    _mainView.GetCurrentPrice().Value = 0;
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame && !AddedConcrete && !OpenWindoorFile && !Duplicate)
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
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && AddedConcrete && !OpenWindoorFile && !Duplicate)
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
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && OpenWindoorFile && !Duplicate) //from Open Windoor File
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
                if (QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile && !Duplicate)
                {
                    _wndrFilePath = string.Empty;
                    _wndrFileName = string.Empty;
                    _basePlatformImagerUCPresenter.SendToBack_baseImager();
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
                        SetMainViewTitle(input_qrefno, _projectName, _custRefNo);
                        ItemToolStrip_Enable();
                        _quotationModel = _quotationServices.AddQuotationModel(input_qrefno, _quotationDate, _quoteId);
                        _quotationModel.Customer_Ref_Number = inputted_custRefNo;
                        _quotationModel.Date_Assigned = dateAssigned;
                        SetPricingFactor();

                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         baseColor,
                                                                         Foil_Color._Walnut,
                                                                         Foil_Color._Walnut);
                        _windoorModel.SetDimensions_basePlatform();
                        AddWndrList_QuotationModel(_windoorModel);
                        _quotationModel.Select_Current_Windoor(_windoorModel);
                        _mainView.Zoom = _windoorModel.WD_zoom;
                        //_mainView.PropertiesScroll = _windoorModel.WD_PropertiesScroll;
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
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && OpenWindoorFile && !Duplicate) // Open File
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
                        _quotationModel.Select_Current_Windoor(_windoorModel);
                        _windoorModel.SetDimensions_basePlatform();

                        _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                        _mainView.GetThis().Controls.Add(bpUC);

                        _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());
                        _pnlMain.Controls.Clear();
                        AddItemInfoUC(_windoorModel); //add item information user control
                        SetMainViewTitle(input_qrefno,
                                        _projectName,
                                        _custRefNo,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         true);

                        BotToolStrip_Enable();
                        CreateNewWindoorBtn_Enable();
                        _pnlPropertiesBody.Controls.Clear(); //Clearing Operation
                        //_basePlatformPresenter.RemoveBindingView();
                        //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
                        _pnlItems.VerticalScroll.Value = _pnlItems.VerticalScroll.Maximum;
                        _pnlItems.PerformLayout();

                        //_frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                    else if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Concrete)
                    {
                        int concreteID = _windoorModel.concreteIDCounter += 1;
                        _concreteModel = _concreteServices.AddConcreteModel(frmDimension_numWd,
                                                                            frmDimension_numHt,
                                                                            _windoorModel.WD_zoom,
                                                                            _windoorModel.WD_zoom_forImageRenderer,
                                                                            concreteID);
                        _concreteModel.Set_DimensionsToBind_using_ConcreteZoom();
                        _concreteModel.Set_ImagerDimensions_using_ImagerZoom();

                        IConcretePropertiesUCPresenter concretePropertiesUCPresenter = _concretePropertiesUCPresenter.GetNewInstance(_concreteModel, _unityC, this);
                        AddConcreteUC(_concreteModel);
                        _concreteModel.Concrete_UC = (UserControl)_concreteUC;
                        _concreteModel.Concrete_PropertiesUC = (UserControl)concretePropertiesUCPresenter.GetConcretePropertiesUC();
                        AddConcreteList_WindoorModel(_concreteModel);
                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                        _windoorModel.Fit_MyControls_ToBindDimensions();
                        _windoorModel.Fit_MyControls_ImagersToBindDimensions();
                    }
                    else if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Frame)
                    {
                        _frameModel = _frameServices.AddFrameModel(frmDimension_numWd,
                                                                   frmDimension_numHt,
                                                                   frameType,
                                                                   _windoorModel.WD_zoom_forImageRenderer,
                                                                   _windoorModel.WD_zoom,
                                                                   frm_ArtNo,
                                                                   _windoorModel,
                                                                   frm_BotfrmArtNo,
                                                                   _windoorModel.frameIDCounter,
                                                                   frm_Name,
                                                                   frm_Visible,
                                                                   frm_BotfrmVisible,
                                                                   null,
                                                                   null,
                                                                   null,
                                                                   (UserControl)_frameUC,
                                                                   (UserControl)_framePropertiesUC);
                        _frameModel.Frame_ID = frm_ID;
                        _frameModel.Frame_WidthToBind = frm_WidthToBind;
                        _frameModel.Frame_HeightToBind = frm_HeightToBind;
                        _frameModel.FrameImageRenderer_Height = frmImageRenderer_Height;
                        _frameModel.FrameImageRenderer_Width = frmImageRenderer_Width;
                        _frameModel.Frame_SlidingRailsQty = frm_SlidingRailsQty;
                        _frameModel.Frame_ExplosionWidth = frm_ExplosionWidth;
                        _frameModel.Frame_ReinfWidth = frm_ReinfWidth;
                        _frameModel.Frame_ReinfHeight = frm_ReinfHeight;
                        _frameModel.Frame_ExplosionHeight = frm_ExplosionHeight;
                        //_frameModel.FrameProp_Height = frmProp_Height;
                        _frameModel.Frame_BotFrameEnable = frm_BotfrmEnable;
                        _frameModel.Frame_SlidingRailsQtyVisibility = false;
                        _frameModel.Frame_ConnectionTypeVisibility = false;
                        _frameModel.Frame_CmenuDeleteVisibility = frm_CmenuDeleteVisibility;
                        _frameModel.Frame_If_InwardMotorizedCasement = frm_If_InwardMotorizedCasement;
                        _frameModel.Frame_Padding_int = frm_Padding_int;
                        _frameModel.FrameImageRenderer_Padding_int = frmImageRenderer_Padding_int;
                        _frameModel.Frame_ConnectionType = frm_ConnectionType;
                        _frameModel.Frame_ArtNoForPremi = frm_ArtNoForPremi;
                        _frameModel.Frame_ReinfArtNo = frm_ReinfArtNo;
                        _frameModel.Frame_ReinfForPremiArtNo = frm_ReinfForPremiArtNo;
                        _frameModel.Frame_MilledArtNo = frm_MilledArtNo;
                        _frameModel.Frame_MilledReinfArtNo = frm_MilledReinfArtNo;
                        _frameModel.Frame_MechanicalJointConnector_Artno = frm_MechJointArticleNo;
                        _frameModel.Frame_TrackProfileArtNoVisibility = frm_TrackProfileArtNoVisibility;
                        _frameModel.Frame_TrackProfileArtNo = frm_TrackProfile_ArticleNo;
                        _frameModel.Frame_ConnectingProfile_ArticleNo = frm_ConnectingProfile_ArticleNo;
                        _frameModel.Frame_MeshType = frm_MeshType;
                        _frameModel.Frame_ScreenVisibility = frm_ScreenVisibility;
                        _frameModel.Frame_ScreenOption = frm_ScreenOption;
                        _frameModel.Frame_ScreenHeightOption = frm_ScreenHeightOption;
                        _frameModel.Frame_ScreenHeightVisibility = frm_ScreenHeightVisibility;
                        _frameModel.Frame_ScreenFrameHeight = frm_ScreenFrameHeight;
                        _frameModel.Frame_ScreenFrameHeightEnable = frm_ScreenFrameHeightEnable;
                        _frameModel.Set_DimensionsToBind_using_FrameZoom();
                        _frameModel.Set_ImagerDimensions_using_ImagerZoom();
                        _frameModel.Set_FramePadding();
                        _framePropertiesUCPresenter = _framePropertiesUCPresenter.GetNewInstance(_frameModel, _unityC, this);
                        AddFrameUC(_frameModel, _framePropertiesUCPresenter);
                        _frameModel.Frame_UC = (UserControl)_frameUC;
                        _frameModel.Frame_PropertiesUC = (UserControl)_framePropertiesUCPresenter.GetFramePropertiesUC();
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
                        _windoorModel.Fit_MyControls_ToBindDimensions();
                        _windoorModel.Fit_MyControls_ImagersToBindDimensions();

                    }
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile && Duplicate) // Open File
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.Duplicate)
                    {
                        wndr_content = new List<string>();
                        SaveWindoorModel(_windoorModel);
                        wndr_content.Add("EndofFile");
                        file_lines = wndr_content.ToArray();
                        onload = true;
                        Windoor_Save_UserControl();
                        Windoor_Save_PropertiesUC();
                        _mainView.GetTsProgressLoading().Maximum = file_lines.Length;
                        _basePlatformImagerUCPresenter.SendToBack_baseImager();
                        StartWorker("Duplicate_Item");


                    }
                }
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile && !Duplicate) //Add new Item
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Item)
                    {
                        Windoor_Save_UserControl();
                        Windoor_Save_PropertiesUC();

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
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame && !AddedConcrete && !OpenWindoorFile && !Duplicate) //add frame
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Frame)
                    {
                        bool NewFrameSizeFit = CheckAvailableDimensionFromBasePlatform(frmDimension_numWd,
                                                                                       frmDimension_numHt);
                        BottomFrameTypes frameBotFrameType = null;
                        if (_windoorModel.WD_profile == "C70 Profile")
                        {
                            if (frameType == Frame_Padding.Door)
                            {
                                frameBotFrameType = BottomFrameTypes._7507;
                            }
                            else if (frameType == Frame_Padding.Window)
                            {
                                frameBotFrameType = BottomFrameTypes._7502;
                            }
                        }
                        else if (_windoorModel.WD_profile == "PremiLine Profile")
                        {
                            if (frameType == Frame_Padding.Door)
                            {
                                frameBotFrameType = BottomFrameTypes._6052;
                            }
                            else if (frameType == Frame_Padding.Window)
                            {
                                frameBotFrameType = BottomFrameTypes._6050;
                            }
                        }
                        if (NewFrameSizeFit)
                        {
                            int frameID = _windoorModel.frameIDCounter += 1;
                            _frameModel = _frameServices.AddFrameModel(frmDimension_numWd,
                                                                       frmDimension_numHt,
                                                                       frameType,
                                                                       _windoorModel.WD_zoom_forImageRenderer,
                                                                       _windoorModel.WD_zoom,
                                                                       FrameProfile_ArticleNo._7502,
                                                                       _windoorModel,
                                                                       frameBotFrameType,
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

                            IFramePropertiesUCPresenter framePropUCP = AddFramePropertiesUC(_frameModel);
                            AddFrameUC(_frameModel, framePropUCP);

                            _frameModel.Frame_UC = (UserControl)_frameUC;
                            _frameModel.Frame_PropertiesUC = (UserControl)framePropUCP.GetFramePropertiesUC();
                            AddFrameList_WindoorModel(_frameModel);
                            _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            _basePlatformPresenter.InvalidateBasePlatform();
                            SetMainViewTitle(input_qrefno,
                                            _projectName,
                                            _custRefNo,
                                             _windoorModel.WD_name,
                                             _windoorModel.WD_profile,
                                             false);

                            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                            _windoorModel.Fit_MyControls_ToBindDimensions();
                            _windoorModel.Fit_MyControls_ImagersToBindDimensions();
                            GetCurrentPrice();
                        }
                        else
                        {
                            MessageBox.Show("Invalid dimension, You exceed the maximum item dimension!", "Frame Dimension", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && AddedConcrete && !OpenWindoorFile && !Duplicate) //add concrete
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Concrete)
                    {

                        bool NewConcreteSizeFit = CheckAvailableDimensionFromBasePlatform(frmDimension_numWd,
                                                                                          frmDimension_numHt);
                        if (NewConcreteSizeFit)
                        {
                            int concreteID = _windoorModel.concreteIDCounter += 1;
                            _concreteModel = _concreteServices.AddConcreteModel(frmDimension_numWd,
                                                                                frmDimension_numHt,
                                                                                _windoorModel.WD_zoom,
                                                                                _windoorModel.WD_zoom_forImageRenderer,
                                                                                concreteID);
                            _concreteModel.Set_DimensionsToBind_using_ConcreteZoom();
                            _concreteModel.Set_ImagerDimensions_using_ImagerZoom();

                            IConcretePropertiesUCPresenter concretePropertiesUCPresenter = AddConcretePropertiesUC(_concreteModel);
                            AddConcreteUC(_concreteModel);
                            _concreteModel.Concrete_UC = (UserControl)_concreteUC;
                            AddConcreteList_WindoorModel(_concreteModel);

                            _basePlatformPresenter.InvalidateBasePlatform();
                            _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                            _windoorModel.Fit_MyControls_ToBindDimensions();
                            _windoorModel.Fit_MyControls_ImagersToBindDimensions();
                        }
                        else
                        {
                            MessageBox.Show("Invalid dimension, You exceed the maximum item dimension!", "Concrete Dimension", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            GetIntownOutofTown();
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
                _windoorModel.SetfrmDimentionZoom();
                _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                _basePlatformPresenter.InvalidateBasePlatform();
                _basePlatformPresenter.Invalidate_flpMainControls();
                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                _basePlatformImagerUCPresenter.Invalidate_flpMain();
            }
            if (_windoorModel.lst_objects.Count > 1)
            {
                _windoorModel.Fit_MyControls_ToBindDimensions();
                _windoorModel.Fit_MyControls_ImagersToBindDimensions();
            }
            //Load_Windoor_Item(_windoorModel);
        }
        #endregion

        #region Functions

        public void Set_User_View()
        {
            if (_userModel.AccountType == "User Level 3")
            {
                _mainView.Set_AssignProject_Visibility(false);
            }
        }

        public void Windoor_Save_PropertiesUC()
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
                if (uc is IConcretePropertiesUC)
                {
                    IConcretePropertiesUC cpUC = (IConcretePropertiesUC)uc;
                    foreach (IConcreteModel ccModel in _windoorModel.lst_concrete)
                    {
                        if (cpUC.Concrete_ID == ccModel.Concrete_Id)
                        {
                            ccModel.Concrete_PropertiesUC = uc;
                        }
                    }
                }
            }
        }

        public void Windoor_Save_UserControl()
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
                if (uc is IConcreteUC)
                {
                    IConcreteUC cUC = (IConcreteUC)uc;
                    foreach (IConcreteModel crModel in _windoorModel.lst_concrete)
                    {
                        if (cUC.Concrete_ID == crModel.Concrete_Id)
                        {
                            crModel.Concrete_UC = uc;
                        }
                    }
                }
            }
        }

        public void Load_Windoor_Item(IWindoorModel item)
        {
            try
            {
                _basePlatformImagerUCPresenter.SendToBack_baseImager();

                //save frame
                Windoor_Save_UserControl();
                Windoor_Save_PropertiesUC();

                //set mainview
                _windoorModel = item;

                _quotationModel.Select_Current_Windoor(_windoorModel);
                SetMainViewTitle(input_qrefno,
                                _projectName,
                                _custRefNo,
                                 _windoorModel.WD_name,
                                 _windoorModel.WD_profile,
                                 false);
                //clear

                _pnlMain.Controls.Clear();
                _pnlPropertiesBody.Controls.Clear();
                _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);

                //basePlatform
                _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());
                _basePlatformPresenter.InvalidateBasePlatform();

                _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                _mainView.GetThis().Controls.Add(bpUC);


                foreach (Control wndr_objects in _windoorModel.lst_objects)
                {
                    if (wndr_objects.Name.Contains("Frame"))
                    {
                        foreach (IFrameModel frame in _windoorModel.lst_frame)
                        {
                            if (wndr_objects.Name == frame.Frame_Name)
                            {
                                _pnlPropertiesBody.Controls.Add((UserControl)frame.Frame_PropertiesUC);
                                frame.Frame_PropertiesUC.BringToFront();
                                _basePlatformPresenter.AddFrame((IFrameUC)frame.Frame_UC);
                            }
                        }
                    }
                    else if (wndr_objects.Name.Contains("Concrete"))
                    {
                        foreach (IConcreteModel concrete in _windoorModel.lst_concrete)
                        {
                            if (wndr_objects.Name == concrete.Concrete_Name)
                            {
                                _pnlPropertiesBody.Controls.Add((UserControl)concrete.Concrete_PropertiesUC);
                                concrete.Concrete_PropertiesUC.BringToFront();
                                _basePlatformPresenter.AddConcrete((IConcreteUC)concrete.Concrete_UC);
                            }
                        }
                    }
                }
                //frames


                //_pnlPropertiesBody.Refresh();
                _mainView.RemoveBinding(_mainView.GetLblSize());
                _mainView.RemoveBinding();
                _windoorModel.SetPanelGlassID();
                _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());
                _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                _windoorModel.SetZoom();
                qoutationModel_MainPresenter.itemSelectStatus = true;
                //GetCurrentPrice();
                _itemLoad = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Location: " + this + "\n\n Error: " + ex.Message);
            }
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
                                !((frame_art == FrameProfile_ArticleNo._6050 || frame_art == FrameProfile_ArticleNo._6052) &&
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
                        else if (handletype == Handle_Type._PopUp)
                        {
                            if (!(frame_art == FrameProfile_ArticleNo._6052 &&
                                  sash_art == SashProfile_ArticleNo._6040))
                            {
                                incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                            }
                        }
                        else if (handletype == Handle_Type._D || handletype == Handle_Type._DummyD || handletype == Handle_Type._D_IO_Locking || handletype == Handle_Type._RotoswingForSliding)
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
                                       !((frame_art == FrameProfile_ArticleNo._6050 || frame_art == FrameProfile_ArticleNo._6052) &&
                                         sash_art == SashProfile_ArticleNo._6040))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                                }
                            }
                            else if (handletype == Handle_Type._Rio || handletype == Handle_Type._Rotoline || handletype == Handle_Type._MVD)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._7507 &&
                                      (sash_art == SashProfile_ArticleNo._374 ||
                                       sash_art == SashProfile_ArticleNo._373)) &&
                                    !(frame_art == FrameProfile_ArticleNo._6052 &&
                                    sash_art == SashProfile_ArticleNo._6041))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                                }
                            }
                            else if (handletype == Handle_Type._PopUp)
                            {
                                if (!(frame_art == FrameProfile_ArticleNo._6052 &&
                                      sash_art == SashProfile_ArticleNo._6040))
                                {
                                    incompatibility += "\n\nOn P" + pnl.PanelGlass_ID + "\nFrame Profile : " + frame_art.DisplayName + ", Sash Profile : " + sash_art.DisplayName + ", Handle Type : " + handletype.DisplayName;
                                }
                            }
                            else if (handletype == Handle_Type._D || handletype == Handle_Type._DummyD || handletype == Handle_Type._D_IO_Locking || handletype == Handle_Type._RotoswingForSliding)
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
                        if (mpnl.MPanelLst_Panel.Count != 0)
                        {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    var st = new StackTrace(ex, true);
                    // Get the top stack frame
                    var errorFrame = st.GetFrame(0);
                    // Get the line number from the stack frame
                    var line = errorFrame.GetFileLineNumber();
                    Console.WriteLine("Error in File " + errorFrame.GetFileName() + "\n Line: " + line.ToString() + "\n Error: " + ex.Message);
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
            //mainPresenterBinding.Add("WD_PropertiesScroll", new Binding("PropertiesScroll", _windoorModel, "WD_PropertiesScroll", true, DataSourceUpdateMode.OnPropertyChanged));
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
                                                                                            _userModel,
                                                                                            frameModel,
                                                                                            this,
                                                                                            _basePlatformPresenter,
                                                                                            frameImagerUCP,
                                                                                            _basePlatformImagerUCPresenter,
                                                                                            framePropertiesUCP);
            _frameUC = frameUCP.GetFrameUC();
            frmUCPresenter = frameUCP;
            _basePlatformPresenter.AddFrame(_frameUC);

        }

        private void AddConcreteUC(IConcreteModel concreteModel)
        {
            IConcreteUCPresenter concreteUCPresenter = _concreteUCPresenter.GetNewInstance(_unityC, concreteModel, this, _basePlatformPresenter);
            _concreteUC = concreteUCPresenter.GetConcreteUC();
            _basePlatformPresenter.AddConcrete(_concreteUC);
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
            _windoorModel.lst_objects.Add((UserControl)frameModel.Frame_UC);
        }

        private void AddConcreteList_WindoorModel(IConcreteModel concreteModel)
        {
            _windoorModel.lst_concrete.Add(concreteModel);
            _windoorModel.lst_objects.Add((UserControl)concreteModel.Concrete_UC);
        }

        public void DeleteFrame_OnFrameList_WindoorModel(IFrameModel frameModel)
        {
            _windoorModel.lst_objects.Remove((UserControl)frameModel.Frame_UC);
            _windoorModel.lst_frame.Remove(frameModel);
            Load_Windoor_Item(_windoorModel);
        }

        public void DeleteConcrete_OnConcreteList_WindoorModel(IConcreteModel concreteModel)
        {
            _windoorModel.lst_objects.Remove((UserControl)concreteModel.Concrete_UC);
            _windoorModel.lst_concrete.Remove(concreteModel);
            Load_Windoor_Item(_windoorModel);
        }


        public IFramePropertiesUC GetFrameProperties(int frameID)
        {
            return _pnlPropertiesBody.Controls.OfType<IFramePropertiesUC>().First(ctrl => ctrl.FrameID == frameID);
        }

        public int GetPanelCount()
        {
            int pnlCount = 0;
            foreach (IFrameModel frm in _windoorModel.lst_frame)
            {
                pnlCount += frm.Lst_Panel.Count;
                foreach (IMultiPanelModel mpl2ndlvl in frm.Lst_MultiPanel)
                {
                    pnlCount += mpl2ndlvl.MPanelLst_Panel.Count;
                    foreach (IMultiPanelModel mpl3rdlvl in mpl2ndlvl.MPanelLst_MultiPanel)
                    {
                        pnlCount += mpl3rdlvl.MPanelLst_Panel.Count;
                        foreach (IMultiPanelModel mpl4thlvl in mpl3rdlvl.MPanelLst_MultiPanel)
                        {
                            pnlCount += mpl4thlvl.MPanelLst_Panel.Count;
                        }
                    }
                }
            }
            if (pnlCount == 0)
            {
                _windoorModel.panelIDCounter = 0;
                _windoorModel.PanelGlassID_Counter = 0;
            }
            return _windoorModel.panelIDCounter += 1;
        }

        public int GetMultiPanelCount()
        {
            int mpnlCount = 0;
            foreach (IFrameModel frm in _windoorModel.lst_frame)
            {
                mpnlCount += frm.Lst_MultiPanel.Count;
                foreach (IMultiPanelModel mpl2ndlvl in frm.Lst_MultiPanel)
                {
                    mpnlCount += mpl2ndlvl.MPanelLst_MultiPanel.Count;
                    foreach (IMultiPanelModel mpl3rdlvl in mpl2ndlvl.MPanelLst_MultiPanel)
                    {
                        mpnlCount += mpl3rdlvl.MPanelLst_MultiPanel.Count;
                        foreach (IMultiPanelModel mpl4thlvl in mpl3rdlvl.MPanelLst_MultiPanel)
                        {
                            mpnlCount += mpl4thlvl.MPanelLst_MultiPanel.Count;
                        }
                    }
                }
            }
            if (mpnlCount == 0)
            {
                _windoorModel.mpanelIDCounter = 0;
            }
            return _windoorModel.mpanelIDCounter += 1;
        }

        public int GetDividerCount()
        {
            int divCount = 0;
            foreach (IFrameModel frm in _windoorModel.lst_frame)
            {
                divCount += frm.Lst_Divider.Count;

            }
            if (divCount == 0)
            {
                _windoorModel.divIDCounter = 0;
            }
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
        ISlidingPanelUCPresenter current_sliding;
        ICasementPanelUCPresenter current_casement;
        IFixedPanelUCPresenter current_fixed;
        public void SetSelectedPanel(IPanelModel panelModel,
                                     ISlidingPanelUCPresenter slidingPanelUCPresenter = null,
                                     ICasementPanelUCPresenter casementPanelUCPresenter = null,
                                     IFixedPanelUCPresenter fixedPanelUCPresenter = null)
        {
            _tsLblStatus.Visible = true;
            _tsLblStatus.Text = panelModel.Panel_Name + " Selected";
            if (slidingPanelUCPresenter != null)
            {
                if (current_sliding != null)
                {
                    current_sliding.boolKeyDown = false;
                    current_sliding = null;
                }
                else if (current_casement != null)
                {
                    current_casement.boolKeyDown = false;
                    current_casement = null;
                }
                else if (current_fixed != null)
                {
                    current_fixed.boolKeyDown = false;
                    current_fixed = null;
                }
                slidingPanelUCPresenter.boolKeyDown = true;
                slidingPanelUCPresenter.FocusOnThisSlidingPanel();
                current_sliding = slidingPanelUCPresenter;
            }
            else if (casementPanelUCPresenter != null)
            {
                if (current_sliding != null)
                {
                    current_sliding.boolKeyDown = false;
                    current_sliding = null;
                }
                else if (current_casement != null)
                {
                    current_casement.boolKeyDown = false;
                    current_casement = null;
                }
                else if (current_fixed != null)
                {
                    current_fixed.boolKeyDown = false;
                    current_fixed = null;
                }
                casementPanelUCPresenter.boolKeyDown = true;
                casementPanelUCPresenter.FocusOnThisCasementPanel();
                current_casement = casementPanelUCPresenter;
            }
            else if (fixedPanelUCPresenter != null)
            {
                if (current_sliding != null)
                {
                    current_sliding.boolKeyDown = false;
                    current_sliding = null;
                }
                else if (current_casement != null)
                {
                    current_casement.boolKeyDown = false;
                    current_casement = null;
                }
                else if (current_fixed != null)
                {
                    current_fixed.boolKeyDown = false;
                    current_fixed = null;
                }
                fixedPanelUCPresenter.boolKeyDown = true;
                fixedPanelUCPresenter.FocusOnThisFixedPanel();
                current_fixed = fixedPanelUCPresenter;
            }
        }
        public void DeselectDivider()
        {
            _mainView.GetLblSelectedDivider().Visible = false;
            _mainView.GetLblSelectedDivider().Text = "";
            _mainView.SetActiveControl(null);
        }
        public void DeselectPanel()
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
            if (_wndrFilePath != "")
            {

                string txtfile = _wndrFilePath.Replace(".wndr", ".txt");
                File.WriteAllLines(txtfile, Saving_dotwndr());
                File.Delete(_wndrFilePath);
                FileInfo f = new FileInfo(txtfile);
                f.MoveTo(Path.ChangeExtension(txtfile, ".wndr"));
                //File.SetAttributes(txtfile, FileAttributes.Hidden);
                //csfunc.EncryptFile(txtfile);
                //File.Delete(txtfile);

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
                SetMainViewTitle(input_qrefno,
                                     _projectName,
                                     _custRefNo,
                                     _windoorModel.WD_name,
                                     _windoorModel.WD_profile,
                                     true);
            }
            //else
            //{
            //    _mainView.GetSaveFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
            //    if (_mainView.GetSaveFileDialog().ShowDialog() == DialogResult.OK)
            //    {
            //        if (wndrfile != _mainView.GetSaveFileDialog().FileName)
            //        {
            //            wndrfile = _mainView.GetSaveFileDialog().FileName;
            //            saveToolStripButton_Click();

            //        }
            //    }

            //}
        }

        public void DeleteConcrete_OnObjectList_WindoorModel(UserControl concreteUC)
        {
            _windoorModel.lst_objects.Remove(concreteUC);
        }
        public async void SetPricingFactor()
        {
            try
            {
                string[] province = projectAddress.Split(',');
                _quotationModel.PricingFactor = await _quotationServices.GetFactorByProvince((province[province.Length - 2]).Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //string province = projectAddress.Split(',').LastOrDefault().Replace("Luzon", string.Empty).Replace("Visayas", string.Empty).Replace("Mindanao", string.Empty).Trim();
            //_quotationModel.PricingFactor = await _quotationServices.GetFactorByProvince(province);
        }


        public List<IMultiPanelModel> Arrange_Frame_MultiPanelModel(IFrameModel frmModel)
        {
            List<IMultiPanelModel> lst_MPanel = new List<IMultiPanelModel>();
            if (frmModel.Lst_MultiPanel.Count > 0)
            {
                lst_MPanel.Add(frmModel.Lst_MultiPanel[0]);
                foreach (IMultiPanelModel mpnl2nd in frmModel.Lst_MultiPanel[0].MPanelLst_MultiPanel)
                {
                    lst_MPanel.Add(mpnl2nd);
                }

                foreach (IMultiPanelModel mpnl3rd in frmModel.Lst_MultiPanel[0].MPanelLst_MultiPanel)
                {

                    foreach (IMultiPanelModel mpnl4th in mpnl3rd.MPanelLst_MultiPanel)
                    {
                        lst_MPanel.Add(mpnl4th);
                    }

                }
            }
            return lst_MPanel;
        }

        #region Variables for description
        private List<IQuoteItemListUCPresenter> _lstQuoteItemUC = new List<IQuoteItemListUCPresenter>();
        private List<int> _lstItemArea = new List<int>();
        private List<string> lst_glassThickness = new List<string>();
        private List<string> lst_glassThicknessPerItem = new List<string>();
        private List<string> lst_glassFilm = new List<string>();
        private List<string> lst_Description = new List<string>();
        private List<string> lst_DuplicatePnl = new List<string>();

        bool pnl_LouverChk = false;

        int GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0;

        string FrameTypeDesc,
               AllItemDescription,
               motorizeDesc,
               NewNoneDuplicatePnlAndCount,
               lst_DescDist,
               glassThick,
               GeorgianBarHorizontalDesc,
               GeorgianBarVerticalDesc,
               additionalZero,
               GeorgianBarArtNoDesc;
        #endregion
        public void itemDescription()
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                if (wdm.WD_Selected == true && !ItemLoad)
                {
                    lst_DuplicatePnl.Clear();
                    lst_Description.Clear();
                    NewNoneDuplicatePnlAndCount = string.Empty;
                    if (wdm.lst_frame.Count > 0)
                    {
                        foreach (IFrameModel fr in wdm.lst_frame)
                        {
                            if (fr.Frame_Type == Frame_Padding.Window)
                            {
                                FrameTypeDesc = "Window";
                            }
                            else if (fr.Frame_Type == Frame_Padding.Door)
                            {
                                FrameTypeDesc = "Door";
                            }

                            #region MultiPnl
                            if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                            {
                                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                                {
                                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                    {

                                        #region 1stApproach
                                        //if (pnl.Panel_Type.Contains("Fixed"))
                                        //{
                                        //    fixedCount += 1;
                                        //}
                                        //else if (pnl.Panel_Type.Contains("Awning"))
                                        //{
                                        //    AwningCount += 1;
                                        //}
                                        //else if (pnl.Panel_Type.Contains("Casement"))
                                        //{
                                        //    CasementCount += 1;
                                        //}

                                        //if (pnl.Panel_GlassThicknessDesc != null)
                                        //{
                                        //    lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + "\n");
                                        //}
                                        //if (pnl.Panel_GlassFilm.ToString() != "None")
                                        //{
                                        //    lst_glassFilm.Add(pnl.Panel_GlassFilm.ToString());
                                        //}




                                        //if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                        //{
                                        //    GeorgianBarHorizontalQty += pnl.Panel_GeorgianBar_HorizontalQty;
                                        //    GeorgianBarVerticalQty += pnl.Panel_GeorgianBar_VerticalQty;

                                        //    GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                                        //    GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                                        //}


                                        //if (pnl.Panel_MotorizedOptionVisibility == true)
                                        //{
                                        //    motorizeDesc = " Panel Motorized";
                                        //}
                                        //else
                                        //{
                                        //    motorizeDesc = " Panel";
                                        //}

                                        //if (fixedCount != 0 && pnl.Panel_Type.Contains("Fixed"))
                                        //{
                                        //    AllItemDescription = AllItemDescription + fixedCount.ToString() + motorizeDesc + " Fixed " + FrameTypeDesc + "\n";
                                        //}
                                        //if (AwningCount != 0 && pnl.Panel_Type.Contains("Awning"))
                                        //{
                                        //    AllItemDescription = AllItemDescription + AwningCount.ToString() + motorizeDesc + " Awning " + FrameTypeDesc + "\n";
                                        //}
                                        //if (CasementCount != 0 && pnl.Panel_Type.Contains("Casement"))
                                        //{
                                        //    AllItemDescription = AllItemDescription + CasementCount.ToString() + motorizeDesc + " Casement " + FrameTypeDesc + "\n";
                                        //}

                                        //List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();
                                        //List<string> lst_glassFilmDistinct = lst_glassFilm.Distinct().ToList();

                                        //foreach (string GT in lst_glassThicknessDistinct)
                                        //{
                                        //    AllItemDescription += GT;
                                        //}

                                        //if (lst_glassFilmDistinct != null)
                                        //{
                                        //    foreach (string GF in lst_glassFilmDistinct)
                                        //    {
                                        //        AllItemDescription += "with " + GF + "\n";
                                        //    }
                                        //}

                                        //AllItemDescription += GeorgianBarHorizontalDesc;
                                        //AllItemDescription += GeorgianBarVerticalDesc;

                                        ////lst_Description.Add(AllItemDescription);
                                        // wdm.WD_description = AllItemDescription;
                                        #endregion

                                        //GlassThickness & Glassfilm
                                        if (pnl.Panel_GlassThicknessDesc != null)
                                        {
                                            if (pnl.Panel_GlassFilm.ToString() != "None")
                                            {
                                                if (pnl.Panel_Type.Contains("Louver"))
                                                {
                                                    lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + " Blades" + " with " + pnl.Panel_GlassFilm.ToString() + "\n");
                                                }
                                                else
                                                {
                                                    lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + " with " + pnl.Panel_GlassFilm.ToString() + "\n");
                                                }
                                            }
                                            else if (pnl.Panel_Type.Contains("Louver"))
                                            {
                                                lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + " Blades" + "\n");
                                            }
                                            else
                                            {
                                                lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + "\n");
                                            }
                                        }
                                        else
                                        {
                                            lst_glassThickness.Add(string.Empty);
                                        }

                                        //GeorgianBar
                                        if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                        {
                                            GeorgianBarHorizontalQty += pnl.Panel_GeorgianBar_HorizontalQty;
                                            GeorgianBarVerticalQty += pnl.Panel_GeorgianBar_VerticalQty;
                                            GeorgianBarArtNoDesc = pnl.Panel_GeorgianBarArtNo.ToString();
                                        }

                                        //panel name desc
                                        #region panelNameDesc
                                        if (pnl.Panel_MotorizedOptionVisibility == true)
                                        {
                                            motorizeDesc = "1 Panel Motorized";
                                        }
                                        else
                                        {
                                            motorizeDesc = "1 Panel";
                                        }

                                        if (pnl.Panel_Type.Contains("Louver"))
                                        {
                                            pnl_LouverChk = true;

                                            List<string> lst_LouverArtNoDistinct = new List<string>();
                                            if (pnl.Panel_LstLouverArtNo != null)
                                            {

                                                if (pnl.Panel_LouverBladesCount >= 2 &&
                                                    pnl.Panel_LouverBladesCount <= 9)
                                                {
                                                    additionalZero = "0";
                                                }
                                                else
                                                {
                                                    additionalZero = "";
                                                }
                                                foreach (string artNo in pnl.Panel_LstLouverArtNo)
                                                {
                                                    string extracted = artNo.Remove(9, 2).Insert(9, additionalZero + pnl.Panel_LouverBladesCount.ToString());
                                                    lst_LouverArtNoDistinct.Add(extracted);
                                                }
                                            }

                                            List<string> lst_LouverArtNoDistinctCheck = lst_LouverArtNoDistinct.Distinct().ToList();

                                            if (lst_LouverArtNoDistinctCheck.Count == 0)
                                            {
                                                AllItemDescription = motorizeDesc + " " + pnl.Panel_Type.Replace("Panel", string.Empty) + FrameTypeDesc + "\n";
                                            }
                                            else if (lst_LouverArtNoDistinctCheck.Count == 1)
                                            {
                                                AllItemDescription = motorizeDesc + " " + lst_LouverArtNoDistinctCheck[0] + "\n";
                                            }
                                            else
                                            {
                                                AllItemDescription = motorizeDesc + " " + "LVRG-152-" + additionalZero + pnl.Panel_LouverBladesCount + "-S-RH-BLK" + "\n";
                                            }
                                        }
                                        else
                                        {
                                            AllItemDescription = motorizeDesc + " " + pnl.Panel_Type.Replace("Panel", string.Empty) + FrameTypeDesc + "\n";
                                        }

                                        #endregion

                                        lst_Description.Add(AllItemDescription);
                                    }

                                }
                            }
                            #endregion

                            #region SinglePnl 
                            else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)//single
                            {
                                IPanelModel Singlepnl = fr.Lst_Panel[0];
                                if (Singlepnl.Panel_MotorizedOptionVisibility == true)
                                {
                                    motorizeDesc = "Panel Motorized ";
                                    wdm.WD_description = wdm.WD_profile + "\n1 " + motorizeDesc + Singlepnl.Panel_Type.Replace("Panel", string.Empty) + " " + FrameTypeDesc;
                                }
                                else if (Singlepnl.Panel_Type.Contains("Louver"))
                                {
                                    pnl_LouverChk = true;
                                    //if (Singlepnl.Panel_MotorizedOptionVisibility == true)
                                    //{
                                    //    motorizeDesc = "Panel Motorized ";
                                    //}
                                    //else
                                    //{
                                    //    motorizeDesc = "";
                                    //}

                                    List<string> lst_LouverArtNoDistinct = new List<string>();
                                    if (Singlepnl.Panel_LstLouverArtNo != null)
                                    {
                                        if (Singlepnl.Panel_LouverBladesCount >= 2 &&
                                            Singlepnl.Panel_LouverBladesCount <= 9)
                                        {
                                            additionalZero = "0";
                                        }
                                        else
                                        {
                                            additionalZero = "";
                                        }

                                        foreach (string artNo in Singlepnl.Panel_LstLouverArtNo)
                                        {
                                            string extracted = artNo.Remove(9, 2).Insert(9, additionalZero + Singlepnl.Panel_LouverBladesCount.ToString());
                                            lst_LouverArtNoDistinct.Add(extracted);
                                        }
                                    }

                                    List<string> lst_LouverArtNoDistinctCheck = lst_LouverArtNoDistinct.Distinct().ToList();
                                    if (lst_LouverArtNoDistinctCheck.Count == 0)
                                    {
                                        wdm.WD_description = wdm.WD_profile + "\n1 " + motorizeDesc + Singlepnl.Panel_Type + " " + FrameTypeDesc;
                                    }
                                    else if (lst_LouverArtNoDistinctCheck.Count == 1)
                                    {
                                        wdm.WD_description = wdm.WD_profile + "\n" + lst_LouverArtNoDistinctCheck[0];
                                    }
                                    else
                                    {
                                        wdm.WD_description = wdm.WD_profile + "\n" + "LVRG-152-" + additionalZero + Singlepnl.Panel_LouverBladesCount + "-S-RH-BLK";
                                    }
                                }
                                else
                                {
                                    motorizeDesc = "";
                                    wdm.WD_description = wdm.WD_profile + "\n1 " + motorizeDesc + Singlepnl.Panel_Type + " " + FrameTypeDesc;
                                }

                                //GlassThickness & Glassfilm
                                if (Singlepnl.Panel_GlassThicknessDesc != null)
                                {
                                    if (Singlepnl.Panel_GlassFilm.ToString() != "None")
                                    {
                                        if (Singlepnl.Panel_Type.Contains("Louver"))
                                        {
                                            lst_glassThickness.Add(Singlepnl.Panel_GlassThicknessDesc + " Blades" + " with " + Singlepnl.Panel_GlassFilm.ToString() + "\n");
                                        }
                                        else
                                        {
                                            lst_glassThickness.Add(Singlepnl.Panel_GlassThicknessDesc + " with " + Singlepnl.Panel_GlassFilm.ToString() + "\n");
                                        }
                                    }
                                    else if (Singlepnl.Panel_Type.Contains("Louver"))
                                    {
                                        lst_glassThickness.Add("\n" + Singlepnl.Panel_GlassThicknessDesc + " Blades" + "\n");
                                    }
                                    else
                                    {
                                        lst_glassThickness.Add(Singlepnl.Panel_GlassThicknessDesc + "\n");
                                    }
                                }
                                else
                                {
                                    lst_glassThickness.Add(string.Empty);
                                }
                                //GeorgianBar
                                if (Singlepnl.Panel_GeorgianBarOptionVisibility == true)
                                {
                                    GeorgianBarHorizontalQty += Singlepnl.Panel_GeorgianBar_HorizontalQty;
                                    GeorgianBarVerticalQty += Singlepnl.Panel_GeorgianBar_VerticalQty;
                                    GeorgianBarArtNoDesc = Singlepnl.Panel_GeorgianBarArtNo.ToString();
                                }
                            }
                            #endregion
                            else
                            {
                                wdm.WD_description = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n" +
                                                     wdm.WD_profile;
                            }
                        }
                    }
                    else
                    {
                        wdm.WD_description = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n" +
                                             wdm.WD_profile;
                    }
                    #region DuplicatedItemListStringManipulation
                    //count duplicate in list
                    Dictionary<string, int> freqMap = lst_Description.GroupBy(x => x)
                                                        .Where(g => g.Count() > 1)
                                                        .ToDictionary(x => x.Key, x => x.Count());

                    string DuplicatePnlAndCount = String.Join("", freqMap);
                    if (DuplicatePnlAndCount != string.Empty)
                    {
                        string NewDuplicatePnlAndCount = DuplicatePnlAndCount.Replace("]", string.Empty);
                        NewDuplicatePnlAndCount = NewDuplicatePnlAndCount.Replace("[", "\n");
                        NewDuplicatePnlAndCount = NewDuplicatePnlAndCount.Replace(",", string.Empty);
                        string[] words = NewDuplicatePnlAndCount.Split('\n');

                        for (int a = 0; a < words.Length; a++)
                        {
                            if (a != 0)
                            {
                                string split1 = words[a],
                                       split2 = words[a + 1];
                                string DuplicatePnl = split1.Replace("1", split2.Replace(" ", string.Empty)) + "\n";

                                int pnlCount = Convert.ToInt32(split2.Replace(" ", string.Empty));

                                if (DuplicatePnl.Contains("LVRG"))
                                {
                                    string blades = string.Concat(split1.Where(Char.IsDigit));
                                    blades = blades.Replace("1150", "").Replace("1152", "");
                                    if (Convert.ToInt32(blades) >= 2 && Convert.ToInt32(blades) <= 9)
                                    {
                                        DuplicatePnl = DuplicatePnl.Remove(17, 1).Insert(17, "0");
                                    }
                                    else if (Convert.ToInt32(blades) >= 10)
                                    {
                                        DuplicatePnl = DuplicatePnl.Remove(17, 1).Insert(17, "1");
                                    }
                                }

                                if (DuplicatePnl.Contains("LVRG") &&
                                    (pnlCount >= 2 && pnlCount <= 9))
                                {
                                    string DuplicateLouverPnl = DuplicatePnl.Remove(13, 1).Insert(13, "1");
                                    lst_DuplicatePnl.Add(DuplicateLouverPnl);
                                }
                                else if (DuplicatePnl.Contains("LVRG") &&
                                     pnlCount >= 10)
                                {
                                    string DuplicateLouverPnl = DuplicatePnl.Remove(14, 1).Insert(14, "1");
                                    lst_DuplicatePnl.Add(DuplicateLouverPnl);
                                }
                                else
                                {
                                    lst_DuplicatePnl.Add(DuplicatePnl);
                                }
                                a++;
                            }
                        }
                    }
                    #endregion

                    #region NonDuplicatedItemListStringManipulation


                    //Not Duplicated Item
                    Dictionary<string, int> freqMap2 = lst_Description.GroupBy(a => a)
                                                   .Where(b => b.Count() == 1)
                                                   .ToDictionary(a => a.Key, a => a.Count());

                    string NoneDuplicatePnlAndCount = String.Join("", freqMap2);
                    NewNoneDuplicatePnlAndCount = NoneDuplicatePnlAndCount.Replace("[", string.Empty);
                    NewNoneDuplicatePnlAndCount = NewNoneDuplicatePnlAndCount.Replace(", 1]", string.Empty);
                    #endregion

                    List<string> lst_DescriptionDistinct = lst_Description.Distinct().ToList();

                    if (lst_DescriptionDistinct.Count != 0)
                    {
                        wdm.WD_description = wdm.WD_profile + "\n" + NewNoneDuplicatePnlAndCount;
                        for (int i = 0; i < lst_DuplicatePnl.Count; i++)
                        {
                            lst_DescDist = lst_DuplicatePnl[i];
                            wdm.WD_description += lst_DescDist;
                        }
                    }

                    List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();

                    if (lst_glassThicknessDistinct.Count > 1)
                    {
                        for (int i = 0; i < lst_glassThicknessDistinct.Count; i++)
                        {
                            glassThick += "(G" + (i + 1).ToString() + ")" + lst_glassThicknessDistinct[i];
                        }
                        wdm.WD_description += glassThick;
                        //lst_glassThicknessPerItem.Add(glassThick);
                    }
                    else if (lst_glassThicknessDistinct.Count == 1)
                    {
                        wdm.WD_description += lst_glassThicknessDistinct[0];
                    }

                    if (GeorgianBarHorizontalQty > 0)
                    {
                        GeorgianBarHorizontalDesc = "GeorgianBar Horizontal " + GeorgianBarArtNoDesc + " : " + GeorgianBarHorizontalQty + "\n";
                    }

                    if (GeorgianBarVerticalQty > 0)
                    {
                        GeorgianBarVerticalDesc = "GeorgianBar Vertical " + GeorgianBarArtNoDesc + " : " + GeorgianBarVerticalQty + "\n";
                    }

                    wdm.WD_description += GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc;

                    if (pnl_LouverChk == true)
                    {
                        wdm.WD_description += "Min. wall thickness is 225mm";
                    }

                    glassThick = string.Empty;
                    lst_glassThickness.Clear();
                    pnl_LouverChk = false;
                }
                GeorgianBarVerticalDesc = "";
                GeorgianBarHorizontalDesc = "";
                GeorgianBarHorizontalQty = 0;
                GeorgianBarVerticalQty = 0;
            }

        }
        public void ZoomIn()
        {
            int ndx_zoomPercentage = Array.IndexOf(_windoorModel.Arr_ZoomPercentage, _windoorModel.WD_zoom);

            if (ndx_zoomPercentage < _windoorModel.Arr_ZoomPercentage.Count() - 1)
            {
                ndx_zoomPercentage++;
                _windoorModel.WD_zoom = _windoorModel.Arr_ZoomPercentage[ndx_zoomPercentage];
                _windoorModel.SetDimensions_basePlatform();
                _windoorModel.SetZoom();
                _windoorModel.Fit_MyControls_ToBindDimensions();
                _windoorModel.Fit_MyControls_ImagersToBindDimensions();
                //FitControls_InsideMultiPanel();
                //Fit_MyControls_byControlsLocation();
            }
            _basePlatformPresenter.InvalidateBasePlatform();
            _basePlatformPresenter.Invalidate_flpMainControls();
        }
        public void ZoomOut()
        {
            int ndx_zoomPercentage = Array.IndexOf(_windoorModel.Arr_ZoomPercentage, _windoorModel.WD_zoom);

            if (ndx_zoomPercentage > 0)
            {
                ndx_zoomPercentage--;
                _windoorModel.WD_zoom = _windoorModel.Arr_ZoomPercentage[ndx_zoomPercentage];
                _windoorModel.SetDimensions_basePlatform();
                _windoorModel.SetZoom();
                _windoorModel.Fit_MyControls_ToBindDimensions();
                _windoorModel.Fit_MyControls_ImagersToBindDimensions();

                //FitControls_InsideMultiPanel();
                //Fit_MyControls_byControlsLocation();
            }
            _basePlatformPresenter.InvalidateBasePlatform();
            _basePlatformPresenter.Invalidate_flpMainControls();
        }
        public void GetCurrentPrice()
        {
            Run_GetListOfMaterials_SpecificItem();

            if (qoutationModel_MainPresenter.itemSelectStatus == true)
            {
                _quotationModel.BOMandItemlistStatus = "BOM";
            }
            else
            {
                _quotationModel.itemSelectStatus = false;
                _quotationModel.BOMandItemlistStatus = "PriceItemList";
            }
            if (ItemLoad == false)
            {
                _quotationModel.ItemCostingPriceAndPoints();
            }
            //GetMainView().GetCurrentPrice().Value = _quotationModel.CurrentPrice;
            GetMainView().GetCurrentPrice().Value = _windoorModel.WD_currentPrice;
            SetChangesMark();
        }

        public async void GetIntownOutofTown()
        {
            decimal value;
            string[] province = projectAddress.Split(',');
            value = await _quotationServices.GetFactorByProvince((province[province.Length - 2]).Trim());

            if (value == 1.30m)
            {
                _quotationModel.ProvinceIntownOrOutoftown = true;
            }
            else if (value == 1.40m)
            {
                _quotationModel.ProvinceIntownOrOutoftown = false;
            }

        }
        public void updatePriceFromMainViewToItemList()
        {
            if (_quotationModel != null)
            {
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    if (wdm.WD_Selected == true)
                    {
                        wdm.WD_price = _lblCurrentPrice.Value;
                    }
                }
            }
        }

        public void updatePriceOfMainView()
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                if (wdm.WD_Selected == true)
                {
                    _lblCurrentPrice.Value = wdm.WD_price;
                }
            }
        }
        private bool CheckAvailableDimensionFromBasePlatform(int frmDimension_numWd, int frmDimension_numHt)
        {
            int occupiedWidth = 0,
                occupiedHeight = 0,
                Maxheight = 0,
                availableWidth = _windoorModel.WD_width,
                availableHeight = _windoorModel.WD_height;
            bool isDimensionFit = true;

            foreach (var wndrObject in _windoorModel.lst_objects)
            {
                foreach (IFrameModel frm in _windoorModel.lst_frame)
                {
                    if (wndrObject.Name == frm.Frame_Name)
                    {
                        if (availableWidth >= frm.Frame_Width)
                        {

                            if (availableHeight >= frm.Frame_Height)
                            {
                                occupiedWidth += frm.Frame_Width;
                                if (Maxheight < frm.Frame_Height)
                                {
                                    Maxheight = frm.Frame_Height;
                                }
                            }
                            else
                            {
                                isDimensionFit = false;
                            }
                        }
                        if (occupiedWidth >= _windoorModel.WD_width)
                        {
                            occupiedHeight += Maxheight;
                            occupiedWidth = 0;
                            availableWidth = _windoorModel.WD_width;
                            availableHeight -= Maxheight;
                            Maxheight = 0;
                        }
                        else
                        {
                            if (availableHeight > frmDimension_numHt &&
                              (_windoorModel.WD_width - occupiedWidth) < frmDimension_numWd &&
                               _windoorModel.lst_frame.LastOrDefault().Frame_Name == frm.Frame_Name)
                            {
                                availableWidth = _windoorModel.WD_width;
                                occupiedHeight += frm.Frame_Height;
                                availableHeight -= frm.Frame_Height;
                                Maxheight = 0;
                            }
                            else
                            {
                                availableWidth -= frm.Frame_Width;
                            }

                        }
                    }

                }
                foreach (IConcreteModel crtm in _windoorModel.lst_concrete)
                {
                    if (wndrObject.Name == crtm.Concrete_Name)
                    {
                        if (availableWidth >= crtm.Concrete_Width)
                        {

                            if (availableHeight >= crtm.Concrete_Height)
                            {
                                occupiedWidth += crtm.Concrete_Width;
                                if (Maxheight < crtm.Concrete_Height)
                                {
                                    Maxheight = crtm.Concrete_Height;
                                }
                            }
                            else
                            {
                                isDimensionFit = false;
                            }

                        }
                        if (occupiedWidth >= _windoorModel.WD_width)
                        {
                            occupiedHeight += Maxheight;
                            occupiedWidth = 0;
                            availableWidth = _windoorModel.WD_width;
                            availableHeight -= Maxheight;
                            Maxheight = 0;
                        }
                        else
                        {


                            if (availableHeight > frmDimension_numHt &&
                                (_windoorModel.WD_width - occupiedWidth) < frmDimension_numWd &&
                               _windoorModel.lst_concrete.LastOrDefault().Concrete_Name == crtm.Concrete_Name)
                            {
                                availableWidth = _windoorModel.WD_width;
                                occupiedHeight += crtm.Concrete_Height;
                                availableHeight -= crtm.Concrete_Height;
                                Maxheight = 0;
                            }
                            else
                            {
                                availableWidth -= crtm.Concrete_Width;
                            }
                        }
                    }

                }
            }
            if (availableWidth < frmDimension_numWd || availableHeight < frmDimension_numHt)
            {
                isDimensionFit = false;

            }
            return isDimensionFit;
        }



        #endregion

    }
}