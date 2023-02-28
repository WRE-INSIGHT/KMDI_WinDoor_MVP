using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_TrackProfilePropertyUCPresenter : IPresenterCommon
    {
        IFP_TrackProfilePropertyUC GetTrackProfilePropertyUC();
        IFP_TrackProfilePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                              IFrameModel frameModel,
                                                              IMainPresenter mainPresenter);
    }
}