using ModelLayer.Model.AddProject;
using ModelLayer.Model.Project;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Screen;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.Costing_Head;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules;
using PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules;
using PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views;
using PresentationLayer.Views.Costing_Head;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using QueryLayer.DataAccess.Repositories.Specific.Address;
using QueryLayer.DataAccess.Repositories.Specific.Customer_Ref_No;
using QueryLayer.DataAccess.Repositories.Specific.Employee;
using QueryLayer.DataAccess.Repositories.Specific.Project_Quote;
using QueryLayer.DataAccess.Repositories.Specific.Quotation;
using QueryLayer.DataAccess.Repositories.Specific.User;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.AddressServices;
using ServiceLayer.Services.ConcreteServices;
using ServiceLayer.Services.CustomerRefNoServices;
using ServiceLayer.Services.DividerServices;
using ServiceLayer.Services.EmployeeServices;
using ServiceLayer.Services.FrameServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using ServiceLayer.Services.ProjectQuoteServices;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.ScreenServices;
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
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string filePath = args[0];
                Properties.Settings.Default.FilePath = filePath;
                Properties.Settings.Default.Save();
            }
            IUnityContainer UnityC;
            string _sqlconStr = Properties.Settings.Default.slqcon;

            UnityC =
                new UnityContainer()
                .RegisterType<ILoginView, LoginView>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginPresenter, LoginPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IAssignProjectsView, AssignProjectsView>(new ContainerControlledLifetimeManager())
                .RegisterType<IAssignProjectsPresenter, AssignProjectsPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IAssignAEView, AssignAEView>(new ContainerControlledLifetimeManager())
                .RegisterType<IAssignAEPresenter, AssignAEPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IAddProjectView, AddProjectView>(new ContainerControlledLifetimeManager())
                .RegisterType<IAddProjectPresenter, AddProjectPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFactorView, FactorView>(new ContainerControlledLifetimeManager())
                .RegisterType<IFactorPresenter, FactorPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICostEngrEmployeeView, CostEngrEmployeeView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICostEngrEmployeePresenter, CostEngrEmployeePresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICostEngrLandingView, CostEngrLandingView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICostEngrLandingPresenter, CostEngrLandingPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICustomerRefNoView, CustomerRefNoView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICustomerRefNoPresenter, CustomerRefNoPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserServices, UserServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IUserModel, UserModel>(new ContainerControlledLifetimeManager())
                .RegisterType<IUserLoginModel, UserLoginModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IQuotationServices, QuotationServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IAddressServices, AddressServices>(new ContainerControlledLifetimeManager())

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

                .RegisterType<IConcreteServices, ConcreteServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IConcreteModel, ConcreteModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IProjectModel, ProjectModel>(new ContainerControlledLifetimeManager())
                .RegisterType<IProjectQuoteServices, ProjectQuoteServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IEmployeeServices, EmployeeServices>(new ContainerControlledLifetimeManager())
                .RegisterType<ICustomerRefNoServices, CustomerRefNoServices>(new ContainerControlledLifetimeManager())

                .RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager())

                .RegisterType<IFrameUC, FrameUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFrameUCPresenter, FrameUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFP_BottomFramePropertyUC, FP_BottomFramePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFP_BottomFramePropertyUCPresenter, FP_BottomFramePropertyUCPresenter>(new ContainerControlledLifetimeManager())

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

                .RegisterType<IConcretePropertiesUC, ConcretePropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IConcretePropertiesUCPresenter, ConcretePropertiesUCPresenter>(new ContainerControlledLifetimeManager())

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

                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ILouverPanelUC, LouverPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>(new ContainerControlledLifetimeManager())

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

                .RegisterType<IPP_MotorizedPropertyUC, PP_MotorizedPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_MotorizedPropertyUCPresenter, PP_MotorizedPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_SashPropertyUC, PP_SashPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_SashPropertyUCPresenter, PP_SashPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_GlassPropertyUC, PP_GlassPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_GlassPropertyUCPresenter, PP_GlassPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_HandlePropertyUC, PP_HandlePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_HandlePropertyUCPresenter, PP_HandlePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_RotoswingPropertyUC, PP_RotoswingPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_RotoswingPropertyUCPresenter, PP_RotoswingPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_RotaryPropertyUC, PP_RotaryPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_RotaryPropertyUCPresenter, PP_RotaryPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_ExtensionPropertyUC, PP_ExtensionPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_ExtensionPropertyUCPresenter, PP_ExtensionPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_CornerDrivePropertyUC, PP_CornerDrivePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_CornerDrivePropertyUCPresenter, PP_CornerDrivePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_GeorgianBarPropertyUC, PP_GeorgianBarPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_GeorgianBarPropertyUCPresenter, PP_GeorgianBarPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IDP_CladdingPropertyUC, DP_CladdingPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IDP_CladdingPropertyUCPresenter, DP_CladdingPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_RioPropertyUC, PP_RioPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_RioPropertyUCPresenter, PP_RioPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_RotolinePropertyUC, PP_RotolinePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_RotolinePropertyUCPresenter, PP_RotolinePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_MVDPropertyUC, PP_MVDPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_MVDPropertyUCPresenter, PP_MVDPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_HingePropertyUC, PP_HingePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_HingePropertyUCPresenter, PP_HingePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_CenterHingePropertyUC, PP_CenterHingePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_CenterHingePropertyUCPresenter, PP_CenterHingePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_NTCenterHingePropertyUC, PP_NTCenterHingePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_NTCenterHingePropertyUCPresenter, PP_NTCenterHingePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_MiddleCloserPropertyUC, PP_MiddleCloserPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_MiddleCloserPropertyUCPresenter, PP_MiddleCloserPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IDP_CladdingBracketPropertyUC, DP_CladdingBracketPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IDP_CladdingBracketPropertyUCPresenter, DP_CladdingBracketPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_EspagnolettePropertyUC, PP_EspagnolettePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_EspagnolettePropertyUCPresenter, PP_EspagnolettePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IDP_LeverEspagnolettePropertyUC, DP_LeverEspagnolettePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IDP_LeverEspagnolettePropertyUCPresenter, DP_LeverEspagnolettePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_3dHingePropertyUC, PP_3dHingePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_3dHingePropertyUCPresenter, PP_3dHingePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_2dHingePropertyUC, PP_2dHingePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_2dHingePropertyUCPresenter, PP_2dHingePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICustomArrowHeadUC, CustomArrowHeadUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICustomArrowHeadUCPresenter, CustomArrowHeadUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ICustomArrowHeadView, CustomArrowHeadView>(new ContainerControlledLifetimeManager())
                .RegisterType<ICustomArrowHeadPresenter, CustomArrowHeadPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IDividerPropertiesUC, DividerPropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IDividerPropertiesUCPresenter, DividerPropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPrintQuoteView, PrintQuoteView>(new ContainerControlledLifetimeManager())
                .RegisterType<IPrintQuotePresenter, PrintQuotePresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IQuoteItemListView, QuoteItemListView>(new ContainerControlledLifetimeManager())
                .RegisterType<IQuoteItemListPresenter, QuoteItemListPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IQuoteItemListUC, QuoteItemListUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IQuoteItemListUCPresenter, QuoteItemListUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISortItemView, SortItemView>(new ContainerControlledLifetimeManager())
                .RegisterType<ISortItemPresenter, SortItemPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISortItemUC, SortItemUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISortItemUCPresenter, SortItemUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_SlidingTypePropertyUC, PP_SlidingTypePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_SlidingTypePropertyUCPresenter, PP_SlidingTypePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISetTopViewSlidingPanellingView, SetTopViewSlidingPanellingView>(new ContainerControlledLifetimeManager())
                .RegisterType<ISetTopViewSlidingPanellingPresenter, SetTopViewSlidingPanellingPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPrintGlassSummaryView, PrintGlassSummaryView>(new ContainerControlledLifetimeManager())
                .RegisterType<IPrintGlassSummaryPresenter, PrintGlassSummaryPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_RollerPropertyUC, PP_RollerPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_RollerPropertyUCPresenter, PP_RollerPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_AliminumTrackPropertyUC, PP_AliminumTrackPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_AliminumTrackPropertyUCPresenter, PP_AliminumTrackPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_DHandlePropertyUC, PP_DHandlePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_DHandlePropertyUCPresenter, PP_DHandlePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_DHandle_IOLockingPropertyUC, PP_DHandle_IOLockingPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_DHandle_IOLockingPropertyUCPresenter, PP_DHandle_IOLockingPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_DummyDHandlePropertyUC, PP_DummyDHandlePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_DummyDHandlePropertyUCPresenter, PP_DummyDHandlePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_PopUpHandlePropertyUC, PP_PopUpHandlePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_PopUpHandlePropertyUCPresenter, PP_PopUpHandlePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_RotoswingForSlidingPropertyUC, PP_RotoswingForSlidingPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_RotoswingForSlidingPropertyUCPresenter, PP_RotoswingForSlidingPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFP_SlidingRailsPropertyUC, FP_SlidingRailsPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFP_SlidingRailsPropertyUCPresenter, FP_SlidingRailsPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFP_FrameConnectionTypePropertyUC, FP_FrameConnectionTypePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IFP_FrameConnectionTypePropertyUCPresenter, FP_FrameConnectionTypePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_TrackRailPropertyUC, PP_TrackRailPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_TrackRailPropertyUCPresenter, PP_TrackRailPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_LouverBladesPropertyUC, PP_LouverBladesPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_LouverBladesPropertyUCPresenter, PP_LouverBladesPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IScreenServices, ScreenServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IScreenModel, ScreenModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IScreenView, ScreenView>(new ContainerControlledLifetimeManager())
                .RegisterType<IScreenPresenter, ScreenPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IScreenAddOnPropertiesUC, ScreenAddOnPropertiesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IScreenAddOnPropertiesUCPresenter, ScreenAddOnPropertiesUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_PVCboxPropertyUC, SP_PVCboxPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_PVCboxPropertyUCPresenter, SP_PVCboxPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_CenterClosurePropertyUC, SP_CenterClosurePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_CenterClosurePropertyUCPresenter, SP_CenterClosurePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_1385MilledProfilePropertyUC, SP_1385MilledProfilePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_1385MilledProfilePropertyUCPresenter, SP_1385MilledProfilePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_373or374MilledProfilePropertyUC, SP_373or374MilledProfilePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_373or374MilledProfilePropertyUCPresenter, SP_373or374MilledProfilePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_6052MilledProfilePropertyUC, SP_6052MilledProfilePropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_6052MilledProfilePropertyUCPresenter, SP_6052MilledProfilePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_SpringLoadedUC, SP_SpringLoadedUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_SpringLoadedUCPresenter, SP_SpringLoadedUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_MagnumScreenTypeUCPresenter, SP_MagnumScreenTypeUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_MagnumScreenTypeUC, SP_MagnumScreenTypeUC>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_PVCbox1067WithReinPropertyUCPresenter, SP_PVCbox1067WithReinPropertyUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_PVCbox1067WithReinPropertyUC, SP_PVCbox1067WithReinPropertyUC>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_6040MilledProfileWithReinforcementPropertyUCPresenter, SP_6040MilledProfileWithReinforcementPropertyUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_6040MilledProfileWithReinforcementPropertyUC, SP_6040MilledProfileWithReinforcementPropertyUC>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_LandCoverPropertyUCPresenter, SP_LandCoverPropertyUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_LandCoverPropertyUC, SP_LandCoverPropertyUC>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_PriceIncreaseByPercentageUCPresenter, SP_PriceIncreaseByPercentageUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_PriceIncreaseByPercentageUC, SP_PriceIncreaseByPercentageUC>(new ContainerControlledLifetimeManager())

                .RegisterType<ISP_FreedomTotalChangerPresenter, SP_FreedomTotalChangerPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISP_FreedomTotalChangerUC, SP_FreedomTotalChangerUC>(new ContainerControlledLifetimeManager())

                .RegisterType<IExchangeRateView, ExchangeRateView>(new ContainerControlledLifetimeManager())
                .RegisterType<IExchangeRatePresenter, ExchangeRatePresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPricingView, PricingView>(new ContainerControlledLifetimeManager())
                .RegisterType<IPricingPresenter, PricingPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_LouverGalleryPropertyUC, PP_LouverGalleryPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_LouverGalleryPropertyUCPresenter, PP_LouverGalleryPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_LouverGallerySetPropertyUC, PP_LouverGallerySetPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_LouverGallerySetPropertyUCPresenter, PP_LouverGallerySetPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IPP_LouverGallerySetOptionPropertyUC, PP_LouverGallerySetOptionPropertyUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IPP_LouverGallerySetOptionPropertyUCPresenter, PP_LouverGallerySetOptionPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IFP_TrackProfilePropertyUCPresenter, FP_TrackProfilePropertyUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IFP_TrackProfilePropertyUC, FP_TrackProfilePropertyUC>(new ContainerControlledLifetimeManager())

                .RegisterType<IFP_ScreenPropertyUCPresenter, FP_ScreenPropertyUCPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IFP_ScreenPropertyUC, FP_ScreenPropertyUC>(new ContainerControlledLifetimeManager())

                .RegisterType<ISetMultipleGlassThicknessPresenter, SetMultipleGlassThicknessPresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<ISetMultipleGlassThicknessView, SetMultipleGlassThicknessView>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPDFCompilerView, PDFCompilerView>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPDFCompilerPresenter, PDFCompilerPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<IRDLCReportCompilerView, RDLCReportCompilerView>(new ContainerControlledLifetimeManager())
                 .RegisterType<IRDLCReportCompilerPresenter, RDLCReportCompilerPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPDFWaitFormPresenter, PDFWaitFormPresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPDFWaitFormView, PDFWaitFormView>(new ContainerControlledLifetimeManager())

                 .RegisterType<IFP_TubularPropertyUCPresenter, FP_TubularPropertyUCPresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<IFP_TubularPropertyUC, FP_TubularPropertyUC>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPriceHistoryPresenter, PriceHistoryPresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPriceHistoryView, PriceHistoryView>(new ContainerControlledLifetimeManager())

                 .RegisterType<IGlassUpgradePresenter, GlassUpgradePresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<IGlassUpgradeView, GlassUpgradeView>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPartialAdjustmentViewPresenter,PartialAdjustmentViewPresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPartialAdjustmentView,PartialAdjustmentView>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPartialAdjustmentUC,PartialAdjustmentUC>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPartialAdjustmentUCPresenter,PartialAdjustmentUCPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPartialAdjustmenItemDisabledUC, PartialAdjustmenItemDisabledUC>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPartialAdjustmentItemDisabledUCPresenter,PartialAdjustmentItemDisabledUCPresenter>(new ContainerControlledLifetimeManager())
                 
                 .RegisterType<IPartialAdjustmentBaseHolderPresenter,PartialAdjustmentBaseHolderPresenter>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPartialAdjustmentBaseHolderUC,PartialAdjustmentBaseHolderUC>(new ContainerControlledLifetimeManager())

                 .RegisterType<ITopView, TopView>(new ContainerControlledLifetimeManager())
                 .RegisterType<ITopViewPresenter, TopViewPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<ITopViewPanelViewer, TopViewPanelViewer>(new ContainerControlledLifetimeManager())
                 .RegisterType<ITopViewPanelViewerPresenter, TopViewPanelViewerPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<IPP_CenterProfilePropertyUC, PP_CenterProfilePropertyUC>(new ContainerControlledLifetimeManager())
                 .RegisterType<IPP_CenterProfilePropertyUCPresenter, PP_CenterProfilePropertyUCPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<IFP_CladdingQtyPropertyUC, FP_CladdingQtyPropertyUC>(new ContainerControlledLifetimeManager())
                 .RegisterType<IFP_CladdingQtyPropertyUCPresenter, FP_CladdingQtyPropertyUCPresenter>(new ContainerControlledLifetimeManager())

                 .RegisterType<IGeorgianBarCustomizeDesignView, GeorgianBarCustomizeDesignView>(new ContainerControlledLifetimeManager())
                 .RegisterType<IGeorgianBarCustomizeDesignPresenter, GeorgianBarCustomizeDesignPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_sqlconStr))
                .RegisterType<IConcreteUC, ConcreteUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IConcreteUCPresenter, ConcreteUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_sqlconStr))
                .RegisterType<IProjectQuoteRepository, ProjectQuoteRepository>(new InjectionConstructor(_sqlconStr))
                .RegisterType<IAddressRepository, AddressRepository>(new InjectionConstructor(_sqlconStr))
                .RegisterType<IEmployeeRepository, EmployeeRepository>(new InjectionConstructor(_sqlconStr))
                .RegisterType<ICustomerRefNoRepository, CustomerRefNoRepository>(new InjectionConstructor(_sqlconStr))
                .RegisterType<IQuotationRepository, QuotationRepository>(new InjectionConstructor(_sqlconStr))


                ;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ILoginPresenter loginPresenter = UnityC.Resolve<LoginPresenter>();

            ILoginView loginView = loginPresenter.GetLoginView(UnityC);
            Application.Run((LoginView)loginView);

            //ICustomArrowHeadPresenter presenter = UnityC.Resolve<CustomArrowHeadPresenter>();

            //ICustomArrowHeadView view = presenter.GetICustomArrowHeadView();
            //Application.Run((CustomArrowHeadView)view);
        }
    }
}
