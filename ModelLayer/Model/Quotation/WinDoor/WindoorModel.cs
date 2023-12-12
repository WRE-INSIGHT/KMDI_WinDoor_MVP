using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.WinDoor
{
    public class WindoorModel : IWindoorModel, INotifyPropertyChanged
    {
        private string _wdProfile;
        [Required(ErrorMessage = "Window Profile is Required")]
        public string WD_profile
        {
            get
            {
                return _wdProfile;
            }
            set
            {
                _wdProfile = value;
                NotifyPropertyChanged();
            }
        }
        private int _wdHeight;
        [Required(ErrorMessage = "Window Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Window Height bigger than or equal to {1}")]
        public int WD_height
        {
            get
            {
                return _wdHeight;
            }
            set
            {
                _wdHeight = value;
                WD_PlasticCover = (decimal)(((value * WD_width) * 2) * 0.00012D) / 1000;

                WD_Dimension = WD_width.ToString() + " x " + value.ToString();
                WD_height_4basePlatform_forImageRenderer = value + 35;
                WD_zoom_forImageRenderer = GetZoom_forRendering(); //1.0f; //GetZoom_forRendering();

                WD_height_4basePlatform = value + 35; // (int)(value * WD_zoom) + 35;
                WD_zoom = GetZoom_forRendering();
                NotifyPropertyChanged();
            }
        }
        public Base_Color WD_BaseColor { get; set; }
        private int _wdWidth;
        [Required(ErrorMessage = "Window Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Window Width bigger than or equal to {1}")]
        public int WD_width
        {
            get
            {
                return _wdWidth;
            }
            set
            {
                _wdWidth = value;
                WD_PlasticCover = (decimal)(((value * WD_height) * 2) * 0.00012) / 1000;

                WD_Dimension = value.ToString() + " x " + WD_height.ToString();
                WD_width_4basePlatform_forImageRenderer = value + 70;
                WD_zoom_forImageRenderer = GetZoom_forRendering();

                WD_width_4basePlatform = value + 70;
                WD_zoom = GetZoom_forRendering();
                NotifyPropertyChanged();
            }
        }
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int WD_id { get; set; }

        private string _wdName;
        [Required(ErrorMessage = "Window Name is Required")]
        [StringLength(15, MinimumLength = 6)]
        public string WD_name
        {
            get
            {
                return _wdName;
            }
            set
            {
                _wdName = value;
                NotifyPropertyChanged();
            }
        }



        private int _wdWidth2;
        public int WD_width_4basePlatform
        {
            get
            {
                return _wdWidth2;
            }
            set
            {
                _wdWidth2 = value;
                NotifyPropertyChanged();
            }
        }

        private int _wdWidthforBasePlatformImageRenderer;
        public int WD_width_4basePlatform_forImageRenderer
        {
            get
            {
                return _wdWidthforBasePlatformImageRenderer;
            }

            set
            {
                _wdWidthforBasePlatformImageRenderer = value;
                NotifyPropertyChanged();
            }
        }


        private int _wdHeight2;
        public int WD_height_4basePlatform
        {
            get
            {
                return _wdHeight2;
            }
            set
            {
                _wdHeight2 = value;
                NotifyPropertyChanged();
            }
        }

        private int _wdHeightforBasePlatformImageRenderer;
        public int WD_height_4basePlatform_forImageRenderer
        {
            get
            {
                return _wdHeightforBasePlatformImageRenderer;
            }

            set
            {
                _wdHeightforBasePlatformImageRenderer = value;
                NotifyPropertyChanged();
            }
        }


        private bool _wdVisibility;
        public bool WD_visibility
        {
            get
            {
                return _wdVisibility;
            }
            set
            {
                _wdVisibility = value;
                NotifyPropertyChanged();
            }
        } //visibility of Window/Door


        private bool _wdOrientation;
        public bool WD_orientation
        {
            get
            {
                return _wdOrientation;
            }
            set
            {
                _wdOrientation = value;
                NotifyPropertyChanged();
            }
        }
        private bool _wdfileLoad;
        public bool WD_fileLoad
        {
            get
            {
                return _wdfileLoad;
            }
            set
            {
                _wdfileLoad = value;
                NotifyPropertyChanged();
            }
        }



        private float _wdZoom;
        [Required(ErrorMessage = "Zoom value is Required")]
        [Range(0.001, 100.0, ErrorMessage = "Please enter a zoom value bigger than or equal to {1}")]
        public float WD_zoom
        {
            get
            {
                return _wdZoom;
            }
            set
            {
                _wdZoom = value;
                NotifyPropertyChanged();
            }
        }

        private float _wdZoomforImageRenderer;
        public float WD_zoom_forImageRenderer
        {
            get
            {
                return _wdZoomforImageRenderer;
            }
            set
            {
                _wdZoomforImageRenderer = value;
                WD_width_4basePlatform_forImageRenderer = Convert.ToInt32((WD_width * value) + 70);
                WD_height_4basePlatform_forImageRenderer = Convert.ToInt32((WD_height * value) + 35);
                SetImageRenderingZoom();
                NotifyPropertyChanged();
            }
        }


        private string _wdDesc;
        public string WD_description
        {
            get
            {
                return _wdDesc;
            }
            set
            {
                _wdDesc = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _wdPrice;
        [Required(ErrorMessage = "Window Price is Required")]
        public decimal WD_price
        {
            get
            {
                return _wdPrice;
            }
            set
            {
                _wdPrice = value;
                NotifyPropertyChanged();
            }
        } //multiply by 0.01 to get cents (decimal)

        private int _wdQty;
        [Required(ErrorMessage = "Window Quantity is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value for Window Quantity bigger than or equal to {1}")]
        public int WD_quantity
        {
            get
            {
                return _wdQty;
            }
            set
            {
                _wdQty = value;
                NotifyPropertyChanged();
            }
        }//dapat hindi zero

        private decimal _wdDiscount;
        public decimal WD_discount
        {
            get
            {
                return _wdDiscount;
            }
            set
            {
                _wdDiscount = value;
                NotifyPropertyChanged();
            }
        }



        private string _wdDimension;
        public string WD_Dimension
        {
            get
            {
                return WD_width.ToString() + " x " + WD_height.ToString();
            }
            set
            {
                _wdDimension = value;
                NotifyPropertyChanged();
            }
        }

        private Image _wdImage;
        public Image WD_image
        {
            get
            {
                return _wdImage;
            }

            set
            {
                _wdImage = value;
                NotifyPropertyChanged();
            }
        }

        private Image _wdFlpImage;
        public Image WD_flpImage
        {
            get
            {
                return _wdFlpImage;
            }

            set
            {
                _wdFlpImage = value;
                NotifyPropertyChanged();
            }
        }

        private Image _wdSlidingTopViewImage;
        public Image WD_SlidingTopViewImage
        {
            get
            {
                return _wdSlidingTopViewImage;
            }

            set
            {
                _wdSlidingTopViewImage = value;
                NotifyPropertyChanged();
            }
        }


        private bool _wdSlidingTopViewVisibility;
        public bool WD_SlidingTopViewVisibility
        {
            get
            {
                return _wdSlidingTopViewVisibility;
            }

            set
            {
                _wdSlidingTopViewVisibility = value;
                NotifyPropertyChanged();
            }
        }


        public List<IFrameModel> lst_frame
        {
            get;
            set;
        }
        public List<IConcreteModel> lst_concrete { get; set; }
        public List<Control> lst_objects { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private float[] _arr_zoomPercentage = { 0.01f,0.02f,0.05f,0.06f,0.08f,0.10f,
                                                0.13f, 0.17f, 0.26f, 0.50f, 1.0f };
        public float[] Arr_ZoomPercentage
        {
            get
            {
                return _arr_zoomPercentage;
            }
        }

        private int _frameIDCounter;
        public int frameIDCounter
        {
            get
            {
                return _frameIDCounter;
            }
            set
            {
                _frameIDCounter = value;
            }
        }

        public int concreteIDCounter { get; set; }

        private int _panelIDCounter;
        public int panelIDCounter
        {
            get
            {
                return _panelIDCounter;
            }
            set
            {
                _panelIDCounter = value;
            }
        }

        private int _mpanelIDCounter;
        public int mpanelIDCounter
        {
            get
            {
                return _mpanelIDCounter;
            }
            set
            {
                _mpanelIDCounter = value;
            }
        }

        private int _divIDCounter;
        public int divIDCounter
        {
            get
            {
                return _divIDCounter;
            }
            set
            {
                _divIDCounter = value;
            }
        }

        public int PanelGlassID_Counter { get; set; }

        public Foil_Color WD_InsideColor { get; set; }
        public Foil_Color WD_OutsideColor { get; set; }

        private decimal _wdPlasticCover;
        [Description("Plastic Cover in kg")]
        public decimal WD_PlasticCover
        {
            get
            {
                return _wdPlasticCover;
            }

            set
            {
                _wdPlasticCover = value;
            }
        }

        private bool _wdCmenuDeleteVisibility;
        public bool WD_CmenuDeleteVisibility
        {
            get
            {
                return _wdCmenuDeleteVisibility;
            }
            set
            {
                _wdCmenuDeleteVisibility = value;
                foreach (IFrameModel frame in lst_frame)
                {
                    frame.Frame_CmenuDeleteVisibility = _wdCmenuDeleteVisibility;

                    foreach (IPanelModel pnl in frame.Lst_Panel)
                    {
                        pnl.Panel_CmenuDeleteVisibility = _wdCmenuDeleteVisibility;
                    }
                    foreach (IMultiPanelModel mpnl in frame.Lst_MultiPanel)
                    {
                        mpnl.MPanel_CmenuDeleteVisibility = _wdCmenuDeleteVisibility;

                        foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                        {
                            pnl.Panel_CmenuDeleteVisibility = _wdCmenuDeleteVisibility;
                        }
                    }
                }
                NotifyPropertyChanged();
            }
        }

        private int _lbl_arrowCount;
        public int Lbl_ArrowHtCount
        {
            get
            {
                return _lbl_arrowCount;
            }
            set
            {
                _lbl_arrowCount = value;
                NotifyPropertyChanged();
            }
        }

        private bool _wdSelected;
        public bool WD_Selected
        {
            get
            {
                return _wdSelected;
            }

            set
            {
                _wdSelected = value;
                NotifyPropertyChanged();
            }
        }

        private int _lbl_arrowWdCount;
        public int Lbl_ArrowWdCount
        {
            get
            {
                return _lbl_arrowWdCount;
            }
            set
            {
                _lbl_arrowWdCount = value;
                NotifyPropertyChanged();
            }
        }

        public Dictionary<int, int> Div_ArrowWdLengthList { get; set; }
        public int Div_ArrowCount { get; set; }
        public Dictionary<int, decimal> Dictionary_wd_redArrowLines { get; set; }
        public Dictionary<int, decimal> Dictionary_ht_redArrowLines { get; set; }
        private bool _WD_customArrowToggle;
        public bool WD_customArrowToggle
        {
            get
            {
                return _WD_customArrowToggle;
            }
            set
            {
                _WD_customArrowToggle = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _wdCostingPoints;
        public decimal WD_CostingPoints
        {
            get
            {
                return _wdCostingPoints;
            }
            set
            {
                _wdCostingPoints = value;
                NotifyPropertyChanged();
            }
        }
        private decimal _wdcurrentPrice;
        public decimal WD_currentPrice
        {
            get
            {
                return _wdcurrentPrice;
            }

            set
            {
                _wdcurrentPrice = value;
            }
        }

        private int _wdpboxImagerHeight;
        public int WD_pboxImagerHeight
        {
            get
            {
                return _wdpboxImagerHeight;
            }
            set
            {
                _wdpboxImagerHeight = value;
                NotifyPropertyChanged();
            }
        }

        private string _wd_itemName;
        public string WD_itemName
        {
            get
            {
                return _wd_itemName;
            }
            set
            {
                _wd_itemName = value;
                NotifyPropertyChanged();
            }
        }

        private string _wd_WindoorNumber;
        public string WD_WindoorNumber
        {
            get
            {
                return _wd_WindoorNumber;
            }
            set
            {
                _wd_WindoorNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string setDiscount { get; set; }

        private string _wd_TopViewType;
        public string WD_TopViewType
        {
            get
            {
                return _wd_TopViewType;
            }
            set
            {
                _wd_TopViewType = value;
                NotifyPropertyChanged();
            }
        }
        private bool _isFromLoad;
        public bool IsFromLoad
        {
            get
            {
                return _isFromLoad;
            }
            set
            {
                _isFromLoad = value;
            }
        }
        public string TotalPriceHistory { get; set; }
        public string TotalPriceHistoryStatus { get; set; }
        public List<string> lst_TotalPriceHistory { get; set; }
        public decimal SystemSuggestedPrice { get; set; }

        public List<Image> WD_PALst_Designs { get; set; }
        public List<string> WD_PALst_Description { get; set; }
        public List<decimal> WD_PALst_Price { get; set; }

        public bool WD_IsSelectedAtPartialAdjusment { get; set; }
        public bool WD_IsPartialADPreviousExist { get; set; }
        public Image WD_PAPreviousImage { get; set; }
        public string WD_PAPreviousDescription { get; set; }
        public decimal WD_PAPreviousPrice { get; set; }


        private int _pnlLeftCounter;
        public int pnlLeftCounter
        {
            get
            {
                return _pnlLeftCounter;
            }
            set
            {
                _pnlLeftCounter = value;
            }
        }


        private int _pnlRightCounter;
        public int pnlRightCounter
        {
            get
            {
                return _pnlRightCounter;
            }
            set
            {
                _pnlRightCounter = value;
            }
        }


        private int _pnlCount;
        public int pnlCount
        {
            get
            {
                return _pnlCount;
            }
            set
            {
                _pnlCount = value;
            }
        }

        #region Methods

        public void SetDimensions_basePlatform()
        {
            decimal wd_flt_convert_dec = Convert.ToDecimal(WD_width * WD_zoom);
            //decimal base_wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            decimal base_wd_dec = decimal.Round(wd_flt_convert_dec, 0, MidpointRounding.AwayFromZero);
            WD_width_4basePlatform = Convert.ToInt32(base_wd_dec) + 70;

            decimal ht_flt_convert_dec = Convert.ToDecimal(WD_height * WD_zoom);
            //decimal base_ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            decimal base_ht_dec = decimal.Round(ht_flt_convert_dec, 0, MidpointRounding.AwayFromZero);
            WD_height_4basePlatform = Convert.ToInt32(base_ht_dec) + 35;
        }

        public float GetZoom_forRendering()
        {
            int area = _wdHeight * _wdWidth;
            float zm = 1.0f;

            if (area <= 360000) //400w x 400h to 600w x 600h
            {
                zm = _arr_zoomPercentage[10];
            }
            else if (area > 360000 && area <= 1000000) //(600w x 601h / 601w x 600h) to 1000w x 1000h
            {
                zm = _arr_zoomPercentage[9];
            }
            else if (area > 1000000 && area <= 4000000) // (1000w x 1001h / 1001w x 1000h) to 2000w x 2000h
            {
                zm = _arr_zoomPercentage[8];
            }
            else if (area > 4000000 && area <= 9000000) // (2000w x 2001h / 2001w x 2000h) to 3000w x 3000h
            {
                zm = _arr_zoomPercentage[7];
            }
            else if (area > 9000000 && area <= 16000000) // (3000w x 3001h / 3001w x 3000h) to 4000w x 4000h
            {
                zm = _arr_zoomPercentage[6];
            }
            else if (area > 16000000 && area <= 36000000) //  (4000w x 4001h / 4001w x 4000h) to 6000w x 6000h
            {
                zm = _arr_zoomPercentage[5];            
            }
            else if (area > 36000000 && area <= 49000000) // (6000w x 6001h / 6001w x 6000h) to 7000w x 7000h
            {
                zm = _arr_zoomPercentage[4];
            } 
            else if (area > 49000000 && area <= 100000000) // (7000w x 7001h / 7001 x 7000 ) to 10000w x 10000h
            {
                zm = _arr_zoomPercentage[3];
            }
            else if (area > 100000000 && area <= 144000000) // (10000 x 10001h / 10001 x 10000 ) to 12000 x 12000h
            {
                zm = Arr_ZoomPercentage[2];
            }
            else if(area > 144000000 && area <= 900000000) // (12000 x 12001h / 12000 x 12000) to 300000 x 300000 
            {
                zm = Arr_ZoomPercentage[1];
            }
            else if (area > 900000000) // 50000 x 50000 
            {
                zm = Arr_ZoomPercentage[0];
            }

            return zm;
        }

        public void SetImageRenderingZoom()
        {
            if (lst_frame != null)
            {
                foreach (IFrameModel fr in lst_frame)
                {
                    fr.FrameImageRenderer_Zoom = WD_zoom_forImageRenderer;

                    foreach (IPanelModel pnl in fr.Lst_Panel)
                    {
                        pnl.PanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                    }
                    foreach (IMultiPanelModel mpnl2ndlvl in fr.Lst_MultiPanel)
                    {
                        mpnl2ndlvl.MPanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //if(mpnl2ndlvl.MPanelLst_MultiPanel.Count > 0)
                        //{
                        //    foreach (IMultiPanelModel mpnl3rdlvl in mpnl2ndlvl.MPanelLst_MultiPanel)
                        //    {
                        //        mpnl3rdlvl.MPanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //        if (mpnl3rdlvl.MPanelLst_MultiPanel.Count > 0)
                        //        {
                        //            foreach (IMultiPanelModel mpnl4thlvl in mpnl3rdlvl.MPanelLst_MultiPanel)
                        //            {
                        //                mpnl4thlvl.MPanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //                if (mpnl4thlvl.MPanelLst_Panel.Count > 0)
                        //                {
                        //                    foreach (IPanelModel pnl4thlvl in mpnl4thlvl.MPanelLst_Panel)
                        //                    {
                        //                        pnl4thlvl.PanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //                    }
                        //                }
                        //                else if (mpnl4thlvl.MPanelLst_Divider.Count > 0)
                        //                {
                        //                    foreach (IDividerModel div4thlvl in mpnl4thlvl.MPanelLst_Divider)
                        //                    {
                        //                        div4thlvl.DivImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //                    }
                        //                }
                        //            }
                        //        }
                        //        else if (mpnl3rdlvl.MPanelLst_Panel.Count > 0)
                        //        {
                        //            foreach (IPanelModel pnl3rdlvl in mpnl3rdlvl.MPanelLst_Panel)
                        //            {
                        //                pnl3rdlvl.PanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //            }
                        //        }
                        //        else if (mpnl3rdlvl.MPanelLst_Divider.Count > 0)
                        //        {
                        //            foreach (IDividerModel div3rdlvl in mpnl3rdlvl.MPanelLst_Divider)
                        //            {
                        //                div3rdlvl.DivImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //            }
                        //        }
                        //    }
                        //}
                        //else if (mpnl2ndlvl.MPanelLst_Panel.Count > 0)
                        //{
                        //    foreach (IPanelModel pnl2ndlvl in mpnl2ndlvl.MPanelLst_Panel)
                        //    {
                        //        pnl2ndlvl.PanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //    }
                        //}
                        //else if (mpnl2ndlvl.MPanelLst_Divider.Count > 0)
                        //{
                        //    foreach (IDividerModel div2ndlvl in mpnl2ndlvl.MPanelLst_Divider)
                        //    {
                        //        div2ndlvl.DivImageRenderer_Zoom = WD_zoom_forImageRenderer;
                        //    }
                        //}
                    }
                }
            }
            if (lst_concrete != null)
            {
                foreach (IConcreteModel cr in lst_concrete)
                {
                    cr.Concrete_ImagerZoom = WD_zoom_forImageRenderer;
                }
            }
        }
        public void SetfrmDimentionZoom()
        {
            foreach (Control wndr_objects in lst_objects)
            {
                if (wndr_objects.Name.Contains("Frame"))
                {
                    foreach (IFrameModel fr in lst_frame)
                    {
                        if (wndr_objects.Name == fr.Frame_Name)
                        {
                            fr.Frame_Zoom = WD_zoom;
                            fr.Set_DimensionsToBind_using_FrameZoom();
                            fr.Set_FramePadding();
                            fr.SetfrmDimensionZoom();
                        }
                    }
                }
                else if (wndr_objects.Name.Contains("Concrete"))
                {
                    foreach (IConcreteModel cr in lst_concrete)
                    {
                        if (wndr_objects.Name == cr.Concrete_Name)
                        {
                            cr.Concrete_Zoom = WD_zoom;
                            cr.Set_DimensionsToBind_using_ConcreteZoom();
                            cr.Set_ImagerDimensions_using_ImagerZoom();
                        }
                    }
                }
            }
        }
        public void SetZoom()
        {
            foreach (Control wndr_objects in lst_objects)
            {
                if (wndr_objects.Name.Contains("Frame"))
                {
                    foreach (IFrameModel fr in lst_frame)
                    {
                        if (wndr_objects.Name == fr.Frame_Name)
                        {
                            fr.Frame_Zoom = WD_zoom;
                            fr.Set_DimensionsToBind_using_FrameZoom();
                            fr.Set_FramePadding();
                            fr.SetZoom();
                        }
                    }
                }
                else if (wndr_objects.Name.Contains("Concrete"))
                {
                    foreach (IConcreteModel cr in lst_concrete)
                    {
                        if (wndr_objects.Name == cr.Concrete_Name)
                        {
                            cr.Concrete_Zoom = WD_zoom;
                            cr.Set_DimensionsToBind_using_ConcreteZoom();
                            cr.Set_ImagerDimensions_using_ImagerZoom();
                        }
                    }
                }
            }
        }
        public void SetPanelGlassID()
        {
            int i = 1;
            //foreach (IFrameModel fr in lst_frame)
            //{
            //    foreach (var wndrObject in fr.Lst_MultiPanel[0].ls)

            //        foreach (IPanelModel pnl in fr.Lst_Panel)
            //        {
            //            pnl.PanelGlass_ID = i;
            //            i++;
            //            //if (i == PanelGlassID_Counter)
            //            //{
            //            //    break;
            //            //}
            //        }
            //    foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
            //    {
            //        foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
            //        {

            //            pnl.PanelGlass_ID = i;
            //            i++;
            //            //if (i == PanelGlassID_Counter)
            //            //{
            //            //    break;
            //            //}
            //        }
            //        //if (i == PanelGlassID_Counter)
            //        //{
            //        //    break;
            //        //}
            //    }
            //    //if (i == PanelGlassID_Counter)
            //    //{
            //    //    break;
            //    //}
            //}


            foreach (IFrameModel frm in lst_frame)
            {
                #region  Frame Panel
                foreach (IPanelModel pnl in frm.Lst_Panel)
                {
                    pnl.PanelGlass_ID = i;
                    i++;
                }
                if (frm.Lst_MultiPanel.Count > 0)
                {

                    foreach (Control ctrl in frm.Lst_MultiPanel[0].MPanelLst_Objects)
                    {
                        if (ctrl.Name.Contains("PanelUC"))
                        {
                            foreach (IPanelModel pnl in frm.Lst_MultiPanel[0].MPanelLst_Panel)
                            {
                                if (ctrl.Name == pnl.Panel_Name)
                                {
                                    pnl.PanelGlass_ID = i;
                                    i++;
                                }
                            }

                        }
                        else if (ctrl.Name.Contains("MultiTransom") || ctrl.Name.Contains("MultiMullion"))
                        {

                            foreach (IMultiPanelModel thirdlvlmpnl in frm.Lst_MultiPanel[0].MPanelLst_MultiPanel)
                            {
                                if (thirdlvlmpnl.MPanel_Name == ctrl.Name)
                                {
                                    foreach (Control thirdlvlctrl in thirdlvlmpnl.MPanelLst_Objects)
                                    {
                                        if (thirdlvlctrl.Name.Contains("PanelUC"))
                                        {
                                            foreach (IPanelModel pnl in thirdlvlmpnl.MPanelLst_Panel)
                                            {
                                                if (thirdlvlctrl.Name == pnl.Panel_Name)
                                                {
                                                    pnl.PanelGlass_ID = i;
                                                    i++;

                                                }
                                            }
                                        }
                                        else if (thirdlvlctrl.Name.Contains("MultiTransom") || thirdlvlctrl.Name.Contains("MultiMullion"))
                                        {
                                            foreach (IMultiPanelModel fourthlvlmpnl in thirdlvlmpnl.MPanelLst_MultiPanel)
                                            {
                                                foreach (IPanelModel pnl in fourthlvlmpnl.MPanelLst_Panel)
                                                {
                                                    pnl.PanelGlass_ID = i;
                                                    i++;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
        }

        public void SetMiddleCloser_onPanel()
        {
            MiddleCloser_ArticleNo midArt = MiddleCloser_ArticleNo._None;
            if (WD_BaseColor == Base_Color._DarkBrown)
            {
                midArt = MiddleCloser_ArticleNo._1WC70DB;
            }
            else if (WD_BaseColor == Base_Color._White ||
                     WD_BaseColor == Base_Color._Ivory)
            {
                midArt = MiddleCloser_ArticleNo._1WC70WHT;
            }

            foreach (IFrameModel fr in lst_frame)
            {
                foreach (IPanelModel pnl in fr.Lst_Panel)
                {
                    pnl.Panel_MiddleCloserArtNo = midArt;
                }
                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {
                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                    {
                        pnl.Panel_MiddleCloserArtNo = midArt;
                    }
                }
            }
        }

        public void Fit_MyControls_ToBindDimensions()
        {
            int occupiedWidth = 0,
                occupiedHeight = 0,
                Maxheight = 0,
                availableWidth = WD_width,
                availableHeight = WD_height;
            if (lst_objects.Count > 1)
            {
                var startingObject = lst_objects[0];
                startingObject = null;
                foreach (var wndrObject in lst_objects)
                {
                    foreach (IFrameModel frm in lst_frame)
                    {
                        if (wndrObject.Name == frm.Frame_Name)
                        {
                            if (availableWidth > frm.Frame_Width)
                            {
                                if (startingObject == null)
                                {
                                    startingObject = wndrObject;
                                }
                                if (availableHeight >= frm.Frame_Height)
                                {
                                    occupiedWidth += frm.Frame_Width;
                                    if (Maxheight < frm.Frame_Height)
                                    {
                                        Maxheight = frm.Frame_Height;
                                    }
                                }
                                else
                                {
                                }
                            }
                            else if (availableWidth == frm.Frame_Width)
                            {
                                Fit_MyObject_ToBindDimensions(startingObject, wndrObject);
                                occupiedWidth += frm.Frame_Width;
                                if (Maxheight < frm.Frame_Height)
                                {
                                    Maxheight = frm.Frame_Height;
                                }
                                startingObject = null;
                            }
                            if (occupiedWidth >= WD_width)
                            {
                                occupiedHeight += Maxheight;
                                occupiedWidth = 0;
                                availableWidth = WD_width;
                                availableHeight -= Maxheight;
                            }
                            else
                            {
                                availableWidth -= frm.Frame_Width;
                            }
                        }
                    }
                    foreach (IConcreteModel crtm in lst_concrete)
                    {
                        if (wndrObject.Name == crtm.Concrete_Name)
                        {
                            if (availableWidth > crtm.Concrete_Width)
                            {
                                if (startingObject == null)
                                {
                                    startingObject = wndrObject;
                                }
                                if (availableHeight >= crtm.Concrete_Height)
                                {
                                    occupiedWidth += crtm.Concrete_Width;
                                    if (Maxheight < crtm.Concrete_Height)
                                    {
                                        Maxheight = crtm.Concrete_Height;
                                    }
                                }
                                else
                                {
                                }
                            }
                            else if (availableWidth == crtm.Concrete_Width)
                            {
                                if (startingObject == null)
                                {
                                    startingObject = wndrObject;
                                }
                                Fit_MyObject_ToBindDimensions(startingObject, wndrObject);
                                occupiedWidth += crtm.Concrete_Width;
                                if (Maxheight < crtm.Concrete_Height)
                                {
                                    Maxheight = crtm.Concrete_Height;
                                }
                                startingObject = null;
                            }
                            if (occupiedWidth >= WD_width)
                            {
                                occupiedHeight += Maxheight;
                                occupiedWidth = 0;
                                availableWidth = WD_width;
                                availableHeight -= Maxheight;
                            }
                            else
                            {
                                availableWidth -= crtm.Concrete_Width;
                            }
                        }

                    }
                }
            }
        }

        private void Fit_MyObject_ToBindDimensions(Control startingObject, Control lastObject)
        {
            int objectWidth = 0;
            bool isLoad = false;
            foreach (var wndrObject in lst_objects)
            {
                if (startingObject == wndrObject)
                {
                    isLoad = true;
                }
                if (isLoad == true)
                {

                    foreach (IFrameModel frm in lst_frame)
                    {
                        if (wndrObject.Name == frm.Frame_Name)
                        {
                            objectWidth += frm.Frame_WidthToBind;
                        }
                    }
                    foreach (IConcreteModel crtm in lst_concrete)
                    {
                        if (wndrObject.Name == crtm.Concrete_Name)
                        {
                            objectWidth += crtm.Concrete_WidthToBind;
                        }
                    }
                }
                if (lastObject == wndrObject)
                {
                    break;
                }
            }

            int diff_BasePlatform_VS_MyCtrlsWidth = objectWidth - (WD_width_4basePlatform - 70);
            if (diff_BasePlatform_VS_MyCtrlsWidth > 0)
                WD_width_4basePlatform += diff_BasePlatform_VS_MyCtrlsWidth;
        }

        public void Fit_MyControls_ImagersToBindDimensions()
        {
            int occupiedWidth = 0,
                occupiedHeight = 0,
                Maxheight = 0,
                availableWidth = WD_width,
                availableHeight = WD_height;
            if (lst_objects.Count > 1)
            {
                var startingObject = lst_objects[0];
                startingObject = null;
                foreach (var wndrObject in lst_objects)
                {
                    foreach (IFrameModel frm in lst_frame)
                    {
                        if (wndrObject.Name == frm.Frame_Name)
                        {
                            if (availableWidth > frm.Frame_Width)
                            {
                                if (startingObject == null)
                                {
                                    startingObject = wndrObject;
                                }
                                if (availableHeight >= frm.Frame_Height)
                                {
                                    occupiedWidth += frm.Frame_Width;
                                    if (Maxheight < frm.Frame_Height)
                                    {
                                        Maxheight = frm.Frame_Height;
                                    }
                                }
                                else
                                {
                                }
                            }
                            else if (availableWidth == frm.Frame_Width)
                            {
                                Fit_MyImagerObject_ToBindDimensions(startingObject, wndrObject);
                                occupiedWidth += frm.Frame_Width;
                                if (Maxheight < frm.Frame_Height)
                                {
                                    Maxheight = frm.Frame_Height;
                                }
                                startingObject = null;
                            }
                            if (occupiedWidth >= WD_width)
                            {
                                occupiedHeight += Maxheight;
                                occupiedWidth = 0;
                                availableWidth = WD_width;
                                availableHeight -= Maxheight;
                            }
                            else
                            {
                                availableWidth -= frm.Frame_Width;
                            }
                        }
                    }
                    foreach (IConcreteModel crtm in lst_concrete)
                    {
                        if (wndrObject.Name == crtm.Concrete_Name)
                        {
                            if (availableWidth > crtm.Concrete_Width)
                            {
                                if (startingObject == null)
                                {
                                    startingObject = wndrObject;
                                }
                                if (availableHeight >= crtm.Concrete_Height)
                                {
                                    occupiedWidth += crtm.Concrete_Width;
                                    if (Maxheight < crtm.Concrete_Height)
                                    {
                                        Maxheight = crtm.Concrete_Height;
                                    }
                                }
                                else
                                {
                                }
                            }
                            else if (availableWidth == crtm.Concrete_Width)
                            {
                                if (startingObject == null)
                                {
                                    startingObject = wndrObject;
                                }
                                Fit_MyImagerObject_ToBindDimensions(startingObject, wndrObject);
                                occupiedWidth += crtm.Concrete_Width;
                                if (Maxheight < crtm.Concrete_Height)
                                {
                                    Maxheight = crtm.Concrete_Height;
                                }
                                startingObject = null;
                            }
                            if (occupiedWidth >= WD_width)
                            {
                                occupiedHeight += Maxheight;
                                occupiedWidth = 0;
                                availableWidth = WD_width;
                                availableHeight -= Maxheight;
                            }
                            else
                            {
                                availableWidth -= crtm.Concrete_Width;
                            }
                        }

                    }
                }
            }
        }

        private void Fit_MyImagerObject_ToBindDimensions(Control startingObject, Control lastObject)
        {
            int objectWidth = 0;
            bool isLoad = false;
            foreach (var wndrObject in lst_objects)
            {
                if (startingObject == wndrObject)
                {
                    isLoad = true;
                }
                if (isLoad == true)
                {

                    foreach (IFrameModel frm in lst_frame)
                    {
                        if (wndrObject.Name == frm.Frame_Name)
                        {
                            objectWidth += frm.FrameImageRenderer_Width;
                        }
                    }
                    foreach (IConcreteModel crtm in lst_concrete)
                    {
                        if (wndrObject.Name == crtm.Concrete_Name)
                        {
                            objectWidth += crtm.Concrete_ImagerWidthToBind;
                        }
                    }
                }
                if (lastObject == wndrObject)
                {
                    break;
                }
            }

            int diff_BasePlatform_VS_MyCtrlsWidth = objectWidth - (WD_width_4basePlatform_forImageRenderer - 70);
            if (diff_BasePlatform_VS_MyCtrlsWidth > 0)
                WD_width_4basePlatform_forImageRenderer += diff_BasePlatform_VS_MyCtrlsWidth;
        }

        #endregion

        public WindoorModel(int wd_id,
                            string wd_name,
                            string wd_description,
                            int wd_width,
                            int wd_height,
                            decimal wd_price,
                            int wd_quantity,
                            decimal wd_discount,
                            string wd_itemName,
                            string wd_windoorNumber,
                            bool wd_visibility,
                            bool wd_orientation,
                            //float wd_zoom,
                            string wd_Profile,
                            List<IFrameModel> wdlstframe,
                            List<IConcreteModel> wdlstconcrete,
                            List<Control> wdlstobjects,
                            Base_Color wd_basecolor,
                            Foil_Color wd_insidecolor,
                            Foil_Color wd_outisdecolor,
                            bool isFromLoad,
                            List<string> lst_totalPriceHistory,
                            decimal systemSuggestedPrice
                            //int wd_costingPoints
                            )
        {
            WD_id = wd_id;
            WD_name = wd_name;
            WD_description = wd_description;
            WD_width = wd_width;
            WD_height = wd_height;
            WD_price = wd_price;
            WD_quantity = wd_quantity;
            WD_discount = wd_discount;
            WD_WindoorNumber = wd_windoorNumber;
            WD_itemName = wd_itemName;
            WD_visibility = wd_visibility;
            WD_orientation = wd_orientation;
            //WD_zoom = wd_zoom;
            WD_profile = wd_Profile;
            lst_frame = wdlstframe;
            lst_concrete = wdlstconcrete;
            lst_objects = wdlstobjects;
            WD_BaseColor = wd_basecolor;
            WD_InsideColor = wd_insidecolor;
            WD_OutsideColor = wd_outisdecolor;
            //WD_CostingPoints = wd_costingPoints;
            WD_CmenuDeleteVisibility = true;
            WD_customArrowToggle = false;
            WD_fileLoad = false;
            Dictionary_wd_redArrowLines = new Dictionary<int, decimal>();
            Dictionary_ht_redArrowLines = new Dictionary<int, decimal>();
            IsFromLoad = isFromLoad;
            lst_TotalPriceHistory = lst_totalPriceHistory;
            SystemSuggestedPrice = systemSuggestedPrice;
        }
    }
}
