using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using QueryLayer.DataAccess.Repositories.Specific.User;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.DividerServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.UserServices;
using ServiceLayer.Services.WindoorServices;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC;
            string _sqlconStr = Properties.Settings.Default.slqcon;

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

                .RegisterType<IPanelServices, PanelServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IPanelModel, PanelModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IMultiPanelServices, MultiPanelServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelModel, MultiPanelModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IDividerServices, DividerServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IDividerModel, DividerModel>(new ContainerControlledLifetimeManager())

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

                .RegisterType<IPanelPropertiesUC, Panel_PropertiesUC>(new ContainerControlledLifetimeManager())
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

                .RegisterType<IMultiPanelMullionImagerUC, MultiPanelMullionImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelMullionImagerUCPresenter, MultiPanelMullionImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMullionUC, MullionUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMullionImagerUC, MullionImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMullionImagerUCPresenter, MullionImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMultiPanelTransomUC, MultiPanelTransomUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelTransomUCPresenter, MultiPanelTransomUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMultiPanelTransomImagerUC, MultiPanelTransomImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelTransomImagerUCPresenter, MultiPanelTransomImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ITransomUC, TransomUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ITransomImagerUC, TransomImagerUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ITransomImagerUCPresenter, TransomImagerUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMultiPanelPropertiesUC, MultiPanelPropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IMultiPanelPropertiesUCPresenter, MultiPanelPropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IDividerPropertiesUC, DividerPropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IDividerPropertiesUCPresenter, DividerPropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IExplosionView, ExplosionView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExplosionPresenter, ExplosionPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICreateNewGlassView, CreateNewGlassView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICreateNewGlassPresenter, CreateNewGlassPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IChangeItemColorView, ChangeItemColorView>(new ContainerControlledLifetimeManager())
                .RegisterType<IChangeItemColorPresenter, ChangeItemColorPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IGlassThicknessListView, GlassThicknessListView>(new ContainerControlledLifetimeManager())
                .RegisterType<IGlassThicknessListPresenter, GlassThicknessListPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICreateNewGlassTypeView, CreateNewGlassTypeView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICreateNewGlassTypePresenter, CreateNewGlassTypePresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICreateNewGlassSpacerView, CreateNewGlassSpacerView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICreateNewGlassSpacerPresenter, CreateNewGlassSpacerPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICreateNewGlassColorView, CreateNewGlassColorView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICreateNewGlassColorPresenter, CreateNewGlassColorPresenter>(new ContainerControlledLifetimeManager())


                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_sqlconStr));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ILoginPresenter loginPresenter = UnityC.Resolve<LoginPresenter>();

            ILoginView loginView = loginPresenter.GetLoginView(UnityC);
            Application.Run((LoginView)loginView);
        }
    }
}
