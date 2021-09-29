using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_NTCenterHingePropertyUCPresenter : IPresenterCommon
    {
        IPP_NTCenterHingePropertyUC GetNTCenterHingePropertyUC();
        IPP_NTCenterHingePropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC);
    }
}
