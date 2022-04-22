using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Services.UserServices;
using ModelLayer.Model.User;
using CommonComponents;
using QueryLayer.DataAccess.Repositories.Specific;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class LoginPresenter : BaseSpecificRepository, ILoginPresenter
    {
        ILoginView _loginView;
        private IMainPresenter _mainPresenter;
        private ICostEngrLandingPresenter _CELandingPresenter;
        private IUserServices _userService;
        private IUserLoginModel _userLoginModel;
        private IUnityContainer _unityC;

        public ILoginView GetLoginView(IUnityContainer unityC)
        {
            _unityC = unityC;
            return _loginView;
        }

        public void SetMainView(ILoginView loginView)
        {
            _loginView = loginView;
        }

        public LoginPresenter(ILoginView loginView, 
                              IMainPresenter mainPresenter, 
                              IUserServices userService, 
                              IUserLoginModel userLoginModel,
                              ICostEngrLandingPresenter CELandingPresenter)
        {
            _loginView = loginView;
            _mainPresenter = mainPresenter;
            _userService = userService;
            _userLoginModel = userLoginModel;
            _CELandingPresenter = CELandingPresenter;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _loginView.FormLoadEventRaised += new EventHandler(OnFormLoadEventRaised);
            _loginView.LoginBtnClickEventRaised += new EventHandler(OnLoginBtnClickEventRaised);
            _loginView.CancelBtnClickEventRaised += new EventHandler(OnCancelBtnClickEventRaised);
            _loginView.OffLoginBtnClickEventRaised += new EventHandler(OnOffLoginBtnClickEventRaised);
        }

        private void OnFormLoadEventRaised(object sender, EventArgs e)
        {
            _loginView.username = Properties.Settings.Default.Username;
            _loginView.password = Decrypt(Properties.Settings.Default.Password);
            _loginView.chkRememberMe = Properties.Settings.Default.RememberMe;
        }

        private void OnOffLoginBtnClickEventRaised(object sender, EventArgs e)
        {
            IUserModel offline_model = _userService.Offline_Login();
            _mainPresenter.SetValues(offline_model, _loginView, _unityC);
            _mainPresenter.GetMainView().ShowMainView();
            _loginView.frmVisibility = false;
        }

        private void OnCancelBtnClickEventRaised(object sender, EventArgs e)
        {
            _loginView.CloseLoginView();
        }

        private async void OnLoginBtnClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                _loginView.pboxVisibility = true;
                _userLoginModel.Username = _loginView.username;
                _userLoginModel.Password = _loginView.password;
                IUserModel userModel = await _userService.Login_Prsntr(_userLoginModel);

                if (userModel != null)
                {
                    _mainPresenter.SetValues(userModel, _loginView, _unityC);
                    _mainPresenter.Set_User_View();
                    _mainPresenter.GetMainView().ShowMainView();
                    setPropertiesSettings();
                    _loginView.frmVisibility = false;
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _loginView.pboxVisibility = false;
            }
        }

        private void setPropertiesSettings()
        {
            if (_loginView.chkRememberMe == true)
            {
                Properties.Settings.Default.Username = _loginView.username;
                Properties.Settings.Default.Password = Encrypt(_loginView.password);
                Properties.Settings.Default.RememberMe = _loginView.chkRememberMe;
            }
            else if (_loginView.chkRememberMe == false)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = Encrypt("");
                Properties.Settings.Default.RememberMe = _loginView.chkRememberMe;
            }
        }
    }
}
