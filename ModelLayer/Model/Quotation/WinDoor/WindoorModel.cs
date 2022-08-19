﻿using ModelLayer.Model.Quotation.Concrete;
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
        private int _wdPropertiesScroll;
        public int WD_PropertiesScroll
        {
            get
            {
                return _wdPropertiesScroll;
            }

            set
            {
                _wdPropertiesScroll = value;
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

        private float _wdZoom;
        [Required(ErrorMessage = "Zoom value is Required")]
        [Range(0.1, 100.0, ErrorMessage = "Please enter a zoom value bigger than or equal to {1}")]
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

        private int _wdPrice;
        [Required(ErrorMessage = "Window Price is Required")]
        public int WD_price
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


        public List<IFrameModel> lst_frame { get; set; }
        public List<IConcreteModel> lst_concrete { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private float[] _arr_zoomPercentage = { 0.10f, 0.13f, 0.17f, 0.26f, 0.50f, 1.0f };
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

        public Base_Color WD_BaseColor { get; set; }
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
        #region Methods

        public void SetDimensions_basePlatform()
        {
            decimal wd_flt_convert_dec = Convert.ToDecimal(WD_width * WD_zoom);
            decimal base_wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            WD_width_4basePlatform = Convert.ToInt32(base_wd_dec) + 70;

            decimal ht_flt_convert_dec = Convert.ToDecimal(WD_height * WD_zoom);
            decimal base_ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            WD_height_4basePlatform = Convert.ToInt32(base_ht_dec) + 35;
        }

        public float GetZoom_forRendering()
        {
            int area = _wdHeight * _wdWidth;
            float zm = 1.0f;

            if (area <= 360000) //400w x 400h to 600w x 600h
            {
                zm = _arr_zoomPercentage[5];
            }
            else if (area > 360000 && area <= 1000000) //(600w x 601h / 601w x 600h) to 1000w x 1000h
            {
                zm = _arr_zoomPercentage[4];
            }
            else if (area > 1000000 && area <= 4000000) // (1000w x 1001h / 1001w x 1000h) to 2000w x 2000h
            {
                zm = _arr_zoomPercentage[3];
            }
            else if (area > 4000000 && area <= 9000000) // (2000w x 2001h / 2001w x 2000h) to 3000w x 3000h
            {
                zm = _arr_zoomPercentage[2];
            }
            else if (area > 9000000 && area <= 16000000) // (3000w x 3001h / 3001w x 3000h) to 4000w x 4000h
            {
                zm = _arr_zoomPercentage[1];
            }
            else if (area > 16000000) // more than (4000w x 4001h / 4001w x 4000h)
            {
                zm = _arr_zoomPercentage[0];
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
                    foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                    {
                        mpnl.MPanelImageRenderer_Zoom = WD_zoom_forImageRenderer;
                    }
                }
            }
        }

        public void SetZoom()
        {
            if (lst_frame != null)
            {
                foreach (IFrameModel fr in lst_frame)
                {
                    fr.Frame_Zoom = WD_zoom;
                    fr.Set_DimensionsToBind_using_FrameZoom();
                    fr.Set_FramePadding();
                    fr.SetZoom();
                }
            }
        }

        public void SetPanelGlassID()
        {
            int i = 0;
            foreach (IFrameModel fr in lst_frame)
            {
                foreach (IPanelModel pnl in fr.Lst_Panel)
                {
                    pnl.PanelGlass_ID = i;
                    i++;
                    if (i == PanelGlassID_Counter)
                    {
                        break;
                    }
                }
                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {
                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                    {
                        i++;
                        pnl.PanelGlass_ID = i;
                        if (i == PanelGlassID_Counter)
                        {
                            break;
                        }
                    }
                    if (i == PanelGlassID_Counter)
                    {
                        break;
                    }
                }
                if (i == PanelGlassID_Counter)
                {
                    break;
                }
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

        #endregion

        public WindoorModel(int wd_id,
                            string wd_name,
                            string wd_description,
                            int wd_width,
                            int wd_height,
                            int wd_price,
                            int wd_quantity,
                            decimal wd_discount,
                            bool wd_visibility,
                            bool wd_orientation,
                            //float wd_zoom,
                            string wd_Profile,
                            List<IFrameModel> wdlstframe,
                            List<IConcreteModel> wdlstconcrete,
                            Base_Color wd_basecolor,
                            Foil_Color wd_insidecolor,
                            Foil_Color wd_outisdecolor,
                            int wd_costingPoints)
        {
            WD_id = wd_id;
            WD_name = wd_name;
            WD_description = wd_description;
            WD_width = wd_width;
            WD_height = wd_height;
            WD_price = wd_price;
            WD_quantity = wd_quantity;
            WD_discount = wd_discount;
            WD_visibility = wd_visibility;
            WD_orientation = wd_orientation;
            //WD_zoom = wd_zoom;
            WD_profile = wd_Profile;
            lst_frame = wdlstframe;
            lst_concrete = wdlstconcrete;
            WD_BaseColor = wd_basecolor;
            WD_InsideColor = wd_insidecolor;
            WD_OutsideColor = wd_outisdecolor;
            WD_CostingPoints = wd_costingPoints;
            WD_CmenuDeleteVisibility = true;
            WD_customArrowToggle = false;
            Dictionary_wd_redArrowLines = new Dictionary<int, decimal>();
            Dictionary_ht_redArrowLines = new Dictionary<int, decimal>();
            WD_PropertiesScroll = 0;
        }
    }
}
