﻿using ModelLayer.Variables;
using System;
using System.ComponentModel;
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

        AddOnsPrice,

        pvc1067PriceLinearMeter,
        pvc0505PricePerLinearMeter,

        pvc0505Price,
        pvc1067Price,


        basicMats,
        WasteCost,
        FreightCost,
        DandTCost,
        SmallShopItemCost,
        OverheadCost,
        ContingenciesCost,
        TotalPrice,

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
         next_deci_index = 0;

        decimal[] deci_getter = new decimal[22] {1.0m, 1.1m, 1.2m, 1.3m, 1.4m, 1.5m, 1.6m, 1.7m, 1.8m, 1.9m, 2.0m,
                                                 2.1m, 2.2m,2.3m, 2.4m, 2.5m, 2.6m,2.7m, 2.8m,2.9m ,3.0m,3.1m };

        decimal[] width_Base_Price_List = new decimal[21];
        decimal[] height_Base_Price_List = new decimal[16];
        int[] indices_pos = new int[5] { 2, 6, 11, 16, 20 };
        int holder = 0;
        int curr_index_pos = 0;
        #endregion



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


        private decimal _screen_Discount;
        public decimal Screen_Discount
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

        private string _plisseMagnumType;
        public string PlisseMagnumType
        {
            get
            {
                return _plisseMagnumType;
            }
            set
            {
                _plisseMagnumType = value;
                NotifyPropertyChanged();
            }
        }

        #endregion



        public void ComputeScreenTotalPrice()
        {
            #region priceBaseOnColor

            if (Screen_BaseColor == Base_Color._White ||
                Screen_BaseColor == Base_Color._Ivory)
            {
                pvc1067PriceLinearMeter = 300;
                pvc0505PricePerLinearMeter = 420;
            }
            else if (Screen_BaseColor == Base_Color._DarkBrown)
            {
                pvc1067PriceLinearMeter = 495;
                pvc0505PricePerLinearMeter = 735;
            }

            #endregion


            if (Screen_Width != 0 &&
                Screen_Height != 0 &&
                Screen_Factor != 0)
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
                }
                else if (Screen_Types == ScreenType._Magnum)
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
                        }
                        built_in_SR_tAmount = (price_base_on_Weight / 2.2m) * 2.8m;
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
                        }
                        built_in_SR_tAmount = (price_base_on_Weight / 2.3m) * 2.9m;
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
                        }
                        built_in_SR_tAmount = (price_base_on_Weight / 2.4m) * 3m;

                        #endregion
                    }

                    #endregion

                    #endregion
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
                    else if(Screen_BaseColor == Base_Color._DarkBrown)
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

                if (Screen_PVCVisibility == true &&
                    Screen_0505Width != 0 &&
                    Screen_1067Height != 0 &&
                    Screen_0505Qty != 0 &&
                    Screen_1067Qty != 0)
                {
                    pvc0505Price = ((Screen_0505Width * Screen_0505Qty) / 1000m) * pvc0505PricePerLinearMeter * Screen_Factor;
                    pvc1067Price = ((Screen_1067Height * Screen_1067Qty) / 1000m) * pvc1067PriceLinearMeter * Screen_Factor;
                }

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
                              pvc1067Price;

                TotalPrice = TotalRollUpCostingMaterials +
                             TotalPlisseCostingMaterials +
                             WasteCost +
                             FreightCost +
                             DandTCost +
                             SmallShopItemCost +
                             OverheadCost +
                             ContingenciesCost +
                             AddOnsPrice;

                if(Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._RD)
                {
                    TotalPrice = (TotalRollUpCostingMaterials +
                                  TotalPlisseCostingMaterials +
                                  WasteCost +
                                  FreightCost +
                                  DandTCost +
                                  SmallShopItemCost +
                                  OverheadCost +
                                  ContingenciesCost +
                                  AddOnsPrice)  + (1000m * ((Screen_Height / 1000m ) * PlissedRd_Panels) );
                }

                #region Screen Unit Price & TotalAmount

                if (Screen_Types == ScreenType._Magnum)
                {
                    Screen_UnitPrice = Math.Ceiling(Magnum_Screen_tAmount) * Screen_Factor;
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity * Screen_Set;
                }
                else if (Screen_Types == ScreenType._RollUp || Screen_Types ==  ScreenType._Plisse)
                {                    
                    Screen_UnitPrice = Math.Ceiling(TotalPrice) * Screen_Factor;
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity * Screen_Set;
                }            
                else if (Screen_Types == ScreenType._ZeroGravityChainDriven)
                {
                    Screen_UnitPrice = Math.Ceiling(ZG_totalMaterial_Cost) * Screen_Factor;
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity * Screen_Set;
                }
                else if (Screen_Types == ScreenType._BuiltInSideroll)
                {
                    Screen_UnitPrice = Math.Round(built_in_SR_tAmount, 2);
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity * Screen_Set;
                }
                else if (Screen_Types == ScreenType._Maxxy)
                {
                    Screen_UnitPrice = Math.Ceiling(Maxxy_Screen_tAmount) * Screen_Factor;
                    Screen_TotalAmount = Screen_UnitPrice * Screen_Quantity * Screen_Set;
                }

                #endregion

                #region Screen Type Description

                if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._AD)
                {
                    PlisseMagnumType = " ( " + Convert.ToString(PlisseType._AD) +  " ) " ;
                }
                else if (Screen_Types == ScreenType._Plisse && Screen_PlisséType == PlisseType._RD)
                {
                    PlisseMagnumType = " ( " + Convert.ToString(PlisseType._RD) + " ) ";
                }
                else if (Screen_Types == ScreenType._Magnum && Magnum_ScreenType == Magnum_ScreenType._Single_Fixed)
                {
                    PlisseMagnumType = " ( " + Convert.ToString(Magnum_ScreenType._Single_Fixed) + " ) ";
                }
                else if (Screen_Types == ScreenType._Magnum && Magnum_ScreenType == Magnum_ScreenType._Double_Fixed)
                {
                    PlisseMagnumType = " ( " + Convert.ToString(Magnum_ScreenType._Double_Fixed) + " ) ";
                }
                else if (Screen_Types == ScreenType._Magnum && Magnum_ScreenType == Magnum_ScreenType._Single_Central)
                {
                    PlisseMagnumType = " ( " + Convert.ToString(Magnum_ScreenType._Single_Central) + " ) ";
                }
                else
                {
                    PlisseMagnumType = " ";
                }

                #endregion

                ClearingOperation();
          

            }
            else
            {
                Screen_TotalAmount = 0;
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
        }



        public ScreenModel(int screen_id,
                           int screen_width,
                           int screen_height,
                           decimal screen_factor,
                           ScreenType screen_types,
                           string screen_windoorID,
                           decimal screen_unitPrice,
                           int screen_quantity,
                           decimal screen_totalAmount)
        {
            Screen_id = screen_id;
            Screen_Width = screen_width;
            Screen_Height = screen_height;
            Screen_Factor = screen_factor;
            Screen_Types = screen_types;
            Screen_WindoorID = screen_windoorID;
            Screen_UnitPrice = screen_unitPrice;
            Screen_Quantity = screen_quantity;
            Screen_TotalAmount = screen_totalAmount;
        }
    }
}
