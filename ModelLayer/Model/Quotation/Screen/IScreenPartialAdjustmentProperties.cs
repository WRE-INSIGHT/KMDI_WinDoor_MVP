using EnumerationTypeLayer;

namespace ModelLayer.Model.Quotation.Screen
{
    public interface IScreenPartialAdjustmentProperties
    {

        long Screen_id { get; set; }
        decimal Screen_ItemNumber { get; set; }
        string Screen_WindoorID { get; set; }
        string Screen_Description { get; set; }
        int Screen_Set { get; set; }
        string Screen_DisplayedDimension { get; set; }
        decimal Screen_UnitPrice { get; set; }
        int Screen_Quantity { get; set; }
        decimal Screen_NetPrice { get; set; }

        decimal Screen_AddOnsSpecialFactor_Revised { get; set; }
        decimal Screen_Adjustment_Price { get; set; }
        string Screen_Description_Revised { get; set; }
        int Screen_Discount_Revised { get; set; }
        string Screen_DisplayedDimes_Revised { get; set; }
        decimal Screen_Factor_Revised { get; set; }
        bool Screen_isAdjusted { get; set; }
        decimal Screen_NetPrice_Revised { get; set; }
        int Screen_Quantity_Revised { get; set; }
        int Screen_Set_Revised { get; set; }
        EnumerationTypes.ScreenType Screen_Type_Revised { get; set; }
        decimal Screen_UnitPrice_Revised { get; set; }
    }
}