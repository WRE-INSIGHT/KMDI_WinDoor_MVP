using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_InversionClipPropertyUCPresenter : IPresenterCommon
    {
        IFP_InversionClipPropertyUC GetInversionClipPropertyUC();

        IFP_InversionClipPropertyUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IFrameModel frameModel);

    }
}
