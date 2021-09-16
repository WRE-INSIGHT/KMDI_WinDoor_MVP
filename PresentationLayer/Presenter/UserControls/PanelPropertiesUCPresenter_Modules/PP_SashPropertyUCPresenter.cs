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

        bool _initialLoad = true;

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
            if (!_initialLoad)
            {
                _panelModel.Panel_SashReinfArtNo = (SashReinf_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        SashProfile_ArticleNo curr_sash;
        private void _pp_sashPropertyUC_cmbSashProfileSelectedValueEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_SashProfileArtNo = (SashProfile_ArticleNo)((ComboBox)sender).SelectedValue;

                SashProfile_ArticleNo sel_sash = (SashProfile_ArticleNo)((ComboBox)sender).SelectedValue;
                if (sel_sash != curr_sash)
                {
                    if (sel_sash == SashProfile_ArticleNo._7581)
                    {
                        _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._R675;

                        if (curr_sash == SashProfile_ArticleNo._395)
                        {
                            _panelModel.Panel_CenterHingeOptionsVisibility = false;
                            _panelModel.AdjustPropertyPanelHeight("minusCenterHinge");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");
                            }

                            if (_panelModel.Panel_NTCenterHingeVisibility == true)
                            {
                                _panelModel.Panel_NTCenterHingeVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minusNTCenterHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                }
                            }
                        }

                        if (_panelModel.Panel_MotorizedOptionVisibility == false)
                        {
                            _panelModel.Panel_HingeOptionsVisibility = true;
                            _panelModel.AdjustPropertyPanelHeight("addHinge");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                            }
                        }
                    }
                    else if (sel_sash == SashProfile_ArticleNo._374)
                    {
                        _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._655;

                        if (curr_sash == SashProfile_ArticleNo._7581)
                        {
                            if (_panelModel.Panel_MotorizedOptionVisibility == false)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                }
                            }
                        }
                        else if (curr_sash == SashProfile_ArticleNo._395)
                        {
                            _panelModel.Panel_CenterHingeOptionsVisibility = false;
                            _panelModel.AdjustPropertyPanelHeight("minusCenterHinge");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");
                            }

                            if (_panelModel.Panel_NTCenterHingeVisibility == true)
                            {
                                _panelModel.Panel_NTCenterHingeVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minusNTCenterHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                }
                            }
                        }
                    }
                    else if(sel_sash == SashProfile_ArticleNo._395)
                    {
                        _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._207;

                        if (curr_sash == SashProfile_ArticleNo._7581)
                        {
                            if (_panelModel.Panel_MotorizedOptionVisibility == false)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                }
                            }
                        }

                        _panelModel.Panel_CenterHingeOptionsVisibility = true;
                        _panelModel.AdjustPropertyPanelHeight("addCenterHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");
                        }

                        if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                        {
                            _panelModel.Panel_NTCenterHingeVisibility = true;
                            _panelModel.AdjustPropertyPanelHeight("addNTCenterHinge");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                            }
                        }
                    }
                    curr_sash = sel_sash;
                }
            }
        }

        private void _pp_sashPropertyUC_PPSashPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_sashPropertyUC.ThisBinding(CreateBindingDictionary());
            curr_sash = SashProfile_ArticleNo._7581;
            _initialLoad = false;
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
            binding.Add("Panel_SashPropertyVisibility", new Binding("Visible", _panelModel, "Panel_SashPropertyVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
