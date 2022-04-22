using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private IEmployeeRepository _empRepo;
        public EmployeeServices(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task<DataTable> GetCostEngrEmp(string searchStr)
        {
            return await _empRepo.GetCostEngrEmp(searchStr);
        }
    }
}