using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public interface IPP_TrackRailPropertyUCPresenter : IPresenterCommon
    {
        IPP_TrackRailPropertyUC GetTrackRailPropertyUC();
        IPP_TrackRailPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                           IPanelModel panelModel);

    }
}