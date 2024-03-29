﻿using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Variables;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class MullionUCPresenter : IMullionUCPresenter, IPresenterCommon
    {
        IMullionUC _mullionUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;
        private ConstantVariables constants = new ConstantVariables();
        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IMainPresenter _mainPresenter;
        //private IBasePlatformImagerUCPresenter _basePlatformImagerUCP;

        bool _mouseDown, //_initialLoad, 
            _keydown;
        private Point _point_of_origin;

        CommonFunctions _commonfunc = new CommonFunctions();

        public bool boolKeyDown
        {
            set
            {
                _keydown = value;
            }
        }

        public MullionUCPresenter(IMullionUC mullionUC)
        {
            _mullionUC = mullionUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _mullionUC.mullionUCMouseDownEventRaised += _mullionUC_mullionUCMouseDownEventRaised;
            _mullionUC.mullionUCMouseMoveEventRaised += _mullionUC_mullionUCMouseMoveEventRaised;
            _mullionUC.mullionUCMouseUpEventRaised += _mullionUC_mullionUCMouseUpEventRaised;
            _mullionUC.mullionUCPaintEventRaised += _mullionUC_mullionUCPaintEventRaised;
            _mullionUC.mullionUCMouseEnterEventRaised += _mullionUC_mullionUCMouseEnterEventRaised;
            _mullionUC.mullionUCMouseLeaveEventRaised += _mullionUC_mullionUCMouseLeaveEventRaised;
            _mullionUC.mullionUCSizeChangedEventRaised += _mullionUC_mullionUCSizeChangedEventRaised;
            _mullionUC.mullionUCKeyDownEventRaised += _mullionUC_mullionUCKeyDownEventRaised;
            _mullionUC.mullionUCMouseDoubleClickedEventRaised += _mullionUC_mullionUCMouseDoubleClickedEventRaised;
            _mullionUC.mullionUCMouseClickEventRaised += _mullionUC_mullionUCMouseClickEventRaised;
        }
        private UserControl mullionUC;
        private void _mullionUC_mullionUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                Console.WriteLine(" " + _divModel.Div_WidthToBind);
                mullionUC = (UserControl)sender;
                Console.WriteLine(mullionUC.Width);
                Console.WriteLine();
                IWindoorModel wdm = _frameModel.Frame_WindoorModel;
                int propertyHeight = 0;
                int framePropertyHeight = 0;
                int concretePropertyHeight = 0;
                int mpnlPropertyHeight = 0;
                int pnlPropertyHeight = 0;
                int divPropertyHeight = 0;
                foreach (Control wndrObject in wdm.lst_objects)
                {
                    if (wndrObject.Name.Contains("Frame"))
                    {
                        #region FrameModel
                        foreach (FrameModel frm in wdm.lst_frame)
                        {
                            if (frm.Frame_Name == wndrObject.Name)
                            {
                                framePropertyHeight += constants.frame_propertyHeight_default;
                                if (_frameModel.Frame_BotFrameVisible == true)
                                {
                                    framePropertyHeight += constants.frame_botframeproperty_PanelHeight;
                                }
                                if (_frameModel.Frame_SlidingRailsQtyVisibility == true)
                                {
                                    framePropertyHeight += constants.frame_SlidingRailsQtyproperty_PanelHeight;
                                }
                                if (_frameModel.Frame_ConnectionTypeVisibility == true && _frameModel.Frame_ArtNo == FrameProfile_ArticleNo._6052)
                                {
                                    framePropertyHeight += constants.frame_ConnectionTypeproperty_PanelHeight;
                                }
                                if (_frameModel.Frame_ScreenVisibility == true)
                                {
                                    framePropertyHeight += constants.frame_ScreenHeightProperty_PanelHeight;
                                    if (_frameModel.Frame_ScreenOption == true)
                                    {
                                        framePropertyHeight += constants.frame_ScreenHeightProperty_PanelHeight;
                                    }
                                }
                                #region  Frame Panel
                                //foreach (PanelModel pnl in frm.Lst_Panel)
                                //{
                                //    if (pnl.Panel_Name == casementUC.Name)
                                //    {
                                //        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 8;
                                //        return;
                                //    }
                                //}
                                #endregion
                                #region 2nd Level MultiPanel
                                foreach (MultiPanelModel mpnl in frm.Lst_MultiPanel)
                                {
                                    mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                    foreach (Control ctrl in mpnl.MPanelLst_Objects)
                                    {
                                        if (ctrl.Name.Contains("PanelUC"))
                                        {
                                            #region 2nd Level MultiPanel Panel
                                            foreach (PanelModel pnl in mpnl.MPanelLst_Panel)
                                            {
                                                if (ctrl.Name == pnl.Panel_Name)
                                                {
                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                    break;
                                                }
                                            }
                                            #endregion

                                        }
                                        else if (ctrl.Name.Contains("MullionUC") || ctrl.Name.Contains("TransomUC"))
                                        {
                                            #region 2nd Level MultiPanel Divider
                                            foreach (DividerModel div in mpnl.MPanelLst_Divider)
                                            {
                                                if (ctrl.Name == div.Div_Name)
                                                {
                                                    if(div.Div_Name == mullionUC.Name)
                                                    {
                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 11;
                                                        return;
                                                    }else
                                                    {
                                                        divPropertyHeight += div.Div_PropHeight;
                                                    }
                                                }
                                                
                                            }
                                            #endregion

                                        }
                                        else if (ctrl.Name.Contains("MultiTransom") || ctrl.Name.Contains("MultiMullion"))
                                        {

                                            #region 2nd Level MultiPanel MultiPanel

                                            foreach (MultiPanelModel thirdlvlmpnl in mpnl.MPanelLst_MultiPanel)
                                            {
                                                if (ctrl.Name == thirdlvlmpnl.MPanel_Name)
                                                {
                                                    mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                    foreach (Control thirdlvlctrl in thirdlvlmpnl.MPanelLst_Objects)
                                                    {
                                                        if (thirdlvlctrl.Name.Contains("PanelUC"))
                                                        {
                                                            foreach (PanelModel pnl in thirdlvlmpnl.MPanelLst_Panel)
                                                            {
                                                                if (thirdlvlctrl.Name == pnl.Panel_Name)
                                                                {
                                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else if (thirdlvlctrl.Name.Contains("MullionUC") || thirdlvlctrl.Name.Contains("TransomUC"))
                                                        {

                                                            foreach (DividerModel div in thirdlvlmpnl.MPanelLst_Divider)
                                                            {
                                                                if (thirdlvlctrl.Name == div.Div_Name)
                                                                {
                                                                    if (div.Div_Name == mullionUC.Name)
                                                                    {
                                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 19;
                                                                        return;
                                                                    }
                                                                    else
                                                                    {
                                                                        divPropertyHeight += div.Div_PropHeight;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        foreach (MultiPanelModel fourthlvlmpnl in thirdlvlmpnl.MPanelLst_MultiPanel)
                                                        {
                                                            if (thirdlvlctrl.Name == fourthlvlmpnl.MPanel_Name)
                                                            {
                                                                mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                                foreach (Control fourthlvlctrl in fourthlvlmpnl.MPanelLst_Objects)
                                                                {

                                                                    if (fourthlvlctrl.Name.Contains("PanelUC"))
                                                                    {
                                                                        foreach (PanelModel pnl in fourthlvlmpnl.MPanelLst_Panel)
                                                                        {
                                                                            if (fourthlvlctrl.Name == pnl.Panel_Name)
                                                                            {
                                                                                pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                                break;
                                                                            }
                                                                        }

                                                                    }
                                                                    else if (fourthlvlctrl.Name.Contains("MullionUC") || fourthlvlctrl.Name.Contains("TransomUC"))
                                                                    {
                                                                        foreach (DividerModel div in fourthlvlmpnl.MPanelLst_Divider)
                                                                        {
                                                                            if (fourthlvlctrl.Name == div.Div_Name)
                                                                            {
                                                                                if (div.Div_Name == mullionUC.Name)
                                                                                {
                                                                                    _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 27;
                                                                                    return;
                                                                                }
                                                                                else
                                                                                {
                                                                                    divPropertyHeight += div.Div_PropHeight;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                                #endregion
                                propertyHeight += frm.Frame_PropertiesUC.Height;
                                framePropertyHeight = 0;
                                mpnlPropertyHeight = 0;
                                pnlPropertyHeight = 0;
                                divPropertyHeight = 0;
                            }

                        }

                        #endregion
                    }
                    else
                    {
                        #region Concrete

                        foreach (IConcreteModel crm in wdm.lst_concrete)
                        {
                            if (wndrObject.Name == crm.Concrete_Name)
                            {
                                concretePropertyHeight += crm.Concrete_PropertiesUC.Height;
                                break;
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void _mullionUC_mullionUCKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            UserControl me = (UserControl)sender;
            int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender);
            FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container
            Control prev_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx - 1];
            Control nxt_ctrl = null;

            if (_multiPanelModel.MPanelLst_Objects.Count() > me_indx + 1)
            {
                nxt_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx + 1];
            }

            int expected_Panel1MinWd = 0,
                expected_Panel2MinWd = 0;
            IMultiPanelModel prev_mpanel = null,
                             nxt_mpnl = null;
            IPanelModel prev_pnl = null,
                        nxt_pnl = null;
            if (prev_ctrl is IMultiPanelUC)
            {
                prev_mpanel = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);
            }
            else if (prev_ctrl is IPanelUC)
            {
                prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_ctrl.Name);
            }
            if (nxt_ctrl is IMultiPanelUC)
            {
                nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == nxt_ctrl.Name);
            }
            else if (nxt_ctrl is IPanelUC)
            {
                nxt_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_ctrl.Name);
            }

            int expected_total_controls_inside_parentMpanel = (_multiPanelModel.MPanel_Divisions * 2) + 1,
                actual_total_controls_inside_parentMpanel = _multiPanelModel.MPanelLst_Objects.Count();

            if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel &&
                _keydown)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        _mainPresenter.DeselectDivider();
                        _keydown = false;
                        break;
                    case Keys.Down:
                        if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                        {
                            if (prev_ctrl is IMultiPanelUC)
                            {
                                expected_Panel1MinWd = prev_mpanel.MPanel_WidthToBind - 1;
                            }
                            else if (prev_ctrl is IPanelUC)
                            {
                                expected_Panel1MinWd = prev_pnl.Panel_WidthToBind - 1;
                            }

                            if (expected_Panel1MinWd >= 30)
                            {
                                if (prev_ctrl is IMultiPanelUC)
                                {
                                    prev_mpanel.MPanel_Width--;
                                    prev_mpanel.MPanel_DisplayWidth--;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        prev_mpanel.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        prev_mpanel.SetDimensions_childPanelObjs(-1);

                                        foreach (IMultiPanelModel mpanel in prev_mpanel.MPanel_ParentModel.MPanelLst_MultiPanel)
                                        {
                                            if (prev_ctrl.Name == mpanel.MPanel_Name)
                                            {
                                                mpanel.SetDimensions_childObjs(-1, "prev");
                                                mpanel.SetDimensions_childPanelObjs(-1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        prev_mpanel.SetDimensionsToBind_using_ParentMultiPanelModel();

                                        prev_mpanel.SetDimensions_childPanelObjs(-1);

                                        foreach (IMultiPanelModel mpanel in prev_mpanel.MPanelLst_MultiPanel)
                                        {
                                            mpanel.MPanel_Width--;
                                            mpanel.MPanel_DisplayWidth--;

                                            mpanel.SetDimensionsToBind_MullionDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(-1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "prev");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "prev");
                                        }

                                        foreach (IDividerModel div in prev_mpanel.MPanelLst_Divider)
                                        {
                                            div.Div_Width--;
                                            div.Div_DisplayWidth--;

                                            div.SetDimensionsToBind_using_DivZoom();
                                            div.SetDimensionsToBind_using_DivZoom_Imager();
                                        }
                                    }

                                    if (prev_mpanel.MPanelImageRenderer_Zoom == 0.26f || prev_mpanel.MPanelImageRenderer_Zoom == 0.17f ||
                                       prev_mpanel.MPanelImageRenderer_Zoom == 0.13f || prev_mpanel.MPanelImageRenderer_Zoom == 0.10f)
                                    {
                                        prev_mpanel.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                        prev_mpanel.ImagerSetDimensions_childPanelObjs(-1);
                                    }
                                    else
                                    {
                                        prev_mpanel.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                        prev_mpanel.Imager_SetDimensionsToBind_MullionDivMovement(-1);
                                        prev_mpanel.ImagerSetDimensions_childPanelObjs(-1);
                                    }
                                }
                                else if (prev_ctrl is IPanelUC)
                                {
                                    prev_pnl.Panel_Width--;
                                    prev_pnl.Panel_DisplayWidth--;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        prev_pnl.SetDimensionToBind_using_BaseDimension();
                                        foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                        {
                                            mpnl.SetDimensions_childObjs();
                                        }
                                    }
                                    if (prev_pnl.PanelImageRenderer_Zoom == 0.26f || prev_pnl.PanelImageRenderer_Zoom == 0.17f ||
                                        prev_pnl.PanelImageRenderer_Zoom == 0.13f || prev_pnl.PanelImageRenderer_Zoom == 0.10f)
                                    {
                                        prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        prev_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                    }
                                }

                                if (nxt_ctrl is IMultiPanelUC)
                                {
                                    nxt_mpnl.MPanel_Width++;
                                    nxt_mpnl.MPanel_DisplayWidth++;


                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        nxt_mpnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        nxt_mpnl.SetDimensions_childPanelObjs(1);

                                        foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanel_ParentModel.MPanelLst_MultiPanel)
                                        {
                                            if (nxt_ctrl.Name == mpanel.MPanel_Name)
                                            {
                                                mpanel.SetDimensions_childObjs(1, "nxt");
                                                mpanel.SetDimensions_childPanelObjs(1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        nxt_mpnl.SetDimensionsToBind_using_ParentMultiPanelModel();
                                        nxt_mpnl.SetDimensions_childPanelObjs(1);

                                        foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanelLst_MultiPanel)
                                        {
                                            mpanel.MPanel_Width++;
                                            mpanel.MPanel_DisplayWidth++;

                                            mpanel.SetDimensionsToBind_MullionDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "nxt");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "nxt");
                                        }

                                        foreach (IDividerModel div in nxt_mpnl.MPanelLst_Divider)
                                        {
                                            div.Div_Width++;
                                            div.Div_DisplayWidth++;

                                            div.SetDimensionsToBind_using_DivZoom();
                                            div.SetDimensionsToBind_using_DivZoom_Imager();
                                        }
                                    }
                                    if (nxt_mpnl.MPanelImageRenderer_Zoom == 0.26f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.17f ||
                                        nxt_mpnl.MPanelImageRenderer_Zoom == 0.13f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.10f)
                                    {
                                        nxt_mpnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                        nxt_mpnl.ImagerSetDimensions_childPanelObjs(1);
                                    }
                                    else
                                    {
                                        nxt_mpnl.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                        nxt_mpnl.Imager_SetDimensionsToBind_MullionDivMovement(1);
                                        nxt_mpnl.ImagerSetDimensions_childPanelObjs(1);
                                    }
                                }
                                else if (nxt_ctrl is IPanelUC)
                                {
                                    nxt_pnl.Panel_Width++;
                                    nxt_pnl.Panel_DisplayWidth++;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        nxt_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        nxt_pnl.SetDimensionToBind_using_BaseDimension();
                                        foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                        {
                                            mpnl.SetDimensions_childObjs();
                                        }
                                    }
                                    if (nxt_pnl.PanelImageRenderer_Zoom == 0.26f || nxt_pnl.PanelImageRenderer_Zoom == 0.17f ||
                                        nxt_pnl.PanelImageRenderer_Zoom == 0.13f || nxt_pnl.PanelImageRenderer_Zoom == 0.10f)
                                    {
                                        nxt_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        nxt_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                    }
                                }
                            }
                            _multiPanelModel.Fit_MyControls_ToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, nxt_pnl);
                            _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, nxt_pnl);
                            _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                            _multiPanelModel.Fit_My2ndLvlControls_Dimensions();
                            _mainPresenter.GetCurrentPrice();

                        }
                        break;
                    case Keys.Up:
                        if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                        {
                            if (nxt_ctrl is IMultiPanelUC)
                            {
                                expected_Panel2MinWd = nxt_mpnl.MPanel_WidthToBind - 1;
                            }
                            else if (nxt_ctrl is IPanelUC)
                            {
                                expected_Panel2MinWd = nxt_pnl.Panel_WidthToBind - 1;
                            }

                            if (expected_Panel2MinWd >= 30)
                            {
                                if (prev_ctrl is IMultiPanelUC)
                                {
                                    prev_mpanel.MPanel_Width++;
                                    prev_mpanel.MPanel_DisplayWidth++;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        prev_mpanel.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        prev_mpanel.SetDimensions_childPanelObjs(1);

                                        foreach (IMultiPanelModel mpanel in prev_mpanel.MPanel_ParentModel.MPanelLst_MultiPanel)
                                        {
                                            if (prev_ctrl.Name == mpanel.MPanel_Name)
                                            {
                                                mpanel.SetDimensions_childObjs(1, "prev");
                                                mpanel.SetDimensions_childPanelObjs(1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        prev_mpanel.SetDimensionsToBind_using_ParentMultiPanelModel();
                                        prev_mpanel.SetDimensions_childPanelObjs(1);
                                        foreach (IMultiPanelModel mpanel in prev_mpanel.MPanelLst_MultiPanel)
                                        {
                                            mpanel.MPanel_Width++;
                                            mpanel.MPanel_DisplayWidth++;

                                            mpanel.SetDimensionsToBind_MullionDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "prev");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "prev");
                                        }

                                        foreach (IDividerModel div in prev_mpanel.MPanelLst_Divider)
                                        {
                                            div.Div_Width++;
                                            div.Div_DisplayWidth++;

                                            div.SetDimensionsToBind_using_DivZoom();
                                            div.SetDimensionsToBind_using_DivZoom_Imager();
                                        }
                                    }
                                    if (prev_mpanel.MPanelImageRenderer_Zoom == 0.26f || prev_mpanel.MPanelImageRenderer_Zoom == 0.17f ||
                                        prev_mpanel.MPanelImageRenderer_Zoom == 0.13f || prev_mpanel.MPanelImageRenderer_Zoom == 0.10f)
                                    {
                                        prev_mpanel.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                        prev_mpanel.ImagerSetDimensions_childPanelObjs(1);
                                    }
                                    else
                                    {
                                        prev_mpanel.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                        prev_mpanel.Imager_SetDimensionsToBind_MullionDivMovement(1);
                                        prev_mpanel.ImagerSetDimensions_childPanelObjs(1);
                                    }
                                }
                                else if (prev_ctrl is IPanelUC)
                                {
                                    prev_pnl.Panel_Width++;
                                    prev_pnl.Panel_DisplayWidth++;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        prev_pnl.SetDimensionToBind_using_BaseDimension();
                                        foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                        {
                                            mpnl.SetDimensions_childObjs();
                                        }
                                    }
                                    if (prev_pnl.PanelImageRenderer_Zoom == 0.26f || prev_pnl.PanelImageRenderer_Zoom == 0.17f ||
                                        prev_pnl.PanelImageRenderer_Zoom == 0.13f || prev_pnl.PanelImageRenderer_Zoom == 0.10f)
                                    {
                                        prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        prev_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                    }
                                }

                                if (nxt_ctrl is IMultiPanelUC)
                                {
                                    nxt_mpnl.MPanel_Width--;
                                    nxt_mpnl.MPanel_DisplayWidth--;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        nxt_mpnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        nxt_mpnl.SetDimensions_childPanelObjs(-1);

                                        foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanel_ParentModel.MPanelLst_MultiPanel)
                                        {
                                            if (nxt_ctrl.Name == mpanel.MPanel_Name)
                                            {
                                                mpanel.SetDimensions_childObjs(-1, "nxt");
                                                mpanel.SetDimensions_childPanelObjs(-1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        nxt_mpnl.SetDimensionsToBind_using_ParentMultiPanelModel();
                                        nxt_mpnl.SetDimensions_childPanelObjs(-1);

                                        foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanelLst_MultiPanel)
                                        {
                                            mpanel.MPanel_Width--;
                                            mpanel.MPanel_DisplayWidth--;

                                            mpanel.SetDimensionsToBind_MullionDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(-1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "nxt");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "nxt");
                                        }

                                        foreach (IDividerModel div in nxt_mpnl.MPanelLst_Divider)
                                        {
                                            div.Div_Width--;
                                            div.Div_DisplayWidth--;

                                            div.SetDimensionsToBind_using_DivZoom();
                                            div.SetDimensionsToBind_using_DivZoom_Imager();
                                        }
                                    }
                                    if (nxt_mpnl.MPanelImageRenderer_Zoom == 0.26f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.17f ||
                                        nxt_mpnl.MPanelImageRenderer_Zoom == 0.13f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.10f)
                                    {
                                        nxt_mpnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                        nxt_mpnl.ImagerSetDimensions_childPanelObjs(-1);
                                    }
                                    else
                                    {
                                        nxt_mpnl.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                        nxt_mpnl.Imager_SetDimensionsToBind_MullionDivMovement(-1);
                                        nxt_mpnl.ImagerSetDimensions_childPanelObjs(-1);
                                    }

                                }
                                else if (nxt_ctrl is IPanelUC)
                                {
                                    nxt_pnl.Panel_Width--;
                                    nxt_pnl.Panel_DisplayWidth--;

                                    if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                        _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                    {
                                        nxt_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        nxt_pnl.SetDimensionToBind_using_BaseDimension();
                                        foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                        {
                                            mpnl.SetDimensions_childObjs();
                                        }
                                    }
                                    if (nxt_pnl.PanelImageRenderer_Zoom == 0.26f || nxt_pnl.PanelImageRenderer_Zoom == 0.17f ||
                                        nxt_pnl.PanelImageRenderer_Zoom == 0.13f || nxt_pnl.PanelImageRenderer_Zoom == 0.10f)
                                    {
                                        nxt_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    else
                                    {
                                        nxt_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                    }
                                }
                            }
                            _multiPanelModel.Fit_MyControls_ToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, nxt_pnl);
                            _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, nxt_pnl);
                            _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                            _multiPanelModel.Fit_My2ndLvlControls_Dimensions();
                            _mainPresenter.GetCurrentPrice();


                        }
                        break;
                }
            }
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
        }

        private void _mullionUC_mullionUCMouseDoubleClickedEventRaised(object sender, MouseEventArgs e)
        {
            int thisIndx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_mullionUC);
            if (thisIndx > 0 && thisIndx < _multiPanelModel.MPanelLst_Objects.Count() - 1)
            {
                _mainPresenter.SetSelectedDivider(_divModel, null, this);
            }
         
        }

        private void _mullionUC_mullionUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!_initialLoad)
            //    {
            //        int thisWd = ((UserControl)sender).Width,
            //        thisHt = ((UserControl)sender).Height,
            //        divModelWd = _divModel.Div_Width,
            //        divModelHt = _divModel.Div_Height;

            //        if (thisWd != divModelWd)
            //        {
            //            _divModel.Div_Width = thisWd;
            //        }
            //        if (thisHt != divModelHt)
            //        {
            //            _divModel.Div_Height = thisHt;
            //        }
            //        ((UserControl)sender).Invalidate();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void _mullionUC_mullionUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Black;
            _mullionUC.InvalidateThis();
        }

        private void _mullionUC_mullionUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Blue;
            _mullionUC.InvalidateThis();
        }

        Color penColor = Color.Black;

        private void _mullionUC_mullionUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl mul = (UserControl)sender;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            Font drawFont = new Font("Segoe UI", 6.5f, FontStyle.Bold); //* zoom);
            Size s2 = TextRenderer.MeasureText(_divModel.Div_Name, drawFont);

            SizeF sz = e.Graphics.VisibleClipBounds.Size;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            //90 degrees
            g.TranslateTransform(sz.Width, 0);
            g.RotateTransform(90);
            g.DrawString(_divModel.Div_Name, drawFont, Brushes.Black, new RectangleF(10, 0, s2.Width, s2.Height), format);
            g.ResetTransform();

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int ctrl_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(mul);
            bool prevCtrl_isPanel = false;
            if (!_multiPanelModel.MPanelLst_Objects[ctrl_ndx - 1].Name.Contains("Multi"))
            {
                prevCtrl_isPanel = true;
            }
            else
            {
                prevCtrl_isPanel = false;
            }

            if ((_divModel.Div_Width == (int)_frameModel.Frame_Type || _divModel.Div_Width == 13) &&
                _frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       mul.ClientRectangle.Width - w,
                                                                       mul.ClientRectangle.Height - w));
            }
            else if ((_divModel.Div_Width == (int)_frameModel.Frame_Type || _divModel.Div_Width == ((int)FrameModel.Frame_Padding.Door / 2)) &&
                     _frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       mul.ClientRectangle.Width - w,
                                                                       mul.ClientRectangle.Height - w));
            }
            else 
            if (_divModel.Div_Width == (int)_frameModel.Frame_Type - _multiPanelModel.MPanel_AddPixel)
            {
                if (prevCtrl_isPanel == false)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(-1,
                                                                           0,
                                                                           (mul.ClientRectangle.Width - w) + 1,
                                                                           mul.ClientRectangle.Height - w));
                }
                else if (prevCtrl_isPanel == true)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                           0,
                                                                           (mul.ClientRectangle.Width - w) + 2,
                                                                           mul.ClientRectangle.Height - w));
                }
            }
            else if (_divModel.Div_Width == (int)_frameModel.Frame_Type - (_multiPanelModel.MPanel_AddPixel * 2))
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(-1,
                                                                       0,
                                                                       (mul.ClientRectangle.Width - w) + 2,
                                                                       mul.ClientRectangle.Height - w));
            }
        }

        private void _mullionUC_mullionUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            int expected_total_controls_inside_parentMpanel = (_multiPanelModel.MPanel_Divisions * 2) + 1,
                   actual_total_controls_inside_parentMpanel = _multiPanelModel.MPanelLst_Objects.Count();

            if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel &&
                e.Button == MouseButtons.Left)
            {
                _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                ////foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                ////{
                ////    pnl.SetDimensionsToBind_using_ZoomPercentage();
                ////    pnl.Imager_SetDimensionsToBind_using_ZoomPercentage();
                ////}
                ////_multiPanelModel.Fit_MyControls_ToBindDimensions();
                ////_multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                _multiPanelModel.Fit_My2ndLvlControls_Dimensions();
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }

               
        }

        private void _mullionUC_mullionUCMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            try
            {

                UserControl me = (UserControl)sender;
                int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender);

                Control prev_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx - 1];
                Control nxt_ctrl = null;

                if (_multiPanelModel.MPanelLst_Objects.Count() > me_indx + 1)
                {
                    nxt_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx + 1];
                }

                int expected_Panel1MinWD = 0,
                    expected_Panel2MinWD = 0,
                    mullion_movement = 0;

                IMultiPanelModel prev_mpanel = null,
                                 nxt_mpnl = null;

                IPanelModel prev_pnl = null,
                            nxt_pnl = null;

                if (prev_ctrl is IMultiPanelUC)
                {
                    prev_mpanel = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);
                    expected_Panel1MinWD = prev_mpanel.MPanel_WidthToBind + (e.X - _point_of_origin.X);
                }
                else if (prev_ctrl is IPanelUC)
                {
                    prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_ctrl.Name);
                    expected_Panel1MinWD = prev_pnl.Panel_WidthToBind + (e.X - _point_of_origin.X);
                }

                if (nxt_ctrl is IMultiPanelUC)
                {
                    nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == nxt_ctrl.Name);
                    expected_Panel2MinWD = nxt_mpnl.MPanel_WidthToBind - (e.X - _point_of_origin.X);
                }
                else if (nxt_ctrl is IPanelUC)
                {
                    nxt_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_ctrl.Name);
                    expected_Panel2MinWD = nxt_pnl.Panel_WidthToBind - (e.X - _point_of_origin.X);
                }

                FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                int expected_total_controls_inside_parentMpanel = (_multiPanelModel.MPanel_Divisions * 2) + 1,
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.MPanelLst_Objects.Count();

                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel &&
                    e.Button == MouseButtons.Left && _mouseDown)
                {
                    if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                    {
                        if (expected_Panel1MinWD >= 30 && expected_Panel2MinWD >= 30)
                        {
                            mullion_movement = (e.X - _point_of_origin.X);

                            if (prev_ctrl is IMultiPanelUC)
                            {
                                prev_mpanel.MPanel_Width += mullion_movement;
                                prev_mpanel.MPanel_DisplayWidth += mullion_movement;

                                if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                    _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                {
                                    prev_mpanel.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    prev_mpanel.SetDimensions_childPanelObjs(mullion_movement);
                                    foreach (IMultiPanelModel mpanel in prev_mpanel.MPanel_ParentModel.MPanelLst_MultiPanel)
                                    {
                                        if (prev_ctrl.Name == mpanel.MPanel_Name)
                                        {
                                            mpanel.SetDimensions_childObjs(mullion_movement, "prev");
                                            mpanel.SetDimensions_childPanelObjs(mullion_movement);
                                        }
                                    }
                                }
                                else
                                {
                                    prev_mpanel.SetDimensionsToBind_using_ParentMultiPanelModel();
                                    prev_mpanel.SetDimensions_childPanelObjs(mullion_movement);
                                    foreach (IMultiPanelModel mpanel in prev_mpanel.MPanelLst_MultiPanel)
                                    {
                                        mpanel.MPanel_Width += mullion_movement;
                                        mpanel.MPanel_DisplayWidth += mullion_movement;

                                        mpanel.SetDimensionsToBind_MullionDivMovement();
                                        mpanel.Imager_SetDimensionsToBind_MullionDivMovement(mullion_movement);

                                        mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(mullion_movement, "prev");
                                        mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(mullion_movement, "prev");
                                    }
                                    
                                    foreach (IDividerModel div in prev_mpanel.MPanelLst_Divider)
                                    {
                                        div.Div_Width += mullion_movement;
                                        div.Div_DisplayWidth += mullion_movement;

                                        div.SetDimensionsToBind_using_DivZoom();
                                        div.SetDimensionsToBind_using_DivZoom_Imager();
                                    }
                                }

                                if (prev_mpanel.MPanelImageRenderer_Zoom == 0.26f || prev_mpanel.MPanelImageRenderer_Zoom == 0.17f ||
                                    prev_mpanel.MPanelImageRenderer_Zoom == 0.13f || prev_mpanel.MPanelImageRenderer_Zoom == 0.10f)
                                {
                                    prev_mpanel.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    prev_mpanel.ImagerSetDimensions_childPanelObjs(mullion_movement);
                                }
                                else
                                {
                                    prev_mpanel.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                    prev_mpanel.Imager_SetDimensionsToBind_MullionDivMovement(mullion_movement);
                                    prev_mpanel.ImagerSetDimensions_childPanelObjs(mullion_movement);
                                }
                            }
                            else if (prev_ctrl is IPanelUC)
                            {
                                prev_pnl.Panel_Width += mullion_movement;
                                prev_pnl.Panel_DisplayWidth += mullion_movement;

                                if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                    _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                {
                                    prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    prev_pnl.SetDimensionToBind_using_BaseDimension();
                                    foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                    {
                                        mpnl.SetDimensions_childObjs();
                                    }
                                }
                                if (prev_pnl.PanelImageRenderer_Zoom == 0.26f || prev_pnl.PanelImageRenderer_Zoom == 0.17f ||
                                    prev_pnl.PanelImageRenderer_Zoom == 0.13f || prev_pnl.PanelImageRenderer_Zoom == 0.10f)
                                {
                                    prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    prev_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                }
                            }

                            if (nxt_ctrl is IMultiPanelUC)
                            {
                                nxt_mpnl.MPanel_Width -= mullion_movement;
                                nxt_mpnl.MPanel_DisplayWidth -= mullion_movement;

                                if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                    _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                {
                                    nxt_mpnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    nxt_mpnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                    nxt_mpnl.SetDimensions_childPanelObjs(-mullion_movement);
                                    nxt_mpnl.ImagerSetDimensions_childPanelObjs(-mullion_movement);

                                    foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanel_ParentModel.MPanelLst_MultiPanel)
                                    {
                                        if (nxt_ctrl.Name == mpanel.MPanel_Name)
                                        {
                                            mpanel.SetDimensions_childObjs(-mullion_movement, "nxt");
                                            mpanel.SetDimensions_childPanelObjs(-mullion_movement);
                                        }
                                    }
                                }
                                else
                                {
                                    nxt_mpnl.SetDimensionsToBind_using_ParentMultiPanelModel();
                                    nxt_mpnl.SetDimensions_childPanelObjs(-mullion_movement);

                                    foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanelLst_MultiPanel)
                                    {
                                        mpanel.MPanel_Width -= mullion_movement;
                                        mpanel.MPanel_DisplayWidth -= mullion_movement;

                                        mpanel.SetDimensionsToBind_MullionDivMovement();
                                        mpanel.Imager_SetDimensionsToBind_MullionDivMovement(-mullion_movement);

                                        mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(-mullion_movement, "nxt");
                                        mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(-mullion_movement, "nxt");
                                    }
                                    
                                    foreach (IDividerModel div in nxt_mpnl.MPanelLst_Divider)
                                    {
                                        div.Div_Width += mullion_movement;
                                        div.Div_DisplayWidth += mullion_movement;

                                        div.SetDimensionsToBind_using_DivZoom();
                                        div.SetDimensionsToBind_using_DivZoom_Imager();
                                    }
                                }
                                if (nxt_mpnl.MPanelImageRenderer_Zoom == 0.26f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.17f ||
                                    nxt_mpnl.MPanelImageRenderer_Zoom == 0.13f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.10f)
                                {
                                    nxt_mpnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    nxt_mpnl.ImagerSetDimensions_childPanelObjs(-mullion_movement);
                                }
                                else
                                {
                                    nxt_mpnl.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                    nxt_mpnl.Imager_SetDimensionsToBind_MullionDivMovement(-mullion_movement);
                                    nxt_mpnl.ImagerSetDimensions_childPanelObjs(-mullion_movement);
                                }

                            }
                            else if (nxt_ctrl is IPanelUC)
                            {
                                nxt_pnl.Panel_Width -= mullion_movement;
                                nxt_pnl.Panel_DisplayWidth -= mullion_movement;

                                if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                    _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                {
                                    nxt_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    nxt_pnl.SetDimensionToBind_using_BaseDimension();
                                    foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                    {
                                        mpnl.SetDimensions_childObjs();
                                    }
                                }

                                if (nxt_pnl.PanelImageRenderer_Zoom == 0.26f || nxt_pnl.PanelImageRenderer_Zoom == 0.17f ||
                                    nxt_pnl.PanelImageRenderer_Zoom == 0.13f || nxt_pnl.PanelImageRenderer_Zoom == 0.10f)
                                {
                                    nxt_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    nxt_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                }
                            }
                        }
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, nxt_pnl);
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, nxt_pnl);
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.GetCurrentPrice();

                }

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _mullionUC_mullionUCMouseDownEventRaised(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = true;
                _point_of_origin = e.Location;
            }
        }

        public IMullionUC GetMullion()
        {
            //_initialLoad = true;
            _mullionUC.ThisBinding(CreateBindingDictionary());
            return _mullionUC;
        }

        public IMullionUC GetMullion(string test) //for Testing
        {
            return _mullionUC;
        }

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC) //for Testing
        {
            unityC
                .RegisterType<IMullionUC, MullionUC>()
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();

            return mullionUCP;
        }

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                  IDividerModel divModel,
                                                  IMultiPanelModel multiPanelModel,
                                                  IMultiPanelMullionUCPresenter multiMullionUCP,
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)//,
                                                                               //IBasePlatformImagerUCPresenter basePlatformImagerUCP)
        {
            unityC
                .RegisterType<IMullionUC, MullionUC>()
                .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();
            mullionUCP._divModel = divModel;
            mullionUCP._multiPanelModel = multiPanelModel;
            mullionUCP._multiMullionUCP = multiMullionUCP;
            mullionUCP._frameModel = frameModel;
            mullionUCP._mainPresenter = mainPresenter;
            //mullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;

            return mullionUCP;
        }

        public IMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                  IDividerModel divModel,
                                                  IMultiPanelModel multiPanelModel,
                                                  IMultiPanelTransomUCPresenter multiTransomUCP,
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)//,
                                                                               //IBasePlatformImagerUCPresenter basePlatformImagerUCP)
        {
            unityC
               .RegisterType<IMullionUC, MullionUC>()
               .RegisterType<IMullionUCPresenter, MullionUCPresenter>();
            MullionUCPresenter mullionUCP = unityC.Resolve<MullionUCPresenter>();
            mullionUCP._divModel = divModel;
            mullionUCP._multiPanelModel = multiPanelModel;
            mullionUCP._multiTransomUCP = multiTransomUCP;
            mullionUCP._frameModel = frameModel;
            mullionUCP._mainPresenter = mainPresenter;
            //mullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;

            return mullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> divBinding = new Dictionary<string, Binding>();
            divBinding.Add("Div_ID", new Binding("Div_ID", _divModel, "Div_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Name", new Binding("Name", _divModel, "Div_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_Visible", new Binding("Visible", _divModel, "Div_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_WidthToBind", new Binding("Width", _divModel, "Div_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            divBinding.Add("Div_HeightToBind", new Binding("Height", _divModel, "Div_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));

            return divBinding;
        }

        public void SetInitialLoadFalse()
        {
            //_initialLoad = false;
        }

        public void FocusOnThisMullionDiv()
        {
            _mullionUC.FocusOnThis();
        }
    }
}
