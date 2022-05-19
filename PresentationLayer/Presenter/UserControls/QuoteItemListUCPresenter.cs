using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class QuoteItemListUCPresenter : IQuoteItemListUCPresenter
    {
        IQuoteItemListUC _quoteItemListUC;

        private IUnityContainer _unityC;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IWindoorModel _windoorModel;


        public QuoteItemListUCPresenter(IQuoteItemListUC quoteItemListUC,
                                        IQuoteItemListPresenter quoteItemListPresenter)
        {
            _quoteItemListUC = quoteItemListUC;
            _quoteItemListPresenter = quoteItemListPresenter;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _quoteItemListUC.QuoteItemListUCLoadEventRaised += _quoteItemListUC_QuoteItemListUCLoadEventRaised;
        }

        private void _quoteItemListUC_QuoteItemListUCLoadEventRaised(object sender, System.EventArgs e)
        {
            //  _quoteItemListUC.ThisBinding(CreateBindingDictionary());
        }

        public IQuoteItemListUC GetiQuoteItemListUC()
        {
            return _quoteItemListUC;
        }

        //public Dictionary<string, Binding> CreateBindingDictionary()
        //{
        //    Dictionary<string, Binding> bind = new Dictionary<string, Binding>();

        //    bind.Add("PbItemImage", new Binding("Image", _windoorModel, "WD_image", true, DataSourceUpdateMode.OnPropertyChanged));

        //    return bind;
        //}

        public IQuoteItemListUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IQuoteItemListUCPresenter, QuoteItemListUCPresenter>()
                .RegisterType<IQuoteItemListUC, QuoteItemListUC>();
            QuoteItemListUCPresenter quoteItem = unityC.Resolve<QuoteItemListUCPresenter>();
            quoteItem._unityC = unityC;
            quoteItem._windoorModel = windoorModel;
            //quoteItem._quoteItemListPresenter = quoteItemListPresenter;

            return quoteItem;
        }
    }
}
