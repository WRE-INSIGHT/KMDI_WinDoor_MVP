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
    public class QuotationServices
    {
        private IModelDataAnnotationCheck _modelCheck;
        public QuotationServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        public IQuotationModel CreateQuotationModel(string quotation_ref_no,
                                                    List<IWindoorModel> lst_wndr)
        {
            QuotationModel qModel = new QuotationModel();
            qModel.Quotation_ref_no = quotation_ref_no;
            qModel.Lst_Windoor = lst_wndr;

            ValidateModel(qModel);
            return qModel;
        }

        public void ValidateModel(IQuotationModel quotationModel)
        {
            _modelCheck.ValidateModelDataAnnotations(quotationModel);
        }
    }
}
