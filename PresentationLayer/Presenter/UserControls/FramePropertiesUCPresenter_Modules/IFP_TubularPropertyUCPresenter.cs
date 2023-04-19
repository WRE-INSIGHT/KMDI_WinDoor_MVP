using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_TubularPropertyUCPresenter : IPresenterCommon
    {
        IFP_TubularPropertyUC GetTubularPropertyUC();

        IFP_TubularPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFramePropertiesUCPresenter framePropertiesUCPresenter);
    }
}