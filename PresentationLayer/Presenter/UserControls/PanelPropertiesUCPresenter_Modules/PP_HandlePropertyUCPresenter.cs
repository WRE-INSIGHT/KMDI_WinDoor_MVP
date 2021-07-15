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
    public class PP_HandlePropertyUCPresenter : IPP_HandlePropertyUCPresenter, IPresenterCommon
    {
        IPP_HandlePropertyUC _pp_handlePropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        public PP_HandlePropertyUCPresenter(IPP_HandlePropertyUC pp_handlePropertyUC)
        {
            _pp_handlePropertyUC = pp_handlePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_handlePropertyUC.PPHandlePropertyLoadEventRaised += _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised;
            _pp_handlePropertyUC.cmbHandleTypeSelectedValueEventRaised += _pp_handlePropertyUC_cmbHandleTypeSelectedValueEventRaised;
        }

        Handle_Type curr_handleType;
        private void _pp_handlePropertyUC_cmbHandleTypeSelectedValueEventRaised(object sender, EventArgs e)
        {
            Handle_Type sel_handleType = (Handle_Type)((ComboBox)sender).SelectedValue;
            if (curr_handleType != sel_handleType)
            {
                _panelModel.Panel_HandleType = sel_handleType;
                curr_handleType = sel_handleType;
            }
        }

        private void _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_handlePropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_HandlePropertyUC GetPPHandlePropertyUC()
        {
            return _pp_handlePropertyUC;
        }

        public IPP_HandlePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_HandlePropertyUC, PP_HandlePropertyUC>()
                .RegisterType<IPP_HandlePropertyUCPresenter, PP_HandlePropertyUCPresenter>();
            PP_HandlePropertyUCPresenter presenter = unityC.Resolve<PP_HandlePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_HandleType", new Binding("Text", _panelModel, "Panel_HandleType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HandleOptionsVisibility", new Binding("Visible", _panelModel, "Panel_HandleOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
