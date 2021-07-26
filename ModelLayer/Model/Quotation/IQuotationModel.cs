using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using System.Data;

namespace ModelLayer.Model.Quotation
{
    public interface IQuotationModel
    {
        string Quotation_ref_no { get; set; }

        int Frame_PUFoamingQty_Total { get; set; }
        int Frame_SealantWHQty_Total { get; set; }
        int Glass_SealantWHQty_Total { get; set; }
        int GlazingSpacer_TotalQty { get; set; }
        int GlazingSeal_TotalQty { get; set; }
        int Screws_for_Fabrication { get; set; }
        int Expansion_BoltQty_Total { get; set; }
        int Screws_for_Installation { get; set; }
        int Rebate_Qty { get; set; }
        int Plastic_CoverQty_Total { get; set; }
        List<IWindoorModel> Lst_Windoor { get; set; }
        DataTable GetListOfMaterials();
        DataTable GetListOfMaterials(IWindoorModel item);
    }
}
