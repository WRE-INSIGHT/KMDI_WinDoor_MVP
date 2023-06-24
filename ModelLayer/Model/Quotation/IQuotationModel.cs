using ModelLayer.Model.Quotation.WinDoor;
using System;
using System.Collections.Generic;
using System.Data;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation
{
    public interface IQuotationModel
    {
        string Quotation_ref_no { get; set; }
        DateTime Quotation_Date { get; set; }

        int Frame_PUFoamingQty_Total { get; set; }
        int Frame_SealantWHQty_Total { get; set; }
        int Glass_SealantWHQty_Total { get; set; }
        int GlazingSpacer_TotalQty { get; set; }
        int GlazingSeal_TotalQty { get; set; }
        int Screws_for_Fabrication { get; set; }
        int Expansion_BoltQty_Total { get; set; }
        int Screws_for_Installation { get; set; }
        int Screws_for_6050Frame { get; set; }
        int Screws_for_6055Frame { get; set; }
        int ACC_for_6050 { get; set; }
        int Screws_for_Cladding { get; set; }
        int Rebate_Qty { get; set; }
        int Plastic_CoverQty_Total { get; set; }
        decimal PricingFactor { get; set; }
        DateTime Date_Assigned { get; set; }
        string Customer_Ref_Number { get; set; }
        BillOfMaterialsFilter BOM_Filter { get; set; }
        bool BOM_Status { get; set; }
        string BOMandItemlistStatus { get; set; }
        bool itemSelectStatus { get; set; }
        List<IWindoorModel> Lst_Windoor { get; set; }
        List<decimal> lstTotalPrice { get; set; }
        bool ProvinceIntownOrOutoftown { get; set; }//Intown = true , OutOfTown = false
        decimal Quote_TotalPrice { get; set; }
        string TotalPriceHistory { get; set; }
        string TotalPriceHistoryStatus { get; set; }
        List<string> lst_TotalPriceHistory { get; set; }
        DataTable GetListOfMaterials(IWindoorModel item);
        void Select_Current_Windoor(IWindoorModel item);
        DataTable ItemCostingPriceAndPoints();
    }
}
