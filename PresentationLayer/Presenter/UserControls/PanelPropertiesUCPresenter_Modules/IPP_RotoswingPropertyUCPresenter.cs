using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_RotoswingPropertyUCPresenter
    {
        IPP_RotoswingPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel);
        IPP_RotoswingPropertyUC GetPPRotoswingPropertyUC();
    }
}