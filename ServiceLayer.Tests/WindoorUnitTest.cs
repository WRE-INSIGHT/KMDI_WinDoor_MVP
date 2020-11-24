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
            expected_wndr.WD_profile = "C70 Profile";

            WindoorModel wndr = new WindoorModel();
            wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Item 1", "Desc", 900, 1200,
                                                               123456, 1, 10.00M, true, true, 10000, "C70 Profile",
                                                               new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());

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
            Assert.AreEqual(expected_wndr.WD_profile, wndr.WD_profile);
        }

        [TestMethod]
        public void CreateWindoor_WindowIDValue0_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(0, "Window1", "Desc", 900, 1200,
                                                                   123456, 1, 10.00M, true, true, 10000, "C70 Profile",
                                                                   new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value bigger than 1");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void CreateWindoor_WindowNameRequired_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "", "Desc", 900, 1200,
                                                                   123456, 1, 10.00M, true, true, 10000, "C70 Profile",
                                                                   new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
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
                                                                   123456, 1, 10.00M, true, true, 10000, "C70 Profile",
                                                               new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "The field WD_name must be a string with a minimum length of 6 and a maximum length of 15.");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void CreateWindoor_WindowWidthValueBelow400_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Window1", "Desc", 399, 1200,
                                                                   123456, 1, 10.00M, true, true, 10000, "C70 Profile",
                                                               new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value for Window Width bigger than or equal to 400");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void CreateWindoor_WindowHeightValueBelow400_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Window1", "Desc", 400, 399,
                                                                   123456, 1, 10.00M, true, true, 10000, "C70 Profile",
                                                               new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value for Window Height bigger than or equal to 400");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void CreateWindoor_WindowZoomValue0_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Window1", "Desc", 400, 400,
                                                                   123456, 1, 10.00M, true, true, 0, "C70 Profile",
                                                               new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a zoom value bigger than or equal to 1");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void CreateWindoor_WindowQtyValue0_ShouldReturnException()
        {
            try
            {
                WindoorModel wndr = new WindoorModel();
                wndr = (WindoorModel)_windoorService.CreateWindoor(1, "Window1", "Desc", 400, 400,
                                                                   123456, 0, 10.00M, true, true, 1, "C70 Profile",
                                                               new System.Collections.Generic.List<ModelLayer.Model.Quotation.Frame.IFrameModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value for Window Quantity bigger than or equal to 1");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
