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
using CommonComponents;
using Unity;
using System.Linq;

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
        //private IPanelModel _panelModel;

        private ILoginView _loginView;
        private IItemInfoUC _itemInfoUC;
        private IFrameUC _frameUC;
        private IFramePropertiesUC _framePropertiesUC;

        private IQuotationServices _quotationServices;
        private IWindoorServices _windoorServices;
        private IFrameServices _frameServices;
        private IPanelServices _panelServices;

        private IFrameUCPresenter _frameUCPresenter;
        private IBasePlatformPresenter _basePlatformPresenter;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IItemInfoUCPresenter _itemInfoUCPresenter;
        private IFramePropertiesUCPresenter _framePropertiesUCPresenter;
        private IControlsUCPresenter _controlsUCP;

        private IFixedPanelUCPresenter _fixedPanelUCPresenter;

        Panel _pnlMain, _pnlItems, _pnlPropertiesBody, _pnlControlSub;

        private FrameModel.Frame_Padding frameType;
        
        private string input_qrefno;

        #endregion

        #region GetSet
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
                             IControlsUCPresenter controlsUCP)
        {
            _mainView = mainView;
            _frameUCPresenter = frameUCPresenter;
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
        }
        #region Events
        
        private void OnLabelSizeClickEventRaised(object sender, EventArgs e)
        {
            _frmDimensionPresenter.SetPresenters(this);
            _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.ChangeBasePlatformSize;
            _frmDimensionPresenter.SetProfileType(_windoorModel.WD_profile);
            _frmDimensionPresenter.SetHeight();
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
                _unityC, "Awning Panel", new Thumbs_AwningPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Casement Panel", new Thumbs_CasementPanelUC()).GetControlUC());

            _pnlControlSub.Controls.Add(
                (UserControl)_controlsUCP.GetNewInstance(
                _unityC, "Fixed Panel", new Thumbs_FixedPanelUC()).GetControlUC());
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
                    AddQuotationModel(input_qrefno);

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
                        _windoorModel = AddWindoorModel(frmDimension_numWd,
                                                        frmDimension_numHt,
                                                        frmDimension_profileType);
                        AddWndrList_QuotationModel(_windoorModel);

                        _basePlatformPresenter.SetWindoorModel(_windoorModel);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());

                        AddItemInfoUC(_windoorModel);

                        _basePlatformPresenter.InvalidateBasePlatform();
                        //_basePlatformPresenter.Invalidate_flpMain();
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
                        _windoorModel = AddWindoorModel(frmDimension_numWd,
                                                        frmDimension_numHt,
                                                        frmDimension_profileType);
                        AddWndrList_QuotationModel(_windoorModel);

                        _basePlatformPresenter.SetWindoorModel(_windoorModel);
                        AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());

                        AddItemInfoUC(_windoorModel); //add item information user control

                        _basePlatformPresenter.InvalidateBasePlatform();
                        //_basePlatformPresenter.Invalidate_flpMain();
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
                        _frameModel = AddFrameModel(frmDimension_numWd, frmDimension_numHt, frameType);
                        AddFrameList_WindoorModel(_frameModel);
                        AddFrameUC(_frameModel);
                        AddFramePropertiesUC(_frameModel);

                        _basePlatformPresenter.InvalidateBasePlatform();
                        //_basePlatformPresenter.Invalidate_flpMain();
                        SetMainViewTitle(input_qrefno,
                                         _windoorModel.WD_name,
                                         _windoorModel.WD_profile,
                                         false);

                         Console.WriteLine("Visible Frames: " + _windoorModel.GetAllVisibleFrames().Count());

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
                //_basePlatformPresenter.Invalidate_flpMain();
            }
        }
        #endregion

        #region Functions
        private Dictionary<string, Binding> CreateBindingDictionary_MainPresenter()
        {
            Dictionary<string, Binding> mainPresenterBinding = new Dictionary<string, Binding>();
            mainPresenterBinding.Add("WD_Dimension", new Binding("Text", _windoorModel, "WD_Dimension", true, DataSourceUpdateMode.OnPropertyChanged));

            return mainPresenterBinding;
        }

        public void AddBasePlatform(IBasePlatformUC basePlatform)
        {
            _pnlMain.Controls.Add((UserControl)basePlatform);
        }

        public void AddQuotationModel(string quotation_ref_no,
                                      List<IWindoorModel> lst_wndr = null)
        {
            if (lst_wndr == null)
            {
                lst_wndr = new List<IWindoorModel>();
            }
            _quotationModel = _quotationServices.CreateQuotationModel(quotation_ref_no, lst_wndr);
        }

        public IWindoorModel AddWindoorModel(int WD_width,
                                             int WD_height,
                                             string WD_Profile,
                                             int WD_ID = 0,
                                             string WD_name = "",
                                             string WD_description = "",
                                             int WD_quantity = 1,
                                             bool WD_visibility = true,
                                             bool WD_orientation = true,
                                             int WD_zoom = 1,
                                             int WD_price = 0,
                                             decimal WD_discount = 0.0M,
                                             List<IFrameModel> lst_frame = null)
        {
            if (WD_ID == 0)
            {
                WD_ID = _quotationModel.Lst_Windoor.Count + 1;
            }
            if (WD_name == "")
            {
                WD_name = "Item " + WD_ID;
            }
            if (WD_description == "")
            {
                WD_description = WD_Profile;
            }
            if (lst_frame == null)
            {
                lst_frame = new List<IFrameModel>();
            }

            _windoorModel = _windoorServices.CreateWindoor(WD_ID,
                                                           WD_name,
                                                           WD_description,
                                                           WD_width,
                                                           WD_height,
                                                           WD_price,
                                                           WD_quantity,
                                                           WD_discount,
                                                           WD_visibility,
                                                           WD_orientation,
                                                           WD_zoom,
                                                           WD_Profile,
                                                           lst_frame);

            return _windoorModel;
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

        public void AddFrameUC(IFrameModel frameModel)
        {
            IFrameUCPresenter frameUCP = (FrameUCPresenter)_frameUCPresenter.GetNewInstance(_unityC, frameModel, this);
            _frameUC = frameUCP.GetFrameUC();
            _basePlatformPresenter.AddFrame(_frameUC);
        }

        public void AddFramePropertiesUC(IFrameModel frameModel)
        {
            IFramePropertiesUCPresenter FramePropertiesUCP = _framePropertiesUCPresenter.GetNewInstance(frameModel, _unityC, _frameUC);
            _framePropertiesUC = FramePropertiesUCP.GetFramePropertiesUC();
            _pnlPropertiesBody.Controls.Add((UserControl)_framePropertiesUC);
        }

        public IFrameModel AddFrameModel(int frame_width,
                                         int frame_height,
                                         FrameModel.Frame_Padding frame_type,
                                         int frame_id = 0,
                                         string frame_name = "",
                                         bool frame_visible = true,
                                         List<IPanelModel> lst_Panel = null)
        {
            if (frame_id == 0)
            {
                frame_id = _windoorModel.lst_frame.Count + 1;
            }
            if (frame_name == "")
            {
                frame_name = "Frame " + frame_id;
            }
            if (lst_Panel == null)
            {
                lst_Panel = new List<IPanelModel>();
            }
            _frameModel = _frameServices.CreateFrame(frame_id,
                                                     frame_name,
                                                     frame_width,
                                                     frame_height,
                                                     frame_type,
                                                     frame_visible,
                                                     lst_Panel);

            return _frameModel;
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
            return _windoorModel.GetPanelCount();
        }

        #endregion

    }
}