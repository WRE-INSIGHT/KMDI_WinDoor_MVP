using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.User;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IFixedPanelUCPresenter
    {
        bool boolKeyDown { set; }
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, 
                                              IPanelModel panelModel, 
                                              IFrameModel frameModel,
                                              IUserModel userModel,
                                              IMainPresenter mainPresenter,
                                              IFrameUCPresenter frameUCP);
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                              IPanelModel panelModel,
                                              IFrameModel frameModel,
                                              IUserModel userModel,
                                              IMainPresenter mainPresenter,
                                              IMultiPanelModel multiPanelModel,
                                              IMultiPanelMullionUCPresenter multiPanelUCP,
                                              IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                              IPanelModel panelModel,
                                              IFrameModel frameModel,
                                              IUserModel userModel,
                                              IMainPresenter mainPresenter,
                                              IMultiPanelModel multiPanelModel,
                                              IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                              IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
        IFixedPanelUC GetFixedPanelUC();
        void SetInitialLoadFalse();
        void FocusOnThisFixedPanel();
    }
}