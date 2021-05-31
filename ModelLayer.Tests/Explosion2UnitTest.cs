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
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(934, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(1934, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(928, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(1928, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

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
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(553, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(859, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(547, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(853, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

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

            //          |――――――――――――|
            //          |            |
            //          |            |
            //          |――――――――――――|
            //          |            |
            //          |            |
            //          |____________|


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
            _panelModel.Panel_Placement = "First";
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
            _panelModel2.Panel_Placement = "Last";
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(1, _qouteModel.Frame_SealantWHQty_Total);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(484, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(546, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(540, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

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
            _panelModel.Panel_Placement = "First";
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
            _panelModel2.Panel_Placement = "Last";
            _multipanelModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multipanelModel.MPanelLst_Objects.Add(fw2);

            _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(555, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1205, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(482, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1132, _frameModel.Frame_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2452, _panelModel.PanelGlazingBead_ArtNo);
            Assert.AreEqual(484, _panelModel.Panel_GlazingBeadWidth);
            Assert.AreEqual(646, _panelModel.Panel_GlazingBeadHeight);
            Assert.AreEqual(478, _panelModel.Panel_GlassWidth);
            Assert.AreEqual(640, _panelModel.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel.Panel_GlazingSpacerQty);

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
                eqpanelwd = 600, eqpanelht = 800;

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

            int suggest_Wd = (((_multiMullionModel.MPanel_Width) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount),
                suggest_HT = _multiMullionModel.MPanel_Height;


            int displayWidth2 = _multiMullionModel.MPanel_DisplayWidth / (_multiMullionModel.MPanel_Divisions + 1),
                displayHeight2 = _multiMullionModel.MPanel_DisplayHeight;

            #region multiMullionPlatform
            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                         suggest_HT,
                                                                                         displayWidth2,
                                                                                         displayHeight2,
                                                                                         multiMullion,
                                                                                         new UserControl(),
                                                                                         _frameModel,
                                                                                         true,
                                                                                         FlowDirection.TopDown,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         3,
                                                                                         DockStyle.None,
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
                                                                    1,
                                                                    _frameModel.FrameImageRenderer_Zoom,
                                                                    _frameModel.Frame_Type.ToString());
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion);


            IMultiPanelModel _multiTransomModel2 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                        suggest_HT,
                                                                                        displayWidth2,
                                                                                        displayHeight2,
                                                                                        multiMullion,
                                                                                        new UserControl(),
                                                                                        _frameModel,
                                                                                        true,
                                                                                        FlowDirection.TopDown,
                                                                                        _frameModel.Frame_Zoom,
                                                                                        4,
                                                                                        DockStyle.None,
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
                                                                  2,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString());
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel2);
            Control div_mullion2 = new Control();
            div_mullion2.Name = "MullionUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion2);

            IMultiPanelModel _multiTransomModel3 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                      suggest_HT,
                                                                                      displayWidth2,
                                                                                      displayHeight2,
                                                                                      multiMullion,
                                                                                      new UserControl(),
                                                                                      _frameModel,
                                                                                      true,
                                                                                      FlowDirection.TopDown,
                                                                                      _frameModel.Frame_Zoom,
                                                                                      5,
                                                                                      DockStyle.None,
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
                                                                 null,
                                                                 _multiTransomModel1,
                                                                 eqpanelwd,
                                                                 eqpanelht,
                                                                 Glass_Thickness._6mm,
                                                                 GlazingBead_ArticleNo._2451,
                                                                 1);
            _panelModel1.Panel_Placement = "First";
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
                                                                  3,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString());
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
                                                                  null,
                                                                  _multiTransomModel1,
                                                                  eqpanelwd,
                                                                  eqpanelht,
                                                                  Glass_Thickness._6mm,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  2);
            _panelModel2.Panel_Placement = "Last";
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
                                                               null,
                                                               _multiTransomModel2,
                                                               eqpanelwd,
                                                               eqpanelht,
                                                               Glass_Thickness._6mm,
                                                               GlazingBead_ArticleNo._2451,
                                                               3);
            _panelModel3.Panel_Placement = "First";
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
                                                      4,
                                                      _frameModel.FrameImageRenderer_Zoom,
                                                      _frameModel.Frame_Type.ToString());

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
                                                              null,
                                                              _multiTransomModel2,
                                                              eqpanelwd,
                                                              eqpanelht,
                                                              Glass_Thickness._6mm,
                                                              GlazingBead_ArticleNo._2451,
                                                              4);
            _panelModel4.Panel_Placement = "Last";
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
                                                             null,
                                                             _multiTransomModel3,
                                                             eqpanelwd,
                                                             eqpanelht,
                                                             Glass_Thickness._6mm,
                                                             GlazingBead_ArticleNo._2451,
                                                             5);
            _panelModel5.Panel_Placement = "First";
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
                                                     5,
                                                     _frameModel.FrameImageRenderer_Zoom,
                                                     _frameModel.Frame_Type.ToString());
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
                                                          null,
                                                          _multiTransomModel3,
                                                          eqpanelwd,
                                                          eqpanelht,
                                                          Glass_Thickness._6mm,
                                                          GlazingBead_ArticleNo._2451,
                                                          6);
            _panelModel6.Panel_Placement = "Last";
            _panelModel6.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel3.MPanelLst_Panel.Add(_panelModel6);
            Control fw6 = new Control();
            fw6.Name = "FixedPanelUC_6";
            _multiTransomModel3.MPanelLst_Objects.Add(fw6);




            #endregion

            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel2);
            _frameModel.Lst_MultiPanel.Add(_multiTransomModel3);


            _qouteModel.GetListOfMaterials(_windoorModel);


            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(1805, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1605, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(1732, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1532, _frameModel.Frame_ReinfHeight);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(2, _qouteModel.Frame_SealantWHQty_Total);

            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1537, mullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1457, mullionModel.Div_ReinfHeight);


            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1537, mullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1457, mullionModel2.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(546, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(746, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(540, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom.Div_ReinfArtNo);
            Assert.AreEqual(549, divModel_Transom.Div_ExplosionWidth);
            Assert.AreEqual(469, divModel_Transom.Div_ReinfWidth);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(546, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(746, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(540, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(558, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(746, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(552, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom2.Div_ReinfArtNo);
            Assert.AreEqual(561, divModel_Transom2.Div_ExplosionWidth);
            Assert.AreEqual(481, divModel_Transom2.Div_ReinfWidth);



            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(558, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(746, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(552, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel5.PanelGlazingBead_ArtNo);
            Assert.AreEqual(546, _panelModel5.Panel_GlazingBeadWidth);
            Assert.AreEqual(746, _panelModel5.Panel_GlazingBeadHeight);
            Assert.AreEqual(540, _panelModel5.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel5.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel5.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom3.Div_ReinfArtNo);
            Assert.AreEqual(549, divModel_Transom3.Div_ExplosionWidth);
            Assert.AreEqual(469, divModel_Transom3.Div_ReinfWidth);


            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel6.PanelGlazingBead_ArtNo);
            Assert.AreEqual(546, _panelModel6.Panel_GlazingBeadWidth);
            Assert.AreEqual(746, _panelModel6.Panel_GlazingBeadHeight);
            Assert.AreEqual(540, _panelModel6.Panel_GlassWidth);
            Assert.AreEqual(740, _panelModel6.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel6.Panel_GlazingSpacerQty);
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
              eqpanelwd = 700, eqpanelht = 850;

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
                                                                 null,
                                                                 _multiMullionModel,
                                                                 eqpanelwd,
                                                                 total_ht,
                                                                 Glass_Thickness._6mm,
                                                                 GlazingBead_ArticleNo._2451,
                                                                 1);
            _panelModel1.Panel_Placement = "First";
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
                                                                  1,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString());
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion);



            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                    suggest_HT,
                                                                                    displayWidth2,
                                                                                    displayHeight2,
                                                                                    multiMullion,
                                                                                    new UserControl(),
                                                                                    _frameModel,
                                                                                    true,
                                                                                    FlowDirection.TopDown,
                                                                                    _frameModel.Frame_Zoom,
                                                                                    1,
                                                                                    DockStyle.None,
                                                                                    0,
                                                                                    _multiMullionModel,
                                                                                    _frameModel.FrameImageRenderer_Zoom,
                                                                                    "",
                                                                                    2);
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
                                                               2,
                                                               _frameModel.FrameImageRenderer_Zoom,
                                                               _frameModel.Frame_Type.ToString());
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
                                                                 null,
                                                                 _multiMullionModel,
                                                                 eqpanelwd,
                                                                 total_ht,
                                                                 Glass_Thickness._6mm,
                                                                 GlazingBead_ArticleNo._2451,
                                                                 2);
            _panelModel2.Panel_Placement = "Last";
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
                                                               null,
                                                               _multiTransomModel1,
                                                               eqpanelwd,
                                                               eqpanelht,
                                                               Glass_Thickness._6mm,
                                                               GlazingBead_ArticleNo._2451,
                                                               3);
            _panelModel3.Panel_Placement = "First";
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
                                                                  3,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString());
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
                                                            null,
                                                            _multiTransomModel1,
                                                            eqpanelwd,
                                                            eqpanelht,
                                                            Glass_Thickness._6mm,
                                                            GlazingBead_ArticleNo._2451,
                                                            4);
            _panelModel4.Panel_Placement = "Last";
            _panelModel4.Panel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_Panel.Add(_panelModel4);
            Control fw4 = new Control();
            fw4.Name = "FixedPanelUC_4";
            _multiTransomModel1.MPanelLst_Objects.Add(fw4);


            #endregion

            _frameModel.Lst_MultiPanel.Add(_multiTransomModel1);
            _qouteModel.GetListOfMaterials(_windoorModel);





            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2105, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1705, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2032, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1632, _frameModel.Frame_ReinfHeight);




            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(646, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1634, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(640, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1628, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);
            Assert.AreEqual(1, _qouteModel.Frame_PUFoamingQty_Total);
            Assert.AreEqual(3, _qouteModel.Frame_SealantWHQty_Total);





            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1637, mullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1557, mullionModel.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(658, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(796, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(652, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(790, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7536, divModel_Transom.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, divModel_Transom.Div_ReinfArtNo);
            Assert.AreEqual(661, divModel_Transom.Div_ExplosionWidth);
            Assert.AreEqual(581, divModel_Transom.Div_ReinfWidth);


            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(658, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(796, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(652, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(790, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7536, mullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1637, mullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1557, mullionModel2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(646, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1634, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(640, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1628, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);



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
                eqpanelwd1 = 800, eqpanelht1 = 1950,
                eqpanelwd3 = 400, eqpanelht3 = 975;

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


            //int displayWidth = _frameModel.Frame_Width,
            //  displayHeight = _frameModel.Frame_Height;


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

            //int displayWidth2 = _multiMullionModel.MPanel_DisplayWidth,
            //   displayHeight2 = _multiMullionModel.MPanel_DisplayHeight / (_multiMullionModel.MPanel_Divisions + 1);


            int suggest_Wd = _multiMullionModel.MPanel_Width,
                suggest_HT = (((_multiMullionModel.MPanel_Height) - (divSize * _multiMullionModel.MPanel_Divisions)) / multiTransom_totalPanelCount);

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
                                                                 null,
                                                                 _multiMullionModel,
                                                                 eqpanelwd1,
                                                                 eqpanelht1,
                                                                 Glass_Thickness._6mm,
                                                                 GlazingBead_ArticleNo._2451,
                                                                 1);
            _panelModel1.Panel_Placement = "First";
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
                                                                  1,
                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                  _frameModel.Frame_Type.ToString());
            _multiMullionModel.MPanelLst_Divider.Add(mullionModel);
            Control div_mullion = new Control();
            div_mullion.Name = "MullionUC_1";
            _multiMullionModel.MPanelLst_Objects.Add(div_mullion);



            IMultiPanelModel _multiTransomModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                    suggest_HT,
                                                                                    eqpanelwd1,
                                                                                    eqpanelht1,
                                                                                    multiMullion,
                                                                                    new UserControl(),
                                                                                    _frameModel,
                                                                                    true,
                                                                                    FlowDirection.TopDown,
                                                                                    _frameModel.Frame_Zoom,
                                                                                    2,
                                                                                    DockStyle.None,
                                                                                    0,
                                                                                    _multiMullionModel,
                                                                                    _frameModel.FrameImageRenderer_Zoom
                                                                                    );
            _multiTransomModel1.MPanel_Placement = "Somewhere in Between";
            _multiTransomModel1.MPanel_Index_Inside_MPanel = 2;
            _multiMullionModel.MPanelLst_MultiPanel.Add(_multiTransomModel1);
            Control multiMullion2 = new Control();
            multiMullion2.Name = "MultiTransom_2";
            _multiMullionModel.MPanelLst_Objects.Add(multiMullion2);

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
                                                               2,
                                                               _frameModel.FrameImageRenderer_Zoom,
                                                               _frameModel.Frame_Type.ToString());
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
                                                                 null,
                                                                 _multiMullionModel,
                                                                 eqpanelwd1,
                                                                 eqpanelht1,
                                                                 Glass_Thickness._6mm,
                                                                 GlazingBead_ArticleNo._2451,
                                                                 2);
            _panelModel2.Panel_Placement = "Last";
            _panelModel2.Panel_Index_Inside_MPanel = 4;
            _multiMullionModel.MPanelLst_Panel.Add(_panelModel2);
            Control fw2 = new Control();
            fw2.Name = "FixedPanelUC_2";
            _multiMullionModel.MPanelLst_Objects.Add(fw2);


            #endregion

            #region multiTransomplatform

            int multiTransom1_totalPanelCount = _multiTransomModel1.MPanel_Divisions + 1;

            //int displayWidth3 = _multiTransomModel1.MPanel_DisplayWidth  / (_multiTransomModel1.MPanel_Divisions + 1),
            //    displayHeight3 = _multiTransomModel1.MPanel_DisplayHeight;


            int multiTransom1_suggest_Wd = (((_multiTransomModel1.MPanel_Width) - (divSize * _multiTransomModel1.MPanel_Divisions)) / multiTransom1_totalPanelCount),
                multiTransom1_suggest_HT = _multiTransomModel1.MPanel_Height;


            IMultiPanelModel _multiMullionModel1 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                    suggest_HT,
                                                                                    eqpanelwd3,
                                                                                    eqpanelht3,
                                                                                    multiMullion,
                                                                                    new UserControl(),
                                                                                    _frameModel,
                                                                                    true,
                                                                                    FlowDirection.TopDown,
                                                                                    _frameModel.Frame_Zoom,
                                                                                    3,
                                                                                    DockStyle.None,
                                                                                    0,
                                                                                    _multiTransomModel1,
                                                                                    _frameModel.FrameImageRenderer_Zoom
                                                                                    );
            _multiMullionModel1.MPanel_Placement = "First";
            _multiMullionModel1.MPanel_Index_Inside_MPanel = 0;
            _multiTransomModel1.MPanelLst_MultiPanel.Add(_multiMullionModel1);
            Control multiMullion3 = new Control();
            multiMullion3.Name = "MultiMullion_3";
            _multiTransomModel1.MPanelLst_Objects.Add(multiMullion3);


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
                                                          3,
                                                          _frameModel.FrameImageRenderer_Zoom,
                                                          _frameModel.Frame_Type.ToString());
            _multiTransomModel1.MPanelLst_Divider.Add(transomModel);
            Control div_Transom3 = new Control();
            div_Transom3.Name = "TransomUC_3";
            _multiTransomModel1.MPanelLst_Objects.Add(div_Transom3);



            IMultiPanelModel _multiMullionModel2 = _multiPanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                      suggest_HT,
                                                                                      eqpanelwd3,
                                                                                      eqpanelht3,
                                                                                      multiMullion,
                                                                                      new UserControl(),
                                                                                      _frameModel,
                                                                                      true,
                                                                                      FlowDirection.LeftToRight,
                                                                                      _frameModel.Frame_Zoom,
                                                                                      4,
                                                                                      DockStyle.None,
                                                                                      0,
                                                                                      _multiTransomModel1,
                                                                                      _frameModel.FrameImageRenderer_Zoom
                                                                                      );
            _multiMullionModel2.MPanel_Placement = "Last";
            _multiMullionModel2.MPanel_Index_Inside_MPanel = 2;
            _multiTransomModel1.MPanelLst_MultiPanel.Add(_multiMullionModel2);
            Control multiMullion4 = new Control();
            multiMullion4.Name = "MultiMullion_4";
            _multiTransomModel1.MPanelLst_Objects.Add(multiMullion4);


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
                                                                  null,
                                                                  _multiMullionModel1,
                                                                  eqpanelwd3,
                                                                  eqpanelht3,
                                                                  Glass_Thickness._6mm,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  3);
            _panelModel3.Panel_Placement = "First";
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
                                                       4,
                                                       _frameModel.FrameImageRenderer_Zoom,
                                                       _frameModel.Frame_Type.ToString());
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
                                                                  null,
                                                                  _multiMullionModel1,
                                                                  eqpanelwd3,
                                                                  eqpanelht3,
                                                                  Glass_Thickness._6mm,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  4);
            _panelModel4.Panel_Placement = "Last";
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
                                                                  null,
                                                                  _multiMullionModel2,
                                                                  eqpanelwd3,
                                                                  eqpanelht3,
                                                                  Glass_Thickness._6mm,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  5);
            _panelModel5.Panel_Placement = "First";
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
                                                       5,
                                                       _frameModel.FrameImageRenderer_Zoom,
                                                       _frameModel.Frame_Type.ToString());
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
                                                                  null,
                                                                  _multiMullionModel2,
                                                                  eqpanelwd3,
                                                                  eqpanelht3,
                                                                  Glass_Thickness._6mm,
                                                                  GlazingBead_ArticleNo._2451,
                                                                  6);
            _panelModel6.Panel_Placement = "Last";
            _panelModel6.Panel_Index_Inside_MPanel = 2;
            _multiMullionModel2.MPanelLst_Panel.Add(_panelModel5);
            Control fw6 = new Control();
            fw6.Name = "FixedPanelUC_6";
            _multiMullionModel2.MPanelLst_Objects.Add(fw4);



            #endregion


            _frameModel.Lst_MultiPanel.Add(_multiMullionModel);
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel1);
            _frameModel.Lst_MultiPanel.Add(_multiMullionModel2);

            _qouteModel.GetListOfMaterials(_windoorModel);

            Assert.AreEqual(FrameProfile_ArticleNo._7502, _frameModel.Frame_ArtNo);
            Assert.AreEqual(2405, _frameModel.Frame_ExplosionWidth);
            Assert.AreEqual(1955, _frameModel.Frame_ExplosionHeight);
            Assert.AreEqual(FrameReinf_ArticleNo._R676, _frameModel.Frame_ReinfArtNo);
            Assert.AreEqual(2332, _frameModel.Frame_ReinfWidth);
            Assert.AreEqual(1882, _frameModel.Frame_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel1.PanelGlazingBead_ArtNo);
            Assert.AreEqual(731, _panelModel1.Panel_GlazingBeadWidth);
            Assert.AreEqual(1884, _panelModel1.Panel_GlazingBeadHeight);
            Assert.AreEqual(725, _panelModel1.Panel_GlassWidth);
            Assert.AreEqual(1878, _panelModel1.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel1.Panel_GlazingSpacerQty);

            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, mullionModel.Div_ReinfArtNo);
            Assert.AreEqual(1892, mullionModel.Div_ExplosionHeight);
            Assert.AreEqual(1782, mullionModel.Div_ReinfHeight);





            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel3.PanelGlazingBead_ArtNo);
            Assert.AreEqual(328, _panelModel3.Panel_GlazingBeadWidth);
            Assert.AreEqual(906, _panelModel3.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel3.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel3.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel3.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel3.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, mullionModel3.Div_ReinfArtNo);
            Assert.AreEqual(914, mullionModel3.Div_ExplosionHeight);
            Assert.AreEqual(804, mullionModel3.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel4.PanelGlazingBead_ArtNo);
            Assert.AreEqual(328, _panelModel4.Panel_GlazingBeadWidth);
            Assert.AreEqual(906, _panelModel4.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel4.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel4.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel4.Panel_GlazingSpacerQty);





            Assert.AreEqual(Divider_ArticleNo._7538, transomModel.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R686, transomModel.Div_ReinfArtNo);
            Assert.AreEqual(736, transomModel.Div_ExplosionWidth);
            Assert.AreEqual(626, transomModel.Div_ReinfWidth);





            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel5.PanelGlazingBead_ArtNo);
            Assert.AreEqual(328, _panelModel5.Panel_GlazingBeadWidth);
            Assert.AreEqual(906, _panelModel5.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel5.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel5.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel5.Panel_GlazingSpacerQty);


            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel4.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel4.Div_ReinfArtNo);
            Assert.AreEqual(914, mullionModel4.Div_ReinfHeight);
            Assert.AreEqual(804, mullionModel4.Div_ReinfHeight);


            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel6.PanelGlazingBead_ArtNo);
            Assert.AreEqual(328, _panelModel6.Panel_GlazingBeadWidth);
            Assert.AreEqual(906, _panelModel6.Panel_GlazingBeadHeight);
            Assert.AreEqual(322, _panelModel6.Panel_GlassWidth);
            Assert.AreEqual(900, _panelModel6.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel6.Panel_GlazingSpacerQty);






            Assert.AreEqual(Divider_ArticleNo._7538, mullionModel2.Div_ArtNo);
            Assert.AreEqual(DividerReinf_ArticleNo._R677, mullionModel2.Div_ReinfArtNo);
            Assert.AreEqual(1892, mullionModel2.Div_ExplosionHeight);
            Assert.AreEqual(1782, mullionModel2.Div_ReinfHeight);

            Assert.AreEqual(GlazingBead_ArticleNo._2451, _panelModel2.PanelGlazingBead_ArtNo);
            Assert.AreEqual(731, _panelModel2.Panel_GlazingBeadWidth);
            Assert.AreEqual(1884, _panelModel2.Panel_GlazingBeadHeight);
            Assert.AreEqual(725, _panelModel2.Panel_GlassWidth);
            Assert.AreEqual(1878, _panelModel2.Panel_GlassHeight);
            Assert.AreEqual(1, _panelModel2.Panel_GlazingSpacerQty);



        }



    }
}
