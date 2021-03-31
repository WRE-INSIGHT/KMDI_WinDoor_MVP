using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using Unity;

namespace PresentationLayer.Presenter.UserControls.Dividers.Imagers
{
    public interface IMullionImagerUCPresenter
    {
        IMullionImagerUC GetMullionImager();
        IMullionImagerUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                 IDividerModel divModel, 
                                                 IMultiPanelModel multiPanelModel, 
                                                 IFrameModel frameModel,
                                                 IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                 IMullionUC mullionUC);
    }
}