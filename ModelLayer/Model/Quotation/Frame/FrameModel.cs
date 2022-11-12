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
            Door = 33
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
                if (Frame_Zoom == 0.17f || Frame_Zoom == 0.26f ||
                    Frame_Zoom == 0.13f || Frame_Zoom == 0.10f)
                {
                    pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                }
                else
                {
                    pnl.SetDimensionToBind_using_BaseDimension();
                }
               
                pnl.SetPanelMargin_using_ZoomPercentage();
                pnl.SetPanelMarginImager_using_ImageZoomPercentage();
            }
        }

        public void Set_DimensionsToBind_using_FrameZoom()
        {
            decimal wd_flt_convert_dec = Convert.ToDecimal(Frame_Width * Frame_Zoom);
            decimal frame_wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            //decimal frame_wd_dec = decimal.Round(wd_flt_convert_dec, 0, MidpointRounding.AwayFromZero);
            Frame_WidthToBind = Convert.ToInt32(frame_wd_dec);
            decimal ht_flt_convert_dec = Convert.ToDecimal(Frame_Height * Frame_Zoom);
            decimal frame_ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
            //decimal frame_ht_dec = decimal.Round(ht_flt_convert_dec, 0, MidpointRounding.AwayFromZero);
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
            if (Frame_Zoom == 0.26f || Frame_Zoom == 0.17f ||
                Frame_Zoom == 0.13f || Frame_Zoom == 0.10f)
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    Frame_Padding_int = new Padding(10);
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507)
                    {
                        Frame_Padding_int = new Padding(10);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                    {
                        Frame_Padding_int = new Padding(10, 10, 10, 5);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 || Frame_BotFrameArtNo == BottomFrameTypes._None)
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
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507)
                    {
                        Frame_Padding_int = new Padding(default_pads);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        (int)((int)26 * Frame_Zoom) - _frameDeduction);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 || Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        0);
                    }
                }
            }
        }

        private void FramePadding_Default()
        {
            if (Frame_Zoom == 0.26f || Frame_Zoom == 0.17f ||
                Frame_Zoom == 0.13f || Frame_Zoom == 0.10f)
            {
                if (_is_MPanel) // meaning MPanel
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        Frame_Padding_int = new Padding(15);
                        FrameImageRenderer_Padding_int = new Padding(15);
                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                        if (Frame_BotFrameArtNo == BottomFrameTypes._7507)
                        {
                            Frame_Padding_int = new Padding(20);
                            FrameImageRenderer_Padding_int = new Padding(20);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 15);
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 15);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 || Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 0);
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 0);
                        }
                    }
                }
                else if (!_is_MPanel) // meaning Panel
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        Frame_Padding_int = new Padding(15);
                        FrameImageRenderer_Padding_int = new Padding(15);
                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                        if (Frame_BotFrameArtNo == BottomFrameTypes._7507)
                        {
                            Frame_Padding_int = new Padding(20);
                            FrameImageRenderer_Padding_int = new Padding(20);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 15);
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 15);
                        }
                        else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 || Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            Frame_Padding_int = new Padding(20, 20, 20, 0);
                            FrameImageRenderer_Padding_int = new Padding(20, 20, 20, 0);
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
                    FrameImageRenderer_Padding_int = new Padding(default_pads_imgr);
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_BotFrameArtNo == BottomFrameTypes._7507)
                    {
                        Frame_Padding_int = new Padding(default_pads);
                        FrameImageRenderer_Padding_int = new Padding(default_pads_imgr);
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        (int)(26 * Frame_Zoom));

                        FrameImageRenderer_Padding_int = new Padding(default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     (int)(26 * FrameImageRenderer_Zoom));
                    }
                    else if (Frame_BotFrameArtNo == BottomFrameTypes._7789 || Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        Frame_Padding_int = new Padding(default_pads,
                                                        default_pads,
                                                        default_pads,
                                                        0);

                        FrameImageRenderer_Padding_int = new Padding(default_pads_imgr,
                                                                     default_pads_imgr,
                                                                     default_pads_imgr,
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
                }

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
        public MilledFrame_ArticleNo Frame_MilledArtNo { get; set; }
        public MilledFrameReinf_ArticleNo Frame_MilledReinfArtNo { get; set; }

        public void SetExplosionValues_Frame()
        {
            if (Lst_Panel.Count == 1 && Lst_MultiPanel.Count == 0) // 1panel
            {
                if (Lst_Panel[0].Panel_SashProfileArtNo == SashProfile_ArticleNo._395 &&
                    Lst_Panel[0].Panel_MotorizedOptionVisibility == true)
                {
                    Frame_If_InwardMotorizedCasement = true;
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
                    }
                }
            }

            int botFrameDiff = 14,// 14 = difference of 7502 & 7507 thickness
                MechjointDeduction = 38;

            if (Frame_Type == Frame_Padding.Door &&
                Frame_BotFrameEnable == true &&
                Frame_BotFrameArtNo == BottomFrameTypes._7502)
            {
                Frame_ExplosionHeight = _frameHeight + botFrameDiff + 5;
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                     Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                Frame_ExplosionHeight = _frameHeight - (MechjointDeduction * 2);
            }
            else
            {
                Frame_ExplosionHeight = _frameHeight + 5;
            }

            if (Frame_If_InwardMotorizedCasement)
            {
                Frame_ExplosionWidth = _frameWidth - 35 + 5;
                Frame_MilledArtNo = MilledFrame_ArticleNo._7502Milled;
                Frame_MilledReinfArtNo = MilledFrameReinf_ArticleNo._R_676;
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                     Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                Frame_ExplosionWidth = _frameWidth;
            }
            else
            {
                Frame_ExplosionWidth = _frameWidth + 5;
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


            if (Frame_Type == Frame_Padding.Door &&
               Frame_BotFrameEnable == true &&
               Frame_BotFrameArtNo == BottomFrameTypes._7502)
            {
                Frame_ReinfHeight = _frameHeight + botFrameDiff - (reinf_size * 2) - 10;
            }
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                    Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                Frame_ReinfHeight = Frame_ExplosionHeight - (reinf_size * 2) - (10 * 2);
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
            else if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                    Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
            {
                Frame_ReinfWidth = Frame_ExplosionWidth - 10;
            }
            else
            {
                Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
            }
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
                else if (mode == "minusLouver")
                {
                    FrameProp_Height -= constants.panel_property_LouverOptionsheight;
                }
                else if (mode == "addLouverBlades")
                {
                    FrameProp_Height += constants.panel_property_LouverBladesOptionsheight;
                }
                else if (mode == "minusLouverBlades")
                {
                    FrameProp_Height -= constants.panel_property_LouverBladesOptionsheight;
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
            int FrameQty;
            if (Frame_BotFrameArtNo == BottomFrameTypes._7507)
            {
                FrameQty = 2;
            }
            else
            {
                FrameQty = 1;
            }


            string cutType = "";
            if (Frame_ConnectionTypeVisibility == true)
            {
                if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    cutType = @"|  |";
                }
                else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                {
                    cutType = @"\  /";
                }
            }
            else
            {
                cutType = @"\  /";
            }

            tbl_explosion.Rows.Add("Frame Width " + Frame_ArtNo.ToString(),
                                                  FrameQty, "pc(s)",
                                                  Frame_ExplosionWidth.ToString(),
                                                  "Frame",
                                                  cutType);

            tbl_explosion.Rows.Add("Frame Height " + Frame_ArtNo.ToString(),
                                   2, "pc(s)",
                                   Frame_ExplosionHeight,
                                   "Frame",
                                   cutType);

            tbl_explosion.Rows.Add("Frame Reinf Width " + Frame_ReinfArtNo.ToString(),
                                   2, "pc(s)",
                                   Frame_ReinfWidth.ToString(),
                                   "Frame",
                                   @"|  |");

            tbl_explosion.Rows.Add("Frame Reinf Height " + Frame_ReinfArtNo.ToString(),
                                   2, "pc(s)",
                                   Frame_ReinfHeight.ToString(),
                                   "Frame",
                                   @"|  |");

        }

        public void Insert_frameInfoForPremi_MaterialList(DataTable tbl_explosion) //2nd frame for sliding using 3 rails
        {
            string cutType = "";
            if (Frame_ConnectionTypeVisibility == true)
            {
                if (Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                {
                    cutType = @"|  |";
                }
                else if (Frame_ConnectionType == FrameConnectionType._Weldable)
                {
                    cutType = @"\  /";
                }
            }
            else
            {
                cutType = @"\  /";
            }

            tbl_explosion.Rows.Add("Frame Width " + Frame_ArtNoForPremi.ToString(),
                                   2, "pc(s)",
                                   Frame_ExplosionWidth.ToString(),
                                   "Frame",
                                   cutType);

            tbl_explosion.Rows.Add("Frame Height " + Frame_ArtNoForPremi.ToString(),
                                   2, "pc(s)",
                                   Frame_ExplosionHeight,
                                   "Frame",
                                   cutType);

            tbl_explosion.Rows.Add("Frame Reinf Width " + Frame_ReinfForPremiArtNo.ToString(),
                                   2, "pc(s)",
                                   Frame_ReinfWidth.ToString(),
                                   "Frame",
                                   @"|  |");

            tbl_explosion.Rows.Add("Frame Reinf Height " + Frame_ReinfForPremiArtNo.ToString(),
                                   2, "pc(s)",
                                   Frame_ReinfHeight.ToString(),
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
            if (Frame_BotFrameArtNo == BottomFrameTypes._7502)
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
                tbl_explosion.Rows.Add("Bottom Frame Width " + Frame_BotFrameArtNo.ToString(),
                                 1, "pc(s)",
                                 Frame_ExplosionWidth.ToString(),
                                 "Frame",
                                 @"|  |");
            }
        }
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
