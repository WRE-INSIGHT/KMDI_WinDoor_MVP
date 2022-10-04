using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_LouverBladesPropertyUCPresenter : IPresenterCommon
    {
        IPP_LouverBladesPropertyUC GetIPP_LouverBladesPropertyUC();

        IPP_LouverBladesPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                              IPanelModel panelModel);
    }
}