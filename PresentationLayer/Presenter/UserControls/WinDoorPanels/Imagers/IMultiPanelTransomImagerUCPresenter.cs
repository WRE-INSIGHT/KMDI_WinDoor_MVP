using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface IMultiPanelTransomImagerUCPresenter
    {
        IMultiPanelTransomImagerUC GetMultiPanelImager();
        IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC, IMultiPanelModel multiPanelModel, IFrameModel frameModel, IFrameImagerUCPresenter frameImagerUCP);
    }
}