using System.Collections.Generic;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.User;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface ITiltNTurnPanelUCPresenter
    {
        ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel,IUserModel userModel, IMainPresenter mainPresenter, IFrameUCPresenter frameUCP);
        ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel,IUserModel userModel, IMainPresenter mainPresenter, IMultiPanelModel multiPanelModel, IMultiPanelTransomUCPresenter multiPanelTransomUCP, IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
        ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IFrameModel frameModel,IUserModel userModel, IMainPresenter mainPresenter, IMultiPanelModel multiPanelModel, IMultiPanelMullionUCPresenter multiPanelUCP, IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        ITiltNTurnPanelUC GetTiltNTurnPanelUC();
        void SetInitialLoadFalse();
    }
}