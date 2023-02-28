using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_373or374MilledProfilePropertyUCPresenter : ISP_373or374MilledProfilePropertyUCPresenter
    {
        ISP_373or374MilledProfilePropertyUC _sp_373or374MilledProfilePropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        public SP_373or374MilledProfilePropertyUCPresenter(ISP_373or374MilledProfilePropertyUC sp_373or374MilledProfilePropertyUC)
        {
            _sp_373or374MilledProfilePropertyUC = sp_373or374MilledProfilePropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sp_373or374MilledProfilePropertyUC.SP373or374MilledProfilePropertyUCLoadEventRaised += _sp_373or374MilledProfilePropertyUC_SP373or374MilledProfilePropertyUCLoadEventRaised;
        }

        private void _sp_373or374MilledProfilePropertyUC_SP373or374MilledProfilePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_373or374MilledProfilePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_373or374MilledProfilePropertyUC Get373or374MilledProfilePropertyUC()
        {
            return _sp_373or374MilledProfilePropertyUC;
        }

        public ISP_373or374MilledProfilePropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                              IMainPresenter mainPresenter,
                                                                              IScreenModel screenModel)
        {
            unityC
                    .RegisterType<ISP_373or374MilledProfilePropertyUC, SP_373or374MilledProfilePropertyUC>()
                    .RegisterType<ISP_373or374MilledProfilePropertyUCPresenter, SP_373or374MilledProfilePropertyUCPresenter>();
            SP_373or374MilledProfilePropertyUCPresenter milledProfile373or374 = unityC.Resolve<SP_373or374MilledProfilePropertyUCPresenter>();
            milledProfile373or374._unityC = unityC;
            milledProfile373or374._mainPresenter = mainPresenter;
            milledProfile373or374._screenModel = screenModel;


            return milledProfile373or374;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_373or374MilledProfileVisibility", new Binding("Visible", _screenModel, "Screen_373or374MilledProfileVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_373or374MilledProfile", new Binding("Value", _screenModel, "Screen_373or374MilledProfile", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_373or374MilledProfileQty", new Binding("Value", _screenModel, "Screen_373or374MilledProfileQty", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
