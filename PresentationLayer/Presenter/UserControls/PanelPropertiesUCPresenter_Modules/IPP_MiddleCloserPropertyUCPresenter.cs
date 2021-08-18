using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_MiddleCloserPropertyUCPresenter : IPresenterCommon
    {
        IPP_MiddleCloserPropertyUC GetMiddleCloserPropertyUC();
        IPP_MiddleCloserPropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC);
    }
}
