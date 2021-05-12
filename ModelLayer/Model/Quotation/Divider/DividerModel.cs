using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ModelLayer.Model.Quotation.Divider
{
    public class DividerModel : IDividerModel, INotifyPropertyChanged
    {
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
                SetPanelExplosionValues_Div();
            }
        }

        public DividerReinf_ArticleNo Div_ReinfArtNo { get; set; }

        public int Div_ExplosionWidth { get; set; }
        public int Div_ExplosionHeight { get; set; }
        public int Div_ReinfWidth { get; set; }
        public int Div_ReinfHeight { get; set; }

        public Divider_MechJointArticleNo Div_MechJoinArtNo { get; set; }

        private void SetPanelExplosionValues_Div()
        {
            if (Div_Type == DividerType.Mullion)
            {
                if (Div_ArtNo == Divider_ArticleNo._7536)
                {
                    Div_ExplosionHeight = (Div_DisplayHeight - (33 * 2)) + 3; //3 = (1.5 * 2)
                }
                else if (Div_ArtNo == Divider_ArticleNo._7538)
                {
                    Div_ExplosionHeight = (Div_DisplayHeight - (33 * 2)) + (4 * 2);
                }

                if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677)
                {
                    Div_ReinfHeight = (Div_ExplosionHeight - (35 * 2)) - (5 * 2);
                }
                else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                {
                    Div_ReinfHeight = (Div_ExplosionHeight - (50 * 2)) - (5 * 2);
                }
            }
            else if (Div_Type == DividerType.Transom)
            {
                if (Div_ArtNo == Divider_ArticleNo._7536)
                {
                    Div_ExplosionWidth = (Div_DisplayWidth - (33 * 2)) + 3; //3 = (1.5 * 2)
                }
                else if (Div_ArtNo == Divider_ArticleNo._7538)
                {
                    Div_ExplosionWidth = (Div_DisplayWidth - (33 * 2)) + (4 * 2);
                }

                if (Div_ReinfArtNo == DividerReinf_ArticleNo._R677)
                {
                    Div_ReinfWidth = (Div_ExplosionWidth - (35 * 2)) - (5 * 2);
                }
                else if (Div_ReinfArtNo == DividerReinf_ArticleNo._R686)
                {
                    Div_ReinfWidth = (Div_ExplosionWidth - (50 * 2)) - (5 * 2);
                }
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
                            int divDisplayHeight)
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

            SetPanelExplosionValues_Div();
        }
    }
}
