using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IMultiPanelPropertiesUCPresenter
    {
        IMultiPanelPropertiesUC GetMultiPanelPropertiesUC();
        IMultiPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMainPresenter mainPresenter);
        FlowLayoutPanel GetMultiPanelPropertiesFLP();
    }
}