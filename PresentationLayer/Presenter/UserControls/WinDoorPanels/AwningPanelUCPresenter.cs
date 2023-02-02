﻿using CommonComponents;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Variables;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class AwningPanelUCPresenter : IAwningPanelUCPresenter, IPresenterCommon
    {
        IAwningPanelUC _awningPanelUC;

        private IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;
        private ConstantVariables constants = new ConstantVariables();

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP;

        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;

        private IDividerServices _divServices;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _initialLoad;
        private UserControl awningUC;
        public AwningPanelUCPresenter(IAwningPanelUC awningPanelUC,
                                      IDividerServices divServices,
                                      ITransomUCPresenter transomUCP,
                                      IMullionUCPresenter mullionUCP,
                                      IMullionImagerUCPresenter mullionImagerUCP,
                                      ITransomImagerUCPresenter transomImagerUCP)
        {
            _awningPanelUC = awningPanelUC;
            _divServices = divServices;
            _transomUCP = transomUCP;
            _mullionUCP = mullionUCP;
            _mullionImagerUCP = mullionImagerUCP;
            _transomImagerUCP = transomImagerUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _awningPanelUC.awningPanelUCPaintEventRaised += OnAwningPanelUCPaintEventRaised;
            _awningPanelUC.awningPanelUCMouseEnterEventRaised += _awningPanelUC_awningPanelUCMouseEnterEventRaised;
            _awningPanelUC.awningPanelUCMouseLeaveEventRaised += _awningPanelUC_awningPanelUCMouseLeaveEventRaised;
            _awningPanelUC.deleteToolStripClickedEventRaised += _awningPanelUC_deleteToolStripClickedEventRaised;
            _awningPanelUC.extensionToolStripMenuItemClickedEventRaised += _awningPanelUC_extensionToolStripMenuItemClickedEventRaised;
            _awningPanelUC.awningPanelUCSizeChangedEventRaised += _awningPanelUC_awningPanelUCSizeChangedEventRaised;
            _awningPanelUC.awningPanelUCMouseClickEventRaised += _awningPanelUC_awningPanelUCMouseClickEventRaised;
            _tmr.Tick += _tmr_Tick;
        }

        private void _awningPanelUC_awningPanelUCMouseClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                //       Console.WriteLine("**Panel Width*" + _panelModel.Panel_WidthWithDecimal);
                //Console.WriteLine("**Panel Width To Bind*" + _multiPanelModel.MPanel_WidthToBind);
                awningUC = (UserControl)sender;
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
                                #region  Frame Panel
                                foreach (PanelModel pnl in frm.Lst_Panel)
                                {
                                    if (pnl.Panel_Name == awningUC.Name)
                                    {
                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 3;
                                        return;
                                    }
                                }
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
                                                    if (pnl.Panel_Name == awningUC.Name)
                                                    {
                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 11;
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                    }
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
                                                    divPropertyHeight += div.Div_PropHeight;
                                                    break;
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
                                                                    if (pnl.Panel_Name == awningUC.Name)
                                                                    {
                                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 19;
                                                                        return;

                                                                    }
                                                                    else
                                                                    {
                                                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (thirdlvlctrl.Name.Contains("MullionUC") || thirdlvlctrl.Name.Contains("TransomUC"))
                                                        {

                                                            foreach (DividerModel div in thirdlvlmpnl.MPanelLst_Divider)
                                                            {
                                                                if (thirdlvlctrl.Name == div.Div_Name)
                                                                {
                                                                    divPropertyHeight += div.Div_PropHeight;
                                                                    break;
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
                                                                                if (pnl.Panel_Name == awningUC.Name)
                                                                                {
                                                                                    _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + pnlPropertyHeight + divPropertyHeight - 27;
                                                                                    return;

                                                                                }
                                                                                else
                                                                                {
                                                                                    pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                                                                }
                                                                            }
                                                                        }

                                                                    }
                                                                    else if (fourthlvlctrl.Name.Contains("MullionUC") || fourthlvlctrl.Name.Contains("TransomUC"))
                                                                    {
                                                                        foreach (DividerModel div in fourthlvlmpnl.MPanelLst_Divider)
                                                                        {
                                                                            if (fourthlvlctrl.Name == div.Div_Name)
                                                                            {
                                                                                divPropertyHeight += div.Div_PropHeight;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        //mpnlPropertyHeight -= 1;

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
                                concretePropertyHeight += constants.concrete_propertyHeight_default;
                                break;
                            }
                        }
                        #endregion
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int prev_Width = 0,
            prev_Height = 0;
        private void _awningPanelUC_awningPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        pnlModelWd = _panelModel.Panel_WidthToBind,
                        pnlModelHt = _panelModel.Panel_HeightToBind;

                    if (thisWd != pnlModelWd || prev_Width != pnlModelWd)
                    {
                        //_multiPanelModel.MPanel_Width = thisWd;
                        _WidthChange = true;
                    }
                    if (thisHt != pnlModelHt || prev_Height != pnlModelHt)
                    {
                        //_multiPanelModel.MPanel_Height = thisHt;
                        _HeightChange = true;
                    }
                }
                prev_Width = _panelModel.Panel_WidthToBind;
                prev_Height = _panelModel.Panel_HeightToBind;

                _tmr.Start();
                ((UserControl)sender).Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _awningPanelUC_extensionToolStripMenuItemClickedEventRaised(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            if (tsm.Checked == true)
            {
                _panelModel.Panel_ExtensionOptionsVisibility = true;
                _panelModel.Panel_CornerDriveOptionsVisibility = true;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                _panelModel.AdjustPropertyPanelHeight("addCornerDrive");

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                _panelModel.AdjustPropertyPanelHeight("addExtension");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addCornerDrive");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                }
            }
            else if (tsm.Checked == false)
            {
                _panelModel.Panel_ExtensionOptionsVisibility = false;
                _panelModel.Panel_CornerDriveOptionsVisibility = false;

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                _panelModel.AdjustPropertyPanelHeight("minusExtension");

                if (_panelModel.Panel_ParentMultiPanelModel != null)
                {
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                    _panelModel.Panel_ParentMultiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                }
            }
        }

        int _timer_count;
        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                ((IPanelUC)_awningPanelUC).InvalidateThis();
            }
        }

        private void _awningPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete Divider
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_awningPanelUC);
                Control nextCtrl = null;
                if (_multiPanelModel.MPanelLst_Objects.Count > (this_indx + 2))
                {
                    nextCtrl = _multiPanelModel.MPanelLst_Objects[this_indx + 2];
                    if (!nextCtrl.Name.Contains("Multi"))
                    {
                        nextCtrl = null;
                    }
                }
                if (this_indx > 1 && _multiPanelModel.MPanel_DividerEnabled && nextCtrl != null)
                {
                    Control prevmPanel = _multiPanelModel.MPanelLst_Objects[this_indx - 2];
                    Control divCtrl = _multiPanelModel.MPanelLst_Objects[this_indx - 1];
                    IMultiPanelModel leftMpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prevmPanel.Name);

                    int div_mpnl_deduct_Tobind = 8;
                    if (_multiPanelModel.MPanel_Zoom > 0.26f)
                    {
                        div_mpnl_deduct_Tobind = (int)(div_mpnl_deduct_Tobind * _multiPanelModel.MPanel_Zoom);//4
                    }
                    else if (_multiPanelModel.MPanel_Zoom <= 0.26f)
                    {
                        div_mpnl_deduct_Tobind = 2; //13 - 2 = 11 - 2 = 9px default on div obj for 2-stack multipanel
                    }

                    if (divCtrl.Name.Contains("Mullion"))
                    {
                        IMullionUC mullionUC = (MullionUC)_multiPanelModel.MPanelLst_Objects[this_indx - 1];
                        _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                        mullionUC.InvalidateThis();
                        leftMpnl.MPanel_WidthToBind -= div_mpnl_deduct_Tobind;
                    }
                    else if (divCtrl.Name.Contains("Transom"))
                    {
                        ITransomUC transomUC = (TransomUC)_multiPanelModel.MPanelLst_Objects[this_indx - 1];
                        _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                        transomUC.InvalidateThis();
                        leftMpnl.MPanel_HeightToBind -= div_mpnl_deduct_Tobind;
                    }
                }
                Control divUC = _multiPanelModel.MPanelLst_Objects[this_indx + 1];
                _multiPanelModel.MPanelLst_Objects.Remove((UserControl)divUC);

                //string imgr_type = "";

                if (_multiPanelMullionUCP != null)
                {
                    _multiPanelMullionUCP.DeletePanel((UserControl)divUC);
                    //imgr_type = "MullionImager";
                }
                if (_multiPanelTransomUCP != null)
                {
                    _multiPanelTransomUCP.DeletePanel((UserControl)divUC);
                    //imgr_type = "TransomImager";
                }

                IDividerModel div = _multiPanelModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                _mainPresenter.DeleteDividerPropertiesUC(div.Div_ID);
                div.Div_MPanelParent.MPanelLst_Divider.Remove(div);
                _frameModel.Lst_Divider.Remove(div);

                _multiPanelModel.DeductPropertyPanelHeight(div.Div_PropHeight);
                _frameModel.DeductPropertyPanelHeight(div.Div_PropHeight);
            }

            #endregion

            #region Delete Awning

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_awningPanelUC, _frameModel.Frame_Type.ToString());
                Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                _multiPanelModel.Reload_PanelMargin();

                _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);
            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_awningPanelUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_awningPanelUC);
            }
            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_awningPanelUC);
            }

            if (_multiPanelModel != null && _multiPanelModel.MPanel_DividerEnabled)
            {
                _multiPanelModel.Object_Indexer();
                _multiPanelModel.Reload_PanelMargin();
                _multiPanelModel.Reload_MultiPanelMargin();
                _commonFunctions.Automatic_Div_Addition(_mainPresenter,
                                                        _frameModel,
                                                        _divServices,
                                                        //_frameUCP,
                                                        _transomUCP,
                                                        _unityC,
                                                        _mullionUCP,
                                                        //_mullionImagerUCP,
                                                        //_transomImagerUCP,
                                                        _mainPresenter.GetDividerCount(),
                                                        _multiPanelModel,
                                                        _panelModel,
                                                        _multiPanelTransomUCP,
                                                        _multiPanelMullionUCP);
                //_multiPanelMullionImagerUCP,
                //_multiPanelTransomImagerUCP);
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

            _mainPresenter.DeletePanelPropertiesUC(_panelModel.Panel_ID);
            _mainPresenter.SetChangesMark();

            if (_frameModel != null)
            {
                _frameModel.Lst_Panel.Remove(_panelModel);
            }
            if (_multiPanelModel != null)
            {
                _multiPanelModel.MPanelLst_Panel.Remove(_panelModel);
            }

            _frameModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);
            _mainPresenter.DeductPanelGlassID();
            _mainPresenter.SetPanelGlassID();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            #endregion
            _mainPresenter.SetChangesMark();

            _mainPresenter.DeselectDivider();
            _mainPresenter.itemDescription();
            _mainPresenter.GetCurrentPrice();
        }

        private void _awningPanelUC_awningPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_awningPanelUC).InvalidateThis();
        }

        private void _awningPanelUC_awningPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_awningPanelUC).InvalidateThis();
        }

        Color color = Color.Black;

        bool _HeightChange = false,
             _WidthChange = false;
        private void OnAwningPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl awning = (UserControl)sender;

            Graphics g = e.Graphics;

            int w = 1;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int font_size = 30,
                outer_line = 10,
                inner_line = 15;

            int ndx_zoomPercentage = Array.IndexOf(_mainPresenter.windoorModel_MainPresenter.Arr_ZoomPercentage, _frameModel.Frame_Zoom);

            if (ndx_zoomPercentage == 3)
            {
                font_size = 25;
            }
            else if (ndx_zoomPercentage == 2)
            {
                font_size = 15;
                outer_line = 5;
                inner_line = 8;
            }
            else if (ndx_zoomPercentage == 1)
            {
                font_size = 13;
                outer_line = 3;
                inner_line = 7;
            }
            else if (ndx_zoomPercentage == 0)
            {
                font_size = 8;
                outer_line = 3;
                inner_line = 7;
            }
            #region Georgian Bar
            int GBpointResultX, GBpointResultY,
                penThickness = 0, penThicknessResult = 0,
                pInnerWd = awning.ClientRectangle.Width,
                pInnerHt = awning.ClientRectangle.Height,
                verticalQty = _panelModel.Panel_GeorgianBar_VerticalQty,
                horizontalQty = _panelModel.Panel_GeorgianBar_HorizontalQty,
                GeorgianBar_GapX = 0,
                GeorgianBar_GapY = 0,
                pInnerX = 0,
                pInnerY = 0,
                sashDeduction = 0,
                sashD = inner_line;
            if (_panelModel.Panel_Type == "Fixed Panel" && _panelModel.Panel_Orient == false)
            {
                sashDeduction = -sashD;
                sashD = 0;
            }
            else
            {
                sashDeduction = sashD;
            }
            if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0724)
            {
                penThickness = 10;
                penThicknessResult = penThickness + 10;
            }
            else if (_panelModel.Panel_GeorgianBarArtNo == GeorgianBar_ArticleNo._0726)
            {
                penThickness = 20;
                penThicknessResult = penThickness - 10;
            }
            Pen pCadetBlue = new Pen(Color.CadetBlue, penThickness);
            int addX = ((pInnerWd - (((int)(pInnerWd + pInnerX - sashDeduction) / (verticalQty + 1)) * verticalQty)) - ((pInnerWd + pInnerX) / (verticalQty + 1))) / 2;
            //vertical
            for (int ii = 0; ii < verticalQty; ii++)
            {
                GBpointResultX = ((pInnerX + pInnerWd - sashDeduction) / (verticalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapX)));
                GeorgianBar_GapX += (pInnerWd + pInnerX - sashDeduction) / (verticalQty + 1);
                Point[] GeorgianBar_PointsX = null;
                GeorgianBar_PointsX = new[]
                {
                    new Point(GBpointResultX + addX,pInnerX+1 + sashD),
                    new Point(GBpointResultX + addX,pInnerX + pInnerHt-1 - sashD),
                };
                for (int i = 0; i < GeorgianBar_PointsX.Length - 1; i += 2)
                {
                    g.DrawLine(pCadetBlue, GeorgianBar_PointsX[i], GeorgianBar_PointsX[i + 1]);
                }
            }
            int addY = ((pInnerHt - (((int)(pInnerHt - sashDeduction + pInnerY) / (horizontalQty + 1)) * horizontalQty)) - ((pInnerHt + pInnerY) / (horizontalQty + 1))) / 2;
            //Horizontal
            for (int ii = 0; ii < horizontalQty; ii++)
            {
                GBpointResultY = ((pInnerY + pInnerHt - sashDeduction) / (horizontalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapY)));
                GeorgianBar_GapY += (pInnerHt - sashDeduction + (pInnerY)) / (horizontalQty + 1);
                Point[] GeorgianBar_PointsY = null;
                GeorgianBar_PointsY = new[]
                {
                    new Point(pInnerY+1 + sashD,GBpointResultY + addX),
                    new Point(pInnerY-1 + pInnerWd - sashD,GBpointResultY + addX),
                };
                for (int i = 0; i < GeorgianBar_PointsY.Length - 1; i += 2)
                {
                    g.DrawLine(pCadetBlue, GeorgianBar_PointsY[i], GeorgianBar_PointsY[i + 1]);
                }
            }
            #endregion


            string glassType = "";
            if (_panelModel.Panel_GlassThicknessDesc != null)
            {
                if (_panelModel.Panel_GlassThicknessDesc.Contains("Tempered"))
                {
                    glassType = "Tempered";
                }
                else if (_panelModel.Panel_GlassThicknessDesc.Contains("Unglazed"))
                {
                    glassType = "Unglazed";
                }
                else
                {
                    glassType = "";
                }
            }

            Font drawFont = new Font("Times New Roman", font_size);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(0,
                                            (awning.ClientRectangle.Height / 2) + 15,
                                            awning.ClientRectangle.Width,
                                            10);

            if (glassType == "Unglazed")
            {
                g.DrawString("P" + _panelModel.PanelGlass_ID + "- " + glassType,
                                      new Font("Segoe UI", 8.0f, FontStyle.Bold),
                                      new SolidBrush(Color.Black),
                                      rect,
                                      drawFormat);
            }
            else
            {
                g.DrawString("P" + _panelModel.PanelGlass_ID + "-" + _panelModel.Panel_GlassThickness.ToString() + "mm " + glassType,
                                        new Font("Segoe UI", 8.0f, FontStyle.Bold),
                                        new SolidBrush(Color.Black),
                                        rect,
                                        drawFormat);
            }

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           awning.ClientRectangle.Width - w,
                                                           awning.ClientRectangle.Height - w));

            Color col = Color.Black;
            g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                           outer_line,
                                                           (awning.ClientRectangle.Width - (outer_line * 2)) - w,
                                                           (awning.ClientRectangle.Height - (outer_line * 2)) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                           inner_line,
                                                           (awning.ClientRectangle.Width - (inner_line * 2)) - w,
                                                           (awning.ClientRectangle.Height - (inner_line * 2)) - w));


            Point sashPoint = new Point(awning.ClientRectangle.X, awning.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = awning.Width,
                sashH = awning.Height;

            if (_panelModel.Panel_Orient == true)
            {
                g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                     new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
                g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                                     new Point(sashPoint.X + sashW, sashPoint.Y));
            }
            else if (_panelModel.Panel_Orient == false)
            {
                g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                                 new Point(sashPoint.X + (sashW / 2), sashPoint.Y));
                g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y),
                                     new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
            }

            if (_timer_count != 0 && _timer_count < 8)
            {
                if (_HeightChange)
                {
                    _commonFunctions.Red_Arrow_Lines_forHeight(g, _panelModel);
                }

                if (_WidthChange)
                {
                    _commonFunctions.Red_Arrow_Lines_forWidth(g, _panelModel);
                }
            }
            else if (_timer_count >= 8)
            {
                _tmr.Stop();
                _timer_count = 0;
                _HeightChange = false;
                _WidthChange = false;
            }
        }

        public IAwningPanelUC GetAwningPanelUC()
        {
            _initialLoad = true;
            _awningPanelUC.ThisBinding(CreateBindingDictionary());
            return _awningPanelUC;
        }


        public IAwningPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<IAwningPanelUC, AwningPanelUC>()
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>();
            AwningPanelUCPresenter awningUCP = unityC.Resolve<AwningPanelUCPresenter>();
            awningUCP._panelModel = panelModel;
            awningUCP._frameModel = frameModel;
            awningUCP._mainPresenter = mainPresenter;
            awningUCP._frameUCP = frameUCP;
            awningUCP._unityC = unityC;

            return awningUCP;
        }

        public IAwningPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP,
                                                        IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<IAwningPanelUC, AwningPanelUC>()
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>();
            AwningPanelUCPresenter awningUCP = unityC.Resolve<AwningPanelUCPresenter>();
            awningUCP._panelModel = panelModel;
            awningUCP._frameModel = frameModel;
            awningUCP._mainPresenter = mainPresenter;
            awningUCP._multiPanelModel = multiPanelModel;
            awningUCP._multiPanelMullionUCP = multiPanelUCP;
            awningUCP._unityC = unityC;
            awningUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return awningUCP;
        }

        public IAwningPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                        IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<IAwningPanelUC, AwningPanelUC>()
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>();
            AwningPanelUCPresenter awningUCP = unityC.Resolve<AwningPanelUCPresenter>();
            awningUCP._panelModel = panelModel;
            awningUCP._frameModel = frameModel;
            awningUCP._mainPresenter = mainPresenter;
            awningUCP._multiPanelModel = multiPanelModel;
            awningUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            awningUCP._unityC = unityC;
            awningUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return awningUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Name", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_WidthToBind", new Binding("Width", _panelModel, "Panel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_HeightToBind", new Binding("Height", _panelModel, "Panel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_DisplayHeight", new Binding("Panel_DisplayHeight", _panelModel, "Panel_DisplayHeight", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_MarginToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_ExtensionOptionsVisibility", new Binding("Panel_ExtensionOptionsVisibility", _panelModel, "Panel_ExtensionOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
