using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface ICasementPanelUCPresenter
    {
        ICasementPanelUC GetCasementPanelUC();
        ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel, IMainPresenter mainPresenter);
        ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IMultiPanelModel multiPanelModel,
                                                     IMultiPanelMullionUCPresenter multiPanelUCP);
        void SetInitialLoadFalse();
    }
}