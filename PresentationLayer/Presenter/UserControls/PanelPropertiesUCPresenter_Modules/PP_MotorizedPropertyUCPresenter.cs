using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_MotorizedPropertyUCPresenter : IPP_MotorizedPropertyUCPresenter, IPresenterCommon
    {
        IPP_MotorizedPropertyUC _pp_motorizedPropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        ConstantVariables const_var = new ConstantVariables();
        bool _initialLoad = true;

        public PP_MotorizedPropertyUCPresenter(IPP_MotorizedPropertyUC pp_motorizedPropertyUC)
        {
            _pp_motorizedPropertyUC = pp_motorizedPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_motorizedPropertyUC.PPMotorizedPropertyUCLoadEventRaised += _pp_motorizedPropertyUC_PPMotorizedPropertyUCLoadEventRaised;
            _pp_motorizedPropertyUC.chkMotorizedCheckedChangedEventRaised += _pp_motorizedPropertyUC_chkMotorizedCheckedChangedEventRaised;
            _pp_motorizedPropertyUC.cmbMotorizedMechSelectedValueChangedEventRaised += _pp_motorizedPropertyUC_cmbMotorizedMechSelectedValueChangedEventRaised;
        }

        private void _pp_motorizedPropertyUC_cmbMotorizedMechSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _panelModel.Panel_MotorizedMechArtNo = (MotorizedMech_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _pp_motorizedPropertyUC_chkMotorizedCheckedChangedEventRaised(object sender, EventArgs e)
        {
            int propertiesScroll = _mainPresenter.PropertiesScroll;
            CheckBox chk = (CheckBox)sender;
            _panelModel.Panel_MotorizedOptionVisibility = chk.Checked;
            _panelModel.Panel_HandleOptionsVisibility = !chk.Checked;

            int fieldExtension_count = 0;

            fieldExtension_count = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count += 1 : fieldExtension_count;


            bool DMSelected = false,
                divChkDM = false;
            int pnlIndex = 0;
            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {
                pnlIndex = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects.FindIndex(pnl => pnl.Name == _panelModel.Panel_Name);
            }
            Control divPrev = null;
            Control divNext = null;
            IDividerModel divPrevModel = null;

            if (pnlIndex > 0 && _panelModel.Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
            {
                divPrev = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects[pnlIndex - 1];
                divPrevModel = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == divPrev.Name);
                if (divPrevModel.Div_DMPanel == _panelModel)
                {
                    DMSelected = true;
                }
                if(divPrevModel.Div_ChkDM == true)
                {
                    divChkDM = true;
                }
            }
            IDividerModel divNextModel = null;
            if (_panelModel.Panel_ParentMultiPanelModel != null)
            {

                if ((_panelModel.Panel_ParentMultiPanelModel.MPanelLst_Divider.Count > pnlIndex) && _panelModel.Panel_ParentMultiPanelModel.MPanel_DividerEnabled)
                {
                    divNext = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects[pnlIndex + 1];
                    divNextModel = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Divider.Find(div => div.Div_Name == divNext.Name);

                    if (divNextModel.Div_ChkDM == true && divNextModel.Div_DMPanel == _panelModel)
                    {
                        DMSelected = true;
                    }
                    if (divNextModel.Div_ChkDM == true)
                    {
                        divChkDM = true;
                    }
                }
            }
            if (chk.Checked == true)
            {
                chk.Text = "Yes";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCmbMotorized");
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHandle");

                _panelModel.AdjustPropertyPanelHeight("addCmbMotorized");
                _panelModel.AdjustPropertyPanelHeight("minusHandle");
                if(_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCmbMotorized");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHandle");
                }
                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                {
                    if (_panelModel.Panel_MiddleCloserVisibility == true)
                    {
                        _panelModel.Panel_MiddleCloserVisibility = false;
                        _panelModel.AdjustPropertyPanelHeight("minusMC");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMC");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                        }
                    }
                }

                if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    _panelModel.AdjustPropertyPanelHeight("minusRotoswing");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    _panelModel.AdjustPropertyPanelHeight("minusRotary");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rio)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                    _panelModel.AdjustPropertyPanelHeight("minusRio");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotoline)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                    _panelModel.AdjustPropertyPanelHeight("minusRotoline");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._MVD)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                    _panelModel.AdjustPropertyPanelHeight("minusMVD");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._D)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                    _panelModel.AdjustPropertyPanelHeight("minusDHandle");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandle");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._D_IO_Locking)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                    _panelModel.AdjustPropertyPanelHeight("minusDHandleIOLocking");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDHandleIOLocking");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._DummyD)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                    _panelModel.AdjustPropertyPanelHeight("minusDummyDHandle");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusDummyDHandle");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._PopUp)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                    _panelModel.AdjustPropertyPanelHeight("minusPopUpHandle");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusPopUpHandle");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._RotoswingForSliding)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                    _panelModel.AdjustPropertyPanelHeight("minusRotoswingForSliding");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswingForSliding");
                    }
                }


                if (_panelModel.Panel_HandleType != Handle_Type._Rotary)
                {
                    if(_panelModel.Panel_EspagnoletteOptionsVisibility == true)
                    {
                        _panelModel.Panel_EspagnoletteOptionsVisibility = false;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");
                        _panelModel.AdjustPropertyPanelHeight("minusEspagnolette");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");
                        }
                    }
                }

                _panelModel.AdjustMotorizedPropertyHeight("whole");

                if (_panelModel.Panel_Type.Contains("Casement"))
                {
                    if (_panelModel.Panel_ExtensionOptionsVisibility == true)
                    {

                        _panelModel.Panel_ExtensionOptionsVisibility = false;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                        _panelModel.AdjustPropertyPanelHeight("minusExtension");

                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                        }
                        for (int i = 0; i < fieldExtension_count; i++)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                            _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                            }
                        }
                    }

                    if (_panelModel.Panel_CornerDriveOptionsVisibility == true && _panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_CornerDriveOptionsVisibility = false;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                        _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                        }
                    }
                }
                else
                {
                    if (_panelModel.Panel_ExtensionOptionsVisibility == true)
                    {
                        _panelModel.Panel_ExtensionOptionsVisibility = false;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                        _panelModel.AdjustPropertyPanelHeight("minusExtension");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                        }
                        for (int i = 0; i < fieldExtension_count; i++)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                            _panelModel.AdjustPropertyPanelHeight("minusExtensionField");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                            }
                        }

                        if (_panelModel.Panel_CornerDriveOptionsVisibility == true && 
                            _panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_CornerDriveOptionsVisibility = false;
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                            _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                            }
                        }
                    }
                }

                if (_panelModel.Panel_HingeOptionsVisibility == true)
                {
                    if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                    {
                        _panelModel.Panel_HingeOptionsVisibility = false;
                        _panelModel.AdjustPropertyPanelHeight("minusHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                        }
                        propertiesScroll -= const_var.panel_property_HingeOptionsheight;
                        if (_panelModel.Panel_HingeOptions == HingeOption._2DHinge)
                        {
                            _panelModel.Panel_HingeOptions = HingeOption._FrictionStay;
                        }
                    }
                }

                if (_panelModel.Panel_CenterHingeOptionsVisibility == true)
                {
                    if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        _panelModel.Panel_CenterHingeOptionsVisibility = false;
                        _panelModel.AdjustPropertyPanelHeight("minusCenterHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");
                        }
                        propertiesScroll -= const_var.panel_property_CenterHingeOptionsheight;
                        if (_panelModel.Panel_NTCenterHingeVisibility == true)
                        {
                            _panelModel.Panel_NTCenterHingeVisibility = false;
                            _panelModel.AdjustPropertyPanelHeight("minusNTCenterHinge");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                            }
                            propertiesScroll -= const_var.panel_property_NTCenterHingeOptionsheight;
                        }
                    }
                }

                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    _panelModel.Panel_2dHingeVisibility = false;
                    _panelModel.Panel_ButtHingeVisibility = true;
                }
                else if (_panelModel.Panel_SashProfileArtNo != SashProfile_ArticleNo._395)
                {
                    _panelModel.Panel_2dHingeVisibility = true;
                    _panelModel.Panel_ButtHingeVisibility = false;
                }
            }
            else if (chk.Checked == false)
            {
                chk.Text = "No";
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCmbMotorized");
                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHandle");

                _panelModel.AdjustPropertyPanelHeight("minusCmbMotorized");
                _panelModel.AdjustPropertyPanelHeight("addHandle");
                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCmbMotorized");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHandle");
                }
                if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                {
                    if (_panelModel.Panel_MiddleCloserVisibility == false)
                    {
                        _panelModel.Panel_MiddleCloserVisibility = true;
                        _panelModel.AdjustPropertyPanelHeight("addMC");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMC");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMC");
                        }
                    }
                }

                if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                    _panelModel.AdjustPropertyPanelHeight("addRotoswing");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoswing");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                    _panelModel.AdjustPropertyPanelHeight("addRotary");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotary");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rio)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRio");
                    _panelModel.AdjustPropertyPanelHeight("addRio");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRio");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotoline)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRotoline");
                    _panelModel.AdjustPropertyPanelHeight("addRotoline");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRotoline");
                    }
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._MVD)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                    _panelModel.AdjustPropertyPanelHeight("addMVD");
                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMVD");
                    }
                }

                if (_panelModel.Panel_HandleType != Handle_Type._Rotary)
                {
                    if (_panelModel.Panel_EspagnoletteOptionsVisibility == false)
                    {
                        _panelModel.Panel_EspagnoletteOptionsVisibility = true;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");
                        _panelModel.AdjustPropertyPanelHeight("addEspagnolette");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addEspagnolette");
                        }
                    }
                }

                _panelModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");

                if (_panelModel.Panel_Type.Contains("Casement"))
                {

                    if (_panelModel.Panel_ExtensionOptionsVisibility == false)
                    {
                        _panelModel.Panel_ExtensionOptionsVisibility = true;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                        _panelModel.AdjustPropertyPanelHeight("addExtension");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                        }
                    }
                    for (int i = 0; i < fieldExtension_count; i++)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                        _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                        }
                    }

                    if (_panelModel.Panel_CornerDriveOptionsVisibility == false &&
                        _panelModel.Panel_ParentMultiPanelModel != null && 
                        (DMSelected == false &&
                         divChkDM == true &&
                        _panelModel.Panel_HandleType != Handle_Type._None))
                    {
                        _panelModel.Panel_CornerDriveOptionsVisibility = true;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                        _panelModel.AdjustPropertyPanelHeight("addCornerDrive");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                        }
                    }
                }
                else
                {
                    if (_panelModel.Panel_ExtensionOptionsVisibility == true)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                        _panelModel.AdjustPropertyPanelHeight("addExtension");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                        }

                        for (int i = 0; i < fieldExtension_count; i++)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                            _panelModel.AdjustPropertyPanelHeight("addExtensionField");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtensionField");
                            }
                        }
                        if (_panelModel.Panel_CornerDriveOptionsVisibility == false && _panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_CornerDriveOptionsVisibility = true;
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                            _panelModel.AdjustPropertyPanelHeight("addCornerDrive");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                            }
                        }
                    }
                }

                if (_panelModel.Panel_HingeOptionsVisibility == false)
                {
                    if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                    {
                        _panelModel.Panel_HingeOptionsVisibility = true;
                        _panelModel.AdjustPropertyPanelHeight("addHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                        }
                        propertiesScroll += const_var.panel_property_HingeOptionsheight;
                    }
                }

                if (_panelModel.Panel_CenterHingeOptionsVisibility == false)
                {
                    if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        _panelModel.Panel_CenterHingeOptionsVisibility = true;
                        _panelModel.AdjustPropertyPanelHeight("addCenterHinge");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");
                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");
                        }
                        propertiesScroll += const_var.panel_property_CenterHingeOptionsheight;

                        if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                        {
                            _panelModel.Panel_NTCenterHingeVisibility = true;
                            _panelModel.AdjustPropertyPanelHeight("addNTCenterHinge");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                            }
                            propertiesScroll += const_var.panel_property_NTCenterHingeOptionsheight;
                        }
                    }
                }
            }
            _mainPresenter.itemDescription();
            _mainPresenter.GetCurrentPrice();
            _mainPresenter.PropertiesScroll = propertiesScroll;
        }

        private void _pp_motorizedPropertyUC_PPMotorizedPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_motorizedPropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_MotorizedPropertyUC GetPPMotorizedPropertyUC()
        {
            return _pp_motorizedPropertyUC;
        }

        public IPP_MotorizedPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPP_MotorizedPropertyUC, PP_MotorizedPropertyUC>()
                .RegisterType<IPP_MotorizedPropertyUCPresenter, PP_MotorizedPropertyUCPresenter>();
            PP_MotorizedPropertyUCPresenter presenter = unityC.Resolve<PP_MotorizedPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;
            presenter._mainPresenter = mainPresenter;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_MotorizedOptionVisibility", new Binding("Checked", _panelModel, "Panel_MotorizedOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedOptionVisibility2", new Binding("Visible", _panelModel, "Panel_MotorizedOptionVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedMechArtNo", new Binding("Text", _panelModel, "Panel_MotorizedMechArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedPropertyHeight", new Binding("Height", _panelModel, "Panel_MotorizedPropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_MotorizedMechSetQty", new Binding("Value", _panelModel, "Panel_MotorizedMechSetQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_2DHingeQty", new Binding("Value", _panelModel, "Panel_2DHingeQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ButtHingeQty", new Binding("Value", _panelModel, "Panel_ButtHingeQty", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_2dHingeVisibility", new Binding("Visible", _panelModel, "Panel_2dHingeVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_ButtHingeVisibility", new Binding("Visible", _panelModel, "Panel_ButtHingeVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
