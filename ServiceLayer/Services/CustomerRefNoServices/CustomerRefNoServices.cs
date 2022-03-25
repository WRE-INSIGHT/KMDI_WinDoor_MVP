using ModelLayer.Model.CustomerRefNo;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CustomerRefNoServices
{
    public class CustomerRefNoServices : ICustomerRefNoServices
    {
        private ICustomerRefNoRepository _custRefNoRepo;
        private IModelDataAnnotationCheck _modelCheck;

        public CustomerRefNoServices(ICustomerRefNoRepository custRefNoRepo, IModelDataAnnotationCheck modelCheck)
        {
            _custRefNoRepo = custRefNoRepo;
            _modelCheck = modelCheck;
        }

        public async Task<DataTable> GetCustRefNo(string searchStr)
        {
            return await _custRefNoRepo.GetCustRefNo(searchStr);
        }

        private ICustomerRefNoModel CreateCustRefNo(int id, string custrefno)
        {
            CustomerRefNoModel custrefnoModel = new CustomerRefNoModel();
            custrefnoModel.CustRefNo_Id = id;
            custrefnoModel.CustomerReferenceNumber = custrefno;

            ValidateModel(custrefnoModel);

            return custrefnoModel;
        }

        public ICustomerRefNoModel AddCustRefNo(int id, string custrefno)
        {
            ICustomerRefNoModel custrefnoModel = CreateCustRefNo(id, custrefno);

            return custrefnoModel;
        }

        private void ValidateModel(ICustomerRefNoModel custrefnoModel)
        {
            _modelCheck.ValidateModelDataAnnotations(custrefnoModel);
        }

        public async Task<int> Insert_CustRefNo(int user_id, ICustomerRefNoModel custRefNo)
        {
            return await _custRefNoRepo.Insert_CustRefNo(user_id, custRefNo);
        }
    }
}
