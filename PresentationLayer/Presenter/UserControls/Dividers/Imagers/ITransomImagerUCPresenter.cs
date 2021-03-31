using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers.Imagers
{
    public interface ITransomImagerUCPresenter
    {
        ITransomImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                 IDividerModel divModel, 
                                                 IMultiPanelModel multiPanelModel, 
                                                 IFrameModel frameModel, 
                                                 IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP,
                                                 ITransomUC transomUC);
        ITransomImagerUC GetTransomImager();
    }
}