using PresentationLayer.Views;
using System;
using Unity;

namespace PresentationLayer.Presenter
{
    public class QuoteItemListPresenter : IQuoteItemListPresenter
    {
        IQuoteItemListView _quoteItemListView;

        private IUnityContainer _unityC;
        private IPrintQuotePresenter _printQuotePresenter;



        public QuoteItemListPresenter(IQuoteItemListView quoteItemListView, IPrintQuotePresenter printQuotePresenter)
        {
            _quoteItemListView = quoteItemListView;
            _printQuotePresenter = printQuotePresenter;

            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _quoteItemListView.TSbtnPrintClickEventRaised += new EventHandler(OnTSbtnPrintClickEventRaised);
        }

        private void OnTSbtnPrintClickEventRaised(object sender, EventArgs e)
        {
            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this);
            printQuote.GetPrintQuoteView().ShowPrintQuoteView();
        }


        public IQuoteItemListView GetQuoteItemListView()
        {
            return _quoteItemListView;
        }


        public IQuoteItemListPresenter GetNewInstance(IUnityContainer unityC)
        {
            unityC
                    .RegisterType<IQuoteItemListPresenter, QuoteItemListPresenter>()
                    .RegisterType<IQuoteItemListView, QuoteItemListView>();
            QuoteItemListPresenter quoteItemList = unityC.Resolve<QuoteItemListPresenter>();
            quoteItemList._unityC = unityC;
            //quoteItemList._printQuotePresenter = printQuotePresenter;

            return quoteItemList;
        }
    }
}
