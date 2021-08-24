using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Panel;
using Unity;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.CommonMethods;
using ServiceLayer.Services.DividerServices;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.Dividers.Imagers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
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
            _tmr.Tick += _tmr_Tick;
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
                _panelModel.AdjustHandlePropertyHeight("addCornerDrive");
                _panelModel.AdjustRotoswingPropertyHeight("addCornerDrive");

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "addExtension");
                _panelModel.AdjustPropertyPanelHeight("addExtension");
                _panelModel.AdjustHandlePropertyHeight("addExtension");
                _panelModel.AdjustRotoswingPropertyHeight("addExtension");

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
                _panelModel.AdjustHandlePropertyHeight("minusCornerDrive");
                _panelModel.AdjustRotoswingPropertyHeight("minusCornerDrive");

                _panelModel.Panel_ParentFrameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                _panelModel.AdjustPropertyPanelHeight("minusExtension");
                _panelModel.AdjustHandlePropertyHeight("minusExtension");
                _panelModel.AdjustRotoswingPropertyHeight("minusExtension");

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

                Control divUC = _multiPanelModel.MPanelLst_Objects[this_indx + 1];
                _multiPanelModel.MPanelLst_Objects.Remove((UserControl)divUC);
                if (_multiPanelMullionUCP != null)
                {
                    _multiPanelMullionUCP.DeletePanel((UserControl)divUC);
                }
                if (_multiPanelTransomUCP != null)
                {
                    _multiPanelTransomUCP.DeletePanel((UserControl)divUC);
                }

                IDividerModel div = _multiPanelModel.MPanelLst_Divider.Find(divd => divd.Div_Name == divUC.Name);
                _mainPresenter.DeleteDividerPropertiesUC(div.Div_ID);
                div.Div_MPanelParent.MPanelLst_Divider.Remove(div);
                _frameModel.Lst_Divider.Remove(div);

                _multiPanelModel.AdjustPropertyPanelHeight("Div", "delete");
                _frameModel.AdjustPropertyPanelHeight("Div", "delete");

                foreach (int cladding in div.Div_CladdingSizeList.Values)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Div", "minusCladding");
                    _frameModel.AdjustPropertyPanelHeight("Div", "minusCladding");
                }
            }

            #endregion

            #region Delete Awning

            if (_multiPanelModel != null)
            {
                _multiPanelModel.DeleteControl_MPanelLstObjects((UserControl)_awningPanelUC, _frameModel.Frame_Type.ToString());
                _multiPanelModel.Reload_PanelMargin();

                _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusChkMotorized");

                if (_panelModel.Panel_MotorizedOptionVisibility == true)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCmbMotorized");
                }
                else if (_panelModel.Panel_MotorizedOptionVisibility == false)
                {
                    if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                    }
                    else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                    }
                    else if (_panelModel.Panel_HandleType == Handle_Type._Rio)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                    }
                    else if (_panelModel.Panel_HandleType == Handle_Type._Rotoline)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                    }
                    else if (_panelModel.Panel_HandleType == Handle_Type._MVD)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                    }

                    if (_panelModel.Panel_HandleType != Handle_Type._Rotary)
                    {
                        _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");
                    }
                }

                if (_panelModel.Panel_HandleOptionsVisibility == true)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHandle");
                }

                if (_panelModel.Panel_CornerDriveOptionsVisibility == true)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
                }

                if (_panelModel.Panel_ExtensionOptionsVisibility == true)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
                }

                int fieldExtension_count2 = 0;

                fieldExtension_count2 = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
                fieldExtension_count2 = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
                fieldExtension_count2 = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;
                fieldExtension_count2 = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count2 += 1 : fieldExtension_count2;

                for (int i = 0; i < fieldExtension_count2; i++)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
                }

                if (_panelModel.Panel_HingeOptionsVisibility == true)
                {
                    _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
                }

                _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minus");
                _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusGlass");
                _multiPanelModel.AdjustPropertyPanelHeight("Panel", "minusSash");

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
                                                        _mullionImagerUCP,
                                                        _transomImagerUCP,
                                                        _mainPresenter.GetDividerCount(),
                                                        _multiPanelModel,
                                                        _panelModel,
                                                        _multiPanelTransomUCP,
                                                        _multiPanelMullionUCP,
                                                        _multiPanelMullionImagerUCP,
                                                        _multiPanelTransomImagerUCP);
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

            _frameModel.AdjustPropertyPanelHeight("Panel", "minusChkMotorized");

            if (_panelModel.Panel_MotorizedOptionVisibility == true)
            {
                _frameModel.AdjustPropertyPanelHeight("Panel", "minusCmbMotorized");
            }
            else if (_panelModel.Panel_MotorizedOptionVisibility == false)
            {
                if (_panelModel.Panel_HandleType == Handle_Type._Rotoswing)
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusRotoswing");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotary)
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusRotary");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rio)
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusRio");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._Rotoline)
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusRotoline");
                }
                else if (_panelModel.Panel_HandleType == Handle_Type._MVD)
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusMVD");
                }

                if (_panelModel.Panel_HandleType != Handle_Type._Rotary)
                {
                    _frameModel.AdjustPropertyPanelHeight("Panel", "minusEspagnolette");
                }
            }

            if (_panelModel.Panel_HandleOptionsVisibility == true)
            {
                _frameModel.AdjustPropertyPanelHeight("Panel", "minusHandle");
            }

            if (_panelModel.Panel_CornerDriveOptionsVisibility == true)
            {
                _frameModel.AdjustPropertyPanelHeight("Panel", "minusCornerDrive");
            }

            if (_panelModel.Panel_ExtensionOptionsVisibility == true)
            {
                _frameModel.AdjustPropertyPanelHeight("Panel", "minusExtension");
            }

            int fieldExtension_count = 0;

            fieldExtension_count = (_panelModel.Panel_ExtTopChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtBotChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtLeftChk == true) ? fieldExtension_count += 1 : fieldExtension_count;
            fieldExtension_count = (_panelModel.Panel_ExtRightChk == true) ? fieldExtension_count += 1 : fieldExtension_count;

            for (int i = 0; i < fieldExtension_count; i++)
            {
                _frameModel.AdjustPropertyPanelHeight("Panel", "minusExtensionField");
            }

            if (_panelModel.Panel_HingeOptionsVisibility == true)
            {
                _frameModel.AdjustPropertyPanelHeight("Panel", "minusHinge");
            }

            _frameModel.AdjustPropertyPanelHeight("Panel", "minus");
            _frameModel.AdjustPropertyPanelHeight("Panel", "minusGlass");
            _frameModel.AdjustPropertyPanelHeight("Panel", "minusSash");

            _mainPresenter.DeductPanelGlassID();
            _mainPresenter.SetPanelGlassID();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            #endregion
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
                                            (awning.ClientRectangle.Height / 2) + 15,
                                            awning.ClientRectangle.Width,
                                            10);

            g.DrawString("P" + _panelModel.PanelGlass_ID + "-" + _panelModel.Panel_GlassThickness.ToString() + "mm",
                         new Font("Segoe UI", 8.0f, FontStyle.Bold),
                         new SolidBrush(Color.Black),
                         rect,
                         drawFormat);

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

            return panelBinding;
        }
    }
}
