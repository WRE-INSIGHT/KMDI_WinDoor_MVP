using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IFixedPanelUCPresenter
    {
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel);
        IFixedPanelUC GetFixedPanelUC();
    }
}