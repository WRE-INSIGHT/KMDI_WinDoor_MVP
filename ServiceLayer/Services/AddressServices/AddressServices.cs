using QueryLayer.DataAccess.Repositories.Specific.Address;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceLayer.Services.AddressServices
{
    public class AddressServices : IAddressServices
    {
        private IAddressRepository _addressRepo;
        private IModelDataAnnotationCheck _modelCheck;
        public AddressServices(IAddressRepository addressRepo, IModelDataAnnotationCheck modelCheck)
        {
            _addressRepo = addressRepo;
            _modelCheck = modelCheck;
        }
        public async Task<DataTable> Get_Factor(string searchStr,DateTime cus_ref_date)
        {
            return await _addressRepo.Get_Factor(searchStr,cus_ref_date);
        }

        public async Task UpdateFactor(string Id, decimal factor)
        {
            await _addressRepo.Update_Factor(Id, factor);

        }

    }
}
