using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Services.UserServices;
using ModelLayer.Model.User;
using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    class LoginPresenter : ILoginPresenter
    {
        ILoginView _loginView;
        private IMainPresenter _mainPresenter;
        private IUserServices _userService;
        private IUserLoginModel _userLoginModel;

        public ILoginView GetLoginView() { return _loginView; }

        public void SetMainView(ILoginView loginView)
        {
            _loginView = loginView;
        }

        public LoginPresenter(ILoginView loginView, IMainPresenter mainPresenter, IUserServices userService, IUserLoginModel userLoginModel)
        {
            _loginView = loginView;
            _mainPresenter = mainPresenter;
            _userService = userService;
            _userLoginModel = userLoginModel;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _loginView.LoginBtnClickEventRaised += new EventHandler(OnLoginBtnClickEventRaised);
            _loginView.CancelBtnClickEventRaised += new EventHandler(OnCancelBtnClickEventRaised);
        }

        private void OnCancelBtnClickEventRaised(object sender, EventArgs e)
        {
            _loginView.CloseLoginView();
        }

        private void OnLoginBtnClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception)
            {

            }
            _loginView.pboxVisibility = false;
        }

        private async void Login()
        {
            _loginView.pboxVisibility = true;
            _userLoginModel.Username = _loginView.username;
            _userLoginModel.Password = _loginView.password;
            _userService.ValidateModel(_userLoginModel);
            IUserModel userModel = await Task.Run(() => _userService.Login(_userLoginModel));

            if (userModel != null)
            {
                _mainPresenter.SetValues(userModel, _loginView);
                _mainPresenter.GetMainView().ShowMainView();
                _loginView.frmVisibility = false;
            }
            else
            {
                throw new Prompts(new Exception(), "Login Failed", "", "", false);
            }
        }
    }
}
