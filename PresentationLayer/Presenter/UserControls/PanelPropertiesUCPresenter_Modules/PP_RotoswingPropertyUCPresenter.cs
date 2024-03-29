﻿using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_RotoswingPropertyUCPresenter : IPP_RotoswingPropertyUCPresenter, IPresenterCommon
    {
        IPP_RotoswingPropertyUC _pp_rotoswingPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        Panel _pnlRotoswingOptions;

        bool _initialLoad = true;

        public PP_RotoswingPropertyUCPresenter(IPP_RotoswingPropertyUC pp_rotoswingPropertyUC)
        {
            _pp_rotoswingPropertyUC = pp_rotoswingPropertyUC;
            _pnlRotoswingOptions = _pp_rotoswingPropertyUC.GetRotoswingOptionPNL();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_rotoswingPropertyUC.PPRotoswingPropertyLoadEventRaised += _pp_rotoswingPropertyUC_PPRotoswingPropertyLoadEventRaised;
            _pp_rotoswingPropertyUC.cmbRotoswingNoSelectedValueEventRaised += _pp_rotoswingPropertyUC_cmbRotoswingNoSelectedValueEventRaised;
        }

        private void _pp_rotoswingPropertyUC_cmbRotoswingNoSelectedValueEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_RotoswingArtNo = (Rotoswing_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_rotoswingPropertyUC_PPRotoswingPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_rotoswingPropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_RotoswingPropertyUC GetPPRotoswingPropertyUC()
        {
            return _pp_rotoswingPropertyUC;
        }

        public IPP_RotoswingPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_RotoswingPropertyUC, PP_RotoswingPropertyUC>()
                .RegisterType<IPP_RotoswingPropertyUCPresenter, PP_RotoswingPropertyUCPresenter>();
            PP_RotoswingPropertyUCPresenter presenter = unityC.Resolve<PP_RotoswingPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_RotoswingOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RotoswingOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotoswingOptionsHeight", new Binding("Height", _panelModel, "Panel_RotoswingOptionsHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_EspagnoletteArtNo", new Binding("Text", _panelModel, "Panel_EspagnoletteArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserArtNo", new Binding("Text", _panelModel, "Panel_MiddleCloserArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotoswingArtNo", new Binding("Text", _panelModel, "Panel_RotoswingArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
