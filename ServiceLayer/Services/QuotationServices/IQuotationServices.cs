using System.Collections.Generic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;

namespace ServiceLayer.Services.QuotationServices
{
    public interface IQuotationServices
    {
        IQuotationModel CreateQuotationModel(string quotation_ref_no, List<IWindoorModel> lst_wndr);
        IQuotationModel AddQuotationModel(string quotation_ref_no,
                                          List<IWindoorModel> lst_wndr = null);
        void ValidateModel(IQuotationModel quotationModel);
    }
}