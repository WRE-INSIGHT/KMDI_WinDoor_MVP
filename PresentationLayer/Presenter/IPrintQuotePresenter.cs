using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPrintQuotePresenter
    {
        IPrintQuotePresenter GetNewInstance(IUnityContainer unityC, IQuoteItemListPresenter quoteItemListPresenter, IMainPresenter mainPresenter); //
        IPrintQuoteView GetPrintQuoteView();
    }
}
