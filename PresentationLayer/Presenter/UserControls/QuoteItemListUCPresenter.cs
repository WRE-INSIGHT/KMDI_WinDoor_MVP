using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class QuoteItemListUCPresenter : IQuoteItemListUCPresenter
    {
        IQuoteItemListUC _quoteItemListUC;

        private IUnityContainer _unityC;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IWindoorModel _windoorModel;

        Label _lblQuantity;
        Label _lblDiscount;
        Label _lblPrice;
        Label _lblNetPrice;
        NumericUpDown _nudItemQty;
        NumericUpDown _nudItemDiscount;
        NumericUpDown _nudItemPrice;

        decimal TotalNetPrice;

        public QuoteItemListUCPresenter(IQuoteItemListUC quoteItemListUC,
                                        IQuoteItemListPresenter quoteItemListPresenter)
        {
            _quoteItemListUC = quoteItemListUC;
            _quoteItemListPresenter = quoteItemListPresenter;
            _lblQuantity = _quoteItemListUC.GetLblQuantity();
            _lblDiscount = _quoteItemListUC.GetLblDiscount();
            _lblPrice = _quoteItemListUC.GetLblPrice();
            _lblNetPrice = _quoteItemListUC.GetLblNetPrice();
            _nudItemQty = _quoteItemListUC.itemQuantity;
            _nudItemDiscount = _quoteItemListUC.itemDiscount;
            _nudItemPrice = quoteItemListUC.itemPrice;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _quoteItemListUC.QuoteItemListUCLoadEventRaised += _quoteItemListUC_QuoteItemListUCLoadEventRaised;
            _quoteItemListUC.LblDiscountDoubleClickEventRaised += _quoteItemListUC_LblDiscountDoubleClickEventRaised;
            _quoteItemListUC.LblPriceDoubleClickEventRaised += _quoteItemListUC_LblPriceDoubleClickEventRaised;
            _quoteItemListUC.lblQuantityDoubleClickEventRaised += _quoteItemListUC_lblQuantityDoubleClickEventRaised;
            _quoteItemListUC.NudItemDiscountValueChangedEventRaised += _quoteItemListUC_NudItemDiscountValueChangedEventRaised;
            _quoteItemListUC.NudItemPriceValueChangedEventRaised += _quoteItemListUC_NudItemPriceValueChangedEventRaised;
            _quoteItemListUC.NudItemQuantityValueChangedEventRaised += _quoteItemListUC_NudItemQuantityValueChangedEventRaised;
            _quoteItemListUC.NudItemDiscountKeyDownEventRaised += _quoteItemListUC_NudItemDiscountKeyDownEventRaised;
            _quoteItemListUC.NudItemPriceKeyDownEventRaised += _quoteItemListUC_NudItemPriceKeyDownEventRaised;
            _quoteItemListUC.NudItemQuantityKeyDownEventRaised += _quoteItemListUC_NudItemQuantityKeyDownEventRaised;
            _quoteItemListUC.ComputeNetPriceTextChangeEventRaised += _quoteItemListUC_ComputeNetPriceTextChangeEventRaised;

        }

        private void _quoteItemListUC_ComputeNetPriceTextChangeEventRaised(object sender, System.EventArgs e)
        {
            decimal ItemPercentageDeduction = (decimal)(((double)100 - (double)_nudItemDiscount.Value) * (double)0.01);
            TotalNetPrice = Math.Round((_nudItemPrice.Value * _nudItemQty.Value) * ItemPercentageDeduction,2);
           
            _lblNetPrice.Text = TotalNetPrice.ToString();
        }

        private void _quoteItemListUC_NudItemQuantityKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                _nudItemQty.SendToBack();
            }
        }

        private void _quoteItemListUC_NudItemPriceKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                _nudItemPrice.SendToBack();
            }
        }

        private void _quoteItemListUC_NudItemDiscountKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                _nudItemDiscount.SendToBack();
            }
        }

        private void _quoteItemListUC_NudItemQuantityValueChangedEventRaised(object sender, System.EventArgs e)
        {
            _lblQuantity.Text = _nudItemQty.Value.ToString();
        }

        private void _quoteItemListUC_NudItemPriceValueChangedEventRaised(object sender, System.EventArgs e)
        {
            _lblPrice.Text = _nudItemPrice.Value.ToString();
        }

        private void _quoteItemListUC_NudItemDiscountValueChangedEventRaised(object sender, System.EventArgs e)
        {
            _lblDiscount.Text = _nudItemDiscount.Value.ToString() + "%";
        }

        private void _quoteItemListUC_lblQuantityDoubleClickEventRaised(object sender, System.EventArgs e)
        {
            _nudItemQty.Location = _lblQuantity.Location;
            _nudItemQty.BringToFront();
            _nudItemQty.Focus();
        }

        private void _quoteItemListUC_LblPriceDoubleClickEventRaised(object sender, System.EventArgs e)
        {
            _nudItemPrice.Location = _lblPrice.Location;
            _nudItemPrice.BringToFront();
            _nudItemPrice.Focus();
        }

        private void _quoteItemListUC_LblDiscountDoubleClickEventRaised(object sender, System.EventArgs e)
        {
            _nudItemDiscount.Location = _lblDiscount.Location;
            _nudItemDiscount.BringToFront();
            _nudItemDiscount.Focus();
        }

        private void _quoteItemListUC_QuoteItemListUCLoadEventRaised(object sender, System.EventArgs e)
        {
           // _nudItemQty.DecimalPlaces = 2;
            //_nudItemDiscount.DecimalPlaces = 2;
            _nudItemPrice.DecimalPlaces = 2; 
             
            _nudItemQty.Maximum = decimal.MaxValue; ;
            _nudItemDiscount.Maximum = decimal.MaxValue; ;
            _nudItemPrice.Maximum = decimal.MaxValue; ;
        }

        public IQuoteItemListUC GetiQuoteItemListUC()
        {
            return _quoteItemListUC;
        }



        public IQuoteItemListUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IQuoteItemListUCPresenter, QuoteItemListUCPresenter>()
                .RegisterType<IQuoteItemListUC, QuoteItemListUC>();
            QuoteItemListUCPresenter quoteItem = unityC.Resolve<QuoteItemListUCPresenter>();
            quoteItem._unityC = unityC;
            quoteItem._windoorModel = windoorModel;
            //quoteItem._quoteItemListPresenter = quoteItemListPresenter;

            return quoteItem;
        }
    }
}
