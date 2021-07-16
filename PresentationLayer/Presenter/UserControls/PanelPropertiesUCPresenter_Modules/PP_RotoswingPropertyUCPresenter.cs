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
    public class PP_RotoswingPropertyUCPresenter : IPP_RotoswingPropertyUCPresenter, IPresenterCommon
    {
        IPP_RotoswingPropertyUC _pp_rotoswingPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        private IPP_ExtensionPropertyUCPresenter _pp_extensionPropertyUCPresenter;

        FlowLayoutPanel _flpRotoswingOptions;

        public PP_RotoswingPropertyUCPresenter(IPP_RotoswingPropertyUC pp_rotoswingPropertyUC,
                                               IPP_ExtensionPropertyUCPresenter pp_extensionPropertyUCPresenter)
        {
            _pp_rotoswingPropertyUC = pp_rotoswingPropertyUC;
            _pp_extensionPropertyUCPresenter = pp_extensionPropertyUCPresenter;
            _flpRotoswingOptions = _pp_rotoswingPropertyUC.GetRotoswingOptionFLP();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_rotoswingPropertyUC.PPRotoswingPropertyLoadEventRaised += _pp_rotoswingPropertyUC_PPRotoswingPropertyLoadEventRaised;
            _pp_rotoswingPropertyUC.cmbEspagnoletteSelectedValueEventRaised += _pp_rotoswingPropertyUC_cmbEspagnoletteSelectedValueEventRaised;
            _pp_rotoswingPropertyUC.cmbMiddleCloserSelectedValueEventRaised += _pp_rotoswingPropertyUC_cmbMiddleCloserSelectedValueEventRaised;
            _pp_rotoswingPropertyUC.cmbRotoswingNoSelectedValueEventRaised += _pp_rotoswingPropertyUC_cmbRotoswingNoSelectedValueEventRaised;
            _pp_rotoswingPropertyUC.cmbStrikerSelectedValueEventRaised += _pp_rotoswingPropertyUC_cmbStrikerSelectedValueEventRaised;
        }

        private void _pp_rotoswingPropertyUC_cmbStrikerSelectedValueEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_StrikerArtno = (Striker_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_rotoswingPropertyUC_cmbRotoswingNoSelectedValueEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_RotoswingArtNo = (Rotoswing_HandleArtNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_rotoswingPropertyUC_cmbMiddleCloserSelectedValueEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_MiddleCloserArtNo = (MiddleCloser_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_rotoswingPropertyUC_cmbEspagnoletteSelectedValueEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_EspagnoletteArtNo = (Espagnolette_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _pp_rotoswingPropertyUC_PPRotoswingPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_rotoswingPropertyUC.ThisBinding(CreateBindingDictionary());

            if (_panelModel.Panel_Height >= 2100)
            {
                IPP_ExtensionPropertyUCPresenter extPropUCP = _pp_extensionPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                _flpRotoswingOptions.Controls.Add((UserControl)extPropUCP.GetPPExtensionUC());

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                _panelModel.AdjustPropertyPanelHeight("addExtension");
                _panelModel.AdjustHandlePropertyHeight("addExtension");
                _panelModel.AdjustRotoswingPropertyHeight("addExtension");
            }
        }

        public IPP_RotoswingPropertyUC GetPPRotoswingPropertyUC()
        {
            return _pp_rotoswingPropertyUC;
        }

        public IPP_RotoswingPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_RotoswingPropertyUC, PP_RotoswingPropertyUC>()
                .RegisterType<IPP_RotoswingPropertyUCPresenter, PP_RotoswingPropertyUCPresenter>();
            PP_RotoswingPropertyUCPresenter presenter = unityC.Resolve<PP_RotoswingPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_RotoswingOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RotoswingOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotoswingOptionsHeight", new Binding("Height", _panelModel, "Panel_RotoswingOptionsHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_EspagnoletteArtNo", new Binding("Text", _panelModel, "Panel_EspagnoletteArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_StrikerArtno", new Binding("Text", _panelModel, "Panel_StrikerArtno", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserArtNo", new Binding("Text", _panelModel, "Panel_MiddleCloserArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_RotoswingArtNo", new Binding("Text", _panelModel, "Panel_RotoswingArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
