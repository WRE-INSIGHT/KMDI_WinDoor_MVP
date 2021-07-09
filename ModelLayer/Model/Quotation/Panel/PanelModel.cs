using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;
using static ModelLayer.Model.Quotation.QuotationModel;

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
                if (value == true)
                {
                    if (Panel_Type == "Fixed Panel")
                    {
                        _panelPropertyHeight = constants.panel_propertyHeight_default 
                                               - constants.panel_property_handleOptionsHeight
                                               - constants.panel_property_pnlmotorizedheight
                                               - constants.panel_property_motorizedOptionsheight;
                    }
                    else
                    {
                        _panelPropertyHeight = constants.panel_propertyHeight_default;
                        if (_panelMotorizedOptionVisibility == false)
                        {
                            if (_panelHandleType == Handle_Type._Rotoswing)
                            {
                                _panelPropertyHeight = constants.panel_propertyHeight_default
                                                       - constants.panel_property_handleOptionsHeight 
                                                       - constants.panel_property_rotaryOptionsheight_default
                                                       - constants.panel_property_motorizedOptionsheight;
                            }
                            else if (_panelHandleType == Handle_Type._Rotary)
                            {
                                _panelPropertyHeight = constants.panel_propertyHeight_default 
                                                       - constants.panel_property_handleOptionsHeight 
                                                       - constants.panel_property_rotoswingOptionsheight_default
                                                       - constants.panel_property_motorizedOptionsheight;
                            }
                        }
                        else if (_panelMotorizedOptionVisibility == true)
                        {

                        }
                    }
                }
                else if (value == false)
                {
                    _panelPropertyHeight = constants.panel_propertyHeight_default 
                                           - (constants.panel_property_sashPanelHeight + constants.panel_property_handleOptionsHeight)
                                           - constants.panel_property_pnlmotorizedheight
                                           - constants.panel_property_motorizedOptionsheight; ;//304;
                }
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
                if (_panelType != "Fixed Panel")
                {
                    if (_panelHandleType == Handle_Type._Rotoswing)
                    {
                        _panelRotoswingOptionsVisibility = true;
                        _panelRotaryOptionsVisibility = false;
                        _panelHandleOptionsHeight = constants.panel_property_handleOptionsHeight - constants.panel_property_rotaryOptionsheight_default; //153
                        _panelPropertyHeight = constants.panel_propertyHeight_default 
                                               - constants.panel_property_rotaryOptionsheight_default
                                               - constants.panel_property_motorizedOptionsheight;
                    }
                    else if (_panelHandleType == Handle_Type._Rotary)
                    {
                        _panelRotoswingOptionsVisibility = false;
                        _panelRotaryOptionsVisibility = true;
                        _panelHandleOptionsHeight = constants.panel_property_handleOptionsHeight - constants.panel_property_rotoswingOptionsheight_default; //107
                        _panelPropertyHeight = constants.panel_propertyHeight_default 
                                               - constants.panel_property_rotoswingOptionsheight_default
                                               - constants.panel_property_motorizedOptionsheight;
                    }
                }
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

        public int Panel_PlasticWedgeQty { get; set; }

        private Striker_ArticleNo _panelStrikerArtno;
        public Striker_ArticleNo Panel_StrikerArtno
        {
            get
            {
                return _panelStrikerArtno;
            }
            set
            {
                _panelStrikerArtno = value;
                NotifyPropertyChanged();
            }
        }
        public int Panel_StrikerQty { get; set; }

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

        public void SetPanelExplosionValues_Panel(bool parentIsFrame)
        {
            if (Panel_SashPropertyVisibility == true)
            {
                Panel_SashWidth = Panel_DisplayWidth - (26 * 2) + 5;
                Panel_SashHeight = Panel_DisplayHeight - (26 * 2) + 5;

                Panel_SashReinfWidth = Panel_SashWidth - 5 - (55 * 2) - 10;
                Panel_SashReinfHeight = Panel_SashHeight - 5 - (55 * 2) - 10;

                Panel_GlazingBeadWidth = Panel_SashWidth;
                Panel_GlazingBeadHeight = Panel_SashHeight;

                Panel_GlassWidth = Panel_SashWidth - 5 - (55 * 2) - 6;
                Panel_GlassHeight = Panel_SashHeight - 5 - (55 * 2) - 6;

                Panel_CoverProfileArtNo = CoverProfile_ArticleNo._0914;
                Panel_CoverProfileArtNo2 = CoverProfile_ArticleNo._1640;

                if (Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                {
                    if (Panel_Height < 1551)
                    {
                        Panel_MiddleCloserPairQty = 1;
                    }
                    else if (Panel_Height > 1551 && Panel_Height < 1999)
                    {
                        Panel_MiddleCloserPairQty = 2;
                    }
                    else if (Panel_Height > 1999)
                    {
                        Panel_MiddleCloserPairQty = 3;
                    }
                }
                else if (Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                         Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
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

                if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._612978)
                {
                    Panel_StrikerQty = 0;
                }
                else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._639957 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._639958)
                {
                    Panel_StrikerQty = 1;
                }
                else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                {
                    Panel_StrikerQty = 2;
                }
                else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                {
                    Panel_StrikerQty = 3;
                }

                int sashWD_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashWidth / 100)) * 100;
                int sashHt_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashHeight / 100)) * 100;

                if ((sashWD_floor >= 400 && sashWD_floor <= 1200) &&
                    (Panel_SashHeight >= 350 && Panel_SashHeight <= 399))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm8;
                }
                else if (sashHt_floor >= 400 && sashHt_floor <= 500)
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._477254;
                }
                else if ((sashWD_floor >= 400 && sashWD_floor <= 1000) &&
                         (sashHt_floor >= 600 && sashHt_floor <= 700))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._A2121C1261;
                }
                else if (((sashWD_floor >= 1100 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 600 && sashHt_floor <= 700)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._A212C16161;
                }
                else if (((sashWD_floor >= 400 && sashWD_floor <= 1100) &&
                         (sashHt_floor >= 800 && sashHt_floor <= 900)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._A212C16161;
                }
                else if (((sashWD_floor >= 1200 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 800 && sashHt_floor <= 900)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm22;
                }
                else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 1000 && sashHt_floor <= 1200)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm22;
                }
                else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 1300 && sashHt_floor <= 2300)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm26;
                }
                else
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._None;
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
                Sash_deduction_forNxtPrev += (42 / 2);
                Sash_deduction_forNxtPrev -= 7; //sash bite allowance
            }
            else if (divNxt_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "Last" && mpanelparent_placement == "")
                {
                    GB_deduction_forNxtPrev += 33;
                    Sash_deduction_forNxtPrev += 26;
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        GB_deduction_forNxtPrev += 33;
                        Sash_deduction_forNxtPrev += 26;
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        GB_deduction_forNxtPrev += 33;
                        Sash_deduction_forNxtPrev += 26;
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
                    Sash_deduction_forNxtPrev += 26;
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        GB_deduction_forNxtPrev += 33;
                        Sash_deduction_forNxtPrev += 26;
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        GB_deduction_forNxtPrev += 33;
                        Sash_deduction_forNxtPrev += 26;
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
                    Sash_deduction_forLeftorTopRightorBot += 26;
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
                    Sash_deduction_forLeftorTopRightorBot += 26;
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

                if (Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                {
                    if (Panel_Height < 1551)
                    {
                        Panel_MiddleCloserPairQty = 1;
                    }
                    else if (Panel_Height > 1551 && Panel_Height < 1999)
                    {
                        Panel_MiddleCloserPairQty = 2;
                    }
                    else if (Panel_Height > 1999)
                    {
                        Panel_MiddleCloserPairQty = 3;
                    }
                }
                else if (Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                         Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
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

                if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._612978)
                {
                    Panel_StrikerQty = 0;
                }
                else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._639957 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._639958)
                {
                    Panel_StrikerQty = 1;
                }
                else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628806 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628807 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._628809)
                {
                    Panel_StrikerQty = 2;
                }
                else if (Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._741012 ||
                         Panel_EspagnoletteArtNo == Espagnolette_ArticleNo._EQ87NT)
                {
                    Panel_StrikerQty = 3;
                }
                int sashWD_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashWidth / 100)) * 100;
                int sashHt_floor = Convert.ToInt32(Math.Floor((decimal)Panel_SashHeight / 100)) * 100;

                if ((sashWD_floor >= 400 && sashWD_floor <= 1200) &&
                    (Panel_SashHeight >= 350 && Panel_SashHeight <= 399))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm8;
                }
                else if (sashHt_floor >= 400 && sashHt_floor <= 500)
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._477254;
                }
                else if ((sashWD_floor >= 400 && sashWD_floor <= 1000) &&
                         (sashHt_floor >= 600 && sashHt_floor <= 700))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._A2121C1261;
                }
                else if (((sashWD_floor >= 1100 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 600 && sashHt_floor <= 700)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._A212C16161;
                }
                else if (((sashWD_floor >= 400 && sashWD_floor <= 1100) &&
                         (sashHt_floor >= 800 && sashHt_floor <= 900)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._A212C16161;
                }
                else if (((sashWD_floor >= 1200 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 800 && sashHt_floor <= 900)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm22;
                }
                else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 1000 && sashHt_floor <= 1200)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm22;
                }
                else if (((sashWD_floor >= 400 && sashWD_floor <= 1500) &&
                         (sashHt_floor >= 1300 && sashHt_floor <= 2300)))
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._Storm26;
                }
                else
                {
                    Panel_FrictionStayArtNo = FrictionStay_ArticleNo._None;
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
                          LockingKit_ArticleNo panelLockingKitArtno)
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
            Panel_StrikerArtno = panelStrikerArtno;
            Panel_MiddleCloserArtNo = panelMiddleCloserArtno;
            Panel_LockingKitArtNo = panelLockingKitArtno;
        }
    }
}
