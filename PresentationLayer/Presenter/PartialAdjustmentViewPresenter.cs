using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
   public class PartialAdjustmentViewPresenter : IPartialAdjustmentViewPresenter
    {
        private IPartialAdjustmentView _partialAdjustmentView;

        private IUnityContainer _unityC;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IMainPresenter _mainPresenter;
        private IPrintQuotePresenter _printQuotePresenter;
        private IPartialAdjustmentUCPresenter _partialAdjustmentUCPresenter;
        private IPartialAdjustmentBaseHolderPresenter _partialAdjustmentBaseHolderPresenter;

        private CheckedListBox _itemsCheckListBox;
        private bool _isFromItemPanelToolStripBtn = false;

        public PartialAdjustmentViewPresenter(IPartialAdjustmentView partialAdjustmentView,
                                              IPrintQuotePresenter printQuotePresenter)
        {
            _partialAdjustmentView = partialAdjustmentView;
            _printQuotePresenter = printQuotePresenter;
            _itemsCheckListBox  = _partialAdjustmentView.GetItemListCheckListBox();
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _partialAdjustmentView._printToolStripBtnClickEventRaised += _partialAdjustmentView__printToolStripBtnClickEventRaised;                 
            _partialAdjustmentView._partialAdjustmentViewLoadEventRaised += _partialAdjustmentView__partialAdjustmentViewLoadEventRaised;
            _partialAdjustmentView._btn_addItem_ClickEventRaised += _partialAdjustmentView__btn_addItem_ClickEventRaised;
            _partialAdjustmentView._ItemPanelToolstripBtn_ClickEventRaised += _partialAdjustmentView__ItemPanelToolstripBtn_ClickEventRaised;
            _partialAdjustmentView._itemSortToolStrpBtn_ClickEventRaised += _partialAdjustmentView__itemSortToolStrpBtn_ClickEventRaised;
        }
        
        private void _partialAdjustmentView__partialAdjustmentViewLoadEventRaised(object sender, EventArgs e)
        {
        
            _partialAdjustmentView.GetItemListPnl().Visible = true;
            LoadItemsInCheckList();
        }
        private void _partialAdjustmentView__ItemPanelToolstripBtn_ClickEventRaised(object sender, EventArgs e)
        {
            if (_partialAdjustmentView.GetItemListPnl().Visible)
            {
                _partialAdjustmentView.GetItemListPnl().Visible = false;
            }
            else
            {
                _isFromItemPanelToolStripBtn = true;
                _itemsCheckListBox.Items.Clear();
                 LoadItemsInCheckList();
                _partialAdjustmentView.GetItemListPnl().Visible = true;
                _isFromItemPanelToolStripBtn = false;
            }
        }
        private void _partialAdjustmentView__btn_addItem_ClickEventRaised(object sender, EventArgs e)
        {

            #region old Algo
            /*
            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                
                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                #region 1st Algo
                //_partialAdjustmentUCPresenter = _partialAdjustmentUCPresenter.GetNewInstance(_unityC, _quotationModel, wdm, _mainPresenter, this);
                //UserControl partialadjustmentItems = (UserControl)_partialAdjustmentUCPresenter.GetPartialAdjustmentUC();
                //_partialAdjustmentView.GetPanelBody().Controls.Add(partialadjustmentItems);
                //partialadjustmentItems.Dock = DockStyle.Top;
                //partialadjustmentItems.BringToFront();
                //_partialAdjustmentView.GetPanelBody().AutoScroll = true;

                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetPAItemNo().Text = "Item No." + (i + 1).ToString();
                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = wdm.WD_image;
                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = wdm.WD_description;
                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = Math.Round(wdm.WD_price, 2).ToString("N");

                //if (wdm.WD_IsPartialADPreviousExist)
                //{
                //    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDesignImage().Image = wdm.WD_PAPreviousImage;
                //    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDescription().Text = wdm.WD_PAPreviousDescription;
                //    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemPrice().Text = Math.Round(wdm.WD_PAPreviousPrice, 2).ToString("N");
                //}
                #endregion
                _partialAdjustmentBaseHolderPresenter = _partialAdjustmentBaseHolderPresenter.GetNewInstance(_unityC,_mainPresenter,wdm,_quotationModel,this);
                _partialAdjustmentBaseHolderPresenter.ItemQuantity = wdm.WD_quantity;
                _partialAdjustmentBaseHolderPresenter.GetPABaseHolderUC().PABaseHolderItemName().Text ="Item No. "+ wdm.WD_id.ToString();

                if(wdm.WD_PALst_Designs == null)
                {
                    //instantiate
                    wdm.WD_PALst_Designs = new List<System.Drawing.Image>();
                    wdm.WD_PALst_Description = new List<string>();
                    wdm.WD_PALst_Price = new List<decimal>();
                }

                UserControl partialadjustmentItems = (UserControl)_partialAdjustmentBaseHolderPresenter.GetPABaseHolderUC();
                _partialAdjustmentView.GetPanelBody().Controls.Add(partialadjustmentItems);
                partialadjustmentItems.Dock = DockStyle.Top;
                partialadjustmentItems.BringToFront();
                _partialAdjustmentView.GetPanelBody().AutoScroll = true;

            }
            */
            #endregion

            foreach (int item in _itemsCheckListBox.CheckedIndices)
            {
                int _selectedItemNum = item;

                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    if (_selectedItemNum == i)
                    {
                        IWindoorModel wdm = _quotationModel.Lst_Windoor[i];

                        if (!wdm.WD_IsSelectedAtPartialAdjusment)
                        {
                            wdm.WD_IsSelectedAtPartialAdjusment = true;
                            LoadMoDel(wdm);
                        }
                    }
                }
                _partialAdjustmentView.GetItemListPnl().Visible = false;
            }
        }

        private void _partialAdjustmentView__printToolStripBtnClickEventRaised(object sender, EventArgs e)
        {
            DSQuotation _dsq = new DSQuotation();
            string[] AlPHA = new[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};

            try
            {
                for(int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];

                    if (wdm.WD_IsSelectedAtPartialAdjusment)
                    {

                        bool _isWDMLstIsZero = true;
                        decimal _price_x_Qty = 0;

                        MemoryStream mstream = new MemoryStream();
                        Image ItemImage;
                        //ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] ArrForImage;
                        string ImageByteToString;

                        _price_x_Qty = wdm.WD_price * wdm.WD_quantity;

                        if (wdm.WD_PALst_Designs != null)
                        {
                            if (wdm.WD_PALst_Designs.Count != 0)
                            {
                                _isWDMLstIsZero = false;
                            }
                        }


                        if (!_isWDMLstIsZero)
                        {
                            bool _isWDMPreviousDesignExist = false;

                            foreach (var item in wdm.WD_PALst_Designs)
                            {
                                if (item != null)
                                {
                                    _isWDMPreviousDesignExist = true;  // check for previous design exist
                                    break;
                                }
                            }

                            if (_isWDMPreviousDesignExist)
                            {
                                #region Adjustable to item below with Previous Design 

                                mstream = new MemoryStream();
                                ItemImage = wdm.WD_PAPreviousImage;
                                
                                ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                                ArrForImage = mstream.ToArray();
                                ImageByteToString = Convert.ToBase64String(ArrForImage);

                                _price_x_Qty = wdm.WD_PAPreviousPrice * wdm.WD_quantity; // multiple price to qty


                                _dsq.dtPartialAdjustment.Rows.Add(wdm.WD_id,
                                                                  wdm.WD_itemName,
                                                                  ImageByteToString,
                                                                  wdm.WD_PAPreviousDescription + "\n ADJUSTED TO ITEM BELOW",
                                                                  wdm.WD_quantity,
                                                                 _price_x_Qty.ToString("N", new CultureInfo("en-US")),
                                                                  ""
                                                     );

                                #endregion 
                            }
                            else
                            {
                                #region Adjustable to item below W/O Previous Design 


                                mstream = new MemoryStream();
                                ItemImage = wdm.WD_image;
                                ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                                ArrForImage = mstream.ToArray();
                                ImageByteToString = Convert.ToBase64String(ArrForImage);

                                _price_x_Qty = wdm.WD_price * wdm.WD_quantity; // multiple price to qty


                                _dsq.dtPartialAdjustment.Rows.Add(wdm.WD_id,
                                                                  wdm.WD_itemName,
                                                                  ImageByteToString,
                                                                  wdm.WD_description + "\n ADJUSTED TO ITEM BELOW",
                                                                  wdm.WD_quantity,
                                                                 _price_x_Qty.ToString("N", new CultureInfo("en-US")),
                                                                  ""
                                                     );

                                #endregion
                            }



                            for (int j = 0; j < wdm.WD_PALst_Designs.Count; j++)
                            {
                                if(wdm.WD_PALst_Designs[j] == null)
                                {
                                    if (_isWDMPreviousDesignExist)
                                    {
                                        #region PartialAdjustment With New Design in another index
                                        mstream = new MemoryStream();
                                        ItemImage = wdm.WD_PAPreviousImage;
                                        ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                                        ArrForImage = mstream.ToArray();
                                        ImageByteToString = Convert.ToBase64String(ArrForImage);

                                        _dsq.dtPartialAdjustment.Rows.Add(AlPHA[j],
                                                                          wdm.WD_itemName,
                                                                          ImageByteToString,
                                                                          wdm.WD_PAPreviousDescription + "\n NO SIGNIFICANT CHANGE",
                                                                          wdm.WD_PALst_Qty[j],//itemQty
                                                                          wdm.WD_PAPreviousPrice.ToString("N", new CultureInfo("en-US")),
                                                                          "0.00"
                                                                          );
                                        #endregion
                                    }
                                    else
                                    {
                                        #region PartialAdjustment Without New Design on any index
                                        mstream = new MemoryStream();
                                        ItemImage = wdm.WD_image;
                                        ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                                        ArrForImage = mstream.ToArray();
                                        ImageByteToString = Convert.ToBase64String(ArrForImage);

                                        _dsq.dtPartialAdjustment.Rows.Add(AlPHA[j],
                                                                          wdm.WD_itemName,
                                                                          ImageByteToString,
                                                                          wdm.WD_description + "\n NO SIGNIFICANT CHANGE",
                                                                          wdm.WD_PALst_Qty[j],//itemqty
                                                                          wdm.WD_price.ToString("N", new CultureInfo("en-US")),
                                                                          "0.00"
                                                                          );
                                        #endregion
                                    }

                                }
                                else
                                {

                                    mstream = new MemoryStream();
                                    ItemImage = wdm.WD_PALst_Designs[j];
                                    ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                                    ArrForImage = mstream.ToArray();
                                    ImageByteToString = Convert.ToBase64String(ArrForImage);

                                    decimal AdjustmentPrice =  wdm.WD_PALst_Price[j] - wdm.WD_PAPreviousPrice;
                                    AdjustmentPrice =  AdjustmentPrice * wdm.WD_PALst_Qty[j];

                                    decimal Price = wdm.WD_PALst_Price[j] * wdm.WD_PALst_Qty[j];

                                    string AdjustmentPriceTostring;
                                    if (AdjustmentPrice < 0)
                                    {
                                         AdjustmentPriceTostring = "( "+ AdjustmentPrice.ToString("N", new CultureInfo("en-US")).Replace("-","") + " )";
                                    }
                                    else
                                    {
                                        AdjustmentPriceTostring = AdjustmentPrice.ToString("N", new CultureInfo("en-US"));
                                    }
                                  

                                    _dsq.dtPartialAdjustment.Rows.Add(AlPHA[j],
                                                                      wdm.WD_itemName,
                                                                      ImageByteToString,
                                                                      wdm.WD_PALst_Description[j],
                                                                      wdm.WD_PALst_Qty[j],//itemQty
                                                                      Price.ToString("N", new CultureInfo("en-US")),
                                                                      AdjustmentPriceTostring
                                                                      );
                                }
                            }

                        }
                        else
                        {
                            mstream = new MemoryStream();
                            ItemImage = wdm.WD_image;
                            ItemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                            ArrForImage = mstream.ToArray();
                            ImageByteToString = Convert.ToBase64String(ArrForImage);

                            _dsq.dtPartialAdjustment.Rows.Add(wdm.WD_id,
                                                              wdm.WD_itemName,
                                                              ImageByteToString,
                                                              wdm.WD_description,
                                                              wdm.WD_quantity,
                                                             _price_x_Qty.ToString("N", new CultureInfo("en-US")),
                                                              ""
                                                              );
                        }

                    }
                    
                }


                _mainPresenter.printStatus = "PartialAdjustment";
                IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, _mainPresenter);
                printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtPartialAdjustment.DefaultView;
                printQuote.GetPrintQuoteView().ShowPrintQuoteView();

                //reset print variables 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in PartialAdjustment Print: " + ex.Message);
            }
        }
        private void _partialAdjustmentView__itemSortToolStrpBtn_ClickEventRaised(object sender, EventArgs e)
        {
            _partialAdjustmentView.GetPanelBody().Controls.Clear();
            LoadItemsInCheckList();
        }

        private void LoadItemsInCheckList()
        {
            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                _itemsCheckListBox.Items.Add("Item: " + wdm.WD_id);

                if (wdm.WD_IsSelectedAtPartialAdjusment)
                {
                    if (!_isFromItemPanelToolStripBtn)
                    {
                        LoadMoDel(wdm);
                    }
                    _itemsCheckListBox.SetItemChecked(i, true);
                    _partialAdjustmentView.GetItemListPnl().Visible = false;
                }
            }
        }

        private IWindoorModel LoadMoDel(IWindoorModel wdm)
        {
            _partialAdjustmentBaseHolderPresenter = _partialAdjustmentBaseHolderPresenter.GetNewInstance(_unityC, _mainPresenter, wdm, _quotationModel, this);
            _partialAdjustmentBaseHolderPresenter.ItemQuantity = wdm.WD_quantity;
            _partialAdjustmentBaseHolderPresenter.GetPABaseHolderUC().PABaseHolderItemName().Text = "Item No. " + wdm.WD_id.ToString();

            if (wdm.WD_PALst_Designs == null)
            {
                //instantiate
                wdm.WD_PALst_Designs = new List<System.Drawing.Image>();
                wdm.WD_PALst_Description = new List<string>();  
                wdm.WD_PALst_Price = new List<decimal>();
                wdm.WD_PALst_Qty = new List<int>();
            }

            if(wdm.WD_PALst_Qty == null)
            {
                wdm.WD_PALst_Qty = new List<int>();
            }

            UserControl partialadjustmentItems = (UserControl)_partialAdjustmentBaseHolderPresenter.GetPABaseHolderUC();
            partialadjustmentItems.Name = wdm.WD_name;                                         
            _partialAdjustmentView.GetPanelBody().Controls.Add(partialadjustmentItems);
            partialadjustmentItems.Dock = DockStyle.Top;
            partialadjustmentItems.BringToFront();
            _partialAdjustmentView.GetPanelBody().AutoScroll = true;
            
            return wdm;

        }


        
        public IPartialAdjustmentView GetPartialAdjustmentView()
        {
            return _partialAdjustmentView;
        }

        public IPartialAdjustmentViewPresenter GetNewInstance(IUnityContainer unityC,
                                                               IQuotationModel quotationModel,
                                                               IWindoorModel windoorModel,
                                                               IMainPresenter mainPresenter,
                                                               IPartialAdjustmentBaseHolderPresenter partialAdjustmentBaseHolder)
        {   
            unityC
                .RegisterType<IPartialAdjustmentViewPresenter, PartialAdjustmentViewPresenter>()
                .RegisterType<IPartialAdjustmentView, PartialAdjustmentView>();
            PartialAdjustmentViewPresenter partialAdjusment = unityC.Resolve<PartialAdjustmentViewPresenter>();
            partialAdjusment._unityC = unityC;
            partialAdjusment._quotationModel = quotationModel;
            partialAdjusment._windoorModel = windoorModel;
            partialAdjusment._mainPresenter = mainPresenter;
            partialAdjusment._partialAdjustmentBaseHolderPresenter = partialAdjustmentBaseHolder;

            return partialAdjusment;
        }
       
    }
}
