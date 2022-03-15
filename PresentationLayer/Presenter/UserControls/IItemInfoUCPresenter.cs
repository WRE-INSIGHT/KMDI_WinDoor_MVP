using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IItemInfoUCPresenter
    {
        IItemInfoUC GetItemInfoUC();
        IItemInfoUCPresenter GetNewInstance(IWindoorModel wndr, IUnityContainer unityC, IMainPresenter mainPresenter);
    }
}