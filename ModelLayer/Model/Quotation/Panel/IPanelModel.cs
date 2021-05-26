using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ModelLayer.Model.Quotation.Panel
{
    public interface IPanelModel
    {
        string Panel_ChkText { get; set; }
        DockStyle Panel_Dock { get; set; }
        Control Panel_Parent { get; set; }
        UserControl Panel_MultiPanelGroup { get; set; }
        UserControl Panel_FrameGroup { get; set; }
        UserControl Panel_FramePropertiesGroup { get; set; }
        int Panel_Height { get; set; }
        int PanelImageRenderer_Height { get; set; }
        int Panel_HeightToBind { get; set; }
        int Panel_DisplayHeight { get; set; }
        int Panel_ID { get; set; }
        string Panel_Name { get; set; }
        bool Panel_Orient { get; set; }
        string Panel_Type { get; set; }
        int Panel_Width { get; set; }
        int PanelImageRenderer_Width { get; set; }
        int Panel_WidthToBind { get; set; }
        int Panel_DisplayWidth { get; set; }
        bool Panel_Visibility { get; set; }
        float PanelImageRenderer_Zoom { get; set; }
        int Panel_Index_Inside_MPanel { get; set; }
        string Panel_Placement { get; set; }
        Padding Panel_Margin { get; set; }
        Padding Panel_MarginToBind { get; set; }
        float Panel_Zoom { get; set; }

        #region Explosion

        Glass_Thickness Panel_GlassThickness { get; set; }
        GlazingBead_ArticleNo PanelGlazingBead_ArtNo { get; set; }
        int Panel_GlazingBeadWidth { get; set; }
        int Panel_GlazingBeadHeight { get; set; }
        int Panel_GlassWidth { get; set; }
        int Panel_GlassHeight { get; set; }
        int Panel_GlazingSpacerQty { get; set; }

        void SetPanelExplosionValues_Panel(bool parentIsFrame);
        void SetPanelExplosionValues_Panel(Divider_ArticleNo div_artNo,
                                           Divider_ArticleNo divPrev_artNo,
                                           DividerType div_type,
                                           Divider_ArticleNo divArtNo_LeftorTop = null,
                                           Divider_ArticleNo divArtNo_RightorBot = null,
                                           string div_type_lvl3 = "",
                                           Divider_ArticleNo divArtNo_LeftorTop_lvl3 = null,
                                           Divider_ArticleNo divArtNo_RightorBot_lvl3 = null,
                                           string panel_placement = "",
                                           string mpanel_placement = "", //1st level
                                           string mpanelparent_placement = ""); //2nd level

        #endregion
    }
}