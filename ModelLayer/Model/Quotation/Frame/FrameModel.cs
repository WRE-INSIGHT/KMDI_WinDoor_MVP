using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Frame
{
    public class FrameModel : IFrameModel, INotifyPropertyChanged
    {
        private int _frameHeight;
        [Required(ErrorMessage = "Frame_Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Height bigger than or equal {1}")]
        public int Frame_Height
        {
            get { return _frameHeight; }
            set
            {
                _frameHeight = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameWidth;
        [Required(ErrorMessage = "Frame_Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Width bigger than or equal {1}")]
        public int Frame_Width
        {
            get { return _frameWidth; }
            set
            {
                _frameWidth = value;
                NotifyPropertyChanged();
            }
        }

        public enum Frame_Padding
        {
            Window = 26,
            Door = 32
        }

        private static int _frame_basicDeduction = 10;
        public int Frame_BasicDeduction
        {
            get
            {
                return _frame_basicDeduction;
            }
        }

        private ConstantVariables constants = new ConstantVariables();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private int _frameID;
        [Required(ErrorMessage = "Frame_ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value for Frame ID bigger than or equal {1}")]
        public int Frame_ID { get; set; }

        private string _frameName;
        public string Frame_Name
        {
            get { return _frameName; }
            set { _frameName = value; NotifyPropertyChanged(); }
        }


        private int _frameWidth_toBind;
        public int Frame_WidthToBind
        {
            get
            {
                return _frameWidth_toBind;
            }
            set
            {
                _frameWidth_toBind = value;
                NotifyPropertyChanged();
            }
        }


        private int _frameHeight_toBind;
        public int Frame_HeightToBind
        {
            get
            {
                return _frameHeight_toBind;
            }
            set
            {
                _frameHeight_toBind = value;
                NotifyPropertyChanged();
            }
        }

        private int[] _arr_padding_norm = { 26, 33, 13, 15, 08, 10, 05, 07 }; //even index means window, odd index means door
        private int[] _arr_padding_withmpnl = { 16, 23, 08, 12, 05, 07, 03, 06 }; //even index means window, odd index means door

        public int[] Arr_padding_norm
        {
            get
            {
                return _arr_padding_norm;
            }
        }

        public int[] Arr_padding_withmpnl
        {
            get
            {
                return _arr_padding_withmpnl;
            }
        }

        private Frame_Padding _frameType;
        public Frame_Padding Frame_Type
        {
            get { return _frameType; }
            set
            {
                _frameType = value;

                if (_deductFramePadding_bool)
                {
                    FramePadding_Deduct();
                }
                else
                {
                    FramePadding_Default();
                    FrameImageRendererPadding_Default();
                }
                NotifyPropertyChanged();
            }
        }

        private bool _frameVisible;
        public bool Frame_Visible
        {
            get { return _frameVisible; }
            set { _frameVisible = value; }
            //NotifyPropertyChanged(); }
        }

        private Padding _framePadding;
        public Padding Frame_Padding_int
        {
            get { return _framePadding; }
            set
            {
                if (value.All == 1)
                {
                    _framePadding = new Padding(2);
                }
                else
                {
                    _framePadding = value;
                }
                NotifyPropertyChanged();
            }
        }

        private Padding _frameImagePadding;
        public Padding FrameImageRenderer_Padding_int
        {
            get { return _frameImagePadding; }
            set { _frameImagePadding = value; NotifyPropertyChanged(); }
        }

        private int _framePropHeight;
        public int FrameProp_Height
        {
            get { return _framePropHeight; }
            set { _framePropHeight = value; NotifyPropertyChanged(); }
        }

        public List<IPanelModel> Lst_Panel { get; set; } // count will always be 1 or 0 (if child is panel or not)
        public List<IMultiPanelModel> Lst_MultiPanel { get; set; }
        public List<IDividerModel> Lst_Divider { get; set; }

        private int _frameImage_Height;
        public int FrameImageRenderer_Height
        {
            get
            {
                return _frameImage_Height;
            }

            set
            {
                _frameImage_Height = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameImage_Width;
        public int FrameImageRenderer_Width
        {
            get
            {
                return _frameImage_Width;
            }

            set
            {
                _frameImage_Width = value;
                NotifyPropertyChanged();
            }
        }

        private float _frameImage_Zoom;
        public float FrameImageRenderer_Zoom
        {
            get
            {
                return _frameImage_Zoom;
            }

            set
            {
                _frameImage_Zoom = value;
                FrameImageRenderer_Width = Convert.ToInt32(Frame_Width * value);
                FrameImageRenderer_Height = Convert.ToInt32(Frame_Height * value);
                NotifyPropertyChanged();
            }
        }

        private float _frameZoom;
        public float Frame_Zoom
        {
            get
            {
                return _frameZoom;
            }

            set
            {
                _frameZoom = value;
            }
        }

        public IWindoorModel Frame_WindoorModel { get; set; }


        private UserControl _frameUC;
        public UserControl Frame_UC
        {
            get
            {
                return _frameUC;
            }

            set
            {
                _frameUC = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _framePropertiesUC;
        public UserControl Frame_PropertiesUC
        {
            get
            {
                return _framePropertiesUC;
            }
            set
            {
                _framePropertiesUC = value;
                NotifyPropertyChanged();
            }
        }

        
        #region Method


        public void SetfrmDimensionZoom()
        {
            foreach (IMultiPanelModel mpnl in Lst_MultiPanel)
            {
                mpnl.MPanel_Zoom = Frame_Zoom;
                if (Lst_MultiPanel[0] == mpnl)
                {
                    mpnl.Set_DimensionToBind_using_FrameDimensions();
                    mpnl.Imager_Set_DimensionToBind_using_FrameDimensions();
                }
                else
                {
                    mpnl.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();

                }

                mpnl.SetZoomPanels();
                mpnl.SetZoomDivider();
                mpnl.SetZoomMPanels();
                mpnl.Reload_PanelMargin();


                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                {
                    pnl.Panel_Zoom = Frame_Zoom;
                    pnl.PanelImageRenderer_Zoom = FrameImageRenderer_Zoom;
                    if (/*Frame_Zoom == 0.17f || Frame_Zoom == 0.26f ||
                        Frame_Zoom == 0.13f || Frame_Zoom == 0.10f*/Frame_Zoom >= 0.01f && Frame_Zoom <= 0.26f)
                    {
                        pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        pnl.Imager_SetDimensionsToBind_using_ZoomPercentage();
                    }
                    else
                    {
                        pnl.SetDimensionToBind_using_BaseDimension();
                        pnl.Imager_SetDimensionsToBind_using_ZoomPercentage();
                    }
                }
                foreach (IDividerModel div in mpnl.MPanelLst_Divider)
                {
                    div.Div_Zoom = Frame_Zoom;
                    div.DivImageRenderer_Zoom = FrameImageRenderer_Zoom;
                    div.SetDimensionsToBind_using_DivZoom();
                    div.SetDimensionsToBind_using_DivZoom_Imager();
                }
                mpnl.Fit_MyControls_ToBindDimensions();
                mpnl.Fit_MyControls_ImagersToBindDimensions();

            }

            foreach (IPanelModel pnl in Lst_Panel)
            {
                pnl.Panel_Zoom = Frame_Zoom;
                if (/*Frame_Zoom == 0.17f || Frame_Zoom == 0.26f ||
                    Frame_Zoom == 0.13f || Frame_Zoom == 0.10f*/Frame_Zoom >= 0.01f && Frame_Zoom <= 0.26f)
                {
                    pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                }
                else
                {
                    pnl.SetDimensionToBind_using_BaseDimension();
                }
                pnl.Imager_SetDimensionsToBind_FrameParent();


            }
        }





        public void SetZoom()
        {
            foreach (IMultiPanelModel mpnl in Lst_MultiPanel)
            {
                mpnl.MPanel_Zoom = Frame_Zoom;
                mpnl.Set_DimensionToBind_using_FrameDimensions();
                mpnl.SetZoomPanels();
                mpnl.SetZoomDivider();
                mpnl.SetZoomMPanels();
                mpnl.Reload_PanelMargin();
                mpnl.Fit_MyControls_ToBindDimensions();
                //mpnl.Fit_EqualPanel_ToBindDimensions();
                //mpnl.Fit_My2ndLvlControls_Dimensions();
            }

            foreach (IPanelModel pnl in Lst_Panel)
            {
                pnl.Panel_Zoom = Frame_Zoom;
                if (pnl.Panel_ParentMultiPanelModel != null)
                {
                    if (/*Frame_Zoom == 0.17f || Frame_Zoom == 0.26f ||
                        Frame_Zoom == 0.13f || Frame_Zoom == 0.10f*/Frame_Zoom >= 0.01f && Frame_Zoom <= 0.26f)
                    {
                        pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                    }
                    else
                    {
                        pnl.SetDimensionToBind_using_BaseDimension();
                    }
                }
                else
                {
                    pnl.Imager_SetDimensionsToBind_FrameParent();

                }

                pnl.SetPanelMargin_using_ZoomPercentage();
                pnl.SetPanelMarginImager_using_ImageZoomPercentage();
            }
        }

        public void Set_DimensionsToBind_using_FrameZoom()
        {
            decimal wd_flt_convert_dec = Convert.ToDecimal(Frame_Width * Frame_Zoom);
            //decimal frame_wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            decimal frame_wd_dec = decimal.Round(wd_flt_convert_dec, 0, MidpointRounding.AwayFromZero);
            Frame_WidthToBind = Convert.ToInt32(frame_wd_dec);
            decimal ht_flt_convert_dec = Convert.ToDecimal(Frame_Height * Frame_Zoom);
            //decimal frame_ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            decimal frame_ht_dec = decimal.Round(ht_flt_convert_dec, 0, MidpointRounding.AwayFromZero);
            Frame_HeightToBind = Convert.ToInt32(frame_ht_dec);
        }

        public void Set_ImagerDimensions_using_ImagerZoom()
        {
            FrameImageRenderer_Width = Convert.ToInt32(Frame_Width * FrameImageRenderer_Zoom);
            FrameImageRenderer_Height = Convert.ToInt32(Frame_Height * FrameImageRenderer_Zoom);
        }

        public void Set_FramePadding()
        {
            if (_deductFramePadding_bool)
            {
                FramePadding_Deduct();
            }
            else
            {
                FramePadding_Default();
                FrameImageRendererPadding_Default();
            }
        }

        private int _frameDeduction = 0;
        public int Frame_Deduction
        {
            get
            {
                return _frameDeduction;
            }
        }

        private void FramePadding_Deduct()
        {
            _frameDeduction = (int)(_frame_basicDeduction * Frame_Zoom);
            if (/*Frame_Zoom == 0.26f || Frame_Zoom == 0.17f ||
                Frame_Zoom == 0.13f || Frame_Zoom == 0.10f*/Frame_Zoom >= 0.01f && Frame_Zoom <= 0.26f)
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    Frame_Padding_int = new Padding(10);
                    if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                    {
                        Frame_Padding_int = new Padding(8);
                    }
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                        Frame_BotFrameArtNo == BottomFrameTypes._6052)
                    {
                        Frame_Padding_int = new Padding(10);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._6050)
                    {
                        Frame_Padding_int = new Padding(10, 10, 10, 5);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        Frame_Padding_int = new Padding(10, 10, 10, 0);
                    }
                }
            }
            else
            {
                int default_pads = (int)((int)Frame_Type * Frame_Zoom) - _frameDeduction;
                if (Frame_Type == Frame_Padding.Window)
                {
                    Frame_Padding_int = new Padding(default_pads);
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                        Frame_BotFrameArtNo == BottomFrameTypes._6052)
                    {
                        Frame_Padding_int = new Padding(default_pads);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._6050)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        (int)((int)26 * Frame_Zoom) - _frameDeduction);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        0);
                    }
                }
            }
        }

        private void FrameImageRendererPadding_Default()
        {
            if (/*FrameImageRenderer_Zoom == 0.26f || FrameImageRenderer_Zoom == 0.17f ||
                FrameImageRenderer_Zoom == 0.13f || FrameImageRenderer_Zoom == 0.10f*/Frame_Zoom >= 0.01f && Frame_Zoom <= 0.26f)
            {
                if (_is_MPanel) // meaning MPanel
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        FrameImageRenderer_Padding_int = new Padding(15);
                       if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                       {
                            FrameImageRenderer_Padding_int = new Padding(12);
                       }
                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                        
                        if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                            Frame_BotFrameArtNo == BottomFrameTypes._6052)
                        {
                            FrameImageRenderer_Padding_int = new Padding(20);
                            if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                            {
                                FrameImageRenderer_Padding_int = new Padding(15);
                            }
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._6050)
                        {
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 15);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 0);
                        }
                    }
                }
                else if (!_is_MPanel) // meaning Panel
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        FrameImageRenderer_Padding_int = new Padding(15);
                        if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                        {
                           FrameImageRenderer_Padding_int = new Padding(12);
                        }
                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                       
                        if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                            Frame_BotFrameArtNo == BottomFrameTypes._6052)
                        {
                            FrameImageRenderer_Padding_int = new Padding(20);
                            if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                            {
                                FrameImageRenderer_Padding_int = new Padding(15);
                            }
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._6050)
                        {
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 15);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 0);
                        }
                    }
                }
            }
            else
            {
                int default_pads = (int)((int)Frame_Type * FrameImageRenderer_Zoom),
                    default_pads_imgr = (int)(((int)Frame_Type) * FrameImageRenderer_Zoom);
                if (Frame_Type == Frame_Padding.Window)
                {
                    FrameImageRenderer_Padding_int = new Padding(default_pads_imgr);
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                        Frame_BotFrameArtNo == BottomFrameTypes._6052)
                    {
                        FrameImageRenderer_Padding_int = new Padding(default_pads_imgr);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                              Frame_BotFrameArtNo == BottomFrameTypes._6050)
                    {
                        FrameImageRenderer_Padding_int = new Padding(default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     (int)(26 * FrameImageRenderer_Zoom));
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        FrameImageRenderer_Padding_int = new Padding(default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     0);
                    }
                }
            }
        }
        private void FramePadding_Default()
        {
            if (/*Frame_Zoom == 0.26f || Frame_Zoom == 0.17f ||
                Frame_Zoom == 0.13f || Frame_Zoom == 0.10f*/ Frame_Zoom >= 0.01f && Frame_Zoom <= 0.26f)
            {
                if (_is_MPanel) // meaning MPanel
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        Frame_Padding_int = new Padding(15);
                       
                        if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                        {
                            Frame_Padding_int = new Padding(12);
                        }

                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                       
                        if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                            Frame_BotFrameArtNo == BottomFrameTypes._6052)
                        {
                            Frame_Padding_int = new Padding(20);
                            if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                            {
                                Frame_Padding_int = new Padding(15);
                            }
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._6050)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 15);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 0);
                        }
                    }
                }
                else if (!_is_MPanel) // meaning Panel
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        Frame_Padding_int = new Padding(15);
                        if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                        {
                            Frame_Padding_int = new Padding(12);
                        }
                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                       
                        if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                            Frame_BotFrameArtNo == BottomFrameTypes._6052)
                        {
                            Frame_Padding_int = new Padding(20);
                            if (Frame_WindoorModel.WD_profile.Contains("Alutek"))
                            {
                                Frame_Padding_int = new Padding(15);
                            }
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._6050)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 15);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                 Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 0);
                        }
                    }
                }
            }
            else
            {
                int default_pads = (int)((int)Frame_Type * Frame_Zoom),
                    default_pads_imgr = (int)(((int)Frame_Type) * FrameImageRenderer_Zoom);
                if (Frame_Type == Frame_Padding.Window)
                {
                    Frame_Padding_int = new Padding(default_pads);
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                        Frame_BotFrameArtNo == BottomFrameTypes._6052)
                    {
                        Frame_Padding_int = new Padding(default_pads);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._6050)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        (int)(26 * Frame_Zoom));

                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        0);

                    }
                }
            }
        }
        private bool _deductFramePadding_bool, _is_MPanel;
        public void SetDeductFramePadding(bool mode, bool is_mpanel = true)
        {
            _deductFramePadding_bool = mode;
            _is_MPanel = is_mpanel;
            if (mode == true)
            {
                FramePadding_Deduct();
            }
            else if (mode == false)
            {
                FramePadding_Default();
                FrameImageRendererPadding_Default();
            }
        }

        #endregion

        #region Explosion

        private FrameProfile_ArticleNo _frameArtNo;
        public FrameProfile_ArticleNo Frame_ArtNo
        {
            get
            {
                return _frameArtNo;
            }
            set
            {
                _frameArtNo = value;

                if (value == FrameProfile_ArticleNo._7502)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._R676;
                }
                else if (value == FrameProfile_ArticleNo._7507)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._R677;
                }
                else if (value == FrameProfile_ArticleNo._2060)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._V226;
                }
                else if (value == FrameProfile_ArticleNo._6050)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._TV110;
                    Frame_ArtNoForPremi = FrameProfileForPremi_ArticleNo._6055;
                }
                else if (value == FrameProfile_ArticleNo._6052)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._TV107;
                    Frame_ArtNoForPremi = FrameProfileForPremi_ArticleNo._6052_milled;
                    Frame_ConnectingProfile_ArticleNo = ConnectingProfile_ArticleNo._0373;
                }
                else if (value == FrameProfile_ArticleNo._84100)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._None;
                }
                else if (value == FrameProfile_ArticleNo._84116)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._None;
                    Frame_BaseClipArtNo = BaseClip_ArticleNo._84811;
                }
                else if (value == FrameProfile_ArticleNo._84118)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._None;
                    Frame_BaseClipArtNo = BaseClip_ArticleNo._84811;
                }

                NotifyPropertyChanged();
            }
        }

        private FrameProfile_ArticleNo _frameArtNoForAlutek;
        public FrameProfile_ArticleNo Frame_ArtNoForAlutek //22
        {
            get
            {
                return _frameArtNoForAlutek;
            }
            set
            {
                _frameArtNoForAlutek = value;
                NotifyPropertyChanged();
            }
        }


        private FrameProfileForPremi_ArticleNo _frameArtNoForPremi;
        public FrameProfileForPremi_ArticleNo Frame_ArtNoForPremi
        {
            get
            {
                return _frameArtNoForPremi;
            }
            set
            {
                _frameArtNoForPremi = value;
                if (value == FrameProfileForPremi_ArticleNo._6055)
                {
                    Frame_ReinfForPremiArtNo = FrameReinfForPremi_ArticleNo._V115;
                }
                else if (value == FrameProfileForPremi_ArticleNo._6052_milled)
                {
                    Frame_ReinfForPremiArtNo = FrameReinfForPremi_ArticleNo._TV107;
                }


                NotifyPropertyChanged();
            }
        }
        public int Frame_ExplosionWidth { get; set; }
        public int Frame_ExplosionHeight { get; set; }

        private FrameReinf_ArticleNo _frameReinfArtNo;
        public FrameReinf_ArticleNo Frame_ReinfArtNo
        {
            get
            {
                return _frameReinfArtNo;
            }
            set
            {
                _frameReinfArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private FrameReinfForPremi_ArticleNo _frameReinfForPremiArtNo;
        public FrameReinfForPremi_ArticleNo Frame_ReinfForPremiArtNo
        {
            get
            {
                return _frameReinfForPremiArtNo;
            }
            set
            {
                _frameReinfForPremiArtNo = value;
                NotifyPropertyChanged();
            }
        }
        public int Frame_ReinfWidth { get; set; }
        public int Frame_ReinfHeight { get; set; }

        public bool Frame_ReinfWidthMorethan5800 { get; set; }

        private BaseClip_ArticleNo _frameBaseClipArtNo;
        public BaseClip_ArticleNo Frame_BaseClipArtNo
        {
            get
            {
                return _frameBaseClipArtNo;
            }

            set
            {
                _frameBaseClipArtNo = value;
                NotifyPropertyChanged();
            }
        } 

        private bool _frameCmenuDeleteVisibility;
        public bool Frame_CmenuDeleteVisibility
        {
            get
            {
                return _frameCmenuDeleteVisibility;
            }

            set
            {
                _frameCmenuDeleteVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public bool Frame_If_InwardMotorizedCasement { get; set; }
        public bool Frame_If_InwardMotorizedSliding { get; set; }
        public MilledFrame_ArticleNo Frame_MilledArtNo { get; set; }
        public MilledFrameReinf_ArticleNo Frame_MilledReinfArtNo { get; set; }

        //private Frame_MechJointArticleNo _frameMechJointArticleNo;
        //public Frame_MechJointArticleNo Frame_MechJointArticleNo
        //{
        //    get
        //    {
        //        return _frameMechJointArticleNo;
        //    }

        //    set
        //    {
        //        _frameMechJointArticleNo = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        private bool _frameTrackProfileArtNoVisibility;
        public bool Frame_TrackProfileArtNoVisibility
        {
            get
            {
                return _frameTrackProfileArtNoVisibility;
            }

            set
            {
                _frameTrackProfileArtNoVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private TrackProfile_ArticleNo _frameTrackProfileArtNo;
        public TrackProfile_ArticleNo Frame_TrackProfileArtNo
        {
            get
            {
                return _frameTrackProfileArtNo;
            }

            set
            {
                _frameTrackProfileArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private ConnectingProfile_ArticleNo _FrameConnectingProfile_ArticleNo;
        public ConnectingProfile_ArticleNo Frame_ConnectingProfile_ArticleNo
        {
            get
            {
                return _FrameConnectingProfile_ArticleNo;
            }

            set
            {
                _FrameConnectingProfile_ArticleNo = value;
                NotifyPropertyChanged();
            }
        }

        private MeshType _frameMeshType;
        public MeshType Frame_MeshType
        {
            get
            {
                return _frameMeshType;
            }

            set
            {
                _frameMeshType = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameScreenVisibility;
        public bool Frame_ScreenVisibility
        {
            get
            {
                return _frameScreenVisibility;
            }

            set
            {
                _frameScreenVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameScreenOption;
        public bool Frame_ScreenOption
        {
            get
            {
                return _frameScreenOption;
            }

            set
            {
                _frameScreenOption = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameScreenHeightOption;
        public bool Frame_ScreenHeightOption
        {
            get
            {
                return _frameScreenHeightOption;
            }

            set
            {
                _frameScreenHeightOption = value;

                if (value == true)
                {
                    Frame_ScreenFrameHeightEnable = true;
                    Frame_ScreenFrameHeight = Frame_Height;
                }
                else if (value == false)
                {
                    Frame_ScreenFrameHeightEnable = false;
                    Frame_ScreenFrameHeight = 0;
                }
                NotifyPropertyChanged();
            }
        }


        private bool _frameScreenHeightVisibility;
        public bool Frame_ScreenHeightVisibility
        {
            get
            {
                return _frameScreenHeightVisibility;
            }

            set
            {
                _frameScreenHeightVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameScreenFrameHeight;
        public int Frame_ScreenFrameHeight
        {
            get
            {
                return _frameScreenFrameHeight;
            }

            set
            {
                _frameScreenFrameHeight = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameScreenFrameHeightEnable;
        public bool Frame_ScreenFrameHeightEnable
        {
            get
            {
                return _frameScreenFrameHeightEnable;
            }

            set
            {
                _frameScreenFrameHeightEnable = value;
                NotifyPropertyChanged();
            }
        }

        private BottomFrameTypes _frameBotFrameArticleNo;
        public BottomFrameTypes Frame_BotFrameArtNo
        {
            get
            {
                return _frameBotFrameArticleNo;
            }
            set
            {
                _frameBotFrameArticleNo = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameBotFrameEnable;
        public bool Frame_BotFrameEnable
        {
            get
            {
                return _frameBotFrameEnable;
            }
            set
            {
                _frameBotFrameEnable = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameBotFrameVisible;
        public bool Frame_BotFrameVisible
        {
            get
            {
                return _frameBotFrameVisible;
            }
            set
            {
                _frameBotFrameVisible = value;
                NotifyPropertyChanged();
            }
        }

        private SealingElement_ArticleNo _frameSealingElementArticleNo;
        public SealingElement_ArticleNo Frame_SealingElement_ArticleNo

        {
            get
            {
                return _frameSealingElementArticleNo;
            }

            set
            {
                _frameSealingElementArticleNo = value;
                NotifyPropertyChanged();
            }
        }

        private Frame_MechJointArticleNo _frameMechanicalJointConnector_Artno;
        public Frame_MechJointArticleNo Frame_MechanicalJointConnector_Artno
        {
            get
            {
                return _frameMechanicalJointConnector_Artno;
            }
            set
            {
                _frameMechanicalJointConnector_Artno = value;
                NotifyPropertyChanged();
            }
        }

        public int Frame_MechanicalJointConnectorQty { get; set; }

        private int _frame_SlidingRailsQty;
        public int Frame_SlidingRailsQty
        {
            get
            {
                return _frame_SlidingRailsQty;
            }
            set
            {
                _frame_SlidingRailsQty = value;
                NotifyPropertyChanged();
            }
        }
        
        private bool _frame_SlidingRailsQtyVisibility;
        public bool Frame_SlidingRailsQtyVisibility
        {
            get
            {
                return _frame_SlidingRailsQtyVisibility;
            }
            set
            {
                _frame_SlidingRailsQtyVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private FrameConnectionType _frameConnectionType;
        public FrameConnectionType Frame_ConnectionType
        {
            get
            {
                return _frameConnectionType;
            }
            set
            {
                _frameConnectionType = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frame_connectionTypeVisibility;
        public bool Frame_ConnectionTypeVisibility
        {
            get
            {
                return _frame_connectionTypeVisibility;
            }
            set
            {
                _frame_connectionTypeVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameTubularVisibility;
        public bool Frame_TubularVisibility
        {
            get
            {
                return _frameTubularVisibility;
            }
            set
            {
                _frameTubularVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameTubularOption;
        public bool Frame_TubularOption
        {
            get
            {
                return _frameTubularOption;
            }
            set
            {
                _frameTubularOption = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameTubularWidthVisibility;
        public bool Frame_TubularWidthVisibility
        {
            get
            {
                return _frameTubularWidthVisibility;
            }
            set
            {
                _frameTubularWidthVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameTubularHeightVisibility;
        public bool Frame_TubularHeightVisibility
        {
            get
            {
                return _frameTubularHeightVisibility;
            }
            set
            {
                _frameTubularHeightVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameTubularHeight;
        public int Frame_TubularHeight
        {
            get
            {
                return _frameTubularHeight;
            }
            set
            {
                _frameTubularHeight = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameTubularWidth;
        public int Frame_TubularWidth
        {
            get
            {
                return _frameTubularWidth;
            }
            set
            {
                _frameTubularWidth = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameFoldAndSlideTopViewLeftCount;
        public int Frame_FoldAndSlideTopViewLeftCount
        {
            get
            {
                return _frameFoldAndSlideTopViewLeftCount;
            }
            set
            {
                _frameFoldAndSlideTopViewLeftCount = value;
            }
        }

        private int _frameFoldAndSlideTopViewRightCount;
        public int Frame_FoldAndSlideTopViewRightCount
        {
            get
            {
                return _frameFoldAndSlideTopViewRightCount;
            }
            set
            {
                _frameFoldAndSlideTopViewRightCount = value;
            }
        }


        public bool Frame_If_SlidingTypeTopHung { get; set; }

        private GUPremilineTopTrack_ArticleNo _frameGUPremilineTopTrackArtNo;
        public GUPremilineTopTrack_ArticleNo Frame_GUPremilineTopTrackArtNo
        {
            get
            {
                return _frameGUPremilineTopTrackArtNo;
            }
            set
            {
                _frameGUPremilineTopTrackArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameCladdingQty;
        public int Frame_CladdingQty
        {
            get
            {
                return _frameCladdingQty;
            }
            set
            {
                _frameCladdingQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameCladdingVisibility;
        public bool Frame_CladdingVisibility
        {
            get
            {
                return _frameCladdingVisibility;
            }
            set
            {
                _frameCladdingVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private CladdingProfileForFrame_ArticleNo _frameCladdingArtNo;
        public CladdingProfileForFrame_ArticleNo Frame_CladdingArtNo
        {
            get
            {
                return _frameCladdingArtNo;
            }
            set
            {
                _frameCladdingArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private CladdingReinfForFrame_ArticleNo _frameCladdingReinArtNo;
        public CladdingReinfForFrame_ArticleNo Frame_CladdingReinArtNo
        {
            get
            {
                return _frameCladdingReinArtNo;
            }
            set
            {
                _frameCladdingReinArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameInversionClipVisibility;
        public bool Frame_InversionClipVisibility
        {
            get
            {
                return _frameInversionClipVisibility;
            }
            set
            {
                _frameInversionClipVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frameInversionClipOption;
        public bool Frame_InversionClipOption
        {
            get
            {
                return _frameInversionClipOption;
            }
            set
            {
                _frameInversionClipOption = value;
                NotifyPropertyChanged();
            }
        }


        public InversionClip_ArticleNo _frameInversionClip_ArtNo;
        public InversionClip_ArticleNo FrameInversionClip_ArtNo
        {
            get
            {
                return _frameInversionClip_ArtNo;
            }
            set
            {
                _frameInversionClip_ArtNo = value;
            }
        }

        public GlazingGasket_ArticleNo _frameGlazingGasket_ArtNo;
        public GlazingGasket_ArticleNo FrameGlazingGasket_ArtNo
        {
            get
            {
                return _frameGlazingGasket_ArtNo;
            }
            set
            {
                _frameGlazingGasket_ArtNo = value;
            }
        }

        public Cheveron_ArticleNo _frameCheveron_ArtNo;
        public Cheveron_ArticleNo FrameCheveron_ArtNo
        {
            get
            {
                return _frameCheveron_ArtNo;
            }
            set
            {
                _frameCheveron_ArtNo = value;
            }
        }

        public CornerCleat_ArticleNo _frameCornerCleat_ArtNo;
        public CornerCleat_ArticleNo FrameCornerCleat_ArtNo
        {
            get
            {
                return _frameCornerCleat_ArtNo;
            }
            set
            {
                _frameCornerCleat_ArtNo = value;
            }
        }

        private string _frameAlutekSystemType;
        public string Frame_AlutekSystemType
        {
            get 
            { 
                return _frameAlutekSystemType;
            }
            set 
            { 
                _frameAlutekSystemType = value;
            }
        }


        public void SetExplosionValues_Frame()
        {
            if (Lst_Panel.Count == 1 && Lst_MultiPanel.Count == 0) // 1panel
            {
                if (Lst_Panel[0].Panel_SashProfileArtNo == SashProfile_ArticleNo._395 &&
                    Lst_Panel[0].Panel_MotorizedOptionVisibility == true)
                {
                    Frame_If_InwardMotorizedCasement = true;
                }

                if (Lst_Panel[0].Panel_SlidingTypes == SlidingTypes._TopHung)
                {
                    Frame_If_SlidingTypeTopHung = true;
                }
            }
            else if (Lst_Panel.Count == 0 && Lst_MultiPanel.Count >= 1) //multipanel
            {
                foreach (IMultiPanelModel mpnl in Lst_MultiPanel)
                {
                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                    {
                        if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 &&
                            pnl.Panel_MotorizedOptionVisibility == true)
                        {
                            Frame_If_InwardMotorizedCasement = true;
                        }

                        if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041 &&
                            pnl.Panel_MotorizedOptionVisibility == true)
                        {
                            Frame_If_InwardMotorizedSliding = true;
                        }

                        if (pnl.Panel_SlidingTypes == SlidingTypes._TopHung)
                        {
                            Frame_If_SlidingTypeTopHung = true;
                            Frame_CladdingArtNo = CladdingProfileForFrame_ArticleNo._1338milled;
                            Frame_CladdingReinArtNo = CladdingReinfForFrame_ArticleNo._9198;
                        }
                    }
                }
            }

            int botFrameDiff = 0,// 14 = difference of 7502 & 7507 thickness
              MechjointDeduction = 38,
              submerged = 11,
              MaxCutofRein = 1;

            if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                Frame_BotFrameArtNo == BottomFrameTypes._A166)
            {
                botFrameDiff = 20;
            }
            else if (Frame_BotFrameArtNo == BottomFrameTypes._7789)
            {
                botFrameDiff = 20;
            }
            else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
            {
                botFrameDiff = 14;
            }
            else if (Frame_BotFrameArtNo == BottomFrameTypes._6050)
            {
                botFrameDiff = 20;
            }


            int reinf_size = 0;
            if (Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
            {
                reinf_size = 29;
            }
            else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
            {
                reinf_size = 43;
            }
            else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
            {
                reinf_size = 20;
            }
            else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
            {
                reinf_size = 38;
            }

            if (Frame_BotFrameVisible == true &&
                Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                Frame_BotFrameArtNo != BottomFrameTypes._6052)
            {
                if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                {
                    Frame_ReinfHeight = _frameHeight + botFrameDiff - (reinf_size * 2) - 10;
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._7789)
                {
                    Frame_ReinfHeight = _frameHeight - botFrameDiff - reinf_size - 10;
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._6050)
                {
                    Frame_ReinfHeight = _frameHeight - botFrameDiff - reinf_size - 10;
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                         Frame_BotFrameArtNo == BottomFrameTypes._A166)
                {
                    if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                    {
                        Frame_ReinfHeight = _frameHeight - reinf_size - botFrameDiff + submerged - 10;
                    }
                    else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                    {
                        Frame_ReinfHeight = _frameHeight - reinf_size - botFrameDiff + submerged - 10;
                    }
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._None &&
                         Frame_If_SlidingTypeTopHung == true)
                {
                    Frame_ReinfHeight = _frameHeight - 5 - 10;
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._None)
                {
                    Frame_ReinfHeight = _frameHeight - reinf_size - 10;
                }
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                     Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                int deductMultiplier = 1;
                if (Frame_If_InwardMotorizedSliding == true)
                {
                    deductMultiplier = 1;
                }
                else
                {
                    deductMultiplier = 2;
                }
                Frame_ReinfHeight = _frameHeight - (reinf_size * 2) - (10 * deductMultiplier);
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._84100)
            {
                Frame_ReinfHeight = 0;
            }
            else
            {
                Frame_ReinfHeight = _frameHeight - (reinf_size * 2) - 10;
            }

            if (Frame_If_InwardMotorizedCasement)
            {
                Frame_ReinfWidth = _frameWidth - 35 - (reinf_size * 2) - 10;
                Frame_MilledArtNo = MilledFrame_ArticleNo._7502Milled;
                Frame_MilledReinfArtNo = MilledFrameReinf_ArticleNo._R_676;
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052)
            {
                if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    Frame_ReinfWidth = _frameWidth - 10;
                    if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                        Frame_BotFrameArtNo == BottomFrameTypes._A166)
                    {
                        Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
                    }
                }
                else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                {
                    Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
                    if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                         Frame_BotFrameArtNo == BottomFrameTypes._A166)
                    {
                        Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
                    }
                }
                else if (Frame_ConnectionType == FrameConnectionType._None &&
                         Frame_If_SlidingTypeTopHung == true)
                {
                    Frame_ReinfWidth = _frameWidth - (38 * 2) - 10;
                }
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._84100)
            {
                Frame_ReinfWidth = 0;
            }
            else
            {
                Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
            }

            if (Frame_ReinfWidth > 5800 &&
                (Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
                 Frame_ArtNo == FrameProfile_ArticleNo._6052))
            {
                Frame_ReinfWidth = _frameWidth - 5800 - (reinf_size * 2) - 10;
                Frame_ReinfWidthMorethan5800 = true;
            }
            else
            {
                Frame_ReinfWidthMorethan5800 = false;
            }

            if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                Frame_MechanicalJointConnector_Artno = Frame_MechJointArticleNo._9C52;
                Frame_SealingElement_ArticleNo = SealingElement_ArticleNo._9C97;
            }

            if (Frame_BotFrameVisible == true &&
                Frame_BotFrameArtNo != BottomFrameTypes._7507 &&
                Frame_BotFrameArtNo != BottomFrameTypes._6052)
            {
                if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                {
                    Frame_ExplosionHeight = _frameHeight + botFrameDiff + 5;
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._7789)
                {
                    Frame_ExplosionHeight = _frameHeight - botFrameDiff + 3;
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._6050)
                {
                    Frame_MechanicalJointConnectorQty = 2;

                    if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                    {
                        Frame_ExplosionHeight = _frameHeight - botFrameDiff - MechjointDeduction;
                    }
                    else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                    {
                        Frame_ExplosionHeight = _frameHeight - botFrameDiff + 3;
                    }
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                         Frame_BotFrameArtNo == BottomFrameTypes._9C66)
                {
                    if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                    {
                        Frame_ExplosionHeight = _frameHeight - MechjointDeduction - botFrameDiff + submerged;
                    }
                    else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                    {
                        Frame_ExplosionHeight = _frameHeight - botFrameDiff + submerged + 3;
                    }
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._None &&
                         Frame_ConnectionType == FrameConnectionType._None &&
                         Frame_If_SlidingTypeTopHung == true)
                {
                    Frame_ExplosionHeight = _frameHeight - 5;
                }
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                     Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                Frame_MechanicalJointConnectorQty = 4;
                if (Frame_If_InwardMotorizedSliding == true)
                {
                    Frame_ExplosionHeight = _frameHeight;
                }
                else
                {
                    Frame_ExplosionHeight = _frameHeight - (MechjointDeduction * 2);
                }
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._84100)
            {
                Frame_ExplosionHeight = _frameHeight;
            } 
            else if (Frame_ArtNo == FrameProfile_ArticleNo._84116 ||
                     Frame_ArtNo == FrameProfile_ArticleNo._84118)
            {
                Frame_ExplosionHeight = _frameHeight - 2 - 3;
            } 

            if (Frame_ReinfWidthMorethan5800 == true)
            {
                MaxCutofRein = 2;
            }

            if (Frame_If_InwardMotorizedCasement)
            {
                Frame_ExplosionWidth = (_frameWidth / MaxCutofRein) - 35 + 5;
                Frame_MilledArtNo = MilledFrame_ArticleNo._7502Milled;
                Frame_MilledReinfArtNo = MilledFrameReinf_ArticleNo._R_676;
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052)
            {
                if (Frame_Type == Frame_Padding.Door)
                {
                    Frame_ConnectingProfile_ArticleNo = ConnectingProfile_ArticleNo._0373;
                }
                if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    if (Frame_If_InwardMotorizedSliding == true)
                    {
                        Frame_ExplosionWidth = (_frameWidth / MaxCutofRein) - (MechjointDeduction * 2);
                    }
                    else
                    {
                        Frame_ExplosionWidth = (_frameWidth / MaxCutofRein);
                    }

                    if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                        Frame_BotFrameArtNo == BottomFrameTypes._A166)
                    {
                        Frame_ExplosionWidth = (_frameWidth / MaxCutofRein);
                    }

                }
                else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                {
                    Frame_ExplosionWidth = (_frameWidth / MaxCutofRein) + 5;

                    if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                       Frame_BotFrameArtNo == BottomFrameTypes._A166)
                    {
                        Frame_ExplosionWidth = (_frameWidth / MaxCutofRein) + 5;
                    }
                }
                else if (Frame_BotFrameArtNo == BottomFrameTypes._None &&
                        Frame_If_SlidingTypeTopHung == true)
                {
                    Frame_ExplosionWidth = (_frameWidth / MaxCutofRein) - (38 * 2);
                }

            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._84100)
            {
                Frame_ExplosionWidth = _frameWidth;

            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._84116 ||
                     Frame_ArtNo == FrameProfile_ArticleNo._84118)
            {
                Frame_ExplosionWidth = _frameWidth - (30 * 2) - (2 * 2);
            }
            else
            {
                Frame_ExplosionWidth = (_frameWidth / MaxCutofRein) + 5;
            }

            if (Frame_ArtNo == FrameProfile_ArticleNo._84100)
            {
                FrameGlazingGasket_ArtNo = GlazingGasket_ArticleNo._G221;
                FrameCheveron_ArtNo = Cheveron_ArticleNo._H083;
                FrameCornerCleat_ArtNo = CornerCleat_ArticleNo._H079;
                FrameInversionClip_ArtNo = InversionClip_ArticleNo._84804;
            }
            if (Frame_ArtNo == FrameProfile_ArticleNo._6050 ||
                Frame_ArtNo == FrameProfile_ArticleNo._6052)
            {
                Frame_MechanicalJointConnector_Artno = Frame_MechJointArticleNo._9C52;
                Frame_SealingElement_ArticleNo = SealingElement_ArticleNo._9C97;
            }

            #region Old algo
            //       public void SetExplosionValues_Frame()
            //{
            //    if (Lst_Panel.Count == 1 && Lst_MultiPanel.Count == 0) // 1panel
            //    {
            //        if (Lst_Panel[0].Panel_SashProfileArtNo == SashProfile_ArticleNo._395 &&
            //            Lst_Panel[0].Panel_MotorizedOptionVisibility == true)
            //        {
            //            Frame_If_InwardMotorizedCasement = true;
            //        }
            //    }
            //    else if (Lst_Panel.Count == 0 && Lst_MultiPanel.Count >= 1) //multipanel
            //    {
            //        foreach (IMultiPanelModel mpnl in Lst_MultiPanel)
            //        {
            //            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
            //            {
            //                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 &&
            //                    pnl.Panel_MotorizedOptionVisibility == true)
            //                {
            //                    Frame_If_InwardMotorizedCasement = true;
            //                }

            //                if (pnl.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041 &&
            //                    pnl.Panel_MotorizedOptionVisibility == true)
            //                {
            //                    Frame_If_InwardMotorizedSliding = true;
            //                }
            //            }
            //        }
            //    }

            //    int botFrameDiff = 0,// 14 = difference of 7502 & 7507 thickness
            //      MechjointDeduction = 38,
            //      submerged = 11;

            //    if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
            //        Frame_BotFrameArtNo == BottomFrameTypes._A166)
            //    {
            //        botFrameDiff = 20;
            //    }
            //    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789)
            //    {
            //        botFrameDiff = 20;
            //    }
            //    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
            //    {
            //        botFrameDiff = 14;
            //    }
            //    else if (Frame_BotFrameArtNo == BottomFrameTypes._6050)
            //    {
            //        botFrameDiff = 20;
            //        Frame_MechanicalJointConnector_Artno = Frame_MechJointArticleNo._9C52;
            //        Frame_SealingElement_ArticleNo = SealingElement_ArticleNo._9C97;
            //    }

            //    if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //    {
            //        Frame_MechanicalJointConnector_Artno = Frame_MechJointArticleNo._9C52;
            //        Frame_SealingElement_ArticleNo = SealingElement_ArticleNo._9C97;
            //    }

            //    if (Frame_Type == Frame_Padding.Door &&
            //        Frame_BotFrameVisible == true &&
            //        Frame_BotFrameArtNo == BottomFrameTypes._7502)
            //    {
            //        Frame_ExplosionHeight = _frameHeight + botFrameDiff + 5;
            //    }
            //    else if (Frame_Type == Frame_Padding.Door &&
            //        Frame_BotFrameVisible == true &&
            //        Frame_BotFrameArtNo == BottomFrameTypes._7789)
            //    {
            //        Frame_ExplosionHeight = _frameHeight - botFrameDiff + 3;
            //    }
            //    else if (Frame_Type == Frame_Padding.Door &&
            //        Frame_BotFrameVisible == true &&
            //        Frame_BotFrameArtNo == BottomFrameTypes._6050)
            //    {
            //        Frame_MechanicalJointConnectorQty = 2;

            //        if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //        {
            //            Frame_ExplosionHeight = _frameHeight - botFrameDiff - MechjointDeduction;
            //        }
            //        else if (Frame_ConnectionType == FrameConnectionType._Weldable)
            //        {
            //            Frame_ExplosionHeight = _frameHeight - botFrameDiff + 3;
            //        }
            //    }
            //    else if (Frame_Type == Frame_Padding.Door &&
            //             Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //             Frame_ConnectionType != null &&
            //             (Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
            //              Frame_BotFrameArtNo == BottomFrameTypes._9C66))
            //    {
            //        if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //        {
            //            Frame_ExplosionHeight = _frameHeight - MechjointDeduction - botFrameDiff + submerged;
            //        }
            //        else if (Frame_ConnectionType == FrameConnectionType._Weldable)
            //        {
            //            Frame_ExplosionHeight = _frameHeight - botFrameDiff + submerged + 3;
            //        }
            //    }
            //    else if (Frame_Type == Frame_Padding.Door &&
            //             Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //             Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //    {
            //        Frame_MechanicalJointConnectorQty = 4;

            //        if (Frame_If_InwardMotorizedSliding == true)
            //        {
            //            Frame_ExplosionHeight = _frameHeight;
            //        }
            //        else
            //        {
            //            Frame_ExplosionHeight = _frameHeight - (MechjointDeduction * 2);
            //        }
            //    }
            //    else
            //    {
            //        Frame_ExplosionHeight = _frameHeight + 5;
            //    }

            //    if (Frame_If_InwardMotorizedCasement)
            //    {
            //        Frame_ExplosionWidth = _frameWidth - 35 + 5;
            //        Frame_MilledArtNo = MilledFrame_ArticleNo._7502Milled;
            //        Frame_MilledReinfArtNo = MilledFrameReinf_ArticleNo._R_676;
            //    }
            //    else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //             Frame_ConnectionType != null &&
            //             Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
            //             Frame_BotFrameArtNo == BottomFrameTypes._A166)
            //    {
            //        if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //        {
            //            Frame_ExplosionWidth = _frameWidth;
            //        }
            //        else if (Frame_ConnectionType == FrameConnectionType._Weldable)
            //        {
            //            Frame_ExplosionWidth = _frameWidth + 5;
            //        }
            //    }
            //    else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //             Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //    {
            //        if (Frame_If_InwardMotorizedSliding == true)
            //        {
            //            Frame_ExplosionWidth = _frameWidth - (MechjointDeduction * 2);
            //        }
            //        else
            //        {
            //            Frame_ExplosionWidth = _frameWidth;
            //        }
            //    }
            //    else
            //    {
            //        Frame_ExplosionWidth = _frameWidth + 5;
            //    }

            //    int reinf_size = 0;
            //    if (Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
            //    {
            //        reinf_size = 29;
            //    }
            //    else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
            //    {
            //        reinf_size = 43;
            //    }
            //    else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
            //    {
            //        reinf_size = 20;
            //    }
            //    else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
            //    {
            //        reinf_size = 38;
            //    }


            //    if (Frame_Type == Frame_Padding.Door &&
            //       Frame_BotFrameVisible == true &&
            //       Frame_BotFrameArtNo == BottomFrameTypes._7502)
            //    {
            //        Frame_ReinfHeight = _frameHeight + botFrameDiff - (reinf_size * 2) - 10;
            //    }
            //    else if (Frame_Type == Frame_Padding.Door &&
            //       Frame_BotFrameVisible == true &&
            //       Frame_BotFrameArtNo == BottomFrameTypes._7789)
            //    {
            //        Frame_ReinfHeight = _frameHeight - botFrameDiff - reinf_size - 10;
            //    }
            //    else if (Frame_Type == Frame_Padding.Door &&
            //       Frame_BotFrameVisible == true &&
            //       Frame_BotFrameArtNo == BottomFrameTypes._6050)
            //    {
            //        Frame_ReinfHeight = _frameHeight - botFrameDiff - reinf_size - 10;
            //    }
            //    else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //           Frame_ConnectionType != null &&
            //           Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
            //           Frame_BotFrameArtNo == BottomFrameTypes._A166)
            //    {
            //        if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //        {
            //            Frame_ReinfHeight = _frameHeight - reinf_size - botFrameDiff + submerged - 10;
            //        }
            //        else if (Frame_ConnectionType == FrameConnectionType._Weldable)
            //        {
            //            Frame_ReinfHeight = _frameHeight - reinf_size - botFrameDiff + submerged - 10;
            //        }
            //    }
            //    else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //            Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //    {
            //        int deductMultiplier = 1;
            //        if (Frame_If_InwardMotorizedSliding == true)
            //        {
            //            deductMultiplier = 1;
            //        }
            //        else
            //        {
            //            deductMultiplier = 2;
            //        }
            //        Frame_ReinfHeight = Frame_ExplosionHeight - (reinf_size * 2) - (10 * deductMultiplier);
            //    }
            //    else
            //    {
            //        Frame_ReinfHeight = _frameHeight - (reinf_size * 2) - 10;
            //    }

            //    if (Frame_If_InwardMotorizedCasement)
            //    {
            //        Frame_ReinfWidth = _frameWidth - 35 - (reinf_size * 2) - 10;
            //        Frame_MilledArtNo = MilledFrame_ArticleNo._7502Milled;
            //        Frame_MilledReinfArtNo = MilledFrameReinf_ArticleNo._R_676;
            //    }
            //    else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //             Frame_ConnectionType == FrameConnectionType._MechanicalJoint &&
            //             Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
            //             Frame_BotFrameArtNo == BottomFrameTypes._A166)
            //    {
            //        if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //        {
            //            Frame_ReinfWidth = Frame_ExplosionWidth - (reinf_size * 2) - 10;
            //        }
            //        else if (Frame_ConnectionType == FrameConnectionType._Weldable)
            //        {
            //            Frame_ReinfWidth = Frame_ExplosionWidth - (reinf_size * 2) - 10;
            //        }
            //    }
            //    else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
            //            Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            //    {
            //        Frame_ReinfWidth = Frame_E1xplosionWidth - 10;
            //    }
            //    else
            //    {
            //        Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
            //    }
            //}
            #endregion
        }

        public void AdjustPropertyPanelHeight(string objtype, string mode)
        {
            if (objtype == "Panel")
            {
                if (mode == "add")
                {
                    FrameProp_Height += constants.panel_propertyHeight_default;
                }
                if (mode == "minus")
                {
                    FrameProp_Height -= constants.panel_propertyHeight_default;
                }
                else if (mode == "addRotary")
                {
                    FrameProp_Height += constants.panel_property_rotaryOptionsheight_default;
                }
                else if (mode == "minusRotary")
                {
                    FrameProp_Height -= constants.panel_property_rotaryOptionsheight_default;
                }
                else if (mode == "addRotoswing")
                {
                    FrameProp_Height += constants.panel_property_rotoswingOptionsheight_default;
                }
                else if (mode == "minusRotoswing")
                {
                    FrameProp_Height -= constants.panel_property_rotoswingOptionsheight_default;
                }
                else if (mode == "addRio")
                {
                    FrameProp_Height += constants.panel_property_rioOptionsheight_default;
                }
                else if (mode == "minusRio")
                {
                    FrameProp_Height -= constants.panel_property_rioOptionsheight_default;
                }
                else if (mode == "addRotoline")
                {
                    FrameProp_Height += constants.panel_property_rotolineOptionsheight_default;
                }
                else if (mode == "minusRotoline")
                {
                    FrameProp_Height -= constants.panel_property_rotolineOptionsheight_default;
                }
                else if (mode == "addMVD")
                {
                    FrameProp_Height += constants.panel_property_mvdOptionsheight_default;
                }
                else if (mode == "minusMVD")
                {
                    FrameProp_Height -= constants.panel_property_mvdOptionsheight_default;
                }
                else if (mode == "addCmbMotorized")
                {
                    FrameProp_Height += constants.panel_property_motorizedCmbOptionsheight;
                }
                else if (mode == "minusCmbMotorized")
                {
                    FrameProp_Height -= constants.panel_property_motorizedCmbOptionsheight;
                }
                else if (mode == "addHandle")
                {
                    FrameProp_Height += constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "minusHandle")
                {
                    FrameProp_Height -= constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "addChkMotorized")
                {
                    FrameProp_Height += constants.panel_property_motorizedChkOptionsheight;
                }
                else if (mode == "minusChkMotorized")
                {
                    FrameProp_Height -= constants.panel_property_motorizedChkOptionsheight;
                }
                else if (mode == "addSash")
                {
                    FrameProp_Height += constants.panel_property_sashPanelHeight;
                }
                else if (mode == "minusSash")
                {
                    FrameProp_Height -= constants.panel_property_sashPanelHeight;
                }
                else if (mode == "addGlass")
                {
                    FrameProp_Height += constants.panel_property_glassOptionsHeight;
                }
                else if (mode == "minusGlass")
                {
                    FrameProp_Height -= constants.panel_property_glassOptionsHeight;
                }
                else if (mode == "addExtension")
                {
                    FrameProp_Height += constants.panel_property_extensionOptionsheight;
                }
                else if (mode == "minusExtension")
                {
                    FrameProp_Height -= constants.panel_property_extensionOptionsheight;
                }
                else if (mode == "addExtensionField")
                {
                    FrameProp_Height += constants.panel_property_extensionFieldsheight;
                }
                else if (mode == "minusExtensionField")
                {
                    FrameProp_Height -= constants.panel_property_extensionFieldsheight;
                }
                else if (mode == "addCornerDrive")
                {
                    FrameProp_Height += constants.panel_property_cornerDriveOptionsheight_default;
                }
                else if (mode == "minusCornerDrive")
                {
                    FrameProp_Height -= constants.panel_property_cornerDriveOptionsheight_default;
                }
                else if (mode == "addGeorgianBar")
                {
                    FrameProp_Height += constants.panel_property_georgianBarHeight;
                }
                else if (mode == "minusGeorgianBar")
                {
                    FrameProp_Height -= constants.panel_property_georgianBarHeight;
                }
                else if (mode == "addEspagnolette")
                {
                    FrameProp_Height += constants.panel_property_espagnoletteOptionsheight_default;
                }
                else if (mode == "minusEspagnolette")
                {
                    FrameProp_Height -= constants.panel_property_espagnoletteOptionsheight_default;
                }
                else if (mode == "addHinge")
                {
                    FrameProp_Height += constants.panel_property_HingeOptionsheight;
                }
                else if (mode == "minusHinge")
                {
                    FrameProp_Height -= constants.panel_property_HingeOptionsheight;
                }
                else if (mode == "addCenterHinge")
                {
                    FrameProp_Height += constants.panel_property_CenterHingeOptionsheight;
                }
                else if (mode == "minusCenterHinge")
                {
                    FrameProp_Height -= constants.panel_property_CenterHingeOptionsheight;
                }
                else if (mode == "addNTCenterHinge")
                {
                    FrameProp_Height += constants.panel_property_NTCenterHingeOptionsheight;
                }
                else if (mode == "minusNTCenterHinge")
                {
                    FrameProp_Height -= constants.panel_property_NTCenterHingeOptionsheight;
                }
                else if (mode == "add2dHingeField")
                {
                    FrameProp_Height += constants.panel_property_2dHingeOptionsheight;
                }
                else if (mode == "minus2dHingeField")
                {
                    FrameProp_Height -= constants.panel_property_2dHingeOptionsheight;
                }
                else if (mode == "add3dHinge")
                {
                    FrameProp_Height += constants.panel_property_3dHingeOptionsheight;
                }
                else if (mode == "minus3dHinge")
                {
                    FrameProp_Height -= constants.panel_property_3dHingeOptionsheight;
                }
                else if (mode == "addMC")
                {
                    FrameProp_Height += constants.panel_property_MiddleCloserOptionsheight;
                }
                else if (mode == "minusMC")
                {
                    FrameProp_Height -= constants.panel_property_MiddleCloserOptionsheight;
                }
                else if (mode == "addSlidingType")
                {
                    FrameProp_Height += constants.panel_property_SlidingTypeOptionsheight;
                }
                else if (mode == "minusSlidingType")
                {
                    FrameProp_Height -= constants.panel_property_SlidingTypeOptionsheight;
                }
                else if (mode == "addRollerType")
                {
                    FrameProp_Height += constants.panel_property_RollerTypeOptionsheight;
                }
                else if (mode == "minusRollerType")
                {
                    FrameProp_Height -= constants.panel_property_RollerTypeOptionsheight;
                }
                else if (mode == "addAluminumTrackQty")
                {
                    FrameProp_Height += constants.panel_property_AluminumTrackQtyOptionsheight;
                }
                else if (mode == "minusAluminumTrackQty")
                {
                    FrameProp_Height -= constants.panel_property_AluminumTrackQtyOptionsheight;
                }
                else if (mode == "addDHandle")
                {
                    FrameProp_Height += constants.panel_property_DHandleOptionsheight;
                }
                else if (mode == "minusDHandle")
                {
                    FrameProp_Height -= constants.panel_property_DHandleOptionsheight;
                }
                else if (mode == "addDHandleIOLocking")
                {
                    FrameProp_Height += constants.panel_property_DhandleIOLockingOptionsheight;
                }
                else if (mode == "minusDHandleIOLocking")
                {
                    FrameProp_Height -= constants.panel_property_DhandleIOLockingOptionsheight;
                }
                else if (mode == "addDummyDHandle")
                {
                    FrameProp_Height += constants.panel_property_DummyDHandleOptionsheight;
                }
                else if (mode == "minusDummyDHandle")
                {
                    FrameProp_Height -= constants.panel_property_DummyDHandleOptionsheight;
                }
                else if (mode == "addPopUpHandle")
                {
                    FrameProp_Height += constants.panel_property_PopUpHandleOptionsheight;
                }
                else if (mode == "minusPopUpHandle")
                {
                    FrameProp_Height -= constants.panel_property_PopUpHandleOptionsheight;
                }
                else if (mode == "addRotoswingForSliding")
                {
                    FrameProp_Height += constants.panel_property_RotoswingForSlidingOptionsheight;
                }
                else if (mode == "minusRotoswingForSliding")
                {
                    FrameProp_Height -= constants.panel_property_RotoswingForSlidingOptionsheight;
                }
                //else if (mode == "minusLouver")
                //{
                //    FrameProp_Height -= constants.panel_property_LouverOptionsheight;
                //}
                else if (mode == "addLouverBlades")
                {
                    FrameProp_Height += constants.panel_property_LouverBladesOptionsheight;
                }
                else if (mode == "minusLouverBlades")
                {
                    FrameProp_Height -= constants.panel_property_LouverBladesOptionsheight;
                }
                else if (mode == "addLouverGallery")
                {
                    FrameProp_Height += constants.panel_property_LouverGalleryOptionsheight;
                }
                else if (mode == "minusLouverGallery")
                {
                    FrameProp_Height -= constants.panel_property_LouverGalleryOptionsheight;
                }
                else if (mode == "addLouverGallerySet")
                {
                    FrameProp_Height += constants.panel_property_LouverGallerySetOptionsheight;
                }
                else if (mode == "minusLouverGallerySet")
                {
                    FrameProp_Height -= constants.panel_property_LouverGallerySetOptionsheight;
                }
                else if (mode == "addLouverGallerySetArtNo")
                {
                    FrameProp_Height += constants.panel_property_LouverGallerySetArtNoOptionsheight;
                }
                else if (mode == "minusLouverGallerySetArtNo")
                {
                    FrameProp_Height -= constants.panel_property_LouverGallerySetArtNoOptionsheight;
                }
                else if (mode == "addLouverGlassDeduction")
                {
                    FrameProp_Height += constants.panel_property_LouverGlassheightDeduction;
                }
                else if (mode == "minusLouverGlassDeduction")
                {
                    FrameProp_Height -= constants.panel_property_LouverGlassheightDeduction;
                }
                else if (mode == "addTrackProfile")
                {
                    FrameProp_Height += constants.frame_TrackProfileproperty_PanelHeight;
                }
                else if (mode == "minusTrackProfile")
                {
                    FrameProp_Height -= constants.frame_TrackProfileproperty_PanelHeight;
                }
                else if (mode == "addCenterProfile")
                {
                    FrameProp_Height += constants.panel_property_CenterProfileOptionsheight;
                }
                else if (mode == "minusCenterProfile")
                {
                    FrameProp_Height -= constants.panel_property_CenterProfileOptionsheight;
                }
                else if (mode == "addCremonHandle")
                {
                    FrameProp_Height += constants.panel_property_CremonHandleOptionsheight;
                }
                else if (mode == "minusCremonHandle")
                {
                    FrameProp_Height -= constants.panel_property_CremonHandleOptionsheight;
                } 
            }
            else if (objtype == "Div")
            {
                if (mode == "delete")
                {
                    FrameProp_Height -= constants.div_propertyheight_default;
                }
                else if (mode == "add")
                {
                    FrameProp_Height += constants.div_propertyheight_default;
                }
                else if (mode == "addCladding")
                {
                    FrameProp_Height += constants.div_property_claddingOptionsHeight;
                }
                else if (mode == "addCladdingArtNo")
                {
                    FrameProp_Height += constants.div_property_claddingArtNoOptionsHeight;
                }
                else if (mode == "minusCladdingArtNo")
                {
                    FrameProp_Height += constants.div_property_claddingArtNoOptionsHeight;
                }
                else if (mode == "minusCladding")
                {
                    FrameProp_Height -= constants.div_property_claddingOptionsHeight;
                }
                else if (mode == "addPanelAddCladding")
                {
                    FrameProp_Height += constants.div_property_pnlAddcladdingOptionsHeight;
                }
                else if (mode == "minusPanelAddCladding")
                {
                    FrameProp_Height -= constants.div_property_pnlAddcladdingOptionsHeight;
                }
                else if (mode == "addDivArt")
                {
                    FrameProp_Height += constants.div_property_divArtOptionsHeight;
                }
                else if (mode == "minusDivArt")
                {
                    FrameProp_Height -= constants.div_property_divArtOptionsHeight;
                }
                else if (mode == "addDM")
                {
                    FrameProp_Height += constants.div_property_DMArtOptionsHeight;
                }
                else if (mode == "minusDM")
                {
                    FrameProp_Height -= constants.div_property_DMArtOptionsHeight;
                }
                else if (mode == "addLeverEspag")
                {
                    FrameProp_Height += constants.div_property_leverEspagOptionsHeight;
                }
                else if (mode == "minusLeverEspag")
                {
                    FrameProp_Height -= constants.div_property_leverEspagOptionsHeight;
                }
                else if (mode == "addCladdingBracket")
                {
                    FrameProp_Height += constants.div_property_claddingBracketOptionsHeight;
                }
                else if (mode == "minusCladdingBracket")
                {
                    FrameProp_Height -= constants.div_property_claddingBracketOptionsHeight;
                }
            }
            else if (objtype == "Mpanel")
            {
                if (mode == "delete")
                {
                    FrameProp_Height -= constants.mpnl_propertyHeight_default;
                }
                else if (mode == "add")
                {
                    FrameProp_Height += constants.mpnl_propertyHeight_default;
                }
            }
        }

        public void DeductPropertyPanelHeight(int propertyHeight)
        {
            FrameProp_Height -= propertyHeight;
        }

        public void Insert_frameInfo_MaterialList(DataTable tbl_explosion)
        { 
               int FrameQtyWd = 2,
                   reinfQty = 1;
              
               string cutTypeWd = "",
                      cutTypeHt = "",
                      widthArtNo = "";
              
               if (Frame_BotFrameVisible == true)
               {
                   if (Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                       Frame_BotFrameArtNo == BottomFrameTypes._6052)
                   {
                       FrameQtyWd = 2;
                   }
                   else
                   {
                       FrameQtyWd = 1;
                   }
               }
                
               if (Frame_ConnectionTypeVisibility == true)
               {
                   if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                   {
                       cutTypeWd = @"|  |";
                       cutTypeHt = @"[  ]";
                       if (Frame_If_InwardMotorizedSliding == true)
                       {
                           cutTypeHt = @"[  ]";
                           widthArtNo = "-milled";
                       }
                   }
                   else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                   {
                       cutTypeWd = @"\  /";
                       cutTypeHt = @"\  /";
                   }
                   else if (Frame_ConnectionType == FrameConnectionType._None)
                   {
                       if (Frame_If_SlidingTypeTopHung == true)
                       {
                           cutTypeHt = @"|  |";
                           cutTypeWd = @"|  |";
                           widthArtNo = "-milled";
                       }
                   }
               }
               else
               {
                   cutTypeWd = @"\  /";
                   cutTypeHt = @"\  /";
               }
              
               if (Frame_BotFrameArtNo == BottomFrameTypes._6050 &&
                        Frame_BotFrameVisible == true)
               {
                   cutTypeHt = @"\  |";
               }
              
               if (Frame_ReinfWidthMorethan5800 == true)
               {
                   cutTypeWd = @"\  |";
                   FrameQtyWd = 4;
                   reinfQty = 4;
               }
                
               if (Frame_ArtNo == FrameProfile_ArticleNo._84116 || Frame_ArtNo == FrameProfile_ArticleNo._84118)
               {
                cutTypeWd = @"|  |";
                cutTypeHt = @"|  |";
                    tbl_explosion.Rows.Add("Frame Width " + Frame_ArtNoForAlutek.ToString(),
                                                   FrameQtyWd, "pc(s)",
                                                   Frame_ExplosionWidth.ToString(),
                                                   "Frame",
                                                   cutTypeWd);
               }
               else
               {
                tbl_explosion.Rows.Add("Frame Width " + Frame_ArtNo.ToString() + widthArtNo,
                                                     FrameQtyWd, "pc(s)",
                                                     Frame_ExplosionWidth.ToString(),
                                                     "Frame",
                                                     cutTypeWd);
               } 
              
               tbl_explosion.Rows.Add("Frame Height " + Frame_ArtNo.ToString(),
                                   2, "pc(s)",
                                   Frame_ExplosionHeight,
                                   "Frame",
                                   cutTypeHt);
             
               if (!Frame_WindoorModel.WD_profile.Contains("Alutek"))
               {
              
              
                   if (Frame_If_InwardMotorizedSliding == true)
                   {
                       tbl_explosion.Rows.Add("Frame Reinf Width " + FrameReinf_ArticleNo._NA120.ToString(),
                                         reinfQty, "pc(s)",
                                         _frameWidth.ToString(),
                                         "Frame",
                                         @"|  |");
                   }
                   else if ((Frame_BotFrameArtNo == BottomFrameTypes._6050 ||
                            Frame_BotFrameArtNo == BottomFrameTypes._7502) &&
                            Frame_BotFrameVisible == true)
                   {
                       reinfQty = 1;
                   }
                   else if (Frame_If_SlidingTypeTopHung == true)
                   {
                       reinfQty = 1;
                   }
                   else
                   {
                       reinfQty = 2;
                   }
              
                   if (Frame_ReinfWidthMorethan5800 == true)
                   {
                       tbl_explosion.Rows.Add("Frame Reinf Width " + Frame_ReinfArtNo.ToString(),
                                          2, "pc(s)",
                                          "5800",
                                          "Frame",
                                          @"|  |");
                   }
              
                   tbl_explosion.Rows.Add("Frame Reinf Width " + Frame_ReinfArtNo.ToString(),
                                          reinfQty, "pc(s)",
                                          Frame_ReinfWidth.ToString(),
                                          "Frame",
                                          @"|  |");
              
                   tbl_explosion.Rows.Add("Frame Reinf Height " + Frame_ReinfArtNo.ToString(),
                                          2, "pc(s)",
                                          Frame_ReinfHeight.ToString(),
                                          "Frame",
                                          @"|  |");
               }

             

        }

        int reinfDeduct;
        public void Insert_frameInfoForPremi_MaterialList(DataTable tbl_explosion) //2nd frame for sliding using 3 rails
        {
            string cutTypeWd = "",
                   cutTypeHt = "";
            if (Frame_ConnectionTypeVisibility == true)
            {
                if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    cutTypeWd = @"|  |";
                    cutTypeHt = @"[  ]";
                }
                else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                {
                    cutTypeWd = @"\  /";
                    cutTypeHt = @"\  /";
                }
            }
            else
            {
                cutTypeWd = @"\  /";
                cutTypeHt = @"\  /";
            }

            int FrameQtyWD, reinfQty;
            if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                Frame_BotFrameArtNo == BottomFrameTypes._A166)
            {
                FrameQtyWD = 1;
                reinfQty = 0;

                if (Frame_ConnectionType == FrameConnectionType._Weldable)
                {
                    reinfDeduct = 2;
                }
                else if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    reinfDeduct = 0;
                }
            }
            else if (Frame_ReinfWidthMorethan5800 == true)
            {
                FrameQtyWD = 4;
                reinfQty = 4;
                cutTypeWd = @"\  |";
            }
            else
            {
                FrameQtyWD = 2;
                reinfQty = 2;
            }



            tbl_explosion.Rows.Add("Frame Width " + Frame_ArtNoForPremi.ToString(),
                                   FrameQtyWD, "pc(s)",
                                   Frame_ExplosionWidth.ToString(),
                                   "Frame",
                                   cutTypeWd);

            tbl_explosion.Rows.Add("Frame Height " + Frame_ArtNoForPremi.ToString(),
                                   2, "pc(s)",
                                   Frame_ExplosionHeight,
                                   "Frame",
                                   cutTypeHt);

            tbl_explosion.Rows.Add("Frame Reinf Width " + Frame_ReinfForPremiArtNo.ToString(),
                                   reinfQty, "pc(s)",
                                   Frame_ReinfWidth.ToString(),
                                   "Frame",
                                   @"|  |");

            tbl_explosion.Rows.Add("Frame Reinf Height " + Frame_ReinfForPremiArtNo.ToString(),
                                   2 - reinfDeduct, "pc(s)",
                                   Frame_ReinfHeight.ToString(),
                                   "Frame",
                                   @"|  |");
        }

        public void Insert_frameInfoForScreen_MaterialList(DataTable tbl_explosion)
        {
            string cutType = "";
            int frameAllowance = 0;

            if (Frame_ScreenHeightOption == false)
            {
                cutType = @"|  |";

                if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    frameAllowance = 0;
                }
                else
                {
                    frameAllowance = 20;
                }
            }
            else if (Frame_ScreenHeightOption == true)
            {
                cutType = @"\  /";
                frameAllowance = 5;
            }

            int screenFrameHeight = (Frame_ConnectionType == FrameConnectionType._MechanicalJoint && Frame_ScreenHeightOption == true) ? Frame_ExplosionHeight : (Frame_ScreenFrameHeight + frameAllowance);
            int screenFrameWidthReinf = (Frame_ScreenHeightOption == false) ? (Frame_Width - 10) : Frame_ReinfWidth;

            tbl_explosion.Rows.Add("Frame Width " + Frame_ArtNoForPremi.ToString(),
                                   2, "pc(s)",
                                   (Frame_Width + frameAllowance).ToString(),
                                   "Frame",
                                   cutType);

            if (Frame_ScreenHeightOption == true)
            {
                tbl_explosion.Rows.Add("Frame Height " + Frame_ArtNoForPremi.ToString(),
                                                   2, "pc(s)",
                                                   screenFrameHeight,
                                                   "Frame",
                                                   cutType);

                tbl_explosion.Rows.Add("Frame Reinf Height " + Frame_ReinfForPremiArtNo.ToString(),
                                       2, "pc(s)",
                                       Frame_ReinfHeight.ToString(),
                                       "Frame",
                                       @"|  |");
            }

            tbl_explosion.Rows.Add("Frame Reinf Width " + Frame_ReinfForPremiArtNo.ToString(),
                                 2, "pc(s)",
                                 screenFrameWidthReinf.ToString(),
                                 "Frame",
                                 @"|  |");
        }




        public void Insert_MilledFrameInfo_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Milled Frame " + Frame_MilledArtNo.DisplayName,
                                       1, "pc(s)",
                                       Frame_Width.ToString(),
                                       "Frame",
                                       @"|  |");

            tbl_explosion.Rows.Add("Milled Frame Reinf " + Frame_MilledReinfArtNo.DisplayName,
                                   1, "pc(s)",
                                   Frame_Width.ToString(),
                                   "Frame",
                                   @"|  |");
        }
        public void Insert_BottomFrame_MaterialList(DataTable tbl_explosion)
        {
            if (Frame_BotFrameArtNo == BottomFrameTypes._7502 && Frame_ArtNo == FrameProfile_ArticleNo._7507)
            {
                tbl_explosion.Rows.Add("Bottom Frame Width " + Frame_BotFrameArtNo.ToString(),
                                   1, "pc(s)",
                                   Frame_ExplosionWidth - 28,//14 * 2 = 28, 14 = difference of 7507 & 7502 thickness 
                                   "Frame",
                                   @"\  /");

                tbl_explosion.Rows.Add("Bottom Frame Reinf Width " + FrameReinf_ArticleNo._R676,
                                 1, "pc(s)",
                                 Frame_ReinfWidth.ToString(),
                                 "Frame",
                                 @"|  |");
            }
            else if (Frame_BotFrameArtNo == BottomFrameTypes._7789)
            {
                tbl_explosion.Rows.Add("Aluminum Threshold " + Frame_BotFrameArtNo.ToString(),
                                 1, "pc(s)",
                                 Frame_Width.ToString(),
                                 "Frame",
                                 @"|  |");
            }
            else if (Frame_BotFrameArtNo == BottomFrameTypes._6050 && Frame_ArtNo == FrameProfile_ArticleNo._6052)
            {
                tbl_explosion.Rows.Add("Bottom Frame Width " + Frame_BotFrameArtNo.ToString(),
                                   1, "pc(s)",
                                   Frame_Width,
                                   "Frame",
                                   @"|  |");

                tbl_explosion.Rows.Add("Bottom Frame Reinf Width " + FrameReinf_ArticleNo._TV110,
                                 1, "pc(s)",
                                 Frame_Width - 10,
                                 "Frame",
                                 @"|  |");
            }
            else if (Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                     Frame_BotFrameArtNo == BottomFrameTypes._A166)
            {
                tbl_explosion.Rows.Add("Aluminum Threshold " + Frame_BotFrameArtNo.ToString(),
                                   1, "pc(s)",
                                   Frame_Width,
                                   "Frame",
                                   @"|  |");
            }
        }

        int totalMechJointQty = 0;
        public void Insert_MechanicalJointConnector_MaterialList(DataTable tbl_explosion, int MechJointConnectorQty)
        {
            int additionalRailingsMechJoint = 0;
            if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                additionalRailingsMechJoint = ((Frame_SlidingRailsQty - 2) * 4);
            }
            Frame_MechanicalJointConnector_Artno = Frame_MechJointArticleNo._9C52;
            totalMechJointQty = Frame_MechanicalJointConnectorQty + additionalRailingsMechJoint + MechJointConnectorQty;
            tbl_explosion.Rows.Add("Mechanical Joint Connector " + Frame_MechanicalJointConnector_Artno.DisplayName,
                                                  totalMechJointQty, "pc(s)",
                                                   "",
                                                   "Frame",
                                                   @"");
        }

        public void Insert_SealingElement_MaterialList(DataTable tbl_explosion)
        {
            Frame_SealingElement_ArticleNo = SealingElement_ArticleNo._9C97;
            tbl_explosion.Rows.Add("Sealing Element " + Frame_SealingElement_ArticleNo.DisplayName,
                                   totalMechJointQty, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_ConnectingProfile_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Connecting Profile " + Frame_ConnectingProfile_ArticleNo.DisplayName,
                                                   1, "pc(s)",
                                                   Frame_Width,
                                                   "Ancillary",
                                                   @"");

        }

        //public void Insert_ConnectorType_MaterialList(DataTable tbl_explosion)
        //{
        //    if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
        //    {
        //        tbl_explosion.Rows.Add("Mechanical Joint Corner Connector " + Frame_MechJointArticleNo.DisplayName,
        //                                               4, "pc(s)",
        //                                               "",
        //                                               "Sash",
        //                                               "");
        //    }
        //}

        public void Insert_GS100EMTrackProfile2p6n3m_MaterialList(DataTable tbl_explosion)
        {
            if (Frame_TrackProfileArtNo != TrackProfile_ArticleNo._none)
            {
                tbl_explosion.Rows.Add("GS-100/EM, Track Profile 2.6-3m " + Frame_TrackProfileArtNo.DisplayName,
                                                   1, "pc(s)",
                                                   "",
                                                   "",
                                                   "");
            }
        }

        public void Insert_CladdingProfile_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Cladding Profile " + Frame_CladdingArtNo.DisplayName,
                                                   Frame_CladdingQty, "pc(s)",
                                                   Frame_Width - (61 * 2),
                                                   "Ancillary",
                                                   @"|  |");

            tbl_explosion.Rows.Add("Cladding Profile Reinforcement " + Frame_CladdingReinArtNo.DisplayName,
                                                Frame_CladdingQty, "pc(s)",
                                                Frame_Width - (61 * 2),
                                                "Ancillary",
                                                @"|  |");

        }

        #region alutek material list
         
        public void Insert_GlazingGasket_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Glazing Gasket Width " + FrameGlazingGasket_ArtNo.DisplayName,
                        2, "pc(s)",
                        Frame_Width.ToString(),
                        "Frame",
                        @"");


            tbl_explosion.Rows.Add("Glazing Gasket Height " + FrameGlazingGasket_ArtNo.DisplayName,
                                   2, "pc(s)",
                                   Frame_Height.ToString(),
                                   "Frame",
                                   @"");
        }

        public void Insert_Cheveron_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Cheveron " + FrameCheveron_ArtNo.DisplayName,
                                   4, "pc(s)",
                                   "",
                                   "Hardware & Accessories",
                                   @"");
        }

        public void Insert_CornerWindow_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Corner Window 26x10mm " + FrameCornerCleat_ArtNo.DisplayName,
                                4, "pc(s)",
                                "",
                                "Hardware & Accessories",
                                @"");
        }

        public void Insert_BaseClipForBottomFrame_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Base Clip For Bottom Frame " + Frame_BaseClipArtNo.DisplayName,
                                1, "pc(s)",
                                Frame_ExplosionWidth,
                                "Frame",
                                @"");
        }

        public void Insert_RainCapCover_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Rain Cap Cover 84806  ",
                                   1, "pc(s)",
                                   Frame_Width - (30 * 2),
                                   "Frame",
                                   @"");
        }

        public void Insert_GroveCoverProfile_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Grove Cover Profile, 5.8m 84810  ",
                                   1, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }
         
        public void Insert_TrackScrewSupportBlock_MaterialList(DataTable tbl_explosion)
        {
            int qty = 0; ;
            if (Frame_SlidingRailsQty == 3)
            {
                qty = 8;
            }
            else if (Frame_SlidingRailsQty == 2)
            {
                qty = 4; 
            }

            tbl_explosion.Rows.Add("Track Screw Support Block M808  ",
                                   qty, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        public void Insert_EndCapForFrameAlu22_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("EndCap for Frame Width 84119",
                                   1, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }

       

        public void Insert_SSGuideRail_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("SS Guide Rail A606  ",
                                   2 * Frame_SlidingRailsQty, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        public void Insert_AlumSupportTrack_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Alum Support Track 84915  ",
                                   2 * Frame_SlidingRailsQty, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        #endregion

        public int Add_framePerimeter_screws4fab()
        {
            return (Frame_Width * 2) + (Frame_Height * 2);
        }

        public int Add_MilledFrameWidth_screws4fab()
        {
            return Frame_Width;
        }


        #endregion


        public FrameModel(int frameID,
                          string frameName,
                          int frameWd,
                          int frameHt,
                          Frame_Padding frameType,
                          bool frameVisible,
                          List<IPanelModel> lst_panel,
                          List<IMultiPanelModel> lst_mpanel,
                          float frameImagerZoom,
                          List<IDividerModel> lst_divider,
                          float frameZoom,
                          FrameProfile_ArticleNo frameArtNo,
                          IWindoorModel frameWindoorModel,
                          BottomFrameTypes frameBotFrameType,
                          bool frameBotFrameEnable,
                          UserControl frameUC,
                          UserControl framePropertiesUC)
        {
            Frame_ID = frameID;
            Frame_Name = frameName;
            Frame_Width = frameWd;
            Frame_Height = frameHt;
            Frame_Type = frameType;
            Frame_Visible = frameVisible;
            Lst_Panel = lst_panel;
            Lst_MultiPanel = lst_mpanel;
            FrameImageRenderer_Zoom = frameImagerZoom;
            Lst_Divider = lst_divider;
            Frame_Zoom = frameZoom;
            Frame_ArtNo = frameArtNo;
            Frame_WindoorModel = frameWindoorModel;
            Frame_CmenuDeleteVisibility = true;
            Frame_BotFrameArtNo = frameBotFrameType;
            Frame_BotFrameEnable = frameBotFrameEnable;
            Frame_UC = frameUC;
            Frame_PropertiesUC = framePropertiesUC;

            FrameProp_Height = constants.frame_propertyHeight_default;
        }
    }
}
