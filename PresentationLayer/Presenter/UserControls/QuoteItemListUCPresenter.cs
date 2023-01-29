using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private IQuotationModel _quotationModel;
        private IMainPresenter _mainPresenter;

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
            _quoteItemListUC.tboxItemNameTextChangedEventRaised += _quoteItemListUC_tboxItemNameTextChangedEventRaised;
            _quoteItemListUC.tboxWindoorNumberTextChangedEventRaised += _quoteItemListUC_tboxWindoorNumberTextChangedEventRaised;
            _quoteItemListUC.suggestedPriceToolStripMenuItemClickEventRaised += _quoteItemListUC_suggestedPriceToolStripMenuItemClickEventRaised;
            _quoteItemListUC.setAllDiscountToolStripMenuItemClickEventRaised += _quoteItemListUC_setAllDiscountToolStripMenuItemClickEventRaised;
            _quoteItemListUC.rtboxDescTextChangedEventRaised += _quoteItemListUC_rtboxDescTextChangedEventRaised;
        }

        private void _quoteItemListUC_rtboxDescTextChangedEventRaised(object sender, EventArgs e)
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                string itemNum = _quoteItemListUC.ItemNumber;
                itemNum = itemNum.Replace("Item ", string.Empty);

                if (itemNum != "Item")
                {
                    if (wdm.WD_id == Convert.ToInt32(itemNum))
                    {
                        wdm.WD_description = ((RichTextBox)sender).Text;
                    }
                }
            }
        }

        private void _quoteItemListUC_setAllDiscountToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Set Discount for all items", "WinDoor Maker", "30");
            if (input != "")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        //_windoorModel.setDiscount = "SetAllDiscount";
                        //_quoteItemListPresenter.SetAllItemDiscount(int_input);

                        foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                        {
                            wdm.WD_discount = int_input;
                        }

                        // _quoteItemListPresenter .GetQuoteItemListView().closeQuoteItemList();
                        _quoteItemListPresenter = _quoteItemListPresenter.GetNewInstance(_unityC, _quotationModel, this, _windoorModel, _mainPresenter);
                        //   _quoteItemListPresenter.GetQuoteItemListView().showQuoteItemList();

                        //_nudItemPrice.Maximum = decimal.MaxValue;

                        //_quoteItemListPresenter.refreshItemList(sender, e);

                        //foreach (IQuoteItemListUCPresenter item in _quoteItemListPresenter._lstQuoteItemUC)
                        //{ 
                        //    item.GetiQuoteItemListUC().itemDiscount.Value = int_input;
                        //    item.GetiQuoteItemListUC().GetLblDiscount().Text= int_input.ToString() + "%";
                        //}
                        //_nudItemDiscount.Value = int_input;
                        //_lblDiscount.Text = int_input.ToString() + "%";
                    }
                    else if (int_input < 0)
                    {
                        MessageBox.Show("Invalid number");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233033)
                    {
                        MessageBox.Show("Please input a number.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, ex.HResult.ToString());
                    }
                }
            }



        }

        private void _quoteItemListUC_suggestedPriceToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                IWindoorModel wdrCurrentSelected = null;
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    if (wdm.WD_Selected == true)
                    {
                        wdrCurrentSelected = wdm; 
                        wdm.WD_Selected = false; 
                    }
                    string itemNum = _quoteItemListUC.ItemNumber;
                    itemNum = itemNum.Replace("Item ", string.Empty);

                    if (itemNum != "Item")
                    {
                        if (wdm.WD_id == Convert.ToInt32(itemNum))
                        {
                            _quotationModel.BOMandItemlistStatus = "BOM";
                            wdm.WD_Selected = true; 
                            _quotationModel.ItemCostingPriceAndPoints();
                            //wdm.WD_price = _quotationModel.lstTotalPrice[wdm.WD_id - 1];
                            wdm.WD_price = _quotationModel.lstTotalPrice[0];
                            _nudItemPrice.Value = wdm.WD_price;
                            _lblPrice.Text = wdm.WD_price.ToString("N", new CultureInfo("en-US"));
                            wdm.WD_Selected = false; 

                        }
                    }
                }
                _quotationModel.Select_Current_Windoor(wdrCurrentSelected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _quoteItemListUC_tboxWindoorNumberTextChangedEventRaised(object sender, EventArgs e)
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                string itemNum = _quoteItemListUC.ItemNumber;
                itemNum = itemNum.Replace("Item ", string.Empty);
                if (wdm.WD_id == Convert.ToInt32(itemNum))
                {
                    wdm.WD_WindoorNumber = ((TextBox)sender).Text;
                }
            }
        }

        private void _quoteItemListUC_tboxItemNameTextChangedEventRaised(object sender, EventArgs e)
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                string itemNum = _quoteItemListUC.ItemNumber;
                itemNum = itemNum.Replace("Item ", string.Empty);
                if (wdm.WD_id == Convert.ToInt32(itemNum))
                {
                    wdm.WD_itemName = ((TextBox)sender).Text;
                }
            }
        }

        private void _quoteItemListUC_ComputeNetPriceTextChangeEventRaised(object sender, System.EventArgs e)
        {
            decimal ItemPercentageDeduction = (decimal)(((double)100 - (double)_nudItemDiscount.Value) * (double)0.01);
            TotalNetPrice = Math.Round((_nudItemPrice.Value * _nudItemQty.Value) * ItemPercentageDeduction, 2);

            _lblNetPrice.Text = TotalNetPrice.ToString("N", new CultureInfo("en-US"));
            _lblPrice.Text = _nudItemPrice.Value.ToString("N", new CultureInfo("en-US"));

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
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                string itemNum = _quoteItemListUC.ItemNumber;
                itemNum = itemNum.Replace("Item ", string.Empty);

                if (itemNum != "Item")
                {
                    if (wdm.WD_id == Convert.ToInt32(itemNum))
                    {
                        wdm.WD_quantity = (int)((NumericUpDown)sender).Value;

                        _lblQuantity.Text = wdm.WD_quantity.ToString();
                    }
                }
            }
        }

        private void _quoteItemListUC_NudItemPriceValueChangedEventRaised(object sender, System.EventArgs e)
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                string itemNum = _quoteItemListUC.ItemNumber;
                itemNum = itemNum.Replace("Item ", string.Empty);

                if (itemNum != "Item")
                {
                    if (wdm.WD_id == Convert.ToInt32(itemNum))
                    {
                        wdm.WD_price = ((NumericUpDown)sender).Value;

                        _lblPrice.Text = wdm.WD_price.ToString("N", new CultureInfo("en-US"));
                    }
                }
            }
        }

        private void _quoteItemListUC_NudItemDiscountValueChangedEventRaised(object sender, System.EventArgs e)
        {
            //if (_windoorModel.setDiscount == "SetAllDiscount")
            //{
            //    foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            //    {
            //        // wdm.WD_discount = (int)((NumericUpDown)sender).Value;
            //        _nudItemDiscount.Value = wdm.WD_discount;
            //        _lblDiscount.Text = wdm.WD_discount.ToString() + "%";
            //    }
            //}
            //else
            //{
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                string itemNum = _quoteItemListUC.ItemNumber;
                itemNum = itemNum.Replace("Item ", string.Empty);

                if (itemNum != "Item")
                {
                    if (wdm.WD_id == Convert.ToInt32(itemNum))
                    {
                        wdm.WD_discount = (int)((NumericUpDown)sender).Value;

                        _lblDiscount.Text = wdm.WD_discount.ToString() + "%";
                    }
                }
            }
            //}
            //_windoorModel.setDiscount = "";
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
            _nudItemPrice.DecimalPlaces = 2;

            _nudItemQty.Maximum = decimal.MaxValue;
            _nudItemDiscount.Maximum = decimal.MaxValue;
            _nudItemPrice.Maximum = decimal.MaxValue;
        }

        public IQuoteItemListUC GetiQuoteItemListUC()
        {
            return _quoteItemListUC;
        }



        public IQuoteItemListUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IWindoorModel windoorModel,
                                                        IQuotationModel quotationModel,
                                                        IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IQuoteItemListUCPresenter, QuoteItemListUCPresenter>()
                .RegisterType<IQuoteItemListUC, QuoteItemListUC>();
            QuoteItemListUCPresenter quoteItem = unityC.Resolve<QuoteItemListUCPresenter>();
            quoteItem._unityC = unityC;
            quoteItem._windoorModel = windoorModel;
            quoteItem._quotationModel = quotationModel;
            quoteItem._mainPresenter = mainPresenter;
            //quoteItem._quoteItemListPresenter = quoteItemListPresenter;

            return quoteItem;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("WD_itemName", new Binding("Text", _windoorModel, "WD_itemName", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("WD_WindoorNumber", new Binding("Text", _windoorModel, "WD_WindoorNumber", true, DataSourceUpdateMode.OnPropertyChanged));
            // binding.Add("WD_quantity", new Binding("Value", _windoorModel, "WD_quantity", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
