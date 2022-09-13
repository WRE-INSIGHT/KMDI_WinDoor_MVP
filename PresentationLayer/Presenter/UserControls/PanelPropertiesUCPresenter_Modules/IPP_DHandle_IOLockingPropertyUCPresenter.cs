using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_DHandle_IOLockingPropertyUCPresenter : IPresenterCommon
    {
        IPP_DHandle_IOLockingPropertyUC GetDHandle_IOLockingPropertyUC();
        IPP_DHandle_IOLockingPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                   IPanelModel panelModel);
    }
}