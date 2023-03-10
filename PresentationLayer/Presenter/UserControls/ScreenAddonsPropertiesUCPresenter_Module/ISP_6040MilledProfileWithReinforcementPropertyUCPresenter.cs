using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_6040MilledProfileWithReinforcementPropertyUCPresenter : IPresenterCommon
    {
        ISP_6040MilledProfileWithReinforcementPropertyUC Get6040MilledProfile();
        ISP_6040MilledProfileWithReinforcementPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                                            IMainPresenter mainPresenter,
                                                                                            IScreenModel screenModel,
                                                                                            IScreenPresenter screenPresenter);
    }
}