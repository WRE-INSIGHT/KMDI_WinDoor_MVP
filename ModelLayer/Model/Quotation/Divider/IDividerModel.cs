using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.QuotationModel;

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

        #region Explosion

        Divider_ArticleNo Div_ArtNo { get; set; }
        DividerReinf_ArticleNo Div_ReinfArtNo { get; set; }

        int Div_ExplosionWidth { get; set; }
        int Div_ExplosionHeight { get; set; }
        int Div_ReinfWidth { get; set; }
        int Div_ReinfHeight { get; set; }

        #endregion
    }
}