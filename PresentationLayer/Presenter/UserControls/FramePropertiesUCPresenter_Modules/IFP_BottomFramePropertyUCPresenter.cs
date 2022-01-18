using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public interface IFP_BottomFramePropertyUCPresenter
    {
        IFP_BottomFramePropertyUC GetFP_BottomFramePropertiesUC();
        IFP_BottomFramePropertyUCPresenter GetNewInstance(IFrameModel frameModel, IUnityContainer unityC);
    }
}