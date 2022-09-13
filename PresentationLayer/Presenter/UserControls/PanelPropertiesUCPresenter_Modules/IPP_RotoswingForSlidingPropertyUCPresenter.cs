using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_RotoswingForSlidingPropertyUCPresenter : IPresenterCommon
    {
        IPP_RotoswingForSlidingPropertyUC GetRotoswingForSlidingPropertyUC();

        IPP_RotoswingForSlidingPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                     IPanelModel panelModel);
    }
}