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
using System.Data;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.QuotationModel;

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

        [TestMethod]
        public void ChkVar_SinglePanelFixWindow()
        {
            int total_wd = 1000, total_height = 2000;

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
            Assert.AreEqual(1005, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(2005, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(932, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1932, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(2, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(934, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1934, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(928, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1928, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            //Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);
        }




        [TestMethod]
        public void chkvar_SinglePannelFix2()
        {
            int total_wd = 619, total_height = 925;

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
            Assert.AreEqual(624, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(930, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(551, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(857, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(1, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(553, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(859, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(547, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(853, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            //Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);
        }




        [TestMethod]
        public void ChkList_SinglePanelFixedWindow()
        {
            int total_wd = 1000, total_height = 2000;

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

            DataTable dt = _qouteModel.GetListOfMaterials();
            Assert.AreEqual("Description", dt.Columns[0].ColumnName);
            Assert.AreEqual("Qty", dt.Columns[1].ColumnName);
            Assert.AreEqual("Unit", dt.Columns[2].ColumnName);
            Assert.AreEqual("Size", dt.Columns[3].ColumnName);

            Assert.AreEqual("Frame Width _7502", dt.Rows[0]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[0]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[0]["Unit"].ToString());
            Assert.AreEqual("1005", dt.Rows[0]["Size"]);

            Assert.AreEqual("Frame Height _7502", dt.Rows[1]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[1]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
            Assert.AreEqual("2005", dt.Rows[1]["Size"]);

            Assert.AreEqual("Frame Reinf Width _R676", dt.Rows[2]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[2]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[2]["Unit"].ToString());
            Assert.AreEqual("932", dt.Rows[2]["Size"]);

            Assert.AreEqual("Frame Reinf Height _R676", dt.Rows[3]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[3]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[3]["Unit"].ToString());
            Assert.AreEqual("1932", dt.Rows[3]["Size"]);

            Assert.AreEqual("Glazing Bead Width _2452", dt.Rows[4]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[4]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[4]["Unit"].ToString());
            Assert.AreEqual("934", dt.Rows[4]["Size"]);

            Assert.AreEqual("Glazing Bead Height _2452", dt.Rows[5]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[5]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[5]["Unit"].ToString());
            Assert.AreEqual("1934", dt.Rows[5]["Size"]);

            Assert.AreEqual("Glass Width (6-8mm)", dt.Rows[6]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[6]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
            Assert.AreEqual("928", dt.Rows[6]["Size"]);

            Assert.AreEqual("Glass Height (6-8mm)", dt.Rows[7]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[7]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
            Assert.AreEqual("1928", dt.Rows[7]["Size"]);

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
        public void ChkList_SinglePanelFixedWindow2()
        {
            int total_wd = 619, total_height = 925;

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

            DataTable dt = _qouteModel.GetListOfMaterials();
            Assert.AreEqual("Description", dt.Columns[0].ColumnName);
            Assert.AreEqual("Qty", dt.Columns[1].ColumnName);
            Assert.AreEqual("Unit", dt.Columns[2].ColumnName);
            Assert.AreEqual("Size", dt.Columns[3].ColumnName);

            Assert.AreEqual("Frame Width _7502", dt.Rows[0]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[0]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[0]["Unit"].ToString());
            Assert.AreEqual("624", dt.Rows[0]["Size"]);

            Assert.AreEqual("Frame Height _7502", dt.Rows[1]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[1]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[1]["Unit"].ToString());
            Assert.AreEqual("930", dt.Rows[1]["Size"]);

            Assert.AreEqual("Frame Reinf Width _R676", dt.Rows[2]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[2]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[2]["Unit"].ToString());
            Assert.AreEqual("551", dt.Rows[2]["Size"]);

            Assert.AreEqual("Frame Reinf Height _R676", dt.Rows[3]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[3]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[3]["Unit"].ToString());
            Assert.AreEqual("857", dt.Rows[3]["Size"]);

            Assert.AreEqual("Glazing Bead Width _2452", dt.Rows[4]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[4]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[4]["Unit"].ToString());
            Assert.AreEqual("553", dt.Rows[4]["Size"]);

            Assert.AreEqual("Glazing Bead Height _2452", dt.Rows[5]["Description"].ToString());
            Assert.AreEqual(2, dt.Rows[5]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[5]["Unit"].ToString());
            Assert.AreEqual("859", dt.Rows[5]["Size"]);

            Assert.AreEqual("Glass Width (6-8mm)", dt.Rows[6]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[6]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[6]["Unit"].ToString());
            Assert.AreEqual("547", dt.Rows[6]["Size"]);

            Assert.AreEqual("Glass Height (6-8mm)", dt.Rows[7]["Description"].ToString());
            Assert.AreEqual(1, dt.Rows[7]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[7]["Unit"].ToString());
            Assert.AreEqual("853", dt.Rows[7]["Size"]);

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
            Assert.AreEqual(1, dt.Rows[11]["Qty"]);
            Assert.AreEqual("pc(s)", dt.Rows[11]["Unit"].ToString());
            Assert.AreEqual("", dt.Rows[11]["Size"]);

        }


        [TestMethod]
        public void ChkVar_2EQualPanelFW_WithTransom()
        {
            int total_wd = 550, total_height = 1200,
                eqpanelWD = 550, eqpanelHT = 600;

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

            IMultiPanelModel _multipanelModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       total_wd,
                                                                                       total_height,
                                                                                       new Control(),
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
                                                                   GlazingBead_ArticleNo._2452,
                                                                   1);
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
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
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
                                                                   null,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   eqpanelHT,
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   2);
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(1, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(484, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(546, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            //Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel.Div_ReinfArtNo);
            Assert.AreEqual(487, divModel.Div_ExplosionWidth);
            Assert.AreEqual(407, divModel.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(484, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(546, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);
            //Assert.AreEqual(1, _panelModel2.Panel_SealantWHQty);
        }


        [TestMethod]
        public void ChkVar_2UnEQualPanelFW_WithTransom()
        {
            int total_wd = 550, total_height = 1200,
                 uneqpanelHT1 = 700, uneqpanelHT2 = 500, eqpanelWD = 550;

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

            IMultiPanelModel _multipanelModel = _multiPanelServices.AddMultiPanelModel(wd,
                                                                                       ht,
                                                                                       total_wd,
                                                                                       total_height,
                                                                                       new Control(),
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
                                                                   uneqpanelHT1,
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   1);
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
                                                                      1,
                                                                      _frameModel.FrameImageRenderer_Zoom,
                                                                      _frameModel.Frame_Type.ToString());
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
                                                                   null,
                                                                   _multipanelModel,
                                                                   eqpanelWD,
                                                                   uneqpanelHT2,
                                                                   Glass_Thickness._6mm,
                                                                   GlazingBead_ArticleNo._2452,
                                                                   2);
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            _qouteModel.GetListOfMaterials();

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _frameModel.Frame_PUFoamingQty);
            Assert.AreEqual(1, _frameModel.Frame_SealantWHQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(484, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(646, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(640, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);
            //Assert.AreEqual(1, _panelModel.Panel_SealantWHQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel.Div_ReinfArtNo);
            Assert.AreEqual(487, divModel.Div_ExplosionWidth);
            Assert.AreEqual(407, divModel.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(484, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(446, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(440, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);
            //Assert.AreEqual(1, _panelModel2.Panel_SealantWHQty);
        }
    }
}
