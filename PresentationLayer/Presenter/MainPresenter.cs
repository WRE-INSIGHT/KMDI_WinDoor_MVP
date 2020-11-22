using PresentationLayer.Views;
using System;
using ModelLayer.Model.User;
using ModelLayer.Model.Quotation;
using System.IO;
using System.Windows.Forms;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views.UserControls;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        IMainView _mainView;
        private IUserModel _userModel;
        private ILoginView _loginView;
        private IQuotationServices _quotationServices;
        private IWindoorServices _windoorServices;
        private IFrameUCPresenter _frameUCPresenter;
        private IBasePlatformPresenter _basePlatformPresenter;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IItemInfoUCPresenter _itemInfoUCPresenter;
        private IQuotationModel _quotationModel;

        Panel _pnlMain, _pnlItems;

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

        public MainPresenter(IMainView mainView,
                             IFrameUCPresenter frameUCPresenter,
                             IfrmDimensionPresenter frmDimensionPresenter,
                             IBasePlatformPresenter basePlatformPresenter,
                             IQuotationServices quotationServices,
                             IWindoorServices windoorServices,
                             IItemInfoUCPresenter itemInfoUCPresenter)
        {
            _mainView = mainView;
            _frameUCPresenter = frameUCPresenter;
            _frmDimensionPresenter = frmDimensionPresenter;
            _basePlatformPresenter = basePlatformPresenter;
            _quotationServices = quotationServices;
            _windoorServices = windoorServices;
            _itemInfoUCPresenter = itemInfoUCPresenter;
            SubscribeToEventsSetup();
        }
        public IMainView GetMainView()
        {
            return _mainView;
        }
        public void SetValues(IUserModel userModel, ILoginView loginView)
        {
            _userModel = userModel;
            _loginView = loginView;
            _pnlMain = _mainView.GetPanelMain();
            _pnlItems = _mainView.GetPanelItems();
        }
        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
            _mainView.MainViewClosingEventRaised += new EventHandler(OnMainViewClosingEventRaised);
            _mainView.OpenToolStripButtonClickEventRaised += new EventHandler(OnOpenToolStripButtonClickEventRaised);
            _mainView.NewFrameButtonClickEventRaised += new EventHandler(OnNewFrameButtonClickEventRaised);
            _mainView.NewQuotationMenuItemClickEventRaised += new EventHandler(OnNewQuotationMenuItemClickEventRaised);
            _mainView.PanelMainSizeChangedEventRaised += new EventHandler(OnPanelMainSizeChangedEventRaised);
            _mainView.CreateNewFrameClickEventRaised += new EventHandler(OnCreateNewFrameClickEventRaised);
        }

        private void OnCreateNewFrameClickEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmItem = (ToolStripMenuItem)sender;
            _frmDimensionPresenter.SetPresenters(this, _basePlatformPresenter);
            _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.CreateNew_Frame;

            if (tsmItem.Name == "C70ToolStripMenuItem")
            {
                _frmDimensionPresenter.SetProfileType("C70 Profile");
            }
            else if (tsmItem.Name == "PremiLineToolStripMenuItem")
            {
                _frmDimensionPresenter.SetProfileType("PremiLine");
            }

            _frmDimensionPresenter.SetHeight();
            _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
        }

        private void OnPanelMainSizeChangedEventRaised(object sender, EventArgs e)
        {
            Panel pnlMain = (Panel)sender;
            pnlMain.PerformLayout();
        }

        private string input_qrefno;
        private void OnNewQuotationMenuItemClickEventRaised(object sender, EventArgs e)
        {
            // check if the _quotationModel is null or not.
            //_quotationModel == null, then createNew()
            //_quotationModel != null, then deleteExisting() and createNew()

            input_qrefno = Interaction.InputBox("Quotation Reference No.", "Windoor Maker", "");
            if (input_qrefno != "" && input_qrefno != "0")
            {
                //Clearing_Operation();
                //pnl_flpMain.Visible = false;
                //pnl_flpMain.Size = new Size(0, 0);
                //paint_pnlMain = false;

                //quotation_ref_no = input.ToUpper();
                //Text = quotation_ref_no;

                _frmDimensionPresenter.SetPresenters(this, _basePlatformPresenter);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.Quotation;
                _frmDimensionPresenter.SetProfileType("C70 Profile");
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                //ProfileTypeToolStripMenuItem_Click(sender, e);
            }
        }

        private void OnNewFrameButtonClickEventRaised(object sender, EventArgs e)
        {
            FrameUCPresenter frameUCP = (FrameUCPresenter)_frameUCPresenter.GetNewInstance();
            _basePlatformPresenter.AddFrame(frameUCP.GetFrameUC());
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
        }

        public void AddBasePlatform(IBasePlatformUC basePlatform)
        {
            _pnlMain.Controls.Add((UserControl)basePlatform);
        }

        public void AddQuotationModel(string quotation_ref_no)
        {
            _quotationModel = _quotationServices.CreateQuotationModel(quotation_ref_no, new List<IWindoorModel>());
        }

        public IWindoorModel AddWindoorModel(int WD_width, 
                                             int WD_height,
                                             string WD_Profile,
                                             string WD_name = "",
                                             string WD_description = "",
                                             int WD_quantity = 1,
                                             bool WD_visibility = true,
                                             bool WD_orientation = true,
                                             int WD_zoom = 1,
                                             int WD_price = 0,
                                             decimal WD_discount = 0.0M)
        {
            int wd_id = _quotationModel.Lst_Windoor.Count + 1;
            if (WD_name == "")
            {
                WD_name = "Item " + wd_id;
            }
            IWindoorModel wndr = _windoorServices.CreateWindoor(wd_id, WD_name, WD_description, WD_width, WD_height, WD_price, WD_quantity, WD_discount, WD_visibility, WD_orientation, WD_zoom, WD_Profile);

            return wndr;
        }

        public void AddWndrList_QuotationModel(IWindoorModel wndr)
        {
            _quotationModel.Lst_Windoor.Add(wndr);
        }

        public void AddItemInfoUC(IWindoorModel wndr)
        {
            ItemInfoUCPresenter ItemInfoUCP = (ItemInfoUCPresenter)_itemInfoUCPresenter.GetNewInstance(wndr);
            _pnlItems.Controls.Add((UserControl)ItemInfoUCP.GetItemInfoUC());
        }

        public void ItemToolStrip_Enable()
        {
            _mainView.ItemToolStripEnabled = true;
        }

        public void SetMainViewTitle(string qrefno, string itemname, string profiletype, bool saved)
        {
            _mainView.mainview_title = qrefno.ToUpper() + " >> " + itemname + " (" + profiletype + ")";
            _mainView.mainview_title = (saved == false) ? _mainView.mainview_title + "*" : _mainView.mainview_title.Replace("*", "");
        }
    }
}