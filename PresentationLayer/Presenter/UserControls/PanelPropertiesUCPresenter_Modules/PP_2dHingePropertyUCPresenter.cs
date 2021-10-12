﻿using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_2dHingePropertyUCPresenter : IPP_2dHingePropertyUCPresenter, IPresenterCommon
    {
        IPP_2dHingePropertyUC _pp_2dHingePropertUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_2dHingePropertyUCPresenter(IPP_2dHingePropertyUC pp_2dHingePropertUC)
        {
            _pp_2dHingePropertUC = pp_2dHingePropertUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_2dHingePropertUC.PP2dHingeLoadEventRaised += _pp_2dHingePropertUC_PP2dHingeLoadEventRaised;
        }

        private void _pp_2dHingePropertUC_PP2dHingeLoadEventRaised(object sender, EventArgs e)
        {
            _pp_2dHingePropertUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_2dHingePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                 .RegisterType<IPP_2dHingePropertyUC, PP_2dHingePropertyUC>()
                 .RegisterType<IPP_2dHingePropertyUCPresenter, PP_2dHingePropertyUCPresenter>();
            PP_2dHingePropertyUCPresenter presenter = unityC.Resolve<PP_2dHingePropertyUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._unityC = unityC;

            return presenter;
        }

        public IPP_2dHingePropertyUC GetPP_2dHingePropertyUC()
        {
            return _pp_2dHingePropertUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_2DHingeQty_nonMotorized", new Binding("Value", _panelModel, "Panel_2DHingeQty_nonMotorized", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_2dHingeVisibility_nonMotorized", new Binding("Visible", _panelModel, "Panel_2dHingeVisibility_nonMotorized", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}