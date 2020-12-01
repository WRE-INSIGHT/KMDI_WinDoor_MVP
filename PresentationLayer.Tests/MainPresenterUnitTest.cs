using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using Unity;
using Unity.Lifetime;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.WindoorServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.CommonServices;
using System.Collections.Generic;
using ModelLayer.Model.User;
using ServiceLayer.Services.UserServices;
using QueryLayer.DataAccess.Repositories.Specific.User;
using Unity.Injection;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class MainPresenterUnitTest
    {
        private IMainView _mainView;
        private IfrmDimensionView _frmDimensionView;

        private IMainPresenter _mainPresenter;
        [TestInitialize]
        public void SetUp()
        {
            string _sqlconStr = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='KMDIDATA';User ID='kmdiadmin';Password='kmdiadmin';";

            IUnityContainer UnityC;
            UnityC =
                new UnityContainer()
                .RegisterType<ILoginView, LoginView>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginPresenter, LoginPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserServices, UserServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IUserModel, UserModel>(new ContainerControlledLifetimeManager())
                .RegisterType<IUserLoginModel, UserLoginModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IQuotationServices, QuotationServices>(new ContainerControlledLifetimeManager())

                .RegisterType<IWindoorServices, WindoorServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IWindoorModel, WindoorModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IFrameServices, FrameServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IFrameModel, FrameModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager())

                .RegisterType<IFrameUC, FrameUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFrameUCPresenter, FrameUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IItemInfoUC, ItemInfoUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IItemInfoUCPresenter, ItemInfoUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IfrmDimensionView, frmDimensionView>(new ContainerControlledLifetimeManager())
                .RegisterType<IfrmDimensionPresenter, frmDimensionPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IBasePlatformUC, BasePlatformUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IBasePlatformPresenter, BasePlatformPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFramePropertiesUC, FramePropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFramePropertiesUCPresenter, FramePropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_sqlconStr));

            ILoginPresenter loginPresenter = UnityC.Resolve<LoginPresenter>();

            _mainPresenter = UnityC.Resolve<MainPresenter>();
            _mainView = _mainPresenter.GetMainView();
            _frmDimensionView = _mainPresenter.frmDimension_MainPresenter.GetDimensionView();

            ILoginView loginView = loginPresenter.GetLoginView(UnityC);

            IUserModel userModel = UnityC.Resolve<UserModel>();

            _mainPresenter.SetValues(userModel, loginView, UnityC);
        }

        [TestMethod]
        public void ScenarioQuotation_ScenarioOne_Test()
        {
            /*Dire-diretso hanggang paggawa ng isang frame.
             * Total Width = 400
             * Total Height = 400
             * Frame Width = 400
             * Frame Height = 400
             */

            #region Scenario 1.1
            /*Scenario 1.1:
             Magcreate ng quotation: hanggang Click ok ng `Quotation Input Box`*/

            //arrange
            string expected_quotation = "SAMPLE123";
            List<IWindoorModel>  lst_wndr = new List<IWindoorModel>();

            //act
            _mainPresenter.inputted_quotationRefNo = "SAMPLE123";
            _mainPresenter.Scenario_Quotation(true, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "");

            //assert
            Assert.AreEqual(expected_quotation, _mainView.mainview_title);
            Assert.AreEqual(true, _mainView.ItemToolStripEnabled);
            Assert.AreEqual(expected_quotation, _mainPresenter.qoutationModel_MainPresenter.Quotation_ref_no);
            Assert.AreEqual(true, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().thisVisibility);
            Assert.AreEqual(frmDimensionPresenter.Show_Purpose.Quotation, _mainPresenter.frmDimension_MainPresenter.purpose);
            Assert.AreEqual("C70 Profile", _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);
            Assert.AreEqual(193, _frmDimensionView.dimension_height);
            Assert.AreEqual(true, _frmDimensionView.ThisVisibility);
            CollectionAssert.AreEqual(lst_wndr, _mainPresenter.qoutationModel_MainPresenter.Lst_Windoor);
            #endregion

            #region Scenario 1.2
            /*Scenario 1.2:
             Magcreate ng quotation: hanggang Click ok ng `frmDimension`*/

            //arrange
            int exp_Wd = 400, exp_Ht = 400, exp_id = 1, exp_qty = 1, exp_wdZoom = 1, exp_wdPrice = 0;
            decimal exp_wdDiscount = 0.0M;
            string exp_profileType = "C70 Profile", exp_wdName = "Item 1", exp_wdDesc = "C70 Profile";
            bool exp_wdVisibility = true, exp_wdOrientation = true;
            List<IFrameModel> lst_frame = new List<IFrameModel>();

            //act
            _frmDimensionView.InumWidth = 400;
            _frmDimensionView.InumHeight = 400;
            _frmDimensionView.c70rRadBtn_CheckState = true;
            _mainPresenter.Scenario_Quotation(_mainPresenter.frmDimension_MainPresenter.mainPresenter_qoutationInputBox_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_newItem_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_AddedFrame_ClickedOK,
                                              frmDimensionPresenter.Show_Purpose.Quotation,
                                              _mainPresenter.frmDimension_MainPresenter.GetDimensionView().InumWidth,
                                              _mainPresenter.frmDimension_MainPresenter.GetDimensionView().InumHeight,
                                              _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);

            //assert
            Assert.AreEqual(exp_id, _mainPresenter.windoorModel_MainPresenter.WD_id);
            Assert.AreEqual(exp_Wd, _mainPresenter.windoorModel_MainPresenter.WD_width);
            Assert.AreEqual(exp_Ht, _mainPresenter.windoorModel_MainPresenter.WD_height);
            Assert.AreEqual(exp_profileType, _mainPresenter.windoorModel_MainPresenter.WD_profile);
            Assert.AreEqual(exp_qty, _mainPresenter.windoorModel_MainPresenter.WD_quantity);
            Assert.AreEqual(exp_wdZoom, _mainPresenter.windoorModel_MainPresenter.WD_zoom);
            Assert.AreEqual(exp_wdPrice, _mainPresenter.windoorModel_MainPresenter.WD_price);
            Assert.AreEqual(exp_wdDiscount, _mainPresenter.windoorModel_MainPresenter.WD_discount);
            Assert.AreEqual(exp_wdName, _mainPresenter.windoorModel_MainPresenter.WD_name);
            Assert.AreEqual(exp_wdDesc, _mainPresenter.windoorModel_MainPresenter.WD_description);
            Assert.AreEqual(exp_wdVisibility, _mainPresenter.windoorModel_MainPresenter.WD_visibility);
            Assert.AreEqual(exp_wdOrientation, _mainPresenter.windoorModel_MainPresenter.WD_orientation);
            CollectionAssert.AreEqual(lst_frame, _mainPresenter.windoorModel_MainPresenter.lst_frame);

            CollectionAssert.Contains(_mainPresenter.pnlMain_MainPresenter.Controls, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC());
            CollectionAssert.Contains(_mainPresenter.pnlItems_MainPresenter.Controls, _mainPresenter.itemInfoUC_MainPresenter);
            Assert.AreEqual(exp_Wd + 70, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().bp_Width);
            Assert.AreEqual(exp_Ht + 35, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().bp_Height);

            string exp_mainViewTitle = expected_quotation + " >> Item 1 (C70 Profile)*";
            Assert.AreEqual(exp_mainViewTitle, _mainPresenter.GetMainView().mainview_title);
            Assert.AreEqual(true, _mainPresenter.GetMainView().ItemToolStripEnabled);
            Assert.AreEqual(true, _mainPresenter.GetMainView().CreateNewWindoorBtnEnabled);
            #endregion

            #region Scenario 1.3
            /*Scenario 1.3:
             Magcreate ng quotation: 
                Mag-Add ng Frame: Open ang frmDimension at click OK*/

            //arrange
            int exp_fWd = 400, exp_fHt = 400;
            FrameModel.Frame_Padding exp_frameType = FrameModel.Frame_Padding.Window;

            //act
            _mainPresenter.frameType_MainPresenter = exp_frameType;
            _mainPresenter.Scenario_Quotation(false, false, true,
                                              frmDimensionPresenter.Show_Purpose.CreateNew_Frame,
                                              0,
                                              0,
                                              "");
            _mainPresenter.Scenario_Quotation(_mainPresenter.frmDimension_MainPresenter.mainPresenter_qoutationInputBox_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_newItem_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_AddedFrame_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.purpose,
                                              exp_fWd,
                                              exp_fHt,
                                              _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);
            //assert
            Assert.AreEqual(1, _mainPresenter.frameModel_MainPresenter.Frame_ID);
            Assert.AreEqual(exp_fWd, _mainPresenter.frameModel_MainPresenter.Frame_Width);
            Assert.AreEqual(exp_fHt, _mainPresenter.frameModel_MainPresenter.Frame_Height);
            Assert.AreEqual("Frame 1", _mainPresenter.frameModel_MainPresenter.Frame_Name);
            Assert.AreEqual(exp_frameType, _mainPresenter.frameModel_MainPresenter.Frame_Type);
            CollectionAssert.Contains(_mainPresenter.windoorModel_MainPresenter.lst_frame, _mainPresenter.frameModel_MainPresenter);
            CollectionAssert.Contains(_mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().GetFlpMain().Controls,
                                      _mainPresenter.frameUC_MainPresenter);
            CollectionAssert.Contains(_mainPresenter.pnlPropertiesBody_MainPresenter.Controls, 
                                      _mainPresenter.framePropertiesUC_MainPresenter);
            #endregion
        }

        [TestMethod]
        public void ScenarioQuotation_ScenarioTwo_Test()
        {
            /*Dire-diretso hanggang paggawa ng 2 equal frames.
             * Total Width = 800
             * Total Height = 400
             * Frame1 Width = 400
             * Frame1 Height = 400
             * Frame2 Width = 400
             * Frame2 Height = 400
             */

            #region Scenario 2.1
            /*Scenario 1.1:
             Magcreate ng quotation: hanggang Click ok ng `Quotation Input Box`*/

            //arrange
            string expected_quotation = "SAMPLE123";
            List<IWindoorModel> lst_wndr = new List<IWindoorModel>();

            //act
            _mainPresenter.inputted_quotationRefNo = "SAMPLE123";
            _mainPresenter.Scenario_Quotation(true, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "");

            //assert
            Assert.AreEqual(expected_quotation, _mainView.mainview_title);
            Assert.AreEqual(true, _mainView.ItemToolStripEnabled);
            Assert.AreEqual(expected_quotation, _mainPresenter.qoutationModel_MainPresenter.Quotation_ref_no);
            Assert.AreEqual(true, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().thisVisibility);
            Assert.AreEqual(frmDimensionPresenter.Show_Purpose.Quotation, _mainPresenter.frmDimension_MainPresenter.purpose);
            Assert.AreEqual("C70 Profile", _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);
            Assert.AreEqual(193, _frmDimensionView.dimension_height);
            Assert.AreEqual(true, _frmDimensionView.ThisVisibility);
            CollectionAssert.AreEqual(lst_wndr, _mainPresenter.qoutationModel_MainPresenter.Lst_Windoor);
            #endregion

            #region Scenario 2.2
            /*Scenario 2.2:
             I-Create ang editor: hanggang Click ok ng `frmDimension`*/

            //arrange
            int exp_Wd = 800, exp_Ht = 800, exp_id = 1, exp_qty = 1, exp_wdZoom = 1, exp_wdPrice = 0;
            decimal exp_wdDiscount = 0.0M;
            string exp_profileType = "PremiLine Profile", exp_wdName = "Item 1", exp_wdDesc = "PremiLine Profile";
            bool exp_wdVisibility = true, exp_wdOrientation = true;
            List<IFrameModel> lst_frame = new List<IFrameModel>();

            //act
            _frmDimensionView.InumWidth = 800;
            _frmDimensionView.InumHeight = 800;
            _frmDimensionView.premiLineRadBtn_CheckState = true;
            _mainPresenter.Scenario_Quotation(_mainPresenter.frmDimension_MainPresenter.mainPresenter_qoutationInputBox_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_newItem_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_AddedFrame_ClickedOK,
                                              frmDimensionPresenter.Show_Purpose.Quotation,
                                              _mainPresenter.frmDimension_MainPresenter.GetDimensionView().InumWidth,
                                              _mainPresenter.frmDimension_MainPresenter.GetDimensionView().InumHeight,
                                              _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);

            //assert
            Assert.AreEqual(exp_id, _mainPresenter.windoorModel_MainPresenter.WD_id);
            Assert.AreEqual(exp_Wd, _mainPresenter.windoorModel_MainPresenter.WD_width);
            Assert.AreEqual(exp_Ht, _mainPresenter.windoorModel_MainPresenter.WD_height);
            Assert.AreEqual(exp_profileType, _mainPresenter.windoorModel_MainPresenter.WD_profile);
            Assert.AreEqual(exp_qty, _mainPresenter.windoorModel_MainPresenter.WD_quantity);
            Assert.AreEqual(exp_wdZoom, _mainPresenter.windoorModel_MainPresenter.WD_zoom);
            Assert.AreEqual(exp_wdPrice, _mainPresenter.windoorModel_MainPresenter.WD_price);
            Assert.AreEqual(exp_wdDiscount, _mainPresenter.windoorModel_MainPresenter.WD_discount);
            Assert.AreEqual(exp_wdName, _mainPresenter.windoorModel_MainPresenter.WD_name);
            Assert.AreEqual(exp_wdDesc, _mainPresenter.windoorModel_MainPresenter.WD_description);
            Assert.AreEqual(exp_wdVisibility, _mainPresenter.windoorModel_MainPresenter.WD_visibility);
            Assert.AreEqual(exp_wdOrientation, _mainPresenter.windoorModel_MainPresenter.WD_orientation);
            CollectionAssert.AreEqual(lst_frame, _mainPresenter.windoorModel_MainPresenter.lst_frame);

            CollectionAssert.Contains(_mainPresenter.pnlMain_MainPresenter.Controls, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC());
            CollectionAssert.Contains(_mainPresenter.pnlItems_MainPresenter.Controls, _mainPresenter.itemInfoUC_MainPresenter);
            Assert.AreEqual(exp_Wd + 70, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().bp_Width);
            Assert.AreEqual(exp_Ht + 35, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().bp_Height);

            string exp_mainViewTitle = expected_quotation + " >> Item 1 (PremiLine Profile)*";
            Assert.AreEqual(exp_mainViewTitle, _mainPresenter.GetMainView().mainview_title);
            Assert.AreEqual(true, _mainPresenter.GetMainView().ItemToolStripEnabled);
            Assert.AreEqual(true, _mainPresenter.GetMainView().CreateNewWindoorBtnEnabled);
            #endregion

            #region Scenario 2.3
            /*Scenario 2.2:
             I-Create ang frame 1: hanggang Click ok ng `frmDimension`*/

            //arrange
            int exp_fWd = 400, exp_fHt = 400;
            FrameModel.Frame_Padding exp_frameType = FrameModel.Frame_Padding.Window;

            //act
            _mainPresenter.frameType_MainPresenter = exp_frameType;
            _mainPresenter.Scenario_Quotation(false, false, true,
                                              frmDimensionPresenter.Show_Purpose.CreateNew_Frame,
                                              0,
                                              0,
                                              "");
            _mainPresenter.Scenario_Quotation(_mainPresenter.frmDimension_MainPresenter.mainPresenter_qoutationInputBox_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_newItem_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_AddedFrame_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.purpose,
                                              exp_fWd,
                                              exp_fHt,
                                              _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);
            //assert
            Assert.AreEqual(1, _mainPresenter.frameModel_MainPresenter.Frame_ID);
            Assert.AreEqual(exp_fWd, _mainPresenter.frameModel_MainPresenter.Frame_Width);
            Assert.AreEqual(exp_fHt, _mainPresenter.frameModel_MainPresenter.Frame_Height);
            Assert.AreEqual("Frame 1", _mainPresenter.frameModel_MainPresenter.Frame_Name);
            Assert.AreEqual(exp_frameType, _mainPresenter.frameModel_MainPresenter.Frame_Type);
            CollectionAssert.Contains(_mainPresenter.windoorModel_MainPresenter.lst_frame, _mainPresenter.frameModel_MainPresenter);
            CollectionAssert.Contains(_mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().GetFlpMain().Controls,
                                      _mainPresenter.frameUC_MainPresenter);
            CollectionAssert.Contains(_mainPresenter.pnlPropertiesBody_MainPresenter.Controls,
                                      _mainPresenter.framePropertiesUC_MainPresenter);
            #endregion

            #region Scenario 2.4
            /*Scenario 2.2:
             I-Create ang frame 2: hanggang Click ok ng `frmDimension`*/

            //arrange
            int exp_fWd2 = 400, exp_fHt2 = 400;
            FrameModel.Frame_Padding exp_frameType2 = FrameModel.Frame_Padding.Door;

            //act
            _mainPresenter.frameType_MainPresenter = exp_frameType2;
            _mainPresenter.Scenario_Quotation(false, false, true,
                                              frmDimensionPresenter.Show_Purpose.CreateNew_Frame,
                                              0,
                                              0,
                                              "");
            _mainPresenter.Scenario_Quotation(_mainPresenter.frmDimension_MainPresenter.mainPresenter_qoutationInputBox_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_newItem_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.mainPresenter_AddedFrame_ClickedOK,
                                              _mainPresenter.frmDimension_MainPresenter.purpose,
                                              exp_fWd2,
                                              exp_fHt2,
                                              _mainPresenter.frmDimension_MainPresenter.profileType_frmDimensionPresenter);
            //assert
            Assert.AreEqual(2, _mainPresenter.frameModel_MainPresenter.Frame_ID);
            Assert.AreEqual(exp_fWd2, _mainPresenter.frameModel_MainPresenter.Frame_Width);
            Assert.AreEqual(exp_fHt2, _mainPresenter.frameModel_MainPresenter.Frame_Height);
            Assert.AreEqual("Frame 2", _mainPresenter.frameModel_MainPresenter.Frame_Name);
            Assert.AreEqual(exp_frameType2, _mainPresenter.frameModel_MainPresenter.Frame_Type);
            CollectionAssert.Contains(_mainPresenter.windoorModel_MainPresenter.lst_frame, _mainPresenter.frameModel_MainPresenter);
            CollectionAssert.Contains(_mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().GetFlpMain().Controls,
                                      _mainPresenter.frameUC_MainPresenter);
            CollectionAssert.Contains(_mainPresenter.pnlPropertiesBody_MainPresenter.Controls,
                                      _mainPresenter.framePropertiesUC_MainPresenter);
            #endregion

            #region Overall Assertion
            //assert the frames if it properly added
            Assert.AreEqual(2, _mainPresenter.basePlatform_MainPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Count);
            Assert.AreEqual(2, _mainPresenter.windoorModel_MainPresenter.lst_frame.Count);
            Assert.AreEqual(1, _mainPresenter.windoorModel_MainPresenter.lst_frame[0].Frame_ID);
            Assert.AreEqual(2, _mainPresenter.windoorModel_MainPresenter.lst_frame[1].Frame_ID);
            Assert.AreEqual("Frame 1", _mainPresenter.windoorModel_MainPresenter.lst_frame[0].Frame_Name);
            Assert.AreEqual("Frame 2", _mainPresenter.windoorModel_MainPresenter.lst_frame[1].Frame_Name);
            Assert.AreEqual(400, _mainPresenter.windoorModel_MainPresenter.lst_frame[0].Frame_Width);
            Assert.AreEqual(400, _mainPresenter.windoorModel_MainPresenter.lst_frame[1].Frame_Width);
            Assert.AreEqual(400, _mainPresenter.windoorModel_MainPresenter.lst_frame[0].Frame_Height);
            Assert.AreEqual(400, _mainPresenter.windoorModel_MainPresenter.lst_frame[1].Frame_Height);
            Assert.AreEqual(FrameModel.Frame_Padding.Window, _mainPresenter.windoorModel_MainPresenter.lst_frame[0].Frame_Type);
            Assert.AreEqual(FrameModel.Frame_Padding.Door, _mainPresenter.windoorModel_MainPresenter.lst_frame[1].Frame_Type);
            #endregion
        }
    }
}
