using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.CommonServices;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.Services.WindoorServices;

namespace ModelLayer.Tests
{
    [TestClass]
    public class ExplosionUnitTest
    {
        IQuotationModel _qouteModel;

        IWindoorServices _windoorServices;
        [TestInitialize]
        public void SetUp()
        {
            IQuotationServices _quotationServices = new QuotationServices(new ModelDataAnnotationCheck());
            _quotationServices.AddQuotationModel("Sample123");

            _windoorServices = new WindoorServices(new ModelDataAnnotationCheck());
        }

        [TestMethod]
        public void SinglePanelFixedWindow()
        {
            int total_wd = 500, total_height = 1500;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1);
        }
    }
}
