using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface ICustomArrowHeadUCPresenter
    {
        ICustomArrowHeadUCPresenter GetNewInstance(IUnityContainer unityC, ICustomArrowHeadPresenter customArrowHeadPresenter);
        ICustomArrowHeadUC GetCustomArrowUC();
    }
}
