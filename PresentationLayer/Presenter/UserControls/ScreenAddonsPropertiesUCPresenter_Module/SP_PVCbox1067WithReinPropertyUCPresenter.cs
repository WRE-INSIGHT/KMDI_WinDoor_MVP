using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_PVCbox1067WithReinPropertyUCPresenter : ISP_PVCbox1067WithReinPropertyUCPresenter
    {
        ISP_PVCbox1067WithReinPropertyUC _PVCbox1067WithReinPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public SP_PVCbox1067WithReinPropertyUCPresenter(ISP_PVCbox1067WithReinPropertyUC PVCbox1067WithReinPropertyUC)
        {
            _PVCbox1067WithReinPropertyUC = PVCbox1067WithReinPropertyUC;

            subcribeToEventSetup();
        }

        private void subcribeToEventSetup()
        {
            _PVCbox1067WithReinPropertyUC.SPPVCbox1067WithReinPropertyUCLoadEventRaised += _PVCbox1067WithReinPropertyUC_SPPVCbox1067WithReinPropertyUCLoadEventRaised;
        }

        private void _PVCbox1067WithReinPropertyUC_SPPVCbox1067WithReinPropertyUCLoadEventRaised(object sender, EventArgs e)
        {

        }

        public ISP_PVCbox1067WithReinPropertyUC GetPVCbox1067WithReinPropertyUC()
        {
            return _PVCbox1067WithReinPropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            return binding;
        }
    }
}
