using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.CommonServices;

namespace ServiceLayer.Services.QuotationServices
{
    public class QuotationServices : IQuotationServices
    {
        private IModelDataAnnotationCheck _modelCheck;
        public QuotationServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        public IQuotationModel CreateQuotationModel(string quotation_ref_no,
                                                    List<IWindoorModel> lst_wndr)
        {
            QuotationModel qModel = new QuotationModel(quotation_ref_no, lst_wndr);

            ValidateModel(qModel);
            return qModel;
        }

        public IQuotationModel AddQuotationModel(string quotation_ref_no,
                                                 List<IWindoorModel> lst_wndr = null)
        {
            if (lst_wndr == null)
            {
                lst_wndr = new List<IWindoorModel>();
            }
            IQuotationModel _quotationModel = CreateQuotationModel(quotation_ref_no, lst_wndr);

            return _quotationModel;
        }

        public void ValidateModel(IQuotationModel quotationModel)
        {
            _modelCheck.ValidateModelDataAnnotations(quotationModel);
        }
    }
}
