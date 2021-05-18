using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;
using System.Data;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.QuotationModel;
using ServiceLayer.Services.DividerServices;
using ModelLayer.Model.Quotation.Divider;

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
                                                                   total_wd,
                                                                   total_height,
                                                                   Glass_Thickness._6mm,
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
            Assert.AreEqual("505", dt.Rows[0]["Size"]);

            Assert.AreEqual("Frame Height _7502", dt.Rows[1]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[1]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
            Assert.AreEqual("1505", dt.Rows[1]["Size"]);

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

            Assert.AreEqual("Glass Width (_6mm)", dt.Rows[6]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[6]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
            Assert.AreEqual("428", dt.Rows[6]["Size"]);

            Assert.AreEqual("Glass Height (_6mm)", dt.Rows[7]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[7]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
            Assert.AreEqual("1428", dt.Rows[7]["Size"]);

            Assert.AreEqual("Glazing Spacer (KBC70)", dt.Rows[8]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[8]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[8]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[8]["Size"]);

            Assert.AreEqual("Sealant-WH (Glass)", dt.Rows[9]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[9]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[9]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[9]["Size"]);

            Assert.AreEqual("PU Foaming", dt.Rows[10]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[10]["Qty"]);
            Assert.AreEqual("can", dt.Rows[10]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[10]["Size"]);

            Assert.AreEqual("Sealant-WH (Frame)", dt.Rows[11]["Description"].ToString());
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
                                                                   total_wd,
                                                                   total_height,
                                                                   Glass_Thickness._6mm,
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
                                                                   total_wd,
                                                                   total_height,
                                                                   Glass_Thickness._6mm,
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

        [TestMethod]
        public void ChkVar_2EQualPanelFW_WithMullion()
        {
            int total_wd = 900, total_height = 1300,
                eqpanelWD = 450, eqpanelHT = 1300;

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

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IMultiPanelModel _multipanelModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       frame,
                                                                                       new UserControl(),
                                                                                       _frameModel,
                                                                                       true,
                                                                                       FlowDirection.LeftToRight,
                                                                                       _frameModel.Frame_Zoom,
                                                                                       1,
                                                                                       DockStyle.Fill,
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   1);
            _panelModel.Panel_Placement = "First";
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(905, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1305, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(832, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1232, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(2, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(381, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1234, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(375, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel.Div_ReinfArtNo);
            Assert.AreEqual(1242, divModel.Div_ExplosionHeight);
            Assert.AreEqual(1132, divModel.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(381, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1234, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(375, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _panelModel2.Panel_SealantWHQty);
        }

        [TestMethod]
        public void ChkVar_2UnequalPanelFW_WithMullion()
        {
            int total_wd = 900, total_height = 1300,
                uneqpanelWD1 = 400, uneqpanelWD2 = 500, eqpanelHT = 1300;

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

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IMultiPanelModel _multipanelModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       frame,
                                                                                       new UserControl(),
                                                                                       _frameModel,
                                                                                       true,
                                                                                       FlowDirection.LeftToRight,
                                                                                       _frameModel.Frame_Zoom,
                                                                                       1,
                                                                                       DockStyle.Fill,
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   1);
            _panelModel.Panel_Placement = "First";
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(905, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1305, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(832, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1232, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(2, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(331, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1234, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(325, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);

            Assert.AreEqual(Divider_ArticleNo._7538, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, divModel.Div_ReinfArtNo);
            Assert.AreEqual(1242, divModel.Div_ExplosionHeight);
            Assert.AreEqual(1132, divModel.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(431, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1234, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(425, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1228, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _panelModel2.Panel_SealantWHQty);
        }

        [TestMethod]
        public void ChkVar_4PanelFixedWindow_WithMullionTransom()
        {
            int total_wd = 550, total_ht = 1200,
                eqpanelwd = 275, eqpanelht = 600;

            IWindoorModel _windoorModel = _windoorServices.AddWindoorModel(total_wd, total_ht, "C70", 1);
            _qouteModel.Lst_Windoor.Add(_windoorModel);

            IFrameModel _frameModel = _frameServices.AddFrameModel(total_wd,
                                                                   total_ht,
                                                                   FrameModel.Frame_Padding.Window,
                                                                   1.0f,
                                                                   1.0f,
                                                                   FrameProfile_ArticleNo._7502,
                                                                   1);
            _windoorModel.lst_frame.Add(_frameModel);

            int wd = _frameModel.Frame_Width - (int)(_frameModel.Frame_Type - 10) * 2,
                ht = _frameModel.Frame_Height - (int)(_frameModel.Frame_Type - 10) * 2;

            Control frame = new Control();
            frame.Name = _frameModel.Frame_Name;

            IMultiPanelModel _multiTransomModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       frame,
                                                                                       new UserControl(),
                                                                                       _frameModel,
                                                                                       true,
                                                                                       FlowDirection.TopDown,
                                                                                       _frameModel.Frame_Zoom,
                                                                                       1,
                                                                                       DockStyle.Fill,
                                                                                       0,
                                                                                       null,
                                                                                       _frameModel.FrameImageRenderer_Zoom);
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
                                                                                          multiTransom,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          2,
                                                                                          DockStyle.None,
                                                                                          0,
                                                                                          _multiTransomModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom);
            _multiMullionModel1.MPanel_Placement = "First";
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
                                                                                          multiTransom,
                                                                                          new UserControl(),
                                                                                          _frameModel,
                                                                                          true,
                                                                                          FlowDirection.LeftToRight,
                                                                                          _frameModel.Frame_Zoom,
                                                                                          3,
                                                                                          DockStyle.None,
                                                                                          0,
                                                                                          _multiTransomModel,
                                                                                          _frameModel.FrameImageRenderer_Zoom);
            _multiMullionModel2.MPanel_Placement = "Last";
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   1);
            _panelModel1.Panel_Placement = "First";
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   2);
            _panelModel2.Panel_Placement = "Last";
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   3);
            _panelModel3.Panel_Placement = "First";
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
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2451,
                                                                   4);
            _panelModel4.Panel_Placement = "Last";
            _multiMullionModel2.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiMullionModel2.MPanelLst_Objects.Add(fw4);

            #endregion

            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel2);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(1, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(Divider_ArticleNo._7536, transomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, transomModel.Div_ReinfArtNo);
            Assert.AreEqual(487, transomModel.Div_ExplosionWidth);
            Assert.AreEqual(407, transomModel.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(221, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(546, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(215, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);
            Assert.AreEqual(2, _panelModel1.Panel_SealantWHQty);
        }
    }
}
