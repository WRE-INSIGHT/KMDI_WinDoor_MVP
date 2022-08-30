﻿using CommonComponents;
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
using System.Reflection;
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
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
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
        private IFixedPanelUCPresenter _fixedUCP;
        private ICasementPanelUCPresenter _casementUCP;
        private IAwningPanelUCPresenter _awningUCP;
        private ISlidingPanelUCPresenter _slidingUCP;
        private ITiltNTurnPanelUCPresenter _tiltNTurnUCP;
        private ILouverPanelUCPresenter _louverPanelUCP;
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
                             ISortItemUCPresenter sortItemUCPresenter,
                             IPanelPropertiesUCPresenter panelPropertiesUCP,
                             IFixedPanelUCPresenter fixedUCP,
                             ICasementPanelUCPresenter casementUCP,
                             IAwningPanelUCPresenter awningUCP,
                             ISlidingPanelUCPresenter slidingUCP,
                             ITiltNTurnPanelUCPresenter tiltNTurnUCP,
                             ILouverPanelUCPresenter louverPanelUCP
                             
                             
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
            _tiltNTurnUCP = tiltNTurnUCP;
            _louverPanelUCP = louverPanelUCP;
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
                        //foreach (Object item in typeof(IPanelModel).GetProperties())
                        //{
                        //    Type t = item.GetType();
                        //    PropertyInfo[] props = t.GetProperties();
                        //    foreach (var prop in props)
                        //    {
                        //        if (prop.GetIndexParameters().Length == 0)
                        //            Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                        //                              prop.PropertyType.Name,
                        //                              prop.GetValue(item));
                        //        else
                        //            Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                        //                              prop.PropertyType.Name);

                        //    }
                        //}
                        wndr_content.Add("\t#");
                        wndr_content.Add("\t\tPanel_ChkText: " + pnl.Panel_ChkText);
                        wndr_content.Add("\t\tPanel_Dock: " + pnl.Panel_Dock);
                        wndr_content.Add("\t\tPanel_Parent: " + pnl.Panel_Parent);
                        wndr_content.Add("\t\tPanel_MultiPanelGroup: " + pnl.Panel_MultiPanelGroup);
                        wndr_content.Add("\t\tPanel_FrameGroup: " + pnl.Panel_FrameGroup);
                        wndr_content.Add("\t\tPanel_FramePropertiesGroup: " + pnl.Panel_FramePropertiesGroup);
                        wndr_content.Add("\t\tPanel_Height: " + pnl.Panel_Height);
                        wndr_content.Add("\t\tPanel_OriginalHeight: " + pnl.Panel_OriginalHeight);
                        wndr_content.Add("\t\tPanel_ImageRenderer_Height: " + pnl.PanelImageRenderer_Height);
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
                        wndr_content.Add("\t\tPanel_ImageRenderer_Width: " + pnl.PanelImageRenderer_Width);
                        wndr_content.Add("\t\tPanel_WidthToBind: " + pnl.Panel_WidthToBind);
                        wndr_content.Add("\t\tPanel_DisplayWidth: " + pnl.Panel_DisplayWidth);
                        wndr_content.Add("\t\tPanel_DisplayWidthDecimal: " + pnl.Panel_DisplayWidthDecimal);
                        wndr_content.Add("\t\tPanel_OriginalDisplayWidth: " + pnl.Panel_OriginalDisplayWidth);
                        wndr_content.Add("\t\tPanel_OriginalDisplayWidthDecimal: " + pnl.Panel_OriginalDisplayWidthDecimal);
                        wndr_content.Add("\t\tPanel_Visibility: " + pnl.Panel_Visibility);
                        wndr_content.Add("\t\tPanel_ImageRenderer_Zoom: " + pnl.PanelImageRenderer_Zoom);
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
                        wndr_content.Add("\t\tExplosion");
                        wndr_content.Add("\t\tPanel_GlassID: " + pnl.PanelGlass_ID);
                        wndr_content.Add("\t\tPanel_GlassThicknessDesc: " + pnl.Panel_GlassThicknessDesc);
                        wndr_content.Add("\t\tPanel_GlassThickness: " + pnl.Panel_GlassThickness);
                        wndr_content.Add("\t\tPanel_GlazingBeadArtNo: " + pnl.PanelGlazingBead_ArtNo);
                        wndr_content.Add("\t\tPanel_GlazingAdaptorArtNo: " + pnl.Panel_GlazingAdaptorArtNo);
                        wndr_content.Add("\t\tPanel_GBSpacerArtNo: " + pnl.Panel_GBSpacerArtNo);
                        wndr_content.Add("\t\tPanel_ChkGlazingAdaptor: " + pnl.Panel_ChkGlazingAdaptor);
                        wndr_content.Add("\t\tPanel_GlazingBeadWidth: " + pnl.Panel_GlazingBeadWidth);
                        wndr_content.Add("\t\tPanel_GlazingBeadWidthDecimal: " + pnl.Panel_GlazingBeadWidthDecimal);
                        wndr_content.Add("\t\tPanel_GlazingBeadHeight: " + pnl.Panel_GlazingBeadHeight);
                        wndr_content.Add("\t\tPanel_GlazingBeadHeightDecimal: " + pnl.Panel_GlazingBeadHeightDecimal);
                        wndr_content.Add("\t\tPanel_GlassWidth: " + pnl.Panel_GlassWidth);
                        wndr_content.Add("\t\tPanel_GlassWidthDecimal: " + pnl.Panel_GlassWidthDecimal);
                        wndr_content.Add("\t\tPanel_OriginalGlassWidth: " + pnl.Panel_OriginalGlassWidth);
                        wndr_content.Add("\t\tPanel_OriginalGlassWidthDecimal: " + pnl.Panel_OriginalGlassWidthDecimal);
                        wndr_content.Add("\t\tPanel_GlassHeight: " + pnl.Panel_GlassHeight);
                        wndr_content.Add("\t\tPanel_GlassHeightDecimal: " + pnl.Panel_GlassHeightDecimal);
                        wndr_content.Add("\t\tPanel_OriginalGlassHeight: " + pnl.Panel_OriginalGlassHeight);
                        wndr_content.Add("\t\tPanel_OriginalGlassHeightDecimal: " + pnl.Panel_OriginalGlassHeightDecimal);
                        wndr_content.Add("\t\tPanel_GlassPropertyHeight: " + pnl.Panel_GlassPropertyHeight);
                        wndr_content.Add("\t\tPanel_GlazingSpacerQty: " + pnl.Panel_GlazingSpacerQty);
                        wndr_content.Add("\t\tPanel_GlassFilm: " + pnl.Panel_GlassFilm);
                        wndr_content.Add("\t\tPanel_SashPropertyVisibility: " + pnl.Panel_SashPropertyVisibility);
                        wndr_content.Add("\t\tPanel_SashProfileArtNo: " + pnl.Panel_SashProfileArtNo);
                        wndr_content.Add("\t\tPanel_SashReinfArtNo: " + pnl.Panel_SashReinfArtNo);
                        wndr_content.Add("\t\tPanel_SashWidth: " + pnl.Panel_SashWidth);
                        wndr_content.Add("\t\tPanel_SashWidthDecimal: " + pnl.Panel_SashWidthDecimal);
                        wndr_content.Add("\t\tPanel_SashHeight: " + pnl.Panel_SashHeight);
                        wndr_content.Add("\t\tPanel_SashHeightDecimal: " + pnl.Panel_SashHeightDecimal);
                        wndr_content.Add("\t\tPanel_OriginalSashWidth: " + pnl.Panel_OriginalSashWidth);
                        wndr_content.Add("\t\tPanel_OriginalSashWidthDecimal: " + pnl.Panel_OriginalSashWidthDecimal);
                        wndr_content.Add("\t\tPanel_OriginalSashHeight: " + pnl.Panel_OriginalSashHeight);
                        wndr_content.Add("\t\tPanel_OriginalSashHeightDecimal: " + pnl.Panel_OriginalSashHeightDecimal);
                        wndr_content.Add("\t\tPanel_SashReinfWidth: " + pnl.Panel_SashReinfWidth);
                        wndr_content.Add("\t\tPanel_SashReinfWidthDecimal: " + pnl.Panel_SashReinfWidthDecimal);
                        wndr_content.Add("\t\tPanel_SashReinfHeight: " + pnl.Panel_SashReinfHeight);
                        wndr_content.Add("\t\tPanel_SashReinfHeightDecimal: " + pnl.Panel_SashReinfHeightDecimal);
                        wndr_content.Add("\t\tPanel_CoverProfileArtNo: " + pnl.Panel_CoverProfileArtNo);
                        wndr_content.Add("\t\tPanel_CoverProfileArtNo2: " + pnl.Panel_CoverProfileArtNo2);
                        wndr_content.Add("\t\tPanel_FrictionStayArtNo: " + pnl.Panel_FrictionStayArtNo);
                        wndr_content.Add("\t\tPanel_FSCasementArtNo: " + pnl.Panel_FSCasementArtNo);
                        wndr_content.Add("\t\tPanel_SnapInKeepArtNo: " + pnl.Panel_SnapInKeepArtNo);
                        wndr_content.Add("\t\tPanel_FixedCamArtNo: " + pnl.Panel_FixedCamArtNo);
                        wndr_content.Add("\t\tPanel_30x25CoverArtNo: " + pnl.Panel_30x25CoverArtNo);
                        wndr_content.Add("\t\tPanel_MotorizedDividerArtNo: " + pnl.Panel_MotorizedDividerArtNo);
                        wndr_content.Add("\t\tPanel_CoverForMotorArtNo: " + pnl.Panel_CoverForMotorArtNo);
                        wndr_content.Add("\t\tPanel_2dHingeArtNo: " + pnl.Panel_2dHingeArtNo);
                        wndr_content.Add("\t\tPanel_PushButtonSwitchArtNo: " + pnl.Panel_PushButtonSwitchArtNo);
                        wndr_content.Add("\t\tPanel_FalsePoleArtNo: " + pnl.Panel_FalsePoleArtNo);
                        wndr_content.Add("\t\tPanel_SupportingFrameArtNo: " + pnl.Panel_SupportingFrameArtNo);
                        wndr_content.Add("\t\tPanel_PlateArtNo: " + pnl.Panel_PlateArtNo);
                        wndr_content.Add("\t\tPanel_HandleType: " + pnl.Panel_HandleType);
                        wndr_content.Add("\t\tPanel_RotoswingArtNo: " + pnl.Panel_RotoswingArtNo);
                        wndr_content.Add("\t\tPanel_RotaryArtNo: " + pnl.Panel_RotaryArtNo);
                        wndr_content.Add("\t\tPanel_RioArtNo: " + pnl.Panel_RioArtNo);
                        wndr_content.Add("\t\tPanel_RioArtNo2: " + pnl.Panel_RioArtNo2);
                        wndr_content.Add("\t\tPanel_ProfileKnobCylinderArtNo: " + pnl.Panel_ProfileKnobCylinderArtNo);
                        wndr_content.Add("\t\tPanel_CylinderCoverArtNo: " + pnl.Panel_CylinderCoverArtNo);
                        wndr_content.Add("\t\tPanel_RotolineArtNo: " + pnl.Panel_RotolineArtNo);
                        wndr_content.Add("\t\tPanel_MVDArtNo: " + pnl.Panel_MVDArtNo);
                        wndr_content.Add("\t\tPanel_EspagnoletteArtNo: " + pnl.Panel_EspagnoletteArtNo);
                        wndr_content.Add("\t\tPanel_EspagnoletteOptionsVisibility: " + pnl.Panel_EspagnoletteOptionsVisibility);
                        wndr_content.Add("\t\tPanel_ExtensionTopArtNo: " + pnl.Panel_ExtensionTopArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionTop2ArtNo: " + pnl.Panel_ExtensionTop2ArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionTop3ArtNo: " + pnl.Panel_ExtensionTop3ArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionBotArtNo: " + pnl.Panel_ExtensionBotArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionBot2ArtNo: " + pnl.Panel_ExtensionBot2ArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionLeftArtNo: " + pnl.Panel_ExtensionLeftArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionLeft2ArtNo: " + pnl.Panel_ExtensionLeft2ArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionRightArtNo: " + pnl.Panel_ExtensionRightArtNo);
                        wndr_content.Add("\t\tPanel_ExtensionRight2ArtNo: " + pnl.Panel_ExtensionRight2ArtNo);
                        wndr_content.Add("\t\tPanel_ExtTopChk: " + pnl.Panel_ExtTopChk);
                        wndr_content.Add("\t\tPanel_ExtTop2Chk: " + pnl.Panel_ExtTop2Chk);
                        wndr_content.Add("\t\tPanel_ExtBotChk: " + pnl.Panel_ExtBotChk);
                        wndr_content.Add("\t\tPanel_ExtLeftChk: " + pnl.Panel_ExtLeftChk);
                        wndr_content.Add("\t\tPanel_ExtRightChk: " + pnl.Panel_ExtRightChk);
                        wndr_content.Add("\t\tPanel_ExtTopQty: " + pnl.Panel_ExtTopQty);
                        wndr_content.Add("\t\tPanel_ExtBotQty: " + pnl.Panel_ExtBotQty);
                        wndr_content.Add("\t\tPanel_ExtLeftQty: " + pnl.Panel_ExtLeftQty);
                        wndr_content.Add("\t\tPanel_ExtRightQty: " + pnl.Panel_ExtRightQty);
                        wndr_content.Add("\t\tPanel_ExtTop2Qty: " + pnl.Panel_ExtTop2Qty);
                        wndr_content.Add("\t\tPanel_ExtTop3Qty: " + pnl.Panel_ExtTop3Qty);
                        wndr_content.Add("\t\tPanel_ExtBot2Qty: " + pnl.Panel_ExtBot2Qty);
                        wndr_content.Add("\t\tPanel_ExtLeft2Qty: " + pnl.Panel_ExtLeft2Qty);
                        wndr_content.Add("\t\tPanel_ExtRight2Qty: " + pnl.Panel_ExtRight2Qty);
                        wndr_content.Add("\t\tPanel_CornerDriveArtNo: " + pnl.Panel_CornerDriveArtNo);
                        wndr_content.Add("\t\tPanel_CornerDriveOptionsVisibility: " + pnl.Panel_CornerDriveOptionsVisibility);
                        wndr_content.Add("\t\tPanel_ExtensionOptionsVisibility: " + pnl.Panel_ExtensionOptionsVisibility);
                        wndr_content.Add("\t\tPanel_RotoswingOptionsHeight: " + pnl.Panel_RotoswingOptionsHeight);
                        wndr_content.Add("\t\tPanel_PlasticWedge: " + pnl.Panel_PlasticWedge);
                        wndr_content.Add("\t\tPanel_PlasticWedgeQty: " + pnl.Panel_PlasticWedgeQty);
                        wndr_content.Add("\t\tPanel_MiddleCloserArtNo: " + pnl.Panel_MiddleCloserArtNo);
                        wndr_content.Add("\t\tPanel_LockingKitArtNo: " + pnl.Panel_LockingKitArtNo);
                        wndr_content.Add("\t\tPanel_GlassType: " + pnl.Panel_GlassType);
                        wndr_content.Add("\t\tPanel_StrikerArtno_A: " + pnl.Panel_StrikerArtno_A);
                        wndr_content.Add("\t\tPanel_StrikerQty_A: " + pnl.Panel_StrikerQty_A);
                        wndr_content.Add("\t\tPanel_StrikerArtno_C: " + pnl.Panel_StrikerArtno_C);
                        wndr_content.Add("\t\tPanel_StrikerQty_C: " + pnl.Panel_StrikerQty_C);
                        wndr_content.Add("\t\tPanel_MiddleCloserPairQty: " + pnl.Panel_MiddleCloserPairQty);
                        wndr_content.Add("\t\tPanel_MotorizedOptionVisibility: " + pnl.Panel_MotorizedOptionVisibility);
                        wndr_content.Add("\t\tPanel_MotorizedMechArtNo: " + pnl.Panel_MotorizedMechArtNo);
                        wndr_content.Add("\t\tPanel_MotorizedPropertyHeight: " + pnl.Panel_MotorizedPropertyHeight);
                        wndr_content.Add("\t\tPanel_MotorizedMechQty: " + pnl.Panel_MotorizedMechQty);
                        wndr_content.Add("\t\tPanel_MotorizedMechSetQty: " + pnl.Panel_MotorizedMechSetQty);
                        wndr_content.Add("\t\tPanel_2DHingeQty: " + pnl.Panel_2DHingeQty);
                        wndr_content.Add("\t\tPanel_2dHingeArtNo_nonMotorized: " + pnl.Panel_2dHingeArtNo_nonMotorized);
                        wndr_content.Add("\t\tPanel_2DHingeQty_nonMotorized: " + pnl.Panel_2DHingeQty_nonMotorized);
                        wndr_content.Add("\t\tPanel_2dHingeVisibility_nonMotorized: " + pnl.Panel_2dHingeVisibility_nonMotorized);
                        wndr_content.Add("\t\tPanel_3dHingeArtNo: " + pnl.Panel_3dHingeArtNo);
                        wndr_content.Add("\t\tPanel_3dHingeQty: " + pnl.Panel_3dHingeQty);
                        wndr_content.Add("\t\tPanel_3dHingePropertyVisibility: " + pnl.Panel_3dHingePropertyVisibility);
                        wndr_content.Add("\t\tPanel_ButtHingeArtNo: " + pnl.Panel_ButtHingeArtNo);
                        wndr_content.Add("\t\tPanel_ButtHingeQty: " + pnl.Panel_ButtHingeQty);
                        wndr_content.Add("\t\tPanel_2dHingeVisibility: " + pnl.Panel_2dHingeVisibility);
                        wndr_content.Add("\t\tPanel_ButtHingeVisibility: " + pnl.Panel_ButtHingeVisibility);
                        wndr_content.Add("\t\tPanel_AdjStrikerArtNo: " + pnl.Panel_AdjStrikerArtNo);
                        wndr_content.Add("\t\tPanel_AdjStrikerQty: " + pnl.Panel_AdjStrikerQty);
                        wndr_content.Add("\t\tPanel_RestrictorStayArtNo: " + pnl.Panel_RestrictorStayArtNo);
                        wndr_content.Add("\t\tPanel_RestrictorStayQty: " + pnl.Panel_RestrictorStayQty);
                        wndr_content.Add("\t\tPanel_ExtensionPropertyHeight: " + pnl.Panel_ExtensionPropertyHeight);
                        wndr_content.Add("\t\tPanel_GeorgianBarArtNo: " + pnl.Panel_GeorgianBarArtNo);
                        wndr_content.Add("\t\tPanel_GeorgianBar_VerticalQty: " + pnl.Panel_GeorgianBar_VerticalQty);
                        wndr_content.Add("\t\tPanel_GeorgianBar_HorizontalQty: " + pnl.Panel_GeorgianBar_HorizontalQty);
                        wndr_content.Add("\t\tPanel_GeorgianBarOptionVisibility: " + pnl.Panel_GeorgianBarOptionVisibility);
                        wndr_content.Add("\t\tPanel_HingeOptions: " + pnl.Panel_HingeOptions);
                        wndr_content.Add("\t\tPanel_HingeOptionsPropertyHeight: " + pnl.Panel_HingeOptionsPropertyHeight);
                        wndr_content.Add("\t\tPanel_HingeOptionsVisibility: " + pnl.Panel_HingeOptionsVisibility);
                        wndr_content.Add("\t\tPanel_CenterHingeOptions: " + pnl.Panel_CenterHingeOptions);
                        wndr_content.Add("\t\tPanel_CenterHingeOptionsVisibility: " + pnl.Panel_CenterHingeOptionsVisibility);
                        wndr_content.Add("\t\tPanel_NTCenterHingeArticleNo: " + pnl.Panel_NTCenterHingeArticleNo);
                        wndr_content.Add("\t\tPanel_StayBearingKArtNo: " + pnl.Panel_StayBearingKArtNo);
                        wndr_content.Add("\t\tPanel_StayBearingPinArtNo: " + pnl.Panel_StayBearingPinArtNo);
                        wndr_content.Add("\t\tPanel_StayBearingCoverArtNo: " + pnl.Panel_StayBearingCoverArtNo);
                        wndr_content.Add("\t\tPanel_TopCornerHingeArtNo: " + pnl.Panel_TopCornerHingeArtNo);
                        wndr_content.Add("\t\tPanel_TopCornerHingeCoverArtNo: " + pnl.Panel_TopCornerHingeCoverArtNo);
                        wndr_content.Add("\t\tPanel_TopCornerHingeSpacerArtNo: " + pnl.Panel_TopCornerHingeSpacerArtNo);
                        wndr_content.Add("\t\tPanel_CornerHingeKArtNo: " + pnl.Panel_CornerHingeKArtNo);
                        wndr_content.Add("\t\tPanel_CornerPivotRestKArtNo: " + pnl.Panel_CornerPivotRestKArtNo);
                        wndr_content.Add("\t\tPanel_CornerHingeCoverKArtNo: " + pnl.Panel_CornerHingeCoverKArtNo);
                        wndr_content.Add("\t\tPanel_CoverForCornerPivotRestVerticalArtNo: " + pnl.Panel_CoverForCornerPivotRestVerticalArtNo);
                        wndr_content.Add("\t\tPanel_CoverForCornerPivotRestArtNo: " + pnl.Panel_CoverForCornerPivotRestArtNo);
                        wndr_content.Add("\t\tPanel_WeldableCArtNo: " + pnl.Panel_WeldableCArtNo);
                        wndr_content.Add("\t\tPanel_LatchDeadboltStrikerArtNo: " + pnl.Panel_LatchDeadboltStrikerArtNo);
                        wndr_content.Add("\t\tPanel_CmenuDeleteVisibility: " + pnl.Panel_CmenuDeleteVisibility);
                        wndr_content.Add("\t\tPanel_NTCenterHingeVisibility: " + pnl.Panel_NTCenterHingeVisibility);
                        wndr_content.Add("\t\tPanel_MiddleCloserVisibility: " + pnl.Panel_MiddleCloserVisibility);
                        wndr_content.Add("\t\tPanel_MotorizedpnlOptionVisibility: " + pnl.Panel_MotorizedpnlOptionVisibility);
                        
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
                wndr_content.Add("EndofFile");
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

        #region Explosion Param 
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
             panel_MotorizedpnlOptionVisibility;
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
            panel_HingeOptionsPropertyHeight;
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
        #endregion
        private void Opening_dotwndr(int row)
        {
            string row_str = file_lines[row].Replace("\t", "");
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
            else if (row_str.Contains("#"))
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
                            panel_ChkText = row_str.Substring(15);
                        }
                        if (row_str.Contains("Panel_Dock:"))
                        {
                            switch (row_str.Substring(12))
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
                            panel_Parent = _frameModel.Frame_UC;
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
                            //panel_Height = Convert.ToInt32(row_str.Substring(14));
                        }
                        if (row_str.Contains("Panel_OriginalHeight:"))
                        {
                            panel_OriginalHeight = Convert.ToInt32(row_str.Substring(22));
                        }
                        if (row_str.Contains("Panel_ImageRenderer_Height:"))
                        {
                            panel_ImageRenderer_Height = Convert.ToInt32(row_str.Substring(27));
                        }
                        if (row_str.Contains("Panel_HeightToBind:"))
                        {
                            panel_HeightToBind = Convert.ToInt32(row_str.Substring(20));
                        }
                        if (row_str.Contains("Panel_DisplayHeight:"))
                        {
                            panel_DisplayHeight = Convert.ToInt32(row_str.Substring(21));
                        }
                        if (row_str.Contains("Panel_DisplayHeightDecimal:"))
                        {
                            panel_DisplayHeightDecimal = Convert.ToInt32(row_str.Substring(28));
                        }
                        if (row_str.Contains("Panel_OriginalDisplayHeight:"))
                        {
                            panel_OriginalDisplayHeight = Convert.ToInt32(row_str.Substring(29));
                        }
                        if (row_str.Contains("Panel_OriginalDisplayHeightDecimal:"))
                        {
                            panel_OriginalDisplayHeightDecimal = Convert.ToInt32(row_str.Substring(36));
                        }
                        if (row_str.Contains("Panel_ID:"))
                        {
                            panel_ID = Convert.ToInt32(row_str.Substring(10));
                        }
                        if (row_str.Contains("Panel_Name:"))
                        {
                            panel_Name = Convert.ToString(row_str.Substring(12));
                        }
                        if (row_str.Contains("Panel_Orient:"))
                        {
                            panel_Orient = Convert.ToBoolean(row_str.Substring(14));
                        }
                        if (row_str.Contains("Panel_OrientVisibility:"))
                        {
                            panel_OrientVisibility = Convert.ToBoolean(row_str.Substring(24));
                        }
                        if (row_str.Contains("Panel_Type:"))
                        {
                            panel_Type = row_str.Substring(12);
                        }
                        if (row_str.Contains("Panel_Width:"))
                        {
                            //panel_Width = Convert.ToInt32(row_str.Substring(13));
                        }
                        if (row_str.Contains("Panel_OriginalWidth:"))
                        {
                            panel_OriginalWidth = Convert.ToInt32(row_str.Substring(21));
                        }
                        if (row_str.Contains("Panel_ImageRenderer_Width:"))
                        {
                            panel_ImageRenderer_Width = Convert.ToInt32(row_str.Substring(26));
                        }
                        if (row_str.Contains("Panel_WidthToBind:"))
                        {
                            panel_WidthToBind = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_DisplayWidth:"))
                        {
                            panel_DisplayWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_DisplayWidthDecimal:"))
                        {
                            panel_DisplayWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_OriginalDisplayWidth:"))
                        {
                            panel_OriginalDisplayWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));

                        }
                        if (row_str.Contains("Panel_OriginalDisplayWidthDecimal:"))
                        {
                            panel_OriginalDisplayWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_Visibility:"))
                        {
                            panel_Visibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_ImageRenderer_Zoom:"))
                        {
                            panel_ImageRendererZoom = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_Index_Inside_MPanel:"))
                        {
                            panel_Index_Inside_MPanel = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_Index_Inside_SPanel:"))
                        {
                            panel_Index_Inside_SPanel = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));

                        }
                        if (row_str.Contains("Panel_Placement:"))
                        {
                            panel_Placement = row_str.Substring(row_str.IndexOf(":") + 1);
                        }
                        if (row_str.Contains("Panel_Overlap_Sash:"))
                        {
                            foreach(OverlapSash pnl_ovrlpsash in OverlapSash.GetAll())
                            {
                                if (pnl_ovrlpsash.ToString() == row_str.Substring(20))
                                {
                                    panel_OverlapSash = pnl_ovrlpsash;
                                }
                            }
                        }
                        if (row_str.Contains("Panel_Margin:"))
                        {
                            //panel_Index_Inside_SPanel = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_MarginToBind:"))
                        {
                            //panel_WidthToBind = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("PanelImageRenderer_Margin:"))
                        {
                            //panel_WidthToBind = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_Zoom:"))
                        {
                            
                            panel_Zoom = float.Parse(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_ParentMultiPanelModel:"))
                        {
                            //panel_ParentMultiPanelModel = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_PropertyHeight:"))
                        {
                            panel_PropertyHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_HandleOptionsVisibility:"))
                        {
                            panel_HandleOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_RotoswingOptionsVisibility:"))
                        {
                            panel_RotoswingOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_RioOptionsVisibility:"))
                        {
                            panel_RioOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_RioOptionsVisibility2:"))
                        {
                            panel_RioOptionsVisibility2 = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_RotolineOptionsVisibility:"))
                        {
                            panel_RotolineOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_MVDOptionsVisibility:"))
                        {
                            panel_MVDOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_RotaryOptionsVisibility:"))
                        {
                            panel_RotaryOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_HandleOptionsHeight:"))
                        {
                            panel_HandleOptionsHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_LouverBladesCount:"))
                        {
                            panel_LouverBladesCount = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        if (row_str.Contains("Panel_BackColor:"))
                        {

                            Console.WriteLine();
                            panel_BackColor = ColorTranslator.FromHtml(row_str.Substring(row_str.IndexOf("[") + 1, row_str.IndexOf("]") - 1 - row_str.IndexOf("[")));
                        }
                        if (row_str.Contains("Panel_SlidingTypes:"))
                        {
                            foreach (SlidingTypes pnl_slidingType in SlidingTypes.GetAll())
                            {
                                int ass = row_str.IndexOf(":");
                                string asda = row_str.Substring(row_str.IndexOf(": ") + 1).Trim();
                                if (pnl_slidingType.ToString() == row_str.Substring(row_str.IndexOf(": ") + 1).Trim())
                                {
                                    panel_SlidingTypes = pnl_slidingType;
                                }
                            }
                        }
                        if (row_str.Contains("Panel_SlidingTypeVisibility:"))
                        {
                            panel_SlidingTypeVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                            
                        }
                        //Explosion
                        else if (row_str.Contains("Panel_GlassID:"))
                        {
                            panel_GlassID = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassThicknessDesc:"))
                        {
                            panel_GlassThicknessDesc = row_str.Substring(row_str.IndexOf(":") + 1);
                        }
                        else if (row_str.Contains("Panel_GlassThickness:"))
                        {
                            panel_GlassThickness = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlazingBeadArtNo:"))
                        {
                            foreach(GlazingBead_ArticleNo gban in GlazingBead_ArticleNo.GetAll())
                            {
                                if(gban.ToString()  == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_GlazingBeadArtNo = gban;
                                }
                            }
                           
                        }
                        else if (row_str.Contains("Panel_GlazingAdaptorArtNo:"))
                        {
                            foreach(GlazingAdaptor_ArticleNo gaan in GlazingAdaptor_ArticleNo.GetAll())
                            {
                                if (gaan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_GlazingAdaptorArtNo = gaan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GBSpacerArtNo:"))
                        {
                            foreach (GBSpacer_ArticleNo gaan in GBSpacer_ArticleNo.GetAll())
                            {
                                if (gaan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_GBSpacerArtNo = gaan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ChkGlazingAdaptor:"))
                        {

                            panel_ChkGlazingAdaptor = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlazingBeadWidth:"))
                        {
                            panel_GlazingBeadWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlazingBeadWidthDecimal:"))
                        {
                            panel_GlazingBeadWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlazingBeadHeight:"))
                        {
                            panel_GlazingBeadHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlazingBeadHeightDecimal:"))
                        {
                            panel_GlazingBeadHeightDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassWidth:"))
                        {
                            panel_GlassWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassWidthDecimal:"))
                        {
                            panel_GlassWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalGlassWidth:"))
                        {
                            panel_OriginalGlassWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalGlassWidthDecimal:"))
                        {
                            panel_OriginalGlassWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassHeight:"))
                        {
                            panel_GlassHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassHeightDecimal:"))
                        {
                            panel_GlassHeightDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalGlassHeight:"))
                        {
                            panel_OriginalGlassHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalGlassHeightDecimal:"))
                        {
                            panel_OriginalGlassHeightDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassPropertyHeight:"))
                        {
                            panel_GlassPropertyHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlazingSpacerQty:"))
                        {
                            panel_GlazingSpacerQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GlassFilm:"))
                        {
                            foreach (GlassFilm_Types gft in GlassFilm_Types.GetAll())
                            {
                                if (gft.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_GlassFilm = gft;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SashPropertyVisibility:"))
                        {
                            panel_SashPropertyVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashProfileArtNo:"))
                        {
                            foreach (SashProfile_ArticleNo span in SashProfile_ArticleNo.GetAll())
                            {
                                if (span.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_SashProfileArtNo = span;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SashReinfArtNo:"))
                        {
                            foreach (SashReinf_ArticleNo sran in SashReinf_ArticleNo.GetAll())
                            {
                                if (sran.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_SashReinfArtNo = sran;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SashWidth:"))
                        {
                            panel_SashWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashWidthDecimal:"))
                        {
                            panel_SashWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashHeight:"))
                        {
                            panel_SashHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashHeightDecimal:"))
                        {
                            panel_SashHeightDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalSashWidth:"))
                        {
                            panel_OriginalSashWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalSashWidthDecimal:"))
                        {
                            panel_OriginalSashWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalSashHeight:"))
                        {
                            panel_OriginalSashHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_OriginalSashHeightDecimal:"))
                        {
                            panel_OriginalSashHeightDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashReinfWidth:"))
                        {
                            panel_SashReinfWidth = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashReinfWidthDecimal:"))
                        {
                            panel_SashReinfWidthDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashReinfHeight:"))
                        {
                            panel_SashReinfHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_SashReinfHeightDecimal:"))
                        {
                            panel_SashReinfHeightDecimal = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_CoverProfileArtNo:"))
                        {
                            foreach (CoverProfile_ArticleNo cpan in CoverProfile_ArticleNo.GetAll())
                            {
                                if (cpan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CoverProfileArtNo = cpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverProfileArtNo2:"))
                        {
                            foreach (CoverProfile_ArticleNo cpan in CoverProfile_ArticleNo.GetAll())
                            {
                                if (cpan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CoverProfileArtNo2 = cpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FrictionStayArtNo:"))
                        {
                            foreach (FrictionStay_ArticleNo fsan in FrictionStay_ArticleNo.GetAll())
                            {
                                if (fsan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_FrictionStayArtNo = fsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FSCasementArtNo:"))
                        {
                            foreach (FrictionStayCasement_ArticleNo fscan in FrictionStayCasement_ArticleNo.GetAll())
                            {
                                if (fscan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_FSCasementArtNo = fscan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SnapInKeepArtNo:"))
                        {
                            foreach (SnapInKeep_ArticleNo sikan in SnapInKeep_ArticleNo.GetAll())
                            {
                                if (sikan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_SnapInKeepArtNo = sikan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FixedCamArtNo:"))
                        {
                            foreach (FixedCam_ArticleNo fcan in FixedCam_ArticleNo.GetAll())
                            {
                                if (fcan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_FixedCamArtNo = fcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_30x25CoverArtNo:"))
                        {
                            foreach (_30x25Cover_ArticleNo can in _30x25Cover_ArticleNo.GetAll())
                            {
                                if (can.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_30x25CoverArtNo = can;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_MotorizedDividerArtNo:"))
                        {
                            foreach (MotorizedDivider_ArticleNo mdan in MotorizedDivider_ArticleNo.GetAll())
                            {
                                if (mdan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_MotorizedDividerArtNo = mdan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverForMotorArtNo:"))
                        {
                            foreach (CoverForMotor_ArticleNo cfman in CoverForMotor_ArticleNo.GetAll())
                            {
                                if (cfman.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CoverForMotorArtNo = cfman;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_2dHingeArtNo:"))
                        {
                            foreach (_2DHinge_ArticleNo han in _2DHinge_ArticleNo.GetAll())
                            {
                                if (han.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_2dHingeArtNo = han;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PushButtonSwitchArtNo:"))
                        {
                            foreach (PushButtonSwitch_ArticleNo pbsan in PushButtonSwitch_ArticleNo.GetAll())
                            {
                                if (pbsan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_PushButtonSwitchArtNo = pbsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_FalsePoleArtNo:"))
                        {
                            foreach (FalsePole_ArticleNo fpan in FalsePole_ArticleNo.GetAll())
                            {
                                if (fpan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_FalsePoleArtNo = fpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_SupportingFrameArtNo:"))
                        {
                            foreach (SupportingFrame_ArticleNo sfan in SupportingFrame_ArticleNo.GetAll())
                            {
                                if (sfan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_SupportingFrameArtNo = sfan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PlateArtNo:"))
                        {
                            foreach (Plate_ArticleNo pan in Plate_ArticleNo.GetAll())
                            {
                                if (pan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_PlateArtNo = pan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_HandleType:"))
                        {
                            foreach (Handle_Type ht in Handle_Type.GetAll())
                            {
                                if (ht.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_HandleType = ht;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotoswingArtNo:"))
                        {
                            foreach (Rotoswing_HandleArtNo rhan in Rotoswing_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_RotoswingArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotaryArtNo:"))
                        {
                            foreach (Rotary_HandleArtNo rhan in Rotary_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_RotaryArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RioArtNo:"))
                        {
                            foreach (Rio_HandleArtNo rhan in Rio_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_RioArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RioArtNo2:"))
                        {
                            foreach (Rio_HandleArtNo rhan in Rio_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_RioArtNo2 = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ProfileKnobCylinderArtNo:"))
                        {
                            foreach (ProfileKnobCylinder_ArtNo pkcan in ProfileKnobCylinder_ArtNo.GetAll())
                            {
                                if (pkcan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ProfileKnobCylinderArtNo = pkcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CylinderCoverArtNo:"))
                        {
                            foreach (Cylinder_CoverArtNo ccan in Cylinder_CoverArtNo.GetAll())
                            {
                                if (ccan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CylinderCoverArtNo = ccan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RotolineArtNo:"))
                        {
                            foreach (Rotoline_HandleArtNo rhan in Rotoline_HandleArtNo.GetAll())
                            {
                                if (rhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_RotolineArtNo = rhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_MVDArtNo:"))
                        {
                            foreach (MVD_HandleArtNo mvdhan in MVD_HandleArtNo.GetAll())
                            {
                                if (mvdhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_MVDArtNo = mvdhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_EspagnoletteArtNo:"))
                        {
                            foreach (Espagnolette_ArticleNo ean in Espagnolette_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_EspagnoletteArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_EspagnoletteOptionsVisibility:"))
                        {
                            panel_EspagnoletteOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtensionTopArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionTopArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionTop2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionTop2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionTop3ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionTop3ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionBotArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionBotArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionBot2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionBot2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionLeftArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionLeftArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionLeft2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionLeft2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionRightArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionRightArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtensionRight2ArtNo:"))
                        {
                            foreach (Extension_ArticleNo ean in Extension_ArticleNo.GetAll())
                            {
                                if (ean.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ExtensionRight2ArtNo = ean;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ExtTopChk:"))
                        {

                            panel_ExtTopChk = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtTop2Chk:"))
                        {
                            panel_ExtTop2Chk = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtBotChk:"))
                        {
                            panel_ExtBotChk = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtLeftChk:"))
                        {
                            panel_ExtLeftChk = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtRightChk:"))
                        {
                            panel_ExtRightChk = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtTopQty:"))
                        {
                            panel_ExtTopQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtBotQty:"))
                        {
                            panel_ExtBotQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtLeftQty:"))
                        {
                            panel_ExtLeftQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtRightQty:"))
                        {
                            panel_ExtRightQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtTop2Qty:"))
                        {
                            panel_ExtTop2Qty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtTop3Qty:"))
                        {
                            panel_ExtTop3Qty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtBot2Qty:"))
                        {
                            panel_ExtBot2Qty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtLeft2Qty:"))
                        {
                            panel_ExtLeft2Qty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtRight2Qty:"))
                        {
                            panel_ExtRight2Qty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_CornerDriveArtNo:"))
                        {
                            foreach (CornerDrive_ArticleNo cdan in CornerDrive_ArticleNo.GetAll())
                            {
                                if (cdan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CornerDriveArtNo = cdan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerDriveOptionsVisibility:"))
                        {
                            panel_CornerDriveOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtensionOptionsVisibility:"))
                        {
                            panel_ExtensionOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_RotoswingOptionsHeight:"))
                        {
                            panel_RotoswingOptionsHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_PlasticWedge:"))
                        {
                            foreach (PlasticWedge_ArticleNo pwan in PlasticWedge_ArticleNo.GetAll())
                            {
                                if (pwan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_PlasticWedge = pwan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_PlasticWedgeQty:"))
                        {
                            panel_PlasticWedgeQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MiddleCloserArtNo:"))
                        {
                            foreach (MiddleCloser_ArticleNo mcan in MiddleCloser_ArticleNo.GetAll())
                            {
                                if (mcan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_MiddleCloserArtNo = mcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LockingKitArtNo:"))
                        {
                            foreach (LockingKit_ArticleNo lkan in LockingKit_ArticleNo.GetAll())
                            {
                                if (lkan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_LockingKitArtNo = lkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GlassType:"))
                        {
                            foreach (GlassType gt in GlassType.GetAll())
                            {
                                if (gt.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_GlassType = gt;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerArtno_A:"))
                        {
                            foreach (Striker_ArticleNo san in Striker_ArticleNo.GetAll())
                            {
                                if (san.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_StrikerArtno_A = san;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerQty_A:"))
                        {
                            panel_StrikerQty_A = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_StrikerArtno_C:"))
                        {
                            foreach (Striker_ArticleNo san in Striker_ArticleNo.GetAll())
                            {
                                if (san.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_StrikerArtno_C = san;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StrikerQty_C:"))
                        {
                            panel_StrikerQty_C = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MiddleCloserPairQty:"))
                        {
                            panel_MiddleCloserPairQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MotorizedOptionVisibility:"))
                        {
                            panel_MotorizedOptionVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MotorizedMechArtNo:"))
                        {
                            foreach (MotorizedMech_ArticleNo mman in MotorizedMech_ArticleNo.GetAll())
                            {
                                if (mman.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_MotorizedMechArtNo = mman;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_MotorizedPropertyHeight:"))
                        {
                            panel_MotorizedPropertyHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MotorizedMechQty:"))
                        {
                            panel_MotorizedMechQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MotorizedMechSetQty:"))
                        {
                            panel_MotorizedMechSetQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_2DHingeQty:"))
                        {
                            panel_2DHingeQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_2dHingeArtNo_nonMotorized:"))
                        {
                            foreach (_2DHinge_ArticleNo han in _2DHinge_ArticleNo.GetAll())
                            {
                                if (han.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_2dHingeArtNo_nonMotorized = han;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_2DHingeQty_nonMotorized:"))
                        {
                            panel_2DHingeQty_nonMotorized = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_2dHingeVisibility_nonMotorized:"))
                        {
                            panel_2dHingeVisibility_nonMotorized = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_3dHingeArtNo:"))
                        {
                            foreach (_3dHinge_ArticleNo han in _3dHinge_ArticleNo.GetAll())
                            {
                                if (han.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_3dHingeArtNo = han;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_3dHingeQty:"))
                        {
                            panel_3dHingeQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_3dHingePropertyVisibility:"))
                        {
                            panel_3dHingePropertyVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ButtHingeArtNo:"))
                        {
                            foreach (ButtHinge_ArticleNo bhan in ButtHinge_ArticleNo.GetAll())
                            {
                                if (bhan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_ButtHingeArtNo = bhan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_ButtHingeQty:"))
                        {

                            panel_ButtHingeQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_2dHingeVisibility:"))
                        {
                            panel_2dHingeVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ButtHingeVisibility:"))
                        {
                            panel_ButtHingeVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_AdjStrikerArtNo:"))
                        {
                            foreach (AdjustableStriker_ArticleNo asan in AdjustableStriker_ArticleNo.GetAll())
                            {
                                if (asan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_AdjStrikerArtNo = asan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_AdjStrikerQty:"))
                        {
                            panel_AdjStrikerQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_RestrictorStayArtNo:"))
                        {
                            foreach (RestrictorStay_ArticleNo rsan in RestrictorStay_ArticleNo.GetAll())
                            {
                                if (rsan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_RestrictorStayArtNo = rsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_RestrictorStayQty:"))
                        {
                            panel_RestrictorStayQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_ExtensionPropertyHeight:"))
                        {
                            panel_ExtensionPropertyHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GeorgianBarArtNo:"))
                        {
                            foreach (GeorgianBar_ArticleNo gban in GeorgianBar_ArticleNo.GetAll())
                            {
                                if (gban.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_GeorgianBarArtNo = gban;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_GeorgianBar_VerticalQty:"))
                        {
                            panel_GeorgianBar_VerticalQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GeorgianBar_HorizontalQty:"))
                        {
                            panel_GeorgianBar_HorizontalQty = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_GeorgianBarOptionVisibility:"))
                        {
                            panel_GeorgianBarOptionVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_HingeOptions:"))
                        {
                            foreach (HingeOption ho in HingeOption.GetAll())
                            {
                                if (ho.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_HingeOptions = ho;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_HingeOptionsPropertyHeight:"))
                        {
                            panel_HingeOptionsPropertyHeight = Convert.ToInt32(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_HingeOptionsVisibility:"))
                        {
                            panel_HingeOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_CenterHingeOptions:"))
                        {
                            foreach (CenterHingeOption cho in CenterHingeOption.GetAll())
                            {
                                if (cho.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CenterHingeOptions = cho;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CenterHingeOptionsVisibility:"))
                        {
                            panel_CenterHingeOptionsVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_NTCenterHingeArticleNo:"))
                        {
                            foreach (NTCenterHinge_ArticleNo ntchan in NTCenterHinge_ArticleNo.GetAll())
                            {
                                if (ntchan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_NTCenterHingeArticleNo = ntchan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StayBearingKArtNo:"))
                        {
                            foreach (StayBearingK_ArticleNo sbkan in StayBearingK_ArticleNo.GetAll())
                            {
                                if (sbkan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_StayBearingKArtNo = sbkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StayBearingPinArtNo:"))
                        {
                            foreach (StayBearingPin_ArticleNo sbpan in StayBearingPin_ArticleNo.GetAll())
                            {
                                if (sbpan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_StayBearingPinArtNo = sbpan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_StayBearingCoverArtNo:"))
                        {
                            foreach (StayBearingCover_ArticleNo sbcan in StayBearingCover_ArticleNo.GetAll())
                            {
                                if (sbcan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_StayBearingCoverArtNo = sbcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TopCornerHingeArtNo:"))
                        {
                            foreach (TopCornerHinge_ArticleNo tchan in TopCornerHinge_ArticleNo.GetAll())
                            {
                                if (tchan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_TopCornerHingeArtNo = tchan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TopCornerHingeCoverArtNo:"))
                        {
                            foreach (TopCornerHingeCover_ArticleNo tchcan in TopCornerHingeCover_ArticleNo.GetAll())
                            {
                                if (tchcan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_TopCornerHingeCoverArtNo = tchcan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_TopCornerHingeSpacerArtNo:"))
                        {
                            foreach (TopCornerHingeSpacer_ArticleNo tchsan in TopCornerHingeSpacer_ArticleNo.GetAll())
                            {
                                if (tchsan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_TopCornerHingeSpacerArtNo = tchsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerHingeKArtNo:"))
                        {
                            foreach (CornerHingeK_ArticleNo chkan in CornerHingeK_ArticleNo.GetAll())
                            {
                                if (chkan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CornerHingeKArtNo = chkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerPivotRestKArtNo:"))
                        {
                            foreach (CornerPivotRestK_ArticleNo cprkan in CornerPivotRestK_ArticleNo.GetAll())
                            {
                                if (cprkan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CornerPivotRestKArtNo = cprkan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CornerHingeCoverKArtNo:"))
                        {
                            foreach (CornerHingeCoverK_ArticleNo chckan in CornerHingeCoverK_ArticleNo.GetAll())
                            {
                                if (chckan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CornerHingeCoverKArtNo = chckan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverForCornerPivotRestVerticalArtNo:"))
                        {
                            foreach (CoverForCornerPivotRestVertical_ArticleNo cfcprvan in CoverForCornerPivotRestVertical_ArticleNo.GetAll())
                            {
                                if (cfcprvan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CoverForCornerPivotRestVerticalArtNo = cfcprvan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CoverForCornerPivotRestArtNo:"))
                        {
                            foreach (CoverForCornerPivotRest_ArticleNo cfcpran in CoverForCornerPivotRest_ArticleNo.GetAll())
                            {
                                if (cfcpran.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_CoverForCornerPivotRestArtNo = cfcpran;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_WeldableCArtNo:"))
                        {
                            foreach (WeldableCornerJoint_ArticleNo wcjan in WeldableCornerJoint_ArticleNo.GetAll())
                            {
                                if (wcjan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_WeldableCArtNo = wcjan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_LatchDeadboltStrikerArtNo:"))
                        {
                            foreach (LatchDeadboltStriker_ArticleNo ldsan in LatchDeadboltStriker_ArticleNo.GetAll())
                            {
                                if (ldsan.ToString() == row_str.Substring(row_str.IndexOf(":") + 1))
                                {
                                    panel_LatchDeadboltStrikerArtNo = ldsan;
                                }
                            }
                        }
                        else if (row_str.Contains("Panel_CmenuDeleteVisibility:"))
                        {
                            panel_CmenuDeleteVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_NTCenterHingeVisibility:"))
                        {
                            panel_NTCenterHingeVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MiddleCloserVisibility:"))
                        {
                            panel_MiddleCloserVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                        }
                        else if (row_str.Contains("Panel_MotorizedpnlOptionVisibility:"))
                        {
                            panel_MotorizedpnlOptionVisibility = Convert.ToBoolean(row_str.Substring(row_str.IndexOf(":") + 1));
                            IPanelModel pnlModel = _panelServices.AddPanelModel(panel_Width,
                                                           panel_Height,
                                                           (Control)_frameModel.Frame_UC,
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
                            pnlModel.Panel_PropertyHeight = panel_PropertyHeight;
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
                            pnlModel.Panel_GlassPropertyHeight = panel_GlassPropertyHeight;
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
                            pnlModel.Panel_MotorizedPropertyHeight = panel_MotorizedPropertyHeight;
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
                            pnlModel.Panel_ExtensionPropertyHeight = panel_ExtensionPropertyHeight;
                            pnlModel.Panel_GeorgianBarArtNo = panel_GeorgianBarArtNo;
                            pnlModel.Panel_GeorgianBar_VerticalQty = panel_GeorgianBar_VerticalQty;
                            pnlModel.Panel_GeorgianBar_HorizontalQty = panel_GeorgianBar_HorizontalQty;
                            pnlModel.Panel_GeorgianBarOptionVisibility = panel_GeorgianBarOptionVisibility; ;
                            pnlModel.Panel_HingeOptions = panel_HingeOptions;
                            pnlModel.Panel_HingeOptionsPropertyHeight = panel_HingeOptionsPropertyHeight;
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
                            #endregion
                            _frameModel.Lst_Panel.Add(pnlModel);
                            pnlModel.Imager_SetDimensionsToBind_FrameParent();
                            IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, pnlModel, this);
                            UserControl panelPropUC = (UserControl)panelPropUCP.GetPanelPropertiesUC();
                            panelPropUC.Dock = DockStyle.Top;
                            GetFrameProperties(_frameModel.Frame_ID).GetFramePropertiesPNL().Controls.Add(panelPropUC);
                            if (row_str.Contains("FixedPanel"))
                            {
                                _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                                _frameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                                pnlModel.AdjustPropertyPanelHeight("addGlass");
                                IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC,
                                                                                           pnlModel,
                                                                                           _frameModel,
                                                                                           this,
                                                                                           _frameUCPresenter);
                                IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                                _frameModel.Frame_UC.Controls.Add((UserControl)fixedUC);

                                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            }
                            else if (row_str.Contains("CasementPanel"))
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
                                ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC,
                                                                                                    pnlModel,
                                                                                                    _frameModel,
                                                                                                    this,
                                                                                                    _frameUCPresenter);
                                ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                                _frameModel.Frame_UC.Controls.Add((UserControl)casementUC);
                                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            }
                            else if (row_str.Contains("AwningPanel"))
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
                                IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC,
                                                                                              pnlModel,
                                                                                              _frameModel,
                                                                                              this,
                                                                                              _frameUCPresenter);
                                IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                                _frameModel.Frame_UC.Controls.Add((UserControl)awningUC);
                                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            }
                            else if (row_str.Contains("SlidingPanel"))
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
                                ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC,
                                                                                                 pnlModel,
                                                                                                 _frameModel,
                                                                                                 this,
                                                                                                 _frameUCPresenter);
                                ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                                _frameModel.Frame_UC.Controls.Add((UserControl)slidingUC);
                                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            }
                            else if (row_str.Contains("TiltNTurnPanel"))
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
                                ITiltNTurnPanelUCPresenter tiltNTurnUCP = _tiltNTurnUCP.GetNewInstance(_unityC,
                                                                                                       pnlModel,
                                                                                                       _frameModel,
                                                                                                       this,
                                                                                                       _frameUCPresenter);
                                ITiltNTurnPanelUC tiltnTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                                _frameModel.Frame_UC.Controls.Add((UserControl)tiltnTurnUC);
                                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            }
                            else if (row_str.Contains("LouverPanel"))
                            {
                                _frameModel.AdjustPropertyPanelHeight("Panel", "add");
                                ILouverPanelUCPresenter louverPanelUCP = _louverPanelUCP.GetNewInstance(_unityC,
                                                                                                        pnlModel,
                                                                                                        _frameModel,
                                                                                                        this,
                                                                                                        _frameUCPresenter);
                                ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                                _frameModel.Frame_UC.Controls.Add((UserControl)louverPanelUC);
                                _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                            }
                            _basePlatformPresenter.InvalidateBasePlatform();
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