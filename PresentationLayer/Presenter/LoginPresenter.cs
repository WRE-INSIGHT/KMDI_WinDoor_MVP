using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenter
{
    class LoginPresenter : ILoginPresenter
    {
        ILoginView _loginView;
        private IMainPresenter _mainPresenter;

        public ILoginView GetLoginView() { return _loginView; }

        public void SetMainView(ILoginView loginView)
        {
            _loginView = loginView;
        }

        public LoginPresenter(ILoginView loginView, IMainPresenter mainPresenter)
        {
            _loginView = loginView;
            _mainPresenter = mainPresenter;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _loginView.LoginBtnClickEventRaised += new EventHandler(OnLoginBtnClickEventRaised);
        }

        private void OnLoginBtnClickEventRaised(object sender, EventArgs e)
        {
            _mainPresenter.GetMainView().ShowMainView();
        }
    }
}
