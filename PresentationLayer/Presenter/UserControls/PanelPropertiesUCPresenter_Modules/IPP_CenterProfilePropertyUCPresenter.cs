using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_CenterProfilePropertyUCPresenter : IPresenterCommon
    {
        IPP_CenterProfilePropertyUC GetCenterProfilePropertyUC();
        IPP_CenterProfilePropertyUCPresenter CreateNewInstance(IMainPresenter mainPresenter,
                                                                      IUnityContainer unityC,
                                                                      IPanelModel panelModel,
                                                                      IFramePropertiesUCPresenter framePropertiesUCPresenter);
    }
}