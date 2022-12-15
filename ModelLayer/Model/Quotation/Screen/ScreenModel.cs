using ModelLayer.Variables;
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
        TotalPrice;

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

                        if (Screen_Width >= 1500 && SpringLoad_Checked == true)
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
                        if (Screen_Width >= 1500 && SpringLoad_Checked == true)
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
                    if (Screen_PlisséType == PlisseType._AD)
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
                    #region Mangnum 
                    if (Screen_BaseColor == Base_Color._White ||
                        Screen_BaseColor == Base_Color._Ivory)
                    {

                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {

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




                Screen_TotalAmount = Math.Ceiling(TotalPrice) * Screen_Factor * Screen_Quantity * Screen_Set;

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
