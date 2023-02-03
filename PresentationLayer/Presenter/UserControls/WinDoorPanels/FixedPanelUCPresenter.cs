using CommonComponents;
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
using System.Linq;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class FixedPanelUCPresenter : IFixedPanelUCPresenter, IPresenterCommon
    {

        IFixedPanelUC _fixedPanelUC;

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
        bool _mouseDown;
        private IDividerServices _divServices;

        bool _initialLoad;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _keydown;
        public bool boolKeyDown
        {
            set
            {
                _keydown = value;
            }
        }
        public FixedPanelUCPresenter(IFixedPanelUC fixedPanelUC,
                                     IDividerServices divServices,
                                     ITransomUCPresenter transomUCP,
                                     IMullionUCPresenter mullionUCP,
                                     IMullionImagerUCPresenter mullionImagerUCP,
                                     ITransomImagerUCPresenter transomImagerUCP)
        {
            _fixedPanelUC = fixedPanelUC;
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
            _fixedPanelUC.deleteToolStripClickedEventRaised += _fixedPanelUC_deleteToolStripClickedEventRaised;
            _fixedPanelUC.fixedPanelUCPaintEventRaised += _fixedPanelUC_fixedPanelUCPaintEventRaised;
            _fixedPanelUC.fixedPanelMouseLeaveEventRaised += _fixedPanelUC_fixedPanelMouseLeaveEventRaised;
            _fixedPanelUC.fixedPanelMouseEnterEventRaised += _fixedPanelUC_fixedPanelMouseEnterEventRaised;
            _fixedPanelUC.fixedPanelSizeChangedEventRaised += _fixedPanelUC_fixedPanelSizeChangedEventRaised;
            _fixedPanelUC.fixedPanelUCMouseDownEventRaised += _fixedPanelUC_fixedPanelUCMouseDownEventRaised;
            _fixedPanelUC.fixedPanelUCMouseClickEventRaised += _fixedPanelUC_fixedPanelUCMouseClickEventRaised;
            _fixedPanelUC.fixedPanelUCMouseMoveEventRaised += _fixedPanelUC_fixedPanelUCMouseMoveEventRaised;
            _fixedPanelUC.fixedPanelUCMouseUpEventRaised += _fixedPanelUC_fixedPanelUCMouseUpEventRaised;
            _fixedPanelUC.bothToolStripClickedEventRaised += _fixedPanelUC_BothToolStripClickedEventRaised;
            _fixedPanelUC.leftToolStripClickedEventRaised += _fixedPanelUC_LeftToolStripClickedEventRaised;
            _fixedPanelUC.rightToolStripClickedEventRaised += _fixedPanelUC_RightToolStripClickedEventRaised;
            _fixedPanelUC.noneToolStripClickedEventRaised += _fixedPanelUC_NoneToolStripClickedEventRaised;
            _fixedPanelUC.fixedPanelUCMouseDoubleClickedEventRaised += _fixedPanelUC_fixedPanelUCMouseDoubleClickedEventRaised;
            _fixedPanelUC.fixedPanelUCKeyDownEventRaised += _fixedPanelUC_fixedPanelUCKeyDownEventRaised;
            _tmr.Tick += _tmr_Tick;
        }

        private void _fixedPanelUC_fixedPanelUCKeyDownEventRaised(object sender, KeyEventArgs e)
        {
            if (_multiPanelModel != null &&
              !_multiPanelModel.MPanel_DividerEnabled && _multiPanelModel.GetCount_MPanelLst_Object() > 1
               && _multiPanelModel.MPanelLst_Objects.Count - 1 != _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender))
            {
                int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender);

                Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];

                Control nxt_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx + 1];
                if (_multiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                {
                    pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];
                }

                IPanelModel prev_pnl = null,
                            pres_pnl = null;

                if (nxt_ctrl is IPanelUC)
                {
                    prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == nxt_ctrl.Name);

                }
                if (pres_ctrl is IPanelUC)
                {
                    pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);

                }

                FlowLayoutPanel flp = (FlowLayoutPanel)((UserControl)_fixedPanelUC).Parent; //MultiPanel Container
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                           actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();

                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        _mainPresenter.DeselectPanel();
                        _keydown = false;
                        break;
                    case Keys.Down:

                        if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel && _keydown)
                        {

                            if (nxt_ctrl is IPanelUC)
                            {
                                prev_pnl.Panel_Width += 1;
                                prev_pnl.Panel_DisplayWidth += 1;

                                if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                    _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                {
                                    prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    prev_pnl.SetDimensionToBind_using_BaseDimension();
                                }
                                prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            }
                            if (pres_ctrl is IPanelUC)
                            {
                                pres_pnl.Panel_Width -= 1;
                                pres_pnl.Panel_DisplayWidth -= 1;

                                if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                    _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                {
                                    pres_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    pres_pnl.SetDimensionToBind_using_BaseDimension();
                                }
                                pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            }
                            _multiPanelModel.Fit_MyControls_ToBindDimensions(null, null, prev_pnl, pres_pnl);
                            IPanelModel pnls = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Overlap_Sash != OverlapSash._None);
                            if (pnls == null)
                            {
                                _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(null, null, prev_pnl, pres_pnl);
                                _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                            }

                        }
                        _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.GetCurrentPrice();

                        break;
                    case Keys.Up:

                        if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel && _keydown)
                        {


                            if (nxt_ctrl is IPanelUC)
                            {
                                prev_pnl.Panel_Width -= 1;
                                prev_pnl.Panel_DisplayWidth -= 1;

                                if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                    _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                {
                                    prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    prev_pnl.SetDimensionToBind_using_BaseDimension();
                                }
                                prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            }
                            if (pres_ctrl is IPanelUC)
                            {
                                pres_pnl.Panel_Width += 1;
                                pres_pnl.Panel_DisplayWidth += 1;

                                if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                    _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                {
                                    pres_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                }
                                else
                                {
                                    pres_pnl.SetDimensionToBind_using_BaseDimension();
                                }
                                pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            }
                            _multiPanelModel.Fit_MyControls_ToBindDimensions(null, null, prev_pnl, pres_pnl);
                            IPanelModel pnls = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Overlap_Sash != OverlapSash._None);
                            if (pnls == null)
                            {
                                _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(null, null, prev_pnl, pres_pnl);
                                _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                            }

                        }
                        _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.GetCurrentPrice();

                        break;
                }
            }
        }

        private void _fixedPanelUC_fixedPanelUCMouseDoubleClickedEventRaised(object sender, MouseEventArgs e)
        {
            if (_multiPanelModel != null)
            {
                if (!_multiPanelModel.MPanel_DividerEnabled)
                {

                    int thisIndx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_fixedPanelUC);
                    if (thisIndx != _multiPanelModel.MPanelLst_Objects.Count - 1)
                    {
                        _mainPresenter.SetSelectedPanel(_panelModel, null, null, this);
                    }
                }
            }

        }

        private void _fixedPanelUC_fixedPanelUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                //       Console.WriteLine("**Panel Width*" + _panelModel.Panel_WidthWithDecimal);
                //Console.WriteLine("**Panel Width To Bind*" + _multiPanelModel.MPanel_WidthToBind);
                fixedUC = (UserControl)sender;

                if (e.Button == MouseButtons.Right && _panelModel.Panel_CmenuDeleteVisibility == true)
                {

                    if (!_panelModel.Panel_Parent.Name.Contains("Frame") && _panelModel.Panel_ChkText == "dSash")
                        _fixedPanelUC.cmenuFxdOverlapSashVisibility = true;
                    else
                        _fixedPanelUC.cmenuFxdOverlapSashVisibility = false;
                    _fixedPanelUC.GetcmenuFxd().Show(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
                else
                {
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
                                        if (pnl.Panel_Name == fixedUC.Name)
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
                                                        if (pnl.Panel_Name == fixedUC.Name)
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
                                                                        if (pnl.Panel_Name == fixedUC.Name)
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
                                                                                    if (pnl.Panel_Name == fixedUC.Name)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _fixedPanelUC_NoneToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)fixedUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object(),
                    totalpanel_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1;
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)fixedUC);
                    //Get Panel from left side of Mullion
                    Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx]; ;

                    if (_multiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                    {
                        //Get Panel from right side of Mullion
                        pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];
                    }
                    IPanelModel pres_pnl = null;
                    int sashDiv = 16 / (_multiPanelModel.MPanel_Divisions + 1);
                    //Get the expected Panel w
                    if (pres_ctrl is IPanelUC)
                    {
                        pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);
                    }
                    if (_panelModel.Panel_Overlap_Sash == OverlapSash._Left || _panelModel.Panel_Overlap_Sash == OverlapSash._Right)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._None;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 16;
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
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
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._None;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 32;
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
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
                        _multiPanelModel.SetZoomPanels();
                    }

                    pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Overlap_Sash != OverlapSash._None);
                    if (pres_pnl == null)
                    {
                        _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.GetCurrentPrice();

                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._None;
            ((IPanelUC)_fixedPanelUC).InvalidateThis();
        }


        private void _fixedPanelUC_RightToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)fixedUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object(),
                    totalpanel_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1;
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)fixedUC);
                    //Get Panel from left side of Mullion
                    Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx]; ;

                    if (_multiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                    {
                        //Get Panel from right side of Mullion
                        pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];
                    }
                    IPanelModel pres_pnl = null;
                    int sashDiv = 16 / (_multiPanelModel.MPanel_Divisions + 1);
                    //Get the expected Panel w
                    if (pres_ctrl is IPanelUC)
                    {
                        pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);
                    }
                    if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._Right;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 16;
                            //pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Right)
                            {
                                pnl.Panel_Width += (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                            }
                            else
                            {
                                pnl.Panel_Width += sashDiv;
                            }
                            pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();


                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._Right;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 16;
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Right)
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
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.GetCurrentPrice();

                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._Right;
            ((IPanelUC)_fixedPanelUC).InvalidateThis();

        }
        private void _fixedPanelUC_LeftToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)fixedUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object(),
                    totalpanel_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1;
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)fixedUC);
                    //Get Panel from left side of Mullion
                    Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx]; ;

                    if (_multiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                    {
                        //Get Panel from right side of Mullion
                        pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];
                    }
                    IPanelModel pres_pnl = null;
                    int sashDiv = 16 / (_multiPanelModel.MPanel_Divisions + 1);
                    //Get the expected Panel w
                    if (pres_ctrl is IPanelUC)
                    {
                        pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);
                    }
                    if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._Left;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 16;
                            //pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Right)
                            {
                                pnl.Panel_Width += (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                            }
                            else
                            {
                                pnl.Panel_Width += sashDiv;
                            }
                            pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();


                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._Left;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 16;
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Right)
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
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.GetCurrentPrice();

                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._Left;
            ((IPanelUC)_fixedPanelUC).InvalidateThis();
        }
        private void _fixedPanelUC_BothToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)fixedUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object(),
                    totalpanel_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1;
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)fixedUC);
                    //Get Panel from left side of Mullion
                    Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];

                    if (_multiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                    {
                        //Get Panel from right side of Mullion
                        pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];
                    }
                    IPanelModel pres_pnl = null;


                    //Get the expected Panel w
                    if (pres_ctrl is IPanelUC)
                    {
                        pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);
                    }
                    if (_panelModel.Panel_Overlap_Sash == OverlapSash._Right || _panelModel.Panel_Overlap_Sash == OverlapSash._Left)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._Both;
                        int sashDiv = 16 / (_multiPanelModel.MPanel_Divisions + 1);
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 16;
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {

                            if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Right)
                            {
                                pnl.Panel_Width += (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                            }
                            else
                            {
                                pnl.Panel_Width += sashDiv;
                            }
                            pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
                    {
                        _panelModel.Panel_Overlap_Sash = OverlapSash._Both;
                        int sashDiv = 32 / totalpanel_inside_parentMpanel;
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 32;
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Overlap_Sash == OverlapSash._Left || pnl.Panel_Overlap_Sash == OverlapSash._Right)
                            {
                                pnl.Panel_Width += (int)Math.Ceiling((decimal)16 / totalpanel_inside_parentMpanel);
                            }
                            else
                            {
                                pnl.Panel_Width += sashDiv;
                            }
                            pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.GetCurrentPrice();

                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._Both;
            ((IPanelUC)_fixedPanelUC).InvalidateThis();
        }
        private void _fixedPanelUC_fixedPanelUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeft = false;
                _mouseDown = false;
                if (_multiPanelModel != null)
                {
                    int totalCount_objs_to_accomodate = _multiPanelModel.MPanel_Divisions + 1;
                    if (_multiPanelModel.MPanel_DividerEnabled)
                    {
                        totalCount_objs_to_accomodate = (_multiPanelModel.MPanel_Divisions * 2) + 1;
                    }
                    else
                    {
                        totalCount_objs_to_accomodate = _multiPanelModel.MPanel_Divisions + 1;
                    }
                    if ((_multiPanelModel.MPanelLst_Objects.Count >= totalCount_objs_to_accomodate) &&
                        !_multiPanelModel.MPanel_DividerEnabled)
                    {
                        _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    }
                }
            }
        }
        private bool isLeft = false;
        private UserControl fixedUC;
        //private bool isRight = false;
        private int sashDeduction = 20;
        private Point _point_of_origin;
        private void _fixedPanelUC_fixedPanelUCMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                if (_multiPanelModel != null &&
                !_multiPanelModel.MPanel_DividerEnabled && _multiPanelModel.GetCount_MPanelLst_Object() > 1)
                {
                    UserControl me = (UserControl)sender;
                    if ((e.Location.X > -1) && (e.Location.X < 5) && (_panelModel.Panel_Placement == "Last" || _panelModel.Panel_Placement == "Somewhere in Between"))
                    {
                        me.Cursor = Cursors.VSplit;
                    }
                    else
                    {
                        me.Cursor = Cursors.Hand;
                    }
                    if (isLeft)
                    {
                        int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)sender);

                        Control prev_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx - 1];
                        Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];

                        if (_multiPanelModel.GetCount_MPanelLst_Object() > me_indx)
                        {
                            pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx];
                        }

                        int expected_Panel1MinWD = 0,
                            expected_Panel2MinWD = 0,
                            mullion_movement = 0;
                        IPanelModel prev_pnl = null,
                                    pres_pnl = null;

                        if (prev_ctrl is IPanelUC)
                        {
                            prev_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == prev_ctrl.Name);
                            expected_Panel1MinWD = prev_pnl.Panel_WidthToBind + (e.X - _point_of_origin.X);
                        }
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Name == pres_ctrl.Name);
                            expected_Panel2MinWD = pres_pnl.Panel_WidthToBind - (e.X - _point_of_origin.X);
                        }

                        FlowLayoutPanel flp = (FlowLayoutPanel)me.Parent; //MultiPanel Container

                        int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                            actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                        if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel && e.Button == MouseButtons.Left && _mouseDown)
                        {
                            if (me_indx != 0 && flp.Controls.Count > (me_indx))
                            {
                                if (expected_Panel1MinWD >= 30 && expected_Panel2MinWD >= 30)
                                {
                                    mullion_movement = (e.X - _point_of_origin.X);
                                    if (prev_ctrl is IPanelUC)
                                    {
                                        prev_pnl.Panel_Width += mullion_movement;
                                        prev_pnl.Panel_DisplayWidth += mullion_movement;

                                        if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                            _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                        {
                                            prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        }
                                        else
                                        {
                                            prev_pnl.SetDimensionToBind_using_BaseDimension();
                                        }
                                        prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                    if (pres_ctrl is IPanelUC)
                                    {
                                        pres_pnl.Panel_Width -= mullion_movement;
                                        pres_pnl.Panel_DisplayWidth -= mullion_movement;

                                        if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                            _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                        {
                                            pres_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        }
                                        else
                                        {
                                            pres_pnl.SetDimensionToBind_using_BaseDimension();
                                        }
                                        pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                    }
                                }
                                _multiPanelModel.Fit_MyControls_ToBindDimensions(null, null, prev_pnl, pres_pnl);
                                IPanelModel pnls = _multiPanelModel.MPanelLst_Panel.Find(pnl => pnl.Panel_Overlap_Sash != OverlapSash._None);
                                if (pnls == null)
                                {
                                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(null, null, prev_pnl, pres_pnl);
                                    _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                                }

                            }
                            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                            _mainPresenter.GetCurrentPrice();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _fixedPanelUC_fixedPanelUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserControl me = (UserControl)sender;
                _point_of_origin = e.Location;

                if ((e.Location.X > -1 && e.Location.X < 4) && (_panelModel.Panel_Placement == "Last" || _panelModel.Panel_Placement == "Somewhere in Between"))
                {
                    isLeft = true;
                }
                //if (((e.Location.X > me.Width - 5) && (e.Location.X < me.Width)) && (_panelModel.Panel_Placement == "First" || _panelModel.Panel_Placement == "Somewhere in Between"))
                //{
                //    isRight = true;
                //}
                _mouseDown = true;
            }
        }
        int prev_Width = 0,
            prev_Height = 0;
        private void _fixedPanelUC_fixedPanelSizeChangedEventRaised(object sender, EventArgs e)
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

        int _timer_count;
        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                ((IPanelUC)_fixedPanelUC).InvalidateThis();
            }
        }

        private void _fixedPanelUC_fixedPanelMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_fixedPanelUC).InvalidateThis();
        }

        private void _fixedPanelUC_fixedPanelMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_fixedPanelUC).InvalidateThis();
        }

        Color color = Color.Gray;

        bool _HeightChange = false,
             _WidthChange = false;
        private void _fixedPanelUC_fixedPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl fixedpnl = (UserControl)sender;

            Graphics g = e.Graphics;
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            g.SmoothingMode = SmoothingMode.HighQuality;

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
                pInnerWd = fixedpnl.ClientRectangle.Width,
                pInnerHt = fixedpnl.ClientRectangle.Height,
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
                //if (ii != 0)
                //{
                //    GeorgianBar_PointsX = new[]
                //    {
                //     new Point(GBpointResultX ,pInnerX+1 + sashD),
                //     new Point(GBpointResultX,pInnerX + pInnerHt-1 - sashD),
                //    };
                //}
                //else
                //{
                //    GeorgianBar_PointsX = new[]
                //    {
                //        new Point(GBpointResultX,pInnerX+1 + sashD),
                //        new Point(GBpointResultX,pInnerX + pInnerHt-1 - sashD),
                //    };
                //    GeorgianBar_GapX += (addX / 2);
                //}

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
                //if (ii != 0)
                //{
                //    GeorgianBar_PointsY = new[]
                //    {
                //        new Point(pInnerY+1 + sashD ,GBpointResultY+ addY),
                //        new Point(pInnerY-1 + pInnerWd - sashD,GBpointResultY+ addY),
                //    };
                //    GeorgianBar_GapY += addY;
                //}
                //else
                //{
                //    GeorgianBar_PointsY = new[]
                //    {
                //        new Point(pInnerY+1 + sashD,GBpointResultY),
                //        new Point(pInnerY-1 + pInnerWd - sashD,GBpointResultY),
                //    };
                //}
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
            g.DrawString("F", drawFont, new SolidBrush(Color.Black), fixedpnl.ClientRectangle, drawFormat);

            RectangleF rect = new RectangleF(0,
                                            (fixedpnl.ClientRectangle.Height / 2) + 15,
                                            fixedpnl.ClientRectangle.Width,
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
                                                            fixedpnl.ClientRectangle.Width - w,
                                                            fixedpnl.ClientRectangle.Height - w));



            Color col = Color.Black;

            if (_panelModel.Panel_Overlap_Sash == OverlapSash._Right)
            {

                if (_panelModel.Panel_ChkText == "dSash")
                {
                    g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                          outer_line,
                                                          (fixedpnl.ClientRectangle.Width - (outer_line * 2)) - w + sashDeduction,
                                                          (fixedpnl.ClientRectangle.Height - (outer_line * 2)) - w));
                }
               


                if (_panelModel.Panel_Orient == true)
                {
                    g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                          inner_line,
                                                          (fixedpnl.ClientRectangle.Width - (inner_line * 2)) - w + sashDeduction,
                                                          (fixedpnl.ClientRectangle.Height - (inner_line * 2)) - w));
                }
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Left)
            {
                if (_panelModel.Panel_ChkText == "dSash")
                {
                    g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line - sashDeduction,
                                                         outer_line,
                                                         (fixedpnl.ClientRectangle.Width - (outer_line * 2)) - w + sashDeduction,
                                                         (fixedpnl.ClientRectangle.Height - (outer_line * 2)) - w));
                }
               
                if (_panelModel.Panel_Orient == true)
                {
                    g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line - sashDeduction,
                                                         inner_line,
                                                         (fixedpnl.ClientRectangle.Width - (inner_line * 2)) - w + sashDeduction,
                                                         (fixedpnl.ClientRectangle.Height - (inner_line * 2)) - w));
                }
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
            {
                if (_panelModel.Panel_ChkText == "dSash")
                {
                    g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line - sashDeduction,
                                                         outer_line,
                                                         (fixedpnl.ClientRectangle.Width - (outer_line * 2)) - w + (sashDeduction * 2),
                                                         (fixedpnl.ClientRectangle.Height - (outer_line * 2)) - w));
                }
                
                if (_panelModel.Panel_Orient == true)
                {
                    g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line - sashDeduction,
                                                          inner_line,
                                                          (fixedpnl.ClientRectangle.Width - (inner_line * 2)) - w + (sashDeduction * 2),
                                                          (fixedpnl.ClientRectangle.Height - (inner_line * 2)) - w));
                }
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
            {
                if (_panelModel.Panel_ChkText == "dSash")
                {
                    g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                         outer_line,
                                                         (fixedpnl.ClientRectangle.Width - (outer_line * 2)) - w,
                                                         (fixedpnl.ClientRectangle.Height - (outer_line * 2)) - w));
                }
                
                if (_panelModel.Panel_Orient == true)
                {
                    g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                          inner_line,
                                                          (fixedpnl.ClientRectangle.Width - (inner_line * 2)) - w,
                                                          (fixedpnl.ClientRectangle.Height - (inner_line * 2)) - w));
                }
            }
            if (_timer_count != 0 && _timer_count < 8) // INSIDE ARROW NA MAY TIMER
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

        private void _fixedPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {

            #region Delete Divider
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_fixedPanelUC);
                Control nextCtrl = null,
                        prevCtrl = null;
                if(_multiPanelModel.MPanelLst_Objects.Count > (this_indx + 2))
                {
                    nextCtrl = _multiPanelModel.MPanelLst_Objects[this_indx + 2];
                    if (!nextCtrl.Name.Contains("Multi"))
                    {
                        nextCtrl = null;
                    }
                    if(this_indx > 1)
                    {
                        prevCtrl = _multiPanelModel.MPanelLst_Objects[this_indx - 2];
                        if (!prevCtrl.Name.Contains("Multi"))
                        {
                            prevCtrl = null;
                        }
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
                       

                        if(prevCtrl == null)
                        {
                            IDividerModel leftDiv = _multiPanelModel.MPanelLst_Divider.Find(divs => divs.Div_Name == ((UserControl)mullionUC).Name);
                            leftDiv.Div_WidthToBind -= div_mpnl_deduct_Tobind;
                            leftDiv.Div_Width -= 8;
                        }
                        
                        _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                        mullionUC.InvalidateThis();
                        if(leftMpnl != null)
                        {
                            leftMpnl.MPanel_WidthToBind -= div_mpnl_deduct_Tobind;
                        }
                    }
                    else if (divCtrl.Name.Contains("Transom"))
                    {
                        ITransomUC transomUC = (TransomUC)_multiPanelModel.MPanelLst_Objects[this_indx - 1];
                        if (prevCtrl == null)
                        {
                            IDividerModel leftDiv = _multiPanelModel.MPanelLst_Divider.Find(divs => divs.Div_Name == ((UserControl)transomUC).Name);
                            leftDiv.Div_HeightToBind -= div_mpnl_deduct_Tobind;
                            leftDiv.Div_Height -= 8;
                        }
                        _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)transomUC, _frameModel.Frame_Type.ToString());
                        transomUC.InvalidateThis();
                        if (leftMpnl != null)
                        {
                            leftMpnl.MPanel_HeightToBind -= div_mpnl_deduct_Tobind;
                        }
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

            #region Delete Fixed

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_fixedPanelUC, _frameModel.Frame_Type.ToString());
                Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                _multiPanelModel.Reload_PanelMargin();

                _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);

            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_fixedPanelUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_fixedPanelUC);
            }
            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_fixedPanelUC);
            }

            if (_multiPanelModel != null)
            {
                _multiPanelModel.Object_Indexer();
                _multiPanelModel.Reload_PanelMargin();
                _multiPanelModel.Reload_MultiPanelMargin();
                if (_multiPanelModel.MPanel_DividerEnabled)
                {
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
            }


            _mainPresenter.DeletePanelPropertiesUC(_panelModel.Panel_ID);

            _mainPresenter.GetCurrentPrice();

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
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            #endregion
            _mainPresenter.DeselectDivider();
            _mainPresenter.itemDescription();
            _mainPresenter.GetCurrentPrice();
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._panelModel = panelModel;
            fixedPanelUCP._frameModel = frameModel;
            fixedPanelUCP._mainPresenter = mainPresenter;
            fixedPanelUCP._frameUCP = frameUCP;
            fixedPanelUCP._unityC = unityC;

            return fixedPanelUCP;
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IMultiPanelModel multiPanelModel,
                                                     IMultiPanelMullionUCPresenter multiPanelUCP,
                                                     IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._panelModel = panelModel;
            fixedPanelUCP._frameModel = frameModel;
            fixedPanelUCP._mainPresenter = mainPresenter;
            fixedPanelUCP._multiPanelModel = multiPanelModel;
            fixedPanelUCP._multiPanelMullionUCP = multiPanelUCP;
            fixedPanelUCP._unityC = unityC;
            fixedPanelUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return fixedPanelUCP;
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IPanelModel panelModel,
                                                     IFrameModel frameModel,
                                                     IMainPresenter mainPresenter,
                                                     IMultiPanelModel multiPanelModel,
                                                     IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                     IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._panelModel = panelModel;
            fixedPanelUCP._frameModel = frameModel;
            fixedPanelUCP._mainPresenter = mainPresenter;
            fixedPanelUCP._multiPanelModel = multiPanelModel;
            fixedPanelUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            fixedPanelUCP._unityC = unityC;
            fixedPanelUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return fixedPanelUCP;
        }

        public IFixedPanelUC GetFixedPanelUC()
        {
            _initialLoad = true;
            _fixedPanelUC.ThisBinding(CreateBindingDictionary());
            return _fixedPanelUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Name", new Binding("Name", _panelModel, "Panel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Width", _panelModel, "Panel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Height", _panelModel, "Panel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Orient", new Binding("pnl_Orientation", _panelModel, "Panel_Orient", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Margin", new Binding("Margin", _panelModel, "Panel_MarginToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Placement", new Binding("Panel_Placement", _panelModel, "Panel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelGlass_ID", new Binding("PanelGlass_ID", _panelModel, "PanelGlass_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
        public void FocusOnThisFixedPanel()
        {
            _fixedPanelUC.FocusOnThis();
        }
    }
}
