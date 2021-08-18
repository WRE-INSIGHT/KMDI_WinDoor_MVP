using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_NTCenterHingePropertyUCPresenter : IPP_NTCenterHingePropertyUCPresenter
    {
        IPP_NTCenterHingePropertyUC _pp_NTCenterHingePropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;
        public PP_NTCenterHingePropertyUCPresenter(IPP_NTCenterHingePropertyUC pp_NTCenterHingePropertyUC)
        {
            _pp_NTCenterHingePropertyUC = pp_NTCenterHingePropertyUC;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_NTCenterHingePropertyUC.NTCenterHingePropertyUCLoadEventRaised += _pp_NTCenterHingePropertyUC_NTCenterHingePropertyUCLoadEventRaised;
            _pp_NTCenterHingePropertyUC.CmbNTCenterHingeSelectedValueChangedEventRaised += _pp_NTCenterHingePropertyUC_CmbNTCenterHingeSelectedValueChangedEventRaised;
        }

        private void _pp_NTCenterHingePropertyUC_CmbNTCenterHingeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmbNTCenterHinge = (ComboBox)sender;
            if (_initialLoad == false)
            {
                _panelModel.Panel_NTCenterHingeArticleNo = (NTCenterHinge_ArticleNo)cmbNTCenterHinge.SelectedValue;
            }
        }

        private void _pp_NTCenterHingePropertyUC_NTCenterHingePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_NTCenterHingePropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_NTCenterHingePropertyUC GetNTCenterHingePropertyUC()
        {
            return _pp_NTCenterHingePropertyUC;
        }

        public IPP_NTCenterHingePropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC)
        {
            unityC
                 .RegisterType<IPP_NTCenterHingePropertyUC, PP_NTCenterHingePropertyUC>()
                 .RegisterType<IPP_NTCenterHingePropertyUCPresenter, PP_NTCenterHingePropertyUCPresenter>();
            PP_NTCenterHingePropertyUCPresenter NTCenterHingePropertyUCPresenter = unityC.Resolve<PP_NTCenterHingePropertyUCPresenter>();
            NTCenterHingePropertyUCPresenter._panelModel = panelModel;
            NTCenterHingePropertyUCPresenter._unityC = unityC;


            return NTCenterHingePropertyUCPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_NTCenterHingeVisibility", new Binding("Visible", _panelModel, "Panel_NTCenterHingeVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_NTCenterHingeArticleNo", new Binding("Text", _panelModel, "Panel_NTCenterHingeArticleNo", true, DataSourceUpdateMode.OnPropertyChanged));


            return binding;
        }
    }
}
