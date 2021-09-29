using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_RotolinePropertyUCPresenter : IPP_RotolinePropertyUCPresenter, IPresenterCommon
    {
        IPP_RotolinePropertyUC _pp_rotolinePropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_RotolinePropertyUCPresenter(IPP_RotolinePropertyUC pp_rotolinePropertyUC)
        {
            _pp_rotolinePropertyUC = pp_rotolinePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_rotolinePropertyUC.PPRotolinePropertyLoadEventRaised += _pp_rotolinePropertyUC_PPRotolinePropertyLoadEventRaised;
            _pp_rotolinePropertyUC.cmbRotolineArtNoSelectedValueChangedEventRaised += _pp_rotolinePropertyUC_cmbRotolineArtNoSelectedValueChangedEventRaised;
        }

        private void _pp_rotolinePropertyUC_cmbRotolineArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_RotolineArtNo = (Rotoline_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_rotolinePropertyUC_PPRotolinePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_rotolinePropertyUC.ThisBinding(CreateBindingDictionary());
            _panelModel.Panel_RotolineArtNo = Rotoline_HandleArtNo._K070A21725;
            _initialLoad = false;
        }

        public IPP_RotolinePropertyUC GetRotolinePropertyUC()
        {
            return _pp_rotolinePropertyUC;
        }

        public IPP_RotolinePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_RotolinePropertyUC, PP_RotolinePropertyUC>()
                .RegisterType<IPP_RotolinePropertyUCPresenter, PP_RotolinePropertyUCPresenter>();
            PP_RotolinePropertyUCPresenter presenter = unityC.Resolve<PP_RotolinePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_RotolineArtNo", new Binding("Text", _panelModel, "Panel_RotolineArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotolineOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RotolineOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
