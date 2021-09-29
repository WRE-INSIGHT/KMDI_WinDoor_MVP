using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_RotolinePropertyUCPresenter
    {
        IPP_RotolinePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel);
        IPP_RotolinePropertyUC GetRotolinePropertyUC();
    }
}