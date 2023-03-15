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
        private IScreenPresenter _screenPresenter;

        public ExchangeRatePresenter(IExchangeRateView exchangeRateView)
        {
            _exchangeRateView = exchangeRateView;

            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _exchangeRateView.ExchangeRateViewLoadEventRaised += _exchangeRateView_ExchangeRateViewLoadEventRaised;
            _exchangeRateView.nudExchangeRateValueChangedEventRaised += _exchangeRateView_nudExchangeRateValueChangedEventRaised;
            _exchangeRateView.nudExchangeRateAUDValueChangedEventRaised += _exchangeRateView_nudExchangeRateAUDValueChangedEventRaised;
        }

        private void _exchangeRateView_nudExchangeRateAUDValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                _screenModel.Screen_ExchangeRateAUD = (int)((NumericUpDown)sender).Value;
                _exchangeRateView.GetNumericUpDownAUD().Value = _screenModel.Screen_ExchangeRateAUD;
                _screenPresenter.GetCurrentAmount();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ExchangeRateAUD " + ex.Message);
            }    
            
        }

        private void _exchangeRateView_nudExchangeRateValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                _screenModel.Screen_ExchangeRate = (int)((NumericUpDown)sender).Value;
                _exchangeRateView.GetNumerinUpDown().Value = _screenModel.Screen_ExchangeRate;
                _screenPresenter.GetCurrentAmount();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ExchangeRateEuro " + ex.Message);
            }
            
        }

        private void _exchangeRateView_ExchangeRateViewLoadEventRaised(object sender, EventArgs e)
        {
            _exchangeRateView.GetNumericUpDownAUD().Maximum = decimal.MaxValue;
            _exchangeRateView.GetNumerinUpDown().Maximum = decimal.MaxValue;
            _exchangeRateView.ThisBinding(CreateBindingDictionary());
            _exchangeRateView.GetNumerinUpDown().Value = _screenModel.Screen_ExchangeRate;
            _exchangeRateView.GetNumericUpDownAUD().Value = _screenModel.Screen_ExchangeRateAUD;
        }

        public IExchangeRateView GetExchangeRateView()
        {
            return _exchangeRateView;
        }

        public IExchangeRatePresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IScreenModel screenModel,
                                                        IScreenPresenter screenPresenter)
        {
            unityC
                    .RegisterType<IExchangeRateView, ExchangeRateView>()
                    .RegisterType<IExchangeRatePresenter, ExchangeRatePresenter>();
            ExchangeRatePresenter exchange = unityC.Resolve<ExchangeRatePresenter>();
            exchange._unityC = unityC;
            exchange._mainPresenter = mainPresenter;
            exchange._screenModel = screenModel;
            exchange._screenPresenter = screenPresenter;

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
