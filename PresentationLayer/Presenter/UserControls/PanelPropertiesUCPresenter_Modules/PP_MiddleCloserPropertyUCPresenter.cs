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
        }

        private void _pp_middleCloserPropertyUC_CmbMiddleCLoserSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmbMC = (ComboBox)sender;
            if (_initialLoad == false)
            {
                _panelModel.Panel_MiddleCloserArtNo = (MiddleCloser_ArticleNo)cmbMC.SelectedValue;
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

        public IPP_MiddleCloserPropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC)
        {
            unityC
                .RegisterType<IPP_MiddleCloserPropertyUC, PP_MiddleCloserPropertyUC>()
                .RegisterType<IPP_MiddleCloserPropertyUCPresenter, PP_MiddleCloserPropertyUCPresenter>();
            PP_MiddleCloserPropertyUCPresenter MiddleCloserPropertyUCPresenter = unityC.Resolve<PP_MiddleCloserPropertyUCPresenter>();
            MiddleCloserPropertyUCPresenter._panelModel = panelModel;
            MiddleCloserPropertyUCPresenter._unityC = unityC;
            return MiddleCloserPropertyUCPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_MiddleCloserVisibilitys", new Binding("Visible", _panelModel, "Panel_MiddleCloserVisibilitys", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserArtNo", new Binding("Text", _panelModel, "Panel_MiddleCloserArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
