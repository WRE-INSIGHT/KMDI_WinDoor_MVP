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
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private IMainPresenter _mainPresenter;





        #region GlobalVariables
        private List<IQuoteItemListUCPresenter> _lstQuoteItemUC = new List<IQuoteItemListUCPresenter>();
        private List<int> _lstItemArea = new List<int>();
        private List<string> lst_glassThickness = new List<string>();
        private List<string> lst_glassFilm = new List<string>();
        private List<string> lst_Description = new List<string>();


        int fixedCount = 0,
            AwningCount = 0,
            CasementCount = 0,
            SlidingCount = 0,
            LouverCount = 0,
            TiltNTurnCount = 0,
            GeorgianBarVerticalQty = 0,
            GeorgianBarHorizontalQty = 0;

        string FrameTypeDesc,
            AllItemDescription,
            motorizeDesc,
            GeorgianBarHorizontalDesc,
            GeorgianBarVerticalDesc,
            all;


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



                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];


                //if (lst_Description != null)
                //{
                //    wdm.WD_description = "C70 Profile\n";
                //    for (int ii = 0; ii < lst_Description.Count; ii++)
                //    {
                //        wdm.WD_description += lst_Description[ii];
                //    }
                //}



                _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName = wdm.WD_name;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDimension = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString();
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc = wdm.WD_description;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
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
                                      lstQuoteUC.GetiQuoteItemListUC().itemDimension,
                                      byteToStr,
                                      1,
                                      0,
                                      0,
                                      0,
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
                foreach (IFrameModel fr in _windoorModel.lst_frame)
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
                                if (pnl.Panel_Type.Contains("Fixed"))
                                {
                                    fixedCount += 1;
                                }
                                else if (pnl.Panel_Type.Contains("Awning"))
                                {
                                    AwningCount += 1;
                                }
                                else if (pnl.Panel_Type.Contains("Casement"))
                                {
                                    CasementCount += 1;
                                }

                                if (pnl.Panel_GlassThicknessDesc != null)
                                {
                                    lst_glassThickness.Add(pnl.Panel_GlassThicknessDesc + "\n");
                                }
                                if (pnl.Panel_GlassFilm.ToString() != "None")
                                {
                                    lst_glassFilm.Add(pnl.Panel_GlassFilm.ToString());
                                }




                                if (pnl.Panel_GeorgianBarOptionVisibility == true)
                                {
                                    GeorgianBarHorizontalQty += pnl.Panel_GeorgianBar_HorizontalQty;
                                    GeorgianBarVerticalQty += pnl.Panel_GeorgianBar_VerticalQty;

                                    GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                                    GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                                }

                                List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();
                                List<string> lst_glassFilmDistinct = lst_glassFilm.Distinct().ToList();

                                if (pnl.Panel_MotorizedOptionVisibility == true)
                                {
                                    motorizeDesc = " Panel Motorized";
                                }
                                else
                                {
                                    motorizeDesc = " Panel";
                                }
                                
                                if (fixedCount != 0 && pnl.Panel_Type.Contains("Fixed"))
                                {
                                    AllItemDescription = AllItemDescription + fixedCount.ToString() + motorizeDesc + " Fixed " + FrameTypeDesc + "\n";
                                }
                                if (AwningCount != 0 && pnl.Panel_Type.Contains("Awning"))
                                {
                                    AllItemDescription = AllItemDescription + AwningCount.ToString() + motorizeDesc + " Awning " + FrameTypeDesc + "\n";
                                }
                                if (CasementCount != 0 && pnl.Panel_Type.Contains("Casement"))
                                {
                                    AllItemDescription = AllItemDescription + CasementCount.ToString() + motorizeDesc + " Casement " + FrameTypeDesc + "\n";
                                }

                                foreach (string GT in lst_glassThicknessDistinct)
                                {
                                    AllItemDescription += GT;
                                }

                                if (lst_glassFilmDistinct != null)
                                {
                                    foreach (string GF in lst_glassFilmDistinct)
                                    {
                                        AllItemDescription += "with " + GF + "\n";
                                    }
                                }

                                AllItemDescription += GeorgianBarHorizontalDesc;
                                AllItemDescription += GeorgianBarVerticalDesc;

                                //lst_Description.Add(AllItemDescription);
                                 wdm.WD_description = AllItemDescription;

                            }
                        }
                    }
                    else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)//single
                    {
                        IPanelModel pnl = fr.Lst_Panel[0];

                        if (pnl.Panel_Type.Contains("Fixed"))
                        {
                            wdm.WD_description = "C70 Profile\n1 Panel Fixed " + FrameTypeDesc;
                        }
                        else if (pnl.Panel_Type.Contains("Awning"))
                        {
                            wdm.WD_description = "C70 Profile\n1 Panel Awning " + FrameTypeDesc;
                        }
                        else if (pnl.Panel_Type.Contains("Casement"))
                        {
                            wdm.WD_description = "C70 Profile\n1 Panel Casement " + FrameTypeDesc;
                        }
                    }
                                

                }

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
