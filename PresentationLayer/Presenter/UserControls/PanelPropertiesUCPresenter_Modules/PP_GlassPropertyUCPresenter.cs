using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
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
        private ISetMultipleGlassThicknessPresenter _setMultipleGlassThicknessPresenter;
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
            _pp_glassPropertyUC.chkGlazingAdaptorCheckedChangedEventRaised += _pp_glassPropertyUC_chkGlazingAdaptorCheckedChangedEventRaised;
        }

        private void _pp_glassPropertyUC_chkGlazingAdaptorCheckedChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_ChkGlazingAdaptor = ((CheckBox)sender).Checked;
            _mainPresenter.GetCurrentPrice();
        }

        private void _pp_glassPropertyUC_btnSelectGlassThicknessClickedEventRaised(object sender, EventArgs e)
        {
            IGlassThicknessListPresenter glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance(_unityC, _mainPresenter.GlassThicknessDT, _panelModel, _mainPresenter);
            glassThicknessPresenter.ShowGlassThicknessListView();
        }

        private void _pp_glassPropertyUC_cmbFilmTypeSelectedValueEventRaised(object sender, EventArgs e)
        {
            //if (!_initialLoad)
            //{
            //    _panelModel.Panel_GlassFilm = (GlassFilm_Types)((ComboBox)sender).SelectedValue;
            //    _mainPresenter.itemDescription();
            //    _mainPresenter.GetCurrentPrice();
            //}

            if (_mainPresenter.ItemLoad == false)
            {
                _panelModel.Panel_GlassFilm = (GlassFilm_Types)((ComboBox)sender).SelectedValue;
                _mainPresenter.itemDescription();
                _mainPresenter.GetCurrentPrice();
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
            //if (!_initialLoad)
            //{
            //    _panelModel.PanelGlazingBead_ArtNo = (GlazingBead_ArticleNo)((ComboBox)sender).SelectedValue;
            //    _mainPresenter.GetCurrentPrice();
            //}

            if (_mainPresenter.ItemLoad == false)
            {
                _panelModel.PanelGlazingBead_ArtNo = (GlazingBead_ArticleNo)((ComboBox)sender).SelectedValue;
                _mainPresenter.GetCurrentPrice();
            }
        }

        private void _pp_glassPropertyUC_PPGlassPropertyLoadEventRaised(object sender, EventArgs e)
        {

            if (_panelModel.Panel_GlassThickness == 0)
            {
                if (_panelModel.Panel_GlassThicknessDesc == "Unglazed")
                {
                    _panelModel.Panel_GlassThicknessDesc = "Unglazed";
                }
                else if (_panelModel.Panel_GlassThicknessDesc == "Security Mesh")
                {
                    _panelModel.Panel_GlassThicknessDesc = "Security Mesh";
                }
                else
                {
                    _panelModel.Panel_GlassThickness = 6;
                    _panelModel.Panel_GlassThicknessDesc = "6 mm Clear";
                    _panelModel.Panel_GlassType_Insu_Lami = "NA";
                }
            }


            _pp_glassPropertyUC.ThisBinding(CreateBindingDictionary());
            _panelModel.Panel_GlazingAdaptorArtNo = GlazingAdaptor_ArticleNo._6418;

            _initialLoad = false;
        }

        public void BringToFrontUC()
        {
            ((UserControl)_pp_glassPropertyUC).BringToFront();
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
            binding.Add("Panel_GlassPropertyHeight", new Binding("Height", _panelModel, "Panel_GlassPropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ChkGlazingAdaptor", new Binding("Checked", _panelModel, "Panel_ChkGlazingAdaptor", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GlassPnlGlazingBeadVisibility", new Binding("Visible", _panelModel, "Panel_GlassPnlGlazingBeadVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_GlassPnlGlazingAdaptorVisibility", new Binding("Visible", _panelModel, "Panel_GlassPnlGlazingAdaptorVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
