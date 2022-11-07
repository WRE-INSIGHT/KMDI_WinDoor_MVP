using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPricingView
    {
        event DataGridViewRowPostPaintEventHandler dgvPriceListRowPostPaintEventRaised;
        event EventHandler PricingViewLoadEventRaised;

        DataGridView GetDgvPrice();

        void ShowPricingList();
    }
}