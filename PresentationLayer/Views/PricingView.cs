using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class PricingView : Form, IPricingView
    {
        public PricingView()
        {
            InitializeComponent();
        }

        public event EventHandler PricingViewLoadEventRaised;
        public event DataGridViewRowPostPaintEventHandler dgvPriceListRowPostPaintEventRaised;

        public DataGridView GetDgvPrice()
        {
            return dgv_priceList;
        }

        public void ShowPricingList()
        {
            this.Show();
        }

        private void PricingView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PricingViewLoadEventRaised, e);
        }

        private void dgv_priceList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, dgvPriceListRowPostPaintEventRaised, e);
        }

    }
}
