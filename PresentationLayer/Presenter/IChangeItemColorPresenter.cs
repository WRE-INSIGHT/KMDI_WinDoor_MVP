using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IChangeItemColorPresenter
    {
        IChangeItemColorView GetChangeItemColorView();

        IChangeItemColorPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, IWindoorModel windoorModel);
        void ShowView();
    }
}