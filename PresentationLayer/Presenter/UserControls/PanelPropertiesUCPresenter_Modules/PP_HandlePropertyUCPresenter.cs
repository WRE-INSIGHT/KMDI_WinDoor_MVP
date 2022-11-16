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
        private IPP_DHandlePropertyUCPresenter _pp_DHandlePropertyUCPresenter;
        private IPP_DHandle_IOLockingPropertyUCPresenter _pp_DHandle_IOLockingPropertyUCPresenter;
        private IPP_DummyDHandlePropertyUCPresenter _pp_DummyDHandlePropertyUCPresenter;
        private IPP_PopUpHandlePropertyUCPresenter _pp_PopUpHandlePropertyUCPresenter;
        private IPP_RotoswingForSlidingPropertyUCPresenter _pp_RotoswingForSlidingPropertyUCPresenter;


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
                                            IPP_DHandlePropertyUCPresenter pp_DHandlePropertyUCPresenter,
                                            IPP_DHandle_IOLockingPropertyUCPresenter pp_DHandle_IOLockingPropertyUCPresenter,
                                            IPP_DummyDHandlePropertyUCPresenter pp_DummyDHandlePropertyUCPresenter,
                                            IPP_PopUpHandlePropertyUCPresenter pp_PopUpHandlePropertyUCPresenter,
                                            IPP_RotoswingForSlidingPropertyUCPresenter pp_RotoswingForSlidingPropertyUCPresenter,
                                            IPP_EspagnolettePropertyUCPresenter pp_espagnolettePropertyUCPresenter)
        {
            _pp_handlePropertyUC = pp_handlePropertyUC;
            _pp_rotoswingPropertyUCPresenter = pp_rotoswingPropertyUCPresenter;
            _pp_rotaryPropertyUCPresenter = pp_rotaryPropertyUCPresenter;
            _pp_rioPropertyUCPresenter = pp_rioPropertyUCPresenter;
            _pp_rotolinePropertyUCPresenter = pp_rotolinePropertyUCPresenter;
            _pp_mvdPropertyUCPresenter = pp_mvdPropertyUCPresenter;
            _pp_DHandlePropertyUCPresenter = pp_DHandlePropertyUCPresenter;
            _pp_DHandle_IOLockingPropertyUCPresenter = pp_DHandle_IOLockingPropertyUCPresenter;
            _pp_DummyDHandlePropertyUCPresenter = pp_DummyDHandlePropertyUCPresenter;
            _pp_PopUpHandlePropertyUCPresenter = pp_PopUpHandlePropertyUCPresenter;
            _pp_RotoswingForSlidingPropertyUCPresenter = pp_RotoswingForSlidingPropertyUCPresenter;
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
                        if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                        {
                            _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774275;
                        }
                        else
                        {
                            _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._628806;
                        }

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
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = true;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;
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
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                        }

                        _panelModel.Panel_RotaryOptionsVisibility = true;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;
                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._Rio)
                    {
                        #region Property Height Adjustment - Rio
                        if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 ||
                            _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                        {
                            _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;
                        }
                        else
                        {
                            _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._642105;
                        }
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
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
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

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;
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
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoline");
                        }

                        _panelModel.Panel_RotolineOptionsVisibility = true;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;
                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._MVD)
                    {
                        #region Property Height Adjustment - MVD

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._630963;
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
                        else if (curr_handleType == Handle_Type._Rotoline)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoline");
                        }
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                        }

                        _panelModel.Panel_MVDOptionsVisibility = true;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

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
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
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

                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                        }

                        _panelModel.Panel_MVDOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RotoswingOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

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
                    else if (sel_handleType == Handle_Type._D)
                    {
                        #region Property Height Adjustment - D handle

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;
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
                        else if (curr_handleType == Handle_Type._Rotary)
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
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                        _panelModel.AdjustPropertyPanelHeight("addDHandle");
                        _panelModel.AdjustHandlePropertyHeight("addDHandle");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rotary)
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
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = true;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;



                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._DummyD)
                    {
                        #region Property Height Adjustment - DummyD handle

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;
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
                        else if (curr_handleType == Handle_Type._Rotary)
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
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDummyDHandle");
                        _panelModel.AdjustPropertyPanelHeight("addDummyDHandle");
                        _panelModel.AdjustHandlePropertyHeight("addDummyDHandle");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rotary)
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
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = true;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;



                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._D_IO_Locking)
                    {
                        #region Property Height Adjustment - D IO Locking handle

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;
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
                        else if (curr_handleType == Handle_Type._Rotary)
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
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDHandleIOLocking");
                        _panelModel.AdjustPropertyPanelHeight("addDHandleIOLocking");
                        _panelModel.AdjustHandlePropertyHeight("addDHandleIOLocking");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rotary)
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = true;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;



                        #endregion
                    }
                    else if (sel_handleType == Handle_Type._PopUp)
                    {
                        #region Property Height Adjustment - Pop-up handle

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774275;
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
                        else if (curr_handleType == Handle_Type._Rotary)
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
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._RotoswingForSliding)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                            _panelModel.AdjustHandlePropertyHeight("minusRotoswingForSliding");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDPopUpHandle");
                        _panelModel.AdjustPropertyPanelHeight("addDPopUpHandle");
                        _panelModel.AdjustHandlePropertyHeight("addDPopUpHandle");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rotary)
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }
                            else if (curr_handleType == Handle_Type._RotoswingForSliding)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                            }
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = true;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;



                        #endregion

                    }
                    else if (sel_handleType == Handle_Type._RotoswingForSliding)
                    {
                        #region Property Height Adjustment - Rotoswing For Sliding handle

                        _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;
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
                        else if (curr_handleType == Handle_Type._Rotary)
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
                        else if (curr_handleType == Handle_Type._D)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandle");
                        }
                        else if (curr_handleType == Handle_Type._D_IO_Locking)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                            _panelModel.AdjustHandlePropertyHeight("minusDHandleIOLocking");
                        }
                        else if (curr_handleType == Handle_Type._DummyD)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusDummyDHandle");
                        }
                        else if (curr_handleType == Handle_Type._PopUp)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                            _panelModel.AdjustHandlePropertyHeight("minusPopUpHandle");
                        }
                        else if (curr_handleType == Handle_Type._None)
                        {
                            HandleType_None();
                        }

                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswingForSliding");
                        _panelModel.AdjustPropertyPanelHeight("addRotoswingForSliding");
                        _panelModel.AdjustHandlePropertyHeight("addRotoswingForSliding");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            if (curr_handleType == Handle_Type._Rotoswing)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                            }
                            else if (curr_handleType == Handle_Type._Rotary)
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
                            else if (curr_handleType == Handle_Type._D)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                            }
                            else if (curr_handleType == Handle_Type._D_IO_Locking)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                            }
                            else if (curr_handleType == Handle_Type._DummyD)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                            }
                            else if (curr_handleType == Handle_Type._PopUp)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                            }

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                        }

                        _panelModel.Panel_RotoswingOptionsVisibility = false;
                        _panelModel.Panel_RotaryOptionsVisibility = false;
                        _panelModel.Panel_RioOptionsVisibility = false;
                        _panelModel.Panel_RotolineOptionsVisibility = false;
                        _panelModel.Panel_MVDOptionsVisibility = false;

                        _panelModel.Panel_DHandleOptionVisibilty = false;
                        _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                        _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                        _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                        _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = true;

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

            IPP_DHandlePropertyUCPresenter dUCP = _pp_DHandlePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl dPropUC = (UserControl)dUCP.GetDHandlePropertyUC();
            _pnlHandleType.Controls.Add(dPropUC);
            dPropUC.Dock = DockStyle.Top;
            dPropUC.BringToFront();

            IPP_DHandle_IOLockingPropertyUCPresenter dIOLockingUCP = _pp_DHandle_IOLockingPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl dIOLockingPropUC = (UserControl)dIOLockingUCP.GetDHandle_IOLockingPropertyUC();
            _pnlHandleType.Controls.Add(dIOLockingPropUC);
            dIOLockingPropUC.Dock = DockStyle.Top;
            dIOLockingPropUC.BringToFront();

            IPP_DummyDHandlePropertyUCPresenter dummyDUCP = _pp_DummyDHandlePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl dummyDPropUC = (UserControl)dummyDUCP.GetDummyDHandlePropertyUC();
            _pnlHandleType.Controls.Add(dummyDPropUC);
            dummyDPropUC.Dock = DockStyle.Top;
            dummyDPropUC.BringToFront();

            IPP_PopUpHandlePropertyUCPresenter popUpUCP = _pp_PopUpHandlePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl popUpPropUC = (UserControl)popUpUCP.GetPopUpHandlePropertyUC();
            _pnlHandleType.Controls.Add(popUpPropUC);
            popUpPropUC.Dock = DockStyle.Top;
            popUpPropUC.BringToFront();

            IPP_RotoswingForSlidingPropertyUCPresenter rotoswingForSlidingUCP = _pp_RotoswingForSlidingPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl rotoswingForSlidingPropUC = (UserControl)rotoswingForSlidingUCP.GetRotoswingForSlidingPropertyUC();
            _pnlHandleType.Controls.Add(rotoswingForSlidingPropUC);
            rotoswingForSlidingPropUC.Dock = DockStyle.Top;
            rotoswingForSlidingPropUC.BringToFront();

            IPP_EspagnolettePropertyUCPresenter espUCP = _pp_espagnolettePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
            UserControl espPropUC = (UserControl)espUCP.GetPPEspagnolettePropertyUC();
            _pnlHandleType.Controls.Add(espPropUC);
            espPropUC.Dock = DockStyle.Top;
            espPropUC.BringToFront();

            if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
            {
                _panelModel.Panel_HandleType = Handle_Type._Rio;
            }
            else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
            {
                _panelModel.Panel_HandleType = Handle_Type._Rotoline;
            }

            Base_Color base_color = _panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_BaseColor;
            Foil_Color inside_color = _panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_InsideColor;
            Foil_Color outside_color = _panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_OutsideColor;

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

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;
                _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._628806;

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

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

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
                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 ||
                    _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;
                }
                else
                {
                    _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._642105;
                }

                _panelModel.Panel_RioOptionsVisibility = true;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_MVDOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRio");
                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRio");
                }

                _panelModel.AdjustPropertyPanelHeight("addRio");

                _panelModel.AdjustHandlePropertyHeight("addRio");
            }
            else if (handle == Handle_Type._Rotoline)
            {
                _panelModel.Panel_RotolineOptionsVisibility = true;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;
                _panelModel.Panel_MVDOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

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

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMVD");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                }

                _panelModel.AdjustPropertyPanelHeight("addMVD");

                _panelModel.AdjustHandlePropertyHeight("addMVD");
            }
            else if (handle == Handle_Type._D)
            {
                _panelModel.Panel_MVDOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = true;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;
                _panelModel.Panel_EspagnoletteArtNo = Espagnolette_ArticleNo._774286;

                if (inside_color == Foil_Color._None)
                {
                    if (base_color == Base_Color._White)
                    {
                        _panelModel.Panel_DHandleInsideArtNo = D_HandleArtNo._DH613226;
                        _panelModel.Panel_DHandleOutsideArtNo = D_HandleArtNo._DH605543;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        _panelModel.Panel_DHandleInsideArtNo = D_HandleArtNo._DH613224;
                        _panelModel.Panel_DHandleOutsideArtNo = D_HandleArtNo._DH613185;
                    }
                    else if (base_color == Base_Color._Ivory)
                    {
                        _panelModel.Panel_DHandleInsideArtNo = D_HandleArtNo._DH613228;
                        _panelModel.Panel_DHandleOutsideArtNo = D_HandleArtNo._DH487261;
                    }
                }
                else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                         inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                {
                    _panelModel.Panel_DHandleInsideArtNo = D_HandleArtNo._DH613224;
                    _panelModel.Panel_DHandleOutsideArtNo = D_HandleArtNo._DH613185;
                }
                else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                         inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                         inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                         inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                         inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                {
                    _panelModel.Panel_DHandleInsideArtNo = D_HandleArtNo._DH613225;
                    _panelModel.Panel_DHandleOutsideArtNo = D_HandleArtNo._DH605551;
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDHandle");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandle");
                }

                _panelModel.AdjustPropertyPanelHeight("addDHandle");

                _panelModel.AdjustHandlePropertyHeight("addDHandle");
            }
            else if (handle == Handle_Type._D_IO_Locking)
            {
                _panelModel.Panel_MVDOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = true;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

                if (inside_color == Foil_Color._None)
                {
                    if (base_color == Base_Color._White)
                    {
                        _panelModel.Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613243;
                        _panelModel.Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._613217;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        _panelModel.Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH833309_613215;
                        _panelModel.Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH833308_613241;
                    }
                    else if (base_color == Base_Color._Ivory)
                    {
                        _panelModel.Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613245;
                        _panelModel.Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH613219;
                    }
                }
                else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                        inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                {
                    _panelModel.Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH833309_613215;
                    _panelModel.Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH833308_613241;
                }
                else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                         inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                         inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                         inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                         inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                {
                    _panelModel.Panel_DHandleIOLockingInsideArtNo = D_Handle_IO_LockingArtNo._DH613242;
                    _panelModel.Panel_DHandleIOLockingOutsideArtNo = D_Handle_IO_LockingArtNo._DH605216;
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDHandleIOLocking");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDHandleIOLocking");
                }

                _panelModel.AdjustPropertyPanelHeight("addDHandleIOLocking");

                _panelModel.AdjustHandlePropertyHeight("addDHandleIOLocking");
            }
            else if (handle == Handle_Type._DummyD)
            {
                _panelModel.Panel_MVDOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = true;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

                if (inside_color == Foil_Color._None)
                {
                    if (base_color == Base_Color._White)
                    {
                        _panelModel.Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613226;
                        _panelModel.Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH613191;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        _panelModel.Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613224;
                        _panelModel.Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH833310_613189;
                    }
                    else if (base_color == Base_Color._Ivory)
                    {
                        _panelModel.Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613228;
                        _panelModel.Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH613193;
                    }
                }
                else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Mahogany ||
                      inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Havana)
                {
                    _panelModel.Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613224;
                    _panelModel.Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH833310_613189;
                }
                else if (inside_color == Foil_Color._FossilGray || inside_color == Foil_Color._BeechOak ||
                         inside_color == Foil_Color._DriftWood || inside_color == Foil_Color._Graphite ||
                         inside_color == Foil_Color._JetBlack || inside_color == Foil_Color._ChestnutOak ||
                         inside_color == Foil_Color._WashedOak || inside_color == Foil_Color._GreyOak ||
                         inside_color == Foil_Color._Cacao || inside_color == Foil_Color._CharcoalGray)
                {
                    _panelModel.Panel_DummyDHandleInsideArtNo = DummyD_HandleArtNo._DH613225;
                    _panelModel.Panel_DummyDHandleOutsideArtNo = DummyD_HandleArtNo._DH613190;
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addDummyDHandle");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addDummyDHandle");
                }

                _panelModel.AdjustPropertyPanelHeight("addDummyDHandle");

                _panelModel.AdjustHandlePropertyHeight("addDummyDHandle");
            }
            else if (handle == Handle_Type._PopUp)
            {
                _panelModel.Panel_MVDOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = true;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = false;

                if (base_color == Base_Color._White || base_color == Base_Color._Ivory)
                {
                    _panelModel.Panel_PopUpHandleArtNo = PopUp_HandleArtNo._3127668;
                }
                else if (base_color == Base_Color._DarkBrown)
                {
                    _panelModel.Panel_PopUpHandleArtNo = PopUp_HandleArtNo._323778;
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addPopUpHandle");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addPopUpHandle");
                }

                _panelModel.AdjustPropertyPanelHeight("addPopUpHandle");

                _panelModel.AdjustHandlePropertyHeight("addPopUpHandle");
            }
            else if (handle == Handle_Type._RotoswingForSliding)
            {
                _panelModel.Panel_MVDOptionsVisibility = false;
                _panelModel.Panel_RotolineOptionsVisibility = false;
                _panelModel.Panel_RioOptionsVisibility = false;
                _panelModel.Panel_RotaryOptionsVisibility = false;
                _panelModel.Panel_RotoswingOptionsVisibility = false;

                _panelModel.Panel_DHandleOptionVisibilty = false;
                _panelModel.Panel_DHandleIOLockingOptionVisibilty = false;
                _panelModel.Panel_DummyDHandleOptionVisibilty = false;
                _panelModel.Panel_PopUpHandleOptionVisibilty = false;
                _panelModel.Panel_RotoswingForSlidingHandleOptionVisibilty = true;

                if (inside_color == Foil_Color._None)
                {
                    if (base_color == Base_Color._White)
                    {
                        _panelModel.Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS632303;
                    }
                    else if (base_color == Base_Color._DarkBrown)
                    {
                        _panelModel.Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS632300;
                    }
                    else if (base_color == Base_Color._Ivory)
                    {
                        _panelModel.Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS823094;
                    }
                }
                else if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Havana ||
                    inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Mahogany)
                {
                    _panelModel.Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS632300;
                }
                else if (inside_color == Foil_Color._CharcoalGray || inside_color == Foil_Color._FossilGray ||
                         inside_color == Foil_Color._BeechOak || inside_color == Foil_Color._DriftWood ||
                         inside_color == Foil_Color._Graphite || inside_color == Foil_Color._JetBlack ||
                         inside_color == Foil_Color._ChestnutOak || inside_color == Foil_Color._WashedOak ||
                         inside_color == Foil_Color._GreyOak || inside_color == Foil_Color._Cacao)
                {
                    _panelModel.Panel_RotoswingForSlidingHandleArtNo = Rotoswing_Sliding_HandleArtNo._RSS823073;
                }

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswingForSliding");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswingForSliding");
                }

                _panelModel.AdjustPropertyPanelHeight("addRotoswingForSliding");

                _panelModel.AdjustHandlePropertyHeight("addRotoswingForSliding");
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
