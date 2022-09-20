using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_FrameConnectionTypePropertyUCPresenter : IPresenterCommon
    {
        IFP_FrameConnectionTypePropertyUC GetFrameConnectionTypePropertyUC();

        IFP_FrameConnectionTypePropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                  IFrameModel frameModel,
                                                                  IMainPresenter mainPresenter);
    }
}