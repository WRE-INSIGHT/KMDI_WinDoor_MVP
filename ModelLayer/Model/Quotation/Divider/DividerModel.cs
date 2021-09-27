using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Divider
{
    public class DividerModel : IDividerModel, INotifyPropertyChanged
    {
        ConstantVariables constants = new ConstantVariables();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public enum DividerType
        {
            Mullion = 0,
            Transom = 1
        }

        private int _divID;
        public int Div_ID
        {
            get
            {
                return _divID;
            }
            set
            {
                _divID = value;
                NotifyPropertyChanged();
            }
        }

        private string _divName;
        public string Div_Name
        {
            get
            {
                return _divName;
            }
            set
            {
                _divName = value;
                NotifyPropertyChanged();
            }
        }

        private DividerType _divType;
        public DividerType Div_Type
        {
            get
            {
                return _divType;
            }
            set
            {
                _divType = value;
            }
        }

        private int _divWd;
        public int Div_Width
        {
            get
            {
                return _divWd;
            }
            set
            {
                _divWd = value;
                Div_WidthToBind = (int)(value * Div_Zoom);
                DivImageRenderer_Width = (int)(value * DivImageRenderer_Zoom);
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that is used for user's output")]
        private int _divDisplayWidth;
        public int Div_DisplayWidth
        {
            get
            {
                return _divDisplayWidth;
            }
            set
            {
                _divDisplayWidth = value;
                NotifyPropertyChanged();
            }
        }

        private int _divHt;
        public int Div_Height
        {
            get
            {
                return _divHt;
            }
            set
            {
                _divHt = value;
                Div_HeightToBind = (int)(value * Div_Zoom);
                DivImageRenderer_Height = (int)(value * DivImageRenderer_Zoom);
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Height that is used for user's output")]
        private int _divDisplayHeight;
        public int Div_DisplayHeight
        {
            get
            {
                return _divDisplayHeight;
            }
            set
            {
                _divDisplayHeight = value;
                NotifyPropertyChanged();
            }
        }

        private bool _divVisibility;
        public bool Div_Visible
        {
            get
            {
                return _divVisibility;
            }
            set
            {
                _divVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private Control _divParent;
        public Control Div_Parent
        {
            get
            {
                return _divParent;
            }
            set
            {
                _divParent = value;
            }
        }

        private string _divFrameType;
        public string Div_FrameType
        {
            get
            {
                return _divFrameType;
            }

            set
            {
                _divFrameType = value;
                NotifyPropertyChanged();
            }
        }

        private float _divImageRenderedZoom;
        public float DivImageRenderer_Zoom
        {
            get
            {
                return _divImageRenderedZoom;
            }

            set
            {
                _divImageRenderedZoom = value;
                DivImageRenderer_Width = (int)(Div_Width * value);
                DivImageRenderer_Height = (int)(Div_Height * value);

                NotifyPropertyChanged();
            }
        }

        private int _divImageRendererHt;
        public int DivImageRenderer_Height
        {
            get
            {
                return _divImageRendererHt;
            }

            set
            {
                _divImageRendererHt = value;
                NotifyPropertyChanged();
            }
        }

        private int _divImagerendererWd;
        public int DivImageRenderer_Width
        {
            get
            {
                return _divImagerendererWd;
            }

            set
            {
                _divImagerendererWd = value;
                NotifyPropertyChanged();
            }
        }

        private int[] _arr_divSizes = { 26, 33, 20 }; //even index - Window ; odd index - Door

        private float _divZoom;
        public float Div_Zoom
        {
            get
            {
                return _divZoom;
            }

            set
            {
                _divZoom = value;
                Div_HeightToBind = (int)(value * Div_Height);
                Div_WidthToBind = (int)(value * Div_Width);
            }
        }

        private int _divWidthToBind;
        public int Div_WidthToBind
        {
            get
            {
                return _divWidthToBind;
            }

            set
            {
                _divWidthToBind = value;
                NotifyPropertyChanged();
            }
        }

        private int _divHeightToBind;
        public int Div_HeightToBind
        {
            get
            {
                return _divHeightToBind;
            }

            set
            {
                _divHeightToBind = value;
                NotifyPropertyChanged();
            }
        }


        private int _divCladdingBracketUPVCQty;
        public int Div_CladdingBracketForUPVCQTY
        {
            get
            {
                return _divCladdingBracketUPVCQty;
            }
            set
            {
                _divCladdingBracketUPVCQty = value;
                NotifyPropertyChanged();
            }
        }

        private int _divCladdingBracketConcreteQty;
        public int Div_CladdingBracketForConcreteQTY
        {
            get
            {
                return _divCladdingBracketConcreteQty;
            }
            set
            {
                _divCladdingBracketConcreteQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _div_claddingBracketVisibility;
        public bool Div_claddingBracketVisibility
        {
            get
            {
                return _div_claddingBracketVisibility;
            }

            set
            {
                _div_claddingBracketVisibility = value;
                NotifyPropertyChanged();
            }
        }
        private DummyMullion_ArticleNo _divDMArtNo;
        public DummyMullion_ArticleNo Div_DMArtNo
        {
            get
            {
                return _divDMArtNo;
            }
            set
            {
                _divDMArtNo = value;
                NotifyPropertyChanged();
            }
        }

        public int Div_AlumSpacer50Qty { get; set; }
        public EndcapDM_ArticleNo Div_EndcapDM { get; set; }
        public FixedCam_ArticleNo Div_FixedCamDM { get; set; }
        public SnapInKeep_ArticleNo Div_SnapNKeepDM { get; set; }

        private bool _divDM;
        public bool Div_ChkDM
        {
            get
            {
                return _divDM;
            }
            set
            {
                _divDM = value;
                NotifyPropertyChanged();
            }
        }

        private bool _divDMVisibility;
        public bool Div_ChkDMVisibility
        {
            get
            {
                return _divDMVisibility;
            }
            set
            {
                _divDMVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _divArtVisibility;
        public bool Div_ArtVisibility
        {
            get
            {
                return _divArtVisibility;
            }
            set
            {
                _divArtVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public IMultiPanelModel Div_MPanelParent { get; set; }
        public IFrameModel Div_FrameParent { get; set; }
        public IPanelModel Div_DMPanel { get; set; }

        #region Explosion

        private Divider_ArticleNo _divArtNo;
        public Divider_ArticleNo Div_ArtNo
        {
            get
            {
                return _divArtNo;
            }
            set
            {
                _divArtNo = value;
                if (value == Divider_ArticleNo._7536)
                {
                    Div_ReinfArtNo = DividerReinf_ArticleNo._R677;
                    Div_MechJoinArtNo = Divider_MechJointArticleNo._9U18;
                }
                else if (value == Divider_ArticleNo._7538)
                {
                    Div_ReinfArtNo = DividerReinf_ArticleNo._R686;
                    Div_MechJoinArtNo = Divider_MechJointArticleNo._AV585;
                }
                NotifyPropertyChanged();
            }
        }

        private DividerReinf_ArticleNo _divReinfArtNo;
        public DividerReinf_ArticleNo Div_ReinfArtNo
        {
            get
            {
                return _divReinfArtNo;
            }
            set
            {
                _divReinfArtNo = value;
                NotifyPropertyChanged();
            }
        }

        public int Div_ExplosionWidth { get; set; }
        public int Div_ExplosionHeight { get; set; }
        public int Div_ReinfWidth { get; set; }
        public int Div_ReinfHeight { get; set; }
        public string Div_Bounded { get; set; }

        public Divider_MechJointArticleNo Div_MechJoinArtNo { get; set; }
        public CladdingProfile_ArticleNo Div_CladdingProfileArtNo { get; set; }
        public CladdingReinf_ArticleNo Div_CladdingReinfArtNo { get; set; }
        public Dictionary<int, int> Div_CladdingSizeList { get; set; }
        public int Div_CladdingCount { get; set; }

        private int _divPropHeight;
        public int Div_PropHeight
        {
            get
            {
                return _divPropHeight;
            }
            set
            {
                _divPropHeight = value;
                NotifyPropertyChanged();
            }
        }

        private bool _divLeverEspagVisibility;
        public bool Div_LeverEspagVisibility
        {
            get
            {
                return _divLeverEspagVisibility;
            }
            set
            {
                _divLeverEspagVisibility = value;
                NotifyPropertyChanged();
            }
        }
        private LeverEspagnolette_ArticleNo _divLeverEspagArtNo;
        public LeverEspagnolette_ArticleNo Div_LeverEspagArtNo
        {
            get
            {
                return _divLeverEspagArtNo;
            }
            set
            {
                _divLeverEspagArtNo = value;
                NotifyPropertyChanged();
            }
        }
        public ShootboltStriker_ArticleNo Div_ShootboltStrikerArtNo { get; set; }
        public ShootboltNonReverse_ArticleNo Div_ShootboltNonReverseArtNo { get; set; }

        public void SetExplosionValues_Div()
        {
            int frame_deduction = 0;

            if (Div_FrameParent.Frame_ArtNo == FrameProfile_ArticleNo._7502)
            {
                frame_deduction = 33;
            }
            else if (Div_FrameParent.Frame_ArtNo == FrameProfile_ArticleNo._7507)
            {
                frame_deduction = 47;
            }

            if (Div_ChkDM == true)
            {
                if (Div_DMArtNo == DummyMullion_ArticleNo._7533)
                {
                    Div_EndcapDM = EndcapDM_ArticleNo._K7533;
                    Div_FixedCamDM = FixedCam_ArticleNo._1481413;

                    if (Div_FrameParent.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                    {
                        Div_SnapNKeepDM = SnapInKeep_ArticleNo._0400215;
                    }
                    else if (Div_FrameParent.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                             Div_FrameParent.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
                    {
                        Div_SnapNKeepDM = SnapInKeep_ArticleNo._0400205;
                    }
                }
                else if (Div_DMArtNo == DummyMullion_ArticleNo._385P)
                {
                    Div_EndcapDM = EndcapDM_ArticleNo._K385;
                }

                if (Div_DMPanel != null)
                {
                    if (Div_LeverEspagVisibility == true)
                    {
                        if (Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._625_205 ||
                            Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._625_206)
                        {
                            Div_DMPanel.Panel_AdjStrikerQty += 1;
                        }
                        else if (Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._625_207)
                        {
                            Div_DMPanel.Panel_AdjStrikerQty += 2;
                        }
                        Div_ShootboltNonReverseArtNo = ShootboltNonReverse_ArticleNo._349187;
                        Div_ShootboltStrikerArtNo = ShootboltStriker_ArticleNo._N705A20106;
                    }
                }
            }

            if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
            {
                Div_Bounded = "Frame";
                if (Div_Type == DividerType.Mullion)
                {
                    if (Div_ChkDM == true)
                    {
                        Div_ExplosionHeight = (Div_DMPanel.Panel_SashHeight - (38 * 2)) - 5;
                        Div_AlumSpacer50Qty = (int)(Math.Ceiling(((decimal)Div_ExplosionHeight / 300)) - 2);
                    }
                    else if (Div_ChkDM == false)
                    {
                        if (Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            Div_ExplosionHeight = (Div_DisplayHeight - (frame_deduction * 2)) + 3; //3 = (1.5 * 2)
                        }
                        else if (Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            Div_ExplosionHeight = (Div_DisplayHeight - (frame_deduction * 2)) + (4 * 2);
                        }

                        if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677)
                        {
                            Div_ReinfHeight = (Div_ExplosionHeight - (35 * 2)) - (5 * 2);
                        }
                        else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                        {
                            Div_ReinfHeight = (Div_ExplosionHeight - (50 * 2)) - (5 * 2);
                        }

                        Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                        Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                    }
                }
                else if (Div_Type == DividerType.Transom)
                {
                    if (Div_ArtNo == Divider_ArticleNo._7536)
                    {
                        Div_ExplosionWidth = (Div_DisplayWidth - (frame_deduction * 2)) + 3; //3 = (1.5 * 2)
                    }
                    else if (Div_ArtNo == Divider_ArticleNo._7538)
                    {
                        Div_ExplosionWidth = (Div_DisplayWidth - (frame_deduction * 2)) + (4 * 2);
                    }

                    if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677)
                    {
                        Div_ReinfWidth = (Div_ExplosionWidth - (35 * 2)) - (5 * 2);
                    }
                    else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                    {
                        Div_ReinfWidth = (Div_ExplosionWidth - (50 * 2)) - (5 * 2);
                    }

                    Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                    Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                }
            }
            else if (Div_MPanelParent.MPanel_Parent.Name.Contains("Multi"))
            {
                IMultiPanelModel parent_mpanelParent = Div_MPanelParent.MPanel_ParentModel; //div.Parent.Parent 2nd level Parent
                if (parent_mpanelParent.MPanel_Type == "Transom")
                {

                    IDividerModel div_top = null,
                                  div_bot = null;

                    int parent_ndx = Div_MPanelParent.MPanel_Index_Inside_MPanel,
                        top_deduction = 0,
                        bot_deduction = 0;
                    string nxtctrl_name = "",
                           prevctrl_name = "";
                    if (Div_MPanelParent.MPanel_Placement == "First")
                    {
                        Div_Bounded = "Frame&Transom";

                        nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                        div_bot = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);

                        top_deduction = 0;
                        if (div_bot.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            bot_deduction = (42 / 2) + frame_deduction;
                        }
                        else if (div_bot.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            bot_deduction = (72 / 2) + frame_deduction;
                        }
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Somewhere in Between")
                    {
                        Div_Bounded = "Transom";

                        nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                        prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;

                        div_top = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);
                        div_bot = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);

                        if (div_top.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            top_deduction = 42 / 2;
                        }
                        else if (div_top.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            top_deduction = 72 / 2;
                        }

                        if (div_bot.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            bot_deduction = 42 / 2;
                        }
                        else if (div_bot.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            bot_deduction = 72 / 2;
                        }
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Last")
                    {
                        Div_Bounded = "Frame&Transom";

                        prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;
                        div_top = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);
                        bot_deduction = 0;

                        if (div_top.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            top_deduction = (42 / 2) + frame_deduction;
                        }
                        else if (div_top.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            top_deduction = (72 / 2) + frame_deduction;
                        }
                    }

                    if (Div_Type == DividerType.Mullion)
                    {
                        if (Div_ChkDM == true)
                        {
                            Div_ExplosionHeight = (Div_DMPanel.Panel_SashHeight - (38 * 2)) - 5;
                            Div_AlumSpacer50Qty = (int)(Math.Ceiling(((decimal)Div_ExplosionHeight / 300)) - 2);
                        }
                        else if (Div_ChkDM == false)
                        {
                            if (Div_ArtNo == Divider_ArticleNo._7536)
                            {
                                Div_ExplosionHeight = (Div_DisplayHeight - (top_deduction + bot_deduction)) + 3; //3 = (1.5 * 2)
                            }
                            else if (Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                Div_ExplosionHeight = (Div_DisplayHeight - (top_deduction + bot_deduction)) + (4 * 2);
                            }

                            if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677)
                            {
                                Div_ReinfHeight = (Div_ExplosionHeight - (35 * 2)) - (5 * 2);
                            }
                            else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                            {
                                Div_ReinfHeight = (Div_ExplosionHeight - (50 * 2)) - (5 * 2);
                            }

                            Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                            Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                        }
                    }
                }
                else if (parent_mpanelParent.MPanel_Type == "Mullion")
                {
                    IDividerModel div_left = null,
                                  div_right = null;

                    int parent_ndx = Div_MPanelParent.MPanel_Index_Inside_MPanel,
                        left_deduction = 0,
                        right_deduction = 0;
                    string nxtctrl_name = "",
                           prevctrl_name = "";

                    if (Div_MPanelParent.MPanel_Placement == "First")
                    {
                        Div_Bounded = "Frame&Mullion";

                        nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                        div_right = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);
                        left_deduction = 0;

                        if (div_right.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            right_deduction = (42 / 2) + frame_deduction;
                        }
                        else if (div_right.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            right_deduction = (72 / 2) + frame_deduction;
                        }
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Somewhere in Between")
                    {
                        Div_Bounded = "Mullion";

                        nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                        div_right = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);

                        prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;
                        div_left = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);

                        if (div_right.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            right_deduction = 42 / 2;
                        }
                        else if (div_right.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            right_deduction = 72 / 2;
                        }

                        if (div_left.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            left_deduction = 42 / 2;
                        }
                        else if (div_left.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            left_deduction = 72 / 2;
                        }
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Last")
                    {
                        Div_Bounded = "Frame&Mullion";

                        prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;
                        div_left = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);
                        right_deduction = 0;

                        if (div_left.Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            left_deduction = (42 / 2) + frame_deduction;
                        }
                        else if (div_left.Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            left_deduction = (72 / 2) + frame_deduction;
                        }
                    }

                    if (Div_Type == DividerType.Transom)
                    {
                        if (Div_ArtNo == Divider_ArticleNo._7536)
                        {
                            Div_ExplosionWidth = (Div_DisplayWidth - (left_deduction + right_deduction)) + 3; //3 = (1.5 * 2)
                        }
                        else if (Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            Div_ExplosionWidth = (Div_DisplayWidth - (left_deduction + right_deduction)) + (4 * 2);
                        }

                        if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677)
                        {
                            Div_ReinfWidth = (Div_ExplosionWidth - (35 * 2)) - (5 * 2);
                        }
                        else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                        {
                            Div_ReinfWidth = (Div_ExplosionWidth - (50 * 2)) - (5 * 2);
                        }

                        Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                        Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                    }
                }
            }

        }

        public void AdjustPropertyPanelHeight(string mode)
        {
            if (mode == "addCladding")
            {
                Div_PropHeight += constants.div_property_claddingOptionsHeight;
            }
            else if (mode == "minusCladding")
            {
                Div_PropHeight -= constants.div_property_claddingOptionsHeight;
            }
            else if (mode == "addPanelAddCladding")
            {
                Div_PropHeight += constants.div_property_pnlAddcladdingOptionsHeight;
            }
            else if (mode == "minusPanelAddCladding")
            {
                Div_PropHeight -= constants.div_property_pnlAddcladdingOptionsHeight;
            }
            else if (mode == "addDivArt")
            {
                Div_PropHeight += constants.div_property_divArtOptionsHeight;
            }
            else if (mode == "minusDivArt")
            {
                Div_PropHeight -= constants.div_property_divArtOptionsHeight;
            }
            else if (mode == "addDM")
            {
                Div_PropHeight += constants.div_property_DMArtOptionsHeight;
            }
            else if (mode == "minusDM")
            {
                Div_PropHeight -= constants.div_property_DMArtOptionsHeight;
            }
            else if (mode == "addLeverEspag")
            {
                Div_PropHeight += constants.div_property_leverEspagOptionsHeight;
            }
            else if (mode == "minusLeverEspag")
            {
                Div_PropHeight -= constants.div_property_leverEspagOptionsHeight;
            }
            else if (mode == "addCladdingBracket")
            {
                Div_PropHeight += constants.div_property_claddingBracketOptionsHeight;
            }
            else if (mode == "minusCladdingBracket")
            {
                Div_PropHeight -= constants.div_property_claddingBracketOptionsHeight;
            }
        }

        #endregion

        public DividerModel(int divID,
                            string divName,
                            int divWD,
                            int divHT,
                            bool divVisibility,
                            DividerType divType,
                            Control divParent,
                            string divFrameType,
                            float divImageRendererZoom,
                            float divZoom,
                            Divider_ArticleNo divArtNo,
                            int divDisplayWidth,
                            int divDisplayHeight,
                            IMultiPanelModel divMPanelParent,
                            Dictionary<int, int> divCladdingSizeList,
                            IFrameModel divFrameParent,
                            bool divChkDM,
                            bool divArtVisibility,
                            DummyMullion_ArticleNo divDMArtNo,
                            IPanelModel divDMPanel,
                            bool divLeverEspagVisibility)
        {
            Div_ID = divID;
            Div_Name = divName;
            Div_Width = divWD;
            Div_Height = divHT;
            Div_Visible = divVisibility;
            Div_Type = divType;
            Div_Parent = divParent;
            Div_FrameType = divFrameType;
            DivImageRenderer_Zoom = divImageRendererZoom;
            Div_Zoom = divZoom;
            Div_ArtNo = divArtNo;
            Div_DisplayWidth = divDisplayWidth;
            Div_DisplayHeight = divDisplayHeight;
            Div_MPanelParent = divMPanelParent;
            Div_CladdingSizeList = divCladdingSizeList;
            Div_FrameParent = divFrameParent;
            Div_ChkDM = divChkDM;
            Div_ArtVisibility = divArtVisibility;
            Div_DMArtNo = divDMArtNo;
            Div_DMPanel = divDMPanel;
            Div_LeverEspagVisibility = divLeverEspagVisibility;

            if (Div_Type == DividerType.Mullion)
            {
                Div_ChkDMVisibility = true;
            }
            else if (Div_Type == DividerType.Transom)
            {
                Div_ChkDMVisibility = false;
            }

            SetExplosionValues_Div();

            Div_PropHeight = constants.div_propertyheight_default +
                             constants.div_property_pnlAddcladdingOptionsHeight;
            Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addPanelAddCladding");
            Div_FrameParent.AdjustPropertyPanelHeight("Div", "addPanelAddCladding");

            if (Div_ChkDM == true && Div_ArtVisibility == false)
            {
                Div_PropHeight += constants.div_property_DMArtOptionsHeight;
                Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addDM");
                Div_FrameParent.AdjustPropertyPanelHeight("Div", "addDM");
            }
            else if (Div_ChkDM == false && Div_ArtVisibility == true)
            {
                Div_PropHeight += constants.div_property_divArtOptionsHeight;
                Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addDivArt");
                Div_FrameParent.AdjustPropertyPanelHeight("Div", "addDivArt");
            }
        }
    }
}
