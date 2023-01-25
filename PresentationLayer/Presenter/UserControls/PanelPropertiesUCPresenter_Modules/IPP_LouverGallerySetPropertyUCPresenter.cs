using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System.Collections.Generic;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_LouverGallerySetPropertyUCPresenter : IPresenterCommon
    {
        IPP_LouverGallerySetPropertyUC GetLouverGallerySetPropertyUC();
        IPP_LouverGallerySetPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, IPanelModel panelModel);
        int GallerySet_Count { get; set; }
        List<IPP_LouverGallerySetOptionPropertyUCPresenter> _lst_gallerySetOptionUCP { get; set; }

        void Remove_GallerySet(IPP_LouverGallerySetOptionPropertyUCPresenter GallerySetOptionUCP);
        void SortGallerySetOrderNumber();
    }
}