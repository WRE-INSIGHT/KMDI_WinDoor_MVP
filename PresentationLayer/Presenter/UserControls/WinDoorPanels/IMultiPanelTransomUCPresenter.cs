﻿using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;
using System.Drawing;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using ModelLayer.Model.User;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IMultiPanelTransomUCPresenter
    {
        IMultiPanelPropertiesUCPresenter multiPropUCP2_given { get; }
        void DeletePanel(UserControl obj);
        void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt);
        IMultiPanelTransomUC GetMultiPanel();
        FlowLayoutPanel GetflpTransom();
        IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IUserModel userModel,
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                     IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP);
        //IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC, 
        //                                             IMultiPanelModel multiPanelModel, 
        //                                             IFrameModel frameModel, 
        //                                             IMainPresenter mainPresenter, 
        //                                             IFrameUCPresenter frameUCP,
        //                                             IMultiPanelPropertiesUCPresenter multiPropUCP,
        //                                             IFrameImagerUCPresenter frameImagerUCP,
        //                                             IBasePlatformImagerUCPresenter basePlatformImagerUCP,
        //                                             IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP,
        //                                             IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP_parent);
        //IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
        //                                             IMultiPanelModel multiPanelModel,
        //                                             IFrameModel frameModel,
        //                                             IMainPresenter mainPresenter,
        //                                             IFrameUCPresenter frameUCP,
        //                                             IMultiPanelPropertiesUCPresenter multiPropUCP,
        //                                             IFrameImagerUCPresenter frameImagerUCP,
        //                                             IBasePlatformImagerUCPresenter basePlatformImagerUCP,
        //                                             IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP,
        //                                             IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP_parent);
        IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IUserModel userModel,
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelMullionUCPresenter multiPanelMullionUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                     IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP,
                                                     IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP);
        void Invalidate_MultiPanelMullionUC();
        void SetInitialLoadFalse();
    }
}