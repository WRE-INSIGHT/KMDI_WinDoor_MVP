using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Screen
{
    public interface IScreenModel
    {
        int Screen_id { get; set; }
        bool Screen_Types_Window { get; set; }
        bool Screen_Types_Door { get; set; }
        int Screen_Width { get; set; }
        int Screen_Height { get; set; }
        decimal Screen_Factor { get; set; }
        ScreenType Screen_Types { get; set; }
        PlisseType Screen_PlisséType { get; set; }
        Base_Color Screen_BaseColor { get; set; }
        int Screen_Set { get; set; }
        string Screen_WindoorID { get; set; }//location
        decimal Screen_UnitPrice { get; set; }
        int Screen_Quantity { get; set; }
        decimal Screen_TotalAmount { get; set; }
        decimal Screen_NetPrice { get; set; }
        int Screen_Discount { get; set; }
        decimal Screen_DiscountedPrice { get; set; }
        decimal Screen_DiscountedPriceWithoutVat { get; set; }
        decimal Screen_LaborAndMobilization { get; set; }
        decimal Screen_TotalNetPriceWithoutVat { get; set; }
        bool Screen_PVCVisibility { get; set; }      
        bool SpringLoad_Visibility { get; set; }

        bool SpringLoad_Checked { get; set; }

        int Screen_0505Width { get; set; }
        int Screen_1067Height { get; set; }
        int Screen_0505Qty { get; set; }
        int Screen_1067Qty { get; set; }
        bool Screen_CenterClosureVisibility { get; set; }
        bool Screen_CenterClosureVisibilityOption { get; set; }
        int Screen_LatchKitQty { get; set; }
        int Screen_IntermediatePartQty { get; set; }
        bool Screen_6040MilledProfileVisibility { get; set; }
        int Screen_6040MilledProfile { get; set; }
        int Screen_6040MilledProfileQty { get; set; }
        bool Screen_LandCoverVisibility { get; set; }
        int Screen_LandCover { get; set; }
        int Screen_LandCoverQty { get; set; }
        bool Screen_1385MilledProfileVisibility { get; set; }
        int Screen_1385MilledProfile { get; set; }
        int Screen_1385MilledProfileQty { get; set; }
        bool Screen_373or374MilledProfileVisibility { get; set; }
        int Screen_373or374MilledProfile { get; set; }
        int Screen_373or374MilledProfileQty { get; set; }
        bool Screen_6052MilledProfileVisibility { get; set; }
        int Screen_6052MilledProfile { get; set; }
        int Screen_6052MilledProfileQty { get; set; }
        bool Screen_ExchangeRateVisibility { get; set; }
        int Screen_ExchangeRate { get; set; }
        void ItemNumberList();
        void DeleteItemNumber(decimal x);
        void ComputeScreenTotalPrice();
        bool Reinforced { get; set; }
        bool SP_MagnumScreenType_Visibility { get; set; }
        Magnum_ScreenType Magnum_ScreenType { get; set; }
        int PlissedRd_Panels { get; set; }
        string PlisseMagnumType { get; set; }
        decimal DiscountPercentage { get; set; }
        decimal Screen_ItemNumber { get; set; }
        decimal Screen_NextItemNumber { get; set; }
        Freedom_ScreenSize Freedom_ScreenSize { get; set; }
        Freedom_ScreenType Freedom_ScreenType { get; set; }


    }
}