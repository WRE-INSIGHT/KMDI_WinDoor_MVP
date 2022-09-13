using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_PopUpHandlePropertyUCPresenter : IPresenterCommon
    {
        IPP_PopUpHandlePropertyUC GetPopUpHandlePropertyUC();

        IPP_PopUpHandlePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                          IPanelModel panelModel);
    }
}