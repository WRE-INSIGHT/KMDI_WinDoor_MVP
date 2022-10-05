using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
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
    public class CasementPanelUCPresenter : ICasementPanelUCPresenter, IPresenterCommon
    {
        ICasementPanelUC _casementUC;

        private IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;
        private IMultiPanelModel _multiPanelModel;

        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelMullionImagerUCPresenter _multiPanelMullionImagerUCP;
        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP;

        private ITransomUCPresenter _transomUCP;
        private IMullionUCPresenter _mullionUCP;
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;

        private IDividerServices _divServices;

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();

        bool _initialLoad;

        public CasementPanelUCPresenter(ICasementPanelUC casementUC,
                                        IDividerServices divServices,
                                        ITransomUCPresenter transomUCP,
                                        IMullionUCPresenter mullionUCP,
                                        IMullionImagerUCPresenter mullionImagerUCP,
                                        ITransomImagerUCPresenter transomImagerUCP)
        {
            _casementUC = casementUC;
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
            _casementUC.casementPanelUCPaintEventRaised += new PaintEventHandler(OnCasementPanelUCPaintEventRaised);
            _casementUC.casementPanelUCMouseEnterEventRaised += new EventHandler(OnCasementPanelUCMouseEnterEventRaised);
            _casementUC.casementPanelUCMouseLeaveEventRaised += new EventHandler(OnCasementPanelUCMouseLeaveEventRaised);
            _casementUC.deleteToolStripClickedEventRaised += new EventHandler(OnDeleteToolStripClickedEventRaised);
            _casementUC.casementPanelUCMouseClickEventRaised += _casementUC_casementPanelUCMouseClickEventRaised;
            _casementUC.casementPanelUCSizeChangedEventRaised += _casementUC_casementPanelUCSizeChangedEventRaised;
            _casementUC.casementPanelUCMouseDownEventRaised += _casementUC_casementPanelUCMouseDownEventRaised;
            _casementUC.casementPanelUCMouseMoveEventRaised += _casementUC_casementPanelUCMouseMoveEventRaised;
            _casementUC.casementPanelUCMouseUpEventRaised += _casementUC_casementPanelUCMouseUpEventRaised;
            _casementUC.bothToolStripClickedEventRaised += _casementUC_BothToolStripClickedEventRaised;
            _casementUC.leftToolStripClickedEventRaised += _casementUC_LeftToolStripClickedEventRaised;
            _casementUC.rightToolStripClickedEventRaised += _casementUC_RightToolStripClickedEventRaised;
            _casementUC.noneToolStripClickedEventRaised += _casementUC_NoneToolStripClickedEventRaised;
            _tmr.Tick += _tmr_Tick;
        }
        private void _casementUC_NoneToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)casementUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)casementUC);
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
            ((IPanelUC)_casementUC).InvalidateThis();
        }


        private void _casementUC_RightToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)casementUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)casementUC);
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
            ((IPanelUC)_casementUC).InvalidateThis();
        }
        private void _casementUC_LeftToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)casementUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)casementUC);
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
            ((IPanelUC)_casementUC).InvalidateThis();
        }
        private void _casementUC_BothToolStripClickedEventRaised(object sender, EventArgs e)
        {
            var flp = (Control)casementUC.Parent; //MultiPanel Container
            if (flp.Name.Contains("MultiMullion"))
            {
                int expected_total_controls_inside_parentMpanel = _multiPanelModel.MPanel_Divisions + 1, // count of object
                    actual_total_controls_inside_parentMpanel = _multiPanelModel.GetCount_MPanelLst_Object();
                if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel)
                {
                    _mainPresenter.SetChangesMark();
                    int me_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((Control)casementUC);
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
            ((IPanelUC)_casementUC).InvalidateThis();
        }
        private bool isLeft = false;
        private UserControl casementUC;
        //private bool isRight = false;
        private int sashDeduction = 16;
        private Point _point_of_origin;
        private void _casementUC_casementPanelUCMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeft = false;
            }
        }

        private void _casementUC_casementPanelUCMouseMoveEventRaised(object sender, MouseEventArgs e)
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
                        if (expected_total_controls_inside_parentMpanel == actual_total_controls_inside_parentMpanel && e.Button == MouseButtons.Left)
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
                            }
                            _multiPanelModel.Fit_MyControls_ToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, pres_pnl);
                            _multiPanelModel.Fit_MyControls_ImagersToBindDimensions(prev_mpanel, nxt_mpnl, prev_pnl, pres_pnl);
                        }
                        _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                        _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
                    }


                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _casementUC_casementPanelUCMouseDownEventRaised(object sender, MouseEventArgs e)
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
            }
        }
        int prev_Width = 0,
            prev_Height = 0;
        private void _casementUC_casementPanelUCSizeChangedEventRaised(object sender, EventArgs e)
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

        private void _casementUC_casementPanelUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            casementUC = (UserControl)sender;
            if (_panelModel.Panel_BackColor == SystemColors.Highlight)
            {
                _panelModel.Panel_HandleType = Handle_Type._None;
                if (_panelModel.Panel_CornerDriveOptionsVisibility == true)
                {
                    _panelModel.Panel_CornerDriveOptionsVisibility = false;
                    _panelModel.AdjustPropertyPanelHeight("minusCornerDrive");
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");

                }
                _mainPresenter.DivModel_forDMSelection.Div_DMPanel = _panelModel;
                _mainPresenter.PrevPnlModel_forDMSelection.Panel_BackColor = Color.DarkGray;
                if (_mainPresenter.NxtPnlModel_forDMSelection != null)
                {
                    _mainPresenter.NxtPnlModel_forDMSelection.Panel_BackColor = Color.DarkGray;
                }
                _mainPresenter.SetLblStatus("DMSelection", false, null, null, _panelModel);
            }
            IWindoorModel wdm = _frameModel.Frame_WindoorModel;
            int propertyHeight = 0;

            foreach (IFrameModel fr in wdm.lst_frame)
            {

                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                {

                    if (mpnl.MPanel_DividerEnabled)
                    {
                        foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                        {
                            if (pnl.Panel_Name == casementUC.Name)
                            {
                                propertyHeight += 382;
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
                            if (pnl.Panel_Name == casementUC.Name)
                            {
                                propertyHeight += 382;
                                break;
                            }
                            else
                            {
                                propertyHeight += pnl.Panel_PropertyHeight;
                            }
                        }
                    }
                }
            }
            wdm.WD_PropertiesScroll = propertyHeight;
        }

        int _timer_count;
        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                ((IPanelUC)_casementUC).InvalidateThis();
            }
        }

        private void OnDeleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete Divider
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_casementUC);

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

            #region Delete Casement

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_casementUC, _frameModel.Frame_Type.ToString());
                Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                _multiPanelModel.Reload_PanelMargin();

                _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);

            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_casementUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_casementUC);
            }
            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_casementUC);
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
                    //_multiTransomImagerUCP);
                }
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

            _mainPresenter.DeselectDivider();
        }

        private void OnCasementPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_casementUC).InvalidateThis();
        }

        private void OnCasementPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_casementUC).InvalidateThis();
        }

        Color color = Color.Black;

        bool _HeightChange = false,
             _WidthChange = false;
        private void OnCasementPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl casement = (UserControl)sender;

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
                pInnerWd = casement.ClientRectangle.Width,
                pInnerHt = casement.ClientRectangle.Height,
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
                                            (casement.ClientRectangle.Height / 2) + 15,
                                             casement.ClientRectangle.Width,
                                            10);

            RectangleF inwardStr_rect = new RectangleF(0,
                                                      (casement.ClientRectangle.Height / 2) + 30,
                                                       casement.ClientRectangle.Width,
                                                      10);

            string in_or_out = "";
            if (_panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395 ||
                _panelModel.Panel_SashProfileArtNo == SashProfile_ArticleNo._373)
            {
                in_or_out = "Inward";
            }

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


            g.DrawString(in_or_out,
                         new Font("Segoe UI", 8.0f, FontStyle.Bold),
                         new SolidBrush(Color.Black),
                         inwardStr_rect,
                         drawFormat);

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           casement.ClientRectangle.Width - w,
                                                           casement.ClientRectangle.Height - w));

            Color col = Color.Black;
            if (_panelModel.Panel_Overlap_Sash == OverlapSash._Right)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                           outer_line,
                                                           (casement.ClientRectangle.Width - (outer_line * 2)) - w + sashDeduction,
                                                           (casement.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                          inner_line,
                                                          (casement.ClientRectangle.Width - (inner_line * 2)) - w + sashDeduction,
                                                          (casement.ClientRectangle.Height - (inner_line * 2)) - w));
            }

            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Left)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line - sashDeduction,
                                                          outer_line,
                                                          (casement.ClientRectangle.Width - (outer_line * 2)) - w + sashDeduction,
                                                          (casement.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line - sashDeduction,
                                                          inner_line,
                                                          (casement.ClientRectangle.Width - (inner_line * 2)) - w + sashDeduction,
                                                          (casement.ClientRectangle.Height - (inner_line * 2)) - w));
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._Both)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line - sashDeduction,
                                                         outer_line,
                                                         (casement.ClientRectangle.Width - (outer_line * 2)) - w + (sashDeduction * 2),
                                                         (casement.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line - sashDeduction,
                                                          inner_line,
                                                          (casement.ClientRectangle.Width - (inner_line * 2)) - w + (sashDeduction * 2),
                                                          (casement.ClientRectangle.Height - (inner_line * 2)) - w));
            }
            else if (_panelModel.Panel_Overlap_Sash == OverlapSash._None)
            {
                g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                         outer_line,
                                                         (casement.ClientRectangle.Width - (outer_line * 2)) - w,
                                                         (casement.ClientRectangle.Height - (outer_line * 2)) - w));
                g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                          inner_line,
                                                          (casement.ClientRectangle.Width - (inner_line * 2)) - w,
                                                          (casement.ClientRectangle.Height - (inner_line * 2)) - w));
            }
            Point sashPoint = new Point(casement.ClientRectangle.X, casement.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = casement.Width,
                sashH = casement.Height;

            if (_panelModel.Panel_Orient == true)//Left
            {
                g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                                         new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                     new Point(sashPoint.X + sashW, sashPoint.Y + sashH));
            }
            else if (_panelModel.Panel_Orient == false)//Right
            {
                g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                     new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))));
                g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))),
                                     new Point(sashPoint.X, sashH + sashPoint.Y));
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

        public ICasementPanelUC GetCasementPanelUC()
        {
            _initialLoad = true;
            _casementUC.ThisBinding(CreateBindingDictionary());
            return _casementUC;
        }

        public ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ICasementPanelUC, CasementPanelUC>()
                .RegisterType<ICasementPanelUCPresenter, CasementPanelUCPresenter>();
            CasementPanelUCPresenter casementUCP = unityC.Resolve<CasementPanelUCPresenter>();
            casementUCP._panelModel = panelModel;
            casementUCP._frameModel = frameModel;
            casementUCP._mainPresenter = mainPresenter;
            casementUCP._frameUCP = frameUCP;
            casementUCP._unityC = unityC;

            return casementUCP;
        }

        public ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP,
                                                        IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<ICasementPanelUC, CasementPanelUC>()
                .RegisterType<ICasementPanelUCPresenter, CasementPanelUCPresenter>();
            CasementPanelUCPresenter casementUCP = unityC.Resolve<CasementPanelUCPresenter>();
            casementUCP._panelModel = panelModel;
            casementUCP._frameModel = frameModel;
            casementUCP._mainPresenter = mainPresenter;
            casementUCP._multiPanelModel = multiPanelModel;
            casementUCP._multiPanelMullionUCP = multiPanelUCP;
            casementUCP._unityC = unityC;
            casementUCP._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return casementUCP;
        }

        public ICasementPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiTransomUCP,
                                                        IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP)
        {
            unityC
                .RegisterType<ICasementPanelUC, CasementPanelUC>()
                .RegisterType<ICasementPanelUCPresenter, CasementPanelUCPresenter>();
            CasementPanelUCPresenter casementUCP = unityC.Resolve<CasementPanelUCPresenter>();
            casementUCP._panelModel = panelModel;
            casementUCP._frameModel = frameModel;
            casementUCP._mainPresenter = mainPresenter;
            casementUCP._multiPanelModel = multiPanelModel;
            casementUCP._multiPanelTransomUCP = multiTransomUCP;
            casementUCP._unityC = unityC;
            casementUCP._multiTransomImagerUCP = multiTransomImagerUCP;

            return casementUCP;
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
            panelBinding.Add("Panel_BackColor", new Binding("BackColor", _panelModel, "Panel_BackColor", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_CmenuDeleteVisibility", new Binding("Panel_CmenuDeleteVisibility", _panelModel, "Panel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
