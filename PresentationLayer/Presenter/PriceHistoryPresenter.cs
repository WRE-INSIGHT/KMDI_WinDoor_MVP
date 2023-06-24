using ModelLayer.Model.Quotation;
using PresentationLayer.Views;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PriceHistoryPresenter : IPriceHistoryPresenter
    {
        IPriceHistoryView _priceHistoryView;
        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IQuotationModel _quotationModel;



        public PriceHistoryPresenter(IPriceHistoryView priceHistoryView)
        {
            _priceHistoryView = priceHistoryView;

            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _priceHistoryView.PriceHistoryViewLoadEventRaised += _priceHistoryView_PriceHistoryViewLoadEventRaised;
            _priceHistoryView.cmb_PriceHistorySelectedValueChangedEventRaised += _priceHistoryView_cmb_PriceHistorySelectedValueChangedEventRaised;
        }

        private void _priceHistoryView_cmb_PriceHistorySelectedValueChangedEventRaised(object sender, EventArgs e)
        {

        }

        private void _priceHistoryView_PriceHistoryViewLoadEventRaised(object sender, EventArgs e)
        {
            if (_quotationModel.lst_TotalPriceHistory.Count != 0)
            {
                foreach (string item in _quotationModel.lst_TotalPriceHistory)
                {
                    if (item.Contains("` COMPUTATION FOR SAVING `\n"))
                    {

                    }

                    GetFirstDateFromString(item);
                    _priceHistoryView.PriceHistory.Text += item;
                }
            }
        }

        static DateTime? GetFirstDateFromString(string inputText)
        {
            var regex = new Regex(@"\b\d{2}\.\d{2}.\d{4}\b");
            foreach (Match m in regex.Matches(inputText))
            {
                DateTime dt;
                if (DateTime.TryParseExact(m.Value, "MM.dd.yyyy\tHH:mm:ss", null, DateTimeStyles.RoundtripKind, out dt))
                    return dt;

                MessageBox.Show(m.ToString());

            }
            return null;
        }



        public IPriceHistoryView GetPriceHistoryView()
        {
            return _priceHistoryView;
        }

        public IPriceHistoryPresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IQuotationModel quotationModel)
        {
            unityC
                .RegisterType<IPriceHistoryView, PriceHistoryView>()
                .RegisterType<IPriceHistoryPresenter, PriceHistoryPresenter>();
            PriceHistoryPresenter priceHistory = unityC.Resolve<PriceHistoryPresenter>();

            priceHistory._unityC = unityC;
            priceHistory._mainPresenter = mainPresenter;
            priceHistory._quotationModel = quotationModel;

            return priceHistory;
        }
    }
}
