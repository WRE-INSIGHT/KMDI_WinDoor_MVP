using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class ExchangeRatePresenter : IExchangeRatePresenter
    {
        IExchangeRateView _exchangeRateView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public ExchangeRatePresenter(IExchangeRateView exchangeRateView)
        {
            _exchangeRateView = exchangeRateView;

            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _exchangeRateView.ExchangeRateViewLoadEventRaised += _exchangeRateView_ExchangeRateViewLoadEventRaised;
            _exchangeRateView.nudExchangeRateValueChangedEventRaised += _exchangeRateView_nudExchangeRateValueChangedEventRaised;
        }

        private void _exchangeRateView_nudExchangeRateValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_ExchangeRate = (int)((NumericUpDown)sender).Value;
        }

        private void _exchangeRateView_ExchangeRateViewLoadEventRaised(object sender, EventArgs e)
        {
            _exchangeRateView.ThisBinding(CreateBindingDictionary());
            _screenModel.Screen_ExchangeRate = 64;
        }

        public IExchangeRateView GetExchangeRateView()
        {
            return _exchangeRateView;
        }

        public IExchangeRatePresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IScreenModel screenModel)
        {
            unityC
                    .RegisterType<IExchangeRateView, IExchangeRateView>()
                    .RegisterType<IExchangeRatePresenter, ExchangeRatePresenter>();
            ExchangeRatePresenter exchange = unityC.Resolve<ExchangeRatePresenter>();
            exchange._unityC = unityC;
            exchange._mainPresenter = mainPresenter;
            exchange._screenModel = screenModel;

            return exchange;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_ExchangeRateVisibility", new Binding("Visible", _screenModel, "Screen_ExchangeRateVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_ExchangeRate", new Binding("Value", _screenModel, "Screen_ExchangeRate", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
