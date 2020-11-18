﻿using System;
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
            expected_wndr.WD_name = "Item 1";
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
            wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Item 1", "Desc", 900, 1200,
                                                               123456, 1, 10.00M, true, true, 10000);

            Assert.AreEqual(expected_wndr.WD_id, wndr.WD_id);
            Assert.AreEqual(expected_wndr.WD_name, wndr.WD_name);
            Assert.AreEqual(expected_wndr.WD_description, wndr.WD_description);
            Assert.AreEqual(expected_wndr.WD_width, wndr.WD_width);
            Assert.AreEqual(expected_wndr.WD_height, wndr.WD_height);
            Assert.AreEqual(expected_wndr.WD_price, wndr.WD_price);
            Assert.AreEqual(expected_wndr.WD_quantity, wndr.WD_quantity);
            Assert.AreEqual(expected_wndr.WD_discount, wndr.WD_discount);
            Assert.AreEqual(expected_wndr.WD_visibility, wndr.WD_visibility);
            Assert.AreEqual(expected_wndr.WD_orientation, wndr.WD_orientation);
            Assert.AreEqual(expected_wndr.WD_zoom, wndr.WD_zoom);
        }

        [TestMethod]
        public void CreateWindoor_WindowNameRequired_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "", "Desc", 900, 1200,
                                                                   123456, 1, 10.00M, true, true, 10000);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Window Name is Required");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void CreateWindoor_WindowNameMinLength_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "W1", "Desc", 900, 1200,
                                                                   123456, 1, 10.00M, true, true, 10000);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "The field WD_name must be a string with a minimum length of 6 and a maximum length of 15.");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
