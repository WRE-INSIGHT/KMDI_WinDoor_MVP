using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface IAwningPanelImagerUCPresenter: IPresenterCommon
    {
        IAwningPanelImagerUC GetAwningPanelUC();
        IAwningPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                     IPanelModel panelModel,
                                                     IFrameImagerUCPresenter frameImagerUCP);
    }
}