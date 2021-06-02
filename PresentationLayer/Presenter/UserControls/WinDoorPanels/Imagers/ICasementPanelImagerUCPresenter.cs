using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface ICasementPanelImagerUCPresenter : IPresenterCommon
    {
        ICasementPanelImagerUC GetCasementPanelImagerUC();
        ICasementPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                       IPanelModel panelModel,
                                                       IFrameImagerUCPresenter frameImagerUCP);
        ICasementPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                       IPanelModel panelModel,
                                                       IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        ICasementPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                       IPanelModel panelModel,
                                                       IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
    }
}