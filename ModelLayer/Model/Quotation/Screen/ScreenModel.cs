using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Screen
{
    public class ScreenModel : IScreenModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConstantVariables constants = new ConstantVariables();

        #region Variables

        decimal
        #region RollUpCostingMaterials
        TotalRollUpCostingMaterials,
        RollUpCostingMaterials,
        HeadRailPricePerLinearMeter_White,
        HeadRailPricePerLinearMeter_WoodGrain,
        SlidingBarPricePerPiece_White,
        SlidingBarPricePerPiece_WoodGrain,
        MeshWithTubePricePerLinearMeter_White,
        MeshWithTubePricePerLinearMeter_WoodGrain,
        GuidePricePerLinearMeter_White,
        GuidePricePerLinearMeter_WoodGrain,
        PilePricePerLinearMeter_White,
        PilePricePerLinearMeter_WoodGrain,
        AntiwindBrushPricePerLinearMeter_White,
        AntiwindBrushPricePerLinearMeter_WoodGrain,
        KitForVerticalOpeningHeadrailPricePerLinearMeter_White,
        KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain,
        BrakePriceperPiece_White,
        BrakePriceperPiece_WoodGrain,
        SupportForFixingHeadRailPricePerLinearMeter_White,
        SupportForFixingHeadRailPricePerLinearMeter_WoodGrain,
        SpringLoadedPricePerPiece_White = 0,
        SpringLoadedPricePerPiece_WoodGrain = 0,

        WithWasteCost = 0,

        HeadRailPrice,
        SlidingBarPrice,
        MeshWithTubePrice,
        GuidePrice,
        PilePrice,
        AntiwindBrushPrice,
        KitForVerticalOpeningHeadrailPrice,
        BrakePrice,
        SupportForFixingHeadRailPrice,
        SpringLoadedPrice,


        HeadRailQty = 1,
        SlidingBarQty = 1,
        MeshWithTubeQty = 1,
        GuideQty = 2,
        PileQty = 2,
        AntiwindBrushQty = 2,
        KitForVerticalOpeningHeadrailQty = 1,
        BrakeQty = 1,
        SupportForFixingHeadRailQty = 2,
        SpringLoadedQty = 1,

        #endregion

        #region PlisseCostingMaterials
        PPPleatingNETHQty,
        BottomRail2p5mBarsQty,
        AnchorplatePriceQty,
        Scorpiontail3Qty,
        WireCB40051PriceQty,
        RollOutMagnetQty,
        WaSbarQty,

        PPPleatingNETHPricePerLinearMeter = 16.2945m,
        BottomRail2p5mBarsPricePerPiece = 4.7475m,
        SettingPlate2p6mbarsPricePricePerPiece = 1.9415m,
        AnchorplatePricePerPiece = 0.36m,
        Scorpiontail3PricePerPiece = 0.145m,
        WireEndtailYellowPricePerPiece = 0.3050m,
        AjustEightTailPricePerPiece = 0.31m,
        WireGuideCenterPricePerPiece = 0.17m,
        WireGuideRPricePerPiece = 0.235m,
        WireGuideLPricePerPiece = 0.235m,
        WireCB40051PricePerLinearMeter = 0.375m,
        TappingScrew3X30BHPricePerPiece = 0.0351m,
        RollOutMagnetPricePerLinearMeter = 0.4302m,
        //PileForPlissèPricePerLinearMeter = 0.5909m,
        LatchForResizablePlissèPricePerPiece = 3.71m,
        ScrewForLatchPricePerPiece = 0.0409m,

        // white/ivory
        WallBarOxRALStandardPricePerLinearMeter = 7.1969m,
        SlideBarOxRALStandardPricePerLinearMeter = 7.2654m,
        TopGuideResizablePlissèMillFinishedPricePerLinearMeter = 5.6634m,
        UprofileForMagnetMillFinishedPricePerLinearMeter = 3.0586m,
        PlisseLProfileFrontalFixingMillFinishedPricePerLinearMeter = 3.4612m,
        PlisseCoverLProfileFrontingFixingMillFinishPricePerLinearMeter = 2.2399m,

        //WoodGrain
        WallBarWoodFinishedPricePerLinearMeter = 8.2820m,
        SlideBarWoodFinishedPricePerLinearMeter = 8.3520m,
        TopGuideResizablePlissèWoodFinishedPricePerLinearMeter = 6.9600m,
        UprofileForMagnetWoodFinishedPricePerLinearMeter = 4.1630m,
        PlisseLProfileFrontalFixingWoodFinishedPerLinearMeter = 4.5090m,
        PlisseCoverLProfileFrontingFixingWoodFinishedPricePerLinearMeter = 3.1200m,

        TotalPlisseCostingMaterials,
        PlisseCostingMaterials,
        PPPleatingNETHPrice,
        BottomRail2p5mBarsPrice,
        SettingPlate2p6mbarsPrice,
        FinplateBarsPrice,
        ScorpionfishLDPrice,
        ScorpionfishRDPrice,
        AnchorplatePrice,
        Scorpiontail3Price,
        WireEndtailYellowPrice,
        AjustEightTailPrice,
        TailEndPrice,
        TailReversalPrice,
        WireGuideCenterPrice,
        WireGuideRPrice,
        WireGuideLPrice,
        WireCB40051Price,
        TappingScrew3X30BHPrice,
        RollOutPositiveMagnetPrice,
        RollOutNegativeMagnetPrice,

        LatchForResizablePlissèPrice,
        ScrewForLatchPrice,
        SlidingBarEndCapResizablePlissèPrice,
        WallProfileEndCapResizablePlissèPrice,
        TopGuideEndCapResizablePlissèPrice,
        CordCurrierResizablePlissèPrice,
        TensionerPrice,
        ScrewForTensionerPrice,
        HammerNutResizablePlissèPrice,
        Grub5x20Price,

        WallBarPrice,
        SlideBarPrice,
        TopGuideResizablePlissèPrice,
        UprofileForMagnetPrice,
        PlisseLProfileFrontalFixingPrice,
        PlisseCoverLProfileFrontingFixingPrice,

        AluminumBottomGuidePrice,
        AluminumPlisseHandlePrice,
        LocalMaterialPrice,

        HandlesPrice = 0,
        CouplingProfilePrice = 0,
        PliseeLandCoverPrice = 0,
        #endregion

        #region MagnumCostingVariable

        #region Calculation Variables

            _whiteFinish,
            _woodFinish,
            SideU_for_WindowApp_whiteFinish = 0,
            SideU_for_WindowApp_woodFinish = 0,

            DoubleHori_LatchSetlock = 40.6092m,
            Extension_for_Bolt,

            Extension_alumBase_DoubleHori_whiteFinish,
            Extension_alumBase_DoubleHori_woodFinish,

            PlisseL_N_Cover_whiteFinish,
            PlisseL_N_Cover_woodFinish,

            CouplingProfile_1248,
            ShootBolt,

            Total_Material_Cost_whiteFinish,
            Total_Material_Cost_woodFinish,

            Wastage_Cost_whiteFinish,
            Wastage_Cost_woodFinish,

            Freight_Cost_whiteFinish,
            Freight_Cost_woodFinish,

            DandT_Cost_whiteFinish,
            DandT_Cost_woodFinish,

            Small_shop_Items = 200m,
            Small_shop_Items_DoubleHori = 400m,

            Reinforced_Labor = 0,

            OverHead_Cost_SF = 2000m,
            OverHead_Cost_DH = 4000m,
            OverHead_Cost_SC = 2500m,

            KM01_Alum_BottomGuide_whiteFinish = 0,
            KM01_Alum_BottomGuide_woodFinish = 0,

            Contingencies_whiteFinish,
            Contingencies_woodFinish,


            Single_Fixed_whiteFinish_Total,
            Single_Fixed_woodFinish_Total,

            Single_Fixed_whiteFinish_CurrAmount,
            Single_Fixed_woodFinish_CurrAmount,

            Double_Horizontal_whiteFinish_Total,
            Double_Horizontal_woodFinish_Total,

            Double_Horizontal_whiteFinish_CurrAmount,
            Double_Horizontal_woodFinish_CurrAmount,

            Single_Central_whiteFinish_Total,
            Single_Central_woodFinsih_Total,

            Single_Central_whiteFinish_CurrAmount,
            Single_Central_woodFinish_CurrAmount,

            Magnum_Screen_tAmount = 0,

            //Material Price List

            KM01_Alum_BottomGuide_BasePrice,
            KM02_Alum_PlissHandle_BasePrice,

            Reinforce_Addon = 0,


            FinalPart_w_MetalTip = 1.98m,
            Cap_for_Alum_Base = 1.98m,
            Black_Alum_base,
            AntiLift_DB_w_CacaoFoil,
            Milled_Profile_6052,
            Cover_Profile,


        #endregion
        #region item Cost Per Unit 


                PleatedMeshNera_Price = 16.2945m,

                Wire_Price = 0.1215m,
                Bushing_Price = 0.111375m,
                TensionerNoGrubs_Price = 0.192375m,
                Grubs4x6_Price = 0.0619875m,
                CordCurriere3Holes_Price = 1.144125m,
                SpringForTensioner_Price = 0.313875m,
                BottomEndCapMagnum31mmForHorizontalNoWHeel_Price = 0.6525m,
                TopEndCapMagnum31mmForHorizontalNoWheel_Price = 0.6525m,
                Wheel_Price = 1.5975m,
                PinForWheel_Price = 1.5975m,
                AdhesiveTapeForAluminum_Price = 0.19220350877193m,
                AdhesiveTapeForBottomGuide_Price = 0.318805263157895m,
                MinyClips_Price = 0.3591m,
                MagnetToClicIntoRollInFly_Price = 0.6372m,
                NegativeMagnetPlisse_Price = 0.4302m,

                PlissePositivePlisse_Price = 0.6372m,
                DoubleCentePart_Price = 3.36751690909091m,
                BottomEndCapMagnum31mm_DoubleHori_Price = 2.98438524590164m,

                AluminumPlateWithTeeth_RALColor_Price = 2.82946716450692m,
                AluminumPlateNoTeeth_RALColor_Price = 1.10115m,
                Magnum31mmSlidingBar_RALColor_Price = 6.2475200668178m,
                Magnum31mmBottomGuide_RALColor_Price = 1.86998016330039m,
                Magnum31mmTopGuide_RALColor_Price = 6.32336444695555m,
                Magnum31mmTensionersProfiles_RALColor_Price = 3.96823381109966m,
                Magnum31mmSideU_RALColor_Price = 4.35839457658489m,

                AluminumPlateWithTeeth_MillFinish_Price = 2.82946716450692m,
                AluminumPlateNoTeeth_MillFinish_Price = 1.10115m,
                Magnum31mmSlidingBar_MillFinish_Price = 4.93584827586207m,
                Magnum31mmBottomGuide_MillFinish_Price = 1.86998016330039m,
                Magnum31mmTopGuide_MillFinish_Price = 4.99601097704068m,
                Magnum31mmTensionersProfiles_MillFinish_Price = 3.96823381109966m,
                Magnum31mmSideU_MillFinish_Price = 3.44431464247561m,

                //Single Central 
                Magnum31mmSlidingBar_RALColor_SingeleCentral_Price = 7.24712327750865m,
                Magnum31mmBottomGuide_RALColor_SingleCentral_Price = 2.16917698942845m,
                Magnum31mmTopGuide_RALColor_SingleCentral_Price = 7.33510275846844m,
                Magnum31mmTensionersProfiles_RALColor_SingleCentral_Price = 4.6031512208756m,
                Magnum31mmSideU_RALColor_SingleCentral_Price = 5.05573770883847m,

                Magnum31mmSlidingBar_MillFinish_SingeleCentral_Price = 5.725584m,
                Magnum31mmBottomGuide_MillFinish_SingleCentral_Price = 2.16917698942845m,
                Magnum31mmTopGuide_MillFinish_SingleCentral_Price = 5.79537273336719m,
                Magnum31mmTensionersProfiles_MillFinish_SingleCentral_Price = 4.6031512208756m,
                Magnum31mmSideU_MillFinish_SingleCentral_Price = 3.99540498527171m,

        #endregion
        #region item costing variable

            PleatedMeshDoubleHori_tCost,
            PleatedMeshSingeFixed_tCost,
            PleatedMeshSingleCentral_tCost,

            Wire_tCost,
            Bushing_tCost,
            TensionerNoGrubs_tCost,
            Grubs4x6_tCost,
            CordCurriere3Holes_tCost,
            SpringForTensioner_tCost,
            BottomEndCapMagnum31mmHorizontalNoWheel_tCost,
            TopEndCapMagnum31mmHorizontalNoWheel_tCost,
            Wheel_tCost,
            PinForWheel_tCost,
            AdhesiveTapeAluminumPlate_tCost,
            AdhesiveTapeBottomGuide_tCost,
            MinyClips_tCost,
            MagnetsClicIntoRollinFly_tCost,
            NegativeMagntePlisse_tCost,

            PlissePositivePlisse_tCost,
            DoubleCentePart_tCost,
            BottomEndCapMagnum31mm_DoubleHori_tCost,

            //RAL COLOR
            AluminumPlateWithTeeth_RALColor_tCost,
            AluminumPlateNoTeeth_RALColor_tCost,
            Magnum31mmSlidingBar_RALColor_tCost,
            Magnum31mmBottomGuide_RALColor_tCost,
            Magnum31mmTopGuide_RALColor_tCost,
            Magnum31mmTensionersProfile_RALColor_tCost,
            Magnum31mmsideU_RALColor_tCost,
            //Mill Finish
            AluminumPlateWithTeeth_MillFinish_tCost,
            AluminumPlateNoTeeth_MillFinish_tCost,
            Magnum31mmSlidingBar_MillFinish_tCost,
            Magnum31mmBottomGuide_MillFinish_tCost,
            Magnum31mmTopGuide_MillFinish_tCost,
            Magnum31mmTensionersProfile_MillFinish_tCost,
            Magnum31mmsideU_MillFinish_tCost,
            //Foiled
            Magnum31mmSlidingBar_Foiled_tCost,
            Magnum31mmTopGuide_Foiled_tCost,
            Magnum31mmsideU_Foiled_tCost,
            //Costing Total
            RALColor_TotalCost,
            MillFinish_TotalCost,
            Foiled_TotalCost,

        #endregion
        #region Item Quantity 


            PleatedMeshDoubleHori_Qty,
            PleatedMeshSingleFixed_Qty,
            PleatedMeshSingleCentral_Qty,

            Wire_Qty = 0,
            Bushing_Qty = 0,
            Bushing_SingleOneSideFixed_Qty = 12, // Constant Quantity for SingleOneSideFixed
            TensionerNoGrubs_Qty = 2,
            Grubs4x6_Qty = 8,
            Grubs4x6_SingleCentralPack_Qty = 12,// Constant Quantity for SingleCentralPack
            CordCurriere3Holes_Qty = 2,
            CordCurriere3Holes_SingleCentralPack_Qty = 4,// Constant Quantity for SingleCentralPack
            SpringForTensioner_Qty = 2,
            BottomEndCapMagnum31mmHorizontalNoWheel_SingleOneSideFixed_Qty = 1,
            BottomEndCapMagnum31mmHorizontalNoWheel_SingleCentralPack_Qty = 2,


            TopEndCapMagnum31mmHorizontalNoWheel_Qty = 2,
            TopEndCapMagnum31mmHorizontalNoWheel_SingleOneSideFixed_Qty = 1,
            Wheel_Qty = 4,
            Wheel_SingleOneSideFixed_Qty = 2,
            PinForWheel_Qty = 4,
            PinForWheel_SingleOneSideFixed_Qty = 2,
            AdhesiveTapeAluminumPlate_Qty,
            AdhesiveTapeBottomGuide_Qty,

            MinyClips_Qty = 0,
            MinyClips_SingleOneSideFixed_Qty = 6,
            MagnetsClicIntoRollinFly_Qty,
            NegativeMagntePlisse_Qty,

            PlissePositivePlisse_Qty,
            DoubleCentePart_Qty = 1,
            BottomEndCapMagnum31mm_DoubleHori_Qty = 2,

            //RAL COLOR
            AluminumPlateWithTeeth_RALColor_Qty,
            AluminumPlateNoTeeth_RALColor_Qty,
            Magnum31mmSlidingBar_RALColor_Qty,
            Magnum31mmBottomGuide_RALColor_Qty,
            Magnum31mmTopGuide_RALColor_Qty,
            Magnum31mmTensionersProfile_RALColor_Qty,
            Magnum31mmsideU_RALColor_Qty,
            //Mill Finish
            AluminumPlateWithTeeth_MillFinish_Qty,
            AluminumPlateWithTeeth_MillFinish_SingleOneSideFixed_Qty = 1,
            AluminumPlateNoTeeth_MillFinish_SingleOneSideFixed_Qty = 1,
            AluminumPlateNoTeeth_MillFinish_Qty,
            Magnum31mmSlidingBar_MillFinish_Qty,
            Magnum31mmBottomGuide_MillFinish_Qty,
            Magnum31mmTopGuide_MillFinish_Qty,
            Magnum31mmTensionersProfile_MillFinish_Qty,
            Magnum31mmsideU_MillFinish_Qty,
        #endregion       
        #endregion

        #region ZeroGravityChain

        #region ItemQuantity

            roller_case_Qty = 1,
            sliding_bar_Qty = 1,
            mesh_w_tube_Qty = 1,
            guide_70x22_Qty = 2,
            reinforing_hand_slidingbar_Qty = 1,
            profiles_supp_tube_ZG_Qty = 1,
            pile_Qty = 0,
            anti_wind_brush_Qty = 2,
            kit_genius_46mm_ZG_Qty = 1,
            supp_fixing_42mm_headrail_Qty = 0,
            dowell_4x25_Qty = 0,
            screw_4x25_Qty = 0,

        #endregion
        #region itemCost
            ZG_waste_10per_ = 0,
            ZG_freight_5per = 0,
            ZG_importation_Cost = 0,
            ZG_small_shop_Items = 500m,
            ZG_overhead_Cost = 3600m,
            additional_for_Woograin = 0,
            ZG_Contigencies = 0,
            ZG_totalMaterial_Cost = 0,

            //PowderCoating
            rollerCase_php_per_meter = 110.236220472441m,
            guide_70x22_php_per_meter = 34.1535433070866m,
            reinforing_hand_slidingbar_php_per_meter = 82.6771653543307m,

            roller_case_Price = 0,
            sliding_bar_Price = 0,
            mesh_w_tube_Price = 0,
            guide_70x22_Price = 0,
            reinforing_hand_slidingbar_Price = 0,
            profiles_supp_tube_ZG_Price = 0,
            pile_Price = 0,
            anti_wind_brush_Price = 0,
            kit_genius_46mm_ZG_Price = 0,
            supp_fixing_42mm_headrail_Price = 0,
            dowell_4x25_Price = 0,
            screw_4x25_Price = 0,


        #endregion

        #endregion

        #region Maxxy Screen Variables

               PP_Maxy_5mmTube = 0,

                Wire_CB_40051 = 1.61352m,
                SettingPlate_Rs_l2600 = 0.8586m,
                Tail_SlideDT = 1.827m,
                ScorpionTail_8 = 0,
                Adjust_EighthHolder = 1.4445m,
                Weight_Bar_Rsz = 0.9826m,
                Anchor_Plate_s4 = 1.44m,
                Mohair = 0,
                Tapping_Screw_3x10_Bh = 0.1575m,

                Maxy_Cassette_EndCap_w_Spring = 8.8875m,
                Maxy_Bushing = 0.2635m,
                Maxy_Cassette_Endcap = 0.3953m,
                Maxy_Sliding_Bottom_EndCap = 1.2047m,
                Maxy_Sliding_Top_EndCap = 1.3176m,
                Maxy_ScorpionTail_53pcs = 0,
                Maxy_White_TailEnd = 0.4518m,
                Maxy_Cap_SlidingBar_TopEndCap = 0.5082m,
                Maxy_TopRailCap_CassetteSide = 1.2424m,
                Maxy_Screw_3x4 = 0.1104m,
                Plate_w_2hole_M3 = 0.675m,
                Maxy_Pile = 0,
                Maxy_ScorpionTail_w_PileCavity = 0.4095m,
                Bottom_Rail = 0,

                Case_Maxy_MillFinish = 0,
                SlidingBar_Maxy_MillFinish = 0,
                TopGuide_Maxy_MillFinish = 0,
                UProfile_46mm_Maxy_MillFinish = 0,

                Case_Maxy_RalColour = 0,
                SlidingBar_Maxy_RalColour = 0,
                TopGuide_Maxy_RalColour = 0,
                UProfile_46mm_Maxy_RalColour = 0,

                Hook_V_MillFinish_tCost = 0,
                Hook_V_RalFinish_tCost = 0,

                Maxxy_Screen_tAmount = 0,

                //Hook Version 
                Cover_ProfileLatch_MillFinish = 0,
                Cover_ProfileLatch_RalColour = 0,
                Latch_Rsz = 0,
                Latch_Hanger_Rsz = 0,

                Maxxy_1248_Coupling_Profile = 0,
                Maxxy_Total_Mat_Cost = 0,
                Maxxy_Wastage = 0,
                Maxxy_Freight = 0,
                Maxxy_DT = 0,

                Maxxy_KM01 = 0,
                Maxxy_KM02 = 0,
                Maxxy_AlumBottomGuide = 0,
                Maxxy_Contigencies = 0,
        #endregion

        #region Freedom Screen Variables
                AUDtoPeso_ExchangRate = 40m,
                Freedom_BasedPrice = 0,
                Freedom_PowderCoating = 150m,
                Freedom_MeshUp = 0,
                Freedom_AUDTCost = 0,
                Freedom_PesoTCost = 0,

                Freedom_Foiling_Cassette = 0,
                Freedom_Foiling_TopRail = 0,
                Freedom_Foiling_SideRail = 0,
                Freedom_Foiling_PullBar = 0,
                Freedom_Foiling_Total = 0,

                Freedom_KM04 = 0,
                Freedom_Accessories = 8000m,
                Freedom_Installation_Cost = 3600m,
                Freedom_OverHead_Cost = 8500m,
                Freedom_Fr_Shipping_Cost = 100000m,

                Freedom_tCost_SF = 0,
                Freedom_tAmount = 0,
        #endregion

        AddOnsPrice,

        pvc1067PriceLinearMeter,
        pvc0505PricePerLinearMeter,

        pvc0505Price,
        pvc1067Price,

        #region Plisse AddOns
        pvc1067withreinforcementPriceLinearMeter,
        milledprofile6040PriceLinearMeter,
        landCoverPriceLinearMeter,

        pvc1067withreinPrice,
        milledprofile6040Price,
        landCoverPrice,
        #endregion

        #region Maxxy Addones
            milled373or374PricePerLinearMeter,
            milled373or374Price,
        #endregion

        #region built in Addons
            milled1385profilePricePerLinearMeter,
            milled6052profilePricePerLinearMeter,

            milled1385Price,
            milled6052Price,
        #endregion

        #region centerclosure
            LatchkitPrice = 1500,
            IntermediatePartPrice = 800,
            Intermediate_X_,

            LatchkitTotal,
            IntermediatePartTotal,
        #endregion

        basicMats,
        WasteCost,
        FreightCost,
        DandTCost,
        SmallShopItemCost,
        OverheadCost,
        ContingenciesCost,
        TotalPrice,
        Discount,
        AddOnsSpecialFactor,
        IncreasePercentage,
        TotalUnitPrice,

        #region Trail Screen Variables
        _tr_PPPleatingNETHQty,
        _tr_BottomRail2p5mBarsQty,
        _tr_AnchorplatePriceQty,
        _tr_Scorpiontail3Qty,
        _tr_WireCB40051PriceQty,
        _tr_MagnetQty,
        _tr_WaSbarQty,

        _tr_PPPleatingNETHPricePerLinearMeter,
        _tr_BottomRail2p5mBarsPricePerPiece = 4.77m / 0.45m,
        _tr_SettingPlate2p6mbarsPricePricePerPiece = 1.719m / 0.45m,
        _tr_AnchorplatePricePerPiece = 0.36m / 0.45m,
        _tr_Scorpiontail3PricePerPiece = 0.144m / 0.45m,
        _tr_WireEndtailYellowPricePerPiece = 0.306m / 0.45m,
        _tr_AjustEightTailPricePerPiece = 0.3105m / 0.45m,
        _tr_WireGuideCenterPricePerPiece = 0.171m / 0.45m,
        _tr_WireGuideRPricePerPiece = 0.234m / 0.45m,
        _tr_WireGuideLPricePerPiece = 0.234m / 0.45m,
        _tr_WireCB40051PricePerLinearMeter = 0.3735m / 0.45m,
        _tr_TappingScrew3X30BHPricePerPiece = 0.03m / 0.45m,
        _tr_MagnetPricePerLinearMeter = 0.3825m / 0.45m,
        _tr_PileForPlissèPricePerLinearMeter = 0.36m * 1.1m,
        _tr_LatchForResizablePlissèPricePerPiece = 2.97m * 1.1m,
        _tr_ScrewForLatchPricePerPiece = 0.038m * 1.1m,
        
        // white/ivory
        _tr_WallBarOxRALStandardPricePerLinearMeter = 7.1969m,
        _tr_SlideBarOxRALStandardPricePerLinearMeter = 7.2654m,
        _tr_TopGuideResizablePlissèMillFinishedPricePerLinearMeter = 5.6634m,
        _tr_UprofileForMagnetMillFinishedPricePerLinearMeter = 3.0586m,
        _tr_PlisseLProfileFrontalFixingMillFinishedPricePerLinearMeter = 3.4612m,
        _tr_PlisseCoverLProfileFrontingFixingMillFinishPricePerLinearMeter = 2.2399m,
        
        //WoodGrain
        _tr_WallBarWoodFinishedPricePerLinearMeter = 8.2820m,
        _tr_SlideBarWoodFinishedPricePerLinearMeter = 8.3520m,
        _tr_TopGuideResizablePlissèWoodFinishedPricePerLinearMeter = 6.9600m,
        _tr_UprofileForMagnetWoodFinishedPricePerLinearMeter = 4.1630m,
        _tr_PlisseLProfileFrontalFixingWoodFinishedPerLinearMeter = 4.5090m,
        _tr_PlisseCoverLProfileFrontingFixingWoodFinishedPricePerLinearMeter = 3.1200m,
        
        _tr_TotalPlisseCostingMaterials,
        _tr_PlisseCostingMaterials,
        _tr_PPPleatingNETHPrice,
        _tr_BottomRail2p5mBarsPrice,
        _tr_SettingPlate2p6mbarsPrice,
        _tr_FinplateBarsPrice,
        _tr_ScorpionfishLDPrice,
        _tr_ScorpionfishRDPrice,
        _tr_AnchorplatePrice,
        _tr_Scorpiontail3Price,
        _tr_WireEndtailYellowPrice,
        _tr_AjustEightTailPrice,
        _tr_TailEndPrice,
        _tr_TailReversalPrice,
        _tr_WireGuideCenterPrice,
        _tr_WireGuideRPrice,
        _tr_WireGuideLPrice,
        _tr_WireCB40051Price,
        _tr_TappingScrew3X30BHPrice,
        _tr_PositiveMagnetPrice,
        _tr_NegativeMagnetPrice,
        _tr_PileforPlissePrice,
        
        _tr_LatchForResizablePlissèPrice,
        _tr_ScrewForLatchPrice,
        _tr_SlidingBarEndCapResizablePlissèPrice,
        _tr_WallProfileEndCapResizablePlissèPrice,
        _tr_TopGuideEndCapResizablePlissèPrice,
        _tr_CordCurrierResizablePlissèPrice,
        _tr_TensionerPrice,
        _tr_ScrewForTensionerPrice,
        _tr_HammerNutResizablePlissèPrice,
        _tr_Grub5x20Price,
        
        _tr_WallBarPrice,
        _tr_SlideBarPrice,
        _tr_TopGuideResizablePlissèPrice,
        _tr_UprofileForMagnetPrice,
        _tr_PlisseLProfileFrontalFixingPrice,
        _tr_PlisseCoverLProfileFrontingFixingPrice,
        
        _tr_AluminumBottomGuidePrice,
        _tr_AluminumPlisseHandlePrice,
        _tr_LocalMaterialPrice,
        
        _tr_HandlesPrice = 0,
        _tr_CouplingProfilePrice = 0,
        _tr_PliseeLandCoverPrice = 0,
        #endregion

        #region BuiltinSideRoll Variables

         temp,
         price_base_on_Height = 0,
         price_base_on_Weight = 0,
         built_in_SR_tAmount = 0,

         base_Price = 0,
         height_Base_Price_Inc = 0,
         width_Base_Price_Inc = 0,
         height_deci = 0,
         weight_deci = 0,
         percentage_multiplier = 0,

         Height_mm_to_meters = 0,
         Width_mm_to_meters = 0,

         current_deci_index = 0,
         next_deci_index = 0,
         _firstLoopInterpolatePrice = 0,
         _secondLoopInterpolatePrice = 0,
         _builtinInterpolationPrice = 0,
         _builtinPowderCoatingMultiplier = 0
         ;

        decimal[] deci_getter = new decimal[22] {1.0m, 1.1m, 1.2m, 1.3m, 1.4m, 1.5m, 1.6m, 1.7m, 1.8m, 1.9m, 2.0m,
                                                 2.1m, 2.2m,2.3m, 2.4m, 2.5m, 2.6m,2.7m, 2.8m,2.9m ,3.0m,3.1m };

        decimal[] width_Base_Price_List = new decimal[21];
        decimal[] height_Base_Price_List = new decimal[16];
        int[] indices_pos = new int[5] { 2, 6, 11, 16, 20 };
        int holder = 0,
            curr_index_pos = 0,
            loopCountLimit = 0,
            _width_builtInInterpolationNewDimension,
            _height_builtInInterpolationNewDimension;
        #endregion

        int _plisséSRPerPanelWidth,
            _screenWidthOriginalDimension,
            _screenHeightOriginalDimension,
            _screenPreviousWidth;

        bool _builtInWidthIsBelowMinimum,
             _builInHeigthIsBelowMinimum;   


        #endregion

        #region Properties

        public int Screen_id { get; set; }

        private bool _screen_Types_Window;

        public bool Screen_Types_Window
        {
            get
            {
                return _screen_Types_Window;
            }
            set
            {
                _screen_Types_Window = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_Types_Door;
        public bool Screen_Types_Door
        {
            get
            {
                return _screen_Types_Door;
            }
            set
            {
                _screen_Types_Door = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Width;

        public int Screen_Width
        {
            get
            {
                return _screen_Width;
            }
            set
            {
                _screen_Width = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Height;

        public int Screen_Height
        {
            get
            {
                return _screen_Height;
            }
            set
            {
                _screen_Height = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screenAddonsSpecialFactor;

        public decimal Screen_AddOnsSpecialFactor
        {
            get
            {
                return _screenAddonsSpecialFactor;
            }
            set
            {
                _screenAddonsSpecialFactor = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_Factor;

        public decimal Screen_Factor
        {
            get
            {
                return _screen_Factor;
            }
            set
            {
                _screen_Factor = value;
                NotifyPropertyChanged();
            }
        }

        private ScreenType _screen_Type;

        public ScreenType Screen_Types
        {
            get
            {
                return _screen_Type;
            }
            set
            {
                _screen_Type = value;
                NotifyPropertyChanged();
            }
        }

        private PlisseType _screen_PlisséType;

        public PlisseType Screen_PlisséType
        {
            get
            {
                return _screen_PlisséType;
            }
            set
            {
                _screen_PlisséType = value;
                NotifyPropertyChanged();
            }
        }

        private Base_Color _screen_BaseColor;

        public Base_Color Screen_BaseColor
        {
            get
            {
                return _screen_BaseColor;
            }
            set
            {
                _screen_BaseColor = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Set;

        public int Screen_Set
        {
            get
            {
                return _screen_Set;
            }
            set
            {
                _screen_Set = value;
                NotifyPropertyChanged();
            }
        }

        private string _screen_WindoorID; //location

        public string Screen_WindoorID //location
        {
            get
            {
                return _screen_WindoorID;
            }
            set
            {
                _screen_WindoorID = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_UnitPrice;

        public decimal Screen_UnitPrice
        {
            get
            {
                return _screen_UnitPrice;
            }
            set
            {
                _screen_UnitPrice = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Quantity;

        public int Screen_Quantity
        {
            get
            {
                return _screen_Quantity;
            }
            set
            {
                _screen_Quantity = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_TotalAmount;

        public decimal Screen_TotalAmount
        {
            get
            {
                return _screen_TotalAmount;
            }
            set
            {
                _screen_TotalAmount = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_NetPrice;

        public decimal Screen_NetPrice
        {
            get
            {
                return _screen_NetPrice;
            }
            set
            {
                _screen_NetPrice = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_Discount;

        public int Screen_Discount
        {
            get
            {
                return _screen_Discount;
            }
            set
            {
                _screen_Discount = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_DiscountedPrice;

        public decimal Screen_DiscountedPrice
        {
            get
            {
                return _screen_DiscountedPrice;
            }
            set
            {
                _screen_DiscountedPrice = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_DiscountedPriceWithoutVat;

        public decimal Screen_DiscountedPriceWithoutVat
        {
            get
            {
                return _screen_DiscountedPriceWithoutVat;
            }
            set
            {
                _screen_DiscountedPriceWithoutVat = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_LaborAndMobilization;

        public decimal Screen_LaborAndMobilization
        {
            get
            {
                return _screen_LaborAndMobilization;
            }
            set
            {
                _screen_LaborAndMobilization = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screen_TotalNetPriceWithoutVat;

        public decimal Screen_TotalNetPriceWithoutVat
        {
            get
            {
                return _screen_TotalNetPriceWithoutVat;
            }
            set
            {
                _screen_TotalNetPriceWithoutVat = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_PVCVisibility;

        public bool Screen_PVCVisibility
        {
            get
            {
                return _screen_PVCVisibility;
            }
            set
            {
                _screen_PVCVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _springload_checked;

        public bool SpringLoad_Checked
        {
            get
            {
                return _springload_checked;
            }
            set
            {
                _springload_checked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _springLoad_Visibility;

        public bool SpringLoad_Visibility
        {
            get
            {
                return _springLoad_Visibility;
            }
            set
            {
                _springLoad_Visibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_0505Width;

        public int Screen_0505Width
        {
            get
            {
                return _screen_0505Width;
            }
            set
            {
                _screen_0505Width = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_1067Height;

        public int Screen_1067Height
        {
            get
            {
                return _screen_1067Height;
            }
            set
            {
                _screen_1067Height = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_0505Qty;

        public int Screen_0505Qty
        {
            get
            {
                return _screen_0505Qty;
            }
            set
            {
                _screen_0505Qty = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_1067Qty;

        public int Screen_1067Qty
        {
            get
            {
                return _screen_1067Qty;
            }
            set
            {
                _screen_1067Qty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_CenterClosureVisibility;

        public bool Screen_CenterClosureVisibility
        {
            get
            {
                return _screen_CenterClosureVisibility;
            }
            set
            {
                _screen_CenterClosureVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_CenterClosureVisibilityOption;

        public bool Screen_CenterClosureVisibilityOption
        {
            get
            {
                return _screen_CenterClosureVisibilityOption;
            }
            set
            {
                _screen_CenterClosureVisibilityOption = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_LatchKitQty;

        public int Screen_LatchKitQty
        {
            get
            {
                return _screen_LatchKitQty;
            }
            set
            {
                _screen_LatchKitQty = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_IntermediatePartQty;

        public int Screen_IntermediatePartQty
        {
            get
            {
                return _screen_IntermediatePartQty;
            }
            set
            {
                _screen_IntermediatePartQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_6040MilledProfileVisibility;

        public bool Screen_6040MilledProfileVisibility
        {
            get
            {
                return _screen_6040MilledProfileVisibility;
            }
            set
            {
                _screen_6040MilledProfileVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_6040MilledProfile;

        public int Screen_6040MilledProfile
        {
            get
            {
                return _screen_6040MilledProfile;
            }
            set
            {
                _screen_6040MilledProfile = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_6040MilledProfileQty;

        public int Screen_6040MilledProfileQty
        {
            get
            {
                return _screen_6040MilledProfileQty;
            }
            set
            {
                _screen_6040MilledProfileQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_LandCoverVisibility;

        public bool Screen_LandCoverVisibility
        {
            get
            {
                return _screen_LandCoverVisibility;
            }
            set
            {
                _screen_LandCoverVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_LandCover;

        public int Screen_LandCover
        {
            get
            {
                return _screen_LandCover;
            }
            set
            {
                _screen_LandCover = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_LandCoverQty;

        public int Screen_LandCoverQty
        {
            get
            {
                return _screen_LandCoverQty;
            }
            set
            {
                _screen_LandCoverQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_1067PVCboxVisibility;

        public bool Screen_1067PVCboxVisibility
        {
            get
            {
                return _screen_1067PVCboxVisibility;
            }
            set
            {
                _screen_1067PVCboxVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_1067PVCbox;

        public int Screen_1067PVCbox
        {
            get
            {
                return _screen_1067PVCbox;
            }
            set
            {
                _screen_1067PVCbox = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_1067PVCboxQty;

        public int Screen_1067PVCboxQty
        {
            get
            {
                return _screen_1067PVCboxQty;
            }
            set
            {
                _screen_1067PVCboxQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_1385MilledProfileVisibility;

        public bool Screen_1385MilledProfileVisibility
        {
            get
            {
                return _screen_1385MilledProfileVisibility;
            }
            set
            {
                _screen_1385MilledProfileVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_1385MilledProfile;

        public int Screen_1385MilledProfile
        {
            get
            {
                return _screen_1385MilledProfile;
            }
            set
            {
                _screen_1385MilledProfile = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_1385MilledProfileQty;

        public int Screen_1385MilledProfileQty
        {
            get
            {
                return _screen_1385MilledProfileQty;
            }
            set
            {
                _screen_1385MilledProfileQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_373or374MilledProfileVisibility;

        public bool Screen_373or374MilledProfileVisibility
        {
            get
            {
                return _screen_373or374MilledProfileVisibility;
            }
            set
            {
                _screen_373or374MilledProfileVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_373or374MilledProfile;

        public int Screen_373or374MilledProfile
        {
            get
            {
                return _screen_373or374MilledProfile;
            }
            set
            {
                _screen_373or374MilledProfile = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_373or374MilledProfileQty;

        public int Screen_373or374MilledProfileQty
        {
            get
            {
                return _screen_373or374MilledProfileQty;
            }
            set
            {
                _screen_373or374MilledProfileQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_6052MilledProfileVisibility;

        public bool Screen_6052MilledProfileVisibility
        {
            get
            {
                return _screen_6052MilledProfileVisibility;
            }
            set
            {
                _screen_6052MilledProfileVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_6052MilledProfile;

        public int Screen_6052MilledProfile
        {
            get
            {
                return _screen_6052MilledProfile;
            }
            set
            {
                _screen_6052MilledProfile = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_6052MilledProfileQty;

        public int Screen_6052MilledProfileQty
        {
            get
            {
                return _screen_6052MilledProfileQty;
            }
            set
            {
                _screen_6052MilledProfileQty = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_ExchangeRateVisibility;

        public bool Screen_ExchangeRateVisibility
        {
            get
            {
                return _screen_ExchangeRateVisibility;
            }
            set
            {
                _screen_ExchangeRateVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_ExchangeRate;

        public int Screen_ExchangeRate
        {
            get
            {
                return _screen_ExchangeRate;
            }
            set
            {
                _screen_ExchangeRate = value;
                NotifyPropertyChanged();
            }
        }

        private Magnum_ScreenType _magnum_Screen_Type;

        public Magnum_ScreenType Magnum_ScreenType
        {
            get
            {
                return _magnum_Screen_Type;
            }
            set
            {
                _magnum_Screen_Type = value;
                NotifyPropertyChanged();
            }
        }

        private bool _reinforced;

        public bool Reinforced
        {
            get
            {
                return _reinforced;
            }
            set
            {
                _reinforced = value;
                NotifyPropertyChanged();
            }
        }

        private bool _sp_magnumscreenType_visibility;

        public bool SP_MagnumScreenType_Visibility
        {
            get
            {
                return _sp_magnumscreenType_visibility;
            }
            set
            {
                _sp_magnumscreenType_visibility = value;
                NotifyPropertyChanged();
            }
        }

        private int _plissedRd_panels;

        public int PlissedRd_Panels
        {
            get
            {
                return _plissedRd_panels;
            }
            set
            {
                _plissedRd_panels = value;
                NotifyPropertyChanged();
            }
        }

        private string _screen_displayeddimension;

        public string Screen_DisplayedDimension
        {
            get
            {
                return _screen_displayeddimension;
            }
            set
            {
                _screen_displayeddimension = value;
                NotifyPropertyChanged();
            }
        }

        private string _screen_description;

        public string Screen_Description
        {
            get
            {
                return _screen_description;
            }
            set
            {
                _screen_description = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _discountPercentage;

        public decimal DiscountPercentage
        {
            get
            {
                return _discountPercentage;
            }
            set
            {
                _discountPercentage = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _screenItemNumber;

        public decimal Screen_ItemNumber
        {
            get
            {
                return _screenItemNumber;
            }
            set
            {
                _screenItemNumber = value;
                NotifyPropertyChanged();
            }
        }

        private decimal _nxtscreenItemNumber;

        public decimal Screen_NextItemNumber
        {
            get
            {
                return _nxtscreenItemNumber;
            }
            set
            {
                _nxtscreenItemNumber = value;
                NotifyPropertyChanged();
            }
        }

        private Freedom_ScreenSize _freedom_screensize;

        public Freedom_ScreenSize Freedom_ScreenSize
        {
            get
            {
                return _freedom_screensize;
            }
            set
            {
                _freedom_screensize = value;
                NotifyPropertyChanged();
            }
        }

        private Freedom_ScreenType _freedom_screentype;

        public Freedom_ScreenType Freedom_ScreenType
        {
            get
            {
                return _freedom_screentype;
            }
            set
            {
                _freedom_screentype = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_ExchangeRateAUD;

        public int Screen_ExchangeRateAUD
        {
            get
            {
                return _screen_ExchangeRateAUD;
            }
            set
            {
                _screen_ExchangeRateAUD = value;
                NotifyPropertyChanged();
            }
        }

        private bool _frmCellEndEdit;

        public bool FromCellEndEdit
        {
            get
            {
                return _frmCellEndEdit;
            }
            set
            {
                _frmCellEndEdit = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_PriceIncreaseVisibility;
        public bool Screen_PriceIncreaseVisibility
        {
            get
            {
                return _screen_PriceIncreaseVisibility;
            }
            set
            {
                _screen_PriceIncreaseVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _screen_PriceIncreaseVisibilityOption;
        public bool Screen_PriceIncreaseVisibilityOption
        {
            get
            {
                return _screen_PriceIncreaseVisibilityOption;
            }
            set
            {
                _screen_PriceIncreaseVisibilityOption = value;
                NotifyPropertyChanged();
            }
        }

        private int _screen_PriceIncreasePercentage;
        public int Screen_PriceIncreasePercentage
        {
            get
            {
                return _screen_PriceIncreasePercentage;
            }
            set
            {
                _screen_PriceIncreasePercentage = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        List<decimal> ItemList = new List<decimal>();
        public void ItemNumberList()
        {
            var _strippedItemNum = (int)Decimal.Truncate(Screen_ItemNumber);
            Screen_NextItemNumber = _strippedItemNum + 1;

            try
            {
                decimal result = ItemList.First(j => j == Screen_ItemNumber);
                Screen_ItemNumber = 0;
            }
            catch
            {
                Screen_ItemNumber = Screen_ItemNumber;
                ItemList.Add(Screen_ItemNumber);
            }
        }
        public void DeleteItemNumber(decimal x)
        {
            //var _strippedItemNum = (int)Decimal.Truncate(Screen_ItemNumber);
            //Screen_NextItemNumber = _strippedItemNum - 1;                     
            ItemList.Remove(x);
        }

        public void PriceIncreaseByPercentage()
        {
            if (Screen_PriceIncreaseVisibilityOption == true)
            {
                if (FromCellEndEdit != true)
                {
                    IncreasePercentage = Screen_PriceIncreasePercentage / 100m;
                    TotalUnitPrice = ((Screen_UnitPrice * IncreasePercentage) + Screen_UnitPrice);
                    Console.WriteLine(" Percentage increase by " + IncreasePercentage);
                    Console.WriteLine(" TotalUnitPrice " + TotalUnitPrice);
                    Screen_UnitPrice = TotalUnitPrice;
                }
            }

        }

        public void BuiltInPrice_and_PriceInterpolation()
        {
            int loopCounter = 1;

            #region Screen Dimension Selector 

            if (Screen_Width < 1000 || Screen_Height < 1500)
            {
                if (Screen_Width < 1000 && Screen_Height < 1500)
               {
                    _screenWidthOriginalDimension = _screen_Width;
                    _screenHeightOriginalDimension = _screen_Height;
                    _width_builtInInterpolationNewDimension = 3000 - Screen_Width;
                    _height_builtInInterpolationNewDimension = 3000 - Screen_Height;
                    _screen_Width = 1000;
                    _screen_Height = 1500;

                    _builtInWidthIsBelowMinimum = true;
                    _builInHeigthIsBelowMinimum = true;
                }

                else if(Screen_Width < 1000)
                {
                    _screenWidthOriginalDimension = _screen_Width;
                    _width_builtInInterpolationNewDimension = 3000 - Screen_Width; 
                    _screen_Width = 1000; 
                    _builtInWidthIsBelowMinimum = true;
                }
                else if(Screen_Height < 1500)
                {
                    _screenHeightOriginalDimension = _screen_Height;
                    _height_builtInInterpolationNewDimension = 3000 - Screen_Height;
                    _screen_Height = 1500;
                    _builInHeigthIsBelowMinimum = true;
                }
                loopCountLimit = 2;
            }
            else
            {
                loopCountLimit = 1;
            }

            #endregion

            do
            {
                #region Change Screen dimension for interpolation
                if (loopCountLimit == 2)
                {
                    if (loopCounter == 2)
                    {
                        if (_builtInWidthIsBelowMinimum == true && _builInHeigthIsBelowMinimum == true)
                        {
                            _screen_Width = _width_builtInInterpolationNewDimension;
                            _screen_Height = _height_builtInInterpolationNewDimension;
                        }
                        else if(_builtInWidthIsBelowMinimum == true)
                        {
                            _screen_Width = _width_builtInInterpolationNewDimension;
                        }
                        else if (_builInHeigthIsBelowMinimum == true)
                        {
                            _screen_Height = _height_builtInInterpolationNewDimension;
                        }
                    }
                }
                #endregion

                #region Built in SideRoll

                Height_mm_to_meters = Screen_Height / 1000m;
                Width_mm_to_meters = Screen_Width / 1000m;

                #region Height Price List

                if (Screen_Factor >= 2.2m && Screen_Factor < 2.3m)
                {
                    base_Price = 11391.60m;

                    height_Base_Price_Inc = 347.6m;
                    height_Base_Price_List[0] = base_Price;
                }
                else if (Screen_Factor >= 2.3m && Screen_Factor < 2.4m)
                {
                    base_Price = 11909.40m;
                    height_Base_Price_Inc = 363.4m;
                    height_Base_Price_List[0] = base_Price;
                }
                else
                {
                    base_Price = 12427.20m;
                    height_Base_Price_Inc = 379.2m;
                    height_Base_Price_List[0] = base_Price;
                }




                for (int i = 1; i < 16m; i++)
                {
                    temp = base_Price + height_Base_Price_Inc;
                    height_Base_Price_List[i] = temp;
                    base_Price = temp;
                }

                if (Height_mm_to_meters >= 1.5m && Height_mm_to_meters < 1.6m)
                {
                    height_deci = (Height_mm_to_meters - 1.5m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[0] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 1.6m && Height_mm_to_meters < 1.7m)
                {
                    height_deci = (Height_mm_to_meters - 1.6m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[1] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 1.7m && Height_mm_to_meters < 1.8m)
                {
                    height_deci = (Height_mm_to_meters - 1.7m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[2] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 1.8m && Height_mm_to_meters < 1.9m)
                {
                    height_deci = (Height_mm_to_meters - 1.8m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[3] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 1.9m && Height_mm_to_meters < 2.0m)
                {
                    height_deci = (Height_mm_to_meters - 1.9m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[4] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.0m && Height_mm_to_meters < 2.1m)
                {
                    height_deci = (Height_mm_to_meters - 2.0m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[5] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.1m && Height_mm_to_meters < 2.2m)
                {
                    height_deci = (Height_mm_to_meters - 2.1m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[6] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.2m && Height_mm_to_meters < 2.3m)
                {
                    height_deci = (Height_mm_to_meters - 2.2m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[7] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.3m && Height_mm_to_meters < 2.4m)
                {
                    height_deci = (Height_mm_to_meters - 2.3m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[8] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.4m && Height_mm_to_meters < 2.5m)
                {
                    height_deci = (Height_mm_to_meters - 2.4m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[9] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.5m && Height_mm_to_meters < 2.6m)
                {
                    height_deci = (Height_mm_to_meters - 2.5m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[10] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.6m && Height_mm_to_meters < 2.7m)
                {
                    height_deci = (Height_mm_to_meters - 2.6m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[11] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.7m && Height_mm_to_meters < 2.8m)
                {
                    height_deci = (Height_mm_to_meters - 2.7m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[12] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.8m && Height_mm_to_meters < 2.9m)
                {
                    height_deci = (Height_mm_to_meters - 2.8m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[13] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 2.9m && Height_mm_to_meters < 3.0m)
                {
                    height_deci = (Height_mm_to_meters - 2.9m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[14] + percentage_multiplier;
                }
                else if (Height_mm_to_meters >= 3.0m)
                {
                    height_deci = (Height_mm_to_meters - 3.0m) / 0.1m;
                    percentage_multiplier = height_Base_Price_Inc * height_deci;
                    price_base_on_Height = height_Base_Price_List[15] + percentage_multiplier;
                }

                #endregion

                #region width price list

                if (Screen_Factor >= 2.2m && Screen_Factor < 2.3m)
                {
                    #region 2.2
                    width_Base_Price_List[0] = price_base_on_Height;

                    for (int i = 1; i <= 20; i++)
                    {
                        holder = indices_pos[curr_index_pos];

                        if (i == holder)
                        {
                            width_Base_Price_Inc = 132m;
                            curr_index_pos++;
                        }
                        else
                        {
                            width_Base_Price_Inc = 134.2m;
                        }
                        temp = price_base_on_Height + width_Base_Price_Inc;
                        width_Base_Price_List[i] = temp;
                        price_base_on_Height = temp;

                        current_deci_index = deci_getter[i];
                        next_deci_index = deci_getter[i + 1];


                        if (Width_mm_to_meters >= current_deci_index && Width_mm_to_meters < next_deci_index)
                        {
                            if (current_deci_index == 1.1m || current_deci_index == 1.5m || current_deci_index == 2.0m || current_deci_index == 2.5m || current_deci_index == 2.9m)
                            {
                                width_Base_Price_Inc = 132m;
                            }
                            else
                            {
                                width_Base_Price_Inc = 134.2m;
                            }

                            weight_deci = (Width_mm_to_meters - deci_getter[i]) / 0.1m;
                            percentage_multiplier = width_Base_Price_Inc * weight_deci;
                            price_base_on_Weight = Math.Round(width_Base_Price_List[i], 2) + percentage_multiplier;
                            break;
                        }
                        else if (Width_mm_to_meters >= 1.0m && Width_mm_to_meters < 1.1m)
                        {
                            price_base_on_Weight = width_Base_Price_List[0];
                            break;
                        }
                    }
                    built_in_SR_tAmount = (price_base_on_Weight / 2.2m);
                    #endregion
                }
                else if (Screen_Factor >= 2.3m && Screen_Factor < 2.4m)
                {
                    #region 2.3
                    width_Base_Price_List[0] = price_base_on_Height;

                    for (int i = 1; i <= 20; i++)
                    {
                        holder = indices_pos[curr_index_pos];

                        if (i == holder)
                        {
                            width_Base_Price_Inc = 138m;
                            curr_index_pos++;
                        }
                        else
                        {
                            width_Base_Price_Inc = 140.3m;
                        }

                        temp = price_base_on_Height + width_Base_Price_Inc;
                        width_Base_Price_List[i] = temp;
                        price_base_on_Height = temp;

                        current_deci_index = deci_getter[i];
                        next_deci_index = deci_getter[i + 1];


                        if (Width_mm_to_meters >= current_deci_index && Width_mm_to_meters < next_deci_index)
                        {
                            if (current_deci_index == 1.1m || current_deci_index == 1.5m || current_deci_index == 2.0m || current_deci_index == 2.5m || current_deci_index == 2.9m)
                            {
                                width_Base_Price_Inc = 138m;
                            }
                            else
                            {
                                width_Base_Price_Inc = 140.3m;
                            }

                            weight_deci = (Width_mm_to_meters - deci_getter[i]) / 0.1m;
                            percentage_multiplier = width_Base_Price_Inc * weight_deci;
                            price_base_on_Weight = Math.Round(width_Base_Price_List[i], 2) + percentage_multiplier;
                            break;
                        }
                        else if (Width_mm_to_meters >= 1.0m && Width_mm_to_meters < 1.1m)
                        {
                            price_base_on_Weight = width_Base_Price_List[0];
                            break;
                        }
                    }
                    built_in_SR_tAmount = (price_base_on_Weight / 2.3m);
                    #endregion
                }
                else
                {
                    #region 2.4
                    width_Base_Price_List[0] = price_base_on_Height;

                    for (int i = 1; i <= 20; i++)
                    {
                        holder = indices_pos[curr_index_pos];

                        if (i == holder)
                        {
                            width_Base_Price_Inc = 144m;
                            curr_index_pos++;
                        }
                        else
                        {
                            width_Base_Price_Inc = 146.4m;
                        }

                        temp = price_base_on_Height + width_Base_Price_Inc;
                        width_Base_Price_List[i] = temp;
                        price_base_on_Height = temp;

                        current_deci_index = deci_getter[i];
                        next_deci_index = deci_getter[i + 1];


                        if (Width_mm_to_meters >= current_deci_index && Width_mm_to_meters < next_deci_index)
                        {
                            if (current_deci_index == 1.1m || current_deci_index == 1.5m || current_deci_index == 2.0m || current_deci_index == 2.5m || current_deci_index == 2.9m)
                            {
                                width_Base_Price_Inc = 144m;
                            }
                            else
                            {
                                width_Base_Price_Inc = 146.4m;
                            }

                            weight_deci = (Width_mm_to_meters - deci_getter[i]) / 0.1m;
                            percentage_multiplier = width_Base_Price_Inc * weight_deci;
                            price_base_on_Weight = width_Base_Price_List[i] + percentage_multiplier;
                            break;
                        }
                        else if (Width_mm_to_meters >= 1.0m && Width_mm_to_meters < 1.1m)
                        {
                            price_base_on_Weight = width_Base_Price_List[0];
                            break;
                        }
                    }
                    built_in_SR_tAmount = (price_base_on_Weight / 2.4m);

                    #endregion
                }

                #endregion

                #endregion                          
           
                #region BuiltInPrice Selector
                if (loopCountLimit == 2)
                {
                    if(loopCounter == 1)
                    {
                        _firstLoopInterpolatePrice = (Math.Round(built_in_SR_tAmount, 2) * (Screen_Factor + .6m)); // lowest price using lowest dimension possible W or H        
                        ClearingOperation();        
                    }
                    else if(loopCounter == 2)
                    {
                        _secondLoopInterpolatePrice = (Math.Round(built_in_SR_tAmount, 2) * (Screen_Factor + .6m));
                        _builtinInterpolationPrice = _firstLoopInterpolatePrice + (_firstLoopInterpolatePrice - _secondLoopInterpolatePrice);                       
                        built_in_SR_tAmount = _builtinInterpolationPrice * _builtinPowderCoatingMultiplier;

                        if (_builtInWidthIsBelowMinimum == true && _builInHeigthIsBelowMinimum == true)
                        {
                            _screen_Width = _screenWidthOriginalDimension;
                            _screen_Height = _screenHeightOriginalDimension;
                        }
                        else if(_builtInWidthIsBelowMinimum == true)
                        {
                            _screen_Width = _screenWidthOriginalDimension;
                        }
                        else if(_builInHeigthIsBelowMinimum == true)
                        {
                            _screen_Height = _screenHeightOriginalDimension;
                        }

                    }
                }
                else if(loopCountLimit == 1)
                {
                      built_in_SR_tAmount = (Math.Round(built_in_SR_tAmount, 2) * (Screen_Factor + .6m) * _builtinPowderCoatingMultiplier);
                }
                #endregion

                loopCounter++;
            } while (loopCounter <= loopCountLimit);

            _builtInWidthIsBelowMinimum = false;
            _builInHeigthIsBelowMinimum = false;
        }

        public void ComputeScreenTotalPrice()
        {
            #region priceBaseOnColor

            if (Screen_BaseColor == Base_Color._White ||
                Screen_BaseColor == Base_Color._Ivory)
            {
                pvc1067PriceLinearMeter = 420;
                pvc0505PricePerLinearMeter = 300;

                pvc1067withreinforcementPriceLinearMeter = 410;
                milledprofile6040PriceLinearMeter = 325;
                landCoverPriceLinearMeter = 560;

                milled373or374PricePerLinearMeter = 150;

                milled1385profilePricePerLinearMeter = 243;
                milled6052profilePricePerLinearMeter = 400;

                _builtinPowderCoatingMultiplier = 1.08m;
            }
            else if (Screen_BaseColor == Base_Color._DarkBrown)
            {
                pvc1067PriceLinearMeter = 735;
                pvc0505PricePerLinearMeter = 495;

                pvc1067withreinforcementPriceLinearMeter = 660;
                milledprofile6040PriceLinearMeter = 500;
                landCoverPriceLinearMeter = 745;

                milled373or374PricePerLinearMeter = 220;

                milled1385profilePricePerLinearMeter = 600;
                milled6052profilePricePerLinearMeter = 590;

                _builtinPowderCoatingMultiplier = 1.2m;

            }

            #endregion
            #region screen default quantity & discount 

            if (Screen_Quantity == 0)
            {
                Screen_Quantity = 1;
            }

            if (DiscountPercentage == 0)
            {
                DiscountPercentage = 0.3m;
            }

            #endregion
            #region AddOnsSpecialFactor
            if(Screen_AddOnsSpecialFactor == 1.3m)
            {
                AddOnsSpecialFactor = 2.9m;
            }
            else
            {
                AddOnsSpecialFactor = 3.0m;
            }
            Console.WriteLine("Addons is using a Factor " + AddOnsSpecialFactor);

            #endregion

            #region ChangeScreenWidthPerPanel
            //if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._SR && _screenOriginalWidth != 0)
            //{
            //    if (Screen_Width == _plisséSRPerPanelWidth)
            //    {
            //        Screen_Width = _screenOriginalWidth;
            //    }
            //    else
            //    {
            //        Screen_Width = Screen_Width;
            //    }
            //}
            //else
            //{
            //    Screen_Width = Screen_Width;
            //}
            #endregion

            if (Screen_Width != 0 &&
                Screen_Height != 0 &&
                Screen_Factor != 0 || FromCellEndEdit == true)
            {

                if (Screen_Types == ScreenType._RollUp)
                {
                    #region RollUp 
                    if (Screen_BaseColor == Base_Color._White ||
                        Screen_BaseColor == Base_Color._Ivory)
                    {
                        #region Default Roll-Up Mats

                        HeadRailPricePerLinearMeter_White = (26.46m / 5.8m) * Screen_ExchangeRate * 1.42m;
                        SlidingBarPricePerPiece_White = (16.92m / 5.8m) * Screen_ExchangeRate * 1.42m;
                        MeshWithTubePricePerLinearMeter_White = 58.45761m / 5.8m * Screen_ExchangeRate;
                        GuidePricePerLinearMeter_White = 14.18m / 5.8m * Screen_ExchangeRate * 1.42m;
                        PilePricePerLinearMeter_White = 0.15396m * Screen_ExchangeRate;
                        AntiwindBrushPricePerLinearMeter_White = 0.38639m * Screen_ExchangeRate;
                        KitForVerticalOpeningHeadrailPricePerLinearMeter_White = 4.2108m * Screen_ExchangeRate;
                        BrakePriceperPiece_White = 2.5m * Screen_ExchangeRate * BrakeQty;
                        SupportForFixingHeadRailPricePerLinearMeter_White = 0.4773m * Screen_ExchangeRate;

                        if (Screen_Width >= 1500)
                        {
                            SpringLoadedPricePerPiece_White = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * Screen_ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion

                        HeadRailPrice = (HeadRailPricePerLinearMeter_White * HeadRailQty * Screen_Width) / 1000m;
                        SlidingBarPrice = (SlidingBarPricePerPiece_White * SlidingBarQty * Screen_Width) / 1000m;
                        MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_White * MeshWithTubeQty * Screen_Width) / 1000m;
                        GuidePrice = (GuidePricePerLinearMeter_White * GuideQty * Screen_Height) / 1000m;
                        PilePrice = ((Screen_Height + Screen_Width) * PilePricePerLinearMeter_White * PileQty) / 1000m;
                        AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_White * AntiwindBrushQty * Screen_Height) / 1000m;
                        KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_White * KitForVerticalOpeningHeadrailQty;
                        BrakePrice = 2.5m * Screen_ExchangeRate * BrakeQty;
                        SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_White * SupportForFixingHeadRailQty;

                        if (SpringLoad_Checked == true)
                        {
                            SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * Screen_ExchangeRate * 1.05m * 1.15m * SpringLoadedQty;
                        }


                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {
                        #region defaultMats

                        HeadRailPricePerLinearMeter_WoodGrain = 5.574m * Screen_ExchangeRate * 1.4m;
                        SlidingBarPricePerPiece_WoodGrain = 3.606m * Screen_ExchangeRate * 1.4m;
                        MeshWithTubePricePerLinearMeter_WoodGrain = 58.45761m / 5.8m * Screen_ExchangeRate;
                        GuidePricePerLinearMeter_WoodGrain = 3.398m * Screen_ExchangeRate * 1.4m;
                        PilePricePerLinearMeter_WoodGrain = 0.15396m * Screen_ExchangeRate;
                        AntiwindBrushPricePerLinearMeter_WoodGrain = 0.38639m * Screen_ExchangeRate;
                        KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain = 4.2108m * Screen_ExchangeRate;
                        BrakePriceperPiece_WoodGrain = 2.5m * Screen_ExchangeRate;
                        SupportForFixingHeadRailPricePerLinearMeter_WoodGrain = 0.4773m * Screen_ExchangeRate;
                        if (Screen_Width >= 1500)
                        {
                            SpringLoadedPricePerPiece_WoodGrain = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * Screen_ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion

                        HeadRailPrice = (HeadRailPricePerLinearMeter_WoodGrain * HeadRailQty * Screen_Width) / 1000m;
                        SlidingBarPrice = (SlidingBarPricePerPiece_WoodGrain * SlidingBarQty * Screen_Width) / 1000m;
                        MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_WoodGrain * MeshWithTubeQty * Screen_Width) / 1000m;
                        GuidePrice = (GuidePricePerLinearMeter_WoodGrain * GuideQty * Screen_Height) / 1000m;
                        PilePrice = ((Screen_Height + Screen_Width) * PilePricePerLinearMeter_WoodGrain * PileQty) / 1000m;
                        AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_WoodGrain * AntiwindBrushQty * Screen_Height) / 1000m;
                        KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain * KitForVerticalOpeningHeadrailQty;
                        BrakePrice = 2.5m * Screen_ExchangeRate;
                        SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_WoodGrain * SupportForFixingHeadRailQty;

                        if (SpringLoad_Checked == true)
                        {
                            SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * Screen_ExchangeRate * 1.05m * 1.15m * SpringLoadedQty;
                        }


                    }
                    RollUpCostingMaterials = HeadRailPrice +
                    SlidingBarPrice +
                    MeshWithTubePrice +
                    GuidePrice +
                    PilePrice +
                    AntiwindBrushPrice;


                    TotalRollUpCostingMaterials = (RollUpCostingMaterials +
                                                   KitForVerticalOpeningHeadrailPrice +
                                                   BrakePrice +
                                                   SupportForFixingHeadRailPrice +
                                                   SpringLoadedPrice);

                    OverheadCost = 0.2m * 6000;
                    WithWasteCost = 1;
                    #endregion
                }
                else if (Screen_Types == ScreenType._Plisse)
                {
                    #region Plisse AD
                    if (Screen_PlisséType == PlisseType._AD || Screen_PlisséType == PlisseType._RD)
                    {
                        HandlesPrice = 0.5009m * 2;
                        CouplingProfilePrice = 0.43m * Screen_Height / 1000;

                        AluminumBottomGuidePrice = 775 * 1.3m * Screen_Width / 1000 / 6;
                        AluminumPlisseHandlePrice = 300 * 1.3m * Screen_Height / 1000 / 6.4m;

                        LocalMaterialPrice = AluminumBottomGuidePrice +
                                             AluminumPlisseHandlePrice;

                        PPPleatingNETHQty = (Screen_Width / 1000m) * 1.3736m;
                        PPPleatingNETHPrice = PPPleatingNETHQty * PPPleatingNETHPricePerLinearMeter;
                        BottomRail2p5mBarsQty = Screen_Width > 800 ? 0.5m : 0.33m;
                        BottomRail2p5mBarsPrice = BottomRail2p5mBarsQty * BottomRail2p5mBarsPricePerPiece;
                        SettingPlate2p6mbarsPrice = 2 * SettingPlate2p6mbarsPricePricePerPiece;
                        FinplateBarsPrice = Screen_Height < 2300 ? 2.0850m : 2.2391m;
                        ScorpionfishLDPrice = 1.45m;
                        ScorpionfishRDPrice = 1.45m;
                        AnchorplatePriceQty = Screen_Height > 2550 ? 4 : 3;
                        AnchorplatePrice = AnchorplatePriceQty * AnchorplatePricePerPiece;
                        Scorpiontail3Qty = Screen_Width * 0.09m / 2;
                        Scorpiontail3Price = Scorpiontail3Qty * Scorpiontail3PricePerPiece;
                        WireEndtailYellowPrice = 6 * WireEndtailYellowPricePerPiece;
                        AjustEightTailPrice = 2 * AjustEightTailPricePerPiece;
                        TailEndPrice = 0.27m;
                        TailReversalPrice = 0.25m;
                        WireGuideCenterPrice = 8 * WireGuideCenterPricePerPiece;
                        WireGuideRPrice = 2 * WireGuideRPricePerPiece;
                        WireGuideLPrice = 2 * WireGuideLPricePerPiece;
                        WireCB40051PriceQty = ((Screen_Width + 5 * (Screen_Height / 5) + 300) + (Screen_Width + 4 * (Screen_Height / 5) + 300) + (Screen_Width + 3 * (Screen_Height / 5) + 300) + (Screen_Width + 2 * (Screen_Height / 5) + 300) + (Screen_Width + 1 * (Screen_Height / 5) + 300) + (Screen_Width + 300) + (Screen_Height)) / 1000m;
                        WireCB40051Price = WireCB40051PriceQty * WireCB40051PricePerLinearMeter;
                        TappingScrew3X30BHPrice = 2 * TappingScrew3X30BHPricePerPiece;
                        RollOutMagnetQty = Screen_Height / 1000m;
                        RollOutPositiveMagnetPrice = RollOutMagnetQty * RollOutMagnetPricePerLinearMeter;
                        RollOutNegativeMagnetPrice = RollOutMagnetQty * RollOutMagnetPricePerLinearMeter;

                        LatchForResizablePlissèPrice = LatchForResizablePlissèPricePerPiece;
                        ScrewForLatchPrice = 2 * ScrewForLatchPricePerPiece;
                        SlidingBarEndCapResizablePlissèPrice = 1.67m;
                        WallProfileEndCapResizablePlissèPrice = 1.83m;
                        TopGuideEndCapResizablePlissèPrice = 1.52m;
                        CordCurrierResizablePlissèPrice = 1.09m;
                        TensionerPrice = 0.18m;
                        ScrewForTensionerPrice = 2 * 0.06m;
                        HammerNutResizablePlissèPrice = 2.50m;
                        Grub5x20Price = 0.32m;

                        WaSbarQty = Screen_Height / 1000m;

                        if (Screen_BaseColor == Base_Color._White ||
                            Screen_BaseColor == Base_Color._Ivory)
                        {
                            WallBarPrice = WaSbarQty * WallBarOxRALStandardPricePerLinearMeter;
                            SlideBarPrice = WaSbarQty * SlideBarOxRALStandardPricePerLinearMeter;
                            TopGuideResizablePlissèPrice = (Screen_Width / 1000m) * TopGuideResizablePlissèMillFinishedPricePerLinearMeter;
                            UprofileForMagnetPrice = WaSbarQty * UprofileForMagnetMillFinishedPricePerLinearMeter;
                            PlisseLProfileFrontalFixingPrice = (WaSbarQty * 2) * PlisseLProfileFrontalFixingMillFinishedPricePerLinearMeter;
                            PlisseCoverLProfileFrontingFixingPrice = (WaSbarQty * 2) * PlisseCoverLProfileFrontingFixingMillFinishPricePerLinearMeter;

                            PliseeLandCoverPrice = (20.07495m + 12.9915m) / 5.8m * Screen_Width / 1000m;
                        }
                        else if (Screen_BaseColor == Base_Color._DarkBrown)
                        {
                            WallBarPrice = WaSbarQty * WallBarWoodFinishedPricePerLinearMeter;
                            SlideBarPrice = WaSbarQty * SlideBarWoodFinishedPricePerLinearMeter;
                            TopGuideResizablePlissèPrice = (Screen_Width / 1000m) * TopGuideResizablePlissèWoodFinishedPricePerLinearMeter;
                            UprofileForMagnetPrice = WaSbarQty * UprofileForMagnetWoodFinishedPricePerLinearMeter;
                            PlisseLProfileFrontalFixingPrice = (WaSbarQty * 2) * PlisseLProfileFrontalFixingWoodFinishedPerLinearMeter;
                            PlisseCoverLProfileFrontingFixingPrice = (WaSbarQty * 2) * PlisseCoverLProfileFrontingFixingWoodFinishedPricePerLinearMeter;

                            PliseeLandCoverPrice = (4.509m + 3.12m) * Screen_Width / 1000m;
                        }
                        PlisseCostingMaterials = Math.Round(PPPleatingNETHPrice, 2) +
                                                   Math.Round(BottomRail2p5mBarsPrice, 2) +
                                                   Math.Round(SettingPlate2p6mbarsPrice, 2) +
                                                   Math.Round(FinplateBarsPrice, 2) +
                                                   Math.Round(ScorpionfishLDPrice, 2) +
                                                   Math.Round(ScorpionfishRDPrice, 2) +
                                                   Math.Round(AnchorplatePrice, 2) +
                                                   Math.Round(Scorpiontail3Price, 2) +
                                                   Math.Round(WireEndtailYellowPrice, 2) +
                                                   Math.Round(AjustEightTailPrice, 2) +
                                                   Math.Round(TailEndPrice, 2) +
                                                   Math.Round(TailReversalPrice, 2) +
                                                   Math.Round(WireGuideCenterPrice, 2) +
                                                   Math.Round(WireGuideRPrice, 2) +
                                                   Math.Round(WireGuideLPrice, 2) +
                                                   Math.Round(WireCB40051Price, 2) +
                                                   Math.Round(TappingScrew3X30BHPrice, 2) +
                                                   Math.Round(RollOutPositiveMagnetPrice, 2) +
                                                   Math.Round(RollOutNegativeMagnetPrice, 2) +
                                                   Math.Round(LatchForResizablePlissèPrice, 2) +
                                                   Math.Round(ScrewForLatchPrice, 2) +
                                                   Math.Round(SlidingBarEndCapResizablePlissèPrice, 2) +
                                                   Math.Round(WallProfileEndCapResizablePlissèPrice, 2) +
                                                   Math.Round(TopGuideEndCapResizablePlissèPrice, 2) +
                                                   Math.Round(CordCurrierResizablePlissèPrice, 2) +
                                                   Math.Round(TensionerPrice, 2) +
                                                   Math.Round(ScrewForTensionerPrice, 2) +
                                                   Math.Round(HammerNutResizablePlissèPrice, 2) +
                                                   Math.Round(Grub5x20Price, 2) +
                                                   Math.Round(WallBarPrice, 2) +
                                                   Math.Round(SlideBarPrice, 2) +
                                                   Math.Round(TopGuideResizablePlissèPrice, 2) +
                                                   Math.Round(UprofileForMagnetPrice, 2) +
                                                   Math.Round(PlisseLProfileFrontalFixingPrice, 2) +
                                                   Math.Round(PlisseCoverLProfileFrontingFixingPrice, 2);

                        TotalPlisseCostingMaterials = (HandlesPrice +
                                                      CouplingProfilePrice +
                                                      PliseeLandCoverPrice +
                                                      PlisseCostingMaterials) * Screen_ExchangeRate;

                        OverheadCost = 0.3333m * 6000;
                        WithWasteCost = 0;
                    }
                    #endregion

                    #region Plisse SR
                    else if (Screen_PlisséType == PlisseType._SR)
                    {
                        #region Magnum 


                        if (Magnum_ScreenType == Magnum_ScreenType._Single_Fixed)
                        {
                            #region single horizontal one side fixed 

                            #region General Item

                            PleatedMeshSingleFixed_Qty = (1.374m * (Screen_Width / 1000m));
                            PleatedMeshSingeFixed_tCost = PleatedMeshSingleFixed_Qty * PleatedMeshNera_Price;

                            Wire_Qty = (2 * (2 * Screen_Width / 1000m + 3 * Screen_Height / 1000m + 1.2m) + 2 * (Screen_Width / 1000m + Screen_Height / 1000m + 0.8m)) * 0.66666666666667m;
                            Wire_tCost = Wire_Qty * Wire_Price;

                            Bushing_tCost = Bushing_SingleOneSideFixed_Qty * Bushing_Price;

                            TensionerNoGrubs_tCost = TensionerNoGrubs_Qty * TensionerNoGrubs_Price;

                            Grubs4x6_tCost = Grubs4x6_Qty * Grubs4x6_Price;

                            CordCurriere3Holes_tCost = CordCurriere3Holes_Qty * CordCurriere3Holes_Price;

                            SpringForTensioner_tCost = SpringForTensioner_Qty * SpringForTensioner_Price;

                            BottomEndCapMagnum31mmHorizontalNoWheel_tCost = BottomEndCapMagnum31mmHorizontalNoWheel_SingleOneSideFixed_Qty * BottomEndCapMagnum31mmForHorizontalNoWHeel_Price;

                            TopEndCapMagnum31mmHorizontalNoWheel_tCost = TopEndCapMagnum31mmHorizontalNoWheel_SingleOneSideFixed_Qty * TopEndCapMagnum31mmForHorizontalNoWheel_Price;

                            Wheel_tCost = Wheel_SingleOneSideFixed_Qty * Wheel_Price;

                            PinForWheel_tCost = PinForWheel_SingleOneSideFixed_Qty * PinForWheel_Price;

                            AdhesiveTapeAluminumPlate_Qty = (Screen_Height * 2 / 1000m);
                            AdhesiveTapeAluminumPlate_tCost = AdhesiveTapeAluminumPlate_Qty * AdhesiveTapeForAluminum_Price;

                            AdhesiveTapeBottomGuide_Qty = (Screen_Width / 1000m);
                            AdhesiveTapeBottomGuide_tCost = AdhesiveTapeBottomGuide_Qty * AdhesiveTapeForBottomGuide_Price;

                            MinyClips_tCost = MinyClips_SingleOneSideFixed_Qty * MinyClips_Price;

                            MagnetsClicIntoRollinFly_Qty = (Screen_Height / 1000m);
                            MagnetsClicIntoRollinFly_tCost = MagnetsClicIntoRollinFly_Qty * MagnetToClicIntoRollInFly_Price;

                            NegativeMagntePlisse_Qty = (Screen_Height / 1000m);
                            NegativeMagntePlisse_tCost = NegativeMagntePlisse_Qty * NegativeMagnetPlisse_Price;


                            var gen_Item_Total_Price = PleatedMeshSingeFixed_tCost + Wire_tCost + Bushing_tCost + TensionerNoGrubs_tCost + Grubs4x6_tCost + CordCurriere3Holes_tCost +
                                                       SpringForTensioner_tCost + BottomEndCapMagnum31mmHorizontalNoWheel_tCost + TopEndCapMagnum31mmHorizontalNoWheel_tCost + Wheel_tCost +
                                                       PinForWheel_tCost + AdhesiveTapeAluminumPlate_tCost + AdhesiveTapeBottomGuide_tCost + MinyClips_tCost + MagnetsClicIntoRollinFly_tCost +
                                                       NegativeMagntePlisse_tCost;
                            #endregion

                            #region RAL Color 
                            AluminumPlateWithTeeth_RALColor_Qty = Screen_Height / 1000m;
                            AluminumPlateWithTeeth_RALColor_tCost = AluminumPlateWithTeeth_RALColor_Qty * AluminumPlateWithTeeth_RALColor_Price;

                            AluminumPlateNoTeeth_RALColor_Qty = Screen_Height / 1000m;
                            AluminumPlateNoTeeth_RALColor_tCost = AluminumPlateWithTeeth_RALColor_Qty * AluminumPlateNoTeeth_RALColor_Price;

                            Magnum31mmSlidingBar_RALColor_Qty = Screen_Height / 1000m;
                            Magnum31mmSlidingBar_RALColor_tCost = Magnum31mmSlidingBar_RALColor_Qty * Magnum31mmSlidingBar_RALColor_Price;

                            Magnum31mmBottomGuide_RALColor_Qty = Screen_Width / 1000m;
                            Magnum31mmBottomGuide_RALColor_tCost = Magnum31mmBottomGuide_RALColor_Qty * Magnum31mmBottomGuide_RALColor_Price;

                            Magnum31mmTopGuide_RALColor_Qty = Screen_Width / 1000m;
                            Magnum31mmTopGuide_RALColor_tCost = Magnum31mmTopGuide_RALColor_Qty * Magnum31mmTopGuide_RALColor_Price;

                            Magnum31mmTensionersProfile_RALColor_Qty = Screen_Height * 2 / 1000m;
                            Magnum31mmTensionersProfile_RALColor_tCost = Magnum31mmTensionersProfile_RALColor_Qty * Magnum31mmTensionersProfiles_RALColor_Price;

                            Magnum31mmsideU_RALColor_Qty = Screen_Height * 2 / 1000m;
                            Magnum31mmsideU_RALColor_tCost = Magnum31mmsideU_RALColor_Qty * Magnum31mmSideU_RALColor_Price;

                            var ralColor_Item_Total_Price = AluminumPlateWithTeeth_RALColor_tCost + AluminumPlateNoTeeth_RALColor_tCost +
                                                            Magnum31mmSlidingBar_RALColor_tCost + Magnum31mmBottomGuide_RALColor_tCost +
                                                            Magnum31mmTopGuide_RALColor_tCost + Magnum31mmTensionersProfile_RALColor_tCost +
                                                            Magnum31mmsideU_RALColor_tCost;


                            #endregion

                            #region Mill Finish

                            AluminumPlateWithTeeth_MillFinish_tCost = AluminumPlateWithTeeth_MillFinish_SingleOneSideFixed_Qty * AluminumPlateWithTeeth_MillFinish_Price;

                            AluminumPlateNoTeeth_MillFinish_tCost = AluminumPlateNoTeeth_MillFinish_SingleOneSideFixed_Qty * AluminumPlateNoTeeth_MillFinish_Price;

                            Magnum31mmSlidingBar_MillFinish_Qty = Screen_Height / 1000m;
                            Magnum31mmSlidingBar_MillFinish_tCost = Magnum31mmSlidingBar_MillFinish_Qty * Magnum31mmSlidingBar_MillFinish_Price;

                            Magnum31mmBottomGuide_MillFinish_Qty = Screen_Width / 1000m;
                            Magnum31mmBottomGuide_MillFinish_tCost = Magnum31mmBottomGuide_MillFinish_Qty * Magnum31mmBottomGuide_MillFinish_Price;

                            Magnum31mmTopGuide_MillFinish_Qty = Screen_Width / 1000m;
                            Magnum31mmTopGuide_MillFinish_tCost = Magnum31mmTopGuide_MillFinish_Qty * Magnum31mmTopGuide_MillFinish_Price;

                            Magnum31mmTensionersProfile_MillFinish_Qty = Screen_Height * 2 / 1000m;
                            Magnum31mmTensionersProfile_MillFinish_tCost = Magnum31mmTensionersProfile_MillFinish_Qty * Magnum31mmTensionersProfiles_MillFinish_Price;

                            Magnum31mmsideU_MillFinish_Qty = Screen_Height * 2 / 1000m;
                            Magnum31mmsideU_MillFinish_tCost = Magnum31mmsideU_MillFinish_Qty * Magnum31mmSideU_MillFinish_Price;

                            var millFinish_Item_Total_Price = AluminumPlateWithTeeth_MillFinish_tCost + AluminumPlateNoTeeth_MillFinish_tCost +
                                                              Magnum31mmSlidingBar_MillFinish_tCost + Magnum31mmBottomGuide_MillFinish_tCost +
                                                              Magnum31mmTopGuide_MillFinish_tCost + Magnum31mmTensionersProfile_MillFinish_tCost +
                                                              Magnum31mmsideU_MillFinish_tCost;

                            #endregion

                            #region Foiled

                            Magnum31mmSlidingBar_Foiled_tCost = Magnum31mmSlidingBar_RALColor_tCost * 1.42m;
                            Magnum31mmTopGuide_Foiled_tCost = Magnum31mmTopGuide_RALColor_tCost * 1.42m;
                            Magnum31mmsideU_Foiled_tCost = Magnum31mmsideU_RALColor_tCost * 1.42m;

                            var foiled_Item_Total_Price = AluminumPlateWithTeeth_RALColor_tCost + AluminumPlateNoTeeth_RALColor_tCost +
                                                          Magnum31mmSlidingBar_Foiled_tCost + Magnum31mmBottomGuide_RALColor_tCost +
                                                          Magnum31mmTopGuide_Foiled_tCost + Magnum31mmTensionersProfile_RALColor_tCost +
                                                          Magnum31mmsideU_Foiled_tCost;


                            #endregion

                            RALColor_TotalCost = gen_Item_Total_Price + ralColor_Item_Total_Price;
                            MillFinish_TotalCost = gen_Item_Total_Price + millFinish_Item_Total_Price;
                            Foiled_TotalCost = gen_Item_Total_Price + foiled_Item_Total_Price;

                            _whiteFinish = RALColor_TotalCost;
                            _woodFinish = Foiled_TotalCost;

                            #endregion
                        }
                        else if (Magnum_ScreenType == Magnum_ScreenType._Double_Fixed)
                        {
                            #region Double Horizontal

                            #region Gen Item

                            PleatedMeshDoubleHori_Qty = (1.374m * (Screen_Width / 1000m));
                            PleatedMeshDoubleHori_tCost = PleatedMeshDoubleHori_Qty * PleatedMeshNera_Price;

                            Wire_Qty = 2 * (2 * (2 * Screen_Width / 1000m + 3 * Screen_Height / 1000m + 1.2m) + 2 * (Screen_Width / 1000m + Screen_Height / 1000m + 0.8m)) * 0.66666666666667m;
                            Wire_tCost = Wire_Qty * Wire_Price;

                            if (Screen_Height > 2632m)
                            {
                                Bushing_Qty = 32m;
                            }
                            else if (Screen_Height > 1631)
                            {
                                Bushing_Qty = 24m;
                            }
                            else if (Screen_Height <= 1631)
                            {
                                Bushing_Qty = 16m;
                            }

                            Bushing_tCost = Bushing_Qty * Bushing_Price;

                            TensionerNoGrubs_tCost = TensionerNoGrubs_Qty * TensionerNoGrubs_Price;

                            Grubs4x6_tCost = Grubs4x6_Qty * Grubs4x6_Price;

                            CordCurriere3Holes_tCost = CordCurriere3Holes_Qty * CordCurriere3Holes_Price;

                            SpringForTensioner_tCost = SpringForTensioner_Qty * SpringForTensioner_Price;

                            TopEndCapMagnum31mmHorizontalNoWheel_tCost = TopEndCapMagnum31mmHorizontalNoWheel_Qty * TopEndCapMagnum31mmForHorizontalNoWheel_Price;

                            Wheel_tCost = Wheel_Qty * Wheel_Price;

                            PinForWheel_tCost = PinForWheel_Qty * PinForWheel_Price;

                            AdhesiveTapeAluminumPlate_Qty = 2 * (Screen_Height * 2 / 1000m);
                            AdhesiveTapeAluminumPlate_tCost = AdhesiveTapeAluminumPlate_Qty * AdhesiveTapeForAluminum_Price;

                            AdhesiveTapeBottomGuide_Qty = (Screen_Width / 1000m);
                            AdhesiveTapeBottomGuide_tCost = AdhesiveTapeBottomGuide_Qty * AdhesiveTapeForBottomGuide_Price;

                            if (Screen_Height > 3200)
                            {
                                MinyClips_Qty = 14;
                            }
                            else if (Screen_Height > 2900)
                            {
                                MinyClips_Qty = 12;
                            }
                            else if (Screen_Height > 2600)
                            {
                                MinyClips_Qty = 10;
                            }
                            else if (Screen_Height > 2300)
                            {
                                MinyClips_Qty = 8;
                            }
                            else if (Screen_Height <= 2300)
                            {
                                MinyClips_Qty = 6;
                            }

                            MinyClips_tCost = MinyClips_Qty * MinyClips_Price;

                            NegativeMagntePlisse_Qty = (Screen_Height / 1000m);
                            NegativeMagntePlisse_tCost = NegativeMagntePlisse_Qty * NegativeMagnetPlisse_Price;

                            PlissePositivePlisse_Qty = (Screen_Height / 1000m);
                            PlissePositivePlisse_tCost = PlissePositivePlisse_Qty * PlissePositivePlisse_Price;

                            DoubleCentePart_tCost = DoubleCentePart_Qty * DoubleCentePart_Price;

                            BottomEndCapMagnum31mm_DoubleHori_tCost = BottomEndCapMagnum31mm_DoubleHori_Qty * BottomEndCapMagnum31mm_DoubleHori_Price;

                            var gen_Item_Total_Price = PleatedMeshDoubleHori_tCost + Wire_tCost + Bushing_tCost + TensionerNoGrubs_tCost + Grubs4x6_tCost + CordCurriere3Holes_tCost +
                                                       SpringForTensioner_tCost + BottomEndCapMagnum31mmHorizontalNoWheel_tCost + TopEndCapMagnum31mmHorizontalNoWheel_tCost + Wheel_tCost +
                                                       PinForWheel_tCost + AdhesiveTapeAluminumPlate_tCost + AdhesiveTapeBottomGuide_tCost + MinyClips_tCost + MagnetsClicIntoRollinFly_tCost +
                                                       NegativeMagntePlisse_tCost + PlissePositivePlisse_tCost + DoubleCentePart_tCost + BottomEndCapMagnum31mm_DoubleHori_tCost;



                            #endregion

                            #region Ral Color

                            AluminumPlateWithTeeth_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            AluminumPlateWithTeeth_RALColor_tCost = AluminumPlateWithTeeth_RALColor_Qty * AluminumPlateWithTeeth_RALColor_Price;

                            AluminumPlateNoTeeth_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            AluminumPlateNoTeeth_RALColor_tCost = AluminumPlateWithTeeth_RALColor_Qty * AluminumPlateNoTeeth_RALColor_Price;

                            Magnum31mmSlidingBar_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmSlidingBar_RALColor_tCost = Magnum31mmSlidingBar_RALColor_Qty * Magnum31mmSlidingBar_RALColor_Price;

                            Magnum31mmBottomGuide_RALColor_Qty = Screen_Width / 1000m;
                            Magnum31mmBottomGuide_RALColor_tCost = Magnum31mmBottomGuide_RALColor_Qty * Magnum31mmBottomGuide_RALColor_Price;

                            Magnum31mmTopGuide_RALColor_Qty = Screen_Width / 1000m;
                            Magnum31mmTopGuide_RALColor_tCost = Magnum31mmTopGuide_RALColor_Qty * Magnum31mmTopGuide_RALColor_Price;

                            Magnum31mmTensionersProfile_RALColor_Qty = Screen_Height * 2 / 1000m;
                            Magnum31mmTensionersProfile_RALColor_tCost = Magnum31mmTensionersProfile_RALColor_Qty * Magnum31mmTensionersProfiles_RALColor_Price;

                            Magnum31mmsideU_RALColor_Qty = Screen_Height * 2 / 1000m;
                            Magnum31mmsideU_RALColor_tCost = Magnum31mmsideU_RALColor_Qty * Magnum31mmSideU_RALColor_Price;

                            var ralColor_Item_Total_Price = AluminumPlateWithTeeth_RALColor_tCost + AluminumPlateNoTeeth_RALColor_tCost +
                                                            Magnum31mmSlidingBar_RALColor_tCost + Magnum31mmBottomGuide_RALColor_tCost +
                                                            Magnum31mmTopGuide_RALColor_tCost + Magnum31mmTensionersProfile_RALColor_tCost +
                                                            Magnum31mmsideU_RALColor_tCost;



                            #endregion

                            #region Mill Finish

                            AluminumPlateWithTeeth_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            AluminumPlateWithTeeth_MillFinish_tCost = AluminumPlateWithTeeth_MillFinish_Qty * AluminumPlateWithTeeth_MillFinish_Price;

                            AluminumPlateNoTeeth_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            AluminumPlateNoTeeth_MillFinish_tCost = AluminumPlateWithTeeth_MillFinish_Qty * AluminumPlateNoTeeth_MillFinish_Price;

                            Magnum31mmSlidingBar_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmSlidingBar_MillFinish_tCost = Magnum31mmSlidingBar_MillFinish_Qty * Magnum31mmSlidingBar_MillFinish_Price;

                            Magnum31mmBottomGuide_MillFinish_Qty = Screen_Width / 1000m;
                            Magnum31mmBottomGuide_MillFinish_tCost = Magnum31mmBottomGuide_MillFinish_Qty * Magnum31mmBottomGuide_MillFinish_Price;

                            Magnum31mmTopGuide_MillFinish_Qty = Screen_Width / 1000m;
                            Magnum31mmTopGuide_MillFinish_tCost = Magnum31mmTopGuide_MillFinish_Qty * Magnum31mmTopGuide_MillFinish_Price;

                            Magnum31mmTensionersProfile_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmTensionersProfile_MillFinish_tCost = Magnum31mmTensionersProfile_MillFinish_Qty * Magnum31mmTensionersProfiles_MillFinish_Price;


                            Magnum31mmsideU_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmsideU_MillFinish_tCost = Magnum31mmsideU_MillFinish_Qty * Magnum31mmSideU_MillFinish_Price;

                            var millFinish_Item_Total_Price = AluminumPlateWithTeeth_MillFinish_tCost + AluminumPlateNoTeeth_MillFinish_tCost +
                                                             Magnum31mmSlidingBar_MillFinish_tCost + Magnum31mmBottomGuide_MillFinish_tCost +
                                                             Magnum31mmTopGuide_MillFinish_tCost + Magnum31mmTensionersProfile_MillFinish_tCost +
                                                             Magnum31mmsideU_MillFinish_tCost;

                            #endregion

                            #region Foiled

                            Magnum31mmSlidingBar_Foiled_tCost = Magnum31mmSlidingBar_RALColor_tCost * 1.42m;
                            Magnum31mmTopGuide_Foiled_tCost = Magnum31mmTopGuide_RALColor_tCost * 1.42m;
                            Magnum31mmsideU_Foiled_tCost = Magnum31mmsideU_RALColor_tCost * 1.42m;

                            var foiled_Item_Total_Price = AluminumPlateWithTeeth_RALColor_tCost + AluminumPlateNoTeeth_RALColor_tCost +
                                                          Magnum31mmSlidingBar_Foiled_tCost + Magnum31mmBottomGuide_RALColor_tCost +
                                                          Magnum31mmTopGuide_Foiled_tCost + Magnum31mmTensionersProfile_RALColor_tCost +
                                                          Magnum31mmsideU_Foiled_tCost;



                            #endregion


                            RALColor_TotalCost = gen_Item_Total_Price + ralColor_Item_Total_Price;
                            MillFinish_TotalCost = gen_Item_Total_Price + millFinish_Item_Total_Price;
                            Foiled_TotalCost = gen_Item_Total_Price + foiled_Item_Total_Price;

                            _whiteFinish = RALColor_TotalCost;
                            _woodFinish = Foiled_TotalCost;



                            #endregion
                        }
                        else if (Magnum_ScreenType == Magnum_ScreenType._Single_Central)
                        {
                            #region Single Central

                            #region Gen Item

                            PleatedMeshSingleCentral_Qty = (1.374m * (Screen_Width / 1000m));
                            PleatedMeshSingleCentral_tCost = PleatedMeshSingleCentral_Qty * PleatedMeshNera_Price;

                            if (Screen_Height >= 1900)
                            {
                                Wire_Qty = (8 * (Screen_Width / 1000m + Screen_Height / 1000m + 0.8m));
                            }
                            else if (Screen_Height < 1900 && Screen_Height > 1300)
                            {
                                Wire_Qty = (6 * (Screen_Width / 1000m + Screen_Height / 1000m + 0.8m));
                            }

                            if (Screen_Height > 2632)
                            {
                                Bushing_Qty = 16;
                            }
                            else if (Screen_Height > 1631)
                            {
                                Bushing_Qty = 12;
                            }
                            else if (Screen_Height <= 1631)
                            {
                                Bushing_Qty = 8;
                            }

                            Wire_tCost = Wire_Qty * Wire_Price;
                            Bushing_tCost = Bushing_Qty * Bushing_Price;

                            TensionerNoGrubs_tCost = TensionerNoGrubs_Qty * TensionerNoGrubs_Price;

                            Grubs4x6_tCost = Grubs4x6_SingleCentralPack_Qty * Grubs4x6_Price;

                            CordCurriere3Holes_tCost = CordCurriere3Holes_SingleCentralPack_Qty * CordCurriere3Holes_Price;

                            SpringForTensioner_tCost = SpringForTensioner_Qty * SpringForTensioner_Price;

                            BottomEndCapMagnum31mmHorizontalNoWheel_tCost = BottomEndCapMagnum31mmHorizontalNoWheel_SingleCentralPack_Qty * BottomEndCapMagnum31mmForHorizontalNoWHeel_Price;

                            TopEndCapMagnum31mmHorizontalNoWheel_tCost = TopEndCapMagnum31mmHorizontalNoWheel_Qty * TopEndCapMagnum31mmForHorizontalNoWheel_Price;

                            Wheel_tCost = Wheel_Qty * Wheel_Price;

                            PinForWheel_tCost = PinForWheel_Qty * PinForWheel_Price;

                            AdhesiveTapeAluminumPlate_Qty = (Screen_Height * 2) / 1000m;
                            AdhesiveTapeAluminumPlate_tCost = AdhesiveTapeAluminumPlate_Qty * AdhesiveTapeForAluminum_Price;

                            AdhesiveTapeBottomGuide_Qty = Screen_Width / 1000m;
                            AdhesiveTapeBottomGuide_tCost = AdhesiveTapeBottomGuide_Qty * AdhesiveTapeForBottomGuide_Price;

                            if (Screen_Height > 3200)
                            {
                                MinyClips_Qty = 14;
                            }
                            else if (Screen_Height > 2900)
                            {
                                MinyClips_Qty = 12;
                            }
                            else if (Screen_Height > 2600)
                            {
                                MinyClips_Qty = 10;
                            }
                            else if (Screen_Height > 2300)
                            {
                                MinyClips_Qty = 8;
                            }
                            else if (Screen_Height <= 2300)
                            {
                                MinyClips_Qty = 6;
                            }

                            MinyClips_tCost = MinyClips_Qty * MinyClips_Price;

                            MagnetsClicIntoRollinFly_Qty = Screen_Height / 1000m;
                            MagnetsClicIntoRollinFly_tCost = MagnetsClicIntoRollinFly_Qty * MagnetToClicIntoRollInFly_Price;

                            NegativeMagntePlisse_Qty = Screen_Height / 1000m;
                            NegativeMagntePlisse_tCost = NegativeMagntePlisse_Qty * NegativeMagnetPlisse_Price;

                            var gen_Item_Total_Price = PleatedMeshSingleCentral_tCost + Wire_tCost + Bushing_tCost + TensionerNoGrubs_tCost + Grubs4x6_tCost + CordCurriere3Holes_tCost +
                                                       SpringForTensioner_tCost + BottomEndCapMagnum31mmHorizontalNoWheel_tCost + TopEndCapMagnum31mmHorizontalNoWheel_tCost + Wheel_tCost +
                                                       PinForWheel_tCost + AdhesiveTapeAluminumPlate_tCost + AdhesiveTapeBottomGuide_tCost + MinyClips_tCost + MagnetsClicIntoRollinFly_tCost +
                                                       NegativeMagntePlisse_tCost;


                            #endregion

                            #region Ral Color

                            AluminumPlateWithTeeth_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            AluminumPlateWithTeeth_RALColor_tCost = AluminumPlateWithTeeth_RALColor_Qty * AluminumPlateWithTeeth_RALColor_Price;

                            Magnum31mmSlidingBar_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmSlidingBar_RALColor_tCost = Magnum31mmSlidingBar_RALColor_Qty * Magnum31mmSlidingBar_RALColor_SingeleCentral_Price;

                            Magnum31mmBottomGuide_RALColor_Qty = Screen_Width / 1000m;
                            Magnum31mmBottomGuide_RALColor_tCost = Magnum31mmBottomGuide_RALColor_Qty * Magnum31mmBottomGuide_RALColor_SingleCentral_Price;

                            Magnum31mmTopGuide_RALColor_Qty = Screen_Width / 1000m;
                            Magnum31mmTopGuide_RALColor_tCost = Magnum31mmTopGuide_RALColor_Qty * Magnum31mmTopGuide_RALColor_SingleCentral_Price;

                            Magnum31mmTensionersProfile_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmTensionersProfile_RALColor_tCost = Magnum31mmTensionersProfile_RALColor_Qty * Magnum31mmTensionersProfiles_RALColor_SingleCentral_Price;

                            Magnum31mmsideU_RALColor_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmsideU_RALColor_tCost = Magnum31mmsideU_RALColor_Qty * Magnum31mmSideU_RALColor_SingleCentral_Price;

                            var ralColor_Item_Total_Price = AluminumPlateWithTeeth_RALColor_tCost + Magnum31mmSlidingBar_RALColor_tCost +
                                                          Magnum31mmBottomGuide_RALColor_tCost + Magnum31mmTopGuide_RALColor_tCost +
                                                          Magnum31mmTensionersProfile_RALColor_tCost + Magnum31mmsideU_RALColor_tCost;

                            #endregion

                            #region Mill Finish

                            AluminumPlateWithTeeth_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            AluminumPlateWithTeeth_MillFinish_tCost = AluminumPlateWithTeeth_MillFinish_Qty * AluminumPlateWithTeeth_MillFinish_Price;

                            Magnum31mmSlidingBar_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmSlidingBar_MillFinish_tCost = Magnum31mmSlidingBar_MillFinish_Qty * Magnum31mmSlidingBar_MillFinish_SingeleCentral_Price;

                            Magnum31mmBottomGuide_MillFinish_Qty = Screen_Width / 1000m;
                            Magnum31mmBottomGuide_MillFinish_tCost = Magnum31mmBottomGuide_MillFinish_Qty * Magnum31mmBottomGuide_MillFinish_SingleCentral_Price;

                            Magnum31mmTopGuide_MillFinish_Qty = Screen_Width / 1000m;
                            Magnum31mmTopGuide_MillFinish_tCost = Magnum31mmTopGuide_MillFinish_Qty * Magnum31mmTopGuide_MillFinish_SingleCentral_Price;

                            Magnum31mmTensionersProfile_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmTensionersProfile_MillFinish_tCost = Magnum31mmTensionersProfile_MillFinish_Qty * Magnum31mmTensionersProfiles_MillFinish_SingleCentral_Price;

                            Magnum31mmsideU_MillFinish_Qty = (Screen_Height * 2) / 1000m;
                            Magnum31mmsideU_MillFinish_tCost = Magnum31mmsideU_MillFinish_Qty * Magnum31mmSideU_MillFinish_SingleCentral_Price;

                            var millFinish_Item_Total_Price = AluminumPlateWithTeeth_MillFinish_tCost +
                                                              Magnum31mmSlidingBar_MillFinish_tCost + Magnum31mmBottomGuide_MillFinish_tCost +
                                                              Magnum31mmTopGuide_MillFinish_tCost + Magnum31mmTensionersProfile_MillFinish_tCost +
                                                              Magnum31mmsideU_MillFinish_tCost;

                            #endregion

                            #region Foiled

                            Magnum31mmSlidingBar_Foiled_tCost = Magnum31mmSlidingBar_RALColor_tCost * 1.42m;
                            Magnum31mmTopGuide_Foiled_tCost = Magnum31mmTopGuide_RALColor_tCost * 1.42m;
                            Magnum31mmsideU_Foiled_tCost = Magnum31mmsideU_RALColor_tCost * 1.42m;

                            var foiled_Item_Total_Price = AluminumPlateWithTeeth_RALColor_tCost +
                                                          Magnum31mmSlidingBar_Foiled_tCost + Magnum31mmBottomGuide_RALColor_tCost +
                                                          Magnum31mmTopGuide_Foiled_tCost + Magnum31mmTensionersProfile_RALColor_tCost +
                                                          Magnum31mmsideU_Foiled_tCost;


                            #endregion

                            RALColor_TotalCost = gen_Item_Total_Price + ralColor_Item_Total_Price;
                            MillFinish_TotalCost = gen_Item_Total_Price + millFinish_Item_Total_Price;
                            Foiled_TotalCost = gen_Item_Total_Price + foiled_Item_Total_Price;

                            _whiteFinish = RALColor_TotalCost;
                            _woodFinish = Foiled_TotalCost;

                            #endregion
                        }

                        Black_Alum_base = (2 * (Screen_Height - 1581m) / 1000m) * (23.0817m / 2.8m);
                        AntiLift_DB_w_CacaoFoil = ((2 * (Screen_Height - 1581m) / 1000m) - 2 * 196m / 1000m) * (165m / 4.9m / 64m);
                        Milled_Profile_6052 = (11.7987419205323m / 2m) * (Screen_Width / 1000m);
                        Cover_Profile = 0.23m * (Screen_Width / 1000m);

                        ShootBolt = FinalPart_w_MetalTip + Cap_for_Alum_Base + Black_Alum_base + AntiLift_DB_w_CacaoFoil + Milled_Profile_6052 + Cover_Profile;

                        Extension_for_Bolt = (((Screen_Height - 1800m) / 150m) - 2);
                        Extension_for_Bolt = (int)Math.Round((decimal)(Extension_for_Bolt));

                        Extension_alumBase_DoubleHori_whiteFinish = (23.0817m / 5.8m) * (Screen_Height / 1000m - 1.5m) * 2;
                        Extension_alumBase_DoubleHori_woodFinish = Extension_alumBase_DoubleHori_whiteFinish * 1.4m;

                        PlisseL_N_Cover_whiteFinish = (20.07495m + 12.9915m) / 5.8m * Screen_Height / 1000m;
                        PlisseL_N_Cover_woodFinish = (4.509m + 3.12m) * Screen_Height / 1000m;

                        CouplingProfile_1248 = 0.43m * (Screen_Height / 1000m * 1.3m);

                        KM01_Alum_BottomGuide_BasePrice = 775m * 1.3m * (Screen_Width / 1000m / 6m);
                        KM02_Alum_PlissHandle_BasePrice = 300m * 1.3m * (Screen_Height / 1000m / 6.4m);


                        if (Magnum_ScreenType == Magnum_ScreenType._Single_Fixed)
                        {
                            #region single Fixed
                            if (Screen_Types_Door == true)
                            {
                                KM01_Alum_BottomGuide_whiteFinish = KM01_Alum_BottomGuide_BasePrice * (Screen_Width / 1000m);
                                KM01_Alum_BottomGuide_woodFinish = KM01_Alum_BottomGuide_whiteFinish * 1.4m;
                            }

                            else if (Screen_Types_Window == true)
                            {
                                SideU_for_WindowApp_whiteFinish = Magnum31mmSideU_RALColor_Price * (Screen_Width / 1000m);
                                SideU_for_WindowApp_woodFinish = SideU_for_WindowApp_whiteFinish * 1.42m;
                            }

                            if (Reinforced == true)
                            {
                                Reinforce_Addon = 53.0355604601368m;
                                Reinforced_Labor = 600m;
                            }

                            #region whiteFinish


                            Total_Material_Cost_whiteFinish = (_whiteFinish + SideU_for_WindowApp_whiteFinish + PlisseL_N_Cover_whiteFinish +
                                                               CouplingProfile_1248 + Reinforce_Addon) * Screen_ExchangeRate;

                            Wastage_Cost_whiteFinish = Total_Material_Cost_whiteFinish * 0.1m;

                            Freight_Cost_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish) * 0.05m;

                            DandT_Cost_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish) * 0.16m;

                            Contingencies_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish + DandT_Cost_whiteFinish +
                                                            Small_shop_Items + Reinforced_Labor + OverHead_Cost_SF + KM01_Alum_BottomGuide_whiteFinish) * 0.05m;

                            Single_Fixed_whiteFinish_Total = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish +
                                                               DandT_Cost_whiteFinish + Small_shop_Items + Reinforced_Labor + OverHead_Cost_SF + KM01_Alum_BottomGuide_whiteFinish
                                                               + Contingencies_whiteFinish) + 0.5m;

                            Single_Fixed_whiteFinish_Total = Math.Round(Single_Fixed_whiteFinish_Total);

                            Single_Fixed_whiteFinish_CurrAmount = Single_Fixed_whiteFinish_Total * Screen_Factor;


                            #endregion

                            #region woodFinish

                            Total_Material_Cost_woodFinish = (_woodFinish + SideU_for_WindowApp_woodFinish + PlisseL_N_Cover_woodFinish +
                                                               CouplingProfile_1248 + Reinforce_Addon) * Screen_ExchangeRate;

                            Wastage_Cost_woodFinish = Total_Material_Cost_woodFinish * 0.1m;

                            Freight_Cost_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish) * 0.05m;

                            DandT_Cost_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish) * 0.16m;

                            Contingencies_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish + DandT_Cost_woodFinish + Small_shop_Items + Reinforced_Labor + OverHead_Cost_SF + KM01_Alum_BottomGuide_woodFinish) * 0.05m;

                            Single_Fixed_woodFinish_Total = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish +
                                                                DandT_Cost_woodFinish + Small_shop_Items + Reinforced_Labor + OverHead_Cost_SF + KM01_Alum_BottomGuide_woodFinish
                                                                + Contingencies_woodFinish) + 0.5m;

                            Single_Fixed_woodFinish_Total = Math.Round(Single_Fixed_woodFinish_Total);

                            Single_Fixed_woodFinish_CurrAmount = Single_Fixed_woodFinish_Total * Screen_Factor;

                            #endregion

                            if (Screen_BaseColor == Base_Color._White || Screen_BaseColor == Base_Color._Ivory)
                            {
                                Magnum_Screen_tAmount = Math.Round(Single_Fixed_whiteFinish_Total);
                            }
                            else if (Screen_BaseColor == Base_Color._DarkBrown)
                            {
                                Magnum_Screen_tAmount = Math.Round(Single_Fixed_woodFinish_Total);
                            }

                            #endregion
                        }

                        else if (Magnum_ScreenType == Magnum_ScreenType._Double_Fixed)
                        {
                            #region Double Hori
                            if (Screen_Types_Door == true)
                            {
                                KM01_Alum_BottomGuide_whiteFinish = KM01_Alum_BottomGuide_BasePrice * (Screen_Width / 1000m);
                                KM01_Alum_BottomGuide_woodFinish = KM01_Alum_BottomGuide_whiteFinish * 1.4m;
                            }
                            else if (Screen_Types_Window == true)
                            {
                                SideU_for_WindowApp_whiteFinish = Magnum31mmSideU_RALColor_Price * (Screen_Width / 1000m);
                                SideU_for_WindowApp_woodFinish = SideU_for_WindowApp_whiteFinish * 1.42m;
                            }

                            if (Reinforced == true)
                            {
                                Reinforce_Addon = 53.0355604601368m;
                                Reinforced_Labor = 1200m;
                            }



                            #region whiteFinish


                            Total_Material_Cost_whiteFinish = (_whiteFinish + SideU_for_WindowApp_whiteFinish + DoubleHori_LatchSetlock + Extension_for_Bolt + Extension_alumBase_DoubleHori_whiteFinish + PlisseL_N_Cover_whiteFinish +
                                                               CouplingProfile_1248 + Reinforce_Addon + ShootBolt) * Screen_ExchangeRate;

                            Wastage_Cost_whiteFinish = Total_Material_Cost_whiteFinish * 0.1m;

                            Freight_Cost_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish) * 0.05m;

                            DandT_Cost_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish) * 0.16m;

                            Contingencies_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish + DandT_Cost_whiteFinish +
                                                            Small_shop_Items_DoubleHori + Reinforced_Labor + OverHead_Cost_DH + KM01_Alum_BottomGuide_whiteFinish) * 0.05m;

                            Double_Horizontal_whiteFinish_Total = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish +
                                                               DandT_Cost_whiteFinish + Small_shop_Items_DoubleHori + Reinforced_Labor + OverHead_Cost_DH + KM01_Alum_BottomGuide_whiteFinish
                                                               + Contingencies_whiteFinish) + 0.5m;

                            Double_Horizontal_whiteFinish_Total = Math.Round(Double_Horizontal_whiteFinish_Total);

                            Double_Horizontal_whiteFinish_CurrAmount = Double_Horizontal_whiteFinish_Total * Screen_Factor;


                            #endregion

                            #region woodFinish

                            Total_Material_Cost_woodFinish = (_woodFinish + SideU_for_WindowApp_woodFinish + DoubleHori_LatchSetlock + Extension_for_Bolt + Extension_alumBase_DoubleHori_woodFinish + PlisseL_N_Cover_woodFinish +
                                                               CouplingProfile_1248 + Reinforce_Addon + ShootBolt) * Screen_ExchangeRate;

                            Wastage_Cost_woodFinish = Total_Material_Cost_woodFinish * 0.1m;

                            Freight_Cost_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish) * 0.05m;

                            DandT_Cost_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish) * 0.16m;

                            Contingencies_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish + DandT_Cost_woodFinish +
                                                            Small_shop_Items_DoubleHori + Reinforced_Labor + OverHead_Cost_DH + KM01_Alum_BottomGuide_woodFinish) * 0.05m;

                            Double_Horizontal_woodFinish_Total = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish +
                                                               DandT_Cost_woodFinish + Small_shop_Items_DoubleHori + Reinforced_Labor + OverHead_Cost_DH + KM01_Alum_BottomGuide_woodFinish
                                                               + Contingencies_woodFinish) + 0.5m;

                            Double_Horizontal_woodFinish_Total = Math.Round(Double_Horizontal_woodFinish_Total);

                            Double_Horizontal_woodFinish_CurrAmount = Double_Horizontal_woodFinish_Total * Screen_Factor;

                            #endregion

                            if (Screen_BaseColor == Base_Color._White || Screen_BaseColor == Base_Color._Ivory)
                            {
                                Magnum_Screen_tAmount = Math.Round(Double_Horizontal_whiteFinish_Total);
                            }
                            else if (Screen_BaseColor == Base_Color._DarkBrown)
                            {
                                Magnum_Screen_tAmount = Math.Round(Double_Horizontal_woodFinish_Total);
                            }

                            #endregion
                        }

                        else if (Magnum_ScreenType == Magnum_ScreenType._Single_Central)
                        {
                            #region Single Central
                            if (Screen_Types_Door == true)
                            {
                                KM01_Alum_BottomGuide_whiteFinish = KM01_Alum_BottomGuide_BasePrice * (Screen_Width / 1000m);
                                KM01_Alum_BottomGuide_woodFinish = KM01_Alum_BottomGuide_whiteFinish * 1.4m;
                            }
                            else if (Screen_Types_Window == true)
                            {
                                SideU_for_WindowApp_whiteFinish = Magnum31mmSideU_RALColor_Price * (Screen_Width / 1000m);
                                SideU_for_WindowApp_woodFinish = SideU_for_WindowApp_whiteFinish * 1.42m;
                            }

                            if (Reinforced == true)
                            {
                                Reinforce_Addon = 53.0355604601368m;
                                Reinforced_Labor = 600m;
                            }

                            #region whiteFinish


                            Total_Material_Cost_whiteFinish = (_whiteFinish + SideU_for_WindowApp_whiteFinish + PlisseL_N_Cover_whiteFinish +
                                                               CouplingProfile_1248 + Reinforce_Addon) * Screen_ExchangeRate;

                            Wastage_Cost_whiteFinish = Total_Material_Cost_whiteFinish * 0.1m;

                            Freight_Cost_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish) * 0.05m;

                            DandT_Cost_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish) * 0.16m;

                            Contingencies_whiteFinish = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish + DandT_Cost_whiteFinish +
                                                            Small_shop_Items + Reinforced_Labor + OverHead_Cost_SC + KM01_Alum_BottomGuide_whiteFinish) * 0.05m;

                            Single_Fixed_whiteFinish_Total = (Total_Material_Cost_whiteFinish + Wastage_Cost_whiteFinish + Freight_Cost_whiteFinish +
                                                               DandT_Cost_whiteFinish + Small_shop_Items + Reinforced_Labor + OverHead_Cost_SC + KM01_Alum_BottomGuide_whiteFinish
                                                               + Contingencies_whiteFinish) + 0.5m;

                            Single_Fixed_whiteFinish_Total = Math.Round(Single_Fixed_whiteFinish_Total);

                            Single_Fixed_whiteFinish_CurrAmount = Single_Fixed_whiteFinish_Total * Screen_Factor;


                            #endregion

                            #region woodFinish

                            Total_Material_Cost_woodFinish = (_woodFinish + SideU_for_WindowApp_woodFinish + PlisseL_N_Cover_woodFinish +
                                                               CouplingProfile_1248 + Reinforce_Addon) * Screen_ExchangeRate;

                            Wastage_Cost_woodFinish = Total_Material_Cost_woodFinish * 0.1m;

                            Freight_Cost_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish) * 0.05m;

                            DandT_Cost_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish) * 0.16m;

                            Contingencies_woodFinish = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish + DandT_Cost_woodFinish + Small_shop_Items + Reinforced_Labor + OverHead_Cost_SC + KM01_Alum_BottomGuide_woodFinish) * 0.05m;

                            Single_Fixed_woodFinish_Total = (Total_Material_Cost_woodFinish + Wastage_Cost_woodFinish + Freight_Cost_woodFinish +
                                                                DandT_Cost_woodFinish + Small_shop_Items + Reinforced_Labor + OverHead_Cost_SC + KM01_Alum_BottomGuide_woodFinish
                                                                + Contingencies_woodFinish) + 0.5m;

                            Single_Fixed_woodFinish_Total = Math.Round(Single_Fixed_woodFinish_Total);

                            Single_Fixed_woodFinish_CurrAmount = Single_Fixed_woodFinish_Total * Screen_Factor;

                            #endregion

                            if (Screen_BaseColor == Base_Color._White || Screen_BaseColor == Base_Color._Ivory)
                            {
                                Magnum_Screen_tAmount = Math.Round(Single_Fixed_whiteFinish_Total);
                            }
                            else if (Screen_BaseColor == Base_Color._DarkBrown)
                            {
                                Magnum_Screen_tAmount = Math.Round(Single_Fixed_woodFinish_Total);
                            }

                            #endregion

                        }

                        #endregion
                    }
                    #endregion

                    #region Plisse TR
                    else if (Screen_PlisséType == PlisseType._TR)
                    {

                        if (Screen_Height >= 2701 && Screen_Height <= 3200)
                        {
                            _tr_PPPleatingNETHPricePerLinearMeter = 15.47m / 0.45m;
                        }
                        else if (Screen_Height >= 2501 && Screen_Height <= 2700)
                        {
                            _tr_PPPleatingNETHPricePerLinearMeter = 12.75m / 0.45m;
                        }
                        else if (Screen_Height <= 2500)
                        {
                            _tr_PPPleatingNETHPricePerLinearMeter = 11.03m / 0.45m;
                        }

                        _tr_PPPleatingNETHQty = Screen_Width / 1000m * 1.3736m;
                        _tr_PPPleatingNETHPrice = _tr_PPPleatingNETHPricePerLinearMeter * _tr_PPPleatingNETHQty;
                        _tr_BottomRail2p5mBarsQty = Screen_Width > 800 ? 0.5m : 0.33m;
                        _tr_BottomRail2p5mBarsPrice = _tr_BottomRail2p5mBarsPricePerPiece * _tr_BottomRail2p5mBarsQty;
                        _tr_SettingPlate2p6mbarsPrice = 2 * _tr_SettingPlate2p6mbarsPricePricePerPiece;
                        _tr_FinplateBarsPrice = Screen_Height > 2300 ? (1.935m / 0.45m * 2.47m / 2.3m) : (1.935m / 0.45m);
                        _tr_ScorpionfishLDPrice = 1.4353m / 0.45m;
                        _tr_ScorpionfishRDPrice = 1.4353m / 0.45m;
                        _tr_AnchorplatePriceQty = Screen_Height > 2550 ? 4 : 3;
                        _tr_AnchorplatePrice = _tr_AnchorplatePricePerPiece * _tr_AnchorplatePriceQty;
                        _tr_Scorpiontail3Qty = Screen_Width * 0.09m / 2;
                        _tr_Scorpiontail3Price = _tr_Scorpiontail3Qty * _tr_Scorpiontail3PricePerPiece;
                        _tr_WireEndtailYellowPrice = 6 * _tr_WireEndtailYellowPricePerPiece;
                        _tr_AjustEightTailPrice = 2 * _tr_AjustEightTailPricePerPiece;
                        _tr_TailEndPrice = 0.2655m / 0.45m;
                        _tr_TailReversalPrice = 0.234m / 0.45m;
                        _tr_WireGuideCenterPrice = 8 * _tr_WireGuideCenterPricePerPiece;
                        _tr_WireGuideRPrice = 2 * _tr_WireGuideRPricePerPiece;
                        _tr_WireGuideLPrice = 2 * _tr_WireGuideLPricePerPiece;
                        _tr_WireCB40051PriceQty = ((Screen_Width + 5 * (Screen_Height / 5) + 300) + (Screen_Width + 4 * (Screen_Height / 5) + 300) + (Screen_Width + 3 * (Screen_Height / 5) + 300) + (Screen_Width + 2 * (Screen_Height / 5) + 300) + (Screen_Width + 1 * (Screen_Height / 5) + 300) + (Screen_Width + 300) + (Screen_Height)) / 1000m;
                        _tr_WireCB40051Price = _tr_WireCB40051PricePerLinearMeter * _tr_WireCB40051PriceQty;
                        _tr_TappingScrew3X30BHPrice = 2 * _tr_TappingScrew3X30BHPricePerPiece;
                        _tr_MagnetQty = Screen_Height / 1000m;
                        _tr_PositiveMagnetPrice = _tr_MagnetPricePerLinearMeter * _tr_MagnetQty;
                        _tr_NegativeMagnetPrice = _tr_MagnetPricePerLinearMeter * _tr_MagnetQty;
                        _tr_PileforPlissePrice = (Screen_Height / 1000m) * _tr_PileForPlissèPricePerLinearMeter; // not included in plissë AD

                        _tr_LatchForResizablePlissèPrice = _tr_LatchForResizablePlissèPricePerPiece;
                        _tr_ScrewForLatchPrice = 2 * _tr_ScrewForLatchPricePerPiece;
                        _tr_SlidingBarEndCapResizablePlissèPrice = 2.97m * 1.1m;
                        _tr_WallProfileEndCapResizablePlissèPrice = 3.26m * 1.1m;
                        _tr_TopGuideEndCapResizablePlissèPrice = 2.7m * 1.1m;
                        _tr_CordCurrierResizablePlissèPrice = 2.26m * 1.1m;
                        _tr_TensionerPrice = 0.38m * 1.1m;
                        _tr_ScrewForTensionerPrice = 0.12m * 1.1m;
                        _tr_HammerNutResizablePlissèPrice = 2.5m * 1.1m;
                        _tr_Grub5x20Price = 0.305m * 1.1m;

                        _tr_WaSbarQty = Screen_Height / 1000m;

                        if (Screen_BaseColor == Base_Color._White || Screen_BaseColor == Base_Color._Ivory)
                        {
                            //Ox/RAL Standard
                            
                        

                        }
                        else if(Screen_BaseColor == Base_Color._DarkBrown)
                        {

                        }                                             
                        
                        
                    }
                    #endregion
                }
                //else if (Screen_Types == ScreenType._Magnum)
                //{

                //}
                else if (Screen_Types == ScreenType._ZeroGravityChainDriven)
                {
                    #region Zero Gravity Chain
                    if (Screen_BaseColor == Base_Color._White || Screen_BaseColor == Base_Color._Ivory)
                    {
                        #region white finish
                        roller_case_Price = (roller_case_Qty * Screen_Width * (rollerCase_php_per_meter + ((22.56m / 6 * 1.14m) * Screen_ExchangeRate))) / 1000m;
                        sliding_bar_Price = (sliding_bar_Qty * Screen_Width * (16.92m / 5.8m) * Screen_ExchangeRate * 1.14m) / 1000m;
                        mesh_w_tube_Price = (((47.63m / 5.8m) * Screen_ExchangeRate * 1.08m) * Screen_Width * mesh_w_tube_Qty) / 1000m;
                        guide_70x22_Price = (((22.09m / 6 * 1.14m * Screen_ExchangeRate) + guide_70x22_php_per_meter) * guide_70x22_Qty * Screen_Height) / 1000m;
                        reinforing_hand_slidingbar_Price = (((8.83m / 5.2m * 1.14m * Screen_ExchangeRate) + reinforing_hand_slidingbar_php_per_meter) * reinforing_hand_slidingbar_Qty * Screen_Width) / 1000m;
                        profiles_supp_tube_ZG_Price = ((9.53m / 5 * Screen_ExchangeRate * 1.05m) * profiles_supp_tube_ZG_Qty * Screen_Width) / 1000m;
                        pile_Qty = (Screen_Width * 2m + Screen_Height * 2m) / 1000m;
                        pile_Price = (0.1398m * Screen_ExchangeRate * 1.05m) * pile_Qty;
                        anti_wind_brush_Price = ((0.3512m * Screen_ExchangeRate * 1.05m) * Screen_Height * anti_wind_brush_Qty) / 1000m;
                        kit_genius_46mm_ZG_Price = ((12.53m * Screen_ExchangeRate * 1.05m) * kit_genius_46mm_ZG_Qty);

                        if (Screen_Width > 2400)
                        {
                            supp_fixing_42mm_headrail_Qty = Math.Round(3 + ((Screen_Width - 2400m) / 800m));

                        }
                        else if (Screen_Width <= 2400)
                        {
                            supp_fixing_42mm_headrail_Qty = 3;
                        }

                        supp_fixing_42mm_headrail_Price = (0.2144m * Screen_ExchangeRate * 1.05m) * supp_fixing_42mm_headrail_Qty;
                        dowell_4x25_Qty = supp_fixing_42mm_headrail_Qty;
                        screw_4x25_Qty = supp_fixing_42mm_headrail_Qty;
                        dowell_4x25_Price = (0.48m * 1.05m) * dowell_4x25_Qty;
                        screw_4x25_Price = (1.3m * 1.05m) * screw_4x25_Qty;

                        ZG_waste_10per_ = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price) * 0.1m
                                          ;

                        ZG_freight_5per = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price +
                                          kit_genius_46mm_ZG_Price +
                                          supp_fixing_42mm_headrail_Price +
                                          dowell_4x25_Price +
                                          screw_4x25_Price +
                                          ZG_waste_10per_) * 0.05m
                                          ;

                        ZG_importation_Cost = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price +
                                          kit_genius_46mm_ZG_Price +
                                          supp_fixing_42mm_headrail_Price +
                                          dowell_4x25_Price +
                                          screw_4x25_Price +
                                          ZG_waste_10per_ +
                                          ZG_freight_5per) * 0.16m
                                          ;

                        ZG_Contigencies = (sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price +
                                          kit_genius_46mm_ZG_Price +
                                          supp_fixing_42mm_headrail_Price +
                                          dowell_4x25_Price +
                                          screw_4x25_Price +
                                          ZG_waste_10per_ +
                                          ZG_freight_5per +
                                          ZG_importation_Cost +
                                          ZG_small_shop_Items +
                                          ZG_overhead_Cost +
                                          additional_for_Woograin) * 0.05m
                                          ;

                        ZG_totalMaterial_Cost = Math.Round((roller_case_Price +
                                                sliding_bar_Price +
                                                mesh_w_tube_Price +
                                                guide_70x22_Price +
                                                reinforing_hand_slidingbar_Price +
                                                profiles_supp_tube_ZG_Price +
                                                pile_Price +
                                                anti_wind_brush_Price +
                                                kit_genius_46mm_ZG_Price +
                                                supp_fixing_42mm_headrail_Price +
                                                dowell_4x25_Price +
                                                screw_4x25_Price +
                                                ZG_waste_10per_ +
                                                ZG_freight_5per +
                                                ZG_importation_Cost +
                                                ZG_small_shop_Items +
                                                ZG_overhead_Cost +
                                                additional_for_Woograin +
                                                ZG_Contigencies) + 0.5m);
                        #endregion
                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {
                        #region wood finish
                        roller_case_Price = (roller_case_Qty * Screen_Width * (7.758m * Screen_ExchangeRate)) / 1000;
                        sliding_bar_Price = (sliding_bar_Qty * Screen_Width * (3.606m * Screen_ExchangeRate)) / 1000;
                        mesh_w_tube_Price = (((47.63m / 5.8m) * Screen_ExchangeRate * 1.08m) * Screen_Width * mesh_w_tube_Qty) / 1000;
                        guide_70x22_Price = ((7.511m * Screen_ExchangeRate) * guide_70x22_Qty * Screen_Height) / 1000;
                        reinforing_hand_slidingbar_Price = ((4.841m * Screen_ExchangeRate) * reinforing_hand_slidingbar_Qty * Screen_Width) / 1000;
                        profiles_supp_tube_ZG_Price = ((9.53m / 5 * Screen_ExchangeRate * 1.05m) * profiles_supp_tube_ZG_Qty * Screen_Width) / 1000;
                        pile_Qty = (Screen_Width * 2m + Screen_Height * 2m) / 1000m;
                        pile_Price = (0.1398m * Screen_ExchangeRate * 1.05m) * pile_Qty;
                        anti_wind_brush_Price = ((0.3512m * Screen_ExchangeRate * 1.05m) * Screen_Height * anti_wind_brush_Qty) / 1000;
                        kit_genius_46mm_ZG_Price = ((12.53m * Screen_ExchangeRate * 1.05m) * kit_genius_46mm_ZG_Qty);

                        if (Screen_Width > 2400)
                        {
                            supp_fixing_42mm_headrail_Qty = Math.Round(3 + ((Screen_Width - 2400m) / 800m));
                        }
                        else if (Screen_Width <= 2400)
                        {
                            supp_fixing_42mm_headrail_Qty = 3;
                        }

                        supp_fixing_42mm_headrail_Price = (0.2144m * Screen_ExchangeRate * 1.05m) * supp_fixing_42mm_headrail_Qty;
                        dowell_4x25_Qty = supp_fixing_42mm_headrail_Qty;
                        screw_4x25_Qty = supp_fixing_42mm_headrail_Qty;
                        dowell_4x25_Price = (0.48m * 1.05m) * dowell_4x25_Qty;
                        screw_4x25_Price = (1.3m * 1.05m) * screw_4x25_Qty;

                        ZG_waste_10per_ = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price) * 0.1m
                                          ;

                        ZG_freight_5per = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price +
                                          kit_genius_46mm_ZG_Price +
                                          supp_fixing_42mm_headrail_Price +
                                          dowell_4x25_Price +
                                          screw_4x25_Price +
                                          ZG_waste_10per_) * 0.05m
                                          ;

                        ZG_importation_Cost = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price +
                                          kit_genius_46mm_ZG_Price +
                                          supp_fixing_42mm_headrail_Price +
                                          dowell_4x25_Price +
                                          screw_4x25_Price +
                                          ZG_waste_10per_ +
                                          ZG_freight_5per) * 0.16m
                                          ;

                        additional_for_Woograin = (roller_case_Price +
                                                   sliding_bar_Price +
                                                   mesh_w_tube_Price +
                                                   guide_70x22_Price +
                                                   reinforing_hand_slidingbar_Price +
                                                   profiles_supp_tube_ZG_Price +
                                                   pile_Price +
                                                   anti_wind_brush_Price +
                                                   kit_genius_46mm_ZG_Price +
                                                   supp_fixing_42mm_headrail_Price +
                                                   dowell_4x25_Price +
                                                   screw_4x25_Price +
                                                   ZG_waste_10per_ +
                                                   ZG_freight_5per +
                                                   ZG_importation_Cost +
                                                   ZG_small_shop_Items +
                                                   ZG_overhead_Cost
                                                   ) * 0.05m
                                                   ;


                        ZG_Contigencies = (roller_case_Price +
                                          sliding_bar_Price +
                                          mesh_w_tube_Price +
                                          guide_70x22_Price +
                                          reinforing_hand_slidingbar_Price +
                                          profiles_supp_tube_ZG_Price +
                                          pile_Price +
                                          anti_wind_brush_Price +
                                          kit_genius_46mm_ZG_Price +
                                          supp_fixing_42mm_headrail_Price +
                                          dowell_4x25_Price +
                                          screw_4x25_Price +
                                          ZG_waste_10per_ +
                                          ZG_freight_5per +
                                          ZG_importation_Cost +
                                          ZG_small_shop_Items +
                                          ZG_overhead_Cost +
                                          additional_for_Woograin) * 0.05m
                                          ;

                        ZG_totalMaterial_Cost = Math.Round((roller_case_Price +
                                                sliding_bar_Price +
                                                mesh_w_tube_Price +
                                                guide_70x22_Price +
                                                reinforing_hand_slidingbar_Price +
                                                profiles_supp_tube_ZG_Price +
                                                pile_Price +
                                                anti_wind_brush_Price +
                                                kit_genius_46mm_ZG_Price +
                                                supp_fixing_42mm_headrail_Price +
                                                dowell_4x25_Price +
                                                screw_4x25_Price +
                                                ZG_waste_10per_ +
                                                ZG_freight_5per +
                                                ZG_importation_Cost +
                                                ZG_small_shop_Items +
                                                ZG_overhead_Cost +
                                                additional_for_Woograin +
                                                ZG_Contigencies) + 0.5m);


                        #endregion
                    }
                    #endregion
                }
                else if (Screen_Types == ScreenType._BuiltInSideroll)
                {
                    BuiltInPrice_and_PriceInterpolation();
                }
                else if (Screen_Types == ScreenType._Maxxy)
                {
                    #region Maxxy Screen 

                    #region Gen item 


                    if (Screen_Width <= 1200m)
                    {
                        PP_Maxy_5mmTube = (Screen_Height / 1000m) * 7.02m;
                    }
                    else if (Screen_Width >= 1201m && Screen_Width <= 1400m)
                    {

                        PP_Maxy_5mmTube = (Screen_Height / 1000m) * 7.174m;
                    }
                    else if (Screen_Width >= 1400m)
                    {
                        PP_Maxy_5mmTube = (Screen_Height / 1000m) * 9.468m;
                    }

                    //int size = ((((Convert.ToInt32(Screen_Width) - 30) / 22) - 2) ); 1st approach
                    // ScorpionTail_8 = (size * 0.180862068965517m);

                    ScorpionTail_8 = ((((Convert.ToInt32(Screen_Width) - 30) / 22) - 2) * 0.180862068965517m);
                    Mohair = ((Screen_Width * 2m) / 1000m) * 0.5625m;
                    Maxy_ScorpionTail_53pcs = (((Screen_Width / 16.6m) / 53m) * 9.3375m);
                    Maxy_Pile = ((Screen_Width * 2m / 1000m) * 0.1424m);

                    if (Screen_Width <= 1450m)
                    {
                        Bottom_Rail = 4.94m;
                    }
                    else if (Screen_Width > 1450m)
                    {
                        Bottom_Rail = 10.6m;
                    }


                    var gen_item_total = PP_Maxy_5mmTube +
                                         Wire_CB_40051 +
                                         SettingPlate_Rs_l2600 +
                                         Tail_SlideDT +
                                         ScorpionTail_8 +
                                         Adjust_EighthHolder +
                                         Weight_Bar_Rsz +
                                         Anchor_Plate_s4 +
                                         Mohair +
                                         Tapping_Screw_3x10_Bh +
                                         Maxy_Cassette_EndCap_w_Spring +
                                         Maxy_Bushing +
                                         Maxy_Cassette_Endcap +
                                         Maxy_Sliding_Bottom_EndCap +
                                         Maxy_Sliding_Top_EndCap +
                                         Maxy_ScorpionTail_53pcs +
                                         Maxy_White_TailEnd +
                                         Maxy_Cap_SlidingBar_TopEndCap +
                                         Maxy_TopRailCap_CassetteSide +
                                         Maxy_Screw_3x4 +
                                         Plate_w_2hole_M3 +
                                         Maxy_Pile +
                                         Maxy_ScorpionTail_w_PileCavity +
                                         Bottom_Rail
                                         ;


                    #endregion

                    #region Mill Finish

                    Case_Maxy_MillFinish = ((Screen_Height / 1000m) * 3.138m);
                    SlidingBar_Maxy_MillFinish = ((Screen_Height / 1000m) * 3.86734693877551m);
                    TopGuide_Maxy_MillFinish = ((Screen_Width / 1000m) * 2.556m);
                    UProfile_46mm_Maxy_MillFinish = (((Screen_Height / 1000m) * 2m) * 1.758m);

                    var mill_finish_total = Case_Maxy_MillFinish +
                                            SlidingBar_Maxy_MillFinish +
                                            TopGuide_Maxy_MillFinish +
                                            UProfile_46mm_Maxy_MillFinish
                                            ;

                    #endregion

                    #region Ral Colour

                    Case_Maxy_RalColour = ((Screen_Height / 1000m) * 4.028m);
                    SlidingBar_Maxy_RalColour = ((Screen_Height / 1000m) * 4.96938775510204m);
                    TopGuide_Maxy_RalColour = ((Screen_Width / 1000m) * 3.284m);
                    UProfile_46mm_Maxy_RalColour = (((Screen_Height / 1000m) * 2m) * 2.238m);

                    var Ral_Finish_total = Case_Maxy_RalColour +
                                         SlidingBar_Maxy_RalColour +
                                         TopGuide_Maxy_RalColour +
                                         UProfile_46mm_Maxy_RalColour
                                         ;

                    #endregion

                    #region Hook Version

                    Cover_ProfileLatch_MillFinish = ((Screen_Height / 1000m) * 0.957142857142857m);
                    Cover_ProfileLatch_RalColour = ((Screen_Height / 1000m) * 1.23061224489796m);
                    Latch_Rsz = 2.151m;
                    Latch_Hanger_Rsz = 1.6875m;


                    #endregion

                    Hook_V_RalFinish_tCost = gen_item_total + Ral_Finish_total + Cover_ProfileLatch_RalColour + Latch_Hanger_Rsz + Latch_Rsz;
                    Hook_V_MillFinish_tCost = gen_item_total + mill_finish_total + Cover_ProfileLatch_MillFinish + Latch_Hanger_Rsz + Latch_Rsz;

                    Maxxy_KM01 = ((775m * 1.3m * Screen_Width) / 1000m) / 6m;
                    Maxxy_KM02 = ((300m * 1.3m * Screen_Height) / 1000m) / 6.4m;

                    if (Screen_BaseColor == Base_Color._White || Screen_BaseColor == Base_Color._Ivory)
                    {
                        #region whiteFinish


                        Maxxy_1248_Coupling_Profile = (Screen_Height * 0.43m) / 1000m;
                        Maxxy_Total_Mat_Cost = (Hook_V_MillFinish_tCost + Maxxy_1248_Coupling_Profile) * Screen_ExchangeRate;
                        Maxxy_Wastage = Maxxy_Total_Mat_Cost * 0.1m;
                        Maxxy_Freight = (Maxxy_Total_Mat_Cost + Maxxy_Wastage) * 0.05m;
                        Maxxy_DT = (Maxxy_Total_Mat_Cost + Maxxy_Wastage + Maxxy_Freight) * 0.12m;
                        Maxxy_AlumBottomGuide = ((Maxxy_KM01 * Screen_Width) / 1000m) * 1.1m;

                        Maxxy_Contigencies = (Maxxy_Total_Mat_Cost +
                                               Maxxy_Wastage +
                                               Maxxy_Freight +
                                               Maxxy_DT +
                                               100m +
                                               Maxxy_AlumBottomGuide +
                                               1000m) * 0.05m
                                               ;

                        Maxxy_Screen_tAmount = Math.Round((Maxxy_Total_Mat_Cost +
                                               Maxxy_Wastage +
                                               Maxxy_Freight +
                                               Maxxy_DT +
                                               100m +
                                               Maxxy_AlumBottomGuide +
                                               1000m +
                                               Maxxy_Contigencies) + 0.5m)
                                               ;

                        #endregion
                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {
                        #region woodFinish

                        Maxxy_1248_Coupling_Profile = (Screen_Height * 0.43m) / 1000m;
                        Maxxy_Total_Mat_Cost = (Hook_V_RalFinish_tCost + Maxxy_1248_Coupling_Profile) * Screen_ExchangeRate;
                        Maxxy_Wastage = Maxxy_Total_Mat_Cost * 0.1m;
                        Maxxy_Freight = (Maxxy_Total_Mat_Cost + Maxxy_Wastage) * 0.05m;
                        Maxxy_DT = (Maxxy_Total_Mat_Cost + Maxxy_Wastage + Maxxy_Freight) * 0.12m;
                        Maxxy_AlumBottomGuide = (((Maxxy_KM01 * Screen_Width) / 1000m) * 1.1m) * 1.3m;

                        Maxxy_Contigencies = (Maxxy_Total_Mat_Cost +
                                                       Maxxy_Wastage +
                                                       Maxxy_Freight +
                                                       Maxxy_DT +
                                                       100m +
                                                       Maxxy_AlumBottomGuide +
                                                       1500m) * 0.05m
                                                       ;

                        Maxxy_Screen_tAmount = Math.Round((Maxxy_Total_Mat_Cost +
                                               Maxxy_Wastage +
                                               Maxxy_Freight +
                                               Maxxy_DT +
                                               100m +
                                               Maxxy_AlumBottomGuide +
                                               1500m +
                                               Maxxy_Contigencies) + 0.5m)
                                               ;

                        #endregion
                    }

                    #endregion
                }
                else if (Screen_Types == ScreenType._Freedom)
                {
                    #region Freedom Screen

                    if (Freedom_ScreenType == Freedom_ScreenType._single)
                    {
                        if (Freedom_ScreenSize == Freedom_ScreenSize._80mm)
                        {
                            #region Single 80 mm 

                            if (Screen_Height <= 2200m)
                            {
                                #region 2200  Base Price

                                if (Screen_Width <= 2000m)
                                {
                                    Freedom_BasedPrice = 990m;
                                }
                                else if (Screen_Width > 2000m && Screen_Width <= 2200m)
                                {
                                    Freedom_BasedPrice = 1017m;
                                }
                                else if (Screen_Width > 2200m && Screen_Width <= 2400m)
                                {
                                    Freedom_BasedPrice = 1043m;
                                }
                                else if (Screen_Width > 2400m && Screen_Width <= 2600m)
                                {
                                    Freedom_BasedPrice = 1070m;
                                }
                                else if (Screen_Width > 2600m && Screen_Width <= 2800m)
                                {
                                    Freedom_BasedPrice = 1097m;
                                }
                                else if (Screen_Width > 2800m && Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1123m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1150m;
                                }
                                else if (Screen_Width > 3200 && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1176m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1203m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1229m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1256m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1282m;
                                }
                                else if (Screen_Width > 4200m && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1309m;
                                }
                                else if (Screen_Width > 4400m)
                                {
                                    Freedom_BasedPrice = 1322m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2200m && Screen_Height <= 2400m)
                            {
                                #region 2400 Base Price

                                if (Screen_Width <= 2000m)
                                {
                                    Freedom_BasedPrice = 1026m;
                                }
                                else if (Screen_Width > 2000m && Screen_Width <= 2200m)
                                {
                                    Freedom_BasedPrice = 1053m;
                                }
                                else if (Screen_Width > 2200m && Screen_Width <= 2400m)
                                {
                                    Freedom_BasedPrice = 1079m;
                                }
                                else if (Screen_Width > 2400m && Screen_Width <= 2600m)
                                {
                                    Freedom_BasedPrice = 1106m;
                                }
                                else if (Screen_Width > 2600m && Screen_Width <= 2800m)
                                {
                                    Freedom_BasedPrice = 1132m;
                                }
                                else if (Screen_Width > 2800m && Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1159m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1185m;
                                }
                                else if (Screen_Width > 3200 && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1212m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1238m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1265m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1291m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1318m;
                                }
                                else if (Screen_Width > 4200m && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1344m;
                                }
                                else if (Screen_Width > 4400m)
                                {
                                    Freedom_BasedPrice = 1358m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2400m && Screen_Height <= 2600m)
                            {
                                #region 2600 Base Price

                                if (Screen_Width <= 2000m)
                                {
                                    Freedom_BasedPrice = 1064m;
                                }
                                else if (Screen_Width > 2000m && Screen_Width <= 2200m)
                                {
                                    Freedom_BasedPrice = 1090m;
                                }
                                else if (Screen_Width > 2200m && Screen_Width <= 2400m)
                                {
                                    Freedom_BasedPrice = 117m;
                                }
                                else if (Screen_Width > 2400m && Screen_Width <= 2600m)
                                {
                                    Freedom_BasedPrice = 1143m;
                                }
                                else if (Screen_Width > 2600m && Screen_Width <= 2800m)
                                {
                                    Freedom_BasedPrice = 1170m;
                                }
                                else if (Screen_Width > 2800m && Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1196m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1223m;
                                }
                                else if (Screen_Width > 3200 && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1250m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1276m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1303m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1329m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1356m;
                                }
                                else if (Screen_Width > 4200m && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1382m;
                                }
                                else if (Screen_Width > 4400m)
                                {
                                    Freedom_BasedPrice = 1395m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2600m && Screen_Height <= 2800m)
                            {
                                #region 2800 Base Price 

                                if (Screen_Width <= 2000m)
                                {
                                    Freedom_BasedPrice = 1102m;
                                }
                                else if (Screen_Width > 2000m && Screen_Width <= 2200m)
                                {
                                    Freedom_BasedPrice = 1128m;
                                }
                                else if (Screen_Width > 2200m && Screen_Width <= 2400m)
                                {
                                    Freedom_BasedPrice = 1155m;
                                }
                                else if (Screen_Width > 2400m && Screen_Width <= 2600m)
                                {
                                    Freedom_BasedPrice = 1181m;
                                }
                                else if (Screen_Width > 2600m && Screen_Width <= 2800m)
                                {
                                    Freedom_BasedPrice = 1208m;
                                }
                                else if (Screen_Width > 2800m && Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1234m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1261m;
                                }
                                else if (Screen_Width > 3200 && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1287m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1314m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1340m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1367m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1393m;
                                }
                                else if (Screen_Width > 4200m && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1420m;
                                }
                                else if (Screen_Width > 4400m)
                                {
                                    Freedom_BasedPrice = 1433m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2800m && Screen_Height <= 3000m)
                            {
                                #region  3000 Base Price 

                                if (Screen_Width <= 2000m)
                                {
                                    Freedom_BasedPrice = 1139m;
                                }
                                else if (Screen_Width > 2000m && Screen_Width <= 2200m)
                                {
                                    Freedom_BasedPrice = 1166m;
                                }
                                else if (Screen_Width > 2200m && Screen_Width <= 2400m)
                                {
                                    Freedom_BasedPrice = 1192m;
                                }
                                else if (Screen_Width > 2400m && Screen_Width <= 2600m)
                                {
                                    Freedom_BasedPrice = 1219m;
                                }
                                else if (Screen_Width > 2600m && Screen_Width <= 2800m)
                                {
                                    Freedom_BasedPrice = 1245m;
                                }
                                else if (Screen_Width > 2800m && Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1272m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1298m;
                                }
                                else if (Screen_Width > 3200 && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1325m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1352m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1378m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1405m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1431m;
                                }
                                else if (Screen_Width > 4200m && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1458m;
                                }
                                else if (Screen_Width > 4400m)
                                {
                                    Freedom_BasedPrice = 1471m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 3000m && Screen_Height <= 3200m)
                            {
                                #region 3200 Base Price

                                if (Screen_Width <= 2000m)
                                {
                                    Freedom_BasedPrice = 1177m;
                                }
                                else if (Screen_Width > 2000m && Screen_Width <= 2200m)
                                {
                                    Freedom_BasedPrice = 1204m;
                                }
                                else if (Screen_Width > 2200m && Screen_Width <= 2400m)
                                {
                                    Freedom_BasedPrice = 1230m;
                                }
                                else if (Screen_Width > 2400m && Screen_Width <= 2600m)
                                {
                                    Freedom_BasedPrice = 1257m;
                                }
                                else if (Screen_Width > 2600m && Screen_Width <= 2800m)
                                {
                                    Freedom_BasedPrice = 1283m;
                                }
                                else if (Screen_Width > 2800m && Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1310m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1336m;
                                }
                                else if (Screen_Width > 3200 && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1363m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1389m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1416m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1442m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1469m;
                                }
                                else if (Screen_Width > 4200m && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1495m;
                                }
                                else if (Screen_Width > 4400m)
                                {
                                    Freedom_BasedPrice = 1509m;
                                }

                                #endregion
                            }

                            #endregion
                        }
                        else if (Freedom_ScreenSize == Freedom_ScreenSize._100mm)
                        {
                            #region Single 100 mm 

                            if (Screen_Height <= 2200m)
                            {
                                #region 2200 Base Price

                                if (Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1140m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1167m;
                                }
                                else if (Screen_Width > 3200m && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1195m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1222m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1249m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1276m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1304m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1331m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 1358m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 1386m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 1416m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 1447m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 1477m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 1508m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 1538m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 1569m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 1599m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 1629m;
                                }
                                else if (Screen_Width > 6400m)
                                {
                                    Freedom_BasedPrice = 1645m;
                                }


                                #endregion
                            }
                            else if (Screen_Height > 2200m && Screen_Height <= 2400m)
                            {
                                #region 2400 Base Price

                                if (Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1177m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1204m;
                                }
                                else if (Screen_Width > 3200m && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1231m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1259m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1286m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1313m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1341m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1368m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 1395m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 1423m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 1451m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 1479m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 1509m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 1538m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 1566m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 1595m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 1624m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 1653m;
                                }
                                else if (Screen_Width > 6400m)
                                {
                                    Freedom_BasedPrice = 1681m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2400m && Screen_Height <= 2600m)
                            {
                                #region 2600 Base Price


                                if (Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1214m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1242m;
                                }
                                else if (Screen_Width > 3200m && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1269m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1296m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1324m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1345m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1378m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1406m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 1433m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 1460m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 1489m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 1517m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 1545m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 1574m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 1603m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 1632m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 1660m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 1688m;
                                }
                                else if (Screen_Width > 6400m)
                                {
                                    Freedom_BasedPrice = 1718m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2600m && Screen_Height <= 2800m)
                            {
                                #region 2800 Base Price

                                if (Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1253m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1281m;
                                }
                                else if (Screen_Width > 3200m && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1308m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1335m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1363m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1390m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1417m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1445m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 1472m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 1499m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 1528m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 1556m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 1584m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 1613m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 1641m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 1669m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 1698m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 1726m;
                                }
                                else if (Screen_Width > 6400m)
                                {
                                    Freedom_BasedPrice = 1755m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2800m && Screen_Height <= 3000m)
                            {
                                #region 3000 Base Price 


                                if (Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1291m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1319m;
                                }
                                else if (Screen_Width > 3200m && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1346m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1373m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1400m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1428m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1455m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1482m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 1510m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 1537m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 1564m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 1592m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 1619m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 1646m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 1675m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 1702m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 1729m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 1758m;
                                }
                                else if (Screen_Width > 6400m)
                                {
                                    Freedom_BasedPrice = 1791m;
                                }


                                #endregion

                            }
                            else if (Screen_Height > 3000m && Screen_Height <= 3200m)
                            {
                                #region 3200 Base Price

                                if (Screen_Width <= 3000m)
                                {
                                    Freedom_BasedPrice = 1330m;
                                }
                                else if (Screen_Width > 3000m && Screen_Width <= 3200m)
                                {
                                    Freedom_BasedPrice = 1357m;
                                }
                                else if (Screen_Width > 3200m && Screen_Width <= 3400m)
                                {
                                    Freedom_BasedPrice = 1385m;
                                }
                                else if (Screen_Width > 3400m && Screen_Width <= 3600m)
                                {
                                    Freedom_BasedPrice = 1412m;
                                }
                                else if (Screen_Width > 3600m && Screen_Width <= 3800m)
                                {
                                    Freedom_BasedPrice = 1439m;
                                }
                                else if (Screen_Width > 3800m && Screen_Width <= 4000m)
                                {
                                    Freedom_BasedPrice = 1467m;
                                }
                                else if (Screen_Width > 4000m && Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 1494m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 1521m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 1549m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 1576m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 1603m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 1631m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 1658m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 1686m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 1715m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 1743m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 1771m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 1800m;
                                }
                                else if (Screen_Width > 6400m)
                                {
                                    Freedom_BasedPrice = 1828m;
                                }

                                #endregion
                            }

                            #endregion
                        }
                    }
                    else if (Freedom_ScreenType == Freedom_ScreenType._double)
                    {
                        if (Freedom_ScreenSize == Freedom_ScreenSize._80mm)
                        {
                            #region Double 80 mm 
                            if (Screen_Height <= 2200m)
                            {
                                #region 2200 Base Price


                                if (Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 2007m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 2034m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 2060m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 2087m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 2113m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 2140m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 2166m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 2193m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 2220m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 2246m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 2273m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 2299m;
                                }
                                else if (Screen_Width > 6400m && Screen_Width <= 6600m)
                                {
                                    Freedom_BasedPrice = 2326m;
                                }
                                else if (Screen_Width > 6600m && Screen_Width <= 6800m)
                                {
                                    Freedom_BasedPrice = 2352m;
                                }
                                else if (Screen_Width > 6800m && Screen_Width <= 7000m)
                                {
                                    Freedom_BasedPrice = 2379m;
                                }
                                else if (Screen_Width > 7000m && Screen_Width <= 7200m)
                                {
                                    Freedom_BasedPrice = 2405m;
                                }
                                else if (Screen_Width > 7200m && Screen_Width <= 7400m)
                                {
                                    Freedom_BasedPrice = 2432m;
                                }
                                else if (Screen_Width > 7400m && Screen_Width <= 7600m)
                                {
                                    Freedom_BasedPrice = 2458m;
                                }
                                else if (Screen_Width > 7600m && Screen_Width <= 7800m)
                                {
                                    Freedom_BasedPrice = 2485;
                                }
                                else if (Screen_Width > 7800m && Screen_Width <= 8000m)
                                {
                                    Freedom_BasedPrice = 2511m;
                                }
                                else if (Screen_Width > 8000m && Screen_Width <= 8200m)
                                {
                                    Freedom_BasedPrice = 2538m;
                                }
                                else if (Screen_Width > 8200m && Screen_Width <= 8400m)
                                {
                                    Freedom_BasedPrice = 2564m;
                                }
                                else if (Screen_Width > 8400m && Screen_Width <= 8600m)
                                {
                                    Freedom_BasedPrice = 2591m;
                                }
                                else if (Screen_Width > 8600m && Screen_Width <= 8800m)
                                {
                                    Freedom_BasedPrice = 2617m;
                                }
                                else if (Screen_Width > 8800m)
                                {
                                    Freedom_BasedPrice = 2644m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2200m && Screen_Height <= 2400m)
                            {
                                #region 2400 Base Price

                                if (Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 2079m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 2105m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 2132m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 2158m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 2185m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 2211m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 2238m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 2264m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 2291m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 2317m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 2344m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 2370m;
                                }
                                else if (Screen_Width > 6400m && Screen_Width <= 6600m)
                                {
                                    Freedom_BasedPrice = 2397m;
                                }
                                else if (Screen_Width > 6600m && Screen_Width <= 6800m)
                                {
                                    Freedom_BasedPrice = 2424m;
                                }
                                else if (Screen_Width > 6800m && Screen_Width <= 7000m)
                                {
                                    Freedom_BasedPrice = 2450m;
                                }
                                else if (Screen_Width > 7000m && Screen_Width <= 7200m)
                                {
                                    Freedom_BasedPrice = 2477m;
                                }
                                else if (Screen_Width > 7200m && Screen_Width <= 7400m)
                                {
                                    Freedom_BasedPrice = 2503m;
                                }
                                else if (Screen_Width > 7400m && Screen_Width <= 7600m)
                                {
                                    Freedom_BasedPrice = 2530m;
                                }
                                else if (Screen_Width > 7600m && Screen_Width <= 7800m)
                                {
                                    Freedom_BasedPrice = 2556m;
                                }
                                else if (Screen_Width > 7800m && Screen_Width <= 8000m)
                                {
                                    Freedom_BasedPrice = 2583m;
                                }
                                else if (Screen_Width > 8000m && Screen_Width <= 8200m)
                                {
                                    Freedom_BasedPrice = 2609m;
                                }
                                else if (Screen_Width > 8200m && Screen_Width <= 8400m)
                                {
                                    Freedom_BasedPrice = 2636m;
                                }
                                else if (Screen_Width > 8400m && Screen_Width <= 8600m)
                                {
                                    Freedom_BasedPrice = 2662m;
                                }
                                else if (Screen_Width > 8600m && Screen_Width <= 8800m)
                                {
                                    Freedom_BasedPrice = 2689m;
                                }
                                else if (Screen_Width > 8800m)
                                {
                                    Freedom_BasedPrice = 2715m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2400m && Screen_Height <= 2600m)
                            {
                                #region 2600 Base Price

                                if (Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 2154m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 2181m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 2207m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 2234m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 2260m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 2287m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 2313m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 2340m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 2366m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 2393m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 2419m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 2446m;
                                }
                                else if (Screen_Width > 6400m && Screen_Width <= 6600m)
                                {
                                    Freedom_BasedPrice = 2472m;
                                }
                                else if (Screen_Width > 6600m && Screen_Width <= 6800m)
                                {
                                    Freedom_BasedPrice = 2499m;
                                }
                                else if (Screen_Width > 6800m && Screen_Width <= 7000m)
                                {
                                    Freedom_BasedPrice = 2526m;
                                }
                                else if (Screen_Width > 7000m && Screen_Width <= 7200m)
                                {
                                    Freedom_BasedPrice = 2552m;
                                }
                                else if (Screen_Width > 7200m && Screen_Width <= 7400m)
                                {
                                    Freedom_BasedPrice = 2579m;
                                }
                                else if (Screen_Width > 7400m && Screen_Width <= 7600m)
                                {
                                    Freedom_BasedPrice = 2605m;
                                }
                                else if (Screen_Width > 7600m && Screen_Width <= 7800m)
                                {
                                    Freedom_BasedPrice = 2632m;
                                }
                                else if (Screen_Width > 7800m && Screen_Width <= 8000m)
                                {
                                    Freedom_BasedPrice = 2658m;
                                }
                                else if (Screen_Width > 8000m && Screen_Width <= 8200m)
                                {
                                    Freedom_BasedPrice = 2685m;
                                }
                                else if (Screen_Width > 8200m && Screen_Width <= 8400m)
                                {
                                    Freedom_BasedPrice = 2711m;
                                }
                                else if (Screen_Width > 8400m && Screen_Width <= 8600m)
                                {
                                    Freedom_BasedPrice = 2738m;
                                }
                                else if (Screen_Width > 8600m && Screen_Width <= 8800m)
                                {
                                    Freedom_BasedPrice = 2764m;
                                }
                                else if (Screen_Width > 8800m)
                                {
                                    Freedom_BasedPrice = 2791m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2600m && Screen_Height <= 2800m)
                            {
                                #region 2800 Base Price

                                if (Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 2230m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 2256m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 2283m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 2309m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 2336m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 2362m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 2389m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 2415m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 2442m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 2468m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 2495m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 2521m;
                                }
                                else if (Screen_Width > 6400m && Screen_Width <= 6600m)
                                {
                                    Freedom_BasedPrice = 2548m;
                                }
                                else if (Screen_Width > 6600m && Screen_Width <= 6800m)
                                {
                                    Freedom_BasedPrice = 2574m;
                                }
                                else if (Screen_Width > 6800m && Screen_Width <= 7000m)
                                {
                                    Freedom_BasedPrice = 2601m;
                                }
                                else if (Screen_Width > 7000m && Screen_Width <= 7200m)
                                {
                                    Freedom_BasedPrice = 2628m;
                                }
                                else if (Screen_Width > 7200m && Screen_Width <= 7400m)
                                {
                                    Freedom_BasedPrice = 2654m;
                                }
                                else if (Screen_Width > 7400m && Screen_Width <= 7600m)
                                {
                                    Freedom_BasedPrice = 2681m;
                                }
                                else if (Screen_Width > 7600m && Screen_Width <= 7800m)
                                {
                                    Freedom_BasedPrice = 2707m;
                                }
                                else if (Screen_Width > 7800m && Screen_Width <= 8000m)
                                {
                                    Freedom_BasedPrice = 2734m;
                                }
                                else if (Screen_Width > 8000m && Screen_Width <= 8200m)
                                {
                                    Freedom_BasedPrice = 2760m;
                                }
                                else if (Screen_Width > 8200m && Screen_Width <= 8400m)
                                {
                                    Freedom_BasedPrice = 2787m;
                                }
                                else if (Screen_Width > 8400m && Screen_Width <= 8600m)
                                {
                                    Freedom_BasedPrice = 2813m;
                                }
                                else if (Screen_Width > 8600m && Screen_Width <= 8800m)
                                {
                                    Freedom_BasedPrice = 2840m;
                                }
                                else if (Screen_Width > 8800m)
                                {
                                    Freedom_BasedPrice = 2866m;
                                }
                                #endregion
                            }
                            else if (Screen_Height > 2800m && Screen_Height <= 3000m)
                            {
                                #region 3000 Base Price 

                                if (Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 2305m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 2332m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 2358m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 2385m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 2411m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 2438m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 2464m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 2491m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 2517m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 2544m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 2570m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 2597m;
                                }
                                else if (Screen_Width > 6400m && Screen_Width <= 6600m)
                                {
                                    Freedom_BasedPrice = 2623m;
                                }
                                else if (Screen_Width > 6600m && Screen_Width <= 6800m)
                                {
                                    Freedom_BasedPrice = 2650m;
                                }
                                else if (Screen_Width > 6800m && Screen_Width <= 7000m)
                                {
                                    Freedom_BasedPrice = 2676m;
                                }
                                else if (Screen_Width > 7000m && Screen_Width <= 7200m)
                                {
                                    Freedom_BasedPrice = 2703m;
                                }
                                else if (Screen_Width > 7200m && Screen_Width <= 7400m)
                                {
                                    Freedom_BasedPrice = 2730m;
                                }
                                else if (Screen_Width > 7400m && Screen_Width <= 7600m)
                                {
                                    Freedom_BasedPrice = 2756m;
                                }
                                else if (Screen_Width > 7600m && Screen_Width <= 7800m)
                                {
                                    Freedom_BasedPrice = 2783;
                                }
                                else if (Screen_Width > 7800m && Screen_Width <= 8000m)
                                {
                                    Freedom_BasedPrice = 2809m;
                                }
                                else if (Screen_Width > 8000m && Screen_Width <= 8200m)
                                {
                                    Freedom_BasedPrice = 2836m;
                                }
                                else if (Screen_Width > 8200m && Screen_Width <= 8400m)
                                {
                                    Freedom_BasedPrice = 2862m;
                                }
                                else if (Screen_Width > 8400m && Screen_Width <= 8600m)
                                {
                                    Freedom_BasedPrice = 2889m;
                                }
                                else if (Screen_Width > 8600m && Screen_Width <= 8800m)
                                {
                                    Freedom_BasedPrice = 2915m;
                                }
                                else if (Screen_Width > 8800m)
                                {
                                    Freedom_BasedPrice = 2942m;
                                }

                                #endregion

                            }
                            else if (Screen_Height > 3000m && Screen_Height <= 3200m)
                            {
                                #region 3200 Base Price

                                if (Screen_Width <= 4200m)
                                {
                                    Freedom_BasedPrice = 2381m;
                                }
                                else if (Screen_Width > 4200 && Screen_Width <= 4400m)
                                {
                                    Freedom_BasedPrice = 2407m;
                                }
                                else if (Screen_Width > 4400m && Screen_Width <= 4600m)
                                {
                                    Freedom_BasedPrice = 2434m;
                                }
                                else if (Screen_Width > 4600m && Screen_Width <= 4800m)
                                {
                                    Freedom_BasedPrice = 2460m;
                                }
                                else if (Screen_Width > 4800m && Screen_Width <= 5000m)
                                {
                                    Freedom_BasedPrice = 2487m;
                                }
                                else if (Screen_Width > 5000m && Screen_Width <= 5200m)
                                {
                                    Freedom_BasedPrice = 2513m;
                                }
                                else if (Screen_Width > 5200m && Screen_Width <= 5400m)
                                {
                                    Freedom_BasedPrice = 2540m;
                                }
                                else if (Screen_Width > 5400m && Screen_Width <= 5600m)
                                {
                                    Freedom_BasedPrice = 2566m;
                                }
                                else if (Screen_Width > 5600m && Screen_Width <= 5800m)
                                {
                                    Freedom_BasedPrice = 2593m;
                                }
                                else if (Screen_Width > 5800m && Screen_Width <= 6000m)
                                {
                                    Freedom_BasedPrice = 2619m;
                                }
                                else if (Screen_Width > 6000m && Screen_Width <= 6200m)
                                {
                                    Freedom_BasedPrice = 2646m;
                                }
                                else if (Screen_Width > 6200m && Screen_Width <= 6400m)
                                {
                                    Freedom_BasedPrice = 2672m;
                                }
                                else if (Screen_Width > 6400m && Screen_Width <= 6600m)
                                {
                                    Freedom_BasedPrice = 2699m;
                                }
                                else if (Screen_Width > 6600m && Screen_Width <= 6800m)
                                {
                                    Freedom_BasedPrice = 2725m;
                                }
                                else if (Screen_Width > 6800m && Screen_Width <= 7000m)
                                {
                                    Freedom_BasedPrice = 2752m;
                                }
                                else if (Screen_Width > 7000m && Screen_Width <= 7200m)
                                {
                                    Freedom_BasedPrice = 2778m;
                                }
                                else if (Screen_Width > 7200m && Screen_Width <= 7400m)
                                {
                                    Freedom_BasedPrice = 2805m;
                                }
                                else if (Screen_Width > 7400m && Screen_Width <= 7600m)
                                {
                                    Freedom_BasedPrice = 2832m;
                                }
                                else if (Screen_Width > 7600m && Screen_Width <= 7800m)
                                {
                                    Freedom_BasedPrice = 2858m;
                                }
                                else if (Screen_Width > 7800m && Screen_Width <= 8000m)
                                {
                                    Freedom_BasedPrice = 2885m;
                                }
                                else if (Screen_Width > 8000m && Screen_Width <= 8200m)
                                {
                                    Freedom_BasedPrice = 2911m;
                                }
                                else if (Screen_Width > 8200m && Screen_Width <= 8400m)
                                {
                                    Freedom_BasedPrice = 2938m;
                                }
                                else if (Screen_Width > 8400m && Screen_Width <= 8600m)
                                {
                                    Freedom_BasedPrice = 2964m;
                                }
                                else if (Screen_Width > 8600m && Screen_Width <= 8800m)
                                {
                                    Freedom_BasedPrice = 2991m;
                                }
                                else if (Screen_Width > 8800m)
                                {
                                    Freedom_BasedPrice = 3017m;
                                }

                                #endregion
                            }
                            #endregion
                        }
                        else if (Freedom_ScreenSize == Freedom_ScreenSize._100mm)
                        {
                            #region Double 100 mm 

                            if (Screen_Height <= 2200m)
                            {
                                #region 2200 Base Price

                                if (Screen_Width <= 6000)
                                {
                                    Freedom_BasedPrice = 2280m;
                                }
                                else if (Screen_Width > 6000 && Screen_Width <= 6200)
                                {
                                    Freedom_BasedPrice = 2037m;
                                }
                                else if (Screen_Width > 6200 && Screen_Width <= 6400)
                                {
                                    Freedom_BasedPrice = 2334m;
                                }
                                else if (Screen_Width > 6400 && Screen_Width <= 6600)
                                {
                                    Freedom_BasedPrice = 2362m;
                                }
                                else if (Screen_Width > 6600 && Screen_Width <= 6800)
                                {
                                    Freedom_BasedPrice = 2389m;
                                }
                                else if (Screen_Width > 6800 && Screen_Width <= 7000)
                                {
                                    Freedom_BasedPrice = 2416m;
                                }
                                else if (Screen_Width > 7000 && Screen_Width <= 7200)
                                {
                                    Freedom_BasedPrice = 2444m;
                                }
                                else if (Screen_Width > 7200 && Screen_Width <= 7400)
                                {
                                    Freedom_BasedPrice = 2471m;
                                }
                                else if (Screen_Width > 7400 && Screen_Width <= 7600)
                                {
                                    Freedom_BasedPrice = 2498m;
                                }
                                else if (Screen_Width > 7600 && Screen_Width <= 7800)
                                {
                                    Freedom_BasedPrice = 2526m;
                                }
                                else if (Screen_Width > 7800 && Screen_Width <= 8000)
                                {
                                    Freedom_BasedPrice = 2553m;
                                }
                                else if (Screen_Width > 8000 && Screen_Width <= 8200)
                                {
                                    Freedom_BasedPrice = 2580m;
                                }
                                else if (Screen_Width > 8200 && Screen_Width <= 8400)
                                {
                                    Freedom_BasedPrice = 2608m;
                                }
                                else if (Screen_Width > 8400 && Screen_Width <= 8600)
                                {
                                    Freedom_BasedPrice = 2635m;
                                }
                                else if (Screen_Width > 8600 && Screen_Width <= 8800)
                                {
                                    Freedom_BasedPrice = 2662m;
                                }
                                else if (Screen_Width > 8800 && Screen_Width <= 9000)
                                {
                                    Freedom_BasedPrice = 2690m;
                                }
                                else if (Screen_Width > 9000 && Screen_Width <= 9200m)
                                {
                                    Freedom_BasedPrice = 2717m;
                                }
                                else if (Screen_Width > 9200m && Screen_Width <= 9400m)
                                {
                                    Freedom_BasedPrice = 2744m;
                                }
                                else if (Screen_Width > 9400m && Screen_Width <= 9600m)
                                {
                                    Freedom_BasedPrice = 2771m;
                                }
                                else if (Screen_Width > 9600m && Screen_Width <= 9800m)
                                {
                                    Freedom_BasedPrice = 2801m;
                                }
                                else if (Screen_Width > 9800m && Screen_Width <= 10000m)
                                {
                                    Freedom_BasedPrice = 2831m;
                                }
                                else if (Screen_Width > 10000m && Screen_Width <= 10200m)
                                {
                                    Freedom_BasedPrice = 2863m;
                                }
                                else if (Screen_Width > 10200m && Screen_Width <= 10400m)
                                {
                                    Freedom_BasedPrice = 2893m;
                                }
                                else if (Screen_Width > 10400m && Screen_Width <= 10600m)
                                {
                                    Freedom_BasedPrice = 2924m;
                                }
                                else if (Screen_Width > 10600m && Screen_Width <= 10800m)
                                {
                                    Freedom_BasedPrice = 2954m;
                                }
                                else if (Screen_Width > 10800m && Screen_Width <= 11000)
                                {
                                    Freedom_BasedPrice = 2985m;
                                }
                                else if (Screen_Width > 11000 && Screen_Width <= 11200)
                                {
                                    Freedom_BasedPrice = 3015m;
                                }
                                else if (Screen_Width > 11200 && Screen_Width <= 11400)
                                {
                                    Freedom_BasedPrice = 3046m;
                                }
                                else if (Screen_Width > 11400 && Screen_Width <= 11600)
                                {
                                    Freedom_BasedPrice = 3076m;
                                }
                                else if (Screen_Width > 11600 && Screen_Width <= 11800)
                                {
                                    Freedom_BasedPrice = 3107m;
                                }
                                else if (Screen_Width > 11800 && Screen_Width <= 12000)
                                {
                                    Freedom_BasedPrice = 3137m;
                                }
                                else if (Screen_Width > 12000 && Screen_Width <= 12200)
                                {
                                    Freedom_BasedPrice = 3168m;
                                }
                                else if (Screen_Width > 12200 && Screen_Width <= 12400)
                                {
                                    Freedom_BasedPrice = 3198m;
                                }
                                else if (Screen_Width > 12400 && Screen_Width <= 12600)
                                {
                                    Freedom_BasedPrice = 3228m;
                                }
                                else if (Screen_Width > 12600 && Screen_Width <= 12800)
                                {
                                    Freedom_BasedPrice = 3259m;
                                }
                                else if (Screen_Width > 12800)
                                {
                                    Freedom_BasedPrice = 3290m;
                                }


                                #endregion
                            }
                            else if (Screen_Height > 2200m && Screen_Height <= 2400m)
                            {
                                #region 2400 Base Price

                                if (Screen_Width <= 6000)
                                {
                                    Freedom_BasedPrice = 2353;
                                }
                                else if (Screen_Width > 6000 && Screen_Width <= 6200)
                                {
                                    Freedom_BasedPrice = 2381m;
                                }
                                else if (Screen_Width > 6200 && Screen_Width <= 6400)
                                {
                                    Freedom_BasedPrice = 2408m;
                                }
                                else if (Screen_Width > 6400 && Screen_Width <= 6600)
                                {
                                    Freedom_BasedPrice = 2435m;
                                }
                                else if (Screen_Width > 6600 && Screen_Width <= 6800)
                                {
                                    Freedom_BasedPrice = 2463m;
                                }
                                else if (Screen_Width > 6800 && Screen_Width <= 7000)
                                {
                                    Freedom_BasedPrice = 2490m;
                                }
                                else if (Screen_Width > 7000 && Screen_Width <= 7200)
                                {
                                    Freedom_BasedPrice = 2517m;
                                }
                                else if (Screen_Width > 7200 && Screen_Width <= 7400)
                                {
                                    Freedom_BasedPrice = 2545m;
                                }
                                else if (Screen_Width > 7400 && Screen_Width <= 7600)
                                {
                                    Freedom_BasedPrice = 2572m;
                                }
                                else if (Screen_Width > 7600 && Screen_Width <= 7800)
                                {
                                    Freedom_BasedPrice = 2599m;
                                }
                                else if (Screen_Width > 7800 && Screen_Width <= 8000)
                                {
                                    Freedom_BasedPrice = 2627m;
                                }
                                else if (Screen_Width > 8000 && Screen_Width <= 8200)
                                {
                                    Freedom_BasedPrice = 2654m;
                                }
                                else if (Screen_Width > 8200 && Screen_Width <= 8400)
                                {
                                    Freedom_BasedPrice = 2681m;
                                }
                                else if (Screen_Width > 8400 && Screen_Width <= 8600)
                                {
                                    Freedom_BasedPrice = 2708m;
                                }
                                else if (Screen_Width > 8600 && Screen_Width <= 8800)
                                {
                                    Freedom_BasedPrice = 2736m;
                                }
                                else if (Screen_Width > 8800 && Screen_Width <= 9000)
                                {
                                    Freedom_BasedPrice = 2763m;
                                }
                                else if (Screen_Width > 9000 && Screen_Width <= 9200m)
                                {
                                    Freedom_BasedPrice = 2790m;
                                }
                                else if (Screen_Width > 9200m && Screen_Width <= 9400m)
                                {
                                    Freedom_BasedPrice = 2818m;
                                }
                                else if (Screen_Width > 9400m && Screen_Width <= 9600m)
                                {
                                    Freedom_BasedPrice = 2845m;
                                }
                                else if (Screen_Width > 9600m && Screen_Width <= 9800m)
                                {
                                    Freedom_BasedPrice = 2873m;
                                }
                                else if (Screen_Width > 9800m && Screen_Width <= 10000m)
                                {
                                    Freedom_BasedPrice = 2902m;
                                }
                                else if (Screen_Width > 10000m && Screen_Width <= 10200m)
                                {
                                    Freedom_BasedPrice = 2930m;
                                }
                                else if (Screen_Width > 10200m && Screen_Width <= 10400m)
                                {
                                    Freedom_BasedPrice = 2958m;
                                }
                                else if (Screen_Width > 10400m && Screen_Width <= 10600m)
                                {
                                    Freedom_BasedPrice = 2988m;
                                }
                                else if (Screen_Width > 10600m && Screen_Width <= 10800m)
                                {
                                    Freedom_BasedPrice = 3017m;
                                }
                                else if (Screen_Width > 10800m && Screen_Width <= 11000)
                                {
                                    Freedom_BasedPrice = 3047m;
                                }
                                else if (Screen_Width > 11000 && Screen_Width <= 11200)
                                {
                                    Freedom_BasedPrice = 3076m;
                                }
                                else if (Screen_Width > 11200 && Screen_Width <= 11400)
                                {
                                    Freedom_BasedPrice = 3105m;
                                }
                                else if (Screen_Width > 11400 && Screen_Width <= 11600)
                                {
                                    Freedom_BasedPrice = 3133m;
                                }
                                else if (Screen_Width > 11600 && Screen_Width <= 11800)
                                {
                                    Freedom_BasedPrice = 3161m;
                                }
                                else if (Screen_Width > 11800 && Screen_Width <= 12000)
                                {
                                    Freedom_BasedPrice = 3190m;
                                }
                                else if (Screen_Width > 12000 && Screen_Width <= 12200)
                                {
                                    Freedom_BasedPrice = 3219m;
                                }
                                else if (Screen_Width > 12200 && Screen_Width <= 12400)
                                {
                                    Freedom_BasedPrice = 3248m;
                                }
                                else if (Screen_Width > 12400 && Screen_Width <= 12600)
                                {
                                    Freedom_BasedPrice = 3277m;
                                }
                                else if (Screen_Width > 12600 && Screen_Width <= 12800)
                                {
                                    Freedom_BasedPrice = 3305m;
                                }
                                else if (Screen_Width > 12800)
                                {
                                    Freedom_BasedPrice = 3362m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2400m && Screen_Height <= 2600m)
                            {
                                #region 2600 Base Price

                                if (Screen_Width <= 6000)
                                {
                                    Freedom_BasedPrice = 2429m;
                                }
                                else if (Screen_Width > 6000 && Screen_Width <= 6200)
                                {
                                    Freedom_BasedPrice = 2456;
                                }
                                else if (Screen_Width > 6200 && Screen_Width <= 6400)
                                {
                                    Freedom_BasedPrice = 2484m;
                                }
                                else if (Screen_Width > 6400 && Screen_Width <= 6600)
                                {
                                    Freedom_BasedPrice = 2511m;
                                }
                                else if (Screen_Width > 6600 && Screen_Width <= 6800)
                                {
                                    Freedom_BasedPrice = 2538m;
                                }
                                else if (Screen_Width > 6800 && Screen_Width <= 7000)
                                {
                                    Freedom_BasedPrice = 2566m;
                                }
                                else if (Screen_Width > 7000 && Screen_Width <= 7200)
                                {
                                    Freedom_BasedPrice = 2593m;
                                }
                                else if (Screen_Width > 7200 && Screen_Width <= 7400)
                                {
                                    Freedom_BasedPrice = 2620m;
                                }
                                else if (Screen_Width > 7400 && Screen_Width <= 7600)
                                {
                                    Freedom_BasedPrice = 2648m;
                                }
                                else if (Screen_Width > 7600 && Screen_Width <= 7800)
                                {
                                    Freedom_BasedPrice = 2675m;
                                }
                                else if (Screen_Width > 7800 && Screen_Width <= 8000)
                                {
                                    Freedom_BasedPrice = 2690m;
                                }
                                else if (Screen_Width > 8000 && Screen_Width <= 8200)
                                {
                                    Freedom_BasedPrice = 2717m;
                                }
                                else if (Screen_Width > 8200 && Screen_Width <= 8400)
                                {
                                    Freedom_BasedPrice = 2757m;
                                }
                                else if (Screen_Width > 8400 && Screen_Width <= 8600)
                                {
                                    Freedom_BasedPrice = 2784m;
                                }
                                else if (Screen_Width > 8600 && Screen_Width <= 8800)
                                {
                                    Freedom_BasedPrice = 2811m;
                                }
                                else if (Screen_Width > 8800 && Screen_Width <= 9000)
                                {
                                    Freedom_BasedPrice = 2839m;
                                }
                                else if (Screen_Width > 9000 && Screen_Width <= 9200m)
                                {
                                    Freedom_BasedPrice = 2866m;
                                }
                                else if (Screen_Width > 9200m && Screen_Width <= 9400m)
                                {
                                    Freedom_BasedPrice = 2893m;
                                }
                                else if (Screen_Width > 9400m && Screen_Width <= 9600m)
                                {
                                    Freedom_BasedPrice = 2921m;
                                }
                                else if (Screen_Width > 9600m && Screen_Width <= 9800m)
                                {
                                    Freedom_BasedPrice = 2949m;
                                }
                                else if (Screen_Width > 9800m && Screen_Width <= 10000m)
                                {
                                    Freedom_BasedPrice = 2977m;
                                }
                                else if (Screen_Width > 10000m && Screen_Width <= 10200m)
                                {
                                    Freedom_BasedPrice = 3006m;
                                }
                                else if (Screen_Width > 10200m && Screen_Width <= 10400m)
                                {
                                    Freedom_BasedPrice = 3034m;
                                }
                                else if (Screen_Width > 10400m && Screen_Width <= 10600m)
                                {
                                    Freedom_BasedPrice = 3062m;
                                }
                                else if (Screen_Width > 10600m && Screen_Width <= 10800m)
                                {
                                    Freedom_BasedPrice = 3091m;
                                }
                                else if (Screen_Width > 10800m && Screen_Width <= 11000)
                                {
                                    Freedom_BasedPrice = 3119m;
                                }
                                else if (Screen_Width > 11000 && Screen_Width <= 11200)
                                {
                                    Freedom_BasedPrice = 3148m;
                                }
                                else if (Screen_Width > 11200 && Screen_Width <= 11400)
                                {
                                    Freedom_BasedPrice = 3177m;
                                }
                                else if (Screen_Width > 11400 && Screen_Width <= 11600)
                                {
                                    Freedom_BasedPrice = 3206m;
                                }
                                else if (Screen_Width > 11600 && Screen_Width <= 11800)
                                {
                                    Freedom_BasedPrice = 3235m;
                                }
                                else if (Screen_Width > 11800 && Screen_Width <= 12000)
                                {
                                    Freedom_BasedPrice = 3263m;
                                }
                                else if (Screen_Width > 12000 && Screen_Width <= 12200)
                                {
                                    Freedom_BasedPrice = 3292m;
                                }
                                else if (Screen_Width > 12200 && Screen_Width <= 12400)
                                {
                                    Freedom_BasedPrice = 3320m;
                                }
                                else if (Screen_Width > 12400 && Screen_Width <= 12600)
                                {
                                    Freedom_BasedPrice = 3348m;
                                }
                                else if (Screen_Width > 12600 && Screen_Width <= 12800)
                                {
                                    Freedom_BasedPrice = 3377m;
                                }
                                else if (Screen_Width > 12800)
                                {
                                    Freedom_BasedPrice = 3435m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2600m && Screen_Height <= 2800m)
                            {
                                #region 2800 Base Price

                                if (Screen_Width <= 6000)
                                {
                                    Freedom_BasedPrice = 2507m;
                                }
                                else if (Screen_Width > 6000 && Screen_Width <= 6200)
                                {
                                    Freedom_BasedPrice = 2534m;
                                }
                                else if (Screen_Width > 6200 && Screen_Width <= 6400)
                                {
                                    Freedom_BasedPrice = 2561m;
                                }
                                else if (Screen_Width > 6400 && Screen_Width <= 6600)
                                {
                                    Freedom_BasedPrice = 2589m;
                                }
                                else if (Screen_Width > 6600 && Screen_Width <= 6800)
                                {
                                    Freedom_BasedPrice = 2616m;
                                }
                                else if (Screen_Width > 6800 && Screen_Width <= 7000)
                                {
                                    Freedom_BasedPrice = 2643m;
                                }
                                else if (Screen_Width > 7000 && Screen_Width <= 7200)
                                {
                                    Freedom_BasedPrice = 2671m;
                                }
                                else if (Screen_Width > 7200 && Screen_Width <= 7400)
                                {
                                    Freedom_BasedPrice = 2698m;
                                }
                                else if (Screen_Width > 7400 && Screen_Width <= 7600)
                                {
                                    Freedom_BasedPrice = 2725m;
                                }
                                else if (Screen_Width > 7600 && Screen_Width <= 7800)
                                {
                                    Freedom_BasedPrice = 2753m;
                                }
                                else if (Screen_Width > 7800 && Screen_Width <= 8000)
                                {
                                    Freedom_BasedPrice = 2780m;
                                }
                                else if (Screen_Width > 8000 && Screen_Width <= 8200)
                                {
                                    Freedom_BasedPrice = 2807m;
                                }
                                else if (Screen_Width > 8200 && Screen_Width <= 8400)
                                {
                                    Freedom_BasedPrice = 2835m;
                                }
                                else if (Screen_Width > 8400 && Screen_Width <= 8600)
                                {
                                    Freedom_BasedPrice = 2862m;
                                }
                                else if (Screen_Width > 8600 && Screen_Width <= 8800)
                                {
                                    Freedom_BasedPrice = 2889m;
                                }
                                else if (Screen_Width > 8800 && Screen_Width <= 9000)
                                {
                                    Freedom_BasedPrice = 2916m;
                                }
                                else if (Screen_Width > 9000 && Screen_Width <= 9200m)
                                {
                                    Freedom_BasedPrice = 2944m;
                                }
                                else if (Screen_Width > 9200m && Screen_Width <= 9400m)
                                {
                                    Freedom_BasedPrice = 2971m;
                                }
                                else if (Screen_Width > 9400m && Screen_Width <= 9600m)
                                {
                                    Freedom_BasedPrice = 2998m;
                                }
                                else if (Screen_Width > 9600m && Screen_Width <= 9800m)
                                {
                                    Freedom_BasedPrice = 3027m;
                                }
                                else if (Screen_Width > 9800m && Screen_Width <= 10000m)
                                {
                                    Freedom_BasedPrice = 3055m;
                                }
                                else if (Screen_Width > 10000m && Screen_Width <= 10200m)
                                {
                                    Freedom_BasedPrice = 3084m;
                                }
                                else if (Screen_Width > 10200m && Screen_Width <= 10400m)
                                {
                                    Freedom_BasedPrice = 3112m;
                                }
                                else if (Screen_Width > 10400m && Screen_Width <= 10600m)
                                {
                                    Freedom_BasedPrice = 3140m;
                                }
                                else if (Screen_Width > 10600m && Screen_Width <= 10800m)
                                {
                                    Freedom_BasedPrice = 3169m;
                                }
                                else if (Screen_Width > 10800m && Screen_Width <= 11000)
                                {
                                    Freedom_BasedPrice = 3197m;
                                }
                                else if (Screen_Width > 11000 && Screen_Width <= 11200)
                                {
                                    Freedom_BasedPrice = 3225;
                                }
                                else if (Screen_Width > 11200 && Screen_Width <= 11400)
                                {
                                    Freedom_BasedPrice = 3254m;
                                }
                                else if (Screen_Width > 11400 && Screen_Width <= 11600)
                                {
                                    Freedom_BasedPrice = 3282m;
                                }
                                else if (Screen_Width > 11600 && Screen_Width <= 11800)
                                {
                                    Freedom_BasedPrice = 3310m;
                                }
                                else if (Screen_Width > 11800 && Screen_Width <= 12000)
                                {
                                    Freedom_BasedPrice = 3339m;
                                }
                                else if (Screen_Width > 12000 && Screen_Width <= 12200)
                                {
                                    Freedom_BasedPrice = 3367m;
                                }
                                else if (Screen_Width > 12200 && Screen_Width <= 12400)
                                {
                                    Freedom_BasedPrice = 3396m;
                                }
                                else if (Screen_Width > 12400 && Screen_Width <= 12600)
                                {
                                    Freedom_BasedPrice = 3424m;
                                }
                                else if (Screen_Width > 12600 && Screen_Width <= 12800)
                                {
                                    Freedom_BasedPrice = 3452m;
                                }
                                else if (Screen_Width > 12800)
                                {
                                    Freedom_BasedPrice = 3509m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 2800m && Screen_Height <= 3000m)
                            {
                                #region 3000 Base Price

                                if (Screen_Width <= 6000)
                                {
                                    Freedom_BasedPrice = 2582m;
                                }
                                else if (Screen_Width > 6000 && Screen_Width <= 6200)
                                {
                                    Freedom_BasedPrice = 2610m;
                                }
                                else if (Screen_Width > 6200 && Screen_Width <= 6400)
                                {
                                    Freedom_BasedPrice = 2637m;
                                }
                                else if (Screen_Width > 6400 && Screen_Width <= 6600)
                                {
                                    Freedom_BasedPrice = 2664m;
                                }
                                else if (Screen_Width > 6600 && Screen_Width <= 6800)
                                {
                                    Freedom_BasedPrice = 2692m;
                                }
                                else if (Screen_Width > 6800 && Screen_Width <= 7000)
                                {
                                    Freedom_BasedPrice = 2719m;
                                }
                                else if (Screen_Width > 7000 && Screen_Width <= 7200)
                                {
                                    Freedom_BasedPrice = 2746m;
                                }
                                else if (Screen_Width > 7200 && Screen_Width <= 7400)
                                {
                                    Freedom_BasedPrice = 2774m;
                                }
                                else if (Screen_Width > 7400 && Screen_Width <= 7600)
                                {
                                    Freedom_BasedPrice = 2801m;
                                }
                                else if (Screen_Width > 7600 && Screen_Width <= 7800)
                                {
                                    Freedom_BasedPrice = 2828m;
                                }
                                else if (Screen_Width > 7800 && Screen_Width <= 8000)
                                {
                                    Freedom_BasedPrice = 2856m;
                                }
                                else if (Screen_Width > 8000 && Screen_Width <= 8200)
                                {
                                    Freedom_BasedPrice = 2883m;
                                }
                                else if (Screen_Width > 8200 && Screen_Width <= 8400)
                                {
                                    Freedom_BasedPrice = 2910m;
                                }
                                else if (Screen_Width > 8400 && Screen_Width <= 8600)
                                {
                                    Freedom_BasedPrice = 2937m;
                                }
                                else if (Screen_Width > 8600 && Screen_Width <= 8800)
                                {
                                    Freedom_BasedPrice = 2965m;
                                }
                                else if (Screen_Width > 8800 && Screen_Width <= 9000)
                                {
                                    Freedom_BasedPrice = 2992m;
                                }
                                else if (Screen_Width > 9000 && Screen_Width <= 9200m)
                                {
                                    Freedom_BasedPrice = 3019m;
                                }
                                else if (Screen_Width > 9200m && Screen_Width <= 9400m)
                                {
                                    Freedom_BasedPrice = 3047m;
                                }
                                else if (Screen_Width > 9400m && Screen_Width <= 9600m)
                                {
                                    Freedom_BasedPrice = 3074m;
                                }
                                else if (Screen_Width > 9600m && Screen_Width <= 9800m)
                                {
                                    Freedom_BasedPrice = 3101m;
                                }
                                else if (Screen_Width > 9800m && Screen_Width <= 10000m)
                                {
                                    Freedom_BasedPrice = 3129m;
                                }
                                else if (Screen_Width > 10000m && Screen_Width <= 10200m)
                                {
                                    Freedom_BasedPrice = 3156m;
                                }
                                else if (Screen_Width > 10200m && Screen_Width <= 10400m)
                                {
                                    Freedom_BasedPrice = 3183m;
                                }
                                else if (Screen_Width > 10400m && Screen_Width <= 10600m)
                                {
                                    Freedom_BasedPrice = 3211m;
                                }
                                else if (Screen_Width > 10600m && Screen_Width <= 10800m)
                                {
                                    Freedom_BasedPrice = 3238m;
                                }
                                else if (Screen_Width > 10800m && Screen_Width <= 11000)
                                {
                                    Freedom_BasedPrice = 3265m;
                                }
                                else if (Screen_Width > 11000 && Screen_Width <= 11200)
                                {
                                    Freedom_BasedPrice = 3293m;
                                }
                                else if (Screen_Width > 11200 && Screen_Width <= 11400)
                                {
                                    Freedom_BasedPrice = 3321m;
                                }
                                else if (Screen_Width > 11400 && Screen_Width <= 11600)
                                {
                                    Freedom_BasedPrice = 3349m;
                                }
                                else if (Screen_Width > 11600 && Screen_Width <= 11800)
                                {
                                    Freedom_BasedPrice = 3377m;
                                }
                                else if (Screen_Width > 11800 && Screen_Width <= 12000)
                                {
                                    Freedom_BasedPrice = 3404m;
                                }
                                else if (Screen_Width > 12000 && Screen_Width <= 12200)
                                {
                                    Freedom_BasedPrice = 3431m;
                                }
                                else if (Screen_Width > 12200 && Screen_Width <= 12400)
                                {
                                    Freedom_BasedPrice = 3459m;
                                }
                                else if (Screen_Width > 12400 && Screen_Width <= 12600)
                                {
                                    Freedom_BasedPrice = 3487m;
                                }
                                else if (Screen_Width > 12600 && Screen_Width <= 12800)
                                {
                                    Freedom_BasedPrice = 3515m;
                                }
                                else if (Screen_Width > 12800)
                                {
                                    Freedom_BasedPrice = 3583m;
                                }

                                #endregion
                            }
                            else if (Screen_Height > 3000m && Screen_Height <= 3200m)
                            {
                                #region 3200 Base Price

                                if (Screen_Width <= 6000)
                                {
                                    Freedom_BasedPrice = 2660m;
                                }
                                else if (Screen_Width > 6000 && Screen_Width <= 6200)
                                {
                                    Freedom_BasedPrice = 2687m;
                                }
                                else if (Screen_Width > 6200 && Screen_Width <= 6400)
                                {
                                    Freedom_BasedPrice = 2715m;
                                }
                                else if (Screen_Width > 6400 && Screen_Width <= 6600)
                                {
                                    Freedom_BasedPrice = 2742m;
                                }
                                else if (Screen_Width > 6600 && Screen_Width <= 6800)
                                {
                                    Freedom_BasedPrice = 2769m;
                                }
                                else if (Screen_Width > 6800 && Screen_Width <= 7000)
                                {
                                    Freedom_BasedPrice = 2797m;
                                }
                                else if (Screen_Width > 7000 && Screen_Width <= 7200)
                                {
                                    Freedom_BasedPrice = 2824m;
                                }
                                else if (Screen_Width > 7200 && Screen_Width <= 7400)
                                {
                                    Freedom_BasedPrice = 2851m;
                                }
                                else if (Screen_Width > 7400 && Screen_Width <= 7600)
                                {
                                    Freedom_BasedPrice = 2879m;
                                }
                                else if (Screen_Width > 7600 && Screen_Width <= 7800)
                                {
                                    Freedom_BasedPrice = 2906m;
                                }
                                else if (Screen_Width > 7800 && Screen_Width <= 8000)
                                {
                                    Freedom_BasedPrice = 2933m;
                                }
                                else if (Screen_Width > 8000 && Screen_Width <= 8200)
                                {
                                    Freedom_BasedPrice = 2961m;
                                }
                                else if (Screen_Width > 8200 && Screen_Width <= 8400)
                                {
                                    Freedom_BasedPrice = 2988m;
                                }
                                else if (Screen_Width > 8400 && Screen_Width <= 8600)
                                {
                                    Freedom_BasedPrice = 3015m;
                                }
                                else if (Screen_Width > 8600 && Screen_Width <= 8800)
                                {
                                    Freedom_BasedPrice = 3043m;
                                }
                                else if (Screen_Width <= 9000)
                                {
                                    Freedom_BasedPrice = 3070m;
                                }
                                else if (Screen_Width > 9000 && Screen_Width <= 9200m)
                                {
                                    Freedom_BasedPrice = 3097m;
                                }
                                else if (Screen_Width > 9200m && Screen_Width <= 9400m)
                                {
                                    Freedom_BasedPrice = 3124m;
                                }
                                else if (Screen_Width > 9400m && Screen_Width <= 9600m)
                                {
                                    Freedom_BasedPrice = 3152m;
                                }
                                else if (Screen_Width > 9600m && Screen_Width <= 9800m)
                                {
                                    Freedom_BasedPrice = 3179m;
                                }
                                else if (Screen_Width > 9800m && Screen_Width <= 10000m)
                                {
                                    Freedom_BasedPrice = 3206m;
                                }
                                else if (Screen_Width > 10000m && Screen_Width <= 10200m)
                                {
                                    Freedom_BasedPrice = 3234m;
                                }
                                else if (Screen_Width > 10200m && Screen_Width <= 10400m)
                                {
                                    Freedom_BasedPrice = 3261m;
                                }
                                else if (Screen_Width > 10400m && Screen_Width <= 10600m)
                                {
                                    Freedom_BasedPrice = 3288m;
                                }
                                else if (Screen_Width > 10600m && Screen_Width <= 10800m)
                                {
                                    Freedom_BasedPrice = 3316m;
                                }
                                else if (Screen_Width > 10800m && Screen_Width <= 11000)
                                {
                                    Freedom_BasedPrice = 3344m;
                                }
                                else if (Screen_Width > 11000 && Screen_Width <= 11200)
                                {
                                    Freedom_BasedPrice = 3372m;
                                }
                                else if (Screen_Width > 11200 && Screen_Width <= 11400)
                                {
                                    Freedom_BasedPrice = 3401m;
                                }
                                else if (Screen_Width > 11400 && Screen_Width <= 11600)
                                {
                                    Freedom_BasedPrice = 3429m;
                                }
                                else if (Screen_Width > 11600 && Screen_Width <= 11800)
                                {
                                    Freedom_BasedPrice = 3458m;
                                }
                                else if (Screen_Width > 11800 && Screen_Width <= 12000)
                                {
                                    Freedom_BasedPrice = 3486m;
                                }
                                else if (Screen_Width > 12000 && Screen_Width <= 12200)
                                {
                                    Freedom_BasedPrice = 3514m;
                                }
                                else if (Screen_Width > 12200 && Screen_Width <= 12400)
                                {
                                    Freedom_BasedPrice = 3543m;
                                }
                                else if (Screen_Width > 12400 && Screen_Width <= 12600)
                                {
                                    Freedom_BasedPrice = 3571m;
                                }
                                else if (Screen_Width > 12600 && Screen_Width <= 12800)
                                {
                                    Freedom_BasedPrice = 3599m;
                                }
                                else if (Screen_Width > 12800)
                                {
                                    Freedom_BasedPrice = 3656m;
                                }

                                #endregion
                            }
                            #endregion
                        }

                    }

                    Freedom_MeshUp = ((12m * Screen_Width) / 1000m) * (Screen_Height / 1000m);
                    Freedom_AUDTCost = Freedom_BasedPrice + Freedom_PowderCoating + Freedom_MeshUp;
                    Freedom_PesoTCost = Freedom_AUDTCost * Screen_ExchangeRateAUD;

                    Freedom_Foiling_Cassette = (1573m * (Screen_Height + 30m)) / 1000m;
                    Freedom_Foiling_TopRail = (394m * (Screen_Width + 30m)) / 1000m;
                    Freedom_Foiling_SideRail = (630m * (Screen_Height + 30m)) / 1000m;
                    Freedom_Foiling_PullBar = (1049m * (Screen_Height + 30m)) / 1000m;

                    Freedom_Foiling_Total = Freedom_Foiling_Cassette +
                                            Freedom_Foiling_TopRail +
                                            Freedom_Foiling_SideRail +
                                            Freedom_Foiling_PullBar;

                    Freedom_KM04 = ((1300m * Screen_Width) / 1000m) * 2m;

                    Freedom_tCost_SF = (Freedom_PesoTCost +
                                        Freedom_Foiling_Total +
                                        Freedom_KM04 +
                                        Freedom_Installation_Cost +
                                        Freedom_OverHead_Cost +
                                        Freedom_Accessories) * Screen_Factor;

                    Freedom_tAmount = (Freedom_tCost_SF * 0.55m) + Freedom_Fr_Shipping_Cost;

                    #endregion                               
                }


                #region Screen AddOns

                #region roll up Screen
                if (Screen_PVCVisibility == true &&
                    Screen_0505Width != 0 &&
                    Screen_0505Qty != 0 
                    )
                {
                    pvc0505Price = ((Screen_0505Width * Screen_0505Qty) / 1000m) * pvc0505PricePerLinearMeter * Screen_Factor;
                }
                else if (Screen_PVCVisibility == true &&
                        Screen_1067Height != 0 &&
                        Screen_1067Qty != 0)
                {
                    pvc1067Price = ((Screen_1067Height * Screen_1067Qty) / 1000m) * pvc1067PriceLinearMeter * Screen_Factor;
                }
                #endregion
                #region Plisse Screen
                if (Screen_1067PVCboxVisibility == true &&
                    Screen_1067PVCbox != 0 &&
                    Screen_1067PVCboxQty != 0)
                {
                    pvc1067withreinPrice = ((Screen_1067PVCbox * Screen_1067PVCboxQty) / 1000m) * pvc1067withreinforcementPriceLinearMeter * AddOnsSpecialFactor;
                }
                if (Screen_6040MilledProfileVisibility == true &&
                    Screen_6040MilledProfile != 0 &&
                    Screen_6040MilledProfileQty != 0)
                {
                    milledprofile6040Price = ((Screen_6040MilledProfile * Screen_6040MilledProfileQty) / 1000m) * milledprofile6040PriceLinearMeter * Screen_Factor;
                }
                if (Screen_6052MilledProfileVisibility == true &&
                    Screen_6052MilledProfile != 0 &&
                    Screen_6052MilledProfileQty != 0)
                {
                    milled6052Price = ((Screen_6052MilledProfile * Screen_6052MilledProfileQty) / 1000m) * milled6052profilePricePerLinearMeter * AddOnsSpecialFactor;
                }
                if(Screen_LandCoverVisibility == true &&
                    Screen_LandCover != 0 &&
                    _screen_LandCoverQty != 0)
                {
                    landCoverPrice = ((Screen_LandCover * Screen_LandCoverQty) / 1000m) * landCoverPriceLinearMeter * Screen_Factor;
                }
                #endregion
                #region Maxxy Screen

                if (Screen_373or374MilledProfileVisibility == true &&
                    Screen_373or374MilledProfile != 0 &&
                    Screen_373or374MilledProfileQty != 0)
                {
                    milled373or374Price = ((Screen_373or374MilledProfile * Screen_373or374MilledProfileQty) / 1000m) * milled373or374PricePerLinearMeter * AddOnsSpecialFactor;
                }

                #endregion
                #region Built in sideroll

                if (Screen_1385MilledProfileVisibility == true &&
                   Screen_1385MilledProfile != 0 &&
                   Screen_1385MilledProfileQty != 0)
                {
                    milled1385Price = ((Screen_1385MilledProfile * Screen_1385MilledProfileQty) / 1000m) * milled1385profilePricePerLinearMeter * AddOnsSpecialFactor;
                }
                if (Screen_6052MilledProfileVisibility == true &&
                        Screen_6052MilledProfile != 0 &&
                        Screen_6052MilledProfileQty != 0)
                {
                    milled6052Price = ((Screen_6052MilledProfile * Screen_6052MilledProfileQty) / 1000m) * milled6052profilePricePerLinearMeter * AddOnsSpecialFactor;
                }
                #endregion
                #region center closure

                if (Screen_CenterClosureVisibility == true && Screen_CenterClosureVisibilityOption == true)
                {
                    LatchkitTotal = (LatchkitPrice * Screen_LatchKitQty) * AddOnsSpecialFactor;

                    if(LatchkitTotal > 0)
                    {
                        if (Screen_Height <= 1499m)
                        {
                            Intermediate_X_ = 0;
                        }
                        else
                        {
                            Intermediate_X_ = ((Screen_Height - 1500m - 450m) / 1000m);
                        }
                    }
                    else if(Screen_Height <= 1499m)
                    {
                        Intermediate_X_ = 0;
                    }
                    else
                    {
                        Intermediate_X_ = ((Screen_Height - 1500m - 450m) / 1000m);
                    }
                    IntermediatePartTotal = (IntermediatePartPrice * Intermediate_X_ * Screen_IntermediatePartQty) * AddOnsSpecialFactor;

                }

                #endregion

                #endregion

                decimal RollUpAdditional = TotalRollUpCostingMaterials - RollUpCostingMaterials;

                basicMats = RollUpCostingMaterials +
                            TotalPlisseCostingMaterials;

                WasteCost = basicMats * 0.1m;

                FreightCost = (TotalRollUpCostingMaterials +
                               TotalPlisseCostingMaterials +
                               (WasteCost * WithWasteCost)) * 0.05m;

                DandTCost = (basicMats +
                            RollUpAdditional +
                            (WasteCost * WithWasteCost) +
                            FreightCost) * 0.16m;

                SmallShopItemCost = 200 +
                                    LocalMaterialPrice;

                ContingenciesCost = (basicMats +
                                    RollUpAdditional +
                                    WasteCost +
                                    FreightCost +
                                    DandTCost +
                                    SmallShopItemCost +
                                    OverheadCost) * 0.05m;

                AddOnsPrice = pvc0505Price +
                              pvc1067Price +
                              pvc1067withreinPrice +
                              milledprofile6040Price +
                              LatchkitTotal +
                              IntermediatePartTotal +
                              landCoverPrice ;

                TotalPrice = TotalRollUpCostingMaterials +
                             TotalPlisseCostingMaterials +
                             WasteCost +
                             FreightCost +
                             DandTCost +
                             SmallShopItemCost +
                             OverheadCost +
                             ContingenciesCost;
                             //+
                             //AddOnsPrice;

                if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._RD)
                {
                    TotalPrice = (TotalRollUpCostingMaterials +
                                  TotalPlisseCostingMaterials +
                                  WasteCost +
                                  FreightCost +
                                  DandTCost +
                                  SmallShopItemCost +
                                  OverheadCost +
                                  ContingenciesCost +
                                  AddOnsPrice) + (1000m * ((Screen_Height / 1000m) * PlissedRd_Panels));
                }

                #region Screen Unit Price & TotalAmount

                if (Screen_Types == ScreenType._Maxxy ||
                    Screen_Types == ScreenType._ZeroGravityChainDriven)
                {
                    #region Maxxy & ZeroGravityChina
                    if (FromCellEndEdit != true)
                    {
                        Screen_UnitPrice = (((Math.Ceiling(Magnum_Screen_tAmount) +
                                             Math.Ceiling(Maxxy_Screen_tAmount) +
                                             Math.Ceiling(ZG_totalMaterial_Cost)) * Screen_Factor) + milled373or374Price + LatchkitTotal + IntermediatePartTotal) * Screen_Set;
                    }
                    PriceIncreaseByPercentage();
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity;

                    Discount = Screen_UnitPrice * DiscountPercentage;
                    Screen_NetPrice = Math.Round((Screen_UnitPrice - Discount) * Screen_Quantity, 2);
                    #endregion
                }
                else if (Screen_Types == ScreenType._RollUp || Screen_Types == ScreenType._Plisse)
                {
                    if (Screen_Types == ScreenType._RollUp || Screen_PlisséType == PlisseType._AD || Screen_PlisséType == PlisseType._RD)
                    {
                        #region Roll-up & Plisse AD RD                     
                        if (FromCellEndEdit != true)
                        {
                            Screen_UnitPrice = ((Math.Ceiling(TotalPrice) * Screen_Factor) + AddOnsPrice) * Screen_Set;                    
                        }
                        PriceIncreaseByPercentage();
                        Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity;

                        Discount = Screen_UnitPrice * DiscountPercentage;
                        Screen_NetPrice = (Screen_UnitPrice - Discount) * Screen_Quantity;
                        #endregion
                    }
                    else if (Screen_PlisséType == PlisseType._SR)
                    {
                        #region Plisse SR Magnum
                        if (FromCellEndEdit != true)
                        {
                            Screen_UnitPrice = ((Math.Ceiling(Magnum_Screen_tAmount) * Screen_Factor)
                                                + LatchkitTotal + IntermediatePartTotal + pvc1067withreinPrice + milledprofile6040Price + milled6052Price)
                                                * Screen_Set;
                        }
                        PriceIncreaseByPercentage();
                        Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity;

                        Discount = Screen_UnitPrice * DiscountPercentage;
                        Screen_NetPrice = Math.Round((Screen_UnitPrice - Discount) * Screen_Quantity, 2);                                            
                        #endregion
                    }
                }
                else if (Screen_Types == ScreenType._BuiltInSideroll)
                {
                    #region built in 
                    if (FromCellEndEdit != true)
                    {
                        Screen_UnitPrice = (built_in_SR_tAmount + milled1385Price + milled6052Price + LatchkitTotal + IntermediatePartTotal) * Screen_Set;
                    }
                    PriceIncreaseByPercentage();
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity;

                    Discount = Screen_UnitPrice * DiscountPercentage;
                    Screen_NetPrice = (Screen_UnitPrice - Discount) * Screen_Quantity;
                    #endregion
                }
                else if (Screen_Types == ScreenType._Freedom)
                {
                    #region Freedom
                    if (FromCellEndEdit != true)
                    {
                        Screen_UnitPrice = (Math.Ceiling(Freedom_tAmount) + LatchkitTotal + IntermediatePartTotal) * Screen_Set;
                    }
                    PriceIncreaseByPercentage();
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity;

                    Discount = Screen_UnitPrice * DiscountPercentage;
                    Screen_NetPrice = (Screen_UnitPrice - Discount) * Screen_Quantity;
                    #endregion
                }
                else if(Screen_Types == ScreenType._SlidingScreen)
                {
                    #region Sliding Screen 
                    if (FromCellEndEdit != true)
                    {
                        Screen_UnitPrice = Screen_UnitPrice * Screen_Set;
                    }
                    PriceIncreaseByPercentage();
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity;

                    Discount = Screen_UnitPrice * DiscountPercentage;
                    Screen_NetPrice = (Screen_UnitPrice - Discount) * Screen_Quantity;
                    #endregion
                }
                else if (Screen_Types == ScreenType._NoInsectScreen || Screen_Types == ScreenType._UnnecessaryForInsectScreen)
                {
                    #region no&Unnecessary
                    Screen_Quantity = 0;
                    Screen_UnitPrice = 0;
                    DiscountPercentage = 0;
                    Screen_TotalAmount = 0;
                    Discount = 0;
                    Screen_NetPrice = 0;
                    #endregion
                }
                else
                {
                    Screen_Quantity = 0;
                    Screen_UnitPrice = 0;
                    DiscountPercentage = 0;
                    Screen_TotalAmount = 0;
                    Discount = 0;
                    Screen_NetPrice = 0;
                }

                Screen_Discount = (int)Decimal.Truncate(100 * DiscountPercentage);

                #endregion

                #region Screen Type Description 


                if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._AD)
                {
                    Screen_Description = "Plissé AD Insect Screen";
                }
                else if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._RD)
                {
                    Screen_Description = "Plissé RD Insect Screen";
                }
                else if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._SR)
                {
                    if(Reinforced == true)
                    {
                        Screen_Description = "Reinforced Plissé SR Slim Line Insect Screen";
                    }
                    else
                    {
                        Screen_Description = "Plissé SR Slim Line Insect Screen";
                    }
                }
                else if (Screen_Types == ScreenType._Freedom)
                {
                    #region Freedom Desc
                    if (Freedom_ScreenType == Freedom_ScreenType._single)
                    {
                        if (Freedom_ScreenSize == Freedom_ScreenSize._80mm)
                        {
                            Screen_Description = "Roll-Out Zip Screen by Freedom (ZL280) - Single ";
                        }
                        else
                        {
                            Screen_Description = "Roll-Out Zip Screen by Freedom (ZL2100) - Single ";
                        }
                    }
                    else if (Freedom_ScreenType == Freedom_ScreenType._double)
                    {
                        if (Freedom_ScreenSize == Freedom_ScreenSize._80mm)
                        {
                            Screen_Description = "Roll-Out Zip Screen by Freedom (ZL280) - Double ";
                        }
                        else
                        {
                            Screen_Description = "Roll-Out Zip Screen by Freedom (ZL2100) - Double ";
                        }
                    }
                    #endregion
                }
                else if (Screen_Types == ScreenType._Maxxy)
                {
                    Screen_Description = "Roll-Out Maxxy Insect Screen";
                }
                else if (Screen_Types == ScreenType._BuiltInSideroll)
                {
                    Screen_Description = "Built-In Sideroll Insect Screen";
                }
                else if (Screen_Types == ScreenType._RollUp)
                {
                    Screen_Description = "Roll-up Insect Screen";
                }
                else if (Screen_Types == ScreenType._ZeroGravityChainDriven)
                {
                    Screen_Description = "Zero Gravity Chain Driven Insect Screen";
                }
                else if (Screen_Types == ScreenType._NoInsectScreen)
                {
                    Screen_Description = "No Insect Screen";
                }
                else if (Screen_Types == ScreenType._UnnecessaryForInsectScreen)
                {
                    Screen_Description = "Unnecessary for Insect Screen";
                }
                else
                {
                    Screen_Description = " ";
                }

                if (Screen_CenterClosureVisibility == true && Screen_CenterClosureVisibilityOption == true)
                {
                    if (LatchkitTotal != 0 && IntermediatePartTotal != 0)
                    {
                        Screen_Description = Screen_Description + " - Center Closure ";
                    }
                    else if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._SR)
                    {
                        //Screen_Description = Screen_Description + " - Center Closure ";                     
                        Screen_Description = Screen_Description + " - Center Closure  ";                     
                        _plisséSRPerPanelWidth = Screen_Width / 2;
                        Screen_Width = _plisséSRPerPanelWidth;
                    }
                    else
                    {
                        Screen_Description = Screen_Description;                     
                    }
                }
                else
                {
                    Screen_Description = Screen_Description;
                }

                #endregion

                #region Screen DisplayedDimension

                Screen_DisplayedDimension = Screen_Width + " x " + Screen_Height;

                #endregion

                ClearingOperation();

            }
            else if (Screen_Types == ScreenType._NoInsectScreen || Screen_Types == ScreenType._UnnecessaryForInsectScreen)
            {
                if (Screen_Types == ScreenType._UnnecessaryForInsectScreen)
                {
                    Screen_Description = "Unnecessary for Insect Screen";
                }
                else
                {
                    Screen_Description = "No Insect Screen";
                }
                #region no&Unnecessary
                Screen_Quantity = 0;
                Screen_UnitPrice = 0;
                DiscountPercentage = 0;
                Screen_TotalAmount = 0;
                Discount = 0;
                Screen_NetPrice = 0;
                #endregion
            }
            else
            {
                Screen_Description = " ";
                Screen_Quantity = 0;
                Screen_UnitPrice = 0;
                DiscountPercentage = 0;
                Screen_TotalAmount = 0;
                Discount = 0;
                Screen_NetPrice = 0;
            }

        }

        public void ClearingOperation()
        {
            #region ClearingOperation
            TotalRollUpCostingMaterials = 0;
            TotalPlisseCostingMaterials = 0;
            RollUpCostingMaterials = 0;
            PlisseCostingMaterials = 0;
            basicMats = 0;
            HeadRailPrice = 0;
            SlidingBarPrice = 0;
            MeshWithTubePrice = 0;
            GuidePrice = 0;
            PilePrice = 0;
            AntiwindBrushPrice = 0;
            WasteCost = 0;
            FreightCost = 0;
            KitForVerticalOpeningHeadrailPrice = 0;
            BrakePrice = 0;
            SupportForFixingHeadRailPrice = 0;
            SpringLoadedPrice = 0;
            DandTCost = 0;
            SmallShopItemCost = 0;
            OverheadCost = 0;
            ContingenciesCost = 0;
            AddOnsPrice = 0;
            pvc0505Price = 0;
            pvc1067Price = 0;
            TotalPrice = 0;
            LocalMaterialPrice = 0;
            #endregion
            #region clearing for Magnum Screen
            Bushing_Qty = 0;
            MinyClips_Qty = 0;
            Wire_Qty = 0;

            KM01_Alum_BottomGuide_whiteFinish = 0;
            KM01_Alum_BottomGuide_woodFinish = 0;
            SideU_for_WindowApp_whiteFinish = 0;
            SideU_for_WindowApp_woodFinish = 0;
            Reinforce_Addon = 0;
            Reinforced_Labor = 0;

            PleatedMeshDoubleHori_tCost = 0;
            PleatedMeshSingeFixed_tCost = 0;
            PleatedMeshSingleCentral_tCost = 0;

            Wire_tCost = 0;
            Bushing_tCost = 0;
            TensionerNoGrubs_tCost = 0;
            Grubs4x6_tCost = 0;
            CordCurriere3Holes_tCost = 0;
            SpringForTensioner_tCost = 0;
            BottomEndCapMagnum31mmHorizontalNoWheel_tCost = 0;
            TopEndCapMagnum31mmHorizontalNoWheel_tCost = 0;
            Wheel_tCost = 0;
            PinForWheel_tCost = 0;
            AdhesiveTapeAluminumPlate_tCost = 0;
            AdhesiveTapeBottomGuide_tCost = 0;
            MinyClips_tCost = 0;
            MagnetsClicIntoRollinFly_tCost = 0;
            NegativeMagntePlisse_tCost = 0;

            PlissePositivePlisse_tCost = 0;
            DoubleCentePart_tCost = 0;
            BottomEndCapMagnum31mm_DoubleHori_tCost = 0;

            //RAL COLOR
            AluminumPlateWithTeeth_RALColor_tCost = 0;
            AluminumPlateNoTeeth_RALColor_tCost = 0;
            Magnum31mmSlidingBar_RALColor_tCost = 0;
            Magnum31mmBottomGuide_RALColor_tCost = 0;
            Magnum31mmTopGuide_RALColor_tCost = 0;
            Magnum31mmTensionersProfile_RALColor_tCost = 0;
            Magnum31mmsideU_RALColor_tCost = 0;
            //Mill Finish
            AluminumPlateWithTeeth_MillFinish_tCost = 0;
            AluminumPlateNoTeeth_MillFinish_tCost = 0;
            Magnum31mmSlidingBar_MillFinish_tCost = 0;
            Magnum31mmBottomGuide_MillFinish_tCost = 0;
            Magnum31mmTopGuide_MillFinish_tCost = 0;
            Magnum31mmTensionersProfile_MillFinish_tCost = 0;
            Magnum31mmsideU_MillFinish_tCost = 0;
            //Foiled
            Magnum31mmSlidingBar_Foiled_tCost = 0;
            Magnum31mmTopGuide_Foiled_tCost = 0;
            Magnum31mmsideU_Foiled_tCost = 0;
            //Costing Total
            RALColor_TotalCost = 0;
            MillFinish_TotalCost = 0;
            Foiled_TotalCost = 0;
            Magnum_Screen_tAmount = 0;
            #endregion
            #region clearing for Zero Gravity

            pile_Qty = 0;
            supp_fixing_42mm_headrail_Qty = 0;
            dowell_4x25_Qty = 0;
            screw_4x25_Qty = 0;
            ZG_waste_10per_ = 0;
            ZG_freight_5per = 0;
            ZG_importation_Cost = 0;
            additional_for_Woograin = 0;
            ZG_Contigencies = 0;
            ZG_totalMaterial_Cost = 0;
            roller_case_Price = 0;
            sliding_bar_Price = 0;
            mesh_w_tube_Price = 0;
            guide_70x22_Price = 0;
            reinforing_hand_slidingbar_Price = 0;
            profiles_supp_tube_ZG_Price = 0;
            pile_Price = 0;
            anti_wind_brush_Price = 0;
            kit_genius_46mm_ZG_Price = 0;
            supp_fixing_42mm_headrail_Price = 0;
            dowell_4x25_Price = 0;
            screw_4x25_Price = 0;

            #endregion
            #region Clearing for Built in SR 
            price_base_on_Height = 0;
            price_base_on_Weight = 0;
            built_in_SR_tAmount = 0;

            base_Price = 0;
            height_Base_Price_Inc = 0;
            width_Base_Price_Inc = 0;
            height_deci = 0;
            weight_deci = 0;
            percentage_multiplier = 0;

            Height_mm_to_meters = 0;
            Width_mm_to_meters = 0;


            holder = 0;
            curr_index_pos = 0;

            current_deci_index = 0;
            next_deci_index = 0;

            #endregion
            #region Clearing for Maxxy Screen

            PP_Maxy_5mmTube = 0;
            ScorpionTail_8 = 0;
            Mohair = 0;
            Maxy_ScorpionTail_53pcs = 0;
            Maxy_Pile = 0;
            Bottom_Rail = 0;
            Case_Maxy_MillFinish = 0;
            SlidingBar_Maxy_MillFinish = 0;
            TopGuide_Maxy_MillFinish = 0;
            UProfile_46mm_Maxy_MillFinish = 0;
            Case_Maxy_RalColour = 0;
            SlidingBar_Maxy_RalColour = 0;
            TopGuide_Maxy_RalColour = 0;
            UProfile_46mm_Maxy_RalColour = 0;
            Hook_V_MillFinish_tCost = 0;
            Hook_V_RalFinish_tCost = 0;
            Maxxy_Screen_tAmount = 0;

            //Hook Version 
            Cover_ProfileLatch_MillFinish = 0;
            Cover_ProfileLatch_RalColour = 0;
            Latch_Rsz = 0;
            Latch_Hanger_Rsz = 0;
            Maxxy_1248_Coupling_Profile = 0;
            Maxxy_Total_Mat_Cost = 0;
            Maxxy_Wastage = 0;
            Maxxy_Freight = 0;
            Maxxy_DT = 0;
            Maxxy_KM01 = 0;
            Maxxy_KM02 = 0;
            Maxxy_AlumBottomGuide = 0;
            Maxxy_Contigencies = 0;

            #endregion
            #region Clearing for Freedom Screen

            Freedom_BasedPrice = 0;
            Freedom_MeshUp = 0;
            Freedom_AUDTCost = 0;
            Freedom_PesoTCost = 0;

            Freedom_Foiling_Cassette = 0;
            Freedom_Foiling_TopRail = 0;
            Freedom_Foiling_SideRail = 0;
            Freedom_Foiling_PullBar = 0;
            Freedom_Foiling_Total = 0;

            Freedom_KM04 = 0;
            Freedom_tCost_SF = 0;
            Freedom_tAmount = 0;

            #endregion

            pvc1067withreinPrice = 0;
            milledprofile6040Price = 0;
            landCoverPrice = 0;
            milled373or374Price = 0;
            milled1385Price = 0;
            milled6052Price = 0;

            LatchkitTotal = 0;
            IntermediatePartTotal = 0;

            //AddOnsSpecialFactor = 0;
            IncreasePercentage = 0;
            TotalUnitPrice = 0;
        }

        public void ScreenPropAddOnsReset()
        {
            Screen_0505Width = 0;
            Screen_0505Qty = 0;
            Screen_1067Height = 0;
            Screen_1067Qty = 0;

            Screen_1067PVCbox = 0;
            Screen_1067PVCboxQty = 0;
            Screen_6040MilledProfile = 0;
            Screen_6040MilledProfileQty = 0;

            Screen_373or374MilledProfile = 0;
            Screen_373or374MilledProfileQty = 0;

            Screen_1385MilledProfile = 0;
            Screen_1385MilledProfileQty = 0;
            Screen_6052MilledProfile = 0;
            Screen_6052MilledProfileQty = 0;

            Screen_LatchKitQty = 0;
            Screen_IntermediatePartQty = 0;
            Screen_PriceIncreasePercentage = 5;
        }


        public ScreenModel(decimal screen_itemnumber,
                           int screen_width,
                           int screen_height,
                           ScreenType screen_types,
                           string screen_windoorID,
                           decimal screen_unitPrice,
                           int screen_quantity,
                           int screen_set,
                           int discount,
                           decimal screen_netPrice,
                           decimal screen_totalAmount,
                           string screen_description,
                           decimal factor,
                           decimal addonsspecialfactor,
                           string screen_displayeddimension
                           )
        {
            Screen_ItemNumber = screen_itemnumber;
            Screen_Width = screen_width;
            Screen_Height = screen_height;
            Screen_Types = screen_types;
            Screen_WindoorID = screen_windoorID;
            Screen_UnitPrice = screen_unitPrice;
            Screen_Quantity = screen_quantity;
            Screen_Set = screen_set;
            Screen_Discount = discount;
            Screen_NetPrice = screen_netPrice;
            Screen_TotalAmount = screen_totalAmount;
            Screen_Description = screen_description;
            Screen_Factor = factor;
            Screen_AddOnsSpecialFactor = addonsspecialfactor;
            Screen_DisplayedDimension = screen_displayeddimension;
        }
    }
}
