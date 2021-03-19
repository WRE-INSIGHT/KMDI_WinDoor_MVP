﻿using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public interface ITransomUCPresenter
    {
        ITransomUCPresenter GetNewInstance(IUnityContainer unityC, 
                                           IDividerModel divModel, 
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelTransomUCPresenter multiTransomUCP,
                                           IFrameModel frameModel);
        ITransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                           IDividerModel divModel,
                                           IMultiPanelModel multiPanelModel,
                                           IMultiPanelMullionUCPresenter multiMullionUCP,
                                           IFrameModel frameModel);
        ITransomUCPresenter GetNewInstance(IUnityContainer unityC); //for Testing
        ITransomUC GetTransom(string test); //for Testing
        ITransomUC GetTransom();
        void SetInitialLoadFalse();
    }
}