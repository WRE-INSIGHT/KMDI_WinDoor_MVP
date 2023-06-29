using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class PriceHistoryView : Form, IPriceHistoryView
    {
        public PriceHistoryView()
        {
            InitializeComponent();
        }
        public Label PriceHistory
        {
            get
            {
                return lbl_priceHistory;
            }
            set
            {
                 lbl_priceHistory = value;
            }
        }

        public ComboBox cmbPriceHistory
        {
            get
            {
                return cmb_PriceHistory;
            }

            set
            {
                 cmb_PriceHistory = value;
            }
        }

        public event EventHandler PriceHistoryViewLoadEventRaised;
        public event EventHandler cmb_PriceHistorySelectedValueChangedEventRaised;
        private void PriceHistoryView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PriceHistoryViewLoadEventRaised, e);
        }

        private void cmb_PriceHistory_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmb_PriceHistorySelectedValueChangedEventRaised, e);
        }

        public void ShowPriceHistory()
        {
            this.Show();
        }
    }
}
