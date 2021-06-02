using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface ISlidingPanelImagerUCPresenter: IPresenterCommon
    {
        ISlidingPanelImagerUC GetSlidingPanelImagerUC();
        ISlidingPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                      IPanelModel panelModel,
                                                      IFrameImagerUCPresenter frameImagerUCP);
        ISlidingPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        ISlidingPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
    }
}