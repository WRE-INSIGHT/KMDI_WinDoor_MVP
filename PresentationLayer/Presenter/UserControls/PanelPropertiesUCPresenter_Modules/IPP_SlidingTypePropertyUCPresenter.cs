using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_SlidingTypePropertyUCPresenter : IPresenterCommon
    {
        IPP_SlidingTypePropertyUC GetSlidingTypePropertyUC();

        IPP_SlidingTypePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                          IPanelModel panelModel,
                                                          IMainPresenter mainPresenter);
    }
}