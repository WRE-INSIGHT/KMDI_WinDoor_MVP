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
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

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

        private string _rdlcReportCompilerOutofTownExpenses,
                       _rdlcReportCompilerVatContractSummary,
                       _rdlcReportCompilerRowLimit,
                       archi;
        private string[] province;
        private bool _callFrmRDLCCompiler,
                     _renderPDFAtBackground,
                     _showVatContractSummary,
                     _rdlcReportCompilerShowSubTotal,
                     _intInString,
                     _guShowReviewedBy,
                     _guShowNotedBy,
                     _guShowVat;

        private string _guGlassType,
                       _guReviewedByOfficial,
                       _guNotedByOfficial,
                       _guVatPercentage;
        private int   _guReviewedOfficialPos,
                      _guNotedByOfficialPos;

        int count = 0,
            newlinecount = 0;
        bool change_desc_format = false;
        string separete_descFormat = null;
        List<string> description_string_list = new List<string>();

        public bool CallFrmRDLCCompiler
        {
            get
            {
                return _callFrmRDLCCompiler;
            }
            set
            {
                _callFrmRDLCCompiler = value;               
            }
        }
        public bool ShowVatContactSummary
        {
            get
            {
                return _showVatContractSummary;
            }
            set
            {
                _showVatContractSummary = value;
            }
        }
        public string RDLCReportCompilerVatContractSummery
        {
            get
            {
                return _rdlcReportCompilerVatContractSummary;
            }
            set
            {
                _rdlcReportCompilerVatContractSummary = value;
            }
        }
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
        public string RDLCReportCompilerRowLimit
        {
            get
            {
                return _rdlcReportCompilerRowLimit;
            }
            set
            {
                _rdlcReportCompilerRowLimit = value;
            }
        }
        public bool RDLCReportCompilerShowSubTotal
        {
            get
            {
                return _rdlcReportCompilerShowSubTotal;
            }
            set
            {
                _rdlcReportCompilerShowSubTotal = value;
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

        public string RDLCGUGlassType
        {
            get
            {
                return _guGlassType;
            }
            set
            {
                _guGlassType = value;
            }
        }
        public string RDLCGUReviewedByOfficial
        {
            get
            {
                return _guReviewedByOfficial;
            }
            set
            {
                _guReviewedByOfficial = value;
            }
        }
        public int RDLCGUReviewedByOfficialPos
        {
            get
            {
                return _guReviewedOfficialPos;
            }
            set
            {
                _guReviewedOfficialPos = value;
            }
        }
        public string RDLCGUNotedByOfficial
        {
            get
            {
                return _guNotedByOfficial;
            }
            set
            {
                _guNotedByOfficial = value;
            }
        }
        public int RDLCGUNotedByOfficialPos
        {
            get
            {
                return _guNotedByOfficialPos;
            }
            set
            {
                _guNotedByOfficialPos = value;
            }
        }
        public string RDLCGUVatPercentage
        {
            get
            {
                return _guVatPercentage;
            }
            set
            {
                _guVatPercentage = value;
            }
        }
        public bool RDLCGUShowReviewedBy
        {
            get
            {
                return _guShowReviewedBy;
            }
            set
            {
                _guShowReviewedBy = value;
            }
        }
        public bool RDLCGUShowNotedBy
        {
            get
            {
                return _guShowNotedBy;
            }
            set
            {
                _guShowNotedBy = value;
            }
        }
        public bool RDLCGUShowVat
        {
            get
            {
                return _guShowVat;
            }
            set
            {
                _guShowVat = value;
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
        public decimal OutOfTownCharges
        {
            get
            {
                return outOfTownCharges;
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
               setDesc,
               Screen_DimensionFormat,
               Screen_UnitPrice,
               Screen_Qty,
               Screen_Discount,
               Screen_NetPrice;

        decimal prev_GlassArea,
                prev_GlassPrice,
                curr_GlassArea,
                curr_GlassPrice,
                windoorTotalListPrice = 0m,
                ScreenTotalListPrice = 0m,
                windoorDiscountAverage,
                ScreenDiscountAverage,
                screen_Windoor_DiscountAverage,
                total_DiscountedPrice_wo_VAT,
                windoortotaldiscount,
                screentotaldiscount,
                screen_priceXquantiy,
                screenUnitPriceTotal,
                outOfTownCharges,
                outOfTownChargesMultiplier;
        bool existing = false;
        bool showImage;
        decimal windoorpricecheck;//check price in rdlc report 
        decimal olddiscount, updateddiscount;
        int countfortick;

        #endregion

        private DataTable _glassUpgradeDT = new DataTable();
        decimal _totalNetPriceforPrint;


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

                 screenUnitPriceTotal = _mainPresenter.Screen_List.Sum(x => x.Screen_TotalAmount);
                foreach (var item in _mainPresenter.Screen_List)
                {
                    //screen_priceXquantiy = item.Screen_UnitPrice * item.Screen_Quantity;
                    //screenUnitPriceTotal = screenUnitPriceTotal + screen_priceXquantiy;

                    if (item.Screen_Quantity > 1)
                    {
                        for (int i = 1; i <= item.Screen_Quantity; i++)
                        {
                            screentotaldiscount = screentotaldiscount + item.Screen_Discount;
                        }
                    }
                    else
                    {
                        screentotaldiscount = screentotaldiscount + item.Screen_Discount;
                    }
                }

                decimal DiscountPercentage = screentotaldiscount / _mainPresenter.Screen_List.Sum(y => y.Screen_Quantity);

                Console.WriteLine(DiscountPercentage.ToString());

                foreach (var item in _mainPresenter.Screen_List)
                {

                    if (item.Screen_Set > 1)
                    {
                        if (item.Screen_Description.Contains("(Sets of"))
                        {
                            setDesc = " ";
                        }
                        else
                        {
                            setDesc = " (Sets of " + item.Screen_Set.ToString() + ")";
                        }
                    }
                    else
                    {
                        setDesc = " ";
                    }


                    if(item.Screen_Types == ScreenType._NoInsectScreen || item.Screen_Types == ScreenType._UnnecessaryForInsectScreen)
                    {
                        Screen_DimensionFormat = " - ";
                        Screen_UnitPrice = "0";
                        Screen_Qty = null;
                        Screen_Discount = " - ";
                        Screen_NetPrice = " - "; 
                    }
                    else
                    {
                        //Screen_DimensionFormat = item.Screen_Width + " x " + item.Screen_Height;
                        Screen_DimensionFormat = item.Screen_DisplayedDimension;
                        Screen_UnitPrice = item.Screen_UnitPrice.ToString("n");
                        Screen_Qty = item.Screen_Quantity.ToString();
                        Screen_Discount = Convert.ToString(item.Screen_Discount) + "%";
                        Screen_NetPrice = item.Screen_NetPrice.ToString("n");
                    }

                    _dsq.dtScreen.Rows.Add( item.Screen_Description + setDesc,
                                            Screen_DimensionFormat, // Screen widht x height
                                            item.Screen_WindoorID,
                                            Screen_UnitPrice, //screen unitprice
                                            Screen_Qty, //screen quantity
                                            screenUnitPriceTotal, 
                                            Convert.ToString(item.Screen_ItemNumber),
                                            Screen_NetPrice, // screen Netprice
                                            1,
                                            "",
                                            Screen_Discount, //screen discount
                                            "",
                                            DiscountPercentage
                                            );
                }
                clearingOperation();
                _mainPresenter.printStatus = "ScreenItem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Screen List Count is 0: ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtScreen.DefaultView;
            printQuote.EventLoad();
            printQuote.GetPrintQuoteView().RowLimit = _rdlcReportCompilerRowLimit;
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
                    if (RenderPDFAtBackGround != true)
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
                            foreach (var item in RDLCReportCompilerItemIndexes.ToArray())
                            {
                                showImage = false;
                                if (i == item)
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

                    #region separate Item description
                    for (int j = 0; j< lstQuoteUC.GetiQuoteItemListUC().itemDesc.Length;j++)
                    {
                       if(lstQuoteUC.GetiQuoteItemListUC().itemDesc[j] == '\n')
                        {
                            count++;
                        }

                    }
                    if(count >= 5)
                    {
                        change_desc_format = true;
                        string[] splitted_string = lstQuoteUC.GetiQuoteItemListUC().itemDesc.Split('\n');
                        foreach (var split in splitted_string)
                        {
                            description_string_list.Add(split);
                            Console.WriteLine(split);
                        }
                        // for(int arr =0; arr <15; arr++)
                        //{
                        //    if(splitted_string.Count() > description_string_list.Count())
                        //    {
                        //        description_string_list.Add(splitted_string[arr]);
                        //    }
                        //    else
                        //    {
                        //        description_string_list.Add(" ");
                        //    }
                        //}
                    }
                    else
                    {
                        change_desc_format = false;
                        count = 0; 
                    }
                    
                    if(change_desc_format == true)
                    {
                        for(int x = 0; x < description_string_list.Count; x++)
                        {
                            newlinecount++;
                            if (newlinecount == 3)
                            {
                                newlinecount = 0;
                                separete_descFormat = separete_descFormat + "  " + description_string_list[x] + "," + "\n";
                            }
                            else
                            {
                                separete_descFormat = separete_descFormat + "  " + description_string_list[x];   
                            }
                        }
                        Console.WriteLine(separete_descFormat.TrimEnd().Replace(" +", ""));
                    }
                    else
                    {
                        description_string_list.Clear();
                        count = 0;
                    }

                    if(separete_descFormat == null)
                    {
                        separete_descFormat = lstQuoteUC.GetiQuoteItemListUC().itemDesc;
                    }

                    #endregion

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
                                          showImage,
                                          separete_descFormat);
                    windoorpricecheck = windoorpricecheck + Convert.ToDecimal(lstQuoteUC.GetiQuoteItemListUC().GetLblNetPrice().Text); // check price

                    description_string_list.Clear();
                    count = 0;
                    newlinecount = 0;
                    separete_descFormat = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message + "\n Location: " + this);
            }

            _mainPresenter.printStatus = "WinDoorItems";
            Console.WriteLine(" Windoor Total Discounted Price: " + windoorpricecheck.ToString());
            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtQuote.DefaultView;

            if (RenderPDFAtBackGround != true)
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
                    windoorTotalListPrice = windoorTotalListPrice + price_x_quantity;
                    if (wdm.WD_quantity > 1)
                    {
                        for (int i = 1; i <= wdm.WD_quantity; i++)
                        {
                            windoortotaldiscount = windoortotaldiscount + wdm.WD_discount;
                        }
                    }
                    else
                    {
                        windoortotaldiscount = windoortotaldiscount + wdm.WD_discount;
                    }

                }
                windoorTotalListCount = _quotationModel.Lst_Windoor.Sum(m => m.WD_quantity);
                windoorDiscountAverage = windoortotaldiscount / _quotationModel.Lst_Windoor.Sum(y => y.WD_quantity) / 100;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in windoormodel lst_windoor " + this + " " + ex.Message);
                divisor = 1;
            }

            try
            {
                //ScreenTotalListPrice = _mainPresenter.Screen_List.Sum(x => x.Screen_TotalAmount);
                ScreenTotalListCount = _mainPresenter.Screen_List.Sum(x => x.Screen_Quantity);

                foreach (var item in _mainPresenter.Screen_List)
                {
                    //screen_priceXquantiy = item.Screen_UnitPrice * item.Screen_Quantity;
                    //ScreenTotalListPrice = ScreenTotalListPrice + screen_priceXquantiy;
                    if (item.Screen_Quantity > 1)
                    {
                        for (int i = 1; i <= item.Screen_Quantity; i++)
                        {
                            screentotaldiscount = screentotaldiscount + item.Screen_Discount;
                        }
                    }
                    else if (item.Screen_Quantity == 1)
                    {
                        screentotaldiscount = screentotaldiscount + item.Screen_Discount;
                    }
                    else
                    {
                        Console.WriteLine("Zero Quantity Detected");
                    }


                    ScreenTotalListPrice += Math.Round(item.Screen_TotalAmount,2);
                }

                ScreenDiscountAverage = (screentotaldiscount / ScreenTotalListCount) / 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in screenmodel " + this + " " + ex.Message);
                divisor = 1;
            }

             screen_Windoor_DiscountAverage = (windoorDiscountAverage + ScreenDiscountAverage) / divisor;
             province = _mainPresenter.projectAddress.Split(',');
             archi = province[province.Length - 1].Trim();

            if(archi == "Luzon")
            {
                outOfTownChargesMultiplier = 0.025m;
            }
            else if (archi == "Visayas")
            {
                outOfTownChargesMultiplier = 0.04m;
            }
            else if (archi == "Mindanao")
            {
                outOfTownChargesMultiplier = 0.05m;
            }

            outOfTownCharges = Math.Round(((windoorTotalListPrice + ScreenTotalListPrice) * outOfTownChargesMultiplier),2);
            if(outOfTownCharges <= 50000) { outOfTownCharges = 50000; }
            total_DiscountedPrice_wo_VAT = Math.Round((windoorTotalListPrice + ScreenTotalListPrice) * (1 - screen_Windoor_DiscountAverage),2);

            //Console.WriteLine(archi + " " + outOfTownCharges.ToString());
            Console.WriteLine(archi + " "  + OutOfTownCharges.ToString());
            Console.WriteLine("This is total DiscountedPrice w/o Vat " + Math.Round((total_DiscountedPrice_wo_VAT),2));
            Console.WriteLine("2 decimal places: " + Math.Truncate(total_DiscountedPrice_wo_VAT * 100) / 100);         
            //Console.WriteLine(" total windoor discount from forloop" + windoortotaldiscount);
            //Console.WriteLine("Windoor DiscountTotal: " +  _quotationModel.Lst_Windoor.Sum(x => x.WD_discount));
            //Console.WriteLine("Windoor Average Discount.: " + windoorDiscountAverage);
            //Console.WriteLine("Screen Average Discount.: " + ScreenDiscountAverage);
            //Console.WriteLine("Screen & Windoor Discount Average.: " + screen_Windoor_DiscountAverage);
            //Console.WriteLine("");
            //Console.WriteLine("Windoor list count total of: " + windoorTotalListCount.T oString());
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
          
            _mainPresenter.printStatus = "ContractSummary";
            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dtqoute.dtContractSummary.DefaultView;
            if (CallFrmRDLCCompiler != true)
            {
                if (RenderPDFAtBackGround != true)
                {
                    printQuote.GetPrintQuoteView().ShowPrintQuoteView();
                    printQuote.GetPrintQuoteView().QuotationOuofTownExpenses = OutOfTownCharges.ToString("N2");
                }
                else
                {
                    printQuote.EventLoad();
                    printQuote.GetPrintQuoteView().QuotationOuofTownExpenses = _rdlcReportCompilerOutofTownExpenses;
                    printQuote.GetPrintQuoteView().VatPercentage = _rdlcReportCompilerVatContractSummary;
                    printQuote.PrintRDLCReport();
                }
            }
            clearingOperation();
        }
        public void QuoteItemList_PrintAnnexRDLC()
        {
            _printQuotePresenter.printAnnexRDLC();
        }
        public void ContractSummaryComputation()
        {
            DSQuotation _dtqoute = new DSQuotation();
            try
            {
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    var price_x_quantity = wdm.WD_price * wdm.WD_quantity;
                    windoorTotalListPrice = windoorTotalListPrice + price_x_quantity;
                    if (wdm.WD_quantity > 1)
                    {
                        for (int i = 1; i <= wdm.WD_quantity; i++)
                        {
                            windoortotaldiscount = windoortotaldiscount + wdm.WD_discount;
                        }
                    }
                    else
                    {
                        windoortotaldiscount = windoortotaldiscount + wdm.WD_discount;
                    }

                }
                windoorTotalListCount = _quotationModel.Lst_Windoor.Sum(m => m.WD_quantity);
                windoorDiscountAverage = windoortotaldiscount / _quotationModel.Lst_Windoor.Sum(y => y.WD_quantity) / 100;

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

                foreach (var item in _mainPresenter.Screen_List)
                {
                    //screen_priceXquantiy = item.Screen_UnitPrice * item.Screen_Quantity;
                    //ScreenTotalListPrice = ScreenTotalListPrice + screen_priceXquantiy;
                    if (item.Screen_Quantity > 1)
                    {
                        for (int i = 1; i <= item.Screen_Quantity; i++)
                        {
                            screentotaldiscount = screentotaldiscount + item.Screen_Discount;
                        }
                    }
                    else
                    {
                        screentotaldiscount = screentotaldiscount + item.Screen_Discount;
                    }
                }

                ScreenDiscountAverage = (screentotaldiscount / ScreenTotalListCount) / 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in screenmodel " + this + " " + ex.Message);
                divisor = 1;
            }

            screen_Windoor_DiscountAverage = (windoorDiscountAverage + ScreenDiscountAverage) / divisor;
            province = _mainPresenter.projectAddress.Split(',');
            archi = province[province.Length - 1].Trim();

            if (archi == "Luzon")
            {
                outOfTownChargesMultiplier = 0.025m;
            }
            else if (archi == "Visayas")
            {
                outOfTownChargesMultiplier = 0.04m;
            }
            else if (archi == "Mindanao")
            {
                outOfTownChargesMultiplier = 0.05m;
            }

            outOfTownCharges = Math.Round(((windoorTotalListPrice + ScreenTotalListPrice) * outOfTownChargesMultiplier), 2);
            if (outOfTownCharges <= 50000) { outOfTownCharges = 50000; }
            total_DiscountedPrice_wo_VAT = Math.Round((windoorTotalListPrice + ScreenTotalListPrice) * (1 - screen_Windoor_DiscountAverage), 2);
     
            clearingOperation();
        }
        private void clearingOperation()
        {
            windoorTotalListCount = 0;
            windoorTotalListPrice = 0;
            ScreenTotalListCount = 0;
            ScreenTotalListPrice = 0;
            ScreenDiscountAverage = 0;
            windoorDiscountAverage = 0;
            windoortotaldiscount = 0;
            screentotaldiscount = 0;
            screen_Windoor_DiscountAverage = 0;
            screen_priceXquantiy = 0;
            screenUnitPriceTotal = 0;
            //outOfTownCharges = 0;
             
            Screen_DimensionFormat = null;
            Screen_UnitPrice = null;        
            Screen_Qty = null;                                            
            Screen_Discount = null;      
            Screen_NetPrice = null;      

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
            if (_lstGlassSummary.Count == 0)
            {
                #region PrintGlass

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

                                        _intInString = curr_GlassDesc.All(char.IsDigit);
                                        
                                        if(_intInString == true)
                                        {
                                            curr_IntDescription = Convert.ToInt32(curr_GlassDesc.Substring(0, 2));
                                            _intInString = false;
                                        }
                                        else
                                        {
                                            curr_IntDescription = 0;
                                        }


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
                                _intInString = curr_GlassDesc.All(char.IsDigit);

                                if (_intInString == true)
                                {
                                    curr_IntDescription = Convert.ToInt32(curr_GlassDesc.Substring(0, 2));
                                    _intInString = false;
                                }
                                else
                                {
                                    curr_IntDescription = 0;
                                }

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

                #endregion
            }

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
                    //_quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxTopView().Image = wdm.WD_SlidingTopViewImage;

                    if (wdm.WD_price == 0 && wdm.IsFromLoad == true)
                    {
                        //_quotationModel.ItemCostingPriceAndPoints();
                        //wdm.WD_price = Math.Round(_quotationModel.lstTotalPrice[i], 2);
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
                LoadGlassUpgradeDt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region Glassupgrade Load 
        private DataColumn CreateColumn(string columnName, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columnName;
            col.Caption = caption;

            return col;
        }
        private void LoadGlassUpgradeDt()
        {
            _glassUpgradeDT.Columns.Add(CreateColumn("Item No.", "Item No", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Qty", "Qty", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Width", "Width", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Height", "Height", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Original Glass Used", "Original Glass Used", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("GlassPrice", "GlassPrice", "System.String"));

            _glassUpgradeDT.Columns.Add(CreateColumn("Upgraded To", "Glass Upgraded To", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Glass Upgrade Price", "Glass Upgrade Price", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Upgrade Value", "Upgrade Value", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Amount Per Unit", "Amount Per Unit", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Total Net Prices", "Total Net Prices", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("GlassType", "GlassType", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Primary Key", "Primary Key", "System.Decimal"));


            foreach (var item in _mainPresenter.NonUnglazed)
            {
                _glassUpgradeDT.Rows.Add(item[0].ToString(),
                                         item[1].ToString(),
                                         item[2].ToString(),
                                         item[3].ToString(),
                                         item[4].ToString(),
                                         item[5].ToString(),
                                         item[6].ToString(),
                                         item[7].ToString(),
                                         item[8].ToString(),
                                         item[9].ToString(),
                                         item[10].ToString(),
                                         item[11].ToString(),
                                         item[12].ToString(),
                                         item[13].ToString());
            }
        }
        private decimal DsqValueTotalNetPricePrint(string glassType)
        {
            var charToRemove = new string[] { "(", ")" };
            string _strRmvChr;
            decimal _convTotalNetPrice;

            foreach (DataRow row in _glassUpgradeDT.Rows)
            {
                if (row["GlassType"].ToString() == glassType)
                {
                    if (!row["Total Net Prices"].ToString().Contains("("))
                    {
                        _convTotalNetPrice = Convert.ToDecimal(row["Total Net Prices"]);
                        _totalNetPriceforPrint = _totalNetPriceforPrint + _convTotalNetPrice;
                    }
                    else
                    {
                        _strRmvChr = row["Total Net Prices"].ToString();
                        foreach (var item in charToRemove)
                        {
                            _strRmvChr = _strRmvChr.Replace(item, string.Empty);
                        }
                        _convTotalNetPrice = Convert.ToDecimal(_strRmvChr);
                        _totalNetPriceforPrint = _totalNetPriceforPrint - _convTotalNetPrice;
                    }


                }
            }

            return _totalNetPriceforPrint;

        }
        public void PrintGlassUpgrade()
        {
            DSQuotation _dsq = new DSQuotation();
            string _itemNumHolder,
                   _dimension;

            /*row0 itemNo.
             *row1 Window/Door I.D.
             *row2 Qty
             *row3 Width
             *row4 Height
             *row5 Original Glass Used
             *row6 GlassPrice
             *row7 Upgraded To
             *row8 Glass Upgrade Price
             *row9 Upgrade Value
             *row10 Amount Per Unit
             *row11 Total Net Prices
             *row12 GlassType
             *row13 Primary Key
             */
            try
            {
                foreach (DataRow dtrow in _glassUpgradeDT.Rows)
                {

                    if (dtrow["GlassType"].ToString() == _guGlassType)
                    {
                        decimal TotalNetPrice = DsqValueTotalNetPricePrint(_guGlassType);

                        if (dtrow["Primary Key"].ToString().Contains(".0"))
                        {
                            _itemNumHolder = dtrow["Item No."].ToString();
                        }
                        else
                        {
                            _itemNumHolder = " ";
                        }

                        _dimension = dtrow["Width"].ToString() + " x " + dtrow["Height"].ToString();

                        _dsq.dtGlassUpgrade.Rows.Add(_itemNumHolder,
                                                     dtrow["Window/Door I.D."],
                                                     dtrow["Original Glass Used"],
                                                     dtrow["Upgraded To"],
                                                     _dimension,
                                                     dtrow["Amount Per Unit"],
                                                     dtrow["Qty"],
                                                     dtrow["Total Net Prices"],
                                                     TotalNetPrice,
                                                     dtrow["GlassType"]);

                    }
                }
                //change this to render backgroundS
                _mainPresenter.printStatus = "GlassUpgrade";
                IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this, _mainPresenter, _quotationModel);
                printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtGlassUpgrade.DefaultView;
                printQuote.EventLoad();
                printQuote.GetPrintQuoteView().GlassType = _guGlassType;
                printQuote.GetPrintQuoteView().VatPercentage = _guVatPercentage;
                printQuote.PrintRDLCReport();

                //reset print variables 
                _totalNetPriceforPrint = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in GU Print: " + ex.Message);
            }
        }

        #endregion

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

        public void refreshItemList()
        {
            try
            {
                Application.OpenForms["QuoteItemListView"].Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in " + this + ex.Message);
            }
        }

        //for ScalingItemSizePicture
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            //create new destImage object
            var destImage = new Bitmap(width, height);

            //maintains DPI regardless of physical size

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
