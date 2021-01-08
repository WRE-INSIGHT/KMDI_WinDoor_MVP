using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface IFixedPanelImagerUCPresenter
    {
        IFixedPanelImagerUC GetFixedPanelImagerUC();
        IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel);
    }
}