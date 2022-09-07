using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_DHandlePropertyUCPresenter : IPresenterCommon
    {
        IPP_DHandlePropertyUC GetDHandlePropertyUC();

        IPP_DHandlePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                         IPanelModel panelModel,
                                                         IMainPresenter mainPresenter);
    }
}