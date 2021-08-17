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
    public class PP_EspagnolettePropertyUCPresenter : IPP_EspagnolettePropertyUCPresenter, IPresenterCommon
    {
        IPP_EspagnolettePropertyUC _pp_espagnolettePropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_EspagnolettePropertyUCPresenter(IPP_EspagnolettePropertyUC pp_espagnolettePropertyUC)
        {
            _pp_espagnolettePropertyUC = pp_espagnolettePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_espagnolettePropertyUC.PPEspagnolettePropertyLoadEventRaised += _pp_espagnolettePropertyUC_PPEspagnolettePropertyLoadEventRaised;
            _pp_espagnolettePropertyUC.cmbEspagnoletteSelectedValueEventRaised += _pp_espagnolettePropertyUC_cmbEspagnoletteSelectedValueEventRaised;
        }

        private void _pp_espagnolettePropertyUC_cmbEspagnoletteSelectedValueEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_EspagnoletteArtNo = (Espagnolette_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_espagnolettePropertyUC_PPEspagnolettePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_espagnolettePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_EspagnolettePropertyUC GetPPEspagnolettePropertyUC()
        {
            return _pp_espagnolettePropertyUC;
        }

        public IPP_EspagnolettePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_EspagnolettePropertyUC, PP_EspagnolettePropertyUC>()
                .RegisterType<IPP_EspagnolettePropertyUCPresenter, PP_EspagnolettePropertyUCPresenter>();
            PP_EspagnolettePropertyUCPresenter presenter = unityC.Resolve<PP_EspagnolettePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_EspagnoletteOptionsVisibility", new Binding("Visible", _panelModel, "Panel_EspagnoletteOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_EspagnoletteArtNo", new Binding("Text", _panelModel, "Panel_EspagnoletteArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
