using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_HingePropertyUCPresenter
    {
        IPP_HingePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelMode);
        IPP_HingePropertyUC GetPP_HingePropertyUC();
    }
}
