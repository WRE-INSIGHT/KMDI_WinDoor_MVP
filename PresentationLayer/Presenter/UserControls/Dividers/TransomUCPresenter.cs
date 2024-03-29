﻿using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.MultiPanel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.CommonMethods;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Concrete;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.Dividers
{
    public class TransomUCPresenter : ITransomUCPresenter, IPresenterCommon
    {
        ITransomUC _transomUC;

        private IFrameModel _frameModel;
        private IDividerModel _divModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelTransomUCPresenter _multiTransomUCP;
        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMainPresenter _mainPresenter;
        private ConstantVariables constants = new ConstantVariables();
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

        public TransomUCPresenter(ITransomUC transomUC)
        {
            _transomUC = transomUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _transomUC.transomUCMouseDownEventRaised += _transomUC_transomUCMouseDownEventRaised;
            _transomUC.transomUCMouseMoveEventRaised += _transomUC_transomUCMouseMoveEventRaised;
            _transomUC.transomUCMouseUpEventRaised += _transomUC_transomUCMouseUpEventRaised;
            _transomUC.transomUCPaintEventRaised += _transomUC_transomUCPaintEventRaised;
            _transomUC.transomUCMouseEnterEventRaised += _transomUC_transomUCMouseEnterEventRaised;
            _transomUC.transomUCMouseLeaveEventRaised += _transomUC_transomUCMouseLeaveEventRaised;
            _transomUC.transomUCSizeChangedEventRaised += _transomUC_transomUCSizeChangedEventRaised;
            _transomUC.transomUCMouseDoubleClickedEventRaised += _transomUC_transomUCMouseDoubleClickedEventRaised;
            _transomUC.transomUCKeyDownEventRaised += _transomUC_transomUCKeyDownEventRaised;
            _transomUC.transomUCMouseClickedEventRaised += _transomUC_transomUCMouseClickedEventRaised;
        }
        private UserControl transomUC;
        private void _transomUC_transomUCMouseClickedEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                transomUC = (UserControl)sender;
                Console.WriteLine("Div Heigth to bind " + _divModel.Div_HeightToBind);
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
                                                    if (div.Div_Name == transomUC.Name)
                                                    {
                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 11;
                                                        return;
                                                    }
                                                    else
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
                                                                    if (div.Div_Name == transomUC.Name)
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
                                                                                if (div.Div_Name == transomUC.Name)
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

        private void _transomUC_transomUCKeyDownEventRaised(object sender, KeyEventArgs e)
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

            int expected_Panel1MinHT = 0,
                expected_Panel2MinHT = 0;

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
                            if (nxt_ctrl is IMultiPanelUC)
                            {
                                expected_Panel2MinHT = nxt_mpnl.MPanel_HeightToBind - 1;
                            }
                            else if (nxt_ctrl is IPanelUC)
                            {
                                expected_Panel2MinHT = nxt_pnl.Panel_HeightToBind - 1;
                            }

                            if (expected_Panel2MinHT >= 30)
                            {
                                if (prev_ctrl is IMultiPanelUC)
                                {
                                    prev_mpanel.MPanel_Height++;
                                    prev_mpanel.MPanel_DisplayHeight++;

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
                                            mpanel.MPanel_Height++;
                                            mpanel.MPanel_DisplayHeight++;

                                            mpanel.SetDimensionsToBind_TransomDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "prev");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "prev");
                                        }

                                        foreach (IDividerModel div in prev_mpanel.MPanelLst_Divider)
                                        {
                                            div.Div_Height++;
                                            div.Div_DisplayHeight++;

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

                                        prev_mpanel.Imager_SetDimensionsToBind_TransomDivMovement(1);
                                        prev_mpanel.ImagerSetDimensions_childPanelObjs(1);
                                    }
                                }
                                else if (prev_ctrl is IPanelUC)
                                {
                                    prev_pnl.Panel_Height++;
                                    prev_pnl.Panel_DisplayHeight++;

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
                                    nxt_mpnl.MPanel_Height--;
                                    nxt_mpnl.MPanel_DisplayHeight--;

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
                                            mpanel.MPanel_Height--;
                                            mpanel.MPanel_DisplayHeight--;

                                            mpanel.SetDimensionsToBind_TransomDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(-1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "nxt");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "nxt");
                                        }

                                        foreach (IDividerModel div in nxt_mpnl.MPanelLst_Divider)
                                        {
                                            div.Div_Height--;
                                            div.Div_DisplayHeight--;

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
                                        nxt_mpnl.Imager_SetDimensionsToBind_TransomDivMovement(-1);
                                        nxt_mpnl.ImagerSetDimensions_childPanelObjs(-1);
                                    }
                                }
                                else if (nxt_ctrl is IPanelUC)
                                {
                                    nxt_pnl.Panel_Height--;
                                    nxt_pnl.Panel_DisplayHeight--;

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

                            if (prev_ctrl is IMultiPanelUC)
                            {
                                expected_Panel1MinHT = prev_mpanel.MPanel_HeightToBind - 1;
                            }
                            else if (prev_ctrl is IPanelUC)
                            {
                                expected_Panel1MinHT = prev_pnl.Panel_HeightToBind - 1;
                            }

                            if (expected_Panel1MinHT >= 30)
                            {
                                if (prev_ctrl is IMultiPanelUC)
                                {
                                    prev_mpanel.MPanel_Height--;
                                    prev_mpanel.MPanel_DisplayHeight--;

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
                                            mpanel.MPanel_Height--;
                                            mpanel.MPanel_DisplayHeight--;

                                            mpanel.SetDimensionsToBind_TransomDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(-1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "prev");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(-1, "prev");
                                        }

                                        foreach (IDividerModel div in prev_mpanel.MPanelLst_Divider)
                                        {
                                            div.Div_Height--;
                                            div.Div_DisplayHeight--;

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
                                        prev_mpanel.Imager_SetDimensionsToBind_TransomDivMovement(-1);
                                        prev_mpanel.ImagerSetDimensions_childPanelObjs(-1);
                                    }
                                }
                                else if (prev_ctrl is IPanelUC)
                                {
                                    prev_pnl.Panel_Height--;
                                    prev_pnl.Panel_DisplayHeight--;

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
                                    nxt_mpnl.MPanel_Height++;
                                    nxt_mpnl.MPanel_DisplayHeight++;

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
                                            mpanel.MPanel_Height++;
                                            mpanel.MPanel_DisplayHeight++;

                                            mpanel.SetDimensionsToBind_TransomDivMovement();
                                            mpanel.Imager_SetDimensionsToBind_MullionDivMovement(1);

                                            mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "nxt");
                                            mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(1, "nxt");
                                        }

                                        foreach (IDividerModel div in nxt_mpnl.MPanelLst_Divider)
                                        {
                                            div.Div_Height++;
                                            div.Div_DisplayHeight++;

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
                                        nxt_mpnl.Imager_SetDimensionsToBind_TransomDivMovement(1);
                                        nxt_mpnl.ImagerSetDimensions_childPanelObjs(1);
                                    }
                                }
                                else if (nxt_ctrl is IPanelUC)
                                {
                                    nxt_pnl.Panel_Height++;
                                    nxt_pnl.Panel_DisplayHeight++;

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
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void _transomUC_transomUCMouseDoubleClickedEventRaised(object sender, MouseEventArgs e)
        {
            int thisIndx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_transomUC);
            if (thisIndx > 0 && thisIndx < _multiPanelModel.MPanelLst_Objects.Count() - 1)
            {
                _mainPresenter.SetSelectedDivider(_divModel, this);
            }
        }

        private void _transomUC_transomUCSizeChangedEventRaised(object sender, EventArgs e)
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

        Color penColor = Color.Black;

        private void _transomUC_transomUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Black;
            _transomUC.InvalidateThis();
        }

        private void _transomUC_transomUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            penColor = Color.Blue;
            _transomUC.InvalidateThis();
        }
        
        private void _transomUC_transomUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl transom = (UserControl)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font drawFont = new Font("Segoe UI", 6.5f, FontStyle.Bold); //* zoom);
            Size s2 = TextRenderer.MeasureText(_divModel.Div_Name, drawFont);

            //int point_Y = (transom.Height / 2) - (s2.Height / 2); //0;

            TextRenderer.DrawText(g,
                                  _divModel.Div_Name,
                                  drawFont,
                                  new Rectangle(new Point(10, 0),
                                                new Size(s2.Width,
                                                         s2.Height)),
                                  Color.Black,
                                  Color.Transparent,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int ctrl_ndx = _multiPanelModel.MPanelLst_Objects.IndexOf(transom);
            bool prevCtrl_isPanel = false;

            if (!_multiPanelModel.MPanelLst_Objects[ctrl_ndx - 1].Name.Contains("Multi"))
            {
                prevCtrl_isPanel = true;
            }
            else
            {
                prevCtrl_isPanel = false;
            }


            if ((_divModel.Div_Height == (int)_frameModel.Frame_Type || _divModel.Div_Height == 13) &&
                _frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       transom.ClientRectangle.Width - w,
                                                                       transom.ClientRectangle.Height - w));
            }
            else if ((_divModel.Div_Height == (int)_frameModel.Frame_Type || _divModel.Div_Height == (int)FrameModel.Frame_Padding.Door / 2) &&
                     _frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       transom.ClientRectangle.Width - w,
                                                                       transom.ClientRectangle.Height - w));
            }
            else if (_divModel.Div_Height == (int)_frameModel.Frame_Type - _multiPanelModel.MPanel_AddPixel)
            {
                if (prevCtrl_isPanel == true)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                           0,
                                                                           transom.ClientRectangle.Width - w,
                                                                           (transom.ClientRectangle.Height - w) + 2));
                }
                else if (prevCtrl_isPanel == false)
                {
                    g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                          -1,
                                                                          transom.ClientRectangle.Width - w,
                                                                          (transom.ClientRectangle.Height - w) + 1));
                }
                    
            }
            else if (_divModel.Div_Height == (int)_frameModel.Frame_Type - (_multiPanelModel.MPanel_AddPixel * 2))
            {
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       -1,
                                                                       transom.ClientRectangle.Width - w,
                                                                       (transom.ClientRectangle.Height - w) + 2));
            }
        }

        private void _transomUC_transomUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            int expected_total_controls_inside_parentMpanel = (_multiPanelModel.MPanel_Divisions * 2) + 1,
                   actual_total_controls_inside_parentMpanel = _multiPanelModel.MPanelLst_Objects.Count();

            if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel &&
                e.Button == MouseButtons.Left)
            {
                _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                //foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                //{
                //    pnl.SetDimensionsToBind_using_ZoomPercentage();
                //    pnl.Imager_SetDimensionsToBind_using_ZoomPercentage();
                //}
                //_multiPanelModel.Fit_MyControls_ToBindDimensions();
                //_multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                _multiPanelModel.Fit_My2ndLvlControls_Dimensions();
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
        }

        private void _transomUC_transomUCMouseMoveEventRaised(object sender, MouseEventArgs e)
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

                int expected_Panel1MinHT = 0,
                    expected_Panel2MinHT = 0,
                    transom_movement = 0;

                IMultiPanelModel prev_mpanel = null, 
                                 nxt_mpnl = null;

                IPanelModel prev_pnl = null,
                            nxt_pnl = null;

                if (prev_ctrl is IMultiPanelUC)
                {
                    prev_mpanel = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);
                    expected_Panel1MinHT = prev_mpanel.MPanel_HeightToBind + (e.Y - _point_of_origin.Y);
                }
                else if (prev_ctrl is IPanelUC)
                {
                    prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_ctrl.Name);
                    expected_Panel1MinHT = prev_pnl.Panel_HeightToBind + (e.Y - _point_of_origin.Y);
                }

                if (nxt_ctrl is IMultiPanelUC)
                {
                    nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == nxt_ctrl.Name);
                    expected_Panel2MinHT = nxt_mpnl.MPanel_HeightToBind - (e.Y - _point_of_origin.Y);
                }
                else if (nxt_ctrl is IPanelUC)
                {
                    nxt_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_ctrl.Name);
                    expected_Panel2MinHT = nxt_pnl.Panel_HeightToBind - (e.Y - _point_of_origin.Y);
                }

                FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                int expected_total_controls_inside_parentMpanel = (_multiPanelModel.MPanel_Divisions * 2) + 1,
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.MPanelLst_Objects.Count();

                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel && 
                    e.Button == MouseButtons.Left && _mouseDown)
                {
                    if (me_indx != 0 && flp.Controls.Count > (me_indx + 1))
                    {
                        if (expected_Panel1MinHT >= 30 && expected_Panel2MinHT >= 30)
                        {
                            transom_movement = (e.Y - _point_of_origin.Y);

                            if (prev_ctrl is IMultiPanelUC)
                            {
                                prev_mpanel.MPanel_Height += transom_movement;
                                prev_mpanel.MPanel_DisplayHeight += transom_movement;

                                if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                    _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                {
                                    prev_mpanel.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    prev_mpanel.SetDimensions_childPanelObjs(transom_movement);
                                    
                                    foreach (IMultiPanelModel mpanel in prev_mpanel.MPanel_ParentModel.MPanelLst_MultiPanel)
                                    {
                                        if(prev_ctrl.Name == mpanel.MPanel_Name)
                                        {
                                            mpanel.SetDimensions_childObjs(transom_movement, "prev");
                                            mpanel.SetDimensions_childPanelObjs(transom_movement);
                                        }
                                      
                                    }
                                }
                                else
                                {
                                    prev_mpanel.SetDimensionsToBind_using_ParentMultiPanelModel();
                                  
                                    prev_mpanel.SetDimensions_childPanelObjs(transom_movement);
                             

                                    foreach (IMultiPanelModel mpanel in prev_mpanel.MPanelLst_MultiPanel)
                                    {
                                        mpanel.MPanel_Height += transom_movement;
                                        mpanel.MPanel_DisplayHeight += transom_movement;

                                        mpanel.SetDimensionsToBind_TransomDivMovement();
                                        mpanel.Imager_SetDimensionsToBind_TransomDivMovement(transom_movement);

                                        mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(transom_movement, "prev");
                                        mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(transom_movement, "prev");
                                    }

                                    foreach (IDividerModel div in prev_mpanel.MPanelLst_Divider)
                                    {
                                        div.Div_Height += transom_movement;
                                        div.Div_DisplayHeight += transom_movement;

                                        div.SetDimensionsToBind_using_DivZoom();
                                        div.SetDimensionsToBind_using_DivZoom_Imager();
                                    }
                                }

                                if (prev_mpanel.MPanelImageRenderer_Zoom == 0.26f || prev_mpanel.MPanelImageRenderer_Zoom == 0.17f ||
                                    prev_mpanel.MPanelImageRenderer_Zoom == 0.13f || prev_mpanel.MPanelImageRenderer_Zoom == 0.10f)
                                {
                                    prev_mpanel.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                    prev_mpanel.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                    prev_mpanel.ImagerSetDimensions_childPanelObjs(transom_movement);
                                }
                                else
                                {
                                    prev_mpanel.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                    prev_mpanel.Imager_SetDimensionsToBind_TransomDivMovement(transom_movement);
                                    prev_mpanel.ImagerSetDimensions_childPanelObjs(transom_movement);
                                }
                            }
                            else if (prev_ctrl is IPanelUC)
                            {
                                prev_pnl.Panel_Height += transom_movement;
                                prev_pnl.Panel_DisplayHeight += transom_movement;

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
                                nxt_mpnl.MPanel_Height -= transom_movement;
                                nxt_mpnl.MPanel_DisplayHeight -= transom_movement;

                                if (_divModel.Div_Zoom == 0.26f || _divModel.Div_Zoom == 0.17f ||
                                    _divModel.Div_Zoom == 0.13f || _divModel.Div_Zoom == 0.10f)
                                {
                                    nxt_mpnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    nxt_mpnl.SetDimensions_childPanelObjs(-transom_movement);
                                    foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanel_ParentModel.MPanelLst_MultiPanel)
                                    {
                                        if (nxt_ctrl.Name == mpanel.MPanel_Name)
                                        {
                                            mpanel.SetDimensions_childObjs(-transom_movement, "nxt");
                                            mpanel.SetDimensions_childPanelObjs(-transom_movement);
                                        }
                                    }
                                }
                                else
                                {
                                    nxt_mpnl.SetDimensionsToBind_using_ParentMultiPanelModel();
                                    nxt_mpnl.SetDimensions_childPanelObjs(-transom_movement);

                                    foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanelLst_MultiPanel)
                                    {
                                        mpanel.MPanel_Height -= transom_movement;
                                        mpanel.MPanel_DisplayHeight -= transom_movement;

                                        mpanel.SetDimensionsToBind_TransomDivMovement();
                                        mpanel.Imager_SetDimensionsToBind_TransomDivMovement(-transom_movement);

                                        mpanel.SetDimensions_PanelObjs_of_3rdLevelMPanel(-transom_movement, "nxt");
                                        mpanel.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(-transom_movement, "nxt");
                                    }

                                    foreach (IDividerModel div in nxt_mpnl.MPanelLst_Divider)
                                    {
                                        div.Div_Height -= transom_movement;
                                        div.Div_DisplayHeight -= transom_movement;

                                        div.SetDimensionsToBind_using_DivZoom();
                                        div.SetDimensionsToBind_using_DivZoom_Imager();
                                    }
                                }
                                if (nxt_mpnl.MPanelImageRenderer_Zoom == 0.26f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.17f ||
                                   nxt_mpnl.MPanelImageRenderer_Zoom == 0.13f || nxt_mpnl.MPanelImageRenderer_Zoom == 0.10f)
                                {
                                    nxt_mpnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                    nxt_mpnl.ImagerSetDimensions_childPanelObjs(-transom_movement);
                                }
                                else
                                {
                                    nxt_mpnl.Imager_SetDimensionsToBind_using_ParentMultiPanelModel();
                                    nxt_mpnl.Imager_SetDimensionsToBind_TransomDivMovement(-transom_movement);
                                    nxt_mpnl.ImagerSetDimensions_childPanelObjs(-transom_movement);
                                }
                            }
                            else if (nxt_ctrl is IPanelUC)
                            {
                                nxt_pnl.Panel_Height -= transom_movement;
                                nxt_pnl.Panel_DisplayHeight -= transom_movement;

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
                    _mainPresenter.GetCurrentPrice();

                }
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _transomUC_transomUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = true;
                _point_of_origin = e.Location;
            }
        }

        public ITransomUC GetTransom(string test) //for Testing
        {
            return _transomUC;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC) //for Testing
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();

            return transomUCP;
        }

        public ITransomUC GetTransom()
        {
            //_initialLoad = true;
            _transomUC.ThisBinding(CreateBindingDictionary());
            return _transomUC;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC,
                                                  IDividerModel divModel,
                                                  IMultiPanelModel multiPanelModel,
                                                  IMultiPanelTransomUCPresenter multiTransomUCP,
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();
            transomUCP._divModel = divModel;
            transomUCP._multiPanelModel = multiPanelModel;
            transomUCP._multiTransomUCP = multiTransomUCP;
            transomUCP._frameModel = frameModel;
            transomUCP._mainPresenter = mainPresenter;

            return transomUCP;
        }

        public ITransomUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                  IDividerModel divModel, 
                                                  IMultiPanelModel multiPanelModel, 
                                                  IMultiPanelMullionUCPresenter multiMullionUCP, 
                                                  IFrameModel frameModel,
                                                  IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<ITransomUC, TransomUC>()
                .RegisterType<ITransomUCPresenter, TransomUCPresenter>();
            TransomUCPresenter transomUCP = unityC.Resolve<TransomUCPresenter>();
            transomUCP._divModel = divModel;
            transomUCP._multiPanelModel = multiPanelModel;
            transomUCP._multiMullionUCP = multiMullionUCP;
            transomUCP._frameModel = frameModel;
            transomUCP._mainPresenter = mainPresenter;

            return transomUCP;
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

        public void FocusOnThisTransomDiv()
        {
            _transomUC.FocusOnThis();
        }
    }
}
