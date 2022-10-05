using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IScreenPresenter
    {
        IScreenView GetScreenView();
        IScreenPresenter CreateNewInstance(IUnityContainer unityC);
    }
}