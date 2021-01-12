using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IMultiPanelMullionUCPresenter
    {
        IMultiPanelMullionUC GetMultiPanel();
        IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC, IMultiPanelModel multiPanelModel);
    }
}