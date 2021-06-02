using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IFixedPanelUCPresenter
    {
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, 
                                              IPanelModel panelModel, 
                                              IFrameModel frameModel, 
                                              IMainPresenter mainPresenter,
                                              IFrameUCPresenter frameUCP);
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                              IPanelModel panelModel,
                                              IFrameModel frameModel,
                                              IMainPresenter mainPresenter,
                                              IMultiPanelModel multiPanelModel,
                                              IMultiPanelMullionUCPresenter multiPanelUCP,
                                              IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                              IPanelModel panelModel,
                                              IFrameModel frameModel,
                                              IMainPresenter mainPresenter,
                                              IMultiPanelModel multiPanelModel,
                                              IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                              IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
        IFixedPanelUC GetFixedPanelUC();
        void SetInitialLoadFalse();
    }
}