using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.QuotationModel;

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

        public IMultiPanelModel Div_MPanelParent { get; set; }
        public IFrameModel Div_FrameParent { get; set; }

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
        public List<int> Div_CladdingSizeList { get; set; }

        public int Div_CladdingProfileSize { get; set; }

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

        public void SetExplosionValues_Div()
        {
            const int frame_deduction = 33;

            if (Div_MPanelParent.MPanel_Parent.Name.Contains("Frame"))
            {
                Div_Bounded = "Frame";
                if (Div_Type == DividerType.Mullion)
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

                    if (Div_ExplosionHeight >= 2000)
                    {
                        Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                        Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                        Div_CladdingProfileSize = Div_ExplosionHeight + 30;
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

                    if (Div_ExplosionWidth >= 2000)
                    {
                        Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                        Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                        Div_CladdingProfileSize = Div_ExplosionWidth + 30;
                    }
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

                        if (Div_ExplosionHeight >= 2000)
                        {
                            Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                            Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                            Div_CladdingProfileSize = Div_ExplosionHeight + 30;
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

                        if (Div_ExplosionWidth >= 2000)
                        {
                            Div_CladdingProfileArtNo = CladdingProfile_ArticleNo._1338;
                            Div_CladdingReinfArtNo = CladdingReinf_ArticleNo._9120;
                            Div_CladdingProfileSize = Div_ExplosionWidth + 30;
                        }
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
                            List<int> divCladdingSizeList,
                            IFrameModel divFrameParent)
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

            Div_PropHeight = constants.div_propertyheight_default;
        }
    }
}
