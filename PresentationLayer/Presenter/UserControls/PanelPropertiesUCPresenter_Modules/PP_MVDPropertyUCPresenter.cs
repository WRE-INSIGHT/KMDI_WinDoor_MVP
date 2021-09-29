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
    public class PP_MVDPropertyUCPresenter : IPP_MVDPropertyUCPresenter, IPresenterCommon
    {
        IPP_MVDPropertyUC _pp_mvdPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_MVDPropertyUCPresenter(IPP_MVDPropertyUC pp_mvdPropertyUC)
        {
            _pp_mvdPropertyUC = pp_mvdPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_mvdPropertyUC.PPMVDPropertyLoadEventRaised += _pp_mvdPropertyUC_PPMVDPropertyLoadEventRaised;
            _pp_mvdPropertyUC.cmbMVDArtNoSelectedValueChangedEventRaised += _pp_mvdPropertyUC_cmbMVDArtNoSelectedValueChangedEventRaised;
        }

        private void _pp_mvdPropertyUC_cmbMVDArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_MVDArtNo = (MVD_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_mvdPropertyUC_PPMVDPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_mvdPropertyUC.ThisBinding(CreateBindingDictionary());
            _panelModel.Panel_MVDArtNo = MVD_HandleArtNo._046366M;
            _initialLoad = false;
        }

        public IPP_MVDPropertyUC GetMVDPropertyUC()
        {
            return _pp_mvdPropertyUC;
        }

        public IPP_MVDPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_MVDPropertyUC, PP_MVDPropertyUC>()
                .RegisterType<IPP_MVDPropertyUCPresenter, PP_MVDPropertyUCPresenter>();
            PP_MVDPropertyUCPresenter presenter = unityC.Resolve<PP_MVDPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_MVDArtNo", new Binding("Text", _panelModel, "Panel_MVDArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MVDOptionsVisibility", new Binding("Visible", _panelModel, "Panel_MVDOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
