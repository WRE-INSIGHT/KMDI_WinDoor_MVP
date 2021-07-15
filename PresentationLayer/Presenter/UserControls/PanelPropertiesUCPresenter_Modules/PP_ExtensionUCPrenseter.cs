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
    public class PP_ExtensionUCPrenseter : IPP_ExtensionUCPrenseter, IPresenterCommon
    {
        IPP_ExtensionUC _pp_extensionUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        public PP_ExtensionUCPrenseter(IPP_ExtensionUC pp_extensionUC)
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

        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            return binding;
        }

        public IPP_ExtensionUC GetPPExtensionUC()
        {
            return _pp_extensionUC;
        }

        public IPP_ExtensionUCPrenseter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_ExtensionUC, PP_ExtensionUC>()
                .RegisterType<IPP_ExtensionUCPrenseter, PP_ExtensionUCPrenseter>();
            PP_ExtensionUCPrenseter presenter = unityC.Resolve<PP_ExtensionUCPrenseter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

    }
}
