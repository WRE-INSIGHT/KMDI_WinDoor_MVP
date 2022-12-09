using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class QuoteItemListPresenter : IQuoteItemListPresenter
    {
        IQuoteItemListView _quoteItemListView;

        private IUnityContainer _unityC;
        private IPrintQuotePresenter _printQuotePresenter;
        private IPrintGlassSummaryPresenter _printGlassSummaryPresenter;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private IMainPresenter _mainPresenter;
       
        #region Variables
        private List<IQuoteItemListUCPresenter> _lstQuoteItemUC = new List<IQuoteItemListUCPresenter>();
        private List<int> _lstItemArea = new List<int>();
        private List<string> lst_glassThicknessPerItem = new List<string>();

        int GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0;

        string glass,
               GeorgianBarHorizontalDesc,
               GeorgianBarVerticalDesc,
               DimensionDesc;
        #endregion

        public QuoteItemListPresenter(IQuoteItemListView quoteItemListView,
                                      IPrintQuotePresenter printQuotePresenter,
                                      IPrintGlassSummaryPresenter printGlassSummaryPresenter
                                      )
        {
            _quoteItemListView = quoteItemListView;
            _printQuotePresenter = printQuotePresenter;
            _printGlassSummaryPresenter = printGlassSummaryPresenter;
            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _quoteItemListView.TSbtnPrintClickEventRaised += new EventHandler(OnTSbtnPrintClickEventRaised);
            _quoteItemListView.QuoteItemListViewLoadEventRaised += _quoteItemListView_QuoteItemListViewLoadEventRaised;
            _quoteItemListView.TSbtnGlassSummaryClickEventRaised += _quoteItemListView_TSbtnGlassSummaryClickEventRaised;
            _quoteItemListView.QuoteItemListViewFormClosedEventRaised += _quoteItemListView_QuoteItemListViewFormClosedEventRaised;
        }

        private void _quoteItemListView_QuoteItemListViewFormClosedEventRaised(object sender, FormClosedEventArgs e)
        {
            // _mainPresenter.GetCurrentPrice();
            _mainPresenter.updatePriceOfMainView();
        }

        private void _quoteItemListView_TSbtnGlassSummaryClickEventRaised(object sender, EventArgs e)
        {
            DSQuotation _dsq = new DSQuotation();
            /*
            dtItemNo
            dtQuantity
            dtSize
            dtArea
            dtReference
            dtLocation
            */
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                int i = 0;

                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    IQuoteItemListUCPresenter lstQuoteUC = this._lstQuoteItemUC[i];

                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                if (pnl.Panel_GlassThicknessDesc != null)
                                {
                                    decimal pnlGlassArea = (pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m);

                                    _dsq.dtGlassSummary.Rows.Add(i,
                                                                 1,
                                                                 pnl.Panel_GlassWidth + "w x " + pnl.Panel_GlassHeight + "h",
                                                                 Math.Round(pnlGlassArea, 3),
                                                                 lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber,
                                                                 lstQuoteUC.GetiQuoteItemListUC().ItemName
                                                                 );
                                }
                            }
                        }
                    }
                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                    {
                        IPanelModel Singlepnl = fr.Lst_Panel[0];

                        if (Singlepnl.Panel_GlassThicknessDesc != null)
                        {
                            decimal pnlGlassArea = (Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m);

                            _dsq.dtGlassSummary.Rows.Add(i,
                                                         1,
                                                         Singlepnl.Panel_GlassWidth + "w x " + Singlepnl.Panel_GlassHeight + "h",
                                                         Math.Round(pnlGlassArea, 3),
                                                         lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber,
                                                         lstQuoteUC.GetiQuoteItemListUC().ItemName
                                                         );
                        }
                    }
                }
                i++;
            }

            IPrintGlassSummaryPresenter printGlass = _printGlassSummaryPresenter.GetNewInstance(_unityC, this, _mainPresenter);
            printGlass.GetPrintGlassSummaryView().GetBindingSource().DataSource = _dsq.dtGlassSummary.DefaultView;
            printGlass.GetPrintGlassSummaryView().ShowGlassSummaryView();
        }

        int TotalItemArea = 0;
        private void _quoteItemListView_QuoteItemListViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                _quotationModel.BOM_Status = false;
                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel, _quotationModel);
                    UserControl quoteItem = (UserControl)_quoteItemListUCPresenter.GetiQuoteItemListUC();
                    _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                    quoteItem.Dock = DockStyle.Top;
                    quoteItem.BringToFront();

                    // _mainPresenter.itemDescription();
                    _mainPresenter.Run_GetListOfMaterials_SpecificItem();
                    //_quotationModel.ItemCostingPriceAndPoints();

                    if (GeorgianBarHorizontalQty > 0)
                    {
                        GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                    }

                    if (GeorgianBarVerticalQty > 0)
                    {
                        GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                    }

                    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                    if (lst_glassThicknessPerItem.Count != 0)
                    {
                        glass = lst_glassThicknessPerItem[i];
                    }

                    DimensionDesc = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n";
                    if (wdm.WD_description.Contains(DimensionDesc))
                    {
                        DimensionDesc = "";
                    }
                    else
                    {
                        DimensionDesc = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n";
                    }

                    _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemNumber = "Item " + (i + 1);
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName = wdm.WD_itemName;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemWindoorNumber = wdm.WD_WindoorNumber; //location
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc = DimensionDesc
                                                                              + wdm.WD_description
                                                                              + glass + GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc;

                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxTopView().Image = wdm.WD_SlidingTopViewImage;

                    //_quoteItemListUCPresenter.GetiQuoteItemListUC().itemPrice.Value = Math.Round(_quotationModel.lstTotalPrice[i], 2);  //TotaPrice;
                    //_quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblPrice().Text = Math.Round(_quotationModel.lstTotalPrice[i], 2).ToString();  //TotaPrice.ToString();


                    if (wdm.WD_price == 0)
                    {
                        _quotationModel.ItemCostingPriceAndPoints();
                        wdm.WD_price = Math.Round(_quotationModel.lstTotalPrice[i], 2);
                    }
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemPrice.Value = Math.Round(wdm.WD_price, 2);  //TotaPrice;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblPrice().Text = Math.Round(wdm.WD_price, 2).ToString();  //TotaPrice.ToString();


                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemQuantity.Value = wdm.WD_quantity;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblQuantity().Text = wdm.WD_quantity.ToString();

                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDiscount.Value = wdm.WD_discount;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblDiscount().Text = wdm.WD_discount.ToString() + "%";


                    this._lstQuoteItemUC.Add(_quoteItemListUCPresenter);
                    TotalItemArea = wdm.WD_width * wdm.WD_height;
                    this._lstItemArea.Add(TotalItemArea);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void SetAllItemDiscount(int inputedDiscount)
        {
            _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel, _quotationModel);

            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                wdm.WD_discount = inputedDiscount;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDiscount.Value = wdm.WD_discount;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblDiscount().Text = wdm.WD_discount.ToString() + "%";
            }
        }

        private void OnTSbtnPrintClickEventRaised(object sender, EventArgs e)
        {
            //Console.WriteLine("item" + _windoorModel.WD_itemName);
            //Console.WriteLine("windoor" +_windoorModel.WD_WindoorNumber);

            DSQuotation _dsq = new DSQuotation();

            /*
          ID
          dtItemName
          dtDescription
          dtDimension
          dtImage
          dtQuantity
          dtPrice
          dtDiscount
          dtNetPrice
           */

            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                #region ScalingItemSizePicture
                //int max = this._lstItemArea[0],
                //    ItemNewWidth,
                //    ItemNewHeight,
                //    maxHeight = 190,
                //    maxWidth = 190,
                //    wdAndHtDiff;
                //decimal itemSizePercentage;

                //int currentItem = this._lstItemArea[i],
                //    itemWidth = _quotationModel.Lst_Windoor[i].WD_width,
                //    itemHeight = _quotationModel.Lst_Windoor[i].WD_height;

                //decimal ProportionItemSizePercentage;

                //for (int ii = 1; ii < this._lstItemArea.Count; ii++)
                //{
                //    max = Math.Max(max, this._lstItemArea[ii]);
                //}

                //itemSizePercentage = (decimal)currentItem / (decimal)max;
                ////ItemScalingSize = (currentItem / max) * itemSizePercentage;
                //ItemNewWidth = (int)((decimal)itemSizePercentage * maxWidth);
                //ItemNewHeight = (int)((decimal)itemSizePercentage * maxHeight);


                //if (itemWidth > itemHeight)
                //{
                //    ProportionItemSizePercentage = ((decimal)itemHeight / (decimal)itemWidth) ;
                //    ItemNewHeight = (int)((decimal)ProportionItemSizePercentage * (decimal)ItemNewHeight);
                //}
                //else if (itemWidth < itemHeight)
                //{
                //    ProportionItemSizePercentage = ((decimal)itemWidth / (decimal)itemHeight);
                //    ItemNewWidth = (int)((decimal)ProportionItemSizePercentage * (decimal)ItemNewWidth);
                //}
                //else
                //{

                //}

                //var resizedImg = ResizeImage(img, ItemNewWidth, ItemNewHeight);


                //resizedImg.Save(mstream, ImageFormat.Png);
                #endregion

                MemoryStream mstream = new MemoryStream();
                MemoryStream mstream2 = new MemoryStream();
                Image itemImage = _quotationModel.Lst_Windoor[i].WD_image,
                      topView = _quotationModel.Lst_Windoor[i].WD_SlidingTopViewImage;

                itemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);

                if (topView != null)
                {
                    topView.Save(mstream2, System.Drawing.Imaging.ImageFormat.Png);
                }

                byte[] arrimageForItemImage = mstream.ToArray();
                byte[] arrimageForTopView = mstream2.ToArray();

                string byteToStrForItemImage = Convert.ToBase64String(arrimageForItemImage);
                string byteToStrForTopView = Convert.ToBase64String(arrimageForTopView);


                IQuoteItemListUCPresenter lstQuoteUC = this._lstQuoteItemUC[i];

                _dsq.dtQuote.dtTopViewImageColumn.AllowDBNull = true;

                _dsq.dtQuote.Rows.Add(lstQuoteUC.GetiQuoteItemListUC().ItemName,
                                      lstQuoteUC.GetiQuoteItemListUC().itemDesc,
                                      lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber,
                                      byteToStrForItemImage,
                                      lstQuoteUC.GetiQuoteItemListUC().itemQuantity.Value,
                                      lstQuoteUC.GetiQuoteItemListUC().itemPrice.Value.ToString("N", new CultureInfo("en-US")),
                                      lstQuoteUC.GetiQuoteItemListUC().itemDiscount.Value,
                                      Convert.ToDecimal(lstQuoteUC.GetiQuoteItemListUC().GetLblNetPrice().Text),
                                      i + 1,
                                      byteToStrForTopView);
            }
            _mainPresenter.printStatus = "WinDoorItems";

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtQuote.DefaultView;
            printQuote.GetPrintQuoteView().ShowPrintQuoteView();
        }

        //for ScalingItemSizePicture
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            //create new destImage object
            var destImage = new Bitmap(width, height);

            //maintains DPI regardless of physical size
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                //determines whether pixels from a source image overwrite or are combined with background pixels.
                graphics.CompositingMode = CompositingMode.SourceCopy;
                //determines the rendering quality level of layered images.
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                // determines how intermediate values between two endpoints are calculated
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //specifies whether lines, curves, and the edges of filled areas use smoothing 
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                //affects rendering quality when drawing the new image
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    //prevents ghosting around the image borders
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }





        public IQuoteItemListView GetQuoteItemListView()
        {
            return _quoteItemListView;
        }

        public IQuoteItemListPresenter GetNewInstance(IUnityContainer unityC,
                                                      IQuotationModel quotationModel,
                                                      IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                                      IWindoorModel windoorModel,
                                                      IMainPresenter mainPresenter)
        {
            unityC
                    .RegisterType<IQuoteItemListPresenter, QuoteItemListPresenter>()
                    .RegisterType<IQuoteItemListView, QuoteItemListView>();
            QuoteItemListPresenter quoteItemList = unityC.Resolve<QuoteItemListPresenter>();
            quoteItemList._unityC = unityC;
            quoteItemList._quotationModel = quotationModel;
            quoteItemList._quoteItemListUCPresenter = quoteItemListUCPresenter;
            quoteItemList._windoorModel = windoorModel;
            quoteItemList._mainPresenter = mainPresenter;



            //quoteItemList._printQuotePresenter = printQuotePresenter;

            return quoteItemList;
        }
    }
}
