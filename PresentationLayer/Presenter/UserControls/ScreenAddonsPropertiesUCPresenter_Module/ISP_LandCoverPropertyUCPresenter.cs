using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_LandCoverPropertyUCPresenter : IPresenterCommon
    {
        ISP_LandCoverPropertyUC GetLandCoverPropertyUC();
        ISP_LandCoverPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                           IMainPresenter mainPresenter,
                                                           IScreenModel screenModel);
    }
}