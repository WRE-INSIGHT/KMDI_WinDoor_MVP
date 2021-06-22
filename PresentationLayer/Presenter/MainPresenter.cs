using PresentationLayer.Views;
using System;
using ModelLayer.Model.User;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels.Thumbs;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.PanelServices;
using Unity;
using System.Linq;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using static EnumerationTypeLayer.EnumerationTypes;
using System.Data;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        #region GlobalVar

        IMainView _mainView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IFrameModel _frameModel;

        private ILoginView _loginView;
        private IItemInfoUC _itemInfoUC;
        private IFrameUC _frameUC;
        private IFramePropertiesUC _framePropertiesUC;

        private IQuotationServices _quotationServices;
        private IWindoorServices _windoorServices;
        private IFrameServices _frameServices;
        private IPanelServices _panelServices;

        private IFrameUCPresenter _frameUCPresenter;
        private IFrameImagerUCPresenter _frameImagerUCPresenter;
        private IBasePlatformPresenter _basePlatformPresenter;
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCPresenter;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IItemInfoUCPresenter _itemInfoUCPresenter;
        private IFramePropertiesUCPresenter _framePropertiesUCPresenter;
        private IControlsUCPresenter _controlsUCP;

        private IFixedPanelUCPresenter _fixedPanelUCPresenter;
        private IExplosionPresenter _explosionPresenter;
        private IDividerPropertiesUCPresenter _divPropertiesUCP;
        private ICreateNewGlassPresenter _createNewGlassPresenter;
        private IChangeItemColorPresenter _changeItemColorPresenter;

        Panel _pnlMain, _pnlItems, _pnlPropertiesBody, _pnlControlSub;

        private FrameModel.Frame_Padding frameType;
        
        private string input_qrefno;

        CommonFunctions _commonfunc = new CommonFunctions();

        private DataTable _glassThicknessDT = new DataTable();
        private DataTable _glassTypeDT = new DataTable();
        private DataTable _spacerDT = new DataTable();
        private DataTable _colorDT = new DataTable();

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
                             IFixedPanelUCPresenter fixedPanelUCPresenter,
                             IPanelServices panelServices,
                             IControlsUCPresenter controlsUCP,
                             IBasePlatformImagerUCPresenter basePlatformImagerUCPresenter,
                             IFrameImagerUCPresenter frameImagerUCPresenter,
                             IExplosionPresenter explosionPresenter,
                             IDividerPropertiesUCPresenter divPropertiesUCP,
                             ICreateNewGlassPresenter createNewGlassPresenter,
                             IChangeItemColorPresenter changeItemColorPresenter)
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
            _fixedPanelUCPresenter = fixedPanelUCPresenter;
            _panelServices = panelServices;
            _controlsUCP = controlsUCP;
            _basePlatformImagerUCPresenter = basePlatformImagerUCPresenter;
            _explosionPresenter = explosionPresenter;
            _divPropertiesUCP = divPropertiesUCP;
            _createNewGlassPresenter = createNewGlassPresenter;
            _changeItemColorPresenter = changeItemColorPresenter;
            SubscribeToEventsSetup();
        }
        public IMainView GetMainView()
        {
            return _mainView;
        }

        public void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC)
        {
            _userModel = userModel;
            _loginView = loginView;
            _pnlMain = _mainView.GetPanelMain();
            _pnlItems = _mainView.GetPanelItems();
            _pnlPropertiesBody = _mainView.GetPanelPropertiesBody();
            _pnlControlSub = _mainView.GetPanelControlSub();
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
        }

        #region Events

        private void _mainView_glassTypeColorSpacerToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            string inputbox_title = "";
            DataTable dt = new DataTable();

            if (menu == _mainView.Glass_Type)
            {
                inputbox_title = "Glass Type";
                dt = _glassTypeDT;
            }
            else if (menu == _mainView.Spacer)
            {
                inputbox_title = "Spacer";
                dt = _spacerDT;
            }
            else if (menu == _mainView.Color)
            {
                inputbox_title = "Color";
                dt = _colorDT;
            }

            string input_box_str = Interaction.InputBox(inputbox_title, "Windoor Maker", "");
            if (input_box_str != "")
            {
                dt.Rows.Add(input_box_str);
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
            IExplosionPresenter explosionPresenter = _explosionPresenter.GetNewInstance(_unityC, _quotationModel, this, _windoorModel);
            explosionPresenter.ShowExplosionView();
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
                Scenario_Quotation(false, true, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "C70 Profile");
            }
            else if (tsmItem.Name == "PremiLineToolStripMenuItem")
            {
                Scenario_Quotation(false, true, false, frmDimensionPresenter.Show_Purpose.CreateNew_Item, 0, 0, "PremiLine Profile");
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
                    Scenario_Quotation(false, false, false,frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "");
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
                    Scenario_Quotation(true, false, false,frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "");
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
            Scenario_Quotation(false, false, true, frmDimensionPresenter.Show_Purpose.CreateNew_Frame, 0, 0, "");
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
                _unityC, "Multi-Panel (Transom)", new Thumbs_MultiPanelTransomUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Multi-Panel (Mullion)", new Thumbs_MultiPanelMullionUC()).GetControlUC());
            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Sliding Panel", new Thumbs_SlidingPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Awning Panel", new Thumbs_AwningPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Casement Panel", new Thumbs_CasementPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Fixed Panel", new Thumbs_FixedPanelUC()).GetControlUC());

            _glassThicknessDT.Columns.Add(CreateColumn("TotalThickness", "TotalThickness", "System.Decimal"));
            _glassThicknessDT.Columns.Add(CreateColumn("Description", "Description", "System.String"));
            _glassThicknessDT.Columns.Add(CreateColumn("Single", "Single", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Double", "Double", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Triple", "Triple", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Insulated", "Insulated", "System.Boolean"));
            _glassThicknessDT.Columns.Add(CreateColumn("Laminated", "Laminated", "System.Boolean"));

            _glassTypeDT.Columns.Add(CreateColumn("GlassType", "GlassType", "System.String"));
            _spacerDT.Columns.Add(CreateColumn("Spacer", "Spacer", "System.String"));
            _colorDT.Columns.Add(CreateColumn("Color", "Color", "System.String"));

            _glassTypeDT.Rows.Add("Anneled");
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
            _basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
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

        private void SetMainViewTitle(string qrefno, string itemname, string profiletype, bool saved)
        {
            _mainView.mainview_title = qrefno.ToUpper() + " >> " + itemname + " (" + profiletype + ")";
            _mainView.mainview_title = (saved == false) ? _mainView.mainview_title + "*" : _mainView.mainview_title.Replace("*", "");
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
                                       frmDimensionPresenter.Show_Purpose purpose,
                                       int frmDimension_numWd,
                                       int frmDimension_numHt,
                                       string frmDimension_profileType)
        {
            if (frmDimension_numWd == 0 && frmDimension_numHt == 0) //from Quotation Input box to here
            {
                if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame)
                {
                    Clearing_Operation();
                }
                else if (QoutationInputBox_OkClicked && !NewItem_OkClicked && !AddedFrame)
                {
                    SetMainViewTitle(input_qrefno.ToUpper());
                    ItemToolStrip_Enable();
                    _quotationModel = _quotationServices.AddQuotationModel(input_qrefno);

                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.Quotation;
                    _frmDimensionPresenter.SetProfileType("C70 Profile");
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame)
                {
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.CreateNew_Item;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = true;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = false;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame)
                {
                    _frmDimensionPresenter.SetValues(_windoorModel.WD_width, _windoorModel.WD_height);
                    _frmDimensionPresenter.SetPresenters(this);
                    _frmDimensionPresenter.purpose = purpose;
                    _frmDimensionPresenter.SetProfileType(frmDimension_profileType);
                    _frmDimensionPresenter.mainPresenter_qoutationInputBox_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_newItem_ClickedOK = false;
                    _frmDimensionPresenter.mainPresenter_AddedFrame_ClickedOK = true;
                    _frmDimensionPresenter.SetHeight();
                    _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                }
            }
            else if (frmDimension_numWd != 0 && frmDimension_numHt != 0) //from frmDimension to here
            {
                if (QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame)
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
                        AddWndrList_QuotationModel(_windoorModel);

                        _mainView.Zoom = _windoorModel.WD_zoom;

                        _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                        _mainView.GetThis().Controls.Add(bpUC);
                        //bpUC.BringToFront();

                        _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());

                        AddItemInfoUC(_windoorModel);
                        
                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);
                        ItemToolStrip_Enable();
                        CreateNewWindoorBtn_Enable();
                        BotToolStrip_Enable();

                        _mainView.RemoveBinding(_mainView.GetLblSize());
                        _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());
                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }
                else if (!QoutationInputBox_OkClicked && NewItem_OkClicked && !AddedFrame) //Add new Item
                {
                    if (purpose == frmDimensionPresenter.Show_Purpose.CreateNew_Item)
                    {
                        _windoorModel = _windoorServices.AddWindoorModel(frmDimension_numWd,
                                                                         frmDimension_numHt,
                                                                         frmDimension_profileType,
                                                                         _quotationModel.Lst_Windoor.Count() + 1,
                                                                         Base_Color._Ivory,
                                                                         Foil_Color._Walnut,
                                                                         Foil_Color._Walnut);
                        AddWndrList_QuotationModel(_windoorModel);

                        _basePlatformImagerUCPresenter = _basePlatformImagerUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        UserControl bpUC = (UserControl)_basePlatformImagerUCPresenter.GetBasePlatformImagerUC();
                        _mainView.GetThis().Controls.Add(bpUC);
                        //bpUC.BringToFront();

                        _basePlatformPresenter = _basePlatformPresenter.GetNewInstance(_unityC, _windoorModel, this);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());

                        AddItemInfoUC(_windoorModel); //add item information user control
                        
                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);

                        BotToolStrip_Enable();
                        CreateNewWindoorBtn_Enable();

                        _mainView.RemoveBinding(_mainView.GetLblSize());
                        _mainView.ThisBinding(CreateBindingDictionary_MainPresenter());

                        _pnlPropertiesBody.Controls.Clear(); //Clearing Operation
                        _basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
                        _pnlItems.VerticalScroll.Value = _pnlItems.VerticalScroll.Maximum;
                        _pnlItems.PerformLayout();

                        _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                    }
                }
                else if (!QoutationInputBox_OkClicked && !NewItem_OkClicked && AddedFrame) //add frame
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
                                                                   frameID);
                        AddFrameList_WindoorModel(_frameModel);
                        IFramePropertiesUCPresenter framePropUCP =  AddFramePropertiesUC(_frameModel);
                        AddFrameUC(_frameModel, framePropUCP);

                        _basePlatformImagerUCPresenter.InvalidateBasePlatform();
                        _basePlatformPresenter.InvalidateBasePlatform();
                        SetMainViewTitle(input_qrefno,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);

                         Console.WriteLine("Visible Frames: " + _windoorModel.lst_frame.Count());

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
                _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
                _basePlatformPresenter.InvalidateBasePlatform();
                _basePlatformPresenter.Invalidate_flpMainControls();
                //_basePlatformPresenter_willRenderImg.InvalidateBasePlatform();
                //_basePlatformPresenter_willRenderImg.Invalidate_flpMain();
            }
        }
        #endregion

        #region Functions

        public void Run_GetListOfMaterials_SpecificItem()
        {
            _quotationModel.GetListOfMaterials(_windoorModel);
        }

        private void Fit_MyControls_byControlsLocation()
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

        private void FitControls_InsideMultiPanel()
        {
            foreach (IFrameModel frames in _windoorModel.lst_frame)
            {
                foreach (IMultiPanelModel mpanel in frames.Lst_MultiPanel)
                {
                    if (mpanel.MPanelLst_Objects.Count() == (mpanel.MPanel_Divisions * 2) + 1)
                    {
                        mpanel.Fit_MyControls_ToBindDimensions();
                    }
                }
            }
        }
        private Dictionary<string, Binding> CreateBindingDictionary_MainPresenter()
        {
            Dictionary<string, Binding> mainPresenterBinding = new Dictionary<string, Binding>();
            mainPresenterBinding.Add("WD_Dimension", new Binding("Text", _windoorModel, "WD_Dimension", true, DataSourceUpdateMode.OnPropertyChanged));
            mainPresenterBinding.Add("WD_zoom", new Binding("Zoom", _windoorModel, "WD_zoom", true, DataSourceUpdateMode.OnPropertyChanged));

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
            IItemInfoUCPresenter itemInfoUCP = (ItemInfoUCPresenter)_itemInfoUCPresenter.GetNewInstance(wndr, _unityC);
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

            _basePlatformImagerUCPresenter.AddFrame(frameImagerUCP.GetFrameImagerUC());
        }

        public IFramePropertiesUCPresenter AddFramePropertiesUC(IFrameModel frameModel)
        {
            IFramePropertiesUCPresenter FramePropertiesUCP = _framePropertiesUCPresenter.GetNewInstance(frameModel, _unityC, this);
            _framePropertiesUC = FramePropertiesUCP.GetFramePropertiesUC();
            _pnlPropertiesBody.Controls.Add((UserControl)_framePropertiesUC);

            return FramePropertiesUCP;
        }

        public void AddFrameList_WindoorModel(IFrameModel frameModel)
        {
            _windoorModel.lst_frame.Add(frameModel);
        }

        public void DeleteFrame_OnFrameList_WindoorModel(IFrameModel frameModel)
        {
            _windoorModel.lst_frame.Remove(frameModel);
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
            _mainView.GetLblSelectedDivider().Visible = true;
            _mainView.GetLblSelectedDivider().Text = divModel.Div_Name + " Selected";
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