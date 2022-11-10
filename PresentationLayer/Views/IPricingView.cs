using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPricingView
    {
        event DataGridViewRowPostPaintEventHandler dgvPriceListRowPostPaintEventRaised;
        event EventHandler PricingViewLoadEventRaised;
        event EventHandler cmbFilterSelectedValueChangedEventRaised;

        DataGridView GetDgvPrice();

        void ShowPricingList();
    }
}