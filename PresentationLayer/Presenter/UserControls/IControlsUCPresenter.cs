using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IControlsUCPresenter
    {
        IControlsUC GetControlUC();
        IControlsUCPresenter GetNewInstance(IUnityContainer unityC, string customtext, UserControl WinDoorPanel);
    }
}