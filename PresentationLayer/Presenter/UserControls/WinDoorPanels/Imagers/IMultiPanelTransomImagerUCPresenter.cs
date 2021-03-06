﻿using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public interface IMultiPanelTransomImagerUCPresenter
    {
        IMultiPanelTransomImagerUC GetMultiPanelImager();
        IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                           IMultiPanelModel multiPanelModel, 
                                                           IFrameModel frameModel, 
                                                           IFrameImagerUCPresenter frameImagerUCP);
        IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IMultiPanelModel multiPanelModel,
                                                           IFrameModel frameModel,
                                                           IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP);
        IMultiPanelTransomImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IMultiPanelModel multiPanelModel,
                                                           IFrameModel frameModel,
                                                           IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
        void AddControl(UserControl userctrlObj);
        void DeleteControl(UserControl userctrlObj);
    }
}