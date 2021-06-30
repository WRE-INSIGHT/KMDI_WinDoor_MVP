using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.CommonServices;

namespace ServiceLayer.Tests
{
    [TestClass]
    public class QuotationUnitTest
    {
        private QuotationServices _quotationServices;
        [TestInitialize]
        public void SetUp()
        {
            _quotationServices = new QuotationServices(new ModelDataAnnotationCheck());
        }

        //[TestMethod]
        //public void CreateQuotation_QRefNoIsNothing_ShouldReturnException()
        //{
        //    try
        //    {
        //        QuotationModel qrefno = new QuotationModel();
        //        List<IWindoorModel> lst_wndr = new List<IWindoorModel>();
        //        lst_wndr.Add(new WindoorModel());
        //        qrefno = (QuotationModel)_quotationServices.CreateQuotationModel("", lst_wndr);
        //    }
        //    catch (Exception ex)
        //    {
        //        StringAssert.Contains(ex.Message, "Quotation reference number is Required");
        //        return;
        //    }
        //    Assert.Fail("No exception was thrown.");
        //}

    }
}
