using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views.UserControls.ScreenAddOns_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module
{
    public class SP_PVCboxPropertyUCPresenter : ISP_PVCboxPropertyUCPresenter
    {
        ISP_PVCboxPropertyUC _sp_pVCboxPropertyUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;


        public SP_PVCboxPropertyUCPresenter(ISP_PVCboxPropertyUC sp_pVCboxPropertyUC)
        {
            _sp_pVCboxPropertyUC = sp_pVCboxPropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sp_pVCboxPropertyUC.SPPVCboxPropertyUCLoadEventRaised += _sp_pVCboxPropertyUC_SPPVCboxPropertyUCLoadEventRaised;
        }

        private void _sp_pVCboxPropertyUC_SPPVCboxPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _sp_pVCboxPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_PVCboxPropertyUC GetPVCboxPropertyUC()
        {
            return _sp_pVCboxPropertyUC;
        }

        public ISP_PVCboxPropertyUCPresenter CreatenewInstance(IUnityContainer unityC,
                                                               IMainPresenter mainPresenter,
                                                               IScreenModel screenModel)
        {
            unityC
                    .RegisterType<ISP_PVCboxPropertyUC, SP_PVCboxPropertyUC>()
                    .RegisterType<ISP_PVCboxPropertyUCPresenter, SP_PVCboxPropertyUCPresenter>();
            SP_PVCboxPropertyUCPresenter PVCbox = unityC.Resolve<SP_PVCboxPropertyUCPresenter>();
            PVCbox._unityC = unityC;
            PVCbox._mainPresenter = mainPresenter;
            PVCbox._screenModel = screenModel;

            return PVCbox;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_PVCVisibility", new Binding("Visible", _screenModel, "Screen_PVCVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_0505Width", new Binding("Value", _screenModel, "Screen_0505Width", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1067Height", new Binding("Value", _screenModel, "Screen_1067Height", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_0505Qty", new Binding("Value", _screenModel, "Screen_0505Qty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_1067Qty", new Binding("Value", _screenModel, "Screen_1067Qty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }


    }
}
