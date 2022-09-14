using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_AliminumTrackPropertyUCPresenter : IPresenterCommon
    {
        IPP_AliminumTrackPropertyUC GetAliminumTrackPropertyUC();
        IPP_AliminumTrackPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IPanelModel panelModel,
                                                            IMainPresenter mainPresenter);
    }
}