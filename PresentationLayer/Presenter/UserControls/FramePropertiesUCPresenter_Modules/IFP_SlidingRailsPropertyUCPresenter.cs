using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_SlidingRailsPropertyUCPresenter : IPresenterCommon
    {
        IFP_SlidingRailsPropertyUC GetSlidingRailsPropertyUC();

        IFP_SlidingRailsPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IFrameModel frameModel,
                                                           IMainPresenter mainPresenter);
    }
}