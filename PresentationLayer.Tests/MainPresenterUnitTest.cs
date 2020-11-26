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
            IUnityContainer UnityC;
            UnityC =
                new UnityContainer()

                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())

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
                .RegisterType<IFramePropertiesUCPresenter, FramePropertiesUCPresenter>(new ContainerControlledLifetimeManager());

            _mainPresenter = UnityC.Resolve<MainPresenter>();
            _mainView = _mainPresenter.GetMainView();
            _frmDimensionView = _mainPresenter.frmDimension_MainPresenter.GetDimensionView();
        }
        [TestMethod]
        public void Scenario_Quotation_Test()
        {
            //arrange
            string expected_quotation = "SAMPLE123";
            List<IWindoorModel>  lst_wndr = new List<IWindoorModel>();

            //act
            _mainPresenter.inputted_quotationRefNo = "SAMPLE123";
            _mainPresenter.Scenario_Quotation(true, true, true);

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
        }
    }
}
