using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.CommonServices;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.Services.WindoorServices;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.PanelServices;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using System.Data;
using static ModelLayer.Model.Quotation.QuotationModel;

namespace ModelLayer.Tests
{
    [TestClass]
    public class ExplosionUnitTest
    {
        IQuotationModel _qouteModel;

        IWindoorServices _windoorServices;
        IFrameServices _frameServices;
        IPanelServices _panelServices;
        [TestInitialize]
        public void SetUp()
        {
            IQuotationServices _quotationServices = new QuotationServices(new ModelDataAnnotationCheck());
            _qouteModel = _quotationServices.AddQuotationModel("Sample123");

            _windoorServices = new WindoorServices(new ModelDataAnnotationCheck());
            _frameServices = new FrameServices(new ModelDataAnnotationCheck());
            _panelServices = new PanelServices(new ModelDataAnnotationCheck());
        }

        [TestMethod]
        public void ChkList_SinglePanelFixedWindow()
        {
            int total_wd = 500, total_height = 1500;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd, 
                                                                   total_height, 
                                                                   FrameModel.Frame_Padding.Window, 
                                                                   1.0f,
                                                                   1.0f, 
                                                                   QuotationModel.FrameProfile_ArticleNo._7502, 
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
                                                                   ht,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   null,
                                                                   "6-8mm",
                                                                   GlazingBead_ArticleNo._2452,
                                                                   1);
            _frameModel.Lst_Panel.Add(_panelModel);

            DataTable dt = _qouteModel.GetListOfMaterials();
            Assert.AreEqual("Description", dt.Columns[0].ColumnName);
            Assert.AreEqual("Qty", dt.Columns[1].ColumnName);
            Assert.AreEqual("Unit", dt.Columns[2].ColumnName);
            Assert.AreEqual("Size", dt.Columns[3].ColumnName);

            Assert.AreEqual("Frame Width _7502", dt.Rows[0]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[0]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[0]["Unit"].ToString());
            Assert.AreEqual("1505", dt.Rows[0]["Size"]);

            Assert.AreEqual("Frame Height _7502", dt.Rows[1]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[1]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
            Assert.AreEqual("505", dt.Rows[1]["Size"]);

            Assert.AreEqual("Frame Reinf Width _R676", dt.Rows[2]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[2]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[2]["Unit"].ToString());
            Assert.AreEqual("432", dt.Rows[2]["Size"]);

            Assert.AreEqual("Frame Reinf Height _R676", dt.Rows[3]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[3]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[3]["Unit"].ToString());
            Assert.AreEqual("1432", dt.Rows[3]["Size"]);

            Assert.AreEqual("Glazing Bead Width _2452", dt.Rows[4]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[4]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[4]["Unit"].ToString());
            Assert.AreEqual("434", dt.Rows[4]["Size"]);

            Assert.AreEqual("Glazing Bead Height _2452", dt.Rows[5]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[5]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[5]["Unit"].ToString());
            Assert.AreEqual("1434", dt.Rows[5]["Size"]);

            Assert.AreEqual("Glass Width (6-8mm)", dt.Rows[6]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[6]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
            Assert.AreEqual("428", dt.Rows[6]["Size"]);

            Assert.AreEqual("Glass Height (6-8mm)", dt.Rows[7]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[7]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
            Assert.AreEqual("1428", dt.Rows[7]["Size"]);

            Assert.AreEqual("Glazing Spacer (KBC70)", dt.Rows[8]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[8]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[8]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[8]["Size"]);

            Assert.AreEqual("Sealant-WH", dt.Rows[9]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[9]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[9]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[9]["Size"]);

            Assert.AreEqual("PU Foaming", dt.Rows[10]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[10]["Qty"]);
            Assert.AreEqual("can", dt.Rows[10]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[10]["Size"]);

            Assert.AreEqual("Sealant-WH", dt.Rows[11]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[11]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[11]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[11]["Size"]);

        }

        [TestMethod]
        public void ChkVar_SinglePanelFixedWindow()
        {
            int total_wd = 700, total_height = 2000;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
                                                                   ht,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   null,
                                                                   "10mm",
                                                                   GlazingBead_ArticleNo._2451,
                                                                   1);
            _frameModel.Lst_Panel.Add(_panelModel);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(705, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(2005, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(632, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1932, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(2, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(634, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1934, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(628, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1928, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);
        }

        [TestMethod]
        public void ChkVar_SinglePanelFixedWindow2()
        {
            int total_wd = 500, total_height = 1500;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
                                                                   ht,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   null,
                                                                   "6-8mm",
                                                                   GlazingBead_ArticleNo._2452,
                                                                   1);
            _frameModel.Lst_Panel.Add(_panelModel);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(505, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(432, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1432, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(2, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(434, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1434, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(428, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1428, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);
        }

        //[TestMethod]
        //public void ChkVar_2EQualPanelFW_WithMullion()
        //{
        //    int total_wd = 900, total_height = 1300;

        //    IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1);
        //    _qouteModel.Lst_Windoor.Add(_windoorModel);


        //    IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
        //                                                           total_height,
        //                                                           FrameModel.Frame_Padding.Window,
        //                                                           1.0f,
        //                                                           1.0f,
        //                                                           FrameProfile_ArticleNo._7502,
        //                                                           1);
        //    _windoorModel.lst_frame.Add(_frameModel);

        //    int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
        //        ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

        //}
    }
}
