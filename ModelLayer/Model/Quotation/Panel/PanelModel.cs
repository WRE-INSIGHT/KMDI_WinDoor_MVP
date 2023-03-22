using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;
using static ModelLayer.Model.Quotation.Frame.FrameModel;

namespace ModelLayer.Model.Quotation.Panel
{
    public class PanelModel : IPanelModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConstantVariables constants = new ConstantVariables();

        private int _panelID;
        public int Panel_ID
        {
            get
            {
                return _panelID;
            }
            set
            {
                _panelID = value;
            }
        }

        private string _panelName;
        public string Panel_Name
        {
            get
            {
                return _panelName;
            }
            set
            {
                _panelName = value;
                NotifyPropertyChanged();
            }
        }
        private OverlapSash _panelOverlapSash;
        public OverlapSash Panel_Overlap_Sash
        {
            get
            {
                return _panelOverlapSash;
            }
            set
            {
                _panelOverlapSash = value;
            }
        }
        private DockStyle _panelDock;
        public DockStyle Panel_Dock
        {
            get
            {
                return _panelDock;
            }
            set
            {
                _panelDock = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that represents the definite given value and used by the program only. (not intended for user to use)")]
        private int _panelWidth;
        public int Panel_Width
        {
            get
            {
                return _panelWidth;
            }
            set
            {
                _panelWidth = value;
            }
        }


        private int _panelOriginalWidth;
        public int Panel_OriginalWidth
        {
            get
            {
                return _panelOriginalWidth;
            }
            set
            {
                _panelOriginalWidth = value;
            }
        }

        [Description("Virtual Width that is dependent on Panel_Width and Panel_Zoomand varies accordingly. (not intended for user to use)")]
        private int _panelWidthToBind;
        public int Panel_WidthToBind
        {
            get
            {
                return _panelWidthToBind;
            }
            set
            {
                _panelWidthToBind = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that is used for user's output")]
        private int _panelDisplayWidth;
        public int Panel_DisplayWidth
        {
            get
            {
                return _panelDisplayWidth;
            }
            set
            {
                _panelDisplayWidth = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelDisplayWidthDecimal;
        public int Panel_DisplayWidthDecimal
        {
            get
            {
                return _panelDisplayWidthDecimal;
            }
            set
            {
                _panelDisplayWidthDecimal = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelDisplayWidth_orig;
        public int Panel_OriginalDisplayWidth
        {
            get
            {
                return _panelDisplayWidth_orig;
            }
            set
            {
                _panelDisplayWidth_orig = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelDisplayWidth_orig_decimal;
        public int Panel_OriginalDisplayWidthDecimal
        {
            get
            {
                return _panelDisplayWidth_orig_decimal;
            }
            set
            {
                _panelDisplayWidth_orig_decimal = value;
            }
        }

        [Description("Virtual Height that represents the definite given value and used by the program only. (not intended for user to use)")]
        private int _panelHeight;
        public int Panel_Height
        {
            get
            {
                return _panelHeight;
            }
            set
            {
                _panelHeight = value;
            }
        }
        public int Panel_OriginalHeight { get; set; }
        [Description("Virtual Height that is dependent on Panel_Height and Panel_Zoom and varies accordingly. (not intended for user to use)")]
        private int _panelHeightToBind;
        public int Panel_HeightToBind
        {
            get
            {
                return _panelHeightToBind;
            }
            set
            {
                _panelHeightToBind = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Height that is used for user's output")]
        private int _panelDisplayHeight;
        public int Panel_DisplayHeight
        {
            get
            {
                return _panelDisplayHeight;
            }
            set
            {
                _panelDisplayHeight = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelDisplayHeightDecimal;
        public int Panel_DisplayHeightDecimal
        {
            get
            {
                return _panelDisplayHeightDecimal;
            }
            set
            {
                _panelDisplayHeightDecimal = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelDisplayHeight_orig;
        public int Panel_OriginalDisplayHeight
        {
            get
            {
                return _panelDisplayHeight_orig;
            }
            set
            {
                _panelDisplayHeight_orig = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelDisplayHeight_orig_decimal;
        public int Panel_OriginalDisplayHeightDecimal
        {
            get
            {
                return _panelDisplayHeight_orig_decimal;
            }
            set
            {
                _panelDisplayHeight_orig_decimal = value;
            }
        }

        private string _panelType;
        public string Panel_Type // panelType + " Panel"
        {
            get
            {
                return _panelType;
            }
            set
            {
                if (value.Contains("Fixed"))
                {
                    Panel_HandleOptionsVisibility = false;
                    Panel_MotorizedpnlOptionVisibility = false;

                    if (_panelOrient == true)
                    {
                        _panelChkText = "dSash";
                        Panel_SashPropertyVisibility = true;
                    }
                    else if (_panelOrient == false)
                    {
                        _panelChkText = "Norm";
                        Panel_SashPropertyVisibility = false;
                    }
                }
                else if (value.Contains("Louver"))
                {
                    Panel_SashPropertyVisibility = false;
                }
                else
                {
                    Panel_HandleOptionsVisibility = true;
                    Panel_MotorizedpnlOptionVisibility = true;
                    Panel_SashPropertyVisibility = true;
                }
                _panelType = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelOrient;
        public bool Panel_Orient
        {
            get
            {
                return _panelOrient;
            }
            set
            {
                if (_panelType.Contains("Fixed"))
                {
                    if (value == true)
                    {
                        _panelChkText = "dSash";
                        Panel_SashPropertyVisibility = true;
                    }
                    else if (value == false)
                    {
                        _panelChkText = "None";
                        Panel_SashPropertyVisibility = false;
                    }
                }
                else if (_panelType.Contains("Casement"))
                {
                    Panel_SashPropertyVisibility = true;
                    if (value == true)
                    {
                        _panelChkText = "L";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "R";
                    }
                }
                else if (_panelType.Contains("Awning"))
                {
                    Panel_SashPropertyVisibility = true;
                    if (value == true)
                    {
                        _panelChkText = "Invrt";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "Norm";
                    }
                }
                else if (_panelType.Contains("Sliding"))
                {
                    Panel_SashPropertyVisibility = true;
                    if (value == true)
                    {
                        _panelChkText = "L";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "R";
                    }
                }
                else if (_panelType.Contains("TiltNTurn"))
                {
                    if (value == true)
                    {
                        _panelChkText = "Mod2";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "Mod1";
                    }
                }
                _panelOrient = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelOrientVisibility;
        public bool Panel_OrientVisibility
        {
            get
            {
                return _panelOrientVisibility;
            }
            set
            {
                _panelOrientVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private string _panelChkText;
        public string Panel_ChkText
        {
            get
            {
                return _panelChkText;
            }
            set
            {
                _panelChkText = value;
                NotifyPropertyChanged();
            }
        }

        private Control _panelParent;
        public Control Panel_Parent
        {
            get
            {
                return _panelParent;
            }
            set
            {
                if (value.Name.Contains("Frame"))
                {
                    _panelPNumEnable = false;
                }
                else
                {
                    _panelPNumEnable = true;
                }
                _panelParent = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _panelFrameGroup;
        public UserControl Panel_FrameGroup
        {
            get
            {
                return _panelFrameGroup;
            }
            set
            {
                _panelFrameGroup = value;
            }
        }

        private UserControl _panelFramePropertiesGroup;
        public UserControl Panel_FramePropertiesGroup
        {
            get
            {
                return _panelFramePropertiesGroup;
            }
            set
            {
                _panelFramePropertiesGroup = value;
            }
        }

        private bool _panelVisibility;
        public bool Panel_Visibility
        {
            get
            {
                return _panelVisibility;
            }

            set
            {
                _panelVisibility = value;
            }
        }

        private bool _panelPNumEnable;
        public bool Panel_PNumEnable
        {
            get
            {
                return _panelPNumEnable;
            }
            set
            {
                _panelPNumEnable = value;
                NotifyPropertyChanged();
            }
        }

        private float _panelImage_Zoom;
        public float PanelImageRenderer_Zoom
        {
            get
            {
                return _panelImage_Zoom;
            }

            set
            {
                _panelImage_Zoom = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelImage_Height;
        public int PanelImageRenderer_Height
        {
            get
            {
                return _panelImage_Height;
            }

            set
            {
                _panelImage_Height = value;
                NotifyPropertyChanged();
            }
        }


        private int _panelImage_Width;
        public int PanelImageRenderer_Width
        {
            get
            {
                return _panelImage_Width;
            }

            set
            {
                _panelImage_Width = value;
                NotifyPropertyChanged();
            }
        }

        private Padding _paneImage_Margin;
        public Padding PanelImageRenderer_Margin
        {
            get
            {
                return _paneImage_Margin;
            }
            set
            {
                _paneImage_Margin = value;
                NotifyPropertyChanged();
            }
        }

        private Padding _panelMargin;
        public Padding Panel_Margin
        {
            get
            {
                return _panelMargin;
            }

            set
            {
                _panelMargin = value;
                NotifyPropertyChanged();
            }
        }

        private Padding _panelMarginToBind;
        public Padding Panel_MarginToBind
        {
            get
            {
                return _panelMarginToBind;
            }

            set
            {
                _panelMarginToBind = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _panelMultiPanelGroup;
        public UserControl Panel_MultiPanelGroup
        {
            get
            {
                return _panelMultiPanelGroup;
            }

            set
            {
                _panelMultiPanelGroup = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelIndexInsideMPanel;
        public int Panel_Index_Inside_MPanel //Always be 0 if its inside frame
        {
            get
            {
                return _panelIndexInsideMPanel;
            }

            set
            {
                _panelIndexInsideMPanel = value;
                NotifyPropertyChanged();
            }
        }


        private int _panelIndexInsideSPanel;
        public int Panel_Index_Inside_SPanel //Always be 0 if its inside frame
        {
            get
            {
                return _panelIndexInsideSPanel;
            }

            set
            {
                _panelIndexInsideSPanel = value;
                NotifyPropertyChanged();
            }
        }
        private string _panelPlacement;
        public string Panel_Placement
        {
            get
            {
                return _panelPlacement;
            }

            set
            {
                _panelPlacement = value;
            }
        }

        private float _panelZoom;

        public float Panel_Zoom
        {
            get
            {
                return _panelZoom;
            }

            set
            {
                _panelZoom = value;

            }
        }

        public IFrameModel Panel_ParentFrameModel { get; set; }

        private IMultiPanelModel _panel_ParentMultiPanelModel;
        public IMultiPanelModel Panel_ParentMultiPanelModel
        {
            get
            {
                return _panel_ParentMultiPanelModel;
            }
            set
            {
                _panel_ParentMultiPanelModel = value;
            }
        }

        public int _panelPropertyHeight;
        public int Panel_PropertyHeight
        {
            get
            {
                return _panelPropertyHeight;
            }
            set
            {
                _panelPropertyHeight = value;
                NotifyPropertyChanged();
            }
        }

        private Color _panelBackColor;
        public Color Panel_BackColor
        {
            get
            {
                return _panelBackColor;
            }
            set
            {
                _panelBackColor = value;
                NotifyPropertyChanged();
            }
        }

        public int Panel_LouverBladesCount { get; set; }

        private bool _panel_louverBladesVisibility;
        public bool Panel_LouverBladesVisibility
        {
            get
            {
                return _panel_louverBladesVisibility;
            }
            set
            {
                _panel_louverBladesVisibility = value;
                NotifyPropertyChanged();
            }
        }
        #region Explosion
        private int _panelGlassID;
        public int PanelGlass_ID
        {
            get
            {
                return _panelGlassID;
            }
            set
            {
                _panelGlassID = value;
                NotifyPropertyChanged();
            }
        }

        private float _panelGlassThickness;
        public float Panel_GlassThickness
        {
            get
            {
                return _panelGlassThickness;
            }
            set
            {
                _panelGlassThickness = value;

                if (Panel_Type.Contains("Sliding"))
                {
                    if (value == 6.0f || value == 7.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2436;
                    }
                    else if (value == 8.0f ||
                             value == 9.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2438;
                    }
                    else if (value == 10.0f ||
                             value == 11.0f ||
                             value == 12.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2434;
                    }
                    else if (value == 13.0f ||
                             value == 14.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2435;
                    }
                    else if (value == 15.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2431_9073;
                    }
                    else if (value == 16.0f || value == 17.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2433;
                    }
                    else if (value == 18.0f || value == 19.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2433_9073;
                    }
                    else if (value == 20.0f ||
                             value == 21.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2431;
                    }
                    else if (value == 22.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2429_9044;
                    }
                    else if (value == 23.0f || value == 24.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2429;
                    }

                }
                else
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._1681;
                    }
                    else if (value == 6.0f ||
                             value == 8.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2452;
                    }
                    else if (value == 10.0f ||
                             value == 11.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2451;
                    }
                    else if (value == 12.0f ||
                             value == 13.0f ||
                             value == 14.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2453;
                    }
                    else if (value == 15.0f ||
                             value == 16.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2436;
                    }
                    else if (value == 18.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2438;
                    }
                    else if (value == 20.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2437;
                    }
                    else if (value == 22.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2434;
                    }
                    else if (value == 23.0f ||
                             value == 24.0f ||
                             value == 25.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2435;
                    }
                    else if (value == 26.0f ||
                             value == 27.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2433;
                    }
                    else if (value == 28.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2432;
                    }
                    else if (value == 29.0f ||
                             value == 30.0f)
                    {
                        PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2431;
                    }
                }



                NotifyPropertyChanged();
            }
        }

        private string _panelGlassThicknessDesc;
        public string Panel_GlassThicknessDesc
        {
            get
            {
                return _panelGlassThicknessDesc;
            }
            set
            {
                _panelGlassThicknessDesc = value;
                NotifyPropertyChanged();
            }
        }

        public GlazingAdaptor_ArticleNo Panel_GlazingAdaptorArtNo { get; set; }
        private bool _panelChkGlazingAdaptor;
        public bool Panel_ChkGlazingAdaptor
        {
            get
            {
                return _panelChkGlazingAdaptor;
            }
            set
            {
                _panelChkGlazingAdaptor = value;
                NotifyPropertyChanged();
            }
        }

        private GlazingBead_ArticleNo _panelGlazingBeadArtNo;
        public GlazingBead_ArticleNo PanelGlazingBead_ArtNo
        {
            get
            {
                return _panelGlazingBeadArtNo;
            }
            set
            {
                _panelGlazingBeadArtNo = value;
                NotifyPropertyChanged();
            }
        }
        public int Panel_GlazingBeadWidth { get; set; }
        public int Panel_GlazingBeadWidthDecimal { get; set; }
        public int Panel_GlazingBeadHeight { get; set; }
        public int Panel_GlazingBeadHeightDecimal { get; set; }
        public int Panel_OriginalGlassWidth { get; set; }
        public int Panel_OriginalGlassWidthDecimal { get; set; }
        public int Panel_GlassWidth { get; set; }
        public int Panel_GlassWidthDecimal { get; set; }
        public int Panel_GlassHeight { get; set; }
        public int Panel_GlassHeightDecimal { get; set; }
        public int Panel_OriginalGlassHeight { get; set; }
        public int Panel_OriginalGlassHeightDecimal { get; set; }
        public int Panel_GlazingSpacerQty { get; set; }

        private int _panelGlassPropertyHt;
        public int Panel_GlassPropertyHeight
        {
            get
            {
                return _panelGlassPropertyHt;
            }
            set
            {
                _panelGlassPropertyHt = value;
                NotifyPropertyChanged();
            }
        }

        private GlassFilm_Types _panelGlassFilm;
        public GlassFilm_Types Panel_GlassFilm
        {
            get
            {
                return _panelGlassFilm;
            }
            set
            {
                _panelGlassFilm = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelGlassPnlGlazingBeadVisibility;
        public bool Panel_GlassPnlGlazingBeadVisibility
        {
            get
            {
                return _panelGlassPnlGlazingBeadVisibility;
            }
            set
            {
                _panelGlassPnlGlazingBeadVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelGlassPnlGlazingAdaptorVisibility;
        public bool Panel_GlassPnlGlazingAdaptorVisibility
        {
            get
            {
                return _panelGlassPnlGlazingAdaptorVisibility;
            }
            set
            {
                _panelGlassPnlGlazingAdaptorVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private SashProfile_ArticleNo _panelSashProfileArtNo;
        public SashProfile_ArticleNo Panel_SashProfileArtNo
        {
            get
            {
                return _panelSashProfileArtNo;
            }
            set
            {
                _panelSashProfileArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private SashReinf_ArticleNo _panelSashReinfArtNo;
        public SashReinf_ArticleNo Panel_SashReinfArtNo
        {
            get
            {
                return _panelSashReinfArtNo;
            }
            set
            {
                _panelSashReinfArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private GlassType _panelGlassType;
        public GlassType Panel_GlassType
        {
            get
            {
                return _panelGlassType;
            }
            set
            {
                _panelGlassType = value;
                NotifyPropertyChanged();
            }
        }

        private string _glassType_Insu_Lami;
        public string Panel_GlassType_Insu_Lami
        {
            get
            {
                return _glassType_Insu_Lami;
            }
            set
            {
                _glassType_Insu_Lami = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _glassPricePerSqrMeter;
        public decimal Panel_GlassPricePerSqrMeter
        {
            get
            {
                return _glassPricePerSqrMeter;
            }
            set
            {
                _glassPricePerSqrMeter = value;
                NotifyPropertyChanged();
            }
        }

        public int Panel_SashWidth { get; set; }
        public int Panel_SashWidthDecimal { get; set; }
        public int _panel_SashHeight;
        public int Panel_SashHeight
        {
            get
            {
                return _panel_SashHeight;
            }
            set
            {
                _panel_SashHeight = value;
            }
        }
        public int Panel_SashHeightDecimal { get; set; }

        public int Panel_OriginalSashWidth { get; set; }
        public int Panel_OriginalSashWidthDecimal { get; set; }
        public int Panel_OriginalSashHeight { get; set; }
        public int Panel_OriginalSashHeightDecimal { get; set; }

        public int Panel_SashReinfWidth { get; set; }
        public int Panel_SashReinfWidthDecimal { get; set; }
        public int Panel_SashReinfHeight { get; set; }
        public int Panel_SashReinfHeightDecimal { get; set; }

        private bool _panelSashPropertyVisibility;
        public bool Panel_SashPropertyVisibility
        {
            get
            {
                return _panelSashPropertyVisibility;
            }
            set
            {
                _panelSashPropertyVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelHandleOptionsVisibility;
        public bool Panel_HandleOptionsVisibility
        {
            get
            {
                return _panelHandleOptionsVisibility;
            }
            set
            {
                _panelHandleOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelHandleOptionsHeight;
        public int Panel_HandleOptionsHeight
        {
            get
            {
                return _panelHandleOptionsHeight;
            }
            set
            {
                _panelHandleOptionsHeight = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelRotoswingOptionsVisibility;
        public bool Panel_RotoswingOptionsVisibility
        {
            get
            {
                return _panelRotoswingOptionsVisibility;
            }
            set
            {
                _panelRotoswingOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelRioOptionsVisibility;
        public bool Panel_RioOptionsVisibility
        {
            get
            {
                return _panelRioOptionsVisibility;
            }
            set
            {
                _panelRioOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelRioOptionsVisibility2; // for 2 diff foil color
        public bool Panel_RioOptionsVisibility2
        {
            get
            {
                return _panelRioOptionsVisibility2;
            }
            set
            {
                _panelRioOptionsVisibility2 = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelRotolineOptionsVisibility;
        public bool Panel_RotolineOptionsVisibility
        {
            get
            {
                return _panelRotolineOptionsVisibility;
            }
            set
            {
                _panelRotolineOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelMVDOptionsVisibility;
        public bool Panel_MVDOptionsVisibility
        {
            get
            {
                return _panelMVDOptionsVisibility;
            }
            set
            {
                _panelMVDOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelRotaryOptionsVisibility;
        public bool Panel_RotaryOptionsVisibility
        {
            get
            {
                return _panelRotaryOptionsVisibility;
            }
            set
            {
                _panelRotaryOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public CoverProfile_ArticleNo Panel_CoverProfileArtNo { get; set; }
        public CoverProfile_ArticleNo Panel_CoverProfileArtNo2 { get; set; }

        private FrictionStay_ArticleNo _panelFrictionStayArtNo;
        public FrictionStay_ArticleNo Panel_FrictionStayArtNo
        {
            get
            {
                return _panelFrictionStayArtNo;
            }
            set
            {
                _panelFrictionStayArtNo = value;
                if (Panel_Type.Contains("Awning"))
                {
                    if (value == FrictionStay_ArticleNo._12HD ||
                        value == FrictionStay_ArticleNo._16HD ||
                        value == FrictionStay_ArticleNo._Storm22)
                    {
                        Panel_PlasticWedgeQty = 2;
                    }
                    else if (value == FrictionStay_ArticleNo._Storm26)
                    {
                        Panel_PlasticWedgeQty = 4;
                    }
                    else
                    {
                        Panel_PlasticWedgeQty = 1;
                    }
                }
            }
        }

        public FrictionStayCasement_ArticleNo Panel_FSCasementArtNo { get; set; }

        public SnapInKeep_ArticleNo Panel_SnapInKeepArtNo { get; set; }
        public FixedCam_ArticleNo Panel_FixedCamArtNo { get; set; }
        public _30x25Cover_ArticleNo Panel_30x25CoverArtNo { get; set; }
        public MotorizedDivider_ArticleNo Panel_MotorizedDividerArtNo { get; set; }
        public CoverForMotor_ArticleNo Panel_CoverForMotorArtNo { get; set; }
        public _2DHinge_ArticleNo Panel_2dHingeArtNo { get; set; } //motorized purposes
        public int Panel_2DHingeQty { get; set; } //motorized purposes
        public _2DHinge_ArticleNo Panel_2dHingeArtNo_nonMotorized { get; set; }
        public int Panel_2DHingeQty_nonMotorized { get; set; }

        private bool _panel2dHingeVisibility_nonMotorized;
        public bool Panel_2dHingeVisibility_nonMotorized
        {
            get
            {
                return _panel2dHingeVisibility_nonMotorized;
            }
            set
            {
                _panel2dHingeVisibility_nonMotorized = value;
                NotifyPropertyChanged();
            }
        }
        public _3dHinge_ArticleNo Panel_3dHingeArtNo { get; set; }
        public int Panel_3dHingeQty { get; set; }

        private bool _panel3dHingePropertyVisibility;
        public bool Panel_3dHingePropertyVisibility
        {
            get
            {
                return _panel3dHingePropertyVisibility;
            }
            set
            {
                _panel3dHingePropertyVisibility = value;
                NotifyPropertyChanged();
            }
        }
        public ButtHinge_ArticleNo Panel_ButtHingeArtNo { get; set; }
        public int Panel_ButtHingeQty { get; set; }

        private bool _panel2dHingeVisibility; //motorized purposes
        public bool Panel_2dHingeVisibility //motorized purposes
        {
            get
            {
                return _panel2dHingeVisibility;
            }
            set
            {
                _panel2dHingeVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelButtHingeVisibility; //motorized purposes
        public bool Panel_ButtHingeVisibility //motorized purposes
        {
            get
            {
                return _panelButtHingeVisibility;
            }
            set
            {
                _panelButtHingeVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public AdjustableStriker_ArticleNo Panel_AdjStrikerArtNo { get; set; }
        public int Panel_AdjStrikerQty { get; set; }
        public RestrictorStay_ArticleNo Panel_RestrictorStayArtNo { get; set; }
        public int Panel_RestrictorStayQty { get; set; }

        public PushButtonSwitch_ArticleNo Panel_PushButtonSwitchArtNo { get; set; }
        public FalsePole_ArticleNo Panel_FalsePoleArtNo { get; set; }
        public SupportingFrame_ArticleNo Panel_SupportingFrameArtNo { get; set; }
        public Plate_ArticleNo Panel_PlateArtNo { get; set; }

        private Handle_Type _panelHandleType;
        public Handle_Type Panel_HandleType
        {
            get
            {
                return _panelHandleType;
            }
            set
            {
                _panelHandleType = value;
                NotifyPropertyChanged();
            }
        }

        private Rotoswing_HandleArtNo _panelRotoswingArtNo;
        public Rotoswing_HandleArtNo Panel_RotoswingArtNo
        {
            get
            {
                return _panelRotoswingArtNo;
            }
            set
            {
                _panelRotoswingArtNo = value;
                NotifyPropertyChanged();
            }
        }


        private Rotary_HandleArtNo _panelRotaryArtNo;
        public Rotary_HandleArtNo Panel_RotaryArtNo
        {
            get
            {
                return _panelRotaryArtNo;
            }
            set
            {
                _panelRotaryArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Rio_HandleArtNo _panelRioArtNo;
        public Rio_HandleArtNo Panel_RioArtNo
        {
            get
            {
                return _panelRioArtNo;
            }
            set
            {
                _panelRioArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Rio_HandleArtNo _panelRioArtNo2; // for 2 diff color 
        public Rio_HandleArtNo Panel_RioArtNo2
        {
            get
            {
                return _panelRioArtNo2;
            }
            set
            {
                _panelRioArtNo2 = value;
                NotifyPropertyChanged();
            }
        }

        public ProfileKnobCylinder_ArtNo Panel_ProfileKnobCylinderArtNo { get; set; }
        public Cylinder_CoverArtNo Panel_CylinderCoverArtNo { get; set; }
        public Cylinder_CoverArtNo Panel_CylinderCoverArtNo2 { get; set; } //for 2 diff foil color

        private Rotoline_HandleArtNo _panelRotolineArtNo;
        public Rotoline_HandleArtNo Panel_RotolineArtNo
        {
            get
            {
                return _panelRotolineArtNo;
            }
            set
            {
                _panelRotolineArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private MVD_HandleArtNo _panelMVDArtNo;
        public MVD_HandleArtNo Panel_MVDArtNo
        {
            get
            {
                return _panelMVDArtNo;
            }
            set
            {
                _panelMVDArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Espagnolette_ArticleNo _panelEspagnoletteArtno;
        public Espagnolette_ArticleNo Panel_EspagnoletteArtNo
        {
            get
            {
                return _panelEspagnoletteArtno;
            }
            set
            {
                _panelEspagnoletteArtno = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelEspagnoletteOptionsVisibility;
        public bool Panel_EspagnoletteOptionsVisibility
        {
            get
            {
                return _panelEspagnoletteOptionsVisibility;
            }
            set
            {
                _panelEspagnoletteOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }
        private bool _panelFileLoad;
        public bool Panel_fileLoad
        {
            get
            {
                return _panelFileLoad;
            }
            set
            {
                _panelFileLoad = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionTopArtNo;
        public Extension_ArticleNo Panel_ExtensionTopArtNo
        {
            get
            {
                return _panelExtensionTopArtNo;
            }
            set
            {
                _panelExtensionTopArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionTop2ArtNo;
        public Extension_ArticleNo Panel_ExtensionTop2ArtNo
        {
            get
            {
                return _panelExtensionTop2ArtNo;
            }
            set
            {
                _panelExtensionTop2ArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionTop3ArtNo;
        public Extension_ArticleNo Panel_ExtensionTop3ArtNo
        {
            get
            {
                return _panelExtensionTop3ArtNo;
            }
            set
            {
                _panelExtensionTop3ArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionBotArtNo;
        public Extension_ArticleNo Panel_ExtensionBotArtNo
        {
            get
            {
                return _panelExtensionBotArtNo;
            }
            set
            {
                _panelExtensionBotArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionBot2ArtNo;
        public Extension_ArticleNo Panel_ExtensionBot2ArtNo
        {
            get
            {
                return _panelExtensionBot2ArtNo;
            }
            set
            {
                _panelExtensionBot2ArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionLeftArtNo;
        public Extension_ArticleNo Panel_ExtensionLeftArtNo
        {
            get
            {
                return _panelExtensionLeftArtNo;
            }
            set
            {
                _panelExtensionLeftArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionLeft2ArtNo;
        public Extension_ArticleNo Panel_ExtensionLeft2ArtNo
        {
            get
            {
                return _panelExtensionLeft2ArtNo;
            }
            set
            {
                _panelExtensionLeft2ArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionRightArtNo;
        public Extension_ArticleNo Panel_ExtensionRightArtNo
        {
            get
            {
                return _panelExtensionRightArtNo;
            }
            set
            {
                _panelExtensionRightArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Extension_ArticleNo _panelExtensionRight2ArtNo;
        public Extension_ArticleNo Panel_ExtensionRight2ArtNo
        {
            get
            {
                return _panelExtensionRight2ArtNo;
            }
            set
            {
                _panelExtensionRight2ArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelExtTopChk;
        public bool Panel_ExtTopChk
        {
            get
            {
                return _panelExtTopChk;
            }
            set
            {
                _panelExtTopChk = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelExtTop2Chk;
        public bool Panel_ExtTop2Chk
        {
            get
            {
                return _panelExtTop2Chk;
            }
            set
            {
                _panelExtTop2Chk = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelExtBotChk;
        public bool Panel_ExtBotChk
        {
            get
            {
                return _panelExtBotChk;
            }
            set
            {
                _panelExtBotChk = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelExtLeftChk;
        public bool Panel_ExtLeftChk
        {
            get
            {
                return _panelExtLeftChk;
            }
            set
            {
                _panelExtLeftChk = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelExtRightChk;
        public bool Panel_ExtRightChk
        {
            get
            {
                return _panelExtRightChk;
            }
            set
            {
                _panelExtRightChk = value;
                NotifyPropertyChanged();
            }
        }

        public int Panel_ExtTopQty { get; set; }
        public int Panel_ExtBotQty { get; set; }
        public int Panel_ExtLeftQty { get; set; }
        public int Panel_ExtRightQty { get; set; }

        public int Panel_ExtTop2Qty { get; set; }
        public int Panel_ExtTop3Qty { get; set; }
        public int Panel_ExtBot2Qty { get; set; }
        public int Panel_ExtLeft2Qty { get; set; }
        public int Panel_ExtRight2Qty { get; set; }

        private CornerDrive_ArticleNo _panelCornerDriveArtNo;
        public CornerDrive_ArticleNo Panel_CornerDriveArtNo
        {
            get
            {
                return _panelCornerDriveArtNo;
            }
            set
            {
                _panelCornerDriveArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelCornerDriveOptionsVisibility;
        public bool Panel_CornerDriveOptionsVisibility
        {
            get
            {
                return _panelCornerDriveOptionsVisibility;
            }
            set
            {
                _panelCornerDriveOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }
        public bool Panel_ExtensionOptionsVisibility { get; set; }

        private int _panelRotoswingOptionsHeight;
        public int Panel_RotoswingOptionsHeight
        {
            get
            {
                return _panelRotoswingOptionsHeight;
            }
            set
            {
                _panelRotoswingOptionsHeight = value;
                NotifyPropertyChanged();
            }
        }

        public PlasticWedge_ArticleNo Panel_PlasticWedge { get; set; }
        public int Panel_PlasticWedgeQty { get; set; }

        public Striker_ArticleNo Panel_StrikerArtno_A { get; set; } //for Awning
        public int Panel_StrikerQty_A { get; set; }

        public Striker_ArticleNo Panel_StrikerArtno_C { get; set; } //for Casement
        public int Panel_StrikerQty_C { get; set; }

        private MiddleCloser_ArticleNo _panelMiddleCloserArtno;
        public MiddleCloser_ArticleNo Panel_MiddleCloserArtNo
        {
            get
            {
                return _panelMiddleCloserArtno;
            }
            set
            {
                _panelMiddleCloserArtno = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelMiddleCloserPairQty;
        public int Panel_MiddleCloserPairQty
        {
            get
            {
                return _panelMiddleCloserPairQty;
            }
            set
            {
                _panelMiddleCloserPairQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_MiddleCloserVisibility;
        public bool Panel_MiddleCloserVisibility
        {
            get
            {
                return _panel_MiddleCloserVisibility;
            }

            set
            {
                _panel_MiddleCloserVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private LockingKit_ArticleNo _panelLockingKitArtno;
        public LockingKit_ArticleNo Panel_LockingKitArtNo
        {
            get
            {
                return _panelLockingKitArtno;
            }
            set
            {
                _panelLockingKitArtno = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelMotorizedpnlOptionVisibility;
        public bool Panel_MotorizedpnlOptionVisibility
        {
            get
            {
                return _panelMotorizedpnlOptionVisibility;
            }
            set
            {
                _panelMotorizedpnlOptionVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelMotorizedOptionVisibility;
        [Description("Used on chk_Motorized on MotorizedProperty"), Category("Appearance")]
        public bool Panel_MotorizedOptionVisibility
        {
            get
            {
                return _panelMotorizedOptionVisibility;
            }
            set
            {
                _panelMotorizedOptionVisibility = value;
                if (_panelMotorizedOptionVisibility == true)
                {
                    if (Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
                    {
                        Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7507;
                    }
                    else if (Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                    {
                        Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._6052;
                    }
                    //if (Panel_ParentMultiPanelModel != null)
                    //{
                    //    Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7502;
                    //}
                    //else if (Panel_ParentMultiPanelModel == null)
                    //{
                    //    Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7507;
                    //}

                    if (Panel_DisplayWidth >= 1100)
                    {
                        Panel_GlassFilm = GlassFilm_Types._4milUpera;
                    }
                }
                else if (_panelMotorizedOptionVisibility == false)
                {
                    if (Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
                    {
                        if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                        {
                            Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7502;
                        }
                        else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7507;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                    {
                        if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                        {
                            Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._6050;
                        }
                        else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._6052;
                        }
                    }

                    if (Panel_DisplayWidth >= 1100)
                    {
                        Panel_GlassFilm = GlassFilm_Types._None;
                    }
                }
                NotifyPropertyChanged();
            }
        }

        private MotorizedMech_ArticleNo _panelMotorizedMechArtNo;
        public MotorizedMech_ArticleNo Panel_MotorizedMechArtNo
        {
            get
            {
                return _panelMotorizedMechArtNo;
            }
            set
            {
                _panelMotorizedMechArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelMotorizedPropertyHeight;
        public int Panel_MotorizedPropertyHeight
        {
            get
            {
                return _panelMotorizedPropertyHeight;
            }
            set
            {
                _panelMotorizedPropertyHeight = value;
                NotifyPropertyChanged();
            }
        }

        public int Panel_MotorizedMechQty { get; set; }

        public int Panel_MotorizedMechSetQty { get; set; }

        private int _panelExtensionPropertyHeight;
        public int Panel_ExtensionPropertyHeight
        {
            get
            {
                return _panelExtensionPropertyHeight;
            }
            set
            {
                _panelExtensionPropertyHeight = value;
                NotifyPropertyChanged();
            }
        }

        private GeorgianBar_ArticleNo _panelGeorgianBarArtNo;
        public GeorgianBar_ArticleNo Panel_GeorgianBarArtNo
        {
            get
            {
                return _panelGeorgianBarArtNo;
            }
            set
            {
                _panelGeorgianBarArtNo = value;
                NotifyPropertyChanged();
            }
        }

        public int Panel_GeorgianBar_VerticalQty { get; set; }
        public int Panel_GeorgianBar_HorizontalQty { get; set; }

        private bool _panelGeorgianBarOptionVisibility;
        public bool Panel_GeorgianBarOptionVisibility
        {
            get
            {
                return _panelGeorgianBarOptionVisibility;
            }
            set
            {
                _panelGeorgianBarOptionVisibility = value;
                NotifyPropertyChanged();
            }
        }
        private HingeOption _panel_HingeOptions;
        public HingeOption Panel_HingeOptions
        {
            get
            {
                return _panel_HingeOptions;
            }

            set
            {
                _panel_HingeOptions = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelHingeOptionsPropertyHeight;
        public int Panel_HingeOptionsPropertyHeight
        {
            get
            {
                return _panelHingeOptionsPropertyHeight;
            }
            set
            {
                _panelHingeOptionsPropertyHeight = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_HingeOptionsVisibility;
        public bool Panel_HingeOptionsVisibility
        {
            get
            {
                return _panel_HingeOptionsVisibility;
            }

            set
            {
                _panel_HingeOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }


        private CenterHingeOption _panel_CenterHingeOptions;
        public CenterHingeOption Panel_CenterHingeOptions
        {
            get
            {
                return _panel_CenterHingeOptions;
            }

            set
            {
                _panel_CenterHingeOptions = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_CenterHingeOptionsVisibility;
        public bool Panel_CenterHingeOptionsVisibility
        {
            get
            {
                return _panel_CenterHingeOptionsVisibility;
            }

            set
            {
                _panel_CenterHingeOptionsVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private NTCenterHinge_ArticleNo _panel_NTCenterHingeArticleNo;
        public NTCenterHinge_ArticleNo Panel_NTCenterHingeArticleNo
        {
            get
            {
                return _panel_NTCenterHingeArticleNo;
            }

            set
            {
                _panel_NTCenterHingeArticleNo = value;
                NotifyPropertyChanged();
            }
        }

        public StayBearingK_ArticleNo Panel_StayBearingKArtNo { get; set; }
        public StayBearingPin_ArticleNo Panel_StayBearingPinArtNo { get; set; }
        public StayBearingCover_ArticleNo Panel_StayBearingCoverArtNo { get; set; }
        public TopCornerHingeCover_ArticleNo Panel_TopCornerHingeCoverArtNo { get; set; }
        public TopCornerHinge_ArticleNo Panel_TopCornerHingeArtNo { get; set; }
        public TopCornerHingeSpacer_ArticleNo Panel_TopCornerHingeSpacerArtNo { get; set; }
        public CornerHingeK_ArticleNo Panel_CornerHingeKArtNo { get; set; }
        public CornerPivotRestK_ArticleNo Panel_CornerPivotRestKArtNo { get; set; }
        public CornerHingeCoverK_ArticleNo Panel_CornerHingeCoverKArtNo { get; set; }
        public CoverForCornerPivotRestVertical_ArticleNo Panel_CoverForCornerPivotRestVerticalArtNo { get; set; }
        public CoverForCornerPivotRest_ArticleNo Panel_CoverForCornerPivotRestArtNo { get; set; }
        public WeldableCornerJoint_ArticleNo Panel_WeldableCArtNo { get; set; }
        public LatchDeadboltStriker_ArticleNo Panel_LatchDeadboltStrikerArtNo { get; set; }

        private bool _panel_NTCenterHingeVisibility;
        public bool Panel_NTCenterHingeVisibility
        {
            get
            {
                return _panel_NTCenterHingeVisibility;
            }

            set
            {
                _panel_NTCenterHingeVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelCmenuDeleteVisibility;
        public bool Panel_CmenuDeleteVisibility
        {
            get
            {
                return _panelCmenuDeleteVisibility;
            }
            set
            {
                _panelCmenuDeleteVisibility = value;
                NotifyPropertyChanged();
            }
        }
        private GBSpacer_ArticleNo _panel_GBSpacerArtNo;
        public GBSpacer_ArticleNo Panel_GBSpacerArtNo
        {
            get
            {
                return _panel_GBSpacerArtNo;
            }

            set
            {
                _panel_GBSpacerArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Spacer_ArticleNo _panel_SpacerArtNo;
        public Spacer_ArticleNo Panel_SpacerArtNo
        {
            get
            {
                return _panel_SpacerArtNo;
            }

            set
            {
                _panel_SpacerArtNo = value;
                NotifyPropertyChanged();
            }
        }


        private SlidingTypes _panel_SlidingTypes;
        public SlidingTypes Panel_SlidingTypes
        {
            get
            {
                return _panel_SlidingTypes;
            }

            set
            {
                _panel_SlidingTypes = value;
                NotifyPropertyChanged();
            }
        }



        private bool _panel_SlidingTypeVisibility;
        public bool Panel_SlidingTypeVisibility
        {
            get
            {
                return _panel_SlidingTypeVisibility;
            }

            set
            {
                _panel_SlidingTypeVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private GuideTrackProfile_ArticleNo _panel_GuideTrackProfileArtNo;
        public GuideTrackProfile_ArticleNo Panel_GuideTrackProfileArtNo
        {
            get
            {
                return _panel_GuideTrackProfileArtNo;
            }

            set
            {
                _panel_GuideTrackProfileArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private AluminumTrack_ArticleNo _panel_AluminumTrackArtNo;
        public AluminumTrack_ArticleNo Panel_AluminumTrackArtNo
        {
            get
            {
                return _panel_AluminumTrackArtNo;
            }

            set
            {
                _panel_AluminumTrackArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private int _panel_AluminumTrackQty;
        public int Panel_AluminumTrackQty
        {
            get
            {
                return _panel_AluminumTrackQty;
            }

            set
            {
                _panel_AluminumTrackQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_AluminumTrackQtyVisibility;
        public bool Panel_AluminumTrackQtyVisibility
        {
            get
            {
                return _panel_AluminumTrackQtyVisibility;
            }

            set
            {
                _panel_AluminumTrackQtyVisibility = value;
                NotifyPropertyChanged();
            }
        }


        private WeatherBar_ArticleNo _panel_WeatherBarArtNo;
        public WeatherBar_ArticleNo Panel_WeatherBarArtNo
        {
            get
            {
                return _panel_WeatherBarArtNo;
            }

            set
            {
                _panel_WeatherBarArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private WeatherBarFastener_ArticleNo _panel_WeatherBarFastenerArtNo;
        public WeatherBarFastener_ArticleNo Panel_WeatherBarFastenerArtNo
        {
            get
            {
                return _panel_WeatherBarFastenerArtNo;
            }

            set
            {
                _panel_WeatherBarFastenerArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private EndCapForWeatherBar_ArticleNo _panel_EndCapForWeatherBarArtNo;
        public EndCapForWeatherBar_ArticleNo Panel_EndCapForWeatherBarArtNo
        {
            get
            {
                return _panel_EndCapForWeatherBarArtNo;
            }

            set
            {
                _panel_EndCapForWeatherBarArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private WaterSeepage_ArticleNo _panel_WaterSeepageArtNo;
        public WaterSeepage_ArticleNo Panel_WaterSeepageArtNo
        {
            get
            {
                return _panel_WaterSeepageArtNo;
            }

            set
            {
                _panel_WaterSeepageArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private BrushSeal_ArticleNo _panel_BrushSealArtNo;
        public BrushSeal_ArticleNo Panel_BrushSealArtNo
        {
            get
            {
                return _panel_BrushSealArtNo;
            }

            set
            {
                _panel_BrushSealArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private RollersTypes _panel_RollersTypes;
        public RollersTypes Panel_RollersTypes
        {
            get
            {
                return _panel_RollersTypes;
            }

            set
            {
                _panel_RollersTypes = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_RollersTypesVisibility;
        public bool Panel_RollersTypesVisibility
        {
            get
            {
                return _panel_RollersTypesVisibility;
            }

            set
            {
                _panel_RollersTypesVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private GlazingRebateBlock_ArticleNo _panel_GlazingRebateBlockArtNo;
        public GlazingRebateBlock_ArticleNo Panel_GlazingRebateBlockArtNo
        {
            get
            {
                return _panel_GlazingRebateBlockArtNo;
            }

            set
            {
                _panel_GlazingRebateBlockArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Spacer_ArticleNo _panel_Spacer;
        public Spacer_ArticleNo Panel_Spacer
        {
            get
            {
                return _panel_Spacer;
            }

            set
            {
                _panel_Spacer = value;
                NotifyPropertyChanged();
            }
        }

        private SealingBlock_ArticleNo _panel_SealingBlockArtNo;
        public SealingBlock_ArticleNo Panel_SealingBlockArtNo
        {
            get
            {
                return _panel_SealingBlockArtNo;
            }

            set
            {
                _panel_SealingBlockArtNo = value;
                NotifyPropertyChanged();
            }
        }


        private Interlock_ArticleNo _panel_InterlockArtNo;
        public Interlock_ArticleNo Panel_InterlockArtNo
        {
            get
            {
                return _panel_InterlockArtNo;
            }

            set
            {
                _panel_InterlockArtNo = value;
                NotifyPropertyChanged();
            }
        }


        private ExtensionForInterlock_ArticleNo _panel_ExtensionForInterlockArtNo;
        public ExtensionForInterlock_ArticleNo Panel_ExtensionForInterlockArtNo
        {
            get
            {
                return _panel_ExtensionForInterlockArtNo;
            }

            set
            {
                _panel_ExtensionForInterlockArtNo = value;
                NotifyPropertyChanged();
            }
        }



        private D_HandleArtNo _panel_DHandleInsideArtNo;
        public D_HandleArtNo Panel_DHandleInsideArtNo
        {
            get
            {
                return _panel_DHandleInsideArtNo;
            }

            set
            {
                _panel_DHandleInsideArtNo = value;
                NotifyPropertyChanged();
            }
        }


        private D_HandleArtNo _panel_DHandleOutsideArtNo;
        public D_HandleArtNo Panel_DHandleOutsideArtNo
        {
            get
            {
                return _panel_DHandleOutsideArtNo;
            }

            set
            {
                _panel_DHandleOutsideArtNo = value;
                if (value == D_HandleArtNo._DH605543)
                {
                    Panel_DHandleInsideArtNo = D_HandleArtNo._DH613226;
                }
                else if (value == D_HandleArtNo._DH613185)
                {
                    Panel_DHandleInsideArtNo = D_HandleArtNo._DH613224;
                }
                else if (value == D_HandleArtNo._DH487261)
                {
                    Panel_DHandleInsideArtNo = D_HandleArtNo._DH613228;
                }
                else if (value == D_HandleArtNo._DH605551)
                {
                    Panel_DHandleInsideArtNo = D_HandleArtNo._DH613225;
                }
                NotifyPropertyChanged();
            }
        }

        private D_Handle_IO_LockingArtNo _panel_DHandleIOLockingInsideArtNo;
        public D_Handle_IO_LockingArtNo Panel_DHandleIOLockingInsideArtNo
        {
            get
            {
                return _panel_DHandleIOLockingInsideArtNo;
            }

            set
            {
                _panel_DHandleIOLockingInsideArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private D_Handle_IO_LockingArtNo _panel_DHandleIOLockingOutsideArtNo;
        public D_Handle_IO_LockingArtNo Panel_DHandleIOLockingOutsideArtNo
        {
            get
            {
                return _panel_DHandleIOLockingOutsideArtNo;
            }

            set
            {
                _panel_DHandleIOLockingOutsideArtNo = value;
                if (value == D_Handle_IO_LockingArtNo._613217)
                {
                    Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613243;
                }
                else if (value == D_Handle_IO_LockingArtNo._DH833308_613241)
                {
                    Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH833309_613215;
                }
                else if (value == D_Handle_IO_LockingArtNo._DH613219)
                {
                    Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613245;
                }
                else if (value == D_Handle_IO_LockingArtNo._DH605216)
                {
                    Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613242;
                }
                NotifyPropertyChanged();
            }
        }

        private DummyD_HandleArtNo _panel_DummyDHandleInsideArtNo;
        public DummyD_HandleArtNo Panel_DummyDHandleInsideArtNo
        {
            get
            {
                return _panel_DummyDHandleInsideArtNo;
            }

            set
            {
                _panel_DummyDHandleInsideArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private DummyD_HandleArtNo _panel_DummyDHandleOutsideArtNo;
        public DummyD_HandleArtNo Panel_DummyDHandleOutsideArtNo
        {
            get
            {
                return _panel_DummyDHandleOutsideArtNo;
            }

            set
            {
                _panel_DummyDHandleOutsideArtNo = value;
                if (value == DummyD_HandleArtNo._DH613191)
                {
                    Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613226;
                }
                else if (value == DummyD_HandleArtNo._DH833310_613189)
                {
                    Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613224;
                }
                else if (value == DummyD_HandleArtNo._DH613193)
                {
                    Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613228;
                }
                else if (value == DummyD_HandleArtNo._DH613190)
                {
                    Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613225;
                }
                NotifyPropertyChanged();
            }
        }

        private PopUp_HandleArtNo _panel_PopUpHandleArtNo;
        public PopUp_HandleArtNo Panel_PopUpHandleArtNo
        {
            get
            {
                return _panel_PopUpHandleArtNo;
            }

            set
            {
                _panel_PopUpHandleArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private Rotoswing_Sliding_HandleArtNo _panel_RotoswingForSlidingHandleArtNo;
        public Rotoswing_Sliding_HandleArtNo Panel_RotoswingForSlidingHandleArtNo
        {
            get
            {
                return _panel_RotoswingForSlidingHandleArtNo;
            }

            set
            {
                _panel_RotoswingForSlidingHandleArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_DHandleOptionVisibilty;
        public bool Panel_DHandleOptionVisibilty
        {
            get
            {
                return _panel_DHandleOptionVisibilty;
            }

            set
            {
                _panel_DHandleOptionVisibilty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_DHandleIOLockingOptionVisibilty;
        public bool Panel_DHandleIOLockingOptionVisibilty
        {
            get
            {
                return _panel_DHandleIOLockingOptionVisibilty;
            }

            set
            {
                _panel_DHandleIOLockingOptionVisibilty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_DummyDHandleOptionVisibilty;
        public bool Panel_DummyDHandleOptionVisibilty
        {
            get
            {
                return _panel_DummyDHandleOptionVisibilty;
            }

            set
            {
                _panel_DummyDHandleOptionVisibilty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_PopUpHandleOptionVisibilty;
        public bool Panel_PopUpHandleOptionVisibilty
        {
            get
            {
                return _panel_PopUpHandleOptionVisibilty;
            }

            set
            {
                _panel_PopUpHandleOptionVisibilty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_RotoswingForSlidingHandleOptionVisibilty;
        public bool Panel_RotoswingForSlidingHandleOptionVisibilty
        {
            get
            {
                return _panel_RotoswingForSlidingHandleOptionVisibilty;
            }

            set
            {
                _panel_RotoswingForSlidingHandleOptionVisibilty = value;
                NotifyPropertyChanged();
            }
        }

        private Striker_ArticleNo _panel_StrikerArtno_Sliding;
        public Striker_ArticleNo Panel_StrikerArtno_Sliding
        {
            get
            {
                return _panel_StrikerArtno_Sliding;
            }

            set
            {
                _panel_StrikerArtno_Sliding = value;
                NotifyPropertyChanged();
            }
        }
        public int Panel_StrikerArtno_SlidingQty { get; set; }

        private ScrewSets _panel_ScrewSetsArtNo;
        public ScrewSets Panel_ScrewSetsArtNo
        {
            get
            {
                return _panel_ScrewSetsArtNo;
            }

            set
            {
                _panel_ScrewSetsArtNo = value;
                NotifyPropertyChanged();
            }
        }


        private PVCCenterProfile_ArticleNo _panel_PVCCenterProfileArtNo;
        public PVCCenterProfile_ArticleNo Panel_PVCCenterProfileArtNo
        {
            get
            {
                return _panel_PVCCenterProfileArtNo;
            }

            set
            {
                _panel_PVCCenterProfileArtNo = value;
                NotifyPropertyChanged();
            }
        }
        private GS100_T_EM_T_HMCOVER_ArticleNo _panel_GS100_T_EM_T_HMCOVER_ArtNo;
        public GS100_T_EM_T_HMCOVER_ArticleNo Panel_GS100_T_EM_T_HMCOVER_ArtNo
        {
            get
            {
                return _panel_GS100_T_EM_T_HMCOVER_ArtNo;
            }

            set
            {
                _panel_GS100_T_EM_T_HMCOVER_ArtNo = value;
                NotifyPropertyChanged();
            }
        }



        private TrackRail_ArticleNo _panel_TrackRailArtNo;
        public TrackRail_ArticleNo Panel_TrackRailArtNo
        {
            get
            {
                return _panel_TrackRailArtNo;
            }

            set
            {
                _panel_TrackRailArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_TrackRailArtNoVisibility;
        public bool Panel_TrackRailArtNoVisibility
        {
            get
            {
                return _panel_TrackRailArtNoVisibility;
            }

            set
            {
                _panel_TrackRailArtNoVisibility = value;
                NotifyPropertyChanged();
            }
        }
        private MicrocellOneSafetySensor_ArticleNo _panel_MicrocellOneSafetySensorArtNo;
        public MicrocellOneSafetySensor_ArticleNo Panel_MicrocellOneSafetySensorArtNo
        {
            get
            {
                return _panel_MicrocellOneSafetySensorArtNo;
            }

            set
            {
                _panel_MicrocellOneSafetySensorArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private AutodoorBracketForGS100UPVC_ArticleNo _panel_AutodoorBracketForGS100UPVCArtNo;
        public AutodoorBracketForGS100UPVC_ArticleNo Panel_AutodoorBracketForGS100UPVCArtNo
        {
            get
            {
                return _panel_AutodoorBracketForGS100UPVCArtNo;
            }

            set
            {
                _panel_AutodoorBracketForGS100UPVCArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private GS100EndCapScrewM5AndLSupport_ArticleNo _panel_GS100EndCapScrewM5AndLSupportArtNo;
        public GS100EndCapScrewM5AndLSupport_ArticleNo Panel_GS100EndCapScrewM5AndLSupportArtNo
        {
            get
            {
                return _panel_GS100EndCapScrewM5AndLSupportArtNo;
            }

            set
            {
                _panel_GS100EndCapScrewM5AndLSupportArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private EuroLeadExitButton_ArticleNo _panel_EuroLeadExitButtonArtNo;
        public EuroLeadExitButton_ArticleNo Panel_EuroLeadExitButtonArtNo
        {
            get
            {
                return _panel_EuroLeadExitButtonArtNo;
            }

            set
            {
                _panel_EuroLeadExitButtonArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private TOOTHBELT_EM_CM_ArticleNo _panel_TOOTHBELT_EM_CMArtNo;
        public TOOTHBELT_EM_CM_ArticleNo Panel_TOOTHBELT_EM_CMArtNo
        {
            get
            {
                return _panel_TOOTHBELT_EM_CMArtNo;
            }

            set
            {
                _panel_TOOTHBELT_EM_CMArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private GuBeaZenMicrowaveSensor_ArticleNo _panel_GuBeaZenMicrowaveSensorArtNo;
        public GuBeaZenMicrowaveSensor_ArticleNo Panel_GuBeaZenMicrowaveSensorArtNo
        {
            get
            {
                return _panel_GuBeaZenMicrowaveSensorArtNo;
            }

            set
            {
                _panel_GuBeaZenMicrowaveSensorArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private SlidingDoorKitGs100_1_ArticleNo _panel_SlidingDoorKitGs100_1ArtNo;
        public SlidingDoorKitGs100_1_ArticleNo Panel_SlidingDoorKitGs100_1ArtNo
        {
            get
            {
                return _panel_SlidingDoorKitGs100_1ArtNo;
            }

            set
            {
                _panel_SlidingDoorKitGs100_1ArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private GS100CoverKit_ArticleNo _panel_GS100CoverKitArtNo;
        public GS100CoverKit_ArticleNo Panel_GS100CoverKitArtNo
        {
            get
            {
                return _panel_GS100CoverKitArtNo;
            }

            set
            {
                _panel_GS100CoverKitArtNo = value;
                NotifyPropertyChanged();
            }
        }

        public int Panel_OverLappingPanelQty { get; set; }


        private AluminumPullHandle_ArticleNo _panel_AluminumPullHandleArtNo;
        public AluminumPullHandle_ArticleNo Panel_AluminumPullHandleArtNo

        {
            get
            {
                return _panel_AluminumPullHandleArtNo;
            }

            set
            {
                _panel_AluminumPullHandleArtNo = value;
                NotifyPropertyChanged();
            }
        }

        private SealingElement_ArticleNo _panelsealingElementArticleNo;
        public SealingElement_ArticleNo Panel_SealingElement_ArticleNo

        {
            get
            {
                return _panelsealingElementArticleNo;
            }

            set
            {
                _panelsealingElementArticleNo = value;
                NotifyPropertyChanged();
            }
        }


        public PlantOnWeatherStripHead_ArticleNo Panel_PlantOnWeatherStripHeadArtNo { get; set; }
        public PlantOnWeatherStripSeal_ArticleNo Panel_PlantOnWeatherStripSealArtNo { get; set; }
        public LouverFrameWeatherStripHead_ArticleNo Panel_LouverFrameWeatherStripHeadArtNo { get; set; }
        public LouverFrameBottomWeatherStrip_ArticleNo Panel_LouverFrameBottomWeatherStripArtNo { get; set; }
        public RubberSeal_ArticleNo Panel_RubberSealArtNo { get; set; }
        public CasementSeal_ArticleNo Panel_CasementSealArtNo { get; set; }
        public SealForHandle_ArticleNo Panel_SealForHandleArtNo { get; set; }
        public BubbleSeal_ArticleNo Panel_BubbleSealArtNo { get; set; }

        //public LouverGallerySet_ArticleNo Panel_LouvreGallerySetArtNo { get; set; }

        public int Panel_PlantOnWeatherStripHeadWidth { get; set; }
        public int Panel_PlantOnWeatherStripSealWidth { get; set; }
        public int Panel_LouverFrameWeatherStripHeadWidth { get; set; }
        public int Panel_LouverFrameBottomWeatherStripWidth { get; set; }
        public int Panel_RubberSealWidth { get; set; }
        public int Panel_CasementSealWidth { get; set; }
        public int Panel_SealForHandleQty { get; set; }
        public int Panel_LouvreGallerySetHeight { get; set; }

        int Panel_SealForHandleMultiplier;

        private bool _panel_LouverGallerySetVisibility;
        public bool Panel_LouverGallerySetVisibility
        {
            get
            {
                return _panel_LouverGallerySetVisibility;
            }

            set
            {
                _panel_LouverGallerySetVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private BladeHeight_Option _panel_LouverBladeHeight;
        public BladeHeight_Option Panel_LouverBladeHeight
        {
            get
            {
                return _panel_LouverBladeHeight;
            }

            set
            {
                _panel_LouverBladeHeight = value;
                NotifyPropertyChanged();
            }
        }

        private int _panel_LouverNumberBladesPerSet;
        public int Panel_LouverNumberBladesPerSet
        {
            get
            {
                return _panel_LouverNumberBladesPerSet;
            }

            set
            {
                _panel_LouverNumberBladesPerSet = value;
                NotifyPropertyChanged();
            }
        }
        private LouverHandleType_Option _panel_LouverHandleType;
        public LouverHandleType_Option Panel_LouverHandleType
        {
            get
            {
                return _panel_LouverHandleType;
            }

            set
            {
                _panel_LouverHandleType = value;
                NotifyPropertyChanged();
            }
        }

        private LouverHandleLoc_Option _panel_LouverHandleLocation;
        public LouverHandleLoc_Option Panel_LouverHandleLocation
        {
            get
            {
                return _panel_LouverHandleLocation;
            }

            set
            {
                _panel_LouverHandleLocation = value;
                NotifyPropertyChanged();
            }
        }

        private LouverColor_Option _panel_LouverGalleryColor;
        public LouverColor_Option Panel_LouverGalleryColor
        {
            get
            {
                return _panel_LouverGalleryColor;
            }

            set
            {
                _panel_LouverGalleryColor = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_LouverGalleryVisibility;
        public bool Panel_LouverGalleryVisibility
        {
            get
            {
                return _panel_LouverGalleryVisibility;
            }

            set
            {
                _panel_LouverGalleryVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private BladeType_Option _panel_LouverBladeTypeOption;
        public BladeType_Option Panel_LouverBladeTypeOption
        {
            get
            {
                return _panel_LouverBladeTypeOption;
            }

            set
            {
                _panel_LouverBladeTypeOption = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_LouverGallerySetOptionVisibility;
        public bool Panel_LouverGallerySetOptionVisibility
        {
            get
            {
                return _panel_LouverGallerySetOptionVisibility;
            }

            set
            {
                _panel_LouverGallerySetOptionVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private string _panel_LouverGallerySetOptionArtNo;
        public string Panel_LouverGallerySetOptionArtNo
        {
            get
            {
                return _panel_LouverGallerySetOptionArtNo;
            }

            set
            {
                _panel_LouverGallerySetOptionArtNo = value;
                NotifyPropertyChanged();
            }
        }
        public int Panel_LouverGallerySetCount { get; set; }

        public List<string> Panel_LstLouverArtNo { get; set; }
        public List<int> Panel_LstSealForHandleMultiplier { get; set; }

        private bool _panel_LouverMotorizeCheck;
        public bool Panel_LouverMotorizeCheck
        {
            get
            {
                return _panel_LouverMotorizeCheck;
            }

            set
            {
                _panel_LouverMotorizeCheck = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panel_LouverSecurityGrillCheck;
        public bool Panel_LouverSecurityGrillCheck
        {
            get
            {
                return _panel_LouverSecurityGrillCheck;
            }

            set
            {
                _panel_LouverSecurityGrillCheck = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Methods

        public void Set_LouverBladesCount()
        {
            #region OldAlgo 
            //if (Panel_LouvreGallerySetHeight <= 320)
            //{
            //    Panel_LouverBladesCount = 2;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15202SRHBlack;
            //    Panel_SealForHandleMultiplier = 1;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 321 && Panel_LouvreGallerySetHeight <= 460)
            //{
            //    Panel_LouverBladesCount = 3;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15203SRHBlack;
            //    Panel_SealForHandleMultiplier = 1;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 461 && Panel_LouvreGallerySetHeight <= 600)
            //{
            //    Panel_LouverBladesCount = 4;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15204SRHBlack;
            //    Panel_SealForHandleMultiplier = 1;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 601 && Panel_LouvreGallerySetHeight <= 740)
            //{
            //    Panel_LouverBladesCount = 5;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15205SRHBlack;
            //    Panel_SealForHandleMultiplier = 1;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 741 && Panel_LouvreGallerySetHeight <= 880)
            //{
            //    Panel_LouverBladesCount = 6;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15206SRHBlack;
            //    Panel_SealForHandleMultiplier = 1;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 881 && Panel_LouvreGallerySetHeight <= 1020)
            //{
            //    Panel_LouverBladesCount = 7;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15207SRHBlack;
            //    Panel_SealForHandleMultiplier = 2;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1021 && Panel_LouvreGallerySetHeight <= 1160)
            //{
            //    Panel_LouverBladesCount = 8;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15208SRHBlack;
            //    Panel_SealForHandleMultiplier = 2;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1161 && Panel_LouvreGallerySetHeight <= 1300)
            //{
            //    Panel_LouverBladesCount = 9;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15209SRHBlack;
            //    Panel_SealForHandleMultiplier = 2;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1301 && Panel_LouvreGallerySetHeight <= 1440)
            //{
            //    Panel_LouverBladesCount = 10;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15210SRHBlack;
            //    Panel_SealForHandleMultiplier = 2;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1401 && Panel_LouvreGallerySetHeight <= 1580)
            //{
            //    Panel_LouverBladesCount = 11;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15211SRHBlack;
            //    Panel_SealForHandleMultiplier = 2;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1581 && Panel_LouvreGallerySetHeight <= 1720)
            //{
            //    Panel_LouverBladesCount = 12;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15212SRHBlack;
            //    Panel_SealForHandleMultiplier = 2;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1721 && Panel_LouvreGallerySetHeight <= 1860)
            //{
            //    Panel_LouverBladesCount = 13;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15213SRHBlack;
            //    Panel_SealForHandleMultiplier = 3;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 1861 && Panel_LouvreGallerySetHeight <= 2000)
            //{
            //    Panel_LouverBladesCount = 14;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15214SRHBlack;
            //    Panel_SealForHandleMultiplier = 3;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 2001 && Panel_LouvreGallerySetHeight <= 2140)
            //{
            //    Panel_LouverBladesCount = 15;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15215SRHBlack;
            //    Panel_SealForHandleMultiplier = 3;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 2141 && Panel_LouvreGallerySetHeight <= 2280)
            //{
            //    Panel_LouverBladesCount = 16;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15216SRHBlack;
            //    Panel_SealForHandleMultiplier = 3;
            //}
            //else if (Panel_LouvreGallerySetHeight >= 2281 && Panel_LouvreGallerySetHeight <= 2420)
            //{
            //    Panel_LouverBladesCount = 17;
            //    //Panel_LouvreGallerySetArtNo = LouverGallerySet_ArticleNo._LVRG15217SRHBlack;
            //    Panel_SealForHandleMultiplier = 3;
            //}
            #endregion

            int lvrgDeduction = 0, lvrgHeigt = 0;
            if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502)
            {
                lvrgDeduction = 33;
            }
            else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
            {
                lvrgDeduction = 47;
            }

            Panel_LouvreGallerySetHeight = Panel_DisplayHeight - (lvrgDeduction * 2) - 12;
            lvrgHeigt = Panel_LouvreGallerySetHeight - 20; // -20 interval No of blades
            Panel_LouverBladesCount = (lvrgHeigt / 140);
        }

        public void Imager_SetDimensionsToBind_FrameParent()
        {
            //if (PanelImageRenderer_Zoom == 1.0f || PanelImageRenderer_Zoom == 0.50f)
            //{
            int padding_top = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Top,
                padding_bot = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Bottom,
                padding_left = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Left,
                padding_right = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Right;

            PanelImageRenderer_Width = Panel_ParentFrameModel.FrameImageRenderer_Width - (padding_left + padding_right);
            PanelImageRenderer_Height = Panel_ParentFrameModel.FrameImageRenderer_Height - (padding_top + padding_bot);
            //}
            //else
            //{
            //    int padding_top = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Top,
            //        padding_bot = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Bottom,
            //        padding_left = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Left,
            //        padding_right = Panel_ParentFrameModel.FrameImageRenderer_Padding_int.Right;
            //    PanelImageRenderer_Width = Panel_ParentFrameModel.FrameImageRenderer_Width - (padding_left + padding_right);
            //    PanelImageRenderer_Height = Panel_ParentFrameModel.FrameImageRenderer_Height - (padding_top + padding_bot);
            //}
        }

        public void SetPanelMargin_using_ZoomPercentage()
        {
            if ((Panel_Zoom == 0.26f || Panel_Zoom == 0.17f ||
                 Panel_Zoom == 0.13f || Panel_Zoom == 0.10f) &&
                Panel_ParentMultiPanelModel != null)
            {
                int right = 0,
                left = 0,
                top = 0,
                bot = 0;

                if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    right = (Panel_Margin.Right != 0) ? 5 : 0;
                    left = (Panel_Margin.Left != 0) ? 5 : 0;
                    top = (Panel_Margin.Top != 0) ? 5 : 0;
                    bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                }
                else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    right = (Panel_Margin.Right != 0) ? 10 : 0;
                    left = (Panel_Margin.Left != 0) ? 10 : 0;
                    top = (Panel_Margin.Top != 0) ? 10 : 0;
                    bot = (Panel_Margin.Bottom != 0) ? 10 : 0;

                    if (Panel_ParentMultiPanelModel.MPanel_ParentModel?.MPanel_ParentModel == null)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_ParentModel != null)
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                                Panel_ParentMultiPanelModel.MPanel_Type == "Transom") //M-T stack
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                    Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    left = (Panel_Margin.Left != 0) ? 5 : 0;
                                }
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom" &&
                                     Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") //T-M stack
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                    Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    top = (Panel_Margin.Top != 0) ? 5 : 0;
                                }
                            }
                        }
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel?.MPanel_ParentModel != null) //meaning 3-stack
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") //M-T-M
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Placement == "First")
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                {
                                    if (Panel_Placement == "Last")
                                    {
                                        right = (Panel_Margin.Right != 0) ? 5 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                         Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    top = (Panel_Margin.Top != 0) ? 5 : 0;

                                    if (Panel_Placement == "Last")
                                    {
                                        right = (Panel_Margin.Right != 0) ? 5 : 0;
                                    }
                                }
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                {
                                    if (Panel_Placement == "First")
                                    {
                                        left = (Panel_Margin.Left != 0) ? 5 : 0;
                                    }
                                    else if (Panel_Placement == "Last")
                                    {
                                        right = (Panel_Margin.Right != 0) ? 5 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                         Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    top = (Panel_Margin.Top != 0) ? 5 : 0;
                                    left = (Panel_Margin.Left != 0) ? 5 : 0;

                                    if (Panel_Placement == "Last")
                                    {
                                        right = (Panel_Margin.Right != 0) ? 5 : 0;
                                    }
                                }
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Placement == "Last")
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                {
                                    if (Panel_Placement == "First")
                                    {
                                        left = (Panel_Margin.Left != 0) ? 5 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                         Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    top = (Panel_Margin.Top != 0) ? 5 : 0;
                                    if (Panel_Placement == "First")
                                    {
                                        left = (Panel_Margin.Left != 0) ? 5 : 0;
                                    }
                                }
                            }
                        }
                        else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom") // T-M-T
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Placement == "First")
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                {
                                    if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                {
                                    left = (Panel_Margin.Left != 0) ? 5 : 0;

                                    if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    left = (Panel_Margin.Left != 0) ? 5 : 0;

                                    if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                                    }
                                }
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                {
                                    if (Panel_Placement == "First")
                                    {
                                        top = (Panel_Margin.Top != 0) ? 5 : 0;
                                    }
                                    else if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                         Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    left = (Panel_Margin.Left != 0) ? 5 : 0;

                                    if (Panel_Placement == "First")
                                    {
                                        top = (Panel_Margin.Top != 0) ? 5 : 0;
                                    }
                                    else if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                                    }
                                }
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Placement == "Last")
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                {
                                    if (Panel_Placement == "First")
                                    {
                                        top = (Panel_Margin.Top != 0) ? 5 : 0;
                                    }
                                    else if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 8 : 0;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between" ||
                                         Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    left = (Panel_Margin.Left != 0) ? 5 : 0;

                                    if (Panel_Placement == "First")
                                    {
                                        top = (Panel_Margin.Top != 0) ? 5 : 0;
                                    }
                                    else if (Panel_Placement == "Last")
                                    {
                                        bot = (Panel_Margin.Bottom != 0) ? 8 : 0;
                                    }
                                }
                            }
                        }
                    }
                }
                Panel_MarginToBind = new Padding(left, top, right, bot);
            }
            else
            {
                Panel_MarginToBind = new Padding((int)(Panel_Margin.Left * Panel_Zoom),
                                                 (int)(Panel_Margin.Top * Panel_Zoom),
                                                 (int)(Panel_Margin.Right * Panel_Zoom),
                                                 (int)(Panel_Margin.Bottom * Panel_Zoom));
            }
        }

        public void SetPanelMarginImager_using_ImageZoomPercentage()
        {
            if ((PanelImageRenderer_Zoom == 0.26f || PanelImageRenderer_Zoom == 0.17f ||
                 PanelImageRenderer_Zoom == 0.13f || PanelImageRenderer_Zoom == 0.13f) &&
                Panel_ParentMultiPanelModel != null)
            {
                int right = 0,
                left = 0,
                top = 0,
                bot = 0;

                if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    right = (Panel_Margin.Right != 0) ? 5 : 0;
                    left = (Panel_Margin.Left != 0) ? 5 : 0;
                    top = (Panel_Margin.Top != 0) ? 5 : 0;
                    bot = (Panel_Margin.Bottom != 0) ? 5 : 0;
                }
                else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    right = (Panel_Margin.Right != 0) ? 10 : 0;
                    left = (Panel_Margin.Left != 0) ? 10 : 0;
                    top = (Panel_Margin.Top != 0) ? 10 : 0;
                    bot = (Panel_Margin.Bottom != 0) ? 10 : 0;
                }

                PanelImageRenderer_Margin = new Padding(left, top, right, bot);
            }
            else
            {
                PanelImageRenderer_Margin = new Padding((int)(Panel_Margin.Left * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Top * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Right * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Bottom * PanelImageRenderer_Zoom));
            }
        }
        public void SetDimensionToBind_2ndlvl_using_BaseDimension()
        {
            //if (Panel_Zoom == 0.5 || Panel_Zoom == 1)
            //{
            if (Panel_ParentMultiPanelModel.MPanel_Parent.Name.Contains("Frame"))
            {


            }
            else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
            {
                int mpnl_deduct = 0;
                if (Panel_Zoom == 0.26f || Panel_Zoom == 0.17f ||
                    Panel_Zoom == 0.13f || Panel_Zoom == 0.10f)
                {
                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {

                        if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                        {
                            mpnl_deduct = 9;

                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                                mpnl_deduct = 9;
                            else
                                mpnl_deduct = 10;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                        {
                            mpnl_deduct = 9;

                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                                mpnl_deduct = 15;
                            else
                                mpnl_deduct = 15;
                        }
                    }
                }
                else if (Panel_Zoom == 0.5f)
                {
                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {

                        if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                        {
                            mpnl_deduct = 9;

                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                                mpnl_deduct = 9;
                            else
                                mpnl_deduct = 10;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                        {
                            mpnl_deduct = 11;

                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                                mpnl_deduct = 11;
                            else
                                mpnl_deduct = 11;
                        }
                    }


                }
                else
                {
                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                        {
                            mpnl_deduct = 16; // 8 + 8
                                              // left margin is 8
                                              // right margin is 8
                        }
                        else
                        {
                            mpnl_deduct = 18; // 10 + 8
                                              //if MPanel_Placement is "First"
                                              // left margin is 10
                                              // right margin is 8

                            //if MPanel_Placement is "Last"
                            // left margin is 8
                            // right margin is 10

                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                        {
                            mpnl_deduct = 20; // 10 + 10
                                              // left margin is 10
                                              // right margin is 10
                        }
                        else
                        {
                            mpnl_deduct = 20; // 13 + 10
                                              //if MPanel_Placement is "First"
                                              // left margin is 12
                                              // right margin is 10

                            //if MPanel_Placement is "Last"
                            // left margin is 10
                            // right margin is 12

                        }
                    }

                }
                if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {
                    Panel_HeightToBind = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - mpnl_deduct);
                    //Panel_WidthToBind = (int)(Panel_Width * Panel_Zoom);
                }
                else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    Panel_WidthToBind = (int)(Panel_ParentMultiPanelModel.MPanel_WidthToBind - mpnl_deduct);
                    //Panel_HeightToBind = (int)(Panel_Height * Panel_Zoom);
                }

            }
            //}
        }
        int first = 0;
        public void SetDimensionsToBind_using_ZoomPercentage()
        {


            int pnl_wd = 0, pnl_ht = 0,
                parent_mpanelWd = 0,
                parent_mpanelHT = 0,
                div_count = 0,
                totalpanel_inside_parentMpanel = 0,
                mpnlWd_deduct = 0,
                mpnlHt_deduct = 0,
                divSize = 0;

            if (Panel_Zoom == 0.26f || Panel_Zoom == 0.17f ||
                Panel_Zoom == 0.13f || Panel_Zoom == 0.10f)
            {
                if (Panel_ParentMultiPanelModel != null)
                {
                    bool isEqual = Panel_ParentMultiPanelModel.isDisplaySizeEqual();
                    parent_mpanelWd = Panel_ParentMultiPanelModel.MPanel_WidthToBind;
                    parent_mpanelHT = Panel_ParentMultiPanelModel.MPanel_HeightToBind;
                    div_count = Panel_ParentMultiPanelModel.MPanel_Divisions;
                    totalpanel_inside_parentMpanel = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;

                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        divSize = 13;

                        mpnlWd_deduct = 10;
                        mpnlHt_deduct = 10;
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        divSize = 16;
                    }

                    if (Panel_ParentMultiPanelModel.MPanel_ParentModel == null)
                    {
                        if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                                Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052)
                            {
                                mpnlWd_deduct = 20;
                                mpnlHt_deduct = 20;
                            }
                            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                            {
                                mpnlWd_deduct = 20;
                                mpnlHt_deduct = 15;
                            }
                            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                            {
                                mpnlWd_deduct = 20;
                                mpnlHt_deduct = 10;
                            }
                        }
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel == null) // 2-stack
                    {
                        if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                                Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052)
                            {
                                mpnlWd_deduct = 15;
                                mpnlHt_deduct = 20;

                                if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                                    Panel_ParentMultiPanelModel.MPanel_Type == "Transom") // M-T stack
                                {
                                    if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        mpnlWd_deduct = 10;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom" &&
                                         Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") //T-M -stack
                                {
                                    if (Panel_ParentMultiPanelModel.MPanel_Placement == "First" ||
                                        Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                    {
                                        mpnlHt_deduct = 16;
                                    }
                                    else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        mpnlHt_deduct = 10;
                                    }
                                }
                            }
                            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                            {
                                mpnlWd_deduct = 15;
                                mpnlHt_deduct = 15;

                                if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                                    Panel_ParentMultiPanelModel.MPanel_Type == "Transom") // M-T stack
                                {
                                    if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        mpnlWd_deduct = 10;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom" &&
                                         Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") // T-M stack
                                {
                                    if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        mpnlHt_deduct = 10;
                                    }
                                    else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                    {
                                        mpnlHt_deduct = 16;
                                    }
                                }
                            }
                            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                     Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                            {
                                mpnlWd_deduct = 15;
                                mpnlHt_deduct = 10;

                                if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                                    Panel_ParentMultiPanelModel.MPanel_Type == "Transom") //M-T stack
                                {
                                    if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                    {
                                        mpnlHt_deduct = 15;
                                    }
                                    else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                    {
                                        mpnlHt_deduct = 6;
                                    }
                                    else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                    {
                                        mpnlWd_deduct = 10;
                                    }
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom" &&
                                         Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") //T-M stack
                                {
                                    if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                                    {
                                        mpnlHt_deduct = 15;
                                    }
                                    else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                    {
                                        mpnlHt_deduct = 6;
                                    }
                                }
                            }
                        }
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel != null)
                    {
                        if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            mpnlWd_deduct = 15;
                            mpnlHt_deduct = 20;

                            if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type == "Transom") // T-M-T stack
                            {
                                if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                                {
                                    mpnlWd_deduct = 10;
                                }
                                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                                {
                                    mpnlWd_deduct = 14;
                                }
                            }
                        }
                    }

                    if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                    {
                        int panelSize = 0;
                        int totalPanelCount = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
                        foreach (IPanelModel pnl in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Name != Panel_Name)
                            {
                                panelSize += pnl.Panel_WidthToBind;
                            }

                        }
                        if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        {
                            if (Panel_ParentMultiPanelModel.isDisplaySizeEqual())
                            {
                                pnl_wd = ((parent_mpanelWd - mpnlWd_deduct) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions)) / totalPanelCount;
                            }
                            else
                            {
                                pnl_wd = ((parent_mpanelWd - mpnlWd_deduct) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions) - panelSize) / (totalPanelCount - (Panel_ParentMultiPanelModel.MPanelLst_Panel.Count - 1));
                            }
                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.isDisplaySizeEqual())
                            {
                                pnl_wd = ((parent_mpanelWd - mpnlWd_deduct)) / totalPanelCount;
                            }
                            else
                            {
                                pnl_wd = ((parent_mpanelWd - mpnlWd_deduct) - panelSize) / (totalPanelCount - (Panel_ParentMultiPanelModel.MPanelLst_Panel.Count - 1));
                            }
                        }
                        pnl_ht = parent_mpanelHT - mpnlHt_deduct;
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                    {
                        int panelSize = 0;
                        int totalPanelCount = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
                        foreach (IPanelModel pnl in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Name != Panel_Name)
                            {
                                panelSize += pnl.Panel_HeightToBind;
                            }

                        }
                        if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        {
                            if (Panel_ParentMultiPanelModel.isDisplaySizeEqual())
                            {
                                pnl_ht = ((parent_mpanelHT - mpnlHt_deduct) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions)) / totalPanelCount;
                            }
                            else
                            {
                                pnl_ht = ((parent_mpanelHT - mpnlHt_deduct) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions) - panelSize) / (totalPanelCount - (Panel_ParentMultiPanelModel.MPanelLst_Panel.Count - 1));
                            }


                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.isDisplaySizeEqual())
                            {
                                pnl_ht = ((parent_mpanelHT - mpnlHt_deduct)) / totalPanelCount;
                            }
                            else
                            {
                                pnl_ht = ((parent_mpanelHT - mpnlHt_deduct) - panelSize) / (totalPanelCount - (Panel_ParentMultiPanelModel.MPanelLst_Panel.Count - 1));
                            }
                        }
                        pnl_wd = parent_mpanelWd - mpnlWd_deduct;
                    }
                }
                else if (Panel_ParentFrameModel != null)
                {
                    int reversed_wd = (int)Math.Ceiling(Panel_ParentFrameModel.Frame_Width * Panel_Zoom) - 20, //padding
                        reversed_ht = (int)Math.Ceiling(Panel_ParentFrameModel.Frame_Height * Panel_Zoom) - 20; //padding

                    pnl_wd = (int)(reversed_wd / Panel_Zoom);
                    pnl_ht = (int)(reversed_ht / Panel_Zoom);
                }
            }
            else
            {
                if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                    Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052)
                {
                    mpnlWd_deduct = 20;
                    mpnlHt_deduct = 20;
                }
                else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                         Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                {
                    mpnlWd_deduct = 20;
                    mpnlHt_deduct = 15;
                }
                else if ((Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                          Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                          Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                          Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None) &&
                          Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    mpnlWd_deduct = 20;
                    mpnlHt_deduct = 10;
                }


                if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {
                    int panelSize = 0;
                    int totalPanelCount = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
                    foreach (IPanelModel pnl in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                    {
                        if (pnl.Panel_Name != Panel_Name)
                        {
                            panelSize += pnl.Panel_WidthToBind;
                        }
                    }
                    foreach (IMultiPanelModel mpnl in Panel_ParentMultiPanelModel.MPanelLst_MultiPanel)
                    {
                        panelSize += mpnl.MPanel_WidthToBind;
                    }
                    parent_mpanelWd = Panel_ParentMultiPanelModel.MPanel_WidthToBind;


                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        divSize = (int)((int)Frame_Padding.Window * Panel_Zoom);
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        divSize = (int)((int)Frame_Padding.Door * Panel_Zoom);
                    }
                    int totalWd_divModel = Panel_ParentMultiPanelModel.MPanelLst_Divider.Sum(div => div.Div_WidthToBind);
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {

                        if (Panel_ParentMultiPanelModel.isDisplaySizeEqual() || Panel_Placement == "First")
                        {
                            pnl_wd = ((parent_mpanelWd - (int)(20 * Panel_Zoom)) / totalPanelCount) - (int)(20 * Panel_Zoom);

                        }
                        else
                        {
                            //if (Panel_ParentMultiPanelModel.MPanelLst_Objects[0].Name.Contains("Multi"))
                            //{
                            //    pnl_wd = ((parent_mpanelWd - (int)(10 * Panel_Zoom)) - (totalWd_divModel) - panelSize) / (totalPanelCount - ((Panel_ParentMultiPanelModel.MPanelLst_Panel.Count + Panel_ParentMultiPanelModel.MPanelLst_MultiPanel.Count) - 1));

                            //}
                            //else
                            //{

                            pnl_wd = ((parent_mpanelWd - (int)(20 * Panel_Zoom)) - (totalWd_divModel) - panelSize) / (totalPanelCount - ((Panel_ParentMultiPanelModel.MPanelLst_Panel.Count + Panel_ParentMultiPanelModel.MPanelLst_MultiPanel.Count) - 1));

                            //}
                            if (Panel_Placement == "Last")
                            {
                                foreach (IPanelModel pnl in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                                {

                                }
                            }

                        }

                        //if (Panel_ParentMultiPanelModel.isDisplaySizeEqual() || Panel_Placement == "First")
                        //{
                        //    pnl_wd = ((parent_mpanelWd - (int)(20 * Panel_Zoom)) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions)) / totalPanelCount;

                        //}
                        //else
                        //{
                        //    if (Panel_ParentMultiPanelModel.MPanelLst_Objects[0].Name.Contains("Multi"))
                        //    {
                        //        pnl_wd = ((parent_mpanelWd - (int)(10 * Panel_Zoom)) - (totalWd_divModel) - panelSize) / (totalPanelCount - ((Panel_ParentMultiPanelModel.MPanelLst_Panel.Count + Panel_ParentMultiPanelModel.MPanelLst_MultiPanel.Count) - 1));

                        //    }
                        //    else
                        //    {
                        //        pnl_wd = ((parent_mpanelWd - (int)(20 * Panel_Zoom)) - (totalWd_divModel) - panelSize) / (totalPanelCount - ((Panel_ParentMultiPanelModel.MPanelLst_Panel.Count + Panel_ParentMultiPanelModel.MPanelLst_MultiPanel.Count) - 1));
                        //    }
                        //}
                    }
                    else
                    {
                        if (Panel_ParentMultiPanelModel.isDisplaySizeEqual() || Panel_Placement == "First")
                        {
                            pnl_wd = ((parent_mpanelWd - (int)(20 * Panel_Zoom))) / totalPanelCount;

                        }
                        else
                        {
                            pnl_wd = ((parent_mpanelWd - (int)(20 * Panel_Zoom)) - panelSize) / (totalPanelCount - (Panel_ParentMultiPanelModel.MPanelLst_Panel.Count - 1));
                        }
                    }
                    //if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                    //                 Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                    //{
                    //    pnl_ht = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (int)(Panel_Margin.Top * Panel_Zoom));
                    //}
                    //else
                    //{
                    //    pnl_ht = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (int)(Panel_Margin.Top * Panel_Zoom) - (int)(Panel_Margin.Bottom * Panel_Zoom));
                    //}

                    if (Panel_ParentMultiPanelModel.MPanel_Parent.Name.Contains("Frame"))
                    {
                        if ((Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None) &&
                             Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            pnl_ht = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (int)(Panel_Margin.Top * Panel_Zoom));
                        }
                        else
                        {
                            pnl_ht = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (20 * Panel_Zoom));

                        }
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {
                        pnl_ht = (int)(Panel_Height * Panel_Zoom);
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {

                        pnl_ht = (int)(Panel_Height * Panel_Zoom);
                    }
                }
                else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    int panelSize = 0;
                    int totalPanelCount = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
                    foreach (IPanelModel pnl in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                    {
                        if (pnl.Panel_Name != Panel_Name)
                        {
                            panelSize += pnl.Panel_HeightToBind;
                        }
                    }
                    foreach (IMultiPanelModel mpnl in Panel_ParentMultiPanelModel.MPanelLst_MultiPanel)
                    {
                        panelSize += mpnl.MPanel_HeightToBind;
                    }
                    parent_mpanelHT = Panel_ParentMultiPanelModel.MPanel_HeightToBind;
                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        divSize = (int)((int)Frame_Padding.Window * Panel_Zoom);
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        divSize = (int)((int)Frame_Padding.Door * Panel_Zoom);
                    }
                    int totalHt_divModel = Panel_ParentMultiPanelModel.MPanelLst_Divider.Sum(div => div.Div_HeightToBind);
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {
                        if (Panel_ParentMultiPanelModel.isDisplaySizeEqual() || Panel_Placement == "First")
                        {
                            pnl_ht = ((parent_mpanelHT - (int)(mpnlHt_deduct * Panel_Zoom)) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions)) / totalPanelCount;
                        }
                        else
                        {
                            if (Panel_ParentMultiPanelModel.MPanelLst_Objects[0].Name.Contains("Multi"))
                            {
                                pnl_ht = ((parent_mpanelHT - (int)(10 * Panel_Zoom)) - (totalHt_divModel) - panelSize) / (totalPanelCount - ((Panel_ParentMultiPanelModel.MPanelLst_Panel.Count + Panel_ParentMultiPanelModel.MPanelLst_MultiPanel.Count) - 1));

                            }
                            else
                            {
                                pnl_ht = ((parent_mpanelHT - (int)(mpnlHt_deduct * Panel_Zoom)) - (totalHt_divModel) - panelSize) / (totalPanelCount - ((Panel_ParentMultiPanelModel.MPanelLst_Panel.Count + Panel_ParentMultiPanelModel.MPanelLst_MultiPanel.Count) - 1));
                            }
                        }
                    }
                    else
                    {
                        if (Panel_ParentMultiPanelModel.isDisplaySizeEqual() || Panel_Placement == "First")
                        {
                            pnl_ht = ((parent_mpanelHT - (int)(20 * Panel_Zoom))) / totalPanelCount;
                        }
                        else
                        {
                            pnl_ht = ((parent_mpanelHT - (int)(20 * Panel_Zoom)) - panelSize) / (totalPanelCount - (Panel_ParentMultiPanelModel.MPanelLst_Panel.Count - 1));
                        }
                    }
                    //pnl_wd = (int)(Panel_Width * Panel_Zoom);

                    if (Panel_ParentMultiPanelModel.MPanel_Parent.Name.Contains("Frame"))
                    {
                        pnl_wd = (int)(Panel_ParentMultiPanelModel.MPanel_WidthToBind - (20 * Panel_Zoom));
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {
                        pnl_wd = (int)(Panel_Width * Panel_Zoom);
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {

                        pnl_wd = (int)(Panel_Width * Panel_Zoom);
                    }
                }
            }

            Panel_WidthToBind = pnl_wd;
            Panel_HeightToBind = pnl_ht;
        }

        public void Imager_SetDimensionsToBind_using_ZoomPercentage()
        {
            int pnl_wd = 0, pnl_ht = 0,
                parent_mpanelWd = 0,
                parent_mpanelHT = 0,
                div_count = 0,
                totalpanel_inside_parentMpanel = 0,
                divSize = 0;
            int panelTotalHt = 0, panelTotalWd = 0;
            int count = 0;
            int totalPanelCount = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
            if (PanelImageRenderer_Zoom == 0.26f || PanelImageRenderer_Zoom == 0.17f ||
                PanelImageRenderer_Zoom == 0.13f || PanelImageRenderer_Zoom == 0.10f)
            {
                if (Panel_ParentMultiPanelModel != null)
                {
                    bool isEqual = Panel_ParentMultiPanelModel.isDisplaySizeEqual();

                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        divSize = 13;
                    }
                    else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        divSize = 16;
                    }

                    parent_mpanelWd = Panel_ParentMultiPanelModel.MPanelImageRenderer_Width;
                    parent_mpanelHT = Panel_ParentMultiPanelModel.MPanelImageRenderer_Height;
                    div_count = Panel_ParentMultiPanelModel.MPanel_Divisions;
                    totalpanel_inside_parentMpanel = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;

                    foreach (IPanelModel pnl in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                    {
                        if (pnl.Panel_Name != Panel_Name)
                        {
                            panelTotalWd += pnl.PanelImageRenderer_Width;
                            panelTotalHt += pnl.PanelImageRenderer_Height;
                            count += 1;
                        }

                    }
                    if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                    {


                        if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        {
                            if (isEqual)
                            {
                                pnl_wd = ((parent_mpanelWd) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions)) / totalPanelCount;
                            }
                            else
                            {
                                pnl_wd = ((parent_mpanelWd) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions) - panelTotalWd) / (totalPanelCount - count);
                            }
                            //pnl_wd = (int)(Panel_Width * PanelImageRenderer_Zoom) - (3 * div_count);

                        }
                        else
                        {
                            if (isEqual)
                            {
                                pnl_wd = parent_mpanelWd / totalPanelCount;
                            }
                            else
                            {
                                pnl_wd = (parent_mpanelWd - panelTotalWd) / (totalPanelCount - count);
                            }
                            //pnl_wd = (int)(Panel_Width * PanelImageRenderer_Zoom);
                        }
                        pnl_ht = parent_mpanelHT;
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                    {

                        if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        {
                            if (isEqual)
                            {
                                pnl_ht = ((parent_mpanelHT) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions)) / totalPanelCount;
                            }
                            else
                            {
                                pnl_ht = ((parent_mpanelHT) - (divSize * Panel_ParentMultiPanelModel.MPanel_Divisions) - panelTotalHt) / (totalPanelCount - count);
                            }
                            //pnl_ht = (int)(Panel_Width * PanelImageRenderer_Zoom) - (3 * div_count);

                        }
                        else
                        {
                            if (isEqual)
                            {
                                pnl_ht = parent_mpanelHT / totalPanelCount;
                            }
                            else
                            {
                                pnl_ht = (parent_mpanelHT - panelTotalHt) / (totalPanelCount - count);
                            }
                            //pnl_ht = (int)(Panel_Width * PanelImageRenderer_Zoom);
                        }
                        pnl_wd = parent_mpanelWd;
                    }
                }
                else if (Panel_ParentFrameModel != null)
                {
                    int reversed_wd = (int)Math.Ceiling(Panel_ParentFrameModel.FrameImageRenderer_Width * PanelImageRenderer_Zoom) - 20, //padding
                        reversed_ht = (int)Math.Ceiling(Panel_ParentFrameModel.FrameImageRenderer_Height * PanelImageRenderer_Zoom) - 20; //padding

                    pnl_wd = (int)(reversed_wd / PanelImageRenderer_Zoom);
                    pnl_ht = (int)(reversed_ht / PanelImageRenderer_Zoom);
                }
            }
            else
            {
                int deduct = 0;
                if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    deduct = 3;
                }

                if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {
                        pnl_wd = (int)(Panel_Width * PanelImageRenderer_Zoom) - deduct;
                        pnl_ht = (int)(Panel_Height * PanelImageRenderer_Zoom);
                    }
                    else
                    {
                        decimal mpnlOriginalWidth = Panel_ParentMultiPanelModel.MPanel_Width - 20;
                        pnl_wd = Panel_ParentMultiPanelModel.MPanelImageRenderer_Width / totalPanelCount;
                        pnl_ht = (int)(Panel_Height * PanelImageRenderer_Zoom) - deduct;
                    }
                }
                else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {
                        pnl_ht = (int)(Panel_Height * PanelImageRenderer_Zoom) - deduct;
                        pnl_wd = (int)(Panel_Width * PanelImageRenderer_Zoom);
                    }
                    else
                    {
                        decimal mpnlOriginalHeight = Panel_ParentMultiPanelModel.MPanel_Height - 20;
                        pnl_ht = Panel_ParentMultiPanelModel.MPanelImageRenderer_Height / totalPanelCount;
                        pnl_wd = (int)(Panel_Width * PanelImageRenderer_Zoom) - deduct;
                    }
                }

            }
            PanelImageRenderer_Width = pnl_wd;
            PanelImageRenderer_Height = pnl_ht;
        }
        public void SetDimensionToBind_using_BaseDimension()
        {
            if (Panel_ParentMultiPanelModel != null)
            {
                int deduct = 0;
                if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                {

                    deduct = (int)(20 * Panel_Zoom);
                    if (Panel_Zoom == 1)
                    {
                        deduct -= 4;
                    }
                }
                else if (Panel_ParentMultiPanelModel.MPanel_Placement == "First" ||
                         Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                {
                    deduct = (int)(16 * Panel_Zoom);
                    deduct += 2;
                }
                if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {

                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {
                        Panel_HeightToBind = (int)(Panel_Height * Panel_Zoom);
                    }
                    else
                    {
                        int mpnlOriginalHeight = Panel_ParentMultiPanelModel.MPanel_Height - 20;

                        int pnl_ht = Convert.ToInt32(Math.Floor((decimal)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (20 * Panel_Zoom)) * ((decimal)Panel_Height / mpnlOriginalHeight)));
                        Panel_HeightToBind = pnl_ht;
                    }

                    if (Panel_ParentMultiPanelModel.MPanel_Parent.Name.Contains("Frame"))
                    {
                        Panel_WidthToBind = (int)(Panel_Width * Panel_Zoom);
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {
                        Panel_WidthToBind = (int)(Panel_ParentMultiPanelModel.MPanel_WidthToBind - deduct);
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {

                        Panel_WidthToBind = (int)(Panel_Width * Panel_Zoom);
                    }
                }
                else
                {
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {
                        Panel_WidthToBind = (int)(Panel_Width * Panel_Zoom);
                    }
                    else
                    {
                        int mpnlOriginalWidth = Panel_ParentMultiPanelModel.MPanel_Width - 20;
                        int pnl_wd = Convert.ToInt32(Math.Floor((decimal)(Panel_ParentMultiPanelModel.MPanel_WidthToBind - (20 * Panel_Zoom)) * ((decimal)Panel_Width / mpnlOriginalWidth)));
                        Panel_WidthToBind = pnl_wd;

                    }


                    if (Panel_ParentMultiPanelModel.MPanel_Parent.Name.Contains("Frame"))
                    {

                        if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            deduct = 3;
                        }


                        if ((Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None) &&
                             Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            Panel_HeightToBind = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (int)(Panel_Margin.Top * Panel_Zoom));
                        }
                        else
                        {
                            Panel_HeightToBind = (int)(Panel_Height * Panel_Zoom);
                        }
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {



                        if ((Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None) &&
                             Panel_ParentMultiPanelModel.MPanel_Placement == "Last" &&
                             Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            Panel_HeightToBind = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - (int)(Panel_Margin.Top * Panel_Zoom));
                        }
                        else
                        {
                            Panel_HeightToBind = (int)(Panel_ParentMultiPanelModel.MPanel_HeightToBind - deduct);
                        }
                    }
                    else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                    {

                        Panel_HeightToBind = (int)(Panel_Height * Panel_Zoom);
                    }
                }
            }

            else
            {
                Panel_WidthToBind = (int)(Panel_Width * Panel_Zoom);
                Panel_HeightToBind = (int)(Panel_Height * Panel_Zoom);
            }
        }
        public void SetDimensionImagerToBind_using_BaseDimension()
        {
            PanelImageRenderer_Width = Convert.ToInt32(Panel_Width * PanelImageRenderer_Zoom) - 10;
            PanelImageRenderer_Height = Convert.ToInt32(Panel_Height * PanelImageRenderer_Zoom);
        }

        public void SetDimensionsToBind_usingZoom_below26_with_DividerMovement()
        {
            int pnl_wd = 0, pnl_ht = 0, divMove_int = 0, div_movement = 0,
                divSize = 0, mpnlWd_deduct = 0, mpnlHt_deduct = 0;

            if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                divSize = 13;

                mpnlWd_deduct = 10;
                mpnlHt_deduct = 10;
            }
            else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                divSize = 16;
                if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                    Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052)
                {
                    mpnlWd_deduct = 20;
                    mpnlHt_deduct = 20;
                    if (Panel_ParentMultiPanelModel.MPanel_ParentModel != null)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom" &&
                            Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") // T-M stack
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                            {
                                mpnlWd_deduct = 10;
                                mpnlHt_deduct = 10;
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_Placement == "First" ||
                                     Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                            {
                                mpnlHt_deduct = 16;
                            }
                        }
                        else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                                 Panel_ParentMultiPanelModel.MPanel_Type == "Transom") // M-T stack
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Placement == "First" ||
                                Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                            {
                                mpnlWd_deduct = 16;
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                            {
                                mpnlWd_deduct = 10;
                            }
                        }
                    }
                }
                else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                         Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                {
                    mpnlWd_deduct = 20;
                    mpnlHt_deduct = 16;
                    if (Panel_ParentMultiPanelModel.MPanel_ParentModel != null)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                        Panel_ParentMultiPanelModel.MPanel_Type == "Transom") // M-T stack
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Placement == "First" ||
                                Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                            {
                                mpnlWd_deduct = 15;
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                            {
                                mpnlWd_deduct = 10;
                            }
                        }
                    }
                }
                else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                         Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                         Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                         Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                {
                    mpnlWd_deduct = 20;
                    mpnlHt_deduct = 10;
                    if (Panel_ParentMultiPanelModel.MPanel_ParentModel != null)
                    {
                        if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Mullion" &&
                        Panel_ParentMultiPanelModel.MPanel_Type == "Transom") //M-T stack
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                            {
                                mpnlWd_deduct = 15;
                                mpnlHt_deduct = 5;
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                            {
                                mpnlWd_deduct = 15;
                                mpnlHt_deduct = 15;
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_Placement == "Somewhere in Between")
                            {
                                mpnlWd_deduct = 10;
                            }
                        }
                        else if (Panel_ParentMultiPanelModel.MPanel_ParentModel.MPanel_Type == "Transom" &&
                            Panel_ParentMultiPanelModel.MPanel_Type == "Mullion") //T-M stack
                        {
                            if (Panel_ParentMultiPanelModel.MPanel_Placement == "Last")
                            {
                                mpnlHt_deduct = 5;
                            }
                            else if (Panel_ParentMultiPanelModel.MPanel_Placement == "First")
                            {
                                mpnlHt_deduct = 15;
                            }
                        }
                    }
                }
            }
            if (Panel_ParentMultiPanelModel != null)
            {
                int parent_MpanelWidth = Panel_ParentMultiPanelModel.MPanel_WidthToBind,
                    parent_MpanelHeight = Panel_ParentMultiPanelModel.MPanel_HeightToBind,
                    div_count = Panel_ParentMultiPanelModel.MPanel_Divisions,
                    sashDeduction = 0,
                    totalpanel_inside_parentMpanel = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;

                int OverlapLeftRight = 0, OverlapBoth = 0;



                foreach (IPanelModel pnls in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                {
                    if (pnls.Panel_Overlap_Sash == OverlapSash._Left ||
                        pnls.Panel_Overlap_Sash == OverlapSash._Right)
                    {
                        OverlapLeftRight += 1;
                    }
                    else if (pnls.Panel_Overlap_Sash == OverlapSash._Both)
                    {
                        OverlapBoth += 1;
                    }
                }

                int inner_line = 0;
                int ndx_zoomPercentage = Array.IndexOf(Panel_ParentFrameModel.Frame_WindoorModel.Arr_ZoomPercentage, Panel_ParentFrameModel.Frame_Zoom);
                if (ndx_zoomPercentage >= 3)
                {
                    inner_line = 16;
                }
                else if (ndx_zoomPercentage == 2)
                {
                    inner_line = 8;
                }
                else if (ndx_zoomPercentage == 1)
                {
                    inner_line = 7;
                }
                else if (ndx_zoomPercentage == 0)
                {
                    inner_line = 7;
                }
                foreach (IPanelModel pnls in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                {
                    if (pnls.Panel_Name == Panel_Name)
                    {

                        if (pnls.Panel_Overlap_Sash == OverlapSash._Left ||
                           pnls.Panel_Overlap_Sash == OverlapSash._Right)
                        {
                            sashDeduction -= inner_line;
                            sashDeduction += (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                            sashDeduction += (OverlapLeftRight - 1) * (inner_line / totalpanel_inside_parentMpanel);
                            sashDeduction += OverlapBoth * ((inner_line / totalpanel_inside_parentMpanel) * 2);
                        }
                        else if (pnls.Panel_Overlap_Sash == OverlapSash._Both)
                        {
                            sashDeduction -= (inner_line * 2);
                            sashDeduction += ((int)Math.Ceiling((decimal)inner_line / totalpanel_inside_parentMpanel) * 2);
                            sashDeduction += OverlapLeftRight * (inner_line / totalpanel_inside_parentMpanel);
                            sashDeduction += (OverlapBoth - 1) * ((inner_line / totalpanel_inside_parentMpanel) * 2);
                        }
                        else
                        {
                            sashDeduction += ((inner_line / totalpanel_inside_parentMpanel) * OverlapLeftRight) + (((inner_line / totalpanel_inside_parentMpanel) * 2) * OverlapBoth);
                        }
                    }
                }
                if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {
                    div_movement = ((Panel_ParentMultiPanelModel.MPanel_DisplayWidth / totalpanel_inside_parentMpanel) - Panel_DisplayWidth);
                    decimal divMove_convert_dec = Convert.ToDecimal(div_movement * Panel_Zoom);
                    decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                    decimal divMove_dec_times2 = divMove_dec * 2;
                    divMove_int = Convert.ToInt32(divMove_dec_times2);
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        pnl_wd = (((parent_MpanelWidth - mpnlWd_deduct) - (divSize * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                    else
                    {
                        //if(_panelOverlapSash == OverlapSash._Left || _panelOverlapSash ==  OverlapSash._Right)
                        //{
                        //    divMove_int += (int) (Panel_Zoom * 32);
                        //}
                        pnl_wd = ((parent_MpanelWidth - mpnlWd_deduct) / totalpanel_inside_parentMpanel) - divMove_int + sashDeduction;
                    }
                    pnl_ht = parent_MpanelHeight - mpnlHt_deduct;
                }
                else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    div_movement = ((Panel_ParentMultiPanelModel.MPanel_DisplayHeight / totalpanel_inside_parentMpanel) - Panel_DisplayHeight);

                    decimal divMove_convert_dec = Convert.ToDecimal(div_movement * Panel_Zoom);
                    decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                    decimal divMove_dec_times2 = divMove_dec * 2;
                    divMove_int = Convert.ToInt32(divMove_dec_times2);
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        pnl_ht = (((parent_MpanelHeight - mpnlHt_deduct) - (divSize * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                    else
                    {
                        pnl_ht = ((parent_MpanelHeight - mpnlHt_deduct) / totalpanel_inside_parentMpanel) - divMove_int;
                    }

                    pnl_wd = parent_MpanelWidth - mpnlWd_deduct;
                }
            }
            else if (Panel_ParentFrameModel != null)
            {
                int reversed_wd = (int)Math.Ceiling(Panel_ParentFrameModel.Frame_Width * Panel_Zoom) - 20, //20px padding
                    reversed_ht = (int)Math.Ceiling(Panel_ParentFrameModel.Frame_Height * Panel_Zoom) - 20; //20px padding

                pnl_wd = (int)(reversed_wd / Panel_Zoom);
                pnl_ht = (int)(reversed_ht / Panel_Zoom);
            }

            Panel_WidthToBind = pnl_wd;
            Panel_HeightToBind = pnl_ht;
        }

        public void Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement()
        {
            int pnl_wd = 0, pnl_ht = 0, divMove_int = 0, div_movement = 0;




            if (Panel_ParentMultiPanelModel != null)
            {
                int parent_MpanelWidth = Panel_ParentMultiPanelModel.MPanelImageRenderer_Width,
                    parent_MpanelHeight = Panel_ParentMultiPanelModel.MPanelImageRenderer_Height,
                    div_count = Panel_ParentMultiPanelModel.MPanel_Divisions,
                    sashDeduction = 0,
                    totalpanel_inside_parentMpanel = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;

                int OverlapLeftRight = 0, OverlapBoth = 0;



                foreach (IPanelModel pnls in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                {
                    if (pnls.Panel_Overlap_Sash == OverlapSash._Left ||
                        pnls.Panel_Overlap_Sash == OverlapSash._Right)
                    {
                        OverlapLeftRight += 1;
                    }
                    else if (pnls.Panel_Overlap_Sash == OverlapSash._Both)
                    {
                        OverlapBoth += 1;
                    }
                }


                foreach (IPanelModel pnls in Panel_ParentMultiPanelModel.MPanelLst_Panel)
                {
                    if (pnls.Panel_Name == Panel_Name)
                    {

                        if (pnls.Panel_Overlap_Sash == OverlapSash._Left ||
                           pnls.Panel_Overlap_Sash == OverlapSash._Right)
                        {
                            sashDeduction -= 16;
                            sashDeduction += (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                            sashDeduction += (OverlapLeftRight - 1) * (16 / totalpanel_inside_parentMpanel);
                            sashDeduction += OverlapBoth * ((16 / totalpanel_inside_parentMpanel) * 2);
                        }
                        else if (pnls.Panel_Overlap_Sash == OverlapSash._Both)
                        {
                            sashDeduction -= 32;
                            sashDeduction += ((int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel) * 2);
                            sashDeduction += OverlapLeftRight * (16 / totalpanel_inside_parentMpanel);
                            sashDeduction += (OverlapBoth - 1) * ((16 / totalpanel_inside_parentMpanel) * 2);
                        }
                        else
                        {
                            sashDeduction += ((16 / totalpanel_inside_parentMpanel) * OverlapLeftRight) + (((16 / totalpanel_inside_parentMpanel) * 2) * OverlapBoth);
                        }
                    }
                }
                if (Panel_ParentMultiPanelModel.MPanel_Type == "Mullion")
                {

                    div_movement = ((Panel_ParentMultiPanelModel.MPanel_DisplayWidth / totalpanel_inside_parentMpanel) - Panel_DisplayWidth);
                    decimal divMove_convert_dec = Convert.ToDecimal(div_movement * PanelImageRenderer_Zoom);
                    decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                    decimal divMove_dec_times2 = divMove_dec * 2;
                    divMove_int = Convert.ToInt32(divMove_dec_times2);
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                    {
                        pnl_wd = ((parent_MpanelWidth - (13 * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                        //pnl_wd = (int)(Panel_Width * PanelImageRenderer_Zoom) ;
                    }
                    else
                    {
                        //int mpnlOriginalWidth = Panel_ParentMultiPanelModel.MPanel_Width - 20;
                        //pnl_wd = Convert.ToInt32(Math((decimal)(Panel_ParentMultiPanelModel.MPanelImageRenderer_Width) * ((decimal)Panel_Width / mpnlOriginalWidth)));
                        ////Panel_WidthToBind = pnl_wd;
                        ////Panel_HeightToBind = Panel_ParentMultiPanelModel.MPanel_HeightToBind;


                        pnl_wd = (parent_MpanelWidth / totalpanel_inside_parentMpanel) - divMove_int + sashDeduction;
                    }
                    //pnl_wd = ((parent_MpanelWidth) / totalpanel_inside_parentMpanel) - divMove_int;
                    pnl_ht = parent_MpanelHeight;
                }
                else if (Panel_ParentMultiPanelModel.MPanel_Type == "Transom")
                {
                    div_movement = ((Panel_ParentMultiPanelModel.MPanel_DisplayHeight / totalpanel_inside_parentMpanel) - Panel_DisplayHeight);
                    decimal divMove_convert_dec = Convert.ToDecimal(div_movement * PanelImageRenderer_Zoom);
                    decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                    decimal divMove_dec_times2 = divMove_dec * 2;
                    divMove_int = Convert.ToInt32(divMove_dec_times2);
                    if (Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                        pnl_ht = (((parent_MpanelHeight) - (13 * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                    else
                    {
                        pnl_ht = (parent_MpanelHeight / totalpanel_inside_parentMpanel) - divMove_int;
                    }

                    pnl_wd = parent_MpanelWidth;
                }
            }
            else if (Panel_ParentFrameModel != null)
            {
                int reversed_wd = (int)Math.Ceiling(Panel_ParentFrameModel.Frame_Width * Panel_Zoom) - 20, //20px padding
                    reversed_ht = (int)Math.Ceiling(Panel_ParentFrameModel.Frame_Height * Panel_Zoom) - 20; //20px padding

                pnl_wd = (int)(reversed_wd / PanelImageRenderer_Zoom);
                pnl_ht = (int)(reversed_ht / PanelImageRenderer_Zoom);
                //pnl_wd = (int)(Panel_Width * Panel_Zoom) - reversed_wd;
                //pnl_ht = (int)(Panel_Height * Panel_Zoom) - reversed_ht;
            }

            PanelImageRenderer_Width = pnl_wd;
            PanelImageRenderer_Height = pnl_ht;
        }

        public void AdjustPropertyPanelHeight(string mode)
        {
            if (mode == "addChkMotorized")
            {
                Panel_PropertyHeight += constants.panel_property_motorizedChkOptionsheight;
            }
            else if (mode == "minusChkMotorized")
            {
                Panel_PropertyHeight -= constants.panel_property_motorizedChkOptionsheight;
            }
            else if (mode == "addCmbMotorized")
            {
                Panel_PropertyHeight += constants.panel_property_motorizedCmbOptionsheight;
            }
            else if (mode == "minusCmbMotorized")
            {
                Panel_PropertyHeight -= constants.panel_property_motorizedCmbOptionsheight;
            }
            else if (mode == "addSash")
            {
                Panel_PropertyHeight += constants.panel_property_sashPanelHeight;
            }
            else if (mode == "minusSash")
            {
                Panel_PropertyHeight -= constants.panel_property_sashPanelHeight;
            }
            else if (mode == "addGlass")
            {
                //if (Panel_Type.Contains("Louver"))
                //{
                //    Panel_PropertyHeight += constants.panel_property_LouverOptionsheight;
                //}
                //else
                //{
                Panel_PropertyHeight += constants.panel_property_glassOptionsHeight;
                //}
            }
            else if (mode == "addHandle")
            {
                Panel_PropertyHeight += constants.panel_property_handleOptionsHeight;
            }
            else if (mode == "minusHandle")
            {
                Panel_PropertyHeight -= constants.panel_property_handleOptionsHeight;
            }
            else if (mode == "addRotoswing")
            {
                Panel_PropertyHeight += constants.panel_property_rotoswingOptionsheight_default;
            }
            else if (mode == "minusRotoswing")
            {
                Panel_PropertyHeight -= constants.panel_property_rotoswingOptionsheight_default;
            }
            else if (mode == "addRotary")
            {
                Panel_PropertyHeight += constants.panel_property_rotaryOptionsheight_default;
            }
            else if (mode == "minusRotary")
            {
                Panel_PropertyHeight -= constants.panel_property_rotaryOptionsheight_default;
            }
            else if (mode == "addRio")
            {
                Panel_PropertyHeight += constants.panel_property_rioOptionsheight_default;
            }
            else if (mode == "minusRio")
            {
                Panel_PropertyHeight -= constants.panel_property_rioOptionsheight_default;
            }
            else if (mode == "addRotoline")
            {
                Panel_PropertyHeight += constants.panel_property_rotolineOptionsheight_default;
            }
            else if (mode == "minusRotoline")
            {
                Panel_PropertyHeight -= constants.panel_property_rotolineOptionsheight_default;
            }
            else if (mode == "addMVD")
            {
                Panel_PropertyHeight += constants.panel_property_mvdOptionsheight_default;
            }
            else if (mode == "minusMVD")
            {
                Panel_PropertyHeight -= constants.panel_property_mvdOptionsheight_default;
            }
            else if (mode == "addExtension")
            {
                Panel_PropertyHeight += constants.panel_property_extensionOptionsheight;
            }
            else if (mode == "minusExtension")
            {
                Panel_PropertyHeight -= constants.panel_property_extensionOptionsheight;
            }
            else if (mode == "addExtensionField")
            {
                Panel_PropertyHeight += constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "minusExtensionField")
            {
                Panel_PropertyHeight -= constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "addCornerDrive")
            {
                Panel_PropertyHeight += constants.panel_property_cornerDriveOptionsheight_default;
            }
            else if (mode == "minusCornerDrive")
            {
                Panel_PropertyHeight -= constants.panel_property_cornerDriveOptionsheight_default;
            }
            else if (mode == "addGeorgianBar")
            {
                Panel_PropertyHeight += constants.panel_property_georgianBarHeight;
            }
            else if (mode == "minusGeorgianBar")
            {
                Panel_PropertyHeight -= constants.panel_property_georgianBarHeight;
            }
            else if (mode == "addEspagnolette")
            {
                Panel_PropertyHeight += constants.panel_property_espagnoletteOptionsheight_default;
            }
            else if (mode == "minusEspagnolette")
            {
                Panel_PropertyHeight -= constants.panel_property_espagnoletteOptionsheight_default;
            }
            else if (mode == "addHinge")
            {
                Panel_PropertyHeight += constants.panel_property_HingeOptionsheight;
            }
            else if (mode == "minusHinge")
            {
                Panel_PropertyHeight -= constants.panel_property_HingeOptionsheight;
            }
            else if (mode == "addCenterHinge")
            {
                Panel_PropertyHeight += constants.panel_property_CenterHingeOptionsheight;
            }
            else if (mode == "minusCenterHinge")
            {
                Panel_PropertyHeight -= constants.panel_property_CenterHingeOptionsheight;
            }
            else if (mode == "addNTCenterHinge")
            {
                Panel_PropertyHeight += constants.panel_property_NTCenterHingeOptionsheight;
            }
            else if (mode == "minusNTCenterHinge")
            {
                Panel_PropertyHeight -= constants.panel_property_NTCenterHingeOptionsheight;
            }
            else if (mode == "add2dHingeField")
            {
                Panel_PropertyHeight += constants.panel_property_2dHingeOptionsheight;
            }
            else if (mode == "minus2dHingeField")
            {
                Panel_PropertyHeight -= constants.panel_property_2dHingeOptionsheight;
            }
            else if (mode == "add3dHinge")
            {
                Panel_PropertyHeight += constants.panel_property_3dHingeOptionsheight;
            }
            else if (mode == "minus3dHinge")
            {
                Panel_PropertyHeight -= constants.panel_property_3dHingeOptionsheight;
            }
            else if (mode == "addMC")
            {
                Panel_PropertyHeight += constants.panel_property_MiddleCloserOptionsheight;
            }
            else if (mode == "minusMC")
            {
                Panel_PropertyHeight -= constants.panel_property_MiddleCloserOptionsheight;
            }
            else if (mode == "addSlidingType")
            {
                Panel_PropertyHeight += constants.panel_property_SlidingTypeOptionsheight;
            }
            else if (mode == "minusSlidingType")
            {
                Panel_PropertyHeight -= constants.panel_property_SlidingTypeOptionsheight;
            }
            else if (mode == "addRollerType")
            {
                Panel_PropertyHeight += constants.panel_property_RollerTypeOptionsheight;
            }
            else if (mode == "minusRollerType")
            {
                Panel_PropertyHeight -= constants.panel_property_RollerTypeOptionsheight;
            }
            else if (mode == "addAluminumTrackQty")
            {
                Panel_PropertyHeight += constants.panel_property_AluminumTrackQtyOptionsheight;
            }
            else if (mode == "minusAluminumTrackQty")
            {
                Panel_PropertyHeight -= constants.panel_property_AluminumTrackQtyOptionsheight;
            }
            else if (mode == "addDHandle")
            {
                Panel_PropertyHeight += constants.panel_property_DHandleOptionsheight;
            }
            else if (mode == "minusDHandle")
            {
                Panel_PropertyHeight -= constants.panel_property_DHandleOptionsheight;
            }
            else if (mode == "addDHandleIOLocking")
            {
                Panel_PropertyHeight += constants.panel_property_DhandleIOLockingOptionsheight;
            }
            else if (mode == "minusDHandleIOLocking")
            {
                Panel_PropertyHeight -= constants.panel_property_DhandleIOLockingOptionsheight;
            }
            else if (mode == "addDummyDHandle")
            {
                Panel_PropertyHeight += constants.panel_property_DummyDHandleOptionsheight;
            }
            else if (mode == "minusDummyDHandle")
            {
                Panel_PropertyHeight -= constants.panel_property_DummyDHandleOptionsheight;
            }
            else if (mode == "addPopUpHandle")
            {
                Panel_PropertyHeight += constants.panel_property_PopUpHandleOptionsheight;
            }
            else if (mode == "minusPopUpHandle")
            {
                Panel_PropertyHeight -= constants.panel_property_PopUpHandleOptionsheight;
            }
            else if (mode == "addRotoswingForSliding")
            {
                Panel_PropertyHeight += constants.panel_property_RotoswingForSlidingOptionsheight;
            }
            else if (mode == "minusRotoswingForSliding")
            {
                Panel_PropertyHeight -= constants.panel_property_RotoswingForSlidingOptionsheight;
            }
            //else if (mode == "minusLouver")
            //{
            //    Panel_PropertyHeight -= constants.panel_property_LouverOptionsheight;
            //}
            else if (mode == "addLouverBlades")
            {
                Panel_PropertyHeight += constants.panel_property_LouverBladesOptionsheight;
            }
            else if (mode == "minusLouverBlades")
            {
                Panel_PropertyHeight -= constants.panel_property_LouverBladesOptionsheight;
            }
            else if (mode == "addLouverGallery")
            {
                Panel_PropertyHeight += constants.panel_property_LouverGalleryOptionsheight;
            }
            else if (mode == "minusLouverGallery")
            {
                Panel_PropertyHeight -= constants.panel_property_LouverGalleryOptionsheight;
            }
            else if (mode == "addLouverGallerySet")
            {
                Panel_PropertyHeight += constants.panel_property_LouverGallerySetOptionsheight;
            }
            else if (mode == "minusLouverGallerySet")
            {
                Panel_PropertyHeight -= constants.panel_property_LouverGallerySetOptionsheight;
            }
            else if (mode == "addLouverGallerySetArtNo")
            {
                Panel_PropertyHeight += constants.panel_property_LouverGallerySetArtNoOptionsheight;
            }
            else if (mode == "minusLouverGallerySetArtNo")
            {
                Panel_PropertyHeight -= constants.panel_property_LouverGallerySetArtNoOptionsheight;
            }
            else if (mode == "addLouverGlassDeduction")
            {
                Panel_PropertyHeight += constants.panel_property_LouverGlassheightDeduction;
            }
            else if (mode == "minusLouverGlassDeduction")
            {
                Panel_PropertyHeight -= constants.panel_property_LouverGlassheightDeduction;
            }

        }

        public void AdjustMotorizedPropertyHeight(string mode)
        {
            if (mode == "chkMotorizedOnly")
            {
                Panel_MotorizedPropertyHeight = constants.panel_property_motorizedChkOptionsheight;
            }
            else if (mode == "whole")
            {
                Panel_MotorizedPropertyHeight = constants.panel_property_motorizedOptionsheight;
            }
        }

        public void AdjustHandlePropertyHeight(string mode)
        {
            if (mode == "addRotoswing")
            {
                Panel_HandleOptionsHeight += constants.panel_property_rotoswingOptionsheight_default;
            }
            else if (mode == "minusRotoswing")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_rotoswingOptionsheight_default;
            }
            else if (mode == "addRotary")
            {
                Panel_HandleOptionsHeight += constants.panel_property_rotaryOptionsheight_default;
            }
            else if (mode == "minusRotary")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_rotaryOptionsheight_default;
            }
            else if (mode == "addRio")
            {
                Panel_HandleOptionsHeight += constants.panel_property_rioOptionsheight_default;
            }
            else if (mode == "minusRio")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_rioOptionsheight_default;
            }
            else if (mode == "addRotoline")
            {
                Panel_HandleOptionsHeight += constants.panel_property_rotolineOptionsheight_default;
            }
            else if (mode == "minusRotoline")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_rotolineOptionsheight_default;
            }
            else if (mode == "addMVD")
            {
                Panel_HandleOptionsHeight += constants.panel_property_mvdOptionsheight_default;
            }
            else if (mode == "minusMVD")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_mvdOptionsheight_default;
            }
            else if (mode == "addExtension")
            {
                Panel_HandleOptionsHeight += constants.panel_property_extensionOptionsheight;
            }
            else if (mode == "minusExtension")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_extensionOptionsheight;
            }
            else if (mode == "addExtensionField")
            {
                Panel_HandleOptionsHeight += constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "minusExtensionField")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "addCornerDrive")
            {
                Panel_HandleOptionsHeight += constants.panel_property_cornerDriveOptionsheight_default;
            }
            else if (mode == "minusCornerDrive")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_cornerDriveOptionsheight_default;
            }
            else if (mode == "addEspagnolette")
            {
                Panel_HandleOptionsHeight += constants.panel_property_espagnoletteOptionsheight_default;
            }
            else if (mode == "minusEspagnolette")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_espagnoletteOptionsheight_default;
            }
            else if (mode == "addDHandle")
            {
                Panel_HandleOptionsHeight += constants.panel_property_DHandleOptionsheight;
            }
            else if (mode == "minusDHandle")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_DHandleOptionsheight;
            }
            else if (mode == "addDHandleIOLocking")
            {
                Panel_HandleOptionsHeight += constants.panel_property_DhandleIOLockingOptionsheight;
            }
            else if (mode == "minusDHandleIOLocking")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_DhandleIOLockingOptionsheight;
            }
            else if (mode == "addDummyDHandle")
            {
                Panel_HandleOptionsHeight += constants.panel_property_DummyDHandleOptionsheight;
            }
            else if (mode == "minusDummyDHandle")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_DummyDHandleOptionsheight;
            }
            else if (mode == "addPopUpHandle")
            {
                Panel_HandleOptionsHeight += constants.panel_property_PopUpHandleOptionsheight;
            }
            else if (mode == "minusPopUpHandle")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_PopUpHandleOptionsheight;
            }
            else if (mode == "addRotoswingForSliding")
            {
                Panel_HandleOptionsHeight += constants.panel_property_RotoswingForSlidingOptionsheight;
            }
            else if (mode == "minusRotoswingForSliding")
            {
                Panel_HandleOptionsHeight -= constants.panel_property_RotoswingForSlidingOptionsheight;
            }

        }

        public void AdjustRotoswingPropertyHeight(string mode)
        {
            if (mode == "addExtension")
            {
                Panel_RotoswingOptionsHeight += constants.panel_property_extensionOptionsheight;
            }
            else if (mode == "minusExtension")
            {
                Panel_RotoswingOptionsHeight -= constants.panel_property_extensionOptionsheight;
            }
            else if (mode == "addExtensionField")
            {
                Panel_RotoswingOptionsHeight += constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "minusExtensionField")
            {
                Panel_RotoswingOptionsHeight -= constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "addCornerDrive")
            {
                Panel_RotoswingOptionsHeight += constants.panel_property_cornerDriveOptionsheight_default;
            }
            else if (mode == "minusCornerDrive")
            {
                Panel_RotoswingOptionsHeight -= constants.panel_property_cornerDriveOptionsheight_default;
            }
        }

        public void AdjustExtensionPropertyHeight(string mode)
        {
            if (mode == "addExtensionField")
            {
                Panel_ExtensionPropertyHeight += constants.panel_property_extensionFieldsheight;
            }
            else if (mode == "minusExtensionField")
            {
                Panel_ExtensionPropertyHeight -= constants.panel_property_extensionFieldsheight;
            }
        }

        public void Panel_PropertyChange(bool Checked)
        {

            if (_panelOrient != Checked)
            {
                _panelOrient = Checked;
                if (_panelOrient == true && Panel_Type == "Fixed Panel")
                {
                    _panelChkText = "dSash";
                    Panel_SashPropertyVisibility = true;
                }
                else if (_panelOrient == false && Panel_Type == "Fixed Panel")
                {
                    _panelChkText = "None";
                    Panel_SashPropertyVisibility = false;
                }
                if (Panel_ParentFrameModel != null)
                {
                    if (_panelChkText == "None")
                    {
                        Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSash");
                        AdjustPropertyPanelHeight("minusSash");

                        if (Panel_Type != "Fixed Panel")
                        {

                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                Panel_HingeOptionsVisibility = false;
                                AdjustPropertyPanelHeight("minusHinge");
                                Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Panel_CenterHingeOptionsVisibility = false;
                                AdjustPropertyPanelHeight("minusCenterHinge");
                                Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");

                                if (Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                {
                                    Panel_NTCenterHingeVisibility = false;
                                    AdjustPropertyPanelHeight("minusNTCenterHinge");
                                    Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                }
                            }
                        }
                    }
                    else if (_panelChkText == "dSash")
                    {
                        AdjustPropertyPanelHeight("addSash");
                        Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addSash");

                        if (Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
                        {
                            if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                            {
                                Panel_SashProfileArtNo = SashProfile_ArticleNo._7581;
                                Panel_SashReinfArtNo = SashReinf_ArticleNo._R675;
                            }
                            else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                            {
                                Panel_SashProfileArtNo = SashProfile_ArticleNo._374;
                                Panel_SashReinfArtNo = SashReinf_ArticleNo._655;
                            }
                        }
                        else if (Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                        {
                            if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                            {
                                Panel_SashProfileArtNo = SashProfile_ArticleNo._6040;
                                Panel_SashReinfArtNo = SashReinf_ArticleNo._TV104;
                            }
                            else if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                            {
                                Panel_SashProfileArtNo = SashProfile_ArticleNo._6041;
                                Panel_SashReinfArtNo = SashReinf_ArticleNo._TV106;
                            }
                            PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2436;
                        }
                    }
                }

                if (Panel_ParentMultiPanelModel != null)
                {
                    if (_panelChkText == "None")
                    {
                        Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSash");

                        if (Panel_Type != "Fixed Panel")
                        {
                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                Panel_HingeOptionsVisibility = false;
                                Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Panel_CenterHingeOptionsVisibility = false;
                                Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");

                                if (Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                {
                                    Panel_NTCenterHingeVisibility = true;
                                    Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                }
                            }
                        }
                    }
                    else if (_panelChkText == "dSash")
                    {
                        Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addSash");
                        if (Panel_Type != "Fixed Panel")
                        {
                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                Panel_HingeOptionsVisibility = true;
                                Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Panel_CenterHingeOptionsVisibility = true;
                                Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");

                                if (Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                {
                                    Panel_NTCenterHingeVisibility = true;
                                    Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                                }
                            }
                        }
                    }
                }

            }
        }

        public void SetPanelExplosionValues_Panel(bool parentIsFrame)
        {
            Panel_StrikerQty_A = 0;
            Panel_StrikerQty_C = 0;
            Panel_AdjStrikerQty = 0;


            Base_Color base_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor;
            Foil_Color inside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;
            Foil_Color outside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_OutsideColor;

            int botFrameDeduction = 0,
                totalBotFrameDeduction = 0;

            bool ChckBotFrame = false;
            if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166)
            {
                botFrameDeduction = 20;
                ChckBotFrame = true;
            }
            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789)
            {
                botFrameDeduction = 2;
                ChckBotFrame = true;
            }
            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502)
            {
                botFrameDeduction = 33 - 8;
                ChckBotFrame = true;

            }
            else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
            {
                botFrameDeduction = 33;
                ChckBotFrame = true;
            }

            if (Panel_SashPropertyVisibility == true)
            {
                if ((Panel_Type.Contains("Awning") || Panel_Type.Contains("Casement")) && Panel_GlassThickness == 6.0f)
                {
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._KBC70;
                }

                if (Panel_Type.Contains("Sliding") || Panel_ChkText == "dSash")
                {
                    Panel_SpacerArtNo = Spacer_ArticleNo._M063;
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._9C54;
                    Panel_GlazingRebateBlockArtNo = GlazingRebateBlock_ArticleNo._9C56;
                }

                if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                    (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373))
                {
                    if (Panel_ParentFrameModel.Frame_Height > 2499)
                    {
                        Panel_WeldableCArtNo = WeldableCornerJoint_ArticleNo._498N;
                    }
                }

                int inward_motorized_deduction = 0;

                if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 ||
                    Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                {
                    if (ChckBotFrame == true)
                    {
                        totalBotFrameDeduction = 26 - botFrameDeduction;
                    }

                    Panel_SashWidth = Panel_DisplayWidth - (26 * 2) + 5;
                    Panel_SashWidthDecimal = Panel_DisplayWidthDecimal;
                    Panel_SashHeight = Panel_DisplayHeight - (26 * 2) + totalBotFrameDeduction + 5;
                    Panel_SashHeightDecimal = Panel_DisplayHeightDecimal;

                    Panel_GlassWidth = Panel_SashWidth - 5 - (55 * 2) - 6;
                    Panel_GlassWidthDecimal = Panel_SashWidthDecimal;
                    Panel_GlassHeight = Panel_SashHeight - 5 - (55 * 2) - 6;
                    Panel_GlassHeightDecimal = Panel_SashHeightDecimal;
                }
                else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                {
                    int sash_deduct = 0, glass_deduct = 0;
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                    {
                        sash_deduct = 40;
                        glass_deduct = 55;
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        sash_deduct = 39;
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                            Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                        {
                            glass_deduct = 86;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            glass_deduct = 57;
                            if (Panel_MotorizedOptionVisibility == true)
                            {
                                inward_motorized_deduction = 35;
                            }
                        }
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                    {
                        glass_deduct = 48;
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                    {
                        glass_deduct = 64;
                    }

                    if (ChckBotFrame == true)
                    {
                        totalBotFrameDeduction = sash_deduct - botFrameDeduction;
                    }

                    Panel_SashWidth = Panel_DisplayWidth - inward_motorized_deduction - (sash_deduct * 2) + 5;
                    Panel_SashWidthDecimal = Panel_DisplayWidthDecimal;
                    Panel_SashHeight = Panel_DisplayHeight - (sash_deduct * 2) + totalBotFrameDeduction + 5;
                    Panel_SashHeightDecimal = Panel_DisplayHeightDecimal;

                    Panel_GlassWidth = Panel_SashWidth - 5 - (glass_deduct * 2) - 6;
                    Panel_GlassWidthDecimal = Panel_SashWidthDecimal;
                    Panel_GlassHeight = Panel_SashHeight - 5 - (glass_deduct * 2) - 6;
                    Panel_GlassHeightDecimal = Panel_SashHeightDecimal;
                }
                //else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                //{
                //    //int sash_deduct = 0, glass_deduct = 0;
                //    //if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                //    //{
                //    //    sash_deduct = 35;
                //    //    glass_deduct = 55;
                //    //}
                //    //else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                //    //{
                //    //    sash_deduct = 39;
                //    //}

                //    //Panel_SashWidth = (Panel_DisplayWidth/2) + 5;
                //    //Panel_SashWidthDecimal = Panel_DisplayWidthDecimal;
                //    //Panel_SashHeight = Panel_DisplayHeight - (sash_deduct * 2) + 5;
                //    //Panel_SashHeightDecimal = Panel_DisplayHeightDecimal;

                //    //Panel_GlassWidth = Panel_SashWidth - 5 - (glass_deduct * 2) - 6;
                //    //Panel_GlassWidthDecimal = Panel_SashWidthDecimal;
                //    //Panel_GlassHeight = Panel_SashHeight - 5 - (glass_deduct * 2) - 6;
                //    //Panel_GlassHeightDecimal = Panel_SashHeightDecimal;
                //}
                //else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                //{

                //}

                int handle_deduct = 0;

                if (Panel_SashReinfArtNo == SashReinf_ArticleNo._R675 || Panel_SashReinfArtNo == SashReinf_ArticleNo._207)
                {
                    handle_deduct = 55;
                }
                else if (Panel_SashReinfArtNo == SashReinf_ArticleNo._655)
                {
                    handle_deduct = 40;
                }
                else if (Panel_SashReinfArtNo == SashReinf_ArticleNo._TV104)
                {
                    handle_deduct = 50;
                }
                else if (Panel_SashReinfArtNo == SashReinf_ArticleNo._TV106)
                {
                    handle_deduct = 50;
                }

                Panel_SashReinfWidth = Panel_SashWidth - 5 - (handle_deduct * 2) - 10;
                Panel_SashReinfWidthDecimal = Panel_SashWidthDecimal;
                Panel_SashReinfHeight = Panel_SashHeight - 5 - (handle_deduct * 2) - 10;
                Panel_SashReinfHeightDecimal = Panel_SashHeightDecimal;

                Panel_GlazingBeadWidth = Panel_GlassWidth + 200; //new formula from Maam D 2/2/2023
                Panel_GlazingBeadWidthDecimal = Panel_GlassWidthDecimal;
                Panel_GlazingBeadHeight = Panel_GlassHeight + 200;
                Panel_GlazingBeadHeightDecimal = Panel_GlassHeightDecimal;

                //Panel_GlazingBeadWidth = Panel_SashWidth;
                //Panel_GlazingBeadWidthDecimal = Panel_SashWidthDecimal;
                //Panel_GlazingBeadHeight = Panel_SashHeight;
                //Panel_GlazingBeadHeightDecimal = Panel_SashHeightDecimal;

                Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;

                Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;

                if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                    {
                        Panel_AdjStrikerQty += 4;
                    }

                    if (Panel_ExtensionTopArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionTopArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionTopArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionTopArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtTopQty);
                    }

                    if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionTop2ArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionTop2ArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionTop2ArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtTop2Qty);
                    }

                    if (Panel_ExtensionBotArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionBotArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionBotArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionBotArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtBotQty);
                    }

                    if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionBot2ArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionBot2ArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionBot2ArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtBot2Qty);
                    }


                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_AdjStrikerQty += 1;
                    }

                    Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
                    Panel_RestrictorStayQty = 2;

                    if (outside_color == Foil_Color._None)
                    {
                        if (base_color == Base_Color._White)
                        {
                            Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_WHT;
                        }
                        else if (base_color == Base_Color._Ivory)
                        {
                            Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_IVORY;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_DB;
                        }
                    }
                    else if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                             outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                             outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                             outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                             outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
                    {
                        Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_BL;
                    }
                    else if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._GoldenOak ||
                             outside_color == Foil_Color._Mahogany || outside_color == Foil_Color._Havana)
                    {
                        Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_DB;
                    }

                    //if (Panel_SashHeight < 2400)
                    //{
                    //    Panel_3dHingeQty = 3;
                    //}
                    //else if (Panel_SashHeight > 2399 && Panel_SashHeight < 2700)
                    //{
                    //    Panel_3dHingeQty = 4;
                    //}
                    //else if (Panel_SashHeight > 2699 && Panel_SashHeight < 3200)
                    //{
                    //    Panel_3dHingeQty = 5;
                    //}
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                    {
                        Panel_AdjStrikerQty += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                    {
                        Panel_AdjStrikerQty += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                    {
                        Panel_AdjStrikerQty += 4;
                    }

                    Panel_StayBearingKArtNo = StayBearingK_ArticleNo._N390A00106_230177;
                    Panel_StayBearingPinArtNo = StayBearingPin_ArticleNo._F710D52008_227354;
                    Panel_TopCornerHingeSpacerArtNo = TopCornerHingeSpacer_ArticleNo._331488;
                    Panel_CornerHingeKArtNo = CornerHingeK_ArticleNo._N510A0011;
                    Panel_CornerPivotRestKArtNo = CornerPivotRestK_ArticleNo._N510A0001_258590;

                    if (base_color == Base_Color._Ivory || base_color == Base_Color._White)
                    {
                        Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._WhiteIvory;
                        Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._WhiteIvory;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
                        Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._WhiteIvory;
                        Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._WhiteIvory;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._DB;
                        Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._DB;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._DB;
                        Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._DB;
                        Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._DB;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._DB;
                    }

                    if (Panel_ChkText == "L")
                    {
                        Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Left;
                    }
                    else if (Panel_ChkText == "R")
                    {
                        Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Right;
                    }
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                {
                    Panel_GuideTrackProfileArtNo = GuideTrackProfile_ArticleNo._6059;
                    Panel_AluminumTrackArtNo = AluminumTrack_ArticleNo._9C51;
                    Panel_WeatherBarArtNo = WeatherBar_ArticleNo._1244;
                    Panel_WaterSeepageArtNo = WaterSeepage_ArticleNo._1646;
                    if (Panel_Overlap_Sash == OverlapSash._Left || Panel_Overlap_Sash == OverlapSash._Right)
                    {
                        Panel_InterlockArtNo = Interlock_ArticleNo._6061_Milled;
                        Panel_ExtensionForInterlockArtNo = ExtensionForInterlock_ArticleNo._9C61_Milled;
                    }
                    Panel_WeatherBarFastenerArtNo = WeatherBarFastener_ArticleNo._9447;
                    Panel_BrushSealArtNo = BrushSeal_ArticleNo._9091;
                    Panel_GlazingRebateBlockArtNo = GlazingRebateBlock_ArticleNo._9C56;
                    Panel_SealingBlockArtNo = SealingBlock_ArticleNo._9C63;
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._9C54;

                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    Panel_GuideTrackProfileArtNo = GuideTrackProfile_ArticleNo._6059;
                    Panel_AluminumTrackArtNo = AluminumTrack_ArticleNo._9C51;
                    Panel_WeatherBarArtNo = WeatherBar_ArticleNo._1244;
                    Panel_WaterSeepageArtNo = WaterSeepage_ArticleNo._1646;
                    if (Panel_Overlap_Sash == OverlapSash._Left || Panel_Overlap_Sash == OverlapSash._Right)
                    {
                        Panel_InterlockArtNo = Interlock_ArticleNo._6061_Milled;
                        Panel_ExtensionForInterlockArtNo = ExtensionForInterlock_ArticleNo._9C61_Milled;
                    }
                    Panel_WeatherBarFastenerArtNo = WeatherBarFastener_ArticleNo._9447;
                    Panel_BrushSealArtNo = BrushSeal_ArticleNo._9091;
                    Panel_GlazingRebateBlockArtNo = GlazingRebateBlock_ArticleNo._9C56;
                    Panel_SealingBlockArtNo = SealingBlock_ArticleNo._9C63;
                }

                if (Panel_MotorizedOptionVisibility == true)
                {
                    Panel_30x25CoverArtNo = _30x25Cover_ArticleNo._1067_Milled;
                    Panel_MotorizedDividerArtNo = MotorizedDivider_ArticleNo._0505;
                    Panel_CoverForMotorArtNo = CoverForMotor_ArticleNo._1182;
                    Panel_2dHingeArtNo = _2DHinge_ArticleNo._614293;
                    Panel_PushButtonSwitchArtNo = PushButtonSwitch_ArticleNo._N4037;
                    Panel_FalsePoleArtNo = FalsePole_ArticleNo._N4950;
                    Panel_SupportingFrameArtNo = SupportingFrame_ArticleNo._N4703;
                    Panel_PlateArtNo = Plate_ArticleNo._N4803LB;

                    if (outside_color != Foil_Color._None)
                    {
                        if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                            outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                            outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                            outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                            outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_ButtHingeArtNo = ButtHinge_ArticleNo._BL;
                        }
                        else if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._GoldenOak ||
                                 outside_color == Foil_Color._Mahogany || outside_color == Foil_Color._Havana)
                        {
                            Panel_ButtHingeArtNo = ButtHinge_ArticleNo._DB;
                        }
                    }
                    else if (outside_color == Foil_Color._None)
                    {
                        if (base_color == Base_Color._White)
                        {
                            Panel_ButtHingeArtNo = ButtHinge_ArticleNo._WHT;
                        }
                        else if (base_color == Base_Color._Ivory)
                        {
                            Panel_ButtHingeArtNo = ButtHinge_ArticleNo._PC;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_ButtHingeArtNo = ButtHinge_ArticleNo._DB;
                        }
                    }

                }

                if (Panel_HingeOptions == HingeOption._2DHinge)
                {
                    Panel_2dHingeArtNo_nonMotorized = _2DHinge_ArticleNo._614293;

                    //if (Panel_SashHeight <= 1499)
                    //{
                    //    Panel_2DHingeQty_nonMotorized = 3;
                    //}
                    //else if (Panel_SashHeight >= 1500)
                    //{
                    //    Panel_2DHingeQty_nonMotorized = 4;
                    //}
                }

                #region MiddleCloser


                //if (base_color == Base_Color._DarkBrown)
                //{
                //    if (Panel_Type.Contains("Awning"))
                //    {
                //        if (Panel_DisplayHeight < 1551)
                //        {
                //            Panel_MiddleCloserPairQty = 1;
                //        }
                //        else if (Panel_DisplayHeight > 1551 && Panel_DisplayHeight < 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 2;
                //        }
                //        else if (Panel_DisplayHeight > 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 3;
                //        }
                //    }
                //    else if (Panel_Type.Contains("Casement"))
                //    {
                //        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                //                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                //            {
                //                Panel_MiddleCloserPairQty = 0;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                //            {
                //                if (Panel_SashHeight < 1201)
                //                {
                //                    Panel_MiddleCloserPairQty = 1;
                //                }
                //                else if (Panel_SashHeight > 1200)
                //                {
                //                    Panel_MiddleCloserPairQty = 0;
                //                }
                //            }
                //        }
                //        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //        }
                //    }
                //}
                //else if (base_color == Base_Color._White ||
                //         base_color == Base_Color._Ivory)
                //{
                //    if (Panel_Type.Contains("Awning"))
                //    {
                //        if (Panel_SashHeight < 1551)
                //        {
                //            Panel_MiddleCloserPairQty = 1;
                //        }
                //        else if (Panel_SashHeight > 1551 && Panel_SashHeight < 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 2;
                //        }
                //        else if (Panel_SashHeight > 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 3;
                //        }
                //    }
                //    else if (Panel_Type.Contains("Casement"))
                //    {
                //        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                //                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                //            {
                //                Panel_MiddleCloserPairQty = 0;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                //            {
                //                if (Panel_SashHeight < 1201)
                //                {
                //                    Panel_MiddleCloserPairQty = 1;
                //                }
                //                else if (Panel_SashHeight > 1200)
                //                {
                //                    Panel_MiddleCloserPairQty = 0;
                //                }
                //            }
                //        }
                //        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //        }
                //    }
                //}

                #endregion

                Panel_StrikerArtno_A = Striker_ArticleNo._M89ANTA;
                Panel_StrikerArtno_C = Striker_ArticleNo._M89ANTC;
                if (Panel_MotorizedOptionVisibility == true)
                {
                    Panel_MotorizedMechQty = 0;
                    if (Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                    {
                        Panel_MotorizedMechQty += 1;
                    }
                    else if (Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                             Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                    {
                        if (Panel_DisplayWidth > 0 && Panel_DisplayWidth <= 1099)
                        {
                            Panel_MotorizedMechQty += 1;
                        }
                        else if (Panel_DisplayWidth >= 1100)
                        {
                            Panel_MotorizedMechQty += 2;
                        }
                    }
                }

                if (Panel_Type.Contains("Awning"))
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                    {
                        Panel_StrikerQty_A += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                    {
                        Panel_StrikerQty_A += 3;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                    {
                        Panel_StrikerQty_A += 4;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                    {
                        Panel_StrikerQty_A += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                    {
                        Panel_StrikerQty_A += 2;
                    }

                    if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtLeftQty);
                    }

                    if (Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtLeft2Qty);
                    }

                    if (Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtRightQty);
                    }

                    if (Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtRight2Qty);
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_StrikerQty_A += 2;
                    }
                }
                else if (Panel_Type.Contains("Casement"))
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                    {
                        Panel_StrikerQty_C += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                    {
                        Panel_StrikerQty_C += 3;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                    {
                        Panel_StrikerQty_C += 4;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                    {
                        Panel_StrikerQty_C += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                    {
                        Panel_StrikerQty_C += 2;
                    }

                    if (Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtTopQty);
                    }

                    if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtTop2Qty);
                    }

                    if (Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtBotQty);
                    }

                    if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtBot2Qty);
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_StrikerQty_A += 1;
                    }
                }


                int sashWD_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashWidth / 100)) * 100;
                int sashHt_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashHeight / 100)) * 100;

                if (Panel_Type.Contains("Awning"))
                {
                    FrictionStay_ArticleNo fs_dimension_based = FrictionStay_ArticleNo._None;
                    FrictionStay_ArticleNo fs_weight_based = FrictionStay_ArticleNo._None;

                    if ((sashWD_floor >= 400 && sashWD_floor <= 1200) &&
                        (Panel_SashHeight >= 350 && Panel_SashHeight <= 399))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm8;
                    }
                    else if (sashHt_floor >= 400 && sashHt_floor <= 500)
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._10HD;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 1000) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._12HD;
                    }
                    else if (((sashWD_floor >= 1100 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._16HD;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1100) &&
                             (sashHt_floor >= 800 && sashHt_floor <= 900)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._16HD;
                    }
                    else if (((sashWD_floor >= 1200 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 800 && sashHt_floor <= 900)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm22;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 1000 && sashHt_floor <= 1200)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm22;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 1300 && sashHt_floor <= 2300)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm26;
                    }
                    else
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._None;
                    }

                    if (Panel_GlassThickness >= 12.0f)
                    {
                        float sash_weight = ((((Panel_SashWidth / 1000) + (Panel_SashHeight / 1000)) * 2) * 1) * 3,
                              glass_weight = (Panel_GlassThickness / 1000) * (Panel_GlassWidth / 1000) * (Panel_GlassHeight / 1000) * 1 * 2500;
                        int total_weight = Convert.ToInt32(Math.Ceiling((decimal)(sash_weight + glass_weight)));

                        if (total_weight >= 1 && total_weight <= 44)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm8;
                        }
                        else if (total_weight >= 45 && total_weight <= 49)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._10HD;
                        }
                        else if (total_weight >= 50 && total_weight <= 54)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._12HD;
                        }
                        else if (total_weight >= 55 && total_weight <= 74)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._16HD;
                        }
                        else if (total_weight >= 75 && total_weight <= 119)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm22;
                        }
                        else if (total_weight >= 120)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm26;
                        }
                    }

                    if (fs_weight_based != FrictionStay_ArticleNo._None)
                    {
                        if (fs_weight_based.Value > fs_dimension_based.Value)
                        {
                            Panel_FrictionStayArtNo = fs_weight_based;
                        }
                        else if (fs_weight_based.Value < fs_dimension_based.Value)
                        {
                            Panel_FrictionStayArtNo = fs_dimension_based;
                        }
                        else if (fs_weight_based.Value == fs_dimension_based.Value)
                        {
                            Panel_FrictionStayArtNo = fs_weight_based;
                        }
                    }
                    else if (fs_weight_based == FrictionStay_ArticleNo._None)
                    {
                        Panel_FrictionStayArtNo = fs_dimension_based;
                    }

                    if (Panel_Type == "Awning Panel")
                    {
                        if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                        {
                            if (base_color == Base_Color._Ivory || base_color == Base_Color._White)
                            {
                                Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
                            }
                            else if (base_color == Base_Color._DarkBrown)
                            {
                                Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400215;
                            }
                        }
                        Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;
                    }
                }
                else if (Panel_Type.Contains("Casement"))
                {
                    FrictionStayCasement_ArticleNo fs_dimension_based = FrictionStayCasement_ArticleNo._None;
                    FrictionStayCasement_ArticleNo fs_weight_based = FrictionStayCasement_ArticleNo._None;

                    if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                        (Panel_SashWidth >= 350 && Panel_SashWidth <= 399))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._10HD;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 400 && sashHt_floor <= 1200))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._12FS;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 1300 && sashHt_floor <= 1500))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._12HD;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 500) &&
                             (sashHt_floor >= 1600 && sashHt_floor <= 2100))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._12HD;
                    }
                    else if ((sashHt_floor >= 1600 && sashHt_floor <= 2200) &&
                             (Panel_SashWidth >= 600 && Panel_SashWidth <= 699))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._16HD;
                    }
                    else if (Panel_SashWidth >= 700 && Panel_SashWidth <= 799)
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._16HD;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 800 && Panel_SashWidth <= 899))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._16HD;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 900 && Panel_SashWidth <= 999))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._20HD;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 1500) &&
                             (Panel_SashWidth >= 1000 && Panel_SashWidth <= 1199))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._20HD;
                    }
                    else
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._None;
                    }

                    if (Panel_GlassThickness >= 12.0f)
                    {
                        float sash_weight = ((((Panel_SashWidth / 1000) + (Panel_SashHeight / 1000)) * 2) * 1) * 3,
                              glass_weight = (Panel_GlassThickness / 1000) * (Panel_GlassWidth / 1000) * (Panel_GlassHeight / 1000) * 1 * 2500;
                        int total_weight = Convert.ToInt32(Math.Ceiling((decimal)(sash_weight + glass_weight)));

                        if (total_weight >= 1 && total_weight <= 18)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._12FS;
                        }
                        else if (total_weight >= 19 && total_weight <= 35)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._10HD;
                        }
                        else if (total_weight >= 36 && total_weight <= 40)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._12HD;
                        }
                        else if (total_weight >= 41 && total_weight <= 45)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._16HD;
                        }
                        else if (total_weight >= 46)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._20HD;
                        }
                    }

                    if (fs_weight_based != FrictionStayCasement_ArticleNo._None)
                    {
                        if (fs_weight_based.Value > fs_dimension_based.Value)
                        {
                            Panel_FSCasementArtNo = fs_weight_based;
                        }
                        else if (fs_weight_based.Value < fs_dimension_based.Value)
                        {
                            Panel_FSCasementArtNo = fs_dimension_based;
                        }
                        else if (fs_weight_based.Value == fs_dimension_based.Value)
                        {
                            Panel_FSCasementArtNo = fs_weight_based;
                        }
                    }
                    else if (fs_weight_based == FrictionStayCasement_ArticleNo._None)
                    {
                        Panel_FSCasementArtNo = fs_dimension_based;
                    }

                    Panel_PlasticWedgeQty = 1;

                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (base_color == Base_Color._Ivory || base_color == Base_Color._White)
                        {
                            Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400215;
                        }

                        Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;
                    }
                }

                if (base_color == Base_Color._Ivory ||
                    base_color == Base_Color._White)
                {
                    Panel_PlasticWedge = PlasticWedge_ArticleNo._7199WHT;
                }
                else if (base_color == Base_Color._DarkBrown)
                {
                    Panel_PlasticWedge = PlasticWedge_ArticleNo._7199DB;
                }

                if (Panel_HandleType == Handle_Type._Rio)
                {
                    Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;

                    if (inside_color != null ||
                        outside_color != null ||
                        inside_color != outside_color)
                    {
                        if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                                 inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                                 inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                                 inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                                 inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                                 inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_9005_614441;
                        }

                        if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._Mahogany ||
                                outside_color == Foil_Color._GoldenOak || outside_color == Foil_Color._Havana)
                        {
                            Panel_CylinderCoverArtNo2 = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                                 outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                                 outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                                 outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                                 outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_CylinderCoverArtNo2 = Cylinder_CoverArtNo._EPSW_9005_614441;
                        }
                    }
                    else
                    {
                        if (inside_color == Foil_Color._None)
                        {
                            if (base_color == Base_Color._White)
                            {
                                Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_7025_50992;
                            }
                            else if (base_color == Base_Color._DarkBrown)
                            {
                                Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                            }
                            else if (base_color == Base_Color._Ivory)
                            {
                                Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_IVORY;
                            }
                        }
                        else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                                 inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                                 inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                                 inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                                 inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                                 inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_9005_614441;
                        }
                    }

                }
                else if (Panel_HandleType == Handle_Type._MVD)
                {
                    Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;

                    if (inside_color == Foil_Color._None)
                    {
                        if (base_color == Base_Color._White)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_7025_50992;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (base_color == Base_Color._Ivory)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_IVORY;
                        }
                    }
                    else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                             inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                    {
                        Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                    }
                    else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                             inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                             inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                             inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                             inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                    {
                        Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_9005_614441;
                    }

                    if (Panel_ParentFrameModel.Frame_Height > 2499)
                    {
                        if (Panel_ChkText == "L")
                        {
                            Panel_LatchDeadboltStrikerArtNo = LatchDeadboltStriker_ArticleNo._Left;
                        }
                        else if (Panel_ChkText == "R")
                        {
                            Panel_LatchDeadboltStrikerArtNo = LatchDeadboltStriker_ArticleNo._Right;
                        }
                    }
                }
                else if (Panel_HandleType == Handle_Type._D)
                {
                    Panel_ScrewSetsArtNo = ScrewSets._DH613172;
                }
                else if (Panel_HandleType == Handle_Type._D_IO_Locking)
                {
                    Panel_ScrewSetsArtNo = ScrewSets._DH613180;
                }
                else if (Panel_HandleType == Handle_Type._DummyD)
                {
                    Panel_ScrewSetsArtNo = ScrewSets._DH613176;
                }
            }
            else if (Panel_SashPropertyVisibility == false)
            {
                int frameDeduction = 0;
                if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 ||
                    Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                {
                    frameDeduction = 33;
                }
                else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                {
                    frameDeduction = 47;
                }
                else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                {
                    frameDeduction = 43;
                }
                else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                {
                    frameDeduction = 61;
                }

                if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                    Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166)
                {
                    botFrameDeduction = frameDeduction - 20;
                }
                else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789)
                {
                    botFrameDeduction = frameDeduction - 2;
                }
                else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502)
                {
                    botFrameDeduction = frameDeduction - 14;
                }
                else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                {
                    botFrameDeduction = frameDeduction - 20;
                }

                Panel_SashWidth = 0;
                Panel_SashHeight = 0;

                Panel_SashReinfWidth = 0;
                Panel_SashReinfHeight = 0;

                Panel_GlassWidth = Panel_DisplayWidth - (frameDeduction * 2) - 6;
                Panel_GlassWidthDecimal = Panel_DisplayWidthDecimal;
                Panel_GlassHeight = Panel_DisplayHeight - (frameDeduction * 2) - botFrameDeduction - 6;
                Panel_GlassHeightDecimal = Panel_DisplayHeightDecimal;

                Panel_GlazingBeadWidth = Panel_GlassWidth + 200;
                Panel_GlazingBeadWidthDecimal = Panel_GlassWidthDecimal;
                Panel_GlazingBeadHeight = Panel_GlassHeight;
                Panel_GlazingBeadHeightDecimal = Panel_GlassHeightDecimal;

                //Panel_GlazingBeadWidth = Panel_DisplayWidth; //- (33 * 2);
                //Panel_GlazingBeadWidthDecimal = Panel_DisplayWidthDecimal; //- (33 * 2);
                //Panel_GlazingBeadHeight = Panel_DisplayHeight; //- (33 * 2);
                //Panel_GlazingBeadHeightDecimal = Panel_DisplayHeightDecimal; //- (33 * 2);

                if (Panel_Type.Contains("Louver"))
                {
                    Set_LouverBladesCount();

                    Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                    Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;
                    Panel_PlantOnWeatherStripHeadArtNo = PlantOnWeatherStripHead_ArticleNo._AL1313;
                    Panel_PlantOnWeatherStripSealArtNo = PlantOnWeatherStripSeal_ArticleNo._AL1314;
                    Panel_LouverFrameWeatherStripHeadArtNo = LouverFrameWeatherStripHead_ArticleNo._AL1307;
                    Panel_LouverFrameBottomWeatherStripArtNo = LouverFrameBottomWeatherStrip_ArticleNo._AL1309;
                    Panel_RubberSealArtNo = RubberSeal_ArticleNo._SL31;
                    Panel_CasementSealArtNo = CasementSeal_ArticleNo._9040;
                    Panel_SealForHandleArtNo = SealForHandle_ArticleNo._WDL2;

                    if (Panel_LouverBladeTypeOption == BladeType_Option._Aluminum)
                    {

                    }

                    int lvrgDeduction = 0;
                    if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                    {
                        lvrgDeduction = 33;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        lvrgDeduction = 47;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._6050)
                    {
                        lvrgDeduction = 43;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                    {
                        lvrgDeduction = 61;
                    }
                    Panel_PlantOnWeatherStripHeadWidth = Panel_DisplayWidth - (lvrgDeduction * 2) - 2;
                    Panel_PlantOnWeatherStripSealWidth = Panel_DisplayWidth - (lvrgDeduction * 2) - 2;
                    Panel_LouverFrameWeatherStripHeadWidth = Panel_PlantOnWeatherStripHeadWidth - 44;
                    Panel_LouverFrameBottomWeatherStripWidth = Panel_PlantOnWeatherStripHeadWidth - 44;
                    Panel_RubberSealWidth = Panel_DisplayWidth;
                    Panel_CasementSealWidth = Panel_DisplayWidth;
                    Panel_GlassWidth = Panel_DisplayWidth - (lvrgDeduction * 2) - (32 * 2);

                    if (Panel_LstSealForHandleMultiplier != null)
                    {
                        Panel_SealForHandleQty = 0;
                        foreach (int multiplier in Panel_LstSealForHandleMultiplier)
                        {
                            Panel_SealForHandleQty += 400 * multiplier;
                        }
                    }
                }
            }

            Panel_GlazingSpacerQty = 1;
        }

        public void SetPanelExplosionValues_Panel(Divider_ArticleNo divNxt_artNo,
                                                  Divider_ArticleNo divPrev_artNo,
                                                  DividerType div_type,
                                                  bool mpnlDivEneable,
                                                  int OverLappingPanel_Qty,
                                                  bool ChckBoundedByBotframe,
                                                  bool if_divNxt_is_dummy_mullion,
                                                  bool if_divPrev_is_dummy_mullion,
                                                  IDividerModel divNxt,
                                                  IDividerModel divPrev,
                                                  Divider_ArticleNo divArtNo_LeftorTop = null,
                                                  Divider_ArticleNo divArtNo_RightorBot = null,
                                                  string div_type_lvl3 = "",
                                                  Divider_ArticleNo divArtNo_LeftorTop_lvl3 = null,
                                                  Divider_ArticleNo divArtNo_RightorBot_lvl3 = null,
                                                  string panel_placement = "",
                                                  string mpanel_placement = "", //1st level
                                                  string mpanelparent_placement = "" //2nd level
                                                  )
        {
            int GB_deduction_forLeftorTopRightorBot = 0,
                GB_deduction_forNxtPrev = 0,
                GB_deduction_lvl3 = 0,
                deduction_for_wd = 0,
                deduction_for_ht = 0,
                Sash_deduction_forNxtPrev = 0,
                Sash_deduction_forLeftorTopRightorBot = 0,
                deduction_for_sashWD = 0,
                deduction_for_sashHT = 0;

            if (divNxt_artNo == Divider_ArticleNo._7536 || divNxt_artNo == Divider_ArticleNo._2069) //base level
            {
                GB_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev += (42 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                    {
                        Sash_deduction_forNxtPrev -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forNxtPrev -= 8; //sash bite allowance
                    }
                }
            }
            else if (divNxt_artNo == Divider_ArticleNo._7538)
            {
                GB_deduction_forNxtPrev += (72 / 2);
                Sash_deduction_forNxtPrev += (72 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                    {
                        Sash_deduction_forNxtPrev -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forNxtPrev -= 8; //sash bite allowance
                    }
                }
            }
            else if (divNxt_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "Last" && mpanelparent_placement == "")
                {
                    if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                    {
                        GB_deduction_forNxtPrev += 33;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        GB_deduction_forNxtPrev += 47;
                    }

                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                    {
                        Sash_deduction_forNxtPrev += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            Sash_deduction_forNxtPrev += 39;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                    {
                        Sash_deduction_forNxtPrev += 35;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                    {
                        Sash_deduction_forNxtPrev += 53;
                    }
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                        {
                            GB_deduction_forNxtPrev += 33;
                        }
                        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            GB_deduction_forNxtPrev += 47;
                        }

                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                            {
                                Sash_deduction_forNxtPrev += 40;
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Sash_deduction_forNxtPrev += 39;
                            }
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                        {
                            Sash_deduction_forNxtPrev += 35;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                        {
                            Sash_deduction_forNxtPrev += 53;
                        }
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                        {
                            GB_deduction_forNxtPrev += 33;
                        }
                        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            GB_deduction_forNxtPrev += 47;
                        }

                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                Sash_deduction_forNxtPrev += 40;
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Sash_deduction_forNxtPrev += 39;
                            }
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                        {
                            Sash_deduction_forNxtPrev += 35;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                        {
                            Sash_deduction_forNxtPrev += 53;
                        }
                    }
                }
                else if (mpnlDivEneable == false)
                {
                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                    {
                        Sash_deduction_forNxtPrev += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            Sash_deduction_forNxtPrev += 39;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                    {
                        Sash_deduction_forNxtPrev += 35;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                    {
                        Sash_deduction_forNxtPrev += 53;
                    }
                }

            }

            if (divPrev_artNo == Divider_ArticleNo._7536 || divPrev_artNo == Divider_ArticleNo._2069) //base level
            {
                GB_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev += (42 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                    {
                        Sash_deduction_forNxtPrev -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forNxtPrev -= 8; //sash bite allowance
                    }
                }
            }
            else if (divPrev_artNo == Divider_ArticleNo._7538)
            {
                GB_deduction_forNxtPrev += (72 / 2);
                Sash_deduction_forNxtPrev += (72 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                    {
                        Sash_deduction_forNxtPrev -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forNxtPrev -= 8; //sash bite allowance
                    }
                }
            }
            else if (divPrev_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "First" && mpanelparent_placement == "")
                {
                    if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                    {
                        GB_deduction_forNxtPrev += 33;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        GB_deduction_forNxtPrev += 47;
                    }

                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                    {
                        Sash_deduction_forNxtPrev += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            Sash_deduction_forNxtPrev += 39;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                    {
                        Sash_deduction_forNxtPrev += 35;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                    {
                        Sash_deduction_forNxtPrev += 53;
                    }
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                        {
                            GB_deduction_forNxtPrev += 33;
                        }
                        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            GB_deduction_forNxtPrev += 47;
                        }

                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                Sash_deduction_forNxtPrev += 40;
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Sash_deduction_forNxtPrev += 39;
                            }
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                        {
                            Sash_deduction_forNxtPrev += 35;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                        {
                            Sash_deduction_forNxtPrev += 53;
                        }
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                        {
                            GB_deduction_forNxtPrev += 33;
                        }
                        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            GB_deduction_forNxtPrev += 47;
                        }

                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                Sash_deduction_forNxtPrev += 40;
                            }
                            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                     Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                Sash_deduction_forNxtPrev += 39;
                            }
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                        {
                            Sash_deduction_forNxtPrev += 35;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                        {
                            Sash_deduction_forNxtPrev += 53;
                        }
                    }
                }
                else if (mpnlDivEneable == false && panel_placement == "Somewhere in Between")
                {
                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                    {
                        Sash_deduction_forNxtPrev += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            Sash_deduction_forNxtPrev += 39;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                    {
                        Sash_deduction_forNxtPrev += 35;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                    {
                        Sash_deduction_forNxtPrev += 53;
                    }
                }
            }

            if (divArtNo_LeftorTop == Divider_ArticleNo._7536 || divArtNo_LeftorTop == Divider_ArticleNo._2069) //level 2
            {
                GB_deduction_forLeftorTopRightorBot += (42 / 2);
                Sash_deduction_forLeftorTopRightorBot += (42 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 8; //sash bite allowance
                    }
                }

            }
            else if (divArtNo_LeftorTop == Divider_ArticleNo._7538 || divArtNo_LeftorTop == Divider_ArticleNo._2069)
            {
                GB_deduction_forLeftorTopRightorBot += (72 / 2);
                Sash_deduction_forLeftorTopRightorBot += (72 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._2067 ||
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 8; //sash bite allowance
                    }
                }
            }
            else if (divArtNo_LeftorTop == Divider_ArticleNo._None)
            {
                if (mpanel_placement == "First" ||
                    mpanel_placement == "Last" ||
                    mpanel_placement == "")
                {
                    if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                    {
                        GB_deduction_forLeftorTopRightorBot += 33;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        GB_deduction_forLeftorTopRightorBot += 47;
                    }

                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                        {
                            Sash_deduction_forLeftorTopRightorBot += 40;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            Sash_deduction_forLeftorTopRightorBot += 39;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 35;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 53;
                    }
                }
            }

            if (divArtNo_RightorBot == Divider_ArticleNo._7536 || divArtNo_RightorBot == Divider_ArticleNo._2069)
            {
                GB_deduction_forLeftorTopRightorBot += (42 / 2);
                Sash_deduction_forLeftorTopRightorBot += (42 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 8; //sash bite allowance
                    }
                }
            }
            else if (divArtNo_RightorBot == Divider_ArticleNo._7538 || divArtNo_RightorBot == Divider_ArticleNo._2069)
            {
                GB_deduction_forLeftorTopRightorBot += (72 / 2);
                Sash_deduction_forLeftorTopRightorBot += (72 / 2);
                if (Panel_Type.Contains("Louver") == false)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        Sash_deduction_forLeftorTopRightorBot -= 8; //sash bite allowance
                    }
                }
            }
            else if (divArtNo_RightorBot == Divider_ArticleNo._None)
            {
                if (mpanel_placement == "First" ||
                    mpanel_placement == "Last" ||
                    mpanel_placement == "")
                {
                    if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                    {
                        GB_deduction_forLeftorTopRightorBot += 33;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        GB_deduction_forLeftorTopRightorBot += 47;
                    }

                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._V226)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                        {
                            Sash_deduction_forLeftorTopRightorBot += 40;
                        }
                        else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                                 Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                        {
                            Sash_deduction_forLeftorTopRightorBot += 39;
                        }
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 35;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 53;
                    }
                }
            }

            if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._7536 || divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._2069)
            {
                GB_deduction_lvl3 += (42 / 2);
            }
            else if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._7538)
            {
                GB_deduction_lvl3 += (72 / 2);
            }

            if (divArtNo_RightorBot_lvl3 == Divider_ArticleNo._7536 || divArtNo_RightorBot_lvl3 == Divider_ArticleNo._2069)
            {
                GB_deduction_lvl3 += (42 / 2);
            }
            else if (divArtNo_RightorBot_lvl3 == Divider_ArticleNo._7538)
            {
                GB_deduction_lvl3 += (72 / 2);
            }

            if (div_type == DividerType.Mullion)
            {
                deduction_for_wd = GB_deduction_forNxtPrev;
                deduction_for_ht = GB_deduction_forLeftorTopRightorBot;

                deduction_for_sashWD = Sash_deduction_forNxtPrev;
                deduction_for_sashHT = Sash_deduction_forLeftorTopRightorBot;
            }
            else if (div_type == DividerType.Transom)
            {
                deduction_for_wd = GB_deduction_forLeftorTopRightorBot;
                deduction_for_ht = GB_deduction_forNxtPrev;

                deduction_for_sashWD = Sash_deduction_forLeftorTopRightorBot;
                deduction_for_sashHT = Sash_deduction_forNxtPrev;
            }
            else if (div_type == DividerType.None)
            {
                deduction_for_wd = GB_deduction_forNxtPrev;
                deduction_for_ht = GB_deduction_forLeftorTopRightorBot;

                deduction_for_sashWD = Sash_deduction_forNxtPrev;
                deduction_for_sashHT = Sash_deduction_forLeftorTopRightorBot;
            }

            if (div_type_lvl3 == DividerType.Mullion.ToString())
            {
                deduction_for_wd += GB_deduction_lvl3;
            }
            else if (div_type_lvl3 == DividerType.Transom.ToString())
            {
                deduction_for_ht += GB_deduction_lvl3;
            }

            Panel_StrikerQty_A = 0;
            Panel_StrikerQty_C = 0;
            Panel_StrikerArtno_SlidingQty = 0;

            Base_Color base_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor;
            Foil_Color inside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;
            Foil_Color outside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_OutsideColor;

            if (Panel_MotorizedOptionVisibility == true)
            {
                Panel_30x25CoverArtNo = _30x25Cover_ArticleNo._1067_Milled;
                Panel_MotorizedDividerArtNo = MotorizedDivider_ArticleNo._0505;
                Panel_CoverForMotorArtNo = CoverForMotor_ArticleNo._1182;
                Panel_2dHingeArtNo = _2DHinge_ArticleNo._614293;
                Panel_PushButtonSwitchArtNo = PushButtonSwitch_ArticleNo._N4037;
                Panel_FalsePoleArtNo = FalsePole_ArticleNo._N4950;
                Panel_SupportingFrameArtNo = SupportingFrame_ArticleNo._N4703;
                Panel_PlateArtNo = Plate_ArticleNo._N4803LB;

                if (outside_color != Foil_Color._None)
                {
                    if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                        outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                        outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                        outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                        outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
                    {
                        Panel_ButtHingeArtNo = ButtHinge_ArticleNo._BL;
                    }
                    else if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._GoldenOak ||
                             outside_color == Foil_Color._Mahogany || outside_color == Foil_Color._Havana)
                    {
                        Panel_ButtHingeArtNo = ButtHinge_ArticleNo._DB;
                    }
                }
                else if (outside_color == Foil_Color._None)
                {
                    if (base_color == Base_Color._White)
                    {
                        Panel_ButtHingeArtNo = ButtHinge_ArticleNo._WHT;
                    }
                    else if (base_color == Base_Color._Ivory)
                    {
                        Panel_ButtHingeArtNo = ButtHinge_ArticleNo._PC;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        Panel_ButtHingeArtNo = ButtHinge_ArticleNo._DB;
                    }
                }
            }

            if (Panel_SashPropertyVisibility == true)
            {
                if ((Panel_Type.Contains("Awning") || Panel_Type.Contains("Casement")) && Panel_GlassThickness == 6.0f)
                {
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._KBC70;
                }

                if (Panel_Type.Contains("Sliding") || Panel_ChkText == "dSash")
                {
                    Panel_SpacerArtNo = Spacer_ArticleNo._M063;
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._9C54;
                    Panel_AluminumPullHandleArtNo = AluminumPullHandle_ArticleNo._9C58;
                    Panel_GlazingRebateBlockArtNo = GlazingRebateBlock_ArticleNo._9C56;
                }

                if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                    (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373))
                {
                    if (Panel_ParentFrameModel.Frame_Height > 2499)
                    {
                        Panel_WeldableCArtNo = WeldableCornerJoint_ArticleNo._498N;
                    }
                }

                int dm_deduct = 0;
                if (if_divNxt_is_dummy_mullion)
                {
                    if (divNxt.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                    {
                        dm_deduct = 8;
                    }
                    else if (divNxt.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                    {
                        dm_deduct = 4;
                    }
                }

                if (if_divPrev_is_dummy_mullion)
                {
                    if (divPrev.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                    {
                        dm_deduct = 8;
                    }
                    else if (divPrev.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                    {
                        dm_deduct = 4;
                    }
                }

                int handle_deduct = 0, glass_deduct = 0, glassAllowance_Deduct = 0, inward_motorized_deduction = 0, SashOverlap_additional = 0, TotalNumberOfPanel = 1;

                if (Panel_SashReinfArtNo == SashReinf_ArticleNo._R675 || Panel_SashReinfArtNo == SashReinf_ArticleNo._207)
                {
                    handle_deduct = 55;
                }
                else if (Panel_SashReinfArtNo == SashReinf_ArticleNo._655)
                {
                    handle_deduct = 40;
                }
                else if (Panel_SashReinfArtNo == SashReinf_ArticleNo._TV104)
                {
                    handle_deduct = 50;
                }
                else if (Panel_SashReinfArtNo == SashReinf_ArticleNo._TV106)
                {
                    handle_deduct = 50;
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                {
                    glass_deduct = 55;
                }
                else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                         Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                {
                    glass_deduct = 86;
                }
                else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    glass_deduct = 57;

                    if (Panel_MotorizedOptionVisibility == true)
                    {
                        inward_motorized_deduction = 35;
                    }
                }
                else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                {
                    glass_deduct = 48;
                }
                else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    glass_deduct = 64;
                }


                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 || Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    glassAllowance_Deduct = 10;
                }
                else
                {
                    glassAllowance_Deduct = 6;
                }

                if (OverLappingPanel_Qty != 0)
                {
                    if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                    {
                        SashOverlap_additional = OverLappingPanel_Qty * 70;
                    }
                    else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                    {
                        SashOverlap_additional = OverLappingPanel_Qty * 86;
                    }
                }


                if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV110 || Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._TV107)
                {
                    TotalNumberOfPanel = Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
                }
                else
                {
                    TotalNumberOfPanel = 1;
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    deduction_for_sashHT -= 2;
                }

                if (ChckBoundedByBotframe == true)
                {
                    if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502)
                    {
                        deduction_for_sashHT -= 6;
                    }
                    else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789)
                    {

                    }
                    else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                    {

                    }
                    else if (Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                             Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166)
                    {

                    }
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 || Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    Panel_SashWidth = ((((Panel_ParentFrameModel.Frame_Width - deduction_for_sashWD + SashOverlap_additional) - dm_deduct) - inward_motorized_deduction) / TotalNumberOfPanel) + 5;
                }
                else
                {
                    Panel_SashWidth = ((((Panel_DisplayWidth - deduction_for_sashWD) - dm_deduct) - inward_motorized_deduction)) + 5;
                }

                Panel_SashWidthDecimal = Panel_DisplayWidthDecimal;
                Panel_SashHeight = (Panel_DisplayHeight - deduction_for_sashHT) + 5;
                Panel_SashHeightDecimal = Panel_DisplayHeightDecimal;

                Panel_OriginalSashWidth = Panel_SashWidth;
                Panel_OriginalSashWidthDecimal = Panel_SashWidthDecimal;
                Panel_OriginalSashHeight = Panel_SashHeight;
                Panel_OriginalSashHeightDecimal = Panel_SashHeightDecimal;

                Panel_SashReinfWidth = Panel_SashWidth - 5 - (handle_deduct * 2) - 10;
                Panel_SashReinfWidthDecimal = Panel_SashWidthDecimal;
                Panel_SashReinfHeight = Panel_SashHeight - 5 - (handle_deduct * 2) - 10;
                Panel_SashReinfHeightDecimal = Panel_SashHeightDecimal;

                //Panel_GlazingBeadWidth = Panel_SashWidth;
                //Panel_GlazingBeadWidthDecimal = Panel_SashWidthDecimal;
                //Panel_GlazingBeadHeight = Panel_SashHeight;
                //Panel_GlazingBeadHeightDecimal = Panel_SashHeightDecimal;
                string name = Panel_Name;
                Panel_GlassWidth = ((Panel_SashWidth - 5) - (glass_deduct * 2)) - glassAllowance_Deduct;
                Panel_GlassWidthDecimal = Panel_SashWidthDecimal;
                Panel_GlassHeight = Panel_SashHeight - 5 - (glass_deduct * 2) - glassAllowance_Deduct;
                Panel_GlassHeightDecimal = Panel_SashHeightDecimal;

                Panel_OriginalGlassWidth = Panel_GlassWidth;
                Panel_OriginalGlassWidthDecimal = Panel_GlassWidthDecimal;
                Panel_OriginalGlassHeight = Panel_GlassHeight;
                Panel_OriginalGlassHeightDecimal = Panel_GlassHeightDecimal;

                Panel_GlazingBeadWidth = Panel_GlassWidth + 200;
                Panel_GlazingBeadWidthDecimal = Panel_GlassWidthDecimal;
                Panel_GlazingBeadHeight = Panel_GlassHeight + 200;
                Panel_GlazingBeadHeightDecimal = Panel_GlassHeightDecimal;


                Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;


                if (Panel_HingeOptions == HingeOption._2DHinge)
                {
                    Panel_2dHingeArtNo_nonMotorized = _2DHinge_ArticleNo._614293;

                    //if (Panel_SashHeight <= 1499)
                    //{
                    //    Panel_2DHingeQty_nonMotorized = 3;
                    //}
                    //else if (Panel_SashHeight >= 1500)
                    //{
                    //    Panel_2DHingeQty_nonMotorized = 4;
                    //}
                }


                #region Algo for Adjustable Striker

                int obj_count = Panel_ParentMultiPanelModel.GetCount_MPanelLst_Object();
                bool allow_adjStriker = true;

                if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                {
                    Panel_AdjStrikerArtNo = null;

                    int nxt_pnl_ndx = Panel_Index_Inside_MPanel + 2;
                    if (Panel_Index_Inside_MPanel == 0 && nxt_pnl_ndx < obj_count)
                    {
                        string nxt_pnl_name = Panel_ParentMultiPanelModel.MPanelLst_Objects[nxt_pnl_ndx].Name;
                        IPanelModel nxt_pnl = Panel_ParentMultiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_pnl_name);

                        string nxt_div_name = Panel_ParentMultiPanelModel.MPanelLst_Objects[Panel_Index_Inside_MPanel + 1].Name;
                        IDividerModel nxt_divModel = Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == nxt_div_name);
                        if (nxt_divModel.Div_DMPanel != null)
                        {
                            if (nxt_divModel.Div_DMPanel == nxt_pnl)
                            {
                                allow_adjStriker = false;
                            }
                        }

                        int nxt_div_indx_after_nxtPnl = Panel_Index_Inside_MPanel + 3;

                        if (nxt_div_indx_after_nxtPnl < obj_count)
                        {
                            string nxt_div_name_after_nxtPnl = Panel_ParentMultiPanelModel.MPanelLst_Objects[nxt_div_indx_after_nxtPnl].Name;
                            IDividerModel nxt_divModel_after_nxtPnl = Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == nxt_div_name_after_nxtPnl);
                            if (nxt_divModel_after_nxtPnl.Div_DMPanel != null)
                            {
                                if (nxt_divModel_after_nxtPnl.Div_DMPanel == nxt_pnl)
                                {
                                    allow_adjStriker = false;
                                }
                            }
                        }

                    }

                    int prev_pnl_ndx = Panel_Index_Inside_MPanel - 2;
                    if (Panel_Index_Inside_MPanel > 1 && prev_pnl_ndx >= 0)
                    {
                        string prev_pnl_name = Panel_ParentMultiPanelModel.MPanelLst_Objects[prev_pnl_ndx].Name;
                        IPanelModel prev_pnl = Panel_ParentMultiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_pnl_name);

                        string prev_div_name = Panel_ParentMultiPanelModel.MPanelLst_Objects[Panel_Index_Inside_MPanel - 1].Name;
                        IDividerModel prev_divModel = Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == prev_div_name);
                        if (prev_divModel.Div_DMPanel != null)
                        {
                            if (prev_divModel.Div_DMPanel == prev_pnl)
                            {
                                allow_adjStriker = false;
                            }
                        }

                        int prev_div_indx_before_prevPnl = Panel_Index_Inside_MPanel - 3;

                        if (prev_div_indx_before_prevPnl > 0)
                        {
                            string prev_div_name_before_prevPnl = Panel_ParentMultiPanelModel.MPanelLst_Objects[prev_div_indx_before_prevPnl].Name;
                            IDividerModel prev_divModel_before_prevPnl = Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == prev_div_name_before_prevPnl);
                            if (prev_divModel_before_prevPnl.Div_DMPanel != null)
                            {
                                if (prev_divModel_before_prevPnl.Div_DMPanel == prev_pnl)
                                {
                                    allow_adjStriker = false;
                                }
                            }
                        }

                    }

                    if (allow_adjStriker)
                    {
                        Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
                    }
                }

                #endregion

                if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                    (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373))
                {

                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                    {
                        Panel_AdjStrikerQty += 4;
                    }

                    if (Panel_ExtensionTopArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionTopArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionTopArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionTopArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtTopQty);
                    }

                    if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionTop2ArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionTop2ArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionTop2ArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtTop2Qty);
                    }

                    if (Panel_ExtensionBotArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionBotArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionBotArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionBotArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtBotQty);
                    }

                    if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957 ||
                        Panel_ExtensionBot2ArtNo == Extension_ArticleNo._567639 ||
                        Panel_ExtensionBot2ArtNo == Extension_ArticleNo._630956 ||
                        Panel_ExtensionBot2ArtNo == Extension_ArticleNo._641798)
                    {
                        Panel_AdjStrikerQty += (1 * Panel_ExtBot2Qty);
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_AdjStrikerQty += 1;
                    }

                    Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
                    Panel_RestrictorStayQty = 2;

                    if (outside_color == Foil_Color._None)
                    {
                        if (base_color == Base_Color._White)
                        {
                            Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_WHT;
                        }
                        else if (base_color == Base_Color._Ivory)
                        {
                            Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_IVORY;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_DB;
                        }
                    }
                    else if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                             outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                             outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                             outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                             outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
                    {
                        Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_BL;
                    }
                    else if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._GoldenOak ||
                             outside_color == Foil_Color._Mahogany || outside_color == Foil_Color._Havana)
                    {
                        Panel_3dHingeArtNo = _3dHinge_ArticleNo._3DHinge_DB;
                    }

                    //if (Panel_SashHeight < 2400)
                    //{
                    //    Panel_3dHingeQty = 3;
                    //}
                    //else if (Panel_SashHeight > 2399 && Panel_SashHeight < 2700)
                    //{
                    //    Panel_3dHingeQty = 4;
                    //}
                    //else if (Panel_SashHeight > 2699 && Panel_SashHeight < 3200)
                    //{
                    //    Panel_3dHingeQty = 5;
                    //}
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                    {
                        Panel_AdjStrikerQty += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                    {
                        Panel_AdjStrikerQty += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
                    {
                        Panel_AdjStrikerQty += 4;
                    }

                    Panel_StayBearingKArtNo = StayBearingK_ArticleNo._N390A00106_230177;
                    Panel_StayBearingPinArtNo = StayBearingPin_ArticleNo._F710D52008_227354;
                    Panel_TopCornerHingeSpacerArtNo = TopCornerHingeSpacer_ArticleNo._331488;
                    Panel_CornerHingeKArtNo = CornerHingeK_ArticleNo._N510A0011;
                    Panel_CornerPivotRestKArtNo = CornerPivotRestK_ArticleNo._N510A0001_258590;

                    if (base_color == Base_Color._Ivory || base_color == Base_Color._White)
                    {
                        Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._WhiteIvory;
                        Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._WhiteIvory;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
                        Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._WhiteIvory;
                        Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._WhiteIvory;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._DB;
                        Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._DB;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._DB;
                        Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._DB;
                        Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._DB;
                        Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._DB;
                    }

                    if (Panel_ChkText == "L")
                    {
                        Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Left;
                    }
                    else if (Panel_ChkText == "R")
                    {
                        Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Right;
                    }
                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                {
                    Panel_GuideTrackProfileArtNo = GuideTrackProfile_ArticleNo._6059;
                    Panel_AluminumTrackArtNo = AluminumTrack_ArticleNo._9C51;
                    Panel_WeatherBarArtNo = WeatherBar_ArticleNo._1244;
                    Panel_WaterSeepageArtNo = WaterSeepage_ArticleNo._1646;
                    if (OverLappingPanel_Qty != 0)
                    {
                        Panel_InterlockArtNo = Interlock_ArticleNo._6061_Milled;
                        Panel_ExtensionForInterlockArtNo = ExtensionForInterlock_ArticleNo._9C61_Milled;
                    }
                    Panel_WeatherBarFastenerArtNo = WeatherBarFastener_ArticleNo._9447;
                    Panel_BrushSealArtNo = BrushSeal_ArticleNo._9091;
                    Panel_GlazingRebateBlockArtNo = GlazingRebateBlock_ArticleNo._9C56;
                    Panel_SealingBlockArtNo = SealingBlock_ArticleNo._9C63;
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._9C54;
                    Panel_SpacerArtNo = Spacer_ArticleNo._M063;

                }

                if (Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    Panel_GuideTrackProfileArtNo = GuideTrackProfile_ArticleNo._6059;
                    Panel_AluminumTrackArtNo = AluminumTrack_ArticleNo._9C51;
                    Panel_WeatherBarArtNo = WeatherBar_ArticleNo._1244;
                    Panel_WaterSeepageArtNo = WaterSeepage_ArticleNo._1646;
                    if (OverLappingPanel_Qty != 0)
                    {
                        Panel_InterlockArtNo = Interlock_ArticleNo._6061_Milled;
                        Panel_ExtensionForInterlockArtNo = ExtensionForInterlock_ArticleNo._9C61_Milled;
                    }
                    Panel_WeatherBarFastenerArtNo = WeatherBarFastener_ArticleNo._9447;
                    Panel_BrushSealArtNo = BrushSeal_ArticleNo._9091;
                    Panel_GlazingRebateBlockArtNo = GlazingRebateBlock_ArticleNo._9C56;
                    Panel_SealingBlockArtNo = SealingBlock_ArticleNo._9C63;
                    Panel_GBSpacerArtNo = GBSpacer_ArticleNo._9C54;
                    Panel_SpacerArtNo = Spacer_ArticleNo._M063;
                    if (Panel_ParentFrameModel.Frame_ConnectionType == FrameConnectionType._MechanicalJoint)
                    {
                        Panel_ParentFrameModel.Frame_MechJointArticleNo = Frame_MechJointArticleNo._9C52;
                        Panel_RollersTypes = RollersTypes._HDRoller;
                        Panel_SealingElement_ArticleNo = SealingElement_ArticleNo._9C97;
                    }

                    if (Panel_MotorizedOptionVisibility == true)
                    {
                        Panel_PVCCenterProfileArtNo = PVCCenterProfile_ArticleNo._6067;

                        if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_GS100_T_EM_T_HMCOVER_ArtNo = GS100_T_EM_T_HMCOVER_ArticleNo._L15056103B;
                        }
                        else
                        {
                            Panel_GS100_T_EM_T_HMCOVER_ArtNo = GS100_T_EM_T_HMCOVER_ArticleNo._L15056103;
                        }

                        Panel_TrackRailArtNo = TrackRail_ArticleNo._L15056196;
                        Panel_MicrocellOneSafetySensorArtNo = MicrocellOneSafetySensor_ArticleNo._L15056051;
                        Panel_AutodoorBracketForGS100UPVCArtNo = AutodoorBracketForGS100UPVC_ArticleNo._L15227001;
                        Panel_GS100EndCapScrewM5AndLSupportArtNo = GS100EndCapScrewM5AndLSupport_ArticleNo._L15227002;
                        Panel_EuroLeadExitButtonArtNo = EuroLeadExitButton_ArticleNo._L15224001;
                        Panel_TOOTHBELT_EM_CMArtNo = TOOTHBELT_EM_CM_ArticleNo._A7134370;
                        Panel_GuBeaZenMicrowaveSensorArtNo = GuBeaZenMicrowaveSensor_ArticleNo._L15049052;
                        Panel_SlidingDoorKitGs100_1ArtNo = SlidingDoorKitGs100_1_ArticleNo._A9002180;
                        Panel_GS100CoverKitArtNo = GS100CoverKit_ArticleNo._L15049052;
                    }
                }

                #region MiddleCloser


                //if (base_color == Base_Color._DarkBrown)
                //{
                //    if (Panel_Type.Contains("Awning"))
                //    {
                //        if (Panel_DisplayHeight < 1551)
                //        {
                //            Panel_MiddleCloserPairQty = 1;
                //        }
                //        else if (Panel_DisplayHeight > 1551 && Panel_DisplayHeight < 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 2;
                //        }
                //        else if (Panel_DisplayHeight > 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 3;
                //        }
                //    }
                //    else if (Panel_Type.Contains("Casement"))
                //    {
                //        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                //                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                //            {
                //                Panel_MiddleCloserPairQty = 0;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                //            {
                //                if (Panel_SashHeight < 1201)
                //                {
                //                    Panel_MiddleCloserPairQty = 1;
                //                }
                //                else if (Panel_SashHeight > 1200)
                //                {
                //                    Panel_MiddleCloserPairQty = 0;
                //                }
                //            }
                //        }
                //        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //        }
                //    }
                //}
                //else if (base_color == Base_Color._White ||
                //         base_color == Base_Color._Ivory)
                //{
                //    if (Panel_Type.Contains("Awning"))
                //    {
                //        if (Panel_SashHeight < 1551)
                //        {
                //            Panel_MiddleCloserPairQty = 1;
                //        }
                //        else if (Panel_SashHeight > 1551 && Panel_SashHeight < 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 2;
                //        }
                //        else if (Panel_SashHeight > 1999)
                //        {
                //            Panel_MiddleCloserPairQty = 3;
                //        }
                //    }
                //    else if (Panel_Type.Contains("Casement"))
                //    {
                //        if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                //                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                //            {
                //                Panel_MiddleCloserPairQty = 0;
                //            }
                //            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                //            {
                //                if (Panel_SashHeight < 1201)
                //                {
                //                    Panel_MiddleCloserPairQty = 1;
                //                }
                //                else if (Panel_SashHeight > 1200)
                //                {
                //                    Panel_MiddleCloserPairQty = 0;
                //                }
                //            }
                //        }
                //        else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                //        {
                //            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                //            {
                //                Panel_MiddleCloserPairQty = 1;
                //            }
                //        }
                //    }
                //}
                #endregion

                Panel_StrikerArtno_A = Striker_ArticleNo._M89ANTA;
                Panel_StrikerArtno_C = Striker_ArticleNo._M89ANTC;

                if (Panel_MotorizedOptionVisibility == true)
                {
                    if (Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                    {
                        Panel_MotorizedMechQty += 1;
                    }
                    else if (Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                             Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                    {
                        if (Panel_DisplayWidth > 0 && Panel_DisplayWidth <= 1099)
                        {
                            Panel_MotorizedMechQty += 1;
                        }
                        else if (Panel_DisplayWidth >= 1100)
                        {
                            Panel_MotorizedMechQty += 2;
                        }
                    }
                }

                if (Panel_Type.Contains("Awning"))
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                    {
                        Panel_StrikerQty_A += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                    {
                        Panel_StrikerQty_A += 3;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                    {
                        Panel_StrikerQty_A += 4;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                    {
                        Panel_StrikerQty_A += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                    {
                        Panel_StrikerQty_A += 2;
                    }

                    if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtLeftQty);
                    }

                    if (Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtLeft2Qty);
                    }

                    if (Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtRightQty);
                    }

                    if (Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtRight2Qty);
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_StrikerQty_A += 2;
                    }
                }
                else if (Panel_Type.Contains("Casement"))
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                    {
                        Panel_StrikerQty_C += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                    {
                        Panel_StrikerQty_C += 3;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
                    {
                        Panel_StrikerQty_C += 4;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206)
                    {
                        Panel_StrikerQty_C += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206)
                    {
                        Panel_StrikerQty_C += 2;
                    }

                    if (Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtTopQty);
                    }

                    if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtTop2Qty);
                    }

                    if (Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtBotQty);
                    }

                    if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                    {
                        Panel_StrikerQty_C += (1 * Panel_ExtBot2Qty);
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        Panel_StrikerQty_A += 1;
                    }
                }
                else if (Panel_Type.Contains("Sliding"))
                {
                    if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._774275 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._774276 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._774277 ||
                        Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._6_90137_10_0_1)
                    {
                        Panel_StrikerArtno_SlidingQty += 2;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._774278 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._774286)
                    {
                        Panel_StrikerArtno_SlidingQty += 3;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._774287 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._731852)
                    {
                        Panel_StrikerArtno_SlidingQty += 4;
                    }
                }

                int sashWD_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashWidth / 100)) * 100;
                int sashHt_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashHeight / 100)) * 100;

                if (Panel_Type.Contains("Awning"))
                {
                    FrictionStay_ArticleNo fs_dimension_based = FrictionStay_ArticleNo._None;
                    FrictionStay_ArticleNo fs_weight_based = FrictionStay_ArticleNo._None;

                    if ((sashWD_floor >= 400 && sashWD_floor <= 1200) &&
                        (Panel_SashHeight >= 350 && Panel_SashHeight <= 399))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm8;
                    }
                    else if (sashHt_floor >= 400 && sashHt_floor <= 500)
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._10HD;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 1000) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._12HD;
                    }
                    else if (((sashWD_floor >= 1100 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._16HD;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1100) &&
                             (sashHt_floor >= 800 && sashHt_floor <= 900)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._16HD;
                    }
                    else if (((sashWD_floor >= 1200 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 800 && sashHt_floor <= 900)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm22;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 1000 && sashHt_floor <= 1200)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm22;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 1300 && sashHt_floor <= 2300)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._Storm26;
                    }
                    else
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._None;
                    }

                    if (Panel_GlassThickness >= 12.0f)
                    {
                        float sash_weight = ((((Panel_SashWidth / 1000) + (Panel_SashHeight / 1000)) * 2) * 1) * 3,
                              glass_weight = (Panel_GlassThickness / 1000) * (Panel_GlassWidth / 1000) * (Panel_GlassHeight / 1000) * 1 * 2500;
                        int total_weight = Convert.ToInt32(Math.Ceiling((decimal)(sash_weight + glass_weight)));

                        if (total_weight >= 1 && total_weight <= 44)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm8;
                        }
                        else if (total_weight >= 45 && total_weight <= 49)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._10HD;
                        }
                        else if (total_weight >= 50 && total_weight <= 54)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._12HD;
                        }
                        else if (total_weight >= 55 && total_weight <= 74)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._16HD;
                        }
                        else if (total_weight >= 75 && total_weight <= 119)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm22;
                        }
                        else if (total_weight >= 120)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm26;
                        }
                    }

                    if (fs_weight_based != FrictionStay_ArticleNo._None)
                    {
                        if (fs_weight_based.Value > fs_dimension_based.Value)
                        {
                            Panel_FrictionStayArtNo = fs_weight_based;
                        }
                        else if (fs_weight_based.Value < fs_dimension_based.Value)
                        {
                            Panel_FrictionStayArtNo = fs_dimension_based;
                        }
                        else if (fs_weight_based.Value == fs_dimension_based.Value)
                        {
                            Panel_FrictionStayArtNo = fs_weight_based;
                        }
                    }
                    else if (fs_weight_based == FrictionStay_ArticleNo._None)
                    {
                        Panel_FrictionStayArtNo = fs_dimension_based;
                    }

                    if (Panel_Type == "Awning Panel")
                    {
                        if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                        {
                            if (base_color == Base_Color._Ivory || base_color == Base_Color._White)
                            {
                                Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
                            }
                            else if (base_color == Base_Color._DarkBrown)
                            {
                                Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400215;
                            }
                            Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;
                        }
                    }
                }
                else if (Panel_Type.Contains("Casement"))
                {
                    FrictionStayCasement_ArticleNo fs_dimension_based = FrictionStayCasement_ArticleNo._None;
                    FrictionStayCasement_ArticleNo fs_weight_based = FrictionStayCasement_ArticleNo._None;

                    if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                        (Panel_SashWidth >= 350 && Panel_SashWidth <= 399))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._10HD;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 400 && sashHt_floor <= 1200))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._12FS;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 1300 && sashHt_floor <= 1500))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._12HD;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 500) &&
                             (sashHt_floor >= 1600 && sashHt_floor <= 2100))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._12HD;
                    }
                    else if ((sashHt_floor >= 1600 && sashHt_floor <= 2200) &&
                             (Panel_SashWidth >= 600 && Panel_SashWidth <= 699))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._16HD;
                    }
                    else if (Panel_SashWidth >= 700 && Panel_SashWidth <= 799)
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._16HD;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 800 && Panel_SashWidth <= 899))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._16HD;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 900 && Panel_SashWidth <= 999))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._20HD;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 1500) &&
                             (Panel_SashWidth >= 1000 && Panel_SashWidth <= 1199))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._20HD;
                    }
                    else
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._None;
                    }

                    if (Panel_GlassThickness >= 12.0f)
                    {
                        float sash_weight = ((((Panel_SashWidth / 1000) + (Panel_SashHeight / 1000)) * 2) * 1) * 3,
                              glass_weight = (Panel_GlassThickness / 1000) * (Panel_GlassWidth / 1000) * (Panel_GlassHeight / 1000) * 1 * 2500;
                        int total_weight = Convert.ToInt32(Math.Ceiling((decimal)(sash_weight + glass_weight)));

                        if (total_weight >= 1 && total_weight <= 18)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._12FS;
                        }
                        else if (total_weight >= 19 && total_weight <= 35)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._10HD;
                        }
                        else if (total_weight >= 36 && total_weight <= 40)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._12HD;
                        }
                        else if (total_weight >= 41 && total_weight <= 45)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._16HD;
                        }
                        else if (total_weight >= 46)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._20HD;
                        }
                    }

                    if (fs_weight_based != FrictionStayCasement_ArticleNo._None)
                    {
                        if (fs_weight_based.Value > fs_dimension_based.Value)
                        {
                            Panel_FSCasementArtNo = fs_weight_based;
                        }
                        else if (fs_weight_based.Value < fs_dimension_based.Value)
                        {
                            Panel_FSCasementArtNo = fs_dimension_based;
                        }
                        else if (fs_weight_based.Value == fs_dimension_based.Value)
                        {
                            Panel_FSCasementArtNo = fs_weight_based;
                        }
                    }
                    else if (fs_weight_based == FrictionStayCasement_ArticleNo._None)
                    {
                        Panel_FSCasementArtNo = fs_dimension_based;
                    }

                    Panel_PlasticWedgeQty = 1;

                    if (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (base_color == Base_Color._Ivory || base_color == Base_Color._White)
                        {
                            Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400215;
                        }

                        Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;
                    }
                }

                if (base_color == Base_Color._Ivory ||
                    base_color == Base_Color._White)
                {
                    Panel_PlasticWedge = PlasticWedge_ArticleNo._7199WHT;
                }
                else if (base_color == Base_Color._DarkBrown)
                {
                    Panel_PlasticWedge = PlasticWedge_ArticleNo._7199DB;
                }

                if (Panel_HandleType == Handle_Type._Rio)
                {
                    Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;

                    if (inside_color != null ||
                       outside_color != null ||
                       inside_color != outside_color) // 2 diff foil color
                    {

                        if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                                 inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                                 inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                                 inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                                 inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                                 inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_9005_614441;
                        }

                        if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._Mahogany ||
                                outside_color == Foil_Color._GoldenOak || outside_color == Foil_Color._Havana)
                        {
                            Panel_CylinderCoverArtNo2 = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                                 outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                                 outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                                 outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                                 outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_CylinderCoverArtNo2 = Cylinder_CoverArtNo._EPSW_9005_614441;
                        }
                    }
                    else
                    {
                        if (inside_color == Foil_Color._None)
                        {
                            if (base_color == Base_Color._White)
                            {
                                Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_7025_50992;
                            }
                            else if (base_color == Base_Color._DarkBrown)
                            {
                                Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                            }
                            else if (base_color == Base_Color._Ivory)
                            {
                                Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_IVORY;
                            }
                        }
                        else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                                 inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                                 inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                                 inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                                 inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                                 inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_9005_614441;
                        }
                    }
                }
                else if (Panel_HandleType == Handle_Type._MVD)
                {
                    Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;

                    if (inside_color == Foil_Color._None)
                    {
                        if (base_color == Base_Color._White)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_7025_50992;
                        }
                        else if (base_color == Base_Color._DarkBrown)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                        }
                        else if (base_color == Base_Color._Ivory)
                        {
                            Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_IVORY;
                        }
                    }
                    else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                             inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                    {
                        Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
                    }
                    else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                             inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                             inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                             inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                             inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                    {
                        Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_9005_614441;
                    }

                    Panel_WeldableCArtNo = WeldableCornerJoint_ArticleNo._498N;
                    if (Panel_ParentFrameModel.Frame_Height > 2499)
                    {
                        if (Panel_ChkText == "L")
                        {
                            Panel_LatchDeadboltStrikerArtNo = LatchDeadboltStriker_ArticleNo._Left;
                        }
                        else if (Panel_ChkText == "R")
                        {
                            Panel_LatchDeadboltStrikerArtNo = LatchDeadboltStriker_ArticleNo._Right;
                        }
                    }
                }
                else if (Panel_HandleType == Handle_Type._D)
                {
                    Panel_ScrewSetsArtNo = ScrewSets._DH613172;
                    #region ColorAndArtNo

                    //if (inside_color == Foil_Color._None)
                    //{
                    //    if (base_color == Base_Color._White)
                    //    {
                    //        Panel_DHandleInsideArtNo = D_HandleArtNo._DH613226;
                    //        Panel_DHandleOutsideArtNo = D_HandleArtNo._DH605543;
                    //    }
                    //    else if (base_color == Base_Color._DarkBrown)
                    //    {
                    //        Panel_DHandleInsideArtNo = D_HandleArtNo._DH613224;
                    //        Panel_DHandleOutsideArtNo = D_HandleArtNo._DH613185;
                    //    }
                    //    else if (base_color == Base_Color._Ivory)
                    //    {
                    //        Panel_DHandleInsideArtNo = D_HandleArtNo._DH613228;
                    //        Panel_DHandleOutsideArtNo = D_HandleArtNo._DH487261;
                    //    }
                    //}
                    //else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                    //         inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                    //{
                    //    Panel_DHandleInsideArtNo = D_HandleArtNo._DH613224;
                    //    Panel_DHandleOutsideArtNo = D_HandleArtNo._DH613185;
                    //}
                    //else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                    //         inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                    //         inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                    //         inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                    //         inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                    //{
                    //    Panel_DHandleInsideArtNo = D_HandleArtNo._DH613225;
                    //    Panel_DHandleOutsideArtNo = D_HandleArtNo._DH605551;
                    //}


                    #endregion
                }
                else if (Panel_HandleType == Handle_Type._D_IO_Locking)
                {
                    Panel_ScrewSetsArtNo = ScrewSets._DH613180;

                    #region ColorAndArtNo


                    //if (inside_color == Foil_Color._None)
                    //{
                    //    if (base_color == Base_Color._White)
                    //    {
                    //        Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613243;
                    //        Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._613217;
                    //    }
                    //    else if (base_color == Base_Color._DarkBrown)
                    //    {
                    //        Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH833309_613215;
                    //        Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH833308_613241;
                    //    }
                    //    else if (base_color == Base_Color._Ivory)
                    //    {
                    //        Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613245;
                    //        Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH613219;
                    //    }
                    //}
                    //else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                    //        inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                    //{
                    //    Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH833309_613215;
                    //    Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH833308_613241;
                    //}
                    //else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                    //         inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                    //         inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                    //         inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                    //         inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                    //{
                    //    Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613242;
                    //    Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH605216;
                    //}
                    #endregion

                }
                else if (Panel_HandleType == Handle_Type._DummyD)
                {
                    Panel_ScrewSetsArtNo = ScrewSets._DH613176;
                    #region ColorAndArtNo

                    //if (inside_color == Foil_Color._None)
                    //{
                    //    if (base_color == Base_Color._White)
                    //    {
                    //        Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613226;
                    //        Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH613191;
                    //    }
                    //    else if (base_color == Base_Color._DarkBrown)
                    //    {
                    //        Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613224;
                    //        Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH833310_613189;
                    //    }
                    //    else if (base_color == Base_Color._Ivory)
                    //    {
                    //        Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613228;
                    //        Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH613193;
                    //    }
                    //}
                    //else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                    //      inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                    //{
                    //    Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613224;
                    //    Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH833310_613189;
                    //}
                    //else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                    //         inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                    //         inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                    //         inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                    //         inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                    //{
                    //    Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613225;
                    //    Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH613190;
                    //}

                    #endregion
                }

                #region PopupAndRSS


                //else if (Panel_HandleType == Handle_Type._PopUp)
                //{
                //    if (base_color == Base_Color._White || base_color == Base_Color._Ivory)
                //    {
                //        Panel_PopUpHandleArtNo = PopUp_HandleArtNo._3127668;
                //    }
                //    else if (base_color == Base_Color._DarkBrown)
                //    {
                //        Panel_PopUpHandleArtNo = PopUp_HandleArtNo._323778;
                //    }
                //}
                //else if (Panel_HandleType == Handle_Type._RotoswingForSliding)
                //{
                //    if (inside_color == Foil_Color._None)
                //    {
                //        if (base_color == Base_Color._White)
                //        {
                //            Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS632303;
                //        }
                //        else if (base_color == Base_Color._DarkBrown)
                //        {
                //            Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS632300;
                //        }
                //        else if (base_color == Base_Color._Ivory)
                //        {
                //            Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS823094;
                //        }
                //    }
                //    else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Havana ||
                //        inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Mahogany)
                //    {
                //        Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS632300;
                //    }
                //    else if (inside_color == Foil_Color._CharcoalGray || inside_color == Foil_Color._FossilGray ||
                //             inside_color == Foil_Color._BeechOak || inside_color == Foil_Color._DriftWood ||
                //             inside_color == Foil_Color._Graphite || inside_color == Foil_Color._JetBlack ||
                //             inside_color == Foil_Color._ChestnutOak || inside_color == Foil_Color._WashedOak ||
                //             inside_color == Foil_Color._GreyOak || inside_color == Foil_Color._Cacao)
                //    {
                //        Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS823073;
                //    }
                //}

                #endregion
            }
            else if (Panel_SashPropertyVisibility == false)
            {
                Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;

                Panel_SashWidth = 0;
                Panel_SashHeight = 0;

                Panel_SashReinfWidth = 0;
                Panel_SashReinfHeight = 0;

                //Panel_GlazingBeadWidth = Panel_DisplayWidth;
                //Panel_GlazingBeadHeight = Panel_DisplayHeight;

                Panel_GlassWidth = (Panel_DisplayWidth - deduction_for_wd) - 6;
                Panel_GlassHeight = (Panel_DisplayHeight - deduction_for_ht) - 6;

                Panel_GlazingBeadWidth = Panel_GlassWidth + 200;
                Panel_GlazingBeadHeight = Panel_GlassHeight + 200;

                Panel_OriginalGlassWidth = (Panel_OriginalDisplayWidth - deduction_for_wd) - 6;
                Panel_OriginalGlassHeight = (Panel_OriginalDisplayHeight - deduction_for_ht) - 6;


                if (Panel_Type.Contains("Louver"))
                {
                    Set_LouverBladesCount();

                    Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                    Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;
                    Panel_PlantOnWeatherStripHeadArtNo = PlantOnWeatherStripHead_ArticleNo._AL1313;
                    Panel_PlantOnWeatherStripSealArtNo = PlantOnWeatherStripSeal_ArticleNo._AL1314;
                    Panel_LouverFrameWeatherStripHeadArtNo = LouverFrameWeatherStripHead_ArticleNo._AL1307;
                    Panel_LouverFrameBottomWeatherStripArtNo = LouverFrameBottomWeatherStrip_ArticleNo._AL1309;
                    Panel_RubberSealArtNo = RubberSeal_ArticleNo._SL31;
                    Panel_CasementSealArtNo = CasementSeal_ArticleNo._9040;
                    Panel_SealForHandleArtNo = SealForHandle_ArticleNo._WDL2;

                    if (Panel_LouverBladeTypeOption == BladeType_Option._Aluminum)
                    {

                    }

                    int lvrgDeduction = 0;
                    if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                    {
                        lvrgDeduction = 33;
                    }
                    else if (Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                    {
                        lvrgDeduction = 47;
                    }

                    Panel_PlantOnWeatherStripHeadWidth = Panel_DisplayWidth - deduction_for_wd - 2;
                    Panel_PlantOnWeatherStripSealWidth = Panel_DisplayWidth - deduction_for_wd - 2;
                    Panel_LouverFrameWeatherStripHeadWidth = Panel_PlantOnWeatherStripHeadWidth - 44;
                    Panel_LouverFrameBottomWeatherStripWidth = Panel_PlantOnWeatherStripHeadWidth - 44;
                    Panel_RubberSealWidth = Panel_DisplayWidth;
                    Panel_CasementSealWidth = Panel_DisplayWidth;
                    Panel_GlassWidth = Panel_DisplayWidth - deduction_for_wd - (32 * 2);

                    if (Panel_LstSealForHandleMultiplier != null)
                    {
                        Panel_SealForHandleQty = 0;
                        foreach (int multiplier in Panel_LstSealForHandleMultiplier)
                        {
                            Panel_SealForHandleQty += 400 * multiplier;
                        }
                    }
                }
            }

            Panel_GlazingSpacerQty = 1;
        }
        public int MotorizeMechQty()
        {
            int motor = 0, resetChk = 0;
            foreach (IMultiPanelModel mpnl in Panel_ParentFrameModel.Lst_MultiPanel)
            {
                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                {
                    resetChk++;
                    if (pnl.Panel_MotorizedOptionVisibility == true)
                    {
                        if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
                        {
                            motor += 1;
                        }
                        else if (pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                                 pnl.Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
                        {
                            if (pnl.Panel_DisplayWidth > 0 && pnl.Panel_DisplayWidth <= 1099)
                            {
                                motor += 1;
                            }
                            else if (pnl.Panel_DisplayWidth >= 1100)
                            {
                                motor += 2;
                            }
                        }
                    }
                }
            }
            Panel_MotorizedMechQty = motor;
            return motor;
        }

        public bool ChckIfBoundedByBottomFrame()
        {
            bool chkBtmFrm = false;




            return chkBtmFrm;
        }

        #region Material_List

        public void Insert_SashInfo_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Sash Width " + Panel_SashProfileArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_SashWidth.ToString(),
                                   "Sash",
                                   @"\  /");

            tbl_explosion.Rows.Add("Sash Height " + Panel_SashProfileArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_SashHeight.ToString(),
                                   "Sash",
                                   @"\  /");

            tbl_explosion.Rows.Add("Sash Reinf Width " + Panel_SashReinfArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_SashReinfWidth.ToString(),
                                   "Sash",
                                   @"|  |");

            tbl_explosion.Rows.Add("Sash Reinf Height " + Panel_SashReinfArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_SashReinfHeight.ToString(),
                                   "Sash",
                                   @"|  |");
        }

        public void Insert_CoverProfileInfo_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Cover Profile " + Panel_CoverProfileArtNo.DisplayName,
                                              1, "pc(s)",
                                              Panel_DisplayWidth.ToString(),
                                              "Frame",
                                              @"|  |");

            tbl_explosion.Rows.Add("Cover Profile " + Panel_CoverProfileArtNo2.DisplayName,
                                   1, "pc(s)",
                                   Panel_DisplayWidth.ToString(),
                                   "Frame",
                                   @"|  |");
        }

        public void Insert_CoverProfileForPremiInfo_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Cover Profile " + Panel_CoverProfileArtNo.DisplayName,
                                             2, "pc(s)",
                                             Panel_DisplayWidth.ToString(),
                                             "Frame",
                                             @"|  |");
        }

        public void Insert_MotorizedInfo_MaterialList(DataTable tbl_explosion, int motorCount)
        {
            if (Panel_Type == "Awning Panel")
            {
                tbl_explosion.Rows.Add("30X25 Cover " + Panel_30x25CoverArtNo.ToString(),
                                       1, "pc(s)",
                                       Panel_ParentFrameModel.Frame_Width + 150,
                                       "Frame",
                                       @"");

                tbl_explosion.Rows.Add("Divider " + Panel_MotorizedDividerArtNo.ToString(),
                                       1, "pc(s)",
                                       Panel_ParentFrameModel.Frame_Width + 150,
                                       "Frame",
                                       @"");

                tbl_explosion.Rows.Add("Cover for motor " + Panel_CoverForMotorArtNo.ToString(),
                                       1, "pc(s)",
                                       Panel_ParentFrameModel.Frame_Width + 150,
                                       "Motorized Mechanism",
                                       @"");

            }
            else if (Panel_Type == "Casement Panel")
            {
                if (Panel_SashProfileArtNo != SashProfile_ArticleNo._395 &&
                    Panel_SashProfileArtNo != SashProfile_ArticleNo._373 &&
                    Panel_SashProfileArtNo != SashProfile_ArticleNo._None)
                {
                    tbl_explosion.Rows.Add("30X25 Cover " + Panel_30x25CoverArtNo.ToString(),
                                           1, "pc(s)",
                                           Panel_ParentFrameModel.Frame_Height + 150,
                                           "Frame",
                                           @"");

                    tbl_explosion.Rows.Add("Divider " + Panel_MotorizedDividerArtNo.ToString(),
                                           1, "pc(s)",
                                           Panel_ParentFrameModel.Frame_Height + 150,
                                           "Frame",
                                           @"");

                    tbl_explosion.Rows.Add("Cover for motor " + Panel_CoverForMotorArtNo.ToString(),
                                           1, "pc(s)",
                                           Panel_ParentFrameModel.Frame_Height + 150,
                                           "Motorized Mechanism",
                                           @"");
                }
            }

            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
                Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
            {
                tbl_explosion.Rows.Add("2D Hinge " + Panel_2dHingeArtNo.DisplayName,
                                       Panel_2DHingeQty, "pc(s)",
                                       "",
                                       "Sash & Frame",
                                       @"");
            }
            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
            {
                tbl_explosion.Rows.Add("Butt Hinge " + Panel_ButtHingeArtNo.DisplayName,
                                       Panel_ButtHingeQty, "pc(s)",
                                       "",
                                       "",
                                       @"");
            }

            tbl_explosion.Rows.Add("Motorized Mechanism " + Panel_MotorizedMechArtNo.DisplayName,
                                   motorCount, "pc(s)",
                                   "",
                                   "Sash",
                                   @"");

            tbl_explosion.Rows.Add("Push Button Switch " + Panel_PushButtonSwitchArtNo.ToString(),
                                   Panel_MotorizedMechSetQty, "pc(s)",
                                   "",
                                   "Concrete",
                                   @"");

            tbl_explosion.Rows.Add("False pole " + Panel_FalsePoleArtNo.ToString(),
                                   Panel_MotorizedMechSetQty * 2, "pc(s)",
                                   "",
                                   "Concrete",
                                   @"");

            tbl_explosion.Rows.Add("Supporting Frame " + Panel_SupportingFrameArtNo.ToString(),
                                   Panel_MotorizedMechSetQty, "pc(s)",
                                   "",
                                   "Concrete",
                                   @"");

            tbl_explosion.Rows.Add("Plate " + Panel_PlateArtNo.ToString(),
                                   Panel_MotorizedMechSetQty, "pc(s)",
                                   "",
                                   "Concrete",
                                   @"");
        }

        public void Insert_FrictionStay_MaterialList(DataTable tbl_explosion)
        {
            if (Panel_Type.Contains("Awning"))
            {
                tbl_explosion.Rows.Add("Friction Stay " + Panel_FrictionStayArtNo.DisplayName,
                                       1, "pair(s)",
                                       "",
                                       "Sash & Frame",
                                       @"");
            }
            else if (Panel_Type.Contains("Casement"))
            {
                tbl_explosion.Rows.Add("Friction Stay " + Panel_FSCasementArtNo.DisplayName,
                                       1, "pair(s)",
                                       "",
                                       "Sash & Frame",
                                       @"");

            }
        }

        public void Insert_SnapNKeep_MaterialList(DataTable tbl_explosion)
        {
            int SnapInKeepQty = (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door &&
                                 Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None) ? 1 : 2;

            tbl_explosion.Rows.Add("Snap-in Keep " + Panel_SnapInKeepArtNo.DisplayName,
                                   SnapInKeepQty, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");

        }

        public void Insert_FixedCam_MaterialList(DataTable tbl_explosion)
        {
            int FixedCamQty = (Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door &&
                                 Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 Panel_ParentFrameModel.Frame_BotFrameArtNo == BottomFrameTypes._None) ? 1 : 2;

            tbl_explosion.Rows.Add("Fixed Cam " + Panel_FixedCamArtNo.DisplayName,
                                   FixedCamQty, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        public void Insert_PlasticWedge_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Plastic Wedge " + Panel_PlasticWedge.DisplayName,
                                   Panel_PlasticWedgeQty, "pc (s)",
                                   "",
                                   "Frame",
                                   @"");

        }

        public void Insert_2dHinge_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("2D hinge " + Panel_2dHingeArtNo_nonMotorized.DisplayName,
                                   Panel_2DHingeQty_nonMotorized, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_3dHinge_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("3D hinge " + Panel_3dHingeArtNo.DisplayName,
                                   Panel_3dHingeQty, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_RestrictorStay_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Restrictor Stay " + Panel_RestrictorStayArtNo.DisplayName,
                                   Panel_RestrictorStayQty, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_NTCenterHinge_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("NT Center Hinge " + Panel_NTCenterHingeArticleNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_StayBearingK_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Stay Bearing, K " + Panel_StayBearingKArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_StayBearingPin_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Stay Bearing Pin " + Panel_StayBearingPinArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");

        }

        public void Insert_StayBearingCover_MaterialList(DataTable tbl_explosion, string basecol)
        {
            tbl_explosion.Rows.Add("Stay Bearing Cover, " + basecol + " " + Panel_StayBearingCoverArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_TopCornerHingeCover_MaterialList(DataTable tbl_explosion, string basecol)
        {
            tbl_explosion.Rows.Add("Top Corner Hinge Cover, " + basecol + " " + Panel_TopCornerHingeCoverArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");

        }

        public void Insert_TopCornerHinge_MaterialList(DataTable tbl_explosion)
        {
            if (Panel_ChkText == "L")
            {
                tbl_explosion.Rows.Add("Top Corner Hinge, Left " + Panel_TopCornerHingeArtNo.DisplayName,
                                       1, "pc(s)",
                                       "",
                                       "Sash & Frame",
                                       @"");
            }
            else if (Panel_ChkText == "R")
            {
                tbl_explosion.Rows.Add("Top Corner Hinge, Right " + Panel_TopCornerHingeArtNo.DisplayName,
                                       1, "pc(s)",
                                       "",
                                       "Sash & Frame",
                                       @"");
            }
        }

        public void Insert_TopCornerHingeSpacer_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Top Corner Hinge Spacer " + Panel_TopCornerHingeSpacerArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_CornerHingeK_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Corner Hinge, K " + Panel_CornerHingeKArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_CornerPivotRestK_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Corner Pivot Rest, K " + Panel_CornerPivotRestKArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_CornerHingeCoverK_MaterialList(DataTable tbl_explosion, string basecol)
        {
            tbl_explosion.Rows.Add("Corner Hinge Cover K, " + basecol + " " + Panel_CornerHingeCoverKArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_CoverForCornerPivotRestVertical_MaterialList(DataTable tbl_explosion, string basecol)
        {
            tbl_explosion.Rows.Add("Cover for corner pivot rest, vertical, " + basecol + " " + Panel_CoverForCornerPivotRestVerticalArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_CoverForCornerPivotRest_MaterialList(DataTable tbl_explosion, string basecol)
        {
            tbl_explosion.Rows.Add("Cover for corner pivot rest, " + basecol + " " + Panel_CoverForCornerPivotRestArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_AdjustableStriker_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Adjustable Striker " + Panel_AdjStrikerArtNo.DisplayName,
                                   Panel_AdjStrikerQty, "pc(s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        public void Insert_MiddleCloser_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Middle Closer " + Panel_MiddleCloserArtNo.DisplayName,
                                   Panel_MiddleCloserPairQty, "pair (s)",
                                   "",
                                   "Sash & Frame",
                                   @"");
        }

        public void Insert_Extension_MaterialList(DataTable tbl_explosion)
        {
            if (Panel_ExtensionTopArtNo != Extension_ArticleNo._None && Panel_ExtTopQty > 0)
            {
                tbl_explosion.Rows.Add("Extension(Top) " + Panel_ExtensionTopArtNo.DisplayName,
                                       Panel_ExtTopQty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");

            }
            if (Panel_ExtensionTop2ArtNo != Extension_ArticleNo._None && Panel_ExtTop2Qty > 0 && Panel_ExtTopChk == true)
            {
                tbl_explosion.Rows.Add("Extension_2(Top) " + Panel_ExtensionTop2ArtNo.DisplayName,
                                       Panel_ExtTop2Qty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");

            }
            if (Panel_ExtensionBotArtNo != Extension_ArticleNo._None && Panel_ExtBotQty > 0)
            {
                tbl_explosion.Rows.Add("Extension(Bot) " + Panel_ExtensionBotArtNo.DisplayName,
                                       Panel_ExtBotQty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");
            }
            if (Panel_ExtensionBot2ArtNo != Extension_ArticleNo._None && Panel_ExtBot2Qty > 0 && Panel_ExtBotChk == true)
            {
                tbl_explosion.Rows.Add("Extension_2(Bot) " + Panel_ExtensionBot2ArtNo.DisplayName,
                                       Panel_ExtBot2Qty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");

            }
            if (Panel_ExtensionLeftArtNo != Extension_ArticleNo._None && Panel_ExtLeftQty > 0)
            {
                tbl_explosion.Rows.Add("Extension(Left) " + Panel_ExtensionLeftArtNo.ToString(),
                                       Panel_ExtLeftQty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");
            }
            if (Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None && Panel_ExtLeft2Qty > 0 && Panel_ExtLeftChk == true)
            {
                tbl_explosion.Rows.Add("Extension_2(Left) " + Panel_ExtensionLeft2ArtNo.ToString(),
                                       Panel_ExtLeft2Qty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");
            }
            if (Panel_ExtensionRightArtNo != Extension_ArticleNo._None && Panel_ExtRightQty > 0)
            {
                tbl_explosion.Rows.Add("Extension(Right) " + Panel_ExtensionRightArtNo.ToString(),
                                       Panel_ExtRightQty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");
            }
            if (Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None && Panel_ExtRight2Qty > 0 && Panel_ExtRightChk == true)
            {
                tbl_explosion.Rows.Add("Extension_2(Right) " + Panel_ExtensionRight2ArtNo.ToString(),
                                       Panel_ExtRight2Qty, "pc (s)",
                                       "",
                                       "Sash",
                                       @"");
            }
        }
        //


        public void Insert_CornerDrive_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Corner Drive " + Panel_CornerDriveArtNo.DisplayName,
                                   2, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_RotoswingHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Rotoswing handle " + Panel_RotoswingArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_StrikerA_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Striker " + Panel_StrikerArtno_A.DisplayName,
                                   Panel_StrikerQty_A, "pc (s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        public void Insert_StrikerC_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Striker " + Panel_StrikerArtno_C.DisplayName,
                                   Panel_StrikerQty_C, "pc (s)",
                                   "",
                                   "Frame",
                                   @"");
        }

        public void Insert_RotaryHandle_LockingKit_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Rotary handle " + Panel_RotaryArtNo.DisplayName,
                                   1, "set (s)",
                                   "",
                                   "Sash",
                                   @"");

            tbl_explosion.Rows.Add("Locking Kit " + Panel_LockingKitArtNo.DisplayName,
                                   1, "set (s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_RioHandle_MaterialList(DataTable tbl_explosion)
        {
            if (Panel_RioArtNo != null)
            {
                tbl_explosion.Rows.Add("Rio handle " + Panel_RioArtNo.DisplayName,
                                                 1, "pc(s)",
                                                 "",
                                                 "Sash",
                                                 @"");
            }

            if (Panel_RioOptionsVisibility2 == true)
            {
                tbl_explosion.Rows.Add("Rio handle " + Panel_RioArtNo2.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash",
                                   @"");
            }
        }

        public void Insert_ProfileKnobCylinder_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Profile Knob Cylinder " + Panel_ProfileKnobCylinderArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_CylinderCover_MaterialList(DataTable tbl_explosion)
        {
            Foil_Color inside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;
            Foil_Color outside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_OutsideColor;

            if (inside_color != outside_color &&
                Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door) // for 2 diff foil color CD
            {
                if (Panel_HandleType == Handle_Type._MVD)
                {
                    //No Cylinder Cover Needed 
                }
                else if (Panel_HandleType == Handle_Type._Rio)
                {
                    tbl_explosion.Rows.Add("Cylinder Cover " + Panel_CylinderCoverArtNo.DisplayName,
                                                       1, "pc(s)",
                                                       "",
                                                       "Sash",
                                                       @"");

                    if (Panel_CylinderCoverArtNo2 != null)
                    {
                        tbl_explosion.Rows.Add("Cylinder Cover " + Panel_CylinderCoverArtNo2.DisplayName,
                                           1, "pc(s)",
                                           "",
                                           "Sash",
                                           @"");
                    }
                }
            }
            else
            {
                tbl_explosion.Rows.Add("Cylinder Cover " + Panel_CylinderCoverArtNo.DisplayName,
                                                        1, "pc(s)",
                                                        "",
                                                        "Sash",
                                                        @"");
            }
        }

        public void Insert_RotolineHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Rotoline handle " + Panel_RotolineArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        string MVDFoilColorInside, MVDFoilColorOutside;
        public void Insert_MVDHandle_MaterialList(DataTable tbl_explosion)
        {
            Foil_Color inside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;
            Foil_Color outside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_OutsideColor;


            if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                        inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                        inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                        inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                        inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
            {
                MVDFoilColorInside = "BL ";
            }
            else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._GoldenOak ||
                     inside_color == Foil_Color._Mahogany || inside_color == Foil_Color._Havana)
            {
                MVDFoilColorInside = "DB ";
            }



            if (outside_color == Foil_Color._FossilGray || outside_color == Foil_Color._BeechOak ||
                        outside_color == Foil_Color._DriftWood || outside_color == Foil_Color._Graphite ||
                        outside_color == Foil_Color._JetBlack || outside_color == Foil_Color._ChestnutOak ||
                        outside_color == Foil_Color._WashedOak || outside_color == Foil_Color._GreyOak ||
                        outside_color == Foil_Color._Cacao || outside_color == Foil_Color._CharcoalGray)
            {
                MVDFoilColorOutside = "BL ";
            }
            else if (outside_color == Foil_Color._Walnut || outside_color == Foil_Color._GoldenOak ||
                     outside_color == Foil_Color._Mahogany || outside_color == Foil_Color._Havana)
            {
                MVDFoilColorOutside = "DB ";
            }



            if (MVDFoilColorInside != MVDFoilColorOutside &&
                Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door) // for 2 diff foil color CD
            {
                tbl_explosion.Rows.Add("MVD handle " + MVDFoilColorInside + Panel_MVDArtNo.DisplayName,
                                  1, "set",
                                  "",
                                  "Sash",
                                  @"");

                tbl_explosion.Rows.Add("MVD handle " + MVDFoilColorOutside + Panel_MVDArtNo.DisplayName,
                                  1, "set",
                                  "",
                                  "Sash",
                                  @"");
            }
            else
            {
                tbl_explosion.Rows.Add("MVD handle " + Panel_MVDArtNo.DisplayName,
                                  1, "set",
                                  "",
                                  "Sash",
                                  @"");
            }

        }

        public void Insert_WeldableCornerJoint_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Weldable corner joint " + Panel_WeldableCArtNo.DisplayName,
                                   8, "pc(s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_Espagnolette_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Espagnolette " + Panel_EspagnoletteArtNo.ToString(),
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_GlazingBead_MaterialList(DataTable tbl_explosion, string location)
        {
            tbl_explosion.Rows.Add("Glazing Bead (P" + PanelGlass_ID + ") Width " + PanelGlazingBead_ArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_GlazingBeadWidth.ToString(),
                                   location,
                                   @"|  |");

            tbl_explosion.Rows.Add("Glazing Bead (P" + PanelGlass_ID + ") Height " + PanelGlazingBead_ArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_GlazingBeadHeight.ToString(),
                                   location,
                                   @"|  |");

        }

        public void Insert_GBSpacer_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("GB SPACER FOR 6mm GLASS " + Panel_GBSpacerArtNo.DisplayName,
                                   4, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_Spacer_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Spacer " + Panel_SpacerArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_GlazingAdapator_MaterialList(DataTable tbl_explosion, string location)
        {
            tbl_explosion.Rows.Add("Glazing Adaptor (P" + PanelGlass_ID + ") Width" + Panel_GlazingAdaptorArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_GlazingBeadWidth.ToString(),
                                   location,
                                   @"\  /");

            tbl_explosion.Rows.Add("Glazing Adaptor (P" + PanelGlass_ID + ") Height " + Panel_GlazingAdaptorArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_GlazingBeadHeight.ToString(),
                                   location,
                                   @"\  /");
        }
        string lvrGlassHt = "152";
        public void Insert_GlassInfo_MaterialList(DataTable tbl_explosion, string location, string glassFilm)
        {
            if (Panel_Type.Contains("Louver"))
            {
                if (Panel_LstLouverArtNo != null)
                {
                    int count152 = 0, count150 = 0;
                    foreach (string lvrCheckArtNo in Panel_LstLouverArtNo)
                    {
                        if (lvrCheckArtNo.Contains("152"))
                        {
                            count152++;
                        }
                        else if (lvrCheckArtNo.Contains("150"))
                        {
                            count150++;
                        }
                    }
                    if (count152 >= count150)
                    {
                        lvrGlassHt = "152";
                    }
                    else if (count152 < count150)
                    {
                        lvrGlassHt = "150";
                    }
                }

                tbl_explosion.Rows.Add("Glass (P" + PanelGlass_ID + ") Width - " + Panel_GlassThicknessDesc + " " + Panel_LouverBladeTypeOption + " Blades " + glassFilm,
                            Panel_LouverBladesCount.ToString(), "pc(s)",
                            Panel_GlassWidth.ToString(),
                            location,
                            "");

                tbl_explosion.Rows.Add("Glass (P" + PanelGlass_ID + ") Height - " + Panel_GlassThicknessDesc + " " + Panel_LouverBladeTypeOption + " Blades " + glassFilm,
                                       Panel_LouverBladesCount.ToString(), "pc(s)",
                                       lvrGlassHt,
                                       location,
                                       "");
            }
            else
            {
                tbl_explosion.Rows.Add("Glass (P" + PanelGlass_ID + ") Width - " + Panel_GlassThicknessDesc + " " + glassFilm,
                                            1, "pc(s)",
                                            Panel_GlassWidth.ToString(),
                                            location,
                                            "");

                tbl_explosion.Rows.Add("Glass (P" + PanelGlass_ID + ") Height - " + Panel_GlassThicknessDesc + " " + glassFilm,
                                       1, "pc(s)",
                                       Panel_GlassHeight.ToString(),
                                       location,
                                       "");
            }
        }

        public void Insert_GeorgianBar_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Georgian bar P" + PanelGlass_ID + " (Horizontal) " + Panel_GeorgianBarArtNo.DisplayName,
                                   Panel_GeorgianBar_HorizontalQty * 2, "pc(s)",
                                   Panel_GlassWidth + 5,
                                   "Glass",
                                   "");

            tbl_explosion.Rows.Add("Georgian bar P" + PanelGlass_ID + " (Vertical) " + Panel_GeorgianBarArtNo.DisplayName,
                                   Panel_GeorgianBar_VerticalQty * 2, "pc(s)",
                                   Panel_GlassHeight + 5,
                                   "Glass",
                                   "");
        }
        public void Insert_LatchAndDeadboltStriker_MaterialList(DataTable tbl_explosion)
        {
            string orient = "";
            if (Panel_ChkText == "L")
            {
                orient = "Left";
            }
            else if (Panel_ChkText == "R")
            {
                orient = "Right";
            }

            if (Panel_LatchDeadboltStrikerArtNo != null)
            {
                tbl_explosion.Rows.Add("Latch and deadbolt striker, " + orient + " " + Panel_LatchDeadboltStrikerArtNo.DisplayName,
                                       1, "pc(s)",
                                       "",
                                       "Frame",
                                       @"");
            }

        }


        public void Insert_GuideTrackProfile_MaterialList(DataTable tbl_explosion)
        {
            int roundoff = (Panel_DisplayWidthDecimal >= 5) ? 1 : 0;

            tbl_explosion.Rows.Add("Guide Track Profile " + Panel_GuideTrackProfileArtNo.DisplayName,
                                   Panel_AluminumTrackQty, "pc(s)",
                                   (Panel_DisplayWidth * 2) + roundoff,//Panel_ParentFrameModel.Frame_Width,
                                   "Frame",
                                   @"|  |");
        }

        public void Insert_AluminumTrack_MaterialList(DataTable tbl_explosion)
        {
            int roundoff = (Panel_DisplayWidthDecimal >= 5) ? 1 : 0;

            tbl_explosion.Rows.Add("Aluminum Track " + Panel_AluminumTrackArtNo.DisplayName,
                                   Panel_AluminumTrackQty, "pc(s)",
                                   (Panel_DisplayWidth * 2) + roundoff,//Panel_ParentFrameModel.Frame_Width,
                                   "Frame",
                                   @"|  |");
        }

        public void Insert_WeatherBar_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Weather Bar " + Panel_WeatherBarArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_ParentFrameModel.Frame_Width,
                                   "Frame",
                                   @"|  |");
        }

        public void Insert_WaterSeepage_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Water Seepage " + Panel_WaterSeepageArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_ParentFrameModel.Frame_Width / 2,
                                   "Frame",
                                   @"|  |");
        }

        public void Insert_Interlock_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Interlock " + Panel_InterlockArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_SashHeight - 5,
                                   "Sash",
                                   @"|  |");
        }

        public void Insert_ExternsionForInterlock_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Extension for Interlock " + Panel_ExtensionForInterlockArtNo.DisplayName,
                                   2, "pc(s)",
                                   Panel_SashHeight - 30,
                                   "Sash",
                                   @"|  |");
        }

        public void Insert_WeatherBarFastener_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Weather Bar Fastener " + Panel_WeatherBarFastenerArtNo.DisplayName,
                                   (int)(Math.Ceiling((decimal)(Panel_ParentFrameModel.Frame_Width) / 300)), "pc(s)",
                                   "",
                                   "Weather Bar",
                                   "");
        }

        public void Insert_BrushSeal_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Brush Seal " + Panel_BrushSealArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_SashHeight - 5,
                                   "Weather Bar",
                                   "");
        }

        public void Insert_Rollers_MaterialList(DataTable tbl_explosion)
        {
            string Roller = "";
            if (Panel_RollersTypes == RollersTypes._GURoller)
            {
                Roller = "GU Roller ";
            }
            else if (Panel_RollersTypes == RollersTypes._HDRoller)
            {
                Roller = "HD Roller ";
            }
            else if (Panel_RollersTypes == RollersTypes._TandemRoller)
            {
                Roller = "Tandem Roller ";
            }

            tbl_explosion.Rows.Add(Roller + Panel_RollersTypes.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_GlazingRebateBlock_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Glazing Rebate Block " + Panel_GlazingRebateBlockArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_AntiLiftDevice_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Anti Lift Device",
                                   2, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_StrikerForSliding_MaterialList(DataTable tbl_explosion)
        {
            string orient = "";
            if (Panel_ChkText == "L")
            {
                orient = "Left";
                Panel_StrikerArtno_Sliding = Striker_ArticleNo._629555;
            }
            else if (Panel_ChkText == "R")
            {
                orient = "Right";
                Panel_StrikerArtno_Sliding = Striker_ArticleNo._629554;
            }

            tbl_explosion.Rows.Add("Striker " + orient + " " + Panel_StrikerArtno_Sliding.DisplayName,
                                   Panel_StrikerArtno_SlidingQty, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_SealingBlock_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Sealing Block " + Panel_SealingBlockArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_DHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("D handle " + Panel_DHandleOutsideArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");

            tbl_explosion.Rows.Add("D handle " + Panel_DHandleInsideArtNo.DisplayName,
                                  1, "pc (s)",
                                  "",
                                  "Sash",
                                  @"");
        }

        public void Insert_DHandleIOLocking_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("D handle In & Out Locking " + Panel_DHandleIOLockingOutsideArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");

            tbl_explosion.Rows.Add("D handle In & Out Locking " + Panel_DHandleIOLockingInsideArtNo.DisplayName,
                                  1, "pc (s)",
                                  "",
                                  "Sash",
                                  @"");
        }

        public void Insert_DummyDHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Dummy D handle " + Panel_DummyDHandleOutsideArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");

            tbl_explosion.Rows.Add("Dummy D handle " + Panel_DummyDHandleInsideArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_PopUpHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Pop-up handle " + _panel_PopUpHandleArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");
        }

        public void Insert_RotoswingForSlidingHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Rotoswing sliding door handle " + Panel_RotoswingForSlidingHandleArtNo.DisplayName,
                                   1, "pc (s)",
                                   "",
                                   "Sash",
                                   @"");
        }


        public void Insert_ScrewSetForDhandlesVariant_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Screw Set " + Panel_ScrewSetsArtNo.DisplayName,
                         1, "Set",
                         "",
                         "Handle",
                         @"");
        }

        public void Insert_SpacerFixedSash_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("SPACER FOR FIXED " + Panel_GBSpacerArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_AluminumPullHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Aluminum Pull Handle " + Panel_AluminumPullHandleArtNo.DisplayName,
                                   Panel_OverLappingPanelQty, "pc(s)",
                                   (Panel_SashHeight - 5).ToString(),
                                   "Ancillary Profile",
                                   "");
        }

        public void Insert_SealingElement_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Sealing Element " + Panel_SealingElement_ArticleNo.DisplayName,
                                   4, "pc(s)",
                                   "",
                                   "Sash",
                                   "");
        }

        public void Insert_GS100TEMHMCOVERENDCAP3p5m_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("GS-100, T/EM,T/HM COVER + END CAP 3.5m " + Panel_GS100_T_EM_T_HMCOVER_ArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }


        public void Insert_TrackRail6m_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Track Rail, 6m " + Panel_TrackRailArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_MicrocellOneSafetySensor_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Microcell One Safety Sensor " + Panel_MicrocellOneSafetySensorArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_AutoDoorBracketForGS100Upvc_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Auto Door Bracket For GS-100 Upvc " + Panel_AutodoorBracketForGS100UPVCArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_GS100EndCapScrewMp5andLSupport_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("GS-100 End Cap Screw M.5 & L Support " + Panel_GS100EndCapScrewM5AndLSupportArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_EuroLeadButtonWhite_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Euro Lead Button, White " + Panel_EuroLeadExitButtonArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_ToothbeltEMCM62m_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Toothbelt EM/CM/62m " + Panel_TOOTHBELT_EM_CMArtNo.DisplayName,
                                   1, "pc(s)",
                                   "7000",
                                   "",
                                   "");
        }

        public void Insert_GuBeaZenMicrowaveSensorSilver_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("GU BEA ZEN Microwave Sensor, Silver " + Panel_GuBeaZenMicrowaveSensorArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_SlidingDoorKitGS100s1_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Sliding Door Kit GS-100/1 " + Panel_SlidingDoorKitGs100_1ArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_GS100CoverKit_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("GS-100 Cover Kit " + Panel_GS100CoverKitArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "",
                                   "");
        }

        public void Insert_PlantOnWeatherStripHead_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Plant on Weather Strip Head " + Panel_PlantOnWeatherStripHeadArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_PlantOnWeatherStripHeadWidth,
                                   "Frame",
                                   "");
        }

        public void Insert_PlantOnWeatherStripSeal_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Plant on Weather Strip Seal " + Panel_PlantOnWeatherStripSealArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_PlantOnWeatherStripSealWidth,
                                   "Frame",
                                   "");
        }

        public void Insert_LouvreFrameWeatherStripHead_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Louvre Frame Weather Strip Head " + Panel_LouverFrameWeatherStripHeadArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_LouverFrameWeatherStripHeadWidth,
                                   "Frame",
                                   "");
        }

        public void Insert_LouvreFrameBottomWeatherStrip_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Louvre Frame Bottom Weather Strip " + Panel_LouverFrameBottomWeatherStripArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_LouverFrameBottomWeatherStripWidth,
                                   "Frame",
                                   "");
        }

        public void Insert_RubberSeal_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Rubber Seal " + Panel_RubberSealArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_RubberSealWidth,
                                   "Frame",
                                   "");
        }

        public void Insert_CasementSeal_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Casement Seal " + Panel_CasementSealArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_CasementSealWidth,
                                   "Frame",
                                   "");
        }

        public void Insert_SealForHandle_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Seal for Handle " + Panel_SealForHandleArtNo.DisplayName,
                                   1, "pc(s)",
                                   Panel_SealForHandleQty,
                                   "Frame",
                                   "");
        }

        public void Insert_LouvreGallerySet_MaterialList(DataTable tbl_explosion)
        {
            if (Panel_LstLouverArtNo != null)
            {
                foreach (string GallerySetArt in Panel_LstLouverArtNo)
                {
                    tbl_explosion.Rows.Add("Louvre Gallery Set " + GallerySetArt,
                                           1, "pc(s)",
                                           0,//Panel_LouvreGallerySetHeight, 01/09/23 alisin ang value as per Maam D
                                           "Frame",
                                           "");
                }
            }
        }


        public int Add_SashPerimeter_screws4fab()
        {
            return (Panel_SashWidth * 2) + (Panel_SashHeight * 2);
        }

        public int Add_StrikerAC_screws4fab()
        {
            int strikerAC_screws = 0;

            if (Panel_Type.Contains("Awning"))
            {
                strikerAC_screws += Panel_StrikerQty_A;

                if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957 ||
                    Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957 ||
                    Panel_ExtensionRightArtNo == Extension_ArticleNo._639957 ||
                    Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                {
                    strikerAC_screws += Panel_StrikerQty_C;
                }
            }
            else if (Panel_Type.Contains("Casement"))
            {
                if (Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                {
                    strikerAC_screws += Panel_StrikerQty_C;

                    if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                    {
                        strikerAC_screws += Panel_StrikerQty_A;
                    }
                }
            }

            return strikerAC_screws;
        }

        public int Add_Espagnolette_screws4fab()
        {
            int espag_screws = 0;

            if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
            {
                espag_screws += 8;
            }
            else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._630963)
            {
                espag_screws += 2;
            }
            else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807)
            {
                espag_screws += 4;
            }
            else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A00006 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A01006 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A02206 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A03206 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A04206 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A05206 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._N110A06206)
            {
                espag_screws += 6;
            }
            else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642105 ||
                     Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._642089)
            {
                espag_screws += 12;
            }

            return espag_screws;
        }

        public int Add_Extension_screws4fab()
        {
            int ext_screws = 0;

            if (Panel_ExtensionTopArtNo != Extension_ArticleNo._None && Panel_ExtTopQty > 0)
            {
                if (Panel_ExtensionTopArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtTopQty);
                }
                else if (Panel_ExtensionTopArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtTopQty);
                }
                else if (Panel_ExtensionTopArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtTopQty);
                }
                else if (Panel_ExtensionTopArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionTopArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtTopQty);
                }
            }
            if (Panel_ExtensionTop2ArtNo != Extension_ArticleNo._None && Panel_ExtTop2Qty > 0 && Panel_ExtTopChk == true)
            {
                if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtTop2Qty);
                }
                else if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtTop2Qty);
                }
                else if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtTop2Qty);
                }
                else if (Panel_ExtensionTop2ArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionTop2ArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtTop2Qty);
                }
            }
            if (Panel_ExtensionBotArtNo != Extension_ArticleNo._None && Panel_ExtBotQty > 0)
            {
                if (Panel_ExtensionBotArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtBotQty);
                }
                else if (Panel_ExtensionBotArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtBotQty);
                }
                else if (Panel_ExtensionBotArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtBotQty);
                }
                else if (Panel_ExtensionBotArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionBotArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtBotQty);
                }
            }
            if (Panel_ExtensionBot2ArtNo != Extension_ArticleNo._None && Panel_ExtBot2Qty > 0 && Panel_ExtBotChk == true)
            {
                if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtBot2Qty);
                }
                else if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtBot2Qty);
                }
                else if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtBot2Qty);
                }
                else if (Panel_ExtensionBot2ArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionBot2ArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtBot2Qty);
                }
            }
            if (Panel_ExtensionLeftArtNo != Extension_ArticleNo._None && Panel_ExtLeftQty > 0)
            {
                if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtLeftQty);
                }
                else if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtLeftQty);
                }
                else if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtLeftQty);
                }
                else if (Panel_ExtensionLeftArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionLeftArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtLeftQty);
                }
            }
            if (Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None && Panel_ExtLeft2Qty > 0 && Panel_ExtLeftChk == true)
            {
                if (Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtLeft2Qty);
                }
                else if (Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtLeft2Qty);
                }
                else if (Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtLeft2Qty);
                }
                else if (Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionLeft2ArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtLeft2Qty);
                }
            }
            if (Panel_ExtensionRightArtNo != Extension_ArticleNo._None && Panel_ExtRightQty > 0)
            {
                if (Panel_ExtensionRightArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtRightQty);
                }
                else if (Panel_ExtensionRightArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtRightQty);
                }
                else if (Panel_ExtensionRightArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtRightQty);
                }
                else if (Panel_ExtensionRightArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionRightArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtRightQty);
                }
            }
            if (Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None && Panel_ExtRight2Qty > 0 && Panel_ExtRightChk == true)
            {
                if (Panel_ExtensionRight2ArtNo == Extension_ArticleNo._612978)
                {
                    ext_screws += (3 * Panel_ExtRight2Qty);
                }
                else if (Panel_ExtensionRight2ArtNo == Extension_ArticleNo._639957)
                {
                    ext_screws += (5 * Panel_ExtRight2Qty);
                }
                else if (Panel_ExtensionRight2ArtNo == Extension_ArticleNo._567639)
                {
                    ext_screws += (2 * Panel_ExtRight2Qty);
                }
                else if (Panel_ExtensionRight2ArtNo == Extension_ArticleNo._630956 ||
                         Panel_ExtensionRight2ArtNo == Extension_ArticleNo._641798)
                {
                    ext_screws += (4 * Panel_ExtRight2Qty);
                }
            }

            return ext_screws;
        }

        public int Add_FSCasement_screws4fab()
        {
            int fsCW_screws = 0;

            if (Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._10HD)
            {
                fsCW_screws += 3;
            }
            else if (Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12FS ||
                     Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._12HD)
            {
                fsCW_screws += 4;
            }
            else if (Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._16HD)
            {
                fsCW_screws += 5;
            }
            else if (Panel_FSCasementArtNo == FrictionStayCasement_ArticleNo._20HD)
            {
                fsCW_screws += 6;
            }

            return fsCW_screws;
        }

        public int Add_FGAwning_screws4fab()
        {
            int fsAW_screws = 0;

            if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
            {
                fsAW_screws += 6; //for Storm26

                fsAW_screws += (2 * 2); //snapNkeep

                fsAW_screws += (2 * 2); //fixed cam
            }
            else if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm8)
            {
                fsAW_screws += 3;
            }
            else if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._10HD ||
                     Panel_FrictionStayArtNo == FrictionStay_ArticleNo._12HD)
            {
                fsAW_screws += 4;
            }
            else if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._16HD)
            {
                fsAW_screws += 5;
            }
            else if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm22)
            {
                fsAW_screws += 6;
            }

            return fsAW_screws;
        }

        public int Add_Hinges_screws4fab()
        {
            int hinge_screws = 0;

            if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
                Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
            {
                hinge_screws += (Panel_2DHingeQty * 3); //qty * 3
            }
            else if (Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
            {
                hinge_screws += (Panel_ButtHingeQty * 3); //qty * 3
            }

            return hinge_screws;
        }



        public int Add_RestrictorStay_screws4fab()
        {
            int restrictorStay_screws = 0;

            restrictorStay_screws += (6 * Panel_RestrictorStayQty);

            return restrictorStay_screws;
        }




        public int Add_MotorizedMech_screws4Inst()
        {
            int motor_screws = 0;

            if (Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._409990E)
            {
                motor_screws += (20 * Panel_MotorizedMechQty);
            }
            else if (Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41555B ||
                     Panel_MotorizedMechArtNo == MotorizedMech_ArticleNo._41556C)
            {
                motor_screws += (10 * Panel_MotorizedMechQty);
            }

            return motor_screws;
        }
        #endregion

        #endregion

        public PanelModel(int panelID,
                          string panelName,
                          int panelWd,
                          int panelHt,
                          DockStyle panelDock,
                          string panelType,
                          bool panelOrient,
                          Control panelParent,
                          UserControl panelFrameGroup,
                          bool panelVisibility,
                          UserControl panelFramePropertiesGroup,
                          UserControl panelMultiPanelGroup,
                          int panelIndexInsideMPanel,
                          float panelImageRendererZoom,
                          float panelZoom,
                          IFrameModel panelFrameModelParent,
                          IMultiPanelModel panelMultiPanelParent,
                          GlazingBead_ArticleNo panelGlazingBeadArtNo,
                          int panelDisplayWidth,
                          int panelDisplayWidthDecimal,
                          int panelDisplayHeight,
                          int panelDisplayHeightDecimal,
                          int panelGlassID,
                          GlassFilm_Types panelGlassFilm,
                          SashProfile_ArticleNo panelSash,
                          SashReinf_ArticleNo panelSashReinf,
                          GlassType panelGlassType,
                          Espagnolette_ArticleNo panelEspagnoletteArtNo,
                          Striker_ArticleNo panelStrikerArtno,
                          MiddleCloser_ArticleNo panelMiddleCloserArtno,
                          LockingKit_ArticleNo panelLockingKitArtno,
                          MotorizedMech_ArticleNo panelMotorizedMechArtNo,
                          Handle_Type panelHandleType,
                          Extension_ArticleNo paneltopExtArtNo,
                          Extension_ArticleNo paneltop2ExtArtNo,
                          Extension_ArticleNo panelbotExtArtNo,
                          Extension_ArticleNo panelbot2ExtArtNo,
                          Extension_ArticleNo panelleftExtArtNo,
                          Extension_ArticleNo panelleft2ExtArtNo,
                          Extension_ArticleNo panelrightExtArtNo,
                          Extension_ArticleNo panelright2ExtArtNo,
                          bool panelExtTopChk,
                          bool panelExtBotChk,
                          bool panelExtLeftChk,
                          bool panelExtRightChk,
                          int panelExtTopQty,
                          int panelExtBotQty,
                          int panelExtLeftQty,
                          int panelExtRightQty,
                          int panelExtTop2Qty,
                          int panelExtBot2Qty,
                          int panelExtLeft2Qty,
                          int panelExtRight2Qty,
                          Rotoswing_HandleArtNo panelRotoswingArtNo,
                          GeorgianBar_ArticleNo panelGeorgianBarArtNo,
                          OverlapSash panelOverlapSash,
                          int panelGeorgianBarVerticalQty,
                          int panelGeorgianBarHorizontalQty,
                          bool panelGeorgianBarOptionVisibility,
                          HingeOption panelHingeOptions,
                          bool panelSlidingTypeVisibility,
                          SlidingTypes panelSlidingTypes,
                          string glasstype_insu_lumi,
                          decimal glasspricepersqrmeter
                          )
        {
            Panel_ID = panelID;
            Panel_fileLoad = false;
            Panel_Name = panelName;
            Panel_ParentMultiPanelModel = panelMultiPanelParent;
            PanelImageRenderer_Zoom = panelImageRendererZoom;
            Panel_Zoom = panelZoom;
            Panel_ParentFrameModel = panelFrameModelParent;
            Panel_Width = panelWd;
            Panel_Height = panelHt;
            Panel_OriginalWidth = Panel_Width;
            Panel_OriginalHeight = Panel_Height;
            Panel_Dock = panelDock;
            Panel_Type = panelType;
            Panel_Orient = panelOrient;
            Panel_Parent = panelParent;
            Panel_FrameGroup = panelFrameGroup;
            Panel_Visibility = panelVisibility;
            Panel_FramePropertiesGroup = panelFramePropertiesGroup;
            Panel_MultiPanelGroup = panelMultiPanelGroup;
            Panel_Index_Inside_MPanel = panelIndexInsideMPanel;
            PanelGlazingBead_ArtNo = panelGlazingBeadArtNo;
            Panel_DisplayWidth = panelDisplayWidth;
            Panel_DisplayWidthDecimal = panelDisplayWidthDecimal;
            Panel_DisplayHeight = panelDisplayHeight;
            Panel_DisplayHeightDecimal = panelDisplayHeightDecimal;
            PanelGlass_ID = panelGlassID;
            Panel_OriginalDisplayWidth = panelDisplayWidth;
            Panel_OriginalDisplayWidthDecimal = panelDisplayWidthDecimal;
            Panel_OriginalDisplayHeight = panelDisplayHeight;
            Panel_OriginalDisplayHeightDecimal = panelDisplayHeightDecimal;
            Panel_GlassFilm = panelGlassFilm;
            Panel_SashProfileArtNo = panelSash;
            Panel_SashReinfArtNo = panelSashReinf;
            Panel_GlassType = panelGlassType;
            Panel_EspagnoletteArtNo = panelEspagnoletteArtNo;
            Panel_StrikerArtno_A = panelStrikerArtno;
            Panel_MiddleCloserArtNo = panelMiddleCloserArtno;
            Panel_LockingKitArtNo = panelLockingKitArtno;
            Panel_MotorizedMechArtNo = panelMotorizedMechArtNo;
            Panel_HandleType = panelHandleType;
            Panel_ExtensionTopArtNo = paneltopExtArtNo;
            Panel_ExtensionTop2ArtNo = paneltop2ExtArtNo;
            Panel_ExtensionBotArtNo = panelbotExtArtNo;
            Panel_ExtensionBot2ArtNo = panelbot2ExtArtNo;
            Panel_ExtensionLeftArtNo = panelleftExtArtNo;
            Panel_ExtensionLeft2ArtNo = panelleft2ExtArtNo;
            Panel_ExtensionRightArtNo = panelrightExtArtNo;
            Panel_ExtensionRight2ArtNo = panelright2ExtArtNo;
            Panel_ExtTopChk = panelExtTopChk;
            Panel_ExtBotChk = panelExtBotChk;
            Panel_ExtLeftChk = panelExtRightChk;
            Panel_ExtRightChk = panelExtLeftChk;
            Panel_ExtTopQty = panelExtTopQty;
            Panel_ExtTop2Qty = panelExtTop2Qty;
            Panel_ExtBotQty = panelExtBotQty;
            Panel_ExtBot2Qty = panelExtBot2Qty;
            Panel_ExtLeftQty = panelExtLeftQty;
            Panel_ExtLeft2Qty = panelExtLeft2Qty;
            Panel_ExtRightQty = panelExtRightQty;
            Panel_ExtRight2Qty = panelExtRight2Qty;
            Panel_RotoswingArtNo = panelRotoswingArtNo;
            Panel_GeorgianBarArtNo = panelGeorgianBarArtNo;
            Panel_Overlap_Sash = panelOverlapSash;
            Panel_GeorgianBar_VerticalQty = panelGeorgianBarVerticalQty;
            Panel_GeorgianBar_HorizontalQty = panelGeorgianBarHorizontalQty;
            Panel_GeorgianBarOptionVisibility = panelGeorgianBarOptionVisibility;
            Panel_HingeOptions = panelHingeOptions;
            Panel_SlidingTypeVisibility = panelSlidingTypeVisibility;
            Panel_SlidingTypes = panelSlidingTypes;
            Panel_BackColor = Color.DarkGray;
            Panel_CmenuDeleteVisibility = true;
            Panel_OrientVisibility = true;
            Panel_PropertyHeight = constants.panel_propertyHeight_default;
            Panel_HandleOptionsHeight = constants.panel_property_handleOptionsHeight;
            Panel_RotoswingOptionsHeight = constants.panel_property_rotoswingOptionsheight_default;
            Panel_ExtensionPropertyHeight = constants.panel_property_extensionOptionsheight;
            Panel_GlassPropertyHeight = constants.panel_property_glassOptionsHeight;
            Panel_HingeOptionsPropertyHeight = constants.panel_property_HingeOptionsheight;
            Panel_GlassType_Insu_Lami = glasstype_insu_lumi;
            Panel_GlassPricePerSqrMeter = glasspricepersqrmeter;

        }
    }
}
