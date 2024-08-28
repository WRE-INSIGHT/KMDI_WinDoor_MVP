using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLayer.DataAccess.Repositories.Specific.Address
{
    public interface IAddressRepository
    {
        Task<DataTable> Get_Factor(string searchStr, DateTime cus_ref_date);
        Task Update_Factor(string id, decimal factor);
    }
}
