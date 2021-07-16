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
    public class PP_SashPropertyUCPresenter : IPP_SashPropertyUCPresenter, IPresenterCommon
    {
        IPP_SashPropertyUC _pp_sashPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        public PP_SashPropertyUCPresenter(IPP_SashPropertyUC pp_sashPropertyUC)
        {
            _pp_sashPropertyUC = pp_sashPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_sashPropertyUC.PPSashPropertyLoadEventRaised += _pp_sashPropertyUC_PPSashPropertyLoadEventRaised;
            _pp_sashPropertyUC.cmbSashProfileSelectedValueEventRaised += _pp_sashPropertyUC_cmbSashProfileSelectedValueEventRaised;
            _pp_sashPropertyUC.cmbSashProfileReinfSelectedValueEventRaised += _pp_sashPropertyUC_cmbSashProfileReinfSelectedValueEventRaised;
        }

        private void _pp_sashPropertyUC_cmbSashProfileReinfSelectedValueEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_SashReinfArtNo = (SashReinf_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_sashPropertyUC_cmbSashProfileSelectedValueEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_SashProfileArtNo = (SashProfile_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_sashPropertyUC_PPSashPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_sashPropertyUC.ThisBinding(CreateBindingDictionary());
        }

        public IPP_SashPropertyUC GetPPSashPropertyUC()
        {
            return _pp_sashPropertyUC;
        }

        public IPP_SashPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_SashPropertyUC, PP_SashPropertyUC>()
                .RegisterType<IPP_SashPropertyUCPresenter, PP_SashPropertyUCPresenter>();
            PP_SashPropertyUCPresenter presenter = unityC.Resolve<PP_SashPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_SashProfileArtNo", new Binding("Text", _panelModel, "Panel_SashProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_SashReinfArtNo", new Binding("Text", _panelModel, "Panel_SashReinfArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
