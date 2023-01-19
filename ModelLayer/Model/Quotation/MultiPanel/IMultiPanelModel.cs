using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;

namespace ModelLayer.Model.Quotation.MultiPanel
{
    public interface IMultiPanelModel
    {
        int MPanel_ID { get; set; }
        string MPanel_Name { get; set; }
        string MPanel_Type { get; set; }
        DockStyle MPanel_Dock { get; set; }
        int MPanel_Width { get; set; }
        int MPanelImageRenderer_Width { get; set; }
        int MPanel_Height { get; set; }
        int MPanelImageRenderer_Height { get; set; }
        int MPanel_HeightToBind { get; set; }
        int MPanel_HeightToBindPrev { get; set; }
        int MPanelImager_HeightToBindPrev { get; set; }
        FlowDirection MPanel_FlowDirection { get; set; }
        bool MPanel_Visibility { get; set; }
        int MPanel_Divisions { get; set; }
        int MPanel_Index_Inside_MPanel { get; set; }
        int MPanelProp_Height { get; set; }
        string MPanel_Placement { get; set; }
        IMultiPanelModel MPanel_ParentModel { get; set; }
        bool MPanel_DividerEnabled { get; set; }
        float MPanelImageRenderer_Zoom { get; set; }
        Control MPanel_Parent { get; set; }
        UserControl MPanel_FrameGroup { get; set; }
        IFrameModel MPanel_FrameModelParent { get; set; }
        Padding MPanel_Margin { get; set; }
        Padding MPanelImageRenderer_Margin { get; set; }
        List<IPanelModel> MPanelLst_Panel { get; set; }
        List<IDividerModel> MPanelLst_Divider { get; set; }
        List<IMultiPanelModel> MPanelLst_MultiPanel { get; set; }
        List<Control> MPanelLst_Objects { get; set; }
        List<Control> MPanelLst_Imagers { get; set; }
        float MPanel_Zoom { get; set; }
        int MPanel_WidthToBind { get; set; }
        int MPanel_WidthToBindPrev { get; set; }
        int MPanelImager_WidthToBindPrev { get; set; }
        int MPanel_AddPixel { get; }
        int MPanel_DisplayWidth { get; set; }
        int MPanel_DisplayWidthDecimal { get; set; }
        int MPanel_DisplayHeight { get; set; }
        int MPanel_DisplayHeightDecimal { get; set; }
        int MPanel_StackNo { get; set; }
        bool MPanel_NumEnable { get; set; }
        int GetNextIndex();
        int GetCount_MPanelLst_Object();

        void SetDimensions_childPanelObjs(int divmovement);
        void ImagerSetDimensions_childPanelObjs(int divmovement);
        void SetDimensions_PanelObjs_of_3rdLevelMPanel(int divmovement, string prevOrNxt);
        void Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(int divmovement, string prevOrNxt);
        void SetDimensions_childObjs(int divmovement = 0, string prevOrNxt = "");
        void SetDimensionsToBind_MullionDivMovement();
        void Imager_SetDimensionsToBind_MullionDivMovement(int divMovement);
        void SetDimensionsToBind_TransomDivMovement();
        void Imager_SetDimensionsToBind_TransomDivMovement(int divMovement);
        void SetDimensionsToBind_using_ParentMultiPanelModel();
        void Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
        void Imager_SetDimensionsToBind_using_ParentMultiPanelModel_Initial();
        void Adapt_sizeToBind_MPanelDivMPanel_Controls(Control current_control,
                                                       string frameType,
                                                       bool if_auto_added = false);
        void SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
        void SetDimensionsToBind_using_ZoomPercentage();
        void Imager_SetDimensionsToBind_using_ZoomPercentage();
        void Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
        void Set_DimensionToBind_using_FrameDimensions();
        void Imager_Set_DimensionToBind_using_FrameDimensions();
        void SetImageZoomDivider();
        void SetZoomDivider();
        void SetZoomPanels();
        void SetZoomMPanels();
        void Reload_PanelMargin();
        void Reload_MultiPanelMargin();
        void AddControl_MPanelLstObjects(Control control,
                                         string frameType,
                                         bool if_auto_added = false);
        void DeleteControl_MPanelLstObjects(Control control, string frameType, string placement = "");
        void Fit_MyControls_ToBindDimensions();
        void Fit_MyControls_ImagersToBindDimensions();
        void Fit_MyControls_Dimensions();
        void Object_Indexer();
        void Adjust_ControlDisplaySize();
        IEnumerable<Control> GetVisibleObjects();

        #region Explosion

        int MPanel_OriginalDisplayWidth { get; set; }
        int MPanel_OriginalDisplayWidthDecimal { get; set; }
        int MPanel_OriginalDisplayHeight { get; set; }
        int MPanel_OriginalDisplayHeightDecimal { get; set; }
        int MPanel_OriginalGlassWidth { get; set; }
        int MPanel_OriginalGlassWidthDecimal { get; set; }
        int MPanel_OriginalGlassHeight { get; set; }
        int MPanel_OriginalGlassHeightDecimal { get; set; }
        bool MPanel_CmenuDeleteVisibility { get; set; }
        bool MPanel_GlassBalanced { get; set; }

        void SetEqualGlassDimension(string mode, SashProfile_ArticleNo sash);

        void SetMPanelExplosionValues_Panel(Divider_ArticleNo divNxt_artNo,
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
        void AdjustPropertyPanelHeight(string objtype, string mode);
        void DeductPropertyPanelHeight(int propertyHeight);
        void Fit_My2ndLvlControls_Dimensions();
        void Fit_MyControls_ToBindDimensions(IMultiPanelModel prev_mpanel, IMultiPanelModel nxt_mpnl, IPanelModel prev_pnl, IPanelModel nxt_pnl);
        void Fit_EqualPanel_ToBindDimensions();
        void Fit_DisplayDimensions();
        void Fit_PanelDimensions();
        bool isDisplaySizeEqual();
        void Fit_MyControls_ImagersToBindDimensions(IMultiPanelModel prev_mpanel, IMultiPanelModel nxt_mpnl, IPanelModel prev_pnl, IPanelModel nxt_pnl);

        #endregion
    }
}