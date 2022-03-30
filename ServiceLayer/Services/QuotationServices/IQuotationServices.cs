using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;

namespace ServiceLayer.Services.QuotationServices
{
    public interface IQuotationServices
    {
        IQuotationModel AddQuotationModel(string quotation_ref_no,
                                          DateTime quote_date,
                                          List<IWindoorModel> lst_wndr = null);
        void ValidateModel(IQuotationModel quotationModel);
        Task<int> Insert_Quotation(IQuotationModel quotationModel, int user_id);
    }
}