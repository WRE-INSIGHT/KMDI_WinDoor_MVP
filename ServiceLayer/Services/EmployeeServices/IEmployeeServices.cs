using System.Data;
using System.Threading.Tasks;

namespace ServiceLayer.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        Task<DataTable> GetCostEngrEmp(string searchStr);
    }
}