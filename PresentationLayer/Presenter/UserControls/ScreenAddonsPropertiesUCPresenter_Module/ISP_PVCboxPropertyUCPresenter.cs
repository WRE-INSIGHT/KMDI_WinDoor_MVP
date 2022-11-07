using CommonComponents;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public interface ISP_PVCboxPropertyUCPresenter : IPresenterCommon
    {
        ISP_PVCboxPropertyUC GetPVCboxPropertyUC();

        ISP_PVCboxPropertyUCPresenter CreatenewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IScreenModel screenModel);
    }
}