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
    public class PP_RotaryPropertyUCPresenter : IPP_RotaryPropertyUCPresenter, IPresenterCommon
    {
        IPP_RotaryPropertyUC _pp_rotaryPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_RotaryPropertyUCPresenter(IPP_RotaryPropertyUC pp_rotaryPropertyUC)
        {
            _pp_rotaryPropertyUC = pp_rotaryPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_rotaryPropertyUC.PPRotaryPropertyLoadEventRaised += _pp_rotaryPropertyUC_PPRotaryPropertyLoadEventRaised;
            _pp_rotaryPropertyUC.cmbRotaryArtNoSelectedValueChangedEventRaised += _pp_rotaryPropertyUC_cmbRotaryArtNoSelectedValueChangedEventRaised;
            _pp_rotaryPropertyUC.cmbLockingKitSelectedValueChangedEventRaised += _pp_rotaryPropertyUC_cmbLockingKitSelectedValueChangedEventRaised;
        }

        private void _pp_rotaryPropertyUC_cmbLockingKitSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_LockingKitArtNo = (LockingKit_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_rotaryPropertyUC_cmbRotaryArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_RotaryArtNo = (Rotary_HandleArtNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_rotaryPropertyUC_PPRotaryPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_rotaryPropertyUC.ThisBinding(CreateBindingDictionary());
            _panelModel.Panel_RotaryArtNo = Rotary_HandleArtNo._T511155KMWSS;
            _initialLoad = false;
        }

        public IPP_RotaryPropertyUC GetPPRotaryPropertyUC()
        {
            return _pp_rotaryPropertyUC;
        }

        public IPP_RotaryPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_RotaryPropertyUC, PP_RotaryPropertyUC>()
                .RegisterType<IPP_RotaryPropertyUCPresenter, PP_RotaryPropertyUCPresenter>();
            PP_RotaryPropertyUCPresenter presenter = unityC.Resolve<PP_RotaryPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_RotaryOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RotaryOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_LockingKitArtNo", new Binding("Text", _panelModel, "Panel_LockingKitArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotaryArtNo", new Binding("Text", _panelModel, "Panel_RotaryArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
