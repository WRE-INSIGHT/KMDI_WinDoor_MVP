using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPrintQuotePresenter
    {
        IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                            IQuoteItemListPresenter quoteItemListPresenter,
                                            IMainPresenter mainPresenter); //
        IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                            IMainPresenter mainPresenter);

        IPrintQuoteView GetPrintQuoteView();
    }
}
