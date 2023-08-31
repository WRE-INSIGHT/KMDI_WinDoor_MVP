using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;

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
        int Panel_DisplayHeightDecimal { get; set; }
        int Panel_OriginalDisplayHeight { get; set; }
        int Panel_OriginalDisplayHeightDecimal { get; set; }
        int Panel_ID { get; set; }
        string Panel_Name { get; set; }
        bool Panel_Orient { get; set; }
        bool Panel_OrientVisibility { get; set; }
        bool Panel_fileLoad { get; set; }
        string Panel_Type { get; set; }
        int Panel_Width { get; set; }
        int Panel_OriginalWidth { get; set; }
        int PanelImageRenderer_Width { get; set; }
        int Panel_WidthToBind { get; set; }
        int Panel_DisplayWidth { get; set; }
        int Panel_DisplayWidthDecimal { get; set; }
        int Panel_OriginalDisplayWidth { get; set; }
        int Panel_OriginalDisplayWidthDecimal { get; set; }
        bool Panel_Visibility { get; set; }
        float PanelImageRenderer_Zoom { get; set; }
        int Panel_Index_Inside_MPanel { get; set; }
        int Panel_Index_Inside_SPanel { get; set; }
        string Panel_Placement { get; set; }
        OverlapSash Panel_Overlap_Sash { get; set; }
        Padding Panel_Margin { get; set; }
        Padding Panel_MarginToBind { get; set; }
        Padding PanelImageRenderer_Margin { get; set; }
        float Panel_Zoom { get; set; }
        IFrameModel Panel_ParentFrameModel { get; set; }
        IMultiPanelModel Panel_ParentMultiPanelModel { get; set; }
        int Panel_PropertyHeight { get; set; }
        bool Panel_HandleOptionsVisibility { get; set; }
        bool Panel_RotoswingOptionsVisibility { get; set; }
        bool Panel_RioOptionsVisibility { get; set; }
        bool Panel_RioOptionsVisibility2 { get; set; }
        bool Panel_RotolineOptionsVisibility { get; set; }
        bool Panel_MVDOptionsVisibility { get; set; }
        bool Panel_RotaryOptionsVisibility { get; set; }
        int Panel_HandleOptionsHeight { get; set; }
        int Panel_LouverBladesCount { get; set; }
        bool Panel_LouverBladesVisibility { get; set; }
        Color Panel_BackColor { get; set; }

        #region Explosion

        int PanelGlass_ID { get; set; }
        string Panel_GlassThicknessDesc { get; set; }
        float Panel_GlassThickness { get; set; }
        GlazingBead_ArticleNo PanelGlazingBead_ArtNo { get; set; }
        GlazingAdaptor_ArticleNo Panel_GlazingAdaptorArtNo { get; set; }
        GBSpacer_ArticleNo Panel_GBSpacerArtNo { get; set; }
        Spacer_ArticleNo Panel_SpacerArtNo { get; set; }

        bool Panel_ChkGlazingAdaptor { get; set; }
        int Panel_GlazingBeadWidth { get; set; }
        int Panel_GlazingBeadWidthDecimal { get; set; }
        int Panel_GlazingBeadHeight { get; set; }
        int Panel_GlazingBeadHeightDecimal { get; set; }
        int Panel_GlassWidth { get; set; }
        int Panel_GlassWidthDecimal { get; set; }
        int Panel_OriginalGlassWidth { get; set; }
        int Panel_OriginalGlassWidthDecimal { get; set; }
        int Panel_GlassHeight { get; set; }
        int Panel_GlassHeightDecimal { get; set; }
        int Panel_OriginalGlassHeight { get; set; }
        int Panel_OriginalGlassHeightDecimal { get; set; }
        int Panel_GlassPropertyHeight { get; set; }
        int Panel_GlazingSpacerQty { get; set; }
        GlassFilm_Types Panel_GlassFilm { get; set; }
        bool Panel_GlassPnlGlazingBeadVisibility { get; set; }
        bool Panel_GlassPnlGlazingAdaptorVisibility { get; set; }
        bool Panel_SashPropertyVisibility { get; set; }
        SashProfile_ArticleNo Panel_SashProfileArtNo { get; set; }
        SashReinf_ArticleNo Panel_SashReinfArtNo { get; set; }
        int Panel_SashWidth { get; set; }
        int Panel_SashWidthDecimal { get; set; }
        int Panel_SashHeight { get; set; }
        int Panel_SashHeightDecimal { get; set; }
        int Panel_OriginalSashWidth { get; set; }
        int Panel_OriginalSashWidthDecimal { get; set; }
        int Panel_OriginalSashHeight { get; set; }
        int Panel_OriginalSashHeightDecimal { get; set; }
        int Panel_SashReinfWidth { get; set; }
        int Panel_SashReinfWidthDecimal { get; set; }
        int Panel_SashReinfHeight { get; set; }
        int Panel_SashReinfHeightDecimal { get; set; }

        CoverProfile_ArticleNo Panel_CoverProfileArtNo { get; set; }
        CoverProfile_ArticleNo Panel_CoverProfileArtNo2 { get; set; }
        FrictionStay_ArticleNo Panel_FrictionStayArtNo { get; set; }
        FrictionStayCasement_ArticleNo Panel_FSCasementArtNo { get; set; }
        SnapInKeep_ArticleNo Panel_SnapInKeepArtNo { get; set; }
        FixedCam_ArticleNo Panel_FixedCamArtNo { get; set; }
        _30x25Cover_ArticleNo Panel_30x25CoverArtNo { get; set; }
        MotorizedDivider_ArticleNo Panel_MotorizedDividerArtNo { get; set; }
        CoverForMotor_ArticleNo Panel_CoverForMotorArtNo { get; set; }
        _2DHinge_ArticleNo Panel_2dHingeArtNo { get; set; }
        PushButtonSwitch_ArticleNo Panel_PushButtonSwitchArtNo { get; set; }
        FalsePole_ArticleNo Panel_FalsePoleArtNo { get; set; }
        SupportingFrame_ArticleNo Panel_SupportingFrameArtNo { get; set; }
        Plate_ArticleNo Panel_PlateArtNo { get; set; }

        Handle_Type Panel_HandleType { get; set; }
        Rotoswing_HandleArtNo Panel_RotoswingArtNo { get; set; }
        Rotary_HandleArtNo Panel_RotaryArtNo { get; set; }
        Rio_HandleArtNo Panel_RioArtNo { get; set; }
        Rio_HandleArtNo Panel_RioArtNo2 { get; set; }
        ProfileKnobCylinder_ArtNo Panel_ProfileKnobCylinderArtNo { get; set; }
        Cylinder_CoverArtNo Panel_CylinderCoverArtNo { get; set; }

        Rotoline_HandleArtNo Panel_RotolineArtNo { get; set; }
        MVD_HandleArtNo Panel_MVDArtNo { get; set; }
        Espagnolette_ArticleNo Panel_EspagnoletteArtNo { get; set; }
        bool Panel_EspagnoletteOptionsVisibility { get; set; }

        Extension_ArticleNo Panel_ExtensionTopArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionTop2ArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionTop3ArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionBotArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionBot2ArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionLeftArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionLeft2ArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionRightArtNo { get; set; }
        Extension_ArticleNo Panel_ExtensionRight2ArtNo { get; set; }

        bool Panel_ExtTopChk { get; set; }
        bool Panel_ExtTop2Chk { get; set; }
        bool Panel_ExtBotChk { get; set; }
        bool Panel_ExtLeftChk { get; set; }

        bool Panel_ExtRightChk { get; set; }
        int Panel_ExtTopQty { get; set; }
        int Panel_ExtBotQty { get; set; }
        int Panel_ExtLeftQty { get; set; }
        int Panel_ExtRightQty { get; set; }

        int Panel_ExtTop2Qty { get; set; }
        int Panel_ExtTop3Qty { get; set; }
        int Panel_ExtBot2Qty { get; set; }
        int Panel_ExtLeft2Qty { get; set; }
        int Panel_ExtRight2Qty { get; set; }

        CornerDrive_ArticleNo Panel_CornerDriveArtNo { get; set; }
        bool Panel_CornerDriveOptionsVisibility { get; set; }
        bool Panel_ExtensionOptionsVisibility { get; set; }
        int Panel_RotoswingOptionsHeight { get; set; }
        PlasticWedge_ArticleNo Panel_PlasticWedge { get; set; }
        int Panel_PlasticWedgeQty { get; set; }
        MiddleCloser_ArticleNo Panel_MiddleCloserArtNo { get; set; }
        LockingKit_ArticleNo Panel_LockingKitArtNo { get; set; }
        GlassType Panel_GlassType { get; set; }
        string Panel_GlassType_Insu_Lami { get; set; }
        decimal Panel_GlassPricePerSqrMeter { get; set; }
        Striker_ArticleNo Panel_StrikerArtno_A { get; set; } //for Awning
        int Panel_StrikerQty_A { get; set; }

        Striker_ArticleNo Panel_StrikerArtno_C { get; set; } //for Casement
        int Panel_StrikerQty_C { get; set; }

        int Panel_MiddleCloserPairQty { get; set; }
        bool Panel_MotorizedOptionVisibility { get; set; }
        MotorizedMech_ArticleNo Panel_MotorizedMechArtNo { get; set; }
        MotorizedMechRemote_ArticleNo Panel_MotorizedMechRemoteArtNo { get; set; }
        bool Panel_MotorizedMechRemoteOption { get; set; }
        int Panel_MotorizedPropertyHeight { get; set; }
        int Panel_MotorizedMechQty { get; set; }
        int Panel_MultiFrmMotorizedMechQty { get; set; }
        int Panel_MotorizedMechSetQty { get; set; }
        int Panel_2DHingeQty { get; set; }
        _2DHinge_ArticleNo Panel_2dHingeArtNo_nonMotorized { get; set; }
        int Panel_2DHingeQty_nonMotorized { get; set; }
        bool Panel_2dHingeVisibility_nonMotorized { get; set; }
        _3dHinge_ArticleNo Panel_3dHingeArtNo { get; set; }
        int Panel_3dHingeQty { get; set; }
        bool Panel_3dHingePropertyVisibility { get; set; }
        ButtHinge_ArticleNo Panel_ButtHingeArtNo { get; set; }
        int Panel_ButtHingeQty { get; set; }
        bool Panel_2dHingeVisibility { get; set; }
        bool Panel_ButtHingeVisibility { get; set; }
        AdjustableStriker_ArticleNo Panel_AdjStrikerArtNo { get; set; }
        int Panel_AdjStrikerQty { get; set; }
        RestrictorStay_ArticleNo Panel_RestrictorStayArtNo { get; set; }
        int Panel_RestrictorStayQty { get; set; }

        int Panel_ExtensionPropertyHeight { get; set; }
        GeorgianBar_ArticleNo Panel_GeorgianBarArtNo { get; set; }
        int Panel_GeorgianBar_VerticalQty { get; set; }
        int Panel_GeorgianBar_HorizontalQty { get; set; }
        bool Panel_GeorgianBarOptionVisibility { get; set; }

        HingeOption Panel_HingeOptions { get; set; }
        int Panel_HingeOptionsPropertyHeight { get; set; }
        bool Panel_HingeOptionsVisibility { get; set; }
        CenterHingeOption Panel_CenterHingeOptions { get; set; }
        bool Panel_CenterHingeOptionsVisibility { get; set; }
        NTCenterHinge_ArticleNo Panel_NTCenterHingeArticleNo { get; set; }
        StayBearingK_ArticleNo Panel_StayBearingKArtNo { get; set; }
        StayBearingPin_ArticleNo Panel_StayBearingPinArtNo { get; set; }
        StayBearingCover_ArticleNo Panel_StayBearingCoverArtNo { get; set; }
        TopCornerHinge_ArticleNo Panel_TopCornerHingeArtNo { get; set; }
        TopCornerHingeCover_ArticleNo Panel_TopCornerHingeCoverArtNo { get; set; }
        TopCornerHingeSpacer_ArticleNo Panel_TopCornerHingeSpacerArtNo { get; set; }
        CornerHingeK_ArticleNo Panel_CornerHingeKArtNo { get; set; }
        CornerPivotRestK_ArticleNo Panel_CornerPivotRestKArtNo { get; set; }
        CornerHingeCoverK_ArticleNo Panel_CornerHingeCoverKArtNo { get; set; }
        CoverForCornerPivotRestVertical_ArticleNo Panel_CoverForCornerPivotRestVerticalArtNo { get; set; }
        CoverForCornerPivotRest_ArticleNo Panel_CoverForCornerPivotRestArtNo { get; set; }
        WeldableCornerJoint_ArticleNo Panel_WeldableCArtNo { get; set; }
        LatchDeadboltStriker_ArticleNo Panel_LatchDeadboltStrikerArtNo { get; set; }

        bool Panel_CmenuDeleteVisibility { get; set; }
        bool Panel_NTCenterHingeVisibility { get; set; }
        bool Panel_MiddleCloserVisibility { get; set; }

        bool Panel_MotorizedpnlOptionVisibility { get; set; }

        SlidingTypes Panel_SlidingTypes { get; set; }
        bool Panel_SlidingTypeVisibility { get; set; }

        GuideTrackProfile_ArticleNo Panel_GuideTrackProfileArtNo { get; set; }
        AluminumTrack_ArticleNo Panel_AluminumTrackArtNo { get; set; }
        int Panel_AluminumTrackQty { get; set; }
        bool Panel_AluminumTrackQtyVisibility { get; set; }
        WeatherBar_ArticleNo Panel_WeatherBarArtNo { get; set; }
        WeatherBarFastener_ArticleNo Panel_WeatherBarFastenerArtNo { get; set; }
        EndCapForWeatherBar_ArticleNo Panel_EndCapForWeatherBarArtNo { get; set; }
        WaterSeepage_ArticleNo Panel_WaterSeepageArtNo { get; set; }
        BrushSeal_ArticleNo Panel_BrushSealArtNo { get; set; }
        RollersTypes Panel_RollersTypes { get; set; }
        bool Panel_RollersTypesVisibility { get; set; }
        GlazingRebateBlock_ArticleNo Panel_GlazingRebateBlockArtNo { get; set; }
        Spacer_ArticleNo Panel_Spacer { get; set; }
        SealingBlock_ArticleNo Panel_SealingBlockArtNo { get; set; }
        Interlock_ArticleNo Panel_InterlockArtNo { get; set; }
        ExtensionForInterlock_ArticleNo Panel_ExtensionForInterlockArtNo { get; set; }
        D_HandleArtNo Panel_DHandleInsideArtNo { get; set; }
        D_HandleArtNo Panel_DHandleOutsideArtNo { get; set; }

        D_Handle_IO_LockingArtNo Panel_DHandleIOLockingInsideArtNo { get; set; }
        D_Handle_IO_LockingArtNo Panel_DHandleIOLockingOutsideArtNo { get; set; }

        DummyD_HandleArtNo Panel_DummyDHandleInsideArtNo { get; set; }
        DummyD_HandleArtNo Panel_DummyDHandleOutsideArtNo { get; set; }

        PopUp_HandleArtNo Panel_PopUpHandleArtNo { get; set; }
        Rotoswing_Sliding_HandleArtNo Panel_RotoswingForSlidingHandleArtNo { get; set; }
        bool Panel_DHandleOptionVisibilty { get; set; }
        bool Panel_DHandleIOLockingOptionVisibilty { get; set; }
        bool Panel_DummyDHandleOptionVisibilty { get; set; }
        bool Panel_PopUpHandleOptionVisibilty { get; set; }
        bool Panel_RotoswingForSlidingHandleOptionVisibilty { get; set; }
        Striker_ArticleNo Panel_StrikerArtno_Sliding { get; set; }
        int Panel_StrikerArtno_SlidingQty { get; set; }
        ScrewSets Panel_ScrewSetsArtNo { get; set; }

        PVCCenterProfile_ArticleNo Panel_PVCCenterProfileArtNo { get; set; }
        GS100_T_EM_T_HMCOVER_ArticleNo Panel_GS100_T_EM_T_HMCOVER_ArtNo { get; set; }
        //bool Panel_TrackProfileArtNoVisibility { get; set; }
        //TrackProfile_ArticleNo Panel_TrackProfileArtNo { get; set; }
        TrackRail_ArticleNo Panel_TrackRailArtNo { get; set; }
        bool Panel_TrackRailArtNoVisibility { get; set; }
        MicrocellOneSafetySensor_ArticleNo Panel_MicrocellOneSafetySensorArtNo { get; set; }
        AutodoorBracketForGS100UPVC_ArticleNo Panel_AutodoorBracketForGS100UPVCArtNo { get; set; }
        GS100EndCapScrewM5AndLSupport_ArticleNo Panel_GS100EndCapScrewM5AndLSupportArtNo { get; set; }
        EuroLeadExitButton_ArticleNo Panel_EuroLeadExitButtonArtNo { get; set; }
        TOOTHBELT_EM_CM_ArticleNo Panel_TOOTHBELT_EM_CMArtNo { get; set; }
        GuBeaZenMicrowaveSensor_ArticleNo Panel_GuBeaZenMicrowaveSensorArtNo { get; set; }
        SlidingDoorKitGs100_1_ArticleNo Panel_SlidingDoorKitGs100_1ArtNo { get; set; }
        GS100CoverKit_ArticleNo Panel_GS100CoverKitArtNo { get; set; }
        int Panel_OverLappingPanelQty { get; set; }
        AluminumPullHandle_ArticleNo Panel_AluminumPullHandleArtNo { get; set; }
        PlantOnWeatherStripHead_ArticleNo Panel_PlantOnWeatherStripHeadArtNo { get; set; }
        PlantOnWeatherStripSeal_ArticleNo Panel_PlantOnWeatherStripSealArtNo { get; set; }
        LouverFrameWeatherStripHead_ArticleNo Panel_LouverFrameWeatherStripHeadArtNo { get; set; }
        LouverFrameBottomWeatherStrip_ArticleNo Panel_LouverFrameBottomWeatherStripArtNo { get; set; }
        RubberSeal_ArticleNo Panel_RubberSealArtNo { get; set; }
        CasementSeal_ArticleNo Panel_CasementSealArtNo { get; set; }
        SealForHandle_ArticleNo Panel_SealForHandleArtNo { get; set; }
        BubbleSeal_ArticleNo Panel_BubbleSealArtNo { get; set; }
        //LouverGallerySet_ArticleNo Panel_LouvreGallerySetArtNo { get; set; }

        int Panel_PlantOnWeatherStripHeadWidth { get; set; }
        int Panel_PlantOnWeatherStripSealWidth { get; set; }
        int Panel_LouverFrameWeatherStripHeadWidth { get; set; }
        int Panel_LouverFrameBottomWeatherStripWidth { get; set; }
        int Panel_RubberSealWidth { get; set; }
        int Panel_CasementSealWidth { get; set; }
        int Panel_SealForHandleQty { get; set; }
        int Panel_LouvreGallerySetHeight { get; set; }
        bool Panel_LouverGallerySetVisibility { get; set; }
        BladeHeight_Option Panel_LouverBladeHeight { get; set; }
        int Panel_LouverNumberBladesPerSet { get; set; }
        LouverHandleType_Option Panel_LouverHandleType { get; set; }
        LouverHandleLoc_Option Panel_LouverHandleLocation { get; set; }
        LouverColor_Option Panel_LouverGalleryColor { get; set; }
        bool Panel_LouverGalleryVisibility { get; set; }
        BladeType_Option Panel_LouverBladeTypeOption { get; set; }
        bool Panel_LouverGallerySetOptionVisibility { get; set; }
        string Panel_LouverGallerySetOptionArtNo { get; set; }
        int Panel_LouverGallerySetCount { get; set; }
        List<string> Panel_LstLouverArtNo { get; set; }
        List<int> Panel_LstSealForHandleMultiplier { get; set; }
        bool Panel_LouverMotorizeCheck { get; set; }
        bool Panel_LouverSecurityGrillCheck { get; set; }
        bool Panel_LouverRPLeverHandleCheck { get; set; }
        bool Panel_CenterProfileVisibility { get; set; }
        CenterProfile_ArticleNo Panel_CenterProfileArtNo { get; set; }
        PVCSettingPlate_ArticleNo Panel_PVCSettingPlateArtNo { get; set; }
        FinPlate_ArticleNo Panel_FinPlateArtNo { get; set; }
        SlidingAccessoriesRoller_ArticleNo Panel_SlidingAccessoriesRollerArtNo { get; set; }
        int TopHungbrushSealPerimeter { get; set; }
        void Set_LouverBladesCount();
        void Imager_SetDimensionsToBind_FrameParent();
        void SetPanelMargin_using_ZoomPercentage();
        void SetPanelMarginImager_using_ImageZoomPercentage();
        void SetDimensionsToBind_using_ZoomPercentage();
        void Imager_SetDimensionsToBind_using_ZoomPercentage();
        void SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
        void Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
        void SetDimensionToBind_using_BaseDimension();
        void SetDimensionToBind_2ndlvl_using_BaseDimension();
        void SetDimensionImagerToBind_using_BaseDimension();
        void AdjustPropertyPanelHeight(string mode);
        void AdjustMotorizedPropertyHeight(string mode);
        void AdjustHandlePropertyHeight(string mode);
        void AdjustRotoswingPropertyHeight(string mode);
        void AdjustExtensionPropertyHeight(string mode);
        void SetPanelExplosionValues_Panel(bool parentIsFrame);
        void SetPanelExplosionValues_Panel(Divider_ArticleNo div_artNo,
                                           Divider_ArticleNo divPrev_artNo,
                                           DividerType div_type,
                                           bool mpnlDivEneable,
                                           int OverLappingPanel_Qty,
                                           bool ChckBoundedByBotframe,
                                           bool if_divNxt_is_dummy_mullion,
                                           bool if_divPrev_is_dummy_mullion,
                                           IDividerModel divNxt,
                                           IDividerModel divPrev,
                                           Divider_ArticleNo divArtNo_LeftorTop = null,
                                           Divider_ArticleNo divArtNo_RightorBot = null,
                                           string div_type_lvl3 = "",
                                           Divider_ArticleNo divArtNo_LeftorTop_lvl3 = null,
                                           Divider_ArticleNo divArtNo_RightorBot_lvl3 = null,
                                           string panel_placement = "",
                                           string mpanel_placement = "", //1st level
                                           string mpanelparent_placement = "" //2nd level
                                           );

        void Insert_SashInfo_MaterialList(DataTable tbl_explosion);
        void Insert_CoverProfileInfo_MaterialList(DataTable tbl_explosion);
        void Insert_CoverProfileForTopHungInfo_MaterialList(DataTable tbl_explosion);
        void Insert_MotorizedInfo_MaterialList(DataTable tbl_explosion, int motorCount);
        void Insert_FrictionStay_MaterialList(DataTable tbl_explosion);
        void Insert_SnapNKeep_MaterialList(DataTable tbl_explosion);
        void Insert_FixedCam_MaterialList(DataTable tbl_explosion);
        void Insert_PlasticWedge_MaterialList(DataTable tbl_explosion);
        void Insert_2dHinge_MaterialList(DataTable tbl_explosion);
        void Insert_3dHinge_MaterialList(DataTable tbl_explosion);
        void Insert_RestrictorStay_MaterialList(DataTable tbl_explosion);
        void Insert_NTCenterHinge_MaterialList(DataTable tbl_explosion);
        void Insert_StayBearingK_MaterialList(DataTable tbl_explosion);
        void Insert_StayBearingPin_MaterialList(DataTable tbl_explosion);
        void Insert_StayBearingCover_MaterialList(DataTable tbl_explosion, string basecol);
        void Insert_TopCornerHingeCover_MaterialList(DataTable tbl_explosion, string basecol);
        void Insert_TopCornerHinge_MaterialList(DataTable tbl_explosion);
        void Insert_TopCornerHingeSpacer_MaterialList(DataTable tbl_explosion);
        void Insert_CornerHingeK_MaterialList(DataTable tbl_explosion);
        void Insert_CornerPivotRestK_MaterialList(DataTable tbl_explosion);
        void Insert_CornerHingeCoverK_MaterialList(DataTable tbl_explosion, string basecol);
        void Insert_CoverForCornerPivotRestVertical_MaterialList(DataTable tbl_explosion, string basecol);
        void Insert_CoverForCornerPivotRest_MaterialList(DataTable tbl_explosion, string basecol);
        void Insert_AdjustableStriker_MaterialList(DataTable tbl_explosion);
        void Insert_MiddleCloser_MaterialList(DataTable tbl_explosion);
        void Insert_Extension_MaterialList(DataTable tbl_explosion);
        void Insert_CornerDrive_MaterialList(DataTable tbl_explosion);
        void Insert_RotoswingHandle_MaterialList(DataTable tbl_explosion);
        void Insert_StrikerA_MaterialList(DataTable tbl_explosion);
        void Insert_StrikerC_MaterialList(DataTable tbl_explosion);
        void Insert_RotaryHandle_LockingKit_MaterialList(DataTable tbl_explosion);
        void Insert_RioHandle_MaterialList(DataTable tbl_explosion);
        void Insert_ProfileKnobCylinder_MaterialList(DataTable tbl_explosion);
        void Insert_CylinderCover_MaterialList(DataTable tbl_explosion);
        void Insert_RotolineHandle_MaterialList(DataTable tbl_explosion);
        void Insert_MVDHandle_MaterialList(DataTable tbl_explosion);
        void Insert_WeldableCornerJoint_MaterialList(DataTable tbl_explosion);
        void Insert_Espagnolette_MaterialList(DataTable tbl_explosion);
        void Insert_GlazingBead_MaterialList(DataTable tbl_explosion, string location);
        void Insert_GBSpacer_MaterialList(DataTable tbl_explosion);
        void Insert_Spacer_MaterialList(DataTable tbl_explosion);

        void Insert_GlazingAdapator_MaterialList(DataTable tbl_explosion, string location);
        void Insert_GlassInfo_MaterialList(DataTable tbl_explosion, string location, string glassFilm);
        void Insert_GeorgianBar_MaterialList(DataTable tbl_explosion);
        void Insert_LatchAndDeadboltStriker_MaterialList(DataTable tbl_explosion);
        int Add_SashPerimeter_screws4fab();
        int Add_StrikerAC_screws4fab();
        int Add_Espagnolette_screws4fab();
        int Add_Extension_screws4fab();
        int Add_FSCasement_screws4fab();
        int Add_FGAwning_screws4fab();
        int Add_Hinges_screws4fab();
        int Add_MotorizedMech_screws4Inst();
        void Insert_GuideTrackProfile_MaterialList(DataTable tbl_explosion);
        void Insert_AluminumTrack_MaterialList(DataTable tbl_explosion);
        void Insert_WeatherBar_MaterialList(DataTable tbl_explosion);
        void Insert_EndCapForWeatherBar_MaterialList(DataTable tbl_explosion);
        void Insert_WaterSeepage_MaterialList(DataTable tbl_explosion);
        void Insert_Interlock_MaterialList(DataTable tbl_explosion, int Insert_Interlock_MaterialList);
        void Insert_ExternsionForInterlock_MaterialList(DataTable tbl_explosion, int Insert_Interlock_MaterialList);
        void Insert_Interlock_Tophung_MaterialList(DataTable tbl_explosion);
        void Insert_Interlock_Tophung_ForFixed_MaterialList(DataTable tbl_explosion);
        void Insert_ExternsionForInterlock_Tophung_MaterialList(DataTable tbl_explosion);
        void Insert_WeatherBarFastener_MaterialList(DataTable tbl_explosion);
        void Insert_BrushSeal_MaterialList(DataTable tbl_explosion);
        void Insert_BrushSealForTopHung_MaterialList(DataTable tbl_explosion, int perimeterBrushSeal);
        void Insert_Rollers_MaterialList(DataTable tbl_explosion);
        void Insert_GlazingRebateBlock_MaterialList(DataTable tbl_explosion);
        void Insert_AntiLiftDevice_MaterialList(DataTable tbl_explosion);
        void Insert_StrikerForSliding_MaterialList(DataTable tbl_explosion);
        void Insert_SealingBlock_MaterialList(DataTable tbl_explosion);
        void Insert_DHandle_MaterialList(DataTable tbl_explosion);
        void Insert_DHandleIOLocking_MaterialList(DataTable tbl_explosion);
        void Insert_DummyDHandle_MaterialList(DataTable tbl_explosion);
        void Insert_PopUpHandle_MaterialList(DataTable tbl_explosion);
        void Insert_RotoswingForSlidingHandle_MaterialList(DataTable tbl_explosion);
        void Insert_ScrewSetForDhandlesVariant_MaterialList(DataTable tbl_explosion);
        void Insert_SpacerFixedSash_MaterialList(DataTable tbl_explosion);

        void Insert_CoverProfileForPremiInfo_MaterialList(DataTable tbl_explosion);
        void Panel_PropertyChange(bool Checked);
        void Insert_AluminumPullHandle_MaterialList(DataTable tbl_explosion);
        void Insert_GS100TEMHMCOVERENDCAP3p5m_MaterialList(DataTable tbl_explosion);

        void Insert_TrackRail6m_MaterialList(DataTable tbl_explosion);

        void Insert_MicrocellOneSafetySensor_MaterialList(DataTable tbl_explosion);

        void Insert_AutoDoorBracketForGS100Upvc_MaterialList(DataTable tbl_explosion);

        void Insert_GS100EndCapScrewMp5andLSupport_MaterialList(DataTable tbl_explosion);

        void Insert_EuroLeadButtonWhite_MaterialList(DataTable tbl_explosion);

        void Insert_ToothbeltEMCM62m_MaterialList(DataTable tbl_explosion);

        void Insert_GuBeaZenMicrowaveSensorSilver_MaterialList(DataTable tbl_explosion);

        void Insert_SlidingDoorKitGS100s1_MaterialList(DataTable tbl_explosion);

        void Insert_GS100CoverKit_MaterialList(DataTable tbl_explosion);

        void Insert_PlantOnWeatherStripHead_MaterialList(DataTable tbl_explosion);
        void Insert_PlantOnWeatherStripSeal_MaterialList(DataTable tbl_explosion);
        void Insert_LouvreFrameWeatherStripHead_MaterialList(DataTable tbl_explosion);
        void Insert_LouvreFrameBottomWeatherStrip_MaterialList(DataTable tbl_explosion);
        void Insert_RubberSeal_MaterialList(DataTable tbl_explosion);
        void Insert_CasementSeal_MaterialList(DataTable tbl_explosion);
        void Insert_SealForHandle_MaterialList(DataTable tbl_explosion);
        void Insert_LouvreGallerySet_MaterialList(DataTable tbl_explosion);
        void Insert_ConnectingProfile_MaterialList(DataTable tbl_explosion);
        void Insert_GUPremilineTopTrack_MaterialList(DataTable tbl_explosion);
        void Insert_PVCSettingPlate_MaterialList(DataTable tbl_explosion);
        void Insert_FinPlate_MaterialList(DataTable tbl_explosion);
        void Insert_SlidingAccessoriesRoller_MaterialList(DataTable tbl_explosion);
        void Insert_SlidingSashBottomGuide_MaterialList(DataTable tbl_explosion, int overlap);

        #endregion

        int MotorizeMechQty();
        int MotorizeMechForFrameParent();
    }
}