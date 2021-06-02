using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface IMultiPanelMullionImagerUCPresenter
    {
        IMultiPanelMullionImagerUC GetMultiPanelImager();
        IMultiPanelMullionImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                           IMultiPanelModel multiPanelModel, 
                                                           IFrameModel frameModel,
                                                           IFrameImagerUCPresenter frameImagerUCP);
        IMultiPanelMullionImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IMultiPanelModel multiPanelModel,
                                                           IFrameModel frameModel,
                                                           IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP);
        IMultiPanelMullionImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IMultiPanelModel multiPanelModel,
                                                           IFrameModel frameModel,
                                                           IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP);
        void AddControl(UserControl userctrlObj);
        void DeleteControl(UserControl userctrlObj);
    }
}