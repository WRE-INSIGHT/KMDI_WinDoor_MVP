using ModelLayer.Model.User;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICostEngrLandingPresenter
    {
        void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC);
        void ShowThisView();
    }
}