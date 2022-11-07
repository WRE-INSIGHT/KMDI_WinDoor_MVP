using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_1385MilledProfilePropertyUCPresenter : ISP_1385MilledProfilePropertyUCPresenter
    {
        ISP_1385MilledProfilePropertyUC _sp_1385MilledProfilePropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public SP_1385MilledProfilePropertyUCPresenter(ISP_1385MilledProfilePropertyUC sp_1385MilledProfilePropertyUC)
        {
            _sp_1385MilledProfilePropertyUC = sp_1385MilledProfilePropertyUC;

            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _sp_1385MilledProfilePropertyUC.SP1385MilledProfilePropertyUCLoadEventRaised += _sp_1385MilledProfilePropertyUC_SP1385MilledProfilePropertyUCLoadEventRaised;
        }

        private void _sp_1385MilledProfilePropertyUC_SP1385MilledProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_1385MilledProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_1385MilledProfilePropertyUC Get1385MilledProfilePropertyUC()
        {
            return _sp_1385MilledProfilePropertyUC;
        }

        public ISP_1385MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                          IMainPresenter mainPresenter,
                                                                          IScreenModel screenModel)
        {
            unityC
                    .RegisterType<ISP_1385MilledProfilePropertyUC, SP_1385MilledProfilePropertyUC>()
                    .RegisterType<ISP_1385MilledProfilePropertyUCPresenter, SP_1385MilledProfilePropertyUCPresenter>();
            SP_1385MilledProfilePropertyUCPresenter milledProfile1385 = unityC.Resolve<SP_1385MilledProfilePropertyUCPresenter>();
            milledProfile1385._unityC = unityC;
            milledProfile1385._mainPresenter = mainPresenter;
            milledProfile1385._screenModel = screenModel;


            return milledProfile1385;
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_1385MilledProfileVisibility", new Binding("Visible", _screenModel, "Screen_1385MilledProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1385MilledProfile", new Binding("Value", _screenModel, "Screen_1385MilledProfile", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1385MilledProfileQty", new Binding("Value", _screenModel, "Screen_1385MilledProfileQty", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
