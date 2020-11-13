using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.User;

namespace PresentationLayer.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        IMainView _mainView;
        private IUserModel _userModel;
        private ILoginView _loginView;

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
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
        }
        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
            _mainView.MainViewClosingEventRaised += new EventHandler(OnMainViewClosingEventRaised);
        }

        private void OnMainViewClosingEventRaised(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            _loginView.CloseLoginView();
        }

        public void OnMainViewLoadEventRaised(object sender, EventArgs e)
        {
            _mainView.Nickname = _userModel.Nickname;
        }

    }
}
