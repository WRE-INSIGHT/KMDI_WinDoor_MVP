using PresentationLayer.Views.UserControls.Dividers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public interface IMullionUCPresenter
    {
        IMullionUC GetMullion();
        IMullionUCPresenter GetNewInstance(IUnityContainer unityC);
    }
}