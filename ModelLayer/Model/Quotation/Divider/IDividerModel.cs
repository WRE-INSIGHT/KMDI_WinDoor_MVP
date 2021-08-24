using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Divider
{
    public interface IDividerModel
    {
        int Div_Height { get; set; }
        int DivImageRenderer_Height { get; set; }
        int Div_ID { get; set; }
        string Div_Name { get; set; }
        Control Div_Parent { get; set; }
        DividerModel.DividerType Div_Type { get; set; }
        bool Div_Visible { get; set; }
        int Div_Width { get; set; }
        int DivImageRenderer_Width { get; set; }
        string Div_FrameType { get; set; }
        float DivImageRenderer_Zoom { get; set; }
        float Div_Zoom { get; set; }
        int Div_WidthToBind { get; set; }
        int Div_HeightToBind { get; set; }
        int Div_DisplayWidth { get; set; }
        int Div_DisplayHeight { get; set; }
        int Div_PropHeight { get; set; }
        int Div_CladdingBracketForUPVC { get; set; }
        int Div_CladdingBracketForConcrete { get; set; }
        bool Div_claddingBracketVisibility { get; set; }

        bool Div_ChkDM { get; set; }
        bool Div_ChkDMVisibility { get; set; }
        bool Div_ArtVisibility { get; set; }
        IMultiPanelModel Div_MPanelParent { get; set; }
        IFrameModel Div_FrameParent { get; set; }

        #region Explosion

        Divider_ArticleNo Div_ArtNo { get; set; }
        DividerReinf_ArticleNo Div_ReinfArtNo { get; set; }
        Divider_MechJointArticleNo Div_MechJoinArtNo { get; set; }

        int Div_ExplosionWidth { get; set; }
        int Div_ExplosionHeight { get; set; }
        int Div_ReinfWidth { get; set; }
        int Div_ReinfHeight { get; set; }
        string Div_Bounded { get; set; }


        CladdingProfile_ArticleNo Div_CladdingProfileArtNo { get; set; }
        CladdingReinf_ArticleNo Div_CladdingReinfArtNo { get; set; }
        Dictionary<int, int> Div_CladdingSizeList { get; set; }

        void SetExplosionValues_Div();
        void AdjustPropertyPanelHeight(string mode);

        #endregion
    }
}