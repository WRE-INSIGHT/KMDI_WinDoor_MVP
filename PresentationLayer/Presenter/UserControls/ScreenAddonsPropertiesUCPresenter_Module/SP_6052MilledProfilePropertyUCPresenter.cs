using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_6052MilledProfilePropertyUCPresenter : ISP_6052MilledProfilePropertyUCPresenter
    {
        ISP_6052MilledProfilePropertyUC _sp_6052MilledProfilePropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public SP_6052MilledProfilePropertyUCPresenter(ISP_6052MilledProfilePropertyUC sp_6052MilledProfilePropertyUC)
        {
            _sp_6052MilledProfilePropertyUC = sp_6052MilledProfilePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sp_6052MilledProfilePropertyUC.SP6052MilledProfilePropertyUCLoadEventRaised += _sp_6052MilledProfilePropertyUC_SP6052MilledProfilePropertyUCLoadEventRaised;
        }

        private void _sp_6052MilledProfilePropertyUC_SP6052MilledProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_6052MilledProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_6052MilledProfilePropertyUC Get6052MilledProfilePropertyUC()
        {
            return _sp_6052MilledProfilePropertyUC;
        }

        public ISP_6052MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                        IMainPresenter mainPresenter,
                                                                        IScreenModel screenModel)
        {
            unityC
                    .RegisterType<ISP_6052MilledProfilePropertyUC, SP_6052MilledProfilePropertyUC>()
                    .RegisterType<ISP_6052MilledProfilePropertyUCPresenter, SP_6052MilledProfilePropertyUCPresenter>();
            SP_6052MilledProfilePropertyUCPresenter milledProfile6052 = unityC.Resolve<SP_6052MilledProfilePropertyUCPresenter>();
            milledProfile6052._unityC = unityC;
            milledProfile6052._mainPresenter = mainPresenter;
            milledProfile6052._screenModel = screenModel;


            return milledProfile6052;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_6052MilledProfileVisibility", new Binding("Visible", _screenModel, "Screen_6052MilledProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6052MilledProfile", new Binding("Value", _screenModel, "Screen_6052MilledProfile", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_6052MilledProfileQty", new Binding("Value", _screenModel, "Screen_6052MilledProfileQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
