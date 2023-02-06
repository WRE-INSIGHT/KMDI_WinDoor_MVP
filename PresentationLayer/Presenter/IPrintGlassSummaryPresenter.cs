using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPrintGlassSummaryPresenter
    {
        IPrintGlassSummaryView GetPrintGlassSummaryView();
        IPrintGlassSummaryPresenter GetNewInstance(IUnityContainer unityC,
                                                   IQuoteItemListPresenter quoteItemListPresenter,
                                                   IMainPresenter mainPresenter,
                                                   IWindoorModel windoorModel,
                                                   IQuotationModel quotationModel);
    }
}
