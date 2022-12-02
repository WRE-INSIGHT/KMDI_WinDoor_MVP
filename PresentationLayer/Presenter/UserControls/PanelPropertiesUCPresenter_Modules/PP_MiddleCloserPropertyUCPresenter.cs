using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_MiddleCloserPropertyUCPresenter : IPP_MiddleCloserPropertyUCPresenter
    {
        IPP_MiddleCloserPropertyUC _pp_middleCloserPropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;


        bool _initialLoad = true;
        public PP_MiddleCloserPropertyUCPresenter(IPP_MiddleCloserPropertyUC pp_middleCloserPropertyUC)
        {
            _pp_middleCloserPropertyUC = pp_middleCloserPropertyUC;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_middleCloserPropertyUC.MiddleCloserPropertyUCLoadEventRaised += _pp_middleCloserPropertyUC_MiddleCloserPropertyUCLoadEventRaised;
            _pp_middleCloserPropertyUC.CmbMiddleCLoserSelectedValueChangedEventRaised += _pp_middleCloserPropertyUC_CmbMiddleCLoserSelectedValueChangedEventRaised;
            _pp_middleCloserPropertyUC.numMCPairQtyValueChangedEventRaised += _pp_middleCloserPropertyUC_numMCPairQtyValueChangedEventRaised;
        }

        private void _pp_middleCloserPropertyUC_numMCPairQtyValueChangedEventRaised(object sender, EventArgs e)
        {
            //_mainPresenter.GetCurrentPrice();
        }

        private void _pp_middleCloserPropertyUC_CmbMiddleCLoserSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmbMC = (ComboBox)sender;
            if (_initialLoad == false)
            {
                MiddleCloser_ArticleNo sel_mc = (MiddleCloser_ArticleNo)cmbMC.SelectedValue;
                _panelModel.Panel_MiddleCloserArtNo = sel_mc;
                if (sel_mc == MiddleCloser_ArticleNo._None)
                {
                    _panelModel.Panel_MiddleCloserPairQty = 0;
                }
                _mainPresenter.GetCurrentPrice();
            }
        }

        private void _pp_middleCloserPropertyUC_MiddleCloserPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_middleCloserPropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_MiddleCloserPropertyUC GetMiddleCloserPropertyUC()
        {
            return _pp_middleCloserPropertyUC;
        }

        public IPP_MiddleCloserPropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_MiddleCloserPropertyUC, PP_MiddleCloserPropertyUC>()
                .RegisterType<IPP_MiddleCloserPropertyUCPresenter, PP_MiddleCloserPropertyUCPresenter>();
            PP_MiddleCloserPropertyUCPresenter MiddleCloserPropertyUCPresenter = unityC.Resolve<PP_MiddleCloserPropertyUCPresenter>();
            MiddleCloserPropertyUCPresenter._panelModel = panelModel;
            MiddleCloserPropertyUCPresenter._unityC = unityC;
            MiddleCloserPropertyUCPresenter._mainPresenter = mainPresenter;

            return MiddleCloserPropertyUCPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_MiddleCloserVisibility", new Binding("Visible", _panelModel, "Panel_MiddleCloserVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserArtNo", new Binding("Text", _panelModel, "Panel_MiddleCloserArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserPairQty", new Binding("Value", _panelModel, "Panel_MiddleCloserPairQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
