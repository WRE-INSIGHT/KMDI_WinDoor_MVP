using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;

namespace ModelLayer.Model.Quotation
{
    public class QuotationModel : IQuotationModel
    {
        public List<IWindoorModel> Lst_Windoor { get; set; }
        public string Quotation_ref_no { get; set; }
    }
}
