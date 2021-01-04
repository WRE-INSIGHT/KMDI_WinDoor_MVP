using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IPanelPropertiesUCPresenter
    {
        IPanelPropertiesUC GetPanelPropertiesUC();
        IPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter);
    }
}