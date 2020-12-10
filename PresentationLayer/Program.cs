using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using QueryLayer.DataAccess.Repositories.Specific.User;
using ServiceLayer.Services.UserServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.WindoorServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.CommonServices;
using ModelLayer.Model.User;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using Unity.Injection;

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
            string _sqlconStr = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='KMDIDATA';User ID='kmdiadmin';Password='kmdiadmin';";

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

                .RegisterType<IpromptYesNo, promptYesNo>(new ContainerControlledLifetimeManager())
                .RegisterType<IpromptYesNoPresenter, promptYesNoPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFixedPanelUC, FixedPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IControlsUC, ControlsUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IControlsUCPresenter, ControlsUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_sqlconStr));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ILoginPresenter loginPresenter = UnityC.Resolve<LoginPresenter>();

            ILoginView loginView = loginPresenter.GetLoginView(UnityC);
            Application.Run((LoginView)loginView);
        }
    }
}
