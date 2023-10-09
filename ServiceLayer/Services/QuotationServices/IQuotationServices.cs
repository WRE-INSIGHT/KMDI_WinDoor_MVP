using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.QuotationServices
{
    public interface IQuotationServices
    {
        IQuotationModel AddQuotationModel(string quotation_ref_no,
                                          DateTime quote_date,
                                          int quote_id = 0,
                                          List<IWindoorModel> lst_wndr = null);
        void ValidateModel(IQuotationModel quotationModel);
        Task<int> Insert_Quotation(IQuotationModel quotationModel, int user_id);
        Task<decimal> GetFactorByProvince(string province);
    }
}