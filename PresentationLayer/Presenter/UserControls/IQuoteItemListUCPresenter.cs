using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IQuoteItemListUCPresenter
    {
        IQuoteItemListUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel);
        IQuoteItemListUC GetiQuoteItemListUC();

    }
}
