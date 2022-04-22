using ModelLayer.Model.User;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICostEngrLandingPresenter
    {
        ICostEngrLandingPresenter GetNewInstance(IUserModel userModel, IMainPresenter mainPresenter, IUnityContainer unityC);
        void ShowThisView();
    }
}