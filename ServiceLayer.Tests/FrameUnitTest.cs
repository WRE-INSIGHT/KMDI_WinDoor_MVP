using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.CommonServices;
using System.Collections.Generic;

namespace ServiceLayer.Tests
{
    [TestClass]
    public class FrameUnitTest
    {
        private IFrameServices _frameServices;
        [TestInitialize]
        public void SetUp()
        {
            _frameServices = new FrameServices(new ModelDataAnnotationCheck());
        }

        [TestMethod]
        public void CreateFrame_Test()
        {
            IFrameModel expected_fr = new FrameModel(1, "Frame_1", 400, 400, FrameModel.Frame_Padding.Window, true, 
                                                     new List<ModelLayer.Model.Quotation.Panel.IPanelModel>(), 
                                                     new List<ModelLayer.Model.Quotation.MultiPanel.IMultiPanelModel>(), 
                                                     1.0f,
                                                     new List<ModelLayer.Model.Quotation.Divider.IDividerModel>());
            IFrameModel fr = _frameServices.CreateFrame(1, "Frame_1", 400, 400, FrameModel.Frame_Padding.Window, true, 
                                                        new List<ModelLayer.Model.Quotation.Panel.IPanelModel>(), 
                                                        new List<ModelLayer.Model.Quotation.MultiPanel.IMultiPanelModel>(),
                                                        1.0f,
                                                        new List<ModelLayer.Model.Quotation.Divider.IDividerModel>());

            Assert.AreEqual(expected_fr.Frame_ID, fr.Frame_ID);
            Assert.AreEqual(expected_fr.Frame_Name, fr.Frame_Name);
            Assert.AreEqual(expected_fr.Frame_Width, fr.Frame_Width);
            Assert.AreEqual(expected_fr.Frame_Height, fr.Frame_Height);
            Assert.AreEqual(expected_fr.Frame_Type, fr.Frame_Type);
        }

        [TestMethod]
        public void CreateFrame_FrameIDValue0_ShouldReturnException()
        {
            try
            {
                IFrameModel wndr = _frameServices.CreateFrame(0, "Frame_1", 400, 400, FrameModel.Frame_Padding.Window, true,
                                                              new List<ModelLayer.Model.Quotation.Panel.IPanelModel>(),
                                                              new List<ModelLayer.Model.Quotation.MultiPanel.IMultiPanelModel>(),
                                                              1.0f,
                                                              new List<ModelLayer.Model.Quotation.Divider.IDividerModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value for Frame ID bigger than or equal 1");
                return;
            }
        }

        [TestMethod]
        public void CreateFrame_FrameWidthValueBelow400_ShouldReturnException()
        {
            try
            {
                IFrameModel wndr = _frameServices.CreateFrame(1, "Frame_1", 399, 400, FrameModel.Frame_Padding.Window, true, 
                                                              new List<ModelLayer.Model.Quotation.Panel.IPanelModel>(), 
                                                              new List<ModelLayer.Model.Quotation.MultiPanel.IMultiPanelModel>(),
                                                              1.0f,
                                                              new List<ModelLayer.Model.Quotation.Divider.IDividerModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value for Frame Width bigger than or equal 400");
                return;
            }
        }

        [TestMethod]
        public void CreateFrame_FrameHeightValueBelow400_ShouldReturnException()
        {
            try
            {
                IFrameModel wndr = _frameServices.CreateFrame(1, "Frame_1", 400, 399, FrameModel.Frame_Padding.Window, true,
                                                              new List<ModelLayer.Model.Quotation.Panel.IPanelModel>(),
                                                              new List<ModelLayer.Model.Quotation.MultiPanel.IMultiPanelModel>(),
                                                              1.0f,
                                                              new List<ModelLayer.Model.Quotation.Divider.IDividerModel>());
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Please enter a value for Frame Height bigger than or equal 400");
                return;
            }
        }
    }
}
