using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Dividers;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class MultiPanelMullionUCPresenter : IMultiPanelMullionUCPresenter, IPresenterCommon
    {
        IMultiPanelMullionUC _multiPanelMullionUC;

        private IUnityContainer _unityC;

        private IMultiPanelModel _multiPanelModel;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;

        private IMainPresenter _mainPresenter;
        private IFixedPanelUCPresenter _fixedUCP;
        private IFixedPanelImagerUCPresenter _fixedImagerUCP;
        private ICasementPanelUCPresenter _casementUCP;
        private IAwningPanelUCPresenter _awningUCP;
        private ISlidingPanelUCPresenter _slidingUCP;
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IfrmDimensionPresenter _frmDimensionPresenter;
        private IMullionUCPresenter _mullionUCP;
        private IFrameUCPresenter _frameUCP;
        private IMultiPanelTransomUCPresenter _multiPanelTransomUCP;
        private IMultiPanelPropertiesUCPresenter _multiPropUCP_orig;  //Original Instance
        private IMultiPanelPropertiesUCPresenter _multiPropUCP2_given; //Given Instance

        private IDividerServices _divServices;
        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;
        
        bool _initialLoad;

        public MultiPanelMullionUCPresenter(IMultiPanelMullionUC multiPanelMullionUC,
                                            IFixedPanelUCPresenter fixedUCP,
                                            ICasementPanelUCPresenter casementUCP,
                                            IAwningPanelUCPresenter awningUCP,
                                            ISlidingPanelUCPresenter slidingUCP,
                                            IPanelServices panelServices,
                                            IMultiPanelServices multipanelServices,
                                            IPanelPropertiesUCPresenter panelPropertiesUCP,
                                            IfrmDimensionPresenter frmDimensionPresenter,
                                            IFixedPanelImagerUCPresenter fixedImagerUCP,
                                            IMullionUCPresenter mullionUCP,
                                            IDividerServices divServices,
                                            IMultiPanelPropertiesUCPresenter multiPropUCP_orig)
        {
            _multiPanelMullionUC = multiPanelMullionUC;
            _fixedUCP = fixedUCP;
            _casementUCP = casementUCP;
            _awningUCP = awningUCP;
            _slidingUCP = slidingUCP;
            _panelServices = panelServices;
            _multipanelServices = multipanelServices;
            _panelPropertiesUCP = panelPropertiesUCP;
            _frmDimensionPresenter = frmDimensionPresenter;
            _fixedImagerUCP = fixedImagerUCP;
            _mullionUCP = mullionUCP;
            _divServices = divServices;
            _multiPropUCP_orig = multiPropUCP_orig;
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
        }

        private void _multiPanelMullionUC_multiMullionSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!_initialLoad)
                {
                    int thisWd = ((UserControl)sender).Width,
                        thisHt = ((UserControl)sender).Height,
                        mpnlModelWd = _multiPanelModel.MPanel_Width,
                        mpnlModelHt = _multiPanelModel.MPanel_Height;

                    if (thisWd != mpnlModelWd)
                    {
                        _multiPanelModel.MPanel_Width = thisWd;
                    }
                    if (thisHt != mpnlModelHt)
                    {
                        _multiPanelModel.MPanel_Height = thisHt;
                    }
                }
                ((UserControl)sender).Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int _frmDmRes_Width;
        private int _frmDmRes_Height;

        private void _multiPanelMullionUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int panelID = _mainPresenter.GetPanelCount() + 1,
                multiID = _mainPresenter.GetMultiPanelCount() + 1,
                divID = _mainPresenter.GetDividerCount() + 1;

            int multiPanel_boundsWD = fpnl.Width - 20,
                multiPanel_boundsHT = fpnl.Height - 18,
                divSize = 0,
                totalPanelCount = _multiPanelModel.MPanel_Divisions + 1;

            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }

            IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);
            if (data.Contains("Multi-Panel"))
            {
                int suggest_Wd = fpnl.Width,
                   suggest_HT = ((fpnl.Height - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount);

                _frmDimensionPresenter.SetPresenters(this);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.AddPanelIntoMultiPanel;
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.SetValues(suggest_Wd, suggest_HT);
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                bool frmResult = _frmDimensionPresenter.GetfrmResult();

                if (!frmResult)
                {
                    FlowDirection flow = FlowDirection.LeftToRight;
                    if (data.Contains("Transom"))
                    {
                        flow = FlowDirection.TopDown;
                    }
                    _multiPanelModel = _multipanelServices.AddMultiPanelModel(_frmDmRes_Width,
                                                                              _frmDmRes_Height,
                                                                              fpnl,
                                                                              (UserControl)_frameUCP.GetFrameUC(),
                                                                              true,
                                                                              flow,
                                                                              multiID);
                    _frameModel.Lst_MultiPanel.Add(_multiPanelModel);

                    if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                    {
                        _frameModel.Frame_Padding_int = new Padding(16);
                    }
                    else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        _frameModel.Frame_Padding_int = new Padding(23);
                    }
                    if (data.Contains("Mullion"))
                    {
                        //IMultiPanelMullionUCPresenter multiUCP = _multiMullionUCP.GetNewInstance(_unityC,
                        //                                                                         _multipanelModel,
                        //                                                                         _frameModel,
                        //                                                                         _mainPresenter,
                        //                                                                         _frameUCP);
                        //IMultiPanelMullionUC multiUC = multiUCP.GetMultiPanel();
                        //fpnl.Controls.Add((UserControl)multiUC);
                        //fpnl.Invalidate();
                        //multiUC.InvalidateFlp();
                    }
                    else if (data.Contains("Transom"))
                    {
                        //_bgImage = _multiPanelTransomUC.GetPartImageThis(_frmDmRes_Height);
                        //IMultiPanelTransomUCPresenter multiTransom = GetNewInstance(_unityC,
                        //                                                            _multiPanelModel,
                        //                                                            _frameModel,
                        //                                                            _mainPresenter,
                        //                                                            _frameUCP,
                        //                                                            _bgImage);
                        //IMultiPanelTransomUC multiUC = multiTransom.GetMultiPanel();
                        //fpnl.Controls.Add((UserControl)multiUC);
                    }
                }
            }
            else if (data == "Mullion")
            {
                IDividerModel divModel = _divServices.AddDividerModel(divSize,
                                                                      fpnl.Height,
                                                                      fpnl,
                                                                      (UserControl)_frameUCP.GetFrameUC(),
                                                                      DividerModel.DividerType.Mullion,
                                                                      true,
                                                                      divID);

                _frameModel.Lst_Divider.Add(divModel);
                _multiPanelModel.MPanelLst_Divider.Add(divModel);

                IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(_unityC, 
                                                                            divModel, 
                                                                            _multiPanelModel,
                                                                            this);
                IMullionUC mullionUC = mullionUCP.GetMullion();
                fpnl.Controls.Add((UserControl)mullionUC);
            }
            else if (data == "Transom")
            {
                MessageBox.Show("Invalid object", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int suggest_Wd = ((multiPanel_boundsWD - (divSize * _multiPanelModel.MPanel_Divisions)) / totalPanelCount),
                    suggest_HT = multiPanel_boundsHT;

                _frmDimensionPresenter.SetPresenters(this);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.AddPanelIntoMultiPanel;
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.SetValues(suggest_Wd, suggest_HT);
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();
                bool frmResult = _frmDimensionPresenter.GetfrmResult();

                if (!frmResult)
                {
                    _panelModel = _panelServices.AddPanelModel(_frmDmRes_Width,
                                                               _frmDmRes_Height,
                                                               fpnl,
                                                               (UserControl)_frameUCP.GetFrameUC(),
                                                               (UserControl)framePropUC,
                                                               (UserControl)_multiPanelMullionUC,
                                                               data,
                                                               true,
                                                               panelID,
                                                               _multiPanelModel.GetNextIndex(),
                                                               DockStyle.None);
                    _frameModel.Lst_Panel.Add(_panelModel);
                    _multiPanelModel.MPanelLst_Panel.Add(_panelModel);
                    _multiPanelModel.Reload_PanelMargin();

                    IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                    _multiPropUCP2_given.GetMultiPanelPropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());

                    _frameModel.FrameProp_Height += 148;
                    _multiPanelModel.MPanelProp_Height += 148;

                    if (data == "Fixed Panel")
                    {
                        IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC,
                                                                                   _panelModel,
                                                                                   _frameModel,
                                                                                   _mainPresenter,
                                                                                   _multiPanelModel,
                                                                                   this);
                        IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                        fpnl.Controls.Add((UserControl)fixedUC);
                        fixedUCP.SetInitialLoadFalse();

                        //IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC, _panelModel);
                        //IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
                        //pnl_inner_willRenderImg.Controls.Add((UserControl)fixedImagerUC);
                    }
                    else if (data == "Casement Panel")
                    {
                        ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(_unityC,
                                                                                            _panelModel,
                                                                                            _frameModel,
                                                                                            _mainPresenter,
                                                                                            _multiPanelModel,
                                                                                            this);
                        ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
                        fpnl.Controls.Add((UserControl)casementUC);
                        casementUCP.SetInitialLoadFalse();

                        //ICasementPanelImagerUCPresenter casementImagerUCP = _casementImagerUCP.GetNewInstance(_unityC, _panelModel);
                        //ICasementPanelImagerUC casementImagerUC = casementImagerUCP.GetCasementPanelImagerUC();
                        //pnl_inner_willRenderImg.Controls.Add((UserControl)casementImagerUC);
                    }
                    else if (data == "Awning Panel")
                    {
                        IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(_unityC,
                                                                                      _panelModel,
                                                                                      _frameModel,
                                                                                      _mainPresenter,
                                                                                      _multiPanelModel,
                                                                                      this);
                        IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
                        fpnl.Controls.Add((UserControl)awningUC);
                        awningUCP.SetInitialLoadFalse();

                        //IAwningPanelImagerUCPresenter awningImagerUCP = _awningImagerUCP.GetNewInstance(_unityC, _panelModel);
                        //IAwningPanelImagerUC awningImagerUC = awningImagerUCP.GetAwningPanelUC();
                        //pnl_inner_willRenderImg.Controls.Add((UserControl)awningImagerUC);
                    }
                    else if (data == "Sliding Panel")
                    {
                        ISlidingPanelUCPresenter slidingUCP = _slidingUCP.GetNewInstance(_unityC,
                                                                                         _panelModel,
                                                                                         _frameModel,
                                                                                         _mainPresenter,
                                                                                         _multiPanelModel,
                                                                                         this);
                        ISlidingPanelUC slidingUC = slidingUCP.GetSlidingPanelUC();
                        fpnl.Controls.Add((UserControl)slidingUC);
                        slidingUCP.SetInitialLoadFalse();

                        //ISlidingPanelImagerUCPresenter slidingImagerUCP = _slidingImagerUCP.GetNewInstance(_unityC, _panelModel);
                        //ISlidingPanelImagerUC slidingImagerUC = slidingImagerUCP.GetSlidingPanelImagerUC();
                        //pnl_inner_willRenderImg.Controls.Add((UserControl)slidingImagerUC);
                    }
                }
            }
        }

        private void _multiPanelMullionUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            _multiPanelModel.MPanel_Visibility = false;
            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                _frameModel.Frame_Type = FrameModel.Frame_Padding.Window;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                _frameModel.Frame_Type = FrameModel.Frame_Padding.Door;
            }
            foreach (IPanelModel pnl in _multiPanelModel.MPanelLst_Panel.Where(pnl => pnl.Panel_Visibility == true))
            {
                pnl.Panel_Visibility = false;
                _frameModel.FrameProp_Height -= 148;
            }
            foreach (IDividerModel div in _multiPanelModel.MPanelLst_Divider.Where(div => div.Div_Visible == true))
            {
                div.Div_Visible = false;
            }
            _frameUCP.ViewDeleteControl((UserControl)_multiPanelMullionUC);
            if (_multiPanelTransomUCP != null)
            {
                _multiPanelTransomUCP.DeletePanel((UserControl)_multiPanelMullionUC);
            }
            foreach (IMultiPanelModel mpnl in _multiPanelModel.MPanelLst_MultiPanel.Where(mpnl => mpnl.MPanel_Visibility == true))
            {
                mpnl.MPanel_Visibility = false;
                _multiPanelModel.MPanelProp_Height -= 129;
            }
            if (_multiPanelModel.MPanel_Parent != null)
            {
                _multiPanelModel.MPanelProp_Height -= 129;
                _frameModel.FrameProp_Height -= 129;
            }
        }

        private void _multiPanelMullionUC_divCountClickedEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input no. of division", "WinDoor Maker", "1");
            if (input != "" && input != "0")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        _multiPanelModel.MPanel_Divisions = int_input;
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
            _multiPanelMullionUC.InvalidateFlp();
        }

        private void _multiPanelMullionUC_flpMultiMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _multiPanelMullionUC.InvalidateFlp();
        }

        Color color = Color.Black;
        private void _multiPanelMullionUC_flpMulltiPaintEventRaised(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            Control fpnlParent = fpnl.Parent.Parent; //Parent ng mismong usercontrol, Its either Frame or Multi-Panel

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            int pInnerX = 10,
                pInnerY = 10,
                pInnerWd = fpnl.ClientRectangle.Width - 20,
                pInnerHt = fpnl.ClientRectangle.Height - 20;

            Point[] upperLine = new Point[2];
            Point[] botLine = new Point[2];
            Point[] leftCurve = new Point[3];
            Point[] rightCurve = new Point[3];

            GraphicsPath gpath = new GraphicsPath();

            int divSize = 0; //used for drawing transom object 
            if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                divSize = 24;
            }
            else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                divSize = 31;
            }

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

            Rectangle bounds = new Rectangle();
            if (_frameUCP != null && _multiPanelTransomUCP == null)
            {
                for (int i = 0; i < corner_points.Length - 1; i += 2)
                {
                    g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                }

                bounds = new Rectangle(new Point(10, 10),
                                       new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
            }
            else if (_frameUCP != null && _multiPanelTransomUCP != null)
            {
                IMultiPanelModel parent_mpnl = _multiPanelModel.MPanel_ParentModel;
                Pen pen = new Pen(Color.Black, 2);

                if (_multiPanelModel.MPanel_Placement == "First")
                {
                    Rectangle topbounds = new Rectangle(new Point(0, 0),
                                                        new Size(fpnl.Width, 10));

                    g.FillRectangle(new SolidBrush(SystemColors.Control), topbounds);

                    for (int i = 0; i < corner_points.Length - 5; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    bounds = new Rectangle(new Point(10, 10),
                                           new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 18));

                    int indx_NxtObj = _multiPanelModel.MPanel_Index_Inside_MPanel + 1;
                                                                                  
                    if (parent_mpnl.GetCount_MPanelLst_Object() > indx_NxtObj)
                    {
                        Control nxt_obj = parent_mpnl.MPanelLst_Objects[indx_NxtObj]; //Either Mpanel or Divider
                        int lineHT = (fpnl.Height - 8) + 18,
                            lineWd = fpnl.ClientRectangle.Width - 6;

                        if (!nxt_obj.Name.Contains("MultiPanel")) //Divider
                        {
                            if (nxt_obj.Name.Contains("Transom")) //Transom Divider
                            {
                                if (nxt_obj.Height == 10) //Transom.Height == 10
                                {
                                    upperLine[0] = new Point(5, fpnl.Height - 8);
                                    upperLine[1] = new Point(lineWd, fpnl.Height - 8);

                                    rightCurve[0] = new Point(lineWd, fpnl.Height - 8);
                                    rightCurve[1] = new Point(fpnl.ClientRectangle.Width - 2, (fpnl.Height - 8) + (divSize / 2));
                                    rightCurve[2] = new Point(lineWd, lineHT);

                                    botLine[0] = new Point(lineWd, lineHT);
                                    botLine[1] = new Point(5, lineHT);

                                    leftCurve[0] = new Point(5, lineHT);
                                    leftCurve[1] = new Point(1, (fpnl.Height - 8) + (divSize / 2));
                                    leftCurve[2] = new Point(5, fpnl.Height - 8);
                                }
                                else if (nxt_obj.Height == 18) //Transom.Height == 18 //Improve this algo.
                                {
                                    upperLine[0] = new Point(5, fpnl.Height - 8);
                                    upperLine[1] = new Point(lineWd + 2, fpnl.Height - 8);

                                    rightCurve[0] = new Point(lineWd + 2, fpnl.Height - 8);
                                    rightCurve[1] = new Point(fpnl.ClientRectangle.Width - 2, (fpnl.Height - (8 / 2)) + (divSize / 2));
                                    rightCurve[2] = new Point(lineWd + 2, lineHT);

                                    botLine[0] = new Point(lineWd + 2, lineHT);
                                    botLine[1] = new Point(5, lineHT);

                                    leftCurve[0] = new Point(5, lineHT);
                                    leftCurve[1] = new Point(1, (fpnl.Height - (8 / 2)) + (divSize / 2));
                                    leftCurve[2] = new Point(5, fpnl.Height - 8);
                                }
                            }
                            else if (nxt_obj.Name.Contains("Mullion"))
                            {
                                if (true)
                                {

                                }
                            }

                            gpath.AddLine(upperLine[0], upperLine[1]);
                            gpath.AddCurve(rightCurve);
                            gpath.AddLine(botLine[0], botLine[1]);
                            gpath.AddCurve(leftCurve);

                            g.DrawPath(pen, gpath);
                            g.FillPath(Brushes.PowderBlue, gpath);
                        }
                    }
                    else
                    {
                        Rectangle botbounds = new Rectangle(new Point(10, fpnl.Height - 18),
                                                            new Size(fpnl.Width - 20, 18));
                        g.DrawRectangle(new Pen(Color.Black, 1), botbounds);
                        g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), botbounds);
                    }
                }
                else if (_multiPanelModel.MPanel_Placement == "Last")
                {
                    Rectangle botbounds = new Rectangle(new Point(0, fpnl.Height - 11),
                                                        new Size(fpnl.Width, 11));
                              
                    g.FillRectangle(new SolidBrush(SystemColors.Control), botbounds);

                    for (int i = 4; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
                    }

                    bounds = new Rectangle(new Point(10, 8),
                                           new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 18));

                    int lineWd = fpnl.ClientRectangle.Width - 6,
                        Point_y = 8 - divSize;

                    upperLine[0] = new Point(6, Point_y);
                    upperLine[1] = new Point(lineWd - 1, Point_y);

                    rightCurve[0] = new Point(lineWd - 1, Point_y);
                    rightCurve[1] = new Point(fpnl.ClientRectangle.Width - 2, 8 - (divSize / 2));
                    rightCurve[2] = new Point(lineWd - 1, 8);

                    botLine[0] = new Point(lineWd - 1, 8);
                    botLine[1] = new Point(6, 8);

                    leftCurve[0] = new Point(6, 8);
                    leftCurve[1] = new Point(1, 8 - (divSize / 2));
                    leftCurve[2] = new Point(6, Point_y);

                    int indx_PrevObj = _multiPanelModel.MPanel_Index_Inside_MPanel - 1;

                    if ((parent_mpnl.MPanelLst_Objects[indx_PrevObj].Name.Contains("Transom") ||
                         parent_mpnl.MPanelLst_Objects[indx_PrevObj].Name.Contains("Mullion")) &&
                         !parent_mpnl.MPanelLst_Objects[indx_PrevObj].Name.Contains("MultiPanel"))
                    {

                        gpath.AddLine(upperLine[0], upperLine[1]);
                        gpath.AddCurve(rightCurve);
                        gpath.AddLine(botLine[0], botLine[1]);
                        gpath.AddCurve(leftCurve);

                        g.DrawPath(pen, gpath);
                        g.FillPath(Brushes.PowderBlue, gpath);
                    }
                }
            }

            g.FillRectangle(new SolidBrush(Color.White), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString(_multiPanelModel.MPanel_Name + " (" + _multiPanelModel.MPanel_Divisions + ")", drawFont, new SolidBrush(Color.Black), 10, 10);
        }

        public IMultiPanelMullionUC GetMultiPanel()
        {
            _initialLoad = true;
            _multiPanelMullionUC.ThisBinding(CreateBindingDictionary());
            return _multiPanelMullionUC;
        }

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel, 
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;

            return multiMullionUCP;
        }

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel,
                                                            IMainPresenter mainPresenter,
                                                            IFrameUCPresenter frameUCP,
                                                            IMultiPanelTransomUCPresenter multiPanelTransomUCP,
                                                            IMultiPanelPropertiesUCPresenter multiPropUCP)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;
            multiMullionUCP._frameUCP = frameUCP;
            multiMullionUCP._multiPanelTransomUCP = multiPanelTransomUCP;
            multiMullionUCP._multiPropUCP2_given = multiPropUCP;

            return multiMullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Width", _multiPanelModel, "MPanel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Height", _multiPanelModel, "MPanel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Margin", new Binding("Margin", _multiPanelModel, "MPanel_Margin", true, DataSourceUpdateMode.OnPropertyChanged));

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
            _multiPanelMullionUC.DeletePanel(obj);
            if (obj.Name.Contains("Panel"))
            {
                _multiPanelModel.MPanelProp_Height -= 148;
            }
        }

        public void Invalidate_MultiPanelMullionUC()
        {
            _multiPanelMullionUC.InvalidateFlp();
        }

        public void SetInitialLoadFalse()
        {
            _initialLoad = false;
        }
    }
}
