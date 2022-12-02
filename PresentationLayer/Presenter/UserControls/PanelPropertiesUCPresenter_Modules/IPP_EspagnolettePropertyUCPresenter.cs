using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_EspagnolettePropertyUCPresenter
    {
        IPP_EspagnolettePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter);
        IPP_EspagnolettePropertyUC GetPPEspagnolettePropertyUC();
    }
}