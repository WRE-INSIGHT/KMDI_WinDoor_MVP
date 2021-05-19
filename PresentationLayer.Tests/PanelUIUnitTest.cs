using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using Unity;
using Unity.Lifetime;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using ServiceLayer.Services.PanelServices;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.CommonServices;
using PresentationLayer.Presenter;
using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.Services.FrameServices;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class PanelUIUnitTest
    {
        IMainPresenter _mainPresenter;

        ICasementPanelUCPresenter _casementUCP;
        IAwningPanelUCPresenter _awningUCP;
        ISlidingPanelUCPresenter _slidingUCP;
        IUnityContainer UnityC;

        private IPanelModel _panelModel;
        private IPanelServices _panelServices;

        [TestInitialize]
        public void SetUp()
        {
            UnityC = new UnityContainer()
                .RegisterType<ILoginView, LoginView>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginPresenter, LoginPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IQuotationServices, QuotationServices>(new ContainerControlledLifetimeManager())

                .RegisterType<IWindoorServices, WindoorServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IWindoorModel, WindoorModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IFrameServices, FrameServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IFrameModel, FrameModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IPanelServices, PanelServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IPanelModel, PanelModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IMultiPanelServices, MultiPanelServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelModel, MultiPanelModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager())

                .RegisterType<IFrameUC, FrameUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFrameUCPresenter, FrameUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFrameImagerUC, FrameImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFrameImagerUCPresenter, FrameImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IItemInfoUC, ItemInfoUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IItemInfoUCPresenter, ItemInfoUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IfrmDimensionView, frmDimensionView>(new ContainerControlledLifetimeManager())
                .RegisterType<IfrmDimensionPresenter, frmDimensionPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IBasePlatformUC, BasePlatformUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IBasePlatformPresenter, BasePlatformPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IBasePlatformImagerUC, BasePlatformImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IBasePlatformImagerUCPresenter, BasePlatformImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFramePropertiesUC, FramePropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFramePropertiesUCPresenter, FramePropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IpromptYesNo, promptYesNo>(new ContainerControlledLifetimeManager())
                .RegisterType<IpromptYesNoPresenter, promptYesNoPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IControlsUC, ControlsUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IControlsUCPresenter, ControlsUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPanelPropertiesUC, PanelPropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPanelPropertiesUCPresenter, PanelPropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFixedPanelUC, FixedPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFixedPanelImagerUC, FixedPanelImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFixedPanelImagerUCPresenter, FixedPanelImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IAwningPanelUC, AwningPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IAwningPanelImagerUC, AwningPanelImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IAwningPanelImagerUCPresenter, AwningPanelImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICasementPanelUC, CasementPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICasementPanelUCPresenter, CasementPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICasementPanelImagerUC, CasementPanelImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICasementPanelImagerUCPresenter, CasementPanelImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISlidingPanelUC, SlidingPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISlidingPanelUCPresenter, SlidingPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISlidingPanelImagerUC, SlidingPanelImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISlidingPanelImagerUCPresenter, SlidingPanelImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>(new ContainerControlledLifetimeManager())

                ;

            _mainPresenter = UnityC.Resolve<MainPresenter>();
            _casementUCP = UnityC.Resolve<CasementPanelUCPresenter>();
            _awningUCP = UnityC.Resolve<AwningPanelUCPresenter>();
            _slidingUCP = UnityC.Resolve<SlidingPanelUCPresenter>();
            _panelServices = UnityC.Resolve<PanelServices>();

            frmUITest frm = new frmUITest();

            //_panelModel = _panelServices.AddPanelModel(frm.Width,
            //                                           frm.Height,
            //                                           new UserControl(),
            //                                           new UserControl(),
            //                                           new UserControl(),
            //                                           new UserControl(),
            //                                           "Awning",
            //                                           true,
            //                                           1);

    }

        //[TestMethod]
        //public void CasementUITest()
        //{
        //    frmUITest frm = new frmUITest();
        //    IFrameModel frame = new FrameModel(1, "Frame 1", 400, 400, FrameModel.Frame_Padding.Door, true, 
        //                                       new System.Collections.Generic.List<IPanelModel>(),
        //                                       new System.Collections.Generic.List<IMultiPanelModel>(),
        //                                       1.0f,
        //                                       new System.Collections.Generic.List<ModelLayer.Model.Quotation.Divider.IDividerModel>());

        //    //ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(UnityC, _panelModel, frame, _mainPresenter);
        //    //ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
        //    //frm.Controls.Add((UserControl)casementUC);
        //    frm.ShowDialog();
        //}

        //[TestMethod]
        //public void AwningUITest()
        //{
        //    frmUITest frm = new frmUITest();
        //    IFrameModel frame = new FrameModel(1, "Frame 1", 400, 400, FrameModel.Frame_Padding.Door, true, 
        //                                       new System.Collections.Generic.List<IPanelModel>(), 
        //                                       new System.Collections.Generic.List<IMultiPanelModel>(),
        //                                       1.0f,
        //                                       new System.Collections.Generic.List<ModelLayer.Model.Quotation.Divider.IDividerModel>());

        //    //IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(UnityC, _panelModel, frame, _mainPresenter);
        //    //IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
        //    //frm.Controls.Add((UserControl)awningUC);
        //    frm.ShowDialog();
        //}

        //[TestMethod]
        //public void SlidingUITest()
        //{
        //    frmUITest frm = new frmUITest();
        //    IFrameModel frame = new FrameModel(1, "Frame 1", 400, 400, FrameModel.Frame_Padding.Door, true, 
        //                                       new System.Collections.Generic.List<IPanelModel>(), 
        //                                       new System.Collections.Generic.List<IMultiPanelModel>(),
        //                                       1.0f,
        //                                       new System.Collections.Generic.List<ModelLayer.Model.Quotation.Divider.IDividerModel>());

        //    //ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(UnityC, _panelModel, frame, _mainPresenter);
        //    //ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
        //    //frm.Controls.Add((UserControl)slidingUC);
        //    frm.ShowDialog();
        //}
    }
}
