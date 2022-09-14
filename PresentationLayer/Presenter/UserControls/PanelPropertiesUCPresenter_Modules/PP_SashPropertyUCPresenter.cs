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
                if (sel_sash != curr_sash && _panelModel.Panel_Type.Contains("Fixed") == false)
                {
                    if (sel_sash == SashProfile_ArticleNo._7581 || sel_sash == SashProfile_ArticleNo._2067)
                    {
                        if (sel_sash == SashProfile_ArticleNo._2067)
                        {
                            _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._V226;
                        }
                        else
                        {
                            _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._R675;
                        }

                        if (_panelModel.Panel_MotorizedOptionVisibility == false)
                        {
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
                            else if (curr_sash == SashProfile_ArticleNo._373 || curr_sash == SashProfile_ArticleNo._374)
                            {
                                _panelModel.Panel_3dHingePropertyVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minus3dHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
                                }
                            }
                            else if (curr_sash == SashProfile_ArticleNo._6040 || curr_sash == SashProfile_ArticleNo._6041)
                            {
                                _panelModel.Panel_SlidingTypeVisibility = false;
                                _panelModel.Panel_RollersTypesVisibility = false;
                                _panelModel.Panel_AluminumTrackQtyVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusRollerType");
                                _panelModel.AdjustPropertyPanelHeight("minusSlidingType");
                                _panelModel.AdjustPropertyPanelHeight("minusAluminumTrackQty");

                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");

                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");
                                }
                            }
                            else if (curr_sash != SashProfile_ArticleNo._7581 && curr_sash != SashProfile_ArticleNo._2067)
                            {

                                _panelModel.Panel_HingeOptionsVisibility = true;
                                _panelModel.AdjustPropertyPanelHeight("addHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                                }

                                _panelModel.Panel_MiddleCloserVisibility = true;
                                _panelModel.AdjustPropertyPanelHeight("addMC");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMC");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMC");
                                }

                                if (_panelModel.Panel_HingeOptions == HingeOption._2DHinge)
                                {
                                    _panelModel.Panel_2dHingeVisibility_nonMotorized = true;
                                    _panelModel.AdjustPropertyPanelHeight("add2dHingeField");

                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "add2dHingeField");
                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "add2dHingeField");
                                    }
                                }
                            }

                        }
                        else if (_panelModel.Panel_MotorizedOptionVisibility == true)
                        {
                            _panelModel.Panel_2dHingeVisibility = true;
                            _panelModel.Panel_ButtHingeVisibility = false;
                        }
                    }
                    else if (sel_sash == SashProfile_ArticleNo._374 || sel_sash == SashProfile_ArticleNo._373)
                    {
                        if ((sel_sash == SashProfile_ArticleNo._374 && curr_sash != SashProfile_ArticleNo._373) ||
                            (sel_sash == SashProfile_ArticleNo._373 && curr_sash != SashProfile_ArticleNo._374))
                        {
                            _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._655;

                            if (_panelModel.Panel_MotorizedOptionVisibility == false)
                            {
                                _panelModel.Panel_3dHingePropertyVisibility = true;
                                _panelModel.AdjustPropertyPanelHeight("add3dHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "add3dHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "add3dHinge");
                                }

                                if (curr_sash == SashProfile_ArticleNo._7581 || sel_sash == SashProfile_ArticleNo._2067) //
                                {
                                    _panelModel.Panel_HingeOptionsVisibility = false;

                                    _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                    }

                                    _panelModel.Panel_MiddleCloserVisibility = false;

                                    _panelModel.AdjustPropertyPanelHeight("minusMC");
                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                    }

                                    if (_panelModel.Panel_HingeOptions == HingeOption._2DHinge)
                                    {
                                        _panelModel.Panel_2dHingeVisibility_nonMotorized = false;
                                        _panelModel.AdjustPropertyPanelHeight("minus2dHingeField");

                                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                        if (_panelModel.Panel_ParentMultiPanelModel != null)
                                        {
                                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
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
                                else if (curr_sash == SashProfile_ArticleNo._6040 || curr_sash == SashProfile_ArticleNo._6041)
                                {
                                    _panelModel.Panel_SlidingTypeVisibility = false;
                                    _panelModel.Panel_RollersTypesVisibility = false;
                                    _panelModel.Panel_AluminumTrackQtyVisibility = false;

                                    _panelModel.AdjustPropertyPanelHeight("minusRollerType");
                                    _panelModel.AdjustPropertyPanelHeight("minusSlidingType");
                                    _panelModel.AdjustPropertyPanelHeight("minusAluminumTrackQty");

                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");

                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");
                                    }
                                }
                            }
                            else if (_panelModel.Panel_MotorizedOptionVisibility == true)
                            {
                                _panelModel.Panel_2dHingeVisibility = true;
                                _panelModel.Panel_ButtHingeVisibility = false;
                            }
                        }
                    }
                    else if (sel_sash == SashProfile_ArticleNo._395)
                    {
                        _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._207;

                        if (_panelModel.Panel_MotorizedOptionVisibility == false)
                        {
                            if (curr_sash == SashProfile_ArticleNo._7581 || sel_sash == SashProfile_ArticleNo._2067)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                }

                                _panelModel.Panel_MiddleCloserVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusMC");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                }

                                if (_panelModel.Panel_HingeOptions == HingeOption._2DHinge)
                                {
                                    _panelModel.Panel_2dHingeVisibility_nonMotorized = false;
                                    _panelModel.AdjustPropertyPanelHeight("minus2dHingeField");

                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                    }
                                }
                            }
                            else if (curr_sash == SashProfile_ArticleNo._373 || curr_sash == SashProfile_ArticleNo._374)
                            {
                                _panelModel.Panel_3dHingePropertyVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minus3dHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
                                }
                            }
                            else if (curr_sash == SashProfile_ArticleNo._6040 || curr_sash == SashProfile_ArticleNo._6041)
                            {
                                _panelModel.Panel_SlidingTypeVisibility = false;
                                _panelModel.Panel_RollersTypesVisibility = false;
                                _panelModel.Panel_AluminumTrackQtyVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusRollerType");
                                _panelModel.AdjustPropertyPanelHeight("minusSlidingType");
                                _panelModel.AdjustPropertyPanelHeight("minusAluminumTrackQty");

                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");

                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");
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
                        else if (_panelModel.Panel_MotorizedOptionVisibility == true)
                        {
                            _panelModel.Panel_2dHingeVisibility = false;
                            _panelModel.Panel_ButtHingeVisibility = true;
                        }
                    }
                    else if (sel_sash == SashProfile_ArticleNo._6040)
                    {
                        _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._TV104;

                        if (_panelModel.Panel_MotorizedOptionVisibility == false)
                        {
                            if (curr_sash == SashProfile_ArticleNo._7581 || sel_sash == SashProfile_ArticleNo._2067)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                }

                                _panelModel.Panel_MiddleCloserVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusMC");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                }

                                if (_panelModel.Panel_HingeOptions == HingeOption._2DHinge)
                                {
                                    _panelModel.Panel_2dHingeVisibility_nonMotorized = false;
                                    _panelModel.AdjustPropertyPanelHeight("minus2dHingeField");

                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                    }
                                }
                            }
                            else if (curr_sash == SashProfile_ArticleNo._373 || curr_sash == SashProfile_ArticleNo._374)
                            {
                                _panelModel.Panel_3dHingePropertyVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minus3dHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
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
                            else if (curr_sash == SashProfile_ArticleNo._6041)
                            {
                                _panelModel.Panel_SlidingTypeVisibility = false;
                                _panelModel.Panel_RollersTypesVisibility = false;
                                _panelModel.Panel_AluminumTrackQtyVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusRollerType");
                                _panelModel.AdjustPropertyPanelHeight("minusSlidingType");
                                _panelModel.AdjustPropertyPanelHeight("minusAluminumTrackQty");

                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");

                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");
                                }
                            }

                            _panelModel.Panel_SlidingTypeVisibility = true;
                            _panelModel.Panel_RollersTypesVisibility = true;
                            _panelModel.Panel_AluminumTrackQtyVisibility = true;

                            _panelModel.AdjustPropertyPanelHeight("addRollerType");
                            _panelModel.AdjustPropertyPanelHeight("addSlidingType");
                            _panelModel.AdjustPropertyPanelHeight("addAluminumTrackQty");

                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addSlidingType");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRollerType");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addAluminumTrackQty");

                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addSlidingType");
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRollerType");
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addAluminumTrackQty");
                            }

                        }
                        else if (_panelModel.Panel_MotorizedOptionVisibility == true)
                        {
                            //do something 
                        }
                    }
                    else if (sel_sash == SashProfile_ArticleNo._6041)
                    {
                        _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._TV106;

                        if (_panelModel.Panel_MotorizedOptionVisibility == false)
                        {
                            if (curr_sash == SashProfile_ArticleNo._7581 || sel_sash == SashProfile_ArticleNo._2067)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                                }

                                _panelModel.Panel_MiddleCloserVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusMC");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMC");
                                }

                                if (_panelModel.Panel_HingeOptions == HingeOption._2DHinge)
                                {
                                    _panelModel.Panel_2dHingeVisibility_nonMotorized = false;
                                    _panelModel.AdjustPropertyPanelHeight("minus2dHingeField");

                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                                    {
                                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus2dHingeField");
                                    }
                                }
                            }
                            else if (curr_sash == SashProfile_ArticleNo._373 || curr_sash == SashProfile_ArticleNo._374)
                            {
                                _panelModel.Panel_3dHingePropertyVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minus3dHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minus3dHinge");
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
                            else if (curr_sash == SashProfile_ArticleNo._6040)
                            {
                                _panelModel.Panel_SlidingTypeVisibility = false;
                                _panelModel.Panel_RollersTypesVisibility = false;
                                _panelModel.Panel_AluminumTrackQtyVisibility = false;

                                _panelModel.AdjustPropertyPanelHeight("minusRollerType");
                                _panelModel.AdjustPropertyPanelHeight("minusSlidingType");
                                _panelModel.AdjustPropertyPanelHeight("minusAluminumTrackQty");

                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");

                                if (_panelModel.Panel_ParentMultiPanelModel != null)
                                {
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSlidingType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRollerType");
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusAluminumTrackQty");
                                }
                            }

                            _panelModel.Panel_SlidingTypeVisibility = true;
                            _panelModel.Panel_RollersTypesVisibility = true;
                            _panelModel.Panel_AluminumTrackQtyVisibility = true;

                            _panelModel.AdjustPropertyPanelHeight("addRollerType");
                            _panelModel.AdjustPropertyPanelHeight("addSlidingType");
                            _panelModel.AdjustPropertyPanelHeight("addAluminumTrackQty");

                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addSlidingType");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addRollerType");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addAluminumTrackQty");

                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addSlidingType");
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addRollerType");
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addAluminumTrackQty");
                            }
                        }
                        else if (_panelModel.Panel_MotorizedOptionVisibility == true)
                        {
                            //do something 
                        }
                    }
                    curr_sash = sel_sash;
                }
            }
        }

        private void _pp_sashPropertyUC_PPSashPropertyLoadEventRaised(object sender, EventArgs e)
        {
            _pp_sashPropertyUC.ThisBinding(CreateBindingDictionary());
            if (_panelModel.Panel_Type.Contains("Fixed") == false)
            {
                curr_sash = SashProfile_ArticleNo._7581;
                _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._7581;
                _panelModel.Panel_2dHingeVisibility = true;
                _panelModel.Panel_ButtHingeVisibility = false;
            }
            else
            {
                curr_sash = SashProfile_ArticleNo._None;
                _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._None;
                _panelModel.Panel_2dHingeVisibility = false;
                _panelModel.Panel_ButtHingeVisibility = false;
            }

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
