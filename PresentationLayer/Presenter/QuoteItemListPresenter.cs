using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Divider;
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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace PresentationLayer.Presenter
{
    public class QuoteItemListPresenter : IQuoteItemListPresenter
    {
        IQuoteItemListView _quoteItemListView;

        private IUnityContainer _unityC;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private IMainPresenter _mainPresenter;

        #region Variables
        private List<IQuoteItemListUCPresenter> _lstQuoteItemUC = new List<IQuoteItemListUCPresenter>();
        private List<int> _lstItemArea = new List<int>();
        private List<string> lst_glassThickness = new List<string>();
        private List<string> lst_glassFilm = new List<string>();
        private List<string> lst_Description = new List<string>();
        private List<string> lst_DuplicatePnl = new List<string>();
        private List<decimal> lstTotalPrice = new List<decimal>();


        int GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0,
            CostPerPoints = 60;

        string FrameTypeDesc,
               AllItemDescription,
               motorizeDesc,
               GeorgianBarHorizontalDesc,
               GeorgianBarVerticalDesc,
               NewNoneDuplicatePnlAndCount,
               lst_DescDist,
               glassThick,
               glassFilm,
               costingPointsDesc,
               laborCostDesc,
               FramePriceDesc,
               FrameReinPriceDesc,
               SashPriceDesc,
               SashReinPriceDesc,
               GBPriceDesc,
               InstallationCostDesc,
               FittingAndSuppliesDesc;

        decimal FramePricePerLinearMeter = 1023.29m,
                FrameReinPricePerLinearMeter = 33.73m,
                SashPricePerLinearMeter = 1210.27m,
                SashReinPricePerLinearMeter = 24.53m,
                GlazingBeadPricePerLinearMeter = 56.45m,
                FS_16HD_casementPricePerPiece = 825.81m,
                FS_26HD_casementPricePerPiece = 1839.35m,
                Glass_6mmClr_PricePerSqrMeter = 670.00m,
                Glass_10mmClr_PricePerSqrMeter = 1662.00m,
                Glass_12mmClr_PricePerSqrMeter = 1941.00m,
                Glass_6mmTemp_PricePerSqrMeter = 1614.00m,
                Glass_10mmTemp_PricePerSqrMeter = 3201.00m,
                Glass_12mmTemp_PricePerSqrMeter = 3619.00m,
                FramePrice,
                FrameReinPrice,
                SashPrice,
                SashReinPrice,
                GbPrice,
                FramePerimeter,
                SashPerimeter,
                GlassPrice,
                ProfileColorPoints = 13,
                CostingPoints = 0,
                InstallationPoints = 0,
                LaborCost = 0,
                InstallationCost = 0,
                FittingAndSuppliesCost,
                TotaPrice;
        #endregion

        public QuoteItemListPresenter(IQuoteItemListView quoteItemListView,
                                      IPrintQuotePresenter printQuotePresenter
                                      )
        {
            _quoteItemListView = quoteItemListView;
            _printQuotePresenter = printQuotePresenter;

            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _quoteItemListView.TSbtnPrintClickEventRaised += new EventHandler(OnTSbtnPrintClickEventRaised);
            _quoteItemListView.QuoteItemListViewLoadEventRaised += _quoteItemListView_QuoteItemListViewLoadEventRaised;
        }

        int TotalItemArea = 0;
        private void _quoteItemListView_QuoteItemListViewLoadEventRaised(object sender, EventArgs e)
        {


            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel);
                UserControl quoteItem = (UserControl)_quoteItemListUCPresenter.GetiQuoteItemListUC();
                _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                quoteItem.Dock = DockStyle.Top;
                quoteItem.BringToFront();

                itemDescription();
                ItemCostingPoints();

                List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();
                List<string> lst_glassFilmDistinct = lst_glassFilm.Distinct().ToList();

                foreach (string GT in lst_glassThicknessDistinct)
                {
                    glassThick += GT;
                }

                foreach (string GF in lst_glassFilmDistinct)
                {
                    glassFilm += "with " + GF + "\n";
                }

                if (GeorgianBarHorizontalQty > 0)
                {
                    GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                }

                if (GeorgianBarVerticalQty > 0)
                {
                    GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                }

                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];

                wdm.WD_description += glassThick + glassFilm + GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc;

                Console.WriteLine(Math.Round(lstTotalPrice[i], 2));

                _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName = wdm.WD_name;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemWindoorNumber = "WD-1A"; //location
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n"
                                                                          + wdm.WD_description
                                                                          + costingPointsDesc
                                                                          + laborCostDesc
                                                                          + InstallationCostDesc
                                                                          + FramePriceDesc
                                                                          + FrameReinPriceDesc
                                                                          + SashPriceDesc
                                                                          + SashReinPriceDesc
                                                                          + GBPriceDesc
                                                                          + FittingAndSuppliesDesc;

                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemPrice.Value = Math.Round(lstTotalPrice[i], 2);  //TotaPrice;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblPrice().Text = Math.Round(lstTotalPrice[i], 2).ToString();  //TotaPrice.ToString();
                this._lstQuoteItemUC.Add(_quoteItemListUCPresenter);
                TotalItemArea = wdm.WD_width * wdm.WD_height;
                this._lstItemArea.Add(TotalItemArea);
            }
        }


        private void OnTSbtnPrintClickEventRaised(object sender, EventArgs e)
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
                Image img = _quotationModel.Lst_Windoor[i].WD_image;

                _quotationModel.Lst_Windoor[i].WD_image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);

                byte[] arrimage = mstream.ToArray();
                string byteToStr = Convert.ToBase64String(arrimage);

                IQuoteItemListUCPresenter lstQuoteUC = this._lstQuoteItemUC[i];



                _dsq.dtQuote.Rows.Add(lstQuoteUC.GetiQuoteItemListUC().ItemName,
                                      lstQuoteUC.GetiQuoteItemListUC().itemDesc,
                                      lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber,
                                      byteToStr,
                                      (int)lstQuoteUC.GetiQuoteItemListUC().itemQuantity.Value,
                                      (int)lstQuoteUC.GetiQuoteItemListUC().itemPrice.Value,
                                      (int)lstQuoteUC.GetiQuoteItemListUC().itemDiscount.Value,
                                      Convert.ToDecimal(lstQuoteUC.GetiQuoteItemListUC().GetLblNetPrice().Text),
                                      i + 1);
            }

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


        public void itemDescription()
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                lst_DuplicatePnl.Clear();
                lst_Description.Clear();
                NewNoneDuplicatePnlAndCount = string.Empty;
                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    if (fr.Frame_Type == Frame_Padding.Window)
                    {
                        FrameTypeDesc = "Window";
                    }
                    else if (fr.Frame_Type == Frame_Padding.Door)
                    {
                        FrameTypeDesc = "Door";
                    }



                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {

                                #region 1stApproach
                                //if (pnl.Panel_Type.Contains("Fixed"))
                                //{
                                //    fixedCount += 1;
                                //}
                                //else if (pnl.Panel_Type.Contains("Awning"))
                                //{
                                //    AwningCount += 1;
                                //}
                                //else if (pnl.Panel_Type.Contains("Casement"))
                                //{
                                //    CasementCount += 1;
                                //}

                                //if (pnl.Panel_GlassThicknessDesc != null)
                                //{
                                //    lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + "\n");
                                //}
                                //if (pnl.Panel_GlassFilm.ToString() != "None")
                                //{
                                //    lst_glassFilm.Add(pnl.Panel_GlassFilm.ToString());
                                //}




                                //if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                //{
                                //    GeorgianBarHorizontalQty += pnl.Panel_GeorgianBar_HorizontalQty;
                                //    GeorgianBarVerticalQty += pnl.Panel_GeorgianBar_VerticalQty;

                                //    GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                                //    GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                                //}


                                //if (pnl.Panel_MotorizedOptionVisibility == true)
                                //{
                                //    motorizeDesc = " Panel Motorized";
                                //}
                                //else
                                //{
                                //    motorizeDesc = " Panel";
                                //}

                                //if (fixedCount != 0 && pnl.Panel_Type.Contains("Fixed"))
                                //{
                                //    AllItemDescription = AllItemDescription + fixedCount.ToString() + motorizeDesc + " Fixed " + FrameTypeDesc + "\n";
                                //}
                                //if (AwningCount != 0 && pnl.Panel_Type.Contains("Awning"))
                                //{
                                //    AllItemDescription = AllItemDescription + AwningCount.ToString() + motorizeDesc + " Awning " + FrameTypeDesc + "\n";
                                //}
                                //if (CasementCount != 0 && pnl.Panel_Type.Contains("Casement"))
                                //{
                                //    AllItemDescription = AllItemDescription + CasementCount.ToString() + motorizeDesc + " Casement " + FrameTypeDesc + "\n";
                                //}

                                //List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();
                                //List<string> lst_glassFilmDistinct = lst_glassFilm.Distinct().ToList();

                                //foreach (string GT in lst_glassThicknessDistinct)
                                //{
                                //    AllItemDescription += GT;
                                //}

                                //if (lst_glassFilmDistinct != null)
                                //{
                                //    foreach (string GF in lst_glassFilmDistinct)
                                //    {
                                //        AllItemDescription += "with " + GF + "\n";
                                //    }
                                //}

                                //AllItemDescription += GeorgianBarHorizontalDesc;
                                //AllItemDescription += GeorgianBarVerticalDesc;

                                ////lst_Description.Add(AllItemDescription);
                                // wdm.WD_description = AllItemDescription;
                                #endregion

                                //GlassThickness
                                if (pnl.Panel_GlassThicknessDesc != null)
                                {
                                    lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + "\n");
                                }

                                //Glassfilm
                                if (pnl.Panel_GlassFilm.ToString() != "None")
                                {
                                    lst_glassFilm.Add(pnl.Panel_GlassFilm.ToString());
                                }

                                //GeorgianBar
                                if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                {
                                    GeorgianBarHorizontalQty += pnl.Panel_GeorgianBar_HorizontalQty;
                                    GeorgianBarVerticalQty += pnl.Panel_GeorgianBar_VerticalQty;

                                    //AllItemDescription += GeorgianBarHorizontalDesc;
                                    //AllItemDescription += GeorgianBarVerticalDesc;
                                }

                                //panel name desc
                                #region panelNameDesc
                                if (pnl.Panel_MotorizedOptionVisibility == true)
                                {
                                    motorizeDesc = "1 Panel Motorized";
                                }
                                else
                                {
                                    motorizeDesc = "1 Panel";
                                }

                                AllItemDescription = motorizeDesc + " " + pnl.Panel_Type.Replace("Panel", string.Empty) + FrameTypeDesc + "\n";

                                #endregion

                                lst_Description.Add(AllItemDescription);
                            }

                        }
                    }
                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)//single
                    {
                        IPanelModel Singlepnl = fr.Lst_Panel[0];
                        if (Singlepnl.Panel_MotorizedOptionVisibility == true)
                        {
                            motorizeDesc = "Panel Motorized ";
                            wdm.WD_description = wdm.WD_profile + "\n1 " + motorizeDesc + Singlepnl.Panel_Type.Replace("Panel", string.Empty) + " " + FrameTypeDesc;
                        }
                        else
                        {
                            motorizeDesc = "";
                            wdm.WD_description = wdm.WD_profile + "\n1 " + motorizeDesc + Singlepnl.Panel_Type + " " + FrameTypeDesc;
                        }
                    }
                }

                #region DuplicatedItemListStringManipulation
                //count duplicate in list
                Dictionary<string, int> freqMap = lst_Description.GroupBy(x => x)
                                                .Where(g => g.Count() > 1)
                                                .ToDictionary(x => x.Key, x => x.Count());

                string DuplicatePnlAndCount = String.Join("", freqMap);
                if (DuplicatePnlAndCount != string.Empty)
                {
                    string NewDuplicatePnlAndCount = DuplicatePnlAndCount.Replace("]", string.Empty);
                    NewDuplicatePnlAndCount = NewDuplicatePnlAndCount.Replace("[", "\n");
                    NewDuplicatePnlAndCount = NewDuplicatePnlAndCount.Replace(",", string.Empty);
                    string[] words = NewDuplicatePnlAndCount.Split('\n');

                    for (int a = 0; a < words.Length; a++)
                    {
                        if (a != 0)
                        {
                            string split1 = words[a],
                                   split2 = words[a + 1];
                            string DuplicatePnl = split1.Replace("1", split2) + "\n";

                            lst_DuplicatePnl.Add(DuplicatePnl);
                            a++;
                        }
                    }
                }
                #endregion

                #region NonDuplicatedItemListStringManipulation


                //Not Duplicated Item
                Dictionary<string, int> freqMap2 = lst_Description.GroupBy(a => a)
                                               .Where(b => b.Count() == 1)
                                               .ToDictionary(a => a.Key, a => a.Count());

                string NoneDuplicatePnlAndCount = String.Join("", freqMap2);
                NewNoneDuplicatePnlAndCount = NoneDuplicatePnlAndCount.Replace("[", string.Empty);
                NewNoneDuplicatePnlAndCount = NewNoneDuplicatePnlAndCount.Replace(", 1]", string.Empty);
                #endregion

                List<string> lst_DescriptionDistinct = lst_Description.Distinct().ToList();

                if (lst_DescriptionDistinct.Count != 0)
                {
                    wdm.WD_description = wdm.WD_profile + "\n" + NewNoneDuplicatePnlAndCount;
                    for (int i = 0; i < lst_DuplicatePnl.Count; i++)
                    {
                        lst_DescDist = lst_DuplicatePnl[i];
                        wdm.WD_description += lst_DescDist;
                    }

                }


            }


        }

        public void ItemCostingPoints()
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    #region baseOnDimensionAndColorPoints
                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                    {
                        if (wdm.WD_width >= 2000)
                        {
                            ProfileColorPoints = 16;
                        }
                        else if (wdm.WD_height >= 2000)
                        {
                            ProfileColorPoints = 16;
                        }
                        else if (wdm.WD_width >= 3000)
                        {
                            ProfileColorPoints = 18;
                        }
                        else if (wdm.WD_height >= 3000)
                        {
                            ProfileColorPoints = 18;
                        }

                        CostingPoints += ProfileColorPoints * 4;
                        InstallationPoints += (ProfileColorPoints / 3) * 4;
                    }
                    else
                    {
                        ProfileColorPoints = 14;
                        if (wdm.WD_width >= 2000)
                        {
                            ProfileColorPoints = 18;
                        }
                        else if (wdm.WD_height >= 2000)
                        {
                            ProfileColorPoints = 18;
                        }
                        else if (wdm.WD_width >= 3000)
                        {
                            ProfileColorPoints = 19;
                        }
                        else if (wdm.WD_height >= 3000)
                        {
                            ProfileColorPoints = 19;
                        }

                        CostingPoints += ProfileColorPoints * 4;
                        InstallationPoints += (ProfileColorPoints / 3) * 4;
                    }
                    #endregion

                    #region FramePrice
                    FramePerimeter = (wdm.WD_height + wdm.WD_width) * 2;


                    FramePrice = (FramePerimeter / 1000) * FramePricePerLinearMeter;
                    FrameReinPrice = (FramePerimeter / 1000) * FrameReinPricePerLinearMeter;
                    #endregion

                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IDividerModel div in mpnl.MPanelLst_Divider)
                            {
                                CostingPoints -= 2;
                                InstallationPoints -= 2;
                            }
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                if (pnl.Panel_SashPropertyVisibility == true)
                                {
                                    #region SashPrice 
                                    SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                    SashPrice = (SashPerimeter / 1000) * SashPricePerLinearMeter;
                                    SashReinPrice = (SashPerimeter / 1000) * SashReinPricePerLinearMeter;
                                    GbPrice = (SashPerimeter / 1000) * GlazingBeadPricePerLinearMeter;
                                    #endregion

                                    #region FrictionStayPrice
                                    if (pnl.Panel_Type.Contains("Casement"))
                                    {
                                        FittingAndSuppliesCost = FS_16HD_casementPricePerPiece * 2;
                                    }

                                    if (pnl.Panel_Type.Contains("Awning"))
                                    {
                                        if (pnl.Panel_SashHeight >= 800)
                                        {
                                            FittingAndSuppliesCost = FS_26HD_casementPricePerPiece * 2;
                                        }
                                        else
                                        {
                                            FittingAndSuppliesCost = FS_16HD_casementPricePerPiece * 2;
                                        }
                                    }
                                    #endregion

                                    CostingPoints += ProfileColorPoints * 4;
                                    InstallationPoints += (ProfileColorPoints / 3) * 4;
                                }
                                if (pnl.Panel_ChkText == "dsash")
                                {
                                    #region SashPrice 
                                    SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                    SashPrice = (SashPerimeter / 1000) * SashPricePerLinearMeter;
                                    SashReinPrice = (SashPerimeter / 1000) * SashReinPricePerLinearMeter;
                                    GbPrice = (SashPerimeter / 1000) * GlazingBeadPricePerLinearMeter;
                                    #endregion

                                    CostingPoints += ProfileColorPoints * 4;
                                    InstallationPoints += (ProfileColorPoints / 3) * 4;
                                }
                            }
                        }
                    }
                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)//single
                    {
                        IPanelModel Singlepnl = fr.Lst_Panel[0];

                        if (Singlepnl.Panel_SashPropertyVisibility == true)
                        {
                            #region SashPrice 
                            SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                            SashPrice = (SashPerimeter / 1000) * SashPricePerLinearMeter;
                            SashReinPrice = (SashPerimeter / 1000) * SashReinPricePerLinearMeter;
                            GbPrice = (SashPerimeter / 1000) * GlazingBeadPricePerLinearMeter;
                            #endregion

                            #region FrictionStayPrice
                            if (Singlepnl.Panel_Type.Contains("Casement"))
                            {
                                FittingAndSuppliesCost = FS_16HD_casementPricePerPiece * 2;
                            }

                            if (Singlepnl.Panel_Type.Contains("Awning"))
                            {
                                if (Singlepnl.Panel_SashHeight >= 800)
                                {
                                    FittingAndSuppliesCost = FS_26HD_casementPricePerPiece * 2;
                                }
                                else
                                {
                                    FittingAndSuppliesCost = FS_16HD_casementPricePerPiece * 2;
                                }
                            }
                            #endregion 
                        }

                        if (Singlepnl.Panel_ChkText == "dsash")
                        {
                            #region SashPrice 
                            SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                            SashPrice = (SashPerimeter / 1000) * SashPricePerLinearMeter;
                            SashReinPrice = (SashPerimeter / 1000) * SashReinPricePerLinearMeter;
                            GbPrice = (SashPerimeter / 1000) * GlazingBeadPricePerLinearMeter;
                            #endregion 
                        }

                        #region Glass 

                        if (Singlepnl.Panel_GlassThickness >= 6.0f &&
                            Singlepnl.Panel_GlassThickness <= 9.0f)
                        {
                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                            {
                                GlassPrice = (Singlepnl.Panel_SashHeight * Singlepnl.Panel_SashWidth) * Glass_6mmTemp_PricePerSqrMeter;
                            }
                            else
                            {
                                GlassPrice = (Singlepnl.Panel_SashHeight * Singlepnl.Panel_SashWidth) * Glass_6mmClr_PricePerSqrMeter;
                            }
                            Console.WriteLine("six to nine" + Singlepnl.Panel_GlassThicknessDesc);
                        }
                        else if (Singlepnl.Panel_GlassThickness == 10.0f ||
                         Singlepnl.Panel_GlassThickness == 11.0f)
                        {
                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                            {
                                GlassPrice = (Singlepnl.Panel_SashHeight * Singlepnl.Panel_SashWidth) * Glass_10mmTemp_PricePerSqrMeter;
                            }
                            else
                            {
                                GlassPrice = (Singlepnl.Panel_SashHeight * Singlepnl.Panel_SashWidth) * Glass_10mmClr_PricePerSqrMeter;
                            }

                            Console.WriteLine("ten to eleven");
                        }
                        else if (Singlepnl.Panel_GlassThickness >= 12.0f)
                        {
                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                            {
                                GlassPrice = (Singlepnl.Panel_SashHeight * Singlepnl.Panel_SashWidth) * Glass_12mmTemp_PricePerSqrMeter;
                            }
                            else
                            {
                                GlassPrice = (Singlepnl.Panel_SashHeight * Singlepnl.Panel_SashWidth) * Glass_12mmClr_PricePerSqrMeter;
                            }

                            Console.WriteLine("twelve above");
                        }

                        #endregion

                        CostingPoints += ProfileColorPoints * 4;
                        InstallationPoints += (ProfileColorPoints / 3) * 4;
                    }
                }



                LaborCost = CostingPoints * CostPerPoints;
                InstallationCost = InstallationPoints * CostPerPoints;

                TotaPrice = Math.Round(LaborCost, 2) +
                            Math.Round(InstallationCost, 2) +
                            Math.Round(FramePrice, 2) +
                            Math.Round(FrameReinPrice, 2) +
                            Math.Round(SashPrice, 2) +
                            Math.Round(SashReinPrice, 2) +
                            Math.Round(GbPrice, 2) +
                            Math.Round(FittingAndSuppliesCost, 2);

                TotaPrice = (TotaPrice * 1.3m) + TotaPrice;

                lstTotalPrice.Add(TotaPrice);



                //costingPointsDesc = "\n\nTotal Points: " + Math.Round(CostingPoints, 2);
                //laborCostDesc = "\n\nLabor Cost: " + Math.Round(LaborCost, 2);
                //FramePriceDesc = "\n\nFrame Price per linear meter: " + Math.Round(FramePrice, 2);
                //FrameReinPriceDesc = "\n\nFrame Rein Price per linear meter: " + Math.Round(FrameReinPrice, 2);
                //SashPriceDesc = "\n\nSash Price per linear meter: " + Math.Round(SashPrice, 2);
                //SashReinPriceDesc = "\n\nSash Rein Price per linear meter: " + Math.Round(SashReinPrice, 2);
                //GBPriceDesc = "\n\nGB Price per linear meter: " + Math.Round(GbPrice, 2);
                //InstallationCostDesc = "\n\nInstallation Cost: " + Math.Round(InstallationCost, 2);
                //FittingAndSuppliesDesc = "\n\nFittingAndSupplies Cost: " + Math.Round(FittingAndSuppliesCost, 2);


                CostingPoints = 0;
                InstallationPoints = 0;
                TotaPrice = 0;
                LaborCost = 0;
                InstallationCost = 0;
                FramePrice = 0;
                FrameReinPrice = 0;
                SashPrice = 0;
                SashReinPrice = 0;
                GbPrice = 0;
                FittingAndSuppliesCost = 0;
            }

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
