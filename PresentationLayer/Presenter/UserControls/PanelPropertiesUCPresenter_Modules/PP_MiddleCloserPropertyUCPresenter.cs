using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_MiddleCloserPropertyUCPresenter : IPP_MiddleCloserPropertyUCPresenter
    {
        IPP_MiddleCloserPropertyUC _pp_middleCloserPropertyUC;
        private IPanelModel _panelModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;


        bool _initialLoad = true;
        public PP_MiddleCloserPropertyUCPresenter(IPP_MiddleCloserPropertyUC pp_middleCloserPropertyUC)
        {
            _pp_middleCloserPropertyUC = pp_middleCloserPropertyUC;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pp_middleCloserPropertyUC.MiddleCloserPropertyUCLoadEventRaised += _pp_middleCloserPropertyUC_MiddleCloserPropertyUCLoadEventRaised;
            _pp_middleCloserPropertyUC.CmbMiddleCLoserSelectedValueChangedEventRaised += _pp_middleCloserPropertyUC_CmbMiddleCLoserSelectedValueChangedEventRaised;
            _pp_middleCloserPropertyUC.MCPairQtyValueChangedEventRaised += _pp_middleCloserPropertyUC_MCPairQtyValueChangedEventRaised;
        }

        private void _pp_middleCloserPropertyUC_MCPairQtyValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numMC = (NumericUpDown)sender;
            _panelModel.Panel_MiddleCloserPairQty = (int)numMC.Value;
            _mainPresenter.GetCurrentPrice();

        }
        private void _pp_middleCloserPropertyUC_CmbMiddleCLoserSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmbMC = (ComboBox)sender;
            if (_initialLoad == false)
            {
                MiddleCloser_ArticleNo sel_mc = (MiddleCloser_ArticleNo)cmbMC.SelectedValue;
                _panelModel.Panel_MiddleCloserArtNo = sel_mc;
                if (sel_mc == MiddleCloser_ArticleNo._None)
                {
                    _panelModel.Panel_MiddleCloserPairQty = 0;
                }
                _mainPresenter.GetCurrentPrice();
            }
        }

        private void _pp_middleCloserPropertyUC_MiddleCloserPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            if (!_panelModel.PanelModelIsFromLoad)
            {
                if (_mainPresenter.wndrFileName != null)
                {
                    Base_Color base_color = _panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor;
                    if (base_color == Base_Color._DarkBrown)
                    {
                        if (_panelModel.Panel_Type.Contains("Awning"))
                        {
                            if (_panelModel.Panel_DisplayHeight < 1551)
                            {
                                _panelModel.Panel_MiddleCloserPairQty = 1;
                            }
                            else if (_panelModel.Panel_DisplayHeight > 1551 && _panelModel.Panel_DisplayHeight < 1999)
                            {
                                _panelModel.Panel_MiddleCloserPairQty = 2;
                            }
                            else if (_panelModel.Panel_DisplayHeight > 1999)
                            {
                                _panelModel.Panel_MiddleCloserPairQty = 3;
                            }
                        }
                        else if (_panelModel.Panel_Type.Contains("Casement"))
                        {
                            if (_panelModel.Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                            {
                                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                {
                                    _panelModel.Panel_MiddleCloserPairQty = 1;
                                }
                                else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                         _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                {
                                    _panelModel.Panel_MiddleCloserPairQty = 0;
                                }
                                else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                {
                                    if (_panelModel.Panel_SashHeight < 1201)
                                    {
                                        _panelModel.Panel_MiddleCloserPairQty = 1;
                                    }
                                    else if (_panelModel.Panel_SashHeight > 1200)
                                    {
                                        _panelModel.Panel_MiddleCloserPairQty = 0;
                                    }
                                }
                            }
                            else if (_panelModel.Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || _panelModel.Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                            {
                                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                {
                                    _panelModel.Panel_MiddleCloserPairQty = 1;
                                }
                            }
                        }
                    }
                    else if (base_color == Base_Color._White ||
                             base_color == Base_Color._Ivory)
                    {
                        if (_panelModel.Panel_Type.Contains("Awning"))
                        {
                            if (_panelModel.Panel_SashHeight < 1551)
                            {
                                _panelModel.Panel_MiddleCloserPairQty = 1;
                            }
                            else if (_panelModel.Panel_SashHeight > 1551 && _panelModel.Panel_SashHeight < 1999)
                            {
                                _panelModel.Panel_MiddleCloserPairQty = 2;
                            }
                            else if (_panelModel.Panel_SashHeight > 1999)
                            {
                                _panelModel.Panel_MiddleCloserPairQty = 3;
                            }
                        }
                        else if (_panelModel.Panel_Type.Contains("Casement"))
                        {
                            if (_panelModel.Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                            {
                                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                                {
                                    _panelModel.Panel_MiddleCloserPairQty = 1;
                                }
                                else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                                         _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
                                {
                                    _panelModel.Panel_MiddleCloserPairQty = 0;
                                }
                                else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                                {
                                    if (_panelModel.Panel_SashHeight < 1201)
                                    {
                                        _panelModel.Panel_MiddleCloserPairQty = 1;
                                    }
                                    else if (_panelModel.Panel_SashHeight > 1200)
                                    {
                                        _panelModel.Panel_MiddleCloserPairQty = 0;
                                    }
                                }
                            }
                            else if (_panelModel.Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._7502 || _panelModel.Panel_ParentFrameModel.Frame_ArtNo == FrameProfile_ArticleNo._2060)
                            {
                                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 || _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._2067)
                                {
                                    _panelModel.Panel_MiddleCloserPairQty = 1;
                                }
                            }
                        }
                    }
                }
            }
            _pp_middleCloserPropertyUC.ThisBinding(CreateBindingDictionary());

            _initialLoad = false;
        }

        public IPP_MiddleCloserPropertyUC GetMiddleCloserPropertyUC()
        {
            return _pp_middleCloserPropertyUC;
        }

        public IPP_MiddleCloserPropertyUCPresenter GetNewInstance(IPanelModel panelModel, IUnityContainer unityC, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_MiddleCloserPropertyUC, PP_MiddleCloserPropertyUC>()
                .RegisterType<IPP_MiddleCloserPropertyUCPresenter, PP_MiddleCloserPropertyUCPresenter>();
            PP_MiddleCloserPropertyUCPresenter MiddleCloserPropertyUCPresenter = unityC.Resolve<PP_MiddleCloserPropertyUCPresenter>();
            MiddleCloserPropertyUCPresenter._panelModel = panelModel;
            MiddleCloserPropertyUCPresenter._unityC = unityC;
            MiddleCloserPropertyUCPresenter._mainPresenter = mainPresenter;

            return MiddleCloserPropertyUCPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Panel_MiddleCloserVisibility", new Binding("Visible", _panelModel, "Panel_MiddleCloserVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserArtNo", new Binding("Text", _panelModel, "Panel_MiddleCloserArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MiddleCloserPairQty", new Binding("Value", _panelModel, "Panel_MiddleCloserPairQty", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
