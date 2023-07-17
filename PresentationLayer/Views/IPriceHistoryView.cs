using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPriceHistoryView
    {
        Label PriceHistory { get; set; }
        ComboBox cmbPriceHistory { get; set; }
        event EventHandler PriceHistoryViewLoadEventRaised;
        event EventHandler cmb_PriceHistorySelectedValueChangedEventRaised;
        void ShowPriceHistory();
    }
}