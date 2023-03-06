using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_PVCbox1067WithReinPropertyUCPresenter : IPresenterCommon
    {
        ISP_PVCbox1067WithReinPropertyUC GetPVCbox1067WithReinPropertyUC();
        ISP_PVCbox1067WithReinPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IScreenModel screenModel,
                                                                    IScreenPresenter screenPresenter);
    }
}