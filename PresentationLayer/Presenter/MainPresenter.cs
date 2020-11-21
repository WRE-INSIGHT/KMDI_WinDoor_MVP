using PresentationLayer.Views;
using System;
using ModelLayer.Model.User;
using ModelLayer.Model.Quotation;
using System.IO;
using System.Windows.Forms;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views.UserControls;
using Microsoft.VisualBasic;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        IMainView _mainView;
        private IUserModel _userModel;
        private ILoginView _loginView;
        private IFrameUCPresenter _frameUCPresenter;
        private IBasePlatformPresenter _basePlatformPresenter;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IQuotationModel _quotationModel;

        Panel _pnlMain;

        public MainPresenter(IMainView mainView, 
                             IFrameUCPresenter frameUCPresenter, 
                             IfrmDimensionPresenter frmDimensionPresenter,
                             IBasePlatformPresenter basePlatformPresenter)
        {
            _mainView = mainView;
            _frameUCPresenter = frameUCPresenter;
            _frmDimensionPresenter = frmDimensionPresenter;
            _basePlatformPresenter = basePlatformPresenter;
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
        }
        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
            _mainView.MainViewClosingEventRaised += new EventHandler(OnMainViewClosingEventRaised);
            _mainView.OpenToolStripButtonClickEventRaised += new EventHandler(OnOpenToolStripButtonClickEventRaised);
            _mainView.NewFrameButtonClickEventRaised += new EventHandler(OnNewFrameButtonClickEventRaised);
            _mainView.NewQuotationMenuItemClickEventRaised += new EventHandler(OnNewQuotationMenuItemClickEventRaised);
            _mainView.PanelMainSizeChangedEventRaised += new EventHandler(OnPanelMainSizeChangedEventRaised);
        }

        private void OnPanelMainSizeChangedEventRaised(object sender, EventArgs e)
        {
            Panel pnlMain = (Panel)sender;
            pnlMain.PerformLayout();
        }

        private void OnNewQuotationMenuItemClickEventRaised(object sender, EventArgs e)
        {
            // check if the _quotationModel is null or not.
            //_quotationModel == null, then createNew()
            //_quotationModel != null, then deleteExisting() and createNew()

            string input = Interaction.InputBox("Quotation Reference No.", "Windoor Maker", "");
            if (input != "" && input != "0")
            {
                //Clearing_Operation();
                //pnl_flpMain.Visible = false;
                //pnl_flpMain.Size = new Size(0, 0);
                //paint_pnlMain = false;

                //quotation_ref_no = input.ToUpper();
                //Text = quotation_ref_no;

                _frmDimensionPresenter.SetPresenters(this, _basePlatformPresenter);
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
    }
}