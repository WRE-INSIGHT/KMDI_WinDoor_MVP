using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System;
using System.Data;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Tests
{
    [TestClass]
    public class ExplosionUnitTest
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

        //[TestMethod]
        //public void ChkList_SinglePanelFixedWindow()
        //{
        //    int total_wd = 500, total_height = 1500;

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
        //    Assert.AreEqual("505", dt.Rows[0]["Size"]);

        //    Assert.AreEqual("Frame Height 7502", dt.Rows[1]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[1]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
        //    Assert.AreEqual("1505", dt.Rows[1]["Size"]);

        //    Assert.AreEqual("Frame Reinf Width R676", dt.Rows[2]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[2]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[2]["Unit"].ToString());
        //    Assert.AreEqual("432", dt.Rows[2]["Size"]);

        //    Assert.AreEqual("Frame Reinf Height R676", dt.Rows[3]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[3]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[3]["Unit"].ToString());
        //    Assert.AreEqual("1432", dt.Rows[3]["Size"]);

        //    Assert.AreEqual("Glazing Bead Width 2452", dt.Rows[4]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[4]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[4]["Unit"].ToString());
        //    Assert.AreEqual("434", dt.Rows[4]["Size"]);

        //    Assert.AreEqual("Glazing Bead Height 2452", dt.Rows[5]["Description"].ToString());
        //    Assert.AreEqual(2, dt.Rows[5]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[5]["Unit"].ToString());
        //    Assert.AreEqual("1434", dt.Rows[5]["Size"]);

        //    Assert.AreEqual("Glass Width (6mm)", dt.Rows[6]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[6]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
        //    Assert.AreEqual("428", dt.Rows[6]["Size"]);

        //    Assert.AreEqual("Glass Height (6mm)", dt.Rows[7]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[7]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
        //    Assert.AreEqual("1428", dt.Rows[7]["Size"]);

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
        //    Assert.AreEqual("pc(s)", dt.Rows[9]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[10]["Size"]);

        //    Assert.AreEqual("Glazing Spacer (KBC70)", dt.Rows[11]["Description"].ToString());
        //    Assert.AreEqual(1, dt.Rows[11]["Qty"]);
        //    Assert.AreEqual("pc(s)", dt.Rows[11]["Unit"].ToString());
        //    Assert.AreEqual("", dt.Rows[11]["Size"]);

        //}

        [TestMethod]
        public void ChkVar_SinglePanelFixedWindow()
        {
            int total_wd = 700, total_height = 2000;

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
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   1);
            _panelModel.Panel_GlassThickness = 6.0f;
            _frameModel.Lst_Panel.Add(_panelModel);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(705, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(2005, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(632, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1932, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(700, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(2000, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(628, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1928, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '705'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '2005'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '632'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1932'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '700'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '2000'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '628'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1928'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_SinglePanelFixedWindow2()
        {
            int total_wd = 500, total_height = 1500;

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
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   1);
            _panelModel.Panel_GlassThickness = 6.0f;
            _frameModel.Lst_Panel.Add(_panelModel);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(505, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1505, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(432, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1432, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(500, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1500, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(428, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1428, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

            #region Check Quantity

            DataRow[] dr;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1505'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1432'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND
                             Size = '1500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '428'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1428'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_2EQualPanelFW_WithMullion()
        {
            int total_wd = 900, total_height = 1300,
                eqpanelWD = 450, eqpanelHT = 1300;

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
                                                                                       FlowDirection.LeftToRight,
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
                                                                   null,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   eqpanelHT,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   1);
            _panelModel.Panel_Placement = "First";
            _panelModel.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multipanelModel.MPanelLst_Objects.Add(fw1);

            IDividerModel divModel = _dividerServices.AddDividerModel(divSize,
                                                                      _multipanelModel.MPanel_Height,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Mullion,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7538,
                                                                      _multipanelModel.MPanel_DisplayWidth,
                                                                      _multipanelModel.MPanel_DisplayHeight,
                                                                      _multipanelModel,
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
            _multipanelModel.MPanelLst_Divider.Add(divModel);
            Control div1 = new Control();
            div1.Name = "MullionUC_1";
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
                                                                   null,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   eqpanelHT,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(905, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1305, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(832, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1232, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(450, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1300, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(375, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel.Div_ReinfArtNo);
            Assert.AreEqual(1242, divModel.Div_ExplosionHeight);
            Assert.AreEqual(1132, divModel.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(450, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1300, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(375, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            #region Check Quantity

            DataRow[] dr;
            object sumObject;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '905'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1305'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '832'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1232'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Width%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '450'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Height%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '1300'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Width%' AND
                                                 Size = '375'");
            Assert.AreEqual(2, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Height%' AND
                                                 Size = '1228'");
            Assert.AreEqual(2, Convert.ToInt32(sumObject));

            dr = dt.Select("Description = 'Mullion Height 7538' AND Size = '1242'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R686' AND Size = '1132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint AV585'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_2UnequalPanelFW_WithMullion()
        {
            int total_wd = 900, total_height = 1300,
                uneqpanelWD1 = 400, uneqpanelWD2 = 500, eqpanelHT = 1300;

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
                                                                                       FlowDirection.LeftToRight,
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
                                                                   null,
                                                                   _multipanelModel,
                                                                   uneqpanelWD1,
                                                                   eqpanelHT,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   1);
            _panelModel.Panel_Placement = "First";
            _panelModel.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multipanelModel.MPanelLst_Objects.Add(fw1);

            IDividerModel divModel = _dividerServices.AddDividerModel(divSize,
                                                                      _multipanelModel.MPanel_Height,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Mullion,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7538,
                                                                      _multipanelModel.MPanel_DisplayWidth,
                                                                      _multipanelModel.MPanel_DisplayHeight,
                                                                      _multipanelModel,
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
            _multipanelModel.MPanelLst_Divider.Add(divModel);
            Control div1 = new Control();
            div1.Name = "MullionUC_1";
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
                                                                   null,
                                                                   _multipanelModel,
                                                                   uneqpanelWD2,
                                                                   eqpanelHT,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(905, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1305, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(832, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1232, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1300, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(325, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel.Div_ReinfArtNo);
            Assert.AreEqual(1242, divModel.Div_ExplosionHeight);
            Assert.AreEqual(1132, divModel.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(500, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1300, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(425, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            #region Check Quantity

            DataRow[] dr;
            object sumObject;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '905'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1305'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '832'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1232'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '400'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Width%' AND
                             Description LIKE '%2452%' AND
                             Size = '500'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Height%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '1300'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '325'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '425'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Height%' AND
                                                 Size = '1228'");
            Assert.AreEqual(2, Convert.ToInt32(sumObject));

            dr = dt.Select("Description = 'Mullion Height 7538' AND Size = '1242'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R686' AND Size = '1132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint AV585'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            #endregion

        }

        [TestMethod]
        public void ChkVar_4PanelFixedWindow_WithMullionTransom()
        {
            int total_wd = 550, total_ht = 1200,
                eqpanelwd = 275, eqpanelht = 600;

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
                                                                                       _frameModel.FrameImageRenderer_Zoom);
            _multiTransomModel.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel);
            Control multiTransom = new Control();
            multiTransom.Name = _multiTransomModel.MPanel_Name;

            int divSize = 26;
            int multiTransom_totalPanelCount = _multiTransomModel.MPanel_Divisions + 1;

            int suggest_Wd = (((_multiTransomModel.MPanel_Width) - (divSize * _multiTransomModel.MPanel_Divisions)) / multiTransom_totalPanelCount),
                suggest_HT = _multiTransomModel.MPanel_Height;

            #region multiTransom Platform

            IMultiPanelModel _multiMullionModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          total_wd,
                                                                                          eqpanelht,
                                                                                          multiTransom,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          2,
                                                                                          DockStyle.None,
                                                                                          2,
                                                                                          0,
                                                                                          _multiTransomModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom);
            _multiMullionModel1.MPanel_Placement = "First";
            _multiMullionModel1.MPanel_Index_Inside_MPanel = 0;
            _multiTransomModel.MPanelLst_MultiPanel.Add(_multiMullionModel1);
            Control multiMullion1 = new Control();
            multiMullion1.Name = "MultiMullion_2";
            _multiTransomModel.MPanelLst_Objects.Add(multiMullion1);

            IDividerModel transomModel = _dividerServices.AddDividerModel(_multiTransomModel.MPanel_Width,
                                                                      divSize,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Transom,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7536,
                                                                      _multiTransomModel.MPanel_DisplayWidth,
                                                                      _multiTransomModel.MPanel_DisplayHeight,
                                                                      _multiTransomModel,
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
            _multiTransomModel.MPanelLst_Divider.Add(transomModel);
            Control div1 = new Control();
            div1.Name = "TransomUC_1";
            _multiTransomModel.MPanelLst_Objects.Add(div1);

            IMultiPanelModel _multiMullionModel2 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                          suggest_HT,
                                                                                          total_wd,
                                                                                          eqpanelht,
                                                                                          multiTransom,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          3,
                                                                                          DockStyle.None,
                                                                                          2,
                                                                                          0,
                                                                                          _multiTransomModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom);
            _multiMullionModel2.MPanel_Placement = "Last";
            _multiMullionModel2.MPanel_Index_Inside_MPanel = 2;
            _multiTransomModel.MPanelLst_MultiPanel.Add(_multiMullionModel2);
            Control multiMullion2 = new Control();
            multiMullion2.Name = "MultiMullion_3";
            _multiTransomModel.MPanelLst_Objects.Add(multiMullion2);

            #endregion

            #region multiMullion1 Platform

            int multiMullion1_totalPanelCount = _multiMullionModel1.MPanel_Divisions + 1;

            int multiMullion1_suggest_Wd = (((_multiMullionModel1.MPanel_Width) - (divSize * _multiMullionModel1.MPanel_Divisions)) / multiMullion1_totalPanelCount),
                multiMullion1_suggest_HT = _multiMullionModel1.MPanel_Height;

            IPanelModel _panelModel1 = _panelServices.AddPanelModel(multiMullion1_suggest_Wd,
                                                                   multiMullion1_suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   null,
                                                                   _multiMullionModel1,
                                                                   eqpanelwd,
                                                                   eqpanelht,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   1);
            _panelModel1.Panel_Placement = "First";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel1);
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_1";
            _multiMullionModel1.MPanelLst_Objects.Add(fw1);

            IDividerModel divModel_mullion = _dividerServices.AddDividerModel(divSize,
                                                                      _multiMullionModel1.MPanel_Height,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Mullion,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7536,
                                                                      _multiMullionModel1.MPanel_DisplayWidth,
                                                                      _multiMullionModel1.MPanel_DisplayHeight,
                                                                      _multiMullionModel1,
                                                                      2,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
            _multiMullionModel1.MPanelLst_Divider.Add(divModel_mullion);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_2";
            _multiMullionModel1.MPanelLst_Objects.Add(div_mullion);

            IPanelModel _panelModel2 = _panelServices.AddPanelModel(multiMullion1_suggest_Wd,
                                                                   multiMullion1_suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   null,
                                                                   _multiMullionModel1,
                                                                   eqpanelwd,
                                                                   eqpanelht,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multiMullionModel1.MPanelLst_Objects.Add(fw2);

            #endregion

            #region multiMullion2 Platform

            int multiMullion2_totalPanelCount = _multiMullionModel2.MPanel_Divisions + 1;

            int multiMullion2_suggest_Wd = (((_multiMullionModel2.MPanel_Width) - (divSize * _multiMullionModel2.MPanel_Divisions)) / multiMullion2_totalPanelCount),
                multiMullion2_suggest_HT = _multiMullionModel2.MPanel_Height;

            IPanelModel _panelModel3 = _panelServices.AddPanelModel(multiMullion2_suggest_Wd,
                                                                   multiMullion2_suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   null,
                                                                   _multiMullionModel1,
                                                                   eqpanelwd,
                                                                   eqpanelht,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   3);
            _panelModel3.Panel_Placement = "First";
            _panelModel3.Panel_GlassThickness = 6.0f;
            _multiMullionModel2.MPanelLst_Panel.Add(_panelModel3);
            Control fw3 = new Control();
            fw3.Name = "FixedPanelUC_3";
            _multiMullionModel2.MPanelLst_Objects.Add(fw3);

            IDividerModel divModel_mullion2 = _dividerServices.AddDividerModel(divSize,
                                                                      _multiMullionModel2.MPanel_Height,
                                                                      new Control(),
                                                                      DividerModel.DividerType.Mullion,
                                                                      true,
                                                                      _frameModel.Frame_Zoom,
                                                                      Divider_ArticleNo._7536,
                                                                      _multiMullionModel2.MPanel_DisplayWidth,
                                                                      _multiMullionModel2.MPanel_DisplayHeight,
                                                                      _multiMullionModel2,
                                                                      3,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
            _multiMullionModel2.MPanelLst_Divider.Add(divModel_mullion2);
            Control div_mullion2 = new Control();
            div_mullion2.Name = "MullionUC_3";
            _multiMullionModel2.MPanelLst_Objects.Add(div_mullion2);

            IPanelModel _panelModel4 = _panelServices.AddPanelModel(multiMullion2_suggest_Wd,
                                                                   multiMullion2_suggest_HT,
                                                                   new Control(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   new UserControl(),
                                                                   "Fixed Panel",
                                                                   true,
                                                                   1.0f,
                                                                   null,
                                                                   _multiMullionModel2,
                                                                   eqpanelwd,
                                                                   eqpanelht,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   GlassFilm_Types._None,
                                                                   SashProfile_ArticleNo._None,
                                                                   SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   4);
            _panelModel4.Panel_Placement = "Last";
            _panelModel4.Panel_GlassThickness = 6.0f;
            _multiMullionModel2.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiMullionModel2.MPanelLst_Objects.Add(fw4);

            #endregion

            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel2);

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(Divider_ArticleNo._7536, transomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, transomModel.Div_ReinfArtNo);
            Assert.AreEqual(487, transomModel.Div_ExplosionWidth);
            Assert.AreEqual(407, transomModel.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(275, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(215, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_mullion.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_mullion.Div_ReinfArtNo);
            Assert.AreEqual(549, divModel_mullion.Div_ExplosionHeight);
            Assert.AreEqual(469, divModel_mullion.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(275, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(215, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(275, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(215, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_mullion2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_mullion2.Div_ReinfArtNo);
            Assert.AreEqual(549, divModel_mullion2.Div_ExplosionHeight);
            Assert.AreEqual(469, divModel_mullion2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(275, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(600, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(215, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);

            #region Check Quantity

            DataRow[] dr;
            object sumObject;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '555'");

            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1205'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '482'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1132'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '487'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '407'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Width%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '275'");
            Assert.AreEqual(8, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Height%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '600'");
            Assert.AreEqual(8, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Width%' AND
                                                 Size = '215'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Height%' AND
                                                 Size = '540'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            dr = dt.Select("Description = 'Mullion Height 7536' AND Size = '549'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R677' AND Size = '469'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(4, dr[0]["Qty"]);

            #endregion
        }

        [TestMethod]
        public void ChkVar_11PanelFixedWindow_WithMullionTransom()
        {
            //Design : ModelLayer.Tests\ExplosionUnitTestDesigns\Example5.png
            int total_wd = 2400, total_ht = 1900,
                p1Wd = 800, p1Ht = 1900,
                p2p3Wd = 800, p2p3Ht = 950,
                p4p11Wd = 400, p4p11Ht = 475,
                panelID = 0, mpanelID = 0, divID = 0;

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

            //Level 1
            #region MultiMullion_base

            mpanelID++;
            IMultiPanelModel _multiMullionModel1 = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                         ht,
                                                                                         total_wd,
                                                                                         total_ht,
                                                                                         frame,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.LeftToRight,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         mpanelID,
                                                                                         DockStyle.Fill,
                                                                                         1,
                                                                                         0,
                                                                                         null,
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         2);
            _multiMullionModel1.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            Control multimullion = new Control();
            multimullion.Name = _multiMullionModel1.MPanel_Name;


            #endregion

            #region Transom(2)-Fixed-Transom(2)
            int divSize = 26;
            int multiMullion_totalPanelCount = _multiMullionModel1.MPanel_Divisions + 1;

            int multiMullion_suggest_Wd = (((_multiMullionModel1.MPanel_Width) - (divSize * _multiMullionModel1.MPanel_Divisions)) / multiMullion_totalPanelCount),
                multiMullion_suggest_HT = _multiMullionModel1.MPanel_Height;

            mpanelID++;
            IMultiPanelModel _multiTransomModel2 = _multiPanelServices.AddMultiPanelModel(multiMullion_suggest_Wd,
                                                                                          multiMullion_suggest_HT,
                                                                                          p2p3Wd,
                                                                                          total_ht,
                                                                                          multimullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.TopDown,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          mpanelID,
                                                                                          DockStyle.Fill,
                                                                                          2,
                                                                                          0,
                                                                                          _multiMullionModel1,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          2);
            _multiTransomModel2.MPanel_Placement = "First";
            _multiTransomModel2.MPanel_Index_Inside_MPanel = 0;
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel2);
            _multiMullionModel1.MPanelLst_MultiPanel.Add(_multiTransomModel2);
            Control multiTransom2 = new Control();
            multiTransom2.Name = _multiTransomModel2.MPanel_Name;
            _multiMullionModel1.MPanelLst_Objects.Add(multiTransom2);

            divID++;
            IDividerModel divModel_mullion1 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel1.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel1.MPanel_DisplayWidth,
                                                                              _multiMullionModel1.MPanel_DisplayHeight,
                                                                              _multiMullionModel1,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiMullionModel1.MPanelLst_Divider.Add(divModel_mullion1);
            Control div_mullion1 = new Control();
            div_mullion1.Name = "MullionUC_" + divID;
            _multiMullionModel1.MPanelLst_Objects.Add(div_mullion1);

            panelID++;
            IPanelModel _panelModel1 = _panelServices.AddPanelModel(multiMullion_suggest_Wd,
                                                                    multiMullion_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel1,
                                                                    p1Wd,
                                                                    p1Ht,
                                                                    GlazingBead_ArticleNo._2451,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel1.Panel_Placement = "Somewhere in Between";
            _panelModel1.Panel_GlassThickness = 6.0f;
            _multiMullionModel1.MPanelLst_Panel.Add(_panelModel1);
            _panelModel1.Panel_Index_Inside_MPanel = 2;
            Control fw1 = new Control();
            fw1.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel1.MPanelLst_Objects.Add(fw1);

            divID++;
            IDividerModel divModel_mullion2 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel1.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel1.MPanel_DisplayWidth,
                                                                              _multiMullionModel1.MPanel_DisplayHeight,
                                                                              _multiMullionModel1,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiMullionModel1.MPanelLst_Divider.Add(divModel_mullion2);
            Control div_mullion2 = new Control();
            div_mullion2.Name = "MullionUC_" + divID;
            _multiMullionModel1.MPanelLst_Objects.Add(div_mullion2);

            mpanelID++;
            IMultiPanelModel _multiTransomModel3 = _multiPanelServices.AddMultiPanelModel(multiMullion_suggest_Wd,
                                                                                          multiMullion_suggest_HT,
                                                                                          p2p3Wd,
                                                                                          total_ht,
                                                                                          multimullion,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.TopDown,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          mpanelID,
                                                                                          DockStyle.Fill,
                                                                                          2,
                                                                                          0,
                                                                                          _multiMullionModel1,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          2);
            _multiTransomModel3.MPanel_Index_Inside_MPanel = 4;
            _multiTransomModel3.MPanel_Placement = "Last";
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel3);
            _multiMullionModel1.MPanelLst_MultiPanel.Add(_multiTransomModel3);
            Control multiTransom3 = new Control();
            multiTransom3.Name = _multiTransomModel3.MPanel_Name;
            _multiMullionModel1.MPanelLst_Objects.Add(multiTransom3);

            #endregion

            //Level 2
            #region _multiTransom2(2) as base

            int multiTransom_totalPanelCount = _multiTransomModel2.MPanel_Divisions + 1;

            int multiTransom2_suggest_Wd = (((_multiTransomModel2.MPanel_Width) - (divSize * _multiTransomModel2.MPanel_Divisions)) / multiTransom_totalPanelCount),
                multiTransom2_suggest_HT = _multiTransomModel2.MPanel_Height;

            mpanelID++;
            IMultiPanelModel _multiMullionModel4 = _multiPanelServices.AddMultiPanelModel(multiTransom2_suggest_Wd,
                                                                                          multiTransom2_suggest_HT,
                                                                                          p2p3Wd,
                                                                                          p4p11Ht,
                                                                                          multiTransom2,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          mpanelID,
                                                                                          DockStyle.Fill,
                                                                                          3,
                                                                                          0,
                                                                                          _multiTransomModel2,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          1);
            _multiMullionModel4.MPanel_Index_Inside_MPanel = 0;
            _multiMullionModel4.MPanel_Placement = "First";
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel4);
            _multiTransomModel2.MPanelLst_MultiPanel.Add(_multiMullionModel4);
            Control multimullion4 = new Control();
            multimullion4.Name = _multiMullionModel4.MPanel_Name;
            _multiTransomModel2.MPanelLst_Objects.Add(multimullion4);

            divID++;
            IDividerModel divModel_transom3 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiTransomModel2.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel2.MPanel_DisplayWidth,
                                                                              _multiTransomModel2.MPanel_DisplayHeight,
                                                                              _multiTransomModel2,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiTransomModel2.MPanelLst_Divider.Add(divModel_transom3);
            Control div_mullion3 = new Control();
            div_mullion3.Name = "TransomUC_" + divID;
            _multiTransomModel2.MPanelLst_Objects.Add(div_mullion3);

            mpanelID++;
            IMultiPanelModel _multiMullionModel5 = _multiPanelServices.AddMultiPanelModel(multiTransom2_suggest_Wd,
                                                                                          multiTransom2_suggest_HT,
                                                                                          p2p3Wd,
                                                                                          p4p11Ht,
                                                                                          multiTransom2,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          mpanelID,
                                                                                          DockStyle.Fill,
                                                                                          3,
                                                                                          0,
                                                                                          _multiTransomModel2,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          1);
            _multiMullionModel5.MPanel_Index_Inside_MPanel = 2;
            _multiMullionModel5.MPanel_Placement = "Somewhere in Between";
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel5);
            _multiTransomModel2.MPanelLst_MultiPanel.Add(_multiMullionModel5);
            Control multimullion5 = new Control();
            multimullion5.Name = _multiMullionModel5.MPanel_Name;
            _multiTransomModel2.MPanelLst_Objects.Add(multimullion5);

            divID++;
            IDividerModel divModel_transom4 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiTransomModel2.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel2.MPanel_DisplayWidth,
                                                                              _multiTransomModel2.MPanel_DisplayHeight,
                                                                              _multiTransomModel2,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiTransomModel2.MPanelLst_Divider.Add(divModel_transom4);
            Control div_transom4 = new Control();
            div_transom4.Name = "TransomUC_" + divID;
            _multiTransomModel2.MPanelLst_Objects.Add(div_transom4);

            panelID++;
            IPanelModel _panelModel2 = _panelServices.AddPanelModel(multiTransom2_suggest_Wd,
                                                                    multiTransom2_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiTransomModel2,
                                                                    p2p3Wd,
                                                                    p2p3Ht,
                                                                    GlazingBead_ArticleNo._2451,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_GlassThickness = 6.0f;
            _multiTransomModel2.MPanelLst_Panel.Add(_panelModel2);
            _panelModel2.Panel_Index_Inside_MPanel = 4;
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_" + panelID;
            _multiTransomModel2.MPanelLst_Objects.Add(fw2);

            #endregion

            #region _multiTransom3(2) as base

            int multiTransom3_totalPanelCount = _multiTransomModel3.MPanel_Divisions + 1;

            int multiTransom3_suggest_Wd = (((_multiTransomModel3.MPanel_Width) - (divSize * _multiTransomModel3.MPanel_Divisions)) / multiTransom3_totalPanelCount),
                multiTransom3_suggest_HT = _multiTransomModel3.MPanel_Height;

            mpanelID++;
            IMultiPanelModel _multiMullionModel6 = _multiPanelServices.AddMultiPanelModel(multiTransom3_suggest_Wd,
                                                                                          multiTransom3_suggest_HT,
                                                                                          p2p3Wd,
                                                                                          p4p11Ht,
                                                                                          multiTransom3,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          mpanelID,
                                                                                          DockStyle.Fill,
                                                                                          3,
                                                                                          0,
                                                                                          _multiTransomModel3,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          1);
            _multiMullionModel6.MPanel_Index_Inside_MPanel = 0;
            _multiMullionModel6.MPanel_Placement = "First";
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel6);
            _multiTransomModel3.MPanelLst_MultiPanel.Add(_multiMullionModel6);
            Control multimullion6 = new Control();
            multimullion6.Name = _multiMullionModel6.MPanel_Name;
            _multiTransomModel3.MPanelLst_Objects.Add(multimullion6);

            divID++;
            IDividerModel divModel_transom5 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiTransomModel3.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel3.MPanel_DisplayWidth,
                                                                              _multiTransomModel3.MPanel_DisplayHeight,
                                                                              _multiTransomModel3,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiTransomModel3.MPanelLst_Divider.Add(divModel_transom5);
            Control div_mullion5 = new Control();
            div_mullion5.Name = "TransomUC_" + divID;
            _multiTransomModel3.MPanelLst_Objects.Add(div_mullion5);

            mpanelID++;
            IMultiPanelModel _multiMullionModel7 = _multiPanelServices.AddMultiPanelModel(multiTransom3_suggest_Wd,
                                                                                          multiTransom3_suggest_HT,
                                                                                          p2p3Wd,
                                                                                          p4p11Ht,
                                                                                          multiTransom3,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          mpanelID,
                                                                                          DockStyle.Fill,
                                                                                          3,
                                                                                          0,
                                                                                          _multiTransomModel3,
                                                                                          _frameModel.FrameImageRenderer_Zoom,
                                                                                          "",
                                                                                          1);
            _multiMullionModel7.MPanel_Index_Inside_MPanel = 2;
            _multiMullionModel7.MPanel_Placement = "Somewhere in Between";
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel7);
            _multiTransomModel3.MPanelLst_MultiPanel.Add(_multiMullionModel7);
            Control multimullion7 = new Control();
            multimullion7.Name = _multiMullionModel7.MPanel_Name;
            _multiTransomModel3.MPanelLst_Objects.Add(multimullion7);

            divID++;
            IDividerModel divModel_transom6 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiTransomModel3.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Transom,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7536,
                                                                              _multiTransomModel3.MPanel_DisplayWidth,
                                                                              _multiTransomModel3.MPanel_DisplayHeight,
                                                                              _multiTransomModel3,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiTransomModel3.MPanelLst_Divider.Add(divModel_transom6);
            Control div_mullion6 = new Control();
            div_mullion6.Name = "TransomUC_" + divID;
            _multiTransomModel3.MPanelLst_Objects.Add(div_mullion6);

            panelID++;
            IPanelModel _panelModel3 = _panelServices.AddPanelModel(multiTransom3_suggest_Wd,
                                                                    multiTransom3_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiTransomModel3,
                                                                    p2p3Wd,
                                                                    p2p3Ht,
                                                                    GlazingBead_ArticleNo._2451,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel3.Panel_Placement = "Last";
            _panelModel3.Panel_GlassThickness = 6.0f;
            _multiTransomModel3.MPanelLst_Panel.Add(_panelModel3);
            _panelModel3.Panel_Index_Inside_MPanel = 4;
            Control fw3 = new Control();
            fw3.Name = "FixedPanelUC_" + panelID;
            _multiTransomModel3.MPanelLst_Objects.Add(fw3);

            #endregion //Level 2

            //Level 3
            #region _multiMullionModel4(2) as base

            int multiMullion4_totalPanelCount = _multiMullionModel4.MPanel_Divisions + 1;

            int multiMullion4_suggest_Wd = (((_multiMullionModel4.MPanel_Width) - (divSize * _multiMullionModel4.MPanel_Divisions)) / multiMullion4_totalPanelCount),
                multiMullion4_suggest_HT = _multiMullionModel4.MPanel_Height;

            panelID++;
            IPanelModel _panelModel4 = _panelServices.AddPanelModel(multiMullion4_suggest_Wd,
                                                                    multiMullion4_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel4,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel4.Panel_Placement = "First";
            _panelModel4.Panel_GlassThickness = 24.0f;
            _multiMullionModel4.MPanelLst_Panel.Add(_panelModel4);
            _panelModel4.Panel_Index_Inside_MPanel = 0;
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel4.MPanelLst_Objects.Add(fw4);

            divID++;
            IDividerModel divModel_mullion7 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel4.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel4.MPanel_DisplayWidth,
                                                                              _multiMullionModel4.MPanel_DisplayHeight,
                                                                              _multiMullionModel4,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiMullionModel4.MPanelLst_Divider.Add(divModel_mullion7);
            Control div_mullion7 = new Control();
            div_mullion7.Name = "MullionUC_" + divID;
            _multiMullionModel4.MPanelLst_Objects.Add(div_mullion7);

            panelID++;
            IPanelModel _panelModel5 = _panelServices.AddPanelModel(multiMullion4_suggest_Wd,
                                                                    multiMullion4_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel4,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel5.Panel_Placement = "Last";
            _panelModel5.Panel_GlassThickness = 24.0f;
            _multiMullionModel4.MPanelLst_Panel.Add(_panelModel5);
            _panelModel5.Panel_Index_Inside_MPanel = 2;
            Control fw5 = new Control();
            fw5.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel4.MPanelLst_Objects.Add(fw5);

            #endregion

            #region _multiMullionModel5(2) as base

            int multiMullion5_totalPanelCount = _multiMullionModel5.MPanel_Divisions + 1;

            int multiMullion5_suggest_Wd = (((_multiMullionModel5.MPanel_Width) - (divSize * _multiMullionModel5.MPanel_Divisions)) / multiMullion5_totalPanelCount),
                multiMullion5_suggest_HT = _multiMullionModel5.MPanel_Height;

            panelID++;
            IPanelModel _panelModel6 = _panelServices.AddPanelModel(multiMullion5_suggest_Wd,
                                                                    multiMullion5_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel5,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel6.Panel_Placement = "First";
            _panelModel6.Panel_GlassThickness = 24.0f;
            _multiMullionModel5.MPanelLst_Panel.Add(_panelModel6);
            _panelModel6.Panel_Index_Inside_MPanel = 0;
            Control fw6 = new Control();
            fw6.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel5.MPanelLst_Objects.Add(fw6);

            divID++;
            IDividerModel divModel_mullion8 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel5.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel5.MPanel_DisplayWidth,
                                                                              _multiMullionModel5.MPanel_DisplayHeight,
                                                                              _multiMullionModel5,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiMullionModel5.MPanelLst_Divider.Add(divModel_mullion8);
            Control div_mullion8 = new Control();
            div_mullion8.Name = "MullionUC_" + divID;
            _multiMullionModel5.MPanelLst_Objects.Add(div_mullion8);

            panelID++;
            IPanelModel _panelModel7 = _panelServices.AddPanelModel(multiMullion4_suggest_Wd,
                                                                    multiMullion4_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel5,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel7.Panel_Placement = "Last";
            _panelModel7.Panel_GlassThickness = 24.0f;
            _multiMullionModel5.MPanelLst_Panel.Add(_panelModel7);
            _panelModel5.Panel_Index_Inside_MPanel = 2;
            Control fw7 = new Control();
            fw7.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel5.MPanelLst_Objects.Add(fw7);

            #endregion

            #region _multiMullionModel6(2) as base

            int multiMullion6_totalPanelCount = _multiMullionModel6.MPanel_Divisions + 1;

            int multiMullion6_suggest_Wd = (((_multiMullionModel6.MPanel_Width) - (divSize * _multiMullionModel6.MPanel_Divisions)) / multiMullion5_totalPanelCount),
                multiMullion6_suggest_HT = _multiMullionModel6.MPanel_Height;

            panelID++;
            IPanelModel _panelModel8 = _panelServices.AddPanelModel(multiMullion6_suggest_Wd,
                                                                    multiMullion6_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel6,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel8.Panel_Placement = "First";
            _panelModel8.Panel_GlassThickness = 24.0f;
            _multiMullionModel6.MPanelLst_Panel.Add(_panelModel8);
            _panelModel8.Panel_Index_Inside_MPanel = 0;
            Control fw8 = new Control();
            fw8.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel6.MPanelLst_Objects.Add(fw8);

            divID++;
            IDividerModel divModel_mullion9 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel6.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel6.MPanel_DisplayWidth,
                                                                              _multiMullionModel6.MPanel_DisplayHeight,
                                                                              _multiMullionModel6,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiMullionModel6.MPanelLst_Divider.Add(divModel_mullion9);
            Control div_mullion9 = new Control();
            div_mullion9.Name = "MullionUC_" + divID;
            _multiMullionModel6.MPanelLst_Objects.Add(div_mullion9);

            panelID++;
            IPanelModel _panelModel9 = _panelServices.AddPanelModel(multiMullion4_suggest_Wd,
                                                                    multiMullion4_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel6,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel9.Panel_Placement = "Last";
            _panelModel9.Panel_GlassThickness = 24.0f;
            _multiMullionModel6.MPanelLst_Panel.Add(_panelModel9);
            _panelModel9.Panel_Index_Inside_MPanel = 2;
            Control fw9 = new Control();
            fw9.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel6.MPanelLst_Objects.Add(fw9);

            #endregion

            #region _multiMullionModel7(2) as base

            int multiMullion7_totalPanelCount = _multiMullionModel7.MPanel_Divisions + 1;

            int multiMullion7_suggest_Wd = (((_multiMullionModel7.MPanel_Width) - (divSize * _multiMullionModel7.MPanel_Divisions)) / multiMullion7_totalPanelCount),
                multiMullion7_suggest_HT = _multiMullionModel7.MPanel_Height;

            panelID++;
            IPanelModel _panelModel10 = _panelServices.AddPanelModel(multiMullion7_suggest_Wd,
                                                                    multiMullion7_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel7,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel10.Panel_Placement = "First";
            _panelModel10.Panel_GlassThickness = 24.0f;
            _multiMullionModel7.MPanelLst_Panel.Add(_panelModel10);
            _panelModel10.Panel_Index_Inside_MPanel = 0;
            Control fw10 = new Control();
            fw10.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel7.MPanelLst_Objects.Add(fw10);

            divID++;
            IDividerModel divModel_mullion10 = _dividerServices.AddDividerModel(divSize,
                                                                              _multiMullionModel7.MPanel_Height,
                                                                              new Control(),
                                                                              DividerModel.DividerType.Mullion,
                                                                              true,
                                                                              _frameModel.Frame_Zoom,
                                                                              Divider_ArticleNo._7538,
                                                                              _multiMullionModel7.MPanel_DisplayWidth,
                                                                              _multiMullionModel7.MPanel_DisplayHeight,
                                                                              _multiMullionModel7,
                                                                              divID,
                                                                              _frameModel.FrameImageRenderer_Zoom,
                                                                              _frameModel.Frame_Type.ToString());
            _multiMullionModel7.MPanelLst_Divider.Add(divModel_mullion10);
            Control div_mullion10 = new Control();
            div_mullion10.Name = "MullionUC_" + divID;
            _multiMullionModel7.MPanelLst_Objects.Add(div_mullion10);

            panelID++;
            IPanelModel _panelModel11 = _panelServices.AddPanelModel(multiMullion7_suggest_Wd,
                                                                    multiMullion7_suggest_HT,
                                                                    new Control(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    new UserControl(),
                                                                    "Fixed Panel",
                                                                    true,
                                                                    1.0f,
                                                                    null,
                                                                    _multiMullionModel7,
                                                                    p4p11Wd,
                                                                    p4p11Ht,
                                                                    GlazingBead_ArticleNo._2435,
                                                                    GlassFilm_Types._None,
                                                                    SashProfile_ArticleNo._None,
                                                                    SashReinf_ArticleNo._None,
                                                                   GlassType._Single,
                                                                   Espagnolette_ArticleNo._None,
                                                                   Striker_ArticleNo._M89ANT,
                                                                   MiddleCloser_ArticleNo._1WC70WHT,
                                                                   LockingKit_ArticleNo._T244002KMW,
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
                                                                   panelID);
            _panelModel11.Panel_Placement = "Last";
            _panelModel11.Panel_GlassThickness = 24.0f;
            _multiMullionModel7.MPanelLst_Panel.Add(_panelModel11);
            _panelModel11.Panel_Index_Inside_MPanel = 2;
            Control fw11 = new Control();
            fw11.Name = "FixedPanelUC_" + panelID;
            _multiMullionModel7.MPanelLst_Objects.Add(fw11);

            #endregion

            DataTable dt = _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2405, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1905, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2332, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1832, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);
            Assert.AreEqual(4, _qouteModel.Glass_SealantWHQty_Total);
            Assert.AreEqual(11, _qouteModel.GlazingSpacer_TotalQty);
            Assert.AreEqual(14000, _qouteModel.GlazingSeal_TotalQty);

            #region multimullion_1 controls

            Assert.AreEqual(Divider_ArticleNo._7538, divModel_mullion1.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel_mullion1.Div_ReinfArtNo);
            Assert.AreEqual(1842, divModel_mullion1.Div_ExplosionHeight);
            Assert.AreEqual(1732, divModel_mullion1.Div_ReinfHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel_mullion2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel_mullion2.Div_ReinfArtNo);
            Assert.AreEqual(1842, divModel_mullion2.Div_ExplosionHeight);
            Assert.AreEqual(1732, divModel_mullion2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1900, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(722, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1828, _panelModel1.Panel_GlassHeight);

            #endregion

            #region multiTransom_2 controls

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_transom3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_transom3.Div_ReinfArtNo);
            Assert.AreEqual(734, divModel_transom3.Div_ExplosionWidth);
            Assert.AreEqual(654, divModel_transom3.Div_ReinfWidth);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_transom4.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_transom4.Div_ReinfArtNo);
            Assert.AreEqual(734, divModel_transom4.Div_ExplosionWidth);
            Assert.AreEqual(654, divModel_transom4.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(950, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(725, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(890, _panelModel2.Panel_GlassHeight);

            #endregion

            #region multiTransom_3 controls

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_transom5.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_transom5.Div_ReinfArtNo);
            Assert.AreEqual(734, divModel_transom5.Div_ExplosionWidth);
            Assert.AreEqual(654, divModel_transom5.Div_ReinfWidth);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_transom6.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_transom6.Div_ReinfArtNo);
            Assert.AreEqual(734, divModel_transom6.Div_ExplosionWidth);
            Assert.AreEqual(654, divModel_transom6.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(800, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(950, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(725, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(890, _panelModel3.Panel_GlassHeight);

            #endregion

            #region multiMullion_4 controls

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(325, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(415, _panelModel4.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel_mullion7.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel_mullion7.Div_ReinfArtNo);
            Assert.AreEqual(429, divModel_mullion7.Div_ExplosionHeight);
            Assert.AreEqual(319, divModel_mullion7.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel5.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel5.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel5.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel5.Panel_GlassWidth);
            Assert.AreEqual(415, _panelModel5.Panel_GlassHeight);

            #endregion

            #region multiMullion_5 controls

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel6.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel6.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel6.Panel_GlazingBeadHeight);
            Assert.AreEqual(325, _panelModel6.Panel_GlassWidth);
            Assert.AreEqual(427, _panelModel6.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel_mullion8.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel_mullion8.Div_ReinfArtNo);
            Assert.AreEqual(441, divModel_mullion8.Div_ExplosionHeight);
            Assert.AreEqual(331, divModel_mullion8.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel7.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel7.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel7.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel7.Panel_GlassWidth);
            Assert.AreEqual(427, _panelModel7.Panel_GlassHeight);

            #endregion

            #region multiMullion_6 controls

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel8.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel8.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel8.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel8.Panel_GlassWidth);
            Assert.AreEqual(415, _panelModel8.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel_mullion9.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel_mullion9.Div_ReinfArtNo);
            Assert.AreEqual(429, divModel_mullion9.Div_ExplosionHeight);
            Assert.AreEqual(319, divModel_mullion9.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel9.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel9.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel9.Panel_GlazingBeadHeight);
            Assert.AreEqual(325, _panelModel9.Panel_GlassWidth);
            Assert.AreEqual(415, _panelModel9.Panel_GlassHeight);

            #endregion

            #region multiMullion_7 controls

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel10.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel10.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel10.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel10.Panel_GlassWidth);
            Assert.AreEqual(427, _panelModel10.Panel_GlassHeight);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel_mullion10.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel_mullion10.Div_ReinfArtNo);
            Assert.AreEqual(441, divModel_mullion10.Div_ExplosionHeight);
            Assert.AreEqual(331, divModel_mullion10.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2435, _panelModel11.PanelGlazingBead_ArtNo);
            Assert.AreEqual(400, _panelModel11.Panel_GlazingBeadWidth);
            Assert.AreEqual(475, _panelModel11.Panel_GlazingBeadHeight);
            Assert.AreEqual(325, _panelModel11.Panel_GlassWidth);
            Assert.AreEqual(427, _panelModel11.Panel_GlassHeight);

            #endregion

            #region Check Quantity

            DataRow[] dr;
            object sumObject;

            dr = dt.Select("Description = 'Frame Width 7502' AND Size = '2405'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Height 7502' AND Size = '1905'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Width R676' AND Size = '2332'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Frame Reinf Height R676' AND Size = '1832'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Height 7538' AND Size = '1842'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Reinforcement Height R686' AND Size = '1732'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Mullion Mechanical Joint AV585'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(12, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glazing Bead Height%' AND
                             Description LIKE '%2452%' AND 
                             Size = '1900'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(2, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Width%' AND
                             Size = '722'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select(@"Description LIKE '%Glass Height%' AND
                             Size = '1828'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(1, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Width 7536' AND Size = '734'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(4, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Reinforcement Width R677' AND Size = '654'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(4, dr[0]["Qty"]);

            dr = dt.Select("Description = 'Transom Mechanical Joint 9U18'");
            Assert.AreEqual(1, dr.Length);
            Assert.AreEqual(8, dr[0]["Qty"]);

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Width%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '800'");
            Assert.AreEqual(6, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Height%' AND
                                                 Description LIKE '%2452%' AND
                                                 Size = '950'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Width%' AND
                                                 Size = '725'");
            Assert.AreEqual(2, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass height%' AND
                                                 Size = '890'");
            Assert.AreEqual(2, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Width%' AND
                                                 Description LIKE '%2435%' AND
                                                 Size = '400'");
            Assert.AreEqual(16, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Height%' AND
                                                 Description LIKE '%2435%' AND
                                                 Size = '475'");
            Assert.AreEqual(16, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Width%' AND
                                                 Size = '325'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass height%' AND
                                                 Size = '415'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Width%' AND
                                                 Description LIKE '%2435%' AND
                                                 Size = '400'");
            Assert.AreEqual(16, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glazing Bead Height%' AND
                                                 Description LIKE '%2435%' AND
                                                 Size = '475'");
            Assert.AreEqual(16, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass Width%' AND
                                                 Size = '322'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            sumObject = dt.Compute("Sum(Qty)", @"Description LIKE '%Glass height%' AND
                                                 Size = '427'");
            Assert.AreEqual(4, Convert.ToInt32(sumObject));

            #endregion
        }

    }
}
