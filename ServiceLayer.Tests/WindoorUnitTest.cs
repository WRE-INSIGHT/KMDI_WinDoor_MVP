using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.Services.WindoorServices;
using ServiceLayer.CommonServices;
using System.Reflection;

namespace ServiceLayer.Tests
{
    [TestClass]
    public class WindoorUnitTest
    {
        private WindoorServices _windoorService;
        [TestInitialize]
        public void SetUp()
        {
            _windoorService = new WindoorServices(new ModelDataAnnotationCheck());
        }
        [TestMethod]
        public void CreateWindoor_Test()
        {
            WindoorModel expected_wndr = new WindoorModel();
            expected_wndr.WD_id = 1;
            expected_wndr.WD_name = "W1";
            expected_wndr.WD_description = "Desc";
            expected_wndr.WD_width = 900;
            expected_wndr.WD_height = 1200;
            expected_wndr.WD_price = 123456;
            expected_wndr.WD_quantity = 1;
            expected_wndr.WD_discount = 10.00M;
            expected_wndr.WD_visibility = true;
            expected_wndr.WD_orientation = true;
            expected_wndr.WD_zoom = 10000;

            WindoorModel wndr = new WindoorModel();
            //wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Window 1", "Desc", 900, 1200, 
            //                                                                 123456, 1, 10.00M, true, true, 10000);

            wndr = (WindoorModel)_windoorService.CreateWindoor(expected_wndr.WD_id, 
                expected_wndr.WD_name, 
                expected_wndr.WD_description,
                expected_wndr.WD_width, 
                expected_wndr.WD_height,
                expected_wndr.WD_price, 
                expected_wndr.WD_quantity, 
                expected_wndr.WD_discount, 
                expected_wndr.WD_visibility, expected_wndr.WD_orientation, expected_wndr.WD_zoom);

            Assert.AreEqual<WindoorModel>(expected_wndr, wndr);
        }
    }
}
