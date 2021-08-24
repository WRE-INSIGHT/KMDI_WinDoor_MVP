using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_HingePropertyUCPresenter : IPP_HingePropertyUCPresenter, IPresenterCommon
    {
        IPP_HingePropertyUC _pp_HingePropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_HingePropertyUCPresenter(IPP_HingePropertyUC pp_HingePropertyUC)
        {
            _pp_HingePropertyUC = pp_HingePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_HingePropertyUC.cmbHingeSelectedValueChangedEventRaised += _pp_HingePropertyUC_cmbHingeSelectedValueChangedEventRaised;
            _pp_HingePropertyUC.PPHingeLoadEventRaised += _pp_HingePropertyUC_PPHingeLoadEventRaised;
        }

        private void _pp_HingePropertyUC_PPHingeLoadEventRaised(object sender, EventArgs e)
        {
            _pp_HingePropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        private void _pp_HingePropertyUC_cmbHingeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmbHinge = (ComboBox)sender;
            if (_initialLoad == false)
            {
                _panelModel.Panel_HingeOptions = (HingeOption)cmbHinge.SelectedValue;
            }
        }

        public IPP_HingePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                 .RegisterType<IPP_HingePropertyUCPresenter, PP_HingePropertyUCPresenter>()
                 .RegisterType<IPP_HingePropertyUC, IPP_HingePropertyUC>();
            PP_HingePropertyUCPresenter HingePropertyUCPresenter = unityC.Resolve<PP_HingePropertyUCPresenter>();
            HingePropertyUCPresenter._panelModel = panelModel;
            HingePropertyUCPresenter._unityC = unityC;

            return HingePropertyUCPresenter;
        }

        public IPP_HingePropertyUC GetPP_HingePropertyUC()
        {
            return _pp_HingePropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_HingeOptions", new Binding("Text", _panelModel, "Panel_HingeOptions", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HingeOptionsVisibility", new Binding("Visible", _panelModel, "Panel_HingeOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

    }
}
