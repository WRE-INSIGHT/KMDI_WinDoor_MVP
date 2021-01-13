using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IMultiPanelMullionUCPresenter
    {
        IMultiPanelMullionUC GetMultiPanel();
        IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter);
        void frmDimensionResults(int frmDimension_numWd,
                                 int frmDimension_numHt);
    }
}