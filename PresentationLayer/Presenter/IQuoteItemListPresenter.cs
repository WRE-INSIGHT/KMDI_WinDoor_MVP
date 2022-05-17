using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IQuoteItemListPresenter
    {
        IQuoteItemListView GetQuoteItemListView();
        IQuoteItemListPresenter GetNewInstance(IUnityContainer unityC);
    }
}
