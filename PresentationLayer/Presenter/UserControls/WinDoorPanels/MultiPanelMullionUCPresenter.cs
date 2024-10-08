using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using ModelLayer.Variables;
using PresentationLayer.CommonMethods;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Dividers;
using PresentationLayer.Views.UserControls.Dividers.Imagers;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ServiceLayer.Services.DividerServices;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
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
    public class MultiPanelMullionUCPresenter : IMultiPanelMullionUCPresenter, IPresenterCommon
    {
        IMultiPanelMullionUC _multiPanelMullionUC;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;

        private IUnityContainer _unityC;
        private IUserModel _userModel;
        private IMultiPanelModel _multiPanelModel;
        private IFrameModel _frameModel;
        private IDividerModel _prev_divModel;
        private ConstantVariables constants = new ConstantVariables();
        private IMainPresenter _mainPresenter;
        private IFixedPanelUCPresenter _fixedUCP;
        private IFixedPanelImagerUCPresenter _fixedImagerUCP;
        private ICasementPanelUCPresenter _casementUCP;
        private ICasementPanelImagerUCPresenter _casementImagerUCP;
        private IAwningPanelUCPresenter _awningUCP;
        private IAwningPanelImagerUCPresenter _awningImagerUCP;
        private ISlidingPanelUCPresenter _slidingUCP;
        private ISlidingPanelImagerUCPresenter _slidingImagerUCP;
        private ITiltNTurnPanelUCPresenter _tiltNTurnUCP;
        private ILouverPanelUCPresenter _louverPanelUCP;
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IDividerPropertiesUCPresenter _divPropertiesUCP;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IMullionUCPresenter _mullionUCP;
        private IMullionImagerUCPresenter _mullionImagerUCP;
        private ITransomUCPresenter _transomUCP;
        private ITransomImagerUCPresenter _transomImagerUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelMullionUCPresenter _multiPanelMullionUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP_orig;  //Injected Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance
        private IBasePlatformImagerUCPresenter _basePlatformImagerUCP;
        private IFrameImagerUCPresenter _frameImagerUCP;
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP; //Given Instance
        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP_Injected; //Injected Instance
        private IMultiPanelTransomImagerUCPresenter _multiTransomImagerUCP; //Injected Instance

        private IMultiPanelMullionImagerUCPresenter _multiMullionImagerUCP_parent; //parent instance of Imager counterpart
        private IMultiPanelTransomImagerUCPresenter _multiPanelTransomImagerUCP_parent; //parent instance of Imager counterpart

        private IDividerServices _divServices;
        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;

        bool _initialLoad;

        private MultiPanelCommon _mpnlCommons = new MultiPanelCommon();
        private CommonFunctions _commonFunctions = new CommonFunctions();

        Timer _tmr = new Timer();

        public IMultiPanelPropertiesUCPresenter multiPropUCP2_given
        {
            get
            {
                return _multiPropUCP2_given;
            }
        }

        public MultiPanelMullionUCPresenter(IMultiPanelMullionUC multiPanelMullionUC,
                                            IFixedPanelUCPresenter fixedUCP,
                                            ICasementPanelUCPresenter casementUCP,
                                            IAwningPanelUCPresenter awningUCP,
                                            ISlidingPanelUCPresenter slidingUCP,
                                            ITiltNTurnPanelUCPresenter tiltNTurnUCP,
                                            ILouverPanelUCPresenter louverPanelUCP,
                                            IPanelServices panelServices,
                                            IMultiPanelServices multipanelServices,
                                            IPanelPropertiesUCPresenter panelPropertiesUCP,
                                            IfrmDimensionPresenter frmDimensionPresenter,
                                            IFixedPanelImagerUCPresenter fixedImagerUCP,
                                            ICasementPanelImagerUCPresenter casementImagerUCP,
                                            IAwningPanelImagerUCPresenter awningImagerUCP,
                                            ISlidingPanelImagerUCPresenter slidingImagerUCP,
                                            IMullionUCPresenter mullionUCP,
                                            ITransomUCPresenter transomUCP,
                                            IDividerServices divServices,
                                            IMultiPanelPropertiesUCPresenter multiPropUCP_orig,
                                            IMullionImagerUCPresenter mullionImagerUCP,
                                            ITransomImagerUCPresenter transomImagerUCP,
                                            IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP,
                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP_Injected,
                                            IDividerPropertiesUCPresenter divPropertiesUCP)
        {
            _multiPanelMullionUC = multiPanelMullionUC;
            _fixedUCP = fixedUCP;
            _casementUCP = casementUCP;
            _awningUCP = awningUCP;
            _slidingUCP = slidingUCP;
            _tiltNTurnUCP = tiltNTurnUCP;
            _louverPanelUCP = louverPanelUCP;
            _panelServices = panelServices;
            _multipanelServices = multipanelServices;
            _panelPropertiesUCP = panelPropertiesUCP;
            _frmDimensionPresenter = frmDimensionPresenter;
            _fixedImagerUCP = fixedImagerUCP;
            _casementImagerUCP = casementImagerUCP;
            _mullionUCP = mullionUCP;
            _transomUCP = transomUCP;
            _divServices = divServices;
            _multiPropUCP_orig = multiPropUCP_orig;
            _mullionImagerUCP = mullionImagerUCP;
            _awningImagerUCP = awningImagerUCP;
            _slidingImagerUCP = slidingImagerUCP;
            _transomImagerUCP = transomImagerUCP;
            _multiTransomImagerUCP = multiTransomImagerUCP;
            _multiMullionImagerUCP_Injected = multiMullionImagerUCP_Injected;
            _divPropertiesUCP = divPropertiesUCP;

            _tmr = new Timer();
            _tmr.Interval = 200;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelMullionUC.flpMulltiPaintEventRaised += _multiPanelMullionUC_flpMulltiPaintEventRaised;
            _multiPanelMullionUC.flpMultiMouseEnterEventRaised += _multiPanelMullionUC_flpMultiMouseEnterEventRaised;
            _multiPanelMullionUC.flpMultiMouseLeaveEventRaised += _multiPanelMullionUC_flpMultiMouseLeaveEventRaised;
            _multiPanelMullionUC.divCountClickedEventRaised += _multiPanelMullionUC_divCountClickedEventRaised;
            _multiPanelMullionUC.deleteClickedEventRaised += _multiPanelMullionUC_deleteClickedEventRaised;
            _multiPanelMullionUC.flpMultiDragDropEventRaised += _multiPanelMullionUC_flpMultiDragDropEventRaised;
            _multiPanelMullionUC.multiMullionSizeChangedEventRaised += _multiPanelMullionUC_multiMullionSizeChangedEventRaised;
            _multiPanelMullionUC.dividerEnabledCheckedChangedEventRaised += _multiPanelMullionUC_dividerEnabledCheckedChangedEventRaised;
            _multiPanelMullionUC.flpMultiDragOverEventRaised += _multiPanelMullionUC_flpMultiDragOverEventRaised;
            _multiPanelMullionUC.multiMullionUCMouseClickEventRaised += _multiPanelMullionUC_multiMullionUCMouseClickEventRaised;
            _tmr.Tick += _tmr_Tick;
        }
        private FlowLayoutPanel multiMullionUC;
        private void _multiPanelMullionUC_multiMullionUCMouseClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {

                Console.WriteLine("Mpanel Width " + _multiPanelModel.MPanel_WidthToBind);
                Console.WriteLine("Mpanel height " + _multiPanelModel.MPanel_HeightToBind);
                Console.WriteLine();
                multiMullionUC = (FlowLayoutPanel)sender;
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
                                foreach (PanelModel pnl in frm.Lst_Panel)
                                {
                                    if (pnl.Panel_Name == wndrObject.Name)
                                    {
                                        pnlPropertyHeight += pnl.Panel_PropertyHeight;
                                        break;
                                    }
                                }
                                #endregion
                                #region 2nd Level MultiPanel
                                foreach (MultiPanelModel mpnl in frm.Lst_MultiPanel)
                                {
                                    if (mpnl.MPanel_Name == multiMullionUC.Parent.Name)
                                    {
                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + divPropertyHeight + pnlPropertyHeight - 5;
                                        return;

                                    }
                                    else
                                    {
                                        mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                    }
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
                                                    if (thirdlvlmpnl.MPanel_Name == multiMullionUC.Parent.Name)
                                                    {
                                                        _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + divPropertyHeight + pnlPropertyHeight - 11;
                                                        return;

                                                    }
                                                    else
                                                    {
                                                        mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                    }
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
                                                                    divPropertyHeight += div.Div_PropHeight;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        foreach (MultiPanelModel fourthlvlmpnl in thirdlvlmpnl.MPanelLst_MultiPanel)
                                                        {
                                                            if (thirdlvlctrl.Name == fourthlvlmpnl.MPanel_Name)
                                                            {
                                                                if (fourthlvlmpnl.MPanel_Name == multiMullionUC.Parent.Name)
                                                                {
                                                                    _mainPresenter.PropertiesScroll = propertyHeight + framePropertyHeight + concretePropertyHeight + mpnlPropertyHeight + divPropertyHeight + pnlPropertyHeight - 19;
                                                                    return;

                                                                }
                                                                else
                                                                {
                                                                    mpnlPropertyHeight += constants.mpnl_propertyHeight_default;
                                                                }
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
            catch (Exception)
            {

            }
        }

        private void _multiPanelMullionUC_flpMultiDragOverEventRaised(object sender, DragEventArgs e)
        {
            int totalCount_objs_to_accomodate = 0;
            if (_multiPanelModel.MPanel_DividerEnabled)
            {
                totalCount_objs_to_accomodate = (_multiPanelModel.MPanel_Divisions * 2) + 1;
            }
            else
            {
                totalCount_objs_to_accomodate = _multiPanelModel.MPanel_Divisions + 1;
            }
            List<object> lst_data = e.Data.GetData(e.Data.GetFormats()[0]) as List<object>;

            string data = lst_data[0].ToString();

            if (_multiPanelModel.MPanelLst_Objects.Count() < totalCount_objs_to_accomodate)
            {
                if (data.Contains("Multi-Panel") && data.Contains("Mullion"))
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        int _timer_count;
        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
            }
        }

        private void _multiPanelMullionUC_dividerEnabledCheckedChangedEventRaised(object sender, EventArgs e)
        {
            _multiPanelModel.MPanel_DividerEnabled = ((ToolStripMenuItem)sender).Checked;
        }

        int prev_Width = 0,
            prev_Height = 0;
        private void _multiPanelMullionUC_multiMullionSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        mpnlModelWd = _multiPanelModel.MPanel_WidthToBind,
                        mpnlModelHt = _multiPanelModel.MPanel_HeightToBind;

                    if (thisWd != mpnlModelWd || prev_Width != mpnlModelWd)
                    {
                        //_multiPanelModel.MPanel_Width = thisWd;
                        _WidthChange = true;
                    }
                    if (thisHt != mpnlModelHt || prev_Height != mpnlModelHt)
                    {
                        //_multiPanelModel.MPanel_Height = thisHt;
                        _HeightChange = true;
                    }
                }
                prev_Width = _multiPanelModel.MPanel_WidthToBind;
                prev_Height = _multiPanelModel.MPanel_HeightToBind;

                _tmr.Start();
                ((UserControl)sender).Invalidate();
                _basePlatformImagerUCP.InvalidateBasePlatform();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int _frmDmRes_Width;
        private int _frmDmRes_Height;

        private int divSize = 0;
        private void _multiPanelMullionUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {
            try
            {
                _mainPresenter.ForceRestartAndLoadFile();//chksrobj
                FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
                int totalCount_objs_to_accomodate = 0;
                if (_multiPanelModel.MPanel_DividerEnabled)
                {
                    totalCount_objs_to_accomodate = (_multiPanelModel.MPanel_Divisions * 2) + 1;
                }
                else
                {
                    totalCount_objs_to_accomodate = _multiPanelModel.MPanel_Divisions + 1;
                }

                List<object> lst_data = e.Data.GetData(e.Data.GetFormats()[0]) as List<object>;

                string data = lst_data[0].ToString();
                int divCount = Convert.ToInt32(lst_data[1]);
                int iteration = Convert.ToInt32(lst_data[2]);

                int totalPanelCount = _multiPanelModel.MPanel_Divisions + 1;

                divSize = (int)_frameModel.Frame_Type;



                for (int i = 0; i < iteration; i++)
                {
                    if (_multiPanelModel != null)
                    {
                        if (_multiPanelModel.MPanelLst_Objects.Count() >= totalCount_objs_to_accomodate)
                        {
                            break;
                        }
                    }
                    IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);
                    if (data.Contains("Multi-Panel"))
                    {
                        if (_multiPanelModel.MPanel_StackNo < 3)
                        {
                            int suggest_Wd = (((_multiPanelModel.MPanel_Width) - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount),
                                suggest_HT = _multiPanelModel.MPanel_Height,
                                mpanelDisplayHeight = _multiPanelModel.MPanel_DisplayHeight,
                                suggest_DisplayHTDecimal = _multiPanelModel.MPanel_DisplayHeightDecimal;



                            //string disp_wd_decimal = _multiPanelModel.MPanel_DisplayWidth + "." + _multiPanelModel.MPanel_DisplayWidthDecimal;
                            //decimal DisplayWD_dec = Convert.ToDecimal(disp_wd_decimal) / totalPanelCount;
                            //if (_userModel.Department == "Sales & Operations (Costing)")
                            //{
                            //    DisplayWD_dec = Convert.ToInt32(DisplayWD_dec);
                            //}
                            //int suggest_DisplayWD = (int)Math.Truncate(DisplayWD_dec);
                            //int DisplayWD_singleDecimalPlace = 0;

                            //string[] DisplayWD_dec_split = decimal.Round(DisplayWD_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            //if (DisplayWD_dec_split.Count() > 1)
                            //{
                            //    DisplayWD_singleDecimalPlace = Convert.ToInt32(DisplayWD_dec_split[1]);
                            //}


                            #region MyRegion
                            string disp_wd_decimal = _multiPanelModel.MPanel_DisplayWidth + "." + _multiPanelModel.MPanel_DisplayWidthDecimal;
                            decimal displayWidthDecimal = 0;
                            decimal displayWidth = 0;
                            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                            {
                                displayWidth += Convert.ToDecimal(mpnl.MPanel_DisplayWidth + "." + mpnl.MPanel_DisplayWidthDecimal);
                                displayWidthDecimal = Convert.ToDecimal("0." + mpnl.MPanel_DisplayWidthDecimal);
                            }
                            foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                            {
                                displayWidth += Convert.ToDecimal(pnl.Panel_DisplayWidth + "." + pnl.Panel_DisplayWidthDecimal);
                                displayWidthDecimal = Convert.ToDecimal("0." + pnl.Panel_DisplayWidthDecimal);
                            }
                            decimal DisplayWD_dec;
                            if (displayWidth == 0)
                            {
                                DisplayWD_dec = Convert.ToDecimal(disp_wd_decimal) / totalPanelCount;
                            }
                            else
                            {
                                DisplayWD_dec = Math.Floor((Convert.ToDecimal(disp_wd_decimal) - displayWidth) / (totalPanelCount - (_multiPanelModel.MPanelLst_Panel.Count + _multiPanelModel.MPanelLst_MultiPanel.Count)));

                            }
                            if (_userModel.Department == "Sales & Operations (Costing)")
                            {
                                DisplayWD_dec = Convert.ToInt32(DisplayWD_dec);
                            }
                            DisplayWD_dec += displayWidthDecimal;




                            int suggest_DisplayWD = (int)Math.Truncate(DisplayWD_dec);

                            int DisplayWD_singleDecimalPlace = 0;

                            string[] DisplayWD_dec_split = decimal.Round(DisplayWD_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayWD_dec_split.Count() > 1)
                            {
                                DisplayWD_singleDecimalPlace = Convert.ToInt32(DisplayWD_dec_split[1]);
                            }

                            if (_userModel.Department != "Sales & Operations (Costing)")
                            {
                                int EqualDisplayWD = (int)Math.Truncate(Convert.ToDecimal(disp_wd_decimal) / totalPanelCount);
                                int EqualMPanelWD = ((_multiPanelModel.MPanel_Width - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);
                                suggest_Wd = EqualMPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                            }

                            #endregion

                            FlowDirection flow = FlowDirection.LeftToRight;
                            if (data.Contains("Transom"))
                            {
                                flow = FlowDirection.TopDown;
                            }

                            int increment_StackNo = _multiPanelModel.MPanel_StackNo + 1;

                            IMultiPanelModel mPanelModel = _multipanelServices.AddMultiPanelModel(suggest_Wd,
                                                                                                  suggest_HT,
                                                                                                  suggest_DisplayWD,
                                                                                                  DisplayWD_singleDecimalPlace,
                                                                                                  mpanelDisplayHeight,
                                                                                                  suggest_DisplayHTDecimal,
                                                                                                  fpnl,
                                                                                                  (UserControl)_frameUCP.GetFrameUC(),
                                                                                                  _frameModel,
                                                                                                  true,
                                                                                                  flow,
                                                                                                  _frameModel.Frame_Zoom,
                                                                                                  _mainPresenter.GetMultiPanelCount(),
                                                                                                  DockStyle.None,
                                                                                                  increment_StackNo,
                                                                                                  _multiPanelModel.GetNextIndex(),
                                                                                                  _multiPanelModel,
                                                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                                                  "",
                                                                                                  divCount);
                            _frameModel.Lst_MultiPanel.Add(mPanelModel);
                            _multiPanelModel.MPanelLst_MultiPanel.Add(mPanelModel);
                            _multiPanelModel.Reload_MultiPanelMargin();

                            mPanelModel.SetDimensionsToBind_using_ZoomPercentage();
                            mPanelModel.Imager_SetDimensionsToBind_using_ParentMultiPanelModel_Initial();

                            IMultiPanelPropertiesUCPresenter multiPropUCP = _multiPropUCP_orig.GetNewInstance(_unityC, mPanelModel, _mainPresenter);
                            UserControl multiProp = (UserControl)multiPropUCP.GetMultiPanelPropertiesUC();
                            multiProp.Dock = DockStyle.Top;
                            _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(multiProp);
                            multiProp.BringToFront();

                            _multiPanelModel.AdjustPropertyPanelHeight("Mpanel", "add");
                            _frameModel.AdjustPropertyPanelHeight("Mpanel", "add");

                            if (data.Contains("Transom"))
                            {
                                IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP = _multiTransomImagerUCP.GetNewInstance(_unityC,
                                                                                                                                 mPanelModel,
                                                                                                                                 _frameModel,
                                                                                                                                 _multiMullionImagerUCP);
                                IMultiPanelTransomImagerUC multiTransomImagerUC = multiTransomImagerUCP.GetMultiPanelImager();
                                _multiMullionImagerUCP.AddControl((UserControl)multiTransomImagerUC);
                                _basePlatformImagerUCP.InvalidateBasePlatform();
                                _multiPanelModel.MPanelLst_Imagers.Add((UserControl)multiTransomImagerUC);

                                IMultiPanelTransomUCPresenter multiTransom = _multiPanelTransomUCP.GetNewInstance(_unityC,
                                                                                                                  _userModel,
                                                                                                                  mPanelModel,
                                                                                                                  _frameModel,
                                                                                                                  _mainPresenter,
                                                                                                                  _frameUCP,
                                                                                                                  this,
                                                                                                                  multiPropUCP,
                                                                                                                  _frameImagerUCP,
                                                                                                                  _basePlatformImagerUCP,
                                                                                                                  multiTransomImagerUCP,
                                                                                                                  _multiMullionImagerUCP);
                                IMultiPanelTransomUC multiUC = multiTransom.GetMultiPanel();
                                fpnl.Controls.Add((UserControl)multiUC);
                                multiTransom.SetInitialLoadFalse();
                                _multiPanelModel.AddControl_MPanelLstObjects((UserControl)multiUC, _frameModel.Frame_Type.ToString());
                                _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)multiUC, _frameModel.Frame_Type.ToString());

                                if (mPanelModel.MPanel_Placement == "Last")
                                {
                                    //if (_multiPanelModel.MPanel_Zoom == 0.5 || _multiPanelModel.MPanel_Zoom == 1)
                                    //{
                                    //    _multiPanelModel.Fit_MyControls_Dimensions();

                                    //}
                                    if (_multiPanelModel.MPanel_ParentModel != null)
                                    {

                                        if (_multiPanelModel.MPanel_ParentModel.MPanel_Parent.Name.Contains("Frame"))
                                        {
                                            _frameModel.Lst_MultiPanel = _mainPresenter.Arrange_Frame_MultiPanelModel(_frameModel);
                                        }
                                    }
                                    _multiPanelModel.Fit_EqualPanel_ToBindDimensions();
                                    _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                                    _multiPanelModel.Fit_MyControls_ToBindDimensions();
                                    _mainPresenter.Run_GetListOfMaterials_SpecificItem();

                                }
                                else if (mPanelModel.MPanel_Placement != "Last")
                                {
                                    bool divchkdm = false;

                                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door && _mainPresenter.windoorModel_MainPresenter.WD_profile.Contains("C70"))
                                    {
                                        if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            divchkdm = true;
                                        }
                                    }

                                    IDividerModel divModel = _divServices.AddDividerModel(divSize,
                                                                                         _multiPanelModel.MPanel_Height,
                                                                                         fpnl,
                                                                                         DividerModel.DividerType.Mullion,
                                                                                         true,
                                                                                         _frameModel.Frame_Zoom,
                                                                                         Divider_ArticleNo._7536,
                                                                                         _multiPanelModel.MPanel_DisplayWidth,
                                                                                         _multiPanelModel.MPanel_DisplayHeight,
                                                                                          _multiPanelModel,
                                                                                          _frameModel,
                                                                                          _userModel,
                                                                                         _mainPresenter.GetDividerCount(),
                                                                                         _frameModel.FrameImageRenderer_Zoom,
                                                                                         "",
                                                                                         "",
                                                                                         null,
                                                                                         divchkdm);

                                    divModel.SetDimensionsToBind_using_DivZoom();
                                    divModel.SetDimensionsToBind_using_DivZoom_Imager_Initial();

                                    _prev_divModel = divModel;
                                    _frameModel.Lst_Divider.Add(divModel);
                                    _multiPanelModel.MPanelLst_Divider.Add(divModel);

                                    IDividerPropertiesUCPresenter divPropUCP = _divPropertiesUCP.GetNewInstance(_unityC, divModel, _mainPresenter);
                                    divPropUCP.GetDivProperties().ProfileType_FromMainPresenter = _frameModel.Frame_WindoorModel.WD_profile;
                                    UserControl divPropUC = (UserControl)divPropUCP.GetDivProperties();
                                    divPropUC.Dock = DockStyle.Top;
                                    _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                                    divPropUC.BringToFront();

                                    _multiPanelModel.AdjustPropertyPanelHeight("Div", "add");
                                    _frameModel.AdjustPropertyPanelHeight("Div", "add");

                                    IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                                divModel,
                                                                                                _multiPanelModel,
                                                                                                this,
                                                                                                _frameModel,
                                                                                                _mainPresenter);
                                    IMullionUC mullionUC = mullionUCP.GetMullion();
                                    fpnl.Controls.Add((UserControl)mullionUC);
                                    mullionUCP.SetInitialLoadFalse();
                                    _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                                    _multiPanelModel.Adapt_sizeToBind_MPanelDivMPanel_Controls((UserControl)mullionUC, _frameModel.Frame_Type.ToString());

                                    IMullionImagerUCPresenter mullionImagerUCP = _mullionImagerUCP.GetNewInstance(_unityC,
                                                                                                                  divModel,
                                                                                                                  _multiPanelModel,
                                                                                                                  _frameModel,
                                                                                                                  _multiMullionImagerUCP,
                                                                                                                  mullionUC);
                                    IMullionImagerUC mullionImagerUC = mullionImagerUCP.GetMullionImager();
                                    _multiMullionImagerUCP.AddControl((UserControl)mullionImagerUC);
                                    _multiPanelModel.MPanelLst_Imagers.Add((UserControl)mullionImagerUC);

                                    _basePlatformImagerUCP.InvalidateBasePlatform();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Maximum stacks reached", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        int suggest_Wd = 0,
                            suggest_HT = _multiPanelModel.MPanel_Height - 20,
                            suggest_DisplayHT = _multiPanelModel.MPanel_DisplayHeight,
                            suggest_DisplayHTDecimal = _multiPanelModel.MPanel_DisplayHeightDecimal;

                        if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                            {
                                if (_multiPanelModel.MPanel_Placement == "Last")
                                {
                                    suggest_HT = _multiPanelModel.MPanel_Height - 10;
                                }
                            }
                            else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                                     _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052)
                            {
                                if (_multiPanelModel.MPanel_Placement == "Last")
                                {
                                    suggest_HT = _multiPanelModel.MPanel_Height - 15;
                                }
                            }
                            else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                     _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                            {
                                if (_multiPanelModel.MPanel_Placement == "Last")
                                {
                                    suggest_HT = _multiPanelModel.MPanel_Height - 16;
                                }
                                else if (_multiPanelModel.MPanel_Placement == "Somewhere in Between")
                                {
                                    suggest_HT = _multiPanelModel.MPanel_Height - 18;
                                }
                            }
                        }
                        string disp_wd_decimal = _multiPanelModel.MPanel_DisplayWidth + "." + _multiPanelModel.MPanel_DisplayWidthDecimal;
                        decimal displayWidthDecimal = 0;
                        decimal displayWidth = 0;
                        foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel)
                        {
                            displayWidth += Convert.ToDecimal(mpnl.MPanel_DisplayWidth + "." + mpnl.MPanel_DisplayWidthDecimal);
                            displayWidthDecimal = Convert.ToDecimal("0." + mpnl.MPanel_DisplayWidthDecimal);
                        }
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            displayWidth += Convert.ToDecimal(pnl.Panel_DisplayWidth + "." + pnl.Panel_DisplayWidthDecimal);
                            displayWidthDecimal = Convert.ToDecimal("0." + pnl.Panel_DisplayWidthDecimal);
                        }
                        decimal DisplayWD_dec;
                        if (displayWidth == 0)
                        {
                            DisplayWD_dec = Convert.ToDecimal(disp_wd_decimal) / totalPanelCount;
                        }
                        else
                        {
                            DisplayWD_dec = Math.Floor((Convert.ToDecimal(disp_wd_decimal) - displayWidth) / (totalPanelCount - (_multiPanelModel.MPanelLst_Panel.Count + _multiPanelModel.MPanelLst_MultiPanel.Count)));

                        }
                        if (_userModel.Department == "Sales & Operations (Costing)")
                        {
                            DisplayWD_dec = (int)Math.Truncate(DisplayWD_dec);
                        }
                        DisplayWD_dec += displayWidthDecimal;
                        int suggest_DisplayWD = (int)Math.Truncate(DisplayWD_dec);

                        int DisplayWD_singleDecimalPlace = 0;

                        string[] DisplayWD_dec_split = decimal.Round(DisplayWD_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                        if (DisplayWD_dec_split.Count() > 1)
                        {
                            DisplayWD_singleDecimalPlace = Convert.ToInt32(DisplayWD_dec_split[1]);
                        }
                        int panelSize = 0;
                        foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel)
                        {
                            panelSize += pnl.Panel_Width;

                        }
                        if (_multiPanelModel.MPanel_DividerEnabled)
                        {
                            int EqualDisplayWD = (int)Math.Truncate(Convert.ToDecimal(disp_wd_decimal) / totalPanelCount);
                            int EqualPanelWD = (((_multiPanelModel.MPanel_Width - 20) - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);
                            suggest_Wd = EqualPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                        }
                        else if (!_multiPanelModel.MPanel_DividerEnabled)
                        {
                            int EqualDisplayWD = (int)Math.Truncate(Convert.ToDecimal(disp_wd_decimal) / totalPanelCount);
                            int EqualPanelWD = ((_multiPanelModel.MPanel_Width - 20) / totalPanelCount);
                            suggest_Wd = EqualPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                        }
                        if (_multiPanelModel.MPanel_ParentModel != null)
                        {
                            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                            {
                                suggest_HT += 4;
                            }
                        }

                        MiddleCloser_ArticleNo midArtNo = MiddleCloser_ArticleNo._None;
                        if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                        {
                            midArtNo = MiddleCloser_ArticleNo._1WC70DB;
                        }
                        else if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                                 _frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
                        {
                            midArtNo = MiddleCloser_ArticleNo._1WC70WHT;
                        }

                        MotorizedMech_ArticleNo motor = MotorizedMech_ArticleNo._41556C;

                        if (suggest_HT >= 2000 ||
                           (suggest_Wd >= 1600 && suggest_HT >= 1500))
                        {
                            motor = MotorizedMech_ArticleNo._409990E;
                        }
                        else
                        {
                            if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._DarkBrown)
                            {
                                motor = MotorizedMech_ArticleNo._41555B;
                            }
                            else if (_frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._White ||
                                     _frameModel.Frame_WindoorModel.WD_BaseColor == Base_Color._Ivory)
                            {
                                motor = MotorizedMech_ArticleNo._41556C;
                            }
                        }

                        Rotoswing_HandleArtNo handleArtNo = null;
                        Foil_Color inside_color = _frameModel.Frame_WindoorModel.WD_InsideColor;

                        if (inside_color == Foil_Color._Walnut || inside_color == Foil_Color._Havana ||
                            inside_color == Foil_Color._GoldenOak || inside_color == Foil_Color._Mahogany)
                        {
                            handleArtNo = Rotoswing_HandleArtNo._RSC833307;
                        }
                        else if (inside_color == Foil_Color._CharcoalGray || inside_color == Foil_Color._FossilGray ||
                                 inside_color == Foil_Color._BeechOak || inside_color == Foil_Color._DriftWood ||
                                 inside_color == Foil_Color._Graphite || inside_color == Foil_Color._JetBlack ||
                                 inside_color == Foil_Color._ChestnutOak || inside_color == Foil_Color._WashedOak ||
                                 inside_color == Foil_Color._GreyOak || inside_color == Foil_Color._Cacao ||
                                 inside_color == Foil_Color._Carbon || inside_color == Foil_Color._UmberOak)
                        {
                            handleArtNo = Rotoswing_HandleArtNo._RSC773452;
                        }

                        IPanelModel _panelModel = _panelServices.AddPanelModel(suggest_Wd,
                                                                               suggest_HT,
                                                                               fpnl,
                                                                               (UserControl)_frameUCP.GetFrameUC(),
                                                                               (UserControl)framePropUC,
                                                                               (UserControl)_multiPanelMullionUC,
                                                                               data,
                                                                               true,
                                                                               _frameModel.Frame_Zoom,
                                                                               _userModel,
                                                                               _frameModel,
                                                                               _multiPanelModel,
                                                                               suggest_DisplayWD,
                                                                               DisplayWD_singleDecimalPlace,
                                                                               suggest_DisplayHT,
                                                                               suggest_DisplayHTDecimal,
                                                                               GlazingBead_ArticleNo._2452,
                                                                               GlassFilm_Types._None,
                                                                               SashProfile_ArticleNo._7581,
                                                                               SashReinf_ArticleNo._R675,
                                                                               GlassType._Single,
                                                                               Espagnolette_ArticleNo._None,
                                                                               Striker_ArticleNo._M89ANTA,
                                                                               midArtNo,
                                                                               LockingKit_ArticleNo._None,
                                                                               motor,
                                                                               Handle_Type._Rotoswing,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               Extension_ArticleNo._None,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               handleArtNo,
                                                                               GeorgianBar_ArticleNo._None,
                                                                               OverlapSash._None,
                                                                               0,
                                                                               0,
                                                                               false,
                                                                               _mainPresenter.GetPanelCount(),
                                                                               _mainPresenter.GetPanelGlassID(),
                                                                               _frameModel.FrameImageRenderer_Zoom,
                                                                               _multiPanelModel.GetNextIndex(),
                                                                               DockStyle.None);
                        if (_prev_divModel != null)
                        {
                            _panelModel.Panel_CornerDriveOptionsVisibility = _prev_divModel.Div_ChkDM;
                        }

                        _multiPanelModel.MPanelLst_Panel.Add(_panelModel);
                        _multiPanelModel.Reload_PanelMargin();

                        _panelModel.SetDimensionsToBind_using_ZoomPercentage();
                        _panelModel.Imager_SetDimensionsToBind_using_ZoomPercentage();
                        _panelModel.SetPanelMargin_using_ZoomPercentage();
                        _panelModel.SetPanelMarginImager_using_ImageZoomPercentage();

                        IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                        UserControl panelPropUC = (UserControl)panelPropUCP.GetPanelPropertiesUC();
                        panelPropUC.Dock = DockStyle.Top;


                        _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(panelPropUC);
                        panelPropUC.BringToFront();

                        if (data == "Fixed Panel")
                        {
                            _panelModel.Panel_SashProfileArtNo = SashProfile_ArticleNo._None;
                            _panelModel.Panel_SashReinfArtNo = SashReinf_ArticleNo._None;

                            IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC,
                                                                                       _panelModel,
                                                                                       _frameModel,
                                                                                       _userModel,
                                                                                       _mainPresenter,
                                                                                       _multiPanelModel,
                                                                                       this,
                                                                                       _multiMullionImagerUCP);
                            IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                            fpnl.Controls.Add((UserControl)fixedUC);
                            fixedUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)fixedUC, _frameModel.Frame_Type.ToString());

                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                        else if (data == "Casement Panel")
                        {
                            ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC,
                                                                                                _panelModel,
                                                                                                _frameModel,
                                                                                                _userModel,
                                                                                                _mainPresenter,
                                                                                                _multiPanelModel,
                                                                                                this,
                                                                                                _multiMullionImagerUCP);
                            ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                            fpnl.Controls.Add((UserControl)casementUC);
                            casementUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)casementUC, _frameModel.Frame_Type.ToString());

                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                        else if (data == "Awning Panel")
                        {
                            IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC,
                                                                                          _panelModel,
                                                                                          _frameModel,
                                                                                          _userModel,
                                                                                          _mainPresenter,
                                                                                          _multiPanelModel,
                                                                                          this,
                                                                                          _multiMullionImagerUCP);
                            IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                            fpnl.Controls.Add((UserControl)awningUC);
                            awningUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)awningUC, _frameModel.Frame_Type.ToString());

                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                        else if (data == "Sliding Panel")
                        {
                            ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC,
                                                                                             _panelModel,
                                                                                             _frameModel,
                                                                                             _userModel,
                                                                                             _mainPresenter,
                                                                                             _multiPanelModel,
                                                                                             this,
                                                                                             _multiMullionImagerUCP);
                            ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                            fpnl.Controls.Add((UserControl)slidingUC);
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)slidingUC, _frameModel.Frame_Type.ToString());
                            slidingUCP.SetInitialLoadFalse();
                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                        else if (data == "TiltNTurn Panel")
                        {
                            ITiltNTurnPanelUCPresenter tiltNTurnUCP = _tiltNTurnUCP.GetNewInstance(_unityC,
                                                                                                   _panelModel,
                                                                                                   _frameModel,
                                                                                                   _userModel,
                                                                                                   _mainPresenter,
                                                                                                   _multiPanelModel,
                                                                                                   this,
                                                                                                   _multiMullionImagerUCP);
                            ITiltNTurnPanelUC tiltnTurnUC = tiltNTurnUCP.GetTiltNTurnPanelUC();
                            fpnl.Controls.Add((UserControl)tiltnTurnUC);
                            tiltNTurnUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)tiltnTurnUC, _frameModel.Frame_Type.ToString());

                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                        else if (data == "Louver Panel")
                        {
                            ILouverPanelUCPresenter louverPanelUCP = _louverPanelUCP.GetNewInstance(_unityC,
                                                                                                   _panelModel,
                                                                                                   _frameModel,
                                                                                                   _userModel,
                                                                                                   _mainPresenter,
                                                                                                   _multiPanelModel,
                                                                                                   this);
                            ILouverPanelUC louverPanelUC = louverPanelUCP.GetLouverPanelUC();
                            fpnl.Controls.Add((UserControl)louverPanelUC);
                            louverPanelUCP.SetInitialLoadFalse();
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)louverPanelUC, _frameModel.Frame_Type.ToString());

                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }

                        if (_panelModel.Panel_Placement == "Last")
                        {
                            //_multiPanelModel.Fit_EqualPanel_ToBindDimensions();

                            _multiPanelModel.Fit_MyControls_ToBindDimensions();
                            _multiPanelModel.Fit_MyControls_ImagersToBindDimensions();
                            _mainPresenter.Run_GetListOfMaterials_SpecificItem();

                        }
                        else if (_multiPanelModel.MPanel_DividerEnabled && _panelModel.Panel_Placement != "Last")
                        {
                            bool divchkdm = false;

                            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door && _mainPresenter.windoorModel_MainPresenter.WD_profile.Contains("C70"))
                            {
                                if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                {
                                    if (_multiPanelModel.MPanel_ParentModel == null)
                                    {
                                        divchkdm = true;
                                    }
                                    else if (_multiPanelModel.MPanel_ParentModel != null)
                                    {
                                        if (_multiPanelModel.MPanel_Placement == "Last")
                                        {
                                            divchkdm = true;
                                        }
                                    }
                                }
                            }

                            IDividerModel divModel = _divServices.AddDividerModel(divSize,
                                                                                  _multiPanelModel.MPanel_Height,
                                                                                  fpnl,
                                                                                  DividerModel.DividerType.Mullion,
                                                                                  true,
                                                                                  _frameModel.Frame_Zoom,
                                                                                  Divider_ArticleNo._7536,
                                                                                  _multiPanelModel.MPanel_DisplayWidth,
                                                                                  _multiPanelModel.MPanel_DisplayHeight,
                                                                                  _multiPanelModel,
                                                                                  _frameModel,
                                                                                  _userModel,
                                                                                  _mainPresenter.GetDividerCount(),
                                                                                  _frameModel.FrameImageRenderer_Zoom,
                                                                                  _frameModel.Frame_Type.ToString(),
                                                                                  "",
                                                                                  null,
                                                                                  divchkdm);
                            divModel.SetDimensionsToBind_using_DivZoom();
                            divModel.SetDimensionsToBind_using_DivZoom_Imager_Initial();

                            _prev_divModel = divModel;
                            _frameModel.Lst_Divider.Add(divModel);
                            _multiPanelModel.MPanelLst_Divider.Add(divModel);

                            IDividerPropertiesUCPresenter divPropUCP = _divPropertiesUCP.GetNewInstance(_unityC, divModel, _mainPresenter);
                            divPropUCP.GetDivProperties().ProfileType_FromMainPresenter = _frameModel.Frame_WindoorModel.WD_profile;
                            UserControl divPropUC = (UserControl)divPropUCP.GetDivProperties();
                            divPropUC.Dock = DockStyle.Top;
                            _multiPropUCP2_given.GetMultiPanelPropertiesPNL().Controls.Add(divPropUC);
                            divPropUC.BringToFront();

                            _multiPanelModel.AdjustPropertyPanelHeight("Div", "add");
                            _frameModel.AdjustPropertyPanelHeight("Div", "add");

                            IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                                        divModel,
                                                                                        _multiPanelModel,
                                                                                        this,
                                                                                        _frameModel,
                                                                                        _mainPresenter);
                            IMullionUC mullionUC = mullionUCP.GetMullion();
                            fpnl.Controls.Add((UserControl)mullionUC);
                            _multiPanelModel.AddControl_MPanelLstObjects((UserControl)mullionUC, _frameModel.Frame_Type.ToString());
                            mullionUCP.SetInitialLoadFalse();

                            _basePlatformImagerUCP.InvalidateBasePlatform();
                        }
                    }

                    foreach (Control ctrl in fpnl.Controls)
                    {
                        if (ctrl.Name.Contains("Multi"))
                        {
                            ctrl.Controls[0].Invalidate(); //Invalidate the fpnl inside
                        }
                        else
                        {
                            ctrl.Invalidate(); //Divider
                        }
                    }
                    _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                }
                _mainPresenter.windoorModel_MainPresenter.SetPanelGlassID();
                _mainPresenter.SetChangesMark();
                _mainPresenter.itemDescription();
                _mainPresenter.GetCurrentPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _multiPanelMullionUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete Divider
            if (_multiPanelModel.MPanel_ParentModel != null &&
                _multiPanelModel.MPanel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.IndexOf((UserControl)_multiPanelMullionUC);
                Control nextCtrl = null;
                if (_multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Count > (this_indx + 2))
                {
                    nextCtrl = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx + 2];
                    if (!nextCtrl.Name.Contains("Panel"))
                    {
                        nextCtrl = null;
                    }
                }
                if (this_indx > 1 && _multiPanelModel.MPanel_ParentModel.MPanel_DividerEnabled && nextCtrl != null)
                {
                    Control prevmPanel = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx - 2];
                    Control divCtrl = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx - 1];
                    IMultiPanelModel leftMpnl = _multiPanelModel.MPanel_ParentModel.MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prevmPanel.Name);

                    int div_mpnl_deduct_Tobind = 8;
                    if (_multiPanelModel.MPanel_ParentModel.MPanel_Zoom > 0.26f)
                    {
                        div_mpnl_deduct_Tobind = (int)(div_mpnl_deduct_Tobind * _multiPanelModel.MPanel_ParentModel.MPanel_Zoom);//4
                    }
                    else if (_multiPanelModel.MPanel_Zoom <= 0.26f)
                    {
                        div_mpnl_deduct_Tobind = 2; //13 - 2 = 11 - 2 = 9px default on div obj for 2-stack multipanel
                    }

                    if (divCtrl.Name.Contains("Mullion"))
                    {
                        Control mullionC = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx - 1];
                        IDividerModel leftDiv = _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Find(divs => divs.Div_Name == mullionC.Name);
                        leftDiv.Div_WidthToBind += div_mpnl_deduct_Tobind;
                        leftDiv.Div_Width += 8;
                    }
                    else if (divCtrl.Name.Contains("Transom"))
                    {
                        Control transomC = (TransomUC)_multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx - 1];
                        IDividerModel leftDiv = _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Find(divs => divs.Div_Name == transomC.Name);
                        leftDiv.Div_HeightToBind += div_mpnl_deduct_Tobind;
                        leftDiv.Div_Height += 8;
                    }
                }
                Control divUC = _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects[this_indx + 1];
                _multiPanelModel.MPanel_ParentModel.MPanelLst_Objects.Remove((UserControl)divUC);
                _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)divUC);

                IDividerModel div = _multiPanelModel.MPanel_ParentModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);

                _multiPanelModel.MPanel_ParentModel.DeductPropertyPanelHeight(div.Div_PropHeight);
                _multiPanelModel.MPanel_FrameModelParent.DeductPropertyPanelHeight(div.Div_PropHeight);

                _mainPresenter.DeleteDividerPropertiesUC(div.Div_ID);
                div.Div_MPanelParent.MPanelLst_Divider.Remove(div);
                _frameModel.Lst_Divider.Remove(div);

                _mainPresenter.DeselectDivider();
            }

            #endregion

            #region Delete MultiPanel Mullion
            Control parent_ctrl = ((UserControl)_multiPanelMullionUC).Parent;

            _multiPanelModel.MPanel_FrameModelParent.DeductPropertyPanelHeight(_multiPanelModel.MPanelProp_Height);

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.DeductPropertyPanelHeight(_multiPanelModel.MPanelProp_Height);
            }

            _mainPresenter.DeleteMultiPanelPropertiesUC(_multiPanelModel.MPanel_ID);

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.DeleteControl_MPanelLstObjects((UserControl)_multiPanelMullionUC,
                                                                                   _frameModel.Frame_Type.ToString(),
                                                                                   _multiPanelModel.MPanel_Placement);

                Control imager = _commonFunctions.FindImagerControl(_multiPanelModel.MPanel_ID, "MPanel", _multiPanelModel.MPanel_ParentModel);
                _multiPanelModel.MPanel_ParentModel.MPanelLst_Imagers.Remove(imager);
            }

            if (_multiPanelModel.MPanel_Parent is IFrameUC)
            {
                _frameModel.SetDeductFramePadding(false);
            }

            var child_mpanels = _commonFunctions.GetAll_MPanel(_multiPanelModel);

            foreach (IMultiPanelModel mpnl in child_mpanels)
            {
                _frameModel.Lst_MultiPanel.Remove(mpnl);
            }

            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_multiPanelMullionUC);
            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_multiPanelMullionUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_multiPanelMullionUC);
            }

            if (_multiPanelModel.MPanel_Parent != null)
            {
                _multiPanelModel.MPanel_Parent.Controls.Remove((UserControl)_multiPanelMullionUC);
            }

            if (_multiPanelModel.MPanel_ParentModel != null)
            {
                _multiPanelModel.MPanel_ParentModel.MPanelLst_MultiPanel.Remove(_multiPanelModel);
                _multiPanelModel.MPanel_ParentModel.Object_Indexer();
                _multiPanelModel.MPanel_ParentModel.Reload_MultiPanelMargin();
                _multiPanelModel.MPanel_ParentModel.Reload_PanelMargin();
                _commonFunctions.Automatic_Div_Addition(_mainPresenter,
                                                        _frameModel,
                                                        _userModel,
                                                        _divServices,
                                                        _transomUCP,
                                                        _unityC,
                                                        _mullionUCP,
                                                        //_mullionImagerUCP,
                                                        //_transomImagerUCP,
                                                        _mainPresenter.GetDividerCount(),
                                                        _multiPanelModel,
                                                        null,
                                                        _multiPanelTransomUCP,
                                                        _multiPanelMullionUCP);
                //_multiMullionImagerUCP_parent,
                //_multiPanelTransomImagerUCP_parent);
            }

            if (_frameModel != null)
            {
                _frameModel.Lst_MultiPanel.Remove(_multiPanelModel);
            }

            if (parent_ctrl.Name.Contains("flp_Multi"))
            {
                foreach (Control ctrl in parent_ctrl.Controls)
                {
                    ctrl.Invalidate();
                }
            }

            _mainPresenter.SetChangesMark();
            _mainPresenter.basePlatformWillRenderImg_MainPresenter.InvalidateBasePlatform();
            _mainPresenter.SetPanelGlassID();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();

            #endregion

            _mainPresenter.DeselectDivider();
        }

        private void _multiPanelMullionUC_divCountClickedEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input no. of division for " + _multiPanelModel.MPanel_Name, "WinDoor Maker", "1");
            if (input != "" && input != "0")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        _multiPanelModel.MPanel_Divisions = int_input;
                        Invalidate_MultiPanelMullionUC();
                    }
                    else if (int_input < 0)
                    {
                        MessageBox.Show("Invalid number");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233033)
                    {
                        MessageBox.Show("Please input a number.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, ex.HResult.ToString());
                    }
                }
            }
        }

        private void _multiPanelMullionUC_flpMultiMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
        }

        private void _multiPanelMullionUC_flpMultiMouseEnterEventRaised(object sender, EventArgs e)
        {

            color = Color.Blue;
            ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
        }

        Color color = Color.Black;
        bool _HeightChange = false,
             _WidthChange = false;

        private void _multiPanelMullionUC_flpMulltiPaintEventRaised(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            Control fpnlParent = fpnl.Parent.Parent; //Parent ng mismong usercontrol, Its either Frame or Multi-Panel
            IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;

            float zoom = _multiPanelModel.MPanel_Zoom;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int pInnerX = _frameModel.Frame_Deduction,
                pInnerY = _frameModel.Frame_Deduction,
                pInnerWd = fpnl.ClientRectangle.Width - (_frameModel.Frame_Deduction * 2),
                pInnerHt = fpnl.ClientRectangle.Height - (_frameModel.Frame_Deduction * 2);

            if (zoom >= 0.01f && zoom <= 0.26f)
            {
                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    pInnerX = 15;
                    pInnerY = 15;
                    pInnerWd = fpnl.ClientRectangle.Width - 30;
                    pInnerHt = fpnl.ClientRectangle.Height - 30;
                  //  if (_frameModel.Frame_WindoorModel.WD_profile.Contains("Alutek"))
                  //  {
                  //      pInnerX = 8;
                  //      pInnerY = 8;
                  //      pInnerWd = fpnl.ClientRectangle.Width - 16;
                  //      pInnerHt = fpnl.ClientRectangle.Height - 16;
                  //  }
                }
                else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    pInnerX = 20;
                    pInnerY = 20;
                    pInnerWd = fpnl.ClientRectangle.Width - 40;
                    pInnerHt = fpnl.ClientRectangle.Height - 40;

                    if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        pInnerHt = fpnl.ClientRectangle.Height;
                    }
                }
            }
            else if (zoom >= 0.50f)
            {
                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        pInnerHt = fpnl.ClientRectangle.Height - (_frameModel.Frame_Deduction + _frameModel.Frame_Padding_int.Bottom);
                    }
                }
            }


            int ht_ToBind = _multiPanelModel.MPanel_HeightToBind,
                wd_ToBind = _multiPanelModel.MPanel_WidthToBind;

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

            Point[] corner_points = new[]
            {
                    new Point(0,0),
                    new Point(pInnerX, pInnerY),
                    new Point(fpnl.ClientRectangle.Width, 0),
                    new Point(pInnerX + pInnerWd, pInnerY),
                    new Point(0, fpnl.ClientRectangle.Height),
                    new Point(pInnerX, pInnerY + pInnerHt),
                    new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                    new Point(pInnerX + pInnerWd, pInnerY + pInnerHt)
            };

            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                {
                    corner_points[4] = new Point(0, fpnl.ClientRectangle.Height - 1);
                    corner_points[5] = new Point(pInnerX, fpnl.ClientRectangle.Height - 1);

                    corner_points[6] = new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height - 1);
                    corner_points[7] = new Point(pInnerX + pInnerWd, fpnl.ClientRectangle.Height - 1);
                }
                if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                {
                    corner_points[4] = new Point(-3, fpnl.ClientRectangle.Height);
                    corner_points[5] = new Point(pInnerX + 3, pInnerY + pInnerHt);

                    corner_points[6] = new Point(fpnl.ClientRectangle.Width + 3, fpnl.ClientRectangle.Height);
                    corner_points[7] = new Point(pInnerX + pInnerWd - 3, pInnerY + pInnerHt);
                }
            }
            //    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            //   {
            //       if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
            //               _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
            //       {
            //           corner_points[4] = new Point(-3, fpnl.ClientRectangle.Height);
            //           corner_points[5] = new Point(pInnerX + 3, pInnerY + pInnerHt);
            //
            //           corner_points[6] = new Point(fpnl.ClientRectangle.Width + 3, fpnl.ClientRectangle.Height);
            //           corner_points[7] = new Point(pInnerX + pInnerWd - 3, pInnerY + pInnerHt);
            //       }
            //   }

            GraphicsPath gpath = new GraphicsPath();
            GraphicsPath gpath2 = new GraphicsPath();
            Rectangle bounds = new Rectangle();
            Pen pen = new Pen(Color.Black, 2);

            List<Point[]> thisDrawingPoints_bot = null, //botTransom
                          thisDrawingPoints_top = null, //topTransom
                          thisDrawingPoints_forMullion_RightSide = null,
                          thisDrawingPoints_forMullion_LeftSide = null;

            int pixels_count = 0;
            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                pixels_count = 8;
            }
            else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                pixels_count = 10;
            }

            Rectangle[] divs_bounds_values = { new Rectangle(new Point(0, ht_ToBind - (int)(pixels_count * zoom)), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))) , //bot
                                               new Rectangle(new Point(0, -1), new Size(wd_ToBind - 1, (int)(pixels_count * zoom))), //top
                                               new Rectangle(new Point(wd_ToBind - (int)(pixels_count * zoom), 0), new Size((int)(pixels_count * zoom), ht_ToBind - 1)), //right
                                               new Rectangle(new Point(-1, 0), new Size((int)(pixels_count * zoom), ht_ToBind - 1)) //left
                                             };

            if (zoom >= 0.01f && zoom <= 0.26f)
            {
                divs_bounds_values[0] = new Rectangle(new Point(0, ht_ToBind - 2), new Size(wd_ToBind - 1, 2)); //bot
                divs_bounds_values[1] = new Rectangle(new Point(0, -1), new Size(wd_ToBind - 1, 2)); //top
                divs_bounds_values[2] = new Rectangle(new Point(wd_ToBind - 2, 0), new Size(2, ht_ToBind - 1)); //right
                divs_bounds_values[3] = new Rectangle(new Point(-1, 0), new Size(2, ht_ToBind - 1)); //left
            }

            Rectangle divider_bounds_Bot = new Rectangle();
            Rectangle divider_bounds_Top = new Rectangle();
            Rectangle divider_bounds_Right = new Rectangle();
            Rectangle divider_bounds_Left = new Rectangle();

            string parent_name = _multiPanelModel.MPanel_Parent.Name,
                   lvl2_parent_Type = "",
                   thisObj_placement = _multiPanelModel.MPanel_Placement;
            DockStyle parent_doxtyle = DockStyle.None;

            int bPoints = (int)(10 * _frameModel.Frame_Zoom),
                bSizeDeduction = (int)(20 * _frameModel.Frame_Zoom),
                botFrameDeduct = 0;

            if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FrameUC))
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                        _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66)
                    {
                        botFrameDeduct = (int)(9 * _frameModel.Frame_Zoom);
                    }
                }

                if (zoom >= 0.01f && zoom <= 0.26f)
                {
                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        bounds = new Rectangle(new Point(5, 5),
                                               new Size(fpnl.ClientRectangle.Width - 10, fpnl.ClientRectangle.Height - 10));
                    }
                    else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            botFrameDeduct = 11;
                        }
                        else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                                 _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                 _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052 ||
                                 _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                        {
                            botFrameDeduct = 20;
                        }

                        bounds = new Rectangle(new Point(10, 10),
                                               new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - botFrameDeduct));
                    }
                }
                else
                {
                    bounds = new Rectangle(new Point(bPoints, bPoints),
                                           new Size(fpnl.ClientRectangle.Width - bSizeDeduction,
                                                    fpnl.ClientRectangle.Height - (bSizeDeduction - botFrameDeduct)));
                }
            }
            else if (_multiPanelModel.MPanel_Parent.GetType() == typeof(FlowLayoutPanel)) //If MultiPanel
            {
                string parentObj_placement = _multiPanelModel.MPanel_ParentModel.MPanel_Placement;

                int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1,
                    parent_mpnl_childObj_count = parent_mpnl.GetCount_MPanelLst_Object(),
                    indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

                parent_doxtyle = _multiPanelModel.MPanel_ParentModel.MPanel_Dock;

                GraphicsPath gpath_forMullion_RightSide = new GraphicsPath();
                GraphicsPath gpath_forMullion_LeftSide = new GraphicsPath();

                #region Variable Declaration

                #region MAIN PLATFORM Parent_Type
                if (parent_doxtyle == DockStyle.None)
                {
                    lvl2_parent_Type = _multiPanelModel.MPanel_ParentModel.MPanel_ParentModel.MPanel_Type;
                }
                #endregion

                #region thisDrawingPoints_bot and thisDrawingPoints_top
                thisDrawingPoints_bot = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                    fpnl.Height,
                                                                                    "TransomUC",
                                                                                    "First",
                                                                                    _frameModel.Frame_Type.ToString());

                thisDrawingPoints_top = _mpnlCommons.GetTransomDividerDrawingPoints(fpnl.Width,
                                                                                    fpnl.Height,
                                                                                    "TransomUC",
                                                                                    "Last",
                                                                                    _frameModel.Frame_Type.ToString());
                #endregion

                #region bounds declaration
                int wd_deduction = 0,
                    ht_deduction = 0,
                    bounds_PointX = 0,
                    bounds_PointY = 0;

                if (parent_name.Contains("MultiTransom"))
                #region Parent is MultiPanel Transom
                {
                    if (zoom <= 0.26f)
                    {
                        if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            bounds_PointX = 10;
                            wd_deduction = 17;

                            if (parentObj_placement == "First")
                            {
                                wd_deduction = 15;
                            }
                            else if (parentObj_placement == "Somewhere in Between")
                            {
                                bounds_PointX = 5;
                                wd_deduction = 10;
                            }
                            else if (parentObj_placement == "Last")
                            {
                                bounds_PointX = 5;
                                wd_deduction = 15;
                            }
                        }
                        else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                        {
                            bounds_PointX = 5;
                            wd_deduction = 10;
                        }
                    }
                    else if (zoom == 1.0f)
                    {
                        wd_deduction = (int)(20 * zoom);
                        bounds_PointX = (int)(10 * zoom);

                        if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                        {
                            if (parent_name.Contains("MultiTransom") &&
                                parent_doxtyle == DockStyle.None &&
                                lvl2_parent_Type == "Mullion") //M-T-M
                            {
                                if (parentObj_placement == "First")
                                {
                                    wd_deduction = 22;
                                }
                                else if (parentObj_placement == "Somewhere in Between")
                                {
                                    wd_deduction = 23;
                                    bounds_PointX = 11;
                                }
                                else if (parentObj_placement == "Last")
                                {
                                    bounds_PointX = 11;
                                }
                            }
                        }
                    }
                    else if (zoom == 0.50f)
                    {
                        wd_deduction = 11;
                        bounds_PointX = 5;
                    }

                    if (thisObj_placement == "First")
                    {
                        if (zoom <= 0.26f)
                        {
                            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                            {
                                bounds_PointY = 5;

                                if (lvl2_parent_Type != "")
                                {
                                    ht_deduction = 8 + 3;
                                }
                                else if (lvl2_parent_Type == "")
                                {
                                    ht_deduction = 8 + 4;
                                }
                            }
                            else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                            {
                                bounds_PointY = 10;
                                if (parent_name.Contains("MultiTransom"))
                                {
                                    if (parent_doxtyle == DockStyle.Fill &&
                                        lvl2_parent_Type == "") //T-M
                                    {
                                        ht_deduction = 17;
                                    }
                                    else if (parent_doxtyle == DockStyle.None &&
                                             lvl2_parent_Type == "Mullion") //M-T-M
                                    {
                                        ht_deduction = 16;
                                    }
                                }
                            }

                        }
                        else if (zoom == 0.50f)
                        {
                            bounds_PointY = (int)(10 * zoom);
                            ht_deduction = (int)((10 + (pixels_count + 1)) * zoom);
                        }
                        else if (zoom == 1.0f)
                        {
                            bounds_PointY = (int)(10 * zoom);
                            ht_deduction = (int)((10 + (pixels_count + 1)) * zoom) - 1;
                        }
                    }
                    else if (thisObj_placement == "Last")
                    {
                        if (zoom <= 0.26f)
                        {
                            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                            {
                                if (lvl2_parent_Type != "")
                                {
                                    bounds_PointY = 2 + 3;
                                    ht_deduction = 8 + 3;
                                }
                                else if (lvl2_parent_Type == "")
                                {
                                    bounds_PointY = 2 + 4;
                                    ht_deduction = 8 + 4;
                                }
                            }
                            else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                            {
                                bounds_PointY = 5;

                                if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                {
                                    ht_deduction = 6;
                                }
                                else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7507 ||
                                         _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                                         _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6052 ||
                                         _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                                {
                                    ht_deduction = 16;
                                }
                            }
                        }
                        else if (zoom > 0.26f)
                        {
                            bounds_PointY = (int)(pixels_count * zoom);
                            ht_deduction = (int)(((((pixels_count + 2) * 2)) - 1) * zoom);

                            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                            {
                                if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                    _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                {
                                    ht_deduction = (int)(11 * _frameModel.Frame_Zoom);
                                }
                                else
                                {
                                    ht_deduction = bSizeDeduction - botFrameDeduct - 1;
                                }
                            }
                        }
                    }
                    else if (thisObj_placement == "Somewhere in Between")
                    {
                        if (zoom <= 0.26f)
                        {
                            if (lvl2_parent_Type != "")
                            {
                                bounds_PointY = 2 + 3;
                                ht_deduction = 5 + 6;
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                bounds_PointY = 2 + 4;
                                ht_deduction = 5 + 7;
                            }
                        }
                        else if (zoom == 0.50f)
                        {
                            bounds_PointY = (int)(pixels_count * zoom);
                            if (lvl2_parent_Type != "")
                            {
                                ht_deduction = (int)((pixels_count * 2) * zoom) + 2;
                            }
                            else if (lvl2_parent_Type == "")
                            {
                                ht_deduction = (int)((pixels_count * 2) * zoom) + 2;
                            }
                        }
                        else if (zoom == 1.0f)
                        {
                            bounds_PointY = (int)(pixels_count * zoom);
                            ht_deduction = (int)((pixels_count * 2) * zoom);
                        }
                    }

                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (parent_name.Contains("MultiTransom"))
                        {
                            if (parent_doxtyle == DockStyle.Fill &&
                                     lvl2_parent_Type == "") //T-M
                            {
                                if (zoom <= 0.26f)
                                {
                                    wd_deduction = 20;
                                }
                            }
                        }
                    }
                }

                bounds = new Rectangle(new Point(bounds_PointX, bounds_PointY),
                                       new Size(fpnl.Width - wd_deduction,
                                                fpnl.Height - ht_deduction));

                #endregion

                #endregion

                #region 'thisDrawingPoints_for..' of this obj when the Parent obj has doxtyle.None

                thisDrawingPoints_forMullion_RightSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                     fpnl.Height,
                                                                                                     "Mullion",
                                                                                                     "First",
                                                                                                     _frameModel.Frame_Type.ToString()); //4th parameter must be the placement of the parent control

                thisDrawingPoints_forMullion_LeftSide = _mpnlCommons.GetMullionDividerDrawingPoints(fpnl.Width,
                                                                                                    fpnl.Height,
                                                                                                    "Mullion",
                                                                                                    "Last",
                                                                                                    _frameModel.Frame_Type.ToString()); //4th parameter must be the placement of the parent control
                #endregion

                #endregion

                #region MAIN GRAPHICS ALGORITHM with curve (commented)
                //if (parent_name.Contains("MultiMullion") &&
                //    parent_doxtyle == DockStyle.Fill &&
                //    thisObj_placement == "First")
                //#region First Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Last")
                //#region Last Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "First")
                //#region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 0; i < corner_points.Length - 5; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Last")
                //#region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 4; i < corner_points.Length - 1; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.Fill &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //#region Pattern (M-T-M)

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Last")
                //#region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height), 
                //                           new Point(pInnerX, pInnerY + pInnerHt));


                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Last")
                //#region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);


                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    thisDrawingPoints_forMullion_RightSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_RightSide[1][2].Y += 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    thisDrawingPoints_forMullion_RightSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_RightSide[3][2].Y -= 20;
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "First")
                //#region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    thisDrawingPoints_forMullion_LeftSide[1][0].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][1].Y += 20;
                //    thisDrawingPoints_forMullion_LeftSide[1][2].Y += 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    thisDrawingPoints_forMullion_LeftSide[3][0].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][1].Y -= 20;
                //    thisDrawingPoints_forMullion_LeftSide[3][2].Y -= 20;
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //#endregion

                //#region Pattern (T-T-M)

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 0; i < corner_points.Length - 5; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiTransom") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                //{
                //    for (int i = 4; i < corner_points.Length - 1; i += 2)
                //    {
                //        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                //    }

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);
                //}
                //#endregion

                //#endregion

                //#region Pattern (M-M-M)

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "First" &&
                //         (thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (Last or Somewhere in Between) in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         (thisObj_placement == "First" ||  thisObj_placement == "Last" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         (thisObj_placement == "First" || thisObj_placement == "Somewhere in Between"))
                //#region (First or Somewhere in Between) in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Mullion" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //#endregion

                //#region Pattern (T-M-M)

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "First")
                //#region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, 0),
                //                           new Point(pInnerX, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Last")
                //#region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                //                           new Point(pInnerX + pInnerWd, pInnerY));

                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "First" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "First")
                //#region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Last")
                //#region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Somewhere in Between" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    gpath.AddLine(thisDrawingPoints_bot[0][0], thisDrawingPoints_bot[0][1]);
                //    thisDrawingPoints_bot[1][0].X += 20;
                //    thisDrawingPoints_bot[1][1].X += 20;
                //    thisDrawingPoints_bot[1][2].X += 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[1]);
                //    gpath.AddLine(thisDrawingPoints_bot[2][0], thisDrawingPoints_bot[2][1]);
                //    thisDrawingPoints_bot[3][0].X -= 20;
                //    thisDrawingPoints_bot[3][1].X -= 20;
                //    thisDrawingPoints_bot[3][2].X -= 20;
                //    gpath.AddCurve(thisDrawingPoints_bot[3]);

                //    g.DrawPath(pen, gpath);
                //    g.FillPath(Brushes.PowderBlue, gpath);

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "First")
                //#region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX, pInnerY + pInnerHt));

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Last")
                //#region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{
                //    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                //                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);
                //}
                //#endregion

                //else if (parent_name.Contains("MultiMullion") &&
                //         parent_doxtyle == DockStyle.None &&
                //         lvl2_parent_Type == "Transom" &&
                //         parentObj_placement == "Last" &&
                //         thisObj_placement == "Somewhere in Between")
                //#region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                //{

                //    gpath2.AddLine(thisDrawingPoints_top[0][0], thisDrawingPoints_top[0][1]);
                //    thisDrawingPoints_top[1][0].X += 20;
                //    thisDrawingPoints_top[1][1].X += 20;
                //    thisDrawingPoints_top[1][2].X += 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[1]);
                //    gpath2.AddLine(thisDrawingPoints_top[2][0], thisDrawingPoints_top[2][1]);
                //    thisDrawingPoints_top[3][0].X -= 20;
                //    thisDrawingPoints_top[3][1].X -= 20;
                //    thisDrawingPoints_top[3][2].X -= 20;
                //    gpath2.AddCurve(thisDrawingPoints_top[3]);

                //    g.DrawPath(pen, gpath2);
                //    g.FillPath(Brushes.PowderBlue, gpath2);

                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[0][0], thisDrawingPoints_forMullion_LeftSide[0][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[1]);
                //    gpath_forMullion_LeftSide.AddLine(thisDrawingPoints_forMullion_LeftSide[2][0], thisDrawingPoints_forMullion_LeftSide[2][1]);
                //    gpath_forMullion_LeftSide.AddCurve(thisDrawingPoints_forMullion_LeftSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_LeftSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_LeftSide);

                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[0][0], thisDrawingPoints_forMullion_RightSide[0][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[1]);
                //    gpath_forMullion_RightSide.AddLine(thisDrawingPoints_forMullion_RightSide[2][0], thisDrawingPoints_forMullion_RightSide[2][1]);
                //    gpath_forMullion_RightSide.AddCurve(thisDrawingPoints_forMullion_RightSide[3]);

                //    g.DrawPath(pen, gpath_forMullion_RightSide);
                //    g.FillPath(Brushes.PowderBlue, gpath_forMullion_RightSide);
                //}
                //#endregion

                //#endregion

                #endregion

                #region MAIN GRAPHICS ALGORITHM without curve

                if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "First")
                #region First Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    if (zoom == 1.0f)
                    {
                        divs_bounds_values[0].Y += 1;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 4;
                        divs_bounds_values[0].Height += 4;
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Last")
                #region Last Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    int locY = fpnl.ClientRectangle.Height,
                        locY2 = pInnerY + pInnerHt;

                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                        {
                            if (zoom <= 0.26f)
                            {
                                locY = fpnl.ClientRectangle.Height;
                                locY2 = pInnerY + pInnerHt;
                            }
                            else if (zoom == 0.50f)
                            {
                                locY = fpnl.ClientRectangle.Height + 1;
                                locY2 = pInnerY + pInnerHt + 1;
                            }
                        }
                        else if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                 _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                                 _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                                 _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            if (zoom == 1.0f)
                            {
                                locY = fpnl.ClientRectangle.Height - 1;
                                locY2 = fpnl.ClientRectangle.Height - 1;
                            }
                            else if (zoom == 0.50f)
                            {
                                locY = fpnl.ClientRectangle.Height;
                                locY2 = fpnl.ClientRectangle.Height;
                            }
                            else if (zoom <= 0.26f)
                            {
                                locY = fpnl.ClientRectangle.Height - 1;
                                locY2 = fpnl.ClientRectangle.Height - 1;
                            }
                        }
                    }
                    if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7502 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._6050)
                    {
                        g.DrawLine(Pens.Black, new Point(0, locY),
                                               new Point(pInnerX, locY2));

                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, locY),
                                               new Point(pInnerX + pInnerWd, locY2));
                    }
                    else
                    {
                        g.DrawLine(Pens.Black, new Point(0, locY),
                                               new Point(pInnerX, locY2));

                        g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, locY),
                                               new Point(pInnerX + pInnerWd, locY2));

                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[1].Height += 4;
                    }
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.Fill &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between Multi-Panel in a MAIN PLATFORM (MultiTransom)
                {
                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 4;
                        divs_bounds_values[0].Height += 4;

                        divs_bounds_values[1].Height += 4;
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                #region Pattern (M-T-M)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0), new Point(pInnerX, pInnerY));

                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    int locY = fpnl.ClientRectangle.Height,
                        locY2 = pInnerY + pInnerHt;

                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            if (zoom == 1.0f || zoom <= 0.26f)
                            {
                                locY = fpnl.ClientRectangle.Height - 1;
                                locY2 = fpnl.ClientRectangle.Height - 1;
                            }
                        }
                    }

                    g.DrawLine(Pens.Black, new Point(0, locY),
                                           new Point(pInnerX, locY2));

                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;

                        divs_bounds_values[1].Height += 3;
                    }


                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divs_bounds_values[3].Width += 2;

                    if (zoom >= 0.01f && zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }


                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;
                    divs_bounds_values[3].Width += 2;

                    if (zoom >= 0.01f && zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divs_bounds_values[3].Width += 2;

                    if (zoom >= 0.01f && zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;

                        divs_bounds_values[1].Height += 3;
                    }

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    divs_bounds_values[3].Width += 2;

                    if (zoom >= 0.01f && zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;
                    }


                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {

                    int locY = fpnl.ClientRectangle.Height,
                        locY2 = pInnerY + pInnerHt;

                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (_frameModel.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._9C66 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._A166 ||
                            _frameModel.Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            if (zoom == 1.0f || zoom == 0.26f)
                            {
                                locY = fpnl.ClientRectangle.Height - 1;
                                locY2 = fpnl.ClientRectangle.Height - 1;
                            }
                        }
                    }

                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, locY),
                                           new Point(pInnerX + pInnerWd, locY2));


                    divs_bounds_values[3].Width += 2;

                    if (zoom >= 0.01f && zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }

                    if (zoom <= 0.26f)
                    {
                        divs_bounds_values[1].Height += 3;
                    }

                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 2;

                    if (zoom >= 0.01f && zoom <= 0.26f)
                    {
                        divs_bounds_values[3].Width += 1;
                    }

                    if (zoom == 0.50f)
                    {
                        divs_bounds_values[0].Y -= 2;
                        divs_bounds_values[0].Height += 2;
                    }
                    else if (zoom <= 0.26f)
                    {
                        divs_bounds_values[0].Y -= 3;
                        divs_bounds_values[0].Height += 3;

                        divs_bounds_values[1].Height += 3;
                    }

                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                #endregion

                #region Pattern (T-T-M)

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    divider_bounds_Bot = divs_bounds_values[0];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region (Last or Somewhere in Between) in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                else if (parent_name.Contains("MultiTransom") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiTransom) in a MAIN PLATFORM (MultiTransom)
                {
                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }
                    divider_bounds_Top = divs_bounds_values[1];
                }
                #endregion

                #endregion

                #region Pattern (M-M-M)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[2].X -= 2;
                    divs_bounds_values[2].Width += 2;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divs_bounds_values[3].Width += 3;

                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Mullion" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiMullion)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                #endregion

                #region Pattern (T-M-M)

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "First")
                #region First in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, 0),
                                           new Point(pInnerX, pInnerY));

                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Last")
                #region Last in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, 0),
                                           new Point(pInnerX + pInnerWd, pInnerY));

                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "First" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a FIRST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Right = divs_bounds_values[2];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "First")
                #region First in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Last")
                #region Last in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Somewhere in Between" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a SOMEWHERE IN BETWEEN SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[0].Y -= 2;
                    divs_bounds_values[0].Height += 2;

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Bot = divs_bounds_values[0];
                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "First")
                #region First in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(0, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX, pInnerY + pInnerHt));

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Last")
                #region Last in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    g.DrawLine(Pens.Black, new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                                           new Point(pInnerX + pInnerWd, pInnerY + pInnerHt));

                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                }
                #endregion

                else if (parent_name.Contains("MultiMullion") &&
                         parent_doxtyle == DockStyle.None &&
                         lvl2_parent_Type == "Transom" &&
                         parentObj_placement == "Last" &&
                         thisObj_placement == "Somewhere in Between")
                #region Somewhere in Between in a LAST SUB-PLATFORM (MultiMullion) in a MAIN PLATFORM (MultiTransom)
                {
                    divs_bounds_values[1].Height += 2;

                    divider_bounds_Top = divs_bounds_values[1];
                    divider_bounds_Left = divs_bounds_values[3];
                    divider_bounds_Right = divs_bounds_values[2];
                }
                #endregion

                #endregion

                #endregion

            }

            if (parent_name.Contains("MultiMullion") &&
                parent_doxtyle == DockStyle.None &&
                lvl2_parent_Type == "Transom")
            {
                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Top);
                g.DrawRectangle(Pens.Black, divider_bounds_Top);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Bot);
                g.DrawRectangle(Pens.Black, divider_bounds_Bot);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Left);
                g.DrawRectangle(Pens.Black, divider_bounds_Left);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Right);
                g.DrawRectangle(Pens.Black, divider_bounds_Right);
            }
            else
            {
                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Left);
                g.DrawRectangle(Pens.Black, divider_bounds_Left);

                g.FillRectangle(Brushes.RosyBrown, divider_bounds_Right);
                g.DrawRectangle(Pens.Black, divider_bounds_Right);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Top);
                g.DrawRectangle(Pens.Black, divider_bounds_Top);

                g.FillRectangle(Brushes.PowderBlue, divider_bounds_Bot);
                g.DrawRectangle(Pens.Black, divider_bounds_Bot);
            }


            g.FillRectangle(new SolidBrush(Color.MistyRose), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString(_multiPanelModel.MPanel_Name + " (" + _multiPanelModel.MPanel_Divisions + ")", drawFont, new SolidBrush(Color.Black), bounds);

            if (_timer_count != 0 && _timer_count < 8)
            {
                if (_HeightChange)
                {
                    _commonFunctions.Red_Arrow_Lines_forHeight(g, _multiPanelModel);
                }

                if (_WidthChange)
                {
                    _commonFunctions.Red_Arrow_Lines_forWidth(g, _multiPanelModel);
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

        public IMultiPanelMullionUC GetMultiPanel()
        {
            _initialLoad = true;
            _multiPanelMullionUC.ThisBinding(CreateBindingDictionary());
            ((IMultiPanelUC)_multiPanelMullionUC).GetDivEnabler().Checked = _multiPanelModel.MPanel_DividerEnabled;
            return _multiPanelMullionUC;
        }

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IUserModel userModel,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                            IMultiPanelTransomImagerUCPresenter multiTransomImagerUCP_parent)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._userModel = userModel;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;
            multiMullionUCP._frameImagerUCP = frameImagerUCP;
            multiMullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiMullionUCP._multiMullionImagerUCP = multiMullionImagerUCP;
            multiMullionUCP._multiPanelTransomImagerUCP_parent = multiTransomImagerUCP_parent;

            return multiMullionUCP;
        }

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IUserModel userModel,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                            IFrameImagerUCPresenter frameImagerUCP,
                                                            IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                            IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._userModel = userModel;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;
            multiMullionUCP._frameImagerUCP = frameImagerUCP;
            multiMullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiMullionUCP._multiMullionImagerUCP = multiMullionImagerUCP;

            return multiMullionUCP;
        }

        private IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                             IUserModel userModel,
                                                             IMultiPanelModel multiPanelModel,
                                                             IFrameModel frameModel,
                                                             IMainPresenter mainPresenter,
                                                             IFrameUCPresenter frameUCP,
                                                             IMultiPanelMullionUCPresenter multiPanelMullionUCP,
                                                             IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                             IMultiPanelPropertiesUCPresenter multiPropUCP,
                                                             IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                                             IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP,
                                                             IMultiPanelMullionImagerUCPresenter multiMullionImagerUCP_parent)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._userModel = userModel;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelMullionUCP = multiPanelMullionUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;
            multiMullionUCP._basePlatformImagerUCP = basePlatformImagerUCP;
            multiMullionUCP._multiMullionImagerUCP = multiMullionImagerUCP;
            multiMullionUCP._multiMullionImagerUCP_parent = multiMullionImagerUCP_parent;

            return multiMullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Name", new Binding("Name", _multiPanelModel, "MPanel_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Width", _multiPanelModel, "MPanel_WidthToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Height", _multiPanelModel, "MPanel_HeightToBind", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Placement", new Binding("MPanel_Placement", _multiPanelModel, "MPanel_Placement", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_CmenuDeleteVisibility", new Binding("MPanel_CmenuDeleteVisibility", _multiPanelModel, "MPanel_CmenuDeleteVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            return multiPanelBinding;
        }

        public void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt)
        {
            _frmDmRes_Width = frmDimension_numWd;
            _frmDmRes_Height = frmDimension_numHt;
            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
        }

        public void DeletePanel(UserControl obj)
        {
            ((IMultiPanelUC)_multiPanelMullionUC).DeletePanel(obj);
        }

        public void Invalidate_MultiPanelMullionUC()
        {
            ((IMultiPanelUC)_multiPanelMullionUC).InvalidateFlp();
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }

        public FlowLayoutPanel GetflpMullion()
        {
            return _multiPanelMullionUCP.GetflpMullion();
        }
    }
}