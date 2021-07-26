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
    public class PP_GlassPropertyUCPresenter : IPP_GlassPropertyUCPresenter, IPresenterCommon
    {
        IPP_GlassPropertyUC _pp_glassPropertyUC;

        private IGlassThicknessListPresenter _glassThicknessPresenter;
        private IMainPresenter _mainPresenter;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_GlassPropertyUCPresenter(IPP_GlassPropertyUC pp_glassPropertyUC,
                                           IGlassThicknessListPresenter glassThicknessPresenter)
        {
            _pp_glassPropertyUC = pp_glassPropertyUC;
            _glassThicknessPresenter = glassThicknessPresenter;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_glassPropertyUC.PPGlassPropertyLoadEventRaised += _pp_glassPropertyUC_PPGlassPropertyLoadEventRaised;
            _pp_glassPropertyUC.cmbGlazingArtNoSelectedValueEventRaised += _pp_glassPropertyUC_cmbGlazingArtNoSelectedValueEventRaised;
            _pp_glassPropertyUC.cmbGlassTypeSelectedValueEventRaised += _pp_glassPropertyUC_cmbGlassTypeSelectedValueEventRaised;
            _pp_glassPropertyUC.cmbFilmTypeSelectedValueEventRaised += _pp_glassPropertyUC_cmbFilmTypeSelectedValueEventRaised;
            _pp_glassPropertyUC.btnSelectGlassThicknessClickedEventRaised += _pp_glassPropertyUC_btnSelectGlassThicknessClickedEventRaised;
        }

        private void _pp_glassPropertyUC_btnSelectGlassThicknessClickedEventRaised(object sender, EventArgs e)
        {
            IGlassThicknessListPresenter glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance(_unityC, _mainPresenter.GlassThicknessDT, _panelModel);
            glassThicknessPresenter.ShowGlassThicknessListView();
        }

        private void _pp_glassPropertyUC_cmbFilmTypeSelectedValueEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_GlassFilm = (GlassFilm_Types)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_glassPropertyUC_cmbGlassTypeSelectedValueEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_GlassType = (GlassType)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_glassPropertyUC_cmbGlazingArtNoSelectedValueEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.PanelGlazingBead_ArtNo = (GlazingBead_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_glassPropertyUC_PPGlassPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_glassPropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_GlassPropertyUC GetPPGlassPropertyUC()
        {
            return _pp_glassPropertyUC;
        }

        public IPP_GlassPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_GlassPropertyUC, PP_GlassPropertyUC>()
                .RegisterType<IPP_GlassPropertyUCPresenter, PP_GlassPropertyUCPresenter>();
            PP_GlassPropertyUCPresenter presenter = unityC.Resolve<PP_GlassPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;
            presenter._mainPresenter = mainPresenter;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_GlassFilm", new Binding("Text", _panelModel, "Panel_GlassFilm", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("PanelGlazingBead_ArtNo", new Binding("Text", _panelModel, "PanelGlazingBead_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GlassType", new Binding("Text", _panelModel, "Panel_GlassType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GlassThicknessDesc", new Binding("Text", _panelModel, "Panel_GlassThicknessDesc", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
