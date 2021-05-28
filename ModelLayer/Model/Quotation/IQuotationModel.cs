using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.WinDoor;
using System.Data;

namespace ModelLayer.Model.Quotation
{
    public interface IQuotationModel
    {
        string Quotation_ref_no { get; set; }

        int Frame_PUFoamingQty_Total { get; set; }
        int Frame_SealantWHQty_Total { get; set; }
        int Glass_SealantWHQty_Total { get; set; }

        List<IWindoorModel> Lst_Windoor { get; set; }
        DataTable GetListOfMaterials();
        DataTable GetListOfMaterials(IWindoorModel item);
    }
}
