using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_6040MilledProfileWithReinforcementPropertyUCPresenter : ISP_6040MilledProfileWithReinforcementPropertyUCPresenter
    {
        ISP_6040MilledProfileWithReinforcementPropertyUC _6040MilledProfile;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public SP_6040MilledProfileWithReinforcementPropertyUCPresenter(ISP_6040MilledProfileWithReinforcementPropertyUC MilledProfile6040)
        {
            MilledProfile6040 = _6040MilledProfile;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _6040MilledProfile.SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised += _6040MilledProfile_SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;
        }

        private void _6040MilledProfile_SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public ISP_6040MilledProfileWithReinforcementPropertyUC Get6040MilledProfile()
        {
            return _6040MilledProfile;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            return binding;
        }
    }
}
