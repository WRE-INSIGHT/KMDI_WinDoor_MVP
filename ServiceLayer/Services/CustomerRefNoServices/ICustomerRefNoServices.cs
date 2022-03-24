using System.Data;
using System.Threading.Tasks;
using ModelLayer.Model.CustomerRefNo;

namespace ServiceLayer.Services.CustomerRefNoServices
{
    public interface ICustomerRefNoServices
    {
        ICustomerRefNoModel AddCustRefNo(int id, string custrefno);
        Task<DataTable> GetCustRefNo(string searchStr);
        Task<int> Insert_CustRefNo(int user_id, ICustomerRefNoModel custRefNo);
    }
}