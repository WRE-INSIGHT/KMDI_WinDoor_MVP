using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_LouverGallerySetOptionPropertyUCPresenter : IPresenterCommon
    {
        IPP_LouverGallerySetOptionPropertyUC GetLouverGallerySetOptionPropertyUC();
        IPP_LouverGallerySetOptionPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IPanelModel panelModel);
    }
}