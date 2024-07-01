using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.User;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface ICasementPanelUCPresenter
    {
        ICasementPanelUC GetCasementPanelUC();
        bool boolKeyDown { set; }
        ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                 IPanelModel panelModel,
                                                 IFrameModel frameModel,
                                                 IUserModel userModel,
                                                 IMainPresenter mainPresenter,
                                                 IFrameUCPresenter frameUCP);
        ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IFrameModel frameModel,
                                                     IUserModel userModel,
                                                     IMainPresenter mainPresenter,
                                                     IMultiPanelModel multiPanelModel,
                                                     IMultiPanelMullionUCPresenter multiPanelUCP,
                                                     IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                 IPanelModel panelModel,
                                                 IFrameModel frameModel,
                                                 IUserModel userModel,
                                                 IMainPresenter mainPresenter,
                                                 IMultiPanelModel multiPanelModel,
                                                 IMultiPanelTransomUCPresenter multiTransomUCP,
                                                 IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP);
        void SetInitialLoadFalse();
        void FocusOnThisCasementPanel();
    }
}