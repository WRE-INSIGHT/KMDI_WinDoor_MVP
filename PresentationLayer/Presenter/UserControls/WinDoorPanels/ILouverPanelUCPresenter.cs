using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface ILouverPanelUCPresenter
    {
        ILouverPanelUC GetLouverPanelUC();
        ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel, IMainPresenter mainPresenter, IFrameUCPresenter frameUCP);
        ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel, IMainPresenter mainPresenter, IMultiPanelModel multiPanelModel, IMultiPanelMullionUCPresenter multiPanelUCP);
        ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel, IMainPresenter mainPresenter, IMultiPanelModel multiPanelModel, IMultiPanelTransomUCPresenter multiPanelTransomUCP);
        void SetInitialLoadFalse();
    }
}