﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.Quotation.Panel;
using System.Windows.Forms;
using Unity;
using CommonComponents;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls
{
    public class PanelPropertiesUCPresenter : IPanelPropertiesUCPresenter, IPresenterCommon
    {
        IPanelPropertiesUC _panelPropertiesUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IGlassThicknessListPresenter _glassThicknessPresenter;
        private IUnityContainer _unityC;

        private ComboBox _cmbHandleArtNo;
        private Panel _pnlRotoswingOptions;
        private Panel _pnlRotaryOptions;

        private bool _initialLoad = true;

        public PanelPropertiesUCPresenter(IPanelPropertiesUC panelPropertiesUC,
                                          IGlassThicknessListPresenter glassThicknessPresenter)
        {
            _panelPropertiesUC = panelPropertiesUC;
            _glassThicknessPresenter = glassThicknessPresenter;
            _cmbHandleArtNo = _panelPropertiesUC.GetCmbHandleArtNo();
            _pnlRotoswingOptions = _panelPropertiesUC.GetPnlRotoswingOptions();
            _pnlRotaryOptions = _panelPropertiesUC.GetPnlRotaryOptions();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _panelPropertiesUC.PanelPropertiesLoadEventRaised += new EventHandler(OnPanelPropertiesLoadEventRaised);
            _panelPropertiesUC.ChkOrientationCheckChangedEventRaised += _panelPropertiesUC_ChkOrientationCheckChangedEventRaised;
            _panelPropertiesUC.CmbGlazingArtNoSelectedValueChangedEventRaised += _panelPropertiesUC_CmbGlazingArtNoSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbFilmTypeSelectedValueChangedEventRaised += _panelPropertiesUC_CmbFilmTypeSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbSashProfileSelectedValueChangedEventRaised += _panelPropertiesUC_CmbSashProfileSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbSashReinfSelectedValueChangedEventRaised += _panelPropertiesUC_CmbSashReinfSelectedValueChangedEventRaised;
            _panelPropertiesUC.btnSelectGlassThicknessClickedEventRaised += _panelPropertiesUC_btnSelectGlassThicknessClickedEventRaised;
            _panelPropertiesUC.CmbGlassTypeSelectedValueChangedEventRaised += _panelPropertiesUC_CmbGlassTypeSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbHandleTypeSelectedValueChangedEventRaised += _panelPropertiesUC_CmbHandleTypeSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbHandleArtNoSelectedValueChangedEventRaised += _panelPropertiesUC_CmbHandleArtNoSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbEspagnoletteSelectedValueChangedEventRaised += _panelPropertiesUC_CmbEspagnoletteSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbMiddleCloserSelectedValueChangedEventRaised += _panelPropertiesUC_CmbMiddleCloserSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbLockingKitSelectedValueChangedEventRaised += _panelPropertiesUC_CmbLockingKitSelectedValueChangedEventRaised;
        }

        private void _panelPropertiesUC_CmbLockingKitSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_LockingKitArtNo = (LockingKit_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbMiddleCloserSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_MiddleCloserArtNo = (MiddleCloser_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbEspagnoletteSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_EspagnoletteArtNo = (Espagnolette_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbHandleArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _panelPropertiesUC_CmbHandleTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_HandleType = (Handle_Type)((ComboBox)sender).SelectedValue;

            List<Rotoswing_HandleArtNo> rotoswing = new List<Rotoswing_HandleArtNo>();
            foreach (Rotoswing_HandleArtNo item in Rotoswing_HandleArtNo.GetAll())
            {
                rotoswing.Add(item);
            }

            List<Rotary_HandleArtNo> rotary = new List<Rotary_HandleArtNo>();
            foreach (Rotary_HandleArtNo item in Rotary_HandleArtNo.GetAll())
            {
                rotary.Add(item);
            }

            if (_panelModel.Panel_Type != "Fixed Panel")
            {
                if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _cmbHandleArtNo.DataSource = rotoswing;
                    _pnlRotoswingOptions.Visible = true;
                    _pnlRotaryOptions.Visible = false;
                    if (_initialLoad == true)
                    {
                        _initialLoad = false;
                    }
                    else if (_initialLoad == false)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                        }
                    }
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _cmbHandleArtNo.DataSource = rotary;
                    _pnlRotoswingOptions.Visible = false;
                    _pnlRotaryOptions.Visible = true;
                    if (_initialLoad == true)
                    {
                        _initialLoad = false;
                    }
                    else if (_initialLoad == false)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                        }
                    }
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    }
                }
            }

        }

        private void _panelPropertiesUC_CmbGlassTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_GlassType = (GlassType)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_btnSelectGlassThicknessClickedEventRaised(object sender, EventArgs e)
        {
            IGlassThicknessListPresenter glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance(_unityC, this, _mainPresenter.GlassThicknessDT, _panelModel);
            glassThicknessPresenter.ShowGlassThicknessListView();
        }

        private void _panelPropertiesUC_CmbSashReinfSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_SashReinfArtNo = (SashReinf_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbSashProfileSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_SashProfileArtNo = (SashProfile_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbFilmTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
           _panelModel.Panel_GlassFilm = (GlassFilm_Types)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbGlazingArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.PanelGlazingBead_ArtNo = (GlazingBead_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_ChkOrientationCheckChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (_panelModel.Panel_ParentFrameModel != null)
            {
                if (chk.Text == "None" && chk.Checked == true)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("SashProp", "add");
                }
                else if (chk.Text == "dSash" && chk.Checked == false)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("SashProp", "delete");
                }
            }
            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                if (chk.Text == "None" == chk.Checked == true)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("SashProp", "add");
                }
                else if (chk.Text == "dSash" && chk.Checked == false)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("SashProp", "delete");
                }
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void OnPanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _panelPropertiesUC.ThisBinding(CreateBindingDictionary());
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Value", _panelModel, "Panel_DisplayWidth", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Value", _panelModel, "Panel_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Text", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Type", new Binding("Text", _panelModel, "Panel_Type", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ChkText", new Binding("Text", _panelModel, "Panel_ChkText", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("Checked", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PNumEnable1", new Binding("Enabled", _panelModel, "Panel_PNumEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PNumEnable2", new Binding("Enabled", _panelModel, "Panel_PNumEnable", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_GlassThickness", new Binding("Text", _panelModel, "Panel_GlassThickness", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlazingBead_ArtNo", new Binding("Text", _panelModel, "PanelGlazingBead_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlass_ID", new Binding("PanelGlass_ID", _panelModel, "PanelGlass_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_GlassFilm", new Binding("Text", _panelModel, "Panel_GlassFilm", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_SashPropertyVisibility", new Binding("Visible", _panelModel, "Panel_SashPropertyVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_SashProfileArtNo", new Binding("Text", _panelModel, "Panel_SashProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_SashReinfArtNo", new Binding("Text", _panelModel, "Panel_SashReinfArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_GlassType", new Binding("Text", _panelModel, "Panel_GlassType", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_GlassThicknessDesc", new Binding("Text", _panelModel, "Panel_GlassThicknessDesc", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HandleType", new Binding("Text", _panelModel, "Panel_HandleType", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PropertyHeight", new Binding("Height", _panelModel, "Panel_PropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HandleOptionsVisibility", new Binding("Visible", _panelModel, "Panel_HandleOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_RotoswingOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RotoswingOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_RotaryOptionsVisibility", new Binding("Visible", _panelModel, "Panel_RotaryOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HandleOptionsHeight", new Binding("Height", _panelModel, "Panel_HandleOptionsHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_EspagnoletteArtNo", new Binding("Text", _panelModel, "Panel_EspagnoletteArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_StrikerArtno", new Binding("Text", _panelModel, "Panel_StrikerArtno", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_MiddleCloserArtNo", new Binding("Text", _panelModel, "Panel_MiddleCloserArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_LockingKitArtNo", new Binding("Text", _panelModel, "Panel_LockingKitArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public IPanelPropertiesUC GetPanelPropertiesUC()
        {
            return _panelPropertiesUC;
        }


        public IPanelPropertiesUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPanelPropertiesUC, Panel_PropertiesUC>()
                .RegisterType<IPanelPropertiesUCPresenter, PanelPropertiesUCPresenter>();
            PanelPropertiesUCPresenter panelPropUCP = unityC.Resolve<PanelPropertiesUCPresenter>();
            panelPropUCP._unityC = unityC;
            panelPropUCP._panelModel = panelModel;
            panelPropUCP._mainPresenter = mainPresenter;

            return panelPropUCP;
        }

    }
}
