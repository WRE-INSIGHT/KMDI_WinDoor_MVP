using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ExchangeRateView : Form, IExchangeRateView
    {
        public ExchangeRateView() 
        {
            InitializeComponent();
        }

        public NumericUpDown GetNumerinUpDown()
        {
            return nud_ExchangeRate;
        }

        public NumericUpDown GetNumericUpDownAUD()
        {
            return nud_ExchangeRateAUD;
        }

        public event EventHandler nudExchangeRateAUDValueChangedEventRaised;
        public event EventHandler ExchangeRateViewLoadEventRaised;
        public event EventHandler nudExchangeRateValueChangedEventRaised;

        private void ExchangeRateView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ExchangeRateViewLoadEventRaised, e);
        }

        private void nud_ExchangeRate_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudExchangeRateValueChangedEventRaised, e);
        }

        private void nud_ExchangeRateAUD_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudExchangeRateAUDValueChangedEventRaised, e);
        }
        public void ShowExchangeRate()
        {
            this.Show();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_ExchangeRateVisibility"]);
            nud_ExchangeRate.DataBindings.Add(ModelBinding["Screen_ExchangeRate"]);
        }


    }
}
