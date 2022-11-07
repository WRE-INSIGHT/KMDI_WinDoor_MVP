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
            _LandCoverPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public ISP_LandCoverPropertyUC GetLandCoverPropertyUC()
        {
            return _LandCoverPropertyUC;
        }

        public ISP_LandCoverPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                                          IMainPresenter mainPresenter,
                                                                                          IScreenModel screenModel)
        {
            unityC
                .RegisterType<ISP_LandCoverPropertyUC, SP_LandCoverPropertyUC>()
                .RegisterType<ISP_LandCoverPropertyUCPresenter, SP_LandCoverPropertyUCPresenter>();
            SP_LandCoverPropertyUCPresenter LandCover = unityC.Resolve<SP_LandCoverPropertyUCPresenter>();
            LandCover._unityC = unityC;
            LandCover._mainPresenter = mainPresenter;
            LandCover._screenModel = screenModel;



            return LandCover;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Screen_LandCoverVisibility", new Binding("Visible", _screenModel, "Screen_LandCoverVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_LandCover", new Binding("Value", _screenModel, "Screen_LandCover", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_LandCoverQty", new Binding("Value", _screenModel, "Screen_LandCoverQty", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
