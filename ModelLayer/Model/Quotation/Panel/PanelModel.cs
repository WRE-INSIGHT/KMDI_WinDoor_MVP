using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Variables;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;

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
                PanelImageRenderer_Width = Convert.ToInt32(value * PanelImageRenderer_Zoom);
                Panel_WidthToBind = (int)(value * Panel_Zoom);
                //NotifyPropertyChanged();
            }
        }

        public int Panel_OriginalWidth { get; set; }

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
                PanelImageRenderer_Height = Convert.ToInt32(value * PanelImageRenderer_Zoom);
                Panel_HeightToBind = (int)(value * Panel_Zoom);
                //NotifyPropertyChanged();
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

        private string _panelType;
        public string Panel_Type
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
                    if (value == true)
                    {
                        _panelChkText = "L";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "R";
                    }
                }
                _panelOrient = value;
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
                PanelImageRenderer_Width = Convert.ToInt32(Panel_Width * value);
                PanelImageRenderer_Height = Convert.ToInt32(Panel_Height * value);

                PanelImageRenderer_Margin = new Padding((int)(Panel_Margin.Left * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Top * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Right * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Bottom * PanelImageRenderer_Zoom));
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
                Panel_MarginToBind = new Padding((int)(Panel_Margin.Left * Panel_Zoom),
                                                 (int)(Panel_Margin.Top * Panel_Zoom),
                                                 (int)(Panel_Margin.Right * Panel_Zoom),
                                                 (int)(Panel_Margin.Bottom * Panel_Zoom));

                PanelImageRenderer_Margin = new Padding((int)(Panel_Margin.Left * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Top * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Right * PanelImageRenderer_Zoom),
                                                        (int)(Panel_Margin.Bottom * PanelImageRenderer_Zoom));
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

                Panel_WidthToBind = (int)(Panel_Width * value);
                Panel_HeightToBind = (int)(Panel_Height * value);
                Panel_MarginToBind = new Padding((int)(Panel_Margin.Left * Panel_Zoom),
                                                 (int)(Panel_Margin.Top * Panel_Zoom),
                                                 (int)(Panel_Margin.Right * Panel_Zoom),
                                                 (int)(Panel_Margin.Bottom * Panel_Zoom));
            }
        }

        public IFrameModel Panel_ParentFrameModel { get; set; }
        public IMultiPanelModel Panel_ParentMultiPanelModel { get; set; }

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
                if (value == 6.0f ||
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
        public int Panel_GlazingBeadHeight { get; set; }
        public int Panel_OriginalGlassWidth { get; set; }
        public int Panel_GlassWidth { get; set; }
        public int Panel_GlassHeight { get; set; }
        public int Panel_OriginalGlassHeight { get; set; }
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

        public int Panel_SashWidth { get; set; }

        public int Panel_SashHeight { get; set; }
        public int Panel_OriginalSashWidth { get; set; }
        public int Panel_OriginalSashHeight { get; set; }

        public int Panel_SashReinfWidth { get; set; }
        public int Panel_SashReinfHeight { get; set; }

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
                if (value == FrictionStay_ArticleNo._A2121C1261 ||
                    value == FrictionStay_ArticleNo._A212C16161 ||
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

        public FrictionStayCasement_ArticleNo Panel_FSCasementArtNo { get; set; }

        public SnapInKeep_ArticleNo Panel_SnapInKeepArtNo { get; set; }
        public FixedCam_ArticleNo Panel_FixedCamArtNo { get; set; }
        public _30x25Cover_ArticleNo Panel_30x25CoverArtNo { get; set; }
        public MotorizedDivider_ArticleNo Panel_MotorizedDividerArtNo { get; set; }
        public CoverForMotor_ArticleNo Panel_CoverForMotorArtNo { get; set; }
        public _2DHinge_ArticleNo Panel_2dHingeArtNo { get; set; }
        public int Panel_2DHingeQty { get; set; }
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

        public ProfileKnobCylinder_ArtNo Panel_ProfileKnobCylinderArtNo { get; set; }
        public Cylinder_CoverArtNo Panel_CylinderCoverArtNo { get; set; }

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

        public bool Panel_CornerDriveOptionsVisibility { get; set; }
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
        public int Panel_MiddleCloserPairQty { get; set; }

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
                    if (Panel_ParentMultiPanelModel != null)
                    {
                        Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7502;
                    }
                    else if (Panel_ParentMultiPanelModel == null)
                    {
                        Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7507;
                    }

                    if (Panel_DisplayWidth >= 1500)
                    {
                        Panel_GlassFilm = GlassFilm_Types._4milUpera;
                    }
                }
                else if (_panelMotorizedOptionVisibility == false)
                {
                    Panel_ParentFrameModel.Frame_ArtNo = FrameProfile_ArticleNo._7502;
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

     

        public void AdjustPropertyPanelHeight(string mode)
        {
            if (mode == "addChkMotorized")
            {
                Panel_PropertyHeight += constants.panel_property_motorizedChkOptionsheight;
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
                Panel_PropertyHeight += constants.panel_property_glassOptionsHeight;
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

        public void SetPanelExplosionValues_Panel(bool parentIsFrame)
        {
            Panel_StrikerQty_A = 0;
            Panel_StrikerQty_C = 0;

            Base_Color base_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor;
            Foil_Color inside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;

            if (Panel_SashPropertyVisibility == true)
            {
                if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                {
                    Panel_SashWidth = Panel_DisplayWidth - (26 * 2) + 5;
                    Panel_SashHeight = Panel_DisplayHeight - (26 * 2) + 5;
                }
                else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                {
                    Panel_SashWidth = Panel_DisplayWidth - (40 * 2) + 5;
                    Panel_SashHeight = Panel_DisplayHeight - (40 * 2) + 5;
                }

                Panel_SashReinfWidth = Panel_SashWidth - 5 - (55 * 2) - 10;
                Panel_SashReinfHeight = Panel_SashHeight - 5 - (55 * 2) - 10;

                Panel_GlazingBeadWidth = Panel_SashWidth;
                Panel_GlazingBeadHeight = Panel_SashHeight;

                Panel_GlassWidth = Panel_SashWidth - 5 - (55 * 2) - 6;
                Panel_GlassHeight = Panel_SashHeight - 5 - (55 * 2) - 6;

                Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;

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
                }

                if (base_color == Base_Color._DarkBrown)
                {
                    if (Panel_DisplayHeight < 1551)
                    {
                        Panel_MiddleCloserPairQty = 1;
                    }
                    else if (Panel_DisplayHeight > 1551 && Panel_DisplayHeight < 1999)
                    {
                        Panel_MiddleCloserPairQty = 2;
                    }
                    else if (Panel_DisplayHeight > 1999)
                    {
                        Panel_MiddleCloserPairQty = 3;
                    }
                }
                else if (base_color == Base_Color._White ||
                         base_color == Base_Color._Ivory)
                {
                    if (Panel_SashHeight < 1551)
                    {
                        Panel_MiddleCloserPairQty = 1;
                    }
                    else if (Panel_SashHeight > 1551 && Panel_SashHeight < 1999)
                    {
                        Panel_MiddleCloserPairQty = 2;
                    }
                    else if (Panel_SashHeight > 1999)
                    {
                        Panel_MiddleCloserPairQty = 3;
                    }
                }

                Panel_StrikerArtno_A = Striker_ArticleNo._M89ANTA;
                Panel_StrikerArtno_C = Striker_ArticleNo._M89ANTC;

                if (Panel_DisplayWidth > 0 && Panel_DisplayWidth <= 1499)
                {
                    Panel_MotorizedMechQty = 1;
                }
                else if (Panel_DisplayWidth >= 1500)
                {
                    Panel_MotorizedMechQty = 2;
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
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_205 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_206)
                    {
                        Panel_StrikerQty_A += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_207)
                    {
                        Panel_StrikerQty_A += 2;
                    }

                    if (Panel_ExtensionLeftArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionRightArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
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
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_205 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_206)
                    {
                        Panel_StrikerQty_C += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_207)
                    {
                        Panel_StrikerQty_C += 2;
                    }

                    if (Panel_ExtensionTopArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionTop2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionBotArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionBot2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }
                }

                if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                {
                    Panel_StrikerQty_A += 2;
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
                        fs_dimension_based = FrictionStay_ArticleNo._477254;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 1000) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._A2121C1261;
                    }
                    else if (((sashWD_floor >= 1100 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._A212C16161;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1100) &&
                             (sashHt_floor >= 800 && sashHt_floor <= 900)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._A212C16161;
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
                        else if (total_weight == 45)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._477254;
                        }
                        else if (total_weight >= 46 && total_weight <= 50)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._A2121C1261;
                        }
                        else if (total_weight >= 51 && total_weight <= 55)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._A212C16161;
                        }
                        else if (total_weight >= 56 && total_weight <= 75)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._Storm22;
                        }
                        else if (total_weight >= 76)
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
                }
                else if (Panel_Type.Contains("Casement"))
                {
                    FrictionStayCasement_ArticleNo fs_dimension_based = FrictionStayCasement_ArticleNo._None;
                    FrictionStayCasement_ArticleNo fs_weight_based = FrictionStayCasement_ArticleNo._None;

                    if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                        (Panel_SashWidth >= 350 && Panel_SashWidth <= 399))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._485770;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 400 && sashHt_floor <= 1200))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A235B12161;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 1300 && sashHt_floor <= 1500))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C12161;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 500) &&
                             (sashHt_floor >= 1600 && sashHt_floor <= 2100))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C12161;
                    }
                    else if ((sashHt_floor >= 1600 && sashHt_floor <= 2200) &&
                             (Panel_SashWidth >= 600 && Panel_SashWidth <= 699))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C16161;
                    }
                    else if (Panel_SashWidth >= 700 && Panel_SashWidth <= 799)
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C16161;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 800 && Panel_SashWidth <= 899))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C16161;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 900 && Panel_SashWidth <= 999))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C20161;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 1500) &&
                             (Panel_SashWidth >= 1000 && Panel_SashWidth <= 1199))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C20161;
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
                            fs_weight_based = FrictionStayCasement_ArticleNo._A235B12161;
                        }
                        else if (total_weight >= 19 && total_weight <= 35)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._485770;
                        }
                        else if (total_weight >= 36 && total_weight <= 40)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._A212C12161;
                        }
                        else if (total_weight >= 41 && total_weight <= 45)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._A212C16161;
                        }
                        else if (total_weight >= 46)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._A212C20161;
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
                }

                if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                {
                    Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;

                    if (base_color == Base_Color._Ivory ||
                        base_color == Base_Color._White)
                    {
                        Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
                        Panel_PlasticWedge = PlasticWedge_ArticleNo._7199WHT;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400215;
                        Panel_PlasticWedge = PlasticWedge_ArticleNo._7199DB;
                    }
                }

                if (Panel_HandleType == Handle_Type._Rio)
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
                }
                else if (Panel_HandleType == Handle_Type._MVD)
                {
                    Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._50p5x50p5;
                }
            }
            else if (Panel_SashPropertyVisibility == false)
            {
                Panel_SashWidth = 0;
                Panel_SashHeight = 0;

                Panel_SashReinfWidth = 0;
                Panel_SashReinfHeight = 0;

                Panel_GlazingBeadWidth = Panel_DisplayWidth; //- (33 * 2);
                Panel_GlazingBeadHeight = Panel_DisplayHeight; //- (33 * 2);

                Panel_GlassWidth = Panel_DisplayWidth - (33 * 2) - 6;
                Panel_GlassHeight = Panel_DisplayHeight - (33 * 2) - 6;
            }

            Panel_GlazingSpacerQty = 1;
        }

        public void SetPanelExplosionValues_Panel(Divider_ArticleNo divNxt_artNo,
                                                  Divider_ArticleNo divPrev_artNo,
                                                  DividerType div_type,
                                                  Divider_ArticleNo divArtNo_LeftorTop = null,
                                                  Divider_ArticleNo divArtNo_RightorBot = null,
                                                  string div_type_lvl3 = "",
                                                  Divider_ArticleNo divArtNo_LeftorTop_lvl3 = null,
                                                  Divider_ArticleNo divArtNo_RightorBot_lvl3 = null,
                                                  string panel_placement = "",
                                                  string mpanel_placement = "", //1st level
                                                  string mpanelparent_placement = "") //2nd level
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

            if (divNxt_artNo == Divider_ArticleNo._7536) //base level
            {
                GB_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev -= 7; //sash bite allowance
            }
            else if (divNxt_artNo == Divider_ArticleNo._7538)
            {
                GB_deduction_forNxtPrev += (72 / 2);
                Sash_deduction_forNxtPrev += (72 / 2);
                Sash_deduction_forNxtPrev -= 7; //sash bite allowance
            }
            else if (divNxt_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "Last" && mpanelparent_placement == "")
                {
                    GB_deduction_forNxtPrev += 33;
                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                    {
                        Sash_deduction_forNxtPrev += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        Sash_deduction_forNxtPrev += 40;
                    }
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        GB_deduction_forNxtPrev += 33;
                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        GB_deduction_forNxtPrev += 33;
                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                    }
                }
            }

            if (divPrev_artNo == Divider_ArticleNo._7536) //base level
            {
                GB_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev -= 7; //sash bite allowance
            }
            else if (divPrev_artNo == Divider_ArticleNo._7538)
            {
                GB_deduction_forNxtPrev += (72 / 2);
                Sash_deduction_forNxtPrev += (72 / 2);
                Sash_deduction_forNxtPrev -= 7; //sash bite allowance
            }
            else if (divPrev_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "First" && mpanelparent_placement == "")
                {
                    GB_deduction_forNxtPrev += 33;
                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                    {
                        Sash_deduction_forNxtPrev += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        Sash_deduction_forNxtPrev += 40;
                    }
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        GB_deduction_forNxtPrev += 33;
                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        GB_deduction_forNxtPrev += 33;
                        if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                        {
                            Sash_deduction_forNxtPrev += 26;
                        }
                        else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                        {
                            Sash_deduction_forNxtPrev += 40;
                        }
                    }
                }
            }

            if (divArtNo_LeftorTop == Divider_ArticleNo._7536) //level 2
            {
                GB_deduction_forLeftorTopRightorBot += (42 / 2);
                Sash_deduction_forLeftorTopRightorBot += (42 / 2);
                Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
            }
            else if (divArtNo_LeftorTop == Divider_ArticleNo._7538)
            {
                GB_deduction_forLeftorTopRightorBot += (72 / 2);
                Sash_deduction_forLeftorTopRightorBot += (72 / 2);
                Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
            }
            else if (divArtNo_LeftorTop == Divider_ArticleNo._None)
            {
                if (mpanel_placement == "First" ||
                    mpanel_placement == "Last" ||
                    mpanel_placement == "")
                {
                    GB_deduction_forLeftorTopRightorBot += 33;
                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 40;
                    }
                }
            }

            if (divArtNo_RightorBot == Divider_ArticleNo._7536)
            {
                GB_deduction_forLeftorTopRightorBot += (42 / 2);
                Sash_deduction_forLeftorTopRightorBot += (42 / 2);
                Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
            }
            else if (divArtNo_RightorBot == Divider_ArticleNo._7538)
            {
                GB_deduction_forLeftorTopRightorBot += (72 / 2);
                Sash_deduction_forLeftorTopRightorBot += (72 / 2);
                Sash_deduction_forLeftorTopRightorBot -= 7; //sash bite allowance
            }
            else if (divArtNo_RightorBot == Divider_ArticleNo._None)
            {
                if (mpanel_placement == "First" ||
                    mpanel_placement == "Last" ||
                    mpanel_placement == "")
                {
                    GB_deduction_forLeftorTopRightorBot += 33;
                    if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 26;
                    }
                    else if (Panel_ParentFrameModel.Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
                    {
                        Sash_deduction_forLeftorTopRightorBot += 40;
                    }
                }
            }

            if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._7536)
            {
                GB_deduction_lvl3 += (42 / 2);
            }
            else if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._7538)
            {
                GB_deduction_lvl3 += (72 / 2);
            }

            if (divArtNo_RightorBot_lvl3 == Divider_ArticleNo._7536)
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

            Base_Color base_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor;
            Foil_Color inside_color = Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;

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
            }

            if (Panel_SashPropertyVisibility == true)
            {
                Panel_SashWidth = (Panel_DisplayWidth - deduction_for_sashWD) + 5;
                Panel_SashHeight = (Panel_DisplayHeight - deduction_for_sashHT) + 5;

                Panel_OriginalSashWidth = (Panel_DisplayWidth - deduction_for_sashWD) + 5;
                Panel_OriginalSashHeight = (Panel_DisplayHeight - deduction_for_sashHT) + 5;

                Panel_SashReinfWidth = Panel_SashWidth - 5 - (55 * 2) - 10;
                Panel_SashReinfHeight = Panel_SashHeight - 5 - (55 * 2) - 10;

                Panel_GlazingBeadWidth = Panel_SashWidth;
                Panel_GlazingBeadHeight = Panel_SashHeight;

                Panel_GlassWidth = Panel_SashWidth - 5 - (55 * 2) - 6;
                Panel_GlassHeight = Panel_SashHeight - 5 - (55 * 2) - 6;

                Panel_OriginalGlassWidth = Panel_SashWidth - 5 - (55 * 2) - 6;
                Panel_OriginalGlassHeight = Panel_SashHeight - 5 - (55 * 2) - 6;

                Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;

                if (base_color == Base_Color._DarkBrown)
                {
                    if (Panel_DisplayHeight < 1551)
                    {
                        Panel_MiddleCloserPairQty = 1;
                    }
                    else if (Panel_DisplayHeight > 1551 && Panel_DisplayHeight < 1999)
                    {
                        Panel_MiddleCloserPairQty = 2;
                    }
                    else if (Panel_DisplayHeight > 1999)
                    {
                        Panel_MiddleCloserPairQty = 3;
                    }
                }
                else if (base_color == Base_Color._White ||
                         base_color == Base_Color._Ivory)
                {
                    if (Panel_SashHeight < 1551)
                    {
                        Panel_MiddleCloserPairQty = 1;
                    }
                    else if (Panel_SashHeight > 1551 && Panel_SashHeight < 1999)
                    {
                        Panel_MiddleCloserPairQty = 2;
                    }
                    else if (Panel_SashHeight > 1999)
                    {
                        Panel_MiddleCloserPairQty = 3;
                    }
                }

                Panel_StrikerArtno_A = Striker_ArticleNo._M89ANTA;
                Panel_StrikerArtno_C = Striker_ArticleNo._M89ANTC;

                if (Panel_DisplayWidth > 0 && Panel_DisplayWidth <= 1499)
                {
                    Panel_MotorizedMechQty = 1;
                }
                else if (Panel_DisplayWidth >= 1500)
                {
                    Panel_MotorizedMechQty = 2;
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
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_205 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_206)
                    {
                        Panel_StrikerQty_A += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_207)
                    {
                        Panel_StrikerQty_A += 2;
                    }

                    if (Panel_ExtensionLeftArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionLeft2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionRightArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionRight2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
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
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_205 ||
                             Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_206)
                    {
                        Panel_StrikerQty_C += 1;
                    }
                    else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._625_207)
                    {
                        Panel_StrikerQty_C += 2;
                    }

                    if (Panel_ExtensionTopArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionTop2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionBotArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }

                    if (Panel_ExtensionBot2ArtNo != Extension_ArticleNo._None)
                    {
                        Panel_StrikerQty_C += 1;
                    }
                }

                if (Panel_CornerDriveArtNo == CornerDrive_ArticleNo._639958)
                {
                    Panel_StrikerQty_A += 2;
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
                        fs_dimension_based = FrictionStay_ArticleNo._477254;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 1000) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._A2121C1261;
                    }
                    else if (((sashWD_floor >= 1100 && sashWD_floor <= 1500) &&
                             (sashHt_floor >= 600 && sashHt_floor <= 700)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._A212C16161;
                    }
                    else if (((sashWD_floor >= 400 && sashWD_floor <= 1100) &&
                             (sashHt_floor >= 800 && sashHt_floor <= 900)))
                    {
                        fs_dimension_based = FrictionStay_ArticleNo._A212C16161;
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
                            fs_weight_based = FrictionStay_ArticleNo._477254;
                        }
                        else if (total_weight >= 50 && total_weight <= 54)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._A2121C1261;
                        }
                        else if (total_weight >= 55 && total_weight <= 74)
                        {
                            fs_weight_based = FrictionStay_ArticleNo._A212C16161;
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
                }
                else if (Panel_Type.Contains("Casement"))
                {
                    FrictionStayCasement_ArticleNo fs_dimension_based = FrictionStayCasement_ArticleNo._None;
                    FrictionStayCasement_ArticleNo fs_weight_based = FrictionStayCasement_ArticleNo._None;

                    if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                        (Panel_SashWidth >= 350 && Panel_SashWidth <= 399))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._485770;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 400 && sashHt_floor <= 1200))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A235B12161;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 600) &&
                             (sashHt_floor >= 1300 && sashHt_floor <= 1500))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C12161;
                    }
                    else if ((sashWD_floor >= 400 && sashWD_floor <= 500) &&
                             (sashHt_floor >= 1600 && sashHt_floor <= 2100))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C12161;
                    }
                    else if ((sashHt_floor >= 1600 && sashHt_floor <= 2200) &&
                             (Panel_SashWidth >= 600 && Panel_SashWidth <= 699))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C16161;
                    }
                    else if (Panel_SashWidth >= 700 && Panel_SashWidth <= 799)
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C16161;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 800 && Panel_SashWidth <= 899))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C16161;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 2100) &&
                             (Panel_SashWidth >= 900 && Panel_SashWidth <= 999))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C20161;
                    }
                    else if ((sashHt_floor >= 400 && sashHt_floor <= 1500) &&
                             (Panel_SashWidth >= 1000 && Panel_SashWidth <= 1199))
                    {
                        fs_dimension_based = FrictionStayCasement_ArticleNo._A212C20161;
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
                            fs_weight_based = FrictionStayCasement_ArticleNo._A235B12161;
                        }
                        else if (total_weight >= 19 && total_weight <= 35)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._485770;
                        }
                        else if (total_weight >= 36 && total_weight <= 40)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._A212C12161;
                        }
                        else if (total_weight >= 41 && total_weight <= 45)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._A212C16161;
                        }
                        else if (total_weight >= 46)
                        {
                            fs_weight_based = FrictionStayCasement_ArticleNo._A212C20161;
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
                }

                if (Panel_FrictionStayArtNo == FrictionStay_ArticleNo._Storm26)
                {
                    Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;

                    if (base_color == Base_Color._Ivory ||
                        base_color == Base_Color._White)
                    {
                        Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
                        Panel_PlasticWedge = PlasticWedge_ArticleNo._7199WHT;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400215;
                        Panel_PlasticWedge = PlasticWedge_ArticleNo._7199DB;
                    }
                }
            }
            else if (Panel_SashPropertyVisibility == false)
            {
                Panel_SashWidth = 0;
                Panel_SashHeight = 0;

                Panel_SashReinfWidth = 0;
                Panel_SashReinfHeight = 0;

                Panel_GlazingBeadWidth = Panel_DisplayWidth;
                Panel_GlazingBeadHeight = Panel_DisplayHeight;

                Panel_GlassWidth = (Panel_DisplayWidth - deduction_for_wd) - 6;
                Panel_GlassHeight = (Panel_DisplayHeight - deduction_for_ht) - 6;

                Panel_OriginalGlassWidth = (Panel_OriginalDisplayWidth - deduction_for_wd) - 6;
                Panel_OriginalGlassHeight = (Panel_OriginalDisplayHeight - deduction_for_ht) - 6;
            }

            Panel_GlazingSpacerQty = 1;
        }

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
                          int panelDisplayHeight,
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
                          int panelGeorgianBarVerticalQty,
                          int panelGeorgianBarHorizontalQty,
                          bool panelGeorgianBarOptionVisibility)
        {
            Panel_ID = panelID;
            Panel_Name = panelName;
            Panel_Width = panelWd;
            Panel_Height = panelHt;
            Panel_Dock = panelDock;
            Panel_Type = panelType;
            Panel_Orient = panelOrient;
            Panel_Parent = panelParent;
            Panel_FrameGroup = panelFrameGroup;
            Panel_Visibility = panelVisibility;
            Panel_FramePropertiesGroup = panelFramePropertiesGroup;
            Panel_MultiPanelGroup = panelMultiPanelGroup;
            Panel_Index_Inside_MPanel = panelIndexInsideMPanel;
            PanelImageRenderer_Zoom = panelImageRendererZoom;
            Panel_Zoom = panelZoom;
            Panel_ParentFrameModel = panelFrameModelParent;
            Panel_ParentMultiPanelModel = panelMultiPanelParent;
            PanelGlazingBead_ArtNo = panelGlazingBeadArtNo;
            Panel_DisplayWidth = panelDisplayWidth;
            Panel_DisplayHeight = panelDisplayHeight;
            PanelGlass_ID = panelGlassID;
            Panel_OriginalDisplayWidth = panelDisplayWidth;
            Panel_OriginalDisplayHeight = panelDisplayHeight;
            Panel_GlassFilm = panelGlassFilm;
            Panel_SashProfileArtNo = panelSash;
            Panel_SashReinfArtNo = panelSashReinf;
            Panel_OriginalWidth = Panel_Width;
            Panel_OriginalHeight = Panel_Height;
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
            Panel_GeorgianBar_VerticalQty = panelGeorgianBarVerticalQty;
            Panel_GeorgianBar_HorizontalQty = panelGeorgianBarHorizontalQty;
            Panel_GeorgianBarOptionVisibility = panelGeorgianBarOptionVisibility;

            Panel_PropertyHeight = constants.panel_propertyHeight_default;
            Panel_HandleOptionsHeight = constants.panel_property_handleOptionsHeight;
            Panel_RotoswingOptionsHeight = constants.panel_property_rotoswingOptionsheight_default;
            Panel_ExtensionPropertyHeight = constants.panel_property_extensionOptionsheight;
            Panel_GlassPropertyHeight = constants.panel_property_glassOptionsHeight;
        }
    }
}
