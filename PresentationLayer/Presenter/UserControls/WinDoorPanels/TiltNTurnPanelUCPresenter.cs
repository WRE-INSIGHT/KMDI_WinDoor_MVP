using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class TiltNTurnPanelUCPresenter : ITiltNTurnPanelUCPresenter, IPresenterCommon
    {
        ITiltNTurnPanelUC _tiltNTurnPanelUC;

        private IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;

        private IDividerServices _divServices;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _initialLoad;

        public TiltNTurnPanelUCPresenter(ITiltNTurnPanelUC tiltNTurnPanelUC,
                                         IDividerServices divServices,
                                         ITransomUCPresenter transomUCP,
                                         IMullionUCPresenter mullionUCP,
                                         IMullionImagerUCPresenter mullionImagerUCP,
                                         ITransomImagerUCPresenter transomImagerUCP)
        {
            _tiltNTurnPanelUC = tiltNTurnPanelUC;
            _divServices = divServices;
            _transomUCP = transomUCP;
            _mullionUCP = mullionUCP;
            _mullionImagerUCP = mullionImagerUCP;
            _transomImagerUCP = transomImagerUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {

        }


        public ITiltNTurnPanelUC GetTiltNTurnPanelUC()
        {
            _initialLoad = true;
            _tiltNTurnPanelUC.ThisBinding(CreateBindingDictionary());
            return _tiltNTurnPanelUC;
        }


        public ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>()
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>();
            TiltNTurnPanelUCPresenter presenter = unityC.Resolve<TiltNTurnPanelUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._frameModel = frameModel;
            presenter._mainPresenter = mainPresenter;
            presenter._frameUCP = frameUCP;
            presenter._unityC = unityC;

            return presenter;
        }

        public ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP,
                                                        IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>()
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>();
            TiltNTurnPanelUCPresenter presenter = unityC.Resolve<TiltNTurnPanelUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._frameModel = frameModel;
            presenter._mainPresenter = mainPresenter;
            presenter._multiPanelModel = multiPanelModel;
            presenter._multiPanelMullionUCP = multiPanelUCP;
            presenter._unityC = unityC;
            presenter._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return presenter;
        }

        public ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                        IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>()
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>();
            TiltNTurnPanelUCPresenter presenter = unityC.Resolve<TiltNTurnPanelUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._frameModel = frameModel;
            presenter._mainPresenter = mainPresenter;
            presenter._multiPanelModel = multiPanelModel;
            presenter._multiPanelTransomUCP = multiPanelTransomUCP;
            presenter._unityC = unityC;
            presenter._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Name", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_WidthToBind", new Binding("Width", _panelModel, "Panel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HeightToBind", new Binding("Height", _panelModel, "Panel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_DisplayHeight", new Binding("Panel_DisplayHeight", _panelModel, "Panel_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_MarginToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtensionOptionsVisibility", new Binding("Panel_ExtensionOptionsVisibility", _panelModel, "Panel_ExtensionOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
