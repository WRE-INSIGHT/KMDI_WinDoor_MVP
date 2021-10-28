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
    public class PP_3dHingePropertyUCPresenter : IPP_3dHingePropertyUCPresenter, IPresenterCommon
    {
        IPP_3dHingePropertyUC _pp_3DHingePropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_3dHingePropertyUCPresenter(IPP_3dHingePropertyUC pp_3DHingePropertyUC)
        {
            _pp_3DHingePropertyUC = pp_3DHingePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_3DHingePropertyUC.PP3dHingeLoadEventRaised += _pp_3DHingePropertyUC_PP3dHingeLoadEventRaised;
        }

        private void _pp_3DHingePropertyUC_PP3dHingeLoadEventRaised(object sender, EventArgs e)
        {
            _pp_3DHingePropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_3dHingePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                 .RegisterType<IPP_3dHingePropertyUC, PP_3dHingePropertyUC>()
                 .RegisterType<IPP_3dHingePropertyUCPresenter, PP_3dHingePropertyUCPresenter>();
            PP_3dHingePropertyUCPresenter presenter = unityC.Resolve<PP_3dHingePropertyUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._unityC = unityC;

            return presenter;
        }

        public IPP_3dHingePropertyUC GetPP_3dHingePropertyUC()
        {
            return _pp_3DHingePropertyUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_3dHingeQty", new Binding("Value", _panelModel, "Panel_3dHingeQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_3dHingePropertyVisibility", new Binding("Visible", _panelModel, "Panel_3dHingePropertyVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
