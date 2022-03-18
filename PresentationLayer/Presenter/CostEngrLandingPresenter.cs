using ModelLayer.Model.User;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CostEngrLandingPresenter : ICostEngrLandingPresenter
    {
        ICostEngrLandingView _CELandingView;

        private IUnityContainer _unityC;
        private IUserModel _userModel;
        private ILoginView _loginView;

        public CostEngrLandingPresenter(ICostEngrLandingView CELandingView)
        {
            _CELandingView = CELandingView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _CELandingView.CostEngrLandingViewLoadEventRaised += _CELandingView_CostEngrLandingViewLoadEventRaised;
        }

        private void _CELandingView_CostEngrLandingViewLoadEventRaised(object sender, EventArgs e)
        {

        }

        public void ShowThisView()
        {
            _CELandingView.ShowThis();
        }

        public void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC)
        {
            _userModel = userModel;
            _loginView = loginView;
            _unityC = unityC;
        }
    }
}
