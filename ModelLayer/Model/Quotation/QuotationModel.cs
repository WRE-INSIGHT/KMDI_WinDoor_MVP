using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Model.Quotation
{
    public class QuotationModel : IQuotationModel
    {
        public List<IWindoorModel> Lst_Windoor { get; set; }

        [Required(ErrorMessage = "Quotation reference number is Required")]
        public string Quotation_ref_no { get; set; }
    }
}
