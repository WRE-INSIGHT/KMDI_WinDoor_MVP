using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.EmployeeServices
{
    public interface IEmployeeRepository
    {
        Task<DataTable> GetCostEngrEmp(string searchStr);
    }
}
