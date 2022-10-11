using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class QuoteItemListUC : UserControl, IQuoteItemListUC
    {
        public QuoteItemListUC()
        {
            InitializeComponent();
        }

        public string ItemName
        {
            get
            {
                return tboxItemName.Text;
            }
            set
            {
                tboxItemName.Text = value;
            }
        }

        public string ItemNumber
        {
            get
            {
                return txt_ItemNumber.Text;
            }
            set
            {
                txt_ItemNumber.Text = value;
            }
        }

        public string itemWindoorNumber
        {
            get
            {
                return tboxWindoorNumber.Text;
            }
            set
            {
                tboxWindoorNumber.Text = value;
            }
        }

        public string itemDesc
        {
            get
            {
                return rtboxDesc.Text;
            }
            set
            {
                rtboxDesc.Text = value;
            }
        }

        public NumericUpDown itemQuantity
        {
            get
            {
                return NudItemQuantity;
            }
            set
            {
                NudItemQuantity.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown itemDiscount
        {
            get
            {
                return NudItemDiscount;
            }
            set
            {
                NudItemDiscount.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown itemPrice
        {
            get
            {
                return nudItemPrice;
            }
            set
            {
                nudItemPrice.Value = Convert.ToDecimal(value);
            }
        }

        public event EventHandler QuoteItemListUCLoadEventRaised;
        public event EventHandler LblPriceDoubleClickEventRaised;
        public event EventHandler LblDiscountDoubleClickEventRaised;
        public event EventHandler lblQuantityDoubleClickEventRaised;
        public event EventHandler NudItemQuantityValueChangedEventRaised;
        public event EventHandler NudItemDiscountValueChangedEventRaised;
        public event EventHandler NudItemPriceValueChangedEventRaised;
        public event EventHandler ComputeNetPriceTextChangeEventRaised;
        public event KeyEventHandler NudItemPriceKeyDownEventRaised;
        public event KeyEventHandler NudItemDiscountKeyDownEventRaised;
        public event KeyEventHandler NudItemQuantityKeyDownEventRaised;

        public PictureBox GetPboxItemImage()
        {
            return pboxItemImage;
        }
        public PictureBox GetPboxTopView()
        {
            return pboxTopView;
        }
        public Label GetLblQuantity()
        {
            return lblQuantity;
        }

        public Label GetLblDiscount()
        {
            return lblDiscount;
        }

        public Label GetLblPrice()
        {
            return lblPrice;
        }
        public Label GetLblNetPrice()
        {
            return lblNetPrice;
        }



        private void QuoteItemListUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, QuoteItemListUCLoadEventRaised, e);
        }

        private void ComputeNetPriceTextChange(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ComputeNetPriceTextChangeEventRaised, e);
        }

        private void lblQuantity_DoubleClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, lblQuantityDoubleClickEventRaised, e);
        }

        private void lblPrice_DoubleClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, LblPriceDoubleClickEventRaised, e);
        }

        private void lblDiscount_DoubleClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, LblDiscountDoubleClickEventRaised, e);
        }

        private void NudItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NudItemQuantityValueChangedEventRaised, e);
        }

        private void nudItemPrice_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NudItemPriceValueChangedEventRaised, e);
        }

        private void NudItemDiscount_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NudItemDiscountValueChangedEventRaised, e);
        }

        private void NudItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(sender, NudItemQuantityKeyDownEventRaised, e);
        }

        private void nudItemPrice_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(sender, NudItemPriceKeyDownEventRaised, e);
        }

        private void NudItemDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            EventHelpers.RaiseKeyEvent(sender, NudItemDiscountKeyDownEventRaised, e);
        }
    }
}
