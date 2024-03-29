﻿using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.QuotationServices
{
    public class QuotationServices : IQuotationServices
    {
        private IModelDataAnnotationCheck _modelCheck;
        private IQuotationRepository _quotationRepo;

        public QuotationServices(IModelDataAnnotationCheck modelCheck, IQuotationRepository quotationRepo)
        {
            _modelCheck = modelCheck;
            _quotationRepo = quotationRepo;
        }

        private IQuotationModel CreateQuotationModel(int quote_id,
                                                    string quotation_ref_no,
                                                    DateTime quote_date,
                                                    List<IWindoorModel> lst_wndr)
        {
            QuotationModel qModel = new QuotationModel(quotation_ref_no, lst_wndr);
            qModel.Quotation_Id = quote_id;
            qModel.Quotation_Date = quote_date;

            ValidateModel(qModel);
            return qModel;
        }

        public IQuotationModel AddQuotationModel(string quotation_ref_no,
                                                 DateTime quote_date,
                                                 int quote_id = 0,
                                                 List<IWindoorModel> lst_wndr = null)
        {
            if (lst_wndr == null)
            {
                lst_wndr = new List<IWindoorModel>();
            }

            IQuotationModel _quotationModel = CreateQuotationModel(quote_id, quotation_ref_no, quote_date, lst_wndr);


            return _quotationModel;
        }

        public void ValidateModel(IQuotationModel quotationModel)
        {
            _modelCheck.ValidateModelDataAnnotations(quotationModel);
        }

        public async Task<int> Insert_Quotation(IQuotationModel quotationModel, int user_id)
        {
            return await _quotationRepo.Insert_Quotation(quotationModel, user_id);
        }

        public async Task<decimal> GetFactorByProvince(string province)
        {
            return await _quotationRepo.GetFactorByProvince(province);
        }
    }
}
