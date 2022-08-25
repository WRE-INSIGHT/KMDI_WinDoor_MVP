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
        private ISortItemPresenter _sortItemPresenter;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private ISortItemUCPresenter _sortItemUCPresenter;
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
        private Base_Color baseColor;

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
                             ISetTopViewSlidingPanellingPresenter setTopViewSlidingPanellingPresenter,
                             ISortItemPresenter sortItemPresenter,
                             ISortItemUCPresenter sortItemUCPresenter)
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
            _sortItemPresenter = sortItemPresenter;
            _sortItemUCPresenter = sortItemUCPresenter;
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
        }

        private void _mainView_SortItemButtonClickEventRaised(object sender, EventArgs e)
        {
            ISortItemPresenter sortItem = _sortItemPresenter.GetNewInstance(_unityC, _quotationModel, _sortItemUCPresenter, _windoorModel, this);
            sortItem.GetSortItemView().showSortItem();
        }

        private void _mainView_ItemsDragEventRaiseEvent(object sender, DragEventArgs e)
        {
            Point p = _mainView.GetPanelItems().PointToClient(new Point(e.X, e.Y));
            var item = _mainView.GetPanelItems().GetChildAtPoint(p);
            int index = _mainView.GetPanelItems().Controls.GetChildIndex(item, false);
            //IItemInfoUC lbl = e.Data.GetData("PresentationLayer.Views.UserControls.ItemInfoUC") as IItemInfoUC;
            //foreach (IItemInfoUC ctrl in _mainView.GetPanelItems().Controls)
            //{
            //    if(lbl.WD_Item == ctrl.WD_Item)
            //    {
            //        _mainView.GetPanelItems().Controls.SetChildIndex((UserControl)ctrl, index);
            //        MessageBox.Show(ctrl.WD_Item);

            //    }
            //}
            _mainView.GetPanelItems().Controls.SetChildIndex((UserControl)_itemInfoUC, index);
            _mainView.GetPanelItems().Invalidate();
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


        #region Events
        private void _mainView_slidingTopViewToolStripMenuItemClickRaiseEvent(object sender, EventArgs e)
        {
            ISetTopViewSlidingPanellingPresenter TopView = _setTopViewSlidingPanellingPresenter.CreateNewInstance(_unityC, this, _windoorModel, _itemInfoUCPresenter);
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
                File.WriteAllLines(txtfile, Saving_dotwndr());
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
            saveToolStripButton_Click(sender, e);
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //saveToolStripButton.Enabled = false;
            //UppdateDictionaries();
            _mainView.mainview_title = _mainView.mainview_title.Replace("*", "");
            if (wndrfile != "")
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
            wndr_content.Add("Quotation_ref_no: " + _quotationModel.Quotation_ref_no);
            wndr_content.Add("Quotation_Date: " + _quotationModel.Quotation_Date);
            wndr_content.Add("Frame_PUFoamingQty_Total: " + _quotationModel.Frame_PUFoamingQty_Total);
            wndr_content.Add("Frame_SealantWHQty_Total: " + _quotationModel.Frame_SealantWHQty_Total);
            wndr_content.Add("Glass_SealantWHQty_Total: " + _quotationModel.Glass_SealantWHQty_Total);
            wndr_content.Add("GlazingSpacer_TotalQty: " + _quotationModel.GlazingSpacer_TotalQty);
            wndr_content.Add("GlazingSeal_TotalQty: " + _quotationModel.GlazingSeal_TotalQty);
            wndr_content.Add("Screws_for_Fabrication: " + _quotationModel.Screws_for_Fabrication);
            wndr_content.Add("Expansion_BoltQty_Total: " + _quotationModel.Expansion_BoltQty_Total);
            wndr_content.Add("Screws_for_Installation: " + _quotationModel.Screws_for_Installation);
            wndr_content.Add("Screws_for_Cladding: " + _quotationModel.Screws_for_Cladding);
            wndr_content.Add("Rebate_Qty: " + _quotationModel.Rebate_Qty);
            wndr_content.Add("Plastic_CoverQty_Total: " + _quotationModel.Plastic_CoverQty_Total);

            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                //float[] Arr_ZoomPercentage { get; }
                wndr_content.Add("(");
                wndr_content.Add("WD_profile: " + wdm.WD_profile);
                wndr_content.Add("WD_height: " + wdm.WD_height);
                wndr_content.Add("WD_BaseColor: " + wdm.WD_BaseColor);
                wndr_content.Add("WD_width: " + wdm.WD_width);
                wndr_content.Add("WD_name: " + wdm.WD_name);
                wndr_content.Add("WD_description: " + wdm.WD_description);
                wndr_content.Add("WD_discount: " + wdm.WD_discount);
                wndr_content.Add("WD_height_4basePlatform: " + wdm.WD_height_4basePlatform);
                wndr_content.Add("WD_height_4basePlatform_forImageRenderer: " + wdm.WD_height_4basePlatform_forImageRenderer);
                wndr_content.Add("WD_id: " + wdm.WD_id);
                wndr_content.Add("WD_orientation: " + wdm.WD_orientation);
                wndr_content.Add("WD_price: " + wdm.WD_price);
                wndr_content.Add("WD_quantity: " + wdm.WD_quantity);
                wndr_content.Add("WD_visibility: " + wdm.WD_visibility);
                wndr_content.Add("WD_width_4basePlatform: " + wdm.WD_width_4basePlatform);
                wndr_content.Add("WD_width_4basePlatform_forImageRenderer: " + wdm.WD_width_4basePlatform_forImageRenderer);
                wndr_content.Add("WD_zoom: " + wdm.WD_zoom);
                wndr_content.Add("WD_zoom_forImageRenderer: " + wdm.WD_zoom_forImageRenderer);
                wndr_content.Add("WD_PropertiesScroll: " + wdm.WD_PropertiesScroll);
                wndr_content.Add("WD_SlidingTopViewVisibility: " + wdm.WD_SlidingTopViewVisibility);
                //wndr_content.Add("frameIDCounter: " + wdm.frameIDCounter);
                wndr_content.Add("concreteIDCounter: " + wdm.concreteIDCounter);
                wndr_content.Add("panelIDCounter: " + wdm.panelIDCounter);
                wndr_content.Add("mpanelIDCounter: " + wdm.mpanelIDCounter);
                wndr_content.Add("divIDCounter: " + wdm.divIDCounter);
                wndr_content.Add("PanelGlassID_Counter: " + wdm.PanelGlassID_Counter);
                wndr_content.Add("WD_InsideColor: " + wdm.WD_InsideColor);
                wndr_content.Add("WD_OutsideColor: " + wdm.WD_OutsideColor);
                wndr_content.Add("WD_PlasticCover: " + wdm.WD_PlasticCover);
                wndr_content.Add("WD_CmenuDeleteVisibility: " + wdm.WD_CmenuDeleteVisibility);
                wndr_content.Add("WD_Selected: " + wdm.WD_Selected);
                wndr_content.Add("Lbl_ArrowHtCount: " + wdm.Lbl_ArrowHtCount);
                wndr_content.Add("Lbl_ArrowWdCount: " + wdm.Lbl_ArrowWdCount);
                wndr_content.Add("Div_ArrowCount: " + wdm.Div_ArrowCount);
                wndr_content.Add("WD_customArrowToggle: " + wdm.WD_customArrowToggle);
                wndr_content.Add("WD_CostingPoints: " + wdm.WD_CostingPoints);
                wndr_content.Add("WD_pboxImagerHeight: " + wdm.WD_pboxImagerHeight);
                foreach (IFrameModel frm in wdm.lst_frame)
                {
                    wndr_content.Add("{");
                    wndr_content.Add("\tFrame_Height: " + frm.Frame_Height);
                    wndr_content.Add("\tFrame_Width: " + frm.Frame_Width);
                    wndr_content.Add("\tFrame_Name: " + frm.Frame_Name);
                    wndr_content.Add("\tFrame_BasicDeduction: " + frm.Frame_BasicDeduction);
                    wndr_content.Add("\tFrame_HeightToBind: " + frm.Frame_HeightToBind);
                    wndr_content.Add("\tFrameImageRenderer_Height: " + frm.FrameImageRenderer_Height);
                    wndr_content.Add("\tFrame_ID: " + frm.Frame_ID);
                    wndr_content.Add("\tFrame_Type: " + frm.Frame_Type);
                    wndr_content.Add("\tFrame_WidthToBind: " + frm.Frame_WidthToBind);
                    wndr_content.Add("\tFrameImageRenderer_Width: " + frm.FrameImageRenderer_Width);
                    wndr_content.Add("\tFrame_Visible: " + frm.Frame_Visible);
                    wndr_content.Add("\tFrameProp_Height: " + frm.FrameProp_Height);
                    wndr_content.Add("\tFrameImageRenderer_Zoom: " + frm.FrameImageRenderer_Zoom);
                    wndr_content.Add("\tFrame_Zoom: " + frm.Frame_Zoom);
                    wndr_content.Add("\tFrame_BotFrameEnable: " + frm.Frame_BotFrameEnable);
                    wndr_content.Add("\tFrame_Deduction: " + frm.Frame_Deduction);
                    wndr_content.Add("\tFrame_ExplosionWidth: " + frm.Frame_ExplosionWidth);
                    wndr_content.Add("\tFrame_ExplosionHeight: " + frm.Frame_ExplosionHeight);
                    wndr_content.Add("\tFrame_ReinfWidth: " + frm.Frame_ReinfWidth);
                    wndr_content.Add("\tFrame_ReinfHeight: " + frm.Frame_ReinfHeight);
                    wndr_content.Add("\tFrame_CmenuDeleteVisibility: " + frm.Frame_CmenuDeleteVisibility);
                    wndr_content.Add("\tFrame_If_InwardMotorizedCasement: " + frm.Frame_If_InwardMotorizedCasement);
                    wndr_content.Add("\tFrame_MilledArtNo: " + frm.Frame_MilledArtNo);
                    wndr_content.Add("\tFrame_MilledReinfArtNo: " + frm.Frame_MilledReinfArtNo);
                    wndr_content.Add("\tFrame_ArtNo: " + frm.Frame_ArtNo);
                    wndr_content.Add("\tFrame_ReinfArtNo: " + frm.Frame_ReinfArtNo);

                    //IWindoorModel Frame_WindoorModel
                    //UserControl Frame_UC
                    //UserControl Frame_PropertiesUC
                    //BottomFrameTypes Frame_BotFrameArtNo
                    //Padding Frame_Padding_int
                    //Padding FrameImageRenderer_Padding_int
                    //List<IPanelModel> Lst_Panel
                    //List<IMultiPanelModel> Lst_MultiPanel
                    //List<IDividerModel> Lst_Divider
                    //int[] Arr_padding_norm { get; }
                    //int[] Arr_padding_withmpnl { get; }
                    //int Add_framePerimeter_screws4fab();
                    //int Add_MilledFrameWidth_screws4fab();
                    foreach (IPanelModel pnl in frm.Lst_Panel)
                    {
                        wndr_content.Add("\t#");
                        wndr_content.Add("\t\tPanel_ChkText: " + pnl.Panel_ChkText);
                        wndr_content.Add("\t\tPanel_Dock: " + pnl.Panel_Dock);
                        wndr_content.Add("\t\tPanel_Parent: " + pnl.Panel_Parent);
                        wndr_content.Add("\t\tPanel_MultiPanelGroup: " + pnl.Panel_MultiPanelGroup);
                        wndr_content.Add("\t\tPanel_FrameGroup: " + pnl.Panel_FrameGroup);
                        wndr_content.Add("\t\tPanel_FramePropertiesGroup: " + pnl.Panel_FramePropertiesGroup);
                        wndr_content.Add("\t\tPanel_Height: " + pnl.Panel_Height);
                        wndr_content.Add("\t\tPanel_OriginalHeight: " + pnl.Panel_OriginalHeight);
                        wndr_content.Add("\t\tPanelImageRenderer_Height: " + pnl.PanelImageRenderer_Height);
                        wndr_content.Add("\t\tPanel_HeightToBind: " + pnl.Panel_HeightToBind);
                        wndr_content.Add("\t\tPanel_DisplayHeight: " + pnl.Panel_DisplayHeight);
                        wndr_content.Add("\t\tPanel_DisplayHeightDecimal: " + pnl.Panel_DisplayHeightDecimal);
                        wndr_content.Add("\t\tPanel_OriginalDisplayHeight: " + pnl.Panel_OriginalDisplayHeight);
                        wndr_content.Add("\t\tPanel_OriginalDisplayHeightDecimal: " + pnl.Panel_OriginalDisplayHeightDecimal);
                        wndr_content.Add("\t\tPanel_ID: " + pnl.Panel_ID);
                        wndr_content.Add("\t\tPanel_Name: " + pnl.Panel_Name);
                        wndr_content.Add("\t\tPanel_Orient: " + pnl.Panel_Orient);
                        wndr_content.Add("\t\tPanel_OrientVisibility: " + pnl.Panel_OrientVisibility);
                        wndr_content.Add("\t\tPanel_Type: " + pnl.Panel_Type);
                        wndr_content.Add("\t\tPanel_Width: " + pnl.Panel_Width);
                        wndr_content.Add("\t\tPanel_OriginalWidth: " + pnl.Panel_OriginalWidth);
                        wndr_content.Add("\t\tPanelImageRenderer_Width: " + pnl.PanelImageRenderer_Width);
                        wndr_content.Add("\t\tPanel_WidthToBind: " + pnl.Panel_WidthToBind);
                        wndr_content.Add("\t\tPanel_DisplayWidth: " + pnl.Panel_DisplayWidth);
                        wndr_content.Add("\t\tPanel_DisplayWidthDecimal: " + pnl.Panel_DisplayWidthDecimal);
                        wndr_content.Add("\t\tPanel_OriginalDisplayWidth: " + pnl.Panel_OriginalDisplayWidth);
                        wndr_content.Add("\t\tPanel_OriginalDisplayWidthDecimal: " + pnl.Panel_OriginalDisplayWidthDecimal);
                        wndr_content.Add("\t\tPanel_Visibility: " + pnl.Panel_Visibility);
                        wndr_content.Add("\t\tPanelImageRenderer_Zoom: " + pnl.PanelImageRenderer_Zoom);
                        wndr_content.Add("\t\tPanel_Index_Inside_MPanel: " + pnl.Panel_Index_Inside_MPanel);
                        wndr_content.Add("\t\tPanel_Index_Inside_SPanel: " + pnl.Panel_Index_Inside_SPanel);
                        wndr_content.Add("\t\tPanel_Placement: " + pnl.Panel_Placement);
                        wndr_content.Add("\t\tPanel_Overlap_Sash: " + pnl.Panel_Overlap_Sash);
                        wndr_content.Add("\t\tPanel_Margin: " + pnl.Panel_Margin);
                        wndr_content.Add("\t\tPanel_MarginToBind: " + pnl.Panel_MarginToBind);
                        wndr_content.Add("\t\tPanelImageRenderer_Margin: " + pnl.PanelImageRenderer_Margin);
                        wndr_content.Add("\t\tPanel_Zoom: " + pnl.Panel_Zoom);
                        wndr_content.Add("\t\tPanel_ParentMultiPanelModel: " + pnl.Panel_ParentMultiPanelModel);
                        wndr_content.Add("\t\tPanel_PropertyHeight: " + pnl.Panel_PropertyHeight);
                        wndr_content.Add("\t\tPanel_HandleOptionsVisibility: " + pnl.Panel_HandleOptionsVisibility);
                        wndr_content.Add("\t\tPanel_RotoswingOptionsVisibility: " + pnl.Panel_RotoswingOptionsVisibility);
                        wndr_content.Add("\t\tPanel_RioOptionsVisibility: " + pnl.Panel_RioOptionsVisibility);
                        wndr_content.Add("\t\tPanel_RioOptionsVisibility2: " + pnl.Panel_RioOptionsVisibility2);
                        wndr_content.Add("\t\tPanel_RotolineOptionsVisibility: " + pnl.Panel_RotolineOptionsVisibility);
                        wndr_content.Add("\t\tPanel_MVDOptionsVisibility: " + pnl.Panel_MVDOptionsVisibility);
                        wndr_content.Add("\t\tPanel_RotaryOptionsVisibility: " + pnl.Panel_RotaryOptionsVisibility);
                        wndr_content.Add("\t\tPanel_HandleOptionsHeight: " + pnl.Panel_HandleOptionsHeight);
                        wndr_content.Add("\t\tPanel_LouverBladesCount: " + pnl.Panel_LouverBladesCount);
                        wndr_content.Add("\t\tPanel_BackColor: " + pnl.Panel_BackColor);
                        wndr_content.Add("\t\tPanel_SlidingTypes: " + pnl.Panel_SlidingTypes);
                        wndr_content.Add("\t\tPanel_SlidingTypeVisibility: " + pnl.Panel_SlidingTypeVisibility);
                        #region Explosion

                        //int PanelGlass_ID
                        //string Panel_GlassThicknessDesc
                        //float Panel_GlassThickness
                        //GlazingBead_ArticleNo PanelGlazingBead_ArtNo
                        //GlazingAdaptor_ArticleNo Panel_GlazingAdaptorArtNo
                        //GBSpacer_ArticleNo Panel_GBSpacerArtNo
                        //bool Panel_ChkGlazingAdaptor
                        //int Panel_GlazingBeadWidth
                        //int Panel_GlazingBeadWidthDecimal
                        //int Panel_GlazingBeadHeight
                        //int Panel_GlazingBeadHeightDecimal
                        //int Panel_GlassWidth
                        //int Panel_GlassWidthDecimal
                        //int Panel_OriginalGlassWidth
                        //int Panel_OriginalGlassWidthDecimal
                        //int Panel_GlassHeight
                        //int Panel_GlassHeightDecimal
                        //int Panel_OriginalGlassHeight
                        //int Panel_OriginalGlassHeightDecimal
                        //int Panel_GlassPropertyHeight
                        //int Panel_GlazingSpacerQty
                        //GlassFilm_Types Panel_GlassFilm
                        //bool Panel_SashPropertyVisibility
                        //SashProfile_ArticleNo Panel_SashProfileArtNo
                        //SashReinf_ArticleNo Panel_SashReinfArtNo
                        //int Panel_SashWidth
                        //int Panel_SashWidthDecimal
                        //int Panel_SashHeight
                        //int Panel_SashHeightDecimal
                        //int Panel_OriginalSashWidth
                        //int Panel_OriginalSashWidthDecimal
                        //int Panel_OriginalSashHeight
                        //int Panel_OriginalSashHeightDecimal
                        //int Panel_SashReinfWidth
                        //int Panel_SashReinfWidthDecimal
                        //int Panel_SashReinfHeight
                        //int Panel_SashReinfHeightDecimal

                        //CoverProfile_ArticleNo Panel_CoverProfileArtNo
                        //CoverProfile_ArticleNo Panel_CoverProfileArtNo2
                        //FrictionStay_ArticleNo Panel_FrictionStayArtNo
                        //FrictionStayCasement_ArticleNo Panel_FSCasementArtNo
                        //SnapInKeep_ArticleNo Panel_SnapInKeepArtNo
                        //FixedCam_ArticleNo Panel_FixedCamArtNo
                        //_30x25Cover_ArticleNo Panel_30x25CoverArtNo
                        //MotorizedDivider_ArticleNo Panel_MotorizedDividerArtNo
                        //CoverForMotor_ArticleNo Panel_CoverForMotorArtNo
                        //_2DHinge_ArticleNo Panel_2dHingeArtNo
                        //PushButtonSwitch_ArticleNo Panel_PushButtonSwitchArtNo
                        //FalsePole_ArticleNo Panel_FalsePoleArtNo
                        //SupportingFrame_ArticleNo Panel_SupportingFrameArtNo
                        //Plate_ArticleNo Panel_PlateArtNo

                        //Handle_Type Panel_HandleType
                        //Rotoswing_HandleArtNo Panel_RotoswingArtNo
                        //Rotary_HandleArtNo Panel_RotaryArtNo
                        //Rio_HandleArtNo Panel_RioArtNo
                        //Rio_HandleArtNo Panel_RioArtNo2
                        //ProfileKnobCylinder_ArtNo Panel_ProfileKnobCylinderArtNo
                        //Cylinder_CoverArtNo Panel_CylinderCoverArtNo

                        //Rotoline_HandleArtNo Panel_RotolineArtNo
                        //MVD_HandleArtNo Panel_MVDArtNo
                        //Espagnolette_ArticleNo Panel_EspagnoletteArtNo
                        //bool Panel_EspagnoletteOptionsVisibility

                        //Extension_ArticleNo Panel_ExtensionTopArtNo
                        //Extension_ArticleNo Panel_ExtensionTop2ArtNo
                        //Extension_ArticleNo Panel_ExtensionTop3ArtNo
                        //Extension_ArticleNo Panel_ExtensionBotArtNo
                        //Extension_ArticleNo Panel_ExtensionBot2ArtNo
                        //Extension_ArticleNo Panel_ExtensionLeftArtNo
                        //Extension_ArticleNo Panel_ExtensionLeft2ArtNo
                        //Extension_ArticleNo Panel_ExtensionRightArtNo
                        //Extension_ArticleNo Panel_ExtensionRight2ArtNo

                        //bool Panel_ExtTopChk
                        //bool Panel_ExtTop2Chk
                        //bool Panel_ExtBotChk
                        //bool Panel_ExtLeftChk

                        //bool Panel_ExtRightChk
                        //int Panel_ExtTopQty
                        //int Panel_ExtBotQty
                        //int Panel_ExtLeftQty
                        //int Panel_ExtRightQty

                        //int Panel_ExtTop2Qty
                        //int Panel_ExtTop3Qty
                        //int Panel_ExtBot2Qty
                        //int Panel_ExtLeft2Qty
                        //int Panel_ExtRight2Qty

                        //CornerDrive_ArticleNo Panel_CornerDriveArtNo
                        //bool Panel_CornerDriveOptionsVisibility
                        //bool Panel_ExtensionOptionsVisibility
                        //int Panel_RotoswingOptionsHeight
                        //PlasticWedge_ArticleNo Panel_PlasticWedge
                        //int Panel_PlasticWedgeQty
                        //MiddleCloser_ArticleNo Panel_MiddleCloserArtNo
                        //LockingKit_ArticleNo Panel_LockingKitArtNo
                        //GlassType Panel_GlassType

                        //Striker_ArticleNo Panel_StrikerArtno_A //for Awning
                        //int Panel_StrikerQty_A

                        //Striker_ArticleNo Panel_StrikerArtno_C //for Casement
                        //int Panel_StrikerQty_C

                        //int Panel_MiddleCloserPairQty
                        //bool Panel_MotorizedOptionVisibility
                        //MotorizedMech_ArticleNo Panel_MotorizedMechArtNo
                        //int Panel_MotorizedPropertyHeight
                        //int Panel_MotorizedMechQty
                        //int Panel_MotorizedMechSetQty
                        //int Panel_2DHingeQty
                        //_2DHinge_ArticleNo Panel_2dHingeArtNo_nonMotorized
                        //int Panel_2DHingeQty_nonMotorized
                        //bool Panel_2dHingeVisibility_nonMotorized
                        //_3dHinge_ArticleNo Panel_3dHingeArtNo
                        //int Panel_3dHingeQty
                        //bool Panel_3dHingePropertyVisibility
                        //ButtHinge_ArticleNo Panel_ButtHingeArtNo
                        //int Panel_ButtHingeQty
                        //bool Panel_2dHingeVisibility
                        //bool Panel_ButtHingeVisibility
                        //AdjustableStriker_ArticleNo Panel_AdjStrikerArtNo
                        //int Panel_AdjStrikerQty
                        //RestrictorStay_ArticleNo Panel_RestrictorStayArtNo
                        //int Panel_RestrictorStayQty

                        //int Panel_ExtensionPropertyHeight
                        //GeorgianBar_ArticleNo Panel_GeorgianBarArtNo
                        //int Panel_GeorgianBar_VerticalQty
                        //int Panel_GeorgianBar_HorizontalQty
                        //bool Panel_GeorgianBarOptionVisibility

                        //HingeOption Panel_HingeOptions
                        //int Panel_HingeOptionsPropertyHeight
                        //bool Panel_HingeOptionsVisibility
                        //CenterHingeOption Panel_CenterHingeOptions
                        //bool Panel_CenterHingeOptionsVisibility
                        //NTCenterHinge_ArticleNo Panel_NTCenterHingeArticleNo
                        //StayBearingK_ArticleNo Panel_StayBearingKArtNo
                        //StayBearingPin_ArticleNo Panel_StayBearingPinArtNo
                        //StayBearingCover_ArticleNo Panel_StayBearingCoverArtNo
                        //TopCornerHinge_ArticleNo Panel_TopCornerHingeArtNo
                        //TopCornerHingeCover_ArticleNo Panel_TopCornerHingeCoverArtNo
                        //TopCornerHingeSpacer_ArticleNo Panel_TopCornerHingeSpacerArtNo
                        //CornerHingeK_ArticleNo Panel_CornerHingeKArtNo
                        //CornerPivotRestK_ArticleNo Panel_CornerPivotRestKArtNo
                        //CornerHingeCoverK_ArticleNo Panel_CornerHingeCoverKArtNo
                        //CoverForCornerPivotRestVertical_ArticleNo Panel_CoverForCornerPivotRestVerticalArtNo
                        //CoverForCornerPivotRest_ArticleNo Panel_CoverForCornerPivotRestArtNo
                        //WeldableCornerJoint_ArticleNo Panel_WeldableCArtNo
                        //LatchDeadboltStriker_ArticleNo Panel_LatchDeadboltStrikerArtNo

                        //bool Panel_CmenuDeleteVisibility
                        //bool Panel_NTCenterHingeVisibility
                        //bool Panel_MiddleCloserVisibility

                        //bool Panel_MotorizedpnlOptionVisibility

                        //int Add_SashPerimeter_screws4fab();
                        //int Add_StrikerAC_screws4fab();
                        //int Add_Espagnolette_screws4fab();
                        //int Add_Extension_screws4fab();
                        //int Add_FSCasement_screws4fab();
                        //int Add_FGAwning_screws4fab();
                        //int Add_Hinges_screws4fab();
                        //int Add_MotorizedMech_screws4Inst();
                        #endregion
                    }
                    foreach (IMultiPanelModel mpnl in frm.Lst_MultiPanel)
                    {
                        foreach (IDividerModel dvd in mpnl.MPanelLst_Divider)
                        {
                        }
                        foreach (IPanelModel pnl in frm.Lst_Panel)
                        {
                        }
                    }
                    wndr_content.Add("}");
                }
                foreach (IConcreteModel crm in wdm.lst_concrete)
                {

                }
                wndr_content.Add(")");

                //float GetZoom_forRendering();
                //Dictionary<int, decimal> Dictionary_ht_redArrowLines
                //Dictionary<int, decimal> Dictionary_wd_redArrowLines
                //Dictionary<int, int> Div_ArrowWdLengthList

            }
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
            if (MessageBox.Show("Are you sure want to delete " + _windoorModel.WD_name + "?", "Delete Item",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_quotationModel != null)
                {

                    foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                    {
                        if (wdm == _windoorModel)
                        {
                            foreach(IItemInfoUC itemInfo in _pnlItems.Controls)
                            {
                                if(itemInfo.WD_Selected == true)
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
                //_mainView.GetOpenFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
                if (_mainView.GetOpenFileDialog().ShowDialog() == DialogResult.OK)
                {
                    Clearing_Operation();
                    wndrfile = _mainView.GetOpenFileDialog().FileName;

                    csfunc.DecryptFile(wndrfile);

                    int startFileName = wndrfile.LastIndexOf("\\") + 1;
                    string outFile = wndrfile.Substring(0, startFileName) +
                                     wndrfile.Substring(startFileName, wndrfile.LastIndexOf(".") - startFileName) + ".txt";

                    file_lines = File.ReadAllLines(outFile);
                    File.SetAttributes(outFile, FileAttributes.Hidden);
                    onload = true;
                    _mainView.GetTsProgressLoading().Maximum = file_lines.Length;
                    StartWorker("Open_WndrFiles");
                    

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
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.DoWork += Bgw_DoWork;
        }

        #endregion
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
        bool inside_quotation, inside_item, inside_frame, inside_panel, inside_multi, inside_divider;
        int frmDimension_numWd = 0,
            frmDimension_numHt = 0;
        string frmDimension_profileType = "",
               frmDimension_baseColor = "";
        bool ons = false;
        private void Opening_dotwndr(int row)
        {
            string row_str = file_lines[row].Replace("\t", "");
            Console.WriteLine(row_str);
            //if (row == 0)
            //{
            //    quotation_ref_no = Text = file_lines[0];
            //}
           

            if (row_str.Contains("Quotation_ref_no"))
            {
                inside_quotation = true;
            }
            else if (row_str == "(")
            {
                inside_item = true;
            }
            else if (row_str == "{")
            {
                inside_frame = true;

            }
            else if (row_str.Contains("PanelName"))
            {
                inside_panel = true;
            }
            else if (row_str.Contains("MultiName"))
            {
                inside_multi = true;
            }
            else if (row_str.Contains("DivdName"))
            {
                inside_divider = true;
            }
            else if (row_str.Contains("DivdName"))
            {
                inside_divider = true;
            }
            else if (row_str == "}")
            {
                frmDimension_numWd = 0; ;
                frmDimension_numHt = 0;
                frmDimension_profileType = "";
                frmDimension_baseColor = "";
                //if (inside_frame)
                //{
                //    frname = "";
                //    frwidth = 0;
                //    frheight = 0;
                //    frwndr = 0;
                //    inside_frame = false;
                //}
                //else if (inside_panel)
                //{
                //    pnlwidth = 0;
                //    pnlheight = 0;
                //    pnlwndrtype = "";
                //    pnl_Orientation = "";
                //    pnl_Parent = "";
                //    frameGroup = "";
                //    inside_panel = false;
                //}
                //else if (inside_multi)
                //{
                //    multi_Name = "";
                //    multi_Size = "";
                //    multidivnum = "";
                //    multi_Tabindex = 0;
                //    multi_type = "";
                //    multi_Parent = "";
                //    inside_multi = false;
                //}
                //else if (inside_divider)
                //{
                //    divd_name = "";
                //    divd_width = 0;
                //    divd_height = 0;
                //    divd_TabIndex = 0;
                //    divd_Parent = "";
                //    inside_divider = false;
                //}
            }
            else if (row_str == ")")
            {
              
                ////Panel_Painter();

                //trkZoom.Value = (int)(fzoom * 100.0f);
                //trkZoom_ValueChanged(new object(), new EventArgs());

                //refreshToolStripButton.PerformClick();
                //UppdateDictionaries();
                //fpwidth = 0;
                //fpheight = 0;
                //fptype = "";
                //fstatus = "";
                //fName = "";
                //fprice = 0.0M;
                //fqty = 0;
                //fdiscount = 0.0M;
                //fzoom = 0.0f;
                //fdesc = "";

                //itemControlsSearch("lbldesc");

                //pnlPropertiesBody.VerticalScroll.Value = pnlPropertiesBody.VerticalScroll.Maximum;
                //pnlPropertiesBody.PerformLayout();

                ////Label lbl = new Label();
                ////lbl = itemControlsSearch("lbldesc");
                ////lbl.Text = UpdateLblDescription(lbl.AccessibleDescription);
            }

            switch (inside_quotation)
            {
                case true:
                    if (row_str.Contains("QuoteId"))
                    {
                        _quoteId = Convert.ToInt32(row_str.Substring(9));
                    }
                    else if (row_str.Contains("ProjectName"))
                    {
                        _projectName = row_str.Substring(13);
                    }
                    else if (row_str.Contains("CustomerRefNo"))
                    {
                        _custRefNo = row_str.Substring(15);
                    }
                    else if (row_str.Contains("Quotation_ref_no"))
                    {
                        inputted_quotationRefNo = row_str.Substring(18);
                    }
                    else if (row_str.Contains("Quotation_Date"))
                    {
                        inputted_quoteDate = Convert.ToDateTime(row_str.Substring(16));
                        Scenario_Quotation(false, false, false, false, true, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                    }
                    else if (row_str.Contains("Frame_PUFoamingQty_Total"))
                    {
                        _quotationModel.Frame_PUFoamingQty_Total = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("Frame_SealantWHQty_Total"))
                    {
                        _quotationModel.Frame_SealantWHQty_Total = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("Glass_SealantWHQty_Total"))
                    {
                        _quotationModel.Glass_SealantWHQty_Total = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("GlazingSpacer_TotalQty"))
                    {
                        _quotationModel.GlazingSpacer_TotalQty = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("GlazingSeal_TotalQty"))
                    {
                        _quotationModel.GlazingSeal_TotalQty = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("Screws_for_Fabrication"))
                    {
                        _quotationModel.Screws_for_Fabrication = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("Expansion_BoltQty_Total"))
                    {
                        _quotationModel.Expansion_BoltQty_Total = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);

                    }
                    else if (row_str.Contains("Screws_for_Installation"))
                    {
                        _quotationModel.Screws_for_Installation = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);

                    }
                    else if (row_str.Contains("Screws_for_Cladding"))
                    {
                        _quotationModel.Screws_for_Cladding = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                    }
                    else if (row_str.Contains("Rebate_Qty"))
                    {
                        _quotationModel.Rebate_Qty = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        inside_quotation = false;
                    }
                    break;
                case false:
                    if (inside_item)
                    {
                        
                        if (row_str.Contains("WD_profile"))
                        {
                            frmDimension_profileType = row_str.Substring(12);
                        }
                        if (row_str.Contains("WD_height:"))
                        {
                            frmDimension_numHt = Convert.ToInt32(row_str.Substring(10));
                        }
                        if (row_str.Contains("WD_BaseColor"))
                        {
                            frmDimension_baseColor = row_str.Substring(14);
                        }
                        if (row_str.Contains("WD_width:"))
                        {
                            frmDimension_numWd = Convert.ToInt32(row_str.Substring(10));
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
                        //if (row_str.Contains("WD_name"))
                        //{
                        //    _windoorModel.WD_name = row_str.Substring(9);
                        //}
                        //if (row_str.Contains("WD_description"))
                        //{
                        //    _windoorModel.WD_description = row_str.Substring(16);
                        //}

                        //if (row_str.Contains("WD_discount"))
                        //{
                        //    //_windoorModel.WD_discount = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}

                        //if (row_str.Contains("WD_height_4basePlatform"))
                        //{
                        //    _windoorModel.WD_height_4basePlatform = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        //if (row_str.Contains("WD_height_4basePlatform_forImageRenderer"))
                        //{
                        //    _windoorModel.WD_height_4basePlatform_forImageRenderer = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        //if (row_str.Contains("WD_id"))
                        //{
                        //    _windoorModel.WD_id = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}

                        //if (row_str.Contains("WD_orientation"))
                        //{
                        //    //_windoorModel.WD_orientation = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        //if (row_str.Contains("WD_price"))
                        //{
                        //    _windoorModel.WD_price = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        //if (row_str.Contains("WD_quantity"))
                        //{
                        //    _windoorModel.WD_quantity = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        //if (row_str.Contains("WD_visibility"))
                        //{
                        //    //_windoorModel.WD_visibility = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}

                        if (row_str.Contains("WD_width_4basePlatform"))
                        {
                            //_windoorModel.WD_width_4basePlatform = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_width_4basePlatform_forImageRenderer"))
                        {
                            //_windoorModel.WD_width_4basePlatform_forImageRenderer = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_zoom"))
                        {
                            //_windoorModel.WD_zoom = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_zoom_forImageRenderer"))
                        {
                            //_windoorModel.WD_zoom_forImageRenderer = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_PropertiesScroll"))
                        {
                            _windoorModel.WD_PropertiesScroll = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_SlidingTopViewVisibility"))
                        {
                            _windoorModel.WD_SlidingTopViewVisibility = Convert.ToBoolean(row_str.Substring(29));
                        }
                        if (row_str.Contains("frameIDCounter"))
                        {
                            //_windoorModel.frameIDCounter = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("concreteIDCounter"))
                        {
                            _windoorModel.concreteIDCounter = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("panelIDCounter"))
                        {
                            _windoorModel.panelIDCounter = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("mpanelIDCounter"))
                        {
                            _windoorModel.mpanelIDCounter = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("divIDCounter"))
                        {
                            _windoorModel.divIDCounter = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("PanelGlassID_Counter"))
                        {
                            _windoorModel.PanelGlassID_Counter = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }

                        if (row_str.Contains("WD_InsideColor"))
                        {
                            foreach (Foil_Color color in Foil_Color.GetAll())
                            {
                                string asd = row_str.Substring(16);
                                if (color.ToString() == row_str.Substring(16))
                                {
                                    _windoorModel.WD_InsideColor = color;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("WD_OutsideColor"))
                        {
                            foreach (Foil_Color color in Foil_Color.GetAll())
                            {
                                if (color.ToString() == row_str.Substring(16))
                                {
                                    _windoorModel.WD_OutsideColor = color;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("WD_PlasticCover"))
                        {
                            _windoorModel.WD_PlasticCover = Convert.ToDecimal(row_str.Substring(17));
                        }
                        if (row_str.Contains("WD_CmenuDeleteVisibility"))
                        {
                            _windoorModel.WD_CmenuDeleteVisibility = Convert.ToBoolean(row_str.Substring(26));
                        }
                        if (row_str.Contains("WD_Selected"))
                        {
                            _windoorModel.WD_Selected = Convert.ToBoolean(row_str.Substring(13));
                        }
                        if (row_str.Contains("Lbl_ArrowHtCount"))
                        {
                            _windoorModel.Lbl_ArrowHtCount = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Lbl_ArrowWdCount"))
                        {
                            _windoorModel.Lbl_ArrowWdCount = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Div_ArrowCount"))
                        {
                            _windoorModel.Div_ArrowCount = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_customArrowToggle"))
                        {
                            _windoorModel.WD_customArrowToggle = Convert.ToBoolean(row_str.Substring(22));
                        }
                        if (row_str.Contains("WD_CostingPoints"))
                        {
                            _windoorModel.WD_CostingPoints = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("WD_pboxImagerHeight"))
                        {
                            _windoorModel.WD_pboxImagerHeight = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                            inside_item = false;
                        }
                    }
                    else if (inside_frame)
                    {
                        if (row_str.Contains("Frame_Height:"))
                        {
                            frmDimension_numHt = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_Width:"))
                        {
                            frmDimension_numWd = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
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
                        if (row_str.Contains("Frame_BasicDeduction"))
                        {
                            Console.WriteLine(row_str);
                        }
                        if (row_str.Contains("Frame_HeightToBind"))
                        {
                            //_frameModel.Frame_HeightToBind = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);

                        }
                        if (row_str.Contains("FrameImageRenderer_Height"))
                        {
                            //_frameModel.FrameImageRenderer_Height = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_ID"))
                        {
                            _frameModel.Frame_ID = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_Type"))
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
                        if (row_str.Contains("Frame_Name"))
                        {
                            _frameModel.Frame_Name = row_str.Substring(12);
                        }

                        if (row_str.Contains("Frame_WidthToBind"))
                        {
                            //_frameModel.Frame_WidthToBind = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("FrameImageRenderer_Width"))
                        {
                            //_frameModel.FrameImageRenderer_Width = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_Visible"))
                        {
                            _frameModel.Frame_Visible = Convert.ToBoolean(row_str.Substring(15));
                        }
                        if (row_str.Contains("FrameProp_Height"))
                        {
                            _frameModel.FrameProp_Height = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        //if (row_str.Contains("FrameImageRenderer_Zoom"))
                        //{
                        //    _frameModel.FrameImageRenderer_Zoom = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        //if (row_str.Contains("Frame_Zoom"))
                        //{
                        //    _frameModel.Frame_Zoom = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        //}
                        if (row_str.Contains("Frame_BotFrameEnable"))
                        {
                            _frameModel.Frame_BotFrameEnable = Convert.ToBoolean(row_str.Substring(22));
                        }
                        if (row_str.Contains("Frame_Deduction"))
                        {
                        }
                        if (row_str.Contains("Frame_ExplosionWidth"))
                        {
                            _frameModel.Frame_ExplosionWidth = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_ExplosionHeight"))
                        {
                            _frameModel.Frame_ExplosionHeight = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_ReinfWidth"))
                        {
                            _frameModel.Frame_ReinfWidth = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_ReinfHeight"))
                        {
                            _frameModel.Frame_ReinfHeight = Convert.ToInt32(Regex.Match(row_str, @"\d+").Value);
                        }
                        if (row_str.Contains("Frame_CmenuDeleteVisibility"))
                        {
                            _frameModel.Frame_CmenuDeleteVisibility = Convert.ToBoolean(row_str.Substring(29));
                        }
                        if (row_str.Contains("Frame_If_InwardMotorizedCasement"))
                        {
                            _frameModel.Frame_If_InwardMotorizedCasement = Convert.ToBoolean(row_str.Substring(34));
                        }
                        if (row_str.Contains("Frame_MilledArtNo:"))
                        {
                            foreach (MilledFrame_ArticleNo artcNo in MilledFrame_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == row_str.Substring(19))
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
                                if (artcNo.ToString() == row_str.Substring(24))
                                {
                                    _frameModel.Frame_MilledReinfArtNo = artcNo;
                                    break;
                                }
                            }
                        }
                        if (row_str.Contains("Frame_ArtNo:"))
                        {
                            foreach (FrameProfile_ArticleNo artcNo in FrameProfile_ArticleNo.GetAll())
                            {
                                if (artcNo.ToString() == row_str.Substring(13))
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
                                if (artcNo.ToString() == row_str.Substring(18))
                                {
                                    _frameModel.Frame_ReinfArtNo = artcNo;
                                    break;
                                }
                            }
                            inside_frame = false;
                        }
                    }

                    else if (inside_panel)
                    {
                        if (row_str.Contains("Panel_ChkText:"))
                        {
                            
                        }
                        if (row_str.Contains("Panel_Dock:"))
                        {
                            //switch (row_str.Substring(15))
                            //{
                            //    case "Fill":
                            //        _frameUCPresenter.
                            //        break;
                            //    case "None":
                            //        dok = DockStyle.None;
                            //        break;
                            //}
                        }
                        if (row_str.Contains("Panel_Parent:"))
                        {

                        }
                        if (row_str.Contains("Panel_MultiPanelGroup:"))
                        {

                        }
                        if (row_str.Contains("Panel_FrameGroup:"))
                        {

                        }
                        if (row_str.Contains("Panel_FramePropertiesGroup:"))
                        {

                        }
                        if (row_str.Contains("Panel_Height:"))
                        {

                        }
                        if (row_str.Contains("Panel_OriginalHeight:"))
                        {

                        }
                        if (row_str.Contains("PanelImageRenderer_Height:"))
                        {

                        }
                        if (row_str.Contains("Panel_HeightToBind:"))
                        {

                        }
                        if (row_str.Contains("Panel_DisplayHeight:"))
                        {

                        }
                        if (row_str.Contains("Panel_DisplayHeightDecimal:"))
                        {

                        }
                        if (row_str.Contains("Panel_OriginalDisplayHeight:"))
                        {

                        }
                        if (row_str.Contains("Panel_OriginalDisplayHeightDecimal:"))
                        {

                        }
                        if (row_str.Contains("Panel_ID:"))
                        {

                        }
                        if (row_str.Contains("Panel_Name:"))
                        {

                        }
                        if (row_str.Contains("Panel_Orient:"))
                        {

                        }
                        if (row_str.Contains("Panel_OrientVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_Type:"))
                        {

                        }
                        if (row_str.Contains("Panel_Width:"))
                        {

                        }
                        if (row_str.Contains("Panel_OriginalWidth:"))
                        {

                        }
                        if (row_str.Contains("PanelImageRenderer_Width:"))
                        {

                        }
                        if (row_str.Contains("Panel_WidthToBind:"))
                        {

                        }
                        if (row_str.Contains("Panel_DisplayWidth:"))
                        {

                        }
                        if (row_str.Contains("Panel_DisplayWidthDecimal:"))
                        {

                        }
                        if (row_str.Contains("Panel_OriginalDisplayWidth:"))
                        {

                        }
                        if (row_str.Contains("Panel_OriginalDisplayWidthDecimal:"))
                        {

                        }
                        if (row_str.Contains("Panel_Visibility:"))
                        {

                        }
                        if (row_str.Contains("PanelImageRenderer_Zoom:"))
                        {

                        }
                        if (row_str.Contains("Panel_Index_Inside_MPanel:"))
                        {

                        }
                        if (row_str.Contains("Panel_Index_Inside_SPanel:"))
                        {

                        }
                        if (row_str.Contains("Panel_Placement:"))
                        {

                        }
                        if (row_str.Contains("Panel_Overlap_Sash:"))
                        {

                        }
                        if (row_str.Contains("Panel_Margin:"))
                        {

                        }
                        if (row_str.Contains("Panel_MarginToBind:"))
                        {

                        }
                        if (row_str.Contains("PanelImageRenderer_Margin:"))
                        {

                        }
                        if (row_str.Contains("Panel_Zoom:"))
                        {

                        }
                        if (row_str.Contains("Panel_ParentMultiPanelModel:"))
                        {

                        }
                        if (row_str.Contains("Panel_PropertyHeight:"))
                        {

                        }
                        if (row_str.Contains("Panel_HandleOptionsVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_RotoswingOptionsVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_RioOptionsVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_RioOptionsVisibility2:"))
                        {

                        }
                        if (row_str.Contains("Panel_RotolineOptionsVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_MVDOptionsVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_RotaryOptionsVisibility:"))
                        {

                        }
                        if (row_str.Contains("Panel_HandleOptionsHeight:"))
                        {

                        }
                        if (row_str.Contains("Panel_LouverBladesCount:"))
                        {

                        }
                        if (row_str.Contains("Panel_BackColor:"))
                        {

                        }
                        if (row_str.Contains("Panel_SlidingTypes:"))
                        {

                        }
                        if (row_str.Contains("Panel_SlidingTypeVisibility:"))
                        {
                            inside_panel = false;
                        }
                    }

                    //else if (inside_multi)
                    //{
                    //    if (row_str.Contains("DockStyle"))
                    //    {
                    //        switch (row_str.Trim().Remove(0, 11))
                    //        {
                    //            case "Fill":
                    //                multidok = DockStyle.Fill;
                    //                break;
                    //            case "None":
                    //                multidok = DockStyle.None;
                    //                break;
                    //        }
                    //    }
                    //    else if (row_str.Contains("MultiName"))
                    //    {
                    //        multi_Name = row_str.Trim().Remove(0, 11);
                    //    }
                    //    else if (row_str.Contains("DivSize"))
                    //    {
                    //        multi_Size = row_str.Trim().Remove(0, 9);
                    //    }
                    //    else if (row_str.Contains("DivTabIndex"))
                    //    {
                    //        multi_Tabindex = Convert.ToInt32(row_str.Trim().Remove(0, 13));
                    //    }
                    //    else if (row_str.Contains("DivType"))
                    //    {
                    //        multi_type = row_str.Trim().Remove(0, 9);
                    //    }
                    //    else if (row_str.Contains("DivNum"))
                    //    {
                    //        multidivnum = row_str.Trim().Remove(0, 8);
                    //    }
                    //    else if (row_str.Contains("Parent"))
                    //    {
                    //        multi_Parent = row_str.Trim().Remove(0, 8);
                    //    }

                    //    if (multi_Name != "" &&
                    //        multi_Size != "" &&
                    //        multidivnum != "" &&
                    //        multi_Tabindex != 0 &&
                    //        multi_type != "" &&
                    //        multi_Parent != "")
                    //    {
                    //        AddMultiPanel();
                    //    }
                    //}

                    //else if (inside_divider)
                    //{
                    //    if (row_str.Contains("DivdName"))
                    //    {
                    //        divd_name = row_str.Trim().Remove(0, 10);
                    //    }
                    //    else if (row_str.Contains("DivdWidth"))
                    //    {
                    //        divd_width = Convert.ToInt32(row_str.Trim().Remove(0, 11));
                    //    }
                    //    else if (row_str.Contains("DivdHeight"))
                    //    {
                    //        divd_height = Convert.ToInt32(row_str.Trim().Remove(0, 12));
                    //    }
                    //    else if (row_str.Contains("DivdTabIndex"))
                    //    {
                    //        divd_TabIndex = Convert.ToInt32(row_str.Trim().Remove(0, 14));
                    //    }
                    //    else if (row_str.Contains("Parent"))
                    //    {
                    //        divd_Parent = row_str.Trim().Remove(0, 8);
                    //    }

                    //    if (divd_name != "" &&
                    //        divd_width != 0 &&
                    //        divd_height != 0 &&
                    //        divd_TabIndex != 0 &&
                    //        divd_Parent != "")
                    //    {
                    //        AddDivider();
                    //    }
                    //}
                    break;
            }
        }

        string sql_Transaction_result;
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (mainTodo)
                {
                    case "Open_WndrFiles":
                        inside_quotation = true;
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
                        Frame_Save_UserControl();
                        Frame_Save_PropertiesUC();

                        //clear previous basePlatformUC
                        _pnlMain.Controls.Clear();

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
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame && !AddedConcrete && !OpenWindoorFile) //Add new Item
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
                                  sash_art == SashProfile_ArticleNo._2067))
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
                                !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067))
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
                                      sash_art == SashProfile_ArticleNo._2067))
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
                                    !(frame_art == FrameProfile_ArticleNo._2060 && sash_art == SashProfile_ArticleNo._2067))
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