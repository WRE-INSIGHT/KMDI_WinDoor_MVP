using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_1385MilledProfilePropertyUCPresenter : IPresenterCommon
    {
        ISP_1385MilledProfilePropertyUC Get1385MilledProfilePropertyUC();

        ISP_1385MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                          IMainPresenter mainPresenter,
                                                                          IScreenModel screenModel,
                                                                          IScreenPresenter screenPresenter);
    }
}