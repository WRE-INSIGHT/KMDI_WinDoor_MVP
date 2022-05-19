using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class QuoteItemListPresenter : IQuoteItemListPresenter
    {
        IQuoteItemListView _quoteItemListView;

        private IUnityContainer _unityC;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;



        public QuoteItemListPresenter(IQuoteItemListView quoteItemListView,
                                      IPrintQuotePresenter printQuotePresenter)
        {
            _quoteItemListView = quoteItemListView;
            _printQuotePresenter = printQuotePresenter;

            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _quoteItemListView.TSbtnPrintClickEventRaised += new EventHandler(OnTSbtnPrintClickEventRaised);
            _quoteItemListView.QuoteItemListViewLoadEventRaised += _quoteItemListView_QuoteItemListViewLoadEventRaised;
        }

        private void _quoteItemListView_QuoteItemListViewLoadEventRaised(object sender, EventArgs e)
        {
            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                IQuoteItemListUCPresenter quoteItemListUCP = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel);
                UserControl quoteItem = (UserControl)quoteItemListUCP.GetiQuoteItemListUC();
                _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                quoteItem.Dock = DockStyle.Top;
                quoteItem.BringToFront();

                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                quoteItemListUCP.GetiQuoteItemListUC().GetTboxItemName().Text = wdm.WD_name;
                quoteItemListUCP.GetiQuoteItemListUC().GetTboxDimension().Text = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString();
                quoteItemListUCP.GetiQuoteItemListUC().GetRtboxDesc().Text = "";
                quoteItemListUCP.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
            }

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




        public IQuoteItemListPresenter GetNewInstance(IUnityContainer unityC,
                                                      IQuotationModel quotationModel,
                                                      IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                                      IWindoorModel windoorModel)
        {
            unityC
                    .RegisterType<IQuoteItemListPresenter, QuoteItemListPresenter>()
                    .RegisterType<IQuoteItemListView, QuoteItemListView>();
            QuoteItemListPresenter quoteItemList = unityC.Resolve<QuoteItemListPresenter>();
            quoteItemList._unityC = unityC;
            quoteItemList._quotationModel = quotationModel;
            quoteItemList._quoteItemListUCPresenter = quoteItemListUCPresenter;
            quoteItemList._windoorModel = windoorModel;
            //quoteItemList._printQuotePresenter = printQuotePresenter;

            return quoteItemList;
        }
    }
}
