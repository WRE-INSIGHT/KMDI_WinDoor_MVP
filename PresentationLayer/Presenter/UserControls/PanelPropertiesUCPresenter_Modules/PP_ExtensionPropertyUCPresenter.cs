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

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_ExtensionPropertyUCPresenter : IPP_ExtensionPropertyUCPresenter, IPresenterCommon
    {
        IPP_ExtensionPropertyUC _pp_extensionUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        public PP_ExtensionPropertyUCPresenter(IPP_ExtensionPropertyUC pp_extensionUC)
        {
            _pp_extensionUC = pp_extensionUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_extensionUC.PPExtensionUCLoadEventRaised += _pp_extensionUC_PPExtensionUCLoadEventRaised;
        }

        private void _pp_extensionUC_PPExtensionUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_extensionUC.ThisBinding(CreateBindingDictionary());
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_ExtTopQty", new Binding("Value", _panelModel, "Panel_ExtTopQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public IPP_ExtensionPropertyUC GetPPExtensionUC()
        {
            return _pp_extensionUC;
        }

        public IPP_ExtensionPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_ExtensionPropertyUC, PP_ExtensionPropertyUC>()
                .RegisterType<IPP_ExtensionPropertyUCPresenter, PP_ExtensionPropertyUCPresenter>();
            PP_ExtensionPropertyUCPresenter presenter = unityC.Resolve<PP_ExtensionPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

    }
}
