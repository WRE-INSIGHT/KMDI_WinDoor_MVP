using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFramePropertiesUCPresenter
    {
        IFramePropertiesUC GetFramePropertiesUC();
        IFramePropertiesUCPresenter GetNewInstance(IFrameModel frameModel, IUnityContainer unityC, IFrameUC frameUC, IMainPresenter mainPresenter);
    }
}