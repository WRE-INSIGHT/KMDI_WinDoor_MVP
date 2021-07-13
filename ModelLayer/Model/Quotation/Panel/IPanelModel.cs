using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
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
        int Panel_OriginalHeight { get; set; }
        int PanelImageRenderer_Height { get; set; }
        int Panel_HeightToBind { get; set; }
        int Panel_DisplayHeight { get; set; }
        int Panel_OriginalDisplayHeight { get; set; }
        int Panel_ID { get; set; }
        string Panel_Name { get; set; }
        bool Panel_Orient { get; set; }
        string Panel_Type { get; set; }
        int Panel_Width { get; set; }
        int Panel_OriginalWidth { get; set; }
        int PanelImageRenderer_Width { get; set; }
        int Panel_WidthToBind { get; set; }
        int Panel_DisplayWidth { get; set; }
        int Panel_OriginalDisplayWidth { get; set; }
        bool Panel_Visibility { get; set; }
        float PanelImageRenderer_Zoom { get; set; }
        int Panel_Index_Inside_MPanel { get; set; }
        string Panel_Placement { get; set; }
        Padding Panel_Margin { get; set; }
        Padding Panel_MarginToBind { get; set; }
        float Panel_Zoom { get; set; }
        IFrameModel Panel_ParentFrameModel { get; set; }
        IMultiPanelModel Panel_ParentMultiPanelModel { get; set; }
        int Panel_PropertyHeight { get; set; }
        bool Panel_HandleOptionsVisibility { get; set; }
        bool Panel_RotoswingOptionsVisibility { get; set; }
        bool Panel_RotaryOptionsVisibility { get; set; }
        int Panel_HandleOptionsHeight { get; set; }
        #region Explosion

        int PanelGlass_ID { get; set; }
        string Panel_GlassThicknessDesc { get; set; }
        float Panel_GlassThickness { get; set; }
        GlazingBead_ArticleNo PanelGlazingBead_ArtNo { get; set; }
        int Panel_GlazingBeadWidth { get; set; }
        int Panel_GlazingBeadHeight { get; set; }
        int Panel_GlassWidth { get; set; }
        int Panel_OriginalGlassWidth { get; set; }
        int Panel_GlassHeight { get; set; }
        int Panel_OriginalGlassHeight { get; set; }
        int Panel_GlazingSpacerQty { get; set; }
        GlassFilm_Types Panel_GlassFilm { get; set; }
        bool Panel_SashPropertyVisibility { get; set; }
        SashProfile_ArticleNo Panel_SashProfileArtNo { get; set; }
        SashReinf_ArticleNo Panel_SashReinfArtNo { get; set; }
        int Panel_SashWidth { get; set; }
        int Panel_SashHeight { get; set; }
        int Panel_OriginalSashWidth { get; set; }
        int Panel_OriginalSashHeight { get; set; }
        int Panel_SashReinfWidth { get; set; }
        int Panel_SashReinfHeight { get; set; }

        CoverProfile_ArticleNo Panel_CoverProfileArtNo { get; set; }
        CoverProfile_ArticleNo Panel_CoverProfileArtNo2 { get; set; }
        FrictionStay_ArticleNo Panel_FrictionStayArtNo { get; set; }
        SnapInKeep_ArticleNo Panel_SnapInKeepArtNo { get; set; }
        Handle_Type Panel_HandleType { get; set; }
        Rotoswing_HandleArtNo Panel_RotoswingArtNo { get; set; }
        Rotary_HandleArtNo Panel_RotaryArtNo { get; set; }
        Espagnolette_ArticleNo Panel_EspagnoletteArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionArtNo { get; set; }
        CornerDrive_ArticleNo Panel_CornerDriveArtNo { get; set; }
        bool Panel_ExtensionCornerDriveOptionsVisibility { get; set; }
        int Panel_RotoswingOptionsHeight { get; set; }
        int Panel_PlasticWedgeQty { get; set; }
        Striker_ArticleNo Panel_StrikerArtno { get; set; }
        MiddleCloser_ArticleNo Panel_MiddleCloserArtNo { get; set; }
        LockingKit_ArticleNo Panel_LockingKitArtNo { get; set; }
        GlassType Panel_GlassType { get; set; }

        int Panel_StrikerQty { get; set; }
        int Panel_MiddleCloserPairQty { get; set; }
        bool Panel_MotorizedOptionVisibility { get; set; }
        MotorizedMech_ArticleNo Panel_MotorizedMechArtNo { get; set; }
        int Panel_MotorizedMechQty { get; set; }
        bool Panel_MotorizedpnlOptionVisibility { get; set; }
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