using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_DummyDHandlePropertyUCPresenter : IPresenterCommon
    {
        IPP_DummyDHandlePropertyUC GetDummyDHandlePropertyUC();
        IPP_DummyDHandlePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                              IPanelModel panelModel,
                                                              IMainPresenter mainPresenter);
    }
}