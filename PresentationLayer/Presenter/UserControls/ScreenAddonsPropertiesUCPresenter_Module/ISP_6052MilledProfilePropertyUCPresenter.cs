using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_6052MilledProfilePropertyUCPresenter : IPresenterCommon
    {
        ISP_6052MilledProfilePropertyUC Get6052MilledProfilePropertyUC();

        ISP_6052MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IScreenModel screenModel,
                                                                    IScreenPresenter screenPresenter);

    }
}