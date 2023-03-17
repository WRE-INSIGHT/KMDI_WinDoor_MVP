using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_MagnumScreenTypeUCPresenter
    {
        ISP_MagnumScreenTypeUCPresenter CreateNewInstance(IUnityContainer unityC, 
                                                          IMainPresenter mainPresenter,
                                                          IScreenModel screenModel,
                                                          IScreenPresenter screenPresenter);
        ISP_MagnumScreenTypeUC GetMagnumScreenTypeView();
    }
}