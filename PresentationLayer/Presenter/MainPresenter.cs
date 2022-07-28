using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.Costing_Head;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels.Thumbs;
using ServiceLayer.Services.ConcreteServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        #region GlobalVar

        IMainView _mainView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel; //currently selected item
        private IFrameModel _frameModel;
        private IConcreteModel _concreteModel;

        private ILoginView _loginView;
        private IItemInfoUC _itemInfoUC;
        private IFrameUC _frameUC;
        private IFramePropertiesUC _framePropertiesUC;

        private IQuotationServices _quotationServices;
        private IWindoorServices _windoorServices;
        private IFrameServices _frameServices;
        private IPanelServices _panelServices;
        private IConcreteServices _concreteServices;

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
        private ICostEngrLandingPresenter _ceLandingPresenter;
        private IConcreteUCPresenter _concreteUCPresenter;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private ISetTopViewSlidingPanellingPresenter _setTopViewSlidingPanellingPresenter;

        Panel _pnlMain, _pnlItems, _pnlPropertiesBody, _pnlControlSub;

        private FrameModel.Frame_Padding frameType;

        private int _quoteId;
        private string input_qrefno, _projectName, _custRefNo;
        private DateTime _quotationDate;

        CommonFunctions _commonfunc = new CommonFunctions();

        private DataTable _glassThicknessDT = new DataTable();
        private DataTable _glassTypeDT = new DataTable();
        private DataTable _spacerDT = new DataTable();
        private DataTable _colorDT = new DataTable();

        private ToolStripLabel _tsLblStatus;
        private ToolStrip _tsMain;
        private MenuStrip _msMainMenu;

        private Control _controlRaised_forDMSelection;
        private IDividerModel _divModel_forDMSelection;
        private IPanelModel _prevPanelModel_forDMSelection;
        private IPanelModel _nxtPanelModel_forDMSelection;
        private IDividerPropertiesUCPresenter _divPropUCP_forDMSelection;

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
                             ICostEngrLandingPresenter ceLandingPresenter,
                             IConcreteUCPresenter concreteUCPresenter,
                             IQuoteItemListPresenter quoteItemListPresenter,
                             IPrintQuotePresenter printQuotePresenter,
                             IQuoteItemListUCPresenter quoteItemListUCPresenter,
                             ISetTopViewSlidingPanellingPresenter setTopViewSlidingPanellingPresenter)
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
        }


        #region Events
        private void _mainView_slidingTopViewToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            ISetTopViewSlidingPanellingPresenter TopView = _setTopViewSlidingPanellingPresenter.CreateNewInstance(_unityC, this, _windoorModel);
            TopView.GetSetTopViewSlidingPanellingView().GetSetTopSlidingPanellingView();
        }


        private void _mainView_selectProjectToolStripMenuItemClickEventRaised1(object sender, EventArgs e)
        {
       
        }

        string wndrfile = "",
              searchStr = "",
              todo,
              mainTodo;
        public bool online_login = true;
        int x = 50;

        private void _mainView_saveToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            _mainView.mainview_title = _mainView.mainview_title.Replace("*", "");
            if (wndrfile != "")
            {
                string txtfile = wndrfile.Replace(".wndr", ".txt");
                //File.WriteAllLines(txtfile,);
                File.SetAttributes(txtfile, FileAttributes.Hidden);
                File.Delete(txtfile);
                if (online_login != true)
                {
                    int startFileName = txtfile.LastIndexOf("\\") + 1;
                    string outFile = txtfile.Substring(startFileName, txtfile.LastIndexOf(".") - startFileName) + ".wndr";
                    searchStr = outFile;
                    x = 50;
                    _mainView.GetToolStripLabelSync().Image = Properties.Resources.cloud_sync_40px;
                    _mainView.GetToolStripLabelSync().Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Please save your progress locally or online to prevent data loss", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _mainView_saveAsToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            _mainView.GetSaveFileDialog().FileName = this.inputted_quotationRefNo;
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
            //save btn event ilagay d2
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
                Bitmap bm = new Bitmap(_windoorModel.WD_width_4basePlatform_forImageRenderer, _windoorModel.WD_height_4basePlatform_forImageRenderer);
                UserControl basePl_imager = _basePlatformImagerUCPresenter.GetBasePlatformImagerUC() as UserControl;
                basePl_imager.DrawToBitmap(bm, new Rectangle(0, 0, _windoorModel.WD_width_4basePlatform_forImageRenderer, _windoorModel.WD_height_4basePlatform_forImageRenderer));
                //_mainView.SetImage(bm);
                _windoorModel.WD_image = bm;
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
                Scenario_Quotation(false, false, false, true, frmDimensionPresenter.Show_Purpose.CreateNew_Concrete, 0, 0, "");
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

        private void _mainView_ButtonPlusZoomClickEventRaised(object sender, EventArgs e)
        {
            int ndx_zoomPercentage = Array.IndexOf(_windoorModel.Arr_ZoomPercentage, _windoorModel.WD_zoom);

            if (ndx_zoomPercentage < _windoorModel.Arr_ZoomPercentage.Count() - 1)
            {
                ndx_zoomPercentage++;
                _windoorModel.WD_zoom = _windoorModel.Arr_ZoomPercentage[ndx_zoomPercentage];
                _windoorModel.SetDimensions_basePlatform();
                _windoorModel.SetZoom();

                FitControls_InsideMultiPanel();
                Fit_MyControls_byControlsLocation();
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

                FitControls_InsideMultiPanel();
                Fit_MyControls_byControlsLocation();
            }
            _basePlatformPresenter.InvalidateBasePlatform();
            _basePlatformPresenter.Invalidate_flpMainControls();
        }

        private void OnLabelSizeClickEventRaised(object sender, EventArgs e)
        {
            _frmDimensionPresenter.SetPresenters(this);
            _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.ChangeBasePlatformSize;
            _frmDimensionPresenter.SetProfileType(_windoorModel.WD_profile);
            _frmDimensionPresenter.SetHeight();
            _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);
            _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
        }

        private void OnCreateNewItemClickEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmItem = (ToolStripMenuItem)sender;
            if (tsmItem.Name == "C70ToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "C70 Profile");
            }
            else if (tsmItem.Name == "PremiLineToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "PremiLine Profile");
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
                    Scenario_Quotation(false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "");
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
                    Scenario_Quotation(true, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "");
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
            Scenario_Quotation(false, false, true, false, frmDimensionPresenter.Show_Purpose.CreateNew_Frame, 0, 0, "");
        }

        private void OnOpenToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            // dito ilagay ang loading ng wndr file
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

            _spacerDT.Rows.Add("Air");
            _spacerDT.Rows.Add("Argon");

            _colorDT.Rows.Add("Clear");
            _colorDT.Rows.Add("Tinted Gray");
            _colorDT.Rows.Add("Tinted Bronze");
            _colorDT.Rows.Add("Tinted Green");
        }

        #endregion

        #region ViewUpdate(Controls)

        private void Clearing_Operation()
        {
            _quotationModel = null;
            _pnlItems.Controls.Clear();
            _pnlPropertiesBody.Controls.Clear();
            _pnlMain.Controls.Clear();
            //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
            _basePlatformPresenter.RemoveBindingView();
            SetMainViewTitle("");
            CreateNewWindoorBtn_Disable();
            ItemToolStrip_Disable();
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
                                       frmDimensionPresenter.Show_Purpose purpose,
                                       int frmDimension_numWd,
                                       int frmDimension_numHt,
                                       string frmDimension_profileType)
        {
            if (frmDimension_numWd == 0 && frmDimension_numHt == 0) //from Quotation Input box to here
            {
                if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete)
                {
                    Clearing_Operation();
                }
                else if (QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && !AddedConcrete)
                {
                    SetMainViewTitle(input_qrefno, _projectName, _custRefNo);
                    ItemToolStrip_Enable();
                    _quotationModel = _quotationServices.AddQuotationModel(input_qrefno, _quotationDate, _quoteId);

                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.Quotation;
                    _frmDimensionPresenter.SetProfileType("C70 Profile");
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete)
                {
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.CreateNew_Item;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame && !AddedConcrete)
                {
                    _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = purpose;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedConcrete_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && AddedConcrete)
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
            }
            else if (frmDimension_numWd != 0 && frmDimension_numHt != 0) //from frmDimension to here
            {
                if (QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete)
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.Quotation)
                    {
                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         Base_Color._Ivory,
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
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete) //Add new Item
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Item)
                    {
                        Frame_Save_UserControl();
                        Frame_Save_PropertiesUC();

                        //clear previous basePlatformUC
                        _pnlMain.Controls.Clear();

                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         Base_Color._Ivory,
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
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame && !AddedConcrete) //add frame
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
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame && AddedConcrete) //add concrete
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

            //basePlatform
            _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, item, this);
            AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());
            _basePlatformPresenter.InvalidateBasePlatform();

            //frames
            foreach (IFrameModel frame in item.lst_frame)
            {
                _pnlPropertiesBody.Controls.Add((UserControl)frame.Frame_PropertiesUC);
                _basePlatformPresenter.AddFrame((IFrameUC)frame.Frame_UC);
            }
            _pnlPropertiesBody.Refresh();
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
                                  sash_art == SashProfile_ArticleNo._395))
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
                                !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581))
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
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581))
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
                                        !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._395))
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
                                      sash_art == SashProfile_ArticleNo._395))
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
                                    !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581))
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
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._7581))
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
                                            !(frame_art == FrameProfile_ArticleNo._7507 && sash_art == SashProfile_ArticleNo._395))
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
                foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                {
                    string gbmode = "";
                    bool same_sash = false;
                    SashProfile_ArticleNo ref_sash = mpnl.MPanelLst_Panel[0].Panel_SashProfileArtNo;
                    bool allWithSash = mpnl.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == true);
                    bool allNoSash = mpnl.MPanelLst_Panel.All(pnl => pnl.Panel_SashPropertyVisibility == false);

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
                        // mpanel.Fit_MyControls_ImagersToBindDimensions();
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

        #endregion

    }
}