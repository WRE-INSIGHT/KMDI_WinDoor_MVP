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
using PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;

namespace PresentationLayer.Presenter.UserControls
{
    public class PanelPropertiesUCPresenter : IPanelPropertiesUCPresenter, IPresenterCommon
    {
        IPanelPropertiesUC _panelPropertiesUC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IGlassThicknessListPresenter _glassThicknessPresenter;
        private IPP_MotorizedPropertyUCPresenter _pp_motorizedPropertyUCPresenter;
        private IPP_SashPropertyUCPresenter _pp_sashPropertyUCPresenter;
        private IPP_GlassPropertyUCPresenter _pp_glassPropertyUCPresenter;
        private IPP_HandlePropertyUCPresenter _pp_handlePropertUCPresenter;
        private IUnityContainer _unityC;

        private FlowLayoutPanel _flpPanelSpecs;
        //private Panel _pnlRotoswingOptions;
        //private Panel _pnlRotaryOptions;

        private bool _initialLoad = true;

        public PanelPropertiesUCPresenter(IPanelPropertiesUC panelPropertiesUC,
                                          IGlassThicknessListPresenter glassThicknessPresenter,
                                          IPP_MotorizedPropertyUCPresenter pp_motorizedPropertyUCPresenter,
                                          IPP_SashPropertyUCPresenter pp_sashPropertyUCPresenter,
                                          IPP_GlassPropertyUCPresenter pp_glassPropertyUCPresenter,
                                          IPP_HandlePropertyUCPresenter pp_handlePropertUCPresenter)
        {
            _panelPropertiesUC = panelPropertiesUC;
            _glassThicknessPresenter = glassThicknessPresenter;
            _pp_motorizedPropertyUCPresenter = pp_motorizedPropertyUCPresenter;
            _pp_sashPropertyUCPresenter = pp_sashPropertyUCPresenter;
            _pp_glassPropertyUCPresenter = pp_glassPropertyUCPresenter;
            _pp_handlePropertUCPresenter = pp_handlePropertUCPresenter;
            _flpPanelSpecs = _panelPropertiesUC.GetPanelSpecsFLP();

            //_pnlRotoswingOptions = _panelPropertiesUC.GetPnlRotoswingOptions();
            //_pnlRotaryOptions = _panelPropertiesUC.GetPnlRotaryOptions();
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
            _panelPropertiesUC.CmbEspagnoletteSelectedValueChangedEventRaised += _panelPropertiesUC_CmbEspagnoletteSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbMiddleCloserSelectedValueChangedEventRaised += _panelPropertiesUC_CmbMiddleCloserSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbLockingKitSelectedValueChangedEventRaised += _panelPropertiesUC_CmbLockingKitSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbRotoswingArtNoSelectedValueChangedEventRaised += _panelPropertiesUC_CmbRotoswingArtNoSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbRotaryArtNoSelectedValueChangedEventRaised += _panelPropertiesUC_CmbRotaryArtNoSelectedValueChangedEventRaised;
            _panelPropertiesUC.ChkMotorizedCheckChangedEventRaised += _panelPropertiesUC_ChkMotorizedCheckChangedEventRaised;
            _panelPropertiesUC.CmbExtensionSelectedValueChangedEventRaised += _panelPropertiesUC_CmbExtensionSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbCornerDriveSelectedValueChangedEventRaised += _panelPropertiesUC_CmbCornerDriveSelectedValueChangedEventRaised;
            _panelPropertiesUC.CmbStrikerSelectedValueChangedEventRaised += _panelPropertiesUC_CmbStrikerSelectedValueChangedEventRaised;
        }

        private void _panelPropertiesUC_CmbStrikerSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_StrikerArtno = (Striker_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbCornerDriveSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_CornerDriveArtNo = (CornerDrive_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbExtensionSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_ExtensionArtNo = (Extension_ArticleNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_ChkMotorizedCheckChangedEventRaised(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            _panelModel.Panel_MotorizedOptionVisibility = chk.Checked;
            bool extCordrive = _panelModel.Panel_ExtensionCornerDriveOptionsVisibility;

            if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _panelModel.Panel_HandleOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHandle");

                if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");

                    if (extCordrive == true)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtCordrive");
                    }
                    else if (extCordrive == false)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtCordrive");
                    }
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addmotorized");
            }
            else if (chk.Checked == false)
            {
                chk.Text = "No";
                _panelModel.Panel_HandleOptionsVisibility = true;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHandle");
                if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    if (extCordrive == true)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtCordrive");
                    }
                    else if (extCordrive == false)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtCordrive");
                    }
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusmotorized");
            }
        }

        private void _panelPropertiesUC_CmbRotaryArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_RotaryArtNo = (Rotary_HandleArtNo)((ComboBox)sender).SelectedValue;
        }

        private void _panelPropertiesUC_CmbRotoswingArtNoSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _panelModel.Panel_RotoswingArtNo = (Rotoswing_HandleArtNo)((ComboBox)sender).SelectedValue;
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

        Handle_Type curr_handleType;

        private void _panelPropertiesUC_CmbHandleTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            Handle_Type sel_handleType = (Handle_Type)((ComboBox)sender).SelectedValue;
            bool extCordrive = _panelModel.Panel_ExtensionCornerDriveOptionsVisibility;

            if (curr_handleType != sel_handleType)
            {
                _panelModel.Panel_HandleType = sel_handleType;
                curr_handleType = sel_handleType;

                if (_panelModel.Panel_Type != "Fixed Panel")
                {
                    if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                    {
                        //_pnlRotoswingOptions.Visible = true;
                        //_pnlRotaryOptions.Visible = false;
                        if (_initialLoad == false)
                        {
                            if (extCordrive == true)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                            }
                            else if (extCordrive == false)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswingWithoutExtCordrive");
                            }

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
                        //_pnlRotoswingOptions.Visible = false;
                        //_pnlRotaryOptions.Visible = true;
                        if (_initialLoad == false)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                            }
                        }
                        if (extCordrive == true)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                        }
                        else if (extCordrive == false)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingExtCordrive");
                        }

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                        }
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
            IGlassThicknessListPresenter glassThicknessPresenter = _glassThicknessPresenter.GetNewInstance(_unityC, _mainPresenter.GlassThicknessDT, _panelModel);
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
                if (chk.Text == "None" && chk.Checked == true)
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
            if (_panelModel.Panel_SashPropertyVisibility == true)
            {
                IPP_MotorizedPropertyUCPresenter motorizedPropUCP = _pp_motorizedPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                _flpPanelSpecs.Controls.Add((UserControl)motorizedPropUCP.GetPPMotorizedPropertyUC());

                IPP_HandlePropertyUCPresenter handlePropUCP = _pp_handlePropertUCPresenter.GetNewInstance(_unityC, _panelModel);
                _flpPanelSpecs.Controls.Add((UserControl)handlePropUCP.GetPPHandlePropertyUC());

                IPP_SashPropertyUCPresenter sashPropUCP = _pp_sashPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                _flpPanelSpecs.Controls.Add((UserControl)sashPropUCP.GetPPSashPropertyUC());
            }

            IPP_GlassPropertyUCPresenter glassPropUCP = _pp_glassPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
            _flpPanelSpecs.Controls.Add((UserControl)glassPropUCP.GetPPGlassPropertyUC());
            _initialLoad = false;
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
            panelBinding.Add("Panel_RotoswingArtNo", new Binding("Text", _panelModel, "Panel_RotoswingArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_RotaryArtNo", new Binding("Text", _panelModel, "Panel_RotaryArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_MotorizedOptionVisibility", new Binding("Checked", _panelModel, "Panel_MotorizedOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_MotorizedMechArtNo", new Binding("Text", _panelModel, "Panel_MotorizedMechArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_MotorizedOptionVisibility2", new Binding("Visible", _panelModel, "Panel_MotorizedOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_MotorizedpnlOptionVisibility", new Binding("Visible", _panelModel, "Panel_MotorizedpnlOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtensionArtNo", new Binding("Text", _panelModel, "Panel_ExtensionArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CornerDriveArtNo", new Binding("Text", _panelModel, "Panel_CornerDriveArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtensionCornerDriveOptionsVisibility", new Binding("Visible", _panelModel, "Panel_ExtensionCornerDriveOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_RotoswingOptionsHeight", new Binding("Height", _panelModel, "Panel_RotoswingOptionsHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtTopQty", new Binding("Value", _panelModel, "Panel_ExtTopQty", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtBotQty", new Binding("Value", _panelModel, "Panel_ExtBotQty", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtLeftQty", new Binding("Value", _panelModel, "Panel_ExtLeftQty", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtRightQty", new Binding("Value", _panelModel, "Panel_ExtRightQty", true, DataSourceUpdateMode.OnPropertyChanged));

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
