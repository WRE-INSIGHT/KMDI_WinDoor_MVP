using ModelLayer.Model.CustomerRefNo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CustomerRefNoServices
{
    public interface ICustomerRefNoRepository
    {
        Task<DataTable> GetCustRefNo(string searchStr);
        Task<int> Insert_CustRefNo(int user_id, ICustomerRefNoModel custRefNo);
    }
}
