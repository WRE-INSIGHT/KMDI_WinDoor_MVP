using ModelLayer.Model.Quotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.QuotationServices
{
    public interface IQuotationRepository
    {
        Task<int> Insert_Quotation(IQuotationModel quotationModel, int user_id);
        Task<decimal> GetFactorByProvince(string province);
    }
}
