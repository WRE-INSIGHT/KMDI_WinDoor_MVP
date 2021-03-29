using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using Unity;
using System.Drawing;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public interface IMultiPanelTransomUCPresenter
    {
        void DeletePanel(UserControl obj);
        void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt);
        IMultiPanelTransomUC GetMultiPanel();
        IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                     IMultiPanelModel multiPanelModel, 
                                                     IFrameModel frameModel, 
                                                     IMainPresenter mainPresenter, 
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP);
        IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP);
        IMultiPanelTransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IMultiPanelModel multiPanelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP,
                                                     IMultiPanelMullionUCPresenter multiPanelMullionUCP,
                                                     IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                     IFrameImagerUCPresenter frameImagerUCP,
                                                     IBasePlatformImagerUCPresenter basePlatformImagerUCP);
        void Invalidate_MultiPanelMullionUC();
        void SetInitialLoadFalse();
    }
}