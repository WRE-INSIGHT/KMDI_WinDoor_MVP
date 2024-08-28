using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Screen
{               
    public class ScreenPartialAdjustmentProperties : IScreenPartialAdjustmentProperties
    {

        public long Screen_id { get; set; }
        public decimal Screen_ItemNumber { get; set; }
        public string Screen_WindoorID { get; set; }
        public string Screen_Description { get; set; }
        public int Screen_Set { get; set; }
        public string Screen_DisplayedDimension { get; set; }
        public decimal Screen_UnitPrice { get; set; }
        public int Screen_Quantity { get; set; }
        public decimal Screen_NetPrice { get; set; }
        public int Screen_Discount { get; set; }
        public decimal Screen_TotalAmount { get; set;}
        public int Screen_Original_Quantity { get; set; }
        

        public ScreenType Screen_Type_Revised { get; set; }
        public string Screen_Description_Revised { get; set; }
        public int Screen_Set_Revised { get; set; }
        public decimal Screen_UnitPrice_Revised { get; set; }
        public int Screen_Quantity_Revised { get; set; }
        public int Screen_Discount_Revised { get; set; }
        public decimal Screen_NetPrice_Revised { get; set; }
        public string Screen_DisplayedDimes_Revised { get; set; }
        public decimal Screen_Factor_Revised { get; set; }
        public decimal Screen_AddOnsSpecialFactor_Revised { get; set; }
        public decimal Screen_Adjustment_Price { get; set; }
        public bool Screen_isAdjusted { get; set; }
        public decimal Screen_TotalAmount_Revised { get; set;}
        public bool Screen_IsChild { get; set; }
        public long Screen_Parent_ID { get; set; }
    }
}
