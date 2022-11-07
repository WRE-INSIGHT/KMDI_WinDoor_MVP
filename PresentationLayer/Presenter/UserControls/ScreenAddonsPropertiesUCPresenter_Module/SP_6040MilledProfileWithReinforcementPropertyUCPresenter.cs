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
            _6040MilledProfile = MilledProfile6040;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _6040MilledProfile.SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised += _6040MilledProfile_SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised;
        }

        private void _6040MilledProfile_SP6040MilledProfileWithReinforcementPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _6040MilledProfile.ThisBinding(CreateBindingDictionary());
        }

        public ISP_6040MilledProfileWithReinforcementPropertyUC Get6040MilledProfile()
        {
            return _6040MilledProfile;
        }

        public ISP_6040MilledProfileWithReinforcementPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                                            IMainPresenter mainPresenter,
                                                                                            IScreenModel screenModel)
        {
            unityC
                .RegisterType<ISP_6040MilledProfileWithReinforcementPropertyUC, SP_6040MilledProfileWithReinforcementPropertyUC>()
                .RegisterType<ISP_6040MilledProfileWithReinforcementPropertyUCPresenter, SP_6040MilledProfileWithReinforcementPropertyUCPresenter>();
            SP_6040MilledProfileWithReinforcementPropertyUCPresenter MilledProfile6040 = unityC.Resolve<SP_6040MilledProfileWithReinforcementPropertyUCPresenter>();
            MilledProfile6040._unityC = unityC;
            MilledProfile6040._mainPresenter = mainPresenter;
            MilledProfile6040._screenModel = screenModel;



            return MilledProfile6040;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_6040MilledProfileVisibility", new Binding("Visible", _screenModel, "Screen_6040MilledProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6040MilledProfile", new Binding("Value", _screenModel, "Screen_6040MilledProfile", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6040MilledProfileQty", new Binding("Value", _screenModel, "Screen_6040MilledProfileQty", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
