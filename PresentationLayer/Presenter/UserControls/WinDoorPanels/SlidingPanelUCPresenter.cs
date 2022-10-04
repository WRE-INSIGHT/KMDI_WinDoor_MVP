using CommonComponents;
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
    public class SlidingPanelUCPresenter : ISlidingPanelUCPresenter, IPresenterCommon
    {
        ISlidingPanelUC _slidingPanelUC;

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

        bool _initialLoad;
        bool _mouseDown;
        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();

        public SlidingPanelUCPresenter(ISlidingPanelUC slidingPanelUC,
                                       IDividerServices divServices,
                                       ITransomUCPresenter transomUCP,
                                       IMullionUCPresenter mullionUCP,
                                       IMullionImagerUCPresenter mullionImagerUCP,
                                       ITransomImagerUCPresenter transomImagerUCP)
        {
            _slidingPanelUC = slidingPanelUC;
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
            _slidingPanelUC.slidingPanelUCPaintEventRaised += _slidingPanelUC_slidingPanelUCPaintEventRaised;
            _slidingPanelUC.slidingPanelUCMouseEnterEventRaised += _slidingPanelUC_slidingPanelUCMouseEnterEventRaised;
            _slidingPanelUC.slidingPanelUCMouseLeaveEventRaised += _slidingPanelUC_slidingPanelUCMouseLeaveEventRaised;
            _slidingPanelUC.deleteToolStripClickedEventRaised += _slidingPanelUC_deleteToolStripClickedEventRaised;
            _slidingPanelUC.slidingPanelUCSizeChangedEventRaised += _slidingPanelUC_slidingPanelUCSizeChangedEventRaised;
            _slidingPanelUC.slidingPanelUCMouseMoveEventRaised += _slidingPanelUC_slidingPanelUCMouseMoveEventRaised;
            _slidingPanelUC.slidingPanelUCMouseDownEventRaised += _slidingPanelUC_slidingPanelUCMouseDownEventRaised;
            _slidingPanelUC.slidingPanelUCMouseUpEventRaised += _slidingPanelUC_slidingPanelUCMouseUpEventRaised;
            _slidingPanelUC.slidingPanelUCMouseClickEventRaised += _slidingPanelUC_slidingPanelUCMouseClickEventRaised;
            _slidingPanelUC.bothToolStripClickedEventRaised += _slidingPanelUC_BothToolStripClickedEventRaised;
            _slidingPanelUC.leftToolStripClickedEventRaised += _slidingPanelUC_LeftToolStripClickedEventRaised;
            _slidingPanelUC.rightToolStripClickedEventRaised += _slidingPanelUC_RightToolStripClickedEventRaised;
            _slidingPanelUC.noneToolStripClickedEventRaised += _slidingPanelUC_NoneToolStripClickedEventRaised;
            _tmr.Tick += _tmr_Tick;
        }
        private void _slidingPanelUC_slidingPanelUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                Console.WriteLine(_panelModel.Panel_Width);
                Console.WriteLine("Panel Renderer Width " + _panelModel.PanelImageRenderer_Width);
                Console.WriteLine("Panel Renderer Height " + _panelModel.PanelImageRenderer_Height);
                Console.WriteLine("Sliding Width " + _panelModel.Panel_Width);
                Console.WriteLine("Sliding Height " + _panelModel.Panel_Height);
                Console.WriteLine("Sliding WidthToBind " + _panelModel.Panel_WidthToBind);
                Console.WriteLine("Sliding HeightToBind " + _panelModel.Panel_HeightToBind);
                Console.WriteLine();
                slidingUC = (UserControl)sender;
                IWindoorModel wdm = _frameModel.Frame_WindoorModel;
                int propertyHeight = 0;
                int framePropertyHeight = 0;
                int mpnlPropertyHeight = 0;
                bool isTrue = false;
                foreach (IFrameModel fr in wdm.lst_frame)
                {
                    if (isTrue == false)
                    {
                        foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel) //1ndlvlMpnlProperties
                        {
                            foreach (IMultiPanelModel secondLvlMpnl in mpnl.MPanelLst_MultiPanel) // 2ndlvlMpnlProperties
                            {
                                mpnlPropertyHeight += constants.mpnl_propertyHeight_default - 8;
                                if (secondLvlMpnl.MPanel_DividerEnabled)
                                {
                                    foreach (IPanelModel pnl in secondLvlMpnl.MPanelLst_Panel)
                                    {
                                        if (pnl.Panel_Name == slidingUC.Name)
                                        {
                                            propertyHeight += constants.mpnl_propertyHeight_default - 12 + constants.frame_propertyHeight_default + framePropertyHeight + mpnlPropertyHeight;
                                            isTrue = true;
                                            break;
                                        }
                                        else
                                        {
                                            foreach (IDividerModel dvd in secondLvlMpnl.MPanelLst_Divider)
                                            {
                                                propertyHeight += dvd.Div_PropHeight;
                                                break;
                                            }
                                            propertyHeight += pnl.Panel_PropertyHeight;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (IPanelModel pnl in secondLvlMpnl.MPanelLst_Panel)
                                    {
                                        if (pnl.Panel_Name == slidingUC.Name)
                                        {
                                            propertyHeight += constants.mpnl_propertyHeight_default - 12 + constants.frame_propertyHeight_default + framePropertyHeight + mpnlPropertyHeight;
                                            isTrue = true;
                                            break;
                                        }
                                        else
                                        {
                                            propertyHeight += pnl.Panel_PropertyHeight;
                                        }
                                    }
                                }
                                if (isTrue == true)
                                {
                                    break;
                                }
                                mpnlPropertyHeight += 8;
                            }
                            //pnl in 1stlvl mpnl
                            if (mpnl.MPanel_DividerEnabled)
                            {
                                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    if (pnl.Panel_Name == slidingUC.Name)
                                    {

                                        propertyHeight += constants.mpnl_propertyHeight_default - 12 + constants.frame_propertyHeight_default + framePropertyHeight;
                                        isTrue = true;
                                        break;
                                    }
                                    else
                                    {
                                        foreach (IDividerModel dvd in mpnl.MPanelLst_Divider)
                                        {
                                            propertyHeight += dvd.Div_PropHeight;
                                            break;
                                        }
                                        propertyHeight += pnl.Panel_PropertyHeight;
                                    }
                                }
                            }
                            else
                            {
                                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    if (pnl.Panel_Name == slidingUC.Name)
                                    {
                                        propertyHeight += constants.mpnl_propertyHeight_default - 12 + constants.frame_propertyHeight_default + framePropertyHeight;
                                        isTrue = true;
                                        break;
                                    }
                                    else
                                    {
                                        propertyHeight += pnl.Panel_PropertyHeight;
                                    }
                                }
                            }
                            if (isTrue == true)
                            {
                                break;
                            }
                        }
                    }
                    foreach (IPanelModel pnl in fr.Lst_Panel)
                    {
                        if (pnl.Panel_Name == slidingUC.Name)
                        {
                            propertyHeight += constants.frame_propertyHeight_default - 4 + framePropertyHeight;
                            isTrue = true;
                            break;
                        }
                        else
                        {
                            propertyHeight += pnl.Panel_PropertyHeight;
                        }
                    }
                    if (isTrue == true)
                    {
                        break;
                    }
                    propertyHeight = 0;
                    mpnlPropertyHeight = 0;
                    framePropertyHeight += fr.FrameProp_Height;
                    Console.WriteLine("Property " + propertyHeight);
                }
                wdm.WD_PropertiesScroll = propertyHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool isLeft = false;
        private UserControl slidingUC;
        //private bool isRight = false;
        private int sashDeduction = 16;
        private Point _point_of_origin;
        private void _slidingPanelUC_NoneToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)slidingUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)slidingUC);
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

                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 16;
                            pres_pnl.SetDimensionToBind_using_BaseDimension();
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width -= sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                    {

                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 32;
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width -= 32 / (_multiPanelModel.MPanel_Divisions + 1);
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._None;
            ((IPanelUC)_slidingPanelUC).InvalidateThis();
        }
        private void _slidingPanelUC_RightToolStripClickedEventRaised(object sender, EventArgs e)
        {


            var flp = (Control)slidingUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)slidingUC);
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

                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 16;
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width += sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();

                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                    {

                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 16;
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width -= sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._Right;
            ((IPanelUC)_slidingPanelUC).InvalidateThis();

        }
        private void _slidingPanelUC_LeftToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)slidingUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)slidingUC);
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

                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 16;
                            pres_pnl.SetDimensionToBind_using_BaseDimension();
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width += sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
                    {

                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width += 16;
                            //pres_pnl.SetDimensionToBind_using_BaseDimension();
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width -= sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._Left;
            ((IPanelUC)_slidingPanelUC).InvalidateThis();
        }
        private void _slidingPanelUC_BothToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)slidingUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)slidingUC);
                    //Get Panel from left side of Mullion
                    Control pres_ctrl = _multiPanelModel.MPanelLst_Objects[me_indx]; ;

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
                        int sashDiv = 16 / (_multiPanelModel.MPanel_Divisions + 1);
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 16;
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width += sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    else if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
                    {
                        int sashDiv = 32 / (_multiPanelModel.MPanel_Divisions + 1);
                        if (pres_ctrl is IPanelUC)
                        {
                            pres_pnl.Panel_Width -= 32;
                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            pnl.Panel_Width += sashDiv;
                            pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                        }
                        _multiPanelModel.SetZoomPanels();
                    }
                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                    _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                }
            }
            _panelModel.Panel_Overlap_Sash = OverlapSash._Both;
            ((IPanelUC)_slidingPanelUC).InvalidateThis();
        }
        private void _slidingPanelUC_slidingPanelUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isLeft == true)
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
                    if (_multiPanelModel.MPanelLst_Objects.Count >= totalCount_objs_to_accomodate)
                    {
                        _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                        _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    }
                }

                isLeft = false;
                _mouseDown = false;



            }
        }
        private void _slidingPanelUC_slidingPanelUCMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UserControl me = (UserControl)sender;
                _point_of_origin = e.Location;
                if ((e.Location.X > -1) && (e.Location.X < 5) && (_panelModel.Panel_Placement == "Last" || _panelModel.Panel_Placement == "Somewhere in Between"))
                {
                    isLeft = true;
                }
                _mouseDown = true;
            }
        }
        private void _slidingPanelUC_slidingPanelUCMouseMoveEventRaised(object sender, MouseEventArgs e)
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
                    //else if (((e.Location.X > me.Width - 5) && (e.Location.X < me.Width)) && (_panelModel.Panel_Placement == "First" || _panelModel.Panel_Placement == "Somewhere in Between"))
                    //{
                    //    me.Cursor = Cursors.VSplit;
                    //}
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

                        IMultiPanelModel prev_mpanel = null,
                                         nxt_mpnl = null;

                        IPanelModel prev_pnl = null,
                                    pres_pnl = null;

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

                        if (pres_ctrl is IMultiPanelUC)
                        {
                            nxt_mpnl = _multiPanelModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == pres_ctrl.Name);
                            expected_Panel2MinWD = nxt_mpnl.MPanel_WidthToBind - (e.X - _point_of_origin.X);
                        }
                        else if (pres_ctrl is IPanelUC)
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
                                    _mainPresenter.SetChangesMark();
                                    mullion_movement = (e.X - _point_of_origin.X);

                                    if (prev_ctrl is IMultiPanelUC)
                                    {
                                        prev_mpanel.MPanel_Width += mullion_movement;
                                        prev_mpanel.MPanel_DisplayWidth += mullion_movement;

                                        if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                            _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                        {
                                            prev_mpanel.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                            prev_mpanel.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                            prev_mpanel.SetDimensions_childPanelObjs(mullion_movement);
                                            prev_mpanel.ImagerSetDimensions_childPanelObjs(mullion_movement);

                                            foreach (IMultiPanelModel mpanel in prev_mpanel.MPanel_ParentModel.MPanelLst_MultiPanel)
                                            {
                                                mpanel.SetDimensions_childObjs(mullion_movement, "prev");
                                                mpanel.SetDimensions_childPanelObjs(mullion_movement);
                                            }
                                        }
                                        else
                                        {
                                            prev_mpanel.SetDimensionsToBind_using_ParentMultiPanelModel();
                                            prev_mpanel.Imager_SetDimensionsToBind_MullionDivMovement(mullion_movement);

                                            prev_mpanel.SetDimensions_childPanelObjs(mullion_movement);
                                            prev_mpanel.ImagerSetDimensions_childPanelObjs(mullion_movement);

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
                                    }
                                    else if (prev_ctrl is IPanelUC)
                                    {
                                        prev_pnl.Panel_Width += mullion_movement;
                                        prev_pnl.Panel_DisplayWidth += mullion_movement;

                                        if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                            _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                        {
                                            prev_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                            prev_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                        }
                                        else
                                        {
                                            prev_pnl.SetDimensionToBind_using_BaseDimension();
                                            prev_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                            {
                                                mpnl.SetDimensions_childObjs();
                                            }
                                        }
                                    }

                                    if (pres_ctrl is IMultiPanelUC)
                                    {
                                        nxt_mpnl.MPanel_Width -= mullion_movement;
                                        nxt_mpnl.MPanel_DisplayWidth -= mullion_movement;

                                        if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                            _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                        {
                                            nxt_mpnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                            nxt_mpnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                            nxt_mpnl.SetDimensions_childPanelObjs(-mullion_movement);
                                            nxt_mpnl.ImagerSetDimensions_childPanelObjs(-mullion_movement);

                                            foreach (IMultiPanelModel mpanel in nxt_mpnl.MPanel_ParentModel.MPanelLst_MultiPanel)
                                            {
                                                mpanel.SetDimensions_childObjs(-mullion_movement, "nxt");
                                                mpanel.SetDimensions_childPanelObjs(-mullion_movement);
                                            }
                                        }
                                        else
                                        {
                                            nxt_mpnl.SetDimensionsToBind_using_ParentMultiPanelModel();
                                            nxt_mpnl.Imager_SetDimensionsToBind_MullionDivMovement(-mullion_movement);

                                            nxt_mpnl.SetDimensions_childPanelObjs(-mullion_movement);
                                            nxt_mpnl.ImagerSetDimensions_childPanelObjs(-mullion_movement);

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

                                    }
                                    else if (pres_ctrl is IPanelUC)
                                    {
                                        pres_pnl.Panel_Width -= mullion_movement;
                                        pres_pnl.Panel_DisplayWidth -= mullion_movement;

                                        if (_panelModel.Panel_Zoom == 0.26f || _panelModel.Panel_Zoom == 0.17f ||
                                            _panelModel.Panel_Zoom == 0.13f || _panelModel.Panel_Zoom == 0.10f)
                                        {
                                            pres_pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                                            pres_pnl.Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement();

                                        }
                                        else
                                        {
                                            pres_pnl.SetDimensionToBind_using_BaseDimension();
                                            pres_pnl.SetDimensionImagerToBind_using_BaseDimension();
                                            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                                            {
                                                mpnl.SetDimensions_childObjs();
                                            }
                                        }

                                    }
                                }
                                _multiPanelModel.Fit_MyControls_ToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, pres_pnl);
                                _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, pres_pnl);
                            }
                            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
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

        int prev_Width = 0,
            prev_Height = 0;
        private void _slidingPanelUC_slidingPanelUCSizeChangedEventRaised(object sender, EventArgs e)
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
                ((IPanelUC)_slidingPanelUC).InvalidateThis();
            }
        }

        private void _slidingPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete TransomUC
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_slidingPanelUC);

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

            #region Delete Sliding

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_slidingPanelUC, _frameModel.Frame_Type.ToString());
                Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                _multiPanelModel.Reload_PanelMargin();
                _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);
            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_slidingPanelUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_slidingPanelUC);
            }
            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_slidingPanelUC);
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
                }
                //_multiPanelMullionImagerUCP,
                //_multiPanelTransomImagerUCP);
            }
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();

            _mainPresenter.DeletePanelPropertiesUC(_panelModel.Panel_ID);
            _mainPresenter.SetChangesMark();
            _frameModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);

            if (_frameModel != null)
            {
                _frameModel.Lst_Panel.Remove(_panelModel);
            }
            if (_multiPanelModel != null)
            {
                _multiPanelModel.MPanelLst_Panel.Remove(_panelModel);
            }

            #endregion
        }

        private void _slidingPanelUC_slidingPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_slidingPanelUC).InvalidateThis();
        }

        private void _slidingPanelUC_slidingPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_slidingPanelUC).InvalidateThis();
        }

        Color color = Color.Black;
        bool _HeightChange = false,
             _WidthChange = false;
        private void _slidingPanelUC_slidingPanelUCPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            UserControl sliding = (UserControl)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            #region Georgian Bar

            int GBpointResultX, GBpointResultY,
                penThickness = 0, penThicknessResult = 0,
                pInnerWd = sliding.ClientRectangle.Width,
                pInnerHt = sliding.ClientRectangle.Height,
                verticalQty = _panelModel.Panel_GeorgianBar_VerticalQty,
                horizontalQty = _panelModel.Panel_GeorgianBar_HorizontalQty,
                GeorgianBar_GapX = 0,
                GeorgianBar_GapY = 0,
                pInnerX = 0,
                pInnerY = 0;

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

            //vertical
            for (int ii = 0; ii < verticalQty; ii++)
            {
                GBpointResultX = ((pInnerX + pInnerWd) / (verticalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapX)));
                GeorgianBar_GapX += (pInnerWd + (pInnerX)) / (verticalQty + 1);
                Point[] GeorgianBar_PointsX = new[]
              {

                  new Point(GBpointResultX,pInnerX+1),
                  new Point(GBpointResultX,pInnerX + pInnerHt-1),
             };
                for (int i = 0; i < GeorgianBar_PointsX.Length - 1; i += 2)
                {
                    g.DrawLine(pCadetBlue, GeorgianBar_PointsX[i], GeorgianBar_PointsX[i + 1]);
                }
            }

            //Horizontal

            for (int ii = 0; ii < horizontalQty; ii++)
            {
                GBpointResultY = ((pInnerY + pInnerHt) / (horizontalQty + 1) + Convert.ToInt32(Math.Floor((double)GeorgianBar_GapY)));
                GeorgianBar_GapY += (pInnerHt + (pInnerY)) / (horizontalQty + 1);
                Point[] GeorgianBar_PointsY = new[]
              {

                  new Point(pInnerY+1,GBpointResultY ),
                  new Point(pInnerY-1 + pInnerWd,GBpointResultY),
             };
                for (int i = 0; i < GeorgianBar_PointsY.Length - 1; i += 2)
                {
                    g.DrawLine(pCadetBlue, GeorgianBar_PointsY[i], GeorgianBar_PointsY[i + 1]);
                }
            }

            #endregion

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int font_size = 30,
                outer_line = 10,
                inner_line = 15;
            float ArrowExpectedWidth = 0
                    , ArrowExpectedHeight = 0
                    , arrowStartingX = 0
                    , arrowStartingY = 0;
            int sashOverlapValue = 0;
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

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           sliding.ClientRectangle.Width - w,
                                                           sliding.ClientRectangle.Height - w));

            Color col = Color.Black;
            if (_panelModel.Panel_Overlap_Sash == OverlapSash._Right)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                               outer_line,
                                                               (sliding.ClientRectangle.Width - (outer_line * 2)) - w + sashDeduction,
                                                               (sliding.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                               inner_line,
                                                               (sliding.ClientRectangle.Width - (inner_line * 2)) - w + sashDeduction,
                                                               (sliding.ClientRectangle.Height - (inner_line * 2)) - w));

                sashOverlapValue += inner_line;
            }

            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Left)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line - sashDeduction,
                                                          outer_line,
                                                          (sliding.ClientRectangle.Width - (outer_line * 2)) - w + sashDeduction,
                                                          (sliding.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line - sashDeduction,
                                                          inner_line,
                                                          (sliding.ClientRectangle.Width - (inner_line * 2)) - w + sashDeduction,
                                                          (sliding.ClientRectangle.Height - (inner_line * 2)) - w));
                arrowStartingX -= inner_line;
                sashOverlapValue += inner_line;
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line - sashDeduction,
                                                         outer_line,
                                                         (sliding.ClientRectangle.Width - (outer_line * 2)) - w + (sashDeduction * 2),
                                                         (sliding.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line - sashDeduction,
                                                          inner_line,
                                                          (sliding.ClientRectangle.Width - (inner_line * 2)) - w + (sashDeduction * 2),
                                                          (sliding.ClientRectangle.Height - (inner_line * 2)) - w));
                arrowStartingX -= inner_line;
                sashOverlapValue += inner_line * 2;
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                         outer_line,
                                                         (sliding.ClientRectangle.Width - (outer_line * 2)) - w,
                                                         (sliding.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                          inner_line,
                                                          (sliding.ClientRectangle.Width - (inner_line * 2)) - w,
                                                          (sliding.ClientRectangle.Height - (inner_line * 2)) - w));

            }
            Point sashPoint = new Point(sliding.ClientRectangle.X + 25, sliding.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = sliding.Width,
                sashH = sliding.Height;

            #region old algo for drawing

            //float ArrowExpectedWidth = 0
            //    , ArrowExpectedHeight = 0
            //    , arrowStartingX
            //    , arrowStartingY;


            //if (sashW > sashH)
            //{

            //        ArrowExpectedWidth = (float)(sashH * 0.5) ;
            //        ArrowExpectedHeight = (float)(sashH * 0.3);
            //        arrowStartingX += (sashW / 2) - (ArrowExpectedWidth / 2);
            //        arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
            //        g.FillRectangle(new SolidBrush(Color.Black), arrowStartingX, arrowStartingY, ArrowExpectedWidth, ArrowExpectedHeight);
            //        float arwStart_x1 = sashPoint.X + (sashW / 20),
            //              center_y1 = sashPoint.Y + (sashH / 2),
            //              arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 20),
            //              arwHeadUp_x3,
            //              arwHeadUp_y3 = center_y1 - (center_y1 / 4),
            //              arwHeadUp_x4,
            //              arwHeadUp_y4 = center_y1 + (center_y1 / 4);
            //        //sliding
            //        PointF sliding1 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.1));
            //        PointF sliding2 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.1));
            //        PointF sliding3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.1));
            //        PointF sliding4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), ArrowExpectedHeight + arrowStartingY-(float)(ArrowExpectedHeight * 0.25));
            //        PointF sliding5 = new PointF(arrowStartingX + ArrowExpectedWidth, (ArrowExpectedHeight / 2) + arrowStartingY);
            //        PointF sliding6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (float)(ArrowExpectedHeight * 0.25));
            //        PointF sliding7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.1));
            //        //PointF sliding8 = new PointF(arrowStartingX + sliding2.Y - sliding1.Y, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.1));
            //        //PointF sliding9 = new PointF(arrowStartingX + sliding2.Y - sliding1.Y, ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.25));
            //        //PointF sliding10 = new PointF(arrowStartingX, ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.25));
            //        PointF[] slidingCurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

            //        g.FillPolygon(new SolidBrush(Color.Red), slidingCurvePoints);

            //}
            #endregion

            float arwStart_x1 = sashPoint.X + (sashW / 20),
                  center_y1 = sashPoint.Y + (sashH / 2),
                  arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 20),
                  arwHeadUp_x3,
                  arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                  arwHeadUp_x4,
                  arwHeadUp_y4 = center_y1 + (center_y1 / 4);


            if (_panelModel.Panel_Orient == false)
            {

                if (_panelModel.Panel_SlidingTypes == SlidingTypes._Premiline ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._FoldAndSlide ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._Pivot ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._TopHung)
                {
                    //sliding
                    if ((sashW + sashOverlapValue) >= sashH)
                    {

                        ArrowExpectedWidth = (float)(sashH * 0.2);
                        ArrowExpectedHeight = (float)(sashH * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    else if ((sashW + sashOverlapValue) < sashH)
                    {
                        ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.2);
                        ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);

                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                    arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                    PointF sliding1 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF sliding2 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF sliding3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.7), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF sliding4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.7), ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                    PointF sliding5 = new PointF(arrowStartingX + ArrowExpectedWidth, (ArrowExpectedHeight / 2) + arrowStartingY);
                    PointF sliding6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.7), arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                    PointF sliding7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.7), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF[] slidingCurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

                    g.FillPolygon(new SolidBrush(Color.Black), slidingCurvePoints);
                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._Paraslide)
                {
                    //paraslide
                    if ((sashW + sashOverlapValue) >= sashH)
                    {

                        ArrowExpectedWidth = (float)(sashH * 0.3);
                        ArrowExpectedHeight = (float)(sashH * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    else if ((sashW + sashOverlapValue) < sashH)
                    {
                        ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                        ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                    arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                    PointF paraslide1 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.3));
                    PointF paraslide2 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF paraslide3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF paraslide4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                    PointF paraslide5 = new PointF(arrowStartingX + ArrowExpectedWidth, (ArrowExpectedHeight / 2) + arrowStartingY);
                    PointF paraslide6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                    PointF paraslide7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF paraslide8 = new PointF(paraslide1.X + (paraslide3.Y - paraslide7.Y), paraslide7.Y);
                    PointF paraslide9 = new PointF(paraslide1.X + (paraslide3.Y - paraslide7.Y), paraslide1.Y);
                    PointF[] paraslideCurvePoints = { paraslide1, paraslide2, paraslide3, paraslide4, paraslide5, paraslide6, paraslide7, paraslide8, paraslide9 };
                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);

                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._LiftAndSlide)
                {
                    //LiftAndSlide
                    if ((sashW + sashOverlapValue) >= sashH)
                    {

                        ArrowExpectedWidth = (float)(sashH * 0.3);
                        ArrowExpectedHeight = (float)(sashH * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    else if ((sashW + sashOverlapValue) < sashH)
                    {
                        ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                        ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                    arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                    PointF liftandslide1 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF liftandslide2 = new PointF(arrowStartingX, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.3));
                    PointF liftandslide3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF liftandslide4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                    PointF liftandslide5 = new PointF(arrowStartingX + ArrowExpectedWidth, (ArrowExpectedHeight / 2) + arrowStartingY);
                    PointF liftandslide6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                    PointF liftandslide7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.8), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF liftandslide8 = new PointF(liftandslide1.X + (liftandslide3.Y - liftandslide7.Y), liftandslide3.Y);
                    PointF liftandslide9 = new PointF(liftandslide1.X + (liftandslide3.Y - liftandslide7.Y), liftandslide2.Y);
                    PointF[] paraslideCurvePoints = { liftandslide1, liftandslide2, liftandslide9, liftandslide8, liftandslide3, liftandslide4, liftandslide5, liftandslide6, liftandslide7 };
                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                }
            }
            else if (_panelModel.Panel_Orient == true)
            {


                if (_panelModel.Panel_SlidingTypes == SlidingTypes._Premiline ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._FoldAndSlide ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._Pivot ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._TopHung)
                {
                    //sliding
                    if ((sashW + sashOverlapValue) >= sashH)
                    {

                        ArrowExpectedWidth = (float)(sashH * 0.2);
                        ArrowExpectedHeight = (float)(sashH * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    else if ((sashW + sashOverlapValue) < sashH)
                    {
                        ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.2);
                        ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }

                    arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                    arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                    PointF sliding1 = new PointF(arrowStartingX + ArrowExpectedWidth, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF sliding2 = new PointF(arrowStartingX + ArrowExpectedWidth, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF sliding3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.3), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF sliding4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.3), ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                    PointF sliding5 = new PointF(arrowStartingX, (ArrowExpectedHeight / 2) + arrowStartingY);
                    PointF sliding6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.3), arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                    PointF sliding7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.3), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF[] slidingCurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

                    g.FillPolygon(new SolidBrush(Color.Black), slidingCurvePoints);
                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._Paraslide)
                {
                    //paraslide
                    if ((sashW + sashOverlapValue) >= sashH)
                    {

                        ArrowExpectedWidth = (float)(sashH * 0.3);
                        ArrowExpectedHeight = (float)(sashH * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    else if ((sashW + sashOverlapValue) < sashH)
                    {
                        ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                        ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                    arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                    PointF paraslide1 = new PointF(arrowStartingX + ArrowExpectedWidth, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.3));
                    PointF paraslide2 = new PointF(arrowStartingX + ArrowExpectedWidth, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF paraslide3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF paraslide4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                    PointF paraslide5 = new PointF(arrowStartingX, (ArrowExpectedHeight / 2) + arrowStartingY);
                    PointF paraslide6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                    PointF paraslide7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF paraslide8 = new PointF(paraslide1.X - (paraslide3.Y - paraslide7.Y), paraslide7.Y);
                    PointF paraslide9 = new PointF(paraslide1.X - (paraslide3.Y - paraslide7.Y), paraslide1.Y);
                    PointF[] paraslideCurvePoints = { paraslide1, paraslide2, paraslide3, paraslide4, paraslide5, paraslide6, paraslide7, paraslide8, paraslide9 };
                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);

                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._LiftAndSlide)
                {
                    //LiftAndSlide
                    if ((sashW + sashOverlapValue) >= sashH)
                    {

                        ArrowExpectedWidth = (float)(sashH * 0.3);
                        ArrowExpectedHeight = (float)(sashH * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    else if ((sashW + sashOverlapValue) < sashH)
                    {
                        ArrowExpectedWidth = (float)((sashW + sashOverlapValue) * 0.3);
                        ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
                        //g.FillRectangle(new SolidBrush(Color.Red), arrowStartingX, arrowStartingY + Ppoint.Y, ArrowExpectedWidth, ArrowExpectedHeight);
                    }
                    arrowStartingX += ((sashW + sashOverlapValue) / 2) - (ArrowExpectedWidth / 2);
                    arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
                    PointF liftandslide1 = new PointF(arrowStartingX + ArrowExpectedWidth, arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF liftandslide2 = new PointF(arrowStartingX + ArrowExpectedWidth, arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.3));
                    PointF liftandslide3 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), arrowStartingY + (ArrowExpectedHeight / 2) + (float)(ArrowExpectedHeight * 0.15));
                    PointF liftandslide4 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2));
                    PointF liftandslide5 = new PointF(arrowStartingX, +(ArrowExpectedHeight / 2) + arrowStartingY);
                    PointF liftandslide6 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), arrowStartingY + (float)(ArrowExpectedHeight * 0.2));
                    PointF liftandslide7 = new PointF(arrowStartingX + (float)(ArrowExpectedWidth * 0.2), arrowStartingY + (ArrowExpectedHeight / 2) - (float)(ArrowExpectedHeight * 0.15));
                    PointF liftandslide8 = new PointF(liftandslide1.X - (liftandslide3.Y - liftandslide7.Y), liftandslide3.Y);
                    PointF liftandslide9 = new PointF(liftandslide1.X - (liftandslide3.Y - liftandslide7.Y), liftandslide2.Y);
                    PointF[] paraslideCurvePoints = { liftandslide1, liftandslide2, liftandslide9, liftandslide8, liftandslide3, liftandslide4, liftandslide5, liftandslide6, liftandslide7 };
                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                }

            }



            string glassType = "";
            if (_panelModel.Panel_GlassThicknessDesc.Contains("Tempered"))
            {
                glassType = "Tempered";
            }
            else
            {
                glassType = "";
            }


            Font drawFont = new Font("Times New Roman", font_size);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            if ((sashW + sashOverlapValue) >= sashH)
            {
                ArrowExpectedHeight = (float)(sashH * 0.3);
            }
            else if ((sashW + sashOverlapValue) < sashH)
            {
                ArrowExpectedHeight = (float)((sashW + sashOverlapValue) * 0.3);
            }

            arrowStartingY = (sashH / 2) - (ArrowExpectedHeight / 2);
            //ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2);

            RectangleF rect = new RectangleF(0,
                                            (ArrowExpectedHeight + arrowStartingY - (float)(ArrowExpectedHeight * 0.2)), //sliding.ClientRectangle.Height / 2) + 33,
                                            sliding.ClientRectangle.Width,
                                            10);

            g.DrawString("P" + _panelModel.PanelGlass_ID + "-" + _panelModel.Panel_GlassThickness.ToString() + "mm " + glassType,
                         new Font("Segoe UI", 8.0f, FontStyle.Bold),
                         new SolidBrush(Color.Black),
                         rect,
                         drawFormat);



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

        public ISlidingPanelUC GetSlidingPanelUC()
        {
            _initialLoad = true;
            _slidingPanelUC.ThisBinding(CreateBindingDictionary());
            return _slidingPanelUC;
        }


        public ISlidingPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                       IPanelModel panelModel,
                                                       IFrameModel frameModel,
                                                       IMainPresenter mainPresenter,
                                                       IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ISlidingPanelUC, SlidingPanelUC>()
                .RegisterType<ISlidingPanelUCPresenter, SlidingPanelUCPresenter>();
            SlidingPanelUCPresenter slidingUCP = unityC.Resolve<SlidingPanelUCPresenter>();
            slidingUCP._panelModel = panelModel;
            slidingUCP._frameModel = frameModel;
            slidingUCP._mainPresenter = mainPresenter;
            slidingUCP._frameUCP = frameUCP;
            slidingUCP._unityC = unityC;

            return slidingUCP;
        }

        public ISlidingPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                       IPanelModel panelModel,
                                                       IFrameModel frameModel,
                                                       IMainPresenter mainPresenter,
                                                       IMultiPanelModel multiPanelModel,
                                                       IMultiPanelMullionUCPresenter multiPanelUCP,
                                                       IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<ISlidingPanelUC, SlidingPanelUC>()
                .RegisterType<ISlidingPanelUCPresenter, SlidingPanelUCPresenter>();
            SlidingPanelUCPresenter slidingUCP = unityC.Resolve<SlidingPanelUCPresenter>();
            slidingUCP._panelModel = panelModel;
            slidingUCP._frameModel = frameModel;
            slidingUCP._mainPresenter = mainPresenter;
            slidingUCP._multiPanelModel = multiPanelModel;
            slidingUCP._multiPanelMullionUCP = multiPanelUCP;
            slidingUCP._unityC = unityC;
            slidingUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return slidingUCP;
        }

        public ISlidingPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                       IPanelModel panelModel,
                                                       IFrameModel frameModel,
                                                       IMainPresenter mainPresenter,
                                                       IMultiPanelModel multiPanelModel,
                                                       IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                       IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<ISlidingPanelUC, SlidingPanelUC>()
                .RegisterType<ISlidingPanelUCPresenter, SlidingPanelUCPresenter>();
            SlidingPanelUCPresenter slidingUCP = unityC.Resolve<SlidingPanelUCPresenter>();
            slidingUCP._panelModel = panelModel;
            slidingUCP._frameModel = frameModel;
            slidingUCP._mainPresenter = mainPresenter;
            slidingUCP._multiPanelModel = multiPanelModel;
            slidingUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            slidingUCP._unityC = unityC;
            slidingUCP._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return slidingUCP;
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
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

    }
}
