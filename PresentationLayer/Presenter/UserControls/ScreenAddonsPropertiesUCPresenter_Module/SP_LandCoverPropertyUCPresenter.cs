using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_LandCoverPropertyUCPresenter : ISP_LandCoverPropertyUCPresenter
    {
        ISP_LandCoverPropertyUC _LandCoverPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public SP_LandCoverPropertyUCPresenter(ISP_LandCoverPropertyUC LandCoverPropertyUC)
        {
            _LandCoverPropertyUC = LandCoverPropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _LandCoverPropertyUC.SPLandCoverPropertyUCLoadEventRaised += _LandCoverPropertyUC_SPLandCoverPropertyUCLoadEventRaised;
        }

        private void _LandCoverPropertyUC_SPLandCoverPropertyUCLoadEventRaised(object sender, EventArgs e)
        {

        }

        public ISP_LandCoverPropertyUC GetLandCoverPropertyUC()
        {
            return _LandCoverPropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();



            return binding;
        }
    }
}
