using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_LouverBladesPropertyUCPresenter : IPP_LouverBladesPropertyUCPresenter
    {
        IPP_LouverBladesPropertyUC _pp_LouverBladesPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        public PP_LouverBladesPropertyUCPresenter(IPP_LouverBladesPropertyUC pp_LouverBladesPropertyUC)
        {
            _pp_LouverBladesPropertyUC = pp_LouverBladesPropertyUC;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_LouverBladesPropertyUC.PPLouverBladesPropertyUCLoadEventRaised += _pp_LouverBladesPropertyUC_PPLouverBladesPropertyUCLoadEventRaised;
        }

        private void _pp_LouverBladesPropertyUC_PPLouverBladesPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _panelModel.Set_LouverBladesCount();
            _pp_LouverBladesPropertyUC.GetNudLouverBlades().Value = _panelModel.Panel_LouverBladesCount;
            _pp_LouverBladesPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_LouverBladesPropertyUC GetIPP_LouverBladesPropertyUC()
        {
            return _pp_LouverBladesPropertyUC;
        }

        public IPP_LouverBladesPropertyUCPresenter CreateNewInstance(IUnityContainer unityC,
                                                                     IPanelModel panelModel)
        {
            unityC
                   .RegisterType<IPP_LouverBladesPropertyUC, PP_LouverBladesPropertyUC>()
                   .RegisterType<IPP_LouverBladesPropertyUCPresenter, PP_LouverBladesPropertyUCPresenter>();
            PP_LouverBladesPropertyUCPresenter blade = unityC.Resolve<PP_LouverBladesPropertyUCPresenter>();
            blade._panelModel = panelModel;
            blade._unityC = unityC;

            return blade;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_LouverBladesVisibility", new Binding("Visible", _panelModel, "Panel_LouverBladesVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LouverBladesCount", new Binding("Value", _panelModel, "Panel_LouverBladesCount", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
