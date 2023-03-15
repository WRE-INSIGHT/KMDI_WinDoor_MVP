using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IExchangeRateView : IViewCommon
    {
        event EventHandler ExchangeRateViewLoadEventRaised;
        event EventHandler nudExchangeRateValueChangedEventRaised;
        event EventHandler nudExchangeRateAUDValueChangedEventRaised;
        NumericUpDown GetNumerinUpDown();
        NumericUpDown GetNumericUpDownAUD();
        void ShowExchangeRate();
    }
}