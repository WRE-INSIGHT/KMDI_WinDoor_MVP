using CommonComponents;
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
    public class PP_RioPropertyUCPresenter : IPP_RioPropertyUCPresenter, IPresenterCommon
    {
        IPP_RioPropertyUC _pp_rioPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_RioPropertyUCPresenter(IPP_RioPropertyUC pp_rioPropertyUC)
        {
            _pp_rioPropertyUC = pp_rioPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_rioPropertyUC.PPRioPropertyLoadEventRaised += _pp_rioPropertyUC_PPRioPropertyLoadEventRaised;
            _pp_rioPropertyUC.cmbRioArtNoSelectedValueChangedEventRaised += _pp_rioPropertyUC_cmbRioArtNoSelectedValueChangedEventRaised;
        }

        private void _pp_rioPropertyUC_cmbRioArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_RioArtNo = (Rio_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_rioPropertyUC_PPRioPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_rioPropertyUC.ThisBinding(CreateBindingDictionary());
            _panelModel.Panel_RioArtNo = Rio_HandleArtNo._C050C108019;
            _initialLoad = false;
        }

        public IPP_RioPropertyUC GetRioPropertyUC()
        {
            return _pp_rioPropertyUC;
        }

        public IPP_RioPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_RioPropertyUC, PP_RioPropertyUC>()
                .RegisterType<IPP_RioPropertyUCPresenter, PP_RioPropertyUCPresenter>();
            PP_RioPropertyUCPresenter presenter = unityC.Resolve<PP_RioPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_RioArtNo", new Binding("Text", _panelModel, "Panel_RioArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RioOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RioOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
