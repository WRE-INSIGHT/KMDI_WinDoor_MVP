using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_MVDPropertyUCPresenter
    {
        IPP_MVDPropertyUC GetMVDPropertyUC();
        IPP_MVDPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel);
    }
}