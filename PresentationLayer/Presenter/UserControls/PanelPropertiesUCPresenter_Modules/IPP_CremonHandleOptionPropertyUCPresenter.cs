using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_CremonHandleOptionPropertyUCPresenter
    {
        IPP_CremonHandleOptionPropertyUC GetCremonHandleOptionPropertyUC();
        IPP_CremonHandleOptionPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IPanelModel panelModel);
    }
}