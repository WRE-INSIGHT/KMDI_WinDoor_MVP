using ModelLayer.Model.Quotation.WinDoor;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IChangeItemColorPresenter
    {
        IChangeItemColorPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, IWindoorModel windoorModel);
        void ShowView();
    }
}