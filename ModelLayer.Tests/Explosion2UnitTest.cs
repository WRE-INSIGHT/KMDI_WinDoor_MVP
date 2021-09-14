﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.DividerServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;
using System.Data;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Tests
{
    [TestClass]
    public class Explosion2UnitTest
    {
        IQuotationModel _qouteModel;
        IWindoorServices _windoorServices;
        IFrameServices _frameServices;
        IPanelServices _panelServices;
        IMultiPanelServices _multiPanelServices;
        IDividerServices _dividerServices;
        [TestInitialize]
        public void SetUp()
        {
            IQuotationServices _quotationServices = new QuotationServices(new ModelDataAnnotationCheck());
            _qouteModel = _quotationServices.AddQuotationModel("Sample123");

            _windoorServices = new WindoorServices(new ModelDataAnnotationCheck());
            _frameServices = new FrameServices(new ModelDataAnnotationCheck());
            _panelServices = new PanelServices(new ModelDataAnnotationCheck());
            _multiPanelServices = new MultiPanelServices(new ModelDataAnnotationCheck());
            _dividerServices = new DividerServices(new ModelDataAnnotationCheck());
        }


        //FIXED WINDOW

        [TestMethod]
        public void ChkVar_SinglePanelFixWindow()
        {
            int total_wd = 1000, total_height = 2000;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
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
                                                                   total_wd,
                                                                   total_height,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);

            _panelModel.Panel_GlassThickness = 6.0f;
            _frameModel.Lst_Panel.Add(_panelModel);

            _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1005, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(2005, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(932, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1932, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(1000, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(2000, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(928, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1928, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

        }




        [TestMethod]
        public void chkvar_SinglePannelFix2()
        {
            int total_wd = 619, total_height = 925;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
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
                                                                   total_wd,
                                                                   total_height,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel.Panel_GlassThickness = 6.0f;
            _frameModel.Lst_Panel.Add(_panelModel);

            _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(624, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(930, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(551, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(857, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(619, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(925, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(547, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(853, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

        }



        // 2 checklist
        //[TestMethod]
        //public void ChkList_SinglePanelFixedWindow()
        //{
        //    int total_wd = 1000, total_height = 2000;

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

        //    IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
        //                                                           ht,
        //                                                           new Control(),
        //                                                           new UserControl(),
        //                                                           new UserControl(),
        //                                                           new UserControl(),
        //                                                           "Fixed Panel",
        //                                                           true,
        //                                                           1.0f,
        //                                                           _frameModel,
        //                                                           null,
        //                                                           total_wd,
        //                                                           total_height,
        //                                                           Glass_Thickness._6mm,
        //                                                           GlazingBead_ArticleNo._2452,
        //                                                           1);
        //    _frameModel.Lst_Panel.Add(_panelModel);

        //    DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);
        //    Assert.AreEqual("Description", dt.Columns[0].ColumnName);
        //    Assert.AreEqual("Qty", dt.Columns[1].ColumnName);
        //    Assert.AreEqual("Unit", dt.Columns[2].ColumnName);
        //    Assert.AreEqual("Size", dt.Columns[3].ColumnName);

        //    Assert.AreEqual("Frame Width 7502", dt.Rows[0]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[0]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[0]["Unit"].ToString());
        //    Assert.AreEqual("1005", dt.Rows[0]["Size"]);

        //    Assert.AreEqual("Frame Height 7502", dt.Rows[1]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[1]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
        //    Assert.AreEqual("2005", dt.Rows[1]["Size"]);

        //    Assert.AreEqual("Frame Reinf Width R676", dt.Rows[2]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[2]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[2]["Unit"].ToString());
        //    Assert.AreEqual("932", dt.Rows[2]["Size"]);

        //    Assert.AreEqual("Frame Reinf Height R676", dt.Rows[3]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[3]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[3]["Unit"].ToString());
        //    Assert.AreEqual("1932", dt.Rows[3]["Size"]);

        //    Assert.AreEqual("Glazing Bead Width 2452", dt.Rows[4]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[4]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[4]["Unit"].ToString());
        //    Assert.AreEqual("934", dt.Rows[4]["Size"]);

        //    Assert.AreEqual("Glazing Bead Height 2452", dt.Rows[5]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[5]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[5]["Unit"].ToString());
        //    Assert.AreEqual("1934", dt.Rows[5]["Size"]);

        //    Assert.AreEqual("Glass Width (6mm)", dt.Rows[6]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[6]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
        //    Assert.AreEqual("928", dt.Rows[6]["Size"]);

        //    Assert.AreEqual("Glass Height (6mm)", dt.Rows[7]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[7]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
        //    Assert.AreEqual("1928", dt.Rows[7]["Size"]);

        //    Assert.AreEqual("PU Foaming", dt.Rows[8]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[8]["Qty"]);
        //    Assert.AreEqual("can", dt.Rows[8]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[8]["Size"]);

        //    Assert.AreEqual("Sealant-WH (Frame)", dt.Rows[9]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[9]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[9]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[9]["Size"]);

        //    Assert.AreEqual("Sealant-WH (Glass)", dt.Rows[10]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[10]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[10]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[10]["Size"]);

        //    Assert.AreEqual("Glazing Spacer (KBC70)", dt.Rows[11]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[11]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[11]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[11]["Size"]);

        //}


        //[TestMethod]
        //public void ChkList_SinglePanelFixedWindow2()
        //{
        //    int total_wd = 619, total_height = 925;

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

        //    IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
        //                                                           ht,
        //                                                           new Control(),
        //                                                           new UserControl(),
        //                                                           new UserControl(),
        //                                                           new UserControl(),
        //                                                           "Fixed Panel",
        //                                                           true,
        //                                                           1.0f,
        //                                                           _frameModel,
        //                                                           null,
        //                                                           total_wd,
        //                                                           total_height,
        //                                                           Glass_Thickness._6mm,
        //                                                           GlazingBead_ArticleNo._2452,
        //                                                           1);
        //    _frameModel.Lst_Panel.Add(_panelModel);

        //    DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);
        //    Assert.AreEqual("Description", dt.Columns[0].ColumnName);
        //    Assert.AreEqual("Qty", dt.Columns[1].ColumnName);
        //    Assert.AreEqual("Unit", dt.Columns[2].ColumnName);
        //    Assert.AreEqual("Size", dt.Columns[3].ColumnName);

        //    Assert.AreEqual("Frame Width 7502", dt.Rows[0]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[0]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[0]["Unit"].ToString());
        //    Assert.AreEqual("624", dt.Rows[0]["Size"]);

        //    Assert.AreEqual("Frame Height 7502", dt.Rows[1]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[1]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
        //    Assert.AreEqual("930", dt.Rows[1]["Size"]);

        //    Assert.AreEqual("Frame Reinf Width R676", dt.Rows[2]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[2]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[2]["Unit"].ToString());
        //    Assert.AreEqual("551", dt.Rows[2]["Size"]);

        //    Assert.AreEqual("Frame Reinf Height R676", dt.Rows[3]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[3]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[3]["Unit"].ToString());
        //    Assert.AreEqual("857", dt.Rows[3]["Size"]);

        //    Assert.AreEqual("Glazing Bead Width 2452", dt.Rows[4]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[4]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[4]["Unit"].ToString());
        //    Assert.AreEqual("553", dt.Rows[4]["Size"]);

        //    Assert.AreEqual("Glazing Bead Height 2452", dt.Rows[5]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[5]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[5]["Unit"].ToString());
        //    Assert.AreEqual("859", dt.Rows[5]["Size"]);

        //    Assert.AreEqual("Glass Width (6mm)", dt.Rows[6]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[6]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
        //    Assert.AreEqual("547", dt.Rows[6]["Size"]);

        //    Assert.AreEqual("Glass Height (6mm)", dt.Rows[7]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[7]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
        //    Assert.AreEqual("853", dt.Rows[7]["Size"]);

        //    Assert.AreEqual("PU Foaming", dt.Rows[8]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[8]["Qty"]);
        //    Assert.AreEqual("can", dt.Rows[8]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[8]["Size"]);

        //    Assert.AreEqual("Sealant-WH (Frame)", dt.Rows[9]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[9]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[9]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[9]["Size"]);

        //    Assert.AreEqual("Sealant-WH (Glass)", dt.Rows[10]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[10]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[10]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[10]["Size"]);

        //    Assert.AreEqual("Glazing Spacer (KBC70)", dt.Rows[11]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[11]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[11]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[11]["Size"]);
        //}



        [TestMethod]
        public void ChkVar_2EQualPanelFW_WithTransom()
        {

            //          |――――――――――――|
            //          |            |
            //          |            |
            //          |――――――――――――|
            //          |            |
            //          |            |
            //          |____________|


            int total_wd = 550, total_height = 1200,
                eqpanelWD = 550, eqpanelHT = 600;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);


            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;


            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IMultiPanelModel _multipanelModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       total_wd,
                                                                                       total_height,
                                                                                       frame,
                                                                                       new UserControl(),
                                                                                       _frameModel,
                                                                                       true,
                                                                                       FlowDirection.TopDown,
                                                                                       _frameModel.Frame_Zoom,
                                                                                       1,
                                                                                       DockStyle.Fill,
                                                                                       1,
                                                                                       0,
                                                                                       null,
                                                                                       _frameModel.FrameImageRenderer_Zoom);
            _frameModel.Lst_MultiPanel.Add(_multipanelModel);

            int divSize = 0;
            int totalPanelCount = _multipanelModel.MPanel_Divisions + 1;

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }
            int suggest_Wd = (((_multipanelModel.MPanel_Width) - (divSize * _multipanelModel.MPanel_Divisions)) / totalPanelCount),
                suggest_HT = _multipanelModel.MPanel_Height;

            IPanelModel _panelModel = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   eqpanelHT,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel.Panel_Placement = "First";
            _panelModel.Panel_GlassThickness = 6.0f;
            _panelModel.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multipanelModel.MPanelLst_Objects.Add(fw1);

            IDividerModel divModel = _dividerServices.AddDividerModel(_multipanelModel.MPanel_Width,
                                                                      divSize,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Transom,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7536,
                                                                      _multipanelModel.MPanel_DisplayWidth,
                                                                      _multipanelModel.MPanel_DisplayHeight,
                                                                      _multipanelModel,
                                                                      _frameModel,
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString(),
                                                                      "TransomUC_1",
                                                                      null,
                                                                      false,
                                                                      true,
                                                                      null
                                                                      );
            _multipanelModel.MPanelLst_Divider.Add(divModel);
            Control div1 = new Control();
            div1.Name = "TransomUC_1";
            _multipanelModel.MPanelLst_Objects.Add(div1);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   eqpanelHT,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _panelModel2.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(550, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel.Div_ReinfArtNo);
            Assert.AreEqual(487, divModel.Div_ExplosionWidth);
            Assert.AreEqual(407, divModel.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(550, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            #region CheckQuantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '555'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1205'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '482'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '487'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '407'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //P1 & P2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '550'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '600'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '478'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '540'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);



            #endregion


        }


        [TestMethod]
        public void ChkVar_2UnEQualPanelFW_WithTransom()
        {

            //          |――――――――――――|
            //          |            |
            //          |            |
            //          |            |
            //          |――――――――――――|
            //          |            |
            //          |____________|


            int total_wd = 550, total_height = 1200,
                 uneqpanelHT1 = 700, uneqpanelHT2 = 500, eqpanelWD = 550;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);


            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IMultiPanelModel _multipanelModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       total_wd,
                                                                                       total_height,
                                                                                       frame,
                                                                                       new UserControl(),
                                                                                       _frameModel,
                                                                                       true,
                                                                                       FlowDirection.TopDown,
                                                                                       _frameModel.Frame_Zoom,
                                                                                       1,
                                                                                       DockStyle.Fill,
                                                                                       1,
                                                                                       0,
                                                                                       null,
                                                                                       _frameModel.FrameImageRenderer_Zoom);
            _frameModel.Lst_MultiPanel.Add(_multipanelModel);

            int divSize = 0;
            int totalPanelCount = _multipanelModel.MPanel_Divisions + 1;

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }
            int suggest_Wd = (((_multipanelModel.MPanel_Width) - (divSize * _multipanelModel.MPanel_Divisions)) / totalPanelCount),
                suggest_HT = _multipanelModel.MPanel_Height;

            IPanelModel _panelModel = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   uneqpanelHT1,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel.Panel_Placement = "First";
            _panelModel.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multipanelModel.MPanelLst_Objects.Add(fw1);

            IDividerModel divModel = _dividerServices.AddDividerModel(divSize,
                                                                      _multipanelModel.MPanel_Width,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Transom,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7536,
                                                                      _multipanelModel.MPanel_DisplayWidth,
                                                                      _multipanelModel.MPanel_DisplayHeight,
                                                                      _multipanelModel,
                                                                      _frameModel,
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString(),
                                                                      "TransomUC_1",
                                                                      null,
                                                                      false,
                                                                      true,
                                                                      null);
            _multipanelModel.MPanelLst_Divider.Add(divModel);
            Control div1 = new Control();
            div1.Name = "TransomUC_1";
            _multipanelModel.MPanelLst_Objects.Add(div1);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   uneqpanelHT2,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);



            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(550, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(700, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(640, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel.Div_ReinfArtNo);
            Assert.AreEqual(487, divModel.Div_ExplosionWidth);
            Assert.AreEqual(407, divModel.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(550, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(500, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(440, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            #region CheckQuantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '555'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1205'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '482'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);




            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '487'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '407'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '550'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '700'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '478'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '640'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '440'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            #endregion
        }



        [TestMethod]
        public void ChkVar_6PanelFixedWindow_With_2Mullion_3Transom()
        {
            //          |――――――――┃―――――――┃―――――――|
            //          |        ┃       ┃       |
            //          |        ┃       ┃       |
            //          |――――――――┃―――――――┃―――――――|
            //          |        ┃       ┃       |
            //          |        ┃       ┃       |
            //          |________┃_______┃_______|

            int total_wd = 1800, total_ht = 1600,
                PanelWD1_BG = 604, PanelHT1_BG = 800,
                PanelWD3_BG = 592, PanelHT3_BG = 800;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;


            int displayWidth = _frameModel.Frame_Width,
              displayHeight = _frameModel.Frame_Height;


            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       displayWidth,
                                                                                       displayHeight,
                                                                                       frame,
                                                                                       new UserControl(),
                                                                                       _frameModel,
                                                                                       true,
                                                                                       FlowDirection.LeftToRight,
                                                                                       _frameModel.Frame_Zoom,
                                                                                       1,
                                                                                       DockStyle.Fill,
                                                                                       1,
                                                                                       0,
                                                                                       null,
                                                                                       _frameModel.FrameImageRenderer_Zoom,
                                                                                       "",
                                                                                       2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;

            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;

            int suggest_Wd = (((_multiMullionModel.MPanel_Width) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount),
                suggest_HT = _multiMullionModel.MPanel_Height;


            int displayWidth2 = _multiMullionModel.MPanel_DisplayWidth / (_multiMullionModel.MPanel_Divisions + 1),
                displayHeight2 = _multiMullionModel.MPanel_DisplayHeight;

            #region multiMullionPlatform
            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                         suggest_HT,
                                                                                         PanelWD1_BG,
                                                                                         displayHeight2,
                                                                                         multiMullion,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.TopDown,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         3,
                                                                                         DockStyle.None,
                                                                                         2,
                                                                                         0,
                                                                                         _multiMullionModel,
                                                                                         _frameModel.FrameImageRenderer_Zoom);
            _multiTransomModel1.MPanel_Placement = "First";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiMullion3 = new Control();

            multiMullion3.Name = "MultiTransom_3";
            _multiMullionModel.MPanelLst_Objects.Add(multiMullion3);



            IDividerModel mullionModel = _dividerServices.AddDividerModel(divSize,
                                                                    _multiMullionModel.MPanel_Height,
                                                                    new Control(),
                                                                    DividerModel.DividerType.Mullion,
                                                                    true,
                                                                    _frameModel.Frame_Zoom,
                                                                    Divider_ArticleNo._7536,
                                                                    _multiMullionModel.MPanel_DisplayWidth,
                                                                    _multiMullionModel.MPanel_DisplayHeight,
                                                                    _multiMullionModel,
                                                                    _frameModel,
                                                                    1,
                                                                    _frameModel.FrameImageRenderer_Zoom,
                                                                    _frameModel.Frame_Type.ToString(),
                                                                    "MullionUC_1",
                                                                    null,
                                                                    false,
                                                                    true,
                                                                    null);
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion);


            IMultiPanelModel _multiTransomModel2 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                        suggest_HT,
                                                                                        PanelWD3_BG,
                                                                                        displayHeight2,
                                                                                        multiMullion,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.TopDown,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        4,
                                                                                        DockStyle.None,
                                                                                        2,
                                                                                        0,
                                                                                        _multiMullionModel,
                                                                                        _frameModel.FrameImageRenderer_Zoom);
            _multiTransomModel2.MPanel_Placement = "Somewhere in Between";
            _multiTransomModel2.MPanel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel2);
            Control multiMullion4 = new Control();
            multiMullion4.Name = "MultiTransom_4";
            _multiMullionModel.MPanelLst_Objects.Add(multiMullion4);


            IDividerModel mullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                  _multiMullionModel.MPanel_Height,
                                                                  new Control(),
                                                                  DividerModel.DividerType.Mullion,
                                                                  true,
                                                                  _frameModel.Frame_Zoom,
                                                                  Divider_ArticleNo._7536,
                                                                  _multiMullionModel.MPanel_DisplayWidth,
                                                                  _multiMullionModel.MPanel_DisplayHeight,
                                                                  _multiMullionModel,
                                                                  _frameModel,
                                                                  2,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString(),
                                                                  "MullionUC_2",
                                                                  null,
                                                                  false,
                                                                  true,
                                                                  null);

            _multiMullionModel.MPanelLst_Divider.Add(mullionModel2);
            Control div_mullion2 = new Control();
            div_mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion2);

            IMultiPanelModel _multiTransomModel3 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                      suggest_HT,
                                                                                      PanelWD1_BG,
                                                                                      displayHeight2,
                                                                                      multiMullion,
                                                                                      new UserControl(),
                                                                                      _frameModel,
                                                                                      true,
                                                                                      FlowDirection.TopDown,
                                                                                      _frameModel.Frame_Zoom,
                                                                                      5,
                                                                                      DockStyle.None,
                                                                                      2,
                                                                                      0,
                                                                                      _multiMullionModel,
                                                                                      _frameModel.FrameImageRenderer_Zoom);
            _multiTransomModel3.MPanel_Placement = "Last";
            _multiTransomModel3.MPanel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel3);
            Control multiTransom5 = new Control();
            multiTransom5.Name = "MultiTransom_5";
            _multiMullionModel.MPanelLst_Objects.Add(multiTransom5);


            #endregion

            #region multiTransomPlatform
            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;

            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                 multiTransom1_suggest_HT,
                                                                 new Control(),
                                                                 new UserControl(),
                                                                 new UserControl(),
                                                                 new UserControl(),
                                                                 "Fixed Panel",
                                                                 true,
                                                                 1.0f,
                                                                 _frameModel,
                                                                 _multiTransomModel1,
                                                                 PanelWD1_BG,
                                                                 PanelHT1_BG,
                                                                 GlazingBead_ArticleNo._2451,
                                                                 GlassFilm_Types._None,
                                                                 SashProfile_ArticleNo._None,
                                                                 SashReinf_ArticleNo._None,
                                                                 GlassType._Single,
                                                                 Espagnolette_ArticleNo._None,
                                                                 Striker_ArticleNo._M89ANTA,
                                                                 MiddleCloser_ArticleNo._None,
                                                                 LockingKit_ArticleNo._None,
                                                                 MotorizedMech_ArticleNo._41555B,
                                                                 Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel1);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multiTransomModel1.MPanelLst_Objects.Add(fw1);



            IDividerModel divModel_Transom = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                  divSize,
                                                                  new Control(),
                                                                  DividerModel.DividerType.Transom,
                                                                  true,
                                                                  _frameModel.Frame_Zoom,
                                                                  Divider_ArticleNo._7536,
                                                                  _multiTransomModel1.MPanel_DisplayWidth,
                                                                  _multiTransomModel1.MPanel_DisplayHeight,
                                                                  _multiTransomModel1,
                                                                  _frameModel,
                                                                  3,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString(),
                                                                  "TransomUC_3",
                                                                  null,
                                                                  false,
                                                                  true,
                                                                  null);

            _multiTransomModel1.MPanelLst_Divider.Add(divModel_Transom);
            Control div3 = new Control();
            div3.Name = "TransomUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(div3);




            IPanelModel _panelModel2 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                  multiTransom1_suggest_HT,
                                                                  new Control(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  "Fixed Panel",
                                                                  true,
                                                                  1.0f,
                                                                  _frameModel,
                                                                  _multiTransomModel1,
                                                                  PanelWD1_BG,
                                                                  PanelHT1_BG,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  GlassFilm_Types._None,
                                                                  SashProfile_ArticleNo._None,
                                                                  SashReinf_ArticleNo._None,
                                                                  GlassType._Single,
                                                                  Espagnolette_ArticleNo._None,
                                                                  Striker_ArticleNo._M89ANTA,
                                                                  MiddleCloser_ArticleNo._None,
                                                                  LockingKit_ArticleNo._None,
                                                                  MotorizedMech_ArticleNo._41555B,
                                                                  Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multiTransomModel1.MPanelLst_Objects.Add(fw2);


            #endregion

            #region multiTransomPlatform2

            int multiMullion2_totalPanelCount = _multiTransomModel2.MPanel_Divisions + 1;

            int multiMullion2_suggest_Wd = (((_multiTransomModel2.MPanel_Width) - (divSize * _multiTransomModel2.MPanel_Divisions)) / multiMullion2_totalPanelCount),
                multiMullion2_suggest_HT = _multiTransomModel2.MPanel_Height;


            IPanelModel _panelModel3 = _panelServices.AddPanelModel(multiMullion2_suggest_Wd,
                                                                   multiMullion2_suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiTransomModel2,
                                                                   PanelWD3_BG,
                                                                   PanelHT3_BG,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   3);
            _panelModel3.Panel_Placement = "First";
            _panelModel3.Panel_GlassThickness = 6.0f;
            _panelModel3.Panel_Index_Inside_MPanel = 1;
            _multiTransomModel2.MPanelLst_Panel.Add(_panelModel3);
            Control fw3 = new Control();
            fw3.Name = "FixedPanelUC_3";
            _multiTransomModel2.MPanelLst_Objects.Add(fw3);


            IDividerModel divModel_Transom2 = _dividerServices.AddDividerModel(_multiTransomModel2.MPanel_Width,
                                                      divSize,
                                                      new Control(),
                                                      DividerModel.DividerType.Transom,
                                                      true,
                                                      _frameModel.Frame_Zoom,
                                                      Divider_ArticleNo._7536,
                                                      _multiTransomModel2.MPanel_DisplayWidth,
                                                      _multiTransomModel2.MPanel_DisplayHeight,
                                                      _multiTransomModel2,
                                                      _frameModel,
                                                      4,
                                                      _frameModel.FrameImageRenderer_Zoom,
                                                      _frameModel.Frame_Type.ToString(),
                                                      "TransomUC_4",
                                                      null,
                                                      false,
                                                      true,
                                                      null);

            _multiTransomModel2.MPanelLst_Divider.Add(divModel_Transom2);
            Control div4 = new Control();
            div4.Name = "TransomUC_4";
            _multiTransomModel2.MPanelLst_Objects.Add(div4);


            IPanelModel _panelModel4 = _panelServices.AddPanelModel(multiMullion2_suggest_Wd,
                                                              multiMullion2_suggest_HT,
                                                              new Control(),
                                                              new UserControl(),
                                                              new UserControl(),
                                                              new UserControl(),
                                                              "Fixed Panel",
                                                              true,
                                                              1.0f,
                                                              _frameModel,
                                                              _multiTransomModel2,
                                                              PanelWD3_BG,
                                                              PanelHT3_BG,
                                                              GlazingBead_ArticleNo._2451,
                                                              GlassFilm_Types._None,
                                                              SashProfile_ArticleNo._None,
                                                              SashReinf_ArticleNo._None,
                                                              GlassType._Single,
                                                              Espagnolette_ArticleNo._None,
                                                              Striker_ArticleNo._M89ANTA,
                                                              MiddleCloser_ArticleNo._None,
                                                              LockingKit_ArticleNo._None,
                                                              MotorizedMech_ArticleNo._41555B,
                                                              Handle_Type._Rotary,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              false,
                                                              false,
                                                              false,
                                                              false,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              Rotoswing_HandleArtNo._RSC773451,
                                                              GeorgianBar_ArticleNo._None,
                                                              0,
                                                              0,
                                                              false,
                                                              4);
            _panelModel4.Panel_Placement = "Last";
            _panelModel4.Panel_GlassThickness = 6.0f;
            _panelModel4.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel2.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiTransomModel2.MPanelLst_Objects.Add(fw4);

            #endregion

            #region multiTransomPlatform3


            int multiMullion3_totalPanelCount = _multiTransomModel3.MPanel_Divisions + 1;

            int multiMullion3_suggest_Wd = (((_multiTransomModel3.MPanel_Width) - (divSize * _multiTransomModel3.MPanel_Divisions)) / multiMullion3_totalPanelCount),
                multiMullion3_suggest_HT = _multiTransomModel3.MPanel_Height;

            IPanelModel _panelModel5 = _panelServices.AddPanelModel(multiMullion3_suggest_Wd,
                                                             multiMullion3_suggest_HT,
                                                             new Control(),
                                                             new UserControl(),
                                                             new UserControl(),
                                                             new UserControl(),
                                                             "Fixed Panel",
                                                             true,
                                                             1.0f,
                                                             _frameModel,
                                                             _multiTransomModel3,
                                                             PanelWD1_BG,
                                                             PanelHT1_BG,
                                                             GlazingBead_ArticleNo._2451,
                                                             GlassFilm_Types._None,
                                                             SashProfile_ArticleNo._None,
                                                             SashReinf_ArticleNo._None,
                                                             GlassType._Single,
                                                             Espagnolette_ArticleNo._None,
                                                             Striker_ArticleNo._M89ANTA,
                                                             MiddleCloser_ArticleNo._None,
                                                             LockingKit_ArticleNo._None,
                                                             MotorizedMech_ArticleNo._41555B,
                                                              Handle_Type._Rotary,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              Extension_ArticleNo._None,
                                                              false,
                                                              false,
                                                              false,
                                                              false,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              0,
                                                              Rotoswing_HandleArtNo._RSC773451,
                                                              GeorgianBar_ArticleNo._None,
                                                              0,
                                                              0,
                                                              false,
                                                              5);
            _panelModel5.Panel_Placement = "First";
            _panelModel5.Panel_GlassThickness = 6.0f;
            _panelModel5.Panel_Index_Inside_MPanel = 1;
            _multiTransomModel3.MPanelLst_Panel.Add(_panelModel5);
            Control fw5 = new Control();
            fw5.Name = "FixedPanelUC_5";
            _multiTransomModel3.MPanelLst_Objects.Add(fw5);



            IDividerModel divModel_Transom3 = _dividerServices.AddDividerModel(_multiTransomModel3.MPanel_Width,
                                                     divSize,
                                                     new Control(),
                                                     DividerModel.DividerType.Transom,
                                                     true,
                                                     _frameModel.Frame_Zoom,
                                                     Divider_ArticleNo._7536,
                                                     _multiTransomModel3.MPanel_DisplayWidth,
                                                     _multiTransomModel3.MPanel_DisplayHeight,
                                                     _multiTransomModel3,
                                                     _frameModel,
                                                     5,
                                                     _frameModel.FrameImageRenderer_Zoom,
                                                     _frameModel.Frame_Type.ToString(),
                                                     "TransomUC_5",
                                                     null,
                                                     false,
                                                     true,
                                                     null);

            _multiTransomModel3.MPanelLst_Divider.Add(divModel_Transom3);
            Control div5 = new Control();
            div5.Name = "TransomUC_5";
            _multiTransomModel3.MPanelLst_Objects.Add(div5);



            IPanelModel _panelModel6 = _panelServices.AddPanelModel(multiMullion3_suggest_Wd,
                                                                  multiMullion3_suggest_HT,
                                                                  new Control(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  "Fixed Panel",
                                                                  true,
                                                                  1.0f,
                                                                  _frameModel,
                                                                  _multiTransomModel3,
                                                                  PanelWD1_BG,
                                                                  PanelHT1_BG,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  GlassFilm_Types._None,
                                                                  SashProfile_ArticleNo._None,
                                                                  SashReinf_ArticleNo._None,
                                                                  GlassType._Single,
                                                                  Espagnolette_ArticleNo._None,
                                                                  Striker_ArticleNo._M89ANTA,
                                                                  MiddleCloser_ArticleNo._None,
                                                                  LockingKit_ArticleNo._None,
                                                                  MotorizedMech_ArticleNo._41555B,
                                                                  Handle_Type._Rotary,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  Rotoswing_HandleArtNo._RSC773451,
                                                                  GeorgianBar_ArticleNo._None,
                                                                  0,
                                                                  0,
                                                                  false,
                                                                  6);
            _panelModel6.Panel_Placement = "Last";
            _panelModel6.Panel_GlassThickness = 6.0f;
            _panelModel6.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel3.MPanelLst_Panel.Add(_panelModel6);
            Control fw6 = new Control();
            fw6.Name = "FixedPanelUC_6";
            _multiTransomModel3.MPanelLst_Objects.Add(fw6);




            #endregion

            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel2);
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel3);


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            #region Frame

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1805, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1732, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1532, _frameModel.Frame_ReinfHeight);


            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(6, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);

            #endregion

            #region MultiMullion(2)

            //TransomUC3

            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1537, mullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1457, mullionModel.Div_ReinfHeight);

            //TransomUC4

            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1537, mullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1457, mullionModel2.Div_ReinfHeight);

            //TransomUC5
            #endregion

            #region MultiTransom1

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(604, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(800, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(544, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom.Div_ReinfArtNo);
            Assert.AreEqual(553, divModel_Transom.Div_ExplosionWidth);
            Assert.AreEqual(473, divModel_Transom.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(604, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(800, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(544, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            #endregion

            #region MultiTransom2

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(592, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(800, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(544, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom2.Div_ReinfArtNo);
            Assert.AreEqual(553, divModel_Transom2.Div_ExplosionWidth);
            Assert.AreEqual(473, divModel_Transom2.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(592, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(800, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(544, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);

            #endregion

            #region MultiTransom3

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel5.PanelGlazingBead_ArtNo);
            Assert.AreEqual(604, _panelModel5.Panel_GlazingBeadWidth);
            Assert.AreEqual(800, _panelModel5.Panel_GlazingBeadHeight);
            Assert.AreEqual(544, _panelModel5.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel5.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel5.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom3.Div_ReinfArtNo);
            Assert.AreEqual(553, divModel_Transom3.Div_ExplosionWidth);
            Assert.AreEqual(473, divModel_Transom3.Div_ReinfWidth);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel6.PanelGlazingBead_ArtNo);
            Assert.AreEqual(604, _panelModel6.Panel_GlazingBeadWidth);
            Assert.AreEqual(800, _panelModel6.Panel_GlazingBeadHeight);
            Assert.AreEqual(544, _panelModel6.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel6.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel6.Panel_GlazingSpacerQty);

            #endregion

            #region CheckQuantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1805'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1532'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            //mullionUC1 & 2
            dr = dt.Select("Description = 'Mullion Height 7536' AND Size = '1537'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R677' AND Size = '1457'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            //TransomUC3


            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '553'");
            Assert.AreEqual(2, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);



            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '473'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '604'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("8", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '592'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("12", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '544'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '740'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);


            #endregion

        }



        [TestMethod]
        public void ChkVar_4PanelFixedWindow_With_2Mullion_1Transom()
        {

            //          |――――――――┃―――――――┃―――――――|
            //          |        ┃       ┃       |
            //          |        ┃       ┃       |
            //          |        ┃―――――――┃       |
            //          |        ┃       ┃       |
            //          |        ┃       ┃       |
            //          |________┃_______┃_______|

            int total_wd = 2100, total_ht = 1700,
               PanelWD1_BG = 704, PanelHT1_BG = 1700,
                PanelWD3_BG = 692, PanelHT3_BG = 850;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;


            int displayWidth = _frameModel.Frame_Width,
              displayHeight = _frameModel.Frame_Height;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;



            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                        ht,
                                                                                        displayWidth,
                                                                                        displayHeight,
                                                                                        frame,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.LeftToRight,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        1,
                                                                                        DockStyle.Fill,
                                                                                        1,
                                                                                        0,
                                                                                        null,
                                                                                        _frameModel.FrameImageRenderer_Zoom,
                                                                                        "",
                                                                                        2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;

            int divSize = 26;
            int multiTransom_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;

            int displayWidth2 = _multiMullionModel.MPanel_DisplayWidth / (_multiMullionModel.MPanel_Divisions + 1),
                displayHeight2 = _multiMullionModel.MPanel_DisplayHeight;

            int suggest_Wd = (((_multiMullionModel.MPanel_Width) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount),
                suggest_HT = _multiMullionModel.MPanel_Height;

            #region multiMullionPlatform

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                     suggest_HT,
                                                                     new Control(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     "Fixed Panel",
                                                                     true,
                                                                     1.0f,
                                                                     _frameModel,
                                                                     _multiMullionModel,
                                                                     PanelWD1_BG,
                                                                     PanelHT1_BG,
                                                                     GlazingBead_ArticleNo._2451,
                                                                     GlassFilm_Types._None,
                                                                     SashProfile_ArticleNo._None,
                                                                     SashReinf_ArticleNo._None,
                                                                     GlassType._Single,
                                                                     Espagnolette_ArticleNo._None,
                                                                     Striker_ArticleNo._M89ANTA,
                                                                     MiddleCloser_ArticleNo._None,
                                                                     LockingKit_ArticleNo._None,
                                                                     MotorizedMech_ArticleNo._41555B,
                                                                     Handle_Type._Rotary,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     Rotoswing_HandleArtNo._RSC773451,
                                                                     GeorgianBar_ArticleNo._None,
                                                                     0,
                                                                     0,
                                                                     false,
                                                                     1);
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(fw1);


            IDividerModel mullionModel = _dividerServices.AddDividerModel(divSize,
                                                                          _multiMullionModel.MPanel_Height,
                                                                          new Control(),
                                                                          DividerModel.DividerType.Mullion,
                                                                          true,
                                                                          _frameModel.Frame_Zoom,
                                                                          Divider_ArticleNo._7536,
                                                                          _multiMullionModel.MPanel_DisplayWidth,
                                                                          _multiMullionModel.MPanel_DisplayHeight,
                                                                          _multiMullionModel,
                                                                          _frameModel,
                                                                          1,
                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                          _frameModel.Frame_Type.ToString(),
                                                                          "MullionUC_1",
                                                                          null,
                                                                          false,
                                                                          true,
                                                                          null);

            _multiMullionModel.MPanelLst_Divider.Add(mullionModel);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion);



            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                        suggest_HT,
                                                                                        PanelWD3_BG,
                                                                                        PanelHT1_BG,
                                                                                        multiMullion,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.TopDown,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        1,
                                                                                        DockStyle.None,
                                                                                        2,
                                                                                        0,
                                                                                        _multiMullionModel,
                                                                                        _frameModel.FrameImageRenderer_Zoom
                                                                                        );
            _multiTransomModel1.MPanel_Placement = "Somewhere in Between";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiMullion3 = new Control();

            multiMullion3.Name = "MultiTransom_1";
            _multiMullionModel.MPanelLst_Objects.Add(multiMullion3);

            IDividerModel mullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                           _multiMullionModel.MPanel_Height,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Mullion,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7536,
                                                                           _multiMullionModel.MPanel_DisplayWidth,
                                                                           _multiMullionModel.MPanel_DisplayHeight,
                                                                           _multiMullionModel,
                                                                           _frameModel,
                                                                           2,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "MullionUC_2",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel2);
            Control div_mullion2 = new Control();
            div_mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion2);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                     suggest_HT,
                                                                     new Control(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     "Fixed Panel",
                                                                     true,
                                                                     1.0f,
                                                                     _frameModel,
                                                                     _multiMullionModel,
                                                                     PanelWD1_BG,
                                                                     PanelHT1_BG,
                                                                     GlazingBead_ArticleNo._2451,
                                                                     GlassFilm_Types._None,
                                                                     SashProfile_ArticleNo._None,
                                                                     SashReinf_ArticleNo._None,
                                                                     GlassType._Single,
                                                                     Espagnolette_ArticleNo._None,
                                                                     Striker_ArticleNo._M89ANTA,
                                                                     MiddleCloser_ArticleNo._None,
                                                                     LockingKit_ArticleNo._None,
                                                                     MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotary,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC773451,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _panelModel2.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(fw2);


            #endregion

            #region multiTransomplatform

            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;

            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;

            IPanelModel _panelModel3 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                   multiTransom1_suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiTransomModel1,
                                                                   PanelWD3_BG,
                                                                   PanelHT3_BG,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._None,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotary,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   3);
            _panelModel3.Panel_Placement = "First";
            _panelModel3.Panel_GlassThickness = 6.0f;
            _panelModel3.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel3);
            Control fw3 = new Control();
            fw3.Name = "FixedPanelUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(fw3);




            IDividerModel divModel_Transom = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                              divSize,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel1.MPanel_DisplayWidth,
                                                                              _multiTransomModel1.MPanel_DisplayHeight,
                                                                              _multiTransomModel1,
                                                                              _frameModel,
                                                                              3,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "TransomUC_3",
                                                                               null,
                                                                               false,
                                                                               true,
                                                                               null);

            _multiTransomModel1.MPanelLst_Divider.Add(divModel_Transom);
            Control div1 = new Control();
            div1.Name = "TransomUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(div1);


            IPanelModel _panelModel4 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                    multiTransom1_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    _frameModel,
                                                                    _multiTransomModel1,
                                                                    PanelWD3_BG,
                                                                    PanelHT3_BG,
                                                                    GlazingBead_ArticleNo._2451,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                    GlassType._Single,
                                                                    Espagnolette_ArticleNo._None,
                                                                    Striker_ArticleNo._M89ANTA,
                                                                    MiddleCloser_ArticleNo._None,
                                                                    LockingKit_ArticleNo._None,
                                                                    MotorizedMech_ArticleNo._41555B,
                                                                    Handle_Type._Rotary,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    Rotoswing_HandleArtNo._RSC773451,
                                                                    GeorgianBar_ArticleNo._None,
                                                                    0,
                                                                    0,
                                                                    false,
                                                                    4);
            _panelModel4.Panel_Placement = "Last";
            _panelModel4.Panel_GlassThickness = 6.0f;
            _panelModel4.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiTransomModel1.MPanelLst_Objects.Add(fw4);


            #endregion


            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            //Assert

            #region Frame

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2105, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1705, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2032, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1632, _frameModel.Frame_ReinfHeight);



            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(4, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            #endregion

            #region MultiMullion(2) as base

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(704, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1700, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1628, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1637, mullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1557, mullionModel.Div_ReinfHeight);

            //TransomUC3

            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1637, mullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1557, mullionModel2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(704, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1700, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1628, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            #endregion

            #region MultiTransom

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(692, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(850, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(790, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom.Div_ReinfArtNo);
            Assert.AreEqual(653, divModel_Transom.Div_ExplosionWidth);
            Assert.AreEqual(573, divModel_Transom.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(692, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(850, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(790, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);

            #endregion

            #region CheckQuantity



            DataRow[] dr;


            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '2105'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1705'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2032'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            //mullionUC1 & 2
            dr = dt.Select("Description = 'Mullion Height 7536' AND Size = '1637'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R677' AND Size = '1557'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            //TransomUC3
            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '653'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '573'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            //P1 & P2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '704'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1700'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '644'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '1628'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //P3 & P4

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '692'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '850'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '790'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            #endregion

        }



        [TestMethod]
        public void ChkVar_6PanelFixedWindow_With_4Mullion_1Transom()
        {
            //              
            //          |――――――――┃―――┃―――┃―――――――|
            //          |        ┃   ┃   ┃       |
            //          |        ┃   ┃   ┃       |
            //          |        ┃―――――――┃       |
            //          |        ┃   ┃   ┃       |
            //          |        ┃   ┃   ┃       |
            //          |________┃___┃___┃_______|
            //

            int total_wd = 2400, total_ht = 1950,

                 PanelWD1_BG = 799, PanelHT1_BG = 1950,
                 PanelWD3PlusWD4 = 802,
                PanelWD3_BG = 401, PanelHT3_BG = 975;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                        ht,
                                                                                        total_wd,
                                                                                        total_ht,
                                                                                        frame,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.LeftToRight,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        1,
                                                                                        DockStyle.Fill,
                                                                                        1,
                                                                                        0,
                                                                                        null,
                                                                                        _frameModel.FrameImageRenderer_Zoom,
                                                                                        "",
                                                                                        2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount);

            #region multiMullionPlatform (2) as base 

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                     suggest_HT,
                                                                     new Control(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     "Fixed Panel",
                                                                     true,
                                                                     1.0f,
                                                                     _frameModel,
                                                                     _multiMullionModel,
                                                                     PanelWD1_BG,
                                                                     PanelHT1_BG,
                                                                     GlazingBead_ArticleNo._2453,
                                                                     GlassFilm_Types._None,
                                                                     SashProfile_ArticleNo._None,
                                                                     SashReinf_ArticleNo._None,
                                                                     GlassType._Single,
                                                                     Espagnolette_ArticleNo._None,
                                                                     Striker_ArticleNo._M89ANTA,
                                                                     MiddleCloser_ArticleNo._None,
                                                                     LockingKit_ArticleNo._None,
                                                                     MotorizedMech_ArticleNo._41555B,
                                                                     Handle_Type._Rotary,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     Rotoswing_HandleArtNo._RSC773451,
                                                                     GeorgianBar_ArticleNo._None,
                                                                     0,
                                                                     0,
                                                                     false,
                                                                     1);
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 14.0f;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(fw1);


            IDividerModel mullionModel = _dividerServices.AddDividerModel(divSize,
                                                                          _multiMullionModel.MPanel_Height,
                                                                          new Control(),
                                                                          DividerModel.DividerType.Mullion,
                                                                          true,
                                                                          _frameModel.Frame_Zoom,
                                                                          Divider_ArticleNo._7538,
                                                                          _multiMullionModel.MPanel_DisplayWidth,
                                                                          _multiMullionModel.MPanel_DisplayHeight,
                                                                          _multiMullionModel,
                                                                          _frameModel,
                                                                          1,
                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                          _frameModel.Frame_Type.ToString(),
                                                                          "MullionUC_1",
                                                                          null,
                                                                          false,
                                                                          true,
                                                                          null);
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion);



            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                        suggest_HT,
                                                                                        PanelWD3PlusWD4,
                                                                                        PanelHT1_BG,
                                                                                        multiMullion,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.TopDown,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        3,
                                                                                        DockStyle.None,
                                                                                        2,
                                                                                        0,
                                                                                        _multiMullionModel,
                                                                                        _frameModel.FrameImageRenderer_Zoom
                                                                                        );
            _multiTransomModel1.MPanel_Placement = "Somewhere in Between";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 2;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiMullion3 = new Control();
            multiMullion3.Name = "MultiTransom_3";
            _multiMullionModel.MPanelLst_Objects.Add(multiMullion3);


            IDividerModel mullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                           _multiMullionModel.MPanel_Height,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Mullion,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7538,
                                                                           _multiMullionModel.MPanel_DisplayWidth,
                                                                           _multiMullionModel.MPanel_DisplayHeight,
                                                                           _multiMullionModel,
                                                                           _frameModel,
                                                                           2,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "MullionUC_2",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel2);
            Control div_mullion2 = new Control();
            div_mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion2);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                     suggest_HT,
                                                                     new Control(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     "Fixed Panel",
                                                                     true,
                                                                     1.0f,
                                                                     _frameModel,
                                                                     _multiMullionModel,
                                                                     PanelWD1_BG,
                                                                     PanelHT1_BG,
                                                                     GlazingBead_ArticleNo._2453,
                                                                     GlassFilm_Types._None,
                                                                     SashProfile_ArticleNo._None,
                                                                     SashReinf_ArticleNo._None,
                                                                     GlassType._Single,
                                                                     Espagnolette_ArticleNo._None,
                                                                     Striker_ArticleNo._M89ANTA,
                                                                     MiddleCloser_ArticleNo._None,
                                                                     LockingKit_ArticleNo._None,
                                                                     MotorizedMech_ArticleNo._41555B,
                                                                     Handle_Type._Rotary,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     Rotoswing_HandleArtNo._RSC773451,
                                                                     GeorgianBar_ArticleNo._None,
                                                                     0,
                                                                     0,
                                                                     false,
                                                                     2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 14.0f;
            _panelModel2.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(fw2);


            #endregion

            #region multiTransomplatform(1) as Base

            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;
            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;


            IMultiPanelModel _multiMullionModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                        suggest_HT,
                                                                                        PanelWD3_BG,
                                                                                        PanelHT3_BG,
                                                                                        multiMullion,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.LeftToRight,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        4,

                                                                                        DockStyle.None,
                                                                                        1,
                                                                                        0,
                                                                                        _multiTransomModel1,
                                                                                        _frameModel.FrameImageRenderer_Zoom
                                                                                        );
            _multiMullionModel1.MPanel_Placement = "First";
            _multiMullionModel1.MPanel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_MultiPanel.Add(_multiMullionModel1);
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            Control multiMullion4 = new Control();
            multiMullion4.Name = "MultiMullion_4";
            _multiTransomModel1.MPanelLst_Objects.Add(multiMullion4);



            IDividerModel transomModel = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                          divSize,
                                                                          new Control(),
                                                                          DividerModel.DividerType.Transom,
                                                                          true,
                                                                          _frameModel.Frame_Zoom,
                                                                          Divider_ArticleNo._7538,
                                                                          _multiTransomModel1.MPanel_DisplayWidth,
                                                                          _multiTransomModel1.MPanel_DisplayHeight,
                                                                          _multiTransomModel1,
                                                                          _frameModel,
                                                                          3,
                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                          _frameModel.Frame_Type.ToString(),
                                                                          "TransomUC_3",
                                                                          null,
                                                                          false,
                                                                          true,
                                                                          null);
            _multiTransomModel1.MPanelLst_Divider.Add(transomModel);
            Control div_Transom3 = new Control();
            div_Transom3.Name = "TransomUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(div_Transom3);




            IMultiPanelModel _multiMullionModel2 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          PanelWD3_BG,
                                                                                          PanelHT3_BG,
                                                                                          multiMullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          5,
                                                                                          DockStyle.None,
                                                                                          1,
                                                                                          0,
                                                                                          _multiTransomModel1,
                                                                                          _frameModel.FrameImageRenderer_Zoom
                                                                                          );
            _multiMullionModel2.MPanel_Placement = "Last";
            _multiMullionModel2.MPanel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_MultiPanel.Add(_multiMullionModel2);
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel2);

            Control multiMullion5 = new Control();
            multiMullion5.Name = "MultiMullion_5";
            _multiTransomModel1.MPanelLst_Objects.Add(multiMullion5);



            #endregion

            #region multiMullionPlatform1

            int multiMullion1_totalPanelCount = _multiMullionModel1.MPanel_Divisions + 1;

            int multiMullion1_suggest_Wd = _multiMullionModel1.MPanel_Width,
                multiMullion1_suggest_HT = (((_multiMullionModel1.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount);




            IPanelModel _panelModel3 = _panelServices.AddPanelModel(multiMullion1_suggest_Wd,
                                                                  multiMullion1_suggest_HT,
                                                                  new Control(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  "Fixed Panel",
                                                                  true,
                                                                  1.0f,
                                                                  _frameModel,
                                                                  _multiMullionModel1,
                                                                  PanelWD3_BG,
                                                                  PanelHT3_BG,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  GlassFilm_Types._None,
                                                                  SashProfile_ArticleNo._None,
                                                                  SashReinf_ArticleNo._None,
                                                                  GlassType._Single,
                                                                  Espagnolette_ArticleNo._None,
                                                                  Striker_ArticleNo._M89ANTA,
                                                                  MiddleCloser_ArticleNo._None,
                                                                  LockingKit_ArticleNo._None,
                                                                  MotorizedMech_ArticleNo._41555B,
                                                                  Handle_Type._Rotary,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  Rotoswing_HandleArtNo._RSC773451,
                                                                  GeorgianBar_ArticleNo._None,
                                                                  0,
                                                                  0,
                                                                  false,
                                                                  3);
            _panelModel3.Panel_Placement = "First";
            _panelModel3.Panel_GlassThickness = 6.0f;
            _panelModel3.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel3);
            Control fw3 = new Control();
            fw3.Name = "FixedPanelUC_3";
            _multiMullionModel1.MPanelLst_Objects.Add(fw3);




            IDividerModel mullionModel3 = _dividerServices.AddDividerModel(divSize,
                                                                           _multiMullionModel1.MPanel_Height,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Mullion,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7538,
                                                                           _multiMullionModel1.MPanel_DisplayWidth,
                                                                           _multiMullionModel1.MPanel_DisplayHeight,
                                                                           _multiMullionModel1,
                                                                           _frameModel,
                                                                           4,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "MullionUC_4",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiMullionModel1.MPanelLst_Divider.Add(mullionModel3);
            Control div_mullion4 = new Control();
            div_mullion4.Name = "MullionUC_4";
            _multiMullionModel1.MPanelLst_Objects.Add(div_mullion4);



            IPanelModel _panelModel4 = _panelServices.AddPanelModel(multiMullion1_suggest_Wd,
                                                                  multiMullion1_suggest_HT,
                                                                  new Control(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  "Fixed Panel",
                                                                  true,
                                                                  1.0f,
                                                                  _frameModel,
                                                                  _multiMullionModel1,
                                                                  PanelWD3_BG,
                                                                  PanelHT3_BG,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  GlassFilm_Types._None,
                                                                  SashProfile_ArticleNo._None,
                                                                  SashReinf_ArticleNo._None,
                                                                  GlassType._Single,
                                                                  Espagnolette_ArticleNo._None,
                                                                  Striker_ArticleNo._M89ANTA,
                                                                  MiddleCloser_ArticleNo._None,
                                                                  LockingKit_ArticleNo._None,
                                                                  MotorizedMech_ArticleNo._41555B,
                                                                  Handle_Type._Rotary,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  Rotoswing_HandleArtNo._RSC773451,
                                                                  GeorgianBar_ArticleNo._None,
                                                                  0,
                                                                  0,
                                                                  false,
                                                                  4);
            _panelModel4.Panel_Placement = "Last";
            _panelModel4.Panel_GlassThickness = 6.0f;
            _panelModel4.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiMullionModel1.MPanelLst_Objects.Add(fw4);



            #endregion

            #region multiMullionPlatform2

            int multiMullion2_totalPanelCount = _multiMullionModel2.MPanel_Divisions + 1;

            int multiMullion2_suggest_Wd = (((_multiMullionModel2.MPanel_Width) - (divSize * _multiMullionModel2.MPanel_Divisions)) / multiMullion2_totalPanelCount),
                multiMullion2_suggest_HT = _multiMullionModel2.MPanel_Height;



            IPanelModel _panelModel5 = _panelServices.AddPanelModel(multiMullion2_suggest_Wd,
                                                                      multiMullion2_suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Fixed Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel2,
                                                                      PanelWD3_BG,
                                                                      PanelHT3_BG,
                                                                      GlazingBead_ArticleNo._2451,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._None,
                                                                      SashReinf_ArticleNo._None,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._None,
                                                                      Striker_ArticleNo._M89ANTA,
                                                                      MiddleCloser_ArticleNo._None,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotary,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC773451,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      5);
            _panelModel5.Panel_Placement = "First";
            _panelModel5.Panel_GlassThickness = 6.0f;
            _panelModel5.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel2.MPanelLst_Panel.Add(_panelModel5);
            Control fw5 = new Control();
            fw5.Name = "FixedPanelUC_5";
            _multiMullionModel2.MPanelLst_Objects.Add(fw5);




            IDividerModel mullionModel4 = _dividerServices.AddDividerModel(divSize,
                                                                           _multiMullionModel2.MPanel_Height,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Mullion,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7538,
                                                                           _multiMullionModel2.MPanel_DisplayWidth,
                                                                           _multiMullionModel2.MPanel_DisplayHeight,
                                                                           _multiMullionModel2,
                                                                           _frameModel,
                                                                           5,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "MullionUC_5",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiMullionModel2.MPanelLst_Divider.Add(mullionModel4);
            Control div_mullion5 = new Control();
            div_mullion5.Name = "MullionUC_5";
            _multiMullionModel2.MPanelLst_Objects.Add(div_mullion5);



            IPanelModel _panelModel6 = _panelServices.AddPanelModel(multiMullion2_suggest_Wd,
                                                                  multiMullion2_suggest_HT,
                                                                  new Control(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  "Fixed Panel",
                                                                  true,
                                                                  1.0f,
                                                                  _frameModel,
                                                                  _multiMullionModel2,
                                                                  PanelWD3_BG,
                                                                  PanelHT3_BG,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  GlassFilm_Types._None,
                                                                  SashProfile_ArticleNo._None,
                                                                  SashReinf_ArticleNo._None,
                                                                  GlassType._Single,
                                                                  Espagnolette_ArticleNo._None,
                                                                  Striker_ArticleNo._M89ANTA,
                                                                  MiddleCloser_ArticleNo._None,
                                                                  LockingKit_ArticleNo._None,
                                                                  MotorizedMech_ArticleNo._41555B,
                                                                  Handle_Type._Rotary,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  Rotoswing_HandleArtNo._RSC773451,
                                                                  GeorgianBar_ArticleNo._None,
                                                                  0,
                                                                  0,
                                                                  false,
                                                                  6);
            _panelModel6.Panel_Placement = "Last";
            _panelModel6.Panel_GlassThickness = 6.0f;
            _panelModel6.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel2.MPanelLst_Panel.Add(_panelModel6);
            Control fw6 = new Control();
            fw6.Name = "FixedPanelUC_6";
            _multiMullionModel2.MPanelLst_Objects.Add(fw6);



            #endregion

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);


            //Assert
            #region Frame

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2405, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1955, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2332, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1882, _frameModel.Frame_ReinfHeight);


            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(6, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(10996, _qouteModel.GlazingSeal_TotalQty);

            #endregion

            #region MultiMullion (2) as base


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(799, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1950, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(724, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1878, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, mullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1892, mullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1782, mullionModel.Div_ReinfHeight);

            //MultiTransom

            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, mullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1892, mullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1782, mullionModel2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(799, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1950, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(724, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1878, _panelModel2.Panel_GlassHeight);


            #endregion

            #region MultriTransom(1)

            //MultiMullion1

            Assert.AreEqual(Divider_ArticleNo._7538, transomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, transomModel.Div_ReinfArtNo);
            Assert.AreEqual(738, transomModel.Div_ExplosionWidth);
            Assert.AreEqual(628, transomModel.Div_ReinfWidth);

            //MultiMullion2

            #endregion

            #region MultiMullion1

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(401, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(975, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(323, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, mullionModel3.Div_ReinfArtNo);
            Assert.AreEqual(914, mullionModel3.Div_ExplosionHeight);
            Assert.AreEqual(804, mullionModel3.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(401, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(975, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(323, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);

            #endregion

            #region MultiMullion2

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel5.PanelGlazingBead_ArtNo);
            Assert.AreEqual(401, _panelModel5.Panel_GlazingBeadWidth);
            Assert.AreEqual(975, _panelModel5.Panel_GlazingBeadHeight);
            Assert.AreEqual(323, _panelModel5.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel5.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel5.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel4.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, mullionModel4.Div_ReinfArtNo);
            Assert.AreEqual(914, mullionModel4.Div_ExplosionHeight);
            Assert.AreEqual(804, mullionModel4.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel6.PanelGlazingBead_ArtNo);
            Assert.AreEqual(401, _panelModel6.Panel_GlazingBeadWidth);
            Assert.AreEqual(975, _panelModel6.Panel_GlazingBeadHeight);
            Assert.AreEqual(323, _panelModel6.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel6.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel6.Panel_GlazingSpacerQty);

            #endregion

            #region CheckQuantity


            DataRow[] dr;


            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '2405'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1955'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2332'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1882'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            //mullionUC1 & 2
            dr = dt.Select("Description = 'Mullion Height 7538' AND Size = '1892'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R686' AND Size = '1782'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint AV585'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("8", dr[0]["Qty"]);

            //TransomUC3
            dr = dt.Select("Description = 'Transom Width 7538' AND Size = '738'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R686' AND Size = '628'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint AV585'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //P1 & P2        

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '799'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1950'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '724'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '1878'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            //P3 - P6



            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '401'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("8", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '975'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("8", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '323'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '900'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            #endregion



        }


        [TestMethod]
        public void Check_6PanelFixedWindow_with_3Mullion_2Transom()
        {
            //              
            //          |――――――――┃―――――――――┃―――――――――|
            //          |        ┃         ┃         |
            //          |        ┃   p3    ┃         |
            //          |        ┃―――――――――┃         |
            //          |        ┃    ┃    ┃         |
            //          |   p1   ┃ p5 ┃ p6 ┃     p2  |
            //          |        ┃    ┃    ┃         |
            //          |        ┃―――――――――┃         |
            //          |        ┃         ┃         |
            //          |        ┃   p4    ┃         |
            //          |________┃_________┃_________|
            //


            int total_wd = 2100, total_ht = 1500,
                pnl_1_wd = 704, pnl_1_ht = 1500,
                pnl_3_wd = 692, pnl_3_ht = 504,
                pnl_5_wd = 346, pnl_5_ht = 492;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount1 = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount1);

            #region MultiMullionPlatform as Base


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                    suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    _frameModel,
                                                                    _multiMullionModel,
                                                                    pnl_1_wd,
                                                                    pnl_1_ht,
                                                                    GlazingBead_ArticleNo._2451,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                    GlassType._Single,
                                                                    Espagnolette_ArticleNo._None,
                                                                    Striker_ArticleNo._M89ANTA,
                                                                    MiddleCloser_ArticleNo._None,
                                                                    LockingKit_ArticleNo._None,
                                                                    MotorizedMech_ArticleNo._41555B,
                                                                    Handle_Type._Rotary,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    Rotoswing_HandleArtNo._RSC773451,
                                                                    GeorgianBar_ArticleNo._None,
                                                                    0,
                                                                    0,
                                                                    false,
                                                                    1);
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(fw1);


            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                               null,
                                                                               false,
                                                                               true,
                                                                               null);

            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);



            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          pnl_3_wd,
                                                                                          pnl_3_ht,
                                                                                          multiMullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.TopDown,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          3,
                                                                                          DockStyle.None,
                                                                                          1,
                                                                                          0,
                                                                                          _multiMullionModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          2);
            _multiTransomModel1.MPanel_Placement = "Somewhere in Between";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 2;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiTransom3 = new Control();
            multiTransom3.Name = "MultiTransom_3";
            _multiMullionModel.MPanelLst_Objects.Add(multiTransom3);


            IDividerModel _divMullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                               _multiMullionModel.MPanel_Height,
                                                                               new Control(),
                                                                               DividerModel.DividerType.Mullion,
                                                                               true,
                                                                               _frameModel.Frame_Zoom,
                                                                               Divider_ArticleNo._7536,
                                                                               _multiMullionModel.MPanel_DisplayWidth,
                                                                               _multiMullionModel.MPanel_DisplayHeight,
                                                                               _multiMullionModel,
                                                                               _frameModel,
                                                                               2,
                                                                               _frameModel.FrameImageRenderer_Zoom,
                                                                               _frameModel.Frame_Type.ToString(),
                                                                                "MullionUC_2",
                                                                                null,
                                                                                false,
                                                                                true,
                                                                                null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel2);
            Control div_Mullion2 = new Control();
            div_Mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion2);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                    suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    _frameModel,
                                                                    _multiMullionModel,
                                                                    pnl_1_wd,
                                                                    pnl_1_ht,
                                                                    GlazingBead_ArticleNo._2451,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                    GlassType._Single,
                                                                    Espagnolette_ArticleNo._None,
                                                                    Striker_ArticleNo._M89ANTA,
                                                                    MiddleCloser_ArticleNo._None,
                                                                    LockingKit_ArticleNo._None,
                                                                    MotorizedMech_ArticleNo._41555B,
                                                                    Handle_Type._Rotary,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    Rotoswing_HandleArtNo._RSC773451,
                                                                    GeorgianBar_ArticleNo._None,
                                                                    0,
                                                                    0,
                                                                    false,
                                                                    2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _panelModel2.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(fw2);


            #endregion

            #region MultiTransomPlatform as Base


            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;
            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;


            IPanelModel _panelModel3 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                    multiTransom1_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    _frameModel,
                                                                    _multiTransomModel1,
                                                                    pnl_3_wd,
                                                                    pnl_3_ht,
                                                                    GlazingBead_ArticleNo._2453,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                    GlassType._Single,
                                                                    Espagnolette_ArticleNo._None,
                                                                    Striker_ArticleNo._M89ANTA,
                                                                    MiddleCloser_ArticleNo._None,
                                                                    LockingKit_ArticleNo._None,
                                                                    MotorizedMech_ArticleNo._41555B,
                                                                    Handle_Type._Rotary,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    Rotoswing_HandleArtNo._RSC773451,
                                                                    GeorgianBar_ArticleNo._None,
                                                                    0,
                                                                    0,
                                                                    false,
                                                                    3);
            _panelModel3.Panel_Placement = "First";
            _panelModel3.Panel_GlassThickness = 13.0f;
            _panelModel3.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel3);
            Control fw3 = new Control();
            fw3.Name = "FixedPanelUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(fw3);



            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                              divSize,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel1.MPanel_DisplayWidth,
                                                                              _multiTransomModel1.MPanel_DisplayHeight,
                                                                              _multiTransomModel1,
                                                                              _frameModel,
                                                                              3,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "TransomUC_3",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              null);
            _multiTransomModel1.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(div_Transom);



            IMultiPanelModel _multiMullionModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          pnl_1_wd,
                                                                                          pnl_5_ht,
                                                                                          multiMullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          4,
                                                                                          DockStyle.None,
                                                                                          1,
                                                                                          0,
                                                                                          _multiTransomModel1,
                                                                                          _frameModel.FrameImageRenderer_Zoom
                                                                                          );
            _multiMullionModel1.MPanel_Placement = "Somewhere in Between";
            _multiMullionModel1.MPanel_Index_Inside_MPanel = 2;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            _multiTransomModel1.MPanelLst_MultiPanel.Add(_multiMullionModel1);
            Control multiMullion4 = new Control();
            multiMullion4.Name = "MultiMullion_4";
            _multiTransomModel1.MPanelLst_Objects.Add(multiMullion4);


            IDividerModel _divTransomModel2 = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                               divSize,
                                                                               new Control(),
                                                                               DividerModel.DividerType.Transom,
                                                                               true,
                                                                               _frameModel.Frame_Zoom,
                                                                               Divider_ArticleNo._7536,
                                                                               _multiTransomModel1.MPanel_DisplayWidth,
                                                                               _multiTransomModel1.MPanel_DisplayHeight,
                                                                               _multiTransomModel1,
                                                                               _frameModel,
                                                                               4,
                                                                               _frameModel.FrameImageRenderer_Zoom,
                                                                               _frameModel.Frame_Type.ToString(),
                                                                                "TransomUC_4",
                                                                                null,
                                                                                false,
                                                                                true,
                                                                                null);
            _multiTransomModel1.MPanelLst_Divider.Add(_divTransomModel2);
            Control div_Transom2 = new Control();
            div_Transom2.Name = "TransomUC_4";
            _multiTransomModel1.MPanelLst_Objects.Add(div_Transom2);


            IPanelModel _panelModel4 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                     multiTransom1_suggest_HT,
                                                                     new Control(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     new UserControl(),
                                                                     "Fixed Panel",
                                                                     true,
                                                                     1.0f,
                                                                     _frameModel,
                                                                     _multiTransomModel1,
                                                                     pnl_3_wd,
                                                                     pnl_3_ht,
                                                                     GlazingBead_ArticleNo._2453,
                                                                     GlassFilm_Types._None,
                                                                     SashProfile_ArticleNo._None,
                                                                     SashReinf_ArticleNo._None,
                                                                     GlassType._Single,
                                                                     Espagnolette_ArticleNo._None,
                                                                     Striker_ArticleNo._M89ANTA,
                                                                     MiddleCloser_ArticleNo._None,
                                                                     LockingKit_ArticleNo._None,
                                                                     MotorizedMech_ArticleNo._41555B,
                                                                     Handle_Type._Rotary,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     Extension_ArticleNo._None,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     false,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     Rotoswing_HandleArtNo._RSC773451,
                                                                     GeorgianBar_ArticleNo._None,
                                                                     0,
                                                                     0,
                                                                     false,
                                                                     4);
            _panelModel4.Panel_Placement = "Last";
            _panelModel4.Panel_GlassThickness = 13.0f;
            _panelModel4.Panel_Index_Inside_MPanel = 4;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiTransomModel1.MPanelLst_Objects.Add(fw4);



            #endregion

            #region MultiMullionPlatform

            int multiMullion_totalPanelCount = _multiMullionModel1.MPanel_Divisions + 1;
            int multiMullion_suggest_Wd = (((_multiMullionModel1.MPanel_Width) - (divSize * _multiMullionModel1.MPanel_Divisions)) / multiMullion_totalPanelCount),
                multiMullion_suggest_HT = _multiMullionModel1.MPanel_Height;




            IPanelModel _panelModel5 = _panelServices.AddPanelModel(multiMullion_suggest_Wd,
                                                                    multiMullion_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    _frameModel,
                                                                    _multiMullionModel1,
                                                                    pnl_5_wd,
                                                                    pnl_5_ht,
                                                                    GlazingBead_ArticleNo._2453,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                    GlassType._Single,
                                                                    Espagnolette_ArticleNo._None,
                                                                    Striker_ArticleNo._M89ANTA,
                                                                    MiddleCloser_ArticleNo._None,
                                                                    LockingKit_ArticleNo._None,
                                                                    MotorizedMech_ArticleNo._41555B,
                                                                    Handle_Type._Rotary,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    Rotoswing_HandleArtNo._RSC773451,
                                                                    GeorgianBar_ArticleNo._None,
                                                                    0,
                                                                    0,
                                                                    false,
                                                                    5);
            _panelModel5.Panel_Placement = "First";
            _panelModel5.Panel_GlassThickness = 13.0f;
            _panelModel5.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel5);
            Control fw5 = new Control();
            fw5.Name = "FixedPanelUC_5";
            _multiMullionModel1.MPanelLst_Objects.Add(fw5);



            IDividerModel _divMullionModel3 = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel1.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiMullionModel1.MPanel_DisplayWidth,
                                                                             _multiMullionModel1.MPanel_DisplayHeight,
                                                                             _multiMullionModel1,
                                                                             _frameModel,
                                                                             5,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_5",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel1.MPanelLst_Divider.Add(_divMullionModel3);
            Control div_Mullion3 = new Control();
            div_Mullion3.Name = "MullionUC_5";
            _multiMullionModel1.MPanelLst_Objects.Add(div_Mullion3);


            IPanelModel _panelModel6 = _panelServices.AddPanelModel(multiMullion_suggest_Wd,
                                                                    multiMullion_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    _frameModel,
                                                                    _multiMullionModel1,
                                                                    pnl_5_wd,
                                                                    pnl_5_ht,
                                                                    GlazingBead_ArticleNo._2453,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                    GlassType._Single,
                                                                    Espagnolette_ArticleNo._None,
                                                                    Striker_ArticleNo._M89ANTA,
                                                                    MiddleCloser_ArticleNo._None,
                                                                    LockingKit_ArticleNo._None,
                                                                    MotorizedMech_ArticleNo._41555B,
                                                                    Handle_Type._Rotary,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    Extension_ArticleNo._None,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    false,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    Rotoswing_HandleArtNo._RSC773451,
                                                                    GeorgianBar_ArticleNo._None,
                                                                    0,
                                                                    0,
                                                                    false,
                                                                    6);
            _panelModel6.Panel_Placement = "Last";
            _panelModel6.Panel_GlassThickness = 13.0f;
            _panelModel6.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel6);
            Control fw6 = new Control();
            fw6.Name = "FixedPanelUC_6";
            _multiMullionModel1.MPanelLst_Objects.Add(fw6);

            #endregion



            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            //Assert

            #region Frame


            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2105, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2032, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1432, _frameModel.Frame_ReinfHeight);

            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(6, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(8136, _qouteModel.GlazingSeal_TotalQty);


            #endregion

            #region MultiMullion(2) base

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(704, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1500, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1428, _panelModel1.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1437, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1357, _divMullionModel.Div_ReinfHeight);

            //multiTransom(2)

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1437, _divMullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1357, _divMullionModel2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(704, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1500, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1428, _panelModel2.Panel_GlassHeight);

            #endregion

            #region MultiTransom(2) base


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(692, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(504, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(444, _panelModel3.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7536, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(653, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(573, _divTransomModel.Div_ReinfWidth);

            //multiMullion(1)

            Assert.AreEqual(Divider_ArticleNo._7536, _divTransomModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divTransomModel2.Div_ReinfArtNo);
            Assert.AreEqual(653, _divTransomModel2.Div_ExplosionWidth);
            Assert.AreEqual(573, _divTransomModel2.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(692, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(504, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(644, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(444, _panelModel4.Panel_GlassHeight);



            #endregion

            #region MultiMullion(1)


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel5.PanelGlazingBead_ArtNo);
            Assert.AreEqual(346, _panelModel5.Panel_GlazingBeadWidth);
            Assert.AreEqual(492, _panelModel5.Panel_GlazingBeadHeight);
            Assert.AreEqual(298, _panelModel5.Panel_GlassWidth);
            Assert.AreEqual(444, _panelModel5.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel3.Div_ReinfArtNo);
            Assert.AreEqual(453, _divMullionModel3.Div_ExplosionHeight);
            Assert.AreEqual(373, _divMullionModel3.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel6.PanelGlazingBead_ArtNo);
            Assert.AreEqual(346, _panelModel6.Panel_GlazingBeadWidth);
            Assert.AreEqual(492, _panelModel6.Panel_GlazingBeadHeight);
            Assert.AreEqual(298, _panelModel6.Panel_GlassWidth);
            Assert.AreEqual(444, _panelModel6.Panel_GlassHeight);


            #endregion

            #region Check Quantity


            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '2105'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2032'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Height 7536' AND Size = '1437'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R677' AND Size = '1357'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '653'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '573'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            //P1 & P2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '704'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '644'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '1428'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //P3 & P4
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '692'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '644'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '444'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            //P5 & P6
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '346'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '492'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%%' AND
                             Size = '298'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass height%%' AND
                             Size = '444'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            #endregion


        }

        //Awning Window Samples

        [TestMethod]
        public void ChkVar_SinglePanelAwningWindow()
        {
            /*           _________________
             *           |       /\       |   
             *           |      /  \      |
             *           |     /    \     |
             *           |    /      \    |
             *           |   /        \   | 
             *           |  /          \  |
             *           | /            \ |
             *           |/______________\|    
             */



            int total_wd = 700, total_height = 1200;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._DarkBrown, Foil_Color._Cacao, Foil_Color._Cacao);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
                                                                   ht,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Awning Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   null,
                                                                   total_wd,
                                                                   total_height,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._628807,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._1WC70DB,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel.Panel_GlassThickness = 14.0f;
            _panelModel.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC773452;
            _frameModel.Lst_Panel.Add(_panelModel);



            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(705, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(632, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(1, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(3612, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(1680000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(6, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(24, _qouteModel.Rebate_Qty);
            Assert.AreEqual(41, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(25, _qouteModel.Screws_for_Installation);

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(653, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1153, _panelModel.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel.Panel_SashProfileArtNo);
            Assert.AreEqual(1153, _panelModel.Panel_SashHeight);
            Assert.AreEqual(653, _panelModel.Panel_SashWidth);
            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel.Panel_SashReinfArtNo);
            Assert.AreEqual(528, _panelModel.Panel_SashReinfWidth);
            Assert.AreEqual(1028, _panelModel.Panel_SashReinfHeight);
            Assert.AreEqual(1028, _panelModel.Panel_SashReinfHeight);
            Assert.AreEqual(532, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1032, _panelModel.Panel_GlassHeight);


            //ACCESSORIES & HARWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773452, _panelModel.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel.Panel_MiddleCloserArtNo);
            Assert.AreEqual(1, _panelModel.Panel_MiddleCloserPairQty);


            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '705'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1205'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '653'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1153'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '528'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1028'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '653'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1153'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '532'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1032'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            #endregion

        }


        [TestMethod]
        public void ChkVar_2PanelAwningWindow()
        {
            /*          __________________________________
            *           |       /\       |       /\       |   
            *           |      /  \      |      /  \      |
            *           |     /    \     |     /    \     |
            *           |    /      \    |    /      \    |
            *           |   /        \   |   /        \   | 
            *           |  /          \  |  /          \  |
            *           | /            \ | /            \ |
            *           |/______________\|/______________\|    
            */

            int total_wd = 1370,
                total_ht = 1100,
                eqpanelWD = 685;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount);


            #region MultiMullionModel


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Awning Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._628807,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._1WC70DB,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC823048,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Awning1 = new Control();
            Awning1.Name = "AwningPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Awning1);


            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Awning Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2452,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._7581,
                                                                      SashReinf_ArticleNo._R675,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._628807,
                                                                      Striker_ArticleNo._M89ANTA,
                                                                      MiddleCloser_ArticleNo._1WC70DB,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC773451,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _panelModel2.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC823048;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Awning2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1375, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1105, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1302, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1032, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(1, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(3014000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(8, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(32, _qouteModel.Rebate_Qty);
            Assert.AreEqual(75, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(43, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region AW1

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(650, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1053, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(650, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1053, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(525, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(928, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(529, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(932, _panelModel1.Panel_GlassHeight);



            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel1.Panel_FrictionStayArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC823048, _panelModel1.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel1.Panel_MiddleCloserArtNo);





            #endregion

            #region MullionUC1

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1037, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(957, _divMullionModel.Div_ReinfHeight);

            #endregion

            #region AW2

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(650, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1053, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(650, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1053, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(525, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(928, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(529, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(932, _panelModel2.Panel_GlassHeight);

            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel2.Panel_FrictionStayArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC823048, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel2.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel2.Panel_MiddleCloserArtNo);



            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1375'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1105'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1302'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1032'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '650'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1053'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '928'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '650'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1053'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '529'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '932'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);




            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_2Panel_2AwningWindowUsingExtension()
        {

            /*
                                                
                   __________________
                   |       /\       |
                   |      /  \      | 
                   |     /    \     |         
                   |    /      \    |   
                   |   /   P1   \   |   
                   |  /          \  |          
                   | /            \ |             
                   |/______________\|
                   |       /\       |
                   |      /  \      | 
                   |     /    \     |         
                   |    /      \    |   
                   |   /   P2   \   |   
                   |  /          \  |          
                   | /            \ |             
                   |/______________\|

             */

            int total_wd = 1247, total_ht = 3370,
                AwWD1 = 1247, AwHT1 = 1235,
                AwWD2 = 1247, AwHT2 = 2135;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._DarkBrown, Foil_Color._JetBlack, Foil_Color._JetBlack);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiTransomModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.TopDown,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiTransomModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiTransomModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiTransomModel.MPanel_Divisions + 1;
            int suggest_Wd = _multiTransomModel.MPanel_Width,
                suggest_HT = (((_multiTransomModel.MPanel_Height) - (divSize * _multiTransomModel.MPanel_Divisions)) / multiTransom_totalPanelCount);

            #region MultiMullionPlatform (2)

            IPanelModel _panelModel1_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                  suggest_HT,
                                                                                  new Control(),
                                                                                  new UserControl(),
                                                                                  new UserControl(),
                                                                                  new UserControl(),
                                                                                  "Awning Panel",
                                                                                  true,
                                                                                  1.0f,
                                                                                  _frameModel,
                                                                                  _multiTransomModel,
                                                                                  AwWD1,
                                                                                  AwHT1,
                                                                                  GlazingBead_ArticleNo._2435,
                                                                                  GlassFilm_Types._None,
                                                                                  SashProfile_ArticleNo._7581,
                                                                                  SashReinf_ArticleNo._R675,
                                                                                  GlassType._Single,
                                                                                  Espagnolette_ArticleNo._628809,
                                                                                  Striker_ArticleNo._M89ANTA,
                                                                                  MiddleCloser_ArticleNo._1WC70DB,
                                                                                  LockingKit_ArticleNo._None,
                                                                                  MotorizedMech_ArticleNo._41556C,
                                                                                   Handle_Type._Rotoswing,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   false,
                                                                                   false,
                                                                                   false,
                                                                                   false,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                                   GeorgianBar_ArticleNo._None,
                                                                                   0,
                                                                                   0,
                                                                                   false,
                                                                                   1);
            _panelModel1_Awning.Panel_Placement = "First";
            _panelModel1_Awning.Panel_GlassThickness = 24.0f;
            _panelModel1_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC773452;
            _panelModel1_Awning.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel1_Awning);
            Control Awning = new Control();
            Awning.Name = "AwningPanelUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(Awning);

            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(divSize,
                                                                             _multiTransomModel.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Transom,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiTransomModel.MPanel_DisplayWidth,
                                                                             _multiTransomModel.MPanel_DisplayHeight,
                                                                             _multiTransomModel,
                                                                             _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "TransomUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              null);
            _multiTransomModel.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(div_Transom);



            IPanelModel _panelModel2_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                  suggest_HT,
                                                                                  new Control(),
                                                                                  new UserControl(),
                                                                                  new UserControl(),
                                                                                  new UserControl(),
                                                                                  "Awning Panel",
                                                                                  true,
                                                                                  1.0f,
                                                                                  _frameModel,
                                                                                  _multiTransomModel,
                                                                                  AwWD2,
                                                                                  AwHT2,
                                                                                  GlazingBead_ArticleNo._2452,
                                                                                  GlassFilm_Types._None,
                                                                                  SashProfile_ArticleNo._7581,
                                                                                  SashReinf_ArticleNo._R675,
                                                                                  GlassType._Single,
                                                                                  Espagnolette_ArticleNo._741012,
                                                                                  Striker_ArticleNo._M89ANTA,
                                                                                  MiddleCloser_ArticleNo._1WC70DB,
                                                                                  LockingKit_ArticleNo._T24402KMBL,
                                                                                  MotorizedMech_ArticleNo._41556C,
                                                                                  Handle_Type._Rotoswing,
                                                                                  Extension_ArticleNo._None,
                                                                                  Extension_ArticleNo._None,
                                                                                  Extension_ArticleNo._None,
                                                                                  Extension_ArticleNo._None,
                                                                                  Extension_ArticleNo._639957,
                                                                                  Extension_ArticleNo._612978,
                                                                                  Extension_ArticleNo._639957,
                                                                                  Extension_ArticleNo._612978,
                                                                                  false,
                                                                                  false,
                                                                                  true,
                                                                                  true,
                                                                                  0,
                                                                                  0,
                                                                                  2,
                                                                                  2,
                                                                                  0,
                                                                                  0,
                                                                                  1,
                                                                                  1,
                                                                                  Rotoswing_HandleArtNo._RSC773452,
                                                                                  GeorgianBar_ArticleNo._None,
                                                                                  0,
                                                                                  0,
                                                                                  false,
                                                                                  2);
            _panelModel2_Awning.Panel_Placement = "Last";
            _panelModel2_Awning.Panel_GlassThickness = 6.0f;
            _panelModel2_Awning.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel2_Awning.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2_Awning.Panel_StrikerArtno_C = Striker_ArticleNo._M89ANTC;
            _panelModel2_Awning.Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
            _panelModel2_Awning.Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;
            _panelModel2_Awning.Panel_ExtensionOptionsVisibility = true;
            _panelModel2_Awning.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel2_Awning);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_2";
            _multiTransomModel.MPanelLst_Objects.Add(Awning2);


            #endregion

            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1252, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(3375, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1179, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(3302, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(4800, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(8404780, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(14, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(56, _qouteModel.Rebate_Qty);
            Assert.AreEqual(164, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(73, _qouteModel.Screws_for_Installation);


            #region AwningUC_1

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel1_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(1200, _panelModel1_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1200, _panelModel1_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(1200, _panelModel1_Awning.Panel_SashHeight);
            Assert.AreEqual(1200, _panelModel1_Awning.Panel_SashWidth);
            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(1075, _panelModel1_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1075, _panelModel1_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(1079, _panelModel1_Awning.Panel_GlassWidth);
            Assert.AreEqual(1079, _panelModel1_Awning.Panel_GlassHeight);


            //ACCESSORIES & HARWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel1_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(1, _panelModel1_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628809, _panelModel1_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773452, _panelModel1_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel1_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel1_Awning.Panel_MiddleCloserArtNo);
            Assert.AreEqual(1, _panelModel1_Awning.Panel_MiddleCloserPairQty);


            #endregion

            Assert.AreEqual(Divider_ArticleNo._7536, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(1184, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(1104, _divTransomModel.Div_ReinfWidth);

            #region AwningUC_2


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(1200, _panelModel2_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(2100, _panelModel2_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(1200, _panelModel2_Awning.Panel_SashWidth);
            Assert.AreEqual(2100, _panelModel2_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(1075, _panelModel2_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1975, _panelModel2_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(1079, _panelModel2_Awning.Panel_GlassWidth);
            Assert.AreEqual(1979, _panelModel2_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm26, _panelModel2_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(4, _panelModel2_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._741012, _panelModel2_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773452, _panelModel2_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(LockingKit_ArticleNo._T24402KMBL, _panelModel2_Awning.Panel_LockingKitArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(5, _panelModel2_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel2_Awning.Panel_StrikerArtno_C);
            Assert.AreEqual(4, _panelModel2_Awning.Panel_StrikerQty_C);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel2_Awning.Panel_MiddleCloserArtNo);
            Assert.AreEqual(3, _panelModel2_Awning.Panel_MiddleCloserPairQty);

            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2_Awning.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(2, _panelModel2_Awning.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2_Awning.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(1, _panelModel2_Awning.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2_Awning.Panel_ExtensionRightArtNo);
            Assert.AreEqual(2, _panelModel2_Awning.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2_Awning.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(1, _panelModel2_Awning.Panel_ExtRight2Qty);


            #endregion




            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1252'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '3375'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1179'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '3302'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '1200'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1200'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '2100'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '1075'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1075'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1975'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //p1
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2435%' AND
                             Size = '1200'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2435%' AND
                             Size = '1200'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '1079'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1079'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            //P2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '1200'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '2100'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '1079'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1079'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            //ACCESSORIES AND HARDWARES 

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-A%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("7", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%SNAP-IN KEEP%' AND
                             Description LIKE '%0400215%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%FIXED CAM%' AND
                             Description LIKE '%1481413%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            #endregion

        }


        [TestMethod]
        public void ChkVar_3Panel_1Awning_2FixWindow()
        {

            /*
                        ________________________________
                       |                |              |                 
                       |       P2       |              |
                       |                |              |
                       |________________|              |
                       |       /\       |              |   
                       |      /  \      |      P1      |
                       |     /    \     |              |
                       |    /      \    |              |
                       |   /   P3   \   |              | 
                       |  /          \  |              |
                       | /            \ |              |
                       |/______________\|______________|    
            */


            int total_wd = 1500, total_ht = 1800,
                PnlWidth1_Fix = 800, PnlHeight1_Fix = 600,
                PnlWidth2_Awning = 800, PnlHeight2_Awning = 1200,
                PnlWidth3_Fix = 700, PnlHeight3_Fix = 1800;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;
            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount);

            #region MultiMullionPlatform (2)


            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          PnlWidth1_Fix,
                                                                                          total_ht,
                                                                                          multiMullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.TopDown,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          1,
                                                                                          DockStyle.None,
                                                                                          1,
                                                                                          0,
                                                                                          _multiMullionModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          2);
            _multiTransomModel1.MPanel_Placement = "First";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiTransom1 = new Control();
            multiTransom1.Name = "MultiTransom_1";
            _multiMullionModel.MPanelLst_Objects.Add(multiTransom1);



            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7538,
                                                                             _multiMullionModel.MPanel_DisplayWidth,
                                                                             _multiMullionModel.MPanel_DisplayHeight,
                                                                             _multiMullionModel,
                                                                             _frameModel,
                                                                             1,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_1",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel1_fixed1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                           suggest_HT,
                                                                           new Control(),
                                                                           new UserControl(),
                                                                           new UserControl(),
                                                                           new UserControl(),
                                                                           "Fixed Panel",
                                                                           true,
                                                                           1.0f,
                                                                           _frameModel,
                                                                           _multiMullionModel,
                                                                           PnlWidth3_Fix,
                                                                           PnlHeight3_Fix,
                                                                           GlazingBead_ArticleNo._2453,
                                                                           GlassFilm_Types._None,
                                                                           SashProfile_ArticleNo._None,
                                                                           SashReinf_ArticleNo._None,
                                                                           GlassType._Single,
                                                                           Espagnolette_ArticleNo._None,
                                                                           Striker_ArticleNo._M89ANTA,
                                                                           MiddleCloser_ArticleNo._None,
                                                                           LockingKit_ArticleNo._None,
                                                                           MotorizedMech_ArticleNo._41555B,
                                                                           Handle_Type._Rotoswing,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           Rotoswing_HandleArtNo._RSC773451,
                                                                           GeorgianBar_ArticleNo._None,
                                                                           0,
                                                                           0,
                                                                           false,
                                                                           1);
            _panelModel1_fixed1.Panel_Placement = "Last";
            _panelModel1_fixed1.Panel_GlassThickness = 14.0f;
            _panelModel1_fixed1.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1_fixed1);
            Control Fixed1 = new Control();
            Fixed1.Name = "FixedPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Fixed1);


            #endregion

            #region MultiTransomPlatform (2)

            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;
            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;

            IPanelModel _panelModel2_fixed2 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                  multiTransom1_suggest_HT,
                                                                  new Control(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  new UserControl(),
                                                                  "Fixed Panel",
                                                                  true,
                                                                  1.0f,
                                                                  _frameModel,
                                                                  _multiTransomModel1,
                                                                  PnlWidth1_Fix,
                                                                  PnlHeight1_Fix,
                                                                  GlazingBead_ArticleNo._2453,
                                                                  GlassFilm_Types._None,
                                                                  SashProfile_ArticleNo._None,
                                                                  SashReinf_ArticleNo._None,
                                                                  GlassType._Single,
                                                                  Espagnolette_ArticleNo._None,
                                                                  Striker_ArticleNo._M89ANTA,
                                                                  MiddleCloser_ArticleNo._None,
                                                                  LockingKit_ArticleNo._None,
                                                                  MotorizedMech_ArticleNo._41555B,
                                                                  Handle_Type._Rotoswing,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  Extension_ArticleNo._None,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  false,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  0,
                                                                  Rotoswing_HandleArtNo._RSC773451,
                                                                  GeorgianBar_ArticleNo._None,
                                                                  0,
                                                                  0,
                                                                  false,
                                                                  2);
            _panelModel2_fixed2.Panel_Placement = "First";
            _panelModel2_fixed2.Panel_GlassThickness = 14.0f;
            _panelModel2_fixed2.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel2_fixed2);
            Control Fixed2 = new Control();
            Fixed2.Name = "FixedPanelUC_2";
            _multiTransomModel1.MPanelLst_Objects.Add(Fixed2);





            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                              divSize,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel1.MPanel_DisplayWidth,
                                                                              _multiTransomModel1.MPanel_DisplayHeight,
                                                                              _multiTransomModel1,
                                                                              _frameModel,
                                                                              2,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                               "TransomUC_2",
                                                                    null,
                                                                    false,
                                                                    true,
                                                                    null);
            _multiTransomModel1.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_2";
            _multiTransomModel1.MPanelLst_Objects.Add(div_Transom);



            IPanelModel _panelModel3_Awning1 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                             multiTransom1_suggest_HT,
                                                                             new Control(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             "Awning Panel",
                                                                             true,
                                                                             1.0f,
                                                                             _frameModel,
                                                                             _multiTransomModel1,
                                                                             PnlWidth2_Awning,
                                                                             PnlHeight2_Awning,
                                                                             GlazingBead_ArticleNo._2453,
                                                                             GlassFilm_Types._None,
                                                                             SashProfile_ArticleNo._7581,
                                                                             SashReinf_ArticleNo._R675,
                                                                             GlassType._Single,
                                                                             Espagnolette_ArticleNo._628807,
                                                                             Striker_ArticleNo._M89ANTA,
                                                                             MiddleCloser_ArticleNo._1WC70DB,
                                                                             LockingKit_ArticleNo._None,
                                                                             MotorizedMech_ArticleNo._41555B,
                                                                             Handle_Type._Rotoswing,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             Extension_ArticleNo._None,
                                                                             false,
                                                                             false,
                                                                             false,
                                                                             false,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             Rotoswing_HandleArtNo._RSC773451,
                                                                             GeorgianBar_ArticleNo._None,
                                                                             0,
                                                                             0,
                                                                             false,
                                                                             3);
            _panelModel3_Awning1.Panel_Placement = "Last";
            _panelModel3_Awning1.Panel_GlassThickness = 14.0f;
            _panelModel3_Awning1.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC823048;
            _panelModel3_Awning1.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel3_Awning1);
            Control Awning3 = new Control();
            Awning3.Name = "AwningPanelUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(Awning3);

            #endregion





            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1805, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1432, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1732, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(11630, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(2, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(5400000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(10, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(40, _qouteModel.Rebate_Qty);
            Assert.AreEqual(62, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(44, _qouteModel.Screws_for_Installation);

            #region MultiMullion

            //MultiTransom

            Assert.AreEqual(Divider_ArticleNo._7538, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1742, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1632, _divMullionModel.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1_fixed1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(700, _panelModel1_fixed1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1800, _panelModel1_fixed1.Panel_GlazingBeadHeight);
            Assert.AreEqual(625, _panelModel1_fixed1.Panel_GlassWidth);
            Assert.AreEqual(1728, _panelModel1_fixed1.Panel_GlassHeight);

            #endregion

            #region MultiTransom

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2_fixed2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel2_fixed2.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel2_fixed2.Panel_GlazingBeadHeight);
            Assert.AreEqual(725, _panelModel2_fixed2.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel2_fixed2.Panel_GlassHeight);



            Assert.AreEqual(Divider_ArticleNo._7536, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(734, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(654, _divTransomModel.Div_ReinfWidth);




            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel3_Awning1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(750, _panelModel3_Awning1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1165, _panelModel3_Awning1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel3_Awning1.Panel_SashProfileArtNo);
            Assert.AreEqual(750, _panelModel3_Awning1.Panel_SashWidth);
            Assert.AreEqual(1165, _panelModel3_Awning1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel3_Awning1.Panel_SashReinfArtNo);
            Assert.AreEqual(625, _panelModel3_Awning1.Panel_SashReinfWidth);
            Assert.AreEqual(1040, _panelModel3_Awning1.Panel_SashReinfHeight);

            Assert.AreEqual(629, _panelModel3_Awning1.Panel_GlassWidth);
            Assert.AreEqual(1044, _panelModel3_Awning1.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel3_Awning1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel3_Awning1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel3_Awning1.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel3_Awning1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel3_Awning1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel3_Awning1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC823048, _panelModel3_Awning1.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel3_Awning1.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel3_Awning1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel3_Awning1.Panel_MiddleCloserArtNo);

            #endregion


            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1805'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '750'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1165'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '625'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1040'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //p1
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '600'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '725'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '540'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            //p2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '750'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1165'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '629'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1044'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            //p3
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '700'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '625'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1728'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);
            #endregion

        }


        [TestMethod]
        public void ChkVar_3Panel_1AwningUsing26HD_2FixWindow()
        {

            /*
                        ________________________________
                       |                |              |                 
                       |       P2       |              |
                       |                |              |
                       |________________|              |
                       |       /\       |              |   
                       |      /  \      |      P1      |
                       |     /    \     |              |
                       |    /      \    |              |
                       |   /   P3   \   |              | 
                       |  /          \  |              |
                       | /            \ |              |
                       |/______________\|______________|    
            */


            int total_wd = 1500, total_ht = 1800,
                PnlWidth1_Fix = 800, PnlHeight1_Fix = 400,
                PnlWidth2_Awning = 800, PnlHeight2_Awning = 1400,
                PnlWidth3_Fix = 700, PnlHeight3_Fix = 1800;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;
            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount);

            #region MultiMullionPlatform (2)


            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          PnlWidth1_Fix,
                                                                                          total_ht,
                                                                                          multiMullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.TopDown,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          1,
                                                                                          DockStyle.None,
                                                                                          1,
                                                                                          0,
                                                                                          _multiMullionModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          2);
            _multiTransomModel1.MPanel_Placement = "First";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiTransom1 = new Control();
            multiTransom1.Name = "MultiTransom_1";
            _multiMullionModel.MPanelLst_Objects.Add(multiTransom1);



            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7538,
                                                                             _multiMullionModel.MPanel_DisplayWidth,
                                                                             _multiMullionModel.MPanel_DisplayHeight,
                                                                             _multiMullionModel,
                                                                             _frameModel,
                                                                             1,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_1",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel1_fixed1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                           suggest_HT,
                                                                           new Control(),
                                                                           new UserControl(),
                                                                           new UserControl(),
                                                                           new UserControl(),
                                                                           "Fixed Panel",
                                                                           true,
                                                                           1.0f,
                                                                           _frameModel,
                                                                           _multiMullionModel,
                                                                           PnlWidth3_Fix,
                                                                           PnlHeight3_Fix,
                                                                           GlazingBead_ArticleNo._2453,
                                                                           GlassFilm_Types._None,
                                                                           SashProfile_ArticleNo._None,
                                                                           SashReinf_ArticleNo._None,
                                                                           GlassType._Single,
                                                                           Espagnolette_ArticleNo._None,
                                                                           Striker_ArticleNo._M89ANTA,
                                                                           MiddleCloser_ArticleNo._None,
                                                                           LockingKit_ArticleNo._None,
                                                                           MotorizedMech_ArticleNo._41555B,
                                                                           Handle_Type._Rotoswing,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           Rotoswing_HandleArtNo._RSC773451,
                                                                           GeorgianBar_ArticleNo._None,
                                                                           0,
                                                                           0,
                                                                           false,
                                                                           1);
            _panelModel1_fixed1.Panel_Placement = "Last";
            _panelModel1_fixed1.Panel_GlassThickness = 14.0f;
            _panelModel1_fixed1.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1_fixed1);
            Control Fixed1 = new Control();
            Fixed1.Name = "FixedPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Fixed1);


            #endregion

            #region MultiTransomPlatform (2)

            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;
            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;

            IPanelModel _panelModel2_fixed2 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                          multiTransom1_suggest_HT,
                                                                          new Control(),
                                                                          new UserControl(),
                                                                          new UserControl(),
                                                                          new UserControl(),
                                                                          "Fixed Panel",
                                                                          true,
                                                                          1.0f,
                                                                          _frameModel,
                                                                          _multiTransomModel1,
                                                                          PnlWidth1_Fix,
                                                                          PnlHeight1_Fix,
                                                                          GlazingBead_ArticleNo._2453,
                                                                          GlassFilm_Types._None,
                                                                          SashProfile_ArticleNo._None,
                                                                          SashReinf_ArticleNo._None,
                                                                          GlassType._Single,
                                                                          Espagnolette_ArticleNo._None,
                                                                          Striker_ArticleNo._M89ANTA,
                                                                          MiddleCloser_ArticleNo._None,
                                                                          LockingKit_ArticleNo._None,
                                                                          MotorizedMech_ArticleNo._41555B,
                                                                          Handle_Type._Rotoswing,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          Rotoswing_HandleArtNo._RSC773451,
                                                                          GeorgianBar_ArticleNo._None,
                                                                          0,
                                                                          0,
                                                                          false,
                                                                          2);
            _panelModel2_fixed2.Panel_Placement = "First";
            _panelModel2_fixed2.Panel_GlassThickness = 14.0f;
            _panelModel2_fixed2.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel2_fixed2);
            Control Fixed2 = new Control();
            Fixed2.Name = "FixedPanelUC_2";
            _multiTransomModel1.MPanelLst_Objects.Add(Fixed2);





            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(_multiTransomModel1.MPanel_Width,
                                                                              divSize,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel1.MPanel_DisplayWidth,
                                                                              _multiTransomModel1.MPanel_DisplayHeight,
                                                                              _multiTransomModel1,
                                                                              _frameModel,
                                                                              2,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "TransomUC_2",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              null);
            _multiTransomModel1.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_2";
            _multiTransomModel1.MPanelLst_Objects.Add(div_Transom);



            IPanelModel _panelModel3_Awning1 = _panelServices.AddPanelModel(multiTransom1_suggest_Wd,
                                                                            multiTransom1_suggest_HT,
                                                                             new Control(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             "Awning Panel",
                                                                             true,
                                                                             1.0f,
                                                                             _frameModel,
                                                                             _multiTransomModel1,
                                                                             PnlWidth2_Awning,
                                                                             PnlHeight2_Awning,
                                                                             GlazingBead_ArticleNo._2453,
                                                                             GlassFilm_Types._None,
                                                                             SashProfile_ArticleNo._7581,
                                                                             SashReinf_ArticleNo._R675,
                                                                             GlassType._Single,
                                                                             Espagnolette_ArticleNo._628807,
                                                                             Striker_ArticleNo._M89ANTA,
                                                                             MiddleCloser_ArticleNo._1WC70DB,
                                                                             LockingKit_ArticleNo._None,
                                                                             MotorizedMech_ArticleNo._41555B,
                                                                             Handle_Type._Rotoswing,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              Rotoswing_HandleArtNo._RSC773451,
                                                                              GeorgianBar_ArticleNo._None,
                                                                              0,
                                                                              0,
                                                                              false,
                                                                              3);
            _panelModel3_Awning1.Panel_Placement = "Last";
            _panelModel3_Awning1.Panel_GlassThickness = 14.0f;
            _panelModel3_Awning1.Panel_SnapInKeepArtNo = SnapInKeep_ArticleNo._0400205;
            _panelModel3_Awning1.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC823048;
            _panelModel3_Awning1.Panel_FixedCamArtNo = FixedCam_ArticleNo._1481413;
            _panelModel3_Awning1.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel3_Awning1);
            Control Awning3 = new Control();
            Awning3.Name = "AwningPanelUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(Awning3);

            #endregion





            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1805, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1432, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1732, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(11630, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(2, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(5400000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(10, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(40, _qouteModel.Rebate_Qty);
            Assert.AreEqual(71, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(45, _qouteModel.Screws_for_Installation);

            #region MultiMullion

            //MultiTransom

            Assert.AreEqual(Divider_ArticleNo._7538, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1742, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1632, _divMullionModel.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1_fixed1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(700, _panelModel1_fixed1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1800, _panelModel1_fixed1.Panel_GlazingBeadHeight);
            Assert.AreEqual(625, _panelModel1_fixed1.Panel_GlassWidth);
            Assert.AreEqual(1728, _panelModel1_fixed1.Panel_GlassHeight);

            #endregion

            #region MultiTransom

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2_fixed2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel2_fixed2.Panel_GlazingBeadWidth);
            Assert.AreEqual(400, _panelModel2_fixed2.Panel_GlazingBeadHeight);
            Assert.AreEqual(725, _panelModel2_fixed2.Panel_GlassWidth);
            Assert.AreEqual(340, _panelModel2_fixed2.Panel_GlassHeight);



            Assert.AreEqual(Divider_ArticleNo._7536, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(734, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(654, _divTransomModel.Div_ReinfWidth);




            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel3_Awning1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(750, _panelModel3_Awning1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1365, _panelModel3_Awning1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel3_Awning1.Panel_SashProfileArtNo);
            Assert.AreEqual(750, _panelModel3_Awning1.Panel_SashWidth);
            Assert.AreEqual(1365, _panelModel3_Awning1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel3_Awning1.Panel_SashReinfArtNo);
            Assert.AreEqual(625, _panelModel3_Awning1.Panel_SashReinfWidth);
            Assert.AreEqual(1240, _panelModel3_Awning1.Panel_SashReinfHeight);

            Assert.AreEqual(629, _panelModel3_Awning1.Panel_GlassWidth);
            Assert.AreEqual(1244, _panelModel3_Awning1.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel3_Awning1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel3_Awning1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm26, _panelModel3_Awning1.Panel_FrictionStayArtNo);
            Assert.AreEqual(4, _panelModel3_Awning1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel3_Awning1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel3_Awning1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC823048, _panelModel3_Awning1.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel3_Awning1.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel3_Awning1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel3_Awning1.Panel_MiddleCloserArtNo);

            #endregion


            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1805'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '750'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1365'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '625'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1240'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //p1
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '400'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '725'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '340'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            //p2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '750'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1365'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '629'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1244'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            //p3
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '700'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '625'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1728'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            //ACCESSORIES AND HARDWARES

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%SNAP-IN KEEP%' AND
                             Description LIKE '%0400205%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%FIXED CAM%' AND
                             Description LIKE '%1481413%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            #endregion

        }



        [TestMethod]
        public void ChkVar_3Panel_2FixWindow_1Awning()
        {
            /*
                      __________________
                      |                |                              
                      |       P1       |             
                      |                |              
                      |________________|             
                      |       /\       |              
                      |      /  \      |            
                      |     /    \     |              
                      |    /      \    |              
                      |   /   P2   \   |              
                      |  /          \  |              
                      | /            \ |              
                      |/______________\|   
                      |                |                              
                      |       P3       |             
                      |                |              
                      |________________|
           */
            int total_wd = 800, total_ht = 2200,
               PnlWidth1_Fix = 800, PnlHeight1_Fix = 600,
               PnlWidth2_Awning = 800, PnlHeight2_Awning = 1000;




            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiTransomModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.TopDown,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         3);
            _multiTransomModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel);
            Control multiTransom = new Control();
            multiTransom.Name = _multiTransomModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiTransomModel.MPanel_Divisions + 1;
            int suggest_Wd = ((_multiTransomModel.MPanel_Width - (divSize * _multiTransomModel.MPanel_Divisions)) / multiMullion_totalPanelCount),
                suggest_HT = _multiTransomModel.MPanel_Height;

            #region MultiTransomPlatform(3)

            IPanelModel _panelModel1_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                             suggest_HT,
                                                                             new Control(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             "Fixed Panel",
                                                                             true,
                                                                             1.0f,
                                                                             _frameModel,
                                                                             _multiTransomModel,
                                                                             PnlWidth1_Fix,
                                                                             PnlHeight1_Fix,
                                                                             GlazingBead_ArticleNo._2453,
                                                                             GlassFilm_Types._None,
                                                                             SashProfile_ArticleNo._None,
                                                                             SashReinf_ArticleNo._None,
                                                                             GlassType._Single,
                                                                             Espagnolette_ArticleNo._None,
                                                                             Striker_ArticleNo._M89ANTA,
                                                                             MiddleCloser_ArticleNo._None,
                                                                             LockingKit_ArticleNo._None,
                                                                             MotorizedMech_ArticleNo._41555B,
                                                                             Handle_Type._Rotoswing,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              Rotoswing_HandleArtNo._RSC773451,
                                                                              GeorgianBar_ArticleNo._None,
                                                                              0,
                                                                              0,
                                                                              false,
                                                                              1);
            _panelModel1_fixed.Panel_Placement = "First";
            _panelModel1_fixed.Panel_GlassThickness = 6.0f;
            _panelModel1_fixed.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel1_fixed);
            Control Fixed1 = new Control();
            Fixed1.Name = "FixedPanelUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(Fixed1);


            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(_multiTransomModel.MPanel_Width,
                                                                           divSize,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Transom,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7538,
                                                                           _multiTransomModel.MPanel_DisplayWidth,
                                                                           _multiTransomModel.MPanel_DisplayHeight,
                                                                           _multiTransomModel,
                                                                           _frameModel,
                                                                           1,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "TransomUC_1",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiTransomModel.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(div_Transom);


            IPanelModel _panelModel2_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                             suggest_HT,
                                                                             new Control(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             new UserControl(),
                                                                             "Awning Panel",
                                                                             true,
                                                                             1.0f,
                                                                             _frameModel,
                                                                             _multiTransomModel,
                                                                             PnlWidth2_Awning,
                                                                             PnlHeight2_Awning,
                                                                             GlazingBead_ArticleNo._2453,
                                                                             GlassFilm_Types._None,
                                                                             SashProfile_ArticleNo._7581,
                                                                             SashReinf_ArticleNo._R675,
                                                                             GlassType._Single,
                                                                             Espagnolette_ArticleNo._628807,
                                                                             Striker_ArticleNo._M89ANTA,
                                                                             MiddleCloser_ArticleNo._1WC70WHT,
                                                                             LockingKit_ArticleNo._None,
                                                                             MotorizedMech_ArticleNo._41555B,
                                                                             Handle_Type._Rotoswing,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              Rotoswing_HandleArtNo._RSC773451,
                                                                              GeorgianBar_ArticleNo._None,
                                                                              0,
                                                                              0,
                                                                              false,
                                                                              2);
            _panelModel2_Awning.Panel_Placement = "Somewhere in Between";
            _panelModel2_Awning.Panel_GlassThickness = 6.0f;
            _panelModel2_Awning.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel2_Awning);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_2";
            _multiTransomModel.MPanelLst_Objects.Add(Awning2);


            IDividerModel _divTransomModel2 = _dividerServices.AddDividerModel(_multiTransomModel.MPanel_Width,
                                                                         divSize,
                                                                         new Control(),
                                                                         DividerModel.DividerType.Transom,
                                                                         true,
                                                                         _frameModel.Frame_Zoom,
                                                                         Divider_ArticleNo._7538,
                                                                         _multiTransomModel.MPanel_DisplayWidth,
                                                                         _multiTransomModel.MPanel_DisplayHeight,
                                                                         _multiTransomModel,
                                                                         _frameModel,
                                                                         2,
                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                         _frameModel.Frame_Type.ToString(),
                                                                         "TransomUC_2",
                                                                         null,
                                                                         false,
                                                                         true,
                                                                         null);
            _multiTransomModel.MPanelLst_Divider.Add(_divTransomModel2);
            Control div_Transom2 = new Control();
            div_Transom2.Name = "TransomUC_2";
            _multiTransomModel.MPanelLst_Objects.Add(div_Transom2);


            IPanelModel _panelModel3_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                            suggest_HT,
                                                                            new Control(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            "Fixed Panel",
                                                                            true,
                                                                            1.0f,
                                                                            _frameModel,
                                                                            _multiTransomModel,
                                                                            PnlWidth1_Fix,
                                                                            PnlHeight1_Fix,
                                                                            GlazingBead_ArticleNo._2453,
                                                                            GlassFilm_Types._None,
                                                                            SashProfile_ArticleNo._None,
                                                                            SashReinf_ArticleNo._None,
                                                                            GlassType._Single,
                                                                            Espagnolette_ArticleNo._None,
                                                                            Striker_ArticleNo._M89ANTA,
                                                                            MiddleCloser_ArticleNo._None,
                                                                            LockingKit_ArticleNo._None,
                                                                            MotorizedMech_ArticleNo._41555B,
                                                                            Handle_Type._Rotoswing,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            Rotoswing_HandleArtNo._RSC773451,
                                                                            GeorgianBar_ArticleNo._None,
                                                                            0,
                                                                            0,
                                                                            false,
                                                                            3);
            _panelModel3_fixed.Panel_Placement = "Last";
            _panelModel3_fixed.Panel_GlassThickness = 6.0f;
            _panelModel3_fixed.Panel_Index_Inside_MPanel = 4;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel3_fixed);
            Control Fixed2 = new Control();
            Fixed2.Name = "FixedPanelUC_3";
            _multiTransomModel.MPanelLst_Objects.Add(Fixed2);



            #endregion

            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(805, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(2205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(732, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(2132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(2, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(3520000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(56, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(37, _qouteModel.Screws_for_Installation);

            #region MultiTransom (3)

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel1_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel1_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(728, _panelModel1_fixed.Panel_GlassWidth);
            Assert.AreEqual(525, _panelModel1_fixed.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(742, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(632, _divTransomModel.Div_ReinfWidth);


            #region AwningUC_2




            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(753, _panelModel2_Awning.Panel_SashWidth);
            Assert.AreEqual(947, _panelModel2_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(628, _panelModel2_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(822, _panelModel2_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(753, _panelModel2_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(947, _panelModel2_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(632, _panelModel2_Awning.Panel_GlassWidth);
            Assert.AreEqual(826, _panelModel2_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._16HD, _panelModel2_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel2_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel2_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773451, _panelModel2_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel2_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel2_Awning.Panel_MiddleCloserArtNo);


            #endregion

            Assert.AreEqual(Divider_ArticleNo._7538, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(742, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(632, _divTransomModel.Div_ReinfWidth);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel3_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel3_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(728, _panelModel3_fixed.Panel_GlassWidth);
            Assert.AreEqual(525, _panelModel3_fixed.Panel_GlassHeight);

            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '805'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '2205'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '2132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '753'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '947'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '628'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '822'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //p1
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '600'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '728'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);
            //p2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '753'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '947'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '826'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);
            #endregion

        }




        [TestMethod]
        public void ChkVar_4Panel_2FixWindow_2Awning()
        {
            /*
                     _________________________________________________
                     |                                                |                  
                     |                       P1                       |      
                     |                                                |  
                     |________________________________________________|
                     |       /\       |              |       /\       |   
                     |      /  \      |              |      /  \      |
                     |     /    \     |              |     /    \     |
                     |    /      \    |              |    /      \    |
                     |   /   P2   \   |      P3      |   /   P4   \   |
                     |  /          \  |              |  /          \  |
                     | /            \ |              | /            \ |
                     |/______________\|______________|/______________\|   
          */

            int total_wd = 3000, total_ht = 1700,
             PnlWidth1_Fix = 3000, PnlHeight1_Fix = 500,
             EqualPnlWidth = 1000, PnlEqualHeight = 1200;



            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiTransomModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.TopDown,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiTransomModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel);
            Control multiTransom = new Control();
            multiTransom.Name = _multiTransomModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiTransomModel.MPanel_Divisions + 1;
            int suggest_Wd = ((_multiTransomModel.MPanel_Width - (divSize * _multiTransomModel.MPanel_Divisions)) / multiTransom_totalPanelCount),
                suggest_HT = _multiTransomModel.MPanel_Height;

            #region MultiTransomPlatform(2)

            IPanelModel _panelModel1_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                            suggest_HT,
                                                                            new Control(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            "Fixed Panel",
                                                                            true,
                                                                            1.0f,
                                                                            _frameModel,
                                                                            _multiTransomModel,
                                                                            PnlWidth1_Fix,
                                                                            PnlHeight1_Fix,
                                                                            GlazingBead_ArticleNo._2453,
                                                                            GlassFilm_Types._None,
                                                                            SashProfile_ArticleNo._None,
                                                                            SashReinf_ArticleNo._None,
                                                                            GlassType._Single,
                                                                            Espagnolette_ArticleNo._None,
                                                                            Striker_ArticleNo._M89ANTA,
                                                                            MiddleCloser_ArticleNo._None,
                                                                            LockingKit_ArticleNo._None,
                                                                            MotorizedMech_ArticleNo._41555B,
                                                                            Handle_Type._Rotoswing,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            Rotoswing_HandleArtNo._RSC773451,
                                                                            GeorgianBar_ArticleNo._None,
                                                                            0,
                                                                            0,
                                                                            false,
                                                                            1);
            _panelModel1_fixed.Panel_Placement = "First";
            _panelModel1_fixed.Panel_GlassThickness = 14.0f;
            _panelModel1_fixed.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel1_fixed);
            Control Fixed1 = new Control();
            Fixed1.Name = "FixedPanelUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(Fixed1);


            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(_multiTransomModel.MPanel_Width,
                                                                           divSize,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Transom,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7538,
                                                                           _multiTransomModel.MPanel_DisplayWidth,
                                                                           _multiTransomModel.MPanel_DisplayHeight,
                                                                           _multiTransomModel,
                                                                           _frameModel,
                                                                           1,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "TransomUC_1",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiTransomModel.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(div_Transom);




            IMultiPanelModel _multiMullionModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          total_wd,
                                                                                          PnlEqualHeight,
                                                                                          multiTransom,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          2,
                                                                                          DockStyle.None,
                                                                                          1,
                                                                                          0,
                                                                                          _multiTransomModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          3);
            _multiMullionModel1.MPanel_Placement = "Last";
            _multiMullionModel1.MPanel_Index_Inside_MPanel = 2;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            _multiTransomModel.MPanelLst_MultiPanel.Add(_multiMullionModel1);
            Control multiMullion2 = new Control();
            multiMullion2.Name = "MultiMullion_2";
            _multiTransomModel.MPanelLst_Objects.Add(multiMullion2);

            #endregion

            #region MultiMullionPlatform (3)
            int multiMullion_totalPanelCount = _multiMullionModel1.MPanel_Divisions + 1;
            int multiMullion_suggest_Wd = (((_multiMullionModel1.MPanel_Width) - (divSize * _multiMullionModel1.MPanel_Divisions)) / multiMullion_totalPanelCount),
                multiMullion_suggest_HT = _multiMullionModel1.MPanel_Height;


            IPanelModel _panelModel2_Awning = _panelServices.AddPanelModel(multiMullion_suggest_Wd,
                                                                           multiMullion_suggest_HT,
                                                                            new Control(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            "Awning Panel",
                                                                            true,
                                                                            1.0f,
                                                                            _frameModel,
                                                                            _multiMullionModel1,
                                                                            EqualPnlWidth,
                                                                            PnlEqualHeight,
                                                                            GlazingBead_ArticleNo._2453,
                                                                            GlassFilm_Types._None,
                                                                            SashProfile_ArticleNo._7581,
                                                                            SashReinf_ArticleNo._R675,
                                                                            GlassType._Single,
                                                                            Espagnolette_ArticleNo._628809,
                                                                            Striker_ArticleNo._M89ANTA,
                                                                            MiddleCloser_ArticleNo._1WC70DB,
                                                                            LockingKit_ArticleNo._None,
                                                                            MotorizedMech_ArticleNo._41555B,
                                                                            Handle_Type._Rotoswing,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            Rotoswing_HandleArtNo._RSC773451,
                                                                            GeorgianBar_ArticleNo._None,
                                                                            0,
                                                                            0,
                                                                            false,
                                                                            2);
            _panelModel2_Awning.Panel_Placement = "First";
            _panelModel2_Awning.Panel_GlassThickness = 14.0f;
            _panelModel2_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC833307;
            _panelModel2_Awning.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel2_Awning);
            Control Awning = new Control();
            Awning.Name = "AwningPanelUC_2";
            _multiMullionModel1.MPanelLst_Objects.Add(Awning);



            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel1.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiMullionModel1.MPanel_DisplayWidth,
                                                                             _multiMullionModel1.MPanel_DisplayHeight,
                                                                             _multiMullionModel1,
                                                                             _frameModel,
                                                                             2,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_2",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel1.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_2";
            _multiMullionModel1.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel3_fixed = _panelServices.AddPanelModel(multiMullion_suggest_Wd,
                                                                            multiMullion_suggest_HT,
                                                                            new Control(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            "Fixed Panel",
                                                                            true,
                                                                            1.0f,
                                                                            _frameModel,
                                                                            _multiMullionModel1,
                                                                            EqualPnlWidth,
                                                                            PnlEqualHeight,
                                                                            GlazingBead_ArticleNo._2453,
                                                                            GlassFilm_Types._None,
                                                                            SashProfile_ArticleNo._None,
                                                                            SashReinf_ArticleNo._None,
                                                                            GlassType._Single,
                                                                            Espagnolette_ArticleNo._None,
                                                                            Striker_ArticleNo._M89ANTA,
                                                                            MiddleCloser_ArticleNo._None,
                                                                            LockingKit_ArticleNo._None,
                                                                            MotorizedMech_ArticleNo._41555B,
                                                                            Handle_Type._Rotoswing,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            Rotoswing_HandleArtNo._RSC773451,
                                                                            GeorgianBar_ArticleNo._None,
                                                                            0,
                                                                            0,
                                                                            false,
                                                                            3);
            _panelModel3_fixed.Panel_Placement = "Somewhere in Between";
            _panelModel3_fixed.Panel_GlassThickness = 14.0f;
            _panelModel3_fixed.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel3_fixed);
            Control Fixed2 = new Control();
            Fixed2.Name = "FixedPanelUC_3";
            _multiMullionModel1.MPanelLst_Objects.Add(Fixed2);




            IDividerModel _divMullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel1.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiMullionModel1.MPanel_DisplayWidth,
                                                                             _multiMullionModel1.MPanel_DisplayHeight,
                                                                             _multiMullionModel1,
                                                                             _frameModel,
                                                                             3,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_3",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel1.MPanelLst_Divider.Add(_divMullionModel2);
            Control div_Mullion2 = new Control();
            div_Mullion2.Name = "MullionUC_3";
            _multiMullionModel1.MPanelLst_Objects.Add(div_Mullion2);




            IPanelModel _panelModel4_Awning = _panelServices.AddPanelModel(multiMullion_suggest_Wd,
                                                                           multiMullion_suggest_HT,
                                                                            new Control(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            new UserControl(),
                                                                            "Awning Panel",
                                                                            true,
                                                                            1.0f,
                                                                            _frameModel,
                                                                            _multiMullionModel1,
                                                                            EqualPnlWidth,
                                                                            PnlEqualHeight,
                                                                            GlazingBead_ArticleNo._2453,
                                                                            GlassFilm_Types._None,
                                                                            SashProfile_ArticleNo._7581,
                                                                            SashReinf_ArticleNo._R675,
                                                                            GlassType._Single,
                                                                            Espagnolette_ArticleNo._628809,
                                                                            Striker_ArticleNo._M89ANTA,
                                                                            MiddleCloser_ArticleNo._1WC70DB,
                                                                            LockingKit_ArticleNo._None,
                                                                            MotorizedMech_ArticleNo._41555B,
                                                                            Handle_Type._Rotoswing,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            Extension_ArticleNo._None,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            false,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            Rotoswing_HandleArtNo._RSC773451,
                                                                            GeorgianBar_ArticleNo._None,
                                                                            0,
                                                                            0,
                                                                            false,
                                                                            4);
            _panelModel4_Awning.Panel_Placement = "Last";
            _panelModel4_Awning.Panel_GlassThickness = 14.0f;
            _panelModel4_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC833307;
            _panelModel4_Awning.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel4_Awning);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_4";
            _multiMullionModel1.MPanelLst_Objects.Add(Awning2);


            #endregion

            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(3005, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1705, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2932, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1632, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(19860, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(2, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(10200000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(14, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(56, _qouteModel.Rebate_Qty);
            Assert.AreEqual(115, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(77, _qouteModel.Screws_for_Installation);



            #region MultiTransom(2)

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(3000, _panelModel1_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(500, _panelModel1_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(2928, _panelModel1_fixed.Panel_GlassWidth);
            Assert.AreEqual(425, _panelModel1_fixed.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(2942, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(2832, _divTransomModel.Div_ReinfWidth);

            //multiMullion(3)

            #endregion

            #region MultiMullion(3)

            #region AwningUC_2

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(965, _panelModel2_Awning.Panel_SashWidth);
            Assert.AreEqual(1150, _panelModel2_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(840, _panelModel2_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1025, _panelModel2_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(965, _panelModel2_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1150, _panelModel2_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(844, _panelModel2_Awning.Panel_GlassWidth);
            Assert.AreEqual(1029, _panelModel2_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel2_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel2_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628809, _panelModel2_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel2_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel2_Awning.Panel_MiddleCloserArtNo);

            #endregion

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1134, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1054, _divMullionModel.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel3_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(1000, _panelModel3_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(1200, _panelModel3_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(952, _panelModel3_fixed.Panel_GlassWidth);
            Assert.AreEqual(1125, _panelModel3_fixed.Panel_GlassHeight);


            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1134, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1054, _divMullionModel.Div_ReinfHeight);

            #region AwningUC_4

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel4_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(965, _panelModel4_Awning.Panel_SashWidth);
            Assert.AreEqual(1150, _panelModel4_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel4_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(840, _panelModel4_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1025, _panelModel4_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel4_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(965, _panelModel4_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1150, _panelModel4_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(844, _panelModel4_Awning.Panel_GlassWidth);
            Assert.AreEqual(1029, _panelModel4_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel4_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel4_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel4_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel4_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628809, _panelModel4_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel4_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel4_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel4_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel4_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel4_Awning.Panel_MiddleCloserArtNo);

            #endregion

            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '3005'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1705'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2932'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '965'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1150'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '840'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1025'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            //p1
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '3000'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '2928'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            //p2
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '965'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(4, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1150'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '844'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1029'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            //P3
            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2453%' AND
                             Size = '1000'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2453%' AND
                             Size = '1200'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '952'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1125'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            #endregion


        }


        //Motorize Awning


        [TestMethod]
        public void ChkVar_SinglePanelMotorizeAwningWindow()
        {
            /*
                         Motorize
                    __________________
                    |       /\       |
                    |      /  \      | 
                    |     /    \     |         
                    |    /      \    |   
                    |   /   P1   \   |   
                    |  /          \  |          
                    | /            \ |             
                    |/______________\|
              */

            int total_wd = 1000, total_height = 500;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._DarkBrown, Foil_Color._CharcoalGray, Foil_Color._CharcoalGray);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
                                                                   ht,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Awning Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   null,
                                                                   total_wd,
                                                                   total_height,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._628807,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._1WC70DB,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel.Panel_GlassThickness = 6.0f;
            _panelModel.Panel_MotorizedOptionVisibility = true;
            _frameModel.Lst_Panel.Add(_panelModel);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1005, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(505, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(904, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(404, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(1, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(1000000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(5, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(20, _qouteModel.Rebate_Qty);
            Assert.AreEqual(22, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(33, _qouteModel.Screws_for_Installation);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(925, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(425, _panelModel.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel.Panel_SashProfileArtNo);
            Assert.AreEqual(425, _panelModel.Panel_SashHeight);
            Assert.AreEqual(925, _panelModel.Panel_SashWidth);
            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel.Panel_SashReinfArtNo);
            Assert.AreEqual(800, _panelModel.Panel_SashReinfWidth);
            Assert.AreEqual(300, _panelModel.Panel_SashReinfHeight);

            Assert.AreEqual(804, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(304, _panelModel.Panel_GlassHeight);


            //ACCESSORIES & HARWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel.Panel_CoverProfileArtNo2);
            Assert.AreEqual(MotorizedMech_ArticleNo._41555B, _panelModel.Panel_MotorizedMechArtNo);



            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1005'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '904'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '925'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '300'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '925'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '804'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '304'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            // ACCESSORIES AND HARDWARE

            dr = dt.Select(@"Description LIKE '%30X25 Cover %' AND
                            Description LIKE '%1067 - MILLED%' AND
                             Size = '1000'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Divider%' AND
                            Description LIKE '%0505%' AND
                             Size = '1000'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover for motor%' AND
                            Description LIKE '%1182%' AND
                             Size = '1000'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%2D Hinge%' AND
                            Description LIKE '%614293%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Push Button Switch%' AND
                            Description LIKE '%N4037%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%False pole%' AND
                            Description LIKE '%N4950%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Supporting Frame%' AND
                            Description LIKE '%N4703%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Plate%' AND
                            Description LIKE '%N4803LB%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            #endregion
        }


        [TestMethod]
        public void ChkVar_SinglePanelMotorizeAwningWindow1500x1500()
        {
            /*
                         Motorize
                    __________________
                    |       /\       |
                    |      /  \      | 
                    |     /    \     |         
                    |    /      \    |   
                    |   /   P1   \   |   
                    |  /          \  |          
                    | /            \ |             
                    |/______________\|
              */

            int total_wd = 1500, total_height = 1500;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_height, "C70", 1, Base_Color._DarkBrown, Foil_Color._CharcoalGray, Foil_Color._CharcoalGray);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_height,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IPanelModel _panelModel = _panelServices.AddPanelModel(wd,
                                                                   ht,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Awning Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   null,
                                                                   total_wd,
                                                                   total_height,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._628807,
                                                                   Striker_ArticleNo._M89ANTA,
                                                                   MiddleCloser_ArticleNo._1WC70DB,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1);
            _panelModel.Panel_GlassThickness = 6.0f;
            _panelModel.Panel_MotorizedOptionVisibility = true;
            _frameModel.Lst_Panel.Add(_panelModel);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1404, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1404, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(1, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(4500000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(42, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(63, _qouteModel.Screws_for_Installation);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(1425, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1425, _panelModel.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel.Panel_SashProfileArtNo);
            Assert.AreEqual(1425, _panelModel.Panel_SashHeight);
            Assert.AreEqual(1425, _panelModel.Panel_SashWidth);
            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel.Panel_SashReinfArtNo);
            Assert.AreEqual(1300, _panelModel.Panel_SashReinfWidth);
            Assert.AreEqual(1300, _panelModel.Panel_SashReinfHeight);

            Assert.AreEqual(1304, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1304, _panelModel.Panel_GlassHeight);


            //ACCESSORIES & HARWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel.Panel_CoverProfileArtNo2);
            Assert.AreEqual(MotorizedMech_ArticleNo._41555B, _panelModel.Panel_MotorizedMechArtNo);
            Assert.AreEqual(2, _panelModel.Panel_MotorizedMechQty);



            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '1425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '1300'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1300'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '1425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '1304'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1304'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            // ACCESSORIES AND HARDWARE

            dr = dt.Select(@"Description LIKE '%30X25 Cover %' AND
                            Description LIKE '%1067 - MILLED%' AND
                             Size = '1500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Divider%' AND
                            Description LIKE '%0505%' AND
                             Size = '1500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover for motor%' AND
                            Description LIKE '%1182%' AND
                             Size = '1500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%2D Hinge%' AND
                            Description LIKE '%614293%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Push Button Switch%' AND
                            Description LIKE '%N4037%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%False pole%' AND
                            Description LIKE '%N4950%'");
            Assert.AreEqual("1", dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Supporting Frame%' AND
                            Description LIKE '%N4703%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Plate%' AND
                            Description LIKE '%N4803LB%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            #endregion
        }


        [TestMethod]
        public void ChkVar_2Panel_1FixedWindow_1MotorizeAwningWindow()
        {
            /*
                    __________________
                    |                |
                    |                |
                    |                |
                    |       p1       |
                    |                |
                    |                |    
                    |________________|
                    |       /\       |
                    |      /  \      | 
                    |     /    \     |         
                    |    /      \    |   
                    |   /   P2   \   |   
                    |  /          \  |          
                    | /            \ |             
                    |/______________\|
         */

            int total_wd = 800, total_ht = 900,
            EqualPnlWidth = 800, EqualPnlHeight = 450;



            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiTransomModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.TopDown,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiTransomModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel);
            Control multiTransom = new Control();
            multiTransom.Name = _multiTransomModel.MPanel_Name;


            int divSize = 26;
            int multiTransom_totalPanelCount = _multiTransomModel.MPanel_Divisions + 1;
            int suggest_Wd = ((_multiTransomModel.MPanel_Width - (divSize * _multiTransomModel.MPanel_Divisions)) / multiTransom_totalPanelCount),
                suggest_HT = _multiTransomModel.MPanel_Height;


            #region MultiTransomPlatform(2)

            IPanelModel _panelModel1_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                          suggest_HT,
                                                                          new Control(),
                                                                          new UserControl(),
                                                                          new UserControl(),
                                                                          new UserControl(),
                                                                          "Fixed Panel",
                                                                          true,
                                                                          1.0f,
                                                                          _frameModel,
                                                                          _multiTransomModel,
                                                                          EqualPnlWidth,
                                                                          EqualPnlHeight,
                                                                          GlazingBead_ArticleNo._2453,
                                                                          GlassFilm_Types._None,
                                                                          SashProfile_ArticleNo._None,
                                                                          SashReinf_ArticleNo._None,
                                                                          GlassType._Single,
                                                                          Espagnolette_ArticleNo._None,
                                                                          Striker_ArticleNo._M89ANTA,
                                                                          MiddleCloser_ArticleNo._None,
                                                                          LockingKit_ArticleNo._None,
                                                                          MotorizedMech_ArticleNo._41555B,
                                                                          Handle_Type._Rotoswing,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           Extension_ArticleNo._None,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           Rotoswing_HandleArtNo._RSC773451,
                                                                           GeorgianBar_ArticleNo._None,
                                                                           0,
                                                                           0,
                                                                           false,
                                                                           1);
            _panelModel1_fixed.Panel_Placement = "First";
            _panelModel1_fixed.Panel_GlassThickness = 6.0f;
            _panelModel1_fixed.Panel_Index_Inside_MPanel = 0;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel1_fixed);
            Control Fixed1 = new Control();
            Fixed1.Name = "FixedPanelUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(Fixed1);


            IDividerModel _divTransomModel = _dividerServices.AddDividerModel(_multiTransomModel.MPanel_Width,
                                                                           divSize,
                                                                           new Control(),
                                                                           DividerModel.DividerType.Transom,
                                                                           true,
                                                                           _frameModel.Frame_Zoom,
                                                                           Divider_ArticleNo._7536,
                                                                           _multiTransomModel.MPanel_DisplayWidth,
                                                                           _multiTransomModel.MPanel_DisplayHeight,
                                                                           _multiTransomModel,
                                                                           _frameModel,
                                                                           1,
                                                                           _frameModel.FrameImageRenderer_Zoom,
                                                                           _frameModel.Frame_Type.ToString(),
                                                                           "TransomUC_1",
                                                                           null,
                                                                           false,
                                                                           true,
                                                                           null);
            _multiTransomModel.MPanelLst_Divider.Add(_divTransomModel);
            Control div_Transom = new Control();
            div_Transom.Name = "TransomUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(div_Transom);




            IPanelModel _panelModel2_MotorizeAwning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                   suggest_HT,
                                                                                   new Control(),
                                                                                   new UserControl(),
                                                                                   new UserControl(),
                                                                                   new UserControl(),
                                                                                   "Awning Panel",
                                                                                   true,
                                                                                   1.0f,
                                                                                   _frameModel,
                                                                                    _multiTransomModel,
                                                                                   EqualPnlWidth,
                                                                                   EqualPnlHeight,
                                                                                   GlazingBead_ArticleNo._2453,
                                                                                   GlassFilm_Types._None,
                                                                                   SashProfile_ArticleNo._7581,
                                                                                   SashReinf_ArticleNo._R675,
                                                                                   GlassType._Single,
                                                                                   Espagnolette_ArticleNo._628809,
                                                                                   Striker_ArticleNo._M89ANTA,
                                                                                   MiddleCloser_ArticleNo._1WC70DB,
                                                                                   LockingKit_ArticleNo._None,
                                                                                   MotorizedMech_ArticleNo._41556C,
                                                                                   Handle_Type._Rotoswing,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   Extension_ArticleNo._None,
                                                                                   false,
                                                                                   false,
                                                                                   false,
                                                                                   false,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   0,
                                                                                   Rotoswing_HandleArtNo._RSC773451,
                                                                                   GeorgianBar_ArticleNo._None,
                                                                                   0,
                                                                                   0,
                                                                                   false,
                                                                                   2);
            _panelModel2_MotorizeAwning.Panel_Placement = "Last";
            _panelModel2_MotorizeAwning.Panel_MotorizedOptionVisibility = true;
            _panelModel2_MotorizeAwning.Panel_GlassThickness = 6.0f;
            _panelModel2_MotorizeAwning.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel.MPanelLst_Panel.Add(_panelModel2_MotorizeAwning);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_2";
            _multiTransomModel.MPanelLst_Objects.Add(Awning2);

            #endregion

            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(805, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(905, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(732, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(832, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(1, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(1440000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(5, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(20, _qouteModel.Rebate_Qty);
            Assert.AreEqual(25, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(36, _qouteModel.Screws_for_Installation);



            #region MultiTransom(2)


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel1_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(450, _panelModel1_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(728, _panelModel1_fixed.Panel_GlassWidth);
            Assert.AreEqual(390, _panelModel1_fixed.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7536, _divTransomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divTransomModel.Div_ReinfArtNo);
            Assert.AreEqual(737, _divTransomModel.Div_ExplosionWidth);
            Assert.AreEqual(657, _divTransomModel.Div_ReinfWidth);


            #region AwningUC_2

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2_MotorizeAwning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(753, _panelModel2_MotorizeAwning.Panel_GlazingBeadWidth);
            Assert.AreEqual(415, _panelModel2_MotorizeAwning.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2_MotorizeAwning.Panel_SashProfileArtNo);
            Assert.AreEqual(415, _panelModel2_MotorizeAwning.Panel_SashHeight);
            Assert.AreEqual(753, _panelModel2_MotorizeAwning.Panel_SashWidth);
            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2_MotorizeAwning.Panel_SashReinfArtNo);
            Assert.AreEqual(628, _panelModel2_MotorizeAwning.Panel_SashReinfWidth);
            Assert.AreEqual(290, _panelModel2_MotorizeAwning.Panel_SashReinfHeight);

            Assert.AreEqual(632, _panelModel2_MotorizeAwning.Panel_GlassWidth);
            Assert.AreEqual(294, _panelModel2_MotorizeAwning.Panel_GlassHeight);


            //ACCESSORIES & HARWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2_MotorizeAwning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2_MotorizeAwning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(MotorizedMech_ArticleNo._41556C, _panelModel2_MotorizeAwning.Panel_MotorizedMechArtNo);


            #endregion





            #endregion



            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '805'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '905'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '832'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '753'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '415'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '628'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '290'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            //p1

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '800'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '450'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '728'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '390'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            //p2

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '753'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '415'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '294'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            //ACCESSORIES AND HARDWARE  

            dr = dt.Select(@"Description LIKE '%30X25 Cover%' AND
                            Description LIKE '%1067 - MILLED%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Divider%' AND
                             Description LIKE '%0505%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover for motor%' AND
                            Description LIKE '%1182%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%2D Hinge%' AND
                            Description LIKE '%614293%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Push Button Switch%' AND
                            Description LIKE '%N4037%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%False pole%' AND
                            Description LIKE '%N4950%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Supporting Frame%' AND
                            Description LIKE '%N4703%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Plate%' AND
                            Description LIKE '%N4803LB%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            #endregion

        }

        //GlassBalancingAwning


        [TestMethod]
        public void ChkVar_3Panel_3AwningWindow()
        {
            /*
                        ____________________________________________________
                        |       /\       |       /\       |       /\       |
                        |      /  \      |      /  \      |      /  \      |
                        |     /    \     |     /    \     |     /    \     |
                        |    /      \    |    /      \    |    /      \    |
                        |   /        \   |   /        \   |   /        \   |
                        |  /          \  |  /          \  |  /          \  |
                        | /            \ | /            \ | /            \ |
                        |/______________\|/______________\|/______________\|

             */



            int total_wd = 2100, total_ht = 1800,
                AwningWD1 = 704, AwningHT1 = 1800,
                AwningWD2 = 692, AwningHT2 = 1800;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         3);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount1 = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount1);


            #region MultiMullionPlatform(3)

            IPanelModel _panelModel1_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                suggest_HT,
                                                                                new Control(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                "Awning Panel",
                                                                                true,
                                                                                1.0f,
                                                                                _frameModel,
                                                                                 _multiMullionModel,
                                                                                AwningWD1,
                                                                                AwningHT1,
                                                                                GlazingBead_ArticleNo._2435,
                                                                                GlassFilm_Types._None,
                                                                                SashProfile_ArticleNo._7581,
                                                                                SashReinf_ArticleNo._R675,
                                                                                GlassType._Single,
                                                                                Espagnolette_ArticleNo._628807,
                                                                                Striker_ArticleNo._M89ANTA,
                                                                                MiddleCloser_ArticleNo._1WC70WHT,
                                                                                LockingKit_ArticleNo._None,
                                                                                MotorizedMech_ArticleNo._41556C,
                                                                                Handle_Type._Rotoswing,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                Rotoswing_HandleArtNo._RSC773451,
                                                                                GeorgianBar_ArticleNo._None,
                                                                                0,
                                                                                0,
                                                                                false,
                                                                                1);
            _panelModel1_Awning.Panel_Placement = "First";
            _panelModel1_Awning.Panel_GlassThickness = 24.0f;
            _panelModel1_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC833307;
            _panelModel1_Awning.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1_Awning);
            Control Awning1 = new Control();
            Awning1.Name = "AwningPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Awning1);



            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiMullionModel.MPanel_DisplayWidth,
                                                                             _multiMullionModel.MPanel_DisplayHeight,
                                                                             _multiMullionModel,
                                                                             _frameModel,
                                                                             1,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_1",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);




            IPanelModel _panelModel2_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                suggest_HT,
                                                                                new Control(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                "Awning Panel",
                                                                                true,
                                                                                1.0f,
                                                                                _frameModel,
                                                                                 _multiMullionModel,
                                                                                AwningWD2,
                                                                                AwningHT2,
                                                                                GlazingBead_ArticleNo._2435,
                                                                                GlassFilm_Types._None,
                                                                                SashProfile_ArticleNo._7581,
                                                                                SashReinf_ArticleNo._R675,
                                                                                GlassType._Single,
                                                                                Espagnolette_ArticleNo._628807,
                                                                                Striker_ArticleNo._M89ANTA,
                                                                                MiddleCloser_ArticleNo._1WC70WHT,
                                                                                LockingKit_ArticleNo._None,
                                                                                MotorizedMech_ArticleNo._41556C,
                                                                                Handle_Type._Rotoswing,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                Rotoswing_HandleArtNo._RSC773451,
                                                                                GeorgianBar_ArticleNo._None,
                                                                                0,
                                                                                0,
                                                                                false,
                                                                                2);
            _panelModel2_Awning.Panel_Placement = "Somewhere in Between";
            _panelModel2_Awning.Panel_GlassThickness = 24.0f;
            _panelModel2_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC833307;
            _panelModel2_Awning.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2_Awning);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Awning2);



            IDividerModel _divMullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiMullionModel.MPanel_DisplayWidth,
                                                                             _multiMullionModel.MPanel_DisplayHeight,
                                                                             _multiMullionModel,
                                                                             _frameModel,
                                                                             2,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_2",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel2);
            Control div_Mullion2 = new Control();
            div_Mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion2);




            IPanelModel _panelModel3_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                suggest_HT,
                                                                                new Control(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                "Awning Panel",
                                                                                true,
                                                                                1.0f,
                                                                                _frameModel,
                                                                                 _multiMullionModel,
                                                                                AwningWD1,
                                                                                AwningHT1,
                                                                                GlazingBead_ArticleNo._2435,
                                                                                GlassFilm_Types._None,
                                                                                SashProfile_ArticleNo._7581,
                                                                                SashReinf_ArticleNo._R675,
                                                                                GlassType._Single,
                                                                                Espagnolette_ArticleNo._628807,
                                                                                Striker_ArticleNo._M89ANTA,
                                                                                MiddleCloser_ArticleNo._1WC70WHT,
                                                                                LockingKit_ArticleNo._None,
                                                                                MotorizedMech_ArticleNo._41556C,
                                                                                Handle_Type._Rotoswing,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                Rotoswing_HandleArtNo._RSC773451,
                                                                                GeorgianBar_ArticleNo._None,
                                                                                0,
                                                                                0,
                                                                                false,
                                                                                3);
            _panelModel3_Awning.Panel_Placement = "Last";
            _panelModel3_Awning.Panel_GlassThickness = 24.0f;
            _panelModel3_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC833307;
            _panelModel3_Awning.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel3_Awning);
            Control Awning3 = new Control();
            Awning3.Name = "AwningPanelUC_3";
            _multiMullionModel.MPanelLst_Objects.Add(Awning3);
            #endregion



            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2105, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1805, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2032, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1732, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(14532, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(7560000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(12, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(48, _qouteModel.Rebate_Qty);
            Assert.AreEqual(171, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(87, _qouteModel.Screws_for_Installation);



            #region MultiMullion(3)

            #region AwningUC_1

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(669, _panelModel1_Awning.Panel_SashWidth);
            Assert.AreEqual(1753, _panelModel1_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(544, _panelModel1_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1628, _panelModel1_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel1_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(669, _panelModel1_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1753, _panelModel1_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(548, _panelModel1_Awning.Panel_GlassWidth);
            Assert.AreEqual(1632, _panelModel1_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm26, _panelModel1_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(4, _panelModel1_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel1_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel1_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1_Awning.Panel_MiddleCloserArtNo);

            #endregion

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1737, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1657, _divMullionModel.Div_ReinfHeight);

            #region AwningUC_2

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(669, _panelModel1_Awning.Panel_SashWidth);
            Assert.AreEqual(1753, _panelModel1_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(544, _panelModel1_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1628, _panelModel1_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel1_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(669, _panelModel1_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1753, _panelModel1_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(548, _panelModel1_Awning.Panel_GlassWidth);
            Assert.AreEqual(1632, _panelModel1_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm26, _panelModel1_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(4, _panelModel1_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel1_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel1_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1_Awning.Panel_MiddleCloserArtNo);

            #endregion

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1737, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1657, _divMullionModel.Div_ReinfHeight);

            #region AwningUC_3


            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(669, _panelModel1_Awning.Panel_SashWidth);
            Assert.AreEqual(1753, _panelModel1_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(544, _panelModel1_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(1628, _panelModel1_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel1_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(669, _panelModel1_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1753, _panelModel1_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(548, _panelModel1_Awning.Panel_GlassWidth);
            Assert.AreEqual(1632, _panelModel1_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm26, _panelModel1_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(4, _panelModel1_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628807, _panelModel1_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel1_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1_Awning.Panel_MiddleCloserArtNo);
            #endregion


            #endregion


            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '2105'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1805'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2032'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '669'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1753'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '544'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1628'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2435%' AND
                             Size = '669'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2435%' AND
                             Size = '1753'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '548'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_6Panel_3FixedWindow_3AwningWindow()
        {

            /*

             ______________________________________________________________________________________________________
             |       /\       |                |       /\       |                |       /\       |                |
             |      /  \      |                |      /  \      |                |      /  \      |                | 
             |     /    \     |                |     /    \     |                |     /    \     |                |         
             |    /      \    |                |    /      \    |                |    /      \    |                |   
             |   /   P1   \   |       P2       |   /   P3   \   |       P4       |   /   P5   \   |       P6       |   
             |  /          \  |                |  /          \  |                |  /          \  |                |          
             | /            \ |                | /            \ |                | /            \ |                |             
             |/______________\|________________|/______________\|________________|/______________\|________________|
      
                  
          */



            int total_wd = 3000, total_ht = 1100,
                BalanceAwningWD1 = 508, AwningHT1 = 1100,
                BalanceAwningWD3 = 496, AwningHT3 = 1100,
                BalanceFixedWD2 = 496, FixedHT2 = 1100,
                BalanceFixedWD6 = 508, FixedHT6 = 1100;


            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._Ivory, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         6);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount1 = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount1);


            #region MultiMullionPlatform(6)

            IPanelModel _panelModel1_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                                suggest_HT,
                                                                                new Control(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                new UserControl(),
                                                                                "Awning Panel",
                                                                                true,
                                                                                1.0f,
                                                                                _frameModel,
                                                                                 _multiMullionModel,
                                                                                BalanceAwningWD1,
                                                                                AwningHT1,
                                                                                GlazingBead_ArticleNo._2452,
                                                                                GlassFilm_Types._None,
                                                                                SashProfile_ArticleNo._7581,
                                                                                SashReinf_ArticleNo._R675,
                                                                                GlassType._Single,
                                                                                Espagnolette_ArticleNo._628806,
                                                                                Striker_ArticleNo._M89ANTA,
                                                                                MiddleCloser_ArticleNo._1WC70DB,
                                                                                LockingKit_ArticleNo._None,
                                                                                MotorizedMech_ArticleNo._41556C,
                                                                                Handle_Type._Rotoswing,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                Extension_ArticleNo._None,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                false,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                Rotoswing_HandleArtNo._RSC773451,
                                                                                GeorgianBar_ArticleNo._None,
                                                                                0,
                                                                                0,
                                                                                false,
                                                                                1);
            _panelModel1_Awning.Panel_Placement = "First";
            _panelModel1_Awning.Panel_GlassThickness = 6.0f;
            _panelModel1_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC773452;
            _panelModel1_Awning.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1_Awning);
            Control Awning1 = new Control();
            Awning1.Name = "AwningPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Awning1);





            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                             _multiMullionModel.MPanel_Height,
                                                                             new Control(),
                                                                             DividerModel.DividerType.Mullion,
                                                                             true,
                                                                             _frameModel.Frame_Zoom,
                                                                             Divider_ArticleNo._7536,
                                                                             _multiMullionModel.MPanel_DisplayWidth,
                                                                             _multiMullionModel.MPanel_DisplayHeight,
                                                                             _multiMullionModel,
                                                                             _frameModel,
                                                                             1,
                                                                             _frameModel.FrameImageRenderer_Zoom,
                                                                             _frameModel.Frame_Type.ToString(),
                                                                             "MullionUC_1",
                                                                             null,
                                                                             false,
                                                                             true,
                                                                             null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel2_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                          suggest_HT,
                                                                          new Control(),
                                                                          new UserControl(),
                                                                          new UserControl(),
                                                                          new UserControl(),
                                                                          "Fixed Panel",
                                                                          true,
                                                                          1.0f,
                                                                          _frameModel,
                                                                          _multiMullionModel,
                                                                          BalanceFixedWD2,
                                                                          FixedHT2,
                                                                          GlazingBead_ArticleNo._2452,
                                                                          GlassFilm_Types._None,
                                                                          SashProfile_ArticleNo._None,
                                                                          SashReinf_ArticleNo._None,
                                                                          GlassType._Single,
                                                                          Espagnolette_ArticleNo._None,
                                                                          Striker_ArticleNo._M89ANTA,
                                                                          MiddleCloser_ArticleNo._None,
                                                                          LockingKit_ArticleNo._None,
                                                                          MotorizedMech_ArticleNo._41555B,
                                                                          Handle_Type._Rotoswing,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          Extension_ArticleNo._None,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          false,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          Rotoswing_HandleArtNo._RSC773451,
                                                                          GeorgianBar_ArticleNo._None,
                                                                          0,
                                                                          0,
                                                                          false,
                                                                          2);
            _panelModel2_fixed.Panel_Placement = "Somewhere in Between";
            _panelModel2_fixed.Panel_GlassThickness = 6.0f;
            _panelModel2_fixed.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2_fixed);
            Control Fixed1 = new Control();
            Fixed1.Name = "FixedPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Fixed1);



            IDividerModel _divMullionModel2 = _dividerServices.AddDividerModel(divSize,
                                                                            _multiMullionModel.MPanel_Height,
                                                                            new Control(),
                                                                            DividerModel.DividerType.Mullion,
                                                                            true,
                                                                            _frameModel.Frame_Zoom,
                                                                            Divider_ArticleNo._7536,
                                                                            _multiMullionModel.MPanel_DisplayWidth,
                                                                            _multiMullionModel.MPanel_DisplayHeight,
                                                                            _multiMullionModel,
                                                                            _frameModel,
                                                                            2,
                                                                            _frameModel.FrameImageRenderer_Zoom,
                                                                            _frameModel.Frame_Type.ToString(),
                                                                            "MullionUC_2",
                                                                            null,
                                                                            false,
                                                                            true,
                                                                            null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel2);
            Control div_Mullion2 = new Control();
            div_Mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion2);


            IPanelModel _panelModel3_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                               suggest_HT,
                                                                               new Control(),
                                                                               new UserControl(),
                                                                               new UserControl(),
                                                                               new UserControl(),
                                                                               "Awning Panel",
                                                                               true,
                                                                               1.0f,
                                                                               _frameModel,
                                                                                _multiMullionModel,
                                                                               BalanceAwningWD3,
                                                                               AwningHT3,
                                                                               GlazingBead_ArticleNo._2452,
                                                                               GlassFilm_Types._None,
                                                                               SashProfile_ArticleNo._7581,
                                                                               SashReinf_ArticleNo._R675,
                                                                               GlassType._Single,
                                                                               Espagnolette_ArticleNo._628806,
                                                                               Striker_ArticleNo._M89ANTA,
                                                                               MiddleCloser_ArticleNo._1WC70DB,
                                                                               LockingKit_ArticleNo._None,
                                                                               MotorizedMech_ArticleNo._41556C,
                                                                               Handle_Type._Rotoswing,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               Rotoswing_HandleArtNo._RSC773451,
                                                                               GeorgianBar_ArticleNo._None,
                                                                               0,
                                                                               0,
                                                                               false,
                                                                               3);
            _panelModel3_Awning.Panel_Placement = "Somewhere in Between";
            _panelModel3_Awning.Panel_GlassThickness = 6.0f;
            _panelModel3_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC773452;
            _panelModel3_Awning.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel3_Awning);
            Control Awning2 = new Control();
            Awning2.Name = "AwningPanelUC_3";
            _multiMullionModel.MPanelLst_Objects.Add(Awning2);


            IDividerModel _divMullionModel3 = _dividerServices.AddDividerModel(divSize,
                                                                      _multiMullionModel.MPanel_Height,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Mullion,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7536,
                                                                      _multiMullionModel.MPanel_DisplayWidth,
                                                                      _multiMullionModel.MPanel_DisplayHeight,
                                                                      _multiMullionModel,
                                                                      _frameModel,
                                                                      3,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString(),
                                                                      "MullionUC_3",
                                                                      null,
                                                                      false,
                                                                      true,
                                                                      null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel3);
            Control div_Mullion3 = new Control();
            div_Mullion3.Name = "MullionUC_3";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion3);



            IPanelModel _panelModel4_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                 suggest_HT,
                                                                 new Control(),
                                                                 new UserControl(),
                                                                 new UserControl(),
                                                                 new UserControl(),
                                                                 "Fixed Panel",
                                                                 true,
                                                                 1.0f,
                                                                 _frameModel,
                                                                 _multiMullionModel,
                                                                 BalanceFixedWD2,
                                                                 FixedHT2,
                                                                 GlazingBead_ArticleNo._2452,
                                                                 GlassFilm_Types._None,
                                                                 SashProfile_ArticleNo._None,
                                                                 SashReinf_ArticleNo._None,
                                                                 GlassType._Single,
                                                                 Espagnolette_ArticleNo._None,
                                                                 Striker_ArticleNo._M89ANTA,
                                                                 MiddleCloser_ArticleNo._None,
                                                                 LockingKit_ArticleNo._None,
                                                                 MotorizedMech_ArticleNo._41555B,
                                                                 Handle_Type._Rotoswing,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 Extension_ArticleNo._None,
                                                                 false,
                                                                 false,
                                                                 false,
                                                                 false,
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 Rotoswing_HandleArtNo._RSC773451,
                                                                 GeorgianBar_ArticleNo._None,
                                                                 0,
                                                                 0,
                                                                 false,
                                                                 4);
            _panelModel4_fixed.Panel_Placement = "Somewhere in Between";
            _panelModel4_fixed.Panel_GlassThickness = 6.0f;
            _panelModel4_fixed.Panel_Index_Inside_MPanel = 6;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel4_fixed);
            Control Fixed2 = new Control();
            Fixed2.Name = "FixedPanelUC_4";
            _multiMullionModel.MPanelLst_Objects.Add(Fixed2);



            IDividerModel _divMullionModel4 = _dividerServices.AddDividerModel(divSize,
                                                                            _multiMullionModel.MPanel_Height,
                                                                            new Control(),
                                                                            DividerModel.DividerType.Mullion,
                                                                            true,
                                                                            _frameModel.Frame_Zoom,
                                                                            Divider_ArticleNo._7536,
                                                                            _multiMullionModel.MPanel_DisplayWidth,
                                                                            _multiMullionModel.MPanel_DisplayHeight,
                                                                            _multiMullionModel,
                                                                            _frameModel,
                                                                            4,
                                                                            _frameModel.FrameImageRenderer_Zoom,
                                                                            _frameModel.Frame_Type.ToString(),
                                                                            "MullionUC_4",
                                                                            null,
                                                                            false,
                                                                            true,
                                                                            null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel4);
            Control div_Mullion4 = new Control();
            div_Mullion4.Name = "MullionUC_4";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion4);


            IPanelModel _panelModel5_Awning = _panelServices.AddPanelModel(suggest_Wd,
                                                                              suggest_HT,
                                                                              new Control(),
                                                                              new UserControl(),
                                                                              new UserControl(),
                                                                              new UserControl(),
                                                                              "Awning Panel",
                                                                              true,
                                                                              1.0f,
                                                                              _frameModel,
                                                                               _multiMullionModel,
                                                                              BalanceAwningWD3,
                                                                              AwningHT3,
                                                                              GlazingBead_ArticleNo._2452,
                                                                              GlassFilm_Types._None,
                                                                              SashProfile_ArticleNo._7581,
                                                                              SashReinf_ArticleNo._R675,
                                                                              GlassType._Single,
                                                                              Espagnolette_ArticleNo._628806,
                                                                              Striker_ArticleNo._M89ANTA,
                                                                              MiddleCloser_ArticleNo._1WC70DB,
                                                                              LockingKit_ArticleNo._None,
                                                                              MotorizedMech_ArticleNo._41556C,
                                                                              Handle_Type._Rotoswing,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              Extension_ArticleNo._None,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              false,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              Rotoswing_HandleArtNo._RSC773451,
                                                                              GeorgianBar_ArticleNo._None,
                                                                              0,
                                                                              0,
                                                                              false,
                                                                              5);
            _panelModel5_Awning.Panel_Placement = "Somewhere in Between";
            _panelModel5_Awning.Panel_GlassThickness = 6.0f;
            _panelModel5_Awning.Panel_RotoswingArtNo = Rotoswing_HandleArtNo._RSC773452;
            _panelModel5_Awning.Panel_Index_Inside_MPanel = 8;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel5_Awning);
            Control Awning3 = new Control();
            Awning3.Name = "AwningPanelUC_5";
            _multiMullionModel.MPanelLst_Objects.Add(Awning3);



            IDividerModel _divMullionModel5 = _dividerServices.AddDividerModel(divSize,
                                                                            _multiMullionModel.MPanel_Height,
                                                                            new Control(),
                                                                            DividerModel.DividerType.Mullion,
                                                                            true,
                                                                            _frameModel.Frame_Zoom,
                                                                            Divider_ArticleNo._7536,
                                                                            _multiMullionModel.MPanel_DisplayWidth,
                                                                            _multiMullionModel.MPanel_DisplayHeight,
                                                                            _multiMullionModel,
                                                                            _frameModel,
                                                                            5,
                                                                            _frameModel.FrameImageRenderer_Zoom,
                                                                            _frameModel.Frame_Type.ToString(),
                                                                            "MullionUC_5",
                                                                            null,
                                                                            false,
                                                                            true,
                                                                            null);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel5);
            Control div_Mullion5 = new Control();
            div_Mullion5.Name = "MullionUC_5";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion5);


            IPanelModel _panelModel6_fixed = _panelServices.AddPanelModel(suggest_Wd,
                                                                        suggest_HT,
                                                                        new Control(),
                                                                        new UserControl(),
                                                                        new UserControl(),
                                                                        new UserControl(),
                                                                        "Fixed Panel",
                                                                        true,
                                                                        1.0f,
                                                                        _frameModel,
                                                                        _multiMullionModel,
                                                                        BalanceFixedWD6,
                                                                        FixedHT6,
                                                                        GlazingBead_ArticleNo._2452,
                                                                        GlassFilm_Types._None,
                                                                        SashProfile_ArticleNo._None,
                                                                        SashReinf_ArticleNo._None,
                                                                        GlassType._Single,
                                                                        Espagnolette_ArticleNo._None,
                                                                        Striker_ArticleNo._M89ANTA,
                                                                        MiddleCloser_ArticleNo._None,
                                                                        LockingKit_ArticleNo._None,
                                                                        MotorizedMech_ArticleNo._41555B,
                                                                        Handle_Type._Rotoswing,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        Extension_ArticleNo._None,
                                                                        false,
                                                                        false,
                                                                        false,
                                                                        false,
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        Rotoswing_HandleArtNo._RSC773451,
                                                                        GeorgianBar_ArticleNo._None,
                                                                        0,
                                                                        0,
                                                                        false,
                                                                        6);
            _panelModel6_fixed.Panel_Placement = "Last";
            _panelModel6_fixed.Panel_GlassThickness = 6.0f;
            _panelModel6_fixed.Panel_Index_Inside_MPanel = 10;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel6_fixed);
            Control Fixed3 = new Control();
            Fixed3.Name = "FixedPanelUC_6";
            _multiMullionModel.MPanelLst_Objects.Add(Fixed3);

            #endregion



            //Assert

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(3005, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1105, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2932, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1032, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(3, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(0, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual(6600000, _qouteModel.Plastic_CoverQty_Total);
            Assert.AreEqual(12, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(48, _qouteModel.Rebate_Qty);
            Assert.AreEqual(118, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(76, _qouteModel.Screws_for_Installation);

            #region MultiMullion (6)

            #region AwningUC_1

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(473, _panelModel1_Awning.Panel_SashWidth);
            Assert.AreEqual(1053, _panelModel1_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(348, _panelModel1_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(928, _panelModel1_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(473, _panelModel1_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1053, _panelModel1_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(352, _panelModel1_Awning.Panel_GlassWidth);
            Assert.AreEqual(932, _panelModel1_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel1_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel1_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628806, _panelModel1_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773452, _panelModel1_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel1_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel1_Awning.Panel_MiddleCloserArtNo);

            #endregion

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1037, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(957, _divMullionModel.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(496, _panelModel2_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(1100, _panelModel2_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(448, _panelModel2_fixed.Panel_GlassWidth);
            Assert.AreEqual(1028, _panelModel2_fixed.Panel_GlassHeight);


            #region AwningUC_2

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel3_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(473, _panelModel3_Awning.Panel_SashWidth);
            Assert.AreEqual(1053, _panelModel3_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel3_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(348, _panelModel3_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(928, _panelModel3_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(473, _panelModel3_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1053, _panelModel3_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(352, _panelModel3_Awning.Panel_GlassWidth);
            Assert.AreEqual(932, _panelModel3_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel3_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel3_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel3_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel3_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628806, _panelModel3_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel3_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773452, _panelModel3_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel3_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel3_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel3_Awning.Panel_MiddleCloserArtNo);

            #endregion


            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1037, _divMullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(957, _divMullionModel2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel4_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(496, _panelModel4_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(1100, _panelModel4_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(448, _panelModel4_fixed.Panel_GlassWidth);
            Assert.AreEqual(1028, _panelModel4_fixed.Panel_GlassHeight);



            #region AwningUC_3

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel5_Awning.Panel_SashProfileArtNo);
            Assert.AreEqual(473, _panelModel5_Awning.Panel_SashWidth);
            Assert.AreEqual(1053, _panelModel5_Awning.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel5_Awning.Panel_SashReinfArtNo);
            Assert.AreEqual(348, _panelModel5_Awning.Panel_SashReinfWidth);
            Assert.AreEqual(928, _panelModel5_Awning.Panel_SashReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel5_Awning.PanelGlazingBead_ArtNo);
            Assert.AreEqual(473, _panelModel5_Awning.Panel_GlazingBeadWidth);
            Assert.AreEqual(1053, _panelModel5_Awning.Panel_GlazingBeadHeight);

            Assert.AreEqual(352, _panelModel5_Awning.Panel_GlassWidth);
            Assert.AreEqual(932, _panelModel5_Awning.Panel_GlassHeight);

            //ACCESSORIES & HARDWARE
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel5_Awning.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel5_Awning.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStay_ArticleNo._Storm22, _panelModel5_Awning.Panel_FrictionStayArtNo);
            Assert.AreEqual(2, _panelModel5_Awning.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._628806, _panelModel5_Awning.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel5_Awning.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC773452, _panelModel5_Awning.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel5_Awning.Panel_StrikerArtno_A);
            Assert.AreEqual(2, _panelModel5_Awning.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70DB, _panelModel5_Awning.Panel_MiddleCloserArtNo);

            #endregion


            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel3.Div_ReinfArtNo);
            Assert.AreEqual(1037, _divMullionModel3.Div_ExplosionHeight);
            Assert.AreEqual(957, _divMullionModel3.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel6_fixed.PanelGlazingBead_ArtNo);
            Assert.AreEqual(508, _panelModel6_fixed.Panel_GlazingBeadWidth);
            Assert.AreEqual(1100, _panelModel6_fixed.Panel_GlazingBeadHeight);
            Assert.AreEqual(448, _panelModel6_fixed.Panel_GlassWidth);
            Assert.AreEqual(1028, _panelModel6_fixed.Panel_GlassHeight);

            #endregion


            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '3005'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1105'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2932'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1032'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            //aw
            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '473'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1053'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '348'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '928'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '473'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1053'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '352'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '932'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            //Fixed

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '508'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '496'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1100'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '448'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1028'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            #endregion



        }





        //casement Window

        // CW Outward

        //Sample 7502 - 7581
        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_A1_UsingMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._741012,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._612978,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._612978,
                                                                   Extension_ArticleNo._639957,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   true,
                                                                   true,
                                                                   false,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   2,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._FrictionStay
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_FSCasementArtNo = FrictionStayCasement_ArticleNo._12HD;
            _panelModel1.Panel_CornerDriveOptionsVisibility = true;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);


            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._7533);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._7581,
                                                                      SashReinf_ArticleNo._R675,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._741012,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      true,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      2,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._FrictionStay
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_FSCasementArtNo = FrictionStayCasement_ArticleNo._12HD;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1382, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1532, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8972, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(142, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(56, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(690, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1553, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(690, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1553, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(565, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1428, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(569, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1432, _panelModel1.Panel_GlassHeight);



            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStayCasement_ArticleNo._12HD, _panelModel1.Panel_FSCasementArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._741012, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel1.Panel_StrikerArtno_C);
            Assert.AreEqual(6, _panelModel1.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1.Panel_StrikerArtno_A);
            Assert.AreEqual(1, _panelModel1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1.Panel_MiddleCloserArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._639958, _panelModel1.Panel_CornerDriveArtNo);


            //EXTENSION

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(2, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);




            #endregion

            #region MullionUC1

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1537, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1457, _divMullionModel.Div_ReinfHeight);

            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(690, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1553, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(690, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1553, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(565, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1428, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(569, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1432, _panelModel2.Panel_GlassHeight);

            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStayCasement_ArticleNo._12HD, _panelModel2.Panel_FSCasementArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._741012, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel2.Panel_StrikerArtno_C);
            Assert.AreEqual(6, _panelModel2.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2.Panel_StrikerArtno_A);
            Assert.AreEqual(1, _panelModel2.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel2.Panel_MiddleCloserArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._639958, _panelModel2.Panel_CornerDriveArtNo);


            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(2, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);

            #endregion

            #endregion

            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1382'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1532'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '690'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1553'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '565'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1428'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '690'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1553'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '690'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1553'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '569'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '569'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);




            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-C%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("12", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-A%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%0914%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%1640%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Middle Closer%' AND
                             Description LIKE '%1WC70-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Corner Drive%' AND
                             Description LIKE '%639958%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%741012%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_A1_UsingDummyMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);

            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._FrictionStay
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_FSCasementArtNo = FrictionStayCasement_ArticleNo._None;
            _panelModel1.Panel_CornerDriveOptionsVisibility = false;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel1.Panel_Index_Inside_MPanel = 0; 
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);

            IDividerModel _divDummyMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              false,
                                                                              DummyMullion_ArticleNo._7533,
                                                                              _panelModel1
                                                                              );

            _divDummyMullionModel.Div_ArtNo = Divider_ArticleNo._None;
            _divDummyMullionModel.Div_ChkDM = true;
            _divDummyMullionModel.Div_ArtVisibility = true;
            _divDummyMullionModel.Div_DMPanel = _panelModel1;
            _divDummyMullionModel.Div_EndcapDM = EndcapDM_ArticleNo._K7533;
            _divDummyMullionModel.Div_FixedCamDM = FixedCam_ArticleNo._1481413;
            _divDummyMullionModel.Div_SnapNKeepDM = SnapInKeep_ArticleNo._0400205;
            _multiMullionModel.MPanelLst_Divider.Add(_divDummyMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._7581,
                                                                      SashReinf_ArticleNo._R675,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._741012,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      true,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._FrictionStay
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_FSCasementArtNo = FrictionStayCasement_ArticleNo._12HD;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);


            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1382, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1532, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8996, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(132, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(56, _qouteModel.Screws_for_Installation);



            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(696, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1553, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(696, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1553, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(571, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1428, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(575, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1432, _panelModel1.Panel_GlassHeight);

            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStayCasement_ArticleNo._12HD, _panelModel1.Panel_FSCasementArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._None, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._None, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel1.Panel_StrikerArtno_C);
            Assert.AreEqual(0, _panelModel1.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1.Panel_StrikerArtno_A);
            Assert.AreEqual(0, _panelModel1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1.Panel_MiddleCloserArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);


            #endregion


            #region MullionUC1

            Assert.AreEqual(DummyMullion_ArticleNo._7533, _divDummyMullionModel.Div_DMArtNo);
            Assert.AreEqual(1472, _divDummyMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(FixedCam_ArticleNo._1481413, _divDummyMullionModel.Div_FixedCamDM);
            Assert.AreEqual(SnapInKeep_ArticleNo._0400205, _divDummyMullionModel.Div_SnapNKeepDM);
            Assert.AreEqual(EndcapDM_ArticleNo._K7533, _divDummyMullionModel.Div_EndcapDM);


            #endregion


            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(696, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1553, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(696, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1553, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(571, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1428, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(575, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1432, _panelModel2.Panel_GlassHeight);



            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStayCasement_ArticleNo._12HD, _panelModel2.Panel_FSCasementArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._741012, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel2.Panel_StrikerArtno_C);
            Assert.AreEqual(6, _panelModel2.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2.Panel_StrikerArtno_A);
            Assert.AreEqual(1, _panelModel2.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel2.Panel_MiddleCloserArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);



            #endregion





            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '1382'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1532'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '696'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1553'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '571'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1428'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '696'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1553'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '696'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1553'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '575'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '575'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            //accesories and hardwares 

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%741012%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Middle Closer%' AND
                             Description LIKE '%1WC70-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-C%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-A%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Fixed cam%' AND
                             Description LIKE '%1481413%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Snap-in Keep%' AND
                             Description LIKE '%0400205%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Endcap for Dummy Mullion%' AND
                             Description LIKE '%K7533%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Aluminum spacer for Dummy Mullion%' AND
                             Description LIKE '%FC770 (80mm)%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Aluminum spacer for Dummy Mullion%' AND
                             Description LIKE '%FC770 (50mm)%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);
            #endregion

        }

        //Sample 7507 - 7581
        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_B1_UsingMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._EQ87NT,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._612978,
                                                                   Extension_ArticleNo._639957,
                                                                   Extension_ArticleNo._612978,
                                                                   Extension_ArticleNo._639957,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   true,
                                                                   true,
                                                                   false,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   0,
                                                                   0,
                                                                   1,
                                                                   1,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = true;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel1.Panel_2dHingeArtNo_nonMotorized = _2DHinge_ArticleNo._614293;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);


            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._7533);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._7581,
                                                                      SashReinf_ArticleNo._R675,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._EQ87NT,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      true,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel2.Panel_2dHingeArtNo_nonMotorized = _2DHinge_ArticleNo._614293;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8804, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(157, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(676, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1525, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(676, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1525, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(551, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1400, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(555, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1404, _panelModel1.Panel_GlassHeight);



            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(HingeOption._2DHinge, _panelModel1.Panel_HingeOptions);
            Assert.AreEqual(_2DHinge_ArticleNo._614293, _panelModel1.Panel_2dHingeArtNo_nonMotorized);
            Assert.AreEqual(1, _panelModel1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._EQ87NT, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel1.Panel_StrikerArtno_C);
            Assert.AreEqual(6, _panelModel1.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1.Panel_StrikerArtno_A);
            Assert.AreEqual(1, _panelModel1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1.Panel_MiddleCloserArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._639958, _panelModel1.Panel_CornerDriveArtNo);


            //EXTENSION

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);




            #endregion

            #region MullionUC1

            Assert.AreEqual(Divider_ArticleNo._7536, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1509, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1429, _divMullionModel.Div_ReinfHeight);

            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(676, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1525, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(676, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1525, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(551, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1400, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(555, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1404, _panelModel2.Panel_GlassHeight);

            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(FrictionStayCasement_ArticleNo._12HD, _panelModel2.Panel_FSCasementArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._EQ87NT, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel2.Panel_StrikerArtno_C);
            Assert.AreEqual(6, _panelModel2.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2.Panel_StrikerArtno_A);
            Assert.AreEqual(1, _panelModel2.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel2.Panel_MiddleCloserArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);

            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '676'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '551'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1400'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '676'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '676'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '555'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '555'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            //ACCESSORIES & HARDWARE
            dr = dt.Select(@"Description LIKE '%2D hinge%' AND
                             Description LIKE '%614293%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("8", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-C%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("12", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-A%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%0914%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%1640%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Middle Closer%' AND
                             Description LIKE '%1WC70-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Corner Drive%' AND
                             Description LIKE '%639958%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%EQ87(NT)%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            #endregion

        }


        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_B1_UsingDummyMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._7581,
                                                                   SashReinf_ArticleNo._R675,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );

            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = false;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None; 
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);

            IDividerModel _divDummyMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._7533,
                                                                              _panelModel1);
            _divDummyMullionModel.Div_ArtNo = Divider_ArticleNo._None;
            _divDummyMullionModel.Div_ChkDM = true;
            _divDummyMullionModel.Div_DMPanel = _panelModel1;
            _divDummyMullionModel.Div_ArtVisibility = true;
            _divDummyMullionModel.Div_EndcapDM = EndcapDM_ArticleNo._K7533;
            _divDummyMullionModel.Div_FixedCamDM = FixedCam_ArticleNo._1481413;
            _divDummyMullionModel.Div_SnapNKeepDM = SnapInKeep_ArticleNo._0400205;
            _multiMullionModel.MPanelLst_Divider.Add(_divDummyMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._7581,
                                                                      SashReinf_ArticleNo._R675,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._EQ87NT,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._639957,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      true,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel2.Panel_2dHingeArtNo_nonMotorized = _2DHinge_ArticleNo._614293;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._639958;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8828, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(147, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(682, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1525, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(682, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1525, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(557, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1400, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(561, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1404, _panelModel1.Panel_GlassHeight);

            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(_2DHinge_ArticleNo._614293, _panelModel1.Panel_2dHingeArtNo_nonMotorized);
            Assert.AreEqual(1, _panelModel1.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._None, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._None, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel1.Panel_StrikerArtno_C);
            Assert.AreEqual(0, _panelModel1.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel1.Panel_StrikerArtno_A);
            Assert.AreEqual(0, _panelModel1.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel1.Panel_MiddleCloserArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);


            #endregion

            #region MullionUC1

            Assert.AreEqual(DummyMullion_ArticleNo._7533, _divDummyMullionModel.Div_DMArtNo);
            Assert.AreEqual(1444, _divDummyMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(FixedCam_ArticleNo._1481413, _divDummyMullionModel.Div_FixedCamDM);
            Assert.AreEqual(SnapInKeep_ArticleNo._0400205, _divDummyMullionModel.Div_SnapNKeepDM);
            Assert.AreEqual(EndcapDM_ArticleNo._K7533, _divDummyMullionModel.Div_EndcapDM);


            #endregion


            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(682, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1525, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._7581, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(682, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1525, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._R675, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(557, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1400, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(561, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1404, _panelModel2.Panel_GlassHeight);



            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(_2DHinge_ArticleNo._614293, _panelModel2.Panel_2dHingeArtNo_nonMotorized);
            Assert.AreEqual(1, _panelModel2.Panel_PlasticWedgeQty);
            Assert.AreEqual(Espagnolette_ArticleNo._EQ87NT, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(Striker_ArticleNo._M89ANTC, _panelModel2.Panel_StrikerArtno_C);
            Assert.AreEqual(6, _panelModel2.Panel_StrikerQty_C);
            Assert.AreEqual(Striker_ArticleNo._M89ANTA, _panelModel2.Panel_StrikerArtno_A);
            Assert.AreEqual(1, _panelModel2.Panel_StrikerQty_A);
            Assert.AreEqual(MiddleCloser_ArticleNo._1WC70WHT, _panelModel2.Panel_MiddleCloserArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._612978, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._639957, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);



            #endregion
            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 7581' AND Size = '682'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 7581' AND Size = '1525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width R675' AND Size = '557'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height R675' AND Size = '1400'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '682'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '682'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1525'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '561'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '561'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1404'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            //accesories and hardwares 

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%EQ87(NT)%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Plastic Wedge%' AND
                             Description LIKE '%7199-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Middle Closer%' AND
                             Description LIKE '%1WC70-WHT%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);



            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-C%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Striker%' AND
                             Description LIKE '%M89A-NT-A%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Fixed cam%' AND
                             Description LIKE '%1481413%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Snap-in Keep%' AND
                             Description LIKE '%0400205%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Endcap for Dummy Mullion%' AND
                             Description LIKE '%K7533%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Aluminum spacer for Dummy Mullion%' AND
                             Description LIKE '%FC770 (80mm)%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Aluminum spacer for Dummy Mullion%' AND
                             Description LIKE '%FC770 (50mm)%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);
            #endregion

        }

        //Sample 7507 - 374 
        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_D1_UsingMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._374,
                                                                   SashReinf_ArticleNo._655,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._642105,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rio,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._641798,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   true,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   1,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = true;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel1.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel1.Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
            _panelModel1.Panel_RioOptionsVisibility = true;
            _panelModel1.Panel_RioArtNo = Rio_HandleArtNo._C050C108019;
            _panelModel1.Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;
            _panelModel1.Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);


            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._7533);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._374,
                                                                      SashReinf_ArticleNo._655,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._642105,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rio,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._641798,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel2.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel2.Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
            _panelModel2.Panel_RioOptionsVisibility = true;
            _panelModel2.Panel_RioArtNo = Rio_HandleArtNo._C050C108019;
            _panelModel2.Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;
            _panelModel2.Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8760, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(159, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(663, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._374, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(663, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._655, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(568, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1432, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(480, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1344, _panelModel1.Panel_GlassHeight);



            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._642105, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rio, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Rio_HandleArtNo._C050C108019, _panelModel1.Panel_RioArtNo);
            Assert.AreEqual(ProfileKnobCylinder_ArtNo._45x45, _panelModel1.Panel_ProfileKnobCylinderArtNo);
            Assert.AreEqual(Cylinder_CoverArtNo._EPSW_8022_823332, _panelModel1.Panel_CylinderCoverArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel1.Panel_AdjStrikerArtNo);
            Assert.AreEqual(_3dHinge_ArticleNo._3DHinge_DB, _panelModel1.Panel_3dHingeArtNo);
            Assert.AreEqual(RestrictorStay_ArticleNo._613249, _panelModel1.Panel_RestrictorStayArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel1.Panel_CornerDriveArtNo);


            //EXTENSION

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._641798, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);




            #endregion

            #region MullionUC1

            Assert.AreEqual(Divider_ArticleNo._7538, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1514, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1404, _divMullionModel.Div_ReinfHeight);

            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(663, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._374, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(663, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._655, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(568, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1432, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(480, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1344, _panelModel2.Panel_GlassHeight);

            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._642105, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rio, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rio_HandleArtNo._C050C108019, _panelModel2.Panel_RioArtNo);
            Assert.AreEqual(ProfileKnobCylinder_ArtNo._45x45, _panelModel2.Panel_ProfileKnobCylinderArtNo);
            Assert.AreEqual(Cylinder_CoverArtNo._EPSW_8022_823332, _panelModel2.Panel_CylinderCoverArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel2.Panel_AdjStrikerArtNo);
            Assert.AreEqual(_3dHinge_ArticleNo._3DHinge_DB, _panelModel2.Panel_3dHingeArtNo);
            Assert.AreEqual(RestrictorStay_ArticleNo._613249, _panelModel2.Panel_RestrictorStayArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel2.Panel_CornerDriveArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._641798, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);

            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 374' AND Size = '663'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 374' AND Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width 655' AND Size = '568'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height 655' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '663'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '663'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '480'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1344'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '480'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1344'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            //ACCESSORIES & HARDWARE
            dr = dt.Select(@"Description LIKE '%3D hinge%' AND
                             Description LIKE '%492594%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Adjustable Striker%' AND
                             Description LIKE '%332439%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("10", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Restrictor Stay%' AND
                             Description LIKE '%613249%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Mechanical Joint%' AND
                             Description LIKE '%AV585%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%0914%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%1640%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Rio handle%' AND
                             Description LIKE '%C050C108019%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Profile Knob Cylinder%' AND
                             Description LIKE '%45x45%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Cylinder Cover%' AND
                             Description LIKE '%EPSW-8022/823332%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%642105%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);




            #endregion

        }

        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_D1_UsingDummyMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._374,
                                                                   SashReinf_ArticleNo._655,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307, 
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = false;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel1.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel1.Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);

            IDividerModel _divDummyMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._None,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._385P);

            _divDummyMullionModel.Div_ChkDM = true;
            _divDummyMullionModel.Div_DMPanel = _panelModel1;
            _divDummyMullionModel.Div_ArtVisibility = true;
            _divDummyMullionModel.Div_EndcapDM = EndcapDM_ArticleNo._K385;
            _multiMullionModel.MPanelLst_Divider.Add(_divDummyMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._374,
                                                                      SashReinf_ArticleNo._655,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._642105,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rio,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._641798,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307, 
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel2.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel2.Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
            _panelModel2.Panel_RioOptionsVisibility = true;
            _panelModel2.Panel_RioArtNo = Rio_HandleArtNo._C050C108019;
            _panelModel2.Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;
            _panelModel2.Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332; 
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8856, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(138, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

        

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(687, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._374, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(687, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._655, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(592, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1432, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(504, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1344, _panelModel1.Panel_GlassHeight);

            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._None, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._None, _panelModel1.Panel_HandleType);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel1.Panel_AdjStrikerArtNo);
            Assert.AreEqual(_3dHinge_ArticleNo._3DHinge_DB, _panelModel1.Panel_3dHingeArtNo);
            Assert.AreEqual(RestrictorStay_ArticleNo._613249, _panelModel1.Panel_RestrictorStayArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel1.Panel_CornerDriveArtNo);


            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);


            #endregion

            #region MullionUC1

            Assert.AreEqual(DummyMullion_ArticleNo._385P, _divDummyMullionModel.Div_DMArtNo);
            Assert.AreEqual(1446, _divDummyMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(EndcapDM_ArticleNo._K385, _divDummyMullionModel.Div_EndcapDM);


            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(687, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._374, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(687, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._655, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(592, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1432, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(504, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1344, _panelModel2.Panel_GlassHeight);



            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._642105, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rio, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rio_HandleArtNo._C050C108019, _panelModel2.Panel_RioArtNo);
            Assert.AreEqual(ProfileKnobCylinder_ArtNo._45x45, _panelModel2.Panel_ProfileKnobCylinderArtNo);
            Assert.AreEqual(Cylinder_CoverArtNo._EPSW_8022_823332, _panelModel2.Panel_CylinderCoverArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel2.Panel_AdjStrikerArtNo);
            Assert.AreEqual(_3dHinge_ArticleNo._3DHinge_DB, _panelModel2.Panel_3dHingeArtNo);
            Assert.AreEqual(RestrictorStay_ArticleNo._613249, _panelModel2.Panel_RestrictorStayArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel2.Panel_CornerDriveArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._641798, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);



            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 374' AND Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 374' AND Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width 655' AND Size = '592'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height 655' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1344'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1344'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            //accesories and hardwares 

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%642105%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%3D hinge%' AND
                             Description LIKE '%492594%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Adjustable Striker%' AND
                             Description LIKE '%332439%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("5", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Restrictor Stay%' AND
                             Description LIKE '%613249%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Endcap for Dummy Mullion%' AND
                             Description LIKE '%K385%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            #endregion

        }

        //using MVD Handle 
        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_A3_UsingDummyMullion_UsingMVDhandle()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._374,
                                                                   SashReinf_ArticleNo._655,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = false;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel1.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel1.Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249; 
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);

            IDividerModel _divDummyMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._None,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._385P);

            _divDummyMullionModel.Div_ChkDM = true;
            _divDummyMullionModel.Div_DMPanel = _panelModel1;
            _divDummyMullionModel.Div_ArtVisibility = true;
            _divDummyMullionModel.Div_EndcapDM = EndcapDM_ArticleNo._K385;
            _multiMullionModel.MPanelLst_Divider.Add(_divDummyMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2452,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._374,
                                                                      SashReinf_ArticleNo._655,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._630963,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._MVD,
                                                                      Extension_ArticleNo._630956,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._630956,
                                                                      Extension_ArticleNo._612978,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      true,
                                                                      true,
                                                                      false,
                                                                      false,
                                                                      1,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel2.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel2.Panel_RestrictorStayArtNo = RestrictorStay_ArticleNo._613249;
            _panelModel2.Panel_RioOptionsVisibility = true;
            _panelModel2.Panel_RioArtNo = Rio_HandleArtNo._C050C108019;
            _panelModel2.Panel_ProfileKnobCylinderArtNo = ProfileKnobCylinder_ArtNo._45x45;
            _panelModel2.Panel_CylinderCoverArtNo = Cylinder_CoverArtNo._EPSW_8022_823332;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8856, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(138, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)



            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(687, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._374, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(687, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._655, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(592, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1432, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(504, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1344, _panelModel1.Panel_GlassHeight);

            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._None, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._None, _panelModel1.Panel_HandleType);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel1.Panel_AdjStrikerArtNo);
            Assert.AreEqual(_3dHinge_ArticleNo._3DHinge_DB, _panelModel1.Panel_3dHingeArtNo);
            Assert.AreEqual(RestrictorStay_ArticleNo._613249, _panelModel1.Panel_RestrictorStayArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel1.Panel_CornerDriveArtNo);


            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);


            #endregion

            #region MullionUC1

            Assert.AreEqual(DummyMullion_ArticleNo._385P, _divDummyMullionModel.Div_DMArtNo);
            Assert.AreEqual(1446, _divDummyMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(EndcapDM_ArticleNo._K385, _divDummyMullionModel.Div_EndcapDM);


            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(687, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._374, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(687, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._655, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(592, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1432, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(504, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1344, _panelModel2.Panel_GlassHeight);



            //ACCESSORIES & HARDWARES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._642105, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rio, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rio_HandleArtNo._C050C108019, _panelModel2.Panel_RioArtNo);
            Assert.AreEqual(ProfileKnobCylinder_ArtNo._45x45, _panelModel2.Panel_ProfileKnobCylinderArtNo);
            Assert.AreEqual(Cylinder_CoverArtNo._EPSW_8022_823332, _panelModel2.Panel_CylinderCoverArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel2.Panel_AdjStrikerArtNo);
            Assert.AreEqual(_3dHinge_ArticleNo._3DHinge_DB, _panelModel2.Panel_3dHingeArtNo);
            Assert.AreEqual(RestrictorStay_ArticleNo._613249, _panelModel2.Panel_RestrictorStayArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel2.Panel_CornerDriveArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._641798, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(1, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);



            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 374' AND Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 374' AND Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width 655' AND Size = '592'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height 655' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1344'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1344'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            //accesories and hardwares 

            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%642105%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%3D hinge%' AND
                             Description LIKE '%492594%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("6", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Adjustable Striker%' AND
                             Description LIKE '%332439%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("5", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Restrictor Stay%' AND
                             Description LIKE '%613249%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Endcap for Dummy Mullion%' AND
                             Description LIKE '%K385%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            #endregion

        }


        // CW Inward

        //sample 7507 - 395

        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_C1_UsingMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._395,
                                                                   SashReinf_ArticleNo._207,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._N110A02206,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._Rotoswing,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = true;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel1.Panel_NTCenterHingeVisibility = true;
            _panelModel1.Panel_NTCenterHingeArticleNo = NTCenterHinge_ArticleNo._N610A06516;
            _panelModel1.Panel_StayBearingKArtNo = StayBearingK_ArticleNo._N390A0001;
            _panelModel1.Panel_StayBearingPinArtNo = StayBearingPin_ArticleNo._F710D52026;
            _panelModel1.Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._WhiteIvory;
            _panelModel1.Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._WhiteIvory;
            _panelModel1.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Left;
            _panelModel1.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Right;
            _panelModel1.Panel_TopCornerHingeSpacerArtNo = TopCornerHingeSpacer_ArticleNo._331488;
            _panelModel1.Panel_CornerHingeKArtNo = CornerHingeK_ArticleNo._N510A0011;
            _panelModel1.Panel_CornerPivotRestKArtNo = CornerPivotRestK_ArticleNo._N510A0001;
            _panelModel1.Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._WhiteIvory;
            _panelModel1.Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
            _panelModel1.Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._WhiteIvory;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);


            IDividerModel _divMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              true,
                                                                              DummyMullion_ArticleNo._7533);
            _multiMullionModel.MPanelLst_Divider.Add(_divMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion);


            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._395,
                                                                      SashReinf_ArticleNo._207,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._N110A02206,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = true;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel2.Panel_Orient = false;
            _panelModel2.Panel_NTCenterHingeVisibility = true;
            _panelModel2.Panel_NTCenterHingeArticleNo = NTCenterHinge_ArticleNo._N610A06516;
            _panelModel2.Panel_StayBearingKArtNo = StayBearingK_ArticleNo._N390A0001;
            _panelModel2.Panel_StayBearingPinArtNo = StayBearingPin_ArticleNo._F710D52026;
            _panelModel2.Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._WhiteIvory;
            _panelModel2.Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._WhiteIvory;
            _panelModel2.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Left;
            _panelModel2.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Right;
            _panelModel2.Panel_TopCornerHingeSpacerArtNo = TopCornerHingeSpacer_ArticleNo._331488;
            _panelModel2.Panel_CornerHingeKArtNo = CornerHingeK_ArticleNo._N510A0011;
            _panelModel2.Panel_CornerPivotRestKArtNo = CornerPivotRestK_ArticleNo._N510A0001;
            _panelModel2.Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._WhiteIvory;
            _panelModel2.Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
            _panelModel2.Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._WhiteIvory;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8760, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(115, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(663, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._395, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(663, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._207, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(538, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1402, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(538, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1402, _panelModel1.Panel_GlassHeight);



            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._N110A02206, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel1.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel1.Panel_RotoswingArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel1.Panel_AdjStrikerArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel1.Panel_CornerDriveArtNo);

            Assert.AreEqual(NTCenterHinge_ArticleNo._N610A06516, _panelModel1.Panel_NTCenterHingeArticleNo);
            Assert.AreEqual(StayBearingK_ArticleNo._N390A0001, _panelModel1.Panel_StayBearingKArtNo);
            Assert.AreEqual(StayBearingPin_ArticleNo._F710D52026, _panelModel1.Panel_StayBearingPinArtNo);
            Assert.AreEqual(StayBearingCover_ArticleNo._WhiteIvory, _panelModel1.Panel_StayBearingCoverArtNo);
            Assert.AreEqual(TopCornerHingeCover_ArticleNo._WhiteIvory, _panelModel1.Panel_TopCornerHingeCoverArtNo);
            Assert.AreEqual(TopCornerHinge_ArticleNo._Left, _panelModel1.Panel_TopCornerHingeArtNo);
            Assert.AreEqual(TopCornerHingeSpacer_ArticleNo._331488, _panelModel1.Panel_TopCornerHingeSpacerArtNo);
            Assert.AreEqual(CornerHingeK_ArticleNo._N510A0011, _panelModel1.Panel_CornerHingeKArtNo);
            Assert.AreEqual(CornerPivotRestK_ArticleNo._N510A0001, _panelModel1.Panel_CornerPivotRestKArtNo);
            Assert.AreEqual(CornerHingeCoverK_ArticleNo._WhiteIvory, _panelModel1.Panel_CornerHingeCoverKArtNo);
            Assert.AreEqual(CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory, _panelModel1.Panel_CoverForCornerPivotRestVerticalArtNo);
            Assert.AreEqual(CoverForCornerPivotRest_ArticleNo._WhiteIvory, _panelModel1.Panel_CoverForCornerPivotRestArtNo);


            //EXTENSION

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);




            #endregion

            #region MullionUC1

            Assert.AreEqual(Divider_ArticleNo._7538, _divMullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, _divMullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1514, _divMullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1404, _divMullionModel.Div_ReinfHeight);

            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(663, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._395, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(663, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._207, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(538, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1402, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(538, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1402, _panelModel2.Panel_GlassHeight);

            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._N110A02206, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel2.Panel_AdjStrikerArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel2.Panel_CornerDriveArtNo);

            Assert.AreEqual(NTCenterHinge_ArticleNo._N610A06516, _panelModel2.Panel_NTCenterHingeArticleNo);
            Assert.AreEqual(StayBearingK_ArticleNo._N390A0001, _panelModel2.Panel_StayBearingKArtNo);
            Assert.AreEqual(StayBearingPin_ArticleNo._F710D52026, _panelModel2.Panel_StayBearingPinArtNo);
            Assert.AreEqual(StayBearingCover_ArticleNo._WhiteIvory, _panelModel2.Panel_StayBearingCoverArtNo);
            Assert.AreEqual(TopCornerHingeCover_ArticleNo._WhiteIvory, _panelModel2.Panel_TopCornerHingeCoverArtNo);
            Assert.AreEqual(TopCornerHinge_ArticleNo._Right, _panelModel2.Panel_TopCornerHingeArtNo);
            Assert.AreEqual(TopCornerHingeSpacer_ArticleNo._331488, _panelModel2.Panel_TopCornerHingeSpacerArtNo);
            Assert.AreEqual(CornerHingeK_ArticleNo._N510A0011, _panelModel2.Panel_CornerHingeKArtNo);
            Assert.AreEqual(CornerPivotRestK_ArticleNo._N510A0001, _panelModel2.Panel_CornerPivotRestKArtNo);
            Assert.AreEqual(CornerHingeCoverK_ArticleNo._WhiteIvory, _panelModel2.Panel_CornerHingeCoverKArtNo);
            Assert.AreEqual(CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory, _panelModel2.Panel_CoverForCornerPivotRestVerticalArtNo);
            Assert.AreEqual(CoverForCornerPivotRest_ArticleNo._WhiteIvory, _panelModel2.Panel_CoverForCornerPivotRestArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);

            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 395' AND Size = '663'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 395' AND Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width 207' AND Size = '538'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height 207' AND Size = '1402'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '663'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '663'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '538'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1402'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '538'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1402'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            //ACCESSORIES & HARDWARE

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%0914%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%N110A02206%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Adjustable Striker%' AND
                             Description LIKE '%332439%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%NT Center Hinge%' AND
                             Description LIKE '%N610A06516%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Mechanical Joint%' AND
                             Description LIKE '%AV585%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Stay Bearing, K%' AND
                             Description LIKE '%N390A0001%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Stay Bearing Pin%' AND
                             Description LIKE '%F710D52026%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Stay Bearing Cover%' AND
                             Description LIKE '%N391A03718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge Cover%' AND
                             Description LIKE '%N391A03718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge%' AND
                             Description LIKE '%N620A6116R%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge%' AND
                             Description LIKE '%N620A6116L%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge Spacer%' AND
                             Description LIKE '%331488%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Corner Hinge, K%' AND
                             Description LIKE '%N510A0011%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Corner Pivot Rest, K%' AND
                             Description LIKE '%N510A0001%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Corner Hinge Cover K%' AND
                             Description LIKE '%N591A04718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Cover for corner pivot rest, vertical%' AND
                             Description LIKE '%N591A01718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Cover for corner pivot rest,%' AND
                             Description LIKE '%N591B02718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Rotoswing handle%' AND
                             Description LIKE '%RSC-833307%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);
            #endregion

        }

        [TestMethod]
        public void ChkVar_2PanelCasementWindowSample_C1_UsingDummyMullion()
        {
            /*          _________________
            *           |      /|\      |
            *           |    /  |  \    |
            *           |  /    |    \  |
            *           |/      |      \|
            *           |\      |      /|
            *           |  \    |    /  |
            *           |    \  |  /    |
            *           |______\|/______|
            */



            int total_wd = 1450,
                total_ht = 1600,
                eqpanelWD = 725;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1, Base_Color._White, Foil_Color._Walnut, Foil_Color._Walnut);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7507,
                                                                   _windoorModel,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;


            IMultiPanelModel _multiMullionModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         1,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                          null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            Control multiMullion = new Control();
            multiMullion.Name = _multiMullionModel.MPanel_Name;


            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel.MPanel_Divisions + 1;


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiMullion_totalPanelCount);


            #region MultiMullionModel


            IPanelModel _panelModel1 = _panelServices.AddPanelModel(suggest_Wd,
                                                                   suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Casement Panel",
                                                                   true,
                                                                   1.0f,
                                                                   _frameModel,
                                                                   _multiMullionModel,
                                                                   eqpanelWD,
                                                                   total_ht,
                                                                   GlazingBead_ArticleNo._2453,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._395,
                                                                   SashReinf_ArticleNo._207,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANTC,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._None,
                                                                   MotorizedMech_ArticleNo._41555B,
                                                                   Handle_Type._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   Extension_ArticleNo._None,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   false,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   Rotoswing_HandleArtNo._RSC833307,
                                                                   GeorgianBar_ArticleNo._None,
                                                                   0,
                                                                   0,
                                                                   false,
                                                                   1,
                                                                   1,
                                                                   _frameModel.FrameImageRenderer_Zoom,
                                                                   1,
                                                                   DockStyle.Fill,
                                                                   "CasementPanelUC_1",
                                                                   true,
                                                                   HingeOption._2DHinge
                                                                   );
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 13.0f;
            _panelModel1.Panel_CornerDriveOptionsVisibility = false;
            _panelModel1.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel1.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel1.Panel_HingeOptionsVisibility = false;
            _panelModel1.Panel_NTCenterHingeVisibility = true;
            _panelModel1.Panel_NTCenterHingeArticleNo = NTCenterHinge_ArticleNo._N610A06516;
            _panelModel1.Panel_StayBearingKArtNo = StayBearingK_ArticleNo._N390A0001;
            _panelModel1.Panel_StayBearingPinArtNo = StayBearingPin_ArticleNo._F710D52026;
            _panelModel1.Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._WhiteIvory;
            _panelModel1.Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._WhiteIvory;
            _panelModel1.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Left;
            _panelModel1.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Right;
            _panelModel1.Panel_TopCornerHingeSpacerArtNo = TopCornerHingeSpacer_ArticleNo._331488;
            _panelModel1.Panel_CornerHingeKArtNo = CornerHingeK_ArticleNo._N510A0011;
            _panelModel1.Panel_CornerPivotRestKArtNo = CornerPivotRestK_ArticleNo._N510A0001;
            _panelModel1.Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._WhiteIvory;
            _panelModel1.Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
            _panelModel1.Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._WhiteIvory;
            _panelModel1.Panel_Index_Inside_MPanel = 0;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel1);
            Control Casement1 = new Control();
            Casement1.Name = "CasementPanelUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(Casement1);


            IDividerModel _divDummyMullionModel = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiMullionModel.MPanel_DisplayWidth,
                                                                              _multiMullionModel.MPanel_DisplayHeight,
                                                                              _multiMullionModel,
                                                                              _frameModel,
                                                                              1,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString(),
                                                                              "MullionUC_1",
                                                                              null,
                                                                              false,
                                                                              false,
                                                                              DummyMullion_ArticleNo._385P);


            _divDummyMullionModel.Div_ChkDM = true;
            _divDummyMullionModel.Div_ArtNo = Divider_ArticleNo._None;
            _divDummyMullionModel.Div_ArtVisibility = true;
            _divDummyMullionModel.Div_DMPanel = _panelModel1;
            _divDummyMullionModel.Div_LeverEspagVisibility = true;
            _divDummyMullionModel.Div_LeverEspagArtNo = LeverEspagnolette_ArticleNo._625_207;
            _divDummyMullionModel.Div_ShootboltNonReverseArtNo = ShootboltNonReverse_ArticleNo._349187;
            _divDummyMullionModel.Div_ShootboltStrikerArtNo = ShootboltStriker_ArticleNo._N705A20106;
            _multiMullionModel.MPanelLst_Divider.Add(_divDummyMullionModel);
            Control div_Mullion = new Control();
            div_Mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_Mullion); 

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(suggest_Wd,
                                                                      suggest_HT,
                                                                      new Control(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      new UserControl(),
                                                                      "Casement Panel",
                                                                      true,
                                                                      1.0f,
                                                                      _frameModel,
                                                                      _multiMullionModel,
                                                                      eqpanelWD,
                                                                      total_ht,
                                                                      GlazingBead_ArticleNo._2453,
                                                                      GlassFilm_Types._None,
                                                                      SashProfile_ArticleNo._395,
                                                                      SashReinf_ArticleNo._207,
                                                                      GlassType._Single,
                                                                      Espagnolette_ArticleNo._N110A02206,
                                                                      Striker_ArticleNo._M89ANTC,
                                                                      MiddleCloser_ArticleNo._1WC70WHT,
                                                                      LockingKit_ArticleNo._None,
                                                                      MotorizedMech_ArticleNo._41555B,
                                                                      Handle_Type._Rotoswing,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      Extension_ArticleNo._None,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      false,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      Rotoswing_HandleArtNo._RSC833307,
                                                                      GeorgianBar_ArticleNo._None,
                                                                      0,
                                                                      0,
                                                                      false,
                                                                      2,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      2,
                                                                      DockStyle.Fill,
                                                                      "CasementPanelUC_2",
                                                                      true,
                                                                      HingeOption._2DHinge
                                                                      );
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 13.0f;
            _panelModel2.Panel_CornerDriveOptionsVisibility = false;
            _panelModel2.Panel_CornerDriveArtNo = CornerDrive_ArticleNo._None;
            _panelModel2.Panel_Orient = false;
            _panelModel1.Panel_AdjStrikerArtNo = AdjustableStriker_ArticleNo._332439;
            _panelModel2.Panel_NTCenterHingeVisibility = true;
            _panelModel2.Panel_NTCenterHingeArticleNo = NTCenterHinge_ArticleNo._N610A06516;
            _panelModel2.Panel_StayBearingKArtNo = StayBearingK_ArticleNo._N390A0001;
            _panelModel2.Panel_StayBearingPinArtNo = StayBearingPin_ArticleNo._F710D52026;
            _panelModel2.Panel_StayBearingCoverArtNo = StayBearingCover_ArticleNo._WhiteIvory;
            _panelModel2.Panel_TopCornerHingeCoverArtNo = TopCornerHingeCover_ArticleNo._WhiteIvory;
            _panelModel2.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Left;
            _panelModel2.Panel_TopCornerHingeArtNo = TopCornerHinge_ArticleNo._Right;
            _panelModel2.Panel_TopCornerHingeSpacerArtNo = TopCornerHingeSpacer_ArticleNo._331488;
            _panelModel2.Panel_CornerHingeKArtNo = CornerHingeK_ArticleNo._N510A0011;
            _panelModel2.Panel_CornerPivotRestKArtNo = CornerPivotRestK_ArticleNo._N510A0001;
            _panelModel2.Panel_CornerHingeCoverKArtNo = CornerHingeCoverK_ArticleNo._WhiteIvory;
            _panelModel2.Panel_CoverForCornerPivotRestVerticalArtNo = CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory;
            _panelModel2.Panel_CoverForCornerPivotRestArtNo = CoverForCornerPivotRest_ArticleNo._WhiteIvory;
            _panelModel2.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control Casement2 = new Control();
            Casement2.Name = "CasementPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(Casement2);

            #endregion

            #region Assert


            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7507, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1455, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R677, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1354, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1504, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(2, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(8856, _qouteModel.GlazingSeal_TotalQty);
            Assert.AreEqual((decimal)0.5568, _windoorModel.WD_PlasticCover);
            Assert.AreEqual(9, _qouteModel.Expansion_BoltQty_Total);
            Assert.AreEqual(36, _qouteModel.Rebate_Qty);
            Assert.AreEqual(124, _qouteModel.Screws_for_Fabrication);
            Assert.AreEqual(55, _qouteModel.Screws_for_Installation);

            #region Multimullion(2)

            #region CW1

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(687, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._395, _panelModel1.Panel_SashProfileArtNo);
            Assert.AreEqual(687, _panelModel1.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel1.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._207, _panelModel1.Panel_SashReinfArtNo);
            Assert.AreEqual(562, _panelModel1.Panel_SashReinfWidth);
            Assert.AreEqual(1402, _panelModel1.Panel_SashReinfHeight);

            Assert.AreEqual(562, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1402, _panelModel1.Panel_GlassHeight);



            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel1.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel1.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._None, _panelModel1.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._None, _panelModel1.Panel_HandleType);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel1.Panel_AdjStrikerArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel1.Panel_CornerDriveArtNo);

            Assert.AreEqual(NTCenterHinge_ArticleNo._N610A06516, _panelModel1.Panel_NTCenterHingeArticleNo);
            Assert.AreEqual(StayBearingK_ArticleNo._N390A0001, _panelModel1.Panel_StayBearingKArtNo);
            Assert.AreEqual(StayBearingPin_ArticleNo._F710D52026, _panelModel1.Panel_StayBearingPinArtNo);
            Assert.AreEqual(StayBearingCover_ArticleNo._WhiteIvory, _panelModel1.Panel_StayBearingCoverArtNo);
            Assert.AreEqual(TopCornerHingeCover_ArticleNo._WhiteIvory, _panelModel1.Panel_TopCornerHingeCoverArtNo);
            Assert.AreEqual(TopCornerHinge_ArticleNo._Left, _panelModel1.Panel_TopCornerHingeArtNo);
            Assert.AreEqual(TopCornerHingeSpacer_ArticleNo._331488, _panelModel1.Panel_TopCornerHingeSpacerArtNo);
            Assert.AreEqual(CornerHingeK_ArticleNo._N510A0011, _panelModel1.Panel_CornerHingeKArtNo);
            Assert.AreEqual(CornerPivotRestK_ArticleNo._N510A0001, _panelModel1.Panel_CornerPivotRestKArtNo);
            Assert.AreEqual(CornerHingeCoverK_ArticleNo._WhiteIvory, _panelModel1.Panel_CornerHingeCoverKArtNo);
            Assert.AreEqual(CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory, _panelModel1.Panel_CoverForCornerPivotRestVerticalArtNo);
            Assert.AreEqual(CoverForCornerPivotRest_ArticleNo._WhiteIvory, _panelModel1.Panel_CoverForCornerPivotRestArtNo);


            //EXTENSION

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel1.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel1.Panel_ExtRight2Qty);




            #endregion

            #region MullionUC1

            Assert.AreEqual(DummyMullion_ArticleNo._385P, _divDummyMullionModel.Div_DMArtNo);
            Assert.AreEqual(1446, _divDummyMullionModel.Div_ExplosionHeight);

            Assert.AreEqual(LeverEspagnolette_ArticleNo._625_207, _divDummyMullionModel.Div_LeverEspagArtNo);
            Assert.AreEqual(ShootboltNonReverse_ArticleNo._349187, _divDummyMullionModel.Div_ShootboltNonReverseArtNo);
            Assert.AreEqual(ShootboltStriker_ArticleNo._N705A20106, _divDummyMullionModel.Div_ShootboltStrikerArtNo);


            #endregion

            #region CW2

            Assert.AreEqual(GlazingBead_ArticleNo._2453, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(687, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_GlazingBeadHeight);

            Assert.AreEqual(SashProfile_ArticleNo._395, _panelModel2.Panel_SashProfileArtNo);
            Assert.AreEqual(687, _panelModel2.Panel_SashWidth);
            Assert.AreEqual(1527, _panelModel2.Panel_SashHeight);

            Assert.AreEqual(SashReinf_ArticleNo._207, _panelModel2.Panel_SashReinfArtNo);
            Assert.AreEqual(562, _panelModel2.Panel_SashReinfWidth);
            Assert.AreEqual(1402, _panelModel2.Panel_SashReinfHeight);

            Assert.AreEqual(562, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1402, _panelModel2.Panel_GlassHeight);

            //ACCESSORIES
            Assert.AreEqual(CoverProfile_ArticleNo._0914, _panelModel2.Panel_CoverProfileArtNo);
            Assert.AreEqual(CoverProfile_ArticleNo._1640, _panelModel2.Panel_CoverProfileArtNo2);
            Assert.AreEqual(Espagnolette_ArticleNo._N110A02206, _panelModel2.Panel_EspagnoletteArtNo);
            Assert.AreEqual(Handle_Type._Rotoswing, _panelModel2.Panel_HandleType);
            Assert.AreEqual(Rotoswing_HandleArtNo._RSC833307, _panelModel2.Panel_RotoswingArtNo);
            Assert.AreEqual(AdjustableStriker_ArticleNo._332439, _panelModel2.Panel_AdjStrikerArtNo);
            Assert.AreEqual(CornerDrive_ArticleNo._None, _panelModel2.Panel_CornerDriveArtNo);

            Assert.AreEqual(NTCenterHinge_ArticleNo._N610A06516, _panelModel2.Panel_NTCenterHingeArticleNo);
            Assert.AreEqual(StayBearingK_ArticleNo._N390A0001, _panelModel2.Panel_StayBearingKArtNo);
            Assert.AreEqual(StayBearingPin_ArticleNo._F710D52026, _panelModel2.Panel_StayBearingPinArtNo);
            Assert.AreEqual(StayBearingCover_ArticleNo._WhiteIvory, _panelModel2.Panel_StayBearingCoverArtNo);
            Assert.AreEqual(TopCornerHingeCover_ArticleNo._WhiteIvory, _panelModel2.Panel_TopCornerHingeCoverArtNo);
            Assert.AreEqual(TopCornerHinge_ArticleNo._Right, _panelModel2.Panel_TopCornerHingeArtNo);
            Assert.AreEqual(TopCornerHingeSpacer_ArticleNo._331488, _panelModel2.Panel_TopCornerHingeSpacerArtNo);
            Assert.AreEqual(CornerHingeK_ArticleNo._N510A0011, _panelModel2.Panel_CornerHingeKArtNo);
            Assert.AreEqual(CornerPivotRestK_ArticleNo._N510A0001, _panelModel2.Panel_CornerPivotRestKArtNo);
            Assert.AreEqual(CornerHingeCoverK_ArticleNo._WhiteIvory, _panelModel2.Panel_CornerHingeCoverKArtNo);
            Assert.AreEqual(CoverForCornerPivotRestVertical_ArticleNo._WhiteIvory, _panelModel2.Panel_CoverForCornerPivotRestVerticalArtNo);
            Assert.AreEqual(CoverForCornerPivotRest_ArticleNo._WhiteIvory, _panelModel2.Panel_CoverForCornerPivotRestArtNo);

            //EXTENSIONS
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTopArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTopQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionTop2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtTop2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBotArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBotQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionBot2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtBot2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeftArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeftQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionLeft2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtLeft2Qty);

            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRightArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRightQty);
            Assert.AreEqual(Extension_ArticleNo._None, _panelModel2.Panel_ExtensionRight2ArtNo);
            Assert.AreEqual(0, _panelModel2.Panel_ExtRight2Qty);

            #endregion

            #endregion



            #endregion

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7507' AND Size = '1455'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7507' AND Size = '1605'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R677' AND Size = '1354'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R677' AND Size = '1504'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Width 395' AND Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Height 395' AND Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Width 207' AND Size = '562'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select("Description = 'Sash Reinf Height 207' AND Size = '1402'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P1)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '687'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%(P2)%' AND
                             Description LIKE '%2453%' AND
                             Size = '1527'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '562'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P1- )%' AND
                             Size = '1402'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '562'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Description LIKE '%(P2- )%' AND
                             Size = '1402'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);



            //ACCESSORIES & HARDWARE

            dr = dt.Select(@"Description LIKE '%Cover Profile%' AND
                             Description LIKE '%0914%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Espagnolette%' AND
                             Description LIKE '%N110A02206%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Lever Espagnolette%' AND
                             Description LIKE '%625-207%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Shootbolt, non-reverse%' AND
                             Description LIKE '%349187%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Shootbolt Striker%' AND
                             Description LIKE '%N705A20106%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Adjustable Striker%' AND
                             Description LIKE '%332439%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("3", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Endcap for Dummy Mullion%' AND
                             Description LIKE '%K385%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%NT Center Hinge%' AND
                             Description LIKE '%N610A06516%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Stay Bearing, K%' AND
                             Description LIKE '%N390A0001%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Stay Bearing Pin%' AND
                             Description LIKE '%F710D52026%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Stay Bearing Cover%' AND
                             Description LIKE '%N391A03718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge Cover%' AND
                             Description LIKE '%N391A03718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("4", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge%' AND
                             Description LIKE '%N620A6116R%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge%' AND
                             Description LIKE '%N620A6116L%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Top Corner Hinge Spacer%' AND
                             Description LIKE '%331488%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Corner Hinge, K%' AND
                             Description LIKE '%N510A0011%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Corner Pivot Rest, K%' AND
                             Description LIKE '%N510A0001%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Corner Hinge Cover K%' AND
                             Description LIKE '%N591A04718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Cover for corner pivot rest, vertical%' AND
                             Description LIKE '%N591A01718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);


            dr = dt.Select(@"Description LIKE '%Cover for corner pivot rest,%' AND
                             Description LIKE '%N591B02718%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("2", dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Rotoswing handle%' AND
                             Description LIKE '%RSC-833307%'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual("1", dr[0]["Qty"]);
            #endregion

        }

    }
}
