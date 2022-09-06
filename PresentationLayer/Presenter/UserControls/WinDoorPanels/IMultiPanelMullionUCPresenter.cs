using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IMultiPanelMullionUCPresenter
    {
        IMultiPanelPropertiesUCPresenter multiPropUCP2_given { get; }
        IMultiPanelMullionUC GetMultiPanel();
        FlowLayoutPanel GetflpMullion();
        IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                     IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                     IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP_parent);
        IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                     IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP);
        void frmDimensionResults(int frmDimension_numWd,
                                 int frmDimension_numHt);
        void DeletePanel(UserControl panel);
        void Invalidate_MultiPanelMullionUC();
        void SetInitialLoadFalse();
    }
}