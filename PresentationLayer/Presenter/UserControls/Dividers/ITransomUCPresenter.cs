using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public interface ITransomUCPresenter
    {
        bool boolKeyDown { set; }
        ITransomUCPresenter GetNewInstance(IUnityContainer unityC, 
                                           IDividerModel divModel, 
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelTransomUCPresenter multiTransomUCP,
                                           IFrameModel frameModel,
                                           IMainPresenter mainPresenter);
        ITransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                           IDividerModel divModel,
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelMullionUCPresenter multiMullionUCP,
                                           IFrameModel frameModel,
                                           IMainPresenter mainPresenter);
        ITransomUCPresenter GetNewInstance(IUnityContainer unityC); //for Testing
        ITransomUC GetTransom(string test); //for Testing
        ITransomUC GetTransom();
        void SetInitialLoadFalse();
        void FocusOnThisTransomDiv();
    }
}