using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceLayer.Services.AddressServices
{
    public interface IAddressServices
    {
        Task<DataTable> Get_Factor(string searchStr);
        Task UpdateFactor(string Id, decimal factor);
    }
}
