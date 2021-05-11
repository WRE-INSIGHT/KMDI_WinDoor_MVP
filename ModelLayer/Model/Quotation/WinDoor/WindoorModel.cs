using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ModelLayer.Model.Quotation.Frame;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;

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
                WD_Dimension = value.ToString() + " x " + WD_height.ToString();
                WD_width_4basePlatform_forImageRenderer = value + 70;
                WD_zoom_forImageRenderer = GetZoom_forRendering();

                WD_width_4basePlatform = value + 70; //(int)(value * WD_zoom) + 70;
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
            get {
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
        [Range(0.1, 200.0, ErrorMessage = "Please enter a zoom value bigger than or equal to {1}")]
        public float WD_zoom
        {
            get
            {
                return _wdZoom;
            }
            set
            {
                _wdZoom = value;
                WD_width_4basePlatform = (int)((WD_width * value) + 70);
                WD_height_4basePlatform = (int)((WD_height * value) + 35);
                SetZoom();
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

        public List<IFrameModel> lst_frame { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<IFrameModel> GetAllVisibleFrames()
        {
            return lst_frame.Where(frame => frame.Frame_Visible == true);
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

        public float GetZoom_forRendering()
        {
            int area = _wdHeight * _wdWidth;
            float zm = 1.0f;

            //if (area <= 1500000)
            //{
            //    zm = 1.00f;
            //}
            //else if (area > 1500000 && area <= 2500000)
            //{
            //    zm = 0.50f;
            //}
            //else if (area > 2500000)
            //{
            //    zm = 0.28f;
            //}

            if (area <= 360000)
            {
                zm = _arr_zoomPercentage[5];
            }
            else if (area > 360000 && area <= 1000000)
            {
                zm = _arr_zoomPercentage[4];
            }
            else if (area > 1000000 && area <= 4000000)
            {
                zm = _arr_zoomPercentage[3];
            }
            else if (area > 4000000 && area <= 9000000)
            {
                zm = _arr_zoomPercentage[2];
            }
            else if (area > 9000000 && area <= 16000000)
            {
                zm = _arr_zoomPercentage[1];
            }
            else if (area > 16000000)
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

        private void SetZoom()
        {
            if (lst_frame != null)
            {
                foreach (IFrameModel fr in lst_frame.Where(fr => fr.Frame_Visible == true))
                {
                    fr.Frame_Zoom = WD_zoom;
                }
            }
        }
    }
}
