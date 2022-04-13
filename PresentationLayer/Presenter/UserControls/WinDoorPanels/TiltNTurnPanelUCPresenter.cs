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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class TiltNTurnPanelUCPresenter : ITiltNTurnPanelUCPresenter, IPresenterCommon
    {
        ITiltNTurnPanelUC _tiltNTurnPanelUC;

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

        private CommonFunctions _commonFunctions = new CommonFunctions();
        Timer _tmr = new Timer();
        bool _initialLoad;
        Color color = Color.Black;

        bool _HeightChange = false,
             _WidthChange = false;

        int prev_Width = 0,
            prev_Height = 0;

        public TiltNTurnPanelUCPresenter(ITiltNTurnPanelUC tiltNTurnPanelUC,
                                         IDividerServices divServices,
                                         ITransomUCPresenter transomUCP,
                                         IMullionUCPresenter mullionUCP,
                                         IMullionImagerUCPresenter mullionImagerUCP,
                                         ITransomImagerUCPresenter transomImagerUCP)
        {
            _tiltNTurnPanelUC = tiltNTurnPanelUC;
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
            _tiltNTurnPanelUC.tiltNturnPanelUCPaintEventRaised += _tiltNTurnPanelUC_tiltNturnPanelUCPaintEventRaised;
            _tiltNTurnPanelUC.tiltNturnPanelUCMouseEnterEventRaised += _tiltNTurnPanelUC_tiltNturnPanelUCMouseEnterEventRaised;
            _tiltNTurnPanelUC.tiltNturnPanelUCMouseLeaveEventRaised += _tiltNTurnPanelUC_tiltNturnPanelUCMouseLeaveEventRaised;
            _tiltNTurnPanelUC.deleteToolStripClickedEventRaised += _tiltNTurnPanelUC_deleteToolStripClickedEventRaised;
            _tiltNTurnPanelUC.tiltNturnPanelUCSizeChangedEventRaised += _tiltNTurnPanelUC_tiltNturnPanelUCSizeChangedEventRaised;
            _tmr.Tick += _tmr_Tick;
        }

        int _timer_count;
        private void _tmr_Tick(object sender, EventArgs e)
        {
            _timer_count++;
            if (_timer_count == 8 || _timer_count == 1)
            {
                ((IPanelUC)_tiltNTurnPanelUC).InvalidateThis();
            }
        }

        private void _tiltNTurnPanelUC_tiltNturnPanelUCSizeChangedEventRaised(object sender, EventArgs e)
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

        private void _tiltNTurnPanelUC_deleteToolStripClickedEventRaised(object sender, EventArgs e)
        {
            #region Delete Divider
            if (_multiPanelModel != null &&
                _multiPanelModel.MPanel_DividerEnabled &&
                _panelModel.Panel_Placement != "Last")
            {
                int this_indx = _multiPanelModel.MPanelLst_Objects.IndexOf((UserControl)_tiltNTurnPanelUC);

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

            #region Delete TiltNTurn

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_tiltNTurnPanelUC, _frameModel.Frame_Type.ToString());
                Control imager = _commonFunctions.FindImagerControl(_panelModel.Panel_ID, "Panel", _multiPanelModel);
                _multiPanelModel.MPanelLst_Imagers.Remove(imager);

                _multiPanelModel.Reload_PanelMargin();

                _multiPanelModel.DeductPropertyPanelHeight(_panelModel.Panel_PropertyHeight);
            }
            if (_multiPanelMullionUCP != null)
            {
                _multiPanelMullionUCP.DeletePanel((UserControl)_tiltNTurnPanelUC);
            }
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_tiltNTurnPanelUC);
            }
            if (_frameUCP != null)
            {
                _frameUCP.ViewDeleteControl((UserControl)_tiltNTurnPanelUC);
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

        private void _tiltNTurnPanelUC_tiltNturnPanelUCMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            ((IPanelUC)_tiltNTurnPanelUC).InvalidateThis();
        }

        private void _tiltNTurnPanelUC_tiltNturnPanelUCMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            ((IPanelUC)_tiltNTurnPanelUC).InvalidateThis();
        }

        private void _tiltNTurnPanelUC_tiltNturnPanelUCPaintEventRaised(object sender, PaintEventArgs e)
        {
            UserControl tiltNTurn = (UserControl)sender;

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
                pInnerWd = tiltNTurn.ClientRectangle.Width,
                pInnerHt = tiltNTurn.ClientRectangle.Height,
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

            Font drawFont = new Font("Times New Roman", font_size);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(0,
                                            (tiltNTurn.ClientRectangle.Height / 2) + 15,
                                            tiltNTurn.ClientRectangle.Width,
                                            10);

            g.DrawString("P" + _panelModel.PanelGlass_ID + "-" + _panelModel.Panel_GlassThickness.ToString() + "mm",
                         new Font("Segoe UI", 8.0f, FontStyle.Bold),
                         new SolidBrush(Color.Black),
                         rect,
                         drawFormat);

            g.DrawRectangle(new Pen(color, w), new Rectangle(0,
                                                           0,
                                                           tiltNTurn.ClientRectangle.Width - w,
                                                           tiltNTurn.ClientRectangle.Height - w));

            Color col = Color.Black;
            g.DrawRectangle(new Pen(col, w), new Rectangle(outer_line,
                                                           outer_line,
                                                           (tiltNTurn.ClientRectangle.Width - (outer_line * 2)) - w,
                                                           (tiltNTurn.ClientRectangle.Height - (outer_line * 2)) - w));

            g.DrawRectangle(new Pen(col, 3), new Rectangle(inner_line,
                                                           inner_line,
                                                           (tiltNTurn.ClientRectangle.Width - (inner_line * 2)) - w,
                                                           (tiltNTurn.ClientRectangle.Height - (inner_line * 2)) - w));


            Point sashPoint = new Point(tiltNTurn.ClientRectangle.X, tiltNTurn.ClientRectangle.Y);

            Pen dgrayPen = new Pen(Color.DimGray);
            dgrayPen.DashStyle = DashStyle.Dash;
            dgrayPen.Width = 3;

            int sashW = tiltNTurn.Width,
                sashH = tiltNTurn.Height;

            g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                     new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
            g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                                 new Point(sashPoint.X + sashW, sashPoint.Y));

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

        public ITiltNTurnPanelUC GetTiltNTurnPanelUC()
        {
            _initialLoad = true;
            _tiltNTurnPanelUC.ThisBinding(CreateBindingDictionary());
            return _tiltNTurnPanelUC;
        }


        public ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                      IPanelModel panelModel,
                                                      IFrameModel frameModel,
                                                      IMainPresenter mainPresenter,
                                                      IFrameUCPresenter frameUCP)
        {
            unityC
                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>()
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>();
            TiltNTurnPanelUCPresenter presenter = unityC.Resolve<TiltNTurnPanelUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._frameModel = frameModel;
            presenter._mainPresenter = mainPresenter;
            presenter._frameUCP = frameUCP;
            presenter._unityC = unityC;

            return presenter;
        }

        public ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelMullionUCPresenter multiPanelUCP,
                                                        IMultiPanelMullionImagerUCPresenter multiPanelMullionImagerUCP)
        {
            unityC
                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>()
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>();
            TiltNTurnPanelUCPresenter presenter = unityC.Resolve<TiltNTurnPanelUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._frameModel = frameModel;
            presenter._mainPresenter = mainPresenter;
            presenter._multiPanelModel = multiPanelModel;
            presenter._multiPanelMullionUCP = multiPanelUCP;
            presenter._unityC = unityC;
            presenter._multiPanelMullionImagerUCP = multiPanelMullionImagerUCP;

            return presenter;
        }

        public ITiltNTurnPanelUCPresenter GetNewInstance(IUnityContainer unityC,
                                                        IPanelModel panelModel,
                                                        IFrameModel frameModel,
                                                        IMainPresenter mainPresenter,
                                                        IMultiPanelModel multiPanelModel,
                                                        IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                        IMultiPanelTransomImagerUCPresenter multiPanelTransomImagerUCP)
        {
            unityC
                .RegisterType<ITiltNTurnPanelUC, TiltNTurnPanelUC>()
                .RegisterType<ITiltNTurnPanelUCPresenter, TiltNTurnPanelUCPresenter>();
            TiltNTurnPanelUCPresenter presenter = unityC.Resolve<TiltNTurnPanelUCPresenter>();
            presenter._panelModel = panelModel;
            presenter._frameModel = frameModel;
            presenter._mainPresenter = mainPresenter;
            presenter._multiPanelModel = multiPanelModel;
            presenter._multiPanelTransomUCP = multiPanelTransomUCP;
            presenter._unityC = unityC;
            presenter._multiPanelTransomImagerUCP = multiPanelTransomImagerUCP;

            return presenter;
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
