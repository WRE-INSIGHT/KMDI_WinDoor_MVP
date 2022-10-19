﻿using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Screen
{
    public interface IScreenModel
    {
        int Screen_id { get; set; }
        int Screen_Width { get; set; }
        int Screen_Height { get; set; }
        decimal Screen_Factor { get; set; }
        ScreenType Screen_Types { get; set; }
        string Screen_BaseColor { get; set; }
        string Screen_WindoorID { get; set; }//location
        decimal Screen_UnitPrice { get; set; }
        int Screen_Quantity { get; set; }
        decimal Screen_TotalAmount { get; set; }
        decimal Screen_NetPrice { get; set; }
        decimal Screen_Discount { get; set; }
        decimal Screen_DiscountedPrice { get; set; }
        decimal Screen_DiscountedPriceWithoutVat { get; set; }
        decimal Screen_LaborAndMobilization { get; set; }
        decimal Screen_TotalNetPriceWithoutVat { get; set; }

        bool Screen_PVCVisibility { get; set; }
        int Screen_0505Width { get; set; }
        int Screen_1067Height { get; set; }
        int Screen_0505Qty { get; set; }
        int Screen_1067Qty { get; set; }



    }
}