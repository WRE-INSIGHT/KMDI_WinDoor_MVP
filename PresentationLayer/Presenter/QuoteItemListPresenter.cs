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
        private IPDFCompilerPresenter _pdfCompilerPresenter;
        private IRDLCReportCompilerPresenter _rdlcReportCompilerPresenter;

        #region Variables
        private List<IQuoteItemListUCPresenter> _lstQuoteItemUC = new List<IQuoteItemListUCPresenter>();
        private List<ShowItemImage> _showItemImage_CheckList = new List<ShowItemImage>();
        private List<GlassRDLC> _lstGlassSummary = new List<GlassRDLC>();
        private List<int> _rdlcReportCompilerItemIndexes = new List<int>();
        private List<int> _lstItemArea = new List<int>();
        private bool _renderPDFAtBackground;
        private string _rdlcReportCompilerOutofTownExpenses;

        public string RDLCReportCompilerOutOfTownExpenses
        {
            get
            {
                return _rdlcReportCompilerOutofTownExpenses;
            }
            set
            {
                _rdlcReportCompilerOutofTownExpenses = value;
            }
        }
        public bool RenderPDFAtBackGround
        {
            get
            {
                return _renderPDFAtBackground;
            }
            set
            {
                _renderPDFAtBackground = value;
            }
        }
        public List<IQuoteItemListUCPresenter> LstQuoteItemUC
        {
            get { return _lstQuoteItemUC; }
            set { _lstQuoteItemUC = value; }
        }
        public List<ShowItemImage> ShowItemImage_CheckList
        {
            get { return _showItemImage_CheckList; }
            set { _showItemImage_CheckList = value; }
        }
        public List<int> RDLCReportCompilerItemIndexes
        {
            get
            {
                return _rdlcReportCompilerItemIndexes;
            }
            set
            {
                _rdlcReportCompilerItemIndexes = value;
            }
        }


        int prev_GlassItemNo,
            prev_GlassQty,
            prev_IntDescription,
            curr_GlassItemNo,
            curr_GlassQty,
            curr_IntDescription,
            GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0,
            windoorTotalListCount = 0,
            ScreenTotalListCount = 0,
            divisor = 2;

        string prev_GlassSize,
               prev_GlassRef,
               prev_GlassLoc, prev_GlassDesc,
               curr_GlassSize,
               curr_GlassRef,
               curr_GlassLoc,
               curr_GlassDesc,
               GeorgianBarHorizontalDesc,
               GeorgianBarVerticalDesc,
               DimensionDesc,
               setDesc;

        decimal prev_GlassArea,
                prev_GlassPrice,
                curr_GlassArea,
                curr_GlassPrice,
                windoorTotalListPrice = 0m,
                ScreenTotalListPrice = 0m,
                windoorDiscountAverage,
                ScreenDiscountAverage,
                screen_Windoor_DiscountAverage;

        bool existing = false;
        bool showImage;
        #endregion

        public QuoteItemListPresenter(IQuoteItemListView quoteItemListView,
                                      IPrintQuotePresenter printQuotePresenter,
                                      IPrintGlassSummaryPresenter printGlassSummaryPresenter,
                                      IPDFCompilerPresenter pdfCompilerPresenter,
                                      IRDLCReportCompilerPresenter rdlcReportCompilerPresenter
                                      )
        {
            _quoteItemListView = quoteItemListView;
            _printQuotePresenter = printQuotePresenter;
            _printGlassSummaryPresenter = printGlassSummaryPresenter;
            _pdfCompilerPresenter = pdfCompilerPresenter;
            _rdlcReportCompilerPresenter = rdlcReportCompilerPresenter;
            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _quoteItemListView.TSbtnPrintClickEventRaised += new EventHandler(OnTSbtnPrintClickEventRaised);
            _quoteItemListView.QuoteItemListViewLoadEventRaised += _quoteItemListView_QuoteItemListViewLoadEventRaised;
            _quoteItemListView.TSbtnGlassSummaryClickEventRaised += _quoteItemListView_TSbtnGlassSummaryClickEventRaised;
            _quoteItemListView.QuoteItemListViewFormClosedEventRaised += _quoteItemListView_QuoteItemListViewFormClosedEventRaised;
            _quoteItemListView.TsbtnContractSummaryClickEventRaised += new EventHandler(OnTsbtnContractSummaryClickEventRaised);
            _quoteItemListView.chkboxSelectallCheckedChangeEventRaised += new EventHandler(OnchkboxSelectallCheckedChangeEventRaised);
            _quoteItemListView.TSbtnPDFCompilerClickEventRaised += new EventHandler(OnTSbtnPDFCompilerClickEventRaised);
        }


        public void PrintScreenRDLC()
        {
            DSQuotation _dsq = new DSQuotation();
            try
            {
                var NetPriceTotal = _mainPresenter.Screen_List.Sum(x => x.Screen_TotalAmount);
                decimal DiscountPercentage = (_mainPresenter.Screen_List.Sum(s => s.Screen_Discount)) / (_mainPresenter.Screen_List.Sum(y => y.Screen_Quantity));
                Console.WriteLine(DiscountPercentage.ToString());

                foreach (var item in _mainPresenter.Screen_List)
                {

                    if (item.Screen_Set > 1)
                    {
                        setDesc = " (Sets of " + item.Screen_Set.ToString() + ")";
                    }
                    else
                    {
                        setDesc = " ";
                    }

                    _dsq.dtScreen.Rows.Add(item.Screen_Types + setDesc + item.Screen_Description,
                                            item.Screen_Width + " x " + item.Screen_Height,
                                            item.Screen_WindoorID,
                                            item.Screen_UnitPrice.ToString("n"),
                                            item.Screen_Quantity,
                                            NetPriceTotal,
                                            Convert.ToString(item.Screen_ItemNumber),
                                            item.Screen_NetPrice.ToString("n"),
                                            1,
                                            "",
                                            Convert.ToString(item.Screen_Discount) + "%",
                                            "",
                                            DiscountPercentage
                                            );
                }
                _mainPresenter.printStatus = "ScreenItem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Screen List Count is 0: ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtScreen.DefaultView;
            printQuote.EventLoad();
            printQuote.PrintRDLCReport();

        }

        public void PrintWindoorRDLC()
        {
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
            try
            {
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
                    if(RenderPDFAtBackGround != true)
                    {
                        bool chkbox_checkstate = Convert.ToBoolean(lstQuoteUC.GetiQuoteItemListUC().GetChkboxItemImage().CheckState);

                        if (chkbox_checkstate == true)
                        {
                            this._quoteItemListView.GetItemListUC_CheckBoxState = true;
                            showImage = true;
                            ShowItemImage_CheckList.Add(new ShowItemImage
                            {
                                ItemIndex = i,
                                ItemboolImage = showImage

                            });
                        }
                        else
                        {
                            showImage = false;
                            ShowItemImage_CheckList.Add(new ShowItemImage
                            {
                                ItemIndex = i,
                                ItemboolImage = showImage

                            });
                        }
                    }
                    else
                    {
                        #region RDLCReportCompiler Executed
                        if (RDLCReportCompilerItemIndexes.Count != 0)
                        {
                            foreach(var item in RDLCReportCompilerItemIndexes.ToArray())
                            {
                                showImage = false;
                                if(i == item)
                                {
                                    showImage = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            showImage = false;
                        }
                        #endregion
                    }

                    Console.WriteLine("EventPrint.: " + showImage.ToString());
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
                                          byteToStrForTopView,
                                          showImage);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message + "\n Location: " + this);
            }

            _mainPresenter.printStatus = "WinDoorItems";

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtQuote.DefaultView;
            if(RenderPDFAtBackGround != true)
            {
                printQuote.GetPrintQuoteView().ShowPrintQuoteView();
            }
            else
            {
                printQuote.EventLoad();
                printQuote.PrintRDLCReport();
            }

        }

        public void PrintContractSummaryRDLC()
        {
            DSQuotation _dtqoute = new DSQuotation();
            try
            {
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    var price_x_quantity = wdm.WD_price * wdm.WD_quantity;
                    windoorTotalListPrice = +windoorTotalListPrice + price_x_quantity;
                }

                windoorTotalListCount = _quotationModel.Lst_Windoor.Sum(m => m.WD_quantity);
                windoorDiscountAverage = (_quotationModel.Lst_Windoor.Sum(x => x.WD_discount) / _quotationModel.Lst_Windoor.Sum(y => y.WD_quantity)) / 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in windoormodel lst_windoor " + this + " " + ex.Message);
                divisor = 1;
            }

            try
            {
                ScreenTotalListPrice = _mainPresenter.Screen_List.Sum(x => x.Screen_TotalAmount);
                ScreenTotalListCount = _mainPresenter.Screen_List.Sum(x => x.Screen_Quantity);
                ScreenDiscountAverage = (Convert.ToDecimal(_mainPresenter.Screen_List.Sum(s => s.Screen_Discount)) / ScreenTotalListCount) / 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in screenmodel " + this + " " + ex.Message);
                divisor = 1;
            }

            screen_Windoor_DiscountAverage = (windoorDiscountAverage + ScreenDiscountAverage) / divisor;

            Console.WriteLine("Windoor Average Discount.: " + windoorDiscountAverage);
            Console.WriteLine("Screen Average Discount.: " + ScreenDiscountAverage);
            Console.WriteLine("Screen & Windoor Discount Average.: " + screen_Windoor_DiscountAverage);
            //Console.WriteLine("");
            //Console.WriteLine("Windoor list count total of: " + windoorTotalListCount.ToString());
            //Console.WriteLine("Windoor total list price: " + windoorTotalListPrice.ToString());
            //Console.WriteLine("");
            //Console.WriteLine("screen total list count: " + ScreenTotalListCount.ToString());
            //Console.WriteLine("screen total list price: " + ScreenTotalListPrice.ToString());
            //Console.WriteLine("");

            _dtqoute.dtContractSummary.Rows.Add(
                                                windoorTotalListCount,
                                                windoorTotalListPrice,
                                                ScreenTotalListCount,
                                                ScreenTotalListPrice,
                                                screen_Windoor_DiscountAverage
                                                );

            windoorTotalListPrice = 0;
            _mainPresenter.printStatus = "ContractSummary";

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dtqoute.dtContractSummary.DefaultView;
            if (RenderPDFAtBackGround != true)
            {
                printQuote.GetPrintQuoteView().ShowPrintQuoteView();
            }
            else
            {
                printQuote.EventLoad();
                printQuote.GetPrintQuoteView().QuotationOuofTownExpenses = _rdlcReportCompilerOutofTownExpenses;
                printQuote.PrintRDLCReport();
            }

        }

        private void OnTSbtnPrintClickEventRaised(object sender, EventArgs e)
        {
            PrintWindoorRDLC();
        }

        private void OnTsbtnContractSummaryClickEventRaised(object sender, EventArgs e)
        {
            PrintContractSummaryRDLC();
        }
        private void OnTSbtnPDFCompilerClickEventRaised(object sender, EventArgs e)
        {
            IPDFCompilerPresenter pdfCompiler = _pdfCompilerPresenter.GetNewInstance(_unityC, _quotationModel, _quoteItemListUCPresenter, _windoorModel, this, _mainPresenter);
            pdfCompiler.GetPDFCompilerView().GetPDFCompilerView();
        }

        private void _quoteItemListView_QuoteItemListViewFormClosedEventRaised(object sender, FormClosedEventArgs e)
        {
            //_mainPresenter.GetCurrentPrice();
            _mainPresenter.updatePriceOfMainView();
            try
            {
                Application.OpenForms["PDFCompilerView"].Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error In FormClose " + this + ex.Message);
            }

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
            int i = 0;
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {

                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    IQuoteItemListUCPresenter lstQuoteUC = this._lstQuoteItemUC[i];

                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        #region multipanel

                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                if (pnl.Panel_GlassThicknessDesc != null)
                                {
                                    decimal pnlGlassArea = (pnl.Panel_GlassWidth / 1000m) * (pnl.Panel_GlassHeight / 1000m);
                                    //_quotationModel.ItemCostingPriceAndPoints();
                                    curr_GlassItemNo = wdm.WD_id;
                                    curr_GlassSize = pnl.Panel_GlassWidth + "w x " + pnl.Panel_GlassHeight + "h";
                                    curr_GlassQty = 1;
                                    curr_GlassArea = Math.Round(pnlGlassArea, 3);
                                    curr_GlassRef = lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber;
                                    curr_GlassLoc = lstQuoteUC.GetiQuoteItemListUC().ItemName;
                                    curr_GlassDesc = pnl.Panel_GlassThicknessDesc;
                                    curr_GlassPrice = Math.Round((pnlGlassArea * pnl.Panel_GlassPricePerSqrMeter) + ((pnlGlassArea * pnl.Panel_GlassPricePerSqrMeter) * _quotationModel.PricingFactor), 2);
                                    curr_IntDescription = Convert.ToInt32(curr_GlassDesc.Substring(0, 2));

                                    if (prev_GlassItemNo != 0)
                                    {
                                        if (prev_GlassItemNo == curr_GlassItemNo)
                                        {
                                            if (prev_GlassArea == curr_GlassArea && prev_GlassDesc == curr_GlassDesc)
                                            {
                                                prev_GlassQty = prev_GlassQty + 1;
                                                prev_GlassPrice = prev_GlassQty * prev_GlassPrice;
                                            }
                                            else
                                            {
                                                this._lstGlassSummary.Add(new GlassRDLC
                                                {
                                                    GlassItemNo = prev_GlassItemNo,
                                                    GlassQuantity = prev_GlassQty,
                                                    GlassSize = prev_GlassSize,
                                                    GlassArea = prev_GlassArea,
                                                    GlassReference = prev_GlassRef,
                                                    GlassLocation = prev_GlassLoc,
                                                    GlassDescription = prev_GlassDesc,
                                                    GlassPrice = prev_GlassPrice,
                                                    IntDesc = prev_IntDescription

                                                });

                                                prev_GlassItemNo = curr_GlassItemNo;
                                                prev_GlassSize = curr_GlassSize;
                                                prev_GlassQty = curr_GlassQty;
                                                prev_GlassArea = curr_GlassArea;
                                                prev_GlassRef = curr_GlassRef;
                                                prev_GlassLoc = curr_GlassLoc;
                                                prev_GlassDesc = curr_GlassDesc;
                                                prev_GlassPrice = curr_GlassPrice;
                                                prev_IntDescription = curr_IntDescription;
                                            }
                                        }
                                        else
                                        {

                                            foreach (var item in _lstGlassSummary.ToArray())
                                            {
                                                if (item.GlassArea == prev_GlassArea && item.GlassDescription == prev_GlassDesc && item.GlassItemNo == prev_GlassItemNo)
                                                {
                                                    item.GlassQuantity = prev_GlassQty + 1;
                                                    item.GlassPrice = item.GlassQuantity * prev_GlassPrice;
                                                    //prev_GlassQty = prev_GlassQty + 1;
                                                    existing = true;
                                                }

                                            }
                                            if (existing == false)
                                            {
                                                this._lstGlassSummary.Add(new GlassRDLC
                                                {
                                                    GlassItemNo = prev_GlassItemNo,
                                                    GlassQuantity = prev_GlassQty,
                                                    GlassSize = prev_GlassSize,
                                                    GlassArea = prev_GlassArea,
                                                    GlassReference = prev_GlassRef,
                                                    GlassLocation = prev_GlassLoc,
                                                    GlassDescription = prev_GlassDesc,
                                                    GlassPrice = prev_GlassPrice,
                                                    IntDesc = prev_IntDescription

                                                });
                                            }
                                            existing = false;

                                            prev_GlassItemNo = curr_GlassItemNo;
                                            prev_GlassSize = curr_GlassSize;
                                            prev_GlassQty = curr_GlassQty;
                                            prev_GlassArea = curr_GlassArea;
                                            prev_GlassRef = curr_GlassRef;
                                            prev_GlassLoc = curr_GlassLoc;
                                            prev_GlassDesc = curr_GlassDesc;
                                            prev_GlassPrice = curr_GlassPrice;
                                            prev_IntDescription = curr_IntDescription;

                                        }

                                    }
                                    else
                                    {
                                        prev_GlassItemNo = curr_GlassItemNo;
                                        prev_GlassSize = curr_GlassSize;
                                        prev_GlassQty = curr_GlassQty;
                                        prev_GlassArea = curr_GlassArea;
                                        prev_GlassRef = curr_GlassRef;
                                        prev_GlassLoc = curr_GlassLoc;
                                        prev_GlassDesc = curr_GlassDesc;
                                        prev_GlassPrice = curr_GlassPrice;
                                        prev_IntDescription = curr_IntDescription;
                                    }

                                }
                            }
                        }
                        #endregion 
                    }
                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                    {
                        #region single panel
                        IPanelModel Singlepnl = fr.Lst_Panel[0];

                        if (Singlepnl.Panel_GlassThicknessDesc != null)
                        {
                            decimal pnlGlassArea = (Singlepnl.Panel_GlassWidth / 1000m) * (Singlepnl.Panel_GlassHeight / 1000m);

                            curr_GlassItemNo = wdm.WD_id;
                            curr_GlassSize = Singlepnl.Panel_GlassWidth + "w x " + Singlepnl.Panel_GlassHeight + "h";
                            curr_GlassQty = 1;
                            curr_GlassArea = Math.Round(pnlGlassArea, 3);
                            curr_GlassRef = lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber;
                            curr_GlassLoc = lstQuoteUC.GetiQuoteItemListUC().ItemName;
                            curr_GlassDesc = Singlepnl.Panel_GlassThicknessDesc;
                            curr_GlassPrice = Math.Round((pnlGlassArea * Singlepnl.Panel_GlassPricePerSqrMeter) + ((pnlGlassArea * Singlepnl.Panel_GlassPricePerSqrMeter) * _quotationModel.PricingFactor), 2);
                            curr_IntDescription = Convert.ToInt32(curr_GlassDesc.Substring(0, 2));
                            if (prev_GlassItemNo != 0)
                            {
                                if (prev_GlassItemNo == curr_GlassItemNo)
                                {
                                    if (prev_GlassArea == curr_GlassArea && prev_GlassDesc == curr_GlassDesc)
                                    {
                                        prev_GlassQty = prev_GlassQty + 1;
                                        prev_GlassPrice = prev_GlassQty * prev_GlassPrice;
                                    }
                                    else
                                    {
                                        this._lstGlassSummary.Add(new GlassRDLC
                                        {
                                            GlassItemNo = prev_GlassItemNo,
                                            GlassQuantity = prev_GlassQty,
                                            GlassSize = prev_GlassSize,
                                            GlassArea = prev_GlassArea,
                                            GlassReference = prev_GlassRef,
                                            GlassLocation = prev_GlassLoc,
                                            GlassDescription = prev_GlassDesc,
                                            GlassPrice = prev_GlassPrice,
                                            IntDesc = prev_IntDescription

                                        });

                                        prev_GlassItemNo = curr_GlassItemNo;
                                        prev_GlassSize = curr_GlassSize;
                                        prev_GlassQty = curr_GlassQty;
                                        prev_GlassArea = curr_GlassArea;
                                        prev_GlassRef = curr_GlassRef;
                                        prev_GlassLoc = curr_GlassLoc;
                                        prev_GlassDesc = curr_GlassDesc;
                                        prev_GlassPrice = curr_GlassPrice;
                                        prev_IntDescription = curr_IntDescription;
                                    }
                                }
                                else
                                {

                                    foreach (var item in _lstGlassSummary.ToArray())
                                    {
                                        if (item.GlassArea == prev_GlassArea && item.GlassDescription == prev_GlassDesc && item.GlassItemNo == prev_GlassItemNo)
                                        {
                                            item.GlassQuantity = prev_GlassQty + 1;
                                            item.GlassPrice = item.GlassQuantity * prev_GlassPrice;
                                            //prev_GlassQty = prev_GlassQty + 1;
                                            existing = true;
                                        }

                                    }
                                    if (existing == false)
                                    {
                                        this._lstGlassSummary.Add(new GlassRDLC
                                        {
                                            GlassItemNo = prev_GlassItemNo,
                                            GlassQuantity = prev_GlassQty,
                                            GlassSize = prev_GlassSize,
                                            GlassArea = prev_GlassArea,
                                            GlassReference = prev_GlassRef,
                                            GlassLocation = prev_GlassLoc,
                                            GlassDescription = prev_GlassDesc,
                                            GlassPrice = prev_GlassPrice,
                                            IntDesc = prev_IntDescription

                                        });
                                    }
                                    existing = false;

                                    prev_GlassItemNo = curr_GlassItemNo;
                                    prev_GlassSize = curr_GlassSize;
                                    prev_GlassQty = curr_GlassQty;
                                    prev_GlassArea = curr_GlassArea;
                                    prev_GlassRef = curr_GlassRef;
                                    prev_GlassLoc = curr_GlassLoc;
                                    prev_GlassDesc = curr_GlassDesc;
                                    prev_GlassPrice = curr_GlassPrice;
                                    prev_IntDescription = curr_IntDescription;
                                }

                            }
                            else
                            {
                                prev_GlassItemNo = curr_GlassItemNo;
                                prev_GlassSize = curr_GlassSize;
                                prev_GlassQty = curr_GlassQty;
                                prev_GlassArea = curr_GlassArea;
                                prev_GlassRef = curr_GlassRef;
                                prev_GlassLoc = curr_GlassLoc;
                                prev_GlassDesc = curr_GlassDesc;
                                prev_GlassPrice = curr_GlassPrice;
                                prev_IntDescription = curr_IntDescription;
                            }


                        }
                        #endregion
                    }
                }
                i++;
            }
            
            #region Last Item 
            foreach (var item in _lstGlassSummary.ToArray())
            {
                if (item.GlassArea == curr_GlassArea && item.GlassDescription == curr_GlassDesc && item.GlassItemNo == curr_GlassItemNo)
                {
                    item.GlassQuantity = prev_GlassQty + 1;
                    item.GlassPrice = item.GlassQuantity * prev_GlassPrice;
                    //prev_GlassQty = prev_GlassQty + 1;
                    existing = true;
                }
            }
            if (existing == false)
            {
                this._lstGlassSummary.Add(new GlassRDLC
                {
                    GlassItemNo = prev_GlassItemNo,
                    GlassQuantity = prev_GlassQty,
                    GlassSize = prev_GlassSize,
                    GlassArea = prev_GlassArea,
                    GlassReference = prev_GlassRef,
                    GlassLocation = prev_GlassLoc,
                    GlassDescription = prev_GlassDesc,
                    GlassPrice = prev_GlassPrice,
                    IntDesc = prev_IntDescription
                });
            }

            existing = false;
            #endregion

            #region print glassrdlclist        

            List<GlassRDLC> sorted = _lstGlassSummary.OrderBy(x => x.IntDesc)
                                                     .ThenBy(x => x.GlassItemNo)
                                                     .ToList();
            foreach (var item in sorted)
            {
                Console.WriteLine(item.IntDesc);
                _dsq.dtGlassSummary.Rows.Add(item.GlassItemNo,
                                             item.GlassQuantity,
                                             item.GlassSize,
                                             item.GlassArea,
                                             item.GlassReference,
                                             item.GlassLocation,
                                             item.GlassDescription,
                                             item.GlassPrice);
            }
            #endregion

            IPrintGlassSummaryPresenter printGlass = _printGlassSummaryPresenter.GetNewInstance(_unityC, this, _mainPresenter, _windoorModel, _quotationModel);
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
                    _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel, _quotationModel, _mainPresenter);
                    UserControl quoteItem = (UserControl)_quoteItemListUCPresenter.GetiQuoteItemListUC();
                    _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                    quoteItem.Dock = DockStyle.Top;
                    quoteItem.BringToFront();
                    _quoteItemListView.GetPnlPrintBody().AutoScroll = true;
                    //_mainPresenter.itemDescription();
                    _mainPresenter.Run_GetListOfMaterials_SpecificItem();
                    //_quotationModel.ItemCostingPriceAndPoints();

                    //if (GeorgianBarHorizontalQty > 0)
                    //{
                    //    GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                    //}

                    //if (GeorgianBarVerticalQty > 0)
                    //{
                    //    GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                    //}

                    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                    //if (_mainPresenter.lst_glassThicknessPerItem.Count != 0)
                    //{
                    //    glass = _mainPresenter.lst_glassThicknessPerItem[i];
                    //}

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
                                                                              + GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc;

                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxTopView().Image = wdm.WD_SlidingTopViewImage;

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

        private void OnchkboxSelectallCheckedChangeEventRaised(object sender, EventArgs e)
        {
            bool chkbox_checkstate_frmQuoteItemList = Convert.ToBoolean(_quoteItemListView.GetChkboxSelectAll().CheckState);

            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                IQuoteItemListUCPresenter lstQuoteUC = this._lstQuoteItemUC[i];

                if (chkbox_checkstate_frmQuoteItemList == true)
                {
                    lstQuoteUC.GetiQuoteItemListUC().GetChkboxItemImage().Checked = true;
                }
                else
                {
                    lstQuoteUC.GetiQuoteItemListUC().GetChkboxItemImage().Checked = false;
                }
                Console.WriteLine("Event select all.: " + chkbox_checkstate_frmQuoteItemList.ToString());
            }
        }

        public void SetAllItemDiscount(int inputedDiscount)
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                wdm.WD_discount = inputedDiscount;
            }
        }

        public void refreshItemList(object sender, EventArgs e)
        {
            _quoteItemListView_QuoteItemListViewLoadEventRaised(sender, e);
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

    public class GlassRDLC
    {
        public string GlassSize { get; set; }
        public string GlassReference { get; set; }
        public string GlassLocation { get; set; }
        public string GlassDescription { get; set; }
        public decimal GlassArea { get; set; }
        public decimal GlassPrice { get; set; }
        public int GlassItemNo { get; set; }
        public int GlassQuantity { get; set; }
        public int IntDesc { get; set; }

    }

    public class ShowItemImage
    {
        public int ItemIndex { get; set; }
        public bool ItemboolImage { get; set; }

    }




}
