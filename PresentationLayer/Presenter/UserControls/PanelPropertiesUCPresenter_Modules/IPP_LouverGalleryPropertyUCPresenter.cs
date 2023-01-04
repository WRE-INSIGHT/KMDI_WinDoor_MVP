using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_LouverGalleryPropertyUCPresenter : IPresenterCommon
    {
        IPP_LouverGalleryPropertyUC GetLouverGalleryPropertyUC();
        IPP_LouverGalleryPropertyUCPresenter GetNewInstance(IUnityContainer _unityC, IMainPresenter _mainPresenter, IPanelModel _panelModel);
    }
}