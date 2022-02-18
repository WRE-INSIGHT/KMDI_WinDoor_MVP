using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_HandlePropertyUCPresenter : IPP_HandlePropertyUCPresenter, IPresenterCommon
    {
        IPP_HandlePropertyUC _pp_handlePropertyUC;

        private IPP_RotoswingPropertyUCPresenter _pp_rotoswingPropertyUCPresenter;
        private IPP_RotaryPropertyUCPresenter _pp_rotaryPropertyUCPresenter;
        private IPP_RioPropertyUCPresenter _pp_rioPropertyUCPresenter;
        private IPP_RotolinePropertyUCPresenter _pp_rotolinePropertyUCPresenter;
        private IPP_MVDPropertyUCPresenter _pp_mvdPropertyUCPresenter;
        private IPP_EspagnolettePropertyUCPresenter _pp_espagnolettePropertyUCPresenter;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        Panel _pnlHandleType;
        bool _initialLoad = true;

        public PP_HandlePropertyUCPresenter(IPP_HandlePropertyUC pp_handlePropertyUC,
                                            IPP_RotoswingPropertyUCPresenter pp_rotoswingPropertyUCPresenter,
                                            IPP_RotaryPropertyUCPresenter pp_rotaryPropertyUCPresenter,
                                            IPP_RioPropertyUCPresenter pp_rioPropertyUCPresenter,
                                            IPP_RotolinePropertyUCPresenter pp_rotolinePropertyUCPresenter,
                                            IPP_MVDPropertyUCPresenter pp_mvdPropertyUCPresenter,
                                            IPP_EspagnolettePropertyUCPresenter pp_espagnolettePropertyUCPresenter)
        {
            _pp_handlePropertyUC = pp_handlePropertyUC;
            _pp_rotoswingPropertyUCPresenter = pp_rotoswingPropertyUCPresenter;
            _pp_rotaryPropertyUCPresenter = pp_rotaryPropertyUCPresenter;
            _pp_rioPropertyUCPresenter = pp_rioPropertyUCPresenter;
            _pp_rotolinePropertyUCPresenter = pp_rotolinePropertyUCPresenter;
            _pp_mvdPropertyUCPresenter = pp_mvdPropertyUCPresenter;
            _pp_espagnolettePropertyUCPresenter = pp_espagnolettePropertyUCPresenter;
            _pnlHandleType = _pp_handlePropertyUC.GetHandleTypePNL();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_handlePropertyUC.PPHandlePropertyLoadEventRaised += _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised;
            _pp_handlePropertyUC.cmbHandleTypeSelectedValueEventRaised += _pp_handlePropertyUC_cmbHandleTypeSelectedValueEventRaised;
        }

        private IDividerModel Get_Previous_Divider()
        {
            IDividerModel prev_div = null;

            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                string prev_div_name = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects[_panelModel.Panel_Index_Inside_MPanel - 1].Name;
                prev_div = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == prev_div_name);
            }

            return prev_div;
        }
        private IDividerModel Get_Next_Divider()
        {
            IDividerModel prev_div = null;

            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                string prev_div_name = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects[_panelModel.Panel_Index_Inside_MPanel + 1].Name;
                prev_div = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == prev_div_name);
            }

            return prev_div;
        }

        private void HandleType_None()
        {
            if (_panelModel.Panel_ParentMultiPanelModel != null && _panelModel.Panel_CornerDriveOptionsVisibility == false)
            {
                IDividerModel div_prev = null,
                              div_nxt = null;

                if (_panelModel.Panel_Index_Inside_MPanel != 0)
                {
                    div_prev = Get_Previous_Divider();
                }

                int indx_limits = _panelModel.Panel_ParentMultiPanelModel.MPanel_Divisions * 2;

                if (_panelModel.Panel_Index_Inside_MPanel < indx_limits)
                {
                    div_nxt = Get_Next_Divider();
                }

                if ((div_nxt != null && div_nxt.Div_ChkDM == true) ||
                    (div_prev != null && div_prev.Div_ChkDM == true))
                {
                    _panelModel.Panel_CornerDriveOptionsVisibility = true;
                    _panelModel.AdjustPropertyPanelHeight("addCornerDrive");
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                }
            }

            _panelModel.Panel_EspagnoletteOptionsVisibility = true;
            _panelModel.Panel_ExtensionOptionsVisibility = true;

            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");
            _panelModel.AdjustPropertyPanelHeight("addEspagnolette");
            _panelModel.AdjustHandlePropertyHeight("addEspagnolette");

            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
            _panelModel.AdjustPropertyPanelHeight("addExtension");

            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");
                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
            }

            int fieldExtension_count2 = 0;

            fieldExtension_count2 = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
            fieldExtension_count2 = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
            fieldExtension_count2 = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
            fieldExtension_count2 = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;

            for (int i = 0; i < fieldExtension_count2; i++)
            {
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                }
            }

        }

        Handle_Type curr_handleType;
        private void _pp_handlePropertyUC_cmbHandleTypeSelectedValueEventRaised(object sender, EventArgs e)
        {
            Handle_Type sel_handleType = (Handle_Type)((ComboBox)sender).SelectedValue;

            if (curr_handleType != sel_handleType)
            {
                if (_initialLoad == false)
                {
                    _panelModel.Panel_HandleType = sel_handleType;
                    int fieldExtension_count = 0;

                    fieldExtension_count = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
                    fieldExtension_count = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
                    fieldExtension_count = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
                    fieldExtension_count = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count += 1 : fieldExtension_count;

                    #region Property Height Adjustment - Espagnolette 
                    if (sel_handleType != Handle_Type._Rotary)
                    {
                        if (curr_handleType == Handle_Type._Rotary)
                        {
                            _panelModel.Panel_EspagnoletteOptionsVisibility = true;
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");

                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");
                            }
                            _panelModel.AdjustPropertyPanelHeight("addEspagnolette");
                            _panelModel.AdjustHandlePropertyHeight("addEspagnolette");
                        }
                    }
                    else if (sel_handleType == Handle_Type._Rotary)
                    {
                        if (curr_handleType != Handle_Type._Rotary)
                        {
                            _panelModel.Panel_EspagnoletteOptionsVisibility = false;
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");

                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");
                            }
                            _panelModel.AdjustPropertyPanelHeight("minusEspagnolette");
                            _panelModel.AdjustHandlePropertyHeight("minusEspagnolette");
                        }
                    }
                    #endregion

                    #region Property Height Adjustment - Handle

                    if (sel_handleType == Handle_Type._Rotoswing)
                    {
                        #region Property Height Adjustment - Rotoswing 

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._None;
                        _panelModel.Panel_ExtensionBotArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionBot2ArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTopArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTop2ArtNo = Extension_ArticleNo._None;

                        if (curr_handleType == Handle_Type._Rotary)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            _panelModel.AdjustPropertyPanelHeight("minusRotary");
                            _panelModel.AdjustHandlePropertyHeight("minusRotary");
                        }
                        else if (curr_handleType == Handle_Type._Rio)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                            _panelModel.AdjustPropertyPanelHeight("minusRio");
                            _panelModel.AdjustHandlePropertyHeight("minusRio");

                            if (_panelModel.Panel_RioOptionsVisibility2 == true)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                _panelModel.AdjustPropertyPanelHeight("minusRio");
                                _panelModel.AdjustHandlePropertyHeight("minusRio");
                            }
                        }
                        else if (curr_handleType == Handle_Type._Rotoline)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoline");
                        }
                        else if (curr_handleType == Handle_Type._MVD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            _panelModel.AdjustPropertyPanelHeight("minusMVD");
                            _panelModel.AdjustHandlePropertyHeight("minusMVD");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                        _panelModel.AdjustPropertyPanelHeight("addRotoswing");
                        _panelModel.AdjustHandlePropertyHeight("addRotoswing");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotary)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            }
                            else if (curr_handleType == Handle_Type._Rio)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                if (_panelModel.Panel_RioOptionsVisibility2 == true)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                }
                            }
                            else if (curr_handleType == Handle_Type._Rotoline)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            }
                            else if (curr_handleType == Handle_Type._MVD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = true;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._Rotary)
                    {
                        #region Property Height Adjustment - Rotary

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._None;
                        _panelModel.Panel_ExtensionBotArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionBot2ArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTopArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTop2ArtNo = Extension_ArticleNo._None;

                        if (curr_handleType == Handle_Type._Rotoswing)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswing");

                        }
                        else if (curr_handleType == Handle_Type._Rio)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                            _panelModel.AdjustPropertyPanelHeight("minusRio");
                            _panelModel.AdjustHandlePropertyHeight("minusRio");

                            if (_panelModel.Panel_RioOptionsVisibility2 == true)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                _panelModel.AdjustPropertyPanelHeight("minusRio");
                                _panelModel.AdjustHandlePropertyHeight("minusRio");
                            }
                        }
                        else if (curr_handleType == Handle_Type._Rotoline)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoline");
                        }
                        else if (curr_handleType == Handle_Type._MVD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            _panelModel.AdjustPropertyPanelHeight("minusMVD");
                            _panelModel.AdjustHandlePropertyHeight("minusMVD");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                        _panelModel.AdjustPropertyPanelHeight("addRotary");
                        _panelModel.AdjustHandlePropertyHeight("addRotary");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rio)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                if (_panelModel.Panel_RioOptionsVisibility2 == true)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                }
                            }
                            else if (curr_handleType == Handle_Type._Rotoline)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            }
                            else if (curr_handleType == Handle_Type._MVD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                        }

                        _panelModel.Panel_RotaryOptionsVisibility = true;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._Rio)
                    {
                        #region Property Height Adjustment - Rio

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._642105;
                        _panelModel.Panel_ExtensionBotArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionBot2ArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTopArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTop2ArtNo = Extension_ArticleNo._None;

                        if (curr_handleType == Handle_Type._Rotary)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            _panelModel.AdjustPropertyPanelHeight("minusRotary");
                            _panelModel.AdjustHandlePropertyHeight("minusRotary");

                        }
                        else if (curr_handleType == Handle_Type._Rotoswing)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswing");
                        }
                        else if (curr_handleType == Handle_Type._Rotoline)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoline");
                        }
                        else if (curr_handleType == Handle_Type._MVD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            _panelModel.AdjustPropertyPanelHeight("minusMVD");
                            _panelModel.AdjustHandlePropertyHeight("minusMVD");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRio");
                        _panelModel.AdjustPropertyPanelHeight("addRio");
                        _panelModel.AdjustHandlePropertyHeight("addRio");


                        Foil_Color inside_color = _panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;
                        Foil_Color outside_color = _panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_OutsideColor;

                        if (_panelModel.Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door &&
                            _panelModel.Panel_Type.Contains("Casement") &&
                            inside_color != outside_color)
                        {
                            _panelModel.Panel_RioOptionsVisibility2 = true;
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRio");
                            _panelModel.AdjustPropertyPanelHeight("addRio");
                            _panelModel.AdjustHandlePropertyHeight("addRio");
                        }
                        else if (_panelModel.Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door &&
                            inside_color == outside_color)
                        {
                            _panelModel.Panel_RioOptionsVisibility2 = false;
                        }


                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotary)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            }
                            else if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rotoline)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            }
                            else if (curr_handleType == Handle_Type._MVD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRio");

                            if (_panelModel.Panel_RioOptionsVisibility2 == true)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRio");
                            }
                        }

                        _panelModel.Panel_RioOptionsVisibility = true;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._Rotoline)
                    {
                        #region Property Height Adjustment - Rotoline

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._642089;
                        _panelModel.Panel_ExtensionBotArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionBot2ArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTopArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTop2ArtNo = Extension_ArticleNo._None;

                        if (curr_handleType == Handle_Type._Rotary)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            _panelModel.AdjustPropertyPanelHeight("minusRotary");
                            _panelModel.AdjustHandlePropertyHeight("minusRotary");

                        }
                        else if (curr_handleType == Handle_Type._Rotoswing)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswing");
                        }
                        else if (curr_handleType == Handle_Type._Rio)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                            _panelModel.AdjustPropertyPanelHeight("minusRio");
                            _panelModel.AdjustHandlePropertyHeight("minusRio");

                            if (_panelModel.Panel_RioOptionsVisibility2 == true)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                _panelModel.AdjustPropertyPanelHeight("minusRio");
                                _panelModel.AdjustHandlePropertyHeight("minusRio");
                            }
                        }
                        else if (curr_handleType == Handle_Type._MVD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            _panelModel.AdjustPropertyPanelHeight("minusMVD");
                            _panelModel.AdjustHandlePropertyHeight("minusMVD");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoline");
                        _panelModel.AdjustPropertyPanelHeight("addRotoline");
                        _panelModel.AdjustHandlePropertyHeight("addRotoline");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotary)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            }
                            else if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rio)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                if (_panelModel.Panel_RioOptionsVisibility2 == true)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                }
                            }
                            else if (curr_handleType == Handle_Type._MVD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoline");
                        }

                        _panelModel.Panel_RotolineOptionsVisibility = true;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._MVD)
                    {
                        #region Property Height Adjustment - MVD

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._630963;
                        _panelModel.Panel_ExtensionBotArtNo = Extension_ArticleNo._630956;
                        _panelModel.Panel_ExtensionBot2ArtNo = Extension_ArticleNo._630956;
                        _panelModel.Panel_ExtensionTopArtNo = Extension_ArticleNo._630956;
                        _panelModel.Panel_ExtensionTop2ArtNo = Extension_ArticleNo._630956;

                        if (curr_handleType == Handle_Type._Rotary)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            _panelModel.AdjustPropertyPanelHeight("minusRotary");
                            _panelModel.AdjustHandlePropertyHeight("minusRotary");

                        }
                        else if (curr_handleType == Handle_Type._Rotoswing)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswing");
                        }
                        else if (curr_handleType == Handle_Type._Rio)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                            _panelModel.AdjustPropertyPanelHeight("minusRio");
                            _panelModel.AdjustHandlePropertyHeight("minusRio");

                            if (_panelModel.Panel_RioOptionsVisibility2 == true)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                _panelModel.AdjustPropertyPanelHeight("minusRio");
                                _panelModel.AdjustHandlePropertyHeight("minusRio");
                            }
                        }
                        else if (curr_handleType == Handle_Type._Rotoline)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoline");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                        _panelModel.AdjustPropertyPanelHeight("addMVD");
                        _panelModel.AdjustHandlePropertyHeight("addMVD");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotary)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            }
                            else if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rio)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                if (_panelModel.Panel_RioOptionsVisibility2 == true)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                }
                            }
                            else if (curr_handleType == Handle_Type._Rotoline)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                        }

                        _panelModel.Panel_MVDOptionsVisibility = true;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;

                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._None)
                    {
                        #region Property Height Adjustment - None

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._None;
                        _panelModel.Panel_ExtensionBotArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionBot2ArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTopArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTop2ArtNo = Extension_ArticleNo._None;
                        _panelModel.Panel_ExtensionTop3ArtNo = Extension_ArticleNo._None;

                        if (curr_handleType == Handle_Type._Rotary)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            _panelModel.AdjustPropertyPanelHeight("minusRotary");
                            _panelModel.AdjustHandlePropertyHeight("minusRotary");
                        }
                        else if (curr_handleType == Handle_Type._Rotoswing)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswing");
                        }
                        else if (curr_handleType == Handle_Type._Rio)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                            _panelModel.AdjustPropertyPanelHeight("minusRio");
                            _panelModel.AdjustHandlePropertyHeight("minusRio");

                            if (_panelModel.Panel_RioOptionsVisibility2 == true)
                            {
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                _panelModel.AdjustPropertyPanelHeight("minusRio");
                                _panelModel.AdjustHandlePropertyHeight("minusRio");
                            }
                        }
                        else if (curr_handleType == Handle_Type._Rotoline)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoline");
                        }
                        else if (curr_handleType == Handle_Type._MVD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            _panelModel.AdjustPropertyPanelHeight("minusMVD");
                            _panelModel.AdjustHandlePropertyHeight("minusMVD");
                        }

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotary)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                            }
                            else if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rio)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                if (_panelModel.Panel_RioOptionsVisibility2 == true)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                                }
                            }
                            else if (curr_handleType == Handle_Type._Rotoline)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            }
                            else if (curr_handleType == Handle_Type._MVD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                            }
                        }

                        _panelModel.Panel_MVDOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;

                        _panelModel.Panel_EspagnoletteOptionsVisibility = false;
                        _panelModel.Panel_ExtensionOptionsVisibility = false;

                        if (_panelModel.Panel_ParentMultiPanelModel != null &&
                            _panelModel.Panel_CornerDriveOptionsVisibility == true)
                        {
                            IDividerModel div_prev = null,
                              div_nxt = null;

                            if (_panelModel.Panel_Index_Inside_MPanel != 0)
                            {
                                div_prev = Get_Previous_Divider();
                            }

                            int indx_limits = _panelModel.Panel_ParentMultiPanelModel.MPanel_Divisions * 2;

                            if (_panelModel.Panel_Index_Inside_MPanel < indx_limits)
                            {
                                div_nxt = Get_Next_Divider();
                            }

                            if ((div_nxt != null && div_nxt.Div_ChkDM == true) ||
                                (div_prev != null && div_prev.Div_ChkDM == true))
                            {
                                if (_panelModel.Panel_CornerDriveOptionsVisibility == true)
                                {
                                    _panelModel.Panel_CornerDriveOptionsVisibility = false;

                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                                    _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");

                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                                }
                            }

                        }

                        _panelModel.AdjustPropertyPanelHeight("minusEspagnolette");
                        _panelModel.AdjustHandlePropertyHeight("minusEspagnolette");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");

                        _panelModel.AdjustPropertyPanelHeight("minusExtension");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");
                        }

                        int fieldExtension_count2 = 0;

                        fieldExtension_count2 = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
                        fieldExtension_count2 = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
                        fieldExtension_count2 = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
                        fieldExtension_count2 = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;

                        for (int i = 0; i < fieldExtension_count2; i++)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                            _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                            }
                        }

                        #endregion
                    }

                    #endregion
                }
                curr_handleType = sel_handleType;
            }
        }

        private void _pp_handlePropertyUC_PPHandlePropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_handlePropertyUC.ThisBinding(CreateBindingDictionary());

            IPP_RotoswingPropertyUCPresenter rotoswingPropUCP = _pp_rotoswingPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rotoswingPropUC = (UserControl)rotoswingPropUCP.GetPPRotoswingPropertyUC();
            _pnlHandleType.Controls.Add(rotoswingPropUC);
            rotoswingPropUC.Dock = DockStyle.Top;
            rotoswingPropUC.BringToFront();

            IPP_RotaryPropertyUCPresenter rotaryPropUCP = _pp_rotaryPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rotaryPropUC = (UserControl)rotaryPropUCP.GetPPRotaryPropertyUC();
            _pnlHandleType.Controls.Add(rotaryPropUC);
            rotaryPropUC.Dock = DockStyle.Top;
            rotaryPropUC.BringToFront();

            IPP_RioPropertyUCPresenter rioUCP = _pp_rioPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rioPropUC = (UserControl)rioUCP.GetRioPropertyUC();
            _pnlHandleType.Controls.Add(rioPropUC);
            rioPropUC.Dock = DockStyle.Top;
            rioPropUC.BringToFront();

            IPP_RotolinePropertyUCPresenter rotolineUCP = _pp_rotolinePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rotolinePropUC = (UserControl)rotolineUCP.GetRotolinePropertyUC();
            _pnlHandleType.Controls.Add(rotolinePropUC);
            rotolinePropUC.Dock = DockStyle.Top;
            rotolinePropUC.BringToFront();

            IPP_MVDPropertyUCPresenter mvdUCP = _pp_mvdPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl mvdPropUC = (UserControl)mvdUCP.GetMVDPropertyUC();
            _pnlHandleType.Controls.Add(mvdPropUC);
            mvdPropUC.Dock = DockStyle.Top;
            mvdPropUC.BringToFront();

            IPP_EspagnolettePropertyUCPresenter espUCP = _pp_espagnolettePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl espPropUC = (UserControl)espUCP.GetPPEspagnolettePropertyUC();
            _pnlHandleType.Controls.Add(espPropUC);
            espPropUC.Dock = DockStyle.Top;
            espPropUC.BringToFront();

            Handle_Type handle = _panelModel.Panel_HandleType;

            if (handle != Handle_Type._Rotary && handle != Handle_Type._None)
            {
                _panelModel.Panel_EspagnoletteOptionsVisibility = true;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");
                }

                _panelModel.AdjustPropertyPanelHeight("addEspagnolette");
                _panelModel.AdjustHandlePropertyHeight("addEspagnolette");
            }
            else
            {
                _panelModel.Panel_EspagnoletteOptionsVisibility = false;
            }

            if (handle == Handle_Type._Rotoswing)
            {
                _panelModel.Panel_RotoswingOptionsVisibility = true;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_MVDOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotoswing");
                _panelModel.AdjustHandlePropertyHeight("addRotoswing");
            }
            else if (handle == Handle_Type._Rotary)
            {
                _panelModel.Panel_RotaryOptionsVisibility = true;
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_MVDOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotary");

                _panelModel.AdjustHandlePropertyHeight("addRotary");
            }
            else if (handle == Handle_Type._Rio)
            {
                _panelModel.Panel_RioOptionsVisibility = true;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_MVDOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRio");
                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRio");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotary");

                _panelModel.AdjustHandlePropertyHeight("addRotary");
            }
            else if (handle == Handle_Type._Rotoline)
            {
                _panelModel.Panel_RotolineOptionsVisibility = true;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_MVDOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoline");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoline");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotoline");

                _panelModel.AdjustHandlePropertyHeight("addRotoline");
            }
            else if (handle == Handle_Type._MVD)
            {
                _panelModel.Panel_MVDOptionsVisibility = true;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMVD");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                }

                _panelModel.AdjustPropertyPanelHeight("addMVD");

                _panelModel.AdjustHandlePropertyHeight("addMVD");
            }

            _initialLoad = false;
        }

        public IPP_HandlePropertyUC GetPPHandlePropertyUC()
        {
            return _pp_handlePropertyUC;
        }

        public IPP_HandlePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_HandlePropertyUC, PP_HandlePropertyUC>()
                .RegisterType<IPP_HandlePropertyUCPresenter, PP_HandlePropertyUCPresenter>();
            PP_HandlePropertyUCPresenter presenter = unityC.Resolve<PP_HandlePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;
            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_HandleType", new Binding("Text", _panelModel, "Panel_HandleType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HandleOptionsVisibility", new Binding("Visible", _panelModel, "Panel_HandleOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_HandleOptionsHeight", new Binding("Height", _panelModel, "Panel_HandleOptionsHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Frame_ArtNo", new Binding("Frame_ArtNo", _panelModel.Panel_ParentFrameModel, "Frame_ArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_SashProfileArtNo", new Binding("Panel_SashProfileArtNo", _panelModel, "Panel_SashProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
