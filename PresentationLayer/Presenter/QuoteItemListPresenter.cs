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
        private List<decimal> lstTotalPrice = new List<decimal>();


        int GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0,
            CostPerPoints = 60,
            Frame_SealantWHQty_Total = 0,
            Glass_SealantWHQty_Total = 0;

        bool ChckDM = false,
             ChckPlasticWedge = false,
             check1stFrame = false;


        string glass,
               FrameTypeDesc,
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
               AncillaryProfileCostDesc,
               AccesorriesCostDesc,
               sealantDesc,
               PUFoamingDesc;

        decimal
        #region FrameAndSashPrice

                FramePricePerLinearMeter_7502_WoodGrain = 465.13m,
                FramePricePerLinearMeter_7502_White = 332.57m,
                FramePricePerLinearMeter_7507_WoodGrain = 507.99m,
                FramePricePerLinearMeter_7507_White = 354.28m,
                FramePricePerLinearMeter_2060_White = 271.35m,//G58
                FramePricePerLinearMeter_6050_WoodGrain = 483.36m,
                FramePricePerLinearMeter_6050_White = 378.19m,
                FramePricePerLinearMeter_6052_WoodGrain = 704.60m,
                FramePricePerLinearMeter_6052_White = 563.48m,
                FrameReinPricePerLinearMeter_7502 = 123.55m,
                FrameReinPricePerLinearMeter_7507 = 406.86m,
                G58ReinPricePerLinearMeter_V226 = 140.69m,//G58 reinforcement for frame, sash and divider
                FrameReinPricePerLinearMeter_6050 = 114.76m,
                FrameReinPricePerLinearMeter_6052 = 194.68m,

                SashPricePerLinearMeter_7581_WoodGrain = 550.13m,
                SashPricePerLinearMeter_7581_White = 375.30m,
                SashPricePerLinearMeter_373_WoodGrain = 712.66m,
                SashPricePerLinearMeter_373_White = 511.72m,
                SashPricePerLinearMeter_374_WoodGrain = 801.83m,
                SashPricePerLinearMeter_374_White = 511.72m,
                SashPricePerLinearMeter_395_WoodGrain = 556.57m,
                SashPricePerLinearMeter_395_White = 412.47m,
                SashPricePerLinearMeter_2067_White = 303.50m,
                SashPricePerLinearMeter_6040_WoodGrain = 500,// 550.13m,
                SashPricePerLinearMeter_6040_White = 325, //373.94m,
                SashPricePerLinearMeter_6041_WoodGrain = 683.91m,
                SashPricePerLinearMeter_6041_White = 483.13m,
                SashReinPricePerLinearMeter_7581 = 89.86m,
                SashReinPricePerLinearMeter_373And374 = 835.18m,
                SashReinPricePerLinearMeter_395 = 305.14m,
                SashReinPricePerLinearMeter_6040 = 287.58m,
                SashReinPricePerLinearMeter_6041 = 655.49m,
        #endregion 
        #region Mullion/TransomPrice

                Divider_7536_PricePerSqrMeter = 663.32m,
                Divider_7538_PricePerSqrMeter = 817.34m,
                Divider_2069_PricePerSqrMeter = 284.12m, // G58
                DividerRein_7536_PricePerSqrMeter = 866.23m,
                DividerRein_7538_PricePerSqrMeter = 858.52m,
        #endregion
        #region DummyMullionPrice

                DummyMullionPricePerLinearMeter_7533_WoodGrain = 608.75m,
                DummyMullionPricePerLinearMeter_385_WoodGrain = 580.72m,
                DummyMullionPricePerLinearMeter_7533_White = 608.75m,
                DummyMullionPricePerLinearMeter_385_White = 580.72m,

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
                RotoswingHanldeForSlidingPricePerPiece = 1123.91m,
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
                StrikerLRPricePerPiece = 52.01m,//sliding
                StrikerForDMPricePerPiece = 62.27m,
                AdjustableStrikerPricePerPiece = 20.72m,
                LatchDeadboltStrikerPricePerPiece = 446.37m,

                MVDHandlePricePerPiece = 985.01m,
                MVDGearPricePerPiece = 1585.92m,

                Extension_639957PricePerPiece = 170.50m,
                Extension_567639PricePerPiece = 134.04m,
                //Extension_N299A01006PricePerPiece = 118.82m,
                MVDExtensionPricePerPiece = 183.80m,

                HDRollerPricePerPiece = 566.06m,
                GURollerPricePerPiece = 1323.08m,
        #endregion
        #region Accessories

        EndCapPricePerPiece = 282.96m,
                MechanicalJoint_AV585PricePerPiece = 87.34m,
                MechanicalJoint_9U18PricePerPiece = 138.45m,
                GBSpacerPricePerPiece = 5.01m,
                PlasticWedgePricePerPiece = 10.09m,
                BarFastenerPricePerPiece = 4.40m,
                SealingBlockPricePerPiece = 63.75m,
                SpacerFixSashPricePerPiece = 21.42m,
        #endregion
        #region AncillaryProfile
        GlazingGasketPricePerLinearMeter = 32.64m,
            GlazingBeadPricePerLinearMeter = 56.45m,
            GlazingBead_G58PricePerLinearMeter = 117.72m,
            GeorgianBar_0724Price = 154.93m,
            GeorgianBar_0726Price = 307.75m,
            CoverProfile_0914Price = 20.68m,
            CoverProfile_0373Price = 105.41m,
            ThresholdPricePerPiece = 1229.34m,
            WeatherBarPricePerPiece = 236.75m,
            GuideTrackPricePerLinearMeter = 157.18m,
            InterlockPricePerPiece = 333.77m,
            ExtensionForInterlockPricePerPiece = 789.01m,
            AluminumTrackPricePerLinearMeter = 251.10m,
            WaterSeepagePricePerLinearMeter = 153.73m,

        #endregion
                BrushSealPricePerLinearMeter = 15.80m,
                SealantPricePerCan_BrownBlack = 430m,
                SealantPricePerCan_Clear = 170m,
                PUFoamingPricePerCan = 210m,
                FramePricePerLinearMeter,
                FrameReinPricePerLinearMeter,
                SashPricePerLinearMeter,
                SashReinPricePerLinearMeter,
                FramePrice,
                FrameReinPrice,
                SashPrice = 0,
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
                LatchDeadboltStrikerPrice,
                StrikerPrice,
                StrikerLRPrice,
                ShootBoltStrikerPrice,
                ShootBoltReversePrice,
                ShootBoltNonReversePrice,
                BrushSealPrice,
                RollerPrice,
                WeatherBarPrice,
                WeatherBarFastenerPrice,
                GuideTrackPrice,
                InterlockPrice,
                ExtensionForInterlockPrice,
                AlumTrackPrice,
                WaterSeepagePrice,
                SealingBlockPrice,
                SpacerFixSashPrice,
                HandlePrice,
                FramePerimeter,
                SashPerimeter,
                GlassPrice,
                FSPrice,
                _2DHingePrice,
                GeorgianBarCost,
                ExtensionPrice,
                ThresholdPrice,
                CoverProfileCost,
                GBSpacerPrice,
                GlazingGasketPrice,
                PlasticWedgePrice,
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


                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel);
                    UserControl quoteItem = (UserControl)_quoteItemListUCPresenter.GetiQuoteItemListUC();
                    _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                    quoteItem.Dock = DockStyle.Top;
                    quoteItem.BringToFront();

                    itemDescription();
                    ItemCostingPoints();

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
                    //else
                    //{
                    //    glass = string.Empty;
                    //}
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName = wdm.WD_name;
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemWindoorNumber = "WD-1A"; //location
                    _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n"
                                                                              + wdm.WD_description
                                                                              + glass + GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc
                                                                              + costingPointsDesc
                                                                              + laborCostDesc
                                                                              + InstallationCostDesc
                                                                              + GlassDesc
                                                                              + MaterialCostDesc
                                                                              + FramePriceDesc
                                                                              + FrameReinPriceDesc
                                                                              + SashPriceDesc
                                                                              + SashReinPriceDesc
                                                                              + DivPriceDesc
                                                                              + FittingAndSuppliesDesc
                                                                              + AncillaryProfileCostDesc
                                                                              + AccesorriesCostDesc
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

        public void ItemCostingPoints()

        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    #region baseOnDimensionAndColorPointsif
                    if (wdm.WD_profile.Contains("C70"))
                    {
                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                        {
                            if (fr.Frame_Width >= 2000)
                            {
                                ProfileColorPoints = 16;
                            }
                            else if (fr.Frame_Height >= 2000)
                            {
                                ProfileColorPoints = 16;
                            }
                            else if (fr.Frame_Width >= 3000)
                            {
                                ProfileColorPoints = 18;
                            }
                            else if (fr.Frame_Height >= 3000)
                            {
                                ProfileColorPoints = 18;
                            }

                            CostingPoints += ProfileColorPoints * 4;
                            InstallationPoints += (ProfileColorPoints / 3) * 4;
                        }
                        else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                        {
                            ProfileColorPoints = 14;
                            if (fr.Frame_Width >= 2000)
                            {
                                ProfileColorPoints = 18;
                            }
                            else if (fr.Frame_Height >= 2000)
                            {
                                ProfileColorPoints = 18;
                            }
                            else if (fr.Frame_Width >= 3000)
                            {
                                ProfileColorPoints = 19;
                            }
                            else if (fr.Frame_Height >= 3000)
                            {
                                ProfileColorPoints = 19;
                            }
                        }
                    }
                    else if (wdm.WD_profile.Contains("PremiLine"))
                    {
                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                        {
                            ProfileColorPoints = 28;
                        }
                        else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                        {
                            ProfileColorPoints = 30;
                        }
                    }

                    CostingPoints += ProfileColorPoints * 4;
                    InstallationPoints += (ProfileColorPoints / 3) * 4;

                    #endregion

                    #region FramePrice
                    FramePerimeter = (fr.Frame_Height + fr.Frame_Width) * 2;

                    if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                    {
                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_7502_White;
                        }
                        else
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_7502_WoodGrain;
                        }
                        FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7502;
                    }
                    else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_7507_White;
                        }
                        else
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_7507_WoodGrain;
                        }
                        FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_7507;
                    }
                    else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                    {

                        FramePricePerLinearMeter = FramePricePerLinearMeter_2060_White;
                        FrameReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;
                        GlazingGasketPrice += (FramePerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                    }
                    else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                    {
                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_6050_White;
                        }
                        else
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_6050_WoodGrain;
                        }
                        FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6050;
                    }
                    else if (fr.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                    {
                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_6052_White;
                        }
                        else
                        {
                            FramePricePerLinearMeter = FramePricePerLinearMeter_6052_WoodGrain;
                        }
                        FrameReinPricePerLinearMeter = FrameReinPricePerLinearMeter_6052;
                    }

                    FramePrice += (FramePerimeter / 1000) * FramePricePerLinearMeter;
                    FrameReinPrice += (FramePerimeter / 1000) * FrameReinPricePerLinearMeter;
                    #endregion

                    #region SealantPrice


                    Frame_SealantWHQty_Total = (int)Math.Ceiling((decimal)((fr.Frame_Width * 2) + (fr.Frame_Height)) / 3570);

                    if (wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White)
                    {
                        SealantPrice += Frame_SealantWHQty_Total * SealantPricePerCan_Clear;
                    }
                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                    {
                        SealantPrice += Frame_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                    }
                    #endregion

                    #region ThresholdPrice
                    if (fr.Frame_BotFrameEnable == true)
                    {
                        if (fr.Frame_BotFrameArtNo == BottomFrameTypes._7789)
                        {
                            ThresholdPrice += (fr.Frame_Width / 1000) * ThresholdPricePerPiece;
                        }
                    }
                    #endregion

                    if (fr.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                    {
                        ChckPlasticWedge = true;
                    }
                    else
                    {
                        ChckPlasticWedge = false;
                    }

                    PUFoamingPrice += _quotationModel.Frame_PUFoamingQty_Total * PUFoamingPricePerCan;

                    #region MultiPnl 
                    if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)//multi pnl
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                        {
                            foreach (IDividerModel div in mpnl.MPanelLst_Divider)
                            {
                                CostingPoints -= 2;
                                InstallationPoints -= 2;

                                #region Transom/MullionAndMechJointPrice 
                                if (mpnl.MPanel_DividerEnabled == true)
                                {
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
                                        else if (div.Div_ArtNo == Divider_ArticleNo._2069)
                                        {
                                            DivPrice += (div.Div_Width / 1000m) * Divider_2069_PricePerSqrMeter;
                                            DivReinPrice += ((div.Div_ReinfWidth) / 1000m) * G58ReinPricePerLinearMeter_V226;
                                            MechJointPrice += MechanicalJoint_9U18PricePerPiece * 2; // for the meantime
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
                                        else if (div.Div_ArtNo == Divider_ArticleNo._2069)
                                        {
                                            DivPrice += (div.Div_Height / 1000m) * Divider_2069_PricePerSqrMeter;
                                            DivReinPrice += ((div.Div_ReinfHeight) / 1000m) * G58ReinPricePerLinearMeter_V226;
                                            MechJointPrice += MechanicalJoint_9U18PricePerPiece * 2; // for the meantime
                                        }
                                    }
                                }

                                #endregion

                                #region DM_Endcap_SBoltStriker_Price
                                if (div.Div_ChkDMVisibility == true)
                                {
                                    if (div.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter_7533_White;
                                        }
                                        else
                                        {
                                            DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter_7533_WoodGrain;
                                        }
                                    }
                                    else if (div.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter_385_White;
                                        }
                                        else
                                        {
                                            DMPrice += (div.Div_Height / 1000m) * DummyMullionPricePerLinearMeter_385_WoodGrain;
                                        }

                                        ShootBoltStrikerPrice += ShootBoltStrikerPricePerPiece;
                                        ShootBoltReversePrice += ShootBoltReversePricePerPiece;
                                        ShootBoltNonReversePrice += ShootBoltNonReversePricePerPiece * 3;
                                    }
                                    ChckDM = true;
                                    EndCapPrice += EndCapPricePerPiece * 2;
                                }
                                else
                                {
                                    ChckDM = false;
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
                                        if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                        {
                                            MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;

                                            if (pnl.Panel_HingeOptions == HingeOption._2DHinge)
                                            {
                                                _2DHingePrice += _2DHingePricePerPiece * pnl.Panel_2DHingeQty_nonMotorized;
                                            }
                                            else if (pnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                            {
                                                FSPrice += FS_16HD_casementPricePerPiece * 2;
                                            }

                                            if (pnl.Panel_ExtensionOptionsVisibility == true &&
                                                pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                                 pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                                 pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                                 pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                            {
                                                if (pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                    pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                    pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                    pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                                {
                                                    ExtensionPrice += Extension_639957PricePerPiece;
                                                }
                                            }

                                            if (pnl.Panel_HandleOptionsVisibility == true)
                                            {
                                                if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                                {
                                                    HandlePrice += RotoswingHanldePricePerPiece;
                                                }
                                                else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                                                {
                                                    //wlang price ng rotaty 
                                                }
                                            }

                                            else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 || pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                            {
                                                #region Handle
                                                if (pnl.Panel_HandleOptionsVisibility == true)
                                                {
                                                    if (pnl.Panel_HandleType == Handle_Type._MVD)
                                                    {
                                                        HandlePrice += MVDHandlePricePerPiece;

                                                        LatchDeadboltStrikerPrice += LatchDeadboltStrikerPricePerPiece;
                                                    }
                                                    else if (pnl.Panel_HandleType == Handle_Type._Rio)
                                                    {
                                                        HandlePrice += RioHandlePricePerPiece;
                                                    }
                                                    else if (pnl.Panel_HandleType == Handle_Type._Rotoline)
                                                    {
                                                        //wlang presyo ng rotoline
                                                    }
                                                }
                                                #endregion

                                                #region ExtensionPrice

                                                if (pnl.Panel_ExtensionOptionsVisibility == true &&
                                                    pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                                    pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                                    pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                                    pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                                {
                                                    if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                                                        pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956)
                                                    {
                                                        ExtensionPrice += MVDExtensionPricePerPiece;
                                                    }
                                                    else if (pnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                             pnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                             pnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                             pnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                                    {
                                                        ExtensionPrice += Extension_567639PricePerPiece;
                                                    }
                                                }
                                                #endregion

                                                if (ChckDM == true)
                                                {
                                                    StrikerPrice += AdjustableStrikerPricePerPiece * pnl.Panel_AdjStrikerQty;
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
                                                        MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;
                                                    }
                                                }

                                                if (pnl.Panel_HandleOptionsVisibility == true)
                                                {
                                                    if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                                    {
                                                        HandlePrice += RotoswingHanldePricePerPiece;
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

                                        MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;

                                        if (pnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                HandlePrice += RotoswingHanldePricePerPiece;
                                            }
                                            else if (pnl.Panel_HandleType == Handle_Type._Rotary)
                                            {
                                                //wlang price ng rotaty 
                                            }
                                        }
                                    }
                                    else if (pnl.Panel_Type.Contains("Sliding"))
                                    {
                                        #region handle
                                        if (pnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (pnl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                HandlePrice += RotoswingHanldePricePerPiece;
                                            }
                                            else if (pnl.Panel_HandleType == Handle_Type._RotoswingForSliding)
                                            {
                                                HandlePrice += RotoswingHanldeForSlidingPricePerPiece;
                                            }
                                            else if (pnl.Panel_HandleType == Handle_Type._Rio)
                                            {
                                                HandlePrice += RioHandlePricePerPiece;
                                            }
                                        }
                                        #endregion


                                        BrushSealPrice = ((pnl.Panel_Height / 1000m) * 2 * 2) * BrushSealPricePerLinearMeter; // 2qty 2perimeter

                                        if (pnl.Panel_RollersTypes == RollersTypes._TandemRoller ||
                                            pnl.Panel_RollersTypes == RollersTypes._HDRoller)
                                        {
                                            RollerPrice += 2 * HDRollerPricePerPiece;
                                        }
                                        else if (pnl.Panel_RollersTypes == RollersTypes._GURoller)
                                        {
                                            RollerPrice += 2 * GURollerPricePerPiece;
                                        }

                                        if (pnl.Panel_HandleType != Handle_Type._None)
                                        {
                                            StrikerLRPrice += 1 * StrikerLRPricePerPiece;
                                        }

                                        WeatherBarPrice += ((fr.Frame_Width / 1000m) * 2) * WeatherBarPricePerPiece;
                                        WeatherBarFastenerPrice += (fr.Frame_Width / 300) * WeatherBarFastenerPrice;
                                        WaterSeepagePrice += (fr.Frame_Width / 1000) * WaterSeepagePricePerLinearMeter;
                                        GuideTrackPrice += ((GuideTrackPricePerLinearMeter / 1000m) * 2) * pnl.Panel_AluminumTrackQty;
                                        AlumTrackPrice += ((AluminumTrackPricePerLinearMeter / 1000m) * 2) * pnl.Panel_AluminumTrackQty;

                                        if (pnl.Panel_Overlap_Sash == OverlapSash._Left ||
                                            pnl.Panel_Overlap_Sash == OverlapSash._Right)
                                        {
                                            InterlockPrice += 2 * InterlockPricePerPiece;
                                            ExtensionForInterlockPrice += 2 * ExtensionForInterlockPricePerPiece;
                                            SealingBlockPrice += 2 * SealingBlockPricePerPiece;
                                        }

                                    }

                                    if (pnl.Panel_ChkText == "dSash" && pnl.Panel_Type.Contains("Fixed"))
                                    {
                                        #region SashPrice 
                                        SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                        if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                        {
                                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                            }
                                            else
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                            }

                                            SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                        {
                                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                            }
                                            else
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                            }

                                            SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                        {
                                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                            }
                                            else
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                            }

                                            SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                        {
                                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                            }
                                            else
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                            }

                                            SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                            SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                            GlazingGasketPrice += (SashPerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                        {
                                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                            }
                                            else
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                            }

                                            SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                        }
                                        else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                        {
                                            if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                            }
                                            else
                                            {
                                                SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                            }

                                            SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                        }



                                        SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                        SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                        GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                        #endregion

                                        MiddleCLoserPrice += MiddleCLoserPricePerPiece * pnl.Panel_MiddleCloserPairQty;
                                        SpacerFixSashPrice += 2 * SpacerFixSashPricePerPiece;
                                    }

                                    if (pnl.Panel_GlassThickness == 6.0f)
                                    {
                                        GBSpacerPrice += GBSpacerPricePerPiece * 4;
                                    }

                                    if (ChckPlasticWedge == true)
                                    {
                                        PlasticWedgePrice += PlasticWedgePricePerPiece;
                                    }

                                    #region SashPrice 
                                    SashPerimeter = (pnl.Panel_SashHeight + pnl.Panel_SashWidth) * 2;

                                    if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                        SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                        GlazingGasketPrice += (SashPerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                    }
                                    else if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                    {
                                        if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                        }
                                        else
                                        {
                                            SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                        }

                                        SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                    }


                                    SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                    SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;

                                    //if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                    //{
                                    //    GbPrice += (SashPerimeter / 1000m) * GlazingBead_G58PricePerLinearMeter;
                                    //}
                                    //else
                                    //{
                                    //    GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                    //}

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
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                        {
                                            EspagPrice += MVDGearPricePerPiece;
                                        }
                                        else
                                        {
                                            EspagPrice += Espag741012_PricePerPiece;
                                        }
                                    }
                                    #endregion

                                    #region StrikerPrice
                                    int Panel_StrikerQty_A = 0,
                                        Panel_StrikerQty_C = 0;


                                    if (pnl.Panel_Type.Contains("Awning"))
                                    {
                                        if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                            pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                            pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                        {
                                            Panel_StrikerQty_A += 2;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                        {
                                            Panel_StrikerQty_A += 3;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                        {
                                            Panel_StrikerQty_A += 4;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                        {
                                            Panel_StrikerQty_A += 1;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                        {
                                            Panel_StrikerQty_A += 2;
                                        }

                                        if (pnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtLeftQty);
                                        }

                                        if (pnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtLeft2Qty);
                                        }

                                        if (pnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtRightQty);
                                        }

                                        if (pnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtRight2Qty);
                                        }

                                        if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                        {
                                            Panel_StrikerQty_A += 2;
                                        }
                                    }
                                    else if (pnl.Panel_Type.Contains("Casement"))
                                    {
                                        if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                            pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                            pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                        {
                                            Panel_StrikerQty_C += 2;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                        {
                                            Panel_StrikerQty_C += 3;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                        {
                                            Panel_StrikerQty_C += 4;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                        {
                                            Panel_StrikerQty_C += 1;
                                        }
                                        else if (pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                                 pnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                        {
                                            Panel_StrikerQty_C += 2;
                                        }

                                        if (pnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtTopQty);
                                        }

                                        if (pnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtTop2Qty);
                                        }

                                        if (pnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtBotQty);
                                        }

                                        if (pnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                        {
                                            Panel_StrikerQty_C += (1 * pnl.Panel_ExtBot2Qty);
                                        }

                                        if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                        {
                                            Panel_StrikerQty_C += 1;
                                        }

                                        if (pnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                        {
                                            Panel_StrikerQty_A += 1;
                                        }
                                    }

                                    if (Panel_StrikerQty_A != 0 ||
                                        Panel_StrikerQty_C != 0)
                                    {
                                        StrikerPrice += (Panel_StrikerQty_A + Panel_StrikerQty_C) * StrikerPricePerPiece;
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
                                    if ((pnl.Panel_Type.Contains("Sliding")))
                                    {
                                        CoverProfileCost += ((pnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price) * 2;
                                    }
                                    else
                                    {
                                        CoverProfileCost += (pnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price +
                                                            (pnl.Panel_SashWidth / 1000m) * CoverProfile_0373Price;
                                    }
                                    #endregion

                                    #region Glass 

                                    if (pnl.Panel_GlassThickness >= 6.0f &&
                                        pnl.Panel_GlassThickness <= 9.0f)
                                    {
                                        if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                        {
                                            GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                        }
                                        else
                                        {
                                            GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                        }
                                    }
                                    else if (pnl.Panel_GlassThickness == 10.0f ||
                                     pnl.Panel_GlassThickness == 11.0f)
                                    {
                                        if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                        {
                                            GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                        }
                                        else
                                        {
                                            GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                        }
                                    }
                                    else if (pnl.Panel_GlassThickness >= 12.0f)
                                    {
                                        if (pnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                        {
                                            GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                        }
                                        else
                                        {
                                            GlassPrice += ((pnl.Panel_GlassHeight / 1000m) * (pnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                        }
                                    }

                                    //sealant for glass
                                    Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)(pnl.Panel_GlassWidth + pnl.Panel_GlassHeight) / 6842));

                                    if (wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                                    }
                                    else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                                    {
                                        SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                                    }
                                    #endregion


                                    CostingPoints += ProfileColorPoints * 4;
                                    InstallationPoints += (ProfileColorPoints / 3) * 4;
                                }
                            }
                        }
                    }
                    #endregion 

                    #region SinglePnl

                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)//single
                    {
                        IPanelModel Singlepnl = fr.Lst_Panel[0];

                        if (Singlepnl.Panel_SashPropertyVisibility == true)
                        {
                            if (Singlepnl.Panel_Type.Contains("Casement"))
                            {
                                MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;

                                if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                {
                                    if (Singlepnl.Panel_HingeOptions == HingeOption._2DHinge)
                                    {
                                        _2DHingePrice += _2DHingePricePerPiece * Singlepnl.Panel_2DHingeQty_nonMotorized;
                                    }
                                    else if (Singlepnl.Panel_HingeOptions == HingeOption._FrictionStay)
                                    {
                                        FSPrice += FS_16HD_casementPricePerPiece * 2;
                                    }

                                    if (Singlepnl.Panel_ExtensionOptionsVisibility == true &&
                                        Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                        Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                        Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                        Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                    {
                                        if (Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                            Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                            Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                            Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                        {
                                            ExtensionPrice += Extension_639957PricePerPiece;
                                        }
                                    }

                                    if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                    {
                                        if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                        {
                                            HandlePrice += RotoswingHanldePricePerPiece;
                                        }
                                        else if (Singlepnl.Panel_HandleType == Handle_Type._Rotary)
                                        {
                                            //wlang price ng rotaty 
                                        }
                                    }

                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                             Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                    {
                                        #region Handle
                                        if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_HandleType == Handle_Type._MVD)
                                            {
                                                HandlePrice += MVDHandlePricePerPiece;

                                                LatchDeadboltStrikerPrice += LatchDeadboltStrikerPricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_HandleType == Handle_Type._Rio)
                                            {
                                                HandlePrice += RioHandlePricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_HandleType == Handle_Type._Rotoline)
                                            {
                                                //wlang presyo ng rotoline
                                            }
                                        }
                                        #endregion

                                        #region ExtensionPrice 
                                        if (Singlepnl.Panel_ExtensionOptionsVisibility == true &&
                                            Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._None ||
                                            Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None ||
                                            Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._None ||
                                            Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                                        {
                                            if (Singlepnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                                                Singlepnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956)
                                            {
                                                ExtensionPrice += MVDExtensionPricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_ExtensionLeftArtNo != Extension_ArticleNo._630956 ||
                                                     Singlepnl.Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._630956 ||
                                                     Singlepnl.Panel_ExtensionRightArtNo != Extension_ArticleNo._630956 ||
                                                     Singlepnl.Panel_ExtensionRight2ArtNo != Extension_ArticleNo._630956)
                                            {
                                                ExtensionPrice += Extension_567639PricePerPiece;
                                            }
                                        }
                                        #endregion

                                        if (ChckDM == true)
                                        {
                                            StrikerPrice += AdjustableStrikerPricePerPiece * Singlepnl.Panel_AdjStrikerQty;
                                        }

                                        RestrictorStayPrice += RestrictorStayPricePerPiece * 2;

                                        _35mmBacksetEspagWithCylinderPrice += _35mmBacksetEspagWithCylinder;

                                        _3DHingePrice += _3DHingePricePerPiece * Singlepnl.Panel_3dHingeQty;
                                    }
                                    else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                    {
                                        if (Singlepnl.Panel_CenterHingeOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                            {
                                                NTCenterHingePrice += NTCenterHingePricePerPiece;
                                            }
                                            else if (Singlepnl.Panel_CenterHingeOptions == CenterHingeOption._MiddleCloser)
                                            {
                                                MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;
                                            }
                                        }

                                        if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                        {
                                            if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                            {
                                                HandlePrice += RotoswingHanldePricePerPiece;
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
                                    else if (Singlepnl.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                                    {
                                        SnapInKeepPrice += SnapInKeepPricePerPiece * 2;
                                    }

                                    if (Singlepnl.Panel_CornerDriveOptionsVisibility == true)
                                    {
                                        CornerDrivePrice += CornerDrivePricePerPiece * 2;
                                    }
                                }
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

                                if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                {
                                    if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                    {
                                        HandlePrice += RotoswingHanldePricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_HandleType == Handle_Type._Rotary)
                                    {
                                        //wlang price ng rotaty 
                                    }
                                }

                                MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;
                            }
                            else if (Singlepnl.Panel_Type.Contains("Sliding"))
                            {
                                #region handle
                                if (Singlepnl.Panel_HandleOptionsVisibility == true)
                                {
                                    if (Singlepnl.Panel_HandleType == Handle_Type._Rotoswing)
                                    {
                                        HandlePrice += RotoswingHanldePricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_HandleType == Handle_Type._RotoswingForSliding)
                                    {
                                        HandlePrice += RotoswingHanldeForSlidingPricePerPiece;
                                    }
                                    else if (Singlepnl.Panel_HandleType == Handle_Type._Rio)
                                    {
                                        HandlePrice += RioHandlePricePerPiece;
                                    }
                                }
                                #endregion

                                BrushSealPrice = ((Singlepnl.Panel_Height / 1000m) * 2 * 2) * BrushSealPricePerLinearMeter; // 2qty 2perimeter

                                if (Singlepnl.Panel_RollersTypes == RollersTypes._TandemRoller ||
                                    Singlepnl.Panel_RollersTypes == RollersTypes._HDRoller)
                                {
                                    RollerPrice += 2 * HDRollerPricePerPiece;
                                }
                                else if (Singlepnl.Panel_RollersTypes == RollersTypes._GURoller)
                                {
                                    RollerPrice += 2 * GURollerPricePerPiece;
                                }

                                if (Singlepnl.Panel_HandleType != Handle_Type._None)
                                {
                                    StrikerLRPrice += 1 * StrikerLRPricePerPiece;
                                }

                                WeatherBarPrice += ((fr.Frame_Width / 1000m) * 2) * WeatherBarPricePerPiece;
                                WeatherBarFastenerPrice += (fr.Frame_Width / 300) * WeatherBarFastenerPrice;
                                WaterSeepagePrice += (fr.Frame_Width / 1000) * WaterSeepagePricePerLinearMeter;
                                GuideTrackPrice += ((GuideTrackPricePerLinearMeter / 1000m) * 2) * Singlepnl.Panel_AluminumTrackQty;
                                AlumTrackPrice += ((AluminumTrackPricePerLinearMeter / 1000m) * 2) * Singlepnl.Panel_AluminumTrackQty;

                                if (Singlepnl.Panel_Overlap_Sash == OverlapSash._Left ||
                                    Singlepnl.Panel_Overlap_Sash == OverlapSash._Right)
                                {
                                    InterlockPrice += 2 * InterlockPricePerPiece;
                                    ExtensionForInterlockPrice += 2 * ExtensionForInterlockPricePerPiece;
                                    SealingBlockPrice += 2 * SealingBlockPricePerPiece;
                                }
                            }

                            if (Singlepnl.Panel_ChkText == "dSash" && Singlepnl.Panel_Type.Contains("Fixed"))
                            {
                                #region SashPrice 
                                SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                                if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                    }
                                    else
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                    }

                                    SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                                }
                                else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                    }
                                    else
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                    }

                                    SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                }
                                else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                    }
                                    else
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                    }

                                    SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                                }
                                else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                    }
                                    else
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                    }

                                    SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                                }
                                else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                    SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                    GlazingGasketPrice += (SashPerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                                }
                                else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                    }
                                    else
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                    }

                                    SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                                }
                                else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                                {
                                    if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                    }
                                    else
                                    {
                                        SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                    }

                                    SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                                }



                                SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                                SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                                GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                                #endregion

                                MiddleCLoserPrice += MiddleCLoserPricePerPiece * Singlepnl.Panel_MiddleCloserPairQty;
                                SpacerFixSashPrice += 2 * SpacerFixSashPricePerPiece;
                            }

                            if (Singlepnl.Panel_GlassThickness == 6.0f)
                            {
                                GBSpacerPrice += GBSpacerPricePerPiece * 4;
                            }

                            if (ChckPlasticWedge == true)
                            {
                                PlasticWedgePrice += PlasticWedgePricePerPiece;
                            }

                            if (Singlepnl.Panel_MotorizedOptionVisibility == true)
                            {
                                //motorize price
                            }


                            #region SashPrice 
                            SashPerimeter = (Singlepnl.Panel_SashHeight + Singlepnl.Panel_SashWidth) * 2;

                            if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_7581_White;
                                }
                                else
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_7581_WoodGrain;
                                }

                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_7581;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                            {
                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_374_White;
                                }
                                else
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_374_WoodGrain;
                                }

                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                            {
                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_373_White;
                                }
                                else
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_373_WoodGrain;
                                }

                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_373And374;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_395_White;
                                }
                                else
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_395_WoodGrain;
                                }
                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_395;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                            {
                                SashPricePerLinearMeter = SashPricePerLinearMeter_2067_White;
                                SashReinPricePerLinearMeter = G58ReinPricePerLinearMeter_V226;

                                GlazingGasketPrice += (SashPerimeter / 1000) * GlazingGasketPricePerLinearMeter;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                            {
                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6040_White;
                                }
                                else
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6040_WoodGrain;
                                }

                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6040;
                            }
                            else if (Singlepnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                            {
                                if (wdm.WD_BaseColor == Base_Color._White || wdm.WD_BaseColor == Base_Color._Ivory)
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6041_White;
                                }
                                else
                                {
                                    SashPricePerLinearMeter = SashPricePerLinearMeter_6041_WoodGrain;
                                }

                                SashReinPricePerLinearMeter = SashReinPricePerLinearMeter_6041;
                            }

                            SashPrice += (SashPerimeter / 1000m) * SashPricePerLinearMeter;
                            SashReinPrice += (SashPerimeter / 1000m) * SashReinPricePerLinearMeter;
                            GbPrice += (SashPerimeter / 1000m) * GlazingBeadPricePerLinearMeter;
                            #endregion

                            #region EspagPrice

                            if (Singlepnl.Panel_EspagnoletteOptionsVisibility == true && Singlepnl.Panel_ChkText != "dSash")
                            {
                                if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A00006PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A01006PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A02206PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A03206PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A04206PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A05206PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                                {
                                    EspagPrice += TiltAndTurnEspag_N110A06206PricePerPiece;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
                                {
                                    EspagPrice += MVDGearPricePerPiece;
                                }
                                else
                                {
                                    EspagPrice += Espag741012_PricePerPiece;
                                }
                            }
                            #endregion

                            #region StrikerPrice
                            int Panel_StrikerQty_A = 0,
                                Panel_StrikerQty_C = 0;


                            if (Singlepnl.Panel_Type.Contains("Awning"))
                            {
                                if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                    Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                    Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                {
                                    Panel_StrikerQty_A += 2;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                {
                                    Panel_StrikerQty_A += 3;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                {
                                    Panel_StrikerQty_A += 4;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                {
                                    Panel_StrikerQty_A += 1;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                {
                                    Panel_StrikerQty_A += 2;
                                }

                                if (Singlepnl.Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtLeftQty);
                                }

                                if (Singlepnl.Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtLeft2Qty);
                                }

                                if (Singlepnl.Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtRightQty);
                                }

                                if (Singlepnl.Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtRight2Qty);
                                }

                                if (Singlepnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                {
                                    Panel_StrikerQty_A += 2;
                                }
                            }
                            else if (Singlepnl.Panel_Type.Contains("Casement"))
                            {
                                if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                                    Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                                    Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                                {
                                    Panel_StrikerQty_C += 2;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                                {
                                    Panel_StrikerQty_C += 3;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                                {
                                    Panel_StrikerQty_C += 4;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                                {
                                    Panel_StrikerQty_C += 1;
                                }
                                else if (Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                                         Singlepnl.Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                                {
                                    Panel_StrikerQty_C += 2;
                                }

                                if (Singlepnl.Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtTopQty);
                                }

                                if (Singlepnl.Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtTop2Qty);
                                }

                                if (Singlepnl.Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtBotQty);
                                }

                                if (Singlepnl.Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                                {
                                    Panel_StrikerQty_C += (1 * Singlepnl.Panel_ExtBot2Qty);
                                }

                                if (Singlepnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                {
                                    Panel_StrikerQty_C += 1;
                                }

                                if (Singlepnl.Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                                {
                                    Panel_StrikerQty_A += 1;
                                }
                            }

                            if (Panel_StrikerQty_A != 0 ||
                                Panel_StrikerQty_C != 0)
                            {
                                StrikerPrice += (Panel_StrikerQty_A + Panel_StrikerQty_C) * StrikerPricePerPiece;
                            }
                            #endregion

                            #region GeorgianBar
                            if (Singlepnl.Panel_GeorgianBarOptionVisibility == true)
                            {
                                if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
                                {
                                    if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                    {
                                        GeorgianBarCost += ((Singlepnl.Panel_SashWidth / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price;
                                    }
                                    if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                    {
                                        GeorgianBarCost += ((Singlepnl.Panel_SashHeight / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0724Price;
                                    }
                                }
                                else if (Singlepnl.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
                                {
                                    if (Singlepnl.Panel_GeorgianBar_HorizontalQty != 0)
                                    {
                                        GeorgianBarCost += ((Singlepnl.Panel_SashWidth / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price;
                                    }
                                    if (Singlepnl.Panel_GeorgianBar_VerticalQty != 0)
                                    {
                                        GeorgianBarCost += ((Singlepnl.Panel_SashHeight / 1000m) * GeorgianBarHorizontalQty) * GeorgianBar_0726Price;
                                    }
                                }
                            }
                            #endregion

                            #region CoverProfilePrice
                            if ((Singlepnl.Panel_Type.Contains("Sliding")))
                            {
                                CoverProfileCost += ((Singlepnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price) * 2;
                            }
                            else
                            {
                                CoverProfileCost += (Singlepnl.Panel_SashWidth / 1000m) * CoverProfile_0914Price +
                                                    (Singlepnl.Panel_SashWidth / 1000m) * CoverProfile_0373Price;
                            }
                            #endregion

                            #region Glass 

                            if (Singlepnl.Panel_GlassThickness >= 6.0f &&
                                Singlepnl.Panel_GlassThickness <= 9.0f)
                            {
                                if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                {
                                    GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmTemp_PricePerSqrMeter;
                                }
                                else
                                {
                                    GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_6mmClr_PricePerSqrMeter;
                                }
                            }
                            else if (Singlepnl.Panel_GlassThickness == 10.0f ||
                             Singlepnl.Panel_GlassThickness == 11.0f)
                            {
                                if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                {
                                    GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmTemp_PricePerSqrMeter;
                                }
                                else
                                {
                                    GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_10mmClr_PricePerSqrMeter;
                                }
                            }
                            else if (Singlepnl.Panel_GlassThickness >= 12.0f)
                            {
                                if (Singlepnl.Panel_GlassThicknessDesc.Contains("Tempered"))
                                {
                                    GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmTemp_PricePerSqrMeter;
                                }
                                else
                                {
                                    GlassPrice += ((Singlepnl.Panel_GlassHeight / 1000m) * (Singlepnl.Panel_GlassWidth / 1000m)) * Glass_12mmClr_PricePerSqrMeter;
                                }
                            }

                            //sealant for glass
                            Glass_SealantWHQty_Total = (int)(Math.Ceiling((decimal)(Singlepnl.Panel_GlassWidth + Singlepnl.Panel_GlassHeight) / 6842));

                            if (wdm.WD_BaseColor == Base_Color._Ivory || wdm.WD_BaseColor == Base_Color._White)
                            {
                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_Clear;
                            }
                            else if (wdm.WD_BaseColor == Base_Color._DarkBrown)
                            {
                                SealantPrice += Glass_SealantWHQty_Total * SealantPricePerCan_BrownBlack;
                            }
                            #endregion

                            CostingPoints += ProfileColorPoints * 4;
                            InstallationPoints += (ProfileColorPoints / 3) * 4;
                        }
                    }

                    #endregion

                }

                LaborCost = CostingPoints * CostPerPoints;
                InstallationCost = InstallationPoints * CostPerPoints;

                // Math.Round( , 2) +

                FittingAndSuppliesCost = Math.Round(FSPrice, 2) +
                                         Math.Round(RestrictorStayPrice, 2) +
                                         Math.Round(CornerDrivePrice, 2) +
                                         Math.Round(SnapInKeepPrice, 2) +
                                         Math.Round(_35mmBacksetEspagWithCylinderPrice, 2) +
                                         Math.Round(MiddleCLoserPrice, 2) +
                                         Math.Round(StayBearingPrice, 2) +
                                         Math.Round(StayBearingPinPrice, 2) +
                                         Math.Round(CoverStayBearingPrice, 2) +
                                         Math.Round(CoverCornerHingePrice, 2) +
                                         Math.Round(CornerPivotRestPrice, 2) +
                                         Math.Round(TopCornerHingePrice, 2) +
                                         Math.Round(CorverCornerPivotRestPrice, 2) +
                                         Math.Round(CorverCornerPivotRestVerticalPrice, 2) +
                                         Math.Round(HandlePrice, 2) +
                                         Math.Round(EspagPrice, 2) +
                                         Math.Round(_2DHingePrice, 2) +
                                         Math.Round(_3DHingePrice, 2) +
                                         Math.Round(NTCenterHingePrice, 2) +
                                         Math.Round(ShootBoltStrikerPrice, 2) +
                                         Math.Round(ShootBoltReversePrice, 2) +
                                         Math.Round(ShootBoltNonReversePrice, 2) +
                                         Math.Round(StrikerPrice, 2) +
                                         Math.Round(LatchDeadboltStrikerPrice, 2) +
                                         Math.Round(ExtensionPrice, 2);

                AncillaryProfileCost = Math.Round(ThresholdPrice, 2) +
                                       Math.Round(GbPrice, 2) +
                                       Math.Round(GeorgianBarCost, 2) +
                                       Math.Round(CoverProfileCost, 2) +
                                       Math.Round(GlazingGasketPrice, 2);

                AccesorriesCost = Math.Round(EndCapPrice, 2) +
                                  Math.Round(MechJointPrice, 2) +
                                  Math.Round(GBSpacerPrice, 2) +
                                  Math.Round(PlasticWedgePrice, 2);

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

                //costingPointsDesc = "\n\nTotal Points: " + Math.Round(CostingPoints, 2);

                //InstallationCostDesc = "\n\nInstallation Cost: " + Math.Round(InstallationCost, 2);
                //laborCostDesc = "\n\nLabor Cost: " + Math.Round(LaborCost, 2);
                //MaterialCostDesc = "\n\nMaterial Cost : " + Math.Round(MaterialCost, 2);

                //FramePriceDesc = "\n\nFrame Price: " + Math.Round(FramePrice, 2);
                //FrameReinPriceDesc = "\n\nFrame Rein Price: " + Math.Round(FrameReinPrice, 2);
                //SashPriceDesc = "\n\nSash Price : " + Math.Round(SashPrice, 2);
                //SashReinPriceDesc = "\n\nSash Rein Price: " + Math.Round(SashReinPrice, 2);
                //GlassDesc = "\n\nGlass Price: " + Math.Round(GlassPrice, 2);
                //DivPriceDesc = "\n\nDivider Price: " + Math.Round(DivPrice, 2);
                //GBPriceDesc = "\n\nGB Price: " + Math.Round(GbPrice, 2);
                //FittingAndSuppliesDesc = "\n\nFittingAndSupplies Cost: " + Math.Round(FittingAndSuppliesCost, 2);
                //AncillaryProfileCostDesc = "\n\nAncillaryProfile Cost: " + Math.Round(AncillaryProfileCost, 2);
                //AccesorriesCostDesc = "\n\nAccesorries Cost: " + Math.Round(AccesorriesCost, 2);
                //sealantDesc = "\n\nSealant Cost : " + Math.Round(SealantPrice, 2);
                //PUFoamingDesc = "\n\nPUFoaming Cost : " + Math.Round(PUFoamingPrice, 2);

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
                DivPrice = 0;
                DMPrice = 0;
                GbPrice = 0;
                GlassPrice = 0;
                SealantPrice = 0;
                PUFoamingPrice = 0;

                FittingAndSuppliesCost = 0;
                FSPrice = 0;
                RestrictorStayPrice = 0;
                CornerDrivePrice = 0;
                SnapInKeepPrice = 0;
                _35mmBacksetEspagWithCylinderPrice = 0;
                MiddleCLoserPrice = 0;
                StayBearingPrice = 0;
                StayBearingPinPrice = 0;
                CoverStayBearingPrice = 0;
                CoverCornerHingePrice = 0;
                CornerPivotRestPrice = 0;
                TopCornerHingePrice = 0;
                CorverCornerPivotRestPrice = 0;
                CorverCornerPivotRestVerticalPrice = 0;
                HandlePrice = 0;
                EspagPrice = 0;
                _2DHingePrice = 0;
                _3DHingePrice = 0;
                NTCenterHingePrice = 0;
                ShootBoltStrikerPrice = 0;
                ShootBoltReversePrice = 0;
                ShootBoltNonReversePrice = 0;
                StrikerPrice = 0;
                LatchDeadboltStrikerPrice = 0;
                ExtensionPrice = 0;

                AncillaryProfileCost = 0;
                ThresholdPrice = 0;
                GbPrice = 0;
                GeorgianBarCost = 0;
                CoverProfileCost = 0;
                GlazingGasketPrice = 0;

                AccesorriesCost = 0;
                EndCapPrice = 0;
                MechJointPrice = 0;
                GBSpacerPrice = 0;
                PlasticWedgePrice = 0;
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
