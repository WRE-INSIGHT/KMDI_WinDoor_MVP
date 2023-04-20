using ModelLayer.Model.Quotation;
using PresentationLayer.Views;
using System.Collections.Generic;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPrintQuotePresenter
    {
        IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                            IQuoteItemListPresenter quoteItemListPresenter,
                                            IMainPresenter mainPresenter,
                                            IQuotationModel _quotationModel); //
        IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                            IMainPresenter mainPresenter);

        IPrintQuoteView GetPrintQuoteView();
        void PrintRDLCReport();
        void EventLoad();
        void printAnnexRDLC();
    }
}
