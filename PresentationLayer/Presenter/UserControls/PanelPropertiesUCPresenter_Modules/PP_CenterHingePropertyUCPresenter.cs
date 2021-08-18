using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_CenterHingePropertyUCPresenter : IPP_CenterHingePropertyUCPresenter, IPresenterCommon
    {
        IPP_CenterHingePropertyUC _pp_centerHingePropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_CenterHingePropertyUCPresenter(IPP_CenterHingePropertyUC pp_centerHingePropertyUC)
        {
            _pp_centerHingePropertyUC = pp_centerHingePropertyUC;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_centerHingePropertyUC.CenterHingeSelectedValueChangedEventRaised += _pp_centerHingePropertyUC_CenterHingeSelectedValueChangedEventRaised;
            _pp_centerHingePropertyUC.CenterHingePropertyUCLoadEventRaised += _pp_centerHingePropertyUC_CenterHingePropertyUCLoadEventRaised;
        }

        private void _pp_centerHingePropertyUC_CenterHingeSelectedValueChangedEventRaised(object sender, System.EventArgs e)
        {
            ComboBox cmbCenterHinge = (ComboBox)sender;
            if (_initialLoad == false)
            {
                _panelModel.Panel_CenterHingeOptions = (CenterHingeOption)cmbCenterHinge.SelectedValue;
            }
        }

        private void _pp_centerHingePropertyUC_CenterHingePropertyUCLoadEventRaised(object sender, System.EventArgs e)
        {
            _pp_centerHingePropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_CenterHingePropertyUC GetCenterHingePropertyUC()
        {
            return _pp_centerHingePropertyUC;
        }

        public IPP_CenterHingePropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC)
        {
            unityC
                .RegisterType<IPP_CenterHingePropertyUC, PP_CenterHingePropertyUC>()
                .RegisterType<IPP_CenterHingePropertyUCPresenter, PP_CenterHingePropertyUCPresenter>();
            PP_CenterHingePropertyUCPresenter CenterHingePropertyUCPresenter = unityC.Resolve<PP_CenterHingePropertyUCPresenter>();
            CenterHingePropertyUCPresenter._unityC = unityC;
            CenterHingePropertyUCPresenter._panelModel = panelModel;

            return CenterHingePropertyUCPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_CenterHingeOptions", new Binding("Text", _panelModel, "Panel_CenterHingeOptions", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HingeOptionsVisibility", new Binding("Visible", _panelModel, "Panel_HingeOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            return binding;
        }



    }
}
