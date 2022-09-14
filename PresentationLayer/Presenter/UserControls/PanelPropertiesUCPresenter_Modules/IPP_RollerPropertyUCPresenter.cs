using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_RollerPropertyUCPresenter : IPresenterCommon
    {
        IPP_RollerPropertyUC GetRollerTypePropertyUC();

        IPP_RollerPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IMainPresenter mainPresenter);
    }
}