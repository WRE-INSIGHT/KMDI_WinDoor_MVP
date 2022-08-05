﻿using ModelLayer.Model.Quotation;
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
        private IPrintGlassSummaryPresenter _printGlassSummaryPresenter;
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
               MaterialCostDesc,
               costingPointsDesc,
               laborCostDesc,
               FramePriceDesc,
               FrameReinPriceDesc,
               SashPriceDesc,
               SashReinPriceDesc,
               GlassDesc,
               DivPriceDesc,
               GBPriceDesc,
               CoverProfileCostDesc,
               GeorgianBarCostDesc,
               InstallationCostDesc,
               FittingAndSuppliesDesc,
               sealantDesc,
               PUFoamingDesc;

        decimal
        #region FrameAndSashPrice

                FramePricePerLinearMeter_7502 = 465.13m, //7502 = 465.13, 7507 = 507.99 
                FramePricePerLinearMeter_7507 = 507.99m,
                FrameReinPricePerLinearMeter_7502 = 123.55m, //7502 = 123.55, 7507 = 406.86   
                FrameReinPricePerLinearMeter_7507 = 406.86m,
                SashPricePerLinearMeter_7581 = 550.13m, //7581 = 550.13, 395 = 566.57, 373 = 712.66, 374= 801.83
                SashPricePerLinearMeter_373 = 712.66m,
                SashPricePerLinearMeter_374 = 801.83m,
                SashPricePerLinearMeter_395 = 556.57m,
                SashReinPricePerLinearMeter_7581 = 89.86m, //7581 = 89.86, 395 = 305.14, 373/374 = 835.18,
                SashReinPricePerLinearMeter_373And374 = 835.18m,
                SashReinPricePerLinearMeter_395 = 305.14m,
        #endregion 
        #region Mullion/TransomPrice
                Divider_7536_PricePerSqrMeter = 663.32m,
                Divider_7538_PricePerSqrMeter = 817.34m,
                DividerRein_7536_PricePerSqrMeter = 866.23m,
                DividerRein_7538_PricePerSqrMeter = 858.52m,
        #endregion
        #region DummyMullionPrice
                DummyMullionPricePerLinearMeter_7533 = 608.75m,
                DummyMullionPricePerLinearMeter_385 = 580.72m,
        #endregion
        #region GlassPrice

                Glass_6mmClr_PricePerSqrMeter = 670.00m,
                Glass_10mmClr_PricePerSqrMeter = 1662.00m,
                Glass_12mmClr_PricePerSqrMeter = 1941.00m,
                Glass_6mmTemp_PricePerSqrMeter = 1614.00m,
                Glass_10mmTemp_PricePerSqrMeter = 3201.00m,
                Glass_12mmTemp_PricePerSqrMeter = 3619.00m,
        #endregion
        #region FittingAndSupplies

                FS_16HD_casementPricePerPiece = 825.81m,
                FS_26HD_casementPricePerPiece = 1839.35m,

                RestrictorStayPricePerPiece = 161.18m,
                CornerDrivePricePerPiece = 150.11m, // standard top= 103.17, bot = 118.82
                SnapInKeepPricePerPiece = 67.79m,
                _35mmBacksetEspagWithCylinder = 1346.78m,
                MiddleCLoserPricePerPiece = 18.57m,

                StayBearingPricePerPiece = 41.44m,
                StayBearingPinPricePerPiece = 8.03m,
                CoverStayBearingPricePerPiece = 16.37m,
                CoverCornerHingePricePerPiece = 8.37m,
                CornerPivotRestPricePerPiece = 85.25m,
                TopCornerHingePricePerPiece = 158.48m,
                CorverCornerPivotRestPricePerPiece = 25.49m,
                CorverCornerPivotRestVerticalPricePerPiece = 8.87m,

                RotoswingHanldePricePerPiece = 257.93m,
                RioHandlePricePerPiece = 481.49m,

                Espag741012_PricePerPiece = 284.15m,
                LeverEspagPricePerPiece = 825.81m,
                TiltAndTurnEspag_N110A00006PricePerPiece = 254.39m,
                TiltAndTurnEspag_N110A01006PricePerPiece = 465.89m,
                TiltAndTurnEspag_N110A02206PricePerPiece = 518.40m,
                TiltAndTurnEspag_N110A03206PricePerPiece = 570.91m,
                TiltAndTurnEspag_N110A04206PricePerPiece = 623.42m,
                TiltAndTurnEspag_N110A05206PricePerPiece = 675.18m,
                TiltAndTurnEspag_N110A06206PricePerPiece = 727.69m,

                _2DHingePricePerPiece = 278.94m,
                _3DHingePricePerPiece = 990.95m,
                NTCenterHingePricePerPiece = 170.50m,

                ShootBoltStrikerPricePerPiece = 57.29m,
                ShootBoltReversePricePerPiece = 368.25m,
                ShootBoltNonReversePricePerPiece = 242.71m,

                StrikerPricePerPiece = 57.08m,
                StrikerForDMPricePerPiece = 62.27m,
                AdjustableStrikerPricePerPiece = 20.72m,
                LatchDeadboltStrikerPricePerPiece = 446.37m,

                MVDHandlePricePerPiece = 985.01m,
                MVDGearPricePerPiece = 1585.92m,

                Extension_639957PricePerPiece = 170.50m,
                Extension_567639PricePerPiece = 134.04m,
                Extension_299A01006PricePerPiece = 118.82m,
                MVDExtensionPricePerPiece = 183.80m,
        #endregion
        #region Accessories
                EndCapPricePerPiece = 282.96m,
                MechanicalJoint_AV585PricePerPiece = 87.34m,
                MechanicalJoint_9U18PricePerPiece = 138.45m,
                GBSpacerPricePerPiece = 5.01m,
                PlasticWedgePricePerPiece = 10.09m,
        #endregion
        #region AncillaryProfile
            GlazingBeadPricePerLinearMeter = 56.45m,
            GeorgianBar_0724Price = 154.93m,
            GeorgianBar_0726Price = 307.75m,
            CoverProfile_0914Price = 20.68m,
            CoverProfile_03734Price = 105.41m,
            ThresholdPrice = 1229.34m,
        #endregion
                SealantPricePerCan_BrownBlack = 430m,
                SealantPricePerCan_Clear = 170m,
                PUFoamingPricePerCan = 210m,
                FramePricePerLinearMeter,
                FrameReinPricePerLinearMeter,
                SashPricePerLinearMeter,
                SashReinPricePerLinearMeter,
                FramePrice,
                FrameReinPrice,
                SashPrice,
                SashReinPrice,
                DivPrice,
                DivReinPrice,
                MechJointPrice,
                DMPrice,
                EndCapPrice,
                RestrictorStayPrice,
                SnapInKeepPrice,
                _3DHingePrice,
                GbPrice,
                _35mmBacksetEspagWithCylinderPrice,
                EspagPrice,
                LeverEspagPrice,
                StayBearingPrice,
                StayBearingPinPrice,
                CornerDrivePrice,
                CoverStayBearingPrice,
                CoverCornerHingePrice,
                CornerPivotRestPrice,
                TopCornerHingePrice,
                CorverCornerPivotRestPrice,
                CorverCornerPivotRestVerticalPrice,
                MiddleCLoserPrice,
                NTCenterHingePrice,
                ShootBoltStrikerPrice,
                ShootBoltReversePrice,
                ShootBoltNonReversePrice,
                MVDHandlePrice,
                FramePerimeter,
                SashPerimeter,
                GlassPrice,
                FSPrice,
                _2DHingePrice,
                GeorgianBarCost,
                ThresholdCost,
                CoverProfileCost,
                SealantPrice,
                PUFoamingPrice,
                ProfileColorPoints = 13,
                CostingPoints = 0,
                InstallationPoints = 0,
                LaborCost = 0,
                InstallationCost = 0,
                MaterialCost = 0,
                FittingAndSuppliesCost,
                AccesorriesCost,
                AncillaryProfileCost,
                TotaPrice;
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
            dtQuoteNo
            dtItemNo
            dtQuantity
            dtSize
            dtArea
            dtReference
            dtLocation
            */
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {

                            }
                        }
                    }
                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                    {

                    }
                }
            }

            IPrintGlassSummaryPresenter printGlass = _printGlassSummaryPresenter.GetNewInstance(_unityC, this, _mainPresenter);
            printGlass.GetPrintGlassSummaryView().GetBindingSource().DataSource = _dsq.dtGlassSummary.DefaultView;
            printGlass.GetPrintGlassSummaryView().ShowGlassSummaryView();
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
                                                                          + MaterialCostDesc
                                                                          + FittingAndSuppliesDesc
                                                                          + FramePriceDesc
                                                                          + FrameReinPriceDesc
                                                                          + SashPriceDesc
                                                                          + SashReinPriceDesc
                                                                          + DivPriceDesc
                                                                          + GlassDesc
                                                                          + GBPriceDesc
                                                                          + sealantDesc
                                                                          + PUFoamingDesc;

                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxTopView().Image = wdm.WD_SlidingTopViewImage;
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
                                      (int)lstQuoteUC.GetiQuoteItemListUC().itemQuantity.Value,
                                      (int)lstQuoteUC.GetiQuoteItemListUC().itemPrice.Value,
                                      (int)lstQuoteUC.GetiQuoteItemListUC().itemDiscount.Value,
                                      Convert.ToDecimal(lstQuoteUC.GetiQuoteItemListUC().GetLblNetPrice().Text),
                                      i + 1,
                                      byteToStrForTopView);
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


                                //if (pnl.Panel_GlassFilm.ToString() != "None")
                                //{
                                //    lst_glassFilm.Add(pnl.Panel_GlassFilm.ToString());
                                //}

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


                        //GlassThickness & Glassfilm
                        if (Singlepnl.Panel_GlassThicknessDesc != null)
                        {
                            if (Singlepnl.Panel_GlassFilm.ToString() != "None")
                            {
                                lst_glassThickness.Add(Singlepnl.Panel_GlassThicknessDesc + " with" + Singlepnl.Panel_GlassFilm.ToString() + "\n");
                            }
                            else
                            {
                                lst_glassThickness.Add(Singlepnl.Panel_GlassThicknessDesc + "\n");
                            }
                        }

                        //Glassfilm
                        //if (Singlepnl.Panel_GlassFilm.ToString() != "None")
                        //{
                        //    lst_glassFilm.Add(Singlepnl.Panel_GlassFilm.ToString());
                        //}

                        //GeorgianBar
                        if (Singlepnl.Panel_GeorgianBarOptionVisibility == true)
                        {
                            GeorgianBarHorizontalQty += Singlepnl.Panel_GeorgianBar_HorizontalQty;
                            GeorgianBarVerticalQty += Singlepnl.Panel_GeorgianBar_VerticalQty;

                            //AllItemDescription += GeorgianBarHorizontalDesc;
                            //AllItemDescription += GeorgianBarVerticalDesc;
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

                    if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                    {
                        FramePricePerLinearMeter = FramePricePerLinearMeter_7502;
                        FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7502;
                    }
                    else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        FramePricePerLinearMeter = FramePricePerLinearMeter_7507;
                        FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7507;
                    }

                    FramePrice = (FramePerimeter / 1000) * FramePricePerLinearMeter;
                    FrameReinPrice = (FramePerimeter / 1000) * FrameReinPricePerLinearMeter;
                    #endregion

                    #region SealantPrice
                    if (wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White)
                    {
                        SealantPrice = _quotationModel.Frame_SealantWHQty_Total * SealantPricePerCan_Clear +
                                        _quotationModel.Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                    }
                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                    {
                        SealantPrice = _quotationModel.Frame_SealantWHQty_Total * SealantPricePerCan_BrownBlack +
                                       _quotationModel.Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                    }
                    #endregion

                    #region ThresholdPrice
                    if (fr.Frame_BotFrameEnable == true)
                    {
                        if (fr.Frame_BotFrameArtNo == BottomFrameTypes._7789)
                        {
                            ThresholdCost = (fr.Frame_Width / 1000) * ThresholdPrice;
                        }
                    }
                    #endregion

                    //PUFoamingPrice
                    PUFoamingPrice = _quotationModel.Frame_PUFoamingQty_Total * PUFoamingPricePerCan;

                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IDividerModel div in mpnl.MPanelLst_Divider)
                            {
                                CostingPoints -= 2;
                                InstallationPoints -= 2;

                                #region Transom/MullionAndMechJointPrice 
                                if (mpnl.MPanel_Type == "Transom")
                                {
                                    if (div.Div_ArtNo == Divider_ArticleNo._7536)
                                    {
                                        DivPrice += ((div.Div_Width) / 1000m) * Divider_7536_PricePerSqrMeter;
                                        DivReinPrice += ((div.Div_ReinfWidth) / 1000m) * DividerRein_7536_PricePerSqrMeter;
                                        MechJointPrice += MechanicalJoint_9U18PricePerPiece * 2;
                                    }
                                    else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                                    {
                                        DivPrice += (div.Div_Width / 1000m) * Divider_7538_PricePerSqrMeter;
                                        DivReinPrice += ((div.Div_ReinfWidth) / 1000m) * DividerRein_7538_PricePerSqrMeter;
                                        MechJointPrice += MechanicalJoint_AV585PricePerPiece * 2;
                                    }
                                }
                                else if (mpnl.MPanel_Type == "Mullion")
                                {
                                    if (div.Div_ArtNo == Divider_ArticleNo._7536)
                                    {
                                        DivPrice += (div.Div_Height / 1000m) * Divider_7536_PricePerSqrMeter;
                                        DivReinPrice += ((div.Div_ReinfHeight) / 1000m) * DividerRein_7536_PricePerSqrMeter;
                                        MechJointPrice += MechanicalJoint_9U18PricePerPiece * 2;
                                    }

                                    else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                                    {
                                        DivPrice += (div.Div_Height / 1000m) * Divider_7538_PricePerSqrMeter;
                                        DivReinPrice += ((div.Div_ReinfHeight) / 1000m) * DividerRein_7538_PricePerSqrMeter;
                                        MechJointPrice += MechanicalJoint_AV585PricePerPiece * 2;
                                    }
                                }
                                #endregion

                                #region DM_Endcap_SBoltStriker_Price
                                if (div.Div_ChkDMVisibility == true)
                                {
                                    if (div.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                    {
                                        DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter_7533;
                                    }
                                    else if (div.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                                    {
                                        DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter_385;

                                        ShootBoltStrikerPrice += ShootBoltStrikerPricePerPiece;
                                        ShootBoltReversePrice += ShootBoltReversePricePerPiece;
                                        ShootBoltNonReversePrice += ShootBoltNonReversePricePerPiece * 3;
                                    }

                                    EndCapPrice += EndCapPricePerPiece * 2;
                                }
                                #endregion

                                #region LeverEspagPrice
                                if (div.Div_LeverEspagVisibility == true)
                                {
                                    LeverEspagPrice += LeverEspagPricePerPiece;
                                }
                                #endregion

                            }
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                if (pnl.Panel_SashPropertyVisibility == true)
                                {
                                    if (pnl.Panel_Type.Contains("Casement"))
                                    {
                                        if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                        {
                                            if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                            {
                                                _2DHingePrice += _2DHingePricePerPiece * pnl.Panel_2DHingeQty_nonMotorized;
                                            }
                                            else if (pnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                            {
                                                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                            }
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 || pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                        {
                                            if (pnl.Panel_HandleOptionsVisibility == true)
                                            {
                                                if (pnl.Panel_HandleType == Handle_Type._MVD)
                                                {
                                                    MVDHandlePrice += MVDHandlePricePerPiece;
                                                }
                                            }


                                            RestrictorStayPrice += RestrictorStayPricePerPiece * 2;

                                            _35mmBacksetEspagWithCylinderPrice += _35mmBacksetEspagWithCylinder;

                                            _3DHingePrice += _3DHingePricePerPiece * pnl.Panel_3dHingeQty;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                        {
                                            if (pnl.Panel_CenterHingeOptionsVisibility == true)
                                            {
                                                if (pnl.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                                {
                                                    NTCenterHingePrice += NTCenterHingePricePerPiece;
                                                }
                                                else if (pnl.Panel_CenterHingeOptions == CenterHingeOption._MiddleCloser)
                                                {
                                                    MiddleCLoserPrice += MiddleCLoserPricePerPiece;
                                                }
                                            }

                                            StayBearingPrice += StayBearingPricePerPiece * 2;
                                            StayBearingPinPrice += StayBearingPinPricePerPiece * 2;
                                            TopCornerHingePrice += TopCornerHingePricePerPiece;
                                            CornerPivotRestPrice += CornerPivotRestPricePerPiece;
                                            CoverStayBearingPrice += CoverStayBearingPricePerPiece;
                                            CoverCornerHingePrice += CoverCornerHingePricePerPiece;
                                            CorverCornerPivotRestPrice += CorverCornerPivotRestPricePerPiece;
                                            CorverCornerPivotRestVerticalPrice += CorverCornerPivotRestVerticalPricePerPiece;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                        {
                                            SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                        }

                                        if (pnl.Panel_CornerDriveOptionsVisibility == true)
                                        {
                                            CornerDrivePrice += CornerDrivePricePerPiece * 2;
                                        }
                                    }
                                    else if (pnl.Panel_Type.Contains("Awning"))
                                    {
                                        #region FSPrice
                                        if (pnl.Panel_SashHeight >= 800)
                                        {
                                            FSPrice += FS_26HD_casementPricePerPiece;
                                        }
                                        else
                                        {
                                            FSPrice += FS_16HD_casementPricePerPiece;
                                        }
                                        #endregion
                                    }

                                    #region SashPrice 
                                    SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                    if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_7581;
                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_374;
                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_373;
                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_395;
                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                    }

                                    SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                    SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                    GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                    #endregion

                                    #region EspagPrice

                                    if (pnl.Panel_EspagnoletteOptionsVisibility == true)
                                    {
                                        if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A00006PricePerPiece;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A01006PricePerPiece;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A02206PricePerPiece;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A03206PricePerPiece;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A04206PricePerPiece;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A05206PricePerPiece;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                                        {
                                            EspagPrice += TiltAndTurnEspag_N110A06206PricePerPiece;
                                        }
                                        else
                                        {
                                            EspagPrice += Espag741012_PricePerPiece;
                                        }
                                    }
                                    #endregion

                                    #region GeorgianBar
                                    if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                    {
                                        if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                        {
                                            if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += ((pnl.Panel_SashWidth / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price;
                                            }
                                            if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += ((pnl.Panel_SashHeight / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price;
                                            }
                                        }
                                        else if (pnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                        {
                                            if (pnl.Panel_GeorgianBar_HorizontalQty != 0)
                                            {
                                                GeorgianBarCost += ((pnl.Panel_SashWidth / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price;
                                            }
                                            if (pnl.Panel_GeorgianBar_VerticalQty != 0)
                                            {
                                                GeorgianBarCost += ((pnl.Panel_SashHeight / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price;
                                            }
                                        }
                                    }
                                    #endregion

                                    #region CoverProfilePrice
                                    CoverProfileCost += (pnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price +
                                                        (pnl.Panel_SashWidth / 1000m) * CoverProfile_03734Price;
                                    #endregion

                                }
                                if (pnl.Panel_ChkText == "dsash")
                                {
                                    #region SashPrice 
                                    SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                    SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter_7581;
                                    SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter_7581;
                                    GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                    #endregion 
                                }

                                #region Glass 

                                if (pnl.Panel_GlassThickness >= 6.0f &&
                                    pnl.Panel_GlassThickness <= 9.0f)
                                {
                                    if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                    {
                                        GlassPrice += ((pnl.Panel_SashHeight / 1000m) * (pnl.Panel_SashWidth / 1000)) * Glass_6mmTemp_PricePerSqrMeter;
                                    }
                                    else
                                    {
                                        GlassPrice += ((pnl.Panel_SashHeight / 1000m) * (pnl.Panel_SashWidth / 1000)) * Glass_6mmClr_PricePerSqrMeter;
                                    }
                                }
                                else if (pnl.Panel_GlassThickness == 10.0f ||
                                 pnl.Panel_GlassThickness == 11.0f)
                                {
                                    if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                    {
                                        GlassPrice += ((pnl.Panel_SashHeight / 1000m) * (pnl.Panel_SashWidth / 1000)) * Glass_10mmTemp_PricePerSqrMeter;
                                    }
                                    else
                                    {
                                        GlassPrice += ((pnl.Panel_SashHeight / 1000m) * (pnl.Panel_SashWidth / 1000)) * Glass_10mmClr_PricePerSqrMeter;
                                    }
                                }
                                else if (pnl.Panel_GlassThickness >= 12.0f)
                                {
                                    if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                    {
                                        GlassPrice += ((pnl.Panel_SashHeight / 1000m) * (pnl.Panel_SashWidth / 1000)) * Glass_12mmTemp_PricePerSqrMeter;
                                    }
                                    else
                                    {
                                        GlassPrice += ((pnl.Panel_SashHeight / 1000m) * (pnl.Panel_SashWidth / 1000)) * Glass_12mmClr_PricePerSqrMeter;
                                    }
                                }
                                #endregion

                                CostingPoints += ProfileColorPoints * 4;
                                InstallationPoints += (ProfileColorPoints / 3) * 4;

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

                            if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                SashPricePerLinearMeter = SashPricePerLinearMeter_7581;
                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                            {
                                SashPricePerLinearMeter = SashPricePerLinearMeter_374;
                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                            {
                                SashPricePerLinearMeter = SashPricePerLinearMeter_373;
                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                SashPricePerLinearMeter = SashPricePerLinearMeter_395;
                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                            }

                            SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                            SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                            GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                            #endregion

                            #region FrictionStayPrice
                            if (Singlepnl.Panel_Type.Contains("Casement"))
                            {
                                #region FSPrice
                                FSPrice += FS_16HD_casementPricePerPiece;
                                #endregion
                            }
                            else if (Singlepnl.Panel_Type.Contains("Awning"))
                            {
                                #region FSPrice
                                if (Singlepnl.Panel_SashHeight >= 800)
                                {
                                    FSPrice += FS_26HD_casementPricePerPiece;
                                }
                                else
                                {
                                    FSPrice += FS_16HD_casementPricePerPiece;
                                }
                                #endregion
                            }
                            #endregion 
                        }

                        if (Singlepnl.Panel_ChkText == "dsash")
                        {
                            #region SashPrice 
                            SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                            SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter_7581;
                            SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter_7581;
                            GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                            #endregion 
                        }

                        #region Glass 

                        if (Singlepnl.Panel_GlassThickness >= 6.0f &&
                            Singlepnl.Panel_GlassThickness <= 9.0f)
                        {
                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                            {
                                GlassPrice += ((Singlepnl.Panel_SashHeight / 1000m) * (Singlepnl.Panel_SashWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                            }
                            else
                            {
                                GlassPrice += ((Singlepnl.Panel_SashHeight / 1000m) * (Singlepnl.Panel_SashWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                            }
                        }
                        else if (Singlepnl.Panel_GlassThickness == 10.0f ||
                         Singlepnl.Panel_GlassThickness == 11.0f)
                        {
                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                            {
                                GlassPrice += ((Singlepnl.Panel_SashHeight / 1000m) * (Singlepnl.Panel_SashWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                            }
                            else
                            {
                                GlassPrice += ((Singlepnl.Panel_SashHeight / 1000m) * (Singlepnl.Panel_SashWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                            }
                        }
                        else if (Singlepnl.Panel_GlassThickness >= 12.0f)
                        {
                            if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                            {
                                GlassPrice += ((Singlepnl.Panel_SashHeight / 1000m) * (Singlepnl.Panel_SashWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                            }
                            else
                            {
                                GlassPrice += ((Singlepnl.Panel_SashHeight / 1000m) * (Singlepnl.Panel_SashWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                            }
                        }
                        #endregion

                        CostingPoints += ProfileColorPoints * 4;
                        InstallationPoints += (ProfileColorPoints / 3) * 4;
                    }
                }



                LaborCost = CostingPoints * CostPerPoints;
                InstallationCost = InstallationPoints * CostPerPoints;
                FittingAndSuppliesCost = FSPrice;

                AncillaryProfileCost = Math.Round(ThresholdPrice, 2) +
                                       Math.Round(GbPrice, 2) +
                                       Math.Round(GeorgianBarCost, 2) +
                                       Math.Round(CoverProfileCost, 2);

                AccesorriesCost = Math.Round(EndCapPrice, 2) +
                                  Math.Round(MechJointPrice, 2);
                ;

                MaterialCost = Math.Round(FramePrice, 2) +
                               Math.Round(FrameReinPrice, 2) +
                               Math.Round(SashPrice, 2) +
                               Math.Round(SashReinPrice, 2) +
                               Math.Round(DivPrice, 2) +
                               Math.Round(DMPrice, 2) +
                               Math.Round(SealantPrice, 2) +
                               Math.Round(PUFoamingPrice, 2) +
                               Math.Round(FittingAndSuppliesCost, 2) +
                               Math.Round(AncillaryProfileCost, 2) +
                               Math.Round(AccesorriesCost, 2);

                MaterialCost = MaterialCost +
                               (MaterialCost * 0.05m) +
                               (MaterialCost * 0.10m) +
                               (MaterialCost * 0.12m) +
                               (MaterialCost * 0.16m);

                TotaPrice = Math.Round(LaborCost, 2) +
                            Math.Round(InstallationCost, 2) +
                            Math.Round(MaterialCost, 2) +
                            Math.Round(GlassPrice, 2);

                TotaPrice = (TotaPrice * 1.3m) + TotaPrice; // factor 1.3 

                lstTotalPrice.Add(TotaPrice);



                costingPointsDesc = "\n\nTotal Points: " + Math.Round(CostingPoints, 2);

                InstallationCostDesc = "\n\nInstallation Cost: " + Math.Round(InstallationCost, 2);
                laborCostDesc = "\n\nLabor Cost: " + Math.Round(LaborCost, 2);
                MaterialCostDesc = "\n\nMaterial Cost : " + Math.Round(MaterialCost, 2);

                FramePriceDesc = "\n\nFrame Price per linear meter: " + Math.Round(FramePrice, 2);
                FrameReinPriceDesc = "\n\nFrame Rein Price per linear meter: " + Math.Round(FrameReinPrice, 2);
                SashPriceDesc = "\n\nSash Price per linear meter: " + Math.Round(SashPrice, 2);
                SashReinPriceDesc = "\n\nSash Rein Price per linear meter: " + Math.Round(SashReinPrice, 2);
                GlassDesc = "\n\nGlass Price: " + Math.Round(GlassPrice, 2);
                DivPriceDesc = "\n\nDivider Price: " + Math.Round(DivPrice, 2);
                GBPriceDesc = "\n\nGB Price per linear meter: " + Math.Round(GbPrice, 2);
                FittingAndSuppliesDesc = "\n\nFittingAndSupplies Cost: " + Math.Round(FittingAndSuppliesCost, 2);
                sealantDesc = "\n\nSealant Cost : " + Math.Round(SealantPrice, 2);
                PUFoamingDesc = "\n\nPUFoaming Cost : " + Math.Round(PUFoamingPrice, 2);


                CostingPoints = 0;

                InstallationPoints = 0;
                TotaPrice = 0;
                LaborCost = 0;
                InstallationCost = 0;
                MaterialCost = 0;

                FramePrice = 0;
                FrameReinPrice = 0;
                SashPrice = 0;
                SashReinPrice = 0;
                GbPrice = 0;
                FittingAndSuppliesCost = 0;
                GlassPrice = 0;
                SealantPrice = 0;
                PUFoamingPrice = 0;
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
