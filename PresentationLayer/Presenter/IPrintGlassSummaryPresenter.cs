using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPrintGlassSummaryPresenter
    {
        IPrintGlassSummaryView GetPrintGlassSummaryView();
        IPrintGlassSummaryPresenter GetNewInstance(IUnityContainer unityC,
                                                   IQuoteItemListPresenter quoteItemListPresenter,
                                                   IMainPresenter mainPresenter);
    }
}
