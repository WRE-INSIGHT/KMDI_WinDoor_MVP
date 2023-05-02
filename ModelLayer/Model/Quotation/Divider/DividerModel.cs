using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Transom = 1,
            None = 2
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

        #region Methods

        public void SetDimensionsToBind_using_DivZoom()
        {
            int wd = Div_MPanelParent.MPanel_WidthToBind,
                ht = Div_MPanelParent.MPanel_HeightToBind,
                divsize = 0;

            if (Div_FrameParent.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                divsize = (int)FrameModel.Frame_Padding.Window / 2;
            }
            else if (Div_FrameParent.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                divsize = (int)FrameModel.Frame_Padding.Door / 2;
            }

            if (Div_Type == DividerType.Mullion)
            {
                if (_divZoom >=  0.01f && _divZoom  <= 0.26f)
                {
                    Div_WidthToBind = divsize;
                    Div_HeightToBind = ht;
                }
                else if (_divZoom > 0.26f)
                {
                    Div_WidthToBind = (int)(Div_Zoom * Div_Width);
                    Div_HeightToBind = ht;
                }
            }
            else if (Div_Type == DividerType.Transom)
            {
                if (_divZoom >= 0.01f && _divZoom <= 0.26f)
                {
                    Div_WidthToBind = wd;
                    Div_HeightToBind = divsize;
                }
                else if (_divZoom > 0.26f)
                {
                    Div_WidthToBind = wd;
                    Div_HeightToBind = (int)(Div_Zoom * Div_Height);
                }
            }
        }

        public void SetDimensionsToBind_using_DivZoom_Imager()
        {
            int wd = Div_MPanelParent.MPanelImageRenderer_Width,
                ht = Div_MPanelParent.MPanelImageRenderer_Height,
                div_overlap = (int)(10 * Div_MPanelParent.MPanelImageRenderer_Zoom),
                divsize = 13;
            
            if (Div_Type == DividerType.Mullion)
            {
                if (/*DivImageRenderer_Zoom == 0.26f || DivImageRenderer_Zoom == 0.17f ||
                    DivImageRenderer_Zoom == 0.13f || DivImageRenderer_Zoom == 0.10f*/DivImageRenderer_Zoom >= 0.01f && DivImageRenderer_Zoom <= 0.26f)
                {
                    DivImageRenderer_Height = ht + 10;
                    DivImageRenderer_Width = divsize;
                }
                else if (DivImageRenderer_Zoom > 0.26f)
                {
                    DivImageRenderer_Height = ht + (div_overlap * 2);
                    //DivImageRenderer_Width = (int)(DivImageRenderer_Zoom * Div_Width);
                    if (DivImageRenderer_Zoom == 0.5f)
                    {
                        if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
                        {
                            DivImageRenderer_Width = (int)(DivImageRenderer_Zoom * Div_Width);
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {
                            DivImageRenderer_Width = 13;
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {


                        }
                    }
                    else
                    {
                        if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
                        {
                            DivImageRenderer_Width = (int)(DivImageRenderer_Zoom * Div_Width);
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {
                            DivImageRenderer_Width = 26;
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {


                        }
                    }


                }
            }
            else if (Div_Type == DividerType.Transom)
            {
                if (/*DivImageRenderer_Zoom == 0.26f || DivImageRenderer_Zoom == 0.17f ||
                    DivImageRenderer_Zoom == 0.13f || DivImageRenderer_Zoom == 0.10f*/DivImageRenderer_Zoom >= 0.01f && DivImageRenderer_Zoom <= 0.26f)
                {
                    DivImageRenderer_Width = wd + 10;
                    DivImageRenderer_Height = divsize;
                }
                else if (DivImageRenderer_Zoom > 0.26f)
                {
                    DivImageRenderer_Width = wd + (div_overlap * 2);
                    //DivImageRenderer_Height = (int)(DivImageRenderer_Zoom * Div_Height);

                    if (DivImageRenderer_Zoom == 0.5f)
                    {
                        if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
                        {
                            DivImageRenderer_Height = (int)(DivImageRenderer_Zoom * Div_Height);
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {
                            DivImageRenderer_Height = 13;
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {


                        }
                    }
                    else
                    {
                        if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
                        {
                            DivImageRenderer_Height = (int)(DivImageRenderer_Zoom * Div_Height);
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {
                            DivImageRenderer_Height = 26;
                        }
                        else if (Div_MPanelParent.MPanel_ParentModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame")) //drawing of 3rd level multipanel objs
                        {


                        }
                    }
                }
            }
        }

        public void SetDimensionsToBind_using_DivZoom_Imager_Initial()
        {
            int wd = Div_MPanelParent.MPanelImageRenderer_Width,
                ht = Div_MPanelParent.MPanelImageRenderer_Height,
                div_overlap = (int)(10 * Div_MPanelParent.MPanelImageRenderer_Zoom),
                divsize = 0;

            if (Div_FrameParent.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                divsize = ((int)FrameModel.Frame_Padding.Window / 2);
            }
            else if (Div_FrameParent.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                divsize = ((int)FrameModel.Frame_Padding.Door / 2);
            }

            if (Div_Type == DividerType.Mullion)
            {
                if (/*DivImageRenderer_Zoom == 0.26f || DivImageRenderer_Zoom == 0.17f ||
                    DivImageRenderer_Zoom == 0.13f || DivImageRenderer_Zoom == 0.10f*/DivImageRenderer_Zoom >= 0.01f && DivImageRenderer_Zoom <= 0.26f)
                {
                    DivImageRenderer_Width = divsize;
                    DivImageRenderer_Height = ht + 10;
                }
                else if (DivImageRenderer_Zoom > 0.26f)
                {
                    DivImageRenderer_Width = (int)(DivImageRenderer_Zoom * Div_Width);
                    DivImageRenderer_Height = ht + div_overlap + Convert.ToInt32(6 * DivImageRenderer_Zoom);
                }
            }
            else if (Div_Type == DividerType.Transom)
            {
                if (/*DivImageRenderer_Zoom == 0.26f || DivImageRenderer_Zoom == 0.17f ||
                    DivImageRenderer_Zoom == 0.13f || DivImageRenderer_Zoom == 0.10f*/DivImageRenderer_Zoom >= 0.01f && DivImageRenderer_Zoom <= 0.26f)
                {
                    DivImageRenderer_Width = wd + 10;
                    DivImageRenderer_Height = divsize;
                }
                else if (DivImageRenderer_Zoom > 0.26f)
                {
                    DivImageRenderer_Width = wd + div_overlap + Convert.ToInt32(6 * DivImageRenderer_Zoom);
                    DivImageRenderer_Height = (int)(DivImageRenderer_Zoom * Div_Height);
                }
            }
        }

        #endregion

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
                else if (value == Divider_ArticleNo._2069)
                {
                    Div_ReinfArtNo = DividerReinf_ArticleNo._V226;
                    Div_MechJoinArtNo = Divider_MechJointArticleNo._9U18;
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

        private bool _div_CladdingProfileArtNoVisibility;
        public bool Div_CladdingProfileArtNoVisibility
        {
            get
            {
                return _div_CladdingProfileArtNoVisibility;
            }
            set
            {
                _div_CladdingProfileArtNoVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private CladdingProfile_ArticleNo _div_claddingProfileArtNo;
        public CladdingProfile_ArticleNo Div_CladdingProfileArtNo
        {
            get
            {
                return _div_claddingProfileArtNo;
            }
            set
            {
                _div_claddingProfileArtNo = value;
                if (value == CladdingProfile_ArticleNo._1338)
                {
                    Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                }
                else if (value == CladdingProfile_ArticleNo._WK50)
                {
                    Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._NA50;
                }
                NotifyPropertyChanged();
            }
        }
        public CladdingReinf_ArticleNo Div_CladdingReinfArtNo { get; set; }
        public Dictionary<int, int> Div_CladdingSizeList { get; set; } //cladding Reinf Sizes
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
        public ShootboltReverse_ArticleNo Div_ShootboltReverseArtNo { get; set; }
        public DummyMullionStriker_ArticleNo Div_DMStrikerArtNo { get; set; }

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

                if (Div_DMArtNo == DummyMullion_ArticleNo._7533)
                {
                    Div_EndcapDM = EndcapDM_ArticleNo._K7533;
                }
                else if (Div_DMArtNo == DummyMullion_ArticleNo._385P)
                {
                    Div_EndcapDM = EndcapDM_ArticleNo._K385;

                    #region Algo for dummy mullion striker

                    int indx = Div_MPanelParent.MPanelLst_Objects.FindIndex(div => div.Name == Div_Name);
                    int prev_div_indx = 0, nxt_div_indx = 0,
                        obj_count = Div_MPanelParent.GetCount_MPanelLst_Object();
                    bool allow_dmStriker = true;

                    IDividerModel prev_div = null, nxt_div = null;

                    if (indx > 1)
                    {
                        prev_div_indx = indx - 2;
                        string prev_div_name = Div_MPanelParent.MPanelLst_Objects[prev_div_indx].Name;
                        prev_div = Div_MPanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prev_div_name);

                        if ((prev_div.Div_LeverEspagVisibility == true && prev_div.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._631153) ||
                            prev_div.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._None &&
                            (Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374))
                        {
                            allow_dmStriker = false;
                        }

                        nxt_div_indx = indx + 2;
                        if (nxt_div_indx < obj_count)
                        {
                            string nxt_div_name = Div_MPanelParent.MPanelLst_Objects[nxt_div_indx].Name;
                            nxt_div = Div_MPanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxt_div_name);

                            if ((nxt_div.Div_LeverEspagVisibility == true && nxt_div.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._631153) ||
                                prev_div.Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._None)
                            {
                                allow_dmStriker = false;
                            }
                        }

                        if (allow_dmStriker)
                        {
                            Div_DMStrikerArtNo = DummyMullionStriker_ArticleNo._339395;
                        }
                    }
                    else if (indx == 1)
                    {
                        if ((Div_LeverEspagVisibility == true && Div_LeverEspagArtNo != LeverEspagnolette_ArticleNo._631153) &&
                             Div_LeverEspagArtNo != LeverEspagnolette_ArticleNo._None &&
                            (Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373 ||
                             Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374))
                        {
                            Div_DMStrikerArtNo = DummyMullionStriker_ArticleNo._339395;
                        }
                    }

                    #endregion
                }

                if (Div_DMPanel != null)
                {
                    Div_ShootboltNonReverseArtNo = ShootboltNonReverse_ArticleNo._349187;
                    Div_ShootboltReverseArtNo = ShootboltReverse_ArticleNo._312033;
                    Div_ShootboltStrikerArtNo = ShootboltStriker_ArticleNo._N705A20106;

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
                    }
                }
            }

            if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
            {
                Div_Bounded = "Frame";
                if (Div_Type == DividerType.Mullion)
                {
                    if (Div_ChkDM == true && Div_DMPanel != null)
                    {
                        Div_ExplosionHeight = (Div_DMPanel.Panel_SashHeight - (38 * 2)) - 5;
                        Div_AlumSpacer50Qty = (int)(Math.Ceiling(((decimal)Div_ExplosionHeight / 300)) - 2);
                    }
                    else if (Div_ChkDM == false)
                    {
                        if (Div_ArtNo == Divider_ArticleNo._7536 || Div_ArtNo == Divider_ArticleNo._2069)
                        {
                            Div_ExplosionHeight = (Div_DisplayHeight - (frame_deduction * 2)) + 3; //3 = (1.5 * 2)
                        }
                        else if (Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            Div_ExplosionHeight = (Div_DisplayHeight - (frame_deduction * 2)) + (4 * 2);
                        }

                        if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677 || Div_ReinfArtNo == DividerReinf_ArticleNo._V226)
                        {
                            Div_ReinfHeight = (Div_ExplosionHeight - (35 * 2)) - (5 * 2);
                        }
                        else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                        {
                            Div_ReinfHeight = (Div_ExplosionHeight - (50 * 2)) - (5 * 2);
                        }

                        //Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                        //Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                    }
                }
                else if (Div_Type == DividerType.Transom)
                {
                    if (Div_ArtNo == Divider_ArticleNo._7536 || Div_ArtNo == Divider_ArticleNo._2069)
                    {
                        Div_ExplosionWidth = (Div_DisplayWidth - (frame_deduction * 2)) + 3; //3 = (1.5 * 2)
                    }
                    else if (Div_ArtNo == Divider_ArticleNo._7538)
                    {
                        Div_ExplosionWidth = (Div_DisplayWidth - (frame_deduction * 2)) + (4 * 2);
                    }

                    if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677 || Div_ReinfArtNo == DividerReinf_ArticleNo._V226)
                    {
                        Div_ReinfWidth = (Div_ExplosionWidth - (35 * 2)) - (5 * 2);
                    }
                    else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                    {
                        Div_ReinfWidth = (Div_ExplosionWidth - (50 * 2)) - (5 * 2);
                    }

                    //Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                    //Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
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
                        try
                        {
                            nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                            div_bot = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);

                            top_deduction = 0;
                            if (div_bot.Div_ArtNo == Divider_ArticleNo._7536 || div_bot.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                bot_deduction = (42 / 2) + frame_deduction;
                            }
                            else if (div_bot.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                bot_deduction = (72 / 2) + frame_deduction;
                            }
                        }
                        catch (Exception)
                        {

                        }
                       
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Somewhere in Between")
                    {
                        Div_Bounded = "Transom";
                        try
                        {
                            nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                            prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;

                            div_top = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);
                            div_bot = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);

                            if (div_top.Div_ArtNo == Divider_ArticleNo._7536 || div_top.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                top_deduction = 42 / 2;
                            }
                            else if (div_top.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                top_deduction = 72 / 2;
                            }

                            if (div_bot.Div_ArtNo == Divider_ArticleNo._7536 || div_bot.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                bot_deduction = 42 / 2;
                            }
                            else if (div_bot.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                bot_deduction = 72 / 2;
                            }
                        }
                        catch (Exception)
                        {

                        }
                      
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Last")
                    {
                        Div_Bounded = "Frame&Transom";

                        prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;
                        div_top = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);
                        bot_deduction = 0;

                        if (div_top.Div_ArtNo == Divider_ArticleNo._7536 || div_top.Div_ArtNo == Divider_ArticleNo._2069)
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
                        if (Div_ChkDM == true && Div_DMPanel != null)
                        {
                            Div_ExplosionHeight = (Div_DMPanel.Panel_SashHeight - (38 * 2)) - 5;
                            Div_AlumSpacer50Qty = (int)(Math.Ceiling(((decimal)Div_ExplosionHeight / 300)) - 2);
                        }
                        else if (Div_ChkDM == false)
                        {
                            if (Div_ArtNo == Divider_ArticleNo._7536 || Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                Div_ExplosionHeight = (Div_DisplayHeight - (top_deduction + bot_deduction)) + 3; //3 = (1.5 * 2)
                            }
                            else if (Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                Div_ExplosionHeight = (Div_DisplayHeight - (top_deduction + bot_deduction)) + (4 * 2);
                            }

                            if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677 || Div_ReinfArtNo == DividerReinf_ArticleNo._V226)
                            {
                                Div_ReinfHeight = (Div_ExplosionHeight - (35 * 2)) - (5 * 2);
                            }
                            else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                            {
                                Div_ReinfHeight = (Div_ExplosionHeight - (50 * 2)) - (5 * 2);
                            }

                            //Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                            //Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
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
                        try
                        {
                            nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                            div_right = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);
                            left_deduction = 0;

                            if (div_right.Div_ArtNo == Divider_ArticleNo._7536 || div_right.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                right_deduction = (42 / 2) + frame_deduction;
                            }
                            else if (div_right.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                right_deduction = (72 / 2) + frame_deduction;
                            }
                        }
                        catch (Exception)
                        {

                        }
                      
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Somewhere in Between")
                    {
                        Div_Bounded = "Mullion";

                        try
                        {
                            nxtctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx + 1].Name;
                            div_right = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == nxtctrl_name);
                            prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;
                            div_left = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);

                            if (div_right.Div_ArtNo == Divider_ArticleNo._7536 || div_right.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                right_deduction = 42 / 2;
                            }
                            else if (div_right.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                right_deduction = 72 / 2;
                            }

                            if (div_left.Div_ArtNo == Divider_ArticleNo._7536 || div_left.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                left_deduction = 42 / 2;
                            }
                            else if (div_left.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                left_deduction = 72 / 2;
                            }
                        }
                        catch (Exception)
                        {
                        }    
                    
                    }
                    else if (Div_MPanelParent.MPanel_Placement == "Last")
                    {
                        Div_Bounded = "Frame&Mullion";
                        try
                        {
                            prevctrl_name = parent_mpanelParent.MPanelLst_Objects[parent_ndx - 1].Name;
                            div_left = parent_mpanelParent.MPanelLst_Divider.Find(div => div.Div_Name == prevctrl_name);
                            right_deduction = 0;

                            if (div_left.Div_ArtNo == Divider_ArticleNo._7536 || div_left.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                left_deduction = (42 / 2) + frame_deduction;
                            }
                            else if (div_left.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                left_deduction = (72 / 2) + frame_deduction;
                            }
                        }
                        catch (Exception)
                        {

                        }
               
                    }

                    if (Div_Type == DividerType.Transom)
                    {
                        if (Div_ArtNo == Divider_ArticleNo._7536 || Div_ArtNo == Divider_ArticleNo._2069)
                        {
                            Div_ExplosionWidth = (Div_DisplayWidth - (left_deduction + right_deduction)) + 3; //3 = (1.5 * 2)
                        }
                        else if (Div_ArtNo == Divider_ArticleNo._7538)
                        {
                            Div_ExplosionWidth = (Div_DisplayWidth - (left_deduction + right_deduction)) + (4 * 2);
                        }

                        if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677 || Div_ReinfArtNo == DividerReinf_ArticleNo._V226)
                        {
                            Div_ReinfWidth = (Div_ExplosionWidth - (35 * 2)) - (5 * 2);
                        }
                        else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                        {
                            Div_ReinfWidth = (Div_ExplosionWidth - (50 * 2)) - (5 * 2);
                        }

                        //Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                        //Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
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
            else if (mode == "addCladdingArtNo")
            {
                Div_PropHeight += constants.div_property_claddingArtNoOptionsHeight;
            }
            else if (mode == "minusCladdingArtNo")
            {
                Div_PropHeight -= constants.div_property_claddingArtNoOptionsHeight;
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

        #region MaterialList

        public void Insert_DivProfile_DivReinf_Info_MaterialList(DataTable tbl_explosion)
        {
            string div_side = "", explosion_length = "", explosion_length2 = "";
            if (Div_Type == DividerType.Transom)
            {
                div_side = "Width";
                explosion_length = Div_ExplosionWidth.ToString();
                explosion_length2 = Div_ReinfWidth.ToString();
            }
            else if (Div_Type == DividerType.Mullion)
            {
                div_side = "Height";
                explosion_length = Div_ExplosionHeight.ToString();
                explosion_length2 = Div_ReinfHeight.ToString();
            }

            tbl_explosion.Rows.Add(Div_Type.ToString() + " " + div_side + " " + Div_ArtNo.DisplayName,
                                   1, "pc(s)",
                                   explosion_length,
                                   Div_Bounded,
                                   @"[  ]");

            tbl_explosion.Rows.Add(Div_Type.ToString() + " Reinforcement " + div_side + " " + Div_ReinfArtNo.DisplayName,
                                   1, "pc(s)",
                                   explosion_length2,
                                   Div_Type.ToString(),
                                   @"|  |");
        }

        public void Insert_MechJoint_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add(Div_Type.ToString() + " Mechanical Joint " + Div_MechJoinArtNo.DisplayName,
                                   2, "pc(s)", "");
        }

        public void Insert_CladdingProfile_MaterialList(DataTable tbl_explosion)
        {
            if(Div_CladdingSizeList != null)
            {
                foreach (int cladding_size in Div_CladdingSizeList.Values)
                {
                    tbl_explosion.Rows.Add("Cladding Profile " + Div_CladdingProfileArtNo.ToString(),
                                           1, "pc(s)",
                                           cladding_size.ToString(),
                                           Div_Type.ToString(),
                                           @"|  |");

                    int claddingReinSize = cladding_size - 30;
                    tbl_explosion.Rows.Add("Cladding Reinforcement " + Div_CladdingReinfArtNo.ToString(),
                                           1, "pc(s)",
                                           claddingReinSize.ToString(),
                                           "CPL",
                                           @"|  |");
                }
            }
           
        }

        public void Insert_CladdingBracket4Concrete_MaterialList(DataTable tbl_explosion)
        {
            if (Div_CladdingBracketForConcreteQTY > 0)
            {
                tbl_explosion.Rows.Add("Bracket for concrete (10mm)",
                                       Div_CladdingBracketForConcreteQTY, "pc(s)",
                                       "",
                                       "CPL",
                                       @"|  |");
            }
        }

        public void Insert_CladdingBracket4UPVC_MaterialList(DataTable tbl_explosion)
        {
            if (Div_CladdingBracketForUPVCQTY > 0)
            {
                tbl_explosion.Rows.Add("Bracket for upvc(5mm)",
                                       Div_CladdingBracketForUPVCQTY, "pc(s)",
                                       "",
                                       "CPL",
                                       @"|  |");
            }
        }

        public void Insert_DummyMullion_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Dummy Mullion Height " + Div_DMArtNo.DisplayName,
                                   1, "pc(s)",
                                   Div_ExplosionHeight.ToString(),
                                   Div_Bounded,
                                   @"[  ]");
        }

        public void Insert_Endcap4DM_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Endcap for Dummy Mullion " + Div_EndcapDM.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Dummy Mullion");
        }

        public void Insert_DMStriker_MaterialList(DataTable tbl_explosion)
        {
            if (Div_DMStrikerArtNo != null)
            {
                tbl_explosion.Rows.Add("Dummy Mullion Striker " + Div_DMStrikerArtNo.DisplayName,
                                       4, "pc(s)",
                                       "",
                                       "Frame",
                                       " ");
            }
        }

        public void Insert_FixedCam_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Fixed cam " + Div_FixedCamDM.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash");
        }

        public void Insert_SnapNKeep_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Snap-in Keep " + Div_SnapNKeepDM.ToString(),
                                   2, "pc(s)",
                                   "",
                                   "Frame");
        }

        public void Insert_AlumSpacer_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Aluminum spacer for Dummy Mullion FC770 (80mm)",
                                   2, "pc(s)",
                                   "",
                                   "Dummy Mullion");
            tbl_explosion.Rows.Add("Aluminum spacer for Dummy Mullion FC770 (50mm)",
                                   Div_AlumSpacer50Qty, "pc(s)",
                                   "",
                                   "Dummy Mullion");
        }

        public void Insert_LeverEspag_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Lever Espagnolette " + Div_LeverEspagArtNo.DisplayName,
                                    1, "pc(s)",
                                    "",
                                    "Dummy Mullion");
        }



        public void Insert_ShootboltStriker_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Shootbolt striker " + Div_ShootboltStrikerArtNo.DisplayName,
                                   2, "pc(s)",
                                   "",
                                   "Sash");
        }

        public void Insert_ShootboltReverse_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Shootbolt, Reverse " + Div_ShootboltReverseArtNo.DisplayName,
                                   1, "pc(s)",
                                   "",
                                   "Sash");
        }

        public void Insert_ShootboltNonReverse_MaterialList(DataTable tbl_explosion)
        {
            tbl_explosion.Rows.Add("Shootbolt, non-reverse " + Div_ShootboltNonReverseArtNo.DisplayName,
                                   3, "pc(s)",
                                   "",
                                   "Sash & DM");
        }


        public int Add_ExplosionLength_screws4fab()
        {
            int explosionLength_screws = 0;

            if (Div_Type == DividerType.Transom)
            {
                explosionLength_screws += Div_ExplosionWidth;
            }
            else if (Div_Type == DividerType.Mullion)
            {
                explosionLength_screws += Div_ExplosionHeight;
            }

            return explosionLength_screws;
        }

        public int Add_MechJoint_screws4fab()
        {
            int mj_screws = 0;

            if (Div_MechJoinArtNo == Divider_MechJointArticleNo._AV585)
            {
                mj_screws += (2 * 2); //qty * 2
            }

            return mj_screws;
        }

        public int Add_TotalCladdingSize_Screws4Cladding()
        {
            int total_clad = 0;

            if (Div_CladdingSizeList != null)
            {
                foreach (int cladding_size in Div_CladdingSizeList.Values)
                {
                    total_clad += cladding_size;
                }

                return total_clad;
            }
            return total_clad;
        }

        public int Add_CladdingBracket4Concrete_screws4fab()
        {
            int cladConcrete_screws = 0;

            if (Div_claddingBracketVisibility == true)
            {
                if (Div_CladdingBracketForConcreteQTY > 0)
                {
                    cladConcrete_screws += (Div_CladdingBracketForConcreteQTY * 3);
                }
            }

            return cladConcrete_screws;
        }

        public int Add_CladdingBracket4UPVC_screws4fab()
        {
            int cladUPVC_screws = 0;

            if (Div_claddingBracketVisibility == true)
            {
                if (Div_CladdingBracketForUPVCQTY > 0)
                {
                    cladUPVC_screws += (Div_CladdingBracketForUPVCQTY * 3);
                }
            }

            return cladUPVC_screws;
        }

        public int Add_DMStriker_screws4fab()
        {
            int dmStriker_screws = 0;
            if (Div_DMArtNo == DummyMullion_ArticleNo._385P)
            {
                if (Div_DMStrikerArtNo != null)
                {
                    dmStriker_screws += 8;
                }
            }

            return dmStriker_screws;
        }

        public int Add_EndCapDM_screws4fab()
        {
            int endcap_screws = 0;

            if (Div_EndcapDM == EndcapDM_ArticleNo._K385 ||
                Div_EndcapDM == EndcapDM_ArticleNo._K7533)
            {
                endcap_screws += 2;
            }

            return endcap_screws;
        }

        public int Add_SnapNKeep_screws4fab()
        {
            int snap_screws = 0;

            if (Div_SnapNKeepDM == SnapInKeep_ArticleNo._0400205 ||
                Div_SnapNKeepDM == SnapInKeep_ArticleNo._0400215)
            {
                snap_screws += (2 * 2); //2 * 2pcs
            }

            return snap_screws;
        }


        public int Add_AlumSpacer_screws4fab()
        {
            int alumSpacer_screws = 0;

            alumSpacer_screws += (3 * 2); //3 * 2pcs (80mm)
            alumSpacer_screws += (3 * Div_AlumSpacer50Qty); //3 (50mm)

            return alumSpacer_screws;
        }

        public int Add_LeverEspag_screws4fab()
        {
            int leverEspag_screws = 0;

            if (Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._631153)
            {
                leverEspag_screws += 3; //Lever Espagnolette
            }
            else if (Div_LeverEspagArtNo == LeverEspagnolette_ArticleNo._476518)
            {
                leverEspag_screws += 3; //Lever Espagnolette
            }
            else
            {
                leverEspag_screws += 8; //Lever Espagnolette
            }

            return leverEspag_screws;
        }

        public int Add_CladdBracket4Concrete_expbolts()
        {
            int cladConcrete_xpbolts = 0;

            if (Div_claddingBracketVisibility == true)
            {
                if (Div_CladdingBracketForConcreteQTY > 0)
                {
                    cladConcrete_xpbolts += Div_CladdingBracketForConcreteQTY;
                }
            }

            return cladConcrete_xpbolts;
        }

        public int Add_CladdBracket4UPVC_expbolts()
        {
            int cladUPVC_xpbolts = 0;

            if (Div_claddingBracketVisibility == true)
            {
                if (Div_CladdingBracketForUPVCQTY > 0)
                {
                    cladUPVC_xpbolts += Div_CladdingBracketForUPVCQTY;
                }
            }

            return cladUPVC_xpbolts;
        }




        #endregion

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
