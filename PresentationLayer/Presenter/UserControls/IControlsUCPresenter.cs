using PresentationLayer.Views.UserControls;
using System.Drawing;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IControlsUCPresenter
    {
        IControlsUC GetControlUC();
        IControlsUCPresenter GetNewInstance(IUnityContainer unityC, string customtext, Image customimage);
    }
}