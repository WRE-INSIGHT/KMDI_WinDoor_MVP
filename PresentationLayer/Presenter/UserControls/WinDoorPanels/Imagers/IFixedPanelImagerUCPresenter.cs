using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface IFixedPanelImagerUCPresenter
    {
        IFixedPanelImagerUC GetFixedPanelImagerUC();
        IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                    IPanelModel panelModel,
                                                    IFrameImagerUCPresenter frameImagerUCP);
        IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                    IPanelModel panelModel,
                                                    IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                    IPanelModel panelModel,
                                                    IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
        
    }
}