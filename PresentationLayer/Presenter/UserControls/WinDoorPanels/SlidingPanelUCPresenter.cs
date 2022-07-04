using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
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
            _tmr.Tick += _tmr_Tick;
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

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));

            int outer_line = 10,
                inner_line = 15;

            int ndx_zoomPercentage = Array.IndexOf(_mainPresenter.windoorModel_MainPresenter.Arr_ZoomPercentage, _frameModel.Frame_Zoom);

            if (ndx_zoomPercentage == 2)
            {
                outer_line = 5;
                inner_line = 8;
            }
            else if (ndx_zoomPercentage == 1)
            {
                outer_line = 3;
                inner_line = 7;
            }
            else if (ndx_zoomPercentage == 0)
            {
                outer_line = 3;
                inner_line = 7;
            }

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           sliding.ClientRectangle.Width - w,
                                                           sliding.ClientRectangle.Height - w));

            Color col = Color.Black;
            g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                           outer_line,
                                                           (sliding.ClientRectangle.Width - (outer_line * 2)) - w,
                                                           (sliding.ClientRectangle.Height - (outer_line * 2)) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                           inner_line,
                                                           (sliding.ClientRectangle.Width - (inner_line * 2)) - w,
                                                           (sliding.ClientRectangle.Height - (inner_line * 2)) - w));

            Point sashPoint = new Point(sliding.ClientRectangle.X + 25, sliding.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = sliding.Width - 25,
                sashH = sliding.Height;

            float arwStart_x1 = sashPoint.X + (sashW / 20),
                  center_y1 = sashPoint.Y + (sashH / 2),
                  arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 20),
                  arwHeadUp_x3,
                  arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                  arwHeadUp_x4,
                  arwHeadUp_y4 = center_y1 + (center_y1 / 4);


            if (_panelModel.Panel_Orient == true)
            {
                arwHeadUp_x3 = sashPoint.X + arwStart_x1 + (sashW / 10);
                arwHeadUp_x4 = sashPoint.X + arwStart_x1 + (sashW / 10);


                if (_panelModel.Panel_SlidingTypes == SlidingTypes._Premiline ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._FoldAndSlide ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._Pivot ||
                    _panelModel.Panel_SlidingTypes == SlidingTypes._TopHung)
                {
                    //sliding
                    PointF sliding1 = new PointF(arwEnd_x2, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF sliding2 = new PointF(arwEnd_x2, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF sliding3 = new PointF(arwHeadUp_x4, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF sliding4 = new PointF(arwHeadUp_x4, arwHeadUp_y4);
                    PointF sliding5 = new PointF(arwStart_x1, center_y1);
                    PointF sliding6 = new PointF(arwHeadUp_x3, arwHeadUp_y3);
                    PointF sliding7 = new PointF(arwHeadUp_x3, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF[] slidingcurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

                    g.FillPolygon(new SolidBrush(Color.Black), slidingcurvePoints);
                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._Paraslide)
                {
                    //paraslide
                    PointF paraslide1 = new PointF(arwEnd_x2, arwHeadUp_y3);
                    PointF paraslide2 = new PointF(arwEnd_x2, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF paraslide3 = new PointF(arwHeadUp_x4, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF paraslide4 = new PointF(arwHeadUp_x4, arwHeadUp_y4);
                    PointF paraslide5 = new PointF(arwStart_x1, center_y1);
                    PointF paraslide6 = new PointF(arwHeadUp_x3, arwHeadUp_y3);
                    PointF paraslide7 = new PointF(arwHeadUp_x3, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF paraslide8 = new PointF(arwEnd_x2 - ((center_y1 + (arwHeadUp_y4 - center_y1) / 2) - (center_y1 - (center_y1 - arwHeadUp_y3) / 2)), center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF paraslide9 = new PointF(arwEnd_x2 - ((center_y1 + (arwHeadUp_y4 - center_y1) / 2) - (center_y1 - (center_y1 - arwHeadUp_y3) / 2)), arwHeadUp_y3);

                    PointF[] paraslideCurvePoints = { paraslide1, paraslide2, paraslide3, paraslide4, paraslide5, paraslide6, paraslide7, paraslide8, paraslide9 };

                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._LiftAndSlide)
                {
                    //LiftAndSlide
                    PointF LiftAndSlide1 = new PointF(arwEnd_x2, arwHeadUp_y4);
                    PointF LiftAndSlide2 = new PointF(arwEnd_x2, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF LiftAndSlide3 = new PointF(arwHeadUp_x4, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF LiftAndSlide4 = new PointF(arwHeadUp_x4, arwHeadUp_y4);
                    PointF LiftAndSlide5 = new PointF(arwStart_x1, center_y1);
                    PointF LiftAndSlide6 = new PointF(arwHeadUp_x3, arwHeadUp_y3);
                    PointF LiftAndSlide7 = new PointF(arwHeadUp_x3, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF LiftAndSlide8 = new PointF(arwEnd_x2 - ((center_y1 + (arwHeadUp_y4 - center_y1) / 2) - (center_y1 - (center_y1 - arwHeadUp_y3) / 2)), center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF LiftAndSlide9 = new PointF(arwEnd_x2 - ((center_y1 + (arwHeadUp_y4 - center_y1) / 2) - (center_y1 - (center_y1 - arwHeadUp_y3) / 2)), arwHeadUp_y4);

                    PointF[] paraslideCurvePoints = { LiftAndSlide1, LiftAndSlide2, LiftAndSlide7, LiftAndSlide4, LiftAndSlide5, LiftAndSlide6, LiftAndSlide3, LiftAndSlide8, LiftAndSlide9 };

                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                }


            }
            else if (_panelModel.Panel_Orient == false)
            {
                arwHeadUp_x3 = ((sashPoint.X + sashW) - arwStart_x1) - (sashW / 10);
                arwHeadUp_x4 = ((sashPoint.X + sashW) - arwStart_x1) - (sashW / 10);

                if (_panelModel.Panel_SlidingTypes == SlidingTypes._Premiline ||
                  _panelModel.Panel_SlidingTypes == SlidingTypes._FoldAndSlide ||
                  _panelModel.Panel_SlidingTypes == SlidingTypes._Pivot ||
                  _panelModel.Panel_SlidingTypes == SlidingTypes._TopHung)
                {
                    //sliding
                    PointF sliding1 = new PointF(arwStart_x1, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF sliding2 = new PointF(arwStart_x1, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF sliding3 = new PointF(arwHeadUp_x4, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF sliding4 = new PointF(arwHeadUp_x4, arwHeadUp_y4);
                    PointF sliding5 = new PointF(arwEnd_x2, center_y1);
                    PointF sliding6 = new PointF(arwHeadUp_x3, arwHeadUp_y3);
                    PointF sliding7 = new PointF(arwHeadUp_x3, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF[] slidingCurvePoints = { sliding1, sliding2, sliding3, sliding4, sliding5, sliding6, sliding7 };

                    g.FillPolygon(new SolidBrush(Color.Black), slidingCurvePoints);
                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._Paraslide)
                {
                    //paraslide
                    PointF paraslide1 = new PointF(arwStart_x1, arwHeadUp_y3);
                    PointF paraslide2 = new PointF(arwStart_x1, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF paraslide3 = new PointF(arwHeadUp_x4, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF paraslide4 = new PointF(arwHeadUp_x4, arwHeadUp_y4);
                    PointF paraslide5 = new PointF(arwEnd_x2, center_y1);
                    PointF paraslide6 = new PointF(arwHeadUp_x3, arwHeadUp_y3);
                    PointF paraslide7 = new PointF(arwHeadUp_x3, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF paraslide8 = new PointF(arwStart_x1 * 2, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF paraslide9 = new PointF(arwStart_x1 * 2, arwHeadUp_y3);

                    PointF[] paraslideCurvePoints = { paraslide1, paraslide2, paraslide3, paraslide4, paraslide5, paraslide6, paraslide7, paraslide8, paraslide9 };

                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                }
                else if (_panelModel.Panel_SlidingTypes == SlidingTypes._LiftAndSlide)
                {
                    //LiftAndSlide
                    PointF LiftAndSlide1 = new PointF(arwStart_x1, arwHeadUp_y4);
                    PointF LiftAndSlide2 = new PointF(arwStart_x1, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF LiftAndSlide3 = new PointF(arwHeadUp_x4, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF LiftAndSlide4 = new PointF(arwHeadUp_x4, arwHeadUp_y4);
                    PointF LiftAndSlide5 = new PointF(arwEnd_x2, center_y1);
                    PointF LiftAndSlide6 = new PointF(arwHeadUp_x3, arwHeadUp_y3);
                    PointF LiftAndSlide7 = new PointF(arwHeadUp_x3, center_y1 - (center_y1 - arwHeadUp_y3) / 2);
                    PointF LiftAndSlide8 = new PointF(arwStart_x1 * 2, center_y1 + (arwHeadUp_y4 - center_y1) / 2);
                    PointF LiftAndSlide9 = new PointF(arwStart_x1 * 2, arwHeadUp_y4);

                    PointF[] paraslideCurvePoints = { LiftAndSlide1, LiftAndSlide2, LiftAndSlide7, LiftAndSlide4, LiftAndSlide5, LiftAndSlide6, LiftAndSlide3, LiftAndSlide8, LiftAndSlide9 };

                    g.FillPolygon(new SolidBrush(Color.Black), paraslideCurvePoints);
                }
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
