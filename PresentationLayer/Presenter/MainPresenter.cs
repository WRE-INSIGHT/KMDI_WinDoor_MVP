using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.User;
using System.IO;
using System.Windows.Forms;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views.UserControls;
using Unity;
using Unity.Lifetime;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        IMainView _mainView;
        private IUserModel _userModel;
        private ILoginView _loginView;
        private IFrameUCPresenter _frameUCPresenter;

        Panel _basePlatform;

        public MainPresenter(IMainView mainView, IFrameUCPresenter frameUCPresenter)
        {
            _mainView = mainView;
            _frameUCPresenter = frameUCPresenter;
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
            _basePlatform = _mainView.GetBasePlatform();
        }
        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
            _mainView.MainViewClosingEventRaised += new EventHandler(OnMainViewClosingEventRaised);
            _mainView.OpenToolStripButtonClickEventRaised += new EventHandler(OnOpenToolStripButtonClickEventRaised);
            _mainView.NewFrameButtonClickEventRaised += new EventHandler(OnNewFrameButtonClickEventRaised);
        }

        private void OnNewFrameButtonClickEventRaised(object sender, EventArgs e)
        {
            // FrameUC frame = new FrameUC();
            //frame = (FrameUC)_frameUCPresenter.GetFrameUC();
            _basePlatform.Controls.Add((FrameUC)_frameUCPresenter.GetFrameUC());
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IFrameUC, FrameUC>();
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

        public void OnMainViewLoadEventRaised(object sender, EventArgs e)
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
    }
}
