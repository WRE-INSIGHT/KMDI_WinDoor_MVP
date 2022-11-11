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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

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
        private List<string> lst_glassThickness = new List<string>();
        private List<string> lst_glassThicknessPerItem = new List<string>();
        private List<string> lst_glassFilm = new List<string>();
        private List<string> lst_Description = new List<string>();
        private List<string> lst_DuplicatePnl = new List<string>();

        int GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0;

        string glass,
               FrameTypeDesc,
               AllItemDescription,
               motorizeDesc,
               GeorgianBarHorizontalDesc,
               GeorgianBarVerticalDesc,
               NewNoneDuplicatePnlAndCount,
               lst_DescDist,
               glassThick;

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
                    _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel);
                    UserControl quoteItem = (UserControl)_quoteItemListUCPresenter.GetiQuoteItemListUC();
                    _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                    quoteItem.Dock = DockStyle.Top;
                    quoteItem.BringToFront();

                    itemDescription();
                    _mainPresenter.Run_GetListOfMaterials_SpecificItem();
                    _quotationModel.ItemCostingPriceAndPoints();

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

                    _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemNumber = "Item " + (i + 1);
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName = string.Empty;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemWindoorNumber = "WD-1A"; //location
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n"
                                                                              + wdm.WD_description
                                                                              + glass + GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc;

                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxTopView().Image = wdm.WD_SlidingTopViewImage;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemPrice.Value = Math.Round(_quotationModel.lstTotalPrice[i], 2);  //TotaPrice;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().GetLblPrice().Text = Math.Round(_quotationModel.lstTotalPrice[i], 2).ToString();  //TotaPrice.ToString();
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
                                      lstQuoteUC.GetiQuoteItemListUC().itemPrice.Value,
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

                    #region MultiPnl
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

                                //GlassThickness & Glassfilm
                                if (pnl.Panel_GlassThicknessDesc != null)
                                {
                                    if (pnl.Panel_GlassFilm.ToString() != "None")
                                    {
                                        lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + " with" + pnl.Panel_GlassFilm.ToString() + "\n");
                                    }
                                    else
                                    {
                                        lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + "\n");
                                    }
                                }
                                else
                                {
                                    lst_glassThickness.Add(string.Empty);
                                }

                                //GeorgianBar
                                if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                {
                                    GeorgianBarHorizontalQty += pnl.Panel_GeorgianBar_HorizontalQty;
                                    GeorgianBarVerticalQty += pnl.Panel_GeorgianBar_VerticalQty;
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
                    #endregion

                    #region SinglePnl 
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


                        //GlassThickness & Glassfilm
                        if (Singlepnl.Panel_GlassThicknessDesc != null)
                        {
                            if (Singlepnl.Panel_GlassFilm.ToString() != "None")
                            {
                                lst_glassThickness.Add("\n" + Singlepnl.Panel_GlassThicknessDesc + " with" + Singlepnl.Panel_GlassFilm.ToString() + "\n");
                            }
                            else
                            {
                                lst_glassThickness.Add("\n" + Singlepnl.Panel_GlassThicknessDesc + "\n");
                            }
                        }
                        else
                        {
                            lst_glassThickness.Add(string.Empty);
                        }


                        //GeorgianBar
                        if (Singlepnl.Panel_GeorgianBarOptionVisibility == true)
                        {
                            GeorgianBarHorizontalQty += Singlepnl.Panel_GeorgianBar_HorizontalQty;
                            GeorgianBarVerticalQty += Singlepnl.Panel_GeorgianBar_VerticalQty;

                        }

                    }
                    #endregion

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

                List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();

                if (lst_glassThicknessDistinct.Count != 0)
                {
                    for (int i = 0; i < lst_glassThicknessDistinct.Count; i++)
                    {
                        glassThick += lst_glassThicknessDistinct[i];
                    }
                    lst_glassThicknessPerItem.Add(glassThick);
                }
                glassThick = string.Empty;
                lst_glassThickness.Clear();
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
