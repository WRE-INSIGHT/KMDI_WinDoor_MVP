using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_CenterClosurePropertyUCPresenter : IPresenterCommon
    {
        ISP_CenterClosurePropertyUC GetISP_CenterClosurePropertyUC();

        ISP_CenterClosurePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                               IMainPresenter mainPresenter,
                                                               IScreenModel screenModel,
                                                               IScreenPresenter screenPresenter);
    }
}