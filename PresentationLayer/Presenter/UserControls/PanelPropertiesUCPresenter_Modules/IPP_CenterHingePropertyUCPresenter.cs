using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_CenterHingePropertyUCPresenter
    {
        IPP_CenterHingePropertyUC GetCenterHingePropertyUC();
        IPP_CenterHingePropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC);
    }
}
