using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public interface IMullionUCPresenter
    {
        bool boolKeyDown { set; }
        IMullionUC GetMullion();
        IMullionUC GetMullion(string test); //for Testing
        IMullionUCPresenter GetNewInstance(IUnityContainer unityC); //for Testing
        IMullionUCPresenter GetNewInstance(IUnityContainer unityC, 
                                           IDividerModel divModel,
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelMullionUCPresenter multiMullionUCP,
                                           IFrameModel frameModel,
                                           IMainPresenter mainPresenter);
        IMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                           IDividerModel divModel,
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelTransomUCPresenter multiTransomUCP,
                                           IFrameModel frameModel,
                                           IMainPresenter mainPresenter);
        void SetInitialLoadFalse();
        void FocusOnThisMullionDiv();
    }
}