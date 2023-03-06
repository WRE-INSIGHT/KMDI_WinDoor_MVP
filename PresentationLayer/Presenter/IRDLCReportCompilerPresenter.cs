using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IRDLCReportCompilerPresenter
    {
        IRDLCReportCompilerView GetIRDLCReportCompilerView();
        IRDLCReportCompilerPresenter GetNewIntance(IUnityContainer unityC,
                                                   IQuotationModel quotaionModel,
                                                   IWindoorModel windoorModel,
                                                   IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                                   IPDFCompilerPresenter pdfCompilerPresenter,
                                                   IQuoteItemListPresenter quoteItemListPresenter,
                                                   IMainPresenter mainPresenter);
    }
}