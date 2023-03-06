using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_SpringLoadedUCPresenter
    {
        ISP_SpringLoadedUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                  IMainPresenter mainPresenter, 
                                                  IScreenModel screenModel,
                                                  IScreenPresenter screenPresenter);
        ISP_SpringLoadedUC GetspringloadedUC();


    }
}