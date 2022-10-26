using CommonComponents;
using System;

namespace PresentationLayer.Views
{
    public interface IExchangeRateView : IViewCommon
    {
        event EventHandler ExchangeRateViewLoadEventRaised;
        event EventHandler nudExchangeRateValueChangedEventRaised;

        void ShowExchangeRate();
    }
}