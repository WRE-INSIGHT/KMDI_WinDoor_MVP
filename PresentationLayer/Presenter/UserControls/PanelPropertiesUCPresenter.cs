using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls
{
    public class PanelPropertiesUCPresenter : IPanelPropertiesUCPresenter, IPresenterCommon
    {
        IPanelPropertiesUC _panelPropertiesUC;
        
        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IPP_MotorizedPropertyUCPresenter _pp_motorizedPropertyUCPresenter;
        private IPP_SashPropertyUCPresenter _pp_sashPropertyUCPresenter;
        private IPP_GlassPropertyUCPresenter _pp_glassPropertyUCPresenter;
        private IPP_HandlePropertyUCPresenter _pp_handlePropertUCPresenter;
        private IPP_GeorgianBarPropertyUCPresenter _pp_georgianBarPropertUCPresenter;
        private IPP_ExtensionPropertyUCPresenter _pp_extensionPropertyUCPresenter;
        private IPP_CornerDrivePropertyUCPresenter _pp_cornerDrivePropertyUCPresenter;
        private IPP_HingePropertyUCPresenter _pp_hingePropertyUCPresenter;
        private IPP_CenterHingePropertyUCPresenter _pp_centerHingePropertyUCPresenter;
        private IPP_NTCenterHingePropertyUCPresenter _pp_ntCenterHingePropertyUCPresenter;
        private IPP_3dHingePropertyUCPresenter _pp_3dHingePropertyUCPresenter;
        private IPP_2dHingePropertyUCPresenter _pp_2dHingePropertyUCPresenter;
        private IPP_MiddleCloserPropertyUCPresenter _pp_middleCloserPropertyUCP;
        private IPP_SlidingTypePropertyUCPresenter _pp_slidingTypePropertyUCP;
        private IPP_RollerPropertyUCPresenter _pp_rollerPropertyUCPresenter;
        private IPP_AliminumTrackPropertyUCPresenter _pp_AliminumTrackPropertyUCPresenter;
        private IPP_LouverBladesPropertyUCPresenter _pp_louverBladesPropertyUCPresenter;

        private IUnityContainer _unityC;

        private Panel _pnlPanelSpecs;

        public PanelPropertiesUCPresenter(IPanelPropertiesUC panelPropertiesUC,
                                          IPP_MotorizedPropertyUCPresenter pp_motorizedPropertyUCPresenter,
                                          IPP_SashPropertyUCPresenter pp_sashPropertyUCPresenter,
                                          IPP_GlassPropertyUCPresenter pp_glassPropertyUCPresenter,
                                          IPP_HandlePropertyUCPresenter pp_handlePropertUCPresenter,
                                          IPP_GeorgianBarPropertyUCPresenter pp_georgianBarPropertUCPresenter,
                                          IPP_ExtensionPropertyUCPresenter pp_extensionPropertyUCPresenter,
                                          IPP_CornerDrivePropertyUCPresenter pp_cornerDrivePropertyUCPresenter,
                                          IPP_HingePropertyUCPresenter pp_hingePropertyUCPresenter,
                                          IPP_CenterHingePropertyUCPresenter pp_centerHingePropertyUCPresenter,
                                          IPP_NTCenterHingePropertyUCPresenter pp_ntCenterHingePropertyUCPresenter,
                                          IPP_3dHingePropertyUCPresenter pp_3dHingePropertyUCPresenter,
                                          IPP_2dHingePropertyUCPresenter pp_2dHingePropertyUCPresenter,
                                          IPP_MiddleCloserPropertyUCPresenter pp_middleCloserPropertyUCP,
                                          IPP_SlidingTypePropertyUCPresenter pp_slidingTypePropertyUCP,
                                          IPP_RollerPropertyUCPresenter pp_rollerPropertyUCPresenter,
                                          IPP_AliminumTrackPropertyUCPresenter pp_AliminumTrackPropertyUCPresenter,
                                          IPP_LouverBladesPropertyUCPresenter pp_louverBladesPropertyUCPresenter)
        {
            _panelPropertiesUC = panelPropertiesUC;
            _pp_motorizedPropertyUCPresenter = pp_motorizedPropertyUCPresenter;
            _pp_sashPropertyUCPresenter = pp_sashPropertyUCPresenter;
            _pp_glassPropertyUCPresenter = pp_glassPropertyUCPresenter;
            _pp_handlePropertUCPresenter = pp_handlePropertUCPresenter;
            _pp_georgianBarPropertUCPresenter = pp_georgianBarPropertUCPresenter;
            _pp_extensionPropertyUCPresenter = pp_extensionPropertyUCPresenter;
            _pp_cornerDrivePropertyUCPresenter = pp_cornerDrivePropertyUCPresenter;
            _pp_hingePropertyUCPresenter = pp_hingePropertyUCPresenter;
            _pp_centerHingePropertyUCPresenter = pp_centerHingePropertyUCPresenter;
            _pp_ntCenterHingePropertyUCPresenter = pp_ntCenterHingePropertyUCPresenter;
            _pp_3dHingePropertyUCPresenter = pp_3dHingePropertyUCPresenter;
            _pp_2dHingePropertyUCPresenter = pp_2dHingePropertyUCPresenter;
            _pp_middleCloserPropertyUCP = pp_middleCloserPropertyUCP;
            _pnlPanelSpecs = _panelPropertiesUC.GetPanelSpecsPNL();
            _pp_slidingTypePropertyUCP = pp_slidingTypePropertyUCP;
            _pp_rollerPropertyUCPresenter = pp_rollerPropertyUCPresenter;
            _pp_AliminumTrackPropertyUCPresenter = pp_AliminumTrackPropertyUCPresenter;
            _pp_louverBladesPropertyUCPresenter = pp_louverBladesPropertyUCPresenter;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _panelPropertiesUC.PanelPropertiesLoadEventRaised += new EventHandler(OnPanelPropertiesLoadEventRaised);
            _panelPropertiesUC.ChkOrientationCheckChangedEventRaised += _panelPropertiesUC_ChkOrientationCheckChangedEventRaised;
        }

        bool chkOrient_state, adjust_bool;
        private void _panelPropertiesUC_ChkOrientationCheckChangedEventRaised(object sender, EventArgs e)
        {

            MessageBox.Show(((UserControl)_panelPropertiesUC).Parent.Name);
            CheckBox chk = (CheckBox)sender;

            _panelModel.Panel_Orient = chk.Checked;

            if (chkOrient_state != chk.Checked)
            {
                adjust_bool = true;
                chkOrient_state = chk.Checked;

                if (adjust_bool == true)
                {
                    if (_panelModel.Panel_ParentFrameModel != null)
                    {
                        if (chk.Text == "None" && chk.Checked == false)
                        {
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusSash");
                            _panelModel.AdjustPropertyPanelHeight("minusSash");

                            if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minusHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                            }
                            else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                _panelModel.Panel_CenterHingeOptionsVisibility = false;
                                _panelModel.AdjustPropertyPanelHeight("minusCenterHinge");
                                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");

                                if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                {
                                    _panelModel.Panel_NTCenterHingeVisibility = false;
                                    _panelModel.AdjustPropertyPanelHeight("minusNTCenterHinge");
                                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                }
                            }
                        }
                        else if (chk.Text == "dSash" && chk.Checked == true)
                        {
                            _panelModel.AdjustPropertyPanelHeight("addSash");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addSash");

                            if (_panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("C70"))
                            {
                                if (_panelModel.Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                                {
                                    _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._7581;
                                    _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._R675;
                                }
                                else if (_panelModel.Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                                {
                                    _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._374;
                                    _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._207;
                                }
                            }
                            else if (_panelModel.Panel_ParentFrameModel.Frame_WindoorModel.WD_profile.Contains("PremiLine"))
                            {
                                if (_panelModel.Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                                {
                                    _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._6040;
                                    _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._TV104;
                                }
                                else if (_panelModel.Panel_ParentFrameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                                {
                                    _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._6041;
                                    _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._TV106;
                                }
                                _panelModel.PanelGlazingBead_ArtNo = GlazingBead_ArticleNo._2436;
                            }


                            //if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            //{
                            //    _panelModel.Panel_HingeOptionsVisibility = true;
                            //    _panelModel.AdjustPropertyPanelHeight("addHinge");
                            //    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                            //}
                            //else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            //{
                            //    _panelModel.Panel_CenterHingeOptionsVisibility = true;
                            //    _panelModel.AdjustPropertyPanelHeight("addCenterHinge");
                            //    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");

                            //    if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                            //    {
                            //        _panelModel.Panel_NTCenterHingeVisibility = true;
                            //        _panelModel.AdjustPropertyPanelHeight("addNTCenterHinge");
                            //        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                            //    }
                            //}
                        }
                        adjust_bool = false;
                    }

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        if (chk.Text == "None" && chk.Checked == false)
                        {


                            #region Fixed Window

                            if (_panelModel.Panel_Type.Contains("Fixed"))
                            {
                                var flp = (Control)_panelModel.Panel_Parent; //MultiPanel Container
                                Control fixedUC = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects.Find(pnl => pnl.Name == _panelModel.Panel_Name);
                                if (flp.Name.Contains("MultiMullion"))
                                {
                                    int expected_total_controls_inside_parentMpanel = _panelModel.Panel_ParentMultiPanelModel.MPanel_Divisions + 1, // count of object
                                        actual_total_controls_inside_parentMpanel = _panelModel.Panel_ParentMultiPanelModel.GetCount_MPanelLst_Object(),
                                        totalpanel_inside_parentMpanel = _panelModel.Panel_ParentMultiPanelModel.MPanel_Divisions + 1;
                                    if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                                    {
                                        _mainPresenter.SetChangesMark();
                                        int me_indx = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects.IndexOf((Control)fixedUC);
                                        //Get Panel from left side of Mullion
                                        Control pres_ctrl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects[me_indx];

                                        if (_panelModel.Panel_ParentMultiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                                        {
                                            //Get Panel from right side of Mullion
                                            pres_ctrl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Objects[me_indx];
                                        }
                                        IPanelModel pres_pnl = null;
                                        int sashDiv = 16 / (_panelModel.Panel_ParentMultiPanelModel.MPanel_Divisions + 1);
                                        //Get the expected Panel w
                                        if (pres_ctrl is IPanelUC)
                                        {
                                            pres_pnl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);
                                        }
                                        if (_panelModel.Panel_Overlap_Sash == OverlapSash._Left || _panelModel.Panel_Overlap_Sash == OverlapSash._Right)
                                        {
                                            _panelModel.Panel_Overlap_Sash = OverlapSash._None;
                                            if (pres_ctrl is IPanelUC)
                                            {
                                                pres_pnl.Panel_Width += 16;
                                                pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                            }
                                            foreach (IPanelModel pnl in _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel)
                                            {
                                                if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Left && pnl.Panel_Name != pres_pnl.Panel_Name)
                                                {
                                                    pnl.Panel_Width -= (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                                                }
                                                else
                                                {
                                                    pnl.Panel_Width -= sashDiv;
                                                }
                                                pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                                pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                            }
                                            _panelModel.Panel_ParentMultiPanelModel.SetZoomPanels();
                                        }
                                        else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                                        {
                                            _panelModel.Panel_Overlap_Sash = OverlapSash._None;
                                            if (pres_ctrl is IPanelUC)
                                            {
                                                pres_pnl.Panel_Width += 32;
                                            }
                                            foreach (IPanelModel pnl in _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel)
                                            {

                                                if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Left && pnl.Panel_Name != pres_pnl.Panel_Name)
                                                {
                                                    pnl.Panel_Width -= (int)Math.Ceiling((decimal)32 / totalpanel_inside_parentMpanel);
                                                }
                                                else
                                                {
                                                    pnl.Panel_Width -= 32 / totalpanel_inside_parentMpanel;
                                                }

                                                pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                                pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                            }
                                            _panelModel.Panel_ParentMultiPanelModel.SetZoomPanels();
                                        }

                                        pres_pnl = _panelModel.Panel_ParentMultiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Overlap_Sash != OverlapSash._None);
                                        if (pres_pnl == null)
                                        {
                                            _panelModel.Panel_ParentMultiPanelModel.Fit_EqualPanel_ToBindDimensions();
                                        }
                                        _panelModel.Panel_ParentMultiPanelModel.Fit_MyControls_ToBindDimensions();
                                        _panelModel.Panel_ParentMultiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                                        _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                                    }
                                }
                                _panelModel.Panel_Overlap_Sash = OverlapSash._None;
                                ((IPanelUC)fixedUC).InvalidateThis();
                            }
                            #endregion

                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSash");

                            if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = false;
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                            }
                            else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                _panelModel.Panel_CenterHingeOptionsVisibility = false;
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCenterHinge");

                                if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                {
                                    _panelModel.Panel_NTCenterHingeVisibility = true;
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusNTCenterHinge");
                                }
                            }
                        }
                        else if (chk.Text == "dSash" && chk.Checked == true)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addSash");

                            if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581)
                            {
                                _panelModel.Panel_HingeOptionsVisibility = true;
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                            }
                            else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                            {
                                _panelModel.Panel_CenterHingeOptionsVisibility = true;
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");

                                if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                                {
                                    _panelModel.Panel_NTCenterHingeVisibility = true;
                                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                                }
                            }
                        }
                        adjust_bool = false;
                    }
                }
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
            _mainPresenter.GetCurrentPrice();
        }

        private void OnPanelPropertiesLoadEventRaised(object sender, EventArgs e)
        {
            try
            {

                _panelPropertiesUC.ThisBinding(CreateBindingDictionary());

                if ((_panelModel.Panel_Type.Contains("Fixed") == false && _panelModel.Panel_Type.Contains("Louver") == false) && _panelModel.Panel_Type.Contains("Sliding") == false &&
                     _panelModel.Panel_HingeOptions == HingeOption._FrictionStay)
                {
                    _panelModel.Panel_MiddleCloserVisibility = true;

                    _panelModel.AdjustPropertyPanelHeight("addMC");
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addMC");

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addMC");
                    }
                }

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "add");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "add");

                    if (_panelModel.Panel_Type.Contains("Louver") == false)
                    {
                        _panelModel.AdjustPropertyPanelHeight("addGlass");
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addGlass");
                    }
                }

                if ((_panelModel.Panel_Type.Contains("Fixed") == false && _panelModel.Panel_Type.Contains("Louver") == false) ||
                    _panelModel.Panel_SashPropertyVisibility == true)
                {
                    if (_panelModel.Panel_ParentFrameModel != null && _panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Type.Contains("Awning") || _panelModel.Panel_Type.Contains("TiltNTurn") || _panelModel.Panel_Type.Contains("Sliding"))
                        {
                            _panelModel.AdjustPropertyPanelHeight("addSash");

                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addSash");
                        }
                    }

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addSash");
                    }
                }

                if (_panelModel.Panel_Type.Contains("Fixed") == false && _panelModel.Panel_Type.Contains("Louver") == false)
                {
                    if (_panelModel.Panel_ParentFrameModel != null && _panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Type.Contains("Awning") || _panelModel.Panel_Type.Contains("TiltNTurn") || _panelModel.Panel_Type.Contains("Sliding"))
                        {
                            _panelModel.AdjustPropertyPanelHeight("addChkMotorized");
                            _panelModel.AdjustPropertyPanelHeight("addHandle");
                            _panelModel.AdjustMotorizedPropertyHeight("chkMotorizedOnly");

                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHandle");
                        }
                    }

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addChkMotorized");
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHandle");
                    }
                }

                if (_panelModel.Panel_Type.Contains("Sliding"))
                {
                    IPP_SlidingTypePropertyUCPresenter slidingTypePresenter = _pp_slidingTypePropertyUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl slidingTypeUCPresenter = (UserControl)slidingTypePresenter.GetSlidingTypePropertyUC();
                    _pnlPanelSpecs.Controls.Add(slidingTypeUCPresenter);
                    slidingTypeUCPresenter.Dock = DockStyle.Top;
                    slidingTypeUCPresenter.BringToFront();
                }

                IPP_SashPropertyUCPresenter sashPropUCP = _pp_sashPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                UserControl sashProp = (UserControl)sashPropUCP.GetPPSashPropertyUC();
                _pnlPanelSpecs.Controls.Add(sashProp);
                sashProp.Dock = DockStyle.Top;
                sashProp.BringToFront();

                if (_panelModel.Panel_Type.Contains("Casement") || _panelModel.Panel_Type.Contains("Awning") || _panelModel.Panel_Type.Contains("TiltNTurn"))
                {
                    _panelModel.Panel_HingeOptionsVisibility = true;


                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addHinge");
                    _panelModel.AdjustPropertyPanelHeight("addHinge");

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addHinge");
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

                    if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
                        _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                    {
                        _panelModel.Panel_CenterHingeOptionsVisibility = false;

                        if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
                        {
                            _panelModel.Panel_3dHingePropertyVisibility = true;

                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "add3dHinge");
                            _panelModel.AdjustPropertyPanelHeight("add3dHinge");

                            if (_panelModel.Panel_ParentMultiPanelModel != null)
                            {
                                _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "add3dHinge");
                            }
                        }
                    }
                    else if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                    {
                        _panelModel.Panel_CenterHingeOptionsVisibility = true;
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCenterHinge");
                        _panelModel.AdjustPropertyPanelHeight("addCenterHinge");

                        if (_panelModel.Panel_CenterHingeOptions == CenterHingeOption._NTCenterHinge)
                        {
                            _panelModel.Panel_NTCenterHingeVisibility = true;
                            _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addNTCenterHinge");
                            _panelModel.AdjustPropertyPanelHeight("addNTCenterHinge");
                        }
                    }
                }



                if (!_panelModel.Panel_Type.Contains("Sliding"))
                {
                    IPP_HingePropertyUCPresenter hingePropUCP = _pp_hingePropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl hingeProp = (UserControl)hingePropUCP.GetPP_HingePropertyUC();
                    _pnlPanelSpecs.Controls.Add(hingeProp);
                    hingeProp.Dock = DockStyle.Top;
                    hingeProp.BringToFront();


                    IPP_2dHingePropertyUCPresenter _2dHingePropUCP = _pp_2dHingePropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl _2dhingeProp = (UserControl)_2dHingePropUCP.GetPP_2dHingePropertyUC();
                    _pnlPanelSpecs.Controls.Add(_2dhingeProp);
                    _2dhingeProp.Dock = DockStyle.Top;
                    _2dhingeProp.BringToFront();

                    IPP_CenterHingePropertyUCPresenter centerHingePropUCP = _pp_centerHingePropertyUCPresenter.GetNewInstance(_panelModel, _unityC);
                    UserControl centerHingeProp = (UserControl)centerHingePropUCP.GetCenterHingePropertyUC();
                    _pnlPanelSpecs.Controls.Add(centerHingeProp);
                    centerHingeProp.Dock = DockStyle.Top;
                    centerHingeProp.BringToFront();

                    IPP_NTCenterHingePropertyUCPresenter ntcenterHingePropUCP = _pp_ntCenterHingePropertyUCPresenter.GetNewInstance(_panelModel, _unityC);
                    UserControl ntcenterHingeProp = (UserControl)ntcenterHingePropUCP.GetNTCenterHingePropertyUC();
                    _pnlPanelSpecs.Controls.Add(ntcenterHingeProp);
                    ntcenterHingeProp.Dock = DockStyle.Top;
                    ntcenterHingeProp.BringToFront();

                }
                if (_panelModel.Panel_SashPropertyVisibility == true)
                {
                    IPP_MotorizedPropertyUCPresenter motorizedPropUCP = _pp_motorizedPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl motorized = (UserControl)motorizedPropUCP.GetPPMotorizedPropertyUC();
                    _pnlPanelSpecs.Controls.Add(motorized);
                    motorized.Dock = DockStyle.Top;
                    motorized.BringToFront();

                    IPP_HandlePropertyUCPresenter handlePropUCP = _pp_handlePropertUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl handle = (UserControl)handlePropUCP.GetPPHandlePropertyUC();
                    _pnlPanelSpecs.Controls.Add(handle);
                    handle.Dock = DockStyle.Top;
                    handle.BringToFront();

                    if (!_panelModel.Panel_Type.Contains("Sliding"))
                    {
                        IPP_MiddleCloserPropertyUCPresenter mcUCP = _pp_middleCloserPropertyUCP.GetNewInstance(_panelModel, _unityC, _mainPresenter);
                        UserControl mc = (UserControl)mcUCP.GetMiddleCloserPropertyUC();
                        _pnlPanelSpecs.Controls.Add(mc);
                        mc.Dock = DockStyle.Top;
                        mc.BringToFront();


                        IPP_3dHingePropertyUCPresenter _3dPropUCP = _pp_3dHingePropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                        UserControl _3dprop = (UserControl)_3dPropUCP.GetPP_3dHingePropertyUC();
                        _pnlPanelSpecs.Controls.Add(_3dprop);
                        _3dprop.Dock = DockStyle.Top;
                        _3dprop.BringToFront();



                        IPP_CornerDrivePropertyUCPresenter cdPropUCP = _pp_cornerDrivePropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                        UserControl cdPropUC = (UserControl)cdPropUCP.GetPPCornerDriveUC();
                        _pnlPanelSpecs.Controls.Add(cdPropUC);
                        cdPropUC.Dock = DockStyle.Top;
                        cdPropUC.BringToFront();


                        IPP_ExtensionPropertyUCPresenter extPropUCP = _pp_extensionPropertyUCPresenter.GetNewInstance(_unityC, _panelModel);
                        UserControl extPropUC = (UserControl)extPropUCP.GetPPExtensionUC();
                        _pnlPanelSpecs.Controls.Add(extPropUC);
                        extPropUC.Dock = DockStyle.Top;
                        extPropUC.BringToFront();
                    }

                }


                if (_panelModel.Panel_Type.Contains("Sliding"))
                {
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

                    IPP_RollerPropertyUCPresenter rollerTypePresenter = _pp_rollerPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl rollerTypeUCPresenter = (UserControl)rollerTypePresenter.GetRollerTypePropertyUC();
                    _pnlPanelSpecs.Controls.Add(rollerTypeUCPresenter);
                    rollerTypeUCPresenter.Dock = DockStyle.Top;
                    rollerTypeUCPresenter.BringToFront();

                    IPP_AliminumTrackPropertyUCPresenter alumTrackQtyPresenter = _pp_AliminumTrackPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    UserControl alumTrackQtyUCPresenter = (UserControl)alumTrackQtyPresenter.GetAliminumTrackPropertyUC();
                    _pnlPanelSpecs.Controls.Add(alumTrackQtyUCPresenter);
                    alumTrackQtyUCPresenter.Dock = DockStyle.Top;
                    alumTrackQtyUCPresenter.BringToFront();

                }


                if (_panelModel.Panel_Type.Contains("Casement"))
                {
                    _panelModel.Panel_ExtensionOptionsVisibility = true;

                    if (_panelModel.Panel_CornerDriveOptionsVisibility)
                    {
                        _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                        _panelModel.AdjustPropertyPanelHeight("addCornerDrive");
                    }
                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                    _panelModel.AdjustPropertyPanelHeight("addExtension");

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        if (_panelModel.Panel_CornerDriveOptionsVisibility)
                        {
                            _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                        }
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                    }
                }


                if (_panelModel.Panel_Type.Contains("Louver") == true)
                {
                    //_panelModel.AdjustPropertyPanelHeight("minusLouver");
                    //_panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusLouver");
                    _panelModel.Panel_LouverBladesVisibility = true;

                    _panelModel.AdjustPropertyPanelHeight("addLouverBlades");

                    _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addLouverBlades");

                    if (_panelModel.Panel_ParentMultiPanelModel != null)
                    {
                        _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addLouverBlades");
                    }
                    IPP_LouverBladesPropertyUCPresenter blades = _pp_louverBladesPropertyUCPresenter.CreateNewInstance(_unityC, _panelModel);
                    UserControl bladesProp = (UserControl)blades.GetIPP_LouverBladesPropertyUC();
                    _pnlPanelSpecs.Controls.Add(bladesProp);
                    bladesProp.Dock = DockStyle.Top;
                    bladesProp.BringToFront();
                }
                
                IPP_GlassPropertyUCPresenter glassPropUCP = _pp_glassPropertyUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                UserControl glassProp = (UserControl)glassPropUCP.GetPPGlassPropertyUC();
                _pnlPanelSpecs.Controls.Add(glassProp);
                glassProp.Dock = DockStyle.Top;
                glassProp.BringToFront();
                //glassProp.Height = 30;


                IPP_GeorgianBarPropertyUCPresenter gbarPropUCP = _pp_georgianBarPropertUCPresenter.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                UserControl gbarProp = (UserControl)gbarPropUCP.GetPPGeorgianBarPropertyUC();
                _pnlPanelSpecs.Controls.Add(gbarProp);
                gbarProp.Dock = DockStyle.Top;
                gbarProp.BringToFront();

                chkOrient_state = _panelModel.Panel_Orient;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            panelBinding.Add("Panel_OrientVisibility", new Binding("Visible", _panelModel, "Panel_OrientVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlass_ID", new Binding("PanelGlass_ID", _panelModel, "PanelGlass_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_PropertyHeight", new Binding("Height", _panelModel, "Panel_PropertyHeight", true, DataSourceUpdateMode.OnPropertyChanged));

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
