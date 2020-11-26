using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ILoginPresenter
    {
        ILoginView GetLoginView(IUnityContainer unityC);
        void SetMainView(ILoginView loginView);
    }
}