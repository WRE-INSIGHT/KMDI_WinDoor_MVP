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
        IMullionUC GetMullion();
        IMullionUC GetMullion(string test); //for Testing
        IMullionUCPresenter GetNewInstance(IUnityContainer unityC); //for Testing
        IMullionUCPresenter GetNewInstance(IUnityContainer unityC, 
                                           IDividerModel divModel,
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelMullionUCPresenter multiMullionUCP,
                                           IFrameModel _frameModel);
        void SetInitialLoadFalse();
    }
}