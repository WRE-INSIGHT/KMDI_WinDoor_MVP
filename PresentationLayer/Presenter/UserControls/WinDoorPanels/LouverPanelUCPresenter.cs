using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
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
    public class LouverPanelUCPresenter : ILouverPanelUCPresenter, IPresenterCommon
    {
        ILouverPanelUC _louverPanelUC;

        private IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;

        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;

        private IDividerServices _divServices;


        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _initialLoad;

        public LouverPanelUCPresenter(ILouverPanelUC louverPanelUC,
                                      IDividerServices divServices,
                                      ITransomUCPresenter transomUCP,
                                      IMullionUCPresenter mullionUCP)
        {
            _louverPanelUC = louverPanelUC;
            _divServices = divServices;
            _transomUCP = transomUCP;
            _mullionUCP = mullionUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _louverPanelUC.louverPanelUCLoadEventRaised += _louverPanelUC_louverPanelUCLoadEventRaised;
            _louverPanelUC.louverPanelUCMouseEnterEventRaised += _louverPanelUC_louverPanelUCMouseEnterEventRaised;
            _louverPanelUC.louverPanelUCMouseLeaveEventRaised += _louverPanelUC_louverPanelUCMouseLeaveEventRaised;
            _louverPanelUC.louverPanelUCSizeChangedEventRaised += _louverPanelUC_louverPanelUCSizeChangedEventRaised;
            _louverPanelUC.deleteToolStripClickedEventRaised += _louverPanelUC_deleteToolStripClickedEventRaised;
        }

        private void _louverPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {

        }

        private void _louverPanelUC_louverPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {

        }

        private void _louverPanelUC_louverPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {

        }

        private void _louverPanelUC_louverPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {

        }

        private void _louverPanelUC_louverPanelUCLoadEventRaised(object sender, EventArgs e)
        {
            _louverPanelUC.ThisBinding(CreateBindingDictionary());
        }

        public ILouverPanelUC GetLouverPanelUC()
        {
            _initialLoad = true;
            return _louverPanelUC;
        }


        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._frameUCP = frameUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._multiPanelModel = multiPanelModel;
            louverUCP._multiPanelMullionUCP = multiPanelUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
        }

        public ILouverPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiPanelTransomUCP)
        {
            unityC
                .RegisterType<ILouverPanelUC, LouverPanelUC>()
                .RegisterType<ILouverPanelUCPresenter, LouverPanelUCPresenter>();
            LouverPanelUCPresenter louverUCP = unityC.Resolve<LouverPanelUCPresenter>();
            louverUCP._panelModel = panelModel;
            louverUCP._frameModel = frameModel;
            louverUCP._mainPresenter = mainPresenter;
            louverUCP._multiPanelModel = multiPanelModel;
            louverUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            louverUCP._unityC = unityC;

            return louverUCP;
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
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_MarginToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }
}