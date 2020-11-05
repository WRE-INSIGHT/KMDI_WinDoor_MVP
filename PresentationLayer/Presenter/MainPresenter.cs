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

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
            SubscribeToEventsSetup();
        }
        public IMainView GetMainView()
        {
            return _mainView;
        }
        public void SetUserModel(IUserModel userModel)
        {
            _userModel = userModel;
        }
        private void SubscribeToEventsSetup()
        {
            _mainView.MainViewLoadEventRaised += new EventHandler(OnMainViewLoadEventRaised);
        }

        public void OnMainViewLoadEventRaised(object sender, EventArgs e)
        {
            _mainView.Nickname = _userModel.Nickname;
        }

    }
}
