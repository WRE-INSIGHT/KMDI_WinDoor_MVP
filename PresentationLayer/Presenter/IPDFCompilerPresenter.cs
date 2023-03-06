using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPDFCompilerPresenter
    {
        IPDFCompilerView GetPDFCompilerView();
        IPDFCompilerPresenter GetNewInstance(IUnityContainer unityC,
                                             IQuotationModel quotationModel,
                                             IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                             IWindoorModel windoorModel,
                                             IQuoteItemListPresenter quoteItemListPresenter,
                                             IMainPresenter mainPresenter);
    }
}