using ModelLayer.Variables;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Screen
{
    public class ScreenModel : IScreenModel, INotifyPropertyChanged
    {


        private ConstantVariables constants = new ConstantVariables();

        #region Variables
        //roll up
        decimal
        ExchangeRate = 64m,

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

        AddOnsPrice,

        pvc1067PriceLinearMeter,
        pvc0505PricePerLinearMeter,

        pvc0505Price,
        pvc1067Price,

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

        WasteCost,
        FreightCost,
        DandTCost,
        SmallShopItemCost,
        OverheadCost,
        ContingenciesCost,
        TotalPrice;

        #endregion

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





        public void ComputeScreenTotalPrice()
        {
            decimal basicFiveMats;

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
                    if (Screen_BaseColor == Base_Color._White ||
                        Screen_BaseColor == Base_Color._Ivory)
                    {
                        #region Default Roll-Up Mats

                        HeadRailPricePerLinearMeter_White = (26.46m / 5.8m) * ExchangeRate * 1.42m;
                        SlidingBarPricePerPiece_White = (16.92m / 5.8m) * ExchangeRate * 1.42m;
                        MeshWithTubePricePerLinearMeter_White = 58.45761m / 5.8m * ExchangeRate;
                        GuidePricePerLinearMeter_White = 14.18m / 5.8m * ExchangeRate * 1.42m;
                        PilePricePerLinearMeter_White = 0.15396m * ExchangeRate;
                        AntiwindBrushPricePerLinearMeter_White = 0.38639m * ExchangeRate;
                        KitForVerticalOpeningHeadrailPricePerLinearMeter_White = 4.2108m * ExchangeRate;
                        BrakePriceperPiece_White = 2.5m * ExchangeRate * BrakeQty;
                        SupportForFixingHeadRailPricePerLinearMeter_White = 0.4773m * ExchangeRate;
                        if (Screen_Width >= 1500)
                        {
                            SpringLoadedPricePerPiece_White = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion

                        HeadRailPrice = (HeadRailPricePerLinearMeter_White * HeadRailQty * Screen_Width) / 1000m;
                        SlidingBarPrice = (SlidingBarPricePerPiece_White * SlidingBarQty * Screen_Width) / 1000m;
                        MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_White * MeshWithTubeQty * Screen_Width) / 1000m;
                        GuidePrice = (GuidePricePerLinearMeter_White * GuideQty * Screen_Width) / 1000m;
                        PilePrice = ((Screen_Height + Screen_Width) * PilePricePerLinearMeter_White * PileQty) / 1000m;
                        AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_White * AntiwindBrushQty * Screen_Height) / 1000m;
                        KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_White * KitForVerticalOpeningHeadrailQty;
                        BrakePrice = 2.5m * ExchangeRate * BrakeQty;
                        SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_White * SupportForFixingHeadRailQty;

                        if (Screen_Width >= 1500)
                        {
                            SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m * SpringLoadedQty;
                        }


                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {
                        #region defaultMats

                        HeadRailPricePerLinearMeter_WoodGrain = 5.574m * ExchangeRate * 1.4m;
                        SlidingBarPricePerPiece_WoodGrain = 3.606m * ExchangeRate * 1.4m;
                        MeshWithTubePricePerLinearMeter_WoodGrain = 58.45761m / 5.8m * ExchangeRate;
                        GuidePricePerLinearMeter_WoodGrain = 3.398m * ExchangeRate * 1.4m;
                        PilePricePerLinearMeter_WoodGrain = 0.15396m * ExchangeRate;
                        AntiwindBrushPricePerLinearMeter_WoodGrain = 0.38639m * ExchangeRate;
                        KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain = 4.2108m * ExchangeRate;
                        BrakePriceperPiece_WoodGrain = 2.5m * ExchangeRate;
                        SupportForFixingHeadRailPricePerLinearMeter_WoodGrain = 0.4773m * ExchangeRate;
                        if (Screen_Width >= 1500)
                        {
                            SpringLoadedPricePerPiece_WoodGrain = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion

                        HeadRailPrice = (HeadRailPricePerLinearMeter_WoodGrain * HeadRailQty * Screen_Width) / 1000m;
                        SlidingBarPrice = (SlidingBarPricePerPiece_WoodGrain * SlidingBarQty * Screen_Width) / 1000m;
                        MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_WoodGrain * MeshWithTubeQty * Screen_Width) / 1000m;
                        GuidePrice = (GuidePricePerLinearMeter_WoodGrain * GuideQty * Screen_Height) / 1000m;
                        PilePrice = ((Screen_Height + Screen_Width) * PilePricePerLinearMeter_WoodGrain * PileQty) / 1000m;
                        AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_WoodGrain * AntiwindBrushQty * Screen_Height) / 1000m;
                        KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain * KitForVerticalOpeningHeadrailQty;
                        BrakePrice = 2.5m * ExchangeRate;
                        SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_WoodGrain * SupportForFixingHeadRailQty;
                        if (Screen_Width >= 1500)
                        {
                            SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m * SpringLoadedQty;
                        }


                    }

                }
                else if (Screen_Types == ScreenType._Piconet)
                {
                    if (Screen_BaseColor == Base_Color._White ||
                        Screen_BaseColor == Base_Color._Ivory)
                    {

                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {

                    }
                }
                else if (Screen_Types == ScreenType._Plisse)
                {
                    if (Screen_BaseColor == Base_Color._White ||
                        Screen_BaseColor == Base_Color._Ivory)
                    {

                    }
                    else if (Screen_BaseColor == Base_Color._DarkBrown)
                    {

                    }
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



                basicFiveMats = HeadRailPrice +
                                       SlidingBarPrice +
                                       MeshWithTubePrice +
                                       GuidePrice +
                                       PilePrice +
                                       AntiwindBrushPrice;

                WasteCost = basicFiveMats * 0.1m;

                FreightCost = (basicFiveMats +
                              KitForVerticalOpeningHeadrailPrice +
                              BrakePrice +
                              SupportForFixingHeadRailPrice +
                              SpringLoadedPrice +
                              WasteCost) * 0.05m;

                DandTCost = (basicFiveMats +
                            KitForVerticalOpeningHeadrailPrice +
                            BrakePrice +
                            SupportForFixingHeadRailPrice +
                            SpringLoadedPrice +
                            WasteCost +
                            FreightCost) * 0.16m;

                SmallShopItemCost = 200;
                OverheadCost = 0.2m * 6000;
                ContingenciesCost = (basicFiveMats +
                                    KitForVerticalOpeningHeadrailPrice +
                                    BrakePrice +
                                    SupportForFixingHeadRailPrice +
                                    SpringLoadedPrice +
                                    WasteCost +
                                    FreightCost +
                                    DandTCost +
                                    SmallShopItemCost +
                                    OverheadCost) * 0.05m;

                AddOnsPrice = pvc0505Price +
                              pvc1067Price;

                TotalPrice = basicFiveMats +
                             KitForVerticalOpeningHeadrailPrice +
                             BrakePrice +
                             SupportForFixingHeadRailPrice +
                             SpringLoadedPrice +
                             WasteCost +
                             FreightCost +
                             DandTCost +
                             SmallShopItemCost +
                             OverheadCost +
                             ContingenciesCost +
                             AddOnsPrice;



                Screen_TotalAmount = (Math.Ceiling(TotalPrice) * Screen_Factor) * Screen_Quantity;

            }
            else
            {
                Screen_TotalAmount = 0;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
