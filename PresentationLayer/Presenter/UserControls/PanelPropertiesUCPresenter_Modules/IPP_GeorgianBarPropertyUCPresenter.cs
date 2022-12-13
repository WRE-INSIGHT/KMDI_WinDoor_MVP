using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_GeorgianBarPropertyUCPresenter
    {
        IPP_GeorgianBarPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter);
        IPP_GeorgianBarPropertyUC GetPPGeorgianBarPropertyUC();
    }
}
