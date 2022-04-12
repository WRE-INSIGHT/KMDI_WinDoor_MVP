using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface ICustomArrowHeadUCPresenter
    {
        ICustomArrowHeadUCPresenter GetNewInstance(IUnityContainer unityC, ICustomArrowHeadPresenter customArrowHeadPresenter, IWindoorModel windoorModel);
        ICustomArrowHeadUC GetCustomArrowUC();
    }
}
